// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
/*LCPI*/using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
//LCPI: using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Utilities;
using CA = System.Diagnostics.CodeAnalysis;

/*LCPI*/ using Microsoft.EntityFrameworkCore;
/*LCPI*/ using Microsoft.EntityFrameworkCore.Query;
/*LCPI*/ using Microsoft.EntityFrameworkCore.Query.Internal;

#nullable enable

namespace Lcpi.EXT.Microsoft.EntityFrameworkCore.Query
{
    /// <summary>
    ///     <para>
    ///         A class that processes a SQL tree based on nullability of nodes to apply null semantics in use and
    ///         optimize it based on parameter values.
    ///     </para>
    ///     <para>
    ///         This type is typically used by database providers (and other extensions). It is generally
    ///         not used in application code.
    ///     </para>
    /// </summary>
    /*LCPI: public*/ class SqlNullabilityProcessor
    {
        private readonly List<ColumnExpression> _nonNullableColumns;
        private readonly List<ColumnExpression> _nullValueColumns;
        private readonly ISqlExpressionFactory _sqlExpressionFactory;
        private bool _canCache;

        //----------------------------------------------------------------
        private readonly RelationalTypeMapping _lcpi_typeMappingForBool;

        private readonly SqlExpression _lcpi_expr_BOOL_FALSE;
        private readonly SqlExpression _lcpi_expr_BOOL_TRUE;

        //----------------------------------------------------------------
        protected enum LCPI__TransformationRule
        {
         AddNullConcatenationProtection     =100,
        };//enum LCPI__TransformationRule

        //----------------------------------------------------------------
        protected virtual bool LCPI__GetPermissionForTransformation(LCPI__TransformationRule optRule)
        {
         return true;
        }//LCPI__GetPermissionForTransformation

        //----------------------------------------------------------------
        /// <summary>
        ///     Creates a new instance of the <see cref="SqlNullabilityProcessor" /> class.
        /// </summary>
        /// <param name="dependencies"> Parameter object containing dependencies for this class. </param>
        /// <param name="useRelationalNulls"> A bool value indicating whether relational null semantics are in use. </param>
        public SqlNullabilityProcessor(
            /*LCPI: [NotNull]*/ RelationalParameterBasedSqlProcessorDependencies dependencies,
            bool useRelationalNulls)
        {
            Check.NotNull(dependencies, nameof(dependencies));

            _sqlExpressionFactory = dependencies.SqlExpressionFactory;
            UseRelationalNulls = useRelationalNulls;
            _nonNullableColumns = new List<ColumnExpression>();
            _nullValueColumns = new List<ColumnExpression>();
            ParameterValues = null!;

            _lcpi_typeMappingForBool
                =Check.NotNull
                    (dependencies.TypeMappingSource.FindMapping(typeof(bool)),
                     nameof(_lcpi_typeMappingForBool));

            _lcpi_expr_BOOL_FALSE
                =Check.NotNull
                    (LCPI__Helper__SqlENodeFactory__Constant(false,_lcpi_typeMappingForBool),
                     nameof(_lcpi_expr_BOOL_FALSE));

            _lcpi_expr_BOOL_TRUE
                =Check.NotNull
                    (LCPI__Helper__SqlENodeFactory__Constant(true,_lcpi_typeMappingForBool),
                     nameof(_lcpi_expr_BOOL_TRUE));
        }

        /// <summary>
        ///     A bool value indicating whether relational null semantics are in use.
        /// </summary>
        protected virtual bool UseRelationalNulls { get; }

        /// <summary>
        ///     Dictionary of current parameter values in use.
        /// </summary>
        protected virtual IReadOnlyDictionary<string, object?> ParameterValues { get; private set; }

        /// <summary>
        ///     Processes a <see cref="SelectExpression" /> to apply null semantics and optimize it.
        /// </summary>
        /// <param name="selectExpression"> A select expression to process. </param>
        /// <param name="parameterValues"> A dictionary of parameter values in use. </param>
        /// <param name="canCache"> A bool value indicating whether the select expression can be cached. </param>
        /// <returns> An optimized select expression. </returns>
        public virtual SelectExpression Process(
            /*LCPI: [NotNull]*/ SelectExpression selectExpression,
            /*LCPI: [NotNull]*/ IReadOnlyDictionary<string, object?> parameterValues,
            out bool canCache)
        {
            Check.NotNull(selectExpression, nameof(selectExpression));
            Check.NotNull(parameterValues, nameof(parameterValues));

            _canCache = true;
            _nonNullableColumns.Clear();
            _nullValueColumns.Clear();
            ParameterValues = parameterValues;

            var result = Visit(selectExpression);
            canCache = _canCache;

            return result;
        }

        /// <summary>
        ///     Marks the select expression being processed as cannot be cached.
        /// </summary>
        protected virtual void DoNotCache()
            => _canCache = false;

        /// <summary>
        ///     Adds a column to non nullable columns list to further optimizations can take the column as non-nullable.
        /// </summary>
        /// <param name="columnExpression"> A column expression to add. </param>
        protected virtual void AddNonNullableColumn(/*LCPI: [NotNull]*/ ColumnExpression columnExpression)
            => _nonNullableColumns.Add(Check.NotNull(columnExpression, nameof(columnExpression)));

        /// <summary>
        ///     Visits a <see cref="TableExpressionBase" />.
        /// </summary>
        /// <param name="tableExpressionBase"> A table expression base to visit. </param>
        /// <returns> An optimized table expression base. </returns>
        protected virtual TableExpressionBase Visit(/*LCPI: [NotNull]*/ TableExpressionBase tableExpressionBase)
        {
            Check.NotNull(tableExpressionBase, nameof(tableExpressionBase));

            switch (tableExpressionBase)
            {
                case CrossApplyExpression crossApplyExpression:
                    return crossApplyExpression.Update(Visit(crossApplyExpression.Table));

                case CrossJoinExpression crossJoinExpression:
                    return crossJoinExpression.Update(Visit(crossJoinExpression.Table));

                case ExceptExpression exceptExpression:
                {
                    var source1 = Visit(exceptExpression.Source1);
                    var source2 = Visit(exceptExpression.Source2);

                    return exceptExpression.Update(source1, source2);
                }

                case FromSqlExpression fromSqlExpression:
                    return fromSqlExpression;

                case InnerJoinExpression innerJoinExpression:
                {
                    var newTable = Visit(innerJoinExpression.Table);
                    var newJoinPredicate = ProcessJoinPredicate(innerJoinExpression.JoinPredicate);

                    return TryGetBoolConstantValue(newJoinPredicate) == true
                        ? (TableExpressionBase)new CrossJoinExpression(newTable)
                        : innerJoinExpression.Update(newTable, newJoinPredicate);
                }

                case IntersectExpression intersectExpression:
                {
                    var source1 = Visit(intersectExpression.Source1);
                    var source2 = Visit(intersectExpression.Source2);

                    return intersectExpression.Update(source1, source2);
                }

                case LeftJoinExpression leftJoinExpression:
                {
                    var newTable = Visit(leftJoinExpression.Table);
                    var newJoinPredicate = ProcessJoinPredicate(leftJoinExpression.JoinPredicate);

                    return leftJoinExpression.Update(newTable, newJoinPredicate);
                }

                case OuterApplyExpression outerApplyExpression:
                    return outerApplyExpression.Update(Visit(outerApplyExpression.Table));

                case SelectExpression selectExpression:
                    return Visit(selectExpression);

                case TableValuedFunctionExpression tableValuedFunctionExpression:
                {
                    var arguments = new List<SqlExpression>();
                    foreach (var argument in tableValuedFunctionExpression.Arguments)
                    {
                        arguments.Add(Visit(argument, out _));
                    }

                    return tableValuedFunctionExpression.Update(arguments);
                }

                case TableExpression tableExpression:
                    return tableExpression;

                case UnionExpression unionExpression:
                {
                    var source1 = Visit(unionExpression.Source1);
                    var source2 = Visit(unionExpression.Source2);

                    return unionExpression.Update(source1, source2);
                }

                default:
                    throw new InvalidOperationException(
                        RelationalStrings.UnhandledExpressionInVisitor(
                            tableExpressionBase, tableExpressionBase.GetType(), nameof(SqlNullabilityProcessor)));
            }
        }

        /// <summary>
        ///     Visits a <see cref="SelectExpression" />.
        /// </summary>
        /// <param name="selectExpression"> A select expression to visit. </param>
        /// <returns> An optimized select expression. </returns>
        protected virtual SelectExpression Visit(/*LCPI: [NotNull]*/ SelectExpression selectExpression)
        {
            Check.NotNull(selectExpression, nameof(selectExpression));

            var changed = false;
            var projections = (List<ProjectionExpression>)selectExpression.Projection;
            for (var i = 0; i < selectExpression.Projection.Count; i++)
            {
                var item = selectExpression.Projection[i];
                var projection = item.Update(Visit(item.Expression, out _));
                if (projection != item
                    && projections == selectExpression.Projection)
                {
                    projections = new List<ProjectionExpression>();
                    for (var j = 0; j < i; j++)
                    {
                        projections.Add(selectExpression.Projection[j]);
                    }

                    changed = true;
                }

                if (projections != selectExpression.Projection)
                {
                    projections.Add(projection);
                }
            }

            var tables = (List<TableExpressionBase>)selectExpression.Tables;
            for (var i = 0; i < selectExpression.Tables.Count; i++)
            {
                var item = selectExpression.Tables[i];
                var table = Visit(item);
                if (table != item
                    && tables == selectExpression.Tables)
                {
                    tables = new List<TableExpressionBase>();
                    for (var j = 0; j < i; j++)
                    {
                        tables.Add(selectExpression.Tables[j]);
                    }

                    changed = true;
                }

                if (tables != selectExpression.Tables)
                {
                    tables.Add(table);
                }
            }

            var predicate = Visit(selectExpression.Predicate, allowOptimizedExpansion: true, out _);
            changed |= predicate != selectExpression.Predicate;

            if (TryGetBoolConstantValue(predicate) == true)
            {
                predicate = null;
                changed = true;
            }

            var groupBy = (List<SqlExpression>)selectExpression.GroupBy;
            for (var i = 0; i < selectExpression.GroupBy.Count; i++)
            {
                var item = selectExpression.GroupBy[i];
                var groupingKey = Visit(item, out _);
                if (groupingKey != item
                    && groupBy == selectExpression.GroupBy)
                {
                    groupBy = new List<SqlExpression>();
                    for (var j = 0; j < i; j++)
                    {
                        groupBy.Add(selectExpression.GroupBy[j]);
                    }

                    changed = true;
                }

                if (groupBy != selectExpression.GroupBy)
                {
                    groupBy.Add(groupingKey);
                }
            }

            var having = Visit(selectExpression.Having, allowOptimizedExpansion: true, out _);
            changed |= having != selectExpression.Having;

            if (TryGetBoolConstantValue(having) == true)
            {
                having = null;
                changed = true;
            }

            var orderings = (List<OrderingExpression>)selectExpression.Orderings;
            for (var i = 0; i < selectExpression.Orderings.Count; i++)
            {
                var item = selectExpression.Orderings[i];
                var ordering = item.Update(Visit(item.Expression, out _));
                if (ordering != item
                    && orderings == selectExpression.Orderings)
                {
                    orderings = new List<OrderingExpression>();
                    for (var j = 0; j < i; j++)
                    {
                        orderings.Add(selectExpression.Orderings[j]);
                    }

                    changed = true;
                }

                if (orderings != selectExpression.Orderings)
                {
                    orderings.Add(ordering);
                }
            }

            var offset = Visit(selectExpression.Offset, out _);
            changed |= offset != selectExpression.Offset;

            var limit = Visit(selectExpression.Limit, out _);
            changed |= limit != selectExpression.Limit;

            return changed
                ? selectExpression.Update(
                    projections, tables, predicate, groupBy, having, orderings, limit, offset)
                : selectExpression;
        }

        /// <summary>
        ///     Visits a <see cref="SqlExpression" /> and computes its nullability.
        /// </summary>
        /// <param name="sqlExpression"> A sql expression to visit. </param>
        /// <param name="nullable"> A bool value indicating whether the sql expression is nullable. </param>
        /// <returns> An optimized sql expression. </returns>
        [return: CA.NotNullIfNotNull("sqlExpression")]
        protected virtual SqlExpression? Visit(/*LCPI: [CanBeNull]*/ SqlExpression? sqlExpression, out bool nullable)
            => Visit(sqlExpression, allowOptimizedExpansion: false, out nullable);

        /// <summary>
        ///     Visits a <see cref="SqlExpression" /> and computes its nullability.
        /// </summary>
        /// <param name="sqlExpression"> A sql expression to visit. </param>
        /// <param name="allowOptimizedExpansion"> A bool value indicating if optimized expansion which considers null value as false value is allowed. </param>
        /// <param name="nullable"> A bool value indicating whether the sql expression is nullable. </param>
        /// <returns> An optimized sql expression. </returns>
        [return: CA.NotNullIfNotNull("sqlExpression")]
        protected virtual SqlExpression? Visit(/*LCPI: [CanBeNull]*/ SqlExpression? sqlExpression, bool allowOptimizedExpansion, out bool nullable)
            => Visit(sqlExpression, allowOptimizedExpansion, preserveColumnNullabilityInformation: false, out nullable);

        [return: CA.NotNullIfNotNull("sqlExpression")]
        private SqlExpression? Visit(
            /*LCPI: [CanBeNull]*/ SqlExpression? sqlExpression,
            bool allowOptimizedExpansion,
            bool preserveColumnNullabilityInformation,
            out bool nullable)
        {
            if (sqlExpression == null)
            {
                nullable = false;
                return sqlExpression;
            }

            var nonNullableColumnsCount = _nonNullableColumns.Count;
            var nullValueColumnsCount = _nullValueColumns.Count;
            var result = sqlExpression switch
            {
                CaseExpression caseExpression
                => VisitCase(caseExpression, allowOptimizedExpansion, out nullable),
                CollateExpression collateExpression
                => VisitCollate(collateExpression, allowOptimizedExpansion, out nullable),
                ColumnExpression columnExpression
                => VisitColumn(columnExpression, allowOptimizedExpansion, out nullable),
                DistinctExpression distinctExpression
                => VisitDistinct(distinctExpression, allowOptimizedExpansion, out nullable),
                ExistsExpression existsExpression
                => VisitExists(existsExpression, allowOptimizedExpansion, out nullable),
                InExpression inExpression
                => VisitIn(inExpression, allowOptimizedExpansion, out nullable),
                LikeExpression likeExpression
                => VisitLike(likeExpression, allowOptimizedExpansion, out nullable),
                RowNumberExpression rowNumberExpression
                => VisitRowNumber(rowNumberExpression, allowOptimizedExpansion, out nullable),
                ScalarSubqueryExpression scalarSubqueryExpression
                => VisitScalarSubquery(scalarSubqueryExpression, allowOptimizedExpansion, out nullable),
                SqlBinaryExpression sqlBinaryExpression
                => VisitSqlBinary(sqlBinaryExpression, allowOptimizedExpansion, out nullable),
                SqlConstantExpression sqlConstantExpression
                => VisitSqlConstant(sqlConstantExpression, allowOptimizedExpansion, out nullable),
                SqlFragmentExpression sqlFragmentExpression
                => VisitSqlFragment(sqlFragmentExpression, allowOptimizedExpansion, out nullable),
                SqlFunctionExpression sqlFunctionExpression
                => VisitSqlFunction(sqlFunctionExpression, allowOptimizedExpansion, out nullable),
                SqlParameterExpression sqlParameterExpression
                => VisitSqlParameter(sqlParameterExpression, allowOptimizedExpansion, out nullable),
                SqlUnaryExpression sqlUnaryExpression
                => VisitSqlUnary(sqlUnaryExpression, allowOptimizedExpansion, out nullable),
                _ => VisitCustomSqlExpression(sqlExpression, allowOptimizedExpansion, out nullable)
            };

            if (!preserveColumnNullabilityInformation)
            {
                RestoreNonNullableColumnsList(nonNullableColumnsCount);
                RestoreNullValueColumnsList(nullValueColumnsCount);
            }

            return result;
        }

        /// <summary>
        ///     Visits a custom <see cref="SqlExpression" /> added by providers and computes its nullability.
        /// </summary>
        /// <param name="sqlExpression"> A sql expression to visit. </param>
        /// <param name="allowOptimizedExpansion"> A bool value indicating if optimized expansion which considers null value as false value is allowed. </param>
        /// <param name="nullable"> A bool value indicating whether the sql expression is nullable. </param>
        /// <returns> An optimized sql expression. </returns>
        protected virtual SqlExpression VisitCustomSqlExpression(
            /*LCPI: [NotNull]*/ SqlExpression sqlExpression,
            bool allowOptimizedExpansion,
            out bool nullable)
            => throw new InvalidOperationException(
                RelationalStrings.UnhandledExpressionInVisitor(sqlExpression, sqlExpression.GetType(), nameof(SqlNullabilityProcessor)));

        /// <summary>
        ///     Visits a <see cref="CaseExpression" /> and computes its nullability.
        /// </summary>
        /// <param name="caseExpression"> A case expression to visit. </param>
        /// <param name="allowOptimizedExpansion"> A bool value indicating if optimized expansion which considers null value as false value is allowed. </param>
        /// <param name="nullable"> A bool value indicating whether the sql expression is nullable. </param>
        /// <returns> An optimized sql expression. </returns>
        protected virtual SqlExpression VisitCase(/*LCPI: [NotNull]*/ CaseExpression caseExpression, bool allowOptimizedExpansion, out bool nullable)
        {
            Check.NotNull(caseExpression, nameof(caseExpression));

            // if there is no 'else' there is a possibility of null, when none of the conditions are met
            // otherwise the result is nullable if any of the WhenClause results OR ElseResult is nullable
            nullable = caseExpression.ElseResult == null;
            var currentNonNullableColumnsCount = _nonNullableColumns.Count;
            var currentNullValueColumnsCount = _nullValueColumns.Count;

            var operand = Visit(caseExpression.Operand, out _);
            var whenClauses = new List<CaseWhenClause>();
            var testIsCondition = caseExpression.Operand == null;

            var testEvaluatesToTrue = false;
            foreach (var whenClause in caseExpression.WhenClauses)
            {
                // we can use column nullability information we got from visiting Test, in the Result
                var test = Visit(whenClause.Test, allowOptimizedExpansion: testIsCondition, preserveColumnNullabilityInformation: true, out _);

                if (TryGetBoolConstantValue(test) is bool testConstantBool)
                {
                    if (testConstantBool)
                    {
                        testEvaluatesToTrue = true;
                    }
                    else
                    {
                        // if test evaluates to 'false' we can remove the WhenClause
                        RestoreNonNullableColumnsList(currentNonNullableColumnsCount);
                        RestoreNullValueColumnsList(currentNullValueColumnsCount);

                        continue;
                    }
                }

                var newResult = Visit(whenClause.Result, out var resultNullable);

                nullable |= resultNullable;
                whenClauses.Add(new CaseWhenClause(test, newResult));
                RestoreNonNullableColumnsList(currentNonNullableColumnsCount);
                RestoreNullValueColumnsList(currentNonNullableColumnsCount);

                // if test evaluates to 'true' we can remove every condition that comes after, including ElseResult
                if (testEvaluatesToTrue)
                {
                    break;
                }
            }

            SqlExpression? elseResult = null;
            if (!testEvaluatesToTrue)
            {
                elseResult = Visit(caseExpression.ElseResult, out var elseResultNullable);
                nullable |= elseResultNullable;
            }

            RestoreNonNullableColumnsList(currentNonNullableColumnsCount);
            RestoreNullValueColumnsList(currentNullValueColumnsCount);

            // if there are no whenClauses left (e.g. their tests evaluated to false):
            // - if there is Else block, return it
            // - if there is no Else block, return null
            if (whenClauses.Count == 0)
            {
                return elseResult ?? LCPI__Helper__SqlENodeFactory__Constant(null, caseExpression.TypeMapping);
            }

            // if there is only one When clause and it's test evaluates to 'true' AND there is no else block, simply return the result
            return elseResult == null
                && whenClauses.Count == 1
                && TryGetBoolConstantValue(whenClauses[0].Test) == true
                    ? whenClauses[0].Result
                    : caseExpression.Update(operand, whenClauses, elseResult);
        }

        /// <summary>
        ///     Visits a <see cref="CollateExpression" /> and computes its nullability.
        /// </summary>
        /// <param name="collateExpression"> A collate expression to visit. </param>
        /// <param name="allowOptimizedExpansion"> A bool value indicating if optimized expansion which considers null value as false value is allowed. </param>
        /// <param name="nullable"> A bool value indicating whether the sql expression is nullable. </param>
        /// <returns> An optimized sql expression. </returns>
        protected virtual SqlExpression VisitCollate(
            /*LCPI: [NotNull]*/ CollateExpression collateExpression,
            bool allowOptimizedExpansion,
            out bool nullable)
        {
            Check.NotNull(collateExpression, nameof(collateExpression));

            return collateExpression.Update(Visit(collateExpression.Operand, out nullable));
        }

        /// <summary>
        ///     Visits a <see cref="ColumnExpression" /> and computes its nullability.
        /// </summary>
        /// <param name="columnExpression"> A column expression to visit. </param>
        /// <param name="allowOptimizedExpansion"> A bool value indicating if optimized expansion which considers null value as false value is allowed. </param>
        /// <param name="nullable"> A bool value indicating whether the sql expression is nullable. </param>
        /// <returns> An optimized sql expression. </returns>
        protected virtual SqlExpression VisitColumn(
            /*LCPI: [NotNull]*/ ColumnExpression columnExpression,
            bool allowOptimizedExpansion,
            out bool nullable)
        {
            Check.NotNull(columnExpression, nameof(columnExpression));

            nullable = columnExpression.IsNullable && !_nonNullableColumns.Contains(columnExpression);

            return columnExpression;
        }

        /// <summary>
        ///     Visits a <see cref="DistinctExpression" /> and computes its nullability.
        /// </summary>
        /// <param name="distinctExpression"> A collate expression to visit. </param>
        /// <param name="allowOptimizedExpansion"> A bool value indicating if optimized expansion which considers null value as false value is allowed. </param>
        /// <param name="nullable"> A bool value indicating whether the sql expression is nullable. </param>
        /// <returns> An optimized sql expression. </returns>
        protected virtual SqlExpression VisitDistinct(
            /*LCPI: [NotNull]*/ DistinctExpression distinctExpression,
            bool allowOptimizedExpansion,
            out bool nullable)
        {
            Check.NotNull(distinctExpression, nameof(distinctExpression));

            return distinctExpression.Update(Visit(distinctExpression.Operand, out nullable));
        }

        /// <summary>
        ///     Visits an <see cref="ExistsExpression" /> and computes its nullability.
        /// </summary>
        /// <param name="existsExpression"> An exists expression to visit. </param>
        /// <param name="allowOptimizedExpansion"> A bool value indicating if optimized expansion which considers null value as false value is allowed. </param>
        /// <param name="nullable"> A bool value indicating whether the sql expression is nullable. </param>
        /// <returns> An optimized sql expression. </returns>
        protected virtual SqlExpression VisitExists(
            /*LCPI: [NotNull]*/ ExistsExpression existsExpression,
            bool allowOptimizedExpansion,
            out bool nullable)
        {
            Check.NotNull(existsExpression, nameof(existsExpression));

            var subquery = Visit(existsExpression.Subquery);
            nullable = false;

            // if subquery has predicate which evaluates to false, we can simply return false
            // if the exisits is negated we need to return true instead
            return TryGetBoolConstantValue(subquery.Predicate) == false
                ? LCPI__Helper__SqlENodeFactory__BoolConstant(existsExpression.IsNegated)
                : existsExpression.Update(subquery);
        }

        /// <summary>
        ///     Visits an <see cref="InExpression" /> and computes its nullability.
        /// </summary>
        /// <param name="inExpression"> An in expression to visit. </param>
        /// <param name="allowOptimizedExpansion"> A bool value indicating if optimized expansion which considers null value as false value is allowed. </param>
        /// <param name="nullable"> A bool value indicating whether the sql expression is nullable. </param>
        /// <returns> An optimized sql expression. </returns>
        protected virtual SqlExpression VisitIn(/*LCPI: [NotNull]*/ InExpression inExpression, bool allowOptimizedExpansion, out bool nullable)
        {
            Check.NotNull(inExpression, nameof(inExpression));

            var item = Visit(inExpression.Item, out var itemNullable);

            if (inExpression.Subquery != null)
            {
                var subquery = Visit(inExpression.Subquery);

                // a IN (SELECT * FROM table WHERE false) => false
                if (TryGetBoolConstantValue(subquery.Predicate) == false)
                {
                    nullable = false;

                    return subquery.Predicate!;
                }

                // if item is not nullable, and subquery contains a non-nullable column we know the result can never be null
                // note: in this case we could broaden the optimization if we knew the nullability of the projection
                // but we don't keep that information and we want to avoid double visitation
                nullable = !(!itemNullable
                    && subquery.Projection.Count == 1
                    && subquery.Projection[0].Expression is ColumnExpression columnProjection
                    && !columnProjection.IsNullable);

                return inExpression.Update(item, values: null, subquery);
            }

            // for relational null semantics we don't need to extract null values from the array
            if (UseRelationalNulls
                || !(inExpression.Values is SqlConstantExpression || inExpression.Values is SqlParameterExpression))
            {
                var (valuesExpression, valuesList, _) = ProcessInExpressionValues(inExpression.Values!, extractNullValues: false);
                nullable = false;

                return valuesList.Count == 0
                    ? LCPI__Helper__SqlENodeFactory__BoolConstant(false)
                    : SimplifyInExpression(
                        inExpression.Update(item, valuesExpression, subquery: null),
                        valuesExpression,
                        valuesList);
            }

            // for c# null semantics we need to remove nulls from Values and add IsNull/IsNotNull when necessary
            var (inValuesExpression, inValuesList, hasNullValue) = ProcessInExpressionValues(inExpression.Values, extractNullValues: true);

            // either values array is empty or only contains null
            if (inValuesList.Count == 0)
            {
                nullable = false;

                // a IN () -> false
                // non_nullable IN (NULL) -> false
                // a NOT IN () -> true
                // non_nullable NOT IN (NULL) -> true
                // nullable IN (NULL) -> nullable IS NULL
                // nullable NOT IN (NULL) -> nullable IS NOT NULL
                return !hasNullValue || !itemNullable
                    ? LCPI__Helper__SqlENodeFactory__BoolConstant(inExpression.IsNegated)
                    : inExpression.IsNegated
                        ? LCPI__Helper__SqlENodeFactory__IsNotNull(item)
                        : LCPI__Helper__SqlENodeFactory__IsNull(item);
            }

            var simplifiedInExpression = SimplifyInExpression(
                inExpression.Update(item, inValuesExpression, subquery: null),
                inValuesExpression,
                inValuesList);

            if (!itemNullable
                || (allowOptimizedExpansion && !inExpression.IsNegated && !hasNullValue))
            {
                nullable = false;

                // non_nullable IN (1, 2) -> non_nullable IN (1, 2)
                // non_nullable IN (1, 2, NULL) -> non_nullable IN (1, 2)
                // non_nullable NOT IN (1, 2) -> non_nullable NOT IN (1, 2)
                // non_nullable NOT IN (1, 2, NULL) -> non_nullable NOT IN (1, 2)
                // nullable IN (1, 2) -> nullable IN (1, 2) (optimized)
                return simplifiedInExpression;
            }

            nullable = false;

            // nullable IN (1, 2) -> nullable IN (1, 2) AND nullable IS NOT NULL (full)
            // nullable IN (1, 2, NULL) -> nullable IN (1, 2) OR nullable IS NULL (full)
            // nullable NOT IN (1, 2) -> nullable NOT IN (1, 2) OR nullable IS NULL (full)
            // nullable NOT IN (1, 2, NULL) -> nullable NOT IN (1, 2) AND nullable IS NOT NULL (full)

            if(inExpression.IsNegated == hasNullValue)
            {
                return LCPI__Helper__SqlENodeFactory__AndAlso(
                    simplifiedInExpression,
                    LCPI__Helper__SqlENodeFactory__IsNotNull(item));
            }

            return LCPI__Helper__SqlENodeFactory__OrElse(
                    simplifiedInExpression,
                    LCPI__Helper__SqlENodeFactory__IsNull(item));

            (SqlConstantExpression ProcessedValuesExpression, List<object?> ProcessedValuesList, bool HasNullValue)
                ProcessInExpressionValues(SqlExpression valuesExpression, bool extractNullValues)
            {
                var inValues = new List<object?>();
                var hasNullValue = false;
                RelationalTypeMapping? typeMapping = null;

                IEnumerable? values = null;
                if (valuesExpression is SqlConstantExpression sqlConstant)
                {
                    typeMapping = sqlConstant.TypeMapping;
                    values = (IEnumerable)sqlConstant.Value!;
                }
                else if (valuesExpression is SqlParameterExpression sqlParameter)
                {
                    DoNotCache();
                    typeMapping = sqlParameter.TypeMapping;
                    values = (IEnumerable?)ParameterValues[sqlParameter.Name];
                    if (values == null)
                    {
                        throw new NullReferenceException();
                    }
                }

                foreach (var value in values!)
                {
                    if (value == null && extractNullValues)
                    {
                        hasNullValue = true;
                        continue;
                    }

                    inValues.Add(value);
                }

                var processedValuesExpression = LCPI__Helper__SqlENodeFactory__Constant(inValues, typeMapping);

                return (processedValuesExpression, inValues, hasNullValue);
            }

            SqlExpression SimplifyInExpression(
                InExpression inExpression,
                SqlConstantExpression inValuesExpression,
                List<object?> inValuesList)
            {
                return inValuesList.Count == 1
                    ? inExpression.IsNegated
                        ? LCPI__Helper__SqlENodeFactory__NotEqual(
                            inExpression.Item,
                            LCPI__Helper__SqlENodeFactory__Constant(inValuesList[0], inValuesExpression.TypeMapping))
                        : LCPI__Helper__SqlENodeFactory__Equal(
                            inExpression.Item,
                            LCPI__Helper__SqlENodeFactory__Constant(inValuesList[0], inExpression.Values!.TypeMapping))
                    : inExpression;
            }
        }

        /// <summary>
        ///     Visits a <see cref="LikeExpression" /> and computes its nullability.
        /// </summary>
        /// <param name="likeExpression"> A like expression to visit. </param>
        /// <param name="allowOptimizedExpansion"> A bool value indicating if optimized expansion which considers null value as false value is allowed. </param>
        /// <param name="nullable"> A bool value indicating whether the sql expression is nullable. </param>
        /// <returns> An optimized sql expression. </returns>
        protected virtual SqlExpression VisitLike(/*LCPI: [NotNull]*/ LikeExpression likeExpression, bool allowOptimizedExpansion, out bool nullable)
        {
            Check.NotNull(likeExpression, nameof(likeExpression));

            var match = Visit(likeExpression.Match, out var matchNullable);
            var pattern = Visit(likeExpression.Pattern, out var patternNullable);
            var escapeChar = Visit(likeExpression.EscapeChar, out var escapeCharNullable);

            nullable = matchNullable || patternNullable || escapeCharNullable;

            return likeExpression.Update(match, pattern, escapeChar);
        }

        /// <summary>
        ///     Visits a <see cref="RowNumberExpression" /> and computes its nullability.
        /// </summary>
        /// <param name="rowNumberExpression"> A row number expression to visit. </param>
        /// <param name="allowOptimizedExpansion"> A bool value indicating if optimized expansion which considers null value as false value is allowed. </param>
        /// <param name="nullable"> A bool value indicating whether the sql expression is nullable. </param>
        /// <returns> An optimized sql expression. </returns>
        protected virtual SqlExpression VisitRowNumber(
            /*LCPI: [NotNull]*/ RowNumberExpression rowNumberExpression,
            bool allowOptimizedExpansion,
            out bool nullable)
        {
            Check.NotNull(rowNumberExpression, nameof(rowNumberExpression));

            var changed = false;
            var partitions = new List<SqlExpression>();
            foreach (var partition in rowNumberExpression.Partitions)
            {
                var newPartition = Visit(partition, out _);
                changed |= newPartition != partition;
                partitions.Add(newPartition);
            }

            var orderings = new List<OrderingExpression>();
            foreach (var ordering in rowNumberExpression.Orderings)
            {
                var newOrdering = ordering.Update(Visit(ordering.Expression, out _));
                changed |= newOrdering != ordering;
                orderings.Add(newOrdering);
            }

            nullable = false;

            return changed
                ? rowNumberExpression.Update(partitions, orderings)
                : rowNumberExpression;
        }

        /// <summary>
        ///     Visits a <see cref="ScalarSubqueryExpression" /> and computes its nullability.
        /// </summary>
        /// <param name="scalarSubqueryExpression"> A scalar subquery expression to visit. </param>
        /// <param name="allowOptimizedExpansion"> A bool value indicating if optimized expansion which considers null value as false value is allowed. </param>
        /// <param name="nullable"> A bool value indicating whether the sql expression is nullable. </param>
        /// <returns> An optimized sql expression. </returns>
        protected virtual SqlExpression VisitScalarSubquery(
            /*LCPI: [NotNull]*/ ScalarSubqueryExpression scalarSubqueryExpression,
            bool allowOptimizedExpansion,
            out bool nullable)
        {
            Check.NotNull(scalarSubqueryExpression, nameof(scalarSubqueryExpression));

            nullable = true;

            return scalarSubqueryExpression.Update(Visit(scalarSubqueryExpression.Subquery));
        }

        /// <summary>
        ///     Visits a <see cref="SqlBinaryExpression" /> and computes its nullability.
        /// </summary>
        /// <param name="sqlBinaryExpression"> A sql binary expression to visit. </param>
        /// <param name="allowOptimizedExpansion"> A bool value indicating if optimized expansion which considers null value as false value is allowed. </param>
        /// <param name="nullable"> A bool value indicating whether the sql expression is nullable. </param>
        /// <returns> An optimized sql expression. </returns>
        protected virtual SqlExpression VisitSqlBinary(
            /*LCPI: [NotNull]*/ SqlBinaryExpression sqlBinaryExpression,
            bool allowOptimizedExpansion,
            out bool nullable)
        {
            Check.NotNull(sqlBinaryExpression, nameof(sqlBinaryExpression));

            var optimize = allowOptimizedExpansion;

            allowOptimizedExpansion = allowOptimizedExpansion
                && (sqlBinaryExpression.OperatorType == ExpressionType.AndAlso
                    || sqlBinaryExpression.OperatorType == ExpressionType.OrElse);

            var currentNonNullableColumnsCount = _nonNullableColumns.Count;
            var currentNullValueColumnsCount = _nullValueColumns.Count;

            var left = Visit(sqlBinaryExpression.Left, allowOptimizedExpansion, preserveColumnNullabilityInformation: true, out var leftNullable);

            var leftNonNullableColumns = _nonNullableColumns.Skip(currentNonNullableColumnsCount).ToList();
            var leftNullValueColumns = _nullValueColumns.Skip(currentNullValueColumnsCount).ToList();
            if (sqlBinaryExpression.OperatorType != ExpressionType.AndAlso)
            {
                RestoreNonNullableColumnsList(currentNonNullableColumnsCount);
            }

            if (sqlBinaryExpression.OperatorType == ExpressionType.OrElse)
            {
                // in case of OrElse, we can assume all null value columns on the left side can be treated as non-nullable on the right
                // e.g. (a == null || b == null) || f(a, b)
                // f(a, b) will only be executed if a != null and b != null
                _nonNullableColumns.AddRange(_nullValueColumns.Skip(currentNullValueColumnsCount).ToList());
            }
            else
            {
                RestoreNullValueColumnsList(currentNullValueColumnsCount);
            }

            var right = Visit(sqlBinaryExpression.Right, allowOptimizedExpansion, preserveColumnNullabilityInformation: true, out var rightNullable);

            if (sqlBinaryExpression.OperatorType == ExpressionType.OrElse)
            {
                var intersect = leftNonNullableColumns.Intersect(_nonNullableColumns.Skip(currentNonNullableColumnsCount)).ToList();
                RestoreNonNullableColumnsList(currentNonNullableColumnsCount);
                _nonNullableColumns.AddRange(intersect);
            }
            else if (sqlBinaryExpression.OperatorType != ExpressionType.AndAlso)
            {
                // in case of AndAlso we already have what we need as the column information propagates from left to right
                RestoreNonNullableColumnsList(currentNonNullableColumnsCount);
            }

            if (sqlBinaryExpression.OperatorType == ExpressionType.AndAlso)
            {
                var intersect = leftNullValueColumns.Intersect(_nullValueColumns.Skip(currentNullValueColumnsCount)).ToList();
                RestoreNullValueColumnsList(currentNullValueColumnsCount);
                _nullValueColumns.AddRange(intersect);
            }
            else if (sqlBinaryExpression.OperatorType != ExpressionType.OrElse)
            {
                RestoreNullValueColumnsList(currentNullValueColumnsCount);
            }

            // nullableStringColumn + a -> COALESCE(nullableStringColumn, "") + a
            if (sqlBinaryExpression.OperatorType == ExpressionType.Add
                && sqlBinaryExpression.Type == typeof(string))
            {
                /*LCPI CODE:*/ if (!this.LCPI__GetPermissionForTransformation(LCPI__TransformationRule.AddNullConcatenationProtection))
                /*LCPI CODE:*/ {
                /*LCPI CODE:*/     nullable = true;
                /*LCPI CODE:*/
                /*LCPI CODE:*/     return sqlBinaryExpression.Update(left, right);
                /*LCPI CODE:*/ }//if

                if (leftNullable)
                {
                    left = AddNullConcatenationProtection(left, sqlBinaryExpression.TypeMapping!);
                }

                if (rightNullable)
                {
                    right = AddNullConcatenationProtection(right, sqlBinaryExpression.TypeMapping!);
                }

                nullable = false;

                return sqlBinaryExpression.Update(left, right);
            }

            if (sqlBinaryExpression.OperatorType == ExpressionType.Equal
                || sqlBinaryExpression.OperatorType == ExpressionType.NotEqual)
            {
                var updated = sqlBinaryExpression.Update(left, right);

                var optimized = OptimizeComparison(
                    updated,
                    left,
                    right,
                    leftNullable,
                    rightNullable,
                    out nullable);

                if (optimized is SqlUnaryExpression optimizedUnary
                    && optimizedUnary.Operand is ColumnExpression optimizedUnaryColumnOperand)
                {
                    if (optimizedUnary.OperatorType == ExpressionType.NotEqual)
                    {
                        _nonNullableColumns.Add(optimizedUnaryColumnOperand);
                    }
                    else if (optimizedUnary.OperatorType == ExpressionType.Equal)
                    {
                        _nullValueColumns.Add(optimizedUnaryColumnOperand);
                    }
                }

                // we assume that NullSemantics rewrite is only needed (on the current level)
                // if the optimization didn't make any changes.
                // Reason is that optimization can/will change the nullability of the resulting expression
                // and that inforation is not tracked/stored anywhere
                // so we can no longer rely on nullabilities that we computed earlier (leftNullable, rightNullable)
                // when performing null semantics rewrite.
                // It should be fine because current optimizations *radically* change the expression
                // (e.g. binary -> unary, or binary -> constant)
                // but we need to pay attention in the future if we introduce more subtle transformations here
                if (optimized.Equals(updated)
                    && (leftNullable || rightNullable)
                    && !UseRelationalNulls)
                {
                    var rewriteNullSemanticsResult = RewriteNullSemantics(
                        updated,
                        updated.Left,
                        updated.Right,
                        leftNullable,
                        rightNullable,
                        optimize,
                        out nullable);

                    return rewriteNullSemanticsResult;
                }

                return optimized;
            }

            nullable = leftNullable || rightNullable;
            var result = sqlBinaryExpression.Update(left, right);

            // LCPI: return result is SqlBinaryExpression sqlBinaryResult
            // LCPI:     && (sqlBinaryExpression.OperatorType == ExpressionType.AndAlso
            // LCPI:         || sqlBinaryExpression.OperatorType == ExpressionType.OrElse)
            // LCPI:         ? SimplifyLogicalSqlBinaryExpression(sqlBinaryResult)
            // LCPI:         : result;

            /*LCPI*/ if (result is SqlBinaryExpression sqlBinaryResult)
            /*LCPI*/ {
            /*LCPI*/     if(sqlBinaryExpression.OperatorType == ExpressionType.AndAlso)
            /*LCPI*/     {
            /*LCPI*/         return LCPI__Make_LogicalAnd
            /*LCPI*/             (sqlBinaryResult.Left,
            /*LCPI*/              sqlBinaryResult.Right,
            /*LCPI*/              new LCPI__tagPreparedResult(sqlBinaryResult));
            /*LCPI*/     }
            /*LCPI*/
            /*LCPI*/     if(sqlBinaryExpression.OperatorType == ExpressionType.OrElse)
            /*LCPI*/     {
            /*LCPI*/         return LCPI__Make_LogicalOr
            /*LCPI*/             (sqlBinaryResult.Left,
            /*LCPI*/              sqlBinaryResult.Right,
            /*LCPI*/              new LCPI__tagPreparedResult(sqlBinaryResult));
            /*LCPI*/     }
            /*LCPI*/
            /*LCPI*/     return sqlBinaryResult;
            /*LCPI*/ }//if
            /*LCPI*/
            /*LCPI*/ return result;

            SqlExpression AddNullConcatenationProtection(SqlExpression argument, RelationalTypeMapping typeMapping)
                => argument is SqlConstantExpression || argument is SqlParameterExpression
                    ? LCPI__Helper__SqlENodeFactory__Constant(string.Empty, typeMapping)
                    : LCPI__Helper__SqlENodeFactory__Coalesce(argument, LCPI__Helper__SqlENodeFactory__Constant(string.Empty, typeMapping));
        }

        /// <summary>
        ///     Visits a <see cref="SqlConstantExpression" /> and computes its nullability.
        /// </summary>
        /// <param name="sqlConstantExpression"> A sql constant expression to visit. </param>
        /// <param name="allowOptimizedExpansion"> A bool value indicating if optimized expansion which considers null value as false value is allowed. </param>
        /// <param name="nullable"> A bool value indicating whether the sql expression is nullable. </param>
        /// <returns> An optimized sql expression. </returns>
        protected virtual SqlExpression VisitSqlConstant(
            /*LCPI: [NotNull]*/ SqlConstantExpression sqlConstantExpression,
            bool allowOptimizedExpansion,
            out bool nullable)
        {
            Check.NotNull(sqlConstantExpression, nameof(sqlConstantExpression));

            nullable = sqlConstantExpression.Value == null;

            return sqlConstantExpression;
        }

        /// <summary>
        ///     Visits a <see cref="SqlFragmentExpression" /> and computes its nullability.
        /// </summary>
        /// <param name="sqlFragmentExpression"> A sql fragment expression to visit. </param>
        /// <param name="allowOptimizedExpansion"> A bool value indicating if optimized expansion which considers null value as false value is allowed. </param>
        /// <param name="nullable"> A bool value indicating whether the sql expression is nullable. </param>
        /// <returns> An optimized sql expression. </returns>
        protected virtual SqlExpression VisitSqlFragment(
            /*LCPI: [NotNull]*/ SqlFragmentExpression sqlFragmentExpression,
            bool allowOptimizedExpansion,
            out bool nullable)
        {
            Check.NotNull(sqlFragmentExpression, nameof(sqlFragmentExpression));

            nullable = false;

            return sqlFragmentExpression;
        }

        /// <summary>
        ///     Visits a <see cref="SqlFunctionExpression" /> and computes its nullability.
        /// </summary>
        /// <param name="sqlFunctionExpression"> A sql function expression to visit. </param>
        /// <param name="allowOptimizedExpansion"> A bool value indicating if optimized expansion which considers null value as false value is allowed. </param>
        /// <param name="nullable"> A bool value indicating whether the sql expression is nullable. </param>
        /// <returns> An optimized sql expression. </returns>
        protected virtual SqlExpression VisitSqlFunction(
            /*LCPI: [NotNull]*/ SqlFunctionExpression sqlFunctionExpression,
            bool allowOptimizedExpansion,
            out bool nullable)
        {
            /*LCPI*/ Check.NotNull(sqlFunctionExpression, nameof(sqlFunctionExpression));
            /*LCPI*/
            /*LCPI*/ var instance = Visit(sqlFunctionExpression.Instance, out _);
            /*LCPI*/
            /*LCPI*/ SqlExpression resultExpression;
            /*LCPI*/
            /*LCPI*/ if (sqlFunctionExpression.IsNiladic)
            /*LCPI*/ {
            /*LCPI*/     resultExpression = sqlFunctionExpression.Update(instance, sqlFunctionExpression.Arguments);
            /*LCPI*/ }
            /*LCPI*/ else
            /*LCPI*/ {
            /*LCPI*/     var arguments = new SqlExpression[sqlFunctionExpression.Arguments.Count];
            /*LCPI*/     for (var i = 0; i < arguments.Length; i++)
            /*LCPI*/     {
            /*LCPI*/         arguments[i] = Visit(sqlFunctionExpression.Arguments[i], out _);
            /*LCPI*/     }
            /*LCPI*/
            /*LCPI*/     resultExpression = sqlFunctionExpression.Update(instance, arguments);
            /*LCPI*/ }
            /*LCPI*/
            /*LCPI*/ if (resultExpression is SqlFunctionExpression updatedFunctionExpresion)
            /*LCPI*/ {
            /*LCPI*/     if (LCPI__Helper__TestBuiltInFunctionName(updatedFunctionExpresion, "SUM"))
            /*LCPI*/     {
            /*LCPI*/         resultExpression = LCPI__Helper__MakeCoalesceForValueAndZero
            /*LCPI*/             (updatedFunctionExpresion);
            /*LCPI*/     }//if - SUM
            /*LCPI*/ }//if - updatedFunctionExpresion
            /*LCPI*/
            /*LCPI*/ Check.NotNull(resultExpression, nameof(resultExpression));
            /*LCPI*/
            /*LCPI*/ nullable = Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.SQL.Core_SQL__TestNullable.TestNullable
            /*LCPI*/     (resultExpression);
            /*LCPI*/
            /*LCPI*/ return resultExpression;
        }

        private static bool LCPI__Helper__TestBuiltInFunctionName(SqlFunctionExpression sqlFunctionExpression,
                                                                  string                functionName)
        {
            Debug.Assert(!Object.ReferenceEquals(sqlFunctionExpression, null));
            Debug.Assert(!Object.ReferenceEquals(functionName, null));
            Debug.Assert(functionName.Length > 0);

            if (!sqlFunctionExpression.IsBuiltIn)
                return false;

            if (!string.Equals(sqlFunctionExpression.Name, functionName, StringComparison.OrdinalIgnoreCase))
                return false;

            return true;
        }//LCPI__Helper__TestBuiltInFunctionName

        private static System.Type LCPI__Helper__GetClrType(SqlExpression sqlExpression)
        {
            Debug.Assert(!Object.ReferenceEquals(sqlExpression,null));

            const string c_bugcheck_src
                = "SqlNullabilityProcessor::LCPI__Helper__GetClrType";

            if (Object.ReferenceEquals(sqlExpression.TypeMapping, null))
            {
                Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.ThrowBugCheck.No_TypeMapping
                    (Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.ErrSourceID.EXT,
                     c_bugcheck_src,
                     "#001");
            }

            if (Object.ReferenceEquals(sqlExpression.TypeMapping!.ClrType, null))
            {
                Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.ThrowBugCheck.No_TypeMapping_ClrType
                    (Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.ErrSourceID.EXT,
                     c_bugcheck_src,
                     "#002");
            }

            return sqlExpression.TypeMapping!.ClrType!;
        }//LCPI__Helper__GetClrType

        private SqlExpression LCPI__Helper__MakeCoalesceForValueAndZero(SqlExpression sqlValue)
        {
            var clrType
                = LCPI__Helper__GetClrType(sqlValue); //throw

            System.Diagnostics.Debug.Assert(!Object.ReferenceEquals(clrType, null));

            var zeroValue
                = System.Convert.ChangeType(0,clrType);

            var sqlConstantZero
                = LCPI__Helper__SqlENodeFactory__Constant
                    (zeroValue,
                     sqlValue.TypeMapping);

            System.Diagnostics.Debug.Assert(!Object.ReferenceEquals(sqlConstantZero, null));

            return LCPI__Helper__SqlENodeFactory__Coalesce(
                    sqlValue,
                    sqlConstantZero,
                    sqlValue.TypeMapping);
        }

        /// <summary>
        ///     Visits a <see cref="SqlParameterExpression" /> and computes its nullability.
        /// </summary>
        /// <param name="sqlParameterExpression"> A sql parameter expression to visit. </param>
        /// <param name="allowOptimizedExpansion"> A bool value indicating if optimized expansion which considers null value as false value is allowed. </param>
        /// <param name="nullable"> A bool value indicating whether the sql expression is nullable. </param>
        /// <returns> An optimized sql expression. </returns>
        protected virtual SqlExpression VisitSqlParameter(
            /*LCPI: [NotNull]*/ SqlParameterExpression sqlParameterExpression,
            bool allowOptimizedExpansion,
            out bool nullable)
        {
            Check.NotNull(sqlParameterExpression, nameof(sqlParameterExpression));

            nullable = ParameterValues[sqlParameterExpression.Name] == null;

            return nullable
                ? LCPI__Helper__SqlENodeFactory__Constant(null, sqlParameterExpression.TypeMapping)
                : sqlParameterExpression;
        }

        /// <summary>
        ///     Visits a <see cref="SqlUnaryExpression" /> and computes its nullability.
        /// </summary>
        /// <param name="sqlUnaryExpression"> A sql unary expression to visit. </param>
        /// <param name="allowOptimizedExpansion"> A bool value indicating if optimized expansion which considers null value as false value is allowed. </param>
        /// <param name="nullable"> A bool value indicating whether the sql expression is nullable. </param>
        /// <returns> An optimized sql expression. </returns>
        protected virtual SqlExpression VisitSqlUnary(
            /*LCPI: [NotNull]*/ SqlUnaryExpression sqlUnaryExpression,
            bool allowOptimizedExpansion,
            out bool nullable)
        {
            Check.NotNull(sqlUnaryExpression, nameof(sqlUnaryExpression));

            var operand = Visit(sqlUnaryExpression.Operand, out var operandNullable);
            var updated = sqlUnaryExpression.Update(operand);

            if (sqlUnaryExpression.OperatorType == ExpressionType.Equal
                || sqlUnaryExpression.OperatorType == ExpressionType.NotEqual)
            {
                //LCPI: var result = ProcessNullNotNull(updated, operandNullable);
                /*LCPI*/var result = LCPI__Make_NullNotNull
                /*LCPI*/        (updated.OperatorType,
                /*LCPI*/         updated.Operand,
                /*LCPI*/         operandNullable,
                /*LCPI*/         new LCPI__tagPreparedResult(updated));

                // result of IsNull/IsNotNull can never be null
                nullable = false;

                if (result is SqlUnaryExpression resultUnary
                    && resultUnary.Operand is ColumnExpression resultColumnOperand)
                {
                    if (resultUnary.OperatorType == ExpressionType.NotEqual)
                    {
                        _nonNullableColumns.Add(resultColumnOperand);
                    }
                    else if (resultUnary.OperatorType == ExpressionType.Equal)
                    {
                        _nullValueColumns.Add(resultColumnOperand);
                    }
                }

                return result;
            }

            nullable = operandNullable;

            return !operandNullable && sqlUnaryExpression.OperatorType == ExpressionType.Not
                ? LCPI__Make_NonNullableNot(updated.Operand,new LCPI__tagPreparedResult(updated))
                : updated;
        }

        private static bool? TryGetBoolConstantValue(SqlExpression? expression)
            => expression is SqlConstantExpression constantExpression
                && constantExpression.Value is bool boolValue
                    ? boolValue
                    : (bool?)null;

        private void RestoreNonNullableColumnsList(int counter)
        {
            if (counter < _nonNullableColumns.Count)
            {
                _nonNullableColumns.RemoveRange(counter, _nonNullableColumns.Count - counter);
            }
        }

        private void RestoreNullValueColumnsList(int counter)
        {
            if (counter < _nullValueColumns.Count)
            {
                _nullValueColumns.RemoveRange(counter, _nullValueColumns.Count - counter);
            }
        }

        private SqlExpression ProcessJoinPredicate(SqlExpression predicate)
        {
            if (predicate is SqlBinaryExpression sqlBinaryExpression)
            {
                if (sqlBinaryExpression.OperatorType == ExpressionType.Equal)
                {
                    var left = Visit(sqlBinaryExpression.Left, allowOptimizedExpansion: true, out var leftNullable);
                    var right = Visit(sqlBinaryExpression.Right, allowOptimizedExpansion: true, out var rightNullable);

                    var result = OptimizeComparison(
                        sqlBinaryExpression.Update(left, right),
                        left,
                        right,
                        leftNullable,
                        rightNullable,
                        out _);

                    return result;
                }

                if (sqlBinaryExpression.OperatorType == ExpressionType.AndAlso
                    || sqlBinaryExpression.OperatorType == ExpressionType.NotEqual
                    || sqlBinaryExpression.OperatorType == ExpressionType.GreaterThan
                    || sqlBinaryExpression.OperatorType == ExpressionType.GreaterThanOrEqual
                    || sqlBinaryExpression.OperatorType == ExpressionType.LessThan
                    || sqlBinaryExpression.OperatorType == ExpressionType.LessThanOrEqual)
                {
                    return Visit(sqlBinaryExpression, allowOptimizedExpansion: true, out _);
                }
            }

            throw new InvalidOperationException(
                RelationalStrings.UnhandledExpressionInVisitor(predicate, predicate.GetType(), nameof(SqlNullabilityProcessor)));
        }

        private SqlExpression OptimizeComparison(
            SqlBinaryExpression sqlBinaryExpression,
            SqlExpression left,
            SqlExpression right,
            bool leftNullable,
            bool rightNullable,
            out bool nullable)
        {
            /*LCPI*/ Debug.Assert(!Object.ReferenceEquals(sqlBinaryExpression,null));
            /*LCPI*/ Debug.Assert(!Object.ReferenceEquals(left,null));
            /*LCPI*/ Debug.Assert(!Object.ReferenceEquals(right,null));
            /*LCPI*/
            /*LCPI*/ Debug.Assert(sqlBinaryExpression.OperatorType == ExpressionType.Equal ||
            /*LCPI*/              sqlBinaryExpression.OperatorType == ExpressionType.NotEqual);

            var leftNullValue = leftNullable && (left is SqlConstantExpression || left is SqlParameterExpression);
            var rightNullValue = rightNullable && (right is SqlConstantExpression || right is SqlParameterExpression);

            // a == null -> a IS NULL
            // a != null -> a IS NOT NULL
            if (rightNullValue)
            {
                //LCPI: var result = sqlBinaryExpression.OperatorType == ExpressionType.Equal
                //LCPI:     ? ProcessNullNotNull(_sqlExpressionFactory.IsNull(left), leftNullable)
                //LCPI:     : ProcessNullNotNull(_sqlExpressionFactory.IsNotNull(left), leftNullable);

                /*LCPI*/ var result = LCPI__Make_NullNotNull
                /*LCPI*/         (sqlBinaryExpression.OperatorType,
                /*LCPI*/          left,
                /*LCPI*/          leftNullable);

                /*LCPI*/ Debug.Assert(!Object.ReferenceEquals(result, null));

                nullable = false;

                return result;
            }

            // null == a -> a IS NULL
            // null != a -> a IS NOT NULL
            if (leftNullValue)
            {
                //LCPI: var result = sqlBinaryExpression.OperatorType == ExpressionType.Equal
                //LCPI:     ? ProcessNullNotNull(_sqlExpressionFactory.IsNull(right), rightNullable)
                //LCPI:     : ProcessNullNotNull(_sqlExpressionFactory.IsNotNull(right), rightNullable);

                /*LCPI*/ var result = LCPI__Make_NullNotNull
                /*LCPI*/         (sqlBinaryExpression.OperatorType,
                /*LCPI*/          right,
                /*LCPI*/          rightNullable);

                /*LCPI*/ Debug.Assert(!Object.ReferenceEquals(result, null));

                nullable = false;

                return result;
            }

            if (TryGetBoolConstantValue(right) is bool rightBoolValue
                && !leftNullable
                && left.TypeMapping!.Converter == null)
            {
                nullable = leftNullable;

                // only correct in 2-value logic
                // a == true -> a
                // a == false -> !a
                // a != true -> !a
                // a != false -> a
                return sqlBinaryExpression.OperatorType == ExpressionType.Equal ^ rightBoolValue
                    ? LCPI__Make_NonNullableNot(left)
                    : left;
            }

            if (TryGetBoolConstantValue(left) is bool leftBoolValue
                && !rightNullable
                && right.TypeMapping!.Converter == null)
            {
                nullable = rightNullable;

                // only correct in 2-value logic
                // true == a -> a
                // false == a -> !a
                // true != a -> !a
                // false != a -> a
                return sqlBinaryExpression.OperatorType == ExpressionType.Equal ^ leftBoolValue
                    ? LCPI__Make_NonNullableNot(right)
                    : right;
            }

            // only correct in 2-value logic
            // a == a -> true
            // a != a -> false
            if (!leftNullable
                && left.Equals(right))
            {
                nullable = false;

                return LCPI__Helper__SqlENodeFactory__BoolConstant(
                    sqlBinaryExpression.OperatorType == ExpressionType.Equal);
            }

            if (!leftNullable
                && !rightNullable
                && (sqlBinaryExpression.OperatorType == ExpressionType.Equal
                    || sqlBinaryExpression.OperatorType == ExpressionType.NotEqual))
            {
                var leftUnary = left as SqlUnaryExpression;
                var rightUnary = right as SqlUnaryExpression;

                var leftNegated = IsLogicalNot(leftUnary);
                var rightNegated = IsLogicalNot(rightUnary);

                if (leftNegated)
                {
                    left = leftUnary!.Operand;
                }

                if (rightNegated)
                {
                    right = rightUnary!.Operand;
                }

                // a == b <=> !a == !b -> a == b
                // !a == b <=> a == !b -> a != b
                // a != b <=> !a != !b -> a != b
                // !a != b <=> a != !b -> a == b

                nullable = false;

                return sqlBinaryExpression.OperatorType == ExpressionType.Equal ^ leftNegated == rightNegated
                    ? LCPI__Helper__SqlENodeFactory__NotEqual(left, right)
                    : LCPI__Helper__SqlENodeFactory__Equal(left, right);
            }

            nullable = false;

            return sqlBinaryExpression.Update(left, right);
        }

        private SqlExpression RewriteNullSemantics(
            SqlBinaryExpression sqlBinaryExpression,
            SqlExpression left,
            SqlExpression right,
            bool leftNullable,
            bool rightNullable,
            bool optimize,
            out bool nullable)
        {
            var leftUnary = left as SqlUnaryExpression;
            var rightUnary = right as SqlUnaryExpression;

            var leftNegated = IsLogicalNot(leftUnary);
            var rightNegated = IsLogicalNot(rightUnary);

            if (leftNegated)
            {
                left = leftUnary!.Operand;
            }

            if (rightNegated)
            {
                right = rightUnary!.Operand;
            }

            //LCPI: var leftIsNull = ProcessNullNotNull(_sqlExpressionFactory.IsNull(left), leftNullable);
            var leftIsNull = LCPI__Make_NullNotNull(ExpressionType.Equal, left, leftNullable);
            var leftIsNotNull = LCPI__Make_NonNullableNot(leftIsNull);

            //var rightIsNull = ProcessNullNotNull(_sqlExpressionFactory.IsNull(right), rightNullable);
            var rightIsNull = LCPI__Make_NullNotNull(ExpressionType.Equal, right, rightNullable);
            var rightIsNotNull = LCPI__Make_NonNullableNot(rightIsNull);

            // optimized expansion which doesn't distinguish between null and false
            if (optimize
                && sqlBinaryExpression.OperatorType == ExpressionType.Equal
                && !leftNegated
                && !rightNegated)
            {
                // when we use optimized form, the result can still be nullable
                if (leftNullable && rightNullable)
                {
                    nullable = true;

                    //LCPI: return SimplifyLogicalSqlBinaryExpression(
                    //LCPI:     _sqlExpressionFactory.OrElse(
                    //LCPI:         _sqlExpressionFactory.Equal(left, right),
                    //LCPI:         SimplifyLogicalSqlBinaryExpression(
                    //LCPI:             _sqlExpressionFactory.AndAlso(leftIsNull, rightIsNull))));

                    /*LCPI*/ return LCPI__Make_LogicalOr
                    /*LCPI*/         (LCPI__Helper__SqlENodeFactory__Equal(left, right),
                    /*LCPI*/          LCPI__Make_LogicalAnd
                    /*LCPI*/              (leftIsNull,
                    /*LCPI*/               rightIsNull));
                }

                if ((leftNullable && !rightNullable)
                    || (!leftNullable && rightNullable))
                {
                    nullable = true;

                    return LCPI__Helper__SqlENodeFactory__Equal(left, right);
                }
            }

            // doing a full null semantics rewrite - removing all nulls from truth table
            nullable = false;

            if (sqlBinaryExpression.OperatorType == ExpressionType.Equal)
            {
                if (leftNullable && rightNullable)
                {
                    // ?a == ?b <=> !(?a) == !(?b) -> [(a == b) && (a != null && b != null)] || (a == null && b == null))
                    // !(?a) == ?b <=> ?a == !(?b) -> [(a != b) && (a != null && b != null)] || (a == null && b == null)
                    return leftNegated == rightNegated
                        ? ExpandNullableEqualNullable(left, right, leftIsNull, leftIsNotNull, rightIsNull, rightIsNotNull)
                        : ExpandNegatedNullableEqualNullable(left, right, leftIsNull, leftIsNotNull, rightIsNull, rightIsNotNull);
                }

                if (leftNullable && !rightNullable)
                {
                    // ?a == b <=> !(?a) == !b -> (a == b) && (a != null)
                    // !(?a) == b <=> ?a == !b -> (a != b) && (a != null)
                    return leftNegated == rightNegated
                        ? ExpandNullableEqualNonNullable(left, right, leftIsNotNull)
                        : ExpandNegatedNullableEqualNonNullable(left, right, leftIsNotNull);
                }

                if (rightNullable && !leftNullable)
                {
                    // a == ?b <=> !a == !(?b) -> (a == b) && (b != null)
                    // !a == ?b <=> a == !(?b) -> (a != b) && (b != null)
                    return leftNegated == rightNegated
                        ? ExpandNullableEqualNonNullable(left, right, rightIsNotNull)
                        : ExpandNegatedNullableEqualNonNullable(left, right, rightIsNotNull);
                }
            }

            if (sqlBinaryExpression.OperatorType == ExpressionType.NotEqual)
            {
                if (leftNullable && rightNullable)
                {
                    // ?a != ?b <=> !(?a) != !(?b) -> [(a != b) || (a == null || b == null)] && (a != null || b != null)
                    // !(?a) != ?b <=> ?a != !(?b) -> [(a == b) || (a == null || b == null)] && (a != null || b != null)
                    return leftNegated == rightNegated
                        ? ExpandNullableNotEqualNullable(left, right, leftIsNull, leftIsNotNull, rightIsNull, rightIsNotNull)
                        : ExpandNegatedNullableNotEqualNullable(left, right, leftIsNull, leftIsNotNull, rightIsNull, rightIsNotNull);
                }

                if (leftNullable && !rightNullable)
                {
                    // ?a != b <=> !(?a) != !b -> (a != b) || (a == null)
                    // !(?a) != b <=> ?a != !b -> (a == b) || (a == null)
                    return leftNegated == rightNegated
                        ? ExpandNullableNotEqualNonNullable(left, right, leftIsNull)
                        : ExpandNegatedNullableNotEqualNonNullable(left, right, leftIsNull);
                }

                if (rightNullable && !leftNullable)
                {
                    // a != ?b <=> !a != !(?b) -> (a != b) || (b == null)
                    // !a != ?b <=> a != !(?b) -> (a == b) || (b == null)
                    return leftNegated == rightNegated
                        ? ExpandNullableNotEqualNonNullable(left, right, rightIsNull)
                        : ExpandNegatedNullableNotEqualNonNullable(left, right, rightIsNull);
                }
            }

            return sqlBinaryExpression.Update(left, right);
        }

        //LCPI: private SqlExpression SimplifyLogicalSqlBinaryExpression(SqlBinaryExpression sqlBinaryExpression)
        //LCPI: {
        //LCPI:     if (sqlBinaryExpression.Left is SqlUnaryExpression leftUnary
        //LCPI:         && sqlBinaryExpression.Right is SqlUnaryExpression rightUnary
        //LCPI:         && (leftUnary.OperatorType == ExpressionType.Equal || leftUnary.OperatorType == ExpressionType.NotEqual)
        //LCPI:         && (rightUnary.OperatorType == ExpressionType.Equal || rightUnary.OperatorType == ExpressionType.NotEqual)
        //LCPI:         && leftUnary.Operand.Equals(rightUnary.Operand))
        //LCPI:     {
        //LCPI:         // a is null || a is null -> a is null
        //LCPI:         // a is not null || a is not null -> a is not null
        //LCPI:         // a is null && a is null -> a is null
        //LCPI:         // a is not null && a is not null -> a is not null
        //LCPI:         // a is null || a is not null -> true
        //LCPI:         // a is null && a is not null -> false
        //LCPI:         return leftUnary.OperatorType == rightUnary.OperatorType
        //LCPI:             ? (SqlExpression)leftUnary
        //LCPI:             : _sqlExpressionFactory.Constant(
        //LCPI:                 sqlBinaryExpression.OperatorType == ExpressionType.OrElse, sqlBinaryExpression.TypeMapping);
        //LCPI:     }
        //LCPI:
        //LCPI:     // true && a -> a
        //LCPI:     // true || a -> true
        //LCPI:     // false && a -> false
        //LCPI:     // false || a -> a
        //LCPI:     if (sqlBinaryExpression.Left is SqlConstantExpression newLeftConstant
        //LCPI:         && newLeftConstant.Value is bool leftBoolValue)
        //LCPI:     {
        //LCPI:         return sqlBinaryExpression.OperatorType == ExpressionType.AndAlso
        //LCPI:             ? leftBoolValue
        //LCPI:                 ? sqlBinaryExpression.Right
        //LCPI:                 : newLeftConstant
        //LCPI:             : leftBoolValue
        //LCPI:                 ? newLeftConstant
        //LCPI:                 : sqlBinaryExpression.Right;
        //LCPI:     }
        //LCPI:
        //LCPI:     if (sqlBinaryExpression.Right is SqlConstantExpression newRightConstant
        //LCPI:         && newRightConstant.Value is bool rightBoolValue)
        //LCPI:     {
        //LCPI:         // a && true -> a
        //LCPI:         // a || true -> true
        //LCPI:         // a && false -> false
        //LCPI:         // a || false -> a
        //LCPI:         return sqlBinaryExpression.OperatorType == ExpressionType.AndAlso
        //LCPI:             ? rightBoolValue
        //LCPI:                 ? sqlBinaryExpression.Left
        //LCPI:                 : newRightConstant
        //LCPI:             : rightBoolValue
        //LCPI:                 ? newRightConstant
        //LCPI:                 : sqlBinaryExpression.Left;
        //LCPI:     }
        //LCPI:
        //LCPI:     return sqlBinaryExpression;
        //LCPI: }

        private struct LCPI__tagPreparedResult
        {
            public readonly SqlExpression? Value;

            public LCPI__tagPreparedResult(SqlExpression v)
            {
                this.Value=v;
            }
        };//struct LCPI__tagPreparedResult

        private SqlExpression LCPI__Make_LogicalAnd
                                           (SqlExpression           sourceLeft,
                                            SqlExpression           sourceRight,
                                            LCPI__tagPreparedResult preparedResult=default)
        {
            // RETURNS AndAlso

            if (sourceLeft is SqlUnaryExpression leftUnary
                && sourceRight is SqlUnaryExpression rightUnary
                && (leftUnary.OperatorType == ExpressionType.Equal || leftUnary.OperatorType == ExpressionType.NotEqual)
                && (rightUnary.OperatorType == ExpressionType.Equal || rightUnary.OperatorType == ExpressionType.NotEqual)
                && leftUnary.Operand.Equals(rightUnary.Operand))
            {
                // a is null || a is null -> a is null
                // a is not null || a is not null -> a is not null
                // a is null && a is null -> a is null
                // a is not null && a is not null -> a is not null
                // a is null || a is not null -> true
                // a is null && a is not null -> false
                return leftUnary.OperatorType == rightUnary.OperatorType
                    ? (SqlExpression)leftUnary
                    : LCPI__Helper__SqlENodeFactory__BoolConstant(false /*sqlBinaryExpression.OperatorType == ExpressionType.OrElse*/);
            }

            // true && a -> a
            // true || a -> true
            // false && a -> false
            // false || a -> a
            if (sourceLeft is SqlConstantExpression newLeftConstant
                && newLeftConstant.Value is bool leftBoolValue)
            {
                return leftBoolValue
                        ? sourceRight
                        : newLeftConstant;
            }

            if (sourceRight is SqlConstantExpression newRightConstant
                && newRightConstant.Value is bool rightBoolValue)
            {
                // a && true -> a
                // a || true -> true
                // a && false -> false
                // a || false -> a
                return rightBoolValue
                        ? sourceLeft
                        : newRightConstant;
            }

            if (!Object.ReferenceEquals(preparedResult.Value, null))
                return preparedResult.Value;

            return LCPI__Helper__SqlENodeFactory__AndAlso
                    (sourceLeft,
                     sourceRight);
        }//LCPI__Make_LogicalAnd

        private SqlExpression LCPI__Make_LogicalOr
                                           (SqlExpression           sourceLeft,
                                            SqlExpression           sourceRight,
                                            LCPI__tagPreparedResult preparedResult=default)
        {
            // RETURNS OrElse

            if (sourceLeft is SqlUnaryExpression leftUnary
                && sourceRight is SqlUnaryExpression rightUnary
                && (leftUnary.OperatorType == ExpressionType.Equal || leftUnary.OperatorType == ExpressionType.NotEqual)
                && (rightUnary.OperatorType == ExpressionType.Equal || rightUnary.OperatorType == ExpressionType.NotEqual)
                && leftUnary.Operand.Equals(rightUnary.Operand))
            {
                // a is null || a is null -> a is null
                // a is not null || a is not null -> a is not null
                // a is null && a is null -> a is null
                // a is not null && a is not null -> a is not null
                // a is null || a is not null -> true
                // a is null && a is not null -> false
                return leftUnary.OperatorType == rightUnary.OperatorType
                    ? (SqlExpression)leftUnary
                    : LCPI__Helper__SqlENodeFactory__BoolConstant(true /*sqlBinaryExpression.OperatorType == ExpressionType.OrElse*/);
            }

            // true && a -> a
            // true || a -> true
            // false && a -> false
            // false || a -> a
            if (sourceLeft is SqlConstantExpression newLeftConstant
                && newLeftConstant.Value is bool leftBoolValue)
            {
                return leftBoolValue
                        ? newLeftConstant
                        : sourceRight;
            }

            if (sourceRight is SqlConstantExpression newRightConstant
                && newRightConstant.Value is bool rightBoolValue)
            {
                // a && true -> a
                // a || true -> true
                // a && false -> false
                // a || false -> a
                return rightBoolValue
                        ? newRightConstant
                        : sourceLeft;
            }

            if (!Object.ReferenceEquals(preparedResult.Value, null))
                return preparedResult.Value;

            return LCPI__Helper__SqlENodeFactory__OrElse
                    (sourceLeft,
                     sourceRight);
        }//LCPI__Make_LogicalOr

        private SqlExpression LCPI__Make_NonNullableNot(SqlExpression           sqlOperandExpression,
                                                        LCPI__tagPreparedResult preparedResult=default)
        {
            switch (sqlOperandExpression)
            {
                // !(true) -> false
                // !(false) -> true
                case SqlConstantExpression constantOperand
                    when constantOperand.Value is bool value:
                {
                    return LCPI__Helper__SqlENodeFactory__BoolConstant(!value);
                }

                case InExpression inOperand:
                    return inOperand.Negate();

                case SqlUnaryExpression sqlUnaryOperand:
                {
                    switch (sqlUnaryOperand.OperatorType)
                    {
                        // !(!a) -> a
                        case ExpressionType.Not:
                            return sqlUnaryOperand.Operand;

                        //!(a IS NULL) -> a IS NOT NULL
                        case ExpressionType.Equal:
                            return LCPI__Helper__SqlENodeFactory__IsNotNull(sqlUnaryOperand.Operand);

                        //!(a IS NOT NULL) -> a IS NULL
                        case ExpressionType.NotEqual:
                            return LCPI__Helper__SqlENodeFactory__IsNull(sqlUnaryOperand.Operand);
                    }

                    break;
                }

                case SqlBinaryExpression sqlBinaryOperand:
                {
                    // optimizations below are only correct in 2-value logic
                    // De Morgan's
                    //LCPI: if (sqlBinaryOperand.OperatorType == ExpressionType.AndAlso
                    //LCPI:     || sqlBinaryOperand.OperatorType == ExpressionType.OrElse)
                    //LCPI: {
                    //LCPI:     // since entire AndAlso/OrElse expression is non-nullable, both sides of it (left and right) must also be non-nullable
                    //LCPI:     // so it's safe to perform recursive optimization here
                    //LCPI:     var left = LCPI__MakeNonNullableNotExpression(sqlBinaryOperand.Left);
                    //LCPI:     var right = LCPI__MakeNonNullableNotExpression(sqlBinaryOperand.Right);
                    //LCPI:
                    //LCPI:     return SimplifyLogicalSqlBinaryExpression(
                    //LCPI:         _sqlExpressionFactory.MakeBinary(
                    //LCPI:             sqlBinaryOperand.OperatorType == ExpressionType.AndAlso
                    //LCPI:                 ? ExpressionType.OrElse
                    //LCPI:                 : ExpressionType.AndAlso,
                    //LCPI:             left,
                    //LCPI:             right,
                    //LCPI:             sqlBinaryOperand.TypeMapping)!);
                    //LCPI: }

                    /*LCPI*/ if (sqlBinaryOperand.OperatorType == ExpressionType.AndAlso)
                    /*LCPI*/ {
                    /*LCPI*/     // since entire AndAlso/OrElse expression is non-nullable, both sides of it (left and right) must also be non-nullable
                    /*LCPI*/     // so it's safe to perform recursive optimization here
                    /*LCPI*/     var left = LCPI__Make_NonNullableNot(sqlBinaryOperand.Left);
                    /*LCPI*/     var right = LCPI__Make_NonNullableNot(sqlBinaryOperand.Right);
                    /*LCPI*/
                    /*LCPI*/     return LCPI__Make_LogicalOr
                    /*LCPI*/         (left,
                    /*LCPI*/          right);
                    /*LCPI*/ }

                    /*LCPI*/ if (sqlBinaryOperand.OperatorType == ExpressionType.OrElse)
                    /*LCPI*/ {
                    /*LCPI*/     // since entire AndAlso/OrElse expression is non-nullable, both sides of it (left and right) must also be non-nullable
                    /*LCPI*/     // so it's safe to perform recursive optimization here
                    /*LCPI*/     var left = LCPI__Make_NonNullableNot(sqlBinaryOperand.Left);
                    /*LCPI*/     var right = LCPI__Make_NonNullableNot(sqlBinaryOperand.Right);
                    /*LCPI*/
                    /*LCPI*/     return LCPI__Make_LogicalAnd
                    /*LCPI*/         (left,
                    /*LCPI*/          right);
                    /*LCPI*/ }

                    // use equality where possible
                    // !(a == true) -> a == false
                    // !(a == false) -> a == true
                    // !(true == a) -> false == a
                    // !(false == a) -> true == a
                    if (sqlBinaryOperand.OperatorType == ExpressionType.Equal)
                    {
                        if (sqlBinaryOperand.Left is SqlConstantExpression leftConstant
                            && leftConstant.Type == typeof(bool))
                        {
                            return LCPI__Helper__SqlENodeFactory__Equal(
                                LCPI__Helper__SqlENodeFactory__BoolConstant(!(bool)leftConstant.Value!),
                                sqlBinaryOperand.Right);
                        }

                        if (sqlBinaryOperand.Right is SqlConstantExpression rightConstant
                            && rightConstant.Type == typeof(bool))
                        {
                            return LCPI__Helper__SqlENodeFactory__Equal(
                                sqlBinaryOperand.Left,
                                LCPI__Helper__SqlENodeFactory__BoolConstant(!(bool)rightConstant.Value!));
                        }
                    }

                    // !(a == b) -> a != b
                    // !(a != b) -> a == b
                    // !(a > b) -> a <= b
                    // !(a >= b) -> a < b
                    // !(a < b) -> a >= b
                    // !(a <= b) -> a > b
                    if (TryNegate(sqlBinaryOperand.OperatorType, out var negated))
                    {
                        return LCPI__Helper__SqlENodeFactory__MakeBinary(
                            negated,
                            sqlBinaryOperand.Left,
                            sqlBinaryOperand.Right,
                            sqlBinaryOperand.TypeMapping);
                    }
                }
                    break;
            }

            if (!Object.ReferenceEquals(preparedResult.Value,null))
                return preparedResult.Value;

            return LCPI__Helper__SqlENodeFactory__Not(sqlOperandExpression);

            static bool TryNegate(ExpressionType expressionType, out ExpressionType result)
            {
                var negated = expressionType switch
                {
                    ExpressionType.Equal => ExpressionType.NotEqual,
                    ExpressionType.NotEqual => ExpressionType.Equal,
                    ExpressionType.GreaterThan => ExpressionType.LessThanOrEqual,
                    ExpressionType.GreaterThanOrEqual => ExpressionType.LessThan,
                    ExpressionType.LessThan => ExpressionType.GreaterThanOrEqual,
                    ExpressionType.LessThanOrEqual => ExpressionType.GreaterThan,
                    _ => (ExpressionType?)null
                };

                result = negated ?? default;

                return negated.HasValue;
            }
        }//LCPI__Make_NonNullableNot

        private SqlExpression LCPI__Make_NullNotNull
                                            (ExpressionType          sourceOperatorType,
                                             SqlExpression           sourceOperand,
                                             bool                    sourceOperandIsNullable,
                                             LCPI__tagPreparedResult preparedResult=default)
        {
            Debug.Assert(sourceOperatorType == ExpressionType.Equal ||
                         sourceOperatorType == ExpressionType.NotEqual);

            if (!sourceOperandIsNullable)
            {
                // when we know that operand is non-nullable:
                // not_null_operand is null-> false
                // not_null_operand is not null -> true
                return LCPI__Helper__SqlENodeFactory__BoolConstant(
                    sourceOperatorType == ExpressionType.NotEqual);
            }

            switch (sourceOperand)
            {
                case SqlConstantExpression sqlConstantOperand:
                    // null_value_constant is null -> true
                    // null_value_constant is not null -> false
                    // not_null_value_constant is null -> false
                    // not_null_value_constant is not null -> true
                    return LCPI__Helper__SqlENodeFactory__BoolConstant(
                        sqlConstantOperand.Value == null ^ sourceOperatorType == ExpressionType.NotEqual);

                case SqlParameterExpression sqlParameterOperand:
                    // null_value_parameter is null -> true
                    // null_value_parameter is not null -> false
                    // not_null_value_parameter is null -> false
                    // not_null_value_parameter is not null -> true
                    return LCPI__Helper__SqlENodeFactory__BoolConstant(
                        ParameterValues[sqlParameterOperand.Name] == null ^ sourceOperatorType == ExpressionType.NotEqual);

                case ColumnExpression columnOperand
                    when !columnOperand.IsNullable || _nonNullableColumns.Contains(columnOperand):
                {
                    // IsNull(non_nullable_column) -> false
                    // IsNotNull(non_nullable_column) -> true
                    return LCPI__Helper__SqlENodeFactory__BoolConstant(
                        sourceOperatorType == ExpressionType.NotEqual);
                }

                case SqlUnaryExpression sqlUnaryOperand:
                    switch (sqlUnaryOperand.OperatorType)
                    {
                        case ExpressionType.Convert:
                        case ExpressionType.Not:
                        case ExpressionType.Negate:
                            // op(a) is null -> a is null
                            // op(a) is not null -> a is not null
                            return LCPI__Make_NullNotNull(
                                sourceOperatorType,
                                sqlUnaryOperand.Operand,
                                sourceOperandIsNullable);

                        case ExpressionType.Equal:
                        case ExpressionType.NotEqual:
                            // (a is null) is null -> false
                            // (a is not null) is null -> false
                            // (a is null) is not null -> true
                            // (a is not null) is not null -> true
                            return LCPI__Helper__SqlENodeFactory__BoolConstant(
                                sourceOperatorType == ExpressionType.NotEqual);
                    }

                    break;

                case SqlBinaryExpression sqlBinaryOperand
                    when sqlBinaryOperand.OperatorType != ExpressionType.AndAlso
                    && sqlBinaryOperand.OperatorType != ExpressionType.OrElse:
                {
                    // in general:
                    // binaryOp(a, b) == null -> a == null || b == null
                    // binaryOp(a, b) != null -> a != null && b != null
                    // for AndAlso, OrElse we can't do this optimization
                    // we could do something like this, but it seems too complicated:
                    // (a && b) == null -> a == null && b != 0 || a != 0 && b == null
                    // NOTE: we don't preserve nullabilities of left/right individually so we are using nullability binary expression as a whole
                    // this may lead to missing some optimizations, where one of the operands (left or right) is not nullable and the other one is
                    var left = LCPI__Make_NullNotNull(
                            sourceOperatorType,
                            sqlBinaryOperand.Left,
                            sourceOperandIsNullable);

                    var right = LCPI__Make_NullNotNull(
                            sourceOperatorType,
                            sqlBinaryOperand.Right,
                            sourceOperandIsNullable);

                    //LCPI: return SimplifyLogicalSqlBinaryExpression(
                    //LCPI:     _sqlExpressionFactory.MakeBinary(
                    //LCPI:         sourceOperatorType == ExpressionType.Equal
                    //LCPI:             ? ExpressionType.OrElse
                    //LCPI:             : ExpressionType.AndAlso,
                    //LCPI:         left,
                    //LCPI:         right,
                    //LCPI:         /*sqlUnaryExpression.TypeMapping*/_lcpi_typeMappingForBool)!);

                    /*LCPI*/ if (sourceOperatorType == ExpressionType.Equal)
                    /*LCPI*/ {
                    /*LCPI*/     return LCPI__Make_LogicalOr
                    /*LCPI*/         (left,
                    /*LCPI*/          right);
                    /*LCPI*/ }
                    /*LCPI*/
                    /*LCPI*/ Debug.Assert(sourceOperatorType == ExpressionType.NotEqual);
                    /*LCPI*/
                    /*LCPI*/ return LCPI__Make_LogicalAnd
                    /*LCPI*/     (left,
                    /*LCPI*/      right);
                }

                case SqlFunctionExpression sqlFunctionExpression:
                {
                    if (LCPI__Helper__TestBuiltInFunctionName(sqlFunctionExpression,"COALESCE"))
                    {
                        /*LCPI*/ Debug.Assert(!Object.ReferenceEquals(sqlFunctionExpression.Arguments,null));
                        /*LCPI*/ Debug.Assert(sqlFunctionExpression.Arguments.Count>=2);

                        // for coalesce:
                        // (a ?? b) == null -> a == null && b == null
                        // (a ?? b) != null -> a != null || b != null

                        /*LCPI*/ var newArguments
                        /*LCPI*/     = sqlFunctionExpression.Arguments!
                        /*LCPI*/       .Select(
                        /*LCPI*/           e => LCPI__Make_NullNotNull(
                        /*LCPI*/                   sourceOperatorType,
                        /*LCPI*/                   e,
                        /*LCPI*/                   sourceOperandIsNullable));

                        //LCPI: return SimplifyLogicalSqlBinaryExpression(
                        //LCPI:     _sqlExpressionFactory.MakeBinary(
                        //LCPI:         sourceOperatorType == ExpressionType.Equal
                        //LCPI:             ? ExpressionType.AndAlso
                        //LCPI:             : ExpressionType.OrElse,
                        //LCPI:         left,
                        //LCPI:         right,
                        //LCPI:         /*sqlUnaryExpression.TypeMapping*/_lcpi_typeMappingForBool)!);

                        /*LCPI*/ if (sourceOperatorType == ExpressionType.Equal)
                        /*LCPI*/ {
                        /*LCPI*/   return newArguments.Aggregate((r, e) => LCPI__Make_LogicalAnd(r, e));
                        /*LCPI*/ }
                        /*LCPI*/
                        /*LCPI*/ Debug.Assert(sourceOperatorType == ExpressionType.NotEqual);
                        /*LCPI*/
                        /*LCPI*/ return newArguments.Aggregate((r, e) => LCPI__Make_LogicalOr(r, e));
                    }

                    if (!sqlFunctionExpression.IsNullable)
                    {
                        // when we know that function can't be nullable:
                        // non_nullable_function() is null-> false
                        // non_nullable_function() is not null -> true
                        return LCPI__Helper__SqlENodeFactory__BoolConstant(
                            sourceOperatorType == ExpressionType.NotEqual);
                    }

                    // see if we can derive function nullability from it's instance and/or arguments
                    // rather than evaluating nullability of the entire function
                    var nullabilityPropagationElements = new List<SqlExpression>();
                    if (sqlFunctionExpression.Instance != null
                        && sqlFunctionExpression.InstancePropagatesNullability == true)
                    {
                        nullabilityPropagationElements.Add(sqlFunctionExpression.Instance);
                    }

                    if (!sqlFunctionExpression.IsNiladic)
                    {
                        for (var i = 0; i < sqlFunctionExpression.Arguments.Count; i++)
                        {
                            if (sqlFunctionExpression.ArgumentsPropagateNullability[i])
                            {
                                nullabilityPropagationElements.Add(sqlFunctionExpression.Arguments[i]);
                            }
                        }
                    }

                    // function(a, b) IS NULL -> a IS NULL || b IS NULL
                    // function(a, b) IS NOT NULL -> a IS NOT NULL && b IS NOT NULL
                    if (nullabilityPropagationElements.Count > 0)
                    {
                        var result = nullabilityPropagationElements
                            .Select(
                                e => LCPI__Make_NullNotNull(
                                        sourceOperatorType,
                                        e,
                                        sourceOperandIsNullable))
                            .Aggregate(
                                (r, e) => sourceOperatorType == ExpressionType.Equal
                                            ? LCPI__Make_LogicalOr(r, e)
                                            : LCPI__Make_LogicalAnd(r, e));

                        return result;
                    }
                }
                break;
            }

            if (!Object.ReferenceEquals(preparedResult.Value,null))
            {
                return preparedResult.Value;
            }

            if (sourceOperatorType == ExpressionType.Equal)
            {
                return LCPI__Helper__SqlENodeFactory__IsNull(sourceOperand);
            }

            Debug.Assert(sourceOperatorType == ExpressionType.NotEqual);

            return LCPI__Helper__SqlENodeFactory__IsNotNull(sourceOperand);
        }//LCPI__Make_NullNotNull

        private static bool IsLogicalNot(SqlUnaryExpression? sqlUnaryExpression)
            => sqlUnaryExpression != null
                && sqlUnaryExpression.OperatorType == ExpressionType.Not
                && sqlUnaryExpression.Type == typeof(bool);

        // ?a == ?b -> [(a == b) && (a != null && b != null)] || (a == null && b == null))
        //
        // a | b | F1 = a == b | F2 = (a != null && b != null) | F3 = F1 && F2 |
        //   |   |             |                               |               |
        // 0 | 0 | 1           | 1                             | 1             |
        // 0 | 1 | 0           | 1                             | 0             |
        // 0 | N | N           | 0                             | 0             |
        // 1 | 0 | 0           | 1                             | 0             |
        // 1 | 1 | 1           | 1                             | 1             |
        // 1 | N | N           | 0                             | 0             |
        // N | 0 | N           | 0                             | 0             |
        // N | 1 | N           | 0                             | 0             |
        // N | N | N           | 0                             | 0             |
        //
        // a | b | F4 = (a == null && b == null) | Final = F3 OR F4 |
        //   |   |                               |                  |
        // 0 | 0 | 0                             | 1 OR 0 = 1       |
        // 0 | 1 | 0                             | 0 OR 0 = 0       |
        // 0 | N | 0                             | 0 OR 0 = 0       |
        // 1 | 0 | 0                             | 0 OR 0 = 0       |
        // 1 | 1 | 0                             | 1 OR 0 = 1       |
        // 1 | N | 0                             | 0 OR 0 = 0       |
        // N | 0 | 0                             | 0 OR 0 = 0       |
        // N | 1 | 0                             | 0 OR 0 = 0       |
        // N | N | 1                             | 0 OR 1 = 1       |
        private SqlExpression ExpandNullableEqualNullable(
            SqlExpression left,
            SqlExpression right,
            SqlExpression leftIsNull,
            SqlExpression leftIsNotNull,
            SqlExpression rightIsNull,
            SqlExpression rightIsNotNull)
            //LCPI: => SimplifyLogicalSqlBinaryExpression(
            //LCPI:     _sqlExpressionFactory.OrElse(
            //LCPI:         SimplifyLogicalSqlBinaryExpression(
            //LCPI:             _sqlExpressionFactory.AndAlso(
            //LCPI:                 _sqlExpressionFactory.Equal(left, right),
            //LCPI:                 SimplifyLogicalSqlBinaryExpression(
            //LCPI:                     _sqlExpressionFactory.AndAlso(leftIsNotNull, rightIsNotNull)))),
            //LCPI:         SimplifyLogicalSqlBinaryExpression(
            //LCPI:             _sqlExpressionFactory.AndAlso(leftIsNull, rightIsNull))));
            /*LCPI*/=> LCPI__Make_LogicalOr(
            /*LCPI*/        LCPI__Make_LogicalAnd(
            /*LCPI*/                LCPI__Helper__SqlENodeFactory__Equal(left, right),
            /*LCPI*/                LCPI__Make_LogicalAnd(leftIsNotNull, rightIsNotNull)),
            /*LCPI*/        LCPI__Make_LogicalAnd(leftIsNull, rightIsNull));

        // !(?a) == ?b -> [(a != b) && (a != null && b != null)] || (a == null && b == null)
        //
        // a | b | F1 = a != b | F2 = (a != null && b != null) | F3 = F1 && F2 |
        //   |   |             |                               |               |
        // 0 | 0 | 0           | 1                             | 0             |
        // 0 | 1 | 1           | 1                             | 1             |
        // 0 | N | N           | 0                             | 0             |
        // 1 | 0 | 1           | 1                             | 1             |
        // 1 | 1 | 0           | 1                             | 0             |
        // 1 | N | N           | 0                             | 0             |
        // N | 0 | N           | 0                             | 0             |
        // N | 1 | N           | 0                             | 0             |
        // N | N | N           | 0                             | 0             |
        //
        // a | b | F4 = (a == null && b == null) | Final = F3 OR F4 |
        //   |   |                               |                  |
        // 0 | 0 | 0                             | 0 OR 0 = 0       |
        // 0 | 1 | 0                             | 1 OR 0 = 1       |
        // 0 | N | 0                             | 0 OR 0 = 0       |
        // 1 | 0 | 0                             | 1 OR 0 = 1       |
        // 1 | 1 | 0                             | 0 OR 0 = 0       |
        // 1 | N | 0                             | 0 OR 0 = 0       |
        // N | 0 | 0                             | 0 OR 0 = 0       |
        // N | 1 | 0                             | 0 OR 0 = 0       |
        // N | N | 1                             | 0 OR 1 = 1       |
        private SqlExpression ExpandNegatedNullableEqualNullable(
            SqlExpression left,
            SqlExpression right,
            SqlExpression leftIsNull,
            SqlExpression leftIsNotNull,
            SqlExpression rightIsNull,
            SqlExpression rightIsNotNull)
            //LCPI: => SimplifyLogicalSqlBinaryExpression(
            //LCPI:     _sqlExpressionFactory.OrElse(
            //LCPI:         SimplifyLogicalSqlBinaryExpression(
            //LCPI:             _sqlExpressionFactory.AndAlso(
            //LCPI:                 _sqlExpressionFactory.NotEqual(left, right),
            //LCPI:                 SimplifyLogicalSqlBinaryExpression(
            //LCPI:                     _sqlExpressionFactory.AndAlso(leftIsNotNull, rightIsNotNull)))),
            //LCPI:         SimplifyLogicalSqlBinaryExpression(
            //LCPI:             _sqlExpressionFactory.AndAlso(leftIsNull, rightIsNull))));
            /*LCPI*/=> LCPI__Make_LogicalOr(
            /*LCPI*/    LCPI__Make_LogicalAnd(
            /*LCPI*/            LCPI__Helper__SqlENodeFactory__NotEqual(left, right),
            /*LCPI*/            LCPI__Make_LogicalAnd(leftIsNotNull, rightIsNotNull)),
            /*LCPI*/    LCPI__Make_LogicalAnd(leftIsNull, rightIsNull));

        // ?a == b -> (a == b) && (a != null)
        //
        // a | b | F1 = a == b | F2 = (a != null) | Final = F1 && F2 |
        //   |   |             |                  |                  |
        // 0 | 0 | 1           | 1                | 1                |
        // 0 | 1 | 0           | 1                | 0                |
        // 1 | 0 | 0           | 1                | 0                |
        // 1 | 1 | 1           | 1                | 1                |
        // N | 0 | N           | 0                | 0                |
        // N | 1 | N           | 0                | 0                |
        private SqlExpression ExpandNullableEqualNonNullable(
            SqlExpression left,
            SqlExpression right,
            SqlExpression leftIsNotNull)
            //LCPI: => SimplifyLogicalSqlBinaryExpression(
            //LCPI:     _sqlExpressionFactory.AndAlso(
            //LCPI:         _sqlExpressionFactory.Equal(left, right),
            //LCPI:         leftIsNotNull));
            /*LCPI*/=> LCPI__Make_LogicalAnd(
            /*LCPI*/    LCPI__Helper__SqlENodeFactory__Equal(left, right),
            /*LCPI*/    leftIsNotNull);

        // !(?a) == b -> (a != b) && (a != null)
        //
        // a | b | F1 = a != b | F2 = (a != null) | Final = F1 && F2 |
        //   |   |             |                  |                  |
        // 0 | 0 | 0           | 1                | 0                |
        // 0 | 1 | 1           | 1                | 1                |
        // 1 | 0 | 1           | 1                | 1                |
        // 1 | 1 | 0           | 1                | 0                |
        // N | 0 | N           | 0                | 0                |
        // N | 1 | N           | 0                | 0                |
        private SqlExpression ExpandNegatedNullableEqualNonNullable(
            SqlExpression left,
            SqlExpression right,
            SqlExpression leftIsNotNull)
            //LCPI: => SimplifyLogicalSqlBinaryExpression(
            //LCPI:     _sqlExpressionFactory.AndAlso(
            //LCPI:         _sqlExpressionFactory.NotEqual(left, right),
            //LCPI:         leftIsNotNull));
            /*LCPI*/=> LCPI__Make_LogicalAnd(
            /*LCPI*/        LCPI__Helper__SqlENodeFactory__NotEqual(left, right),
            /*LCPI*/        leftIsNotNull);

        // ?a != ?b -> [(a != b) || (a == null || b == null)] && (a != null || b != null)
        //
        // a | b | F1 = a != b | F2 = (a == null || b == null) | F3 = F1 || F2 |
        //   |   |             |                               |               |
        // 0 | 0 | 0           | 0                             | 0             |
        // 0 | 1 | 1           | 0                             | 1             |
        // 0 | N | N           | 1                             | 1             |
        // 1 | 0 | 1           | 0                             | 1             |
        // 1 | 1 | 0           | 0                             | 0             |
        // 1 | N | N           | 1                             | 1             |
        // N | 0 | N           | 1                             | 1             |
        // N | 1 | N           | 1                             | 1             |
        // N | N | N           | 1                             | 1             |
        //
        // a | b | F4 = (a != null || b != null) | Final = F3 && F4 |
        //   |   |                               |                  |
        // 0 | 0 | 1                             | 0 && 1 = 0       |
        // 0 | 1 | 1                             | 1 && 1 = 1       |
        // 0 | N | 1                             | 1 && 1 = 1       |
        // 1 | 0 | 1                             | 1 && 1 = 1       |
        // 1 | 1 | 1                             | 0 && 1 = 0       |
        // 1 | N | 1                             | 1 && 1 = 1       |
        // N | 0 | 1                             | 1 && 1 = 1       |
        // N | 1 | 1                             | 1 && 1 = 1       |
        // N | N | 0                             | 1 && 0 = 0       |
        private SqlExpression ExpandNullableNotEqualNullable(
            SqlExpression left,
            SqlExpression right,
            SqlExpression leftIsNull,
            SqlExpression leftIsNotNull,
            SqlExpression rightIsNull,
            SqlExpression rightIsNotNull)
            //LCPI:=> SimplifyLogicalSqlBinaryExpression(
            //LCPI:    _sqlExpressionFactory.AndAlso(
            //LCPI:        SimplifyLogicalSqlBinaryExpression(
            //LCPI:            _sqlExpressionFactory.OrElse(
            //LCPI:                _sqlExpressionFactory.NotEqual(left, right),
            //LCPI:                SimplifyLogicalSqlBinaryExpression(
            //LCPI:                    _sqlExpressionFactory.OrElse(leftIsNull, rightIsNull)))),
            //LCPI:        SimplifyLogicalSqlBinaryExpression(
            //LCPI:            _sqlExpressionFactory.OrElse(leftIsNotNull, rightIsNotNull))));
            /*LCPI*/=> LCPI__Make_LogicalAnd(
            /*LCPI*/        LCPI__Make_LogicalOr(
            /*LCPI*/            LCPI__Helper__SqlENodeFactory__NotEqual(left, right),
            /*LCPI*/            LCPI__Make_LogicalOr(leftIsNull, rightIsNull)),
            /*LCPI*/        LCPI__Make_LogicalOr(leftIsNotNull, rightIsNotNull));

        // !(?a) != ?b -> [(a == b) || (a == null || b == null)] && (a != null || b != null)
        //
        // a | b | F1 = a == b | F2 = (a == null || b == null) | F3 = F1 || F2 |
        //   |   |             |                               |               |
        // 0 | 0 | 1           | 0                             | 1             |
        // 0 | 1 | 0           | 0                             | 0             |
        // 0 | N | N           | 1                             | 1             |
        // 1 | 0 | 0           | 0                             | 0             |
        // 1 | 1 | 1           | 0                             | 1             |
        // 1 | N | N           | 1                             | 1             |
        // N | 0 | N           | 1                             | 1             |
        // N | 1 | N           | 1                             | 1             |
        // N | N | N           | 1                             | 1             |
        //
        // a | b | F4 = (a != null || b != null) | Final = F3 && F4 |
        //   |   |                               |                  |
        // 0 | 0 | 1                             | 1 && 1 = 1       |
        // 0 | 1 | 1                             | 0 && 1 = 0       |
        // 0 | N | 1                             | 1 && 1 = 1       |
        // 1 | 0 | 1                             | 0 && 1 = 0       |
        // 1 | 1 | 1                             | 1 && 1 = 1       |
        // 1 | N | 1                             | 1 && 1 = 1       |
        // N | 0 | 1                             | 1 && 1 = 1       |
        // N | 1 | 1                             | 1 && 1 = 1       |
        // N | N | 0                             | 1 && 0 = 0       |
        private SqlExpression ExpandNegatedNullableNotEqualNullable(
            SqlExpression left,
            SqlExpression right,
            SqlExpression leftIsNull,
            SqlExpression leftIsNotNull,
            SqlExpression rightIsNull,
            SqlExpression rightIsNotNull)
            //LCPI:=> SimplifyLogicalSqlBinaryExpression(
            //LCPI:    _sqlExpressionFactory.AndAlso(
            //LCPI:        SimplifyLogicalSqlBinaryExpression(
            //LCPI:            _sqlExpressionFactory.OrElse(
            //LCPI:                _sqlExpressionFactory.Equal(left, right),
            //LCPI:                SimplifyLogicalSqlBinaryExpression(
            //LCPI:                    _sqlExpressionFactory.OrElse(leftIsNull, rightIsNull)))),
            //LCPI:        SimplifyLogicalSqlBinaryExpression(
            //LCPI:            _sqlExpressionFactory.OrElse(leftIsNotNull, rightIsNotNull))));
            /*LCPI*/=> LCPI__Make_LogicalAnd(
            /*LCPI*/        LCPI__Make_LogicalOr(
            /*LCPI*/            LCPI__Helper__SqlENodeFactory__Equal(left, right),
            /*LCPI*/            LCPI__Make_LogicalOr(leftIsNull, rightIsNull)),
            /*LCPI*/        LCPI__Make_LogicalOr(leftIsNotNull, rightIsNotNull));

        // ?a != b -> (a != b) || (a == null)
        //
        // a | b | F1 = a != b | F2 = (a == null) | Final = F1 OR F2 |
        //   |   |             |                  |                  |
        // 0 | 0 | 0           | 0                | 0                |
        // 0 | 1 | 1           | 0                | 1                |
        // 1 | 0 | 1           | 0                | 1                |
        // 1 | 1 | 0           | 0                | 0                |
        // N | 0 | N           | 1                | 1                |
        // N | 1 | N           | 1                | 1                |
        private SqlExpression ExpandNullableNotEqualNonNullable(
            SqlExpression left,
            SqlExpression right,
            SqlExpression leftIsNull)
            //LCPI:=> SimplifyLogicalSqlBinaryExpression(
            //LCPI:    _sqlExpressionFactory.OrElse(
            //LCPI:        _sqlExpressionFactory.NotEqual(left, right),
            //LCPI:        leftIsNull));
            /*LCPI*/=> LCPI__Make_LogicalOr(
            /*LCPI*/        LCPI__Helper__SqlENodeFactory__NotEqual(left, right),
            /*LCPI*/        leftIsNull);

        // !(?a) != b -> (a == b) || (a == null)
        //
        // a | b | F1 = a == b | F2 = (a == null) | F3 = F1 OR F2 |
        //   |   |             |                  |               |
        // 0 | 0 | 1           | 0                | 1             |
        // 0 | 1 | 0           | 0                | 0             |
        // 1 | 0 | 0           | 0                | 0             |
        // 1 | 1 | 1           | 0                | 1             |
        // N | 0 | N           | 1                | 1             |
        // N | 1 | N           | 1                | 1             |
        private SqlExpression ExpandNegatedNullableNotEqualNonNullable(
            SqlExpression left,
            SqlExpression right,
            SqlExpression leftIsNull)
            //LCPI:=> SimplifyLogicalSqlBinaryExpression(
            //LCPI:    _sqlExpressionFactory.OrElse(
            //LCPI:        _sqlExpressionFactory.Equal(left, right),
            //LCPI:        leftIsNull));
            /*LCPI*/=> LCPI__Make_LogicalOr(
            /*LCPI*/        LCPI__Helper__SqlENodeFactory__Equal(left, right),
            /*LCPI*/        leftIsNull);

        //----------------------------------------------------------------
        private SqlExpression LCPI__Helper__SqlENodeFactory__BoolConstant(bool value)
        {
            if(value)
                return _lcpi_expr_BOOL_TRUE;

            return _lcpi_expr_BOOL_FALSE;
        }//LCPI__Helper__SqlENodeFactory__BoolConstant

        //----------------------------------------------------------------
        //
        // PRIMARY TARGET:
        //
        //  The switch to usage of SqlExpression instead typed subclasses of SqlExpression.
        //

        private SqlExpression LCPI__Helper__SqlENodeFactory__Not(SqlExpression sqlOperand)
        {
            Debug.Assert(!Object.ReferenceEquals(_sqlExpressionFactory,null));

            return _sqlExpressionFactory.Not
                    (sqlOperand);
        }//LCPI__Helper__SqlENodeFactory__Not

        //----------------------------------------------------------------
        private SqlExpression LCPI__Helper__SqlENodeFactory__IsNotNull(SqlExpression sqlOperand)
        {
            Debug.Assert(!Object.ReferenceEquals(_sqlExpressionFactory,null));

            return _sqlExpressionFactory.IsNotNull
                    (sqlOperand);
        }//LCPI__Helper__SqlENodeFactory__IsNotNull

        //----------------------------------------------------------------
        private SqlExpression LCPI__Helper__SqlENodeFactory__IsNull(SqlExpression sqlOperand)
        {
            Debug.Assert(!Object.ReferenceEquals(_sqlExpressionFactory,null));

            return _sqlExpressionFactory.IsNull
                    (sqlOperand);
        }//LCPI__Helper__SqlENodeFactory__IsNull

        //----------------------------------------------------------------
        private SqlExpression LCPI__Helper__SqlENodeFactory__AndAlso
                        (SqlExpression sqlLeft,
                         SqlExpression sqlRight)
        {
            Debug.Assert(!Object.ReferenceEquals(_sqlExpressionFactory,null));

            Debug.Assert(!Object.ReferenceEquals(sqlLeft, null));
            Debug.Assert(!Object.ReferenceEquals(sqlRight, null));

            return _sqlExpressionFactory.AndAlso
                    (sqlLeft,
                     sqlRight);
        }//LCPI__Helper__SqlENodeFactory__AndAlso

        //----------------------------------------------------------------
        private SqlExpression LCPI__Helper__SqlENodeFactory__OrElse
                        (SqlExpression sqlLeft,
                         SqlExpression sqlRight)
        {
            Debug.Assert(!Object.ReferenceEquals(_sqlExpressionFactory,null));

            Debug.Assert(!Object.ReferenceEquals(sqlLeft, null));
            Debug.Assert(!Object.ReferenceEquals(sqlRight, null));

            return _sqlExpressionFactory.OrElse
                    (sqlLeft,
                     sqlRight);
        }//LCPI__Helper__SqlENodeFactory__OrElse

        //----------------------------------------------------------------
        private SqlExpression LCPI__Helper__SqlENodeFactory__Equal
                        (SqlExpression sqlLeft,
                         SqlExpression sqlRight)
        {
            Debug.Assert(!Object.ReferenceEquals(_sqlExpressionFactory,null));

            Debug.Assert(!Object.ReferenceEquals(sqlLeft, null));
            Debug.Assert(!Object.ReferenceEquals(sqlRight, null));

            return _sqlExpressionFactory.Equal
                    (sqlLeft,
                     sqlRight);
        }//LCPI__Helper__SqlENodeFactory__Equal

        //----------------------------------------------------------------
        private SqlExpression LCPI__Helper__SqlENodeFactory__NotEqual
                        (SqlExpression sqlLeft,
                         SqlExpression sqlRight)
        {
            Debug.Assert(!Object.ReferenceEquals(_sqlExpressionFactory,null));

            Debug.Assert(!Object.ReferenceEquals(sqlLeft, null));
            Debug.Assert(!Object.ReferenceEquals(sqlRight, null));

            return _sqlExpressionFactory.NotEqual
                    (sqlLeft,
                     sqlRight);
        }//LCPI__Helper__SqlENodeFactory__NotEqual

        //----------------------------------------------------------------
        private SqlExpression LCPI__Helper__SqlENodeFactory__MakeBinary
                        (ExpressionType         operatorType,
                         SqlExpression          sqlLeft,
                         SqlExpression          sqlRight,
                         RelationalTypeMapping? resultTypeMapping)
        {
            Debug.Assert(!Object.ReferenceEquals(_sqlExpressionFactory,null));

            Debug.Assert(!Object.ReferenceEquals(sqlLeft, null));
            Debug.Assert(!Object.ReferenceEquals(sqlRight, null));

            var r=_sqlExpressionFactory.MakeBinary
                    (operatorType,
                     sqlLeft,
                     sqlRight,
                     resultTypeMapping);

           return Check.NotNull
                    (r,
                     nameof(r));
        }//LCPI__Helper__SqlENodeFactory__MakeBinary

        //----------------------------------------------------------------
        private SqlExpression LCPI__Helper__SqlENodeFactory__Coalesce
                        (SqlExpression          sqlLeft,
                         SqlExpression          sqlRight,
                         RelationalTypeMapping? typeMapping=null)
        {
            Debug.Assert(!Object.ReferenceEquals(_sqlExpressionFactory,null));

            Debug.Assert(!Object.ReferenceEquals(sqlLeft, null));
            Debug.Assert(!Object.ReferenceEquals(sqlRight, null));

            return _sqlExpressionFactory.Coalesce
                    (sqlLeft,
                     sqlRight);
        }//LCPI__Helper__SqlENodeFactory__Coalesce

        //----------------------------------------------------------------
        private SqlConstantExpression LCPI__Helper__SqlENodeFactory__Constant
                        (object?                value,
                         RelationalTypeMapping? typeMapping)
        {
            Debug.Assert(!Object.ReferenceEquals(_sqlExpressionFactory,null));

            return _sqlExpressionFactory.Constant
                    (value,
                     typeMapping);
        }//LCPI__Helper__SqlENodeFactory__Constant
    }
}

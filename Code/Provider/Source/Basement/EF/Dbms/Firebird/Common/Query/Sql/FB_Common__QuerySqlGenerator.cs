////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 07.05.2019.
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql{
////////////////////////////////////////////////////////////////////////////////

using Structure_TypeCache
 =Structure.Structure_TypeCache;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__QuerySqlGenerator

sealed class FB_Common__QuerySqlGenerator:QuerySqlGenerator
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__QuerySqlGenerator;

 //constructor -----------------------------------------------------------
 public FB_Common__QuerySqlGenerator(QuerySqlGeneratorDependencies                dependencies,
                                     Core.Core_ConnectionOptions                  cnOptions,
                                     FB_Common__IQuerySqlPartGenerator__Parameter sqlPartGenerator__Parameter)
  :base(dependencies)
 {
  Debug.Assert(!Object.ReferenceEquals(cnOptions,null));
  Debug.Assert(!Object.ReferenceEquals(sqlPartGenerator__Parameter,null));

#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__QuerySqlGenerator::FB_Common__QuerySqlGenerator()");
#endif

  //----------------------------------------
  m_cnOptions                   =cnOptions;
  m_sqlPartGenerator__Parameter =sqlPartGenerator__Parameter;
 }//FB_Common__QuerySqlGenerator

 //own interface ---------------------------------------------------------
 public new IRelationalCommandBuilder Sql
 {
  get
  {
   return base.Sql;
  }//get
 }//Sql

 //-----------------------------------------------------------------------
 public Core.Core_ConnectionOptions CnOptions
 {
  get
  {
   Debug.Assert(!Object.ReferenceEquals(m_cnOptions,null));

   return m_cnOptions;
  }//get
 }//CnOptions

 //-----------------------------------------------------------------------
 public void VisitAndWrapIntoBrackets(SqlExpression sqlExpression,
                                      SqlExpression sqlParentExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlExpression,null));

  if(!Helper__RequiresBrackets(sqlExpression,sqlParentExpression))
  {
   this.Visit(sqlExpression);
  }
  else
  {
   this.Sql.Append("(");
   this.Visit(sqlExpression);
   this.Sql.Append(")");
  }//else
 }//VisitAndWrapIntoBrackets

 //-----------------------------------------------------------------------
 public void VisitSqlParameter_base(SqlParameterExpression sqlParameterExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlParameterExpression,null));

  base.VisitSqlParameter(sqlParameterExpression);
 }//VisitSqlParameter_base

 //QuerySqlGenerator interface -------------------------------------------
 protected override Expression VisitSelect(SelectExpression selectExpression)
 {
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(VisitSelect),
    nameof(selectExpression),
    selectExpression);

  if(Helper__IsNonComposedSetOperation(selectExpression))
  {
   // Naked set operation
   this.GenerateSetOperation((SetOperationBase)selectExpression.Tables[0]);

   return selectExpression;
  }//if

  IDisposable subQueryIndent=null;

  if(selectExpression.Alias!=null)
  {
   this.Sql.AppendLine("(");

   subQueryIndent=this.Sql.Indent();
  }//if

  this.Sql.Append("SELECT ");

  this.Helper__GenerateFirstSkip(selectExpression);

  if(selectExpression.IsDistinct)
  {
   this.Sql.Append("DISTINCT ");
  }//if

  //
  // [2021-09-07] See Helper__GenerateFirstSkip
  //
  //this.GenerateTop(selectExpression);

  if(selectExpression.Projection.Any())
  {
   this.Helper__GenerateList
    (selectExpression.Projection,
     e => Visit(e));
  }
  else
  {
   this.Sql.Append("1");
  }//else

  if(selectExpression.Tables.Any())
  {
   this.Sql.AppendLine().Append("FROM ");

   this.Helper__GenerateList
    (selectExpression.Tables,
     e => Visit(e),
     sql => sql.AppendLine());
  }
  else
  {
   this.GeneratePseudoFromClause();
  }//else

  if(selectExpression.Predicate!=null)
  {
   this.Sql.AppendLine().Append("WHERE ");

   this.Visit(selectExpression.Predicate);
  }//if

  if(selectExpression.GroupBy.Count>0)
  {
   this.Sql.AppendLine().Append("GROUP BY ");

   this.Helper__GenerateList
    (selectExpression.GroupBy,
     e => Visit(e));
  }//if

  if(selectExpression.Having!=null)
  {
   this.Sql.AppendLine().Append("HAVING ");

   this.Visit(selectExpression.Having);
  }//if

  this.GenerateOrderings(selectExpression);

  //
  // [2021-09-07] replaced by Helper__GenerateFirstSkip
  //
  //this.GenerateLimitOffset(selectExpression);

  if(selectExpression.Alias!=null)
  {
   subQueryIndent!.Dispose();

   this
    .Sql
    .AppendLine()
    .Append(")")
    .Append(AliasSeparator)
    .Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(selectExpression.Alias));
  }//if

  return selectExpression;
 }//VisitSelect

 //-----------------------------------------------------------------------
 private void Helper__GenerateFirstSkip(SelectExpression selectExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(selectExpression,null));

  var limit
   =selectExpression.Limit;

  var offset
   =selectExpression.Offset;

  if(!Object.ReferenceEquals(limit,null))
  {
   this.Sql.Append("FIRST (");
   this.Visit(limit);
   this.Sql.Append(") ");
  }//if limit!=null

  if(!Object.ReferenceEquals(offset,null))
  {
   this.Sql.Append("SKIP (");
   this.Visit(offset);
   this.Sql.Append(") ");
  }//if offset!=null
 }//Helper__GenerateFirstSkip

 //-----------------------------------------------------------------------
 private void Helper__GenerateList<T>(IReadOnlyList<T>                  items,
                                      Action<T>                         generationAction,
                                      Action<IRelationalCommandBuilder> joinAction = null)
 {
  joinAction??=(isb=>isb.Append(", "));

  for(var i=0;i<items.Count;++i)
  {
   if(i>0)
   {
    joinAction(this.Sql);
   }

   generationAction(items[i]);
  }//for i
 }//Helper__GenerateList

 //-----------------------------------------------------------------------
 private bool Helper__IsNonComposedSetOperation(SelectExpression selectExpression)
 {
  return selectExpression.Offset == null
         && selectExpression.Limit == null
         && !selectExpression.IsDistinct
         && selectExpression.Predicate == null
         && selectExpression.Having == null
         && selectExpression.Orderings.Count == 0
         && selectExpression.GroupBy.Count == 0
         && selectExpression.Tables.Count == 1
         && selectExpression.Tables[0] is SetOperationBase setOperation
         && selectExpression.Projection.Count == setOperation.Source1.Projection.Count
         && selectExpression.Projection.Select
             ((pe, index)
                => pe.Expression is ColumnExpression column
                   && string.Equals(column.TableAlias, setOperation.Alias, StringComparison.OrdinalIgnoreCase)
                   && string.Equals(column.Name, setOperation.Source1.Projection[index].Alias, StringComparison.OrdinalIgnoreCase))
             .All(e => e);
 }//Helper__IsNonComposedSetOperation

 //-----------------------------------------------------------------------
 protected override Expression VisitSqlParameter(SqlParameterExpression sqlParameterExpression)
 {
  // [2021-09-07] Reviewed.

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(VisitSqlParameter),
    nameof(sqlParameterExpression),
    sqlParameterExpression);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(VisitSqlParameter),
    "sqlParameterExpression.TypeMapping",
    sqlParameterExpression.TypeMapping);

  //------------------------------------------------------------
  Debug.Assert(!Object.ReferenceEquals(m_sqlPartGenerator__Parameter,null));

  m_sqlPartGenerator__Parameter.Exec
   (this,
    sqlParameterExpression);

  return sqlParameterExpression;
 }//VisitSqlParameter

 //-----------------------------------------------------------------------
 protected override Expression VisitSqlBinary(SqlBinaryExpression sqlBinaryExpression)
 {
  // [2021-09-07] Reviewed.

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(VisitSqlBinary),
    nameof(sqlBinaryExpression),
    sqlBinaryExpression);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(VisitSqlBinary),
    "sqlBinaryExpression.Left",
    sqlBinaryExpression.Left);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(VisitSqlBinary),
    "sqlBinaryExpression.Right",
    sqlBinaryExpression.Right);

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(sqlBinaryExpression,null));
  Debug.Assert(!Object.ReferenceEquals(sqlBinaryExpression.Left,null));
  Debug.Assert(!Object.ReferenceEquals(sqlBinaryExpression.Right,null));

  //------------------------------------------------------------
  this.VisitAndWrapIntoBrackets(sqlBinaryExpression.Left,sqlBinaryExpression);

  Sql.Append(this.GetOperator(sqlBinaryExpression));

  this.VisitAndWrapIntoBrackets(sqlBinaryExpression.Right,sqlBinaryExpression);

  return sqlBinaryExpression;
 }//VisitSqlBinary

 //-----------------------------------------------------------------------
 protected override Expression VisitSqlUnary(SqlUnaryExpression sqlUnaryExpression)
 {
  // [2021-09-07] Reviewed.

  const string c_bugcheck_src
   ="FB_Common__QuerySqlGenerator::VisitSqlUnary";

  //------------------------------------------------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(VisitSqlUnary),
    nameof(sqlUnaryExpression),
    sqlUnaryExpression);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(VisitSqlUnary),
    "sqlUnaryExpression.Operand",
    sqlUnaryExpression.Operand);

  //------------------------------------------------------------
  Debug.Assert(!Object.ReferenceEquals(sqlUnaryExpression,null));
  Debug.Assert(!Object.ReferenceEquals(sqlUnaryExpression.Operand,null));

  //------------------------------------------------------------
  switch(sqlUnaryExpression.OperatorType)
  {
   //
   // [2021-10-04] Bye. Functional was moved on the ENODE level.
   //
   // case ExpressionType.Convert:
   // {
   //  m_sqlPartGenerator__Convert.Exec(this,sqlUnaryExpression);
   //  break;
   // }//Convert

   case ExpressionType.Not when sqlUnaryExpression.Type == Structure_TypeCache.TypeOf__System_Boolean:
   {
    this.Sql.Append("NOT ");
    this.VisitAndWrapIntoBrackets(sqlUnaryExpression.Operand,sqlUnaryExpression);
    break;
   }//Not

   //
   // NOT SUPPORTED
   //
   // case ExpressionType.Not:
   // {
   //  this.Sql.Append("~");
   //  this.VisitAndWrapIntoBrackets(sqlUnaryExpression.Operand);
   //  break;
   // }//Not

   //
   // [2021-10-09] Bye. Functional was moved on the ENODE level.
   //
   // case ExpressionType.Equal:
   // {
   //  this.VisitAndWrapIntoBrackets(sqlUnaryExpression.Operand,sqlUnaryExpression);
   //  this.Sql.Append(" IS NULL");
   //  break;
   // }//Equal
   // 
   // case ExpressionType.NotEqual:
   // {
   //  this.VisitAndWrapIntoBrackets(sqlUnaryExpression.Operand,sqlUnaryExpression);
   //  this.Sql.Append(" IS NOT NULL");
   //  break;
   // }//NotEqual
   //
   // case ExpressionType.Negate:
   // {
   //  this.Sql.Append("-");
   //  this.VisitAndWrapIntoBrackets(sqlUnaryExpression.Operand,sqlUnaryExpression);
   //  break;
   // }//Negate

   default:
   {
    //
    // [2020-12-23]
    //
    // BUG CHECK, because we should prevent generation of SQL tree
    // with unsupported operations.
    //

    ThrowBugCheck.unexpected_operator_type
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      sqlUnaryExpression.OperatorType);

    break;
   }//default
  }//switch

  return sqlUnaryExpression;
 }//VisitSqlUnary

 //-----------------------------------------------------------------------
 protected override string GetOperator(SqlBinaryExpression sqlBinaryExpression)
 {
  // [2021-09-07] Reviewed.

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(GetOperator),
    nameof(sqlBinaryExpression),
    sqlBinaryExpression);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(GetOperator),
    "sqlBinaryExpression.Left",
    sqlBinaryExpression.Left);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(GetOperator),
    "sqlBinaryExpression.Right",
    sqlBinaryExpression.Right);

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(sqlBinaryExpression,null));
  Debug.Assert(!Object.ReferenceEquals(sqlBinaryExpression.Left,null));
  Debug.Assert(!Object.ReferenceEquals(sqlBinaryExpression.Right,null));

  switch(sqlBinaryExpression.OperatorType)
  {
   case ExpressionType.Add:
    return this.Helper__GetOperator__Add(sqlBinaryExpression);
  }//switch

  return Helper__GetOperator__STD(sqlBinaryExpression);
 }//GetOperator

 //-----------------------------------------------------------------------
 protected override void GeneratePseudoFromClause()
 {
  // [2021-09-07] Reviewed.

  this.Sql.Append(" FROM RDB$DATABASE");
 }//GeneratePseudoFromClause

 //-----------------------------------------------------------------------
 protected override void GenerateTop(SelectExpression selectExpression)
 {
  // [2021-09-07] Reviewed.

  Debug.Assert(!Object.ReferenceEquals(selectExpression,null));

  // [2021-09-07] Call not expected.

  ThrowBugCheck.incorrect_call_of_method
   (c_ErrSrcID,
    "FB_Common__QuerySqlGenerator::GenerateTop",
    "#001");
 }//GenerateTop

 //-----------------------------------------------------------------------
 protected override void GenerateLimitOffset(SelectExpression selectExpression)
 {
  // [2021-09-07] Reviewed.

  Debug.Assert(!Object.ReferenceEquals(selectExpression,null));

  //
  // Firebird 3.0 does't support an expression like 'CAST(? AS INTEGER)' as
  // argument of "OFFSET FETCH".
  //
  // Usage of ROWS, with their "+1" and "long.MaxValue", looks ugly.
  //
  // So, will use "FIRST SKIP" in Helper__GenerateFirstSkip, and be happy.
  //

  // [2021-09-07] Call not expected.

  ThrowBugCheck.incorrect_call_of_method
   (c_ErrSrcID,
    "FB_Common__QuerySqlGenerator::GenerateLimitOffset",
    "#001");
 }//GenerateLimitOffset

 //-----------------------------------------------------------------------
 protected override Expression VisitOrdering(OrderingExpression orderingExpression)
 {
  // [2021-09-07] Reviewed.

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(VisitOrdering),
    nameof(orderingExpression),
    orderingExpression);

  // [2021-09-07] Research.
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(VisitOrdering),
    "orderingExpression.Expression",
    orderingExpression.Expression);

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(orderingExpression,null));
  Debug.Assert(!Object.ReferenceEquals(orderingExpression.Expression,null));

  if(Helper__TestOrderingExpression__ToSelect1(orderingExpression.Expression))
  {
   this.Sql.Append("(SELECT 1");
   this.GeneratePseudoFromClause();
   this.Sql.Append(")");
  }
  else
  {
   this.Visit(orderingExpression.Expression);
  }//else

  if(!orderingExpression.IsAscending)
  {
   this.Sql.Append(" DESC");
  }//if

  return orderingExpression;
 }//VisitOrdering

 //-----------------------------------------------------------------------
 protected override Expression VisitLike(LikeExpression likeExpression)
 {
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(VisitLike),
    nameof(likeExpression),
    likeExpression);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(VisitLike),
    "likeExpression.Match",
    likeExpression.Match);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(VisitLike),
    "likeExpression.Pattern",
    likeExpression.Pattern);

  //-----------------------------------------------------------------
  this.VisitAndWrapIntoBrackets(likeExpression.Match,likeExpression);

  this.Sql.Append(" LIKE ");

  this.VisitAndWrapIntoBrackets(likeExpression.Pattern,likeExpression);

  if(!Object.ReferenceEquals(likeExpression.EscapeChar,null))
  {
   this.Sql.Append(" ESCAPE ");

   this.VisitAndWrapIntoBrackets(likeExpression.EscapeChar,likeExpression);
  }//if

  return likeExpression;
 }//VisitLike

 //-----------------------------------------------------------------------
 private static bool Helper__TestOrderingExpression__ToSelect1(SqlExpression sqlExpression)
 {
  if(sqlExpression is SqlConstantExpression)
   return true;

  if(sqlExpression is SqlParameterExpression)
   return true;

  if(sqlExpression is SqlFragmentExpression sqlFragment)
  {
   //
   // Special support for SelectExpression.AddJoin ?
   //
   if(sqlFragment.Sql.Equals("(SELECT 1)", StringComparison.Ordinal))
    return true;

   return false;
  }//if

  return false;
 }//Helper__TestOrderingExpression__ToSelect1

 //Helper methods --------------------------------------------------------
 private string Helper__GetOperator__Add(SqlBinaryExpression sqlBinaryExpression)
 {
  // [2021-09-07] Reviewed.

  Debug.Assert(!Object.ReferenceEquals(sqlBinaryExpression,null));

  Debug.Assert(sqlBinaryExpression.OperatorType==ExpressionType.Add);

  if(Core.SQL.Core_SQL__TestExpressionKind.IsStringConcatenation2(sqlBinaryExpression))
  {
   return "||";
  }//if

  return Helper__GetOperator__STD(sqlBinaryExpression);
 }//Helper__GetOperator__Add

 //-----------------------------------------------------------------------
 private string Helper__GetOperator__STD(SqlBinaryExpression sqlBinaryExpression)
 {
  // [2021-09-07] Reviewed.

  Debug.Assert(!Object.ReferenceEquals(sqlBinaryExpression,null));

  Debug.Assert(!Object.ReferenceEquals(sm_stdOperatorMap,null));

  //----------------------------------------
  const string c_bugcheck_src
   ="FB_Common__QuerySqlGenerator::Helper__GetOperator__STD";

  string opSign;

  if(!sm_stdOperatorMap.TryGetValue(sqlBinaryExpression.OperatorType,out opSign))
  {
   //ERROR - WTF. [BUG CHECK] Unsupported binary operator.

   ThrowBugCheck.unexpected_operator_type
    (c_ErrSrcID,
     c_bugcheck_src,
     "#001",
     sqlBinaryExpression.OperatorType);

   Debug.Assert(false);
  }//if - not found

  Debug.Assert(!Object.ReferenceEquals(opSign,null));
  Debug.Assert(opSign.Trim().Length>0);

  return opSign;
 }//Helper__GetOperator__STD

 //-----------------------------------------------------------------------
 public static bool Helper__RequiresBrackets(SqlExpression sqlTestExpression,
                                             SqlExpression sqlParentExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlTestExpression,null));

  if(sqlTestExpression is Expressions.Tags.FB_Common__Sql_ETag__RequiresBrackets e)
   return e.RequiresBrackets(sqlParentExpression);

  if(sqlTestExpression is LikeExpression)
   return true;

  if(sqlTestExpression is SqlUnaryExpression unaryExpression)
  {
   if(unaryExpression.OperatorType == ExpressionType.Equal ||
      unaryExpression.OperatorType == ExpressionType.NotEqual)
   {
    //
    // [2021-09-05]
    //
    // Generation:
    //  (a IS NULL)
    //  (a IS NOT NULL)
    //
    // Reasons:
    //  1. Improving of readable
    //  2. Preventing of ANY problem with priority of calculations
    //

    return true;
   }//if

   return false;
  }//if - SqlUnaryExpression

  if(sqlTestExpression is SqlBinaryExpression binaryExpression)
  {
   if(Core.SQL.Core_SQL__TestExpressionKind.IsStringConcatenation(binaryExpression))
   {
    if(!Object.ReferenceEquals(sqlParentExpression,null))
    {
     if(Core.SQL.Core_SQL__TestExpressionKind.IsStringConcatenation(sqlParentExpression))
     {
      //special support for "a || b || c"

      return false;
     }//if
    }//if
   }//if
   else
   if(Core.SQL.Core_SQL__TestExpressionKind.IsLogicalOrElse(binaryExpression))
   {
    if(!Object.ReferenceEquals(sqlParentExpression,null))
    {
     if(Core.SQL.Core_SQL__TestExpressionKind.IsLogicalOrElse(sqlParentExpression))
     {
      //special support for "a OR b OR c"

      return false;
     }//if
    }//if
   }//if
   else
   if(Core.SQL.Core_SQL__TestExpressionKind.IsLogicalAndAlso(binaryExpression))
   {
    if(!Object.ReferenceEquals(sqlParentExpression,null))
    {
     if(Core.SQL.Core_SQL__TestExpressionKind.IsLogicalAndAlso(sqlParentExpression))
     {
      //special support for "a AND b AND c"

      return false;
     }//if
    }//if
   }//if

   return true;
  }//if - SqlBinaryExpression

  return false;
 }//Helper__RequiresBrackets

 //private data ----------------------------------------------------------
 private readonly Core.Core_ConnectionOptions
  m_cnOptions;

 private readonly FB_Common__IQuerySqlPartGenerator__Parameter
  m_sqlPartGenerator__Parameter;

 //-----------------------------------------------------------------------
 private static readonly Dictionary<ExpressionType,string>
  sm_stdOperatorMap
   =new Dictionary<ExpressionType,string>
     {
      { ExpressionType.Equal              , " = "   },
      { ExpressionType.NotEqual           , " <> "  },
      { ExpressionType.GreaterThan        , " > "   },
      { ExpressionType.GreaterThanOrEqual , " >= "  },
      { ExpressionType.LessThan           , " < "   },
      { ExpressionType.LessThanOrEqual    , " <= "  },
      { ExpressionType.AndAlso            , " AND " },
      { ExpressionType.OrElse             , " OR "  },
      { ExpressionType.Add                , " + "   },
      { ExpressionType.Subtract           , " - "   },
      { ExpressionType.Multiply           , " * "   },
      { ExpressionType.Divide             , " / "   }
     };//sm_stdOperatorMap
};//class FB_Common__QuerySqlGenerator

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql

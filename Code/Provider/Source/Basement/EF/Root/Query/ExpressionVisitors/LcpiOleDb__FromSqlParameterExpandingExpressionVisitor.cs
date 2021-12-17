////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 02.09.2021.
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.ExpressionVisitors{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_LegacyReferenceEqualityComparer
 =Structure.Structure_LegacyReferenceEqualityComparer;

////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__FromSqlParameterExpandingExpressionVisitor

sealed class LcpiOleDb__FromSqlParameterExpandingExpressionVisitor
 :ExpressionVisitor
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.LcpiOleDb__FromSqlParameterExpandingExpressionVisitor;

 //-----------------------------------------------------------------------
 private LcpiOleDb__FromSqlParameterExpandingExpressionVisitor
    (RelationalParameterBasedSqlProcessorDependencies dependencies,
     Core.Core_ConnectionOptions                      cnOptions,
     IReadOnlyDictionary<string,object>               parameterValues)
 {
  Debug.Assert(!Object.ReferenceEquals(dependencies,null));
  Debug.Assert(!Object.ReferenceEquals(cnOptions,null));

  m_visitedFromSqlExpressions
   =new Dictionary<FromSqlExpression,Expression>
     (Structure_LegacyReferenceEqualityComparer.Instance);

  m_sqlExpressionFactory      = dependencies.SqlExpressionFactory;
  m_typeMappingSource         = dependencies.TypeMappingSource;
  m_parameterNameGenerator    = dependencies.ParameterNameGeneratorFactory.Create();

  //---------------------
  m_EngineSvc__CommandParameterNameBuilder
   =Core.Core_SvcUtils.QuerySvc<Core.Engines.EngineSvc__CommandParameterNameBuilder>
     (cnOptions,
      Core.Engines.EngineSvcID.EngineSvc__CommandParameterNameBuilder);

  Debug.Assert(!Object.ReferenceEquals(m_EngineSvc__CommandParameterNameBuilder,null));

  //---------------------
  m_parametersValues          = parameterValues;
  m_canCache                  = true;
 }//LcpiOleDb__FromSqlParameterExpandingExpressionVisitor

 //-----------------------------------------------------------------------
 public static SelectExpression Expand(RelationalParameterBasedSqlProcessorDependencies dependencies,
                                       Core.Core_ConnectionOptions                      cnOptions,
                                       SelectExpression                                 selectExpression,
                                       IReadOnlyDictionary<string, object>              parameterValues,
                                       out bool                                         canCache)
 {
  Debug.Assert(!Object.ReferenceEquals(dependencies,null));
  Debug.Assert(!Object.ReferenceEquals(cnOptions,null));
  Debug.Assert(!Object.ReferenceEquals(cnOptions,null));
  Debug.Assert(!Object.ReferenceEquals(selectExpression,null));
  Debug.Assert(!Object.ReferenceEquals(parameterValues,null));

  const string c_bugcheck_src
   ="LcpiOleDb__FromSqlParameterExpandingExpressionVisitor.Expand";

  //----------------------------------------------------------------------
  var visitor
   =new LcpiOleDb__FromSqlParameterExpandingExpressionVisitor
     (dependencies,
      cnOptions,
      parameterValues);

  var result_e
   =visitor.Visit
    (selectExpression);

  var result
   =Check.BugCheck_Value_NotNullAndInstanceOf<SelectExpression,Expression>
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      nameof(result_e),
      result_e);

  canCache
   =visitor.m_canCache;

  return result;
 }//Expand

 //ExpressionVisitor interface -------------------------------------------
 public override Expression Visit(Expression expression)
 {
  if(expression is FromSqlExpression fromSql)
  {
   Expression cachedExpression;

   if(m_visitedFromSqlExpressions.TryGetValue(fromSql, out cachedExpression))
   {
    Debug.Assert(!Object.ReferenceEquals(cachedExpression,null));

    return cachedExpression;
   }//if

   cachedExpression
    =this.Helper__VisitFromSqlExpression
      (fromSql);

   Debug.Assert(!Object.ReferenceEquals(cachedExpression,null));

   m_visitedFromSqlExpressions.Add
    (fromSql,
     cachedExpression);

   return cachedExpression;
  }//if FromSqlExpression

  return base.Visit(expression);
 }//Visit

 //Helper method ---------------------------------------------------------
 private Expression Helper__VisitFromSqlExpression(FromSqlExpression fromSql)
 {
  const string c_bugcheck_src
   ="LcpiOleDb__FromSqlParameterExpandingExpressionVisitor.Helper__VisitFromSqlExpression";

  if(fromSql.Arguments is ParameterExpression parameterExpression)
  {
   // parameter value will never be null. It could be empty object[]
   var parameterValues=(object[])m_parametersValues[parameterExpression.Name!]!;

   m_canCache=false;

   var subParameters=new List<IRelationalParameter>(parameterValues.Length);

   // ReSharper disable once ForCanBeConvertedToForeach
   for (var i = 0; i < parameterValues.Length; i++)
   {
    var invariantParameterName=m_parameterNameGenerator.GenerateNext();

    if(parameterValues[i] is DbParameter dbParameter)
    {
     if(string.IsNullOrEmpty(dbParameter.ParameterName))
     {
      dbParameter.ParameterName=m_EngineSvc__CommandParameterNameBuilder.GenParameterName(invariantParameterName);
     }
     else
     {
      invariantParameterName=m_EngineSvc__CommandParameterNameBuilder.ExtractInvariantParameterName(dbParameter.ParameterName);
     }

     subParameters.Add
      (new RawRelationalParameter
        (invariantParameterName,
         dbParameter));
    }
    else
    {
     subParameters.Add
      (new TypeMappedRelationalParameter
        (invariantParameterName,
         m_EngineSvc__CommandParameterNameBuilder.GenParameterName(invariantParameterName),
         m_typeMappingSource.GetMappingForValue(parameterValues[i]),//
         parameterValues[i]?.GetType().IsNullableType()));//
    }//else
   }//for

   var r
    =fromSql.Update
     (Expression.Constant
       (new CompositeRelationalParameter
         (parameterExpression.Name!,
          subParameters)));

   Debug.Assert(!Object.ReferenceEquals(r,null));

   return r;
  }//fromSql.Arguments is ParameterExpression

  if(fromSql.Arguments is ConstantExpression constantExpression)
  {
   var existingValues
    =Check.BugCheck_Value_NotNullAndInstanceOf<object[],object>
      (c_ErrSrcID,
       c_bugcheck_src,
       "#001",
       "constantExpression.Value",
       constantExpression.Value);

   var constantValues=new object[existingValues.Length];

   for(var i=0;i<existingValues.Length;++i)
   {
    var value = existingValues[i];

    if(value is DbParameter dbParameter)
    {
     var invariantParameterName=m_parameterNameGenerator.GenerateNext();

     if(string.IsNullOrEmpty(dbParameter.ParameterName))
     {
      dbParameter.ParameterName=m_EngineSvc__CommandParameterNameBuilder.GenParameterName(invariantParameterName);
     }
     else
     {
      invariantParameterName=m_EngineSvc__CommandParameterNameBuilder.ExtractInvariantParameterName(dbParameter.ParameterName);
     }

     constantValues[i]
      =new RawRelationalParameter
        (invariantParameterName,
         dbParameter);
    }
    else
    {
     constantValues[i]
      =m_sqlExpressionFactory.Constant
        (value,
         m_typeMappingSource.GetMappingForValue(value));
    }//else
   }//for

   var r
    =fromSql.Update
      (Expression.Constant(constantValues, typeof(object[])));

   Debug.Assert(!Object.ReferenceEquals(r,null));

   return r;
  }//if

  Debug.Assert(false);

  ThrowBugCheck.incorrect_call_of_method
   (c_ErrSrcID,
    c_bugcheck_src,
    "#001");

  return null;
 }//Helper__VisitFromSqlExpression

 //Private data ----------------------------------------------------------
 private readonly IDictionary<FromSqlExpression,Expression> m_visitedFromSqlExpressions;

 private readonly ISqlExpressionFactory m_sqlExpressionFactory;

 private readonly IRelationalTypeMappingSource m_typeMappingSource;

 private readonly ParameterNameGenerator m_parameterNameGenerator;

 //-----------------------------------------------------------------------
 private readonly Core.Engines.EngineSvc__CommandParameterNameBuilder
  m_EngineSvc__CommandParameterNameBuilder; //Not null

 //-----------------------------------------------------------------------
 private readonly IReadOnlyDictionary<string, object>
  m_parametersValues;

 private bool m_canCache;
};//class LcpiOleDb__FromSqlParameterExpandingExpressionVisitor

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.ExpressionVisitors

////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 03.09.2021.
using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query{
////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0__QueryTranslationPostprocessor

sealed class FB_V03_0_0__QueryTranslationPostprocessor:RelationalQueryTranslationPostprocessor
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_V03_0_0__QueryTranslationPostprocessor;

 //-----------------------------------------------------------------------
 public FB_V03_0_0__QueryTranslationPostprocessor
   (QueryTranslationPostprocessorDependencies           dependencies,
    RelationalQueryTranslationPostprocessorDependencies relationalDependencies,
    QueryCompilationContext                             queryCompilationContext)
  :base(dependencies, relationalDependencies, queryCompilationContext)
 {
 }

 //-----------------------------------------------------------------------
 public override Expression Process(Expression query)
 {
  var result=base.Process(query);

  sm_notSupportedValidator.Visit(result);

  return result;
 }//Process

 //Helper types ----------------------------------------------------------
 private sealed class tagNotSupportedOpValidatingVisitor:ExpressionVisitor
 {
  protected override Expression VisitExtension(Expression extensionExpression)
  {
   if(extensionExpression is ShapedQueryExpression shapedQueryExpression)
   {
    this.Visit(shapedQueryExpression.QueryExpression);
    this.Visit(shapedQueryExpression.ShaperExpression);

    return extensionExpression;
   }//if

   if(extensionExpression is SelectExpression selectExpression)
   {
    foreach(var table in selectExpression.Tables)
    {
     if(table is CrossApplyExpression)
     {
      ThrowError.SqlGenErr__NotSupportedSqlOperator__APPLY
       (c_ErrSrcID);
     }//if

     if(table is OuterApplyExpression)
     {
      ThrowError.SqlGenErr__NotSupportedSqlOperator__APPLY
       (c_ErrSrcID);
     }//if

     if(table is IntersectExpression)
     {
      ThrowError.SqlGenErr__NotSupportedSqlOperator__INTERSECT
       (c_ErrSrcID);
     }//if

     if(table is ExceptExpression)
     {
      ThrowError.SqlGenErr__NotSupportedSqlOperator__EXCEPT
       (c_ErrSrcID);
     }//if
    }//for[ever]
   }//if SelectExpression

   return base.VisitExtension(extensionExpression);
  }//VisitExtension
 };//class tagNotSupportedOpValidatingVisitor

 //Helper data -----------------------------------------------------------
 private static readonly tagNotSupportedOpValidatingVisitor
  sm_notSupportedValidator
   =new tagNotSupportedOpValidatingVisitor();
};//class FB_V03_0_0__QueryTranslationPostprocessor

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query

////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 18.05.2018.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.ExpressionVisitors{
////////////////////////////////////////////////////////////////////////////////
//Using

using Structure_MethodIdCache
 =Structure.Structure_MethodIdCache;

////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__SqlTranslatingExpressionVisitor

sealed partial class LcpiOleDb__SqlTranslatingExpressionVisitor
 :RelationalSqlTranslatingExpressionVisitor
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.LcpiOleDb__SqlTranslatingExpressionVisitor;

 //-----------------------------------------------------------------------
 public LcpiOleDb__SqlTranslatingExpressionVisitor
         (RelationalSqlTranslatingExpressionVisitorDependencies dependencies,
          LcpiOleDb__ISqlTreeNodeBuilder                        sqlTreeNodeBuilder,
          QueryCompilationContext                               queryCompilationContext,
          QueryableMethodTranslatingExpressionVisitor           queryableMethodTranslatingExpressionVisitor)
  :base(dependencies,
        queryCompilationContext,
        queryableMethodTranslatingExpressionVisitor)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlTreeNodeBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(queryCompilationContext,null));

  //----------------------------------------
  m_SqlTreeNodeBuilder=sqlTreeNodeBuilder;
 }//LcpiOleDb__SqlTranslatingExpressionVisitor

 //ExpressionVisitor interface -------------------------------------------
 public override Expression Visit(Expression expression)
 {
  Expression resultExpression;

  if(expression is Expressions.LcpiOleDb__SqlStubExpression stubExpression)
  {
   Debug.Assert(!Object.ReferenceEquals(stubExpression.InnerExpression,null));

   resultExpression=this.Visit(stubExpression.InnerExpression);
  }
  else
  {
   resultExpression=base.Visit(expression);
  }//else

  return resultExpression;
 }//Visit

 //-----------------------------------------------------------------------
 protected override Expression VisitTypeBinary(TypeBinaryExpression typeBinaryExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(typeBinaryExpression,null));

  var r1_e
   =base.VisitTypeBinary(typeBinaryExpression);

  if(Helper__EFCore__TranslationFailed(typeBinaryExpression,r1_e,out var r1))
  {
   return QueryCompilationContext.NotTranslatedExpression;
  }//if

  Debug.Assert(!Object.ReferenceEquals(r1,null));

  Debug.Assert(!Object.ReferenceEquals(this.Dependencies,null));
  Debug.Assert(!Object.ReferenceEquals(this.Dependencies.SqlExpressionFactory,null));

  var r2
   =this.Dependencies.SqlExpressionFactory.ApplyDefaultTypeMapping
     (r1);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlType(r2);
#endif

  return r2;
 }//VisitTypeBinary

 //-----------------------------------------------------------------------
 protected override Expression VisitParameter(ParameterExpression parameterExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(parameterExpression,null));

  var r1_e
   =base.VisitParameter(parameterExpression);

  if(Helper__EFCore__TranslationFailed(parameterExpression,r1_e,out var r1))
  {
   return QueryCompilationContext.NotTranslatedExpression;
  }//if

  Debug.Assert(!Object.ReferenceEquals(r1,null));

  Debug.Assert(!Object.ReferenceEquals(this.Dependencies,null));
  Debug.Assert(!Object.ReferenceEquals(this.Dependencies.SqlExpressionFactory,null));

  var r2
   =this.Dependencies.SqlExpressionFactory.ApplyDefaultTypeMapping
     (r1);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlType(r2);
#endif

  return r2;
 }//VisitParameter

 //-----------------------------------------------------------------------
 protected override Expression VisitConstant(ConstantExpression constantExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(constantExpression,null));

  var r1_e
   =base.VisitConstant(constantExpression);

  if(Helper__EFCore__TranslationFailed(constantExpression,r1_e,out var r1))
  {
   return QueryCompilationContext.NotTranslatedExpression;
  }//if

  Debug.Assert(!Object.ReferenceEquals(r1,null));

  Debug.Assert(!Object.ReferenceEquals(this.Dependencies,null));
  Debug.Assert(!Object.ReferenceEquals(this.Dependencies.SqlExpressionFactory,null));

  var r2
   =this.Dependencies.SqlExpressionFactory.ApplyDefaultTypeMapping
     (r1);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlType(r2);
#endif

  return r2;
 }//VisitConstant

 //-----------------------------------------------------------------------
 protected override Expression VisitMemberInit(MemberInitExpression memberInitExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(memberInitExpression,null));

  var r1_e
   =base.VisitMemberInit(memberInitExpression); //throw

  Debug.Assert(!Object.ReferenceEquals(r1_e,null));

  if(Helper__EFCore__TranslationFailed(memberInitExpression,r1_e,out var r1))
  {
   return QueryCompilationContext.NotTranslatedExpression;
  }//if

  Debug.Assert(!Object.ReferenceEquals(r1,null));

  Debug.Assert(!Object.ReferenceEquals(this.Dependencies,null));
  Debug.Assert(!Object.ReferenceEquals(this.Dependencies.SqlExpressionFactory,null));

  var r2
   =this.Dependencies.SqlExpressionFactory.ApplyDefaultTypeMapping
     (r1);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlType(r2);
#endif

  return r2;
 }//VisitMemberInit

 //-----------------------------------------------------------------------
 protected override Expression VisitNew(NewExpression newExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(newExpression,null));

  var r1_e
   =base.VisitNew(newExpression); //throw

  Debug.Assert(!Object.ReferenceEquals(r1_e,null));

  if(Helper__EFCore__TranslationFailed(newExpression,r1_e,out var r1))
  {
   return QueryCompilationContext.NotTranslatedExpression;
  }//if

  Debug.Assert(!Object.ReferenceEquals(r1,null));

  Debug.Assert(!Object.ReferenceEquals(this.Dependencies,null));
  Debug.Assert(!Object.ReferenceEquals(this.Dependencies.SqlExpressionFactory,null));

  var r2
   =this.Dependencies.SqlExpressionFactory.ApplyDefaultTypeMapping
     (r1);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlType(r2);
#endif

  return r2;
 }//VisitNew

 //-----------------------------------------------------------------------
 public override SqlExpression TranslateAverage(SqlExpression sqlExpression)
 {
#if TRACE
  Core.Core_Trace.Method
   ("LcpiOleDb__SqlTranslatingExpressionVisitor::TranslateAverage");
#endif

  //----------------------------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(TranslateSum),
    nameof(sqlExpression),
    sqlExpression);

  //----------------------------------------
  var r
   =m_SqlTreeNodeBuilder.MakeCall
    (Structure_MethodIdCache.MethodIdOf__QUERABLE__AVG,
     /*instance*/null,
     new[]{sqlExpression}); //throw

  // [2021-10-04] Expected not null.
  Debug.Assert(!Object.ReferenceEquals(r,null));

  return r;
 }//TranslateAverage

 //-----------------------------------------------------------------------
 public override SqlExpression TranslateSum(SqlExpression sqlExpression)
 {
#if TRACE
  Core.Core_Trace.Method
   ("LcpiOleDb__SqlTranslatingExpressionVisitor::TranslateSum");
#endif

  //----------------------------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(TranslateSum),
    nameof(sqlExpression),
    sqlExpression);

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(sqlExpression,null));;

  var r
   =m_SqlTreeNodeBuilder.MakeCall
    (Structure_MethodIdCache.MethodIdOf__QUERABLE__SUM,
     /*instance*/null,
     new[]{sqlExpression}); //throw

  // [2021-09-11] Expected not null.
  Debug.Assert(!Object.ReferenceEquals(r,null));

  return r;
 }//TranslateSum

 //Helper methods --------------------------------------------------------
 private static bool Helper__SET_NULL_AND_RETURN_FALSE<T>(out T outputValue)
  where T:class
 {
  outputValue=null;

  return false;
 }//Helper__SET_NULL_AND_RETURN_FALSE

 //private data ----------------------------------------------------------
 private readonly LcpiOleDb__ISqlTreeNodeBuilder m_SqlTreeNodeBuilder;
};//class LcpiOleDb__SqlTranslatingExpressionVisitor

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.ExpressionVisitors

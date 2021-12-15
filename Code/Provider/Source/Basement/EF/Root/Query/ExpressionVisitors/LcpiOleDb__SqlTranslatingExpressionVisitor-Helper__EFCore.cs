////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 18.05.2018.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.ExpressionVisitors{
////////////////////////////////////////////////////////////////////////////////

using Structure_TypeCache
 =Structure.Structure_TypeCache;

using Structure_MethodInfoCache
 =Structure.Structure_MethodInfoCache;

////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__SqlTranslatingExpressionVisitor

sealed partial class LcpiOleDb__SqlTranslatingExpressionVisitor
{
 //Helper methods --------------------------------------------------------
 private static ExpressionType Helper__EFCore__GetUncheckedNodeTypeVariant(ExpressionType nodeType)
 {
  switch(nodeType)
  {
   case ExpressionType.AddChecked      : return ExpressionType.Add;
   case ExpressionType.SubtractChecked : return ExpressionType.Subtract;
   case ExpressionType.MultiplyChecked : return ExpressionType.Multiply;
  }//switch

  return nodeType;
 }//Helper__EFCore__GetUncheckedNodeTypeVariant

 //-----------------------------------------------------------------------
 private bool Helper__EFCore__TryRewriteEntityEquality
                                           (ExpressionType nodeType,
                                            Expression     left,
                                            Expression     right,
                                            bool           equalsMethod,
                                            out Expression result)
 {
  Debug.Assert(!Object.ReferenceEquals(left,null));
  Debug.Assert(!Object.ReferenceEquals(right,null));

  //------------------------------------------------------------ Debug Checks
#if DEBUG
  {
   Debug.Assert
    (!Object.ReferenceEquals
      (Structure_MethodInfoCache.Hack__MethodInfoOf__RelationalSqlTranslatingExpressionVisitor__TryRewriteEntityEquality,
       null));

   Debug.Assert
    (Structure_MethodInfoCache.Hack__MethodInfoOf__RelationalSqlTranslatingExpressionVisitor__TryRewriteEntityEquality.ReturnType
      ==Structure_TypeCache.TypeOf__System_Boolean);

   var debug__methodParams
    =Structure_MethodInfoCache.Hack__MethodInfoOf__RelationalSqlTranslatingExpressionVisitor__TryRewriteEntityEquality.GetParameters();

   Debug.Assert(!Object.ReferenceEquals(debug__methodParams,null));

   Debug.Assert(debug__methodParams.Length==5);

   Debug.Assert(!Object.ReferenceEquals(debug__methodParams[0],null));
   Debug.Assert(!Object.ReferenceEquals(debug__methodParams[1],null));
   Debug.Assert(!Object.ReferenceEquals(debug__methodParams[2],null));
   Debug.Assert(!Object.ReferenceEquals(debug__methodParams[3],null));
   Debug.Assert(!Object.ReferenceEquals(debug__methodParams[4],null));

   Debug.Assert(debug__methodParams[0].ParameterType==Structure_TypeCache.TypeOf__SystemLinqExpressions_ExpressionType);
   Debug.Assert(debug__methodParams[1].ParameterType==Structure_TypeCache.TypeOf__SystemLinqExpressions_Expression);
   Debug.Assert(debug__methodParams[2].ParameterType==Structure_TypeCache.TypeOf__SystemLinqExpressions_Expression);
   Debug.Assert(debug__methodParams[3].ParameterType==Structure_TypeCache.TypeOf__System_Boolean);
   Debug.Assert(debug__methodParams[4].ParameterType==Structure_TypeCache.TypeOf__SystemLinqExpressions_Expression.MakeByRefType());

   /* OK! */
  }//local
#endif //DEBUG

  //------------------------------------------------------------
  var parameters
   =new object[]
     {
      /* 0 */ nodeType,
      /* 1 */ left,
      /* 2 */ right,
      /* 3 */ equalsMethod,
      /* 4 */ /*out*/null
     };//parameters

  System.Object
   invokeResult_obj
    =Structure_MethodInfoCache.Hack__MethodInfoOf__RelationalSqlTranslatingExpressionVisitor__TryRewriteEntityEquality
      .Extension__InvokeWithTransparentHandlingOfException
        (this,
         parameters); //throw

  //------------------------------------------------------------
  Debug.Assert(Object.ReferenceEquals(parameters[4],null) ||
               parameters[4] is Expression);

  //--------------------------
  Debug.Assert(!Object.ReferenceEquals(invokeResult_obj,null));
  Debug.Assert(invokeResult_obj.GetType()==Structure_TypeCache.TypeOf__System_Boolean);

  //------------------------------------------------------------
  result=parameters[4] as Expression;

  return (bool)invokeResult_obj;
 }//Helper__EFCore__TryRewriteEntityEquality

 //-----------------------------------------------------------------------
 private static bool Helper__EFCore__TranslationFailed
                             (Expression        original,
                              Expression        translation,
                              out SqlExpression castTranslation)
 {
  if(!Object.ReferenceEquals(original,null))
  {
   if(!(translation is SqlExpression))
   {
    castTranslation = null;

    return true;
   }//if
  }//if

  castTranslation=translation as SqlExpression;

  return false;
 }//Helper__EFCore__TranslationFailed

 //-----------------------------------------------------------------------
 private static Expression Helper__EFCore__EntityReferenceExpression__Convert
                                           (object         nodeExpression,
                                            System.Type    type)
 {
  Debug.Assert(!Object.ReferenceEquals(nodeExpression,null));
  Debug.Assert(!Object.ReferenceEquals(type,null));

  Debug.Assert(nodeExpression.GetType().Equals(Structure_TypeCache.TypeOf__MS_EFCore_Query__RelationalSqlTranslatingExpressionVisitor___EntityReferenceExpression));

  //------------------------------------------------------------ Debug Checks
#if DEBUG
  {
   Debug.Assert
    (!Object.ReferenceEquals
      (Structure_MethodInfoCache.Hack__MethodInfoOf__RelationalSqlTranslatingExpressionVisitor_EntityReferenceExpression__Convert,
       null));

   Debug.Assert
    (Structure_MethodInfoCache.Hack__MethodInfoOf__RelationalSqlTranslatingExpressionVisitor_EntityReferenceExpression__Convert.ReturnType
      ==Structure_TypeCache.TypeOf__SystemLinqExpressions_Expression);

   var debug__methodParams
    =Structure_MethodInfoCache.Hack__MethodInfoOf__RelationalSqlTranslatingExpressionVisitor_EntityReferenceExpression__Convert.GetParameters();

   Debug.Assert(!Object.ReferenceEquals(debug__methodParams,null));

   Debug.Assert(debug__methodParams.Length==1);

   Debug.Assert(!Object.ReferenceEquals(debug__methodParams[0],null));

   Debug.Assert(debug__methodParams[0].ParameterType==Structure_TypeCache.TypeOf__System_Type);

   /* OK! */
  }//local
#endif //DEBUG

  //------------------------------------------------------------
  var parameters
   =new object[]
     {
      /* 0 */ type,
     };//parameters

  var r
   =Structure_MethodInfoCache.Hack__MethodInfoOf__RelationalSqlTranslatingExpressionVisitor_EntityReferenceExpression__Convert
     .Extension__InvokeWithTransparentHandlingOfException
       (nodeExpression,
        parameters);

  //--------------------------
#if DEBUG
  if(!Object.ReferenceEquals(r,null))
  {
   Debug.Assert(r.GetType().IsAssignableTo(Structure_TypeCache.TypeOf__SystemLinqExpressions_Expression));
  }
#endif

  //------------------------------------------------------------
  return (Expression)r;
 }//Helper__EFCore__EntityReferenceExpression__Convert
};//class LcpiOleDb__SqlTranslatingExpressionVisitor

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.ExpressionVisitors

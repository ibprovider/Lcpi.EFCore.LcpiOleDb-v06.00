////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 19.05.2018.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

using Structure_MethodIdCache
 =Structure.Structure_MethodIdCache;

using Structure_MethodInfoCache
 =Structure.Structure_MethodInfoCache;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator__String__std__EndsWith__str___through_RIGHT

sealed class FB_Common__Sql_ETranslator__String__std__EndsWith__str___through_RIGHT
 :FB_Common__Sql_ETranslator_MethodCall
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__Sql_ETranslator__String__std__EndsWith__str___through_RIGHT;

 //-----------------------------------------------------------------------
 public static readonly FB_Common__Sql_ETranslator_MethodCall.tagDescr
  Instance
   =new FB_Common__Sql_ETranslator_MethodCall.tagDescr
     (Structure_MethodIdCache.MethodIdOf__String__std__EndsWith__str,
      new FB_Common__Sql_ETranslator__String__std__EndsWith__str___through_RIGHT());

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator__String__std__EndsWith__str___through_RIGHT()
 {
 }//FB_Common__Sql_ETranslator__String__std__EndsWith__str___through_RIGHT

 //FB_Common__Sql_ETranslator_MethodCall interface -----------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.Instance,null));

  Debug.Assert(!Object.ReferenceEquals(opData.MethodId,null));
  Debug.Assert(opData.MethodId.Equals(Structure_MethodInfoCache.MethodInfoOf__String__std__EndsWith__str));

  Debug.Assert(!Object.ReferenceEquals(opData.Arguments,null));
  Debug.Assert(opData.Arguments.Count==1);
  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[0],null));

  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));

  //-----
  var exprSource
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(opData.Instance);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (exprSource,
    Structure_TypeCache.TypeOf__System_String);
#endif

  //-----
  var exprArg0
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(opData.Arguments[0]);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (exprArg0,
    Structure_TypeCache.TypeOf__System_String);
#endif

  if(exprArg0 is SqlConstantExpression exprArg0_Const)
  {
   if(Object.ReferenceEquals(exprArg0_Const.Value,null))
   {
    var r
     =FB_Common__Data.sm_SqlConstantExpression__Boolean__NULL;

#if DEBUG
    Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
     (r,
      Structure_TypeCache.TypeOf__System_Boolean);
#endif

    return r;
   }//if

   Debug.Assert(!Object.ReferenceEquals(exprArg0_Const.Value,null));
   Debug.Assert(exprArg0_Const.Value is string);

   string patternString=(string)exprArg0_Const.Value;

   int cch_patternString=0;

   try
   {
    cch_patternString
     =Structure.Structure_CS_UTF16.GetCharCount
      (patternString); //throw
   }
   catch(Exception e)
   {
    ThrowError.FailedToProcessValue
     (c_ErrSrcID,
      "patternString",
      e);

    Debug.Assert(false);
   }//catch

   Debug.Assert(cch_patternString<=patternString.Length);

   var lengthExpression
    =opData.SqlExpressionFactory.Constant
      (cch_patternString,
       FB_Common__TypeMappingCache.TypeMapping__INT32);

#if DEBUG
   Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
    (lengthExpression,
     FB_Common__TypeMappingCache.TypeMapping__INT32);
#endif

   {
    var r
     =Internal.FB_Common__Sql_EBuilder__String_EndsWith__through_RIGHT.Exec
       (exprSource,
        lengthExpression,
        exprArg0_Const);

#if DEBUG
    Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
     (r,
      FB_Common__TypeMappingCache.TypeMapping__BOOLEAN);
#endif

    return r;
   }//local
  }//if exprArg0 is ConstantExpression

  //-----
  {
   var lengthExpression
    =opData.SqlTreeNodeBuilder.MakeCall
      (Structure_MethodIdCache.MethodIdOf__BUILTIN_SQL__CHARACTER_LENGTH,
       /*sqlInstance*/null,
       new[]{exprArg0});

#if DEBUG
   Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
    (lengthExpression);
#endif

   var r
    =Internal.FB_Common__Sql_EBuilder__String_EndsWith__through_RIGHT.Exec
      (exprSource,
       lengthExpression,
       exprArg0);

#if DEBUG
   Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
    (r,
     Structure_TypeCache.TypeOf__System_Boolean);
#endif

   return r;
  }//local
 }//Translate
};//class FB_Common__Sql_ETranslator__String__std__EndsWith__str___through_RIGHT

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code

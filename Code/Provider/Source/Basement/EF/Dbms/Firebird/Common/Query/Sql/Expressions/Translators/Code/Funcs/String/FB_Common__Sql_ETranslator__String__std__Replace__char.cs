////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 18.05.2018.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_MethodInfoCache
 =Structure.Structure_MethodInfoCache;

using Structure_MethodIdCache
 =Structure.Structure_MethodIdCache;

using Structure_TypeCache
 =Structure.Structure_TypeCache;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator__String__std__Replace__char

sealed class FB_Common__Sql_ETranslator__String__std__Replace__char
 :FB_Common__Sql_ETranslator_MethodCall
{
 public static readonly FB_Common__Sql_ETranslator_MethodCall.tagDescr
  Instance
   =new FB_Common__Sql_ETranslator_MethodCall.tagDescr
     (Structure_MethodIdCache.MethodIdOf__String__std__Replace__char_char,
      new FB_Common__Sql_ETranslator__String__std__Replace__char());

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator__String__std__Replace__char()
 {
 }//FB_Common__Sql_ETranslator__String__std__Replace__char

 //FB_Common__Sql_ETranslator_MethodCall interface -----------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.Instance,null));

  Debug.Assert(!Object.ReferenceEquals(opData.MethodId,null));
  Debug.Assert(opData.MethodId.Equals(Structure_MethodInfoCache.MethodInfoOf__String__std__Replace__char_char));

  Debug.Assert(!Object.ReferenceEquals(opData.Arguments,null));
  Debug.Assert(opData.Arguments.Count==2);
  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[0],null));
  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[1],null));

  //----------------------------------------
  var exprSource
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(opData.Instance);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (exprSource,
    Structure_TypeCache.TypeOf__System_String);
#endif

  //----------------------------------------
  var exprArg0
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping
     (opData.Arguments[0]);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (exprArg0);
#endif

  //----------------------------------------
  var exprArg1
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping
     (opData.Arguments[1]);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (exprArg1);
#endif

  //----------------------------------------
  var r
   =opData.SqlExpressionFactory.Function
     ("REPLACE",
      new[]{exprSource,exprArg0,exprArg1},
      true,
      sm_argumentsPropagateNullability,
      Structure_TypeCache.TypeOf__System_String,
      FB_Common__TypeMappingCache.TypeMapping__TEXT);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (r,
    Structure_TypeCache.TypeOf__System_String);
#endif

  return r;
 }//Translate

 //private data ----------------------------------------------------------
 private static readonly bool[] sm_argumentsPropagateNullability
  =new bool[3]{true,true,true};
};//class FB_Common__Sql_ETranslator__String__std__Replace__char

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code

////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 22.09.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D1.Expressions.Translators.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

using Structure_MethodIdCache
 =Structure.Structure_MethodIdCache;

using Structure_MethodInfoCache
 =Structure.Structure_MethodInfoCache;

using FB_Common__Sql_ETranslator_MethodCall
 =Common.Query.Sql.Expressions.Translators.FB_Common__Sql_ETranslator_MethodCall;

using FB_Common__Data
 =Common.FB_Common__Data;

using FB_Common__TypeMappingCache
 =Common.FB_Common__TypeMappingCache;

using Root.Query.Sql.Extensions.LcpiOleDb__ISqlTreeNodeBuilder__Extensions;

////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0__Sql_ETranslator__String__std__IndexOf__str

sealed class FB_V03_0_0__Sql_ETranslator__String__std__IndexOf__str
 :FB_Common__Sql_ETranslator_MethodCall
{
 public static readonly FB_Common__Sql_ETranslator_MethodCall.tagDescr
  Instance
   =new FB_Common__Sql_ETranslator_MethodCall.tagDescr
     (Structure_MethodIdCache.MethodIdOf__String__std__IndexOf__str,
      new FB_V03_0_0__Sql_ETranslator__String__std__IndexOf__str());

 //-----------------------------------------------------------------------
 private FB_V03_0_0__Sql_ETranslator__String__std__IndexOf__str()
 {
 }//FB_V03_0_0__Sql_ETranslator__String__std__IndexOf__str

 //FB_Common__Sql_ETranslator_MethodCall interface -----------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.Instance,null));

  Debug.Assert(!Object.ReferenceEquals(opData.MethodId,null));
  Debug.Assert(opData.MethodId.Equals(Structure_MethodInfoCache.MethodInfoOf__String__std__IndexOf__str));

  Debug.Assert(!Object.ReferenceEquals(opData.Arguments,null));
  Debug.Assert(opData.Arguments.Count==1);
  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[0],null));

  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlTreeNodeBuilder,null));

  //-----
  var exprSource
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(opData.Instance);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (exprSource,
    Structure_TypeCache.TypeOf__System_String);
#endif

  //-----
  var exprArg0__substr
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(opData.Arguments[0]);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (exprArg0__substr,
    Structure_TypeCache.TypeOf__System_String);
#endif

  //----------------------------------------
  var expr1_Pos
   =opData.SqlTreeNodeBuilder.MakeCall
     (Structure_MethodIdCache.MethodIdOf__BUILTIN_SQL__POSITION,
      /*instance*/null,
      new[]
       {
        exprArg0__substr,
        exprSource
       });

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (expr1_Pos,
    FB_Common__TypeMappingCache.TypeMapping__INT32);
#endif

  //----------------------------------------
  var expr2_Subtract
   =opData.SqlTreeNodeBuilder.Extension__MakeBinary__Subtract__Throw
     (expr1_Pos,
      FB_Common__Data.sm_SqlConstantExpression__Int32__ONE);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (expr2_Subtract);
#endif

  //----------------------------------------

  //
  // [2022-09-22]
  //  Why we convert to INT64?
  //  - Unification with Dialect3.
  //  - Just we can.
  //
  // If you detect any problem with this conversion, please notife us.
  //

  var expr3__ToInt64
   =opData.SqlTreeNodeBuilder.MakeCall
     (Structure_MethodIdCache.MethodIdOf__DbCast__std__AsBigInt,
      /*instance*/null,
      new[]{expr2_Subtract});

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (expr3__ToInt64);
#endif

  //----------------------------------------
  return expr3__ToInt64;
 }//Translate
};//class FB_V03_0_0__Sql_ETranslator__String__std__IndexOf__str

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D1.Expressions.Translators.Code

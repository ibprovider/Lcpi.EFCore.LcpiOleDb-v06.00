////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 19.07.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D3.Expressions.Translators.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

using Structure_MethodInfoCache
 =Structure.Structure_MethodInfoCache;

using Structure_MethodIdCache
 =Structure.Structure_MethodIdCache;

using FB_Common__Sql_ETranslator_MethodCall
 =Common.Query.Sql.Expressions.Translators.FB_Common__Sql_ETranslator_MethodCall;

using FB_Common__TypeMappingCache
 =Common.FB_Common__TypeMappingCache;

using Root.Query.Sql.Extensions.LcpiOleDb__ISqlTreeNodeBuilder__Extensions;

////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0__Sql_ETranslator__TimeOnly__std__Add___TimeSpan

sealed class FB_V03_0_0__Sql_ETranslator__TimeOnly__std__Add___TimeSpan
 :FB_Common__Sql_ETranslator_MethodCall
{
 public static readonly FB_Common__Sql_ETranslator_MethodCall.tagDescr
  Instance
   =new FB_Common__Sql_ETranslator_MethodCall.tagDescr
     (Structure_MethodIdCache.MethodIdOf__TimeOnly__std__Add___TimeSpan,
      new FB_V03_0_0__Sql_ETranslator__TimeOnly__std__Add___TimeSpan());

 //-----------------------------------------------------------------------
 private FB_V03_0_0__Sql_ETranslator__TimeOnly__std__Add___TimeSpan()
 {
 }//FB_V03_0_0__Sql_ETranslator__TimeOnly__std__Add___TimeSpan

 //FB_Common__Sql_ETranslator_Op2 interface ------------------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.MethodId,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));

  Debug.Assert(opData.MethodId.Equals(Structure_MethodInfoCache.MethodInfoOf__TimeOnly__std__Add___TimeSpan));

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(opData.Instance,null));
  Debug.Assert(!Object.ReferenceEquals(opData.Instance.Type,null));

  Debug.Assert(opData.Instance.Type==Structure_TypeCache.TypeOf__System_TimeOnly);

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(opData.Arguments,null));
  Debug.Assert(opData.Arguments.Count==1);

  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[0],null));
  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[0].Type,null));

  Debug.Assert(opData.Arguments[0].Type==Structure_TypeCache.TypeOf__System_TimeSpan);

  //----------------------------------------
  var exprObject
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(opData.Instance);

  Debug.Assert(!Object.ReferenceEquals(exprObject,null));
  Debug.Assert(!Object.ReferenceEquals(exprObject.Type,null));
  Debug.Assert(!Object.ReferenceEquals(exprObject.TypeMapping,null));

  Debug.Assert(exprObject.Type==Structure_TypeCache.TypeOf__System_TimeOnly);

  //----------------------------------------
  var exprArg0
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(opData.Arguments[0]);

  Debug.Assert(!Object.ReferenceEquals(exprArg0,null));
  Debug.Assert(!Object.ReferenceEquals(exprArg0.Type,null));
  Debug.Assert(!Object.ReferenceEquals(exprArg0.TypeMapping,null));

  Debug.Assert(exprArg0.Type==Structure_TypeCache.TypeOf__System_TimeSpan);

  //------------------------------------------------------------
  //
  // Generated SQL:
  //
  // LEFT + RIGHT
  //

  //------------------------------------------------------------

  //
  // [2021-01-03] No idea how to send here the arguments without TypeMapping.
  //

  //------------------------------------------------------------
#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (exprObject,
    Structure_TypeCache.TypeOf__System_TimeOnly);

  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (exprArg0,
    Structure_TypeCache.TypeOf__System_TimeSpan);
#endif

  //------------------------------------------------------------
  var r
   =opData.SqlTreeNodeBuilder.Extension__MakeBinary__Add__Throw
    (exprObject,
     exprArg0);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (r,
    FB_Common__TypeMappingCache.TypeMapping_D3__TIME__as_TimeOnly);
#endif

  //------------------------------------------------------------
  return r;
 }//Translate
};//class FB_V03_0_0__Sql_ETranslator__TimeOnly__std__Add___TimeSpan

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D3.Expressions.Translators.Code

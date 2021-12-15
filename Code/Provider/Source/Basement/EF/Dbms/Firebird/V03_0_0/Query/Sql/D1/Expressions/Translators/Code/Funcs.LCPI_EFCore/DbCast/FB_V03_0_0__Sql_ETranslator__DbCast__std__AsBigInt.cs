////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 22.09.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D1.Expressions.Translators.Code.LCPI_EFCore{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_MethodIdCache
 =Structure.Structure_MethodIdCache;

using Structure_MethodInfoCache
 =Structure.Structure_MethodInfoCache;

using FB_Common__Sql_ETranslator_MethodCall
 =Common.Query.Sql.Expressions.Translators.FB_Common__Sql_ETranslator_MethodCall;

using FB_Common__TypeMappingCache
 =Common.FB_Common__TypeMappingCache;

////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0__Sql_ETranslator__DbCast__std__AsBigInt

sealed class FB_V03_0_0__Sql_ETranslator__DbCast__std__AsBigInt
 :FB_Common__Sql_ETranslator_MethodCall
{
 public static readonly FB_Common__Sql_ETranslator_MethodCall.tagDescr
  Instance
   =new FB_Common__Sql_ETranslator_MethodCall.tagDescr
     (Structure_MethodIdCache.MethodIdOf__DbCast__std__AsBigInt,
      new FB_V03_0_0__Sql_ETranslator__DbCast__std__AsBigInt());

 //-----------------------------------------------------------------------
 private FB_V03_0_0__Sql_ETranslator__DbCast__std__AsBigInt()
 {
 }//FB_V03_0_0__Sql_ETranslator__DbCast__std__AsBigInt

 //FB_Common__Sql_ETranslator_MethodCall interface -----------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.MethodId,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));

  Debug.Assert(opData.MethodId.Equals(Structure_MethodInfoCache.MethodInfoOf__DbCast__std__AsBigInt));

  //----------------------------------------
  Debug.Assert(Object.ReferenceEquals(opData.Instance,null));

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(opData.Arguments,null));
  Debug.Assert(opData.Arguments.Count==1);

  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[0],null));

  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[0].Type,null));

  //
  // ((object)typedValue) --> typedValue
  //
  //Debug.Assert(opData.Arguments[0].Type==Structure_TypeCache.TypeOf__System_Object);

  //----------------------------------------
  var exprArg0
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(opData.Arguments[0]);

  Debug.Assert(!Object.ReferenceEquals(exprArg0,null));
  Debug.Assert(!Object.ReferenceEquals(exprArg0.Type,null));
  Debug.Assert(!Object.ReferenceEquals(exprArg0.TypeMapping,null));

  //----------------------------------------
  var r
   =Common.Query.Sql.Expressions.Nodes.FB_Common__Sql_ENode_Function__SQL__CAST_AS.Create
     (exprArg0,
      FB_Common__TypeMappingCache.TypeMapping__INT64,
      FB_V03_0_0__Consts.c_TypeOf_BIGINT_D1);

  Debug.Assert(!Object.ReferenceEquals(r,null));

  return r;
 }//Translate
};//class FB_V03_0_0__Sql_ETranslator__DbCast__std__AsBigInt

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D1.Expressions.Translators.Code.LCPI_EFCore

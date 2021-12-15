////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 11.09.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D3.Expressions.Translators.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_MethodIdCache
 =Structure.Structure_MethodIdCache;

using FB_Common__Sql_ETranslator_MethodCall
 =Common.Query.Sql.Expressions.Translators.FB_Common__Sql_ETranslator_MethodCall;

////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0_D3__Sql_ETranslator__BUILTIN_SQL__SUM

sealed class FB_V03_0_0_D3__Sql_ETranslator__BUILTIN_SQL__SUM
 :FB_Common__Sql_ETranslator_MethodCall
{
 public static readonly FB_Common__Sql_ETranslator_MethodCall.tagDescr
  Instance
   =new FB_Common__Sql_ETranslator_MethodCall.tagDescr
     (Structure_MethodIdCache.MethodIdOf__BUILTIN_SQL__SUM,
      new FB_V03_0_0_D3__Sql_ETranslator__BUILTIN_SQL__SUM());

 //-----------------------------------------------------------------------
 private FB_V03_0_0_D3__Sql_ETranslator__BUILTIN_SQL__SUM()
 {
 }//FB_V03_0_0_D3__Sql_ETranslator__BUILTIN_SQL__SUM

 //FB_Common__Sql_ETranslator_Op2 interface ------------------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.MethodId,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));

  Debug.Assert(opData.MethodId.Equals(Structure_MethodIdCache.MethodIdOf__BUILTIN_SQL__SUM));

  //----------------------------------------
  Debug.Assert(Object.ReferenceEquals(opData.Instance,null));

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(opData.Arguments,null));
  Debug.Assert(opData.Arguments.Count==1);

  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[0],null));
  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[0].Type,null));

  //----------------------------------------
  var exprArg0
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(opData.Arguments[0]);

  Debug.Assert(!Object.ReferenceEquals(exprArg0,null));
  Debug.Assert(!Object.ReferenceEquals(exprArg0.Type,null));
  Debug.Assert(!Object.ReferenceEquals(exprArg0.TypeMapping,null));

  //------------------------------------------------------------
  var r
   =Nodes.FB_V03_0_0_D3__Sql_ENode_Function__SQL__SUM.Create
     (exprArg0);

  Debug.Assert(!Object.ReferenceEquals(r,null));

  //------------------------------------------------------------
  return r;
 }//Translate
};//class FB_V03_0_0_D3__Sql_ETranslator__BUILTIN_SQL__SUM

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D3.Expressions.Translators.Code

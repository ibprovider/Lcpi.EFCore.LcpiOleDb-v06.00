////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 15.06.2021.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Translators{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

using Structure_MethodIdCache
 =Structure.Structure_MethodIdCache;

////////////////////////////////////////////////////////////////////////////////
//class ETranslator__IEnumerableNullableInt64__vrt__Contains

sealed class ETranslator__IEnumerableNullableInt64__vrt__Contains
 :Root.Query.Local.LcpiOleDb__LocalEval_MethodCallTranslator
{
 public static readonly Root.Query.Local.LcpiOleDb__LocalEval_MethodCallTranslator
  Instance
   =new ETranslator__IEnumerableNullableInt64__vrt__Contains();

 //-----------------------------------------------------------------------
 private ETranslator__IEnumerableNullableInt64__vrt__Contains()
  :base(Structure_MethodIdCache.MethodIdOf__IEnumerableNullableInt64__vrt__Contains)
 {
 }//ETranslator__IEnumerableNullableInt64__vrt__Contains

 //interface -------------------------------------------------------------
 public override Expression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.MethodId,null));

  Debug.Assert(opData.MethodId==Structure_MethodIdCache.MethodIdOf__IEnumerableNullableInt64__vrt__Contains);

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(opData.CallObject,null));

  Debug.Assert(!Object.ReferenceEquals(opData.Arguments,null));
  Debug.Assert(opData.Arguments.Count==1);

  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[0],null));

  //----------------------------------------
  var node_Arg0
   =opData.CallObject;

  Debug.Assert(!Object.ReferenceEquals(node_Arg0,null));
  Debug.Assert(node_Arg0.Type==Structure_TypeCache.TypeOf__System_Collection_Generic_IEnumerableNullableInt64);

  //----------------------------------------
  var node_Arg1
   =opData.Arguments[0];

  Debug.Assert(!Object.ReferenceEquals(node_Arg1,null));
  Debug.Assert(node_Arg1.Type==Structure_TypeCache.TypeOf__System_NullableInt64);

  //----------------------------------------
  var r
   =Expression.Call
     (Code.Method_Code__IEnumerableNullableInt64__Contains__NullableInt64.MethodInfo,
      opData.ExpressionServices.GetExpressionWithExecCtx(),
      node_Arg0,
      node_Arg1);

  Debug.Assert(!Object.ReferenceEquals(r,null));

  return r;
 }//Translate
};//class ETranslator__IEnumerableNullableInt64__vrt__Contains

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Translators

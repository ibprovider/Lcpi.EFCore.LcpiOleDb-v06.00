////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 30.08.2021.
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

using Structure_MethodInfoCache
 =Structure.Structure_MethodInfoCache;

////////////////////////////////////////////////////////////////////////////////
//class ETranslator__NullableInt64__vrt__GetValueOrDefault__NullableDouble

sealed class ETranslator__NullableInt64__vrt__GetValueOrDefault__NullableDouble
 :Root.Query.Local.LcpiOleDb__LocalEval_MethodCallTranslator
{
 public static readonly Root.Query.Local.LcpiOleDb__LocalEval_MethodCallTranslator
  Instance
   =new ETranslator__NullableInt64__vrt__GetValueOrDefault__NullableDouble();

 //-----------------------------------------------------------------------
 private ETranslator__NullableInt64__vrt__GetValueOrDefault__NullableDouble()
  :base(Structure_MethodIdCache.MethodIdOf__NullableInt64__vrt__GetValueOrDefault__NullableDouble)
 {
 }//ETranslator__NullableInt64__vrt__GetValueOrDefault__NullableDouble

 //interface -------------------------------------------------------------
 public override Expression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.MethodId,null));

  Debug.Assert(opData.MethodId==Structure_MethodIdCache.MethodIdOf__NullableInt64__vrt__GetValueOrDefault__NullableDouble);

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(opData.CallObject,null));
  Debug.Assert(!Object.ReferenceEquals(opData.CallObject.Type,null));

  Debug.Assert(opData.CallObject.Type==Structure_TypeCache.TypeOf__System_NullableInt64);

  Debug.Assert(!Object.ReferenceEquals(opData.Arguments,null));
  Debug.Assert(opData.Arguments.Count==1);

  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[0],null));

  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[0].Type,null));

  Debug.Assert(opData.Arguments[0].Type==Structure_TypeCache.TypeOf__System_NullableDouble);

  //----------------------------------------
  var node_Object
   =opData.CallObject;

  Debug.Assert(!Object.ReferenceEquals(node_Object,null));
  Debug.Assert(!Object.ReferenceEquals(node_Object.Type,null));
  Debug.Assert(node_Object.Type==Structure_TypeCache.TypeOf__System_NullableInt64);

  //----------------------------------------
  var node_Arg0
   =opData.Arguments[0];

  Debug.Assert(!Object.ReferenceEquals(node_Arg0,null));
  Debug.Assert(!Object.ReferenceEquals(node_Arg0.Type,null));
  Debug.Assert(node_Arg0.Type==Structure_TypeCache.TypeOf__System_NullableDouble);

  //----------------------------------------
  var result
   =Expression.Call
     (Code.Method_Code__NullableInt64__GetValueOrDefault__NullableDouble.MethodInfo,
      node_Object,
      node_Arg0);

  Debug.Assert(!Object.ReferenceEquals(result,null));

  return result;
 }//Translate
};//class ETranslator__NullableInt64__vrt__GetValueOrDefault__NullableDouble

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Translators

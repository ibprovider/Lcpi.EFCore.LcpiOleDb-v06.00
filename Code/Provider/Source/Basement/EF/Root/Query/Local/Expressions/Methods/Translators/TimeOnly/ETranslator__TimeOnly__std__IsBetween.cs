////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 04.09.2021.
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
//class ETranslator__TimeOnly__std__IsBetween

sealed class ETranslator__TimeOnly__std__IsBetween
 :Root.Query.Local.LcpiOleDb__LocalEval_MethodCallTranslator
{
 public static readonly Root.Query.Local.LcpiOleDb__LocalEval_MethodCallTranslator
  Instance
   =new ETranslator__TimeOnly__std__IsBetween();

 //-----------------------------------------------------------------------
 private ETranslator__TimeOnly__std__IsBetween()
  :base(Structure_MethodIdCache.MethodIdOf__TimeOnly__std__IsBetween)
 {
 }//ETranslator__TimeOnly__std__IsBetween

 //interface -------------------------------------------------------------
 public override Expression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.MethodId,null));

  Debug.Assert(opData.MethodId==Structure_MethodInfoCache.MethodInfoOf__TimeOnly__std__IsBetween);

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(opData.CallObject,null));

  Debug.Assert(!Object.ReferenceEquals(opData.Arguments,null));
  Debug.Assert(opData.Arguments.Count==2);

  //----------------------------------------
  var node_Source
   =opData.CallObject;

  Debug.Assert(!Object.ReferenceEquals(node_Source,null));
  Debug.Assert(!Object.ReferenceEquals(node_Source.Type,null));

  Debug.Assert(node_Source.Type==Structure_TypeCache.TypeOf__System_TimeOnly);

  //----------------------------------------
  var node_Start
   =opData.Arguments[0];

  Debug.Assert(!Object.ReferenceEquals(node_Start,null));
  Debug.Assert(!Object.ReferenceEquals(node_Start.Type,null));

  Debug.Assert(node_Start.Type==Structure_TypeCache.TypeOf__System_TimeOnly);

  //----------------------------------------
  var node_End
   =opData.Arguments[1];

  Debug.Assert(!Object.ReferenceEquals(node_End,null));
  Debug.Assert(!Object.ReferenceEquals(node_End.Type,null));

  Debug.Assert(node_End.Type==Structure_TypeCache.TypeOf__System_TimeOnly);

  //----------------------------------------
  var r
   =Expression.Call
     (Code.Method_Code__TimeOnly__IsBetween.MethodInfo,
      node_Source,
      node_Start,
      node_End);

  Debug.Assert(!Object.ReferenceEquals(r,null));

  return r;
 }//Translate
};//class ETranslator__TimeOnly__std__IsBetween

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Translators

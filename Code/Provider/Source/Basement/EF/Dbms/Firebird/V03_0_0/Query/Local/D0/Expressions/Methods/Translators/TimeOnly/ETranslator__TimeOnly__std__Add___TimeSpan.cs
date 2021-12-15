////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 19.07.2021.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Methods.Translators{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

using Structure_MethodIdCache
 =Structure.Structure_MethodIdCache;

using Structure_MethodInfoCache
 =Structure.Structure_MethodInfoCache;

////////////////////////////////////////////////////////////////////////////////
//class ETranslator__TimeOnly__std__Add___TimeSpan

sealed class ETranslator__TimeOnly__std__Add___TimeSpan
 :Root.Query.Local.LcpiOleDb__LocalEval_MethodCallTranslator
{
 public static readonly Root.Query.Local.LcpiOleDb__LocalEval_MethodCallTranslator
  Instance
   =new ETranslator__TimeOnly__std__Add___TimeSpan();

 //-----------------------------------------------------------------------
 private ETranslator__TimeOnly__std__Add___TimeSpan()
  :base(Structure_MethodIdCache.MethodIdOf__TimeOnly__std__Add___TimeSpan)
 {
 }//ETranslator__TimeOnly__std__Add___TimeSpan

 //interface -------------------------------------------------------------
 public override Expression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.MethodId,null));

  Debug.Assert(opData.MethodId==Structure_MethodInfoCache.MethodInfoOf__TimeOnly__std__Add___TimeSpan);

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(opData.CallObject,null));
  Debug.Assert(!Object.ReferenceEquals(opData.CallObject.Type,null));

  Debug.Assert(opData.CallObject.Type==Structure_TypeCache.TypeOf__System_TimeOnly);

  Debug.Assert(!Object.ReferenceEquals(opData.Arguments,null));
  Debug.Assert(opData.Arguments.Count==1);

  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[0],null));

  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[0].Type,null));

  Debug.Assert(opData.Arguments[0].Type==Structure_TypeCache.TypeOf__System_TimeSpan);

  //----------------------------------------
  var node_Object
   =opData.CallObject;

  Debug.Assert(!Object.ReferenceEquals(node_Object,null));
  Debug.Assert(!Object.ReferenceEquals(node_Object.Type,null));
  Debug.Assert(node_Object.Type==Structure_TypeCache.TypeOf__System_TimeOnly);

  //----------------------------------------
  var node_Arg0
   =opData.Arguments[0];

  Debug.Assert(!Object.ReferenceEquals(node_Arg0,null));
  Debug.Assert(!Object.ReferenceEquals(node_Arg0.Type,null));
  Debug.Assert(node_Arg0.Type==Structure_TypeCache.TypeOf__System_TimeSpan);

  //----------------------------------------
  var r
   =Expression.Call
     (Code.Method_Code__TimeOnly__Add___TimeSpan.MethodInfo,
      node_Object,
      node_Arg0);

  Debug.Assert(!Object.ReferenceEquals(r,null));

  return r;
 }//Translate
};//class ETranslator__TimeOnly__std__Add___TimeSpan

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Methods.Translators

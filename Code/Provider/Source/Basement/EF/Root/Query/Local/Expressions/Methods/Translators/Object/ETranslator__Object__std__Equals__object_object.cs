////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 28.12.2020.
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
//class ETranslator__Object__std__Equals__object_object

sealed class ETranslator__Object__std__Equals__object_object
 :Root.Query.Local.LcpiOleDb__LocalEval_MethodCallTranslator
{
 public static readonly Root.Query.Local.LcpiOleDb__LocalEval_MethodCallTranslator
  Instance
   =new ETranslator__Object__std__Equals__object_object();

 //-----------------------------------------------------------------------
 private ETranslator__Object__std__Equals__object_object()
  :base(Structure_MethodIdCache.MethodIdOf__Object__std__Equals__object_object)
 {
 }//ETranslator__Object__std__Equals__object_object

 //interface -------------------------------------------------------------
 public override Expression Translate(in tagOpData opData)
 {
  //
  // [2020-12-28]
  //
  //  Temporary solution. Need look to argument types and translate to use direct comparison of arguments.
  //

  Debug.Assert(!Object.ReferenceEquals(opData.MethodId,null));

  Debug.Assert(opData.MethodId==Structure_MethodInfoCache.MethodInfoOf__Object__std__Equals__object_object);

  //----------------------------------------
  Debug.Assert(Object.ReferenceEquals(opData.CallObject,null));

  Debug.Assert(!Object.ReferenceEquals(opData.Arguments,null));
  Debug.Assert(opData.Arguments.Count==2);

  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[0],null));
  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[1],null));

  //----------------------------------------
  var node_Arg0
   =opData.Arguments[0];

  Debug.Assert(!Object.ReferenceEquals(node_Arg0,null));
  Debug.Assert(node_Arg0.Type==Structure_TypeCache.TypeOf__System_Object);

  //----------------------------------------
  var node_Arg1
   =opData.Arguments[1];

  Debug.Assert(!Object.ReferenceEquals(node_Arg1,null));
  Debug.Assert(node_Arg0.Type==Structure_TypeCache.TypeOf__System_Object);

  //----------------------------------------

  //! \todo [2021-06-14] Forward this work to translator of binary operator ==

  var r
   =Expression.Call
     (Op2.Code.Op2_Code__Equal___Object__Object.MethodInfo_V_V,
      opData.ExpressionServices.GetExpressionWithExecCtx(),
      Expression.Convert(node_Arg0,Structure_TypeCache.TypeOf__System_Object),
      Expression.Convert(node_Arg1,Structure_TypeCache.TypeOf__System_Object));

  Debug.Assert(!Object.ReferenceEquals(r,null));

  return r;
 }//Translate
};//class ETranslator__Object__std__Equals__object_object

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Translators

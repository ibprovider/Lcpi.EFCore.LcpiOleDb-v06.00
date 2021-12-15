////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 08.01.2021.
using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Translators.Std{
////////////////////////////////////////////////////////////////////////////////
//class ETranslator__Std__WithCvtCtx

sealed class ETranslator__Std__WithCvtCtx:LcpiOleDb__LocalEval_ConvertTranslator
{
 //
 // methodInfo:
 //  - static T_TARGET CVT(Core_ValueCvtCtx, T_SOURCE)
 //

 public ETranslator__Std__WithCvtCtx(MethodInfo methodInfo)
 {
#if DEBUG
  Debug.Assert(!Object.ReferenceEquals(methodInfo,null));

  Debug.Assert(!Object.ReferenceEquals(methodInfo.ReturnType,null));

  var debug__Parameters=methodInfo.GetParameters();

  Debug.Assert(!Object.ReferenceEquals(debug__Parameters,null));

  Debug.Assert(debug__Parameters.Length==2);

  Debug.Assert(!Object.ReferenceEquals(debug__Parameters[0],null));
  Debug.Assert(!Object.ReferenceEquals(debug__Parameters[0].ParameterType,null));

  Debug.Assert(!Object.ReferenceEquals(debug__Parameters[1],null));
  Debug.Assert(!Object.ReferenceEquals(debug__Parameters[1].ParameterType,null));

  Debug.Assert(debug__Parameters[0].ParameterType==Structure.Structure_TypeCache.TypeOf__LcpiEF__Core_ValueCvtCtx);
#endif

  //----------------------------------------
  m_MethodInfo=methodInfo;
 }//ETranslator__Std__WithCvtCtx

 //LcpiOleDb__LocalEval_ConvertTranslator interface ----------------------
 public override System.Type SourceType
 {
  get
  {
   Debug.Assert(!Object.ReferenceEquals(m_MethodInfo,null));

   var parameters=m_MethodInfo.GetParameters();

   Debug.Assert(!Object.ReferenceEquals(parameters,null));

   Debug.Assert(parameters.Length==2);

   Debug.Assert(!Object.ReferenceEquals(parameters[1],null));
   Debug.Assert(!Object.ReferenceEquals(parameters[1].ParameterType,null));

   return parameters[1].ParameterType;
  }//get
 }//SourceType

 //-----------------------------------------------------------------------
 public override System.Type TargetType
 {
  get
  {
   Debug.Assert(!Object.ReferenceEquals(m_MethodInfo,null));

   Debug.Assert(!Object.ReferenceEquals(m_MethodInfo.ReturnType,null));

   return m_MethodInfo.ReturnType;
  }//get
 }//TargetType

 //-----------------------------------------------------------------------
 public override Expression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.Node,null));
  Debug.Assert(!Object.ReferenceEquals(opData.Node.Type,null));

  //----------------------------------------
#if DEBUG
  Debug.Assert(!Object.ReferenceEquals(m_MethodInfo,null));

  Debug.Assert(!Object.ReferenceEquals(m_MethodInfo.ReturnType,null));

  var debug__Parameters=m_MethodInfo.GetParameters();

  Debug.Assert(!Object.ReferenceEquals(debug__Parameters,null));

  Debug.Assert(debug__Parameters.Length==2);

  Debug.Assert(!Object.ReferenceEquals(debug__Parameters[0],null));
  Debug.Assert(!Object.ReferenceEquals(debug__Parameters[0].ParameterType,null));

  Debug.Assert(!Object.ReferenceEquals(debug__Parameters[1],null));
  Debug.Assert(!Object.ReferenceEquals(debug__Parameters[1].ParameterType,null));

  Debug.Assert(debug__Parameters[0].ParameterType==Structure.Structure_TypeCache.TypeOf__LcpiEF__Core_ValueCvtCtx);
  Debug.Assert(debug__Parameters[1].ParameterType==opData.Node.Type);
#endif

  //----------------------------------------
  var exprCvtCtx
   =opData.ExpressionServices.GetExpressionWithValueCvtCtx();

  Debug.Assert(!Object.ReferenceEquals(exprCvtCtx,null));

  //----------------------------------------
  var exprResult
   =Expression.Call
     (m_MethodInfo,
      exprCvtCtx,
      opData.Node);

  Debug.Assert(!Object.ReferenceEquals(exprResult,null));

  Debug.Assert(exprResult.NodeType==ExpressionType.Call);

  Debug.Assert(Object.ReferenceEquals(exprResult.Method,m_MethodInfo));

  //----------------------------------------
  return exprResult;
 }//Translate

 //private data ----------------------------------------------------------
 private readonly MethodInfo m_MethodInfo;
};//class ETranslator__Std__WithCvtCtx

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Translators.Std
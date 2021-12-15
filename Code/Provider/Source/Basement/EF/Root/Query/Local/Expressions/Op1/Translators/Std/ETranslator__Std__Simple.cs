////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 12.10.2021.
using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op1.Translators.Std{
////////////////////////////////////////////////////////////////////////////////
//class ETranslator__Std__Simple

sealed class ETranslator__Std__Simple
 :LcpiOleDb__LocalEval_UnaryTranslator
{
 //
 // methodInfo:
 //  - static T_TARGET CVT(T_ARG)
 //

 public ETranslator__Std__Simple(MethodInfo methodInfo)
 {
#if DEBUG
  Debug.Assert(!Object.ReferenceEquals(methodInfo,null));

  Debug.Assert(!Object.ReferenceEquals(methodInfo.ReturnType,null));

  var debug__Parameters=methodInfo.GetParameters();

  Debug.Assert(!Object.ReferenceEquals(debug__Parameters,null));

  Debug.Assert(debug__Parameters.Length==1);

  Debug.Assert(!Object.ReferenceEquals(debug__Parameters[0],null));

  Debug.Assert(!Object.ReferenceEquals(debug__Parameters[0].ParameterType,null));
#endif

  //----------------------------------------
  m_MethodInfo=methodInfo;
 }//ETranslator__Std__Simple

 //own interface ---------------------------------------------------------
 public System.Type ArgType
 {
  get
  {
   Debug.Assert(!Object.ReferenceEquals(m_MethodInfo,null));

   var parameters=m_MethodInfo.GetParameters();

   Debug.Assert(!Object.ReferenceEquals(parameters,null));

   Debug.Assert(parameters.Length==1);

   Debug.Assert(!Object.ReferenceEquals(parameters[0],null));

   Debug.Assert(!Object.ReferenceEquals(parameters[0].ParameterType,null));

   return parameters[0].ParameterType;
  }//get
 }//ArgType

 //-----------------------------------------------------------------------
 public override Expression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.Operand,null));
  Debug.Assert(!Object.ReferenceEquals(opData.Operand.Type,null));

  //----------------------------------------
#if DEBUG
  Debug.Assert(!Object.ReferenceEquals(m_MethodInfo,null));

  Debug.Assert(!Object.ReferenceEquals(m_MethodInfo.ReturnType,null));

  var debug__Parameters=m_MethodInfo.GetParameters();

  Debug.Assert(!Object.ReferenceEquals(debug__Parameters,null));

  Debug.Assert(debug__Parameters.Length==1);

  Debug.Assert(!Object.ReferenceEquals(debug__Parameters[0],null));

  Debug.Assert(!Object.ReferenceEquals(debug__Parameters[0].ParameterType,null));

  Debug.Assert(debug__Parameters[0].ParameterType==opData.Operand.Type);
#endif

  //----------------------------------------
  var exprResult
   =Expression.Call
     (m_MethodInfo,
      opData.Operand);

  Debug.Assert(!Object.ReferenceEquals(exprResult,null));

  Debug.Assert(exprResult.NodeType==ExpressionType.Call);

  Debug.Assert(exprResult.Type==m_MethodInfo.ReturnType);

  Debug.Assert(Object.ReferenceEquals(exprResult.Method,m_MethodInfo));

  //----------------------------------------
  return exprResult;
 }//Translate

 //private data ----------------------------------------------------------
 private readonly MethodInfo m_MethodInfo;
};//class ETranslator__Std__Simple

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op1.Translators.Std

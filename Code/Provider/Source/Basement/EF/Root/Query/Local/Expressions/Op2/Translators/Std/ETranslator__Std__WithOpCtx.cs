////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 14.02.2021.
using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Translators.Std{
////////////////////////////////////////////////////////////////////////////////
//class ETranslator__Std__WithOpCtx

sealed class ETranslator__Std__WithOpCtx:LcpiOleDb__LocalEval_BinaryTranslator
{
 //
 // methodInfo:
 //  - static T_TARGET CVT(Core_OperationCtx, T_LEFT, T_RIGHT)
 //

 public ETranslator__Std__WithOpCtx(MethodInfo methodInfo)
 {
#if DEBUG
  Debug.Assert(!Object.ReferenceEquals(methodInfo,null));

  Debug.Assert(!Object.ReferenceEquals(methodInfo.ReturnType,null));

  var debug__Parameters=methodInfo.GetParameters();

  Debug.Assert(!Object.ReferenceEquals(debug__Parameters,null));

  Debug.Assert(debug__Parameters.Length==3);

  Debug.Assert(!Object.ReferenceEquals(debug__Parameters[0],null));
  Debug.Assert(!Object.ReferenceEquals(debug__Parameters[1],null));
  Debug.Assert(!Object.ReferenceEquals(debug__Parameters[2],null));

  Debug.Assert(!Object.ReferenceEquals(debug__Parameters[0].ParameterType,null));
  Debug.Assert(!Object.ReferenceEquals(debug__Parameters[1].ParameterType,null));
  Debug.Assert(!Object.ReferenceEquals(debug__Parameters[2].ParameterType,null));

  Debug.Assert(debug__Parameters[0].ParameterType==Structure.Structure_TypeCache.TypeOf__LcpiEF__Core_OperationCtx);
#endif

  //----------------------------------------
  m_MethodInfo=methodInfo;
 }//ETranslator__Std__WithOpCtx

 //own interface ---------------------------------------------------------
 public System.Type LeftType
 {
  get
  {
   Debug.Assert(!Object.ReferenceEquals(m_MethodInfo,null));

   var parameters=m_MethodInfo.GetParameters();

   Debug.Assert(!Object.ReferenceEquals(parameters,null));

   Debug.Assert(parameters.Length==3);

   Debug.Assert(!Object.ReferenceEquals(parameters[1],null));

   Debug.Assert(!Object.ReferenceEquals(parameters[1].ParameterType,null));

   return parameters[1].ParameterType;
  }//get
 }//LeftType

 //-----------------------------------------------------------------------
 public System.Type RightType
 {
  get
  {
   Debug.Assert(!Object.ReferenceEquals(m_MethodInfo,null));

   var parameters=m_MethodInfo.GetParameters();

   Debug.Assert(!Object.ReferenceEquals(parameters,null));

   Debug.Assert(parameters.Length==3);

   Debug.Assert(!Object.ReferenceEquals(parameters[2],null));

   Debug.Assert(!Object.ReferenceEquals(parameters[2].ParameterType,null));

   return parameters[2].ParameterType;
  }//get
 }//RightType

 //-----------------------------------------------------------------------
 public override Expression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.Left,null));
  Debug.Assert(!Object.ReferenceEquals(opData.Right,null));
  Debug.Assert(!Object.ReferenceEquals(opData.Left.Type,null));
  Debug.Assert(!Object.ReferenceEquals(opData.Right.Type,null));

  //----------------------------------------
#if DEBUG
  Debug.Assert(!Object.ReferenceEquals(m_MethodInfo,null));

  Debug.Assert(!Object.ReferenceEquals(m_MethodInfo.ReturnType,null));

  var debug__Parameters=m_MethodInfo.GetParameters();

  Debug.Assert(!Object.ReferenceEquals(debug__Parameters,null));

  Debug.Assert(debug__Parameters.Length==3);

  Debug.Assert(!Object.ReferenceEquals(debug__Parameters[0],null));
  Debug.Assert(!Object.ReferenceEquals(debug__Parameters[1],null));
  Debug.Assert(!Object.ReferenceEquals(debug__Parameters[2],null));

  Debug.Assert(!Object.ReferenceEquals(debug__Parameters[0].ParameterType,null));
  Debug.Assert(!Object.ReferenceEquals(debug__Parameters[1].ParameterType,null));
  Debug.Assert(!Object.ReferenceEquals(debug__Parameters[2].ParameterType,null));

  Debug.Assert(debug__Parameters[1].ParameterType==opData.Left.Type);
  Debug.Assert(debug__Parameters[2].ParameterType==opData.Right.Type);

  Debug.Assert(debug__Parameters[0].ParameterType==Structure.Structure_TypeCache.TypeOf__LcpiEF__Core_OperationCtx);
#endif

  //----------------------------------------
  var exprOpCtx
   =opData.ExpressionServices.GetExpressionWithExecCtx();

  Debug.Assert(!Object.ReferenceEquals(exprOpCtx,null));

  //----------------------------------------
  var exprResult
   =Expression.Call
     (m_MethodInfo,
      exprOpCtx,
      opData.Left,
      opData.Right);

  Debug.Assert(!Object.ReferenceEquals(exprResult,null));

  Debug.Assert(exprResult.NodeType==ExpressionType.Call);

  Debug.Assert(exprResult.Type==m_MethodInfo.ReturnType);

  Debug.Assert(Object.ReferenceEquals(exprResult.Method,m_MethodInfo));

  //----------------------------------------
  return exprResult;
 }//Translate

 //private data ----------------------------------------------------------
 private readonly MethodInfo m_MethodInfo;
};//class ETranslator__Std__WithOpCtx

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Translators.Std

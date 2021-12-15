////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 07.01.2021.
using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Translators.Std{
////////////////////////////////////////////////////////////////////////////////
//class ETranslator__Std__Simple

sealed class ETranslator__Std__Simple:LcpiOleDb__LocalEval_ConvertTranslator
{
 //
 // methodInfo:
 //  - static T_TARGET CVT(T_SOURCE)
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

 //LcpiOleDb__LocalEval_ConvertTranslator interface ----------------------
 public override System.Type SourceType
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

  Debug.Assert(debug__Parameters.Length==1);

  Debug.Assert(!Object.ReferenceEquals(debug__Parameters[0],null));

  Debug.Assert(!Object.ReferenceEquals(debug__Parameters[0].ParameterType,null));

  Debug.Assert(debug__Parameters[0].ParameterType==opData.Node.Type);
#endif

  //----------------------------------------
  var exprResult
   =Expression.Convert
     (opData.Node,
      m_MethodInfo.ReturnType,
      m_MethodInfo);

  Debug.Assert(!Object.ReferenceEquals(exprResult,null));

  Debug.Assert(exprResult.NodeType==ExpressionType.Convert);

  Debug.Assert(exprResult.Type==m_MethodInfo.ReturnType);

  Debug.Assert(Object.ReferenceEquals(exprResult.Operand,opData.Node));

  Debug.Assert(Object.ReferenceEquals(exprResult.Method,m_MethodInfo));

  //----------------------------------------
  return exprResult;
 }//Translate

 //private data ----------------------------------------------------------
 private readonly MethodInfo m_MethodInfo;
};//class ETranslator__Std__Simple

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Translators.Std
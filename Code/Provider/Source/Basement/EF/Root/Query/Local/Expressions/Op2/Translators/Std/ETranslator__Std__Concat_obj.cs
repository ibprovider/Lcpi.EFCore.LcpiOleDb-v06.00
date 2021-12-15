////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 07.01.2021.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Translators.Std{
////////////////////////////////////////////////////////////////////////////////
//class ETranslator__Std__Concat_obj

sealed class ETranslator__Std__Concat_obj:LcpiOleDb__LocalEval_BinaryTranslator
{
 public static readonly LcpiOleDb__LocalEval_Op2__Descr<ETranslator__Std__Concat_obj>
  InstanceDescr
   =new LcpiOleDb__LocalEval_Op2__Descr<ETranslator__Std__Concat_obj>
     (new ETranslator__Std__Concat_obj(),
      /*Op2*/null);

 //-----------------------------------------------------------------------
 private ETranslator__Std__Concat_obj()
 {
 }//ETranslator__Std__Concat_obj

 //LcpiOleDb__LocalEval_BinaryTranslator interface -----------------------
 public override Expression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.Left,null));
  Debug.Assert(!Object.ReferenceEquals(opData.Right,null));
  Debug.Assert(!Object.ReferenceEquals(opData.Left.Type,null));
  Debug.Assert(!Object.ReferenceEquals(opData.Right.Type,null));
  Debug.Assert(!Object.ReferenceEquals(opData.ExpressionServices,null));

  //----------------------------------------
  var node_Arg0
   =opData.Left;

  Debug.Assert(!Object.ReferenceEquals(node_Arg0,null));
  Debug.Assert(!Object.ReferenceEquals(node_Arg0.Type,null));

  //----------------------------------------
  var node_Arg1
   =opData.Right;

  Debug.Assert(!Object.ReferenceEquals(node_Arg1,null));
  Debug.Assert(!Object.ReferenceEquals(node_Arg1.Type,null));

  //----------------------------------------
  var exprExecCtx
   =opData.ExpressionServices.GetExpressionWithExecCtx();

  Debug.Assert(!Object.ReferenceEquals(exprExecCtx,null));
  Debug.Assert(!Object.ReferenceEquals(exprExecCtx.Type,null));

  Debug.Assert(exprExecCtx.Type==Structure.Structure_TypeCache.TypeOf__LcpiEF__Core_OperationCtx);

  //----------------------------------------
  var r
   =Expression.Call
     (Code.Op2_Code__Concat___Object__Object.MethodInfo,
      exprExecCtx,
      node_Arg0,
      node_Arg1);

  Debug.Assert(!Object.ReferenceEquals(r,null));

  return r;
 }//Translate
};//class ETranslator__Std__Concat_obj

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Translators.Std

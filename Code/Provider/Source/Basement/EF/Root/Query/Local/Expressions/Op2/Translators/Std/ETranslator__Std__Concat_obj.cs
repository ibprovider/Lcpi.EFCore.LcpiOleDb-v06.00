////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 07.01.2021.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Translators.Std{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

////////////////////////////////////////////////////////////////////////////////
//class ETranslator__Std__Concat_obj

sealed class ETranslator__Std__Concat_obj:LcpiOleDb__LocalEval_BinaryTranslator
{
 private const ErrSourceID c_ErrSrcID
  =ErrSourceID.Root_Query_Local_Expressions__Op2_ETranslator__Std__Concat_obj;

 //-----------------------------------------------------------------------
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
  var expr0
   =Helper__CvtToString
     (opData,
      node_Arg0);

  Debug.Assert(!Object.ReferenceEquals(expr0,null));

  var expr1
   =Helper__CvtToString
     (opData,
      node_Arg1);

  Debug.Assert(!Object.ReferenceEquals(expr1,null));

  //----------------------------------------
  var r
   =Expression.Call
     (Code.Op2_Code__Concat___String__String.MethodInfo,
      expr0,
      expr1);

  Debug.Assert(!Object.ReferenceEquals(r,null));

  return r;
 }//Translate

 //Helper methods --------------------------------------------------------
 private static Expression Helper__CvtToString(in tagOpData opData,
                                               Expression   valueExpr)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.ExpressionServices,null));
  Debug.Assert(!Object.ReferenceEquals(valueExpr,null));
  Debug.Assert(!Object.ReferenceEquals(valueExpr.Type,null));

  var valueType
   =valueExpr.Type;

  if(valueType==Structure_TypeCache.TypeOf__System_String)
  {
   return valueExpr;
  }//if

  //-------------------------------------------------------
  if(!opData.ExpressionServices.TryGetECvtDescr
       (valueType,
        Structure_TypeCache.TypeOf__System_String,
        out var cvtDescr))
  {
   ThrowError.UnsupportedDataTypesConversion
    (c_ErrSrcID,
     valueType,
     Structure_TypeCache.TypeOf__System_String);

   Debug.Assert(false);
  }//if

  Debug.Assert(!Object.ReferenceEquals(cvtDescr.Translator,null));

  LcpiOleDb__LocalEval_ConvertTranslator.tagOpData
   cvtOpData
    =new LcpiOleDb__LocalEval_ConvertTranslator.tagOpData
      (valueExpr,
       opData.ExpressionServices);

  var cvtExpr
   =cvtDescr.Translator.Translate
     (cvtOpData);

  Debug.Assert(!Object.ReferenceEquals(cvtExpr,null));
  Debug.Assert(!Object.ReferenceEquals(cvtExpr.Type,null));

  Debug.Assert(cvtExpr.Type==Structure_TypeCache.TypeOf__System_String);

  return cvtExpr;
 }//Helper__CvtToString
};//class ETranslator__Std__Concat_obj

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Translators.Std

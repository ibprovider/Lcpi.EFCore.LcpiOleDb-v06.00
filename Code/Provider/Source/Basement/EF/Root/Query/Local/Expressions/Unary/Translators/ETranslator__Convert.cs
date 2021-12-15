////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 04.10.2018.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Unary.Translators{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

////////////////////////////////////////////////////////////////////////////////
//class ETranslator__Convert

sealed class ETranslator__Convert
 :LcpiOleDb__LocalEval_UnaryTranslator
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Root_Query_Local_Expressions_Unary__ETranslator__Convert;

 //-----------------------------------------------------------------------
 public static readonly LcpiOleDb__LocalEval_Op1__Descr<ETranslator__Convert>
  Instance
   =new LcpiOleDb__LocalEval_Op1__Descr<ETranslator__Convert>
      (new ETranslator__Convert());

 //-----------------------------------------------------------------------
 private ETranslator__Convert()
 {
 }//ETranslator__Convert

 //Core_Expression_UnaryTranslator interface -----------------------------
 public override Expression Translate(in tagOpData opData)
 {
  Debug.Assert(opData.OperationType==ExpressionType.Convert);
  Debug.Assert(!Object.ReferenceEquals(opData.ResultType,null));
  Debug.Assert(!Object.ReferenceEquals(opData.Operand,null));
  Debug.Assert(!Object.ReferenceEquals(opData.Operand.Type,null));

  Debug.Assert(opData.Operand.Type==opData.Operand.Type.Extension__SwitchToUnderlying());

  //----------------------------------------
  const string c_bugcheck_src
   ="ETranslator__Convert::Translate";

  //----------------------------------------
  Check.BugCheck_Value_NotNull
   (c_ErrSrcID,
    c_bugcheck_src,
    "#001",
    "opData.Operand",
    opData.Operand);

  //----------------------------------------
  var operand
   =opData.Operand;

  bool operandTypeIsNullable
   =operand.Type.Extension__IsNullableType();

  var newTargetType1
   =opData.ResultType.Extension__SwitchToUnderlying();

  var newTargetType2
   =Helper__AdjustNewTargetType
     (newTargetType1,
      operandTypeIsNullable);

  Debug.Assert(!Object.ReferenceEquals(newTargetType2,null));

  if(operand.Type==newTargetType2)
  {
   //Conversion not required

   return operand;
  }//if

  LcpiOleDb__LocalEval_Convert__Descr cvtDescr=default;

  if(!opData.ExpressionServices.TryGetECvtDescr(operand.Type,newTargetType2,out cvtDescr))
  {
   ThrowBugCheck.LocalEvalErr__unsupported_conversion
    (c_ErrSrcID,
     c_bugcheck_src,
     "#002",
     operand.Type,
     newTargetType2);
  }//if

  Debug.Assert(!Object.ReferenceEquals(cvtDescr.Translator,null));
  Debug.Assert(cvtDescr.Translator.SourceType==operand.Type);
  Debug.Assert(cvtDescr.Translator.TargetType==newTargetType2);

  var translatorData
   =new LcpiOleDb__LocalEval_ConvertTranslator.tagOpData
     (operand,
      opData.ExpressionServices);

  var result
   =cvtDescr.Translator.Translate
     (translatorData);

  Debug.Assert(!Object.ReferenceEquals(result,null));
  Debug.Assert(!Object.ReferenceEquals(result.Type,null));

  Debug.Assert(result.Type==newTargetType2);

  return result;
 }//Translate

 //Helper methods --------------------------------------------------------
 private static System.Type Helper__AdjustNewTargetType
                                           (System.Type curTargetType,
                                            bool        liftToNullable)
 {
  Debug.Assert(!Object.ReferenceEquals(curTargetType,null));

  if(liftToNullable)
  {
   if(!curTargetType.Extension__IsNullableType())
   {
    var resultType
     =Structure_TypeCache.TypeOf__System_Nullable.MakeGenericType(curTargetType);

    Debug.Assert(!Object.ReferenceEquals(resultType,null));
    Debug.Assert(resultType.Extension__IsNullableType());

    return resultType;
   }//if
  }//if

  return curTargetType;
 }//Helper__AdjustNewTargetType
};//class ETranslator__Convert

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Unary.Translators

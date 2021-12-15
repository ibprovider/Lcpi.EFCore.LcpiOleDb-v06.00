////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 12.05.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.MasterCode{
////////////////////////////////////////////////////////////////////////////////
//class Op2_MasterCode__ANY___VALUE__TEXT

static class Op2_MasterCode__ANY___VALUE__TEXT<T_RESULT,T_ARG1,T_ARG2,T_ARG2X>
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Root_Query_Local_Expressions__Op2_MasterCode__ANY___VALUE__TEXT;

 //-----------------------------------------------------------------------
 public static T_RESULT Exec(Core.Core_OperationCtx    opCtx,
                             LcpiOleDb__ExpressionType operandType,
                             T_ARG1                    a,
                             T_ARG2                    b)
 {
  const string c_bugcheck_src
   ="Op2_MasterCode__ANY___VALUE__TEXT::Exec";

  //-------------------------------------------------------

  //try to convert 'b' to T_ARG2X

  Debug.Assert(typeof(T_ARG2X).Extension__IsNullableType());

  Core.Core_ValueCvtCtx
   cvtCtx
    =Core.Core_SvcUtils.QuerySvc<Core.Core_ValueCvtCtx>
      (opCtx,
       Core.Core_SvcID.Core_ValueCvtCtx); //throw

  Debug.Assert(!Object.ReferenceEquals(cvtCtx,null));

  var cvt
   =cvtCtx.GetValueCvt
     (typeof(T_ARG2),
      typeof(T_ARG2X));

  if(Object.ReferenceEquals(cvt,null))
  {
   ThrowError.UnsupportedDataTypesConversion
    (c_ErrSrcID,
     typeof(T_ARG2),
     typeof(T_ARG2X));

   Debug.Assert(false);
  }//if

  var cvt_t
   =Check.BugCheck_Value_NotNullAndInstanceOf<Core.Core_ValueCvt<T_ARG2,T_ARG2X>,Core.Core_ValueCvt>
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      nameof(cvt),
      cvt);

  Debug.Assert(!Object.ReferenceEquals(cvt_t,null));

  T_ARG2X bx;

  cvt_t.Exec
   (cvtCtx,
    b,
    out bx); //throw

  //-------------------------------------------------------

  //get operator for comparison of 'a' and 'bx'

  Core.Core_Op2Provider
   op2Provider
    =Core.Core_SvcUtils.QuerySvc<Core.Core_Op2Provider>
      (opCtx,
       Core.Core_SvcID.Core_Op2Provider); //throw

  Debug.Assert(!Object.ReferenceEquals(op2Provider,null));

  //----------------------------------------
  var typeAX=typeof(T_ARG1);
  var typeBX=typeof(T_ARG2X);

  Debug.Assert(!Object.ReferenceEquals(typeAX,null));
  Debug.Assert(!Object.ReferenceEquals(typeBX,null));

  //----------------------------------------
  var op2
   =op2Provider.GetOp2
     (operandType,
      typeAX,
      typeBX); //no throw

  if(Object.ReferenceEquals(op2,null))
  {
   ThrowError.LocalEvalErr__BinaryOperatorNotSupported
    (c_ErrSrcID,
     operandType,
     typeAX,
     typeBX);
  }//if

  Debug.Assert(!Object.ReferenceEquals(op2,null));

  //----------------------------------------
  var op2_t
   =Check.BugCheck_Value_NotNullAndInstanceOf<Core.Core_Op2<T_ARG1,T_ARG2X,T_RESULT>,Core.Core_Op2>
     (c_ErrSrcID,
      c_bugcheck_src,
      "#002",
      nameof(op2),
      op2);

  Debug.Assert(!Object.ReferenceEquals(op2_t,null));

  //----------------------------------------
  T_RESULT result;

  op2_t.Exec
   (opCtx,
    a,
    bx,
    out result); //throw?

  return result;
 }//Exec
};//class Op2_MasterCode__ANY___VALUE__TEXT

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.MasterCode

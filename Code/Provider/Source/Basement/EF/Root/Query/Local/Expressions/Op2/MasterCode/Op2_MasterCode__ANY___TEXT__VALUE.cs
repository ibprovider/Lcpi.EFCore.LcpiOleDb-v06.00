////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 12.05.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.MasterCode{
////////////////////////////////////////////////////////////////////////////////
//class Op2_MasterCode__ANY___TEXT__VALUE

static class Op2_MasterCode__ANY___TEXT__VALUE<T_RESULT,T_ARG1,T_ARG2,T_ARG1X>
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Root_Query_Local_Expressions__Op2_MasterCode__ANY___TEXT__VALUE;

 //-----------------------------------------------------------------------
 public static T_RESULT Exec(Core.Core_OperationCtx    opCtx,
                             LcpiOleDb__ExpressionType operandType,
                             T_ARG1                    a,
                             T_ARG2                    b)
 {
  const string c_bugcheck_src
   ="Op2_MasterCode__ANY___TEXT__VALUE::Exec";

  //-------------------------------------------------------

  //try to convert 'a' to T_ARG1X

  Debug.Assert(typeof(T_ARG1X).Extension__IsNullableType());

  Core.Core_ValueCvtCtx
   cvtCtx
    =Core.Core_SvcUtils.QuerySvc<Core.Core_ValueCvtCtx>
      (opCtx,
       Core.Core_SvcID.Core_ValueCvtCtx); //throw

  Debug.Assert(!Object.ReferenceEquals(cvtCtx,null));

  var cvt
   =cvtCtx.GetValueCvt
     (typeof(T_ARG1),
      typeof(T_ARG1X));

  if(Object.ReferenceEquals(cvt,null))
  {
   ThrowError.UnsupportedDataTypesConversion
    (c_ErrSrcID,
     typeof(T_ARG1),
     typeof(T_ARG1X));

   Debug.Assert(false);
  }//if

  var cvt_t
   =Check.BugCheck_Value_NotNullAndInstanceOf<Core.Core_ValueCvt<T_ARG1,T_ARG1X>,Core.Core_ValueCvt>
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      nameof(cvt),
      cvt);

  Debug.Assert(!Object.ReferenceEquals(cvt_t,null));

  T_ARG1X ax;

  cvt_t.Exec
   (cvtCtx,
    a,
    out ax); //throw

  //-------------------------------------------------------

  //get operator for comparison of 'aa' and 'b'

  Core.Core_Op2Provider
   op2Provider
    =Core.Core_SvcUtils.QuerySvc<Core.Core_Op2Provider>
      (opCtx,
       Core.Core_SvcID.Core_Op2Provider); //throw

  Debug.Assert(!Object.ReferenceEquals(op2Provider,null));

  //----------------------------------------
  var typeAX=typeof(T_ARG1X);
  var typeBX=typeof(T_ARG2);

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
   =Check.BugCheck_Value_NotNullAndInstanceOf<Core.Core_Op2<T_ARG1X,T_ARG2,T_RESULT>,Core.Core_Op2>
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
    ax,
    b,
    out result); //throw?

  return result;
 }//Exec
};//class Op2_MasterCode__ANY___TEXT__VALUE

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.MasterCode

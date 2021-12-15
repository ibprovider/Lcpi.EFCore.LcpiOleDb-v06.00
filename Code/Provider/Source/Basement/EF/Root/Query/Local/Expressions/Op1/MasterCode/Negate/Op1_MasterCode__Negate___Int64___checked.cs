////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 11.10.2021.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op1.MasterCode{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1
 =System.Int64;

using T_RESULT
 =System.Int64;

////////////////////////////////////////////////////////////////////////////////
//class Op1_MasterCode__Negate___Int64___checked

static class Op1_MasterCode__Negate___Int64___checked
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Root_Query_Local_Expressions__Op1_MasterCode__Negate___Int64___checked;

 //-----------------------------------------------------------------------
 public static T_RESULT Exec(T_ARG1 v)
 {
  if(v==T_ARG1.MinValue)
  {
   Helper__ThrowError__Overflow
    (v);
  }//if

  Debug.Assert(v!=T_ARG1.MinValue);

  T_RESULT r=-v;

  return r;
 }//Exec

 //Helper method ---------------------------------------------------------
 private static void Helper__ThrowError__Overflow(T_ARG1 v)
 {
  ThrowSysError.overflow_in_arithmetic_op1<T_ARG1>
   (c_ErrSrcID,
    ExpressionType.Negate,
    v,
    /*innerException*/null);//throw!
 }//Helper__ThrowError__Overflow
};//class Op1_MasterCode__Negate___Int64___checked

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op1.MasterCode

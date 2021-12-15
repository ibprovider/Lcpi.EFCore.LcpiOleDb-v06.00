////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 20.03.2021.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.MasterCode{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1
 =System.Decimal;

using T_ARG2
 =System.Decimal;

using T_RESULT
 =System.Decimal;

////////////////////////////////////////////////////////////////////////////////
//class Op2_MasterCode__Add___Decimal__Decimal

static class Op2_MasterCode__Add___Decimal__Decimal
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Root_Query_Local_Expressions__Op2_MasterCode__Add___Decimal__Decimal;

 //-----------------------------------------------------------------------
 public static T_RESULT Exec(T_ARG1 a,T_ARG2 b)
 {
  T_RESULT r=default;

  try
  {
   r=a+b;
  }
  catch(OverflowException e)
  {
   ThrowSysError.overflow_in_arithmetic_op2<T_ARG1,T_ARG2>
    (c_ErrSrcID,
     ExpressionType.Add,
     a,
     b,
     /*innerException*/e);

   Debug.Assert(false);
  }//catch

  return r;
 }//Exec
};//class Op2_MasterCode__Add___Decimal__Decimal

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.MasterCode
////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 30.03.2021.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.MasterCode{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1
 =System.Double;

using T_ARG2
 =System.Double;

using T_RESULT
 =System.Double;

////////////////////////////////////////////////////////////////////////////////
//class Op2_MasterCode__Divide___Double__Double

static class Op2_MasterCode__Divide___Double__Double
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_V03_0_0__Query_Local_D0_Expressions__Op2_MasterCode__Divide___Double__Double;

 //-----------------------------------------------------------------------
 public static T_RESULT Exec(T_ARG1 a,T_ARG2 b)
 {
  if(b==0)
  {
   ThrowSysError.divide_by_zero
    (c_ErrSrcID,
     /*innerException*/null);
  }//if

  Debug.Assert(b!=0);
  
  T_RESULT r=a/b;
  
  if(T_RESULT.IsInfinity(r))
  {
   ThrowSysError.overflow_in_arithmetic_op2<T_ARG1,T_ARG2>
    (c_ErrSrcID,
     ExpressionType.Divide,
     a,
     b,
     /*innerException*/null);

   Debug.Assert(false);
  }//if

  return r;
 }//Exec
};//class Op2_MasterCode__Divide___Double__Double

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.MasterCode

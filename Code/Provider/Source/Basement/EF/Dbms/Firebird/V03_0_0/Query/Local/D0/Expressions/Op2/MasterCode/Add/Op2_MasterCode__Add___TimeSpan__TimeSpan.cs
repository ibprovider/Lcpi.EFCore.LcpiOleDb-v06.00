////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 19.03.2021.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.MasterCode{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1
 =System.TimeSpan;

using T_ARG2
 =System.TimeSpan;

using T_RESULT
 =System.TimeSpan;

////////////////////////////////////////////////////////////////////////////////

using IscBase_Utils
 =Core.Engines.Dbms.IscBase.IscBase_Utils;

////////////////////////////////////////////////////////////////////////////////
//class Op2_MasterCode__Add___TimeSpan__TimeSpan

static class Op2_MasterCode__Add___TimeSpan__TimeSpan
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_V03_0_0__Query_Local_D0_Expressions__Op2_MasterCode__Add___TimeSpan__TimeSpan;

 //-----------------------------------------------------------------------
 public static T_RESULT Exec(T_ARG1 a,T_ARG2 b)
 {
  var a1
   =IscBase_Utils.NormalizeTimeSpan(a);

  var b1
   =IscBase_Utils.NormalizeTimeSpan(b);

  //----------------------------------------
  if(a1>=sm_ZERO)
  {
   if(b1<=sm_ZERO)
   {
    //no problem
   }
   else
   {
    Debug.Assert(b1>sm_ZERO);

    if((T_RESULT.MaxValue-b1)<a1)
     Helper__ThrowError__Overflow(a1,b1);

    //no problem
   }//else
  }
  else
  {
   Debug.Assert(a1<sm_ZERO);

   if(b1>=sm_ZERO)
   {
    //no problem
   }
   else
   {
    Debug.Assert(b1<sm_ZERO);

    if(a1<(T_RESULT.MinValue-b1))
     Helper__ThrowError__Overflow(a1,b1);

    //no problem
   }//else
  }//else

  //----------------------------------------
  T_RESULT r
   =a1+b1;

  return r;
 }//Exec

 //Helper method ---------------------------------------------------------
 private static void Helper__ThrowError__Overflow(T_ARG1 a,
                                                  T_ARG2 b)
 {
  ThrowSysError.overflow_in_arithmetic_op2<T_ARG1,T_ARG2>
   (c_ErrSrcID,
    ExpressionType.Subtract,
    a,
    b,
    /*innerException*/null);//throw!
 }//Helper__ThrowError__Overflow

 //private data ----------------------------------------------------------
 static readonly System.TimeSpan
  sm_ZERO
   =new System.TimeSpan(0);
};//class Op2_MasterCode__Add___TimeSpan__TimeSpan

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.MasterCode
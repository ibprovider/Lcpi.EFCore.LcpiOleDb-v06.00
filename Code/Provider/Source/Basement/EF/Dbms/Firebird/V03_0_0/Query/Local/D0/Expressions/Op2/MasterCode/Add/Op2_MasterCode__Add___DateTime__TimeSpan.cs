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
 =System.DateTime;

using T_ARG2
 =System.TimeSpan;

using T_RESULT
 =System.DateTime;

////////////////////////////////////////////////////////////////////////////////

using IscBase_Utils
 =Core.Engines.Dbms.IscBase.IscBase_Utils;

using IscBase_Const
 =Core.Engines.Dbms.IscBase.IscBase_Const;

////////////////////////////////////////////////////////////////////////////////
//class Op2_MasterCode__Add___DateTime__TimeSpan

static class Op2_MasterCode__Add___DateTime__TimeSpan
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_V03_0_0__Query_Local_D0_Expressions__Op2_MasterCode__Add___DateTime__TimeSpan;

 //-----------------------------------------------------------------------
 public static T_RESULT Exec(T_ARG1 a,T_ARG2 b)
 {
  var a1
   =IscBase_Utils.NormalizeDateTime(a);

  var b1
   =IscBase_Utils.NormalizeTimeSpan(b);

  //----------------------------------------
  if(b1<sm_ZERO)
  {
   Debug.Assert(a1>=T_ARG1.MinValue);

   var x=a1-T_ARG1.MinValue; //result is timespan

   Debug.Assert(x>=sm_ZERO);

   var x2=x+b1; //result is timespan

   if(x2<sm_ZERO)
   {
    Helper__ThrowError__OutOfRange
     (a1,
      b1);
   }//if

   //OK
  }
  else
  {
   Debug.Assert(b1>=sm_ZERO);

   Debug.Assert(a1<=T_ARG1.MaxValue);

   var x=T_ARG1.MaxValue-a1; //result is timespan

   Debug.Assert(x>=sm_ZERO);

   if(x<b1)
   {
    Helper__ThrowError__OutOfRange
     (a1,
      b1);
   }//if

   //OK
  }//else

  //----------------------------------------
  T_RESULT r=a1+b1;

  // Validate the TIMESTAMP's range?

  // [2021-10-05] Expected that.
  Debug.Assert(r>=IscBase_Const.MinDate);
  Debug.Assert(r<=IscBase_Const.MaxDate);

  //----------------------------------------
  return r;
 }//Exec

 //Helper method ---------------------------------------------------------
 private static void Helper__ThrowError__OutOfRange(T_ARG1 a,
                                                    T_ARG2 b)
 {
  ThrowSysError.out_of_range_in_arithmetic_op2<T_ARG1,T_ARG2>
   (c_ErrSrcID,
    ExpressionType.Add,
    a,
    b);//throw!
 }//Helper__ThrowError__OutOfRange

 //private data ----------------------------------------------------------
 static readonly System.TimeSpan
  sm_ZERO
   =new System.TimeSpan(0);
};//class Op2_MasterCode__Add___DateTime__TimeSpan

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.MasterCode
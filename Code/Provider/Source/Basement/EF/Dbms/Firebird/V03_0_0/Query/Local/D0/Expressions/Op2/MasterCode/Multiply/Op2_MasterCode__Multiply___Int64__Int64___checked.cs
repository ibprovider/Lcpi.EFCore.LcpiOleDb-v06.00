////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 29.03.2021.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.MasterCode{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1
 =System.Int64;

using T_ARG2
 =System.Int64;

using T_RESULT
 =System.Int64;

////////////////////////////////////////////////////////////////////////////////
//class Op2_MasterCode__Multiply___Int64__Int64___checked

static class Op2_MasterCode__Multiply___Int64__Int64___checked
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_V03_0_0__Query_Local_D0_Expressions__Op2_MasterCode__Multiply___Int64__Int64___checked;

 //-----------------------------------------------------------------------
 public static T_RESULT Exec(T_ARG1 a,T_ARG2 b)
 {
  if(a>0)
  {
   // b = -1, 0, 1  no problem

   if(b>1)
   {
    if((T_RESULT.MaxValue/b)<a)
     Helper__ThrowError__Overflow(a,b);

    //no problem
   }
   else
   if(b<-1)
   {
    if((T_RESULT.MinValue/b)<a)
     Helper__ThrowError__Overflow(a,b);

    //no problem
   }//if
  }
  else
  if(a<0)
  {
   if(b<0)
   {
    if((T_RESULT.MaxValue/b)>a)
     Helper__ThrowError__Overflow(a,b);

    //no problem
   }
   else
   if(b>0)
   {
    if((T_RESULT.MinValue/b)>a)
     Helper__ThrowError__Overflow(a,b);

    //no problem
   }//if
  }//if

  T_RESULT r=a*b;

  return r;
 }//Exec

 //Helper method ---------------------------------------------------------
 private static void Helper__ThrowError__Overflow(T_ARG1 a,
                                                  T_ARG2 b)
 {
  ThrowSysError.overflow_in_arithmetic_op2<T_ARG1,T_ARG2>
   (c_ErrSrcID,
    ExpressionType.Multiply,
    a,
    b,
    /*innerException*/null);//throw!
 }//Helper__ThrowError__Overflow
};//class Op2_MasterCode__Multiply___Int64__Int64___checked

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.MasterCode
////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 29.03.2021.
using System;
using System.Diagnostics;

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
//class Op2_MasterCode__Multiply___Int64__Int64___unchecked

static class Op2_MasterCode__Multiply___Int64__Int64___unchecked
{
 public static T_RESULT Exec(T_ARG1 a,T_ARG2 b)
 {
#if DEBUG
  if(a>0)
  {
   // b = -1, 0, 1  no problem

   if(b>1)
   {
    if((T_RESULT.MaxValue/b)<a)
     Debug.Assert(false);

    //no problem
   }
   else
   if(b<-1)
   {
    if((T_RESULT.MinValue/b)<a)
     Debug.Assert(false);

    //no problem
   }//if
  }
  else
  if(a<0)
  {
   if(b<0)
   {
    if((T_RESULT.MaxValue/b)>a)
     Debug.Assert(false);

    //no problem
   }
   else
   if(b>0)
   {
    if((T_RESULT.MinValue/b)>a)
     Debug.Assert(false);

    //no problem
   }//if
  }//if
#endif //DEBUG

  T_RESULT r=a*b;

  return r;
 }//Exec
};//class Op2_MasterCode__Multiply___Int64__Int64___unchecked

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.MasterCode

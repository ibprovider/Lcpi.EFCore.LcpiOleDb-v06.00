////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 20.04.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.MasterCode{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1
 =System.Int16;

using T_ARG2
 =System.Int16;

using T_RESULT
 =System.Int32;

////////////////////////////////////////////////////////////////////////////////
//class Op2_MasterCode__Add___Int16__Int16__Int32

static class Op2_MasterCode__Add___Int16__Int16__Int32
{
 public static T_RESULT Exec(T_ARG1 int16A,T_ARG2 int16B)
 {
  System.Int32 a=int16A;
  System.Int32 b=int16B;

#if DEBUG
  if(a>=0)
  {
   if(b<=0)
   {
    //no problem
   }
   else
   {
    Debug.Assert(b>0);

    if((T_RESULT.MaxValue-b)<a)
     Debug.Assert(false);

    //no problem
   }//else
  }
  else
  {
   Debug.Assert(a<0);

   if(b>=0)
   {
    //no problem
   }
   else
   {
    Debug.Assert(b<0);

    if(a<(T_RESULT.MinValue-b))
     Debug.Assert(false);

    //no problem
   }//else
  }//else
#endif //DEBUG

  T_RESULT r=a+b;

  return r;
 }//Exec
};//class Op2_MasterCode__Add___Int16__Int16__Int32

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.MasterCode
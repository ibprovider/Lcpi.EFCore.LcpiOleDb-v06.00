////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 07.10.2021.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1
 =System.Nullable<System.TimeSpan>;

using T_ARG2
 =System.TimeSpan;

using T_RESULT
 =System.Nullable<System.TimeSpan>;

////////////////////////////////////////////////////////////////////////////////
//class Op2_Code__Subtract___NullableTimeSpan__TimeSpan

static class Op2_Code__Subtract___NullableTimeSpan__TimeSpan
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo_V_V
   =typeof(Op2_Code__Subtract___NullableTimeSpan__TimeSpan)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec_V_V));

 //-----------------------------------------------------------------------
 private static T_RESULT Exec_V_V(T_ARG1 a,T_ARG2 b)
 {
  if(!a.HasValue)
   return null;

  Debug.Assert(a.HasValue);

  return D0.Expressions.Op2.MasterCode.Op2_MasterCode__Subtract___TimeSpan__TimeSpan.Exec
          (a.Value,
           b);
 }//Exec_V_V
};//class Op2_Code__Subtract___NullableTimeSpan__TimeSpan

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.Code

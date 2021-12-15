////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 12.10.2021.
using System;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op1.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1
 =System.TimeSpan;

using T_RESULT
 =System.TimeSpan;

////////////////////////////////////////////////////////////////////////////////
//class Op1_Code__Negate___TimeSpan

static class Op1_Code__Negate___TimeSpan
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo_V
   =typeof(Op1_Code__Negate___TimeSpan)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec_V));

 //-----------------------------------------------------------------------
 private static T_RESULT Exec_V(T_ARG1 v)
 {
  return MasterCode.Op1_MasterCode__Negate___TimeSpan.Exec
          (v);
 }//Exec_V_V
};//class Op1_Code__Negate___TimeSpan

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op1.Code

////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 31.03.2021.
using System;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1
 =System.Double;

using T_ARG2
 =System.Decimal;

using T_RESULT
 =System.Double;

////////////////////////////////////////////////////////////////////////////////
//class Op2_Code__Subtract___Double__Decimal

static class Op2_Code__Subtract___Double__Decimal
{
 public static readonly System.Reflection.MethodInfo MethodInfo_V_V
  =typeof(Op2_Code__Subtract___Double__Decimal)
    .GetTypeInfo()
    .GetDeclaredMethod(nameof(Exec_V_V));

 //-----------------------------------------------------------------------
 public static T_RESULT Exec_V_V(T_ARG1 a,T_ARG2 b)
 {
  return D0.Expressions.Op2.MasterCode.Op2_MasterCode__Subtract___Double__Double.Exec
          (a,
           (double)b);
 }//Exec_V_V
};//class Op2_Code__Subtract___Double__Decimal

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.Code

////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 30.03.2021.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1
 =System.Single;

using T_ARG2
 =System.Nullable<System.Double>;

using T_RESULT
 =System.Nullable<System.Double>;

////////////////////////////////////////////////////////////////////////////////
//class Op2_Code__Divide___Single__NullableDouble

static class Op2_Code__Divide___Single__NullableDouble
{
 public static readonly System.Reflection.MethodInfo MethodInfo_V_V
  =typeof(Op2_Code__Divide___Single__NullableDouble)
    .GetTypeInfo()
    .GetDeclaredMethod(nameof(Exec_V_V));

 //-----------------------------------------------------------------------
 private static T_RESULT Exec_V_V(T_ARG1 a,T_ARG2 b)
 {
  if(!b.HasValue)
   return null;

  Debug.Assert(b.HasValue);

  return D0.Expressions.Op2.MasterCode.Op2_MasterCode__Divide___Double__Double.Exec
          (a,
           b.Value);
 }//Exec_V_V
};//class Op2_Code__Divide___Single__NullableDouble

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.Code

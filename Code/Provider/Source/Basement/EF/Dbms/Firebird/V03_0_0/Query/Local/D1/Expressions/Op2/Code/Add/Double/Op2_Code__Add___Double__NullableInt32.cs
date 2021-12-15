////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 01.04.2021.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D1.Expressions.Op2.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1
 =System.Double;

using T_ARG2
 =System.Nullable<System.Int32>;

using T_RESULT
 =System.Nullable<System.Double>;

////////////////////////////////////////////////////////////////////////////////
//class Op2_Code__Add___Double__NullableInt32

static class Op2_Code__Add___Double__NullableInt32
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo_V_V
   =typeof(Op2_Code__Add___Double__NullableInt32)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec_V_V));

 //-----------------------------------------------------------------------
 private static T_RESULT Exec_V_V(T_ARG1 a,T_ARG2 b)
 {
  if(!b.HasValue)
   return null;

  Debug.Assert(b.HasValue);

  return D0.Expressions.Op2.MasterCode.Op2_MasterCode__Add___Double__Double.Exec
          (a,
           b.Value);
 }//Exec_V_V
};//class Op2_Code__Add___Double__NullableInt32

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D1.Expressions.Op2.Code

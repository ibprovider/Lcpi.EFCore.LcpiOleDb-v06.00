////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 28.05.2021.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1_E
 =System.Byte;

using T_ARG2
 =System.Int32;

using T_RESULT
 =System.Nullable<System.Byte>;

////////////////////////////////////////////////////////////////////////////////
//class Op2_Code__ArrayIndex___Array_Byte__Int32

static class Op2_Code__ArrayIndex___Array_Byte__Int32
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo_V_V
   =typeof(Op2_Code__ArrayIndex___Array_Byte__Int32)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec_V_V));

 //-----------------------------------------------------------------------
 private static T_RESULT Exec_V_V(T_ARG1_E[] a,T_ARG2 b)
 {
  return MasterCode.Op2_MasterCode__ArrayIndex___Array_Byte__Int32.Exec
          (a,
           b);
 }//Exec_V_V
};//class Op2_Code__ArrayIndex___Array_Byte__Int32

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Code

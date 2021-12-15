////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 11.10.2021.
using System;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op1.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1
 =System.Single;

using T_RESULT
 =System.Single;

////////////////////////////////////////////////////////////////////////////////
//class Op1_Code__Negate___Single

static class Op1_Code__Negate___Single
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo_V
   =typeof(Op1_Code__Negate___Single)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec_V));

 //-----------------------------------------------------------------------
 private static T_RESULT Exec_V(T_ARG1 v)
 {
  return MasterCode.Op1_MasterCode__Negate___Single.Exec
          (v);
 }//Exec_V
};//class Op1_Code__Negate___Single

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op1.Code

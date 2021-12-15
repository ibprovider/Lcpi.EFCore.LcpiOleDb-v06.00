////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 08.10.2018.
using System;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op1.Code{
////////////////////////////////////////////////////////////////////////////////
//class Op1_Code__Not___NullableBoolean

static class Op1_Code__Not___NullableBoolean
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo_V
   =typeof(Op1_Code__Not___NullableBoolean)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec_V));

 //-----------------------------------------------------------------------
 private static Nullable<Boolean> Exec_V(Nullable<Boolean> v)
 {
  if(!v.HasValue)
   return null;

  return !v.Value;
 }//Exec_V
};//class Op1_Code__Not___NullableBoolean

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op1.Code

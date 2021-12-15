////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 01.10.2018.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Code{
////////////////////////////////////////////////////////////////////////////////
//class Op2_Code__OrElse___Boolean__NullableBoolean

static class Op2_Code__OrElse___Boolean__NullableBoolean
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo_V_V
   =typeof(Op2_Code__OrElse___Boolean__NullableBoolean)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec_V_V));

 //-----------------------------------------------------------------------
 //
 // Expression:
 //   bool or Nullable<bool>(...)
 //
 //   false or NULL  ->  NULL
 //   true  or NULL  ->  true
 //
 private static Nullable<Boolean> Exec_V_V(Boolean a,Nullable<Boolean> b)
 {
  if(a)
   return true;

  Debug.Assert(!a);

  if(b.HasValue)
   return b.Value;

  Debug.Assert(!b.HasValue);

  return null;
 }//Exec_V_V
};//class Op2_Code__OrElse___Boolean__NullableBoolean

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Code

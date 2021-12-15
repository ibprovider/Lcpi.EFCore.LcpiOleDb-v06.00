////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 01.10.2018.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Code{
////////////////////////////////////////////////////////////////////////////////
//class Op2_Code__OrElse___NullableBoolean__Boolean

static class Op2_Code__OrElse___NullableBoolean__Boolean
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo_V_V
   =typeof(Op2_Code__OrElse___NullableBoolean__Boolean)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec_V_V));

 //-----------------------------------------------------------------------
 //
 // Expression:
 //   Nullable<bool>(...) or bool
 //
 //   NULL or false  ->  NULL
 //   NULL or true   ->  true
 //
 private static Nullable<Boolean> Exec_V_V(Nullable<Boolean> a,Boolean b)
 {
  if(b)
   return true;

  Debug.Assert(!b);

  if(a.HasValue)
   return a.Value;

  Debug.Assert(!a.HasValue);

  return null;
 }//Exec_V_V
};//class Op2_Code__OrElse___NullableBoolean__Boolean

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Code

////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 16.10.2018.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Code{
////////////////////////////////////////////////////////////////////////////////
//class Op2_Code__AndAlso___NullableBoolean__NullableBoolean

static class Op2_Code__AndAlso___NullableBoolean__NullableBoolean
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo_V_V
   =typeof(Op2_Code__AndAlso___NullableBoolean__NullableBoolean)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec_V_V));

 //-----------------------------------------------------------------------
 //
 // Expression:
 //   Nullable<bool>(...) and Nullable<bool>(...)
 //
 //   NULL and NULL   ->  NULL
 //   NULL and false  ->  false
 //   NULL and true   ->  NULL
 //
 private static Nullable<Boolean> Exec_V_V(Nullable<Boolean> a,Nullable<Boolean> b)
 {
  if(!a.HasValue)
  {
   if(!b.HasValue)
    return null;

   if(b.Value) //true
    return null;

   return false;
  }//if !a.HasValue

  Debug.Assert(a.HasValue);

  if(!a.Value) //false
   return false;

  Debug.Assert(a.Value); //a==true

  if(!b.HasValue)
   return null;

  return b.Value;
 }//Exec_V_V
};//class Op2_Code__AndAlso___NullableBoolean__NullableBoolean

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Code

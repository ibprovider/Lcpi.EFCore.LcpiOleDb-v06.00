////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 01.10.2018.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Code{
////////////////////////////////////////////////////////////////////////////////
//class Op2_Code__OrElse___NullableBoolean__NullableBoolean

static class Op2_Code__OrElse___NullableBoolean__NullableBoolean
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo_V_V
   =typeof(Op2_Code__OrElse___NullableBoolean__NullableBoolean)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec_V_V));

 //-----------------------------------------------------------------------
 //
 // Expression:
 //   Nullable<bool>(...) or Nullable<bool>(...)
 //
 //   NULL or NULL   ->  NULL
 //   NULL or false  ->  NULL
 //   NULL or true   ->  true
 //
 private static Nullable<Boolean> Exec_V_V(Nullable<Boolean> a,Nullable<Boolean> b)
 {
  if(a.HasValue)
  {
   if(a.Value)
    return true;

   Debug.Assert(a.HasValue);
   Debug.Assert(a.Value==false);

   if(b.HasValue)
    return b.Value;

   Debug.Assert(!b.HasValue);
   Debug.Assert(a.Value==false);

   return null;
  }//if(a.HasValue)

  Debug.Assert(!a.HasValue);

  if(b.HasValue)
  {
   if(b.Value)
    return true;

   return null;
  }//if(b.HasValue)

  Debug.Assert(!b.HasValue);

  return null;
 }//Exec_V_V
};//class Op2_Code__OrElse___NullableBoolean__NullableBoolean

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Code

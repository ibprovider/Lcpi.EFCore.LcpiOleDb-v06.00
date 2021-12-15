////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 15.07.2021.
using System;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code{
////////////////////////////////////////////////////////////////////////////////
//class Method_Code__NullableDateOnly__AddDays

static class Method_Code__NullableDateOnly__AddDays
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Method_Code__NullableDateOnly__AddDays)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static Nullable<DateOnly> Exec(Nullable<DateOnly> obj,
                                        Nullable<Int32>    amount)
 {
  if(!obj.HasValue)
   return null;

  if(!amount.HasValue)
   return null;

  return obj.Value.AddDays(amount.Value);
 }//Exec
};//class Method_Code__NullableDateOnly__AddDays

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code

////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 16.07.2021.
using System;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code{
////////////////////////////////////////////////////////////////////////////////
//class Method_Code__NullableDateOnly__AddYears

static class Method_Code__NullableDateOnly__AddYears
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Method_Code__NullableDateOnly__AddYears)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static Nullable<DateOnly> Exec(Nullable<DateOnly> obj,
                                        Nullable<Int32>    amountValue)
 {
  if(!obj.HasValue)
   return null;

  if(!amountValue.HasValue)
   return null;

  return obj.Value.AddYears(amountValue.Value);
 }//Exec
};//class Method_Code__NullableDateOnly__AddYears

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code

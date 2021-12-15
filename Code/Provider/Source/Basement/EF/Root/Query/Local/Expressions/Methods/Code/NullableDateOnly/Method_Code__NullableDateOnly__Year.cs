////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 15.07.2021.
using System;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code{
////////////////////////////////////////////////////////////////////////////////
//class Method_Code__NullableDateOnly__Year

static class Method_Code__NullableDateOnly__Year
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Method_Code__NullableDateOnly__Year)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static Nullable<Int32> Exec(Nullable<DateOnly> obj)
 {
  if(!obj.HasValue)
   return null;

  return obj.Value.Year;
 }//Exec
};//class Method_Code__NullableDateOnly__Year

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code

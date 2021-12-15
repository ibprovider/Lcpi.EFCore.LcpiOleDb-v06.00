////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 01.07.2021.
using System;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Code{
////////////////////////////////////////////////////////////////////////////////

using T_SOURCE
 =System.DateOnly;

using T_TARGET
 =System.Nullable<System.DateOnly>;

////////////////////////////////////////////////////////////////////////////////
//class Convert_Code__DateOnly__NullableDateOnly

static class Convert_Code__DateOnly__NullableDateOnly
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Convert_Code__DateOnly__NullableDateOnly)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static T_TARGET Exec(T_SOURCE v)
 {
  return v;
 }//Exec
};//class Convert_Code__DateOnly__NullableDateOnly

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Code

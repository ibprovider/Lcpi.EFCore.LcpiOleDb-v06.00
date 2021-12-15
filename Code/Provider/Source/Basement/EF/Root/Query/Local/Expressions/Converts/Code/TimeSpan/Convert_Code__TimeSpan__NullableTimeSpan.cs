////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 14.11.2020.
using System;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Code{
////////////////////////////////////////////////////////////////////////////////

using T_SOURCE
 =System.TimeSpan;

using T_TARGET
 =System.Nullable<System.TimeSpan>;

////////////////////////////////////////////////////////////////////////////////
//class Convert_Code__TimeSpan__NullableTimeSpan

static class Convert_Code__TimeSpan__NullableTimeSpan
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Convert_Code__TimeSpan__NullableTimeSpan)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static T_TARGET Exec(T_SOURCE v)
 {
  return v;
 }//Exec
};//class Convert_Code__TimeSpan__NullableTimeSpan

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Code

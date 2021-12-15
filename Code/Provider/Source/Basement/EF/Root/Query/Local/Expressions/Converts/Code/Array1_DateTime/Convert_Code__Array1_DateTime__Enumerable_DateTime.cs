////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 16.09.2021.
using System;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Code{
////////////////////////////////////////////////////////////////////////////////

using T_SOURCE_E
 =System.DateTime;

using T_TARGET
 =System.Collections.Generic.IEnumerable<System.DateTime>;

////////////////////////////////////////////////////////////////////////////////
//class Convert_Code__Array1_DateTime__Enumerable_DateTime

static class Convert_Code__Array1_DateTime__Enumerable_DateTime
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Convert_Code__Array1_DateTime__Enumerable_DateTime)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static T_TARGET Exec(T_SOURCE_E[] v)
 {
  return MasterCode.Convert_MasterCode__Array1_T__IEnumerable_T<T_SOURCE_E>.Exec(v);
 }//Exec
};//class Convert_Code__Array1_DateTime__Enumerable_DateTime

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Code

////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 27.03.2019.
using System;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code{
////////////////////////////////////////////////////////////////////////////////
//class Method_Code__DateTime__DayOfYear

static class Method_Code__DateTime__DayOfYear
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Method_Code__DateTime__DayOfYear)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static int Exec(DateTime obj)
 {
  return obj.DayOfYear;
 }//Exec
};//class Method_Code__DateTime__DayOfYear

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code

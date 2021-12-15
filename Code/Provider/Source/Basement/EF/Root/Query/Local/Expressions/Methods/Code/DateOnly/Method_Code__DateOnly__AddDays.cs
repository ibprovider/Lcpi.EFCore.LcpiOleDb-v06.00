////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 14.07.2021.
using System;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code{
////////////////////////////////////////////////////////////////////////////////
//class Method_Code__DateOnly__AddDays

static class Method_Code__DateOnly__AddDays
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Method_Code__DateOnly__AddDays)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static DateOnly Exec(DateOnly obj,
                              int      amountValue)
 {
  return obj.AddDays(amountValue);
 }//Exec
};//class Method_Code__DateOnly__AddDays

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code

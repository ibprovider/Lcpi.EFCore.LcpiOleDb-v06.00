////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 02.04.2019.
using System;
using System.Reflection;

using structure_lib=lcpi.lib.structure;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code{
////////////////////////////////////////////////////////////////////////////////
//class Method_Code__Math__Round__Double_Int32

static class Method_Code__Math__Round__Double_Int32
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Method_Code__Math__Round__Double_Int32)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static double Exec(Double value,
                            Int32  digits)
 {
  //Firebird supports digits in [-127 ... 126]

  return structure_lib.DoubleUtils.Round(value,digits);
 }//Exec
};//class Method_Code__Math__Round__Double_Int32

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code

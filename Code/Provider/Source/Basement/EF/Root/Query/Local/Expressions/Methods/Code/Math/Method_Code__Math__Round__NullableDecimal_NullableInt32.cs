////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 11.04.2019.
using System;
using System.Reflection;

using structure_lib=lcpi.lib.structure;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code{
////////////////////////////////////////////////////////////////////////////////
//class Method_Code__Math__Round__NullableDecimal_NullableInt32

static class Method_Code__Math__Round__NullableDecimal_NullableInt32
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Method_Code__Math__Round__NullableDecimal_NullableInt32)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static Nullable<decimal> Exec(Nullable<Decimal> value,
                                       Nullable<Int32>   digits)
 {
  if(!value.HasValue)
   return null;

  if(!digits.HasValue)
   return null;

  //Firebird supports digits in [-127 ... 126]

  return structure_lib.DecimalUtils.Round(value.Value,digits.Value); //throw
 }//Exec
};//class Method_Code__Math__Round__NullableDecimal_NullableInt32

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code

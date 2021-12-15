////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 07.11.2018.
using System;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code{
////////////////////////////////////////////////////////////////////////////////
//class Method_Code__NullableDateTime__AddMonths

static class Method_Code__NullableDateTime__AddMonths
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Method_Code__NullableDateTime__AddMonths)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static Nullable<DateTime> Exec(Nullable<DateTime> obj,
                                        Nullable<Int32>    amountValue)
 {
  if(!obj.HasValue)
   return null;

  if(!amountValue.HasValue)
   return null;

  return obj.Value.AddMonths(amountValue.Value);
 }//Exec
};//class Method_Code__NullableDateTime__AddMonths

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code

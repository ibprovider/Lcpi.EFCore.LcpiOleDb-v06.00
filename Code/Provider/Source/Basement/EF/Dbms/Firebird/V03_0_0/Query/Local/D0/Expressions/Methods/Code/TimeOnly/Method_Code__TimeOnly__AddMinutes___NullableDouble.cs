////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 22.07.2021.
using System;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Methods.Code{
////////////////////////////////////////////////////////////////////////////////
//class Method_Code__TimeOnly__AddMinutes___NullableDouble

static class Method_Code__TimeOnly__AddMinutes___NullableDouble
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Method_Code__TimeOnly__AddMinutes___NullableDouble)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static Nullable<TimeOnly> Exec(TimeOnly         obj,
                                        Nullable<Double> amountValue)
 {
  if(!amountValue.HasValue)
   return null;

  return MasterCode.Method_MasterCode__TimeOnly__AddMinutes.Exec
          (obj,
           amountValue.Value);
 }//Exec
};//class Method_Code__TimeOnly__AddMinutes___NullableDouble

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Methods.Code

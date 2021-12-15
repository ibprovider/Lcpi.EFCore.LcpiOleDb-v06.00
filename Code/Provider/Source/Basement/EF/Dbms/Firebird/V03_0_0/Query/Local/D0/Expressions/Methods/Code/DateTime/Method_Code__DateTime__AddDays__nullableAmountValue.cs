////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 09.11.2018.
using System;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Methods.Code{
////////////////////////////////////////////////////////////////////////////////
//class Method_Code__DateTime__AddDays__nullableAmountValue

static class Method_Code__DateTime__AddDays__nullableAmountValue
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Method_Code__DateTime__AddDays__nullableAmountValue)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static Nullable<DateTime> Exec(DateTime         obj,
                                        Nullable<Double> amountValue)
 {
  if(!amountValue.HasValue)
   return null;

  return MasterCode.Method_MasterCode__DateTime__AddDays.Exec
          (obj,
           amountValue.Value);
 }//Exec
};//class Method_Code__DateTime__AddDays__nullableAmountValue

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Methods.Code

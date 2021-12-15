////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 17.11.2018.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Methods.Code{
////////////////////////////////////////////////////////////////////////////////
//class Method_Code__DateTime__AddSeconds__nullableAmountValue

static class Method_Code__DateTime__AddSeconds__nullableAmountValue
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Method_Code__DateTime__AddSeconds__nullableAmountValue)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static Nullable<DateTime> Exec(DateTime         obj,
                                        Nullable<Double> amountValue)
 {
  if(!amountValue.HasValue)
   return null;

  Debug.Assert(amountValue.HasValue);

  return MasterCode.Method_MasterCode__DateTime__AddSeconds.Exec
          (obj,
           amountValue.Value);
 }//Exec
};//class Method_Code__DateTime__AddSeconds__nullableAmountValue

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Methods.Code

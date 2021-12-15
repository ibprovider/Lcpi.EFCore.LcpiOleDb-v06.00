////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 18.11.2018.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Methods.Code{
////////////////////////////////////////////////////////////////////////////////
//class Method_Code__NullableDateTime__AddMilliseconds

static class Method_Code__NullableDateTime__AddMilliseconds
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Method_Code__NullableDateTime__AddMilliseconds)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static Nullable<DateTime> Exec(Nullable<DateTime> obj,
                                        Nullable<Double>   amountValue)
 {
  if(!obj.HasValue)
   return null;

  Debug.Assert(obj.HasValue);

  if(!amountValue.HasValue)
   return null;

  Debug.Assert(amountValue.HasValue);

  return MasterCode.Method_MasterCode__DateTime__AddMilliseconds.Exec
          (obj.Value,
           amountValue.Value);
 }//Exec
};//class Method_Code__NullableDateTime__AddMilliseconds

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Methods.Code

////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 21.07.2021.
using System;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Methods.Code{
////////////////////////////////////////////////////////////////////////////////
//class Method_Code__NullableTimeOnly__Add___NullableTimeSpan

static class Method_Code__NullableTimeOnly__Add___NullableTimeSpan
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Method_Code__NullableTimeOnly__Add___NullableTimeSpan)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static Nullable<TimeOnly> Exec(Nullable<TimeOnly> obj,
                                        Nullable<TimeSpan> amountValue)
 {
  if(!obj.HasValue)
   return null;

  if(!amountValue.HasValue)
   return null;

  return MasterCode.Method_MasterCode__TimeOnly__Add___TimeSpan.Exec
          (obj.Value,
           amountValue.Value);
 }//Exec
};//class Method_Code__NullableTimeOnly__Add___NullableTimeSpan

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Methods.Code

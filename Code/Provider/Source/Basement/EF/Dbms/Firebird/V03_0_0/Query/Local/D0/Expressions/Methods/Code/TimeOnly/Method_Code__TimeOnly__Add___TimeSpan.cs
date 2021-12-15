////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 19.07.2021.
using System;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Methods.Code{
////////////////////////////////////////////////////////////////////////////////
//class Method_Code__TimeOnly__Add___TimeSpan

static class Method_Code__TimeOnly__Add___TimeSpan
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Method_Code__TimeOnly__Add___TimeSpan)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static TimeOnly Exec(TimeOnly obj,
                              TimeSpan amountValue)
 {
  return MasterCode.Method_MasterCode__TimeOnly__Add___TimeSpan.Exec
          (obj,
           amountValue);
 }//Exec
};//class Method_Code__TimeOnly__Add___TimeSpan

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Methods.Code

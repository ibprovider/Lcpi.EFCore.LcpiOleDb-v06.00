////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 18.07.2021.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_ADP
 =Structure.Structure_ADP;

////////////////////////////////////////////////////////////////////////////////
//class Method_Code__TimeOnly__Hour

static class Method_Code__TimeOnly__Hour
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Method_Code__TimeOnly__Hour)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static int Exec(TimeOnly obj)
 {
#if DEBUG
  Debug.Assert(Structure_ADP.DEBUG__TimeOnlyContainsValidSqlTime(obj));
#endif

  //----------------------------------------
  return obj.Hour;
 }//Exec
};//class Method_Code__TimeOnly__Hour

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code

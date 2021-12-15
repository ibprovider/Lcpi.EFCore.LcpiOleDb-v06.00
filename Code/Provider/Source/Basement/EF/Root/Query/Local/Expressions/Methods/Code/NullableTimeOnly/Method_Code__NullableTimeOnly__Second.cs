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
//class Method_Code__NullableTimeOnly__Second

static class Method_Code__NullableTimeOnly__Second
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Method_Code__NullableTimeOnly__Second)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static Nullable<int> Exec(Nullable<TimeOnly> obj)
 {
  if(!obj.HasValue)
   return null;

  //----------------------------------------
#if DEBUG
  Debug.Assert(Structure_ADP.DEBUG__TimeOnlyContainsValidSqlTime(obj.Value));
#endif

  //----------------------------------------
  return obj.Value.Second;
 }//Exec
};//class Method_Code__NullableTimeOnly__Second

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code

////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 29.08.2021.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code{
////////////////////////////////////////////////////////////////////////////////

using T_RESULT
 =System.Nullable<System.Double>;

using T_ARG1__OBJ
 =System.Nullable<System.Int32>;

using T_ARG2
 =System.Nullable<System.Double>;

////////////////////////////////////////////////////////////////////////////////
//class Method_Code__NullableInt32__GetValueOrDefault__NullableDouble

static class Method_Code__NullableInt32__GetValueOrDefault__NullableDouble
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Method_Code__NullableInt32__GetValueOrDefault__NullableDouble)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static T_RESULT Exec(T_ARG1__OBJ obj,
                              T_ARG2      defaultValue)
 {
  if(!obj.HasValue)
   return defaultValue;

  Debug.Assert(obj.HasValue);

  return obj.Value;
 }//Exec
};//class Method_Code__NullableInt32__GetValueOrDefault__NullableDouble

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code

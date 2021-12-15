////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 08.06.2021.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code{
////////////////////////////////////////////////////////////////////////////////

using T_RESULT
 =System.Nullable<System.Boolean>;

using T_ARG1__OBJ
 =System.Int64;

using T_ARG2__VALUE
 =System.Nullable<System.Int64>;

////////////////////////////////////////////////////////////////////////////////
//class Method_Code__Int64__HasFlag__NullableInt64

static class Method_Code__Int64__HasFlag__NullableInt64
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Method_Code__Int64__HasFlag__NullableInt64)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static T_RESULT Exec(T_ARG1__OBJ   obj,
                              T_ARG2__VALUE value)
 {
  if(!value.HasValue)
   return null;

  Debug.Assert(value.HasValue);

  var result
   =MasterCode.Method_MasterCode__Int64__HasFlag.Exec
     (obj,
      value.Value);

  return result;
 }//Exec
};//class Method_Code__Int64__HasFlag__NullableInt64

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code

////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 30.08.2021.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code{
////////////////////////////////////////////////////////////////////////////////

using T_RESULT
 =System.Boolean;

using T_ARG1__OBJ
 =System.Nullable<System.Boolean>;

using T_ARG2
 =System.Boolean;

////////////////////////////////////////////////////////////////////////////////
//class Method_Code__NullableBoolean__GetValueOrDefault__Boolean

static class Method_Code__NullableBoolean__GetValueOrDefault__Boolean
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Method_Code__NullableBoolean__GetValueOrDefault__Boolean)
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
};//class Method_Code__NullableBoolean__GetValueOrDefault__Boolean

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code

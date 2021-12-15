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
 =System.Nullable<System.Int16>;

using T_ARG2__VALUE
 =System.Nullable<System.Int16>;

////////////////////////////////////////////////////////////////////////////////
//class Method_Code__NullableInt16__HasFlag__NullableInt16

static class Method_Code__NullableInt16__HasFlag__NullableInt16
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Method_Code__NullableInt16__HasFlag__NullableInt16)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static T_RESULT Exec(T_ARG1__OBJ   obj,
                              T_ARG2__VALUE value)
 {
  if(!obj.HasValue)
   return null;

  Debug.Assert(obj.HasValue);

  if(!value.HasValue)
   return null;

  Debug.Assert(value.HasValue);

  var result
   =MasterCode.Method_MasterCode__Int16__HasFlag.Exec
     (obj.Value,
      value.Value);

  return result;
 }//Exec
};//class Method_Code__NullableInt16__HasFlag__NullableInt16

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code

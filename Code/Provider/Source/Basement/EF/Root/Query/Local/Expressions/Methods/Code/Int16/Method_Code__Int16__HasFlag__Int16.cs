////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 08.06.2021.
using System;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code{
////////////////////////////////////////////////////////////////////////////////

using T_RESULT
 =System.Boolean;

using T_ARG1__OBJ
 =System.Int16;

using T_ARG2__VALUE
 =System.Int16;

////////////////////////////////////////////////////////////////////////////////
//class Method_Code__Int16__HasFlag__Int16

static class Method_Code__Int16__HasFlag__Int16
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Method_Code__Int16__HasFlag__Int16)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static T_RESULT Exec(T_ARG1__OBJ   obj,
                              T_ARG2__VALUE value)
 {
  var result
   =MasterCode.Method_MasterCode__Int16__HasFlag.Exec
     (obj,
      value);

  return result;
 }//Exec
};//class Method_Code__Int16__HasFlag__Int16

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code

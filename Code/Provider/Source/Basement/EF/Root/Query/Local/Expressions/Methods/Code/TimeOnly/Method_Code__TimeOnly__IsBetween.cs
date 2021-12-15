////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 04.09.2021.
using System;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using T_RESULT
 =System.Boolean;

using T_ARG1__OBJ
 =System.TimeOnly;

using T_ARG2__VALUE
 =System.TimeOnly;

using T_ARG3__VALUE
 =System.TimeOnly;

////////////////////////////////////////////////////////////////////////////////
//class Method_Code__TimeOnly__IsBetween

static class Method_Code__TimeOnly__IsBetween
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Method_Code__TimeOnly__IsBetween)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static T_RESULT Exec(T_ARG1__OBJ   obj,
                              T_ARG2__VALUE start,
                              T_ARG3__VALUE end)
 {
  return MasterCode.Method_MasterCode__TimeOnly__IsBetween.Exec
         (obj,
          start,
          end);
 }//Exec
};//class Method_Code__TimeOnly__IsBetween

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code

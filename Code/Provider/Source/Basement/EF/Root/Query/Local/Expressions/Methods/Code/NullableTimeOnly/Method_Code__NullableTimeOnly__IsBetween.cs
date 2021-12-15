////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 04.09.2021.
using System;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using T_RESULT
 =System.Nullable<System.Boolean>;

using T_ARG1__OBJ
 =System.Nullable<System.TimeOnly>;

using T_ARG2__VALUE
 =System.Nullable<System.TimeOnly>;

using T_ARG3__VALUE
 =System.Nullable<System.TimeOnly>;

////////////////////////////////////////////////////////////////////////////////
//class Method_Code__NullableTimeOnly__IsBetween

static class Method_Code__NullableTimeOnly__IsBetween
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Method_Code__NullableTimeOnly__IsBetween)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static T_RESULT Exec(T_ARG1__OBJ   obj,
                              T_ARG2__VALUE start,
                              T_ARG3__VALUE end)
 {
  if(!obj.HasValue)
   return null;

  if(!start.HasValue)
   return null;

  if(!end.HasValue)
   return null;

  return MasterCode.Method_MasterCode__TimeOnly__IsBetween.Exec
         (obj.Value,
          start.Value,
          end.Value);
 }//Exec
};//class Method_Code__NullableTimeOnly__IsBetween

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code

////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 22.09.2021.
using System;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code{
////////////////////////////////////////////////////////////////////////////////

//
// [2021-09-22]
//  Returns INT64. Just because we can.
//
using T_RESULT
 =System.Nullable<System.Int64>;

using T_ARG1__srcStr
 =System.String;

using T_ARG2__seekStr
 =System.String;

////////////////////////////////////////////////////////////////////////////////
//class Method_Code__String__IndexOf__str

static class Method_Code__String__IndexOf__str
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Method_Code__String__IndexOf__str)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static T_RESULT Exec(T_ARG1__srcStr  srcStr,
                              T_ARG2__seekStr seekStr)
 {
  if(Object.ReferenceEquals(srcStr,null))
   return null;

  if(Object.ReferenceEquals(seekStr,null))
   return null;

  return srcStr.IndexOf(seekStr);
 }//Exec
};//class Method_Code__String__IndexOf__str

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code

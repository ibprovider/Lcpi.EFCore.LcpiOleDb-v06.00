////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 27.09.2018.
using System;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code{
////////////////////////////////////////////////////////////////////////////////
//class Method_Code__String__Replace___char__char

static class Method_Code__String__Replace___char__char
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Method_Code__String__Replace___char__char)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static String Exec(String obj,Char old_ch,Char new_ch)
 {
  if(Object.ReferenceEquals(obj,null))
   return null;

  return obj.Replace(old_ch,new_ch);
 }//Exec
};//class Method_Code__String__Replace___char__char

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code

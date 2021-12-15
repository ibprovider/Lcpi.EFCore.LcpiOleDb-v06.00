////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 27.09.2018.
using System;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code{
////////////////////////////////////////////////////////////////////////////////
//class Method_Code__String__Replace___str__str

static class Method_Code__String__Replace___str__str
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Method_Code__String__Replace___str__str)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static String Exec(String obj,String old_str,String new_str)
 {
  if(Object.ReferenceEquals(obj,null))
   return null;

  if(Object.ReferenceEquals(old_str,null))
   return null;

  if(Object.ReferenceEquals(new_str,null))
   return null;

  return obj.Replace(old_str,new_str);
 }//Exec
};//class Method_Code__String__Replace___str__str

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code

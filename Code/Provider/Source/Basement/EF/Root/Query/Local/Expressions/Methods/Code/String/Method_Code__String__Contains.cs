////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 01.10.2018.
using System;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code{
////////////////////////////////////////////////////////////////////////////////
//class Method_Code__String__Contains

static class Method_Code__String__Contains
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Method_Code__String__Contains)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static Nullable<bool> Exec(string obj,string str)
 {
  if(Object.ReferenceEquals(obj,null))
   return null;

  if(Object.ReferenceEquals(str,null))
   return null;

  return obj.Contains(str);
 }//Exec
};//class Method_Code__String__Contains

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code

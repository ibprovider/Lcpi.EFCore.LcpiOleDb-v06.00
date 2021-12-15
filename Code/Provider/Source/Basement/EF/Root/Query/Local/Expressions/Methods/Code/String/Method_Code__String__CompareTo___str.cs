////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 31.05.2021.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code{
////////////////////////////////////////////////////////////////////////////////
//class Method_Code__String__CompareTo___str

static class Method_Code__String__CompareTo___str
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Method_Code__String__CompareTo___str)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static Nullable<int> Exec(String obj,String str)
 {
  //
  //    obj         str        result
  //
  //    null        null       0
  //    value       null       null
  //    null        value      null
  //    value       value      -1,0,1
  //

  if(Object.ReferenceEquals(obj,null))
  {
   if(Object.ReferenceEquals(str,null))
    return 0;

   return null;
  }//if

  Debug.Assert(!Object.ReferenceEquals(obj,null));

  if(Object.ReferenceEquals(str,null))
  {
   return null;
  }//if

  Debug.Assert(!Object.ReferenceEquals(obj,null));

  var result
   =System.StringComparer.Ordinal.Compare(obj,str);

  return result;
 }//Exec
};//class Method_Code__String__CompareTo___str

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code

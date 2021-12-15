////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 01.07.2021.
using System;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Code{
////////////////////////////////////////////////////////////////////////////////

using T_SOURCE
 =System.TimeOnly;

using T_TARGET
 =System.Object;

////////////////////////////////////////////////////////////////////////////////
//class Convert_Code__TimeOnly__Object

static class Convert_Code__TimeOnly__Object
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Convert_Code__TimeOnly__Object)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 public static T_TARGET Exec(T_SOURCE v)
 {
  return MasterCode.Convert_MasterCode__TimeOnly__Object.Exec
          (v);
 }//Exec
};//class Convert_Code__TimeOnly__Object

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Code

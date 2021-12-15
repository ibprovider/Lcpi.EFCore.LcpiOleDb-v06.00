////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 02.05.2021.
using System;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Code{
////////////////////////////////////////////////////////////////////////////////

using T_SOURCE
 =System.SByte;

using T_TARGET
 =System.Double;

////////////////////////////////////////////////////////////////////////////////
//class Convert_Code__SByte__Double

static class Convert_Code__SByte__Double
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Convert_Code__SByte__Double)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static T_TARGET Exec(T_SOURCE v)
 {
  return MasterCode.Convert_MasterCode__SByte__Double.Exec
          (v);
 }//Exec
};//class Convert_Code__SByte__Double

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Code

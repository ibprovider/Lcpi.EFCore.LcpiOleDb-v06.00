////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 04.09.2021.
using System;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.MasterCode{
////////////////////////////////////////////////////////////////////////////////

using T_RESULT
 =System.Boolean;

using T_ARG1__OBJ
 =System.TimeOnly;

using T_ARG2__VALUE
 =System.TimeOnly;

using T_ARG3__VALUE
 =System.TimeOnly;

////////////////////////////////////////////////////////////////////////////////
//class Method_MasterCode__TimeOnly__IsBetween

static class Method_MasterCode__TimeOnly__IsBetween
{
 public static T_RESULT Exec(T_ARG1__OBJ   obj,
                             T_ARG2__VALUE start,
                             T_ARG3__VALUE end)
 {
  return obj.IsBetween(start,end);
 }//Exec
};//class Method_Code__Int64__HasFlag__Int64

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.MasterCode

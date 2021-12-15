////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 08.06.2021.
using System;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.MasterCode{
////////////////////////////////////////////////////////////////////////////////

using T_RESULT
 =System.Boolean;

using T_ARG1__OBJ
 =System.Int64;

using T_ARG2__VALUE
 =System.Int64;

////////////////////////////////////////////////////////////////////////////////
//class Method_MasterCode__Int64__HasFlag

static class Method_MasterCode__Int64__HasFlag
{
 public static T_RESULT Exec(T_ARG1__OBJ   obj,
                             T_ARG2__VALUE value)
 {
  var x=(obj&value);

  if(x==value)
   return true;

  return false;
 }//Exec
};//class Method_MasterCode__Int64__HasFlag

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.MasterCode

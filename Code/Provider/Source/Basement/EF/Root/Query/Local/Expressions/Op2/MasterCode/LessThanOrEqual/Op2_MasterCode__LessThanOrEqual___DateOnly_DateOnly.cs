////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 06.07.2021.

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.MasterCode{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1
 =System.DateOnly;

using T_ARG2
 =System.DateOnly;

using T_RESULT
 =System.Boolean;

////////////////////////////////////////////////////////////////////////////////
//class Op2_MasterCode__LessThanOrEqual___DateOnly_DateOnly

static class Op2_MasterCode__LessThanOrEqual___DateOnly_DateOnly
{
 public static T_RESULT Exec(T_ARG1 a,T_ARG2 b)
 {
  if(a<=b)
   return true;

  return false;
 }//Exec
};//class Op2_MasterCode__LessThanOrEqual___DateOnly_DateOnly

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.MasterCode
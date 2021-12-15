////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 02.01.2021.

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.MasterCode{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1
 =System.Int64;

using T_ARG2
 =System.Int64;

using T_RESULT
 =System.Boolean;

////////////////////////////////////////////////////////////////////////////////
//class Op2_MasterCode__LessThan___Int64_Int64

static class Op2_MasterCode__LessThan___Int64_Int64
{
 public static T_RESULT Exec(T_ARG1 a,T_ARG2 b)
 {
  T_RESULT r=(a<b);

  return r;
 }//Exec
};//class Op2_MasterCode__LessThan___Int64_Int64

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.MasterCode
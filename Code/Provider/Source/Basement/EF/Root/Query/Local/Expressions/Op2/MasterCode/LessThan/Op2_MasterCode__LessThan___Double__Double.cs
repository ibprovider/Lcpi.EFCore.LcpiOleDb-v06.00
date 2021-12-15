////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 02.01.2021.

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.MasterCode{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1
 =System.Double;

using T_ARG2
 =System.Double;

using T_RESULT
 =System.Boolean;

////////////////////////////////////////////////////////////////////////////////
//class Op2_MasterCode__LessThan___Double__Double

static class Op2_MasterCode__LessThan___Double__Double
{
 public static T_RESULT Exec(T_ARG1 a,T_ARG2 b)
 {
  T_RESULT r=(a<b);

  return r;
 }//Exec
};//class Op2_MasterCode__LessThan___Double__Double

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.MasterCode
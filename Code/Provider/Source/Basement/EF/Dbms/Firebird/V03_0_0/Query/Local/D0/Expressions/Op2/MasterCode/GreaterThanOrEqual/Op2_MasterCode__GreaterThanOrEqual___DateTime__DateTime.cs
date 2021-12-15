////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 13.05.2021.

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.MasterCode{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1
 =System.DateTime;

using T_ARG2
 =System.DateTime;

using T_RESULT
 =System.Boolean;

////////////////////////////////////////////////////////////////////////////////

using IscBase_Utils
 =Core.Engines.Dbms.IscBase.IscBase_Utils;

////////////////////////////////////////////////////////////////////////////////
//class Op2_MasterCode__GreaterThanOrEqual___DateTime__DateTime

static class Op2_MasterCode__GreaterThanOrEqual___DateTime__DateTime
{
 public static T_RESULT Exec(T_ARG1 a,T_ARG2 b)
 {
  var a2=IscBase_Utils.NormalizeDateTime(a);
  var b2=IscBase_Utils.NormalizeDateTime(b);

  if(a2>=b2)
   return true;

  return false;
 }//Exec
};//class Op2_MasterCode__GreaterThanOrEqual___DateTime__DateTime

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.MasterCode
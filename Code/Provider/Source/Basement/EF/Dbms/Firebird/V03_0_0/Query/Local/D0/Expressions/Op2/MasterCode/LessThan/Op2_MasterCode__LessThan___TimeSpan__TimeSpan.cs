////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 13.05.2021.
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.MasterCode{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1
 =System.TimeSpan;

using T_ARG2
 =System.TimeSpan;

using T_RESULT
 =System.Boolean;

////////////////////////////////////////////////////////////////////////////////

using IscBase_Utils
 =Core.Engines.Dbms.IscBase.IscBase_Utils;

////////////////////////////////////////////////////////////////////////////////
//class Op2_MasterCode__LessThan___TimeSpan__TimeSpan

static class Op2_MasterCode__LessThan___TimeSpan__TimeSpan
{
 public static T_RESULT Exec(T_ARG1 a,T_ARG2 b)
 {
  var a2
   =IscBase_Utils.NormalizeTimeSpan(a);

  var b2
   =IscBase_Utils.NormalizeTimeSpan(b);

  //----------------------------------------
  if(a2<b2)
   return true;

  return false;
 }//Exec
};//class Op2_MasterCode__LessThan___TimeSpan__TimeSpan

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.MasterCode
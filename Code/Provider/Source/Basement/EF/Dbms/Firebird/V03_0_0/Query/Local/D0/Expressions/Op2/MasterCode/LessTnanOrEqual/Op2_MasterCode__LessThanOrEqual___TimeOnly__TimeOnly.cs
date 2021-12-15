////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 06.07.2021.
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.MasterCode{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1
 =System.TimeOnly;

using T_ARG2
 =System.TimeOnly;

using T_RESULT
 =System.Boolean;

////////////////////////////////////////////////////////////////////////////////

using IscBase_Utils
 =Core.Engines.Dbms.IscBase.IscBase_Utils;

#if DEBUG

using Structure_ADP
 =Structure.Structure_ADP;

#endif

////////////////////////////////////////////////////////////////////////////////
//class Op2_MasterCode__LessThanOrEqual___TimeOnly__TimeOnly

static class Op2_MasterCode__LessThanOrEqual___TimeOnly__TimeOnly
{
 public static T_RESULT Exec(T_ARG1 a,T_ARG2 b)
 {
#if DEBUG
  Debug.Assert(Structure_ADP.DEBUG__TimeOnlyContainsValidSqlTime(a));
  Debug.Assert(Structure_ADP.DEBUG__TimeOnlyContainsValidSqlTime(b));
#endif

  //----------------------------------------
  var a2
   =IscBase_Utils.NormalizeTimeOnly(a);

  var b2
   =IscBase_Utils.NormalizeTimeOnly(b);

  //----------------------------------------
  if(a2<=b2)
   return true;

  return false;
 }//Exec
};//class Op2_MasterCode__LessThanOrEqual___TimeOnly__TimeOnly

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.MasterCode
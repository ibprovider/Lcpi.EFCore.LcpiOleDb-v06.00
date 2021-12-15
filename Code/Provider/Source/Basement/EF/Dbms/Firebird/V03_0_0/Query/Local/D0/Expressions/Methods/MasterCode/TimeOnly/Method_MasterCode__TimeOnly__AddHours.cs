////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 22.07.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Methods.MasterCode{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1
 =System.TimeOnly;

using T_ARG2
 =System.Double;

using T_RESULT
 =System.TimeOnly;

////////////////////////////////////////////////////////////////////////////////

using IscBase_Utils
 =Core.Engines.Dbms.IscBase.IscBase_Utils;

using Structure_ADP
 =Structure.Structure_ADP;

////////////////////////////////////////////////////////////////////////////////
//class Method_MasterCode__TimeOnly__AddHours

static class Method_MasterCode__TimeOnly__AddHours
{
 public static T_RESULT Exec(T_ARG1 obj,
                             T_ARG2 amountValue)
 {
#if DEBUG
  Debug.Assert(Structure_ADP.DEBUG__TimeOnlyContainsValidSqlTime(obj));
#endif

  var resultValue
   =HelperCode.Method_HelperCode__TimeOnly.Add
      (obj,
       amountValue,
       TimeSpan.TicksPerHour); //throw

  //----------------------------------------
  return resultValue;
 }//Exec
};//class Method_MasterCode__TimeOnly__AddHours

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Methods.MasterCode

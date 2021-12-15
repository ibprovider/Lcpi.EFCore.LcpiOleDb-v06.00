////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 26.07.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Methods.MasterCode{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1
 =System.DateTime;

using T_ARG2
 =System.Double;

using T_RESULT
 =System.DateTime;

////////////////////////////////////////////////////////////////////////////////

using IscBase_Utils
 =Core.Engines.Dbms.IscBase.IscBase_Utils;

////////////////////////////////////////////////////////////////////////////////
//class Method_MasterCode__DateTime__AddHours

static class Method_MasterCode__DateTime__AddHours
{
 public static T_RESULT Exec(T_ARG1 obj,
                             T_ARG2 amountValue)
 {
  var resultValue
   =HelperCode.Method_HelperCode__DateTime.Add
      (obj,
       amountValue,
       TimeSpan.TicksPerHour); //throw

  //----------------------------------------
  return resultValue;
 }//Exec
};//class Method_MasterCode__DateTime__AddHours

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Methods.MasterCode

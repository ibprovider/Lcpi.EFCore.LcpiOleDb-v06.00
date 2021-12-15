////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 19.07.2021.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Methods.MasterCode{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1
 =System.TimeOnly;

using T_ARG2
 =System.TimeSpan;

using T_RESULT
 =System.TimeOnly;

////////////////////////////////////////////////////////////////////////////////

using IscBase_Utils
 =Core.Engines.Dbms.IscBase.IscBase_Utils;

using Structure_ADP
 =Structure.Structure_ADP;

////////////////////////////////////////////////////////////////////////////////
//class Method_MasterCode__TimeOnly__Add___TimeSpan

static class Method_MasterCode__TimeOnly__Add___TimeSpan
{
 public static T_RESULT Exec(T_ARG1 a,T_ARG2 b)
 {
#if DEBUG
  Debug.Assert(Structure_ADP.DEBUG__TimeOnlyContainsValidSqlTime(a));
#endif

  //----------------------------------------
  var a1
   =IscBase_Utils.NormalizeTimeOnly(a);

  var b1
   =IscBase_Utils.NormalizeTimeSpan(b);

  //----------------------------------------
  T_RESULT r
   =a1.Add(b1);

#if DEBUG
  Debug.Assert(Structure_ADP.DEBUG__TimeOnlyContainsValidSqlTime(r));
#endif

  //----------------------------------------
  return r;
 }//Exec
};//class Method_MasterCode__TimeOnly__Add___TimeSpan

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Methods.MasterCode

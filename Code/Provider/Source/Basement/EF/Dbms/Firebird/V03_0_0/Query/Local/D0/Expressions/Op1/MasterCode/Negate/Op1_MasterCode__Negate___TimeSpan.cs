////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 12.10.2021.
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op1.MasterCode{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1
 =System.TimeSpan;

using T_RESULT
 =System.TimeSpan;

////////////////////////////////////////////////////////////////////////////////

using IscBase_Utils
 =Core.Engines.Dbms.IscBase.IscBase_Utils;

////////////////////////////////////////////////////////////////////////////////
//class Op1_MasterCode__Negate___TimeSpan

static class Op1_MasterCode__Negate___TimeSpan
{
 public static T_RESULT Exec(T_ARG1 v)
 {
  var v2
   =IscBase_Utils.NormalizeTimeSpan(v);

  Debug.Assert(v2.Ticks!=long.MinValue);

  //----------------------------------------
  var r_Ticks
   =-v2.Ticks; //no problem

  var r
   =new T_ARG1(r_Ticks);

  return r;
 }//Exec
};//class Op1_MasterCode__Negate___TimeSpan

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op1.MasterCode

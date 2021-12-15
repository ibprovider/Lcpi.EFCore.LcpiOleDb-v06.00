////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 06.10.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.MasterCode{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1
 =System.DateTime;

using T_ARG2
 =System.DateTime;

using T_RESULT
 =System.TimeSpan;

////////////////////////////////////////////////////////////////////////////////

using IscBase_Utils
 =Core.Engines.Dbms.IscBase.IscBase_Utils;

////////////////////////////////////////////////////////////////////////////////
//class Op2_MasterCode__Subtract___DateTime__DateTime

static class Op2_MasterCode__Subtract___DateTime__DateTime
{
 public static T_RESULT Exec(T_ARG1 a,T_ARG2 b)
 {
  var a1
   =IscBase_Utils.NormalizeDateTime(a);

  var b1
   =IscBase_Utils.NormalizeDateTime(b);

  //----------------------------------------
  T_RESULT r
   =a1-b1;

  //Check result
  Debug.Assert
   (r.Ticks==(a1.Ticks-b1.Ticks));

  //----------------------------------------
  return r;
 }//Exec
};//class Op2_MasterCode__Subtract___DateTime__DateTime

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.MasterCode
////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 12.08.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Methods.HelperCode{
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
//class Method_HelperCode__DateTime

static class Method_HelperCode__DateTime
{
 public static T_RESULT Add(T_ARG1 obj,
                            T_ARG2 amountValue,
                            long   amountScale)
 {
  Debug.Assert(amountScale>0);

  //----------------------------------------
  const long c_adjustTicks
   =IscBase_Utils.c_AdjustTicks;

  //----------------------------------------
  var obj1
   =IscBase_Utils.NormalizeDateTime(obj);

  //----------------------------------------
  var a1
   =Math.Truncate(amountValue);

  var a2
   =amountValue-a1;

  //----------------------------------------
  var amountInTicks1
    =(long)(a1)*amountScale;

  var amountInTicks2
    =(long)((a2)*amountScale)+((amountValue<0)?-c_adjustTicks:c_adjustTicks);

  var amountInTicks
   =amountInTicks1+amountInTicks2;

  var amountInTicks_n
   =IscBase_Utils.NormalizeTicks(amountInTicks); //throw

  var resultValue1
   =obj1.AddTicks(amountInTicks_n);

  //----------------------------------------
  return resultValue1;
 }//Add
};//class Method_HelperCode__DateTime

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Methods.HelperCode

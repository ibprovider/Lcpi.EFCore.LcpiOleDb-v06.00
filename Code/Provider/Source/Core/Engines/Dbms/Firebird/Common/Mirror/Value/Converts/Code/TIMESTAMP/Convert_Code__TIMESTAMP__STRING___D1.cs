////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core. Engines. Dbms. Firebird.
//                                      IBProvider and Contributors. 27.01.2021.
using System;
using System.Diagnostics;
using System.Text;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Code{
////////////////////////////////////////////////////////////////////////////////
//class Convert_Code__TIMESTAMP__STRING___D1

/// <summary>
///  Converter from TIMESTAMP to TEXT. Firebird 3.0.0.33445, Dialect 1.
/// </summary>
static class Convert_Code__TIMESTAMP__STRING___D1
{
 public static System.String Exec(System.DateTime value)
 {
  var sb=new StringBuilder();

  //----- DATE PART: day-MonthSIGN-year
  Debug.Assert(!Object.ReferenceEquals(sm_MonthSigns,null));
  Debug.Assert(sm_MonthSigns.Length==12);

  Debug.Assert(value.Month>=1);
  Debug.Assert(value.Month<=12);
  Debug.Assert(value.Month<=sm_MonthSigns.Length);

  Debug.Assert(!Object.ReferenceEquals(ConvertConfig.CvtCulture,null));

  sb.Append(value.Day.ToString("D2",ConvertConfig.CvtCulture));
  sb.Append("-");
  sb.Append(sm_MonthSigns[value.Month-1]);
  sb.Append("-");
  sb.Append(value.Year.ToString("D4",ConvertConfig.CvtCulture));

  //----- TIME PART
  if((value.Ticks%c_TicksForDay)<c_TicksForMicroSecond)
  {
   //no time part
  }
  else
  {
   var timePart
    =value.ToString
     ("H:mm:ss.ffff",
      ConvertConfig.CvtCulture);

   sb.Append(" ");
   sb.Append(timePart);
  }//else

  //----- RESULT
  var resultStr
   =sb.ToString();

  Debug.Assert(!string.IsNullOrEmpty(resultStr));
  Debug.Assert(resultStr==resultStr.Trim());

  return resultStr;
 }//Exec

 //private data ----------------------------------------------------------
 const long c_TicksForMicroSecond =1000;
 const long c_TicksForSecond      =10*1000*c_TicksForMicroSecond;
 const long c_TicksForMinute      =60*c_TicksForSecond;
 const long c_TicksForHour        =60*c_TicksForMinute;
 const long c_TicksForDay         =24*c_TicksForHour;

 private static readonly string[]
  sm_MonthSigns
   ={
     /*  0 */ "JAN",
     /*  1 */ "FEB",
     /*  2 */ "MAR",
     /*  3 */ "APR",
     /*  4 */ "MAY",
     /*  5 */ "JUN",
     /*  6 */ "JUL",
     /*  7 */ "AUG",
     /*  8 */ "SEP",
     /*  9 */ "OCT",
     /* 10 */ "NOV",
     /* 11 */ "DEC",
    };//sm_MonthSigns
};//class Convert_Code__TIMESTAMP__STRING___D1

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Code

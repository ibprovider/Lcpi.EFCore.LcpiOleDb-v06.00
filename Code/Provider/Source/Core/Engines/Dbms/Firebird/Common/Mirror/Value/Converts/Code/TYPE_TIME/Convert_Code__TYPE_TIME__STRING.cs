////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core. Engines. Dbms. Firebird.
//                                      IBProvider and Contributors. 27.01.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Code{
////////////////////////////////////////////////////////////////////////////////

using Structure_ADP
 =Structure.Structure_ADP;

////////////////////////////////////////////////////////////////////////////////
//class Convert_Code__TYPE_TIME__STRING

static class Convert_Code__TYPE_TIME__STRING
{
 public static System.String Exec(System.TimeOnly v)
 {
#if DEBUG
  Debug.Assert(Structure_ADP.DEBUG__TimeOnlyContainsValidSqlTime(v));
#endif

  var resultStr
   =v.ToString
     ("HH\\:mm\\:ss\\.ffff",                // <------ NOTE THAT WE USE "HH"!
      ConvertConfig.CvtCulture);

  Debug.Assert(!string.IsNullOrEmpty(resultStr));
  Debug.Assert(resultStr==resultStr.Trim());

  return resultStr;
 }//Exec
};//class Convert_Code__TYPE_TIME__STRING

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Code

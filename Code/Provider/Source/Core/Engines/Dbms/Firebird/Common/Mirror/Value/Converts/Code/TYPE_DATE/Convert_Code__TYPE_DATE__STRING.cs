////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core. Engines. Dbms. Firebird.
//                                      IBProvider and Contributors. 02.07.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Code{
////////////////////////////////////////////////////////////////////////////////
//class Convert_Code__TYPE_DATE__STRING

static class Convert_Code__TYPE_DATE__STRING
{
 public static System.String Exec(System.DateOnly value)
 {
  Debug.Assert(!Object.ReferenceEquals(ConvertConfig.CvtCulture,null));

  var resultStr
   =value.ToString
     ("yyyy-MM-dd",
      ConvertConfig.CvtCulture);

  Debug.Assert(!string.IsNullOrEmpty(resultStr));
  Debug.Assert(resultStr==resultStr.Trim());

  return resultStr;
 }//Exec
};//class Convert_Code__TYPE_DATE__STRING

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Code

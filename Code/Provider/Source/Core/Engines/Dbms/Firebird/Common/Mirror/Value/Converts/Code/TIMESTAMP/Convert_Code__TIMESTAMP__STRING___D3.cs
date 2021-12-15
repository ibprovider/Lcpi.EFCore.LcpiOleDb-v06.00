////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core. Engines. Dbms. Firebird.
//                                      IBProvider and Contributors. 27.01.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Code{
////////////////////////////////////////////////////////////////////////////////
//class Convert_Code__TIMESTAMP__STRING___D3

static class Convert_Code__TIMESTAMP__STRING___D3
{
 public static System.String Exec(System.DateTime value)
 {
  Debug.Assert(!Object.ReferenceEquals(ConvertConfig.CvtCulture,null));

  var resultStr
   =value.ToString
     ("yyyy-MM-dd HH:mm:ss.ffff",
      ConvertConfig.CvtCulture);

  Debug.Assert(!string.IsNullOrEmpty(resultStr));
  Debug.Assert(resultStr==resultStr.Trim());

  return resultStr;
 }//Exec
};//class Convert_Code__TIMESTAMP__STRING___D3

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Code

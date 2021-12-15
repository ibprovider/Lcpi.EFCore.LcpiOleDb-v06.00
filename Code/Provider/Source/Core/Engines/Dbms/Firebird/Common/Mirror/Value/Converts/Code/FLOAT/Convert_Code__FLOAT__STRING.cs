////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core. Engines. Dbms. Firebird.
//                                      IBProvider and Contributors. 27.01.2021.
using lcpi.lib.oledb;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Code{
////////////////////////////////////////////////////////////////////////////////
//class Convert_Code__FLOAT__STRING

static class Convert_Code__FLOAT__STRING
{
 public static System.String Exec(System.Single v)
 {
  //
  //   12345678901234567890123
  // "-1.234567890123456E-300"
  //
  // Max Width: 23
  //
  // Precision: 8
  //
  // Examples:
  //
  // 0.0                                0.00000000
  // 1                                  1.0000000
  // 1.23456799                         1.2345680
  //
  // short.MaxValue                    -3.4028235e+38
  // short.MaxValue                     3.4028235e+38
  // short.Epsilon                      1.4012985e-45
  //

  //--------------------------
  const int c_precision=8;

  return Helpers.Convert_Helper__DOUBLE__STRING.Exec
          (v,
           c_precision);
 }//Exec
};//class Convert_Code__FLOAT__STRING

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Code

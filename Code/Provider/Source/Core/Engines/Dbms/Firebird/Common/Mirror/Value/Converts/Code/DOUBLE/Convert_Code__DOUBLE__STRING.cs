////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core. Engines. Dbms. Firebird.
//                                      IBProvider and Contributors. 26.01.2021.
using lcpi.lib.oledb;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Code{
////////////////////////////////////////////////////////////////////////////////
//class Convert_Code__DOUBLE__STRING

static class Convert_Code__DOUBLE__STRING
{
 public static System.String Exec(System.Double v)
 {
  //
  //   12345678901234567890123
  // "-1.234567890123456E-300"
  //
  // Max Width: 23
  //
  // Precision: 16
  //
  // Examples:
  //
  // 0.0                                0.0000000000000000
  // 1                                  1.000000000000000
  // 1.234567890123459                  1.234567890123459
  // 1.2345678901234599                 1.234567890123460
  // 1234567890123459.9                 1234567890123460.
  //
  // 9999999999999999.0                 1.000000000000000e+16
  //
  // double.MaxValue                   -1.797693134862316e+308
  // double.MaxValue                    1.797693134862316e+308
  // double.Epsilon                     4.940656458412465e-324
  //

  //--------------------------
  const int c_precision=16;

  return Helpers.Convert_Helper__DOUBLE__STRING.Exec
          (v,
           c_precision);
 }//Exec
};//class Convert_Code__DOUBLE__STRING

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Code

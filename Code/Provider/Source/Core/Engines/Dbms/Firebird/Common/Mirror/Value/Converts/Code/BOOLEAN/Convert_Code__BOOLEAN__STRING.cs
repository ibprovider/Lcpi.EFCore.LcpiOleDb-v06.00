////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core. Engines. Dbms. Firebird.
//                                      IBProvider and Contributors. 13.01.2021.

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Code{
////////////////////////////////////////////////////////////////////////////////
//class Convert_Code__BOOLEAN__STRING

static class Convert_Code__BOOLEAN__STRING
{
 public static System.String Exec(System.Boolean v)
 {
  if(v)
   return "TRUE";

  return "FALSE";
 }//Exec
};//class Convert_Code__BOOLEAN__STRING

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Code

////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core. Engines. Dbms. Firebird.
//                                      IBProvider and Contributors. 21.10.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common{
////////////////////////////////////////////////////////////////////////////////
//class FB_Common__CharSetUtils

static class FB_Common__CharSetUtils
{
 public static bool TestCsName__Is_OCTETS(ReadOnlySpan<char> csName)
 {
  if(!Structure.Structure_StrHelpers.TestStrRange__ASCII_UPPER(csName,FB_Common__CharSetNames.OCTETS))
   return false;

  return true;
 }//TestCsName__Is_OCTETS
};//class FB_Common__CharSetUtils

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common

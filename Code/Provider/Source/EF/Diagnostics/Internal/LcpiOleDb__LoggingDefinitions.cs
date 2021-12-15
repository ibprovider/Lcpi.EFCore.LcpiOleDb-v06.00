////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 17.11.2021.
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Diagnostics.Internal{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__LoggingDefinitions

sealed class LcpiOleDb__LoggingDefinitions
 :RelationalLoggingDefinitions
{
#if TRACE
 public LcpiOleDb__LoggingDefinitions()
 {
  Core.Core_Trace.Method
   ("LcpiOleDb__LoggingDefinitions::LcpiOleDb__LoggingDefinitions()");
 }//LcpiOleDb__LoggingDefinitions
#endif
};//class LcpiOleDb__LoggingDefinitions

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Diagnostics.Internal

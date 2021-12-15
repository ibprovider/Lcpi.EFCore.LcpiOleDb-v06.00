////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 14.05.2018.
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Resources{
////////////////////////////////////////////////////////////////////////////////
//class ResourceFileID

static class ResourceFileID
{
 public static readonly Assembly
  Assembly=Assembly.GetExecutingAssembly();

 //-----------------------------------------
 public const string error_sources
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Source.ErrorServices.ErrSourceID";

 public const string error_messages
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Source.ErrorServices.ErrMessageID";
};//class ResourceFileID

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Resources

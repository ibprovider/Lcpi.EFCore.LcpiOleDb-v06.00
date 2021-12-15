////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 01.10.2021.
using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Storage{
////////////////////////////////////////////////////////////////////////////////
//interface LcpiOleDb__IGetUnderlyingTypeMapping

interface LcpiOleDb__IGetUnderlyingTypeMapping
{
 RelationalTypeMapping GetUnderlyingTypeMapping();
};//interface LcpiOleDb__IGetUnderlyingTypeMapping

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Storage

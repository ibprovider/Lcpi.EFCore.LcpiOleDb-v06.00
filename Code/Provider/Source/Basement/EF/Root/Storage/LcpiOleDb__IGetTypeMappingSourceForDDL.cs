////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 18.10.2021.
using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Storage{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__IGetTypeMappingSourceForDDL

interface LcpiOleDb__IGetTypeMappingSourceForDDL
{
 IRelationalTypeMappingSource GetTypeMappingSourceForDDL();
};//interface LcpiOleDb__IGetTypeMappingSourceForDDL

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Storage
////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core.
//                                      IBProvider and Contributors. 03.06.2018.

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core{
////////////////////////////////////////////////////////////////////////////////
//interface Core_ValueCvtCtx

interface Core_ValueCvtCtx:Core_Svc
{
 Core_ValueCvt GetValueCvt(System.Type sourceType,
                           System.Type targetType);
};//class Core_ValueCvtCtx

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core

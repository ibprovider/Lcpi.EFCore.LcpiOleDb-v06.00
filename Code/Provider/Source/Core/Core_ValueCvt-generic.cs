////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core.
//                                      IBProvider and Contributors. 07.01.2021.

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core{
////////////////////////////////////////////////////////////////////////////////
//interface Core_ValueCvt<T_SOURCE,T_TARGET>

interface Core_ValueCvt<T_SOURCE,T_TARGET>:Core_ValueCvt
{
 void Exec(Core_ValueCvtCtx context,
           T_SOURCE         sourceValue,
           out T_TARGET     targetValue);
};//class Core_ValueCvt<T_SOURCE,T_TARGET>

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core

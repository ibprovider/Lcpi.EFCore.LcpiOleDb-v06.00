////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 23.11.2020.

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure{
////////////////////////////////////////////////////////////////////////////////
//interface Structure_IGetDataByKey

interface Structure_IGetDataByKey<TKey,TData>
{
 bool TryGetData(TKey key,out TData data);
};//interface Structure_IGetDataByKey

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure
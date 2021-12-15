////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 27.05.2021.
using System.Collections.Generic;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure{
////////////////////////////////////////////////////////////////////////////////
//interface Structure_IGetDataByKey2

interface Structure_IGetDataByKey2<TKey,TData>
{
 bool TryGetData(TKey key,out TData data);

 IEnumerable<TKey> SelectKeysByName(string name);
};//interface Structure_IGetDataByKey2

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure
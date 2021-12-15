////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core.
//                                      IBProvider and Contributors. 24.05.2018.
using System;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core{
////////////////////////////////////////////////////////////////////////////////
//interface Core_SvcProvider

interface Core_SvcProvider
{
 Core_Svc QuerySvc(Guid SvcID);
};//interface Core_SvcProvider

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core

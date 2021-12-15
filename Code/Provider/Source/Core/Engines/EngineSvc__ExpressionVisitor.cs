////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core. Engines.
//                                      IBProvider and Contributors. 24.05.2018.
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines{
////////////////////////////////////////////////////////////////////////////////
//interface EngineSvc__ObjectIdentifierBuilder

/// <summary>
///  Interface for visitor of expression tree.
/// </summary>
interface EngineSvc__ExpressionVisitor:Core_Svc
{
 Expression Visit(Expression expression);
};//interface EngineSvc__ObjectIdentifierBuilder

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines

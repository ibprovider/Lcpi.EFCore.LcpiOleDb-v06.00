////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 22.12.2020.
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Tags{
////////////////////////////////////////////////////////////////////////////////
//interface FB_Common__Sql_ETag__RequiresBrackets

/// <summary>
///  ETag for usage of brackets around expression body.
/// </summary>
interface FB_Common__Sql_ETag__RequiresBrackets
{
 bool RequiresBrackets(SqlExpression sqlParentExpression);
};//interface FB_Common__Sql_ETag__RequiresBrackets

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Tags

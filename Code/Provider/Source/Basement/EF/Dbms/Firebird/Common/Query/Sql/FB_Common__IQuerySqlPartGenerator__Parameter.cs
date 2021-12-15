////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 22.12.2020.
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql{
////////////////////////////////////////////////////////////////////////////////
//interface FB_Common__IQuerySqlPartGenerator__Parameter

interface FB_Common__IQuerySqlPartGenerator__Parameter
{
 //interface -------------------------------------------------------------
 void Exec(FB_Common__QuerySqlGenerator sqlGenerator,
           SqlParameterExpression       sqlParameterExpression);
};//class FB_Common__IQuerySqlPartGenerator__Parameter

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql

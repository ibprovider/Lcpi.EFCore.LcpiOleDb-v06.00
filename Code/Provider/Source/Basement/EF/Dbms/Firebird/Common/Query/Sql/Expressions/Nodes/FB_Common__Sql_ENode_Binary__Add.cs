////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 13.10.2021.
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes{
////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ENode_Binary__Add

static class FB_Common__Sql_ENode_Binary__Add
{
 public static SqlBinaryExpression Create(SqlExpression         left,
                                          SqlExpression         right,
                                          RelationalTypeMapping resultTypeMapping)
 {
  return Helpers.SqlExpressionFactory__STD.CreateBinaryExpression
          (ExpressionType.Add,
           left,
           right,
           resultTypeMapping); //throw
 }//Create
};//class FB_Common__Sql_ENode_Binary__Add

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes
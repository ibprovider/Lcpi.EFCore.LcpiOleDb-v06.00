////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 23.12.2020.
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_MethodId
 =Structure.Structure_MethodId;

////////////////////////////////////////////////////////////////////////////////
//interface LcpiOleDb__ISqlTreeNodeBuilder

interface LcpiOleDb__ISqlTreeNodeBuilder
{
 SqlExpression MakeUnary(LcpiOleDb__ExpressionType operatorType,
                         SqlExpression             sqlOperand,
                         System.Type               clrResultType);
                         
 SqlExpression MakeBinary(LcpiOleDb__ExpressionType operatorType,
                          SqlExpression             left,
                          SqlExpression             right);

 SqlExpression MakeCall(Structure_MethodId           methodId,
                        SqlExpression                sqlInstance,
                        IReadOnlyList<SqlExpression> sqlArguments);
};//interface LcpiOleDb__ISqlTreeNodeBuilder

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query
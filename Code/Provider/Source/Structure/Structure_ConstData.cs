////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 17.06.2021.
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure{
////////////////////////////////////////////////////////////////////////////////
//class Structure_ConstData

static class Structure_ConstData
{
 public static readonly System.Type[] Array_SystemType__EMPTY
  =System.Array.Empty<System.Type>();

 public static readonly Expression[] Array_LinqExpression__EMPTY
  =System.Array.Empty<Expression>();

 public static readonly bool[] Array_Boolean__EMPTY
  =System.Array.Empty<bool>();

 public static readonly SqlExpression[] Array_SqlExpression__EMPTY
  =System.Array.Empty<SqlExpression>();

 //-----------------------------------------------------------------------
 public static readonly Expression ConstantExpression__String__EMTY
  =Expression.Constant("",Structure_TypeCache.TypeOf__System_String);
};//class Structure_ConstData

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure

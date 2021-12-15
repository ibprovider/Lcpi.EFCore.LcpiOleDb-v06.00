////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 03.04.2019.
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes{
////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ENode_Function

abstract class FB_Common__Sql_ENode_Function:SqlFunctionExpression
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__Sql_ENode_Function;

 //-----------------------------------------------------------------------
 protected FB_Common__Sql_ENode_Function
                             (System.String              functionName,
                              IEnumerable<SqlExpression> arguments,
                              bool                       nullable,
                              IEnumerable<bool>          argumentsPropagateNullability,
                              System.Type                resultType,
                              RelationalTypeMapping      resultTypeMapping)
  :base(functionName,
        arguments,
        nullable,
        argumentsPropagateNullability,
        resultType,
        resultTypeMapping)
 {
 }//FB_Common__Sql_ENode_Function

 //SqlFunctionExpression interface ---------------------------------------
 protected override abstract Expression VisitChildren(ExpressionVisitor visitor);

 //-----------------------------------------------------------------------
 public override abstract SqlFunctionExpression ApplyTypeMapping(RelationalTypeMapping typeMapping);

 //-----------------------------------------------------------------------
 public override abstract SqlFunctionExpression Update(SqlExpression instance, IReadOnlyList<SqlExpression> arguments);

 //-----------------------------------------------------------------------
 protected override abstract void Print(ExpressionPrinter expressionPrinter);

 //Helper methods --------------------------------------------------------
 protected bool Helper__Equals(FB_Common__Sql_ENode_Function e)
 {
  Debug.Assert(!Object.ReferenceEquals(e,null));

  return base.Equals(e);
 }//Helper__Equals
};//class FB_Common__Sql_ENode_Function

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes

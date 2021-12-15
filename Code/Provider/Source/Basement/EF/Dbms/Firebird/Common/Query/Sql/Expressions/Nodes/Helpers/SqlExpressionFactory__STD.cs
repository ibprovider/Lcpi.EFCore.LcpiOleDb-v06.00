////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 03.11.2021.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes.Helpers{
////////////////////////////////////////////////////////////////////////////////
//class SqlExpressionFactory__STD

static class SqlExpressionFactory__STD
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__Sql_ENode_Helpers__SqlExpressionFactory__STD;

 //-----------------------------------------------------------------------
 public static SqlBinaryExpression CreateBinaryExpression
                                        (ExpressionType        operatorType,
                                         SqlExpression         left,
                                         SqlExpression         right,
                                         RelationalTypeMapping resultTypeMapping)

 {
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(CreateBinaryExpression),
    nameof(left),
    left);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(CreateBinaryExpression),
    nameof(right),
    right);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(CreateBinaryExpression),
    nameof(resultTypeMapping),
    resultTypeMapping);

  //------------------------------------------------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(CreateBinaryExpression),
    "left.TypeMapping",
    left.TypeMapping);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(CreateBinaryExpression),
    "right.TypeMapping",
    right.TypeMapping);

  //------------------------------------------------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(CreateBinaryExpression),
    "left.TypeMapping.ClrType",
    left.TypeMapping.ClrType);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(CreateBinaryExpression),
    "right.TypeMapping.ClrType",
    right.TypeMapping.ClrType);

  //------------------------------------------------------------

  // OK

  Debug.Assert(!Object.ReferenceEquals(left,null));
  Debug.Assert(!Object.ReferenceEquals(right,null));
  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));

  Debug.Assert(!Object.ReferenceEquals(left.Type,null));
  Debug.Assert(!Object.ReferenceEquals(left.TypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(left.TypeMapping.ClrType,null));

  Debug.Assert(!Object.ReferenceEquals(right.Type,null));
  Debug.Assert(!Object.ReferenceEquals(right.TypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(right.TypeMapping.ClrType,null));

  //------------------------------------------------------------
  var r
   =new SqlBinaryExpression
     (operatorType,
      left,
      right,
      resultTypeMapping.ClrType,
      resultTypeMapping);

  //------------------------------------------------------------
  Debug.Assert(!Object.ReferenceEquals(r,null));
  Debug.Assert(!Object.ReferenceEquals(r.Type,null));
  Debug.Assert(!Object.ReferenceEquals(r.TypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(r.TypeMapping.ClrType,null));
  Debug.Assert(!Object.ReferenceEquals(r.Left,null));
  Debug.Assert(!Object.ReferenceEquals(r.Right,null));

  Debug.Assert(Object.ReferenceEquals(r.Left,left));
  Debug.Assert(Object.ReferenceEquals(r.Right,right));
  Debug.Assert(Object.ReferenceEquals(r.TypeMapping,resultTypeMapping));

  return r;
 }//CreateBinaryExpression
};//class SqlExpressionFactory__STD

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes.Helpers

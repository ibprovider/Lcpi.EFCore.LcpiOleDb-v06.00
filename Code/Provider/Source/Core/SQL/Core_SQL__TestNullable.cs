////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 14.10.2021.
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.SQL{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

////////////////////////////////////////////////////////////////////////////////
//class Core_SQL__TestNullable

static class Core_SQL__TestNullable
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Core_SQL__TestNullable;

 //-----------------------------------------------------------------------
 public static bool TestNullable_ANY(IEnumerable<SqlExpression> arguments)
 {
  Debug.Assert(!Object.ReferenceEquals(arguments,null));

  foreach(var e in arguments)
  {
   Debug.Assert(!Object.ReferenceEquals(e,null));

   if(Helper__TestNullable(e))
    return true;
  }//foreach e

  return false;
 }//TestNullable_ANY

 //-----------------------------------------------------------------------
 public static bool TestNullable_ALL(IEnumerable<SqlExpression> arguments)
 {
  Debug.Assert(!Object.ReferenceEquals(arguments,null));

  foreach(var e in arguments)
  {
   Debug.Assert(!Object.ReferenceEquals(e,null));

   if(!Helper__TestNullable(e))
    return false;
  }//foreach e

  return true;
 }//TestNullable_ALL

 //-----------------------------------------------------------------------
 public static bool TestNullable(SqlExpression sqlExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlExpression,null));

  if(Helper__TestNullable(sqlExpression))
   return true;

  return false;
 }//TestNullable

 //Helper methods --------------------------------------------------------
 private static bool Helper__TestNullable(SqlExpression sqlExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlExpression,null));

  if(sqlExpression is SqlFunctionExpression sqlFunctionExpression)
   return Helper__TestNullable__Function(sqlFunctionExpression);

  if(sqlExpression is ColumnExpression columnExpression)
   return Helper__TestNullable__Column(columnExpression);

  if(sqlExpression is SqlUnaryExpression sqlUnaryExpression)
   return Helper__TestNullable__Unary(sqlUnaryExpression);

  if(sqlExpression is SqlBinaryExpression sqlBinaryExpression)
   return Helper__TestNullable__Binary(sqlBinaryExpression);

  if(sqlExpression is CaseExpression sqlCaseExpression)
   return Helper__TestNullable__Case(sqlCaseExpression);

  if(sqlExpression is ScalarSubqueryExpression sqlScalarSubqueryExpression)
   return Helper__TestNullable__ScalarSubquery(sqlScalarSubqueryExpression);

  if(sqlExpression is SqlConstantExpression sqlConstantExpression)
   return Helper__TestNullable__Constant(sqlConstantExpression);

  if(sqlExpression is SqlParameterExpression sqlParameterExpression)
   return Helper__TestNullable__Parameter(sqlParameterExpression);

  if(sqlExpression is LikeExpression sqlLikeExpression)
   return Helper__TestNullable__Like(sqlLikeExpression);

  return Helper__TestNullable__UNKNOWN__return_true(sqlExpression);
 }//Helper__TestNullable

 //-----------------------------------------------------------------------
 private static bool Helper__TestNullable__Column(ColumnExpression columnExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(columnExpression,null));

  return columnExpression.IsNullable;
 }//Helper__TestNullable__Column

 //-----------------------------------------------------------------------
 private static bool Helper__TestNullable__Function(SqlFunctionExpression sqlFunctionExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlFunctionExpression,null));

  return sqlFunctionExpression.IsNullable;
 }//Helper__TestNullable__Function

 //-----------------------------------------------------------------------
 private static bool Helper__TestNullable__Unary(SqlUnaryExpression sqlUnaryExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlUnaryExpression,null));

  switch(sqlUnaryExpression.OperatorType)
  {
   case ExpressionType.Equal:
   case ExpressionType.NotEqual:
   {
    if(sqlUnaryExpression.Type==Structure_TypeCache.TypeOf__System_Boolean)
    {
     //"IS NULL" or "IS NOT NULL"

     return false;
    }//if

    //[2021-10-14] Unexpected state
    Debug.Assert(false);

    return true;
   }//Equal, NotEqual

   case ExpressionType.Negate:
   {
    Debug.Assert(!Object.ReferenceEquals(sqlUnaryExpression.Operand,null));

    return Helper__TestNullable(sqlUnaryExpression.Operand);
   }//Negate

   case ExpressionType.Not:
   {
    Debug.Assert(!Object.ReferenceEquals(sqlUnaryExpression.Operand,null));

    return Helper__TestNullable(sqlUnaryExpression.Operand);
   }//Not

   case ExpressionType.Convert:
   {
    Debug.Assert(!Object.ReferenceEquals(sqlUnaryExpression.Operand,null));

    return Helper__TestNullable(sqlUnaryExpression.Operand);
   }//Convert

   default:
   {
    break;
   }//default
  }//switch sqlUnaryExpression.OperatorType

  return Helper__TestNullable__UNKNOWN__return_true(sqlUnaryExpression);
 }//Helper__TestNullable__Unary

 //-----------------------------------------------------------------------
 private static bool Helper__TestNullable__Binary(SqlBinaryExpression sqlBinaryExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlBinaryExpression,null));
  Debug.Assert(!Object.ReferenceEquals(sqlBinaryExpression.Left,null));
  Debug.Assert(!Object.ReferenceEquals(sqlBinaryExpression.Right,null));

  switch(sqlBinaryExpression.OperatorType)
  {
   case ExpressionType.Add:
   case ExpressionType.Subtract:
   case ExpressionType.Multiply:
   case ExpressionType.Divide:
   case ExpressionType.Modulo:
   case ExpressionType.AndAlso:
   case ExpressionType.OrElse:
   case ExpressionType.ExclusiveOr:

   case ExpressionType.LessThan:
   case ExpressionType.LessThanOrEqual:
   case ExpressionType.GreaterThan:
   case ExpressionType.GreaterThanOrEqual:

   //! \todo Need look to setting useRelationalNulls
   case ExpressionType.Equal:
   case ExpressionType.NotEqual:
   {
    if(Helper__TestNullable(sqlBinaryExpression.Left))
     return true;

    if(Helper__TestNullable(sqlBinaryExpression.Right))
     return true;

    return false;
   }//case

   default:
   {
    break;
   }
  }//switch Helper__TestNullable__Binary

  return Helper__TestNullable__UNKNOWN__return_true(sqlBinaryExpression);
 }//Helper__TestNullable__Binary

 //-----------------------------------------------------------------------
 private static bool Helper__TestNullable__Constant(SqlConstantExpression sqlConstantExpression)
 {
  const string c_bugcheck_src
   ="Core_SQL__TestNullable::Helper__TestNullable__Constant";

  if(Object.ReferenceEquals(sqlConstantExpression.Value,null))
   return true;

  if(DBNull.Value.Equals(sqlConstantExpression.Value))
  {
   //[2021-09-18] We are not currently expecting DBNull.Value here.

   ThrowBugCheck.generic_error
    (c_ErrSrcID,
     c_bugcheck_src,
     "#001",
     "DBNull.Value not expected here");
  }//if

  Debug.Assert(!DBNull.Value.Equals(sqlConstantExpression.Value));

  return false;
 }//Helper__TestNullable__Constant

 //-----------------------------------------------------------------------
 private static bool Helper__TestNullable__Parameter(SqlParameterExpression sqlParameterExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlParameterExpression,null));

  return sqlParameterExpression.IsNullable;
 }//Helper__TestNullable__Parameter

 //-----------------------------------------------------------------------
 private static bool Helper__TestNullable__Like(LikeExpression sqlLikeExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlLikeExpression,null));
  Debug.Assert(!Object.ReferenceEquals(sqlLikeExpression.Match,null));
  Debug.Assert(!Object.ReferenceEquals(sqlLikeExpression.Pattern,null));

  if(Helper__TestNullable(sqlLikeExpression.Match))
   return true;

  if(Helper__TestNullable(sqlLikeExpression.Pattern))
   return true;

  if(!Object.ReferenceEquals(sqlLikeExpression.EscapeChar,null))
  {
   if(Helper__TestNullable(sqlLikeExpression.EscapeChar))
    return true;
  }//if

  return false;
 }//Helper__TestNullable__Like

 //-----------------------------------------------------------------------
 private static bool Helper__TestNullable__Case(CaseExpression sqlCaseExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlCaseExpression,null));

  //! \todo [2021-10-14] Not implemented. Need research. Sorry.

  return true;
 }//Helper__TestNullable__Case

 //-----------------------------------------------------------------------
 private static bool Helper__TestNullable__ScalarSubquery(ScalarSubqueryExpression sqlExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlExpression,null));

  Expression
   subquery
    =sqlExpression.Subquery;

  Debug.Assert(!Object.ReferenceEquals(subquery,null));
  Debug.Assert(!(subquery is SqlExpression));

  Debug.Assert(!Object.ReferenceEquals(subquery.Type,null));

  if(!subquery.Type.Extension__IsNullableType())
   return false;

  return true;
 }//Helper__TestNullable__ScalarSubquery

 //-----------------------------------------------------------------------
 private static bool Helper__TestNullable__UNKNOWN__return_true(SqlExpression sqlExpression)
 {
  //Trap for unexpected cases
  Debug.Assert(false);

  return true;
 }//Helper__TestNullable__UNKNOWN__return_true
};//class Core_SQL__TestNullable

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.SQL

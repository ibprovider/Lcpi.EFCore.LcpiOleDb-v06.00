////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 24.12.2020.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.SQL{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

////////////////////////////////////////////////////////////////////////////////
//class Core_SQL__TestExpressionKind

static class Core_SQL__TestExpressionKind
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Core_SQL__TestExpressionKind;

 //-----------------------------------------------------------------------
 public static bool IsStringConcatenation(SqlExpression expression)
 {
  Debug.Assert(!Object.Equals(expression,null));

  if(expression is SqlBinaryExpression binaryExpression)
  {
   if(IsStringConcatenation(binaryExpression))
    return true;

   return false;
  }//if

  return false;
 }//IsStringConcatenation - expression

 //-----------------------------------------------------------------------
 public static bool IsStringConcatenation(SqlBinaryExpression binaryExpression)
 {
  Debug.Assert(!Object.Equals(binaryExpression,null));

  if(binaryExpression.OperatorType!=ExpressionType.Add)
   return false;

  if(!IsStringConcatenation2(binaryExpression))
   return false;

  return true;
 }//Helper__IsStringConcatenation - binaryExpression

 //-----------------------------------------------------------------------
 public static bool IsStringConcatenation2(SqlBinaryExpression binaryExpression)
 {
  Debug.Assert(!Object.Equals(binaryExpression,null));

  Debug.Assert(binaryExpression.OperatorType==ExpressionType.Add);  // <--- !!!!

  //----------------------------------------
  const string c_bugcheck_src
   ="Core_SQL__TestExpressionKind::IsStringConcatenation2";

  //----------------------------------------
  var opSqlType
   =Core_SQL__ExpressionUtils.GetSqlType
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      binaryExpression);

  //----------------------------------------
  if(opSqlType==Structure_TypeCache.TypeOf__System_String)
  {
   return true;
  }//if

  //----------------------------------------
  return false;
 }//IsStringConcatenation2 - binaryExpression

 //-----------------------------------------------------------------------
 public static bool IsLogicalOrElse(SqlExpression expression)
 {
  Debug.Assert(!Object.Equals(expression,null));

  if(expression is SqlBinaryExpression binaryExpression)
  {
   if(IsLogicalOrElse(binaryExpression))
    return true;

   return false;
  }//if

  return false;
 }//IsLogicalOrElse - expression

 //-----------------------------------------------------------------------
 public static bool IsLogicalOrElse(SqlBinaryExpression binaryExpression)
 {
  Debug.Assert(!Object.Equals(binaryExpression,null));

  if(binaryExpression.OperatorType!=ExpressionType.OrElse)
   return false;

  //----------------------------------------
  if(!Helper__ExpressionHasTypeOfLogicalValue(binaryExpression))
   return false;

  //----------------------------------------
  return true;
 }//IsLogicalOrElse - binaryExpression

 //-----------------------------------------------------------------------
 public static bool IsLogicalAndAlso(SqlExpression expression)
 {
  Debug.Assert(!Object.Equals(expression,null));

  if(expression is SqlBinaryExpression binaryExpression)
  {
   if(IsLogicalAndAlso(binaryExpression))
    return true;

   return false;
  }//if

  return false;
 }//IsLogicalAndAlso - expression

 //-----------------------------------------------------------------------
 public static bool IsLogicalAndAlso(SqlBinaryExpression binaryExpression)
 {
  Debug.Assert(!Object.Equals(binaryExpression,null));

  if(binaryExpression.OperatorType!=ExpressionType.AndAlso)
   return false;

  //----------------------------------------
  if(!Helper__ExpressionHasTypeOfLogicalValue(binaryExpression))
   return false;

  //----------------------------------------
  return true;
 }//IsLogicalAndAlso - binaryExpression

 //Helper methods --------------------------------------------------------
 private static bool Helper__ExpressionHasTypeOfLogicalValue(SqlExpression sqlExpression)
 {
  Debug.Assert(!Object.Equals(sqlExpression,null));

  //----------------------------------------
  const string c_bugcheck_src
   ="Core_SQL__TestExpressionKind::Helper__ExpressionHasTypeOfLogicalValue";

  //----------------------------------------
  var opSqlType
   =Core.SQL.Core_SQL__ExpressionUtils.GetSqlType
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      sqlExpression);

  //----------------------------------------
  if(opSqlType==Structure_TypeCache.TypeOf__System_Boolean)
  {
   return true;
  }//if

  //----------------------------------------
  return false;
 }//Helper__ExpressionHasTypeOfLogicalValue
};//class Core_SQL__TestExpressionKind

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.SQL

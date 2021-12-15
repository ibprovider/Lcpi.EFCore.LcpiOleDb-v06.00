////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 13.10.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Sql.Extensions.LcpiOleDb__ISqlTreeNodeBuilder__Extensions{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__ISqlTreeNodeBuilder__Extensions

static class LcpiOleDb__ISqlTreeNodeBuilder__Extensions
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.LcpiOleDb__ISqlTreeNodeBuilder__Extensions;

 //-----------------------------------------------------------------------
 public static SqlExpression Extension__MakeUnary__IsNull__Throw
                        (this LcpiOleDb__ISqlTreeNodeBuilder sqlBuilder,
                         SqlExpression                       value)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(value,null));

  return Helper__MakeUnary__Throw
          (sqlBuilder,
           LcpiOleDb__ExpressionType.Equal,
           value,
           Structure.Structure_TypeCache.TypeOf__System_Boolean);
 }//Extension__MakeUnary__IsNull__Throw

 //-----------------------------------------------------------------------
 public static SqlExpression Extension__MakeUnary__IsNotNull__Throw
                        (this LcpiOleDb__ISqlTreeNodeBuilder sqlBuilder,
                         SqlExpression                       value)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(value,null));

  return Helper__MakeUnary__Throw
          (sqlBuilder,
           LcpiOleDb__ExpressionType.NotEqual,
           value,
           Structure.Structure_TypeCache.TypeOf__System_Boolean);
 }//Extension__MakeUnary__IsNotNull__Throw

 //-----------------------------------------------------------------------
 public static SqlExpression Extension__MakeBinary__Concat__Throw
                        (this LcpiOleDb__ISqlTreeNodeBuilder sqlBuilder,
                         SqlExpression                       left,
                         SqlExpression                       right)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(left,null));
  Debug.Assert(!Object.ReferenceEquals(right,null));

  return Helper__MakeBinary__Throw
          (sqlBuilder,
           LcpiOleDb__ExpressionType.Concat,
           left,
           right);
 }//Extension__MakeBinary__Concat__Throw

 //-----------------------------------------------------------------------
 public static SqlExpression Extension__MakeBinary__Add__Throw
                        (this LcpiOleDb__ISqlTreeNodeBuilder sqlBuilder,
                         SqlExpression                       left,
                         SqlExpression                       right)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(left,null));
  Debug.Assert(!Object.ReferenceEquals(right,null));

  return Helper__MakeBinary__Throw
          (sqlBuilder,
           LcpiOleDb__ExpressionType.Add,
           left,
           right);
 }//Extension__MakeBinary__Add__Throw

 //-----------------------------------------------------------------------
 public static SqlExpression Extension__MakeBinary__Subtract__Throw
                        (this LcpiOleDb__ISqlTreeNodeBuilder sqlBuilder,
                         SqlExpression                       left,
                         SqlExpression                       right)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(left,null));
  Debug.Assert(!Object.ReferenceEquals(right,null));

  return Helper__MakeBinary__Throw
          (sqlBuilder,
           LcpiOleDb__ExpressionType.Subtract,
           left,
           right);
 }//Extension__MakeBinary__Subtract__Throw

 //-----------------------------------------------------------------------
 public static SqlExpression Extension__MakeBinary__Multiply__Throw
                        (this LcpiOleDb__ISqlTreeNodeBuilder sqlBuilder,
                         SqlExpression                       left,
                         SqlExpression                       right)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(left,null));
  Debug.Assert(!Object.ReferenceEquals(right,null));

  return Helper__MakeBinary__Throw
          (sqlBuilder,
           LcpiOleDb__ExpressionType.Multiply,
           left,
           right);
 }//Extension__MakeBinary__Multiply__Throw

 //-----------------------------------------------------------------------
 public static SqlExpression Extension__MakeBinary__Divide__Throw
                        (this LcpiOleDb__ISqlTreeNodeBuilder sqlBuilder,
                         SqlExpression                       left,
                         SqlExpression                       right)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(left,null));
  Debug.Assert(!Object.ReferenceEquals(right,null));

  return Helper__MakeBinary__Throw
          (sqlBuilder,
           LcpiOleDb__ExpressionType.Divide,
           left,
           right);
 }//Extension__MakeBinary__Divide__Throw

 //-----------------------------------------------------------------------
 public static SqlExpression Extension__MakeBinary__Equal__Throw
                        (this LcpiOleDb__ISqlTreeNodeBuilder sqlBuilder,
                         SqlExpression                       left,
                         SqlExpression                       right)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(left,null));
  Debug.Assert(!Object.ReferenceEquals(right,null));

  return Helper__MakeBinary__Throw
          (sqlBuilder,
           LcpiOleDb__ExpressionType.Equal,
           left,
           right);
 }//Extension__MakeBinary__Equal__Throw

 //-----------------------------------------------------------------------
 public static SqlExpression Extension__MakeBinary__NotEqual__Throw
                        (this LcpiOleDb__ISqlTreeNodeBuilder sqlBuilder,
                         SqlExpression                       left,
                         SqlExpression                       right)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(left,null));
  Debug.Assert(!Object.ReferenceEquals(right,null));

  return Helper__MakeBinary__Throw
          (sqlBuilder,
           LcpiOleDb__ExpressionType.NotEqual,
           left,
           right);
 }//Extension__MakeBinary__NotEqual__Throw

 //-----------------------------------------------------------------------
 public static SqlExpression Extension__MakeBinary__LessThan__Throw
                        (this LcpiOleDb__ISqlTreeNodeBuilder sqlBuilder,
                         SqlExpression                       left,
                         SqlExpression                       right)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(left,null));
  Debug.Assert(!Object.ReferenceEquals(right,null));

  return Helper__MakeBinary__Throw
          (sqlBuilder,
           LcpiOleDb__ExpressionType.LessThan,
           left,
           right);
 }//Extension__MakeBinary__LessThan__Throw

 //-----------------------------------------------------------------------
 public static SqlExpression Extension__MakeBinary__LessThanOrEqual__Throw
                        (this LcpiOleDb__ISqlTreeNodeBuilder sqlBuilder,
                         SqlExpression                       left,
                         SqlExpression                       right)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(left,null));
  Debug.Assert(!Object.ReferenceEquals(right,null));

  return Helper__MakeBinary__Throw
          (sqlBuilder,
           LcpiOleDb__ExpressionType.LessThanOrEqual,
           left,
           right);
 }//Extension__MakeBinary__LessThanOrEqual__Throw

 //-----------------------------------------------------------------------
 public static SqlExpression Extension__MakeBinary__GreaterThan__Throw
                        (this LcpiOleDb__ISqlTreeNodeBuilder sqlBuilder,
                         SqlExpression                       left,
                         SqlExpression                       right)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(left,null));
  Debug.Assert(!Object.ReferenceEquals(right,null));

  return Helper__MakeBinary__Throw
          (sqlBuilder,
           LcpiOleDb__ExpressionType.GreaterThan,
           left,
           right);
 }//Extension__MakeBinary__GreaterThan__Throw

 //-----------------------------------------------------------------------
 public static SqlExpression Extension__MakeBinary__GreaterThanOrEqual__Throw
                        (this LcpiOleDb__ISqlTreeNodeBuilder sqlBuilder,
                         SqlExpression                       left,
                         SqlExpression                       right)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(left,null));
  Debug.Assert(!Object.ReferenceEquals(right,null));

  return Helper__MakeBinary__Throw
          (sqlBuilder,
           LcpiOleDb__ExpressionType.GreaterThanOrEqual,
           left,
           right);
 }//Extension__MakeBinary__GreaterThanOrEqual__Throw

 //-----------------------------------------------------------------------
 public static SqlExpression Extension__MakeBinary__AndAlso__Throw
                        (this LcpiOleDb__ISqlTreeNodeBuilder sqlBuilder,
                         SqlExpression                       left,
                         SqlExpression                       right)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(left,null));
  Debug.Assert(!Object.ReferenceEquals(right,null));

  return Helper__MakeBinary__Throw
          (sqlBuilder,
           LcpiOleDb__ExpressionType.AndAlso,
           left,
           right);
 }//Extension__MakeBinary__AndAlso__Throw

 //-----------------------------------------------------------------------
 public static SqlExpression Extension__MakeBinary__OrElse__Throw
                        (this LcpiOleDb__ISqlTreeNodeBuilder sqlBuilder,
                         SqlExpression                       left,
                         SqlExpression                       right)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(left,null));
  Debug.Assert(!Object.ReferenceEquals(right,null));

  return Helper__MakeBinary__Throw
          (sqlBuilder,
           LcpiOleDb__ExpressionType.OrElse,
           left,
           right);
 }//Extension__MakeBinary__OrElse__Throw

 //-----------------------------------------------------------------------
 public static SqlExpression Extension__MakeBinary__Coalesce__Throw
                        (this LcpiOleDb__ISqlTreeNodeBuilder sqlBuilder,
                         SqlExpression                       left,
                         SqlExpression                       right)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(left,null));
  Debug.Assert(!Object.ReferenceEquals(right,null));

  return Helper__MakeBinary__Throw
          (sqlBuilder,
           LcpiOleDb__ExpressionType.Coalesce,
           left,
           right);
 }//Extension__MakeBinary__Coalesce__Throw

 //-----------------------------------------------------------------------
 public static SqlExpression Extension__MakeBinary__And__Throw
                        (this LcpiOleDb__ISqlTreeNodeBuilder sqlBuilder,
                         SqlExpression                       left,
                         SqlExpression                       right)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(left,null));
  Debug.Assert(!Object.ReferenceEquals(right,null));

  return Helper__MakeBinary__Throw
          (sqlBuilder,
           LcpiOleDb__ExpressionType.And,
           left,
           right);
 }//Extension__MakeBinary__And__Throw

 //-----------------------------------------------------------------------
 public static SqlExpression Extension__MakeBinary__Or__Throw
                        (this LcpiOleDb__ISqlTreeNodeBuilder sqlBuilder,
                         SqlExpression                       left,
                         SqlExpression                       right)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(left,null));
  Debug.Assert(!Object.ReferenceEquals(right,null));

  return Helper__MakeBinary__Throw
          (sqlBuilder,
           LcpiOleDb__ExpressionType.Or,
           left,
           right);
 }//Extension__MakeBinary__Or__Throw

 //Helper interface ------------------------------------------------------
 private static SqlExpression Helper__MakeUnary__Throw
                        (LcpiOleDb__ISqlTreeNodeBuilder sqlBuilder,
                         LcpiOleDb__ExpressionType      operationID,
                         SqlExpression                  operand,
                         System.Type                    type)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(operand,null));
  Debug.Assert(!Object.ReferenceEquals(type,null));

  var r
   =sqlBuilder.MakeUnary
     (operationID,
      operand,
      type); //throw

  if(Object.ReferenceEquals(r,null))
  {
   ThrowError.SqlTranslatorErr__UnsupportedUnaryOperatorType
    (c_ErrSrcID,
     operationID,
     operand.Type,
     type);
  }//if

  Debug.Assert(!Object.ReferenceEquals(r,null));

  return r;
 }//Helper__MakeUnary__Throw

 //-----------------------------------------------------------------------
 private static SqlExpression Helper__MakeBinary__Throw
                        (LcpiOleDb__ISqlTreeNodeBuilder sqlBuilder,
                         LcpiOleDb__ExpressionType      operationID,
                         SqlExpression                  left,
                         SqlExpression                  right)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(left,null));
  Debug.Assert(!Object.ReferenceEquals(right,null));

  var r
   =sqlBuilder.MakeBinary
     (operationID,
      left,
      right); //throw

  if(Object.ReferenceEquals(r,null))
  {
   ThrowError.SqlTranslatorErr__UnsupportedBinaryOperatorType
    (c_ErrSrcID,
     operationID,
     left.Type,
     right.Type);
  }//if

  Debug.Assert(!Object.ReferenceEquals(r,null));

  return r;
 }//Helper__MakeBinary__Throw
};//class LcpiOleDb__ISqlTreeNodeBuilder__Extensions

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Sql.Extensions.LcpiOleDb__ISqlTreeNodeBuilder__Extensions

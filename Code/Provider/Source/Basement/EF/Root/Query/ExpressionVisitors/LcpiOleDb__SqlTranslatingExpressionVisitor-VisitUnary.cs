////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 02.10.2021.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.ExpressionVisitors{
////////////////////////////////////////////////////////////////////////////////
//Using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__SqlTranslatingExpressionVisitor

sealed partial class LcpiOleDb__SqlTranslatingExpressionVisitor
{
 protected override Expression VisitUnary(UnaryExpression unaryExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(unaryExpression,null));

  //
  // [IMPORTANT!]
  //
  // Remove ALL unrequired conversions.
  //
  //  - (int)shortValue -> shortValue
  //
  //  - (object)anyValue -> anyValue
  //

  if(Helper__CanRemoveConvert(unaryExpression))
  {
   Debug.Assert(!Object.ReferenceEquals(unaryExpression.Operand,null));

   return this.Visit(unaryExpression.Operand);
  }//if

  var translatedOperand
   =this.Visit
     (unaryExpression.Operand);

  if(!Object.ReferenceEquals(translatedOperand,null))
  {
   Debug.Assert(!Object.ReferenceEquals(Structure_TypeCache.TypeOf__MS_EFCore_Query__RelationalSqlTranslatingExpressionVisitor___EntityReferenceExpression,null));

   if(translatedOperand.GetType().Equals(Structure_TypeCache.TypeOf__MS_EFCore_Query__RelationalSqlTranslatingExpressionVisitor___EntityReferenceExpression))
   {
    //if(unaryExpression.NodeType == ExpressionType.Convert        ||
    //   unaryExpression.NodeType == ExpressionType.ConvertChecked ||
    //   unaryExpression.NodeType == ExpressionType.TypeAs)

    if(unaryExpression.Extension__IsConvert2())
    {
     return Helper__EFCore__EntityReferenceExpression__Convert
      (translatedOperand,
       unaryExpression.Type);
    }//if

    Debug.Assert(unaryExpression.NodeType != ExpressionType.Convert);
    Debug.Assert(unaryExpression.NodeType != ExpressionType.ConvertChecked);
    Debug.Assert(unaryExpression.NodeType != ExpressionType.TypeAs);

    return QueryCompilationContext.NotTranslatedExpression;
   }//if is EntityReferenceExpression
  }//if

  if(Helper__EFCore__TranslationFailed(unaryExpression.Operand,translatedOperand,out var sqlOperand))
  {
   return QueryCompilationContext.NotTranslatedExpression;
  }//if

  var r1_e
   =Helper__Translate__Unary
    (unaryExpression.NodeType,
     unaryExpression.Type,
     sqlOperand);

  if(Helper__EFCore__TranslationFailed(unaryExpression,r1_e,out var r1))
  {
   return QueryCompilationContext.NotTranslatedExpression;
  }//if

  Debug.Assert(!Object.ReferenceEquals(r1,null));

  var r2
   =this.Dependencies.SqlExpressionFactory.ApplyDefaultTypeMapping
     (r1);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlType(r2);
#endif

  return r2;
 }//VisitUnary

 //Helper methods --------------------------------------------------------
 private Expression Helper__Translate__Unary(ExpressionType operationID,
                                             System.Type    clrResultType,
                                             SqlExpression  sqlOperand)
 {
  Debug.Assert(!Object.ReferenceEquals(clrResultType,null));
  Debug.Assert(!Object.ReferenceEquals(sqlOperand,null));
  Debug.Assert(!Object.ReferenceEquals(sqlOperand.Type,null));

  //
  // [2021-10-02]
  //  Constructor of SqlExpression does not allow usage a Type, that based on Nullable<>.
  //
  Debug.Assert(!sqlOperand.Type.Extension__IsNullableValueType());
  //
  // As result
  //
  Debug.Assert(sqlOperand.Type==sqlOperand.Type.Extension__UnwrapNullableType());

  switch(operationID)
  {
   //
   // [2021-10-08] Go to m_SqlTreeNodeBuilder.MakeUnary
   //
   // case ExpressionType.Not:
   // {
   //  return this.Dependencies.SqlExpressionFactory.Not(sqlOperand);
   // }//Not ...

   //
   // [2021-10-11] Go to m_SqlTreeNodeBuilder.MakeUnary
   //
   // case ExpressionType.Negate:
   // case ExpressionType.NegateChecked:
   // {
   //  return this.Dependencies.SqlExpressionFactory.Negate(sqlOperand);
   // }//case Negate ...

   case ExpressionType.Quote:
   {
    return sqlOperand;
   }//case Quote

   default:
   {
    break;
   }//default
  }//switch

  //
  // Map external ID of binary operation to internal ID
  //

  LcpiOleDb__ExpressionType operationID2;

  if(!Core.Core_MapSysETypeToLcpiOleDbEType.TryMap
       (operationID,
        out operationID2))
  {
   // [2020-12-28] Throw error instead return NotTranslatedExpression.

   ThrowError.SqlTranslatorErr__UnsupportedUnaryOperatorType
    (c_ErrSrcID,
     operationID);
  }//if

  Debug.Assert(!Object.ReferenceEquals(m_SqlTreeNodeBuilder,null));

  var r
   =m_SqlTreeNodeBuilder.MakeUnary
     (operationID2,
      sqlOperand,
      clrResultType); //throw

  if(Object.ReferenceEquals(r,null))
  {
   // [2021-10-11] Throw error instead return NotTranslatedExpression.

   ThrowError.SqlTranslatorErr__UnsupportedUnaryOperatorType
    (c_ErrSrcID,
     operationID2,
     sqlOperand.Type,
     clrResultType);
  }//if

  Debug.Assert(!Object.ReferenceEquals(r,null));
  Debug.Assert(!Object.ReferenceEquals(r.Type,null));
  Debug.Assert(!Object.ReferenceEquals(r.TypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(r.TypeMapping.ClrType,null));

  return r;
 }//Helper__Translate__Unary

 //-----------------------------------------------------------------------
 private static bool Helper__CanRemoveConvert(UnaryExpression unaryExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(unaryExpression,null));

  if(!unaryExpression.Extension__IsConvert2())
   return false;

  Debug.Assert(!Object.ReferenceEquals(unaryExpression.Type,null));
  Debug.Assert(!Object.ReferenceEquals(unaryExpression.Operand,null));
  Debug.Assert(!Object.ReferenceEquals(unaryExpression.Operand.Type,null));

  if(unaryExpression.Type==Structure.Structure_TypeCache.TypeOf__System_Object)
  {
   //Remove convert to object

   return true;
  }//if

  var innerType=unaryExpression.Operand.Type.Extension__GetUnderlyingValueType();

  var convertedType=unaryExpression.Type.Extension__GetUnderlyingValueType();

  if(innerType==convertedType)
  {
   return true;
  }//if

  if(convertedType==Structure_TypeCache.TypeOf__System_Int32)
  {
   if(innerType==Structure_TypeCache.TypeOf__System_Byte   ||
      innerType==Structure_TypeCache.TypeOf__System_SByte  ||
      innerType==Structure_TypeCache.TypeOf__System_Char   ||
      innerType==Structure_TypeCache.TypeOf__System_Int16  ||
      innerType==Structure_TypeCache.TypeOf__System_UInt16)
   {
    return true;
   }//if
  }
  else
  if(convertedType==Structure_TypeCache.TypeOf__System_Int64)
  {
   //LcpiOleDb provider specific.

   if(innerType==Structure_TypeCache.TypeOf__System_Byte   ||
      innerType==Structure_TypeCache.TypeOf__System_SByte  ||
      innerType==Structure_TypeCache.TypeOf__System_Char   ||
      innerType==Structure_TypeCache.TypeOf__System_Int16  ||
      innerType==Structure_TypeCache.TypeOf__System_UInt16 ||
      innerType==Structure_TypeCache.TypeOf__System_Int32  ||
      innerType==Structure_TypeCache.TypeOf__System_UInt32)
   {
    return true;
   }//if
  }//if

  //
  // [2020-12-06] Save conversion to decimal:
  //
  // 7 / (decimal)2 == 3.5m
  // 7 / 2 == 3
  //

  return false;
 }//Helper__CanRemoveConvert
};//class LcpiOleDb__SqlTranslatingExpressionVisitor

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.ExpressionVisitors
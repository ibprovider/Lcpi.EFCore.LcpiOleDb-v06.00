////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 05.12.2021.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore.Query;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.ExpressionVisitors{
////////////////////////////////////////////////////////////////////////////////
//Using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__SqlTranslatingExpressionVisitor

sealed partial class LcpiOleDb__SqlTranslatingExpressionVisitor
{
 protected override Expression VisitBinary(BinaryExpression binaryExpression)
 {
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(VisitBinary),
    nameof(binaryExpression),
    binaryExpression);

  //--------------------------------------------------
  {
   if(Helper__TryRewrite_Op2(binaryExpression,
                             out var rewritedExpression))
   {
    Debug.Assert(!Object.ReferenceEquals(rewritedExpression,null));

    return this.Visit(rewritedExpression);
   }//if
  }//local

  //--------------------------------------------------
  Debug.Assert(!Object.ReferenceEquals(binaryExpression.Left,null));
  Debug.Assert(!Object.ReferenceEquals(binaryExpression.Right,null));

  var left  = binaryExpression.Left;
  var right = binaryExpression.Right;

  Debug.Assert(!Object.ReferenceEquals(left,null));
  Debug.Assert(!Object.ReferenceEquals(right,null));

  var visitedLeft  = this.Visit(left);
  var visitedRight = this.Visit(right);

  if(binaryExpression.NodeType == ExpressionType.Equal ||
     binaryExpression.NodeType == ExpressionType.NotEqual)
  {
   // Visited expression could be null, We need to pass MemberInitExpression

   if(Helper__EFCore__TryRewriteEntityEquality
       (binaryExpression.NodeType,
        visitedLeft  == QueryCompilationContext.NotTranslatedExpression ? left  : visitedLeft,
        visitedRight == QueryCompilationContext.NotTranslatedExpression ? right : visitedRight,
        equalsMethod: false,
        out var result))
   {
    return result;
   }//if
  }//if

  if(Helper__EFCore__TranslationFailed(binaryExpression.Left,visitedLeft,out var sqlLeft))
   return QueryCompilationContext.NotTranslatedExpression;

  if(Helper__EFCore__TranslationFailed(binaryExpression.Right,visitedRight,out var sqlRight))
   return QueryCompilationContext.NotTranslatedExpression;

  ExpressionType
   uncheckedNodeTypeVariant
    =Helper__EFCore__GetUncheckedNodeTypeVariant(binaryExpression.NodeType);

  Debug.Assert(!Object.ReferenceEquals(this.Dependencies,null));
  Debug.Assert(!Object.ReferenceEquals(this.Dependencies.SqlExpressionFactory,null));

  Debug.Assert(!Object.ReferenceEquals(m_SqlTreeNodeBuilder,null));

  //
  // Map external ID of binary operation to internal ID
  //

  LcpiOleDb__ExpressionType uncheckedNodeTypeVariant2;

  if(!Core.Core_MapSysETypeToLcpiOleDbEType.TryMap
       (uncheckedNodeTypeVariant,
        out uncheckedNodeTypeVariant2))
  {
   // [2020-12-28] Throw error instead return NotTranslatedExpression.

   ThrowError.SqlTranslatorErr__UnsupportedBinaryOperatorType
    (c_ErrSrcID,
     binaryExpression.NodeType);
  }//if

  //
  // [2020-12-23]
  //
  // Note that, we are ignore binaryExpression.Type.
  //
  // Target expression may has another (compatible) type.
  //
  // It is expected that this type will be the same as the DBMS can assign.
  //
  // If you want, you may check type of result expression and
  // generate error, if you find that result is strange :)
  //

  var r
   =m_SqlTreeNodeBuilder.MakeBinary
     (uncheckedNodeTypeVariant2,
      sqlLeft,
      sqlRight); //throw

  if(Object.ReferenceEquals(r,null))
  {
   //! \todo Log reason?

   return QueryCompilationContext.NotTranslatedExpression;
  }//if

#if DEBUG
  Debug.Assert(!Object.ReferenceEquals(r,null));
  Debug.Assert(!Object.ReferenceEquals(r.Type,null));
  Debug.Assert(!Object.ReferenceEquals(r.TypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(r.TypeMapping.ClrType,null));

  // Check stable types ...

  Debug.Assert
   ((binaryExpression.Type.Extension__UnwrapNullableType()==Structure_TypeCache.TypeOf__System_Boolean)==
    (r.Type==Structure_TypeCache.TypeOf__System_Boolean));

  Debug.Assert
   ((binaryExpression.Type.Extension__UnwrapNullableType()==Structure_TypeCache.TypeOf__System_DateTime)==
    (r.Type==Structure_TypeCache.TypeOf__System_DateTime));

  Debug.Assert
   ((binaryExpression.Type.Extension__UnwrapNullableType()==Structure_TypeCache.TypeOf__System_TimeSpan)==
    (r.Type==Structure_TypeCache.TypeOf__System_TimeSpan));
#endif

  return r;
 }//VisitBinary
};//class LcpiOleDb__SqlTranslatingExpressionVisitor

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.ExpressionVisitors

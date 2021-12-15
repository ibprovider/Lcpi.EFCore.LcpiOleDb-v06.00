////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 03.12.2021.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.ExpressionVisitors{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__SqlTranslatingExpressionVisitor

sealed partial class LcpiOleDb__SqlTranslatingExpressionVisitor
{
 private static bool Helper__TryRewrite_Op2_NotEqual
                                           (Expression     left,
                                            Expression     right,
                                            out Expression rewritedExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(left,null));
  Debug.Assert(!Object.ReferenceEquals(right,null));

  //--------------------------------------------------
  {
   //
   // Source:
   //  NewArrayExpression != {NewArrayExpression | constantArray}
   //
   // Result:
   //  !object.Equals(left[0],right[0]) or !object.Equals(left[1],right[1]) or  ...
   //
   // Restrictions:
   //  Equal length of left and right collection.
   //

   if(left is NewArrayExpression left_t)
   {
    Debug.Assert(!Object.ReferenceEquals(left_t.Expressions,null));

    var leftExpressions
     =Helper__RewriteBuilder__ConvertExpressionIntoCollectionOfObjects
       (left_t);

    Debug.Assert(!Object.ReferenceEquals(leftExpressions,null));

    if(!Helper__RewriteBuilder__TryConvertExpressionIntoCollectionOfObjects
         (right,
          out var rightExpressions))
    {
     return Helper__SET_NULL_AND_RETURN_FALSE(out rewritedExpression);
    }//if

    Debug.Assert(!Object.ReferenceEquals(rightExpressions,null));

    if(leftExpressions.Count!=rightExpressions.Count)
    {
     return Helper__SET_NULL_AND_RETURN_FALSE(out rewritedExpression);
    }//if

    return Helper__RewriteBuilder__TryBuildNotEqualComparisonOfObjectCollections
     (leftExpressions,
      rightExpressions,
      out rewritedExpression);
   }//if - left is NewArrayExpression
  }//local

  //--------------------------------------------------
  {
   //
   // Source:
   //  {NewArrayExpression | constantArray} != NewArrayExpression
   //
   // Result:
   //  !object.Equals(left[0],right[0]) or !object.Equals(left[1],right[1]) or  ...
   //
   // Restrictions:
   //  Equal length of left and right collection.
   //

   if(right is NewArrayExpression right_t)
   {
    Debug.Assert(!Object.ReferenceEquals(right_t.Expressions,null));

    if(!Helper__RewriteBuilder__TryConvertExpressionIntoCollectionOfObjects
         (left,
          out var leftExpressions))
    {
     return Helper__SET_NULL_AND_RETURN_FALSE(out rewritedExpression);
    }//if

    Debug.Assert(!Object.ReferenceEquals(leftExpressions,null));

    var rightExpressions
     =Helper__RewriteBuilder__ConvertExpressionIntoCollectionOfObjects
       (right_t);

    Debug.Assert(!Object.ReferenceEquals(rightExpressions,null));

    return Helper__RewriteBuilder__TryBuildNotEqualComparisonOfObjectCollections
     (leftExpressions,
      rightExpressions,
      out rewritedExpression);
   }//if - left is NewArrayExpression
  }//local

  //--------------------------------------------------
  return Helper__SET_NULL_AND_RETURN_FALSE(out rewritedExpression);
 }//Helper__TryRewrite_Op2_NotEqual
};//class LcpiOleDb__SqlTranslatingExpressionVisitor

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.ExpressionVisitors

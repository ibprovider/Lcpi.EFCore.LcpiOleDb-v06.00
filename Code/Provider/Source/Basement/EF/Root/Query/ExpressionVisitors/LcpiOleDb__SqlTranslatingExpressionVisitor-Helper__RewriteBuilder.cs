////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 02.12.2021.
using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.ExpressionVisitors{
////////////////////////////////////////////////////////////////////////////////

using Structure_TypeCache
 =Structure.Structure_TypeCache;

using Structure_MethodInfoCache
 =Structure.Structure_MethodInfoCache;

////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__SqlTranslatingExpressionVisitor

sealed partial class LcpiOleDb__SqlTranslatingExpressionVisitor
{
 private static bool Helper__RewriteBuilder__TryConvertExpressionIntoCollectionOfObjects
                                           (Expression                          expression,
                                            out IReadOnlyCollection<Expression> collectionOfObjects)
 {
  Debug.Assert(!Object.ReferenceEquals(expression,null));

  collectionOfObjects=null;

  if(expression is NewArrayExpression newArrayExpression)
  {
   Debug.Assert(!Object.ReferenceEquals(newArrayExpression.Expressions,null));

   collectionOfObjects
    =Helper__RewriteBuilder__ConvertExpressionIntoCollectionOfObjects
      (newArrayExpression);

   return true;
  }//if - NewArrayExpression

  if(expression is ConstantExpression constantExpression)
  {
   var result
    =Helper__RewriteBuilder__TryConvertValueIntoArrayOfObjects
      (constantExpression.Value,
       out var arrayOfObjects);

   collectionOfObjects=arrayOfObjects;

   return result;
  }//if - ConstantExpression

  return false;
 }//Helper__RewriteBuilder__TryConvertExpressionIntoCollectionOfObjects

 //-----------------------------------------------------------------------
 private static IReadOnlyCollection<Expression>
                             Helper__RewriteBuilder__ConvertExpressionIntoCollectionOfObjects
                                           (NewArrayExpression expression)
 {
  Debug.Assert(!Object.ReferenceEquals(expression,null));
  Debug.Assert(!Object.ReferenceEquals(expression.Expressions,null));

  if(expression.Type==Structure_TypeCache.TypeOf__System_Array_Object)
  {
   return expression.Expressions;
  }//if

  Debug.Assert(expression.Type!=Structure_TypeCache.TypeOf__System_Array_Object);

  var cElements
   =expression.Expressions.Count;

  var rebuildedCollection
   =new Expression[cElements];

  int i=0;

  foreach(var x in expression.Expressions)
  {
   Debug.Assert(!Object.ReferenceEquals(x,null));
   Debug.Assert(!Object.ReferenceEquals(x.Type,null));
   Debug.Assert(x.Type!=Structure_TypeCache.TypeOf__System_Object);

   rebuildedCollection[i]
    =Expression.Convert
      (x,
       Structure_TypeCache.TypeOf__System_Object);

   Debug.Assert(!Object.ReferenceEquals(rebuildedCollection[i],null));
   Debug.Assert(!Object.ReferenceEquals(rebuildedCollection[i].Type,null));

   Debug.Assert(rebuildedCollection[i].Type==Structure_TypeCache.TypeOf__System_Object);

   ++i;
  }//foreach x

  return rebuildedCollection;
 }//Helper__RewriteBuilder__TryConvertExpressionIntoCollectionOfObjects

 //-----------------------------------------------------------------------
 private static bool Helper__RewriteBuilder__TryConvertValueIntoArrayOfObjects
                                           (object           value,
                                            out Expression[] arrayOfObjects)
 {
  arrayOfObjects=null;

  if(Object.ReferenceEquals(value,null))
   return false;

  var valueType
   =value.GetType();

  if(!valueType.IsArray)
   return false;

  var valueAsArray
   =(System.Array)value;

  if(valueAsArray.Rank!=1)
   return false;

  if(valueAsArray.GetLowerBound(0)!=0)
   return false;

  var cElements
   =valueAsArray.Length;

  var expressions
   =new Expression[valueAsArray.Length];

  for(int i=0;i!=cElements;++i)
  {
   var elementValue
    =valueAsArray.GetValue(i);

   Expression
    elementExpression
     =Expression.Constant
       (elementValue);

   Debug.Assert(!Object.ReferenceEquals(elementExpression,null));
   Debug.Assert(!Object.ReferenceEquals(elementExpression.Type,null));

   if(elementExpression.Type!=Structure_TypeCache.TypeOf__System_Object)
   {
    elementExpression
     =Expression.Convert
       (elementExpression,
        Structure.Structure_TypeCache.TypeOf__System_Object);

    Debug.Assert(!Object.ReferenceEquals(elementExpression,null));
    Debug.Assert(!Object.ReferenceEquals(elementExpression.Type,null));

    Debug.Assert(elementExpression.Type==Structure_TypeCache.TypeOf__System_Object);
   }//if

   Debug.Assert(!Object.ReferenceEquals(elementExpression,null));
   Debug.Assert(!Object.ReferenceEquals(elementExpression.Type,null));
   Debug.Assert(elementExpression.Type==Structure_TypeCache.TypeOf__System_Object);

   expressions[i]
    =elementExpression;

   Debug.Assert(!Object.ReferenceEquals(expressions[i],null));
  }//for i

  arrayOfObjects
   =expressions;

  return true;
 }//Helper__RewriteBuilder__TryConvertValueIntoArrayOfObjects

 //-----------------------------------------------------------------------
 private static bool Helper__RewriteBuilder__TryBuildEqualComparisonOfObjectCollections
                                           (IReadOnlyCollection<Expression> leftExpressions,
                                            IReadOnlyCollection<Expression> rightExpressions,
                                            out Expression                  resultExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(leftExpressions,null));
  Debug.Assert(!Object.ReferenceEquals(rightExpressions,null));

  if(leftExpressions.Count!=rightExpressions.Count)
  {
   //! \todo May be need write warning about this into log?

#if TRACE
   Core.Core_Trace.Send
    ("Helper__RewriteBuilder__TryBuildEqualComparisonOfObjectCollections. "
    +"Left collection has {0} element(s). "
    +"Right collection has {1} element(s).",
    leftExpressions.Count,
    rightExpressions.Count);
#endif

   return Helper__SET_NULL_AND_RETURN_FALSE(out resultExpression);
  }//if

  Debug.Assert(leftExpressions.Count==rightExpressions.Count);

  if(leftExpressions.Count==0)
  {
   //[2021-12-03] Protection.

   resultExpression
    =Expression.Constant(true);

   Debug.Assert(!Object.ReferenceEquals(resultExpression,null));

   return true;
  }//if leftExpressions.Count==0

  Debug.Assert(leftExpressions.Count>0);
  Debug.Assert(leftExpressions.Count==rightExpressions.Count);

  //
  // Result expression:
  //
  //  objects.Equals(a[0],b[0]) AND objects.Equals(a[1],b[1]) AND ...
  //

  var r1_Zip
   =leftExpressions.Zip
     (rightExpressions,
      (a, b) =>
       {
        Debug.Assert(!Object.ReferenceEquals(a,null));
        Debug.Assert(!Object.ReferenceEquals(b,null));

        Debug.Assert(a.Type==Structure_TypeCache.TypeOf__System_Object);
        Debug.Assert(b.Type==Structure_TypeCache.TypeOf__System_Object);

        Expression
         result
          =Expression.Call
            (Structure_MethodInfoCache.MethodInfoOf__Object__std__Equals__object_object,
             a,
             b);

        Debug.Assert(!Object.ReferenceEquals(result,null));
        Debug.Assert(!Object.ReferenceEquals(result.Type,null));

        Debug.Assert(result.Type==Structure_TypeCache.TypeOf__System_Boolean);

        return result;
       });

  Debug.Assert(!Object.ReferenceEquals(r1_Zip,null));

  resultExpression
   =r1_Zip.Aggregate
     ((a, b) =>
      {
       Debug.Assert(!Object.ReferenceEquals(a,null));
       Debug.Assert(!Object.ReferenceEquals(b,null));

       Debug.Assert(a.Type==Structure_TypeCache.TypeOf__System_Boolean);
       Debug.Assert(b.Type==Structure_TypeCache.TypeOf__System_Boolean);

       Expression
        result
         =Expression.AndAlso
           (a,
            b);

       Debug.Assert(!Object.ReferenceEquals(result,null));
       Debug.Assert(!Object.ReferenceEquals(result.Type,null));

       Debug.Assert(result.Type==Structure_TypeCache.TypeOf__System_Boolean);

       return result;
      });

  Debug.Assert(!Object.ReferenceEquals(resultExpression,null));

  return true;
 }//Helper__RewriteBuilder__TryBuildEqualComparisonOfObjectCollections

 //-----------------------------------------------------------------------
 private static bool Helper__RewriteBuilder__TryBuildNotEqualComparisonOfObjectCollections
                                           (IReadOnlyCollection<Expression> leftExpressions,
                                            IReadOnlyCollection<Expression> rightExpressions,
                                            out Expression                  resultExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(leftExpressions,null));
  Debug.Assert(!Object.ReferenceEquals(rightExpressions,null));

  if(leftExpressions.Count!=rightExpressions.Count)
  {
   //! \todo May be need write warning about this into log?

#if TRACE
   Core.Core_Trace.Send
    ("Helper__RewriteBuilder__TryBuildNotEqualComparisonOfObjectCollections. "
    +"Left collection has {0} element(s). "
    +"Right collection has {1} element(s).",
    leftExpressions.Count,
    rightExpressions.Count);
#endif

   return Helper__SET_NULL_AND_RETURN_FALSE(out resultExpression);
  }//if

  Debug.Assert(leftExpressions.Count==rightExpressions.Count);

  if(leftExpressions.Count==0)
  {
   //[2021-12-03] Protection.

   resultExpression
    =Expression.Constant(true);

   Debug.Assert(!Object.ReferenceEquals(resultExpression,null));

   return true;
  }//if leftExpressions.Count==0

  Debug.Assert(leftExpressions.Count>0);
  Debug.Assert(leftExpressions.Count==rightExpressions.Count);

  //
  // Result expression:
  //
  //  !objects.Equals(a[0],b[0]) OR !objects.Equals(a[1],b[1]) OR ...
  //

  var r1_Zip
   =leftExpressions.Zip
     (rightExpressions,
      (a, b) =>
       {
        Debug.Assert(!Object.ReferenceEquals(a,null));
        Debug.Assert(!Object.ReferenceEquals(b,null));

        Debug.Assert(a.Type==Structure_TypeCache.TypeOf__System_Object);
        Debug.Assert(b.Type==Structure_TypeCache.TypeOf__System_Object);

        Expression
         e1
          =Expression.Call
            (Structure_MethodInfoCache.MethodInfoOf__Object__std__Equals__object_object,
             a,
             b);

        Debug.Assert(!Object.ReferenceEquals(e1,null));

        Expression
         result
          =Expression.Not
            (e1);

        Debug.Assert(!Object.ReferenceEquals(result,null));
        Debug.Assert(!Object.ReferenceEquals(result.Type,null));

        Debug.Assert(result.Type==Structure_TypeCache.TypeOf__System_Boolean);

        return result;
       });

  Debug.Assert(!Object.ReferenceEquals(r1_Zip,null));

  resultExpression
   =r1_Zip.Aggregate
     ((a, b) =>
      {
       Debug.Assert(!Object.ReferenceEquals(a,null));
       Debug.Assert(!Object.ReferenceEquals(b,null));

       Debug.Assert(a.Type==Structure_TypeCache.TypeOf__System_Boolean);
       Debug.Assert(b.Type==Structure_TypeCache.TypeOf__System_Boolean);

       Expression
        result
         =Expression.OrElse
           (a,
            b);

       Debug.Assert(!Object.ReferenceEquals(result,null));
       Debug.Assert(!Object.ReferenceEquals(result.Type,null));

       Debug.Assert(result.Type==Structure_TypeCache.TypeOf__System_Boolean);

       return result;
      });

  Debug.Assert(!Object.ReferenceEquals(resultExpression,null));

  return true;
 }//Helper__RewriteBuilder__TryBuildNotEqualComparisonOfObjectCollections
};//class LcpiOleDb__SqlTranslatingExpressionVisitor

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.ExpressionVisitors

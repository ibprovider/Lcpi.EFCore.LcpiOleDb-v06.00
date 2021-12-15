////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 02.12.2021.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.ExpressionVisitors{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__SqlTranslatingExpressionVisitor

sealed partial class LcpiOleDb__SqlTranslatingExpressionVisitor
{
 private static bool Helper__TryRewrite_Op2
                                           (BinaryExpression binaryExpression,
                                            out Expression   rewritedExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(binaryExpression,null));
  Debug.Assert(!Object.ReferenceEquals(binaryExpression.Left,null));
  Debug.Assert(!Object.ReferenceEquals(binaryExpression.Right,null));

  if(binaryExpression.NodeType==ExpressionType.Equal)
  {
   return Helper__TryRewrite_Op2_Equal
    (binaryExpression.Left,
     binaryExpression.Right,
     out rewritedExpression);
  }//if Equal

  if(binaryExpression.NodeType==ExpressionType.NotEqual)
  {
   return Helper__TryRewrite_Op2_NotEqual
    (binaryExpression.Left,
     binaryExpression.Right,
     out rewritedExpression);
  }//if NotEqual

  return Helper__SET_NULL_AND_RETURN_FALSE(out rewritedExpression);
 }//Helper__TryRewrite_Op2
};//class LcpiOleDb__SqlTranslatingExpressionVisitor

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.ExpressionVisitors

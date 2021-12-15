////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 12.06.2021.
using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Svcs{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__LocalSvc__PrepareForLocalEvaluation

sealed partial class LcpiOleDb__LocalSvc__PrepareForLocalEvaluation
{
 protected override Expression VisitNewArray(NewArrayExpression node)
 {
  Debug.Assert(!Object.ReferenceEquals(node,null));
  Debug.Assert(!Object.ReferenceEquals(node.Expressions,null));
  Debug.Assert(node.Type.IsArray);

  //-------------------------------------------------------
  const string c_bugcheck_src
   ="LcpiOleDb__LocalSvc__PrepareForLocalEvaluation::VisitNewArray";

  //-------------------------------------------------------
  var newArgs__raw
   =this.Visit(node.Expressions);

  Debug.Assert(!Object.ReferenceEquals(newArgs__raw,null));

  var elementType
   =node.Type.GetElementType();

  Debug.Assert(!Object.ReferenceEquals(elementType,null));

  var elementType_u
   =elementType.Extension__SwitchToUnderlying();

  //-------------------------------------------------------
  NewArrayExpression resultExpr
    =null;

  switch(node.NodeType)
  {
   case ExpressionType.NewArrayInit:
   {
    //
    // [2021-12-03]
    //
    //  Adjusting of newArgs__raw to elementType_u
    //

    var newArgs
     =Helper__AdjustExpressionTypes
       (newArgs__raw,
        elementType_u);

    Debug.Assert(!Object.ReferenceEquals(newArgs,null));

    resultExpr
     =Expression.NewArrayInit
       (elementType_u,
        newArgs); //throw

    Debug.Assert(!Object.ReferenceEquals(resultExpr,null));

    break;
   }//case NewArrayInit

   case ExpressionType.NewArrayBounds:
   {
    resultExpr
     =Expression.NewArrayBounds
       (elementType_u,
        newArgs__raw); //throw

    Debug.Assert(!Object.ReferenceEquals(resultExpr,null));

    break;
   }//case NewArrayBounds

   default:
   {
    ThrowBugCheck.Unexpected_Expression_NodeType
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      node.NodeType);

    break;
   }//default
  }//switch

  Debug.Assert(!Object.ReferenceEquals(resultExpr,null));

  return resultExpr;
 }//VisitNewArray

 //Helper methods --------------------------------------------------------
 private static IReadOnlyCollection<Expression>
                             Helper__AdjustExpressionTypes
                                           (IReadOnlyCollection<Expression> expressions,
                                            System.Type                     requiredType)
 {
  Debug.Assert(!Object.ReferenceEquals(expressions,null));
  Debug.Assert(!Object.ReferenceEquals(requiredType,null));

  bool needRebuild
   =false;

  foreach(var a in expressions)
  {
   Debug.Assert(!Object.ReferenceEquals(a,null));

   if(a.Type!=requiredType)
   {
    needRebuild=true;
    break;
   }
  }//foreach a

  if(!needRebuild)
  {
   return expressions;
  }//if

  Debug.Assert(needRebuild);

  var correctedExpressions
   =new Expression[expressions.Count];

  var i=0;

  foreach(var a in expressions)
  {
   Debug.Assert(!Object.ReferenceEquals(a,null));
   Debug.Assert(!Object.ReferenceEquals(a.Type,null));

   if(!Helper__TryMakeSafeConversion(a,requiredType,out var correctedA))
   {
    //ERROR - cannot convert array element value to required type.

    ThrowError.LocalEvalErr__CantConvertArrayElementValueToRequiredType
     (c_ErrSrcID,
      new int[]{i},
      a.Type,
      requiredType);

    Debug.Assert(false);
   }//if

   Debug.Assert(!Object.ReferenceEquals(correctedA,null));
   Debug.Assert(!Object.ReferenceEquals(correctedA.Type,null));
   Debug.Assert(correctedA.Type==requiredType);

   correctedExpressions[i]=correctedA;

   ++i;
  }//foreach a

  return correctedExpressions;
 }//Helper__AdjustExpressionTypes
};//class LcpiOleDb__LocalSvc__PrepareForLocalEvaluation

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Svcs

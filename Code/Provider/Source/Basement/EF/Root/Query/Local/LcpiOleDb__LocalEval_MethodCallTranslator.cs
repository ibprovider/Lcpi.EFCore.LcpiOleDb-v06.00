////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 04.10.2018.
using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure__MethodId
 =Structure.Structure_MethodId;

////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__LocalEval_MethodCallTranslator

abstract class LcpiOleDb__LocalEval_MethodCallTranslator
{
 public struct tagOpData
 {
  public readonly Structure__MethodId MethodId;

  public readonly Expression CallObject;

  public readonly IReadOnlyList<Expression> Arguments;

  public readonly LcpiOleDb__LocalEval_Services ExpressionServices;

  //------------------------------------------------------------
  public tagOpData(Structure__MethodId           methodId,
                   Expression                    callObject,
                   IReadOnlyList<Expression>     arguments,
                   LcpiOleDb__LocalEval_Services expressionServices)
  {
   Debug.Assert(!Object.ReferenceEquals(methodId,null));
   Debug.Assert(!Object.ReferenceEquals(expressionServices,null));

   //---------------------------------------
   this.MethodId=methodId;

   this.CallObject=callObject;

   this.Arguments=arguments;

   this.ExpressionServices=expressionServices;

   //---------------------------------------
   Debug.Assert(!Object.ReferenceEquals(this.MethodId,null));
   Debug.Assert(!Object.ReferenceEquals(this.ExpressionServices,null));
  }//tagOpData
 };//struct tagOpData

 //public data -----------------------------------------------------------
 public readonly Structure__MethodId MethodId;

 //constructor -----------------------------------------------------------
 public LcpiOleDb__LocalEval_MethodCallTranslator(Structure__MethodId methodId)
 {
  Debug.Assert(!Object.ReferenceEquals(methodId,null));

  this.MethodId=methodId;
 }//LcpiOleDb__LocalEval_MethodCallTranslator

 //interface -------------------------------------------------------------
 public abstract Expression Translate(in tagOpData opData);
};//class LcpiOleDb__LocalEval_MethodCallTranslator

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local

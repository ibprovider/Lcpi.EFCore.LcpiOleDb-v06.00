////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 08.10.2018.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__LocalEval_UnaryTranslator

abstract class LcpiOleDb__LocalEval_UnaryTranslator
{
 public struct tagOpData
 {
  public readonly ExpressionType OperationType;

  public readonly System.Type ResultType;

  public readonly Expression Operand;

  public readonly LcpiOleDb__LocalEval_Services ExpressionServices;

  //----------------------------------------
  public tagOpData(ExpressionType                operationType,
                   System.Type                   resultType,
                   Expression                    operand,
                   LcpiOleDb__LocalEval_Services expressionServices)
  {
   Debug.Assert(!Object.ReferenceEquals(resultType,null));
   Debug.Assert(!Object.ReferenceEquals(operand,null));
   Debug.Assert(!Object.ReferenceEquals(operand.Type,null));
   Debug.Assert(!Object.ReferenceEquals(expressionServices,null));

   //---------------------------------------
   this.OperationType=operationType;

   this.ResultType=resultType;

   this.Operand=operand;

   this.ExpressionServices=expressionServices;

   //---------------------------------------
   Debug.Assert(!Object.ReferenceEquals(this.Operand,null));
   Debug.Assert(!Object.ReferenceEquals(this.ResultType,null));
   Debug.Assert(!Object.ReferenceEquals(this.ExpressionServices,null));
  }//tagOpData
 };//struct tagOpData

 //constructor -----------------------------------------------------------
 public LcpiOleDb__LocalEval_UnaryTranslator()
 {
 }//LcpiOleDb__LocalEval_UnaryTranslator

 //interface -------------------------------------------------------------
 public abstract Expression Translate(in tagOpData opData);
};//class LcpiOleDb__LocalEval_UnaryTranslator

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local

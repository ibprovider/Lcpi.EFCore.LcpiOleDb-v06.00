////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 08.10.2018.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__LocalEval_BinaryTranslator

abstract class LcpiOleDb__LocalEval_BinaryTranslator
{
 public struct tagOpData
 {
  public readonly Expression Left;

  public readonly Expression Right;

  public readonly LcpiOleDb__LocalEval_Services ExpressionServices;

  //----------------------------------------
  public tagOpData(Expression                    left,
                   Expression                    right,
                   LcpiOleDb__LocalEval_Services expressionServices)
  {
   Debug.Assert(!Object.ReferenceEquals(left,null));
   Debug.Assert(!Object.ReferenceEquals(right,null));
   Debug.Assert(!Object.ReferenceEquals(expressionServices,null));

   //---------------------------------------
   this.Left=left;

   this.Right=right;

   this.ExpressionServices=expressionServices;

   //---------------------------------------
   Debug.Assert(!Object.ReferenceEquals(this.Left,null));
   Debug.Assert(!Object.ReferenceEquals(this.Right,null));
   Debug.Assert(!Object.ReferenceEquals(this.ExpressionServices,null));
  }//tagOpData
 };//struct tagOpData

 //constructor -----------------------------------------------------------
 public LcpiOleDb__LocalEval_BinaryTranslator()
 {
 }//LcpiOleDb__LocalEval_BinaryTranslator

 //interface -------------------------------------------------------------
 public abstract Expression Translate(in tagOpData opData);
};//class LcpiOleDb__LocalEval_BinaryTranslator

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local

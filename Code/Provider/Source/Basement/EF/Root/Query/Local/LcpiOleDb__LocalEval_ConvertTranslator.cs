////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 07.01.2021.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__LocalEval_ConvertTranslator

abstract class LcpiOleDb__LocalEval_ConvertTranslator
{
 public struct tagOpData
 {
  public readonly Expression Node;

  public readonly LcpiOleDb__LocalEval_Services ExpressionServices;

  //------------------------------------------------------------
  public tagOpData(Expression                    node,
                   LcpiOleDb__LocalEval_Services expressionServices)
  {
   Debug.Assert(!Object.ReferenceEquals(node,null));
   Debug.Assert(!Object.ReferenceEquals(expressionServices,null));

   //---------------------------------------
   this.Node=node;

   this.ExpressionServices=expressionServices;

   //---------------------------------------
   Debug.Assert(!Object.ReferenceEquals(this.Node,null));
   Debug.Assert(!Object.ReferenceEquals(this.ExpressionServices,null));
  }//tagOpData
 };//struct tagOpData

 //interface -------------------------------------------------------------
 public abstract System.Type SourceType
 {
  get;
 }//SourceType

 public abstract System.Type TargetType
 {
  get;
 }//TargetType

 public abstract Expression Translate(in tagOpData opData);
};//class LcpiOleDb__LocalEval_ConvertTranslator

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local

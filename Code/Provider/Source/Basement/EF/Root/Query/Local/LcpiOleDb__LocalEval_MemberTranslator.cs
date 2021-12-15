////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 04.10.2018.
using System;
using System.Diagnostics;
using System.Reflection;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_MemberId
 =Structure.Structure_MemberId;

////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__LocalEval_MemberTranslator

abstract class LcpiOleDb__LocalEval_MemberTranslator
{
 public struct tagOpData
 {
  public readonly Structure_MemberId MemberId;

  public readonly Expression Expression;

  public readonly LcpiOleDb__LocalEval_Services ExpressionServices;

  //------------------------------------------------------------
  public tagOpData(Structure_MemberId            memberId,
                   Expression                    expression,
                   LcpiOleDb__LocalEval_Services expressionServices)
  {
   Debug.Assert(!Object.ReferenceEquals(memberId,null));
   Debug.Assert(!Object.ReferenceEquals(expressionServices,null));

   //---------------------------------------
   this.MemberId=memberId;

   this.Expression=expression;

   this.ExpressionServices=expressionServices;

   //---------------------------------------
   Debug.Assert(!Object.ReferenceEquals(this.MemberId,null));
   Debug.Assert(!Object.ReferenceEquals(this.ExpressionServices,null));
  }//tagOpData
 };//struct tagOpData

 //public data -----------------------------------------------------------
 public readonly Structure_MemberId MemberId;

 //constructor -----------------------------------------------------------
 public LcpiOleDb__LocalEval_MemberTranslator(Structure_MemberId MemberId)
 {
  Debug.Assert(!Object.ReferenceEquals(MemberId,null));

  this.MemberId=MemberId;
 }//LcpiOleDb__LocalEval_MemberTranslator

 //interface -------------------------------------------------------------
 public abstract Expression Translate(in tagOpData opData);
};//class LcpiOleDb__LocalEval_MemberTranslator

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local

///////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 30.04.2021.
using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators{
////////////////////////////////////////////////////////////////////////////////
//using

using LcpiOleDb__SqlExpressionFactory
 =Root.Query.LcpiOleDb__SqlExpressionFactory;

using LcpiOleDb__ISqlTreeNodeBuilder
 =Root.Query.LcpiOleDb__ISqlTreeNodeBuilder;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator_Unary

abstract class FB_Common__Sql_ETranslator_Unary
{
 public struct tagOpData
 {
  public readonly LcpiOleDb__ExpressionType OperatorType;

  public readonly System.Type ClrResultType;

  public readonly SqlExpression SqlOperand;

  public readonly LcpiOleDb__SqlExpressionFactory SqlExpressionFactory;

  public readonly LcpiOleDb__ISqlTreeNodeBuilder SqlTreeNodeBuilder;

  //-----------------------------------------------------------------------
  public tagOpData(LcpiOleDb__ExpressionType             operatorType,
                   System.Type                           clrResultType,
                   SqlExpression                         sqlOperand,
                   LcpiOleDb__SqlExpressionFactory       sqlExpressionFactory,
                   LcpiOleDb__ISqlTreeNodeBuilder        sqlTreeNodeBuilder)
  {
   Debug.Assert(!Object.ReferenceEquals(clrResultType,null));
   //Debug.Assert(!Object.ReferenceEquals(sqlOperand,null));
   Debug.Assert(!Object.ReferenceEquals(sqlExpressionFactory,null));

   //----------
   this.OperatorType=operatorType;

   this.SqlOperand=sqlOperand;

   this.ClrResultType=clrResultType;

   this.SqlExpressionFactory=sqlExpressionFactory;

   this.SqlTreeNodeBuilder=sqlTreeNodeBuilder;

   //----------
   Debug.Assert(!Object.ReferenceEquals(this.ClrResultType,null));
   //Debug.Assert(!Object.ReferenceEquals(this.SqlOperand,null));
   Debug.Assert(!Object.ReferenceEquals(this.SqlExpressionFactory,null));
   Debug.Assert(!Object.ReferenceEquals(this.SqlTreeNodeBuilder,null));
  }//tagOpData
 };//struct tagOpData

 //-----------------------------------------------------------------------
 public FB_Common__Sql_ETranslator_Unary()
 {
 }//FB_Common__Sql_ETranslator_Unary

 //interface -------------------------------------------------------------
 public abstract SqlExpression Translate(in tagOpData opData);
};//class FB_Common__Sql_ETranslator_Unary

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators

///////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 21.11.2020.
using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators{
////////////////////////////////////////////////////////////////////////////////
//using

using LcpiOleDb__SqlExpressionFactory
 =Root.Query.LcpiOleDb__SqlExpressionFactory;

using LcpiOleDb__ISqlTreeNodeBuilder
 =Root.Query.LcpiOleDb__ISqlTreeNodeBuilder;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator_Op2

abstract class FB_Common__Sql_ETranslator_Op2
{
 public struct tagOpData
 {
  public readonly LcpiOleDb__ExpressionType OperationType;

  public readonly SqlExpression SqlLeft;

  public readonly SqlExpression SqlRight;

  public readonly RelationalTypeMapping SqlResultTypeMapping;

  public readonly LcpiOleDb__SqlExpressionFactory SqlExpressionFactory;

  public readonly LcpiOleDb__ISqlTreeNodeBuilder SqlTreeNodeBuilder;

  //-----------------------------------------------------------------------
  public tagOpData(LcpiOleDb__ExpressionType             operationType,
                   SqlExpression                         sqlLeft,
                   SqlExpression                         sqlRight,
                   RelationalTypeMapping                 sqlResultTypeMapping,
                   LcpiOleDb__SqlExpressionFactory       sqlExpressionFactory,
                   LcpiOleDb__ISqlTreeNodeBuilder        sqlTreeNodeBuilder)
  {
   Debug.Assert(!Object.ReferenceEquals(sqlLeft,null));
   Debug.Assert(!Object.ReferenceEquals(sqlRight,null));
   //Debug.Assert(!Object.ReferenceEquals(sqlResultTypeMapping,null));
   Debug.Assert(!Object.ReferenceEquals(sqlExpressionFactory,null));

   //----------
   this.OperationType=operationType;

   this.SqlLeft=sqlLeft;

   this.SqlRight=sqlRight;

   this.SqlResultTypeMapping=sqlResultTypeMapping;

   this.SqlExpressionFactory=sqlExpressionFactory;

   this.SqlTreeNodeBuilder=sqlTreeNodeBuilder;

   //----------
   Debug.Assert(!Object.ReferenceEquals(this.SqlLeft,null));
   Debug.Assert(!Object.ReferenceEquals(this.SqlRight,null));
   Debug.Assert(!Object.ReferenceEquals(this.SqlExpressionFactory,null));
   Debug.Assert(!Object.ReferenceEquals(this.SqlTreeNodeBuilder,null));
  }//tagOpData
 };//struct tagOpData

 //-----------------------------------------------------------------------
 public FB_Common__Sql_ETranslator_Op2()
 {
 }//FB_Common__Sql_ETranslator_Op2

 //interface -------------------------------------------------------------
 public abstract SqlExpression Translate(in tagOpData opData);
};//class FB_Common__Sql_ETranslator_Op2

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators

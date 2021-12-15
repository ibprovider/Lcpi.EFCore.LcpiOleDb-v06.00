////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 21.11.2020.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query{
////////////////////////////////////////////////////////////////////////////////
//interface LcpiOleDb__IBinaryOperatorTranslatorProvider

interface LcpiOleDb__IBinaryOperatorTranslatorProvider
{
 public struct tagOpData
 {
  public readonly LcpiOleDb__ExpressionType OperationType;

  public readonly SqlExpression SqlLeft;

  public readonly SqlExpression SqlRight;

  public readonly LcpiOleDb__SqlExpressionFactory SqlExpressionFactory;

  public readonly LcpiOleDb__ISqlTreeNodeBuilder SqlTreeNodeBuilder;

  //-----------------------------------------------------------------------
  public tagOpData(LcpiOleDb__ExpressionType             operationType,
                   SqlExpression                         sqlLeft,
                   SqlExpression                         sqlRight,
                   LcpiOleDb__SqlExpressionFactory       sqlExpressionFactory,
                   LcpiOleDb__ISqlTreeNodeBuilder        sqlTreeNodeBuilder)
  {
   Debug.Assert(!Object.ReferenceEquals(sqlLeft,null));
   Debug.Assert(!Object.ReferenceEquals(sqlRight,null));
   Debug.Assert(!Object.ReferenceEquals(sqlExpressionFactory,null));
   Debug.Assert(!Object.ReferenceEquals(sqlTreeNodeBuilder,null));

   //----------
   this.OperationType=operationType;

   this.SqlLeft=sqlLeft;

   this.SqlRight=sqlRight;

   this.SqlExpressionFactory=sqlExpressionFactory;

   this.SqlTreeNodeBuilder=sqlTreeNodeBuilder;

   //----------
   Debug.Assert(!Object.ReferenceEquals(this.SqlLeft,null));
   Debug.Assert(!Object.ReferenceEquals(this.SqlRight,null));
   Debug.Assert(!Object.ReferenceEquals(this.SqlExpressionFactory,null));
   Debug.Assert(!Object.ReferenceEquals(this.SqlTreeNodeBuilder,null));
  }//tagOpData
 };//struct tagOpData

 //interface -------------------------------------------------------------
 SqlExpression Translate(in tagOpData opData);
};//interface LcpiOleDb__IBinaryOperatorTranslatorProvider

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query

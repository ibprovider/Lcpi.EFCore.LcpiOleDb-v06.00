////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 23.11.2020.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql{
////////////////////////////////////////////////////////////////////////////////
//class FB_Common__BinaryOperatorTranslatorKey

sealed class FB_Common__BinaryOperatorTranslatorKey
{
 public readonly LcpiOleDb__ExpressionType OperationType;

 public readonly System.Type LeftType;

 public readonly System.Type RightType;

 //-------------------------------------------------------------
 public FB_Common__BinaryOperatorTranslatorKey(LcpiOleDb__ExpressionType operationType,
                                               System.Type               leftType,
                                               System.Type               rightType)
 {
  Debug.Assert(!Object.ReferenceEquals(leftType,null));
  Debug.Assert(!Object.ReferenceEquals(rightType,null));

  this.OperationType=operationType;

  this.LeftType=leftType;

  this.RightType=rightType;
 }//FB_Common__BinaryOperatorTranslatorKey
};//struct FB_Common__BinaryOperatorTranslatorKey

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql

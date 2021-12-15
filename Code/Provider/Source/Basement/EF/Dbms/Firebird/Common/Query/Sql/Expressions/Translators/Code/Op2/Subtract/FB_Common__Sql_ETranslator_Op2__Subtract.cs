////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 26.12.2020.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code{
////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator_Op2__Subtract

sealed class FB_Common__Sql_ETranslator_Op2__Subtract
 :FB_Common__Sql_ETranslator_Op2
{
 public static readonly FB_Common__Sql_ETranslator_Op2
  Instance
   =new FB_Common__Sql_ETranslator_Op2__Subtract();

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator_Op2__Subtract()
 {
 }//FB_Common__Sql_ETranslator_Op2__Subtract

 //FB_Common__Sql_ETranslator_Op2 interface ------------------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(opData.OperationType==LcpiOleDb__ExpressionType.Subtract);

  Debug.Assert(!Object.ReferenceEquals(opData.SqlLeft,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlRight,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlResultTypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));

  //------------------------------------------------------------

  //
  // [2021-01-03] No idea how to send here the arguments without TypeMapping.
  //

  //------------------------------------------------------------
#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (opData.SqlLeft);

  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (opData.SqlRight);
#endif

  //------------------------------------------------------------
  var r
   =Nodes.FB_Common__Sql_ENode_Binary__Subtract.Create
     (opData.SqlLeft,
      opData.SqlRight,
      opData.SqlResultTypeMapping);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (r,
    opData.SqlResultTypeMapping);
#endif

  return r;
 }//Translate
};//class FB_Common__Sql_ETranslator_Op2__Subtract

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 30.04.2021.
using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code{
////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator_Op2__LessThan

sealed class FB_Common__Sql_ETranslator_Op2__LessThan
 :FB_Common__Sql_ETranslator_Op2
{
 public static readonly FB_Common__Sql_ETranslator_Op2
  Instance
   =new FB_Common__Sql_ETranslator_Op2__LessThan();

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator_Op2__LessThan()
 {
 }//FB_Common__Sql_ETranslator_Op2__LessThan

 //FB_Common__Sql_ETranslator_Op2 interface ------------------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(opData.OperationType==LcpiOleDb__ExpressionType.LessThan);

  Debug.Assert(!Object.ReferenceEquals(opData.SqlLeft,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlRight,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));

  //------------------------------------------------------------
#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlType
   (opData.SqlLeft);
#endif

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlType
   (opData.SqlRight);
#endif

  //------------------------------------------------------------
  var resultTypeMapping
   =FB_Common__TypeMappingCache.TypeMapping__BOOLEAN;

  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));

  //------------------------------------------------------------
  var sqlLeft
   =opData.SqlLeft;

  var sqlRight
   =opData.SqlRight;

  //------------------------------------------------------------
  sqlLeft
   =opData.SqlExpressionFactory.ApplyTypeMapping2
     (sqlLeft,
      sqlRight.TypeMapping,
      resultTypeMapping);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (sqlLeft);
#endif

  //----------------------------------------
  sqlRight
   =opData.SqlExpressionFactory.ApplyTypeMapping2
     (sqlRight,
      sqlLeft.TypeMapping,
      resultTypeMapping);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (sqlRight);
#endif

  //------------------------------------------------------------
  var result
   =Nodes.FB_Common__Sql_ENode_Binary__LessThan.Create
     (sqlLeft,
      sqlRight,
      resultTypeMapping);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (result,
    resultTypeMapping);
#endif

  return result;
 }//Translate
};//class FB_Common__Sql_ETranslator_Op2__LessThan

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code

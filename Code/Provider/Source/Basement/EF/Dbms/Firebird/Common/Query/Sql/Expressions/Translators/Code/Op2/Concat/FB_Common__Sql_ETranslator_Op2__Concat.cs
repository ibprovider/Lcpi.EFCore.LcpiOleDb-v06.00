////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 26.11.2020.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator_Op2__Concat

sealed class FB_Common__Sql_ETranslator_Op2__Concat
 :FB_Common__Sql_ETranslator_Op2
{
 public static readonly FB_Common__Sql_ETranslator_Op2
  Instance
   =new FB_Common__Sql_ETranslator_Op2__Concat();

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator_Op2__Concat()
 {
 }//FB_Common__Sql_ETranslator_Op2__Concat

 //FB_Common__Sql_ETranslator_Op2 interface ------------------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.SqlLeft,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlRight,null));
  //Debug.Assert(!Object.ReferenceEquals(opData.SqlResultTypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));

  Debug.Assert(!Object.ReferenceEquals(opData.SqlLeft.Type,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlRight.Type,null));

  //----------------------------------------
#if DEBUG
  if(opData.OperationType==LcpiOleDb__ExpressionType.Concat)
  {
   //OK
  }
  else
  if(opData.OperationType==LcpiOleDb__ExpressionType.Add)
  {
   Debug.Assert
    (Core.SQL.Core_SQL__ExpressionUtils.DEBUG__GetSqlType(opData.SqlLeft) ==Structure_TypeCache.TypeOf__System_String ||
     Core.SQL.Core_SQL__ExpressionUtils.DEBUG__GetSqlType(opData.SqlRight)==Structure_TypeCache.TypeOf__System_String);
  }
  else
  {
   Debug.Assert(false);
  }
#endif

  //----------------------------------------

  //
  // ((string)value1) + ((string)value2) -> value1 || value2
  //

  var sqlLeft
   =Core.SQL.Core_SQL__ExpressionUtils.RemoveConvertToString(opData.SqlLeft);

  Debug.Assert(!Object.ReferenceEquals(sqlLeft,null));

  var sqlRight
   =Core.SQL.Core_SQL__ExpressionUtils.RemoveConvertToString(opData.SqlRight);

  Debug.Assert(!Object.ReferenceEquals(sqlRight,null));

  //------------------------------------------------------------

  //
  // Variants:
  //   1. null || value
  //   2. value || null
  //   3. string.concat(null, null)
  //
  // where null - this is expression WITHOUT TypeMapping
  //

  //------------------------------------------------------------
  sqlLeft
   =opData.SqlExpressionFactory.ApplyTypeMapping
     (sqlLeft,
      FB_Common__TypeMappingCache.TypeMapping__TEXT);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (sqlLeft);
#endif

  //--------------------------
  sqlRight
   =opData.SqlExpressionFactory.ApplyTypeMapping
    (sqlRight,
     FB_Common__TypeMappingCache.TypeMapping__TEXT);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (sqlRight);
#endif

  //------------------------------------------------------------
  //! \todo VARCHAR(?) + VARCHAR(?) == ???

  var resultTypeMapping
   =FB_Common__TypeMappingCache.TypeMapping__TEXT;

  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping.ClrType,null));
  Debug.Assert(resultTypeMapping.ClrType==Structure_TypeCache.TypeOf__System_String);

  var r
   =Nodes.FB_Common__Sql_ENode_Binary__Add.Create
     (sqlLeft,
      sqlRight,
      resultTypeMapping);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (r,
    resultTypeMapping);
#endif

  return r;
 }//Translate
};//class FB_Common__Sql_ETranslator_Op2__Concat

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 26.11.2020.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator_Op2__Add__Decimal

sealed class FB_Common__Sql_ETranslator_Op2__Add__Decimal
 :FB_Common__Sql_ETranslator_Op2
{
 public static readonly FB_Common__Sql_ETranslator_Op2
  Instance
   =new FB_Common__Sql_ETranslator_Op2__Add__Decimal();

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator_Op2__Add__Decimal()
 {
 }//FB_Common__Sql_ETranslator_Op2__Add__Decimal

 //FB_Common__Sql_ETranslator_Op2 interface ------------------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(opData.OperationType==LcpiOleDb__ExpressionType.Add);

  Debug.Assert(!Object.ReferenceEquals(opData.SqlLeft,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlRight,null));
  //Debug.Assert(!Object.ReferenceEquals(opData.SqlResultTypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));

  Debug.Assert(!Object.ReferenceEquals(opData.SqlLeft.Type,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlRight.Type,null));

#if DEBUG
  Debug.Assert
   (Core.SQL.Core_SQL__ExpressionUtils.DEBUG__GetSqlType(opData.SqlLeft)  ==Structure_TypeCache.TypeOf__System_Decimal ||
    Core.SQL.Core_SQL__ExpressionUtils.DEBUG__GetSqlType(opData.SqlRight) ==Structure_TypeCache.TypeOf__System_Decimal);
#endif

  //------------------------------------------------------------

  //
  // [2021-01-02] No idea how to send here the arguments without TypeMapping.
  //

  //------------------------------------------------------------
#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (opData.SqlLeft);

  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (opData.SqlRight);
#endif

  //------------------------------------------------------------
  //! \todo DECIMAL(p1,s1) + DECIMAL(p2,s2) == ???

  var resultTypeMapping
   =FB_Common__TypeMappingCache.TypeMapping__DECIMAL;

  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));

  var r
   =Nodes.FB_Common__Sql_ENode_Binary__Add.Create
     (opData.SqlLeft,
      opData.SqlRight,
      resultTypeMapping);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (r,
    resultTypeMapping);
#endif

  return r;
 }//Translate
};//class FB_Common__Sql_ETranslator_Op2__Add__Decimal

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code

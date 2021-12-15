////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 06.10.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D3.Expressions.Translators.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

using Nodes
 =Common.Query.Sql.Expressions.Nodes;

using FB_Common__Data
 =Common.FB_Common__Data;

using FB_Common__TypeMappingCache
 =Common.FB_Common__TypeMappingCache;

using FB_Common__Sql_ETranslator_Op2
 =Common.Query.Sql.Expressions.Translators.FB_Common__Sql_ETranslator_Op2;

////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0__Sql_ETranslator_Op2__Subtract__DateTime__DateTime

sealed class FB_V03_0_0__Sql_ETranslator_Op2__Subtract__DateTime__DateTime
 :FB_Common__Sql_ETranslator_Op2
{
 public static readonly FB_Common__Sql_ETranslator_Op2
  Instance
   =new FB_V03_0_0__Sql_ETranslator_Op2__Subtract__DateTime__DateTime();

 //-----------------------------------------------------------------------
 private FB_V03_0_0__Sql_ETranslator_Op2__Subtract__DateTime__DateTime()
 {
 }//FB_V03_0_0__Sql_ETranslator_Op2__Subtract__DateTime__DateTime

 //FB_Common__Sql_ETranslator_Op2 interface ------------------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(opData.OperationType==LcpiOleDb__ExpressionType.Subtract);

  Debug.Assert(!Object.ReferenceEquals(opData.SqlLeft,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlRight,null));
  Debug.Assert( Object.ReferenceEquals(opData.SqlResultTypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlTreeNodeBuilder,null));

  Debug.Assert(!Object.ReferenceEquals(opData.SqlLeft.Type,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlRight.Type,null));

#if DEBUG
  Debug.Assert
   (Core.SQL.Core_SQL__ExpressionUtils.DEBUG__GetSqlType(opData.SqlLeft)
     ==Structure_TypeCache.TypeOf__System_DateTime);

  Debug.Assert
   (Core.SQL.Core_SQL__ExpressionUtils.DEBUG__GetSqlType(opData.SqlRight)
     ==Structure_TypeCache.TypeOf__System_DateTime);
#endif

  //------------------------------------------------------------
  //
  // Generated SQL:
  //
  // (DATEDIFF(MILLISECOND, RIGHT, LEFT) MUL 0.001
  //
  // Firebird result has type NUMERIC(18,4)  ----> it is our TimeSpan (D3)
  //

  //------------------------------------------------------------

  //
  // [2021-01-03] No idea how to send here the arguments without TypeMapping.
  //

  //------------------------------------------------------------
  var exprLeft
   =/*[2020-12-29] Bye: opData.SqlExpressionFactory.ApplyDefaultTypeMapping*/
     (opData.SqlLeft);

  var exprRight
   =/*[2020-12-29] Bye: opData.SqlExpressionFactory.ApplyDefaultTypeMapping*/
     (opData.SqlRight);

  //------------------------------------------------------------
#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (exprLeft,
    Structure_TypeCache.TypeOf__System_DateTime);

  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (exprRight,
    Structure_TypeCache.TypeOf__System_DateTime);
#endif

  //------------------------------------------------------------
  var exprDateDiff
   =Nodes.FB_Common__Sql_ENode_Function__SQL__DATEDIFF.Create4
     (exprRight,
      exprLeft,
      FB_Common__TypeMappingCache.TypeMapping__NUMERIC_18_1);

  Debug.Assert(!Object.ReferenceEquals(exprDateDiff,null));

  //------------------------------------------------------------
  var exprMul_typeMapping
   =opData.SqlExpressionFactory.GetTypeMapping__Throw(Structure_TypeCache.TypeOf__System_TimeSpan);

  Debug.Assert(!Object.ReferenceEquals(exprMul_typeMapping,null));

  //Expected
  Debug.Assert(Object.ReferenceEquals(exprMul_typeMapping,FB_Common__TypeMappingCache.TypeMapping__TimeSpan__as_Decimal18_4));

  var exprMul
   =Nodes.FB_Common__Sql_ENode_Function__SQL__OP_MUL.Create
     (exprDateDiff,
      FB_Common__Data.sm_SqlConstantExpression__NUMERIC_4_3__MillisecondAsPartOfSecond,
      exprMul_typeMapping);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (exprMul,
    FB_Common__TypeMappingCache.TypeMapping__TimeSpan__as_Decimal18_4);
#endif

  //------------------------------------------------------------
  return exprMul;
 }//Translate
};//class FB_V03_0_0__Sql_ETranslator_Op2__Subtract__DateTime__DateTime

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D3.Expressions.Translators.Code

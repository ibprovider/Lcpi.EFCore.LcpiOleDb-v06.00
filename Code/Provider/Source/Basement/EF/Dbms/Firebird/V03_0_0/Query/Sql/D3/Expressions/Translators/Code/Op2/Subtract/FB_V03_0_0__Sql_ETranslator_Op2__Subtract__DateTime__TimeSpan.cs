////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 04.12.2020.
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
//class FB_V03_0_0__Sql_ETranslator_Op2__Subtract__DateTime__TimeSpan

sealed class FB_V03_0_0__Sql_ETranslator_Op2__Subtract__DateTime__TimeSpan
 :FB_Common__Sql_ETranslator_Op2
{
 public static readonly FB_Common__Sql_ETranslator_Op2
  Instance
   =new FB_V03_0_0__Sql_ETranslator_Op2__Subtract__DateTime__TimeSpan();

 //-----------------------------------------------------------------------
 private FB_V03_0_0__Sql_ETranslator_Op2__Subtract__DateTime__TimeSpan()
 {
 }//FB_V03_0_0__Sql_ETranslator_Op2__Subtract__DateTime__TimeSpan

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
     ==Structure_TypeCache.TypeOf__System_TimeSpan);
#endif

  //------------------------------------------------------------
  //
  // Generated SQL:
  //
  // DATEADD(MILLISECOND, -1000 MUL RIGHT, LEFT)
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
    Structure_TypeCache.TypeOf__System_TimeSpan);
#endif

  //------------------------------------------------------------
  var exprAmount
   =Nodes.FB_Common__Sql_ENode_Function__SQL__OP_MUL.Create
     (FB_Common__Data.sm_SqlConstantExpression__Int32__MillisecondsInSecond__negative,
      exprRight,
      FB_Common__TypeMappingCache.TypeMapping__DECIMAL);

  Debug.Assert(!Object.ReferenceEquals(exprAmount,null));

  //------------------------------------------------------------
  var resultTypeMapping
   =FB_Common__TypeMappingCache.TypeMapping__TIMESTAMP;

  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));

  var r
   =Nodes.FB_Common__Sql_ENode_Function__SQL__DATEADD.Create4
     (opData.SqlTreeNodeBuilder,
      /*value*/ exprLeft,
      /*amount*/exprAmount,
      resultTypeMapping);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (r,
    resultTypeMapping);
#endif

  //------------------------------------------------------------
  return r;
 }//Translate
};//class FB_V03_0_0__Sql_ETranslator_Op2__Subtract__DateTime__TimeSpan

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D3.Expressions.Translators.Code

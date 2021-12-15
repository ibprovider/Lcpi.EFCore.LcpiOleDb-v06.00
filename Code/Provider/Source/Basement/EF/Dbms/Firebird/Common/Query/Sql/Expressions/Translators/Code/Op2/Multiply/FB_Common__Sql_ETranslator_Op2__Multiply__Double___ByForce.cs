////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 01.02.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code{
////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator_Op2__Multiply__Double___ByForce

//
// (Double)arg1 * arg2 -> Double
//

sealed class FB_Common__Sql_ETranslator_Op2__Multiply__Double___ByForce
 :FB_Common__Sql_ETranslator_Op2
{
 public static readonly FB_Common__Sql_ETranslator_Op2
  Instance
   =new FB_Common__Sql_ETranslator_Op2__Multiply__Double___ByForce();

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator_Op2__Multiply__Double___ByForce()
 {
 }//FB_Common__Sql_ETranslator_Op2__Multiply__Double___ByForce

 //FB_Common__Sql_ETranslator_Op2 interface ------------------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(opData.OperationType==LcpiOleDb__ExpressionType.Multiply);

  Debug.Assert(!Object.ReferenceEquals(opData.SqlLeft,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlRight,null));
  //Debug.Assert(!Object.ReferenceEquals(opData.SqlResultTypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));

  Debug.Assert(!Object.ReferenceEquals(opData.SqlLeft.Type,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlRight.Type,null));

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
  var leftExpr2
   =opData.SqlTreeNodeBuilder.MakeUnary
     (LcpiOleDb__ExpressionType.Convert,
      opData.SqlLeft,
      Structure.Structure_TypeCache.TypeOf__System_Double);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (leftExpr2,
    FB_Common__TypeMappingCache.TypeMapping__DOUBLE);
#endif

  //----------------------------------------
  var result
   =Nodes.FB_Common__Sql_ENode_Binary__Multiply.Create
     (leftExpr2,
      opData.SqlRight,
      FB_Common__TypeMappingCache.TypeMapping__DOUBLE);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (result,
    FB_Common__TypeMappingCache.TypeMapping__DOUBLE);
#endif

  return result;
 }//Translate
};//class FB_Common__Sql_ETranslator_Op2__Multiply__Double___ByForce

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code

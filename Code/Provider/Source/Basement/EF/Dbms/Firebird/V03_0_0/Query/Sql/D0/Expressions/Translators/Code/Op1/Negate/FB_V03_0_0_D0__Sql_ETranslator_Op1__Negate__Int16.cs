////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 12.10.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D0.Expressions.Translators.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using FB_Common__Sql_ETranslator_Op1
 =Common.Query.Sql.Expressions.Translators.FB_Common__Sql_ETranslator_Op1;

using FB_Common__Data
 =Common.FB_Common__Data;

using Root.Query.Sql.Extensions.LcpiOleDb__ISqlTreeNodeBuilder__Extensions;

////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0_D0__Sql_ETranslator_Op1__Negate__Int16

sealed class FB_V03_0_0_D0__Sql_ETranslator_Op1__Negate__Int16
 :FB_Common__Sql_ETranslator_Op1
{
 public static readonly FB_Common__Sql_ETranslator_Op1
  Instance
   =new FB_V03_0_0_D0__Sql_ETranslator_Op1__Negate__Int16();

 //-----------------------------------------------------------------------
 private FB_V03_0_0_D0__Sql_ETranslator_Op1__Negate__Int16()
 {
 }//FB_V03_0_0_D0__Sql_ETranslator_Op1__Negate__Int16

 //FB_Common__Sql_ETranslator_Op2 interface ------------------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(opData.OperatorType==LcpiOleDb__ExpressionType.Negate);

  Debug.Assert(!Object.ReferenceEquals(opData.SqlOperand,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));

  //------------------------------------------------------------
  var sqlOperand
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping
     (opData.SqlOperand);

  Debug.Assert(!Object.ReferenceEquals(sqlOperand,null));
  Debug.Assert(!Object.ReferenceEquals(sqlOperand.Type,null));

  //------------------------------------------------------------

  //
  // Generated SQL:
  //
  //   0-OPERAND
  //

  //------------------------------------------------------------
  var r
   =opData.SqlTreeNodeBuilder.Extension__MakeBinary__Subtract__Throw
     (FB_Common__Data.sm_SqlConstantExpression__Int16__ZERO,
      sqlOperand);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (r);
#endif

  return r;
 }//Translate
};//class FB_V03_0_0_D0__Sql_ETranslator_Op1__Negate__Int16

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D0.Expressions.Translators.Code

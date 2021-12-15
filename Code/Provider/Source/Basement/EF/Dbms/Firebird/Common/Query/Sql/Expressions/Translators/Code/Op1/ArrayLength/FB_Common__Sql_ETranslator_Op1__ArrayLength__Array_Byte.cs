////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 30.04.2021.
using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

using Structure_MethodIdCache
 =Structure.Structure_MethodIdCache;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator_Op1__ArrayLength__Array_Byte

sealed class FB_Common__Sql_ETranslator_Op1__ArrayLength__Array_Byte
 :FB_Common__Sql_ETranslator_Op1
{
 public static readonly FB_Common__Sql_ETranslator_Op1
  Instance
   =new FB_Common__Sql_ETranslator_Op1__ArrayLength__Array_Byte();

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator_Op1__ArrayLength__Array_Byte()
 {
 }//FB_Common__Sql_ETranslator_Op1__ArrayLength__Array_Byte

 //FB_Common__Sql_ETranslator_Op2 interface ------------------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(opData.OperatorType==LcpiOleDb__ExpressionType.ArrayLength);

  Debug.Assert(!Object.ReferenceEquals(opData.SqlOperand,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));

  //------------------------------------------------------------
#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (opData.SqlOperand,
    Structure_TypeCache.TypeOf__System_Array_Byte);
#endif

  //------------------------------------------------------------
  var sqlOperand
   =opData.SqlOperand;

  Debug.Assert(!Object.ReferenceEquals(sqlOperand,null));
  Debug.Assert(!Object.ReferenceEquals(sqlOperand.Type,null));

  //------------------------------------------------------------
  var r
   =opData.SqlTreeNodeBuilder.MakeCall
     (Structure_MethodIdCache.MethodIdOf__BUILTIN_SQL__OCTET_LENGTH,
      /*instance*/null,
      new[]{sqlOperand});

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (r);
#endif

  return r;
 }//Translate
};//class FB_Common__Sql_ETranslator_Op1__ArrayLength__Array_Byte

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code

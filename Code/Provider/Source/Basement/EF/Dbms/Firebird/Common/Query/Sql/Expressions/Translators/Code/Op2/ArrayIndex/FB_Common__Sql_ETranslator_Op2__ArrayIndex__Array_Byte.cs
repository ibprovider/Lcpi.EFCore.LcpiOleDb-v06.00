////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 26.05.2021.
using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_MethodIdCache
 =Structure.Structure_MethodIdCache;

using Root.Query.Sql.Extensions.LcpiOleDb__ISqlTreeNodeBuilder__Extensions;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator_Op2__ArrayIndex__Array_Byte

sealed class FB_Common__Sql_ETranslator_Op2__ArrayIndex__Array_Byte
 :FB_Common__Sql_ETranslator_Op2
{
 public static readonly FB_Common__Sql_ETranslator_Op2
  Instance
   =new FB_Common__Sql_ETranslator_Op2__ArrayIndex__Array_Byte();

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator_Op2__ArrayIndex__Array_Byte()
 {
 }//FB_Common__Sql_ETranslator_Op2__ArrayIndex__Array_Byte

 //FB_Common__Sql_ETranslator_Op2 interface ------------------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(opData.OperationType==LcpiOleDb__ExpressionType.ArrayIndex);

  Debug.Assert(!Object.ReferenceEquals(opData.SqlLeft,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlRight,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlTreeNodeBuilder,null));

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

  //
  // [2021-05-26] No idea how to send here the arguments without TypeMapping.
  //

  //------------------------------------------------------------
  var exprSource
   =/*[2021-05-26] opData.SqlExpressionFactory.ApplyDefaultTypeMapping*/
     (opData.SqlLeft);

  var exprFrom
   =/*[2021-05-26] opData.SqlExpressionFactory.ApplyDefaultTypeMapping*/
     (opData.SqlRight);

  var exprFor
   =FB_Common__Data.sm_SqlConstantExpression__Int32__ONE;

  //------------------------------------------------------------
#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (exprSource);

  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (exprFrom);

  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (exprFor);
#endif

  //----------------------------------------

  //
  // BUILD SQL:
  //  CASE
  //  WHEN COALESCE((0 <= exprFrom) AND (exprFrom < OCTET_LENGTH(exprSource)), TRUE)
  //   THEN ASCII_VAL(SUBSTRING(exprSource FROM exprFrom + 1 FOR 1))
  //  ELSE CAST('OUT OF RANGE' AS SMALLINT)
  //  END
  //

  //----------------------------------------

  // exprFrom + 1

  var exprFrom2
   =opData.SqlTreeNodeBuilder.Extension__MakeBinary__Add__Throw
     (exprFrom,
      FB_Common__Data.sm_SqlConstantExpression__Int32__ONE);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (exprFrom2);
#endif

  //----------------------------------------
  var exprSubstr__typeMapping
   =FB_Common__TypeMappingCache.TypeMapping__VARBINARY1;

  Debug.Assert(!Object.ReferenceEquals(exprSubstr__typeMapping,null));

  // SUBSTRING(exprSource FROM exprFrom2 FOR exprFor)

  var exprSubstr
   =Nodes.FB_Common__Sql_ENode_Function__SQL__SUBSTRING_from_for.Create
     (exprSource,
      exprFrom2,
      exprFor,
      exprSubstr__typeMapping);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (exprSubstr,
    exprSubstr__typeMapping);
#endif

  //----------------------------------------

  // ASCII_VAL(exprSubstr)

  var exprAsciiVal
   =Nodes.FB_Common__Sql_ENode_Function__SQL__ASCII_VAL.Create
     (exprSubstr);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (exprAsciiVal);
#endif

  //----------------------------------------

  // 0<=exprFrom

  var exprCond_p1
   =opData.SqlTreeNodeBuilder.Extension__MakeBinary__LessThanOrEqual__Throw
     (FB_Common__Data.sm_SqlConstantExpression__Int32__ZERO,
      exprFrom);

  Debug.Assert(!Object.ReferenceEquals(exprCond_p1,null));

  //----------------------------------------

  // OCTET_LENGTH(exprSource)

  var exprBinLen
   =opData.SqlTreeNodeBuilder.MakeCall
     (Structure_MethodIdCache.MethodIdOf__BUILTIN_SQL__OCTET_LENGTH,
      /*instance*/null,
      new[]{exprSource});

  //----------------------------------------

  // exprFrom<exprBinLen

  var exprCond_p2
   =opData.SqlTreeNodeBuilder.Extension__MakeBinary__LessThan__Throw
     (exprFrom,
      exprBinLen);

  Debug.Assert(!Object.ReferenceEquals(exprCond_p2,null));

  //----------------------------------------

  // exprCond_p1 AND exprCond_p2

  var exprCond
   =opData.SqlTreeNodeBuilder.Extension__MakeBinary__AndAlso__Throw
     (exprCond_p1,
      exprCond_p2);

  Debug.Assert(!Object.ReferenceEquals(exprCond,null));

  //----------------------------------------

  // COALESCE(exprCond, TRUE)

  var exprCoalesce
   =opData.SqlTreeNodeBuilder.Extension__MakeBinary__Coalesce__Throw
     (exprCond,
      FB_Common__Data.sm_SqlConstantExpression__Boolean__TRUE);

  Debug.Assert(!Object.ReferenceEquals(exprCoalesce,null));

  //----------------------------------------

  // CAST('OUT OF RANGE' AS SMALLINT)

  var exprFailed
   =Nodes.FB_Common__Sql_ENode_Function__SQL__CAST_AS.Create
     (FB_Common__Data.sm_SqlConstantExpression__VARCHAR___OUT_OF_RANGE,
      FB_Common__TypeMappingCache.TypeMapping__INT16);

  Debug.Assert(!Object.ReferenceEquals(exprFailed,null));

  //----------------------------------------

  // CASE WHEN exprCoalesce THEN exprAsciiVal ELSE exprFailed END

  var result
   =opData.SqlExpressionFactory.Case
     (new []{new CaseWhenClause(exprCoalesce,exprAsciiVal)},
      exprFailed);

  Debug.Assert(!Object.ReferenceEquals(result,null));

  return result;
 }//Translate
};//class FB_Common__Sql_ETranslator_Op2__ArrayIndex__Array_Byte

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code

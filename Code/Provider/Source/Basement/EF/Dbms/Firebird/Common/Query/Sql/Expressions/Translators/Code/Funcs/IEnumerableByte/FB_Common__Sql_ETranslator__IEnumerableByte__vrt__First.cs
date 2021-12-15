////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 14.06.2021.
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
//class FB_Common__Sql_ETranslator__IEnumerableByte__vrt__First

sealed class FB_Common__Sql_ETranslator__IEnumerableByte__vrt__First
 :FB_Common__Sql_ETranslator_MethodCall
{
 public static readonly FB_Common__Sql_ETranslator_MethodCall.tagDescr
  Instance
   =new FB_Common__Sql_ETranslator_MethodCall.tagDescr
     (Structure_MethodIdCache.MethodIdOf__IEnumerableByte__vrt__First,
      new FB_Common__Sql_ETranslator__IEnumerableByte__vrt__First());

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator__IEnumerableByte__vrt__First()
 {
 }//FB_Common__Sql_ETranslator__IEnumerableByte__vrt__First

 //FB_Common__Sql_ETranslator_Op2 interface ------------------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.MethodId,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlTreeNodeBuilder,null));

  Debug.Assert(opData.MethodId.Equals(Structure_MethodIdCache.MethodIdOf__IEnumerableByte__vrt__First));

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(opData.Instance,null));
  Debug.Assert(!Object.ReferenceEquals(opData.Instance.Type,null));

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(opData.Arguments,null));
  Debug.Assert(opData.Arguments.Count==0);

  //----------------------------------------
  var exprObject
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(opData.Instance);

  Debug.Assert(!Object.ReferenceEquals(exprObject,null));
  Debug.Assert(!Object.ReferenceEquals(exprObject.Type,null));
  Debug.Assert(!Object.ReferenceEquals(exprObject.TypeMapping,null));

  //------------------------------------------------------------
#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (exprObject);
#endif

  //----------------------------------------

  //
  // BUILD SQL:
  //  CASE
  //  WHEN COALESCE((0 < OCTET_LENGTH(exprSource)), TRUE)
  //   THEN ASCII_VAL(SUBSTRING(exprSource FROM 1 FOR 1))
  //  ELSE CAST('OUT OF RANGE' AS SMALLINT)
  //  END
  //

  //----------------------------------------
  var exprSubstr__typeMapping
   =FB_Common__TypeMappingCache.TypeMapping__VARBINARY1;

  Debug.Assert(!Object.ReferenceEquals(exprSubstr__typeMapping,null));

  // SUBSTRING(exprSource FROM exprFrom2 FOR exprFor)

  var exprSubstr
   =Nodes.FB_Common__Sql_ENode_Function__SQL__SUBSTRING_from_for.Create
     (exprObject,
      FB_Common__Data.sm_SqlConstantExpression__Int32__ONE,
      FB_Common__Data.sm_SqlConstantExpression__Int32__ONE,
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

  // OCTET_LENGTH(exprSource)

  var exprBinLen
   =opData.SqlTreeNodeBuilder.MakeCall
     (Structure_MethodIdCache.MethodIdOf__BUILTIN_SQL__OCTET_LENGTH,
      /*instance*/null,
      new[]{exprObject});

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (exprBinLen);
#endif

  //----------------------------------------

  // 0<exprBinLen

  var exprCond
   =opData.SqlTreeNodeBuilder.Extension__MakeBinary__LessThan__Throw
     (FB_Common__Data.sm_SqlConstantExpression__Int32__ZERO,
      exprBinLen);

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
};//class FB_Common__Sql_ETranslator__IEnumerableByte__vrt__First

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code

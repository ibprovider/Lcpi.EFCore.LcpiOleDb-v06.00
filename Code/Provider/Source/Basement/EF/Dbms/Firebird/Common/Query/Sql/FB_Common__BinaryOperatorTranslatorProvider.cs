////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 21.11.2020.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql{
////////////////////////////////////////////////////////////////////////////////
//using

using LcpiOleDb__SqlExpressionFactory
 =Root.Query.LcpiOleDb__SqlExpressionFactory;

using LcpiOleDb__ISqlTreeNodeBuilder
 =Root.Query.LcpiOleDb__ISqlTreeNodeBuilder;

using LcpiOleDb__IBinaryOperatorTranslatorProvider
 =Root.Query.LcpiOleDb__IBinaryOperatorTranslatorProvider;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__BinaryOperatorTranslatorProvider

sealed class FB_Common__BinaryOperatorTranslatorProvider<TGetDataByKey>
 :LcpiOleDb__IBinaryOperatorTranslatorProvider
  where TGetDataByKey: Structure.Structure_IGetDataByKey<FB_Common__BinaryOperatorTranslatorKey,FB_Common__BinaryOperatorTranslatorData>, new()
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__BinaryOperatorTranslatorProvider;

 //-----------------------------------------------------------------------
 public FB_Common__BinaryOperatorTranslatorProvider()
 {
 }//FB_Common__BinaryOperatorTranslatorProvider

 //LcpiOleDb__IBinaryOperatorTranslatorProvider interface ----------------
 public SqlExpression Translate(in LcpiOleDb__IBinaryOperatorTranslatorProvider.tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.SqlLeft,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlRight,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlTreeNodeBuilder,null));

  //----------------------------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Translate),
    "opData.SqlLeft",
    opData.SqlLeft);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Translate),
    "opData.SqlRight",
    opData.SqlRight);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Translate),
    "opData.SqlExpressionFactory",
    opData.SqlExpressionFactory);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Translate),
    "opData.SqlTreeNodeBuilder",
    opData.SqlTreeNodeBuilder);

  //----------------------------------------
  var r
   =Helper__Translate
     (opData);

  return r;
 }//Translate

 //Helper methods --------------------------------------------------------
 private SqlExpression Helper__Translate(in LcpiOleDb__IBinaryOperatorTranslatorProvider.tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.SqlLeft,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlRight,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlTreeNodeBuilder,null));

  //----------------------------------------------------------------------
  const string c_bugcheck_src
   ="FB_Common__BinaryOperatorTranslatorProvider::Helper__Translate";

  //----------------------------------------------------------------------
  var leftSqlType
   =Core.SQL.Core_SQL__ExpressionUtils.GetSqlType
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      opData.SqlLeft);

  Debug.Assert(!Object.ReferenceEquals(leftSqlType,null));

  var rightSqlType
   =Core.SQL.Core_SQL__ExpressionUtils.GetSqlType
     (c_ErrSrcID,
      c_bugcheck_src,
      "#002",
      opData.SqlRight);

  Debug.Assert(!Object.ReferenceEquals(rightSqlType,null));

  //----------------------------------------------------------------------
  FB_Common__BinaryOperatorTranslatorKey
   translatorKey
    =new FB_Common__BinaryOperatorTranslatorKey
      (opData.OperationType,
       leftSqlType,
       rightSqlType);

  FB_Common__BinaryOperatorTranslatorData
   translatorData;

  Debug.Assert(!Object.ReferenceEquals(sm_translators1,null));

  if(!sm_translators1.TryGetData(translatorKey,out translatorData))
  {
   // [2020-12-28] Throw error instead return null.

   ThrowError.SqlTranslatorErr__UnsupportedBinaryOperatorType
    (c_ErrSrcID,
     translatorKey.OperationType,
     translatorKey.LeftType,
     translatorKey.RightType);
  }//if

  Debug.Assert(!Object.ReferenceEquals(translatorData.Translator,null));

  {
   var opData2
    =new Common.Query.Sql.Expressions.Translators.FB_Common__Sql_ETranslator_Op2.tagOpData
      (opData.OperationType,
       opData.SqlLeft,
       opData.SqlRight,
       translatorData.SqlResultTypeMapping,
       opData.SqlExpressionFactory,
       opData.SqlTreeNodeBuilder);

   var r
    =translatorData.Translator.Translate
      (opData2);

   return r;
  }//local
 }//Helper__Translate

 //private data ----------------------------------------------------------
 private static readonly TGetDataByKey
  sm_translators1
   =new TGetDataByKey();
};//class FB_Common__BinaryOperatorTranslatorProvider

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql

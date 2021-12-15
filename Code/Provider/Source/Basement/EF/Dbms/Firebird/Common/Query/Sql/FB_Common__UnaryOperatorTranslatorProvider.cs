////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 30.04.2021.
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

using LcpiOleDb__IUnaryOperatorTranslatorProvider
 =Root.Query.LcpiOleDb__IUnaryOperatorTranslatorProvider;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__UnaryOperatorTranslatorProvider

sealed class FB_Common__UnaryOperatorTranslatorProvider<TGetDataByKey>
 :LcpiOleDb__IUnaryOperatorTranslatorProvider
  where TGetDataByKey: Structure.Structure_IGetDataByKey<FB_Common__UnaryOperatorTranslatorKey,FB_Common__UnaryOperatorTranslatorData>, new()
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__UnaryOperatorTranslatorProvider;

 //-----------------------------------------------------------------------
 public FB_Common__UnaryOperatorTranslatorProvider()
 {
 }//FB_Common__UnaryOperatorTranslatorProvider

 //LcpiOleDb__IUnaryOperatorTranslatorProvider interface ----------------
 public SqlExpression Translate(in LcpiOleDb__IUnaryOperatorTranslatorProvider.tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.SqlTreeNodeBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(opData.ClrResultType,null));

  //----------------------------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Translate),
    "opData.SqlTreeNodeBuilder",
    opData.SqlTreeNodeBuilder);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Translate),
    "opData.ClrResultType",
    opData.ClrResultType);

  //----------------------------------------
  var r
   =Helper__Translate
     (opData);

  return r;
 }//Translate

 //Helper methods --------------------------------------------------------
 private SqlExpression Helper__Translate(in LcpiOleDb__IUnaryOperatorTranslatorProvider.tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.SqlTreeNodeBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(opData.ClrResultType,null));

  //----------------------------------------------------------------------
  FB_Common__UnaryOperatorTranslatorKey
   translatorKey
    =new FB_Common__UnaryOperatorTranslatorKey
      (opData.OperatorType);

  FB_Common__UnaryOperatorTranslatorData
   translatorData;

  Debug.Assert(!Object.ReferenceEquals(sm_translators1,null));

  if(!sm_translators1.TryGetData(translatorKey,out translatorData))
  {
   // [2021-04-30] Throw error instead return null.

   ThrowError.SqlTranslatorErr__UnsupportedUnaryOperatorType
    (c_ErrSrcID,
     translatorKey.OperatorType);
  }//if

  Debug.Assert(!Object.ReferenceEquals(translatorData.Translator,null));

  {
   var opData2
    =new Common.Query.Sql.Expressions.Translators.FB_Common__Sql_ETranslator_Unary.tagOpData
      (opData.OperatorType,
       opData.ClrResultType,
       opData.SqlOperand,
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
};//class FB_Common__UnaryOperatorTranslatorProvider

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql

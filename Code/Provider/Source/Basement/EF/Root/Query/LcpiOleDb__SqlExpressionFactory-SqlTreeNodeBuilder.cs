////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 09.10.2021.
using System;
using System.Diagnostics;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_MethodId
 =Structure.Structure_MethodId;

using LcpiOleDb__Sql_ETranslator_MethodCall
 =Query.Sql.Expressions.Translators.LcpiOleDb__Sql_ETranslator_MethodCall;

////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__SqlTreeNodeBuilder

sealed partial class LcpiOleDb__SqlExpressionFactory
 :LcpiOleDb__ISqlTreeNodeBuilder
{
 //LcpiOleDb__ISqlTreeNodeBuilder interface ------------------------------
 SqlExpression LcpiOleDb__ISqlTreeNodeBuilder.MakeUnary
                               (LcpiOleDb__ExpressionType operatorType,
                                SqlExpression             sqlOperand,
                                System.Type               clrResultType)
 {
  Debug.Assert(!Object.ReferenceEquals(clrResultType,null));

  //--------------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    "LcpiOleDb__ISqlTreeNodeBuilder.MakeUnary",
    nameof(clrResultType),
    clrResultType);

  //-------------------------- Expected
#if DEBUG
  if(!Object.ReferenceEquals(sqlOperand,null))
  {
   Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlType(sqlOperand);
  }
#endif //DEBUG

  //--------------------------
  Debug.Assert(!Object.ReferenceEquals(m_UnaryOperatorTranslator,null));

  var opData
   =new LcpiOleDb__IUnaryOperatorTranslatorProvider.tagOpData
     (operatorType,
      clrResultType,
      sqlOperand,
      this,
      this);

  var r
   =m_UnaryOperatorTranslator.Translate
     (opData);

  return r;
 }//MakeUnary

 //-----------------------------------------------------------------------
 SqlExpression LcpiOleDb__ISqlTreeNodeBuilder.MakeBinary
                                (LcpiOleDb__ExpressionType operatorType,
                                 SqlExpression             left,
                                 SqlExpression             right)
 {
  Debug.Assert(!Object.ReferenceEquals(left,null));
  Debug.Assert(!Object.ReferenceEquals(right,null));

  //--------------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    "LcpiOleDb__ISqlTreeNodeBuilder.MakeBinary",
    nameof(left),
    left);

  Check.Arg_NotNull
   (c_ErrSrcID,
    "LcpiOleDb__ISqlTreeNodeBuilder.MakeBinary",
    nameof(right),
    right);

  //-------------------------- Expected
#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlType(left);

  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlType(right);
#endif //DEBUG

  //--------------------------
  Debug.Assert(!Object.ReferenceEquals(m_BinaryOperatorTranslator,null));

  var opData
   =new LcpiOleDb__IBinaryOperatorTranslatorProvider.tagOpData
     (operatorType,
      left,
      right,
      this,
      this);

  var r
   =m_BinaryOperatorTranslator.Translate
     (opData);

  return r;
 }//MakeBinary

 //-----------------------------------------------------------------------
 SqlExpression LcpiOleDb__ISqlTreeNodeBuilder.MakeCall
                        (Structure_MethodId           methodId,
                         SqlExpression                sqlInstance,
                         IReadOnlyList<SqlExpression> sqlArguments)
 {
  Check.Arg_NotNull
   (c_ErrSrcID,
    "LcpiOleDb__ISqlTreeNodeBuilder.MakeBinary",
    nameof(methodId),
    methodId);

  Check.Arg_NotNull
   (c_ErrSrcID,
    "LcpiOleDb__ISqlTreeNodeBuilder.MakeBinary",
    nameof(sqlArguments),
    sqlArguments);

  //------------------------------------------------------------
  Debug.Assert(!Object.ReferenceEquals(m_DataFor_MethodCallTranslation,null));

  LcpiOleDb__Sql_ETranslator_MethodCall
   translator
    =null;

  if(!m_DataFor_MethodCallTranslation.TryGetData(methodId,out translator))
  {
   //ERROR - sql-translation of function not supported.

   ThrowError.SqlTranslatorErr__MethodNotSupported
    (c_ErrSrcID,
     methodId);

   Debug.Assert(false);
  }//if

  Debug.Assert(!Object.ReferenceEquals(methodId,null));

  //------------------------------------------------------------
  var opData
   =new LcpiOleDb__Sql_ETranslator_MethodCall.tagOpData
     (methodId,
      sqlInstance,
      sqlArguments,
      this,
      /*factory*/this,
      m_CnOptions);

  var r
   =translator.Translate
     (/*in*/opData);

  return r;
 }//MakeCall
};//class LcpiOleDb__SqlTreeNodeBuilder

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query

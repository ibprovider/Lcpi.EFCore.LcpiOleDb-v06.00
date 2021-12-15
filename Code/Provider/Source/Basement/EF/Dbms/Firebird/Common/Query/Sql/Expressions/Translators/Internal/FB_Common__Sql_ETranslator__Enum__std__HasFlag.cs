////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 02.06.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Internal{
////////////////////////////////////////////////////////////////////////////////

using Root.Query.Sql.Extensions.LcpiOleDb__ISqlTreeNodeBuilder__Extensions;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator__Enum__std__HasFlag

sealed class FB_Common__Sql_ETranslator__Enum__std__HasFlag
 :FB_Common__Sql_ETranslator_MethodCall
{
 public static readonly FB_Common__Sql_ETranslator_MethodCall
  Instance
   =new FB_Common__Sql_ETranslator__Enum__std__HasFlag();

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator__Enum__std__HasFlag()
 {
 }//FB_Common__Sql_ETranslator__Enum__std__HasFlag

 //FB_Common__Sql_ETranslator_MethodCall interface -----------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.MethodId,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlTreeNodeBuilder,null));

  Debug.Assert(opData.MethodId.MethodName==nameof(Enum.HasFlag));

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(opData.Instance,null));
  Debug.Assert(!Object.ReferenceEquals(opData.Instance.Type,null));

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (opData.Instance);
#endif

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(opData.Arguments,null));
  Debug.Assert(opData.Arguments.Count==1);

  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[0],null));
  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[0].Type,null));

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (opData.Arguments[0]);
#endif

  //----------------------------------------
  var exprObject
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(opData.Instance);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (exprObject);
#endif

  //----------------------------------------
  var exprArg0
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(opData.Arguments[0]);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (exprArg0);
#endif

  //----------------------------------------

  //
  // SQL: "BIN_AND(exprObject, exprArg0) SQL_OP_EQUAL exprArg0".
  //
  // Usage of SQL_OP_EQUAL instead OP_EQUAL for preventing comparison of NULLs.
  //

  //----------------------------------------
  var exprBinAnd
   =opData.SqlTreeNodeBuilder.Extension__MakeBinary__And__Throw
     (exprObject,
      exprArg0);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (exprBinAnd);
#endif

  //----------------------------------------
  var exprResult
   =Nodes.FB_Common__Sql_ENode_Function__SQL__OP_EQUAL.Create
     (exprBinAnd,
      exprArg0);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (exprResult,
    FB_Common__TypeMappingCache.TypeMapping__BOOLEAN);
#endif

  return exprResult;
 }//Translate
};//class FB_Common__Sql_ETranslator__Enum__std__HasFlag

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Internal

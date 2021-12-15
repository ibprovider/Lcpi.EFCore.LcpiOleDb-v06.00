////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 23.10.2020.
using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Internal{
////////////////////////////////////////////////////////////////////////////////

using Root.Query.Sql.Extensions.LcpiOleDb__ISqlTreeNodeBuilder__Extensions;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator__Nullable__std__GetValueOrDefault

sealed class FB_Common__Sql_ETranslator__Nullable__std__GetValueOrDefault
 :FB_Common__Sql_ETranslator_MethodCall
{
 public FB_Common__Sql_ETranslator__Nullable__std__GetValueOrDefault
                                           (RelationalTypeMapping valueTypeMapping,
                                            SqlExpression         defaultValue)
 {
  Debug.Assert(!Object.ReferenceEquals(valueTypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(defaultValue,null));

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (defaultValue);
#endif

  //----------------------------------------
  m_ValueTypeMapping=valueTypeMapping;

  m_DefaultValue=defaultValue;
 }//FB_Common__Sql_ETranslator__Nullable__std__GetValueOrDefault

 //IMethodTranslator interface -------------------------------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.MethodId,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));

  //----------------------------------------
#if DEBUG
  // [2021-06-16] Expected
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (opData.Instance);
#endif

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(opData.Arguments,null));
  Debug.Assert(opData.Arguments.Count==0);

  //------------------------------------------------------------
  var exprObject
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(opData.Instance);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (exprObject);
#endif

  //------------------------------------------------------------
  var exprResult
   =opData.SqlTreeNodeBuilder.Extension__MakeBinary__Coalesce__Throw
     (exprObject,
      m_DefaultValue);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (exprResult);
#endif

  return exprResult;
 }//Translate

 //private data ----------------------------------------------------------
 //! \todo NOT USED
 private readonly RelationalTypeMapping m_ValueTypeMapping;

 private readonly SqlExpression m_DefaultValue;
};//class FB_Common__Sql_ETranslator__Nullable__std__GetValueOrDefault

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Internal

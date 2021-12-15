////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 25.10.2020.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Internal{
////////////////////////////////////////////////////////////////////////////////

using Root.Query.Sql.Extensions.LcpiOleDb__ISqlTreeNodeBuilder__Extensions;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator__Nullable__std__HasValue

sealed class FB_Common__Sql_ETranslator__Nullable__std__HasValue
 :FB_Common__Sql_ETranslator_Member
{
 public static readonly FB_Common__Sql_ETranslator_Member
  Instance
   =new FB_Common__Sql_ETranslator__Nullable__std__HasValue();

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator__Nullable__std__HasValue()
 {
 }//FB_Common__Sql_ETranslator__Nullable__std__HasValue

 //IMemberTranslator interface -------------------------------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.Instance,null));

#if DEBUG
  //opData.DEBUG_CheckMemberId(this.MemberId);
#endif

  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));

  //------------------------------------------------------------
  var Expression
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(opData.Instance);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (Expression);
#endif

  //------------------------------------------------------------
  var result
   =opData.SqlTreeNodeBuilder.Extension__MakeUnary__IsNotNull__Throw
     (Expression);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (result,
    FB_Common__TypeMappingCache.TypeMapping__BOOLEAN);
#endif

  return result;
 }//Translate
};//class FB_Common__Sql_ETranslator__Nullable__std__HasValue

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Internal

////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 11.09.2018.
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

using Structure_MethodInfoCache
 =Structure.Structure_MethodInfoCache;

using Root.Query.Sql.Extensions.LcpiOleDb__ISqlTreeNodeBuilder__Extensions;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator__String__std__Substring__from

sealed class FB_Common__Sql_ETranslator__String__std__Substring__from
 :FB_Common__Sql_ETranslator_MethodCall
{
 public static readonly FB_Common__Sql_ETranslator_MethodCall.tagDescr
  Instance
   =new FB_Common__Sql_ETranslator_MethodCall.tagDescr
     (Structure_MethodIdCache.MethodIdOf__String__std__Substring__from,
      new FB_Common__Sql_ETranslator__String__std__Substring__from());

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator__String__std__Substring__from()
 {
 }//FB_Common__Sql_ETranslator__String__std__Substring__from

 //FB_Common__Sql_ETranslator_MethodCall interface -----------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.Instance,null));

  Debug.Assert(!Object.ReferenceEquals(opData.MethodId,null));
  Debug.Assert(opData.MethodId.Equals(Structure_MethodInfoCache.MethodInfoOf__String__std__Substring__from));

  Debug.Assert(!Object.ReferenceEquals(opData.Arguments,null));
  Debug.Assert(opData.Arguments.Count==1);

  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[0],null));

  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));

  //----------------------------------------
  var exprSource
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(opData.Instance);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (exprSource,
    Structure_TypeCache.TypeOf__System_String);
#endif

  //----------------------------------------
  var exprFrom
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(opData.Arguments[0]);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (exprFrom);
#endif

  //----------------------------------------
  var exprFrom2
   =opData.SqlTreeNodeBuilder.Extension__MakeBinary__Add__Throw
     (exprFrom,
      FB_Common__Data.sm_SqlConstantExpression__Int32__ONE);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (exprFrom2);
#endif

  //----------------------------------------
  var resultTypeMapping
   =FB_Common__TypeMappingCache.TypeMapping__TEXT;

  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));

  var r
   =Nodes.FB_Common__Sql_ENode_Function__SQL__SUBSTRING_from.Create
     (exprSource,
      exprFrom2,
      resultTypeMapping);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (r,
    resultTypeMapping);
#endif

  return r;
 }//Translate
};//class FB_Common__Sql_ETranslator__String__std__Substring__from

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code

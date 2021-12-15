////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 17.09.2018.
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
//class FB_Common__Sql_ETranslator__String__std__IsNullOrEmpty

sealed class FB_Common__Sql_ETranslator__String__std__IsNullOrEmpty
 :FB_Common__Sql_ETranslator_MethodCall
{
 public static readonly FB_Common__Sql_ETranslator_MethodCall.tagDescr
  Instance
   =new FB_Common__Sql_ETranslator_MethodCall.tagDescr
     (Structure_MethodIdCache.MethodIdOf__String__std__IsNullOrEmpty,
      new FB_Common__Sql_ETranslator__String__std__IsNullOrEmpty());

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator__String__std__IsNullOrEmpty()
 {
 }//FB_Common__Sql_ETranslator__String__std__IsNullOrEmpty

 //FB_Common__Sql_ETranslator_MethodCall interface -----------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(Object.ReferenceEquals(opData.Instance,null));

  Debug.Assert(!Object.ReferenceEquals(opData.MethodId,null));
  Debug.Assert(opData.MethodId.Equals(Structure_MethodInfoCache.MethodInfoOf__String__std__IsNullOrEmpty));

  Debug.Assert(!Object.ReferenceEquals(opData.Arguments,null));
  Debug.Assert(opData.Arguments.Count==1);
  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[0],null));

  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));

  //------------------------------------------------------------
  var exprArg0
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping
     (opData.Arguments[0]);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (exprArg0,
    Structure_TypeCache.TypeOf__System_String);
#endif

  //------------------------------------------------------------
  var expr2
   =opData.SqlTreeNodeBuilder.Extension__MakeUnary__IsNull__Throw
     (exprArg0);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (expr2,
    FB_Common__TypeMappingCache.TypeMapping__BOOLEAN);
#endif

  //----------------------------------------
  //! \todo Rewrite expr3_len and expr3 to one expression with explicit comparison with empty string?

  var expr3_len
   =opData.SqlTreeNodeBuilder.MakeCall
     (Structure_MethodIdCache.MethodIdOf__BUILTIN_SQL__OCTET_LENGTH,
      /*instance*/null,
      new[]{exprArg0});

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (expr3_len);
#endif

  var expr3
   =opData.SqlTreeNodeBuilder.Extension__MakeBinary__Equal__Throw
     (expr3_len,
      FB_Common__Data.sm_SqlConstantExpression__Int32__ZERO);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (expr3,
    FB_Common__TypeMappingCache.TypeMapping__BOOLEAN);
#endif

  //----------------------------------------
  var expr4
   =opData.SqlTreeNodeBuilder.Extension__MakeBinary__OrElse__Throw
     (expr2,
      expr3);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (expr4,
    FB_Common__TypeMappingCache.TypeMapping__BOOLEAN);
#endif

  return expr4;
 }//Translate
};//class FB_Common__Sql_ETranslator__String__std__IsNullOrEmpty

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code

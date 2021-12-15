////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 31.05.2021.
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
//class FB_Common__Sql_ETranslator__String__std__CompareTo__str

sealed class FB_Common__Sql_ETranslator__String__std__CompareTo__str
 :FB_Common__Sql_ETranslator_MethodCall
{
 public static readonly FB_Common__Sql_ETranslator_MethodCall.tagDescr
  Instance
   =new FB_Common__Sql_ETranslator_MethodCall.tagDescr
     (Structure_MethodIdCache.MethodIdOf__String__std__CompareTo__str,
      new FB_Common__Sql_ETranslator__String__std__CompareTo__str());

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator__String__std__CompareTo__str()
 {
 }//FB_Common__Sql_ETranslator__String__std__CompareTo__str

 //FB_Common__Sql_ETranslator_MethodCall interface -----------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.Instance,null));

  Debug.Assert(!Object.ReferenceEquals(opData.MethodId,null));
  Debug.Assert(opData.MethodId.Equals(Structure_MethodInfoCache.MethodInfoOf__String__std__CompareTo__str));

  Debug.Assert(!Object.ReferenceEquals(opData.Arguments,null));
  Debug.Assert(opData.Arguments.Count==1);
  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[0],null));

  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));

  //-----
  var exprSource
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(opData.Instance);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (exprSource,
    Structure_TypeCache.TypeOf__System_String);
#endif

  //-----
  var exprArg0
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(opData.Arguments[0]);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (exprArg0,
    Structure_TypeCache.TypeOf__System_String);
#endif

  //-----
  var exprTest1__Equal
   =opData.SqlTreeNodeBuilder.Extension__MakeBinary__Equal__Throw
     (exprSource,
      exprArg0);

  Debug.Assert(!Object.ReferenceEquals(exprTest1__Equal,null));

  //-----
  var exprTest2__GreaterThan
   =opData.SqlTreeNodeBuilder.Extension__MakeBinary__GreaterThan__Throw
     (exprSource,
      exprArg0);

  Debug.Assert(!Object.ReferenceEquals(exprTest2__GreaterThan,null));

  //-----
  var exprTest3__LessThan
   =opData.SqlTreeNodeBuilder.Extension__MakeBinary__LessThan__Throw
     (exprSource,
      exprArg0);

  Debug.Assert(!Object.ReferenceEquals(exprTest3__LessThan,null));

  //-----
  var r
   =opData.SqlExpressionFactory.Case
     (
      new[]
      {
       new CaseWhenClause (exprTest1__Equal       , FB_Common__Data.sm_SqlConstantExpression__Int32__ZERO),
       new CaseWhenClause (exprTest2__GreaterThan , FB_Common__Data.sm_SqlConstantExpression__Int32__ONE),
       new CaseWhenClause (exprTest3__LessThan    , FB_Common__Data.sm_SqlConstantExpression__Int32__NEGATIVE_ONE),
      },
      /*elseResult*/null
     );

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (r,
    Structure_TypeCache.TypeOf__System_Int32);
#endif

  return r;
 }//Translate
};//class FB_Common__Sql_ETranslator__String__std__CompareTo__str

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code

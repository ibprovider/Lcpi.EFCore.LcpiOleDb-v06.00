////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 15.06.2021.
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

using Root.Query.Sql.Extensions.LcpiOleDb__ISqlTreeNodeBuilder__Extensions;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator__IEnumerableByte__vrt__Contains

sealed class FB_Common__Sql_ETranslator__IEnumerableByte__vrt__Contains
 :FB_Common__Sql_ETranslator_MethodCall
{
 public static readonly FB_Common__Sql_ETranslator_MethodCall.tagDescr
  Instance
   =new FB_Common__Sql_ETranslator_MethodCall.tagDescr
     (Structure_MethodIdCache.MethodIdOf__IEnumerableByte__vrt__Contains,
      new FB_Common__Sql_ETranslator__IEnumerableByte__vrt__Contains());

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator__IEnumerableByte__vrt__Contains()
 {
 }//FB_Common__Sql_ETranslator__IEnumerableByte__vrt__Contains

 //FB_Common__Sql_ETranslator_MethodCall interface -----------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.Instance,null));

  Debug.Assert(!Object.ReferenceEquals(opData.MethodId,null));
  Debug.Assert(opData.MethodId.Equals(Structure_MethodIdCache.MethodIdOf__IEnumerableByte__vrt__Contains));

  Debug.Assert(!Object.ReferenceEquals(opData.Arguments,null));
  Debug.Assert(opData.Arguments.Count==1);
  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[0],null));

  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));

  //-----
  var exprSource
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(opData.Instance);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (exprSource);
#endif

  //-----
  var exprArg0
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(opData.Arguments[0]);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (exprArg0,
    Structure_TypeCache.TypeOf__System_Byte);
#endif

  //----------------------------------------
  var exprAsciiChar
   =Nodes.FB_Common__Sql_ENode_Function__SQL__ASCII_CHAR.Create
    (exprArg0);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (exprAsciiChar,
    FB_Common__TypeMappingCache.TypeMapping__VARBINARY1);
#endif

  //----------------------------------------
  var exprPos
   =Nodes.FB_Common__Sql_ENode_Function__SQL__POSITION.Create
     (exprSource,
      exprAsciiChar);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (exprPos,
    Structure_TypeCache.TypeOf__System_Int32);
#endif

  //----------------------------------------
  var resultExpr
   =opData.SqlTreeNodeBuilder.Extension__MakeBinary__GreaterThan__Throw
     (exprPos,
      FB_Common__Data.sm_SqlConstantExpression__Int32__ZERO);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (resultExpr,
    Structure_TypeCache.TypeOf__System_Boolean);
#endif

  return resultExpr;
 }//Translate
};//class FB_Common__Sql_ETranslator__IEnumerableByte__vrt__Contains

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code

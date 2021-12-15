////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 27.11.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code.MS_EFCore{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

using Structure_MethodIdCache
 =Structure.Structure_MethodIdCache;

using Structure_MethodInfoCache
 =Structure.Structure_MethodInfoCache;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator__DbFunctions__ext__Like__str3

sealed class FB_Common__Sql_ETranslator__DbFunctions__ext__Like__str3
 :FB_Common__Sql_ETranslator_MethodCall
{
 public static readonly FB_Common__Sql_ETranslator_MethodCall.tagDescr
  Instance
   =new FB_Common__Sql_ETranslator_MethodCall.tagDescr
     (Structure_MethodIdCache.MethodIdOf__MS_EFCore__DbFunctions__ext__Like__match_pattern_escape,
      new FB_Common__Sql_ETranslator__DbFunctions__ext__Like__str3());

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator__DbFunctions__ext__Like__str3()
 {
 }//FB_Common__Sql_ETranslator__DbFunctions__ext__Like__str3

 //FB_Common__Sql_ETranslator_MethodCall interface -----------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(Object.ReferenceEquals(opData.Instance,null));

  Debug.Assert(!Object.ReferenceEquals(opData.MethodId,null));
  Debug.Assert(opData.MethodId.Equals(Structure_MethodInfoCache.MethodInfoOf__MS_EFCore__DbFunctions__ext__Like__match_pattern_escape));

  Debug.Assert(!Object.ReferenceEquals(opData.Arguments,null));
  Debug.Assert(opData.Arguments.Count==4);

  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[0],null));
  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[1],null));
  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[2],null));
  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[3],null));

  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));

  //----------------------------------------
  var exprMatch
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(opData.Arguments[1]);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (exprMatch,
    Structure_TypeCache.TypeOf__System_String);
#endif

  //----------------------------------------
  var exprPattern
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(opData.Arguments[2]);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (exprPattern,
    Structure_TypeCache.TypeOf__System_String);
#endif

  //----------------------------------------
  var exprEscape
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(opData.Arguments[3]);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (exprPattern,
    Structure_TypeCache.TypeOf__System_String);
#endif

  //----------------------------------------
  var result
   =Nodes.FB_Common__Sql_ENode_Function__SQL__LIKE_escape.Create
     (exprMatch,
      exprPattern,
      exprEscape);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (result,
    Structure_TypeCache.TypeOf__System_Boolean);
#endif

  return result;
 }//Translate
};//class FB_Common__Sql_ETranslator__DbFunctions__ext__Like__str3

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code.MS_EFCore

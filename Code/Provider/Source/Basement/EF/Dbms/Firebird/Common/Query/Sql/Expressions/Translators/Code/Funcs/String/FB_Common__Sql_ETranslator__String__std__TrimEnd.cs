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

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator__String__std__TrimEnd

sealed class FB_Common__Sql_ETranslator__String__std__TrimEnd
 :FB_Common__Sql_ETranslator_MethodCall
{
 public static readonly FB_Common__Sql_ETranslator_MethodCall.tagDescr
  Instance
   =new FB_Common__Sql_ETranslator_MethodCall.tagDescr
     (Structure_MethodIdCache.MethodIdOf__String__std__TrimEnd,
      new FB_Common__Sql_ETranslator__String__std__TrimEnd());

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator__String__std__TrimEnd()
 {
 }//FB_Common__Sql_ETranslator__String__std__TrimEnd

 //FB_Common__Sql_ETranslator_MethodCall interface -----------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.Instance,null));

  Debug.Assert(!Object.ReferenceEquals(opData.MethodId,null));
  Debug.Assert(opData.MethodId.Equals(Structure_MethodInfoCache.MethodInfoOf__String__std__TrimEnd));

  Debug.Assert(!Object.ReferenceEquals(opData.Arguments,null));
  Debug.Assert(opData.Arguments.Count==0);

  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));

  //---------------------------------------
  var exprSource
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(opData.Instance);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (exprSource,
    Structure_TypeCache.TypeOf__System_String);
#endif

  //---------------------------------------
  return Helper__CreateExpression_STD
          (exprSource);
 }//Translate

 //Helper methods --------------------------------------------------------
 private static SqlExpression Helper__CreateExpression_STD(SqlExpression value)
 {
  Debug.Assert(!Object.ReferenceEquals(value,null));

  return new Nodes.FB_Common__Sql_ENode_Function__SQL__TRIM_END
          (value);
 }//Helper__CreateExpression_STD
};//class FB_Common__Sql_ETranslator__String__std__TrimEnd

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code

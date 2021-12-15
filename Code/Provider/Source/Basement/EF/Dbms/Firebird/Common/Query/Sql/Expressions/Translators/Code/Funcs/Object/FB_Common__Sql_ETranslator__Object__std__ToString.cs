////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 09.12.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_MethodInfoCache
 =Structure.Structure_MethodInfoCache;

using Structure_MethodIdCache
 =Structure.Structure_MethodIdCache;

using Structure_TypeCache
 =Structure.Structure_TypeCache;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator__Object__std__ToString

sealed class FB_Common__Sql_ETranslator__Object__std__ToString
 :FB_Common__Sql_ETranslator_MethodCall
{
 public static readonly FB_Common__Sql_ETranslator_MethodCall.tagDescr
  Instance
   =new FB_Common__Sql_ETranslator_MethodCall.tagDescr
     (Structure_MethodIdCache.MethodIdOf__Object__std__ToString,
      new FB_Common__Sql_ETranslator__Object__std__ToString());

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator__Object__std__ToString()
 {
 }//FB_Common__Sql_ETranslator__Object__std__ToString

 //FB_Common__Sql_ETranslator_MethodCall interface -----------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.MethodId,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));

  Debug.Assert(opData.MethodId.Equals(Structure_MethodInfoCache.MethodInfoOf__Object__std__ToString));

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(opData.Instance,null));
  Debug.Assert(!Object.ReferenceEquals(opData.Instance.Type,null));

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(opData.Arguments,null));
  Debug.Assert(opData.Arguments.Count==0);

  //----------------------------------------
  var exprObject
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(opData.Instance);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlType
   (exprObject);
#endif

  //----------------------------------------
  var r
   =opData.SqlTreeNodeBuilder.MakeUnary
    (LcpiOleDb__ExpressionType.Convert,
     exprObject,
     Structure_TypeCache.TypeOf__System_String);

  Debug.Assert(!Object.ReferenceEquals(r,null));

  return r;
 }//Translate
};//class FB_Common__Sql_ETranslator__Object__std__ToString

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code

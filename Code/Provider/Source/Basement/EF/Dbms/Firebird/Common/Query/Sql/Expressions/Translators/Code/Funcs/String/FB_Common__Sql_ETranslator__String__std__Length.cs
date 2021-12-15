////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 18.05.2018.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

using Structure_MemberIdCache
 =Structure.Structure_MemberIdCache;

using Structure_MethodIdCache
 =Structure.Structure_MethodIdCache;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator__String__std__Length

sealed class FB_Common__Sql_ETranslator__String__std__Length
 :FB_Common__Sql_ETranslator_Member
{
 public static readonly FB_Common__Sql_ETranslator_Member.tagDescr
  Instance
   =new FB_Common__Sql_ETranslator_Member.tagDescr
     (Structure_MemberIdCache.MemberIdOf__String__std__Length,
      new FB_Common__Sql_ETranslator__String__std__Length());

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator__String__std__Length()
 {
 }//FB_Common__Sql_ETranslator__String__std__Length

 //IMemberTranslator interface -------------------------------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.Instance,null));

#if DEBUG
  opData.DEBUG_CheckMemberId(Structure_MemberIdCache.MemberIdOf__String__std__Length);
#endif

  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));

  //------------------------------------------------------------
  var exprSource
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(opData.Instance);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (exprSource,
    Structure_TypeCache.TypeOf__System_String);
#endif

  //------------------------------------------------------------
  var r
   =opData.SqlTreeNodeBuilder.MakeCall
     (Structure_MethodIdCache.MethodIdOf__BUILTIN_SQL__CHARACTER_LENGTH,
       /*sqlInstance*/null,
       new[]{exprSource});

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (r);
#endif

  return r;
 }//Translate
};//class FB_Common__Sql_ETranslator__String__std__Length

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code

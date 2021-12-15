////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 18.07.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_MemberIdCache
 =Structure.Structure_MemberIdCache;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator__TimeOnly__std__Millisecond

sealed class FB_Common__Sql_ETranslator__TimeOnly__std__Millisecond
 :FB_Common__Sql_ETranslator_Member
{
 public static readonly FB_Common__Sql_ETranslator_Member.tagDescr
  Instance
   =new FB_Common__Sql_ETranslator_Member.tagDescr
     (Structure_MemberIdCache.MemberIdOf__TimeOnly__std__Millisecond,
      new FB_Common__Sql_ETranslator__TimeOnly__std__Millisecond());

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator__TimeOnly__std__Millisecond()
 {
 }//FB_Common__Sql_ETranslator__TimeOnly__std__Millisecond

 //IMemberTranslator interface -------------------------------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.Instance,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));

#if DEBUG
  opData.DEBUG_CheckMemberId(Structure_MemberIdCache.MemberIdOf__TimeOnly__std__Millisecond);
#endif

  //------------------------------------------------------------
  var Expression
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(opData.Instance);

  Debug.Assert(!Object.ReferenceEquals(Expression,null));
  Debug.Assert(!Object.ReferenceEquals(Expression.Type,null));
  Debug.Assert(!Object.ReferenceEquals(Expression.TypeMapping,null));

  //------------------------------------------------------------
  var nodeResult
   =Internal.FB_Common__Sql_EBuilder__ExtractMillisecond.Exec
     (Expression);

  Debug.Assert(!Object.ReferenceEquals(nodeResult,null));
  Debug.Assert(!Object.ReferenceEquals(nodeResult.Type,null));
  Debug.Assert(!Object.ReferenceEquals(nodeResult.TypeMapping,null));

  return nodeResult;
 }//Translate
};//class FB_Common__Sql_ETranslator__TimeOnly__std__Millisecond

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code

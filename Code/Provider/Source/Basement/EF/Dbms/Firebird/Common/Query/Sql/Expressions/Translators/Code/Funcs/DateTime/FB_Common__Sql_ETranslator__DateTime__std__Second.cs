////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 26.03.2019.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_MemberIdCache
 =Structure.Structure_MemberIdCache;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator__DateTime__std__Second

sealed class FB_Common__Sql_ETranslator__DateTime__std__Second
 :FB_Common__Sql_ETranslator_Member
{
 public static readonly FB_Common__Sql_ETranslator_Member.tagDescr
  Instance
   =new FB_Common__Sql_ETranslator_Member.tagDescr
     (Structure_MemberIdCache.MemberIdOf__DateTime__std__Second,
      new FB_Common__Sql_ETranslator__DateTime__std__Second());

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator__DateTime__std__Second()
 {
 }//FB_Common__Sql_ETranslator__DateTime__std__Second

 //IMemberTranslator interface -------------------------------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.Instance,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));

#if DEBUG
  opData.DEBUG_CheckMemberId(Structure_MemberIdCache.MemberIdOf__DateTime__std__Second);
#endif

  //------------------------------------------------------------
  var Expression
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(opData.Instance);

  Debug.Assert(!Object.ReferenceEquals(Expression,null));
  Debug.Assert(!Object.ReferenceEquals(Expression.Type,null));
  Debug.Assert(!Object.ReferenceEquals(Expression.TypeMapping,null));

  //------------------------------------------------------------
  var nodeResult
   =Internal.FB_Common__Sql_EBuilder__ExtractSecond.Exec
     (Expression);

  Debug.Assert(!Object.ReferenceEquals(nodeResult,null));
  Debug.Assert(!Object.ReferenceEquals(nodeResult.Type,null));
  Debug.Assert(!Object.ReferenceEquals(nodeResult.TypeMapping,null));

  return nodeResult;
 }//Translate
};//class FB_Common__Sql_ETranslator__DateTime__std__Second

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code

////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 09.10.2018.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_MemberIdCache
 =Structure.Structure_MemberIdCache;

using Structure_TypeCache
 =Structure.Structure_TypeCache;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator__DateTime__std__Now__through_CURRENT_TIMESTAMP

sealed class FB_Common__Sql_ETranslator__DateTime__std__Now__through_CURRENT_TIMESTAMP
 :FB_Common__Sql_ETranslator_Member
{
 public static readonly FB_Common__Sql_ETranslator_Member.tagDescr
  Instance
   =new FB_Common__Sql_ETranslator_Member.tagDescr
     (Structure_MemberIdCache.MemberIdOf__DateTime__std__Now,
      new FB_Common__Sql_ETranslator__DateTime__std__Now__through_CURRENT_TIMESTAMP());

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator__DateTime__std__Now__through_CURRENT_TIMESTAMP()
 {
 }//FB_Common__Sql_ETranslator__DateTime__std__Now__through_CURRENT_TIMESTAMP

 //IMemberTranslator interface -------------------------------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(Object.ReferenceEquals(opData.Instance,null));

#if DEBUG
  opData.DEBUG_CheckMemberId(Structure_MemberIdCache.MemberIdOf__DateTime__std__Now);
#endif

  return Nodes.FB_Common__Sql_ENode_Function__SQL__CURRENT_TIMESTAMP.Create();
 }//Translate
};//class FB_Common__Sql_ETranslator__DateTime__std__Now__through_CURRENT_TIMESTAMP

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code

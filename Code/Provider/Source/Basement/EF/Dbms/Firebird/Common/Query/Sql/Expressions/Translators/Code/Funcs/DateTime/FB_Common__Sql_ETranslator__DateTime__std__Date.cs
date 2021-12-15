////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 17.09.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_MemberIdCache
 =Structure.Structure_MemberIdCache;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator__DateTime__std__Date

sealed class FB_Common__Sql_ETranslator__DateTime__std__Date
 :FB_Common__Sql_ETranslator_Member
{
 public static readonly FB_Common__Sql_ETranslator_Member.tagDescr
  Instance
   =new FB_Common__Sql_ETranslator_Member.tagDescr
     (Structure_MemberIdCache.MemberIdOf__DateTime__std__Date,
      new FB_Common__Sql_ETranslator__DateTime__std__Date());

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator__DateTime__std__Date()
 {
 }//FB_Common__Sql_ETranslator__DateTime__std__Date

 //IMemberTranslator interface -------------------------------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.Instance,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));

#if DEBUG
  opData.DEBUG_CheckMemberId(Structure_MemberIdCache.MemberIdOf__DateTime__std__Date);
#endif

  //------------------------------------------------------------
  var exprInstance
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(opData.Instance);

  Debug.Assert(!Object.ReferenceEquals(exprInstance,null));
  Debug.Assert(!Object.ReferenceEquals(exprInstance.Type,null));
  Debug.Assert(!Object.ReferenceEquals(exprInstance.TypeMapping,null));

  //------------------------------------------------------------
  var exprResult
   =opData.SqlTreeNodeBuilder.MakeCall
     (Structure.Structure_MethodIdCache.MethodIdOf__DateTime__ext__ExtractDate,
      /*instance*/null,
      new[]{exprInstance});

  Debug.Assert(!Object.ReferenceEquals(exprResult,null));

  //------------------------------------------------------------
  return exprResult;
 }//Translate
};//class FB_Common__Sql_ETranslator__DateTime__std__Date

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code

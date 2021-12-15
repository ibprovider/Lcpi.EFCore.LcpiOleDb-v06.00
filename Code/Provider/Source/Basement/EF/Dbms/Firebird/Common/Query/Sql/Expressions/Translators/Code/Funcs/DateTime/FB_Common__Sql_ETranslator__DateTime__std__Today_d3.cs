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

using Structure_TypeCache
 =Structure.Structure_TypeCache;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator__DateTime__std__Today_d3

sealed class FB_Common__Sql_ETranslator__DateTime__std__Today_d3
 :FB_Common__Sql_ETranslator_Member
{
 public static readonly FB_Common__Sql_ETranslator_Member.tagDescr
  Instance
   =new FB_Common__Sql_ETranslator_Member.tagDescr
     (Structure_MemberIdCache.MemberIdOf__DateTime__std__Today,
      new FB_Common__Sql_ETranslator__DateTime__std__Today_d3());

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator__DateTime__std__Today_d3()
 {
 }//FB_Common__Sql_ETranslator__DateTime__std__Today_d3

 //IMemberTranslator interface -------------------------------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(Object.ReferenceEquals(opData.Instance,null));

#if DEBUG
  opData.DEBUG_CheckMemberId(Structure_MemberIdCache.MemberIdOf__DateTime__std__Today);
#endif

  if(Object.ReferenceEquals(sm_SingleSubTreeInstance,null))
  {
   System.Threading.Interlocked.CompareExchange
    (ref sm_SingleSubTreeInstance,
     Helper__CreateENodeTree(opData),
     null);
  }//if

  Debug.Assert(!Object.ReferenceEquals(sm_SingleSubTreeInstance,null));

  return sm_SingleSubTreeInstance;
 }//Translate

 //Helper methods --------------------------------------------------------
 private static SqlExpression Helper__CreateENodeTree(in tagOpData opData)
 {
  var expr1_CURRENT_DATE
   =Nodes.FB_Common__Sql_ENode_Function__SQL__CURRENT_DATE_d3.Create();

  //cast to TIMESTAMP
  var expr5__CAST_TO_TIMESTAMP
   =Nodes.FB_Common__Sql_ENode_Function__SQL__CAST_AS.Create
     (expr1_CURRENT_DATE,
      FB_Common__TypeMappingCache.TypeMapping__TIMESTAMP);

  Debug.Assert(!Object.ReferenceEquals(expr5__CAST_TO_TIMESTAMP,null));

  return expr5__CAST_TO_TIMESTAMP;
 }//Helper__CreateENodeTree

 //private data ----------------------------------------------------------
 private static SqlExpression
  sm_SingleSubTreeInstance
   =null;
};//class FB_Common__Sql_ETranslator__DateTime__std__Today_d3

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code

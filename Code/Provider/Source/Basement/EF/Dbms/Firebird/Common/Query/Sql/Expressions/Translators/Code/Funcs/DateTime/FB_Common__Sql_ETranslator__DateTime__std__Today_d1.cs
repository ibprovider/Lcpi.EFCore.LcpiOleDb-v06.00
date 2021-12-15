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
//class FB_Common__Sql_ETranslator__DateTime__std__Today_d1

sealed class FB_Common__Sql_ETranslator__DateTime__std__Today_d1
 :FB_Common__Sql_ETranslator_Member
{
 public static readonly FB_Common__Sql_ETranslator_Member.tagDescr
  Instance
   =new FB_Common__Sql_ETranslator_Member.tagDescr
     (Structure_MemberIdCache.MemberIdOf__DateTime__std__Today,
      new FB_Common__Sql_ETranslator__DateTime__std__Today_d1());

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator__DateTime__std__Today_d1()
 {
 }//FB_Common__Sql_ETranslator__DateTime__std__Today_d1

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
  var expr1_CURRENT_TIMESTAMP
   =Nodes.FB_Common__Sql_ENode_Function__SQL__CURRENT_TIMESTAMP.Create();

  var array_with_expr1
   =new SqlExpression[]
    {
     expr1_CURRENT_TIMESTAMP
    };

  var expr2_PartYear
   =opData.SqlTreeNodeBuilder.MakeCall
     (Structure.Structure_MethodIdCache.MethodIdOf__DateTime__ext__ExtractYear,
      /*instance*/null,
      array_with_expr1);

  var expr2_PartMonth
   =opData.SqlTreeNodeBuilder.MakeCall
     (Structure.Structure_MethodIdCache.MethodIdOf__DateTime__ext__ExtractMonth,
      /*instance*/null,
      array_with_expr1);

  var expr2_PartDay
   =opData.SqlTreeNodeBuilder.MakeCall
     (Structure.Structure_MethodIdCache.MethodIdOf__DateTime__ext__ExtractDay,
      /*instance*/null,
      array_with_expr1);

  var expr3_Defis
   =FB_Common__Data.sm_SqlConstantExpression__VARCHAR___DEFIS;

  //concatenations
  var expr4_1
   =Nodes.FB_Common__Sql_ENode_Function__SQL__OP_CONCAT.Create
     (expr2_PartYear,
      expr3_Defis);

  var expr4_2
   =Nodes.FB_Common__Sql_ENode_Function__SQL__OP_CONCAT.Create
     (expr4_1,
      expr2_PartMonth);

  var expr4_3
   =Nodes.FB_Common__Sql_ENode_Function__SQL__OP_CONCAT.Create
     (expr4_2,
      expr3_Defis);

  var expr4_4
   =Nodes.FB_Common__Sql_ENode_Function__SQL__OP_CONCAT.Create
     (expr4_3,
      expr2_PartDay);

  //cast to TIMESTAMP
  var expr5__CAST_TO_TIMESTAMP
   =Nodes.FB_Common__Sql_ENode_Function__SQL__CAST_AS.Create
     (expr4_4,
      FB_Common__TypeMappingCache.TypeMapping__TIMESTAMP);

  Debug.Assert(!Object.ReferenceEquals(expr5__CAST_TO_TIMESTAMP,null));

  return expr5__CAST_TO_TIMESTAMP;
 }//Helper__CreateENodeTree

 //private data ----------------------------------------------------------
 private static SqlExpression
  sm_SingleSubTreeInstance
   =null;
};//class FB_Common__Sql_ETranslator__DateTime__std__Today_d1

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code

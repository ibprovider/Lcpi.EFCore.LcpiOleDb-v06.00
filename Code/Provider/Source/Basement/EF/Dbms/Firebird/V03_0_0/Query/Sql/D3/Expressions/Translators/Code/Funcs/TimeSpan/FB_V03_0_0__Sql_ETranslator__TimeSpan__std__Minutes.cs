////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 30.09.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D3.Expressions.Translators.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_MemberIdCache
 =Structure.Structure_MemberIdCache;

using FB_Common__Sql_ETranslator_Member
 =Common.Query.Sql.Expressions.Translators.FB_Common__Sql_ETranslator_Member;

using FB_Common__Data
 =Common.FB_Common__Data;

using FB_Common__TypeMappingCache
 =Common.FB_Common__TypeMappingCache;

////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0__Sql_ETranslator__TimeSpan__std__Minutes

sealed class FB_V03_0_0__Sql_ETranslator__TimeSpan__std__Minutes
 :FB_Common__Sql_ETranslator_Member
{
 public static readonly FB_Common__Sql_ETranslator_Member.tagDescr
  Instance
   =new FB_Common__Sql_ETranslator_Member.tagDescr
     (Structure_MemberIdCache.MemberIdOf__TimeSpan__std__Minutes,
      new FB_V03_0_0__Sql_ETranslator__TimeSpan__std__Minutes());

 //-----------------------------------------------------------------------
 private FB_V03_0_0__Sql_ETranslator__TimeSpan__std__Minutes()
 {
 }//FB_V03_0_0__Sql_ETranslator__TimeSpan__std__Minutes

 //IMemberTranslator interface -------------------------------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.Instance,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));

#if DEBUG
  opData.DEBUG_CheckMemberId(Structure_MemberIdCache.MemberIdOf__TimeSpan__std__Minutes);
#endif

  //------------------------------------------------------------
  var exprInstance
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(opData.Instance);

  Debug.Assert(!Object.ReferenceEquals(exprInstance,null));
  Debug.Assert(!Object.ReferenceEquals(exprInstance.Type,null));
  Debug.Assert(!Object.ReferenceEquals(exprInstance.TypeMapping,null));

  //------------------------------------------------------------

  //
  // Generated SQL:
  //  - CAST( ( (TRUNC(exprInstance) MOD secondInHour) DIV secondInMinute) AS INTEGER)
  //
  // Expected result:
  //  - INTEGER
  //

  //------------------------------------------------------------
  var expr1_Trunc
   =Common.Query.Sql.Expressions.Nodes.FB_Common__Sql_ENode_Function__SQL__TRUNC.Create
     (exprInstance);

  Debug.Assert(!Object.ReferenceEquals(expr1_Trunc,null));

  //------------------------------------------------------------
  var expr2_MOD
   =Common.Query.Sql.Expressions.Nodes.FB_Common__Sql_ENode_Function__SQL__MOD.Create
     (expr1_Trunc,
      FB_Common__Data.sm_SqlConstantExpression__Int32__SecondsInHour);

  Debug.Assert(!Object.ReferenceEquals(expr2_MOD,null));

  //------------------------------------------------------------

  //
  // Direct usage of DIV with abstract (DECIMAL) result.
  //

  var expr3_DIV
   =Common.Query.Sql.Expressions.Nodes.FB_Common__Sql_ENode_Function__SQL__OP_DIV.Create
     (expr2_MOD,
      FB_Common__Data.sm_SqlConstantExpression__Int32__SecondsInMinute,
      FB_Common__TypeMappingCache.TypeMapping__DECIMAL);

  Debug.Assert(!Object.ReferenceEquals(expr3_DIV,null));

  //------------------------------------------------------------
  var expr4_CAST
   =Common.Query.Sql.Expressions.Nodes.FB_Common__Sql_ENode_Function__SQL__CAST_AS.Create
     (expr3_DIV,
      FB_Common__TypeMappingCache.TypeMapping__INT32);

  Debug.Assert(!Object.ReferenceEquals(expr4_CAST,null));

  return expr4_CAST;
 }//Translate
};//class FB_V03_0_0__Sql_ETranslator__TimeSpan__std__Minutes

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D3.Expressions.Translators.Code

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
//class FB_V03_0_0__Sql_ETranslator__TimeSpan__std__Milliseconds

sealed class FB_V03_0_0__Sql_ETranslator__TimeSpan__std__Milliseconds
 :FB_Common__Sql_ETranslator_Member
{
 public static readonly FB_Common__Sql_ETranslator_Member.tagDescr
  Instance
   =new FB_Common__Sql_ETranslator_Member.tagDescr
     (Structure_MemberIdCache.MemberIdOf__TimeSpan__std__Milliseconds,
      new FB_V03_0_0__Sql_ETranslator__TimeSpan__std__Milliseconds());

 //-----------------------------------------------------------------------
 private FB_V03_0_0__Sql_ETranslator__TimeSpan__std__Milliseconds()
 {
 }//FB_V03_0_0__Sql_ETranslator__TimeSpan__std__Milliseconds

 //IMemberTranslator interface -------------------------------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.Instance,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));

#if DEBUG
  opData.DEBUG_CheckMemberId(Structure_MemberIdCache.MemberIdOf__TimeSpan__std__Milliseconds);
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
  //  - CAST( TRUNC( ( exprInstance SUB TRUNC(exprInstance) ) MULT MillisecondInSecond) AS INTEGER)
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
  //
  // Direct usage of SUB with abstract (DECIMAL) result.
  //

  var expr2_SUB
   =Common.Query.Sql.Expressions.Nodes.FB_Common__Sql_ENode_Function__SQL__OP_SUB.Create
     (exprInstance,
      expr1_Trunc,
      FB_Common__TypeMappingCache.TypeMapping__DECIMAL);

  Debug.Assert(!Object.ReferenceEquals(expr2_SUB,null));

  //------------------------------------------------------------
  //
  // Direct usage of MUL with abstract (DECIMAL) result.
  //

  var expr3_MUL
   =Common.Query.Sql.Expressions.Nodes.FB_Common__Sql_ENode_Function__SQL__OP_MUL.Create
     (expr2_SUB,
      FB_Common__Data.sm_SqlConstantExpression__Int32__MillisecondsInSecond,
      FB_Common__TypeMappingCache.TypeMapping__DECIMAL);

  Debug.Assert(!Object.ReferenceEquals(expr3_MUL,null));

  //------------------------------------------------------------
  var expr4_Trunc
   =Common.Query.Sql.Expressions.Nodes.FB_Common__Sql_ENode_Function__SQL__TRUNC.Create
     (expr3_MUL);

  Debug.Assert(!Object.ReferenceEquals(expr4_Trunc,null));

  //------------------------------------------------------------
  var expr5_CAST
   =Common.Query.Sql.Expressions.Nodes.FB_Common__Sql_ENode_Function__SQL__CAST_AS.Create
     (expr4_Trunc,
      FB_Common__TypeMappingCache.TypeMapping__INT32);

  Debug.Assert(!Object.ReferenceEquals(expr5_CAST,null));

  return expr5_CAST;
 }//Translate
};//class FB_V03_0_0__Sql_ETranslator__TimeSpan__std__Milliseconds

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D3.Expressions.Translators.Code

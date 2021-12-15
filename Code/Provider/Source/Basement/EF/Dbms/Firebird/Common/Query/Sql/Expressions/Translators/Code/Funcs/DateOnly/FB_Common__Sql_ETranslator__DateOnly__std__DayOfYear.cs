////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 14.07.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_MemberIdCache
 =Structure.Structure_MemberIdCache;

using Root.Query.Sql.Extensions.LcpiOleDb__ISqlTreeNodeBuilder__Extensions;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator__DateOnly__std__DayOfYear

sealed class FB_Common__Sql_ETranslator__DateOnly__std__DayOfYear
 :FB_Common__Sql_ETranslator_Member
{
 public static readonly FB_Common__Sql_ETranslator_Member.tagDescr
  Instance
   =new FB_Common__Sql_ETranslator_Member.tagDescr
     (Structure_MemberIdCache.MemberIdOf__DateOnly__std__DayOfYear,
      new FB_Common__Sql_ETranslator__DateOnly__std__DayOfYear());

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator__DateOnly__std__DayOfYear()
 {
 }//FB_Common__Sql_ETranslator__DateOnly__std__DayOfYear

 //IMemberTranslator interface -------------------------------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.Instance,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlTreeNodeBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));

#if DEBUG
  opData.DEBUG_CheckMemberId(Structure_MemberIdCache.MemberIdOf__DateOnly__std__DayOfYear);
#endif

  //------------------------------------------------------------
  var Expression
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(opData.Instance);

  Debug.Assert(!Object.ReferenceEquals(Expression,null));
  Debug.Assert(!Object.ReferenceEquals(Expression.Type,null));
  Debug.Assert(!Object.ReferenceEquals(Expression.TypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(Expression.TypeMapping.ClrType,null));

  //------------------------------------------------------------
  var nodeExtract
   =Nodes.FB_Common__Sql_ENode_Function__SQL__EXTRACT.Create
     (Expression,
      "YEARDAY");

  Debug.Assert(!Object.ReferenceEquals(nodeExtract,null));
  Debug.Assert(!Object.ReferenceEquals(nodeExtract.Type,null));
  Debug.Assert(!Object.ReferenceEquals(nodeExtract.TypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(nodeExtract.TypeMapping.ClrType,null));

  //------------------------------------------------------------
  var nodeResult
   =opData.SqlTreeNodeBuilder.Extension__MakeBinary__Add__Throw
     (nodeExtract,
      FB_Common__Data.sm_SqlConstantExpression__Int32__ONE);

  Debug.Assert(!Object.ReferenceEquals(nodeResult,null));
  Debug.Assert(!Object.ReferenceEquals(nodeResult.Type,null));
  Debug.Assert(!Object.ReferenceEquals(nodeResult.TypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(nodeResult.TypeMapping.ClrType,null));

  //------------------------------------------------------------
  return nodeResult;
 }//Translate
};//class FB_Common__Sql_ETranslator__DateOnly__std__DayOfYear

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code

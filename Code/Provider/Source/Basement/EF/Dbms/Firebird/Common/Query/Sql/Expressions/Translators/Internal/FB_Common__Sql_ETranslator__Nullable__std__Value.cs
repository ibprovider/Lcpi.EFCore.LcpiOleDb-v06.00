////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 23.10.2020.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Internal{
////////////////////////////////////////////////////////////////////////////////

using Root.Query.Sql.Extensions.LcpiOleDb__ISqlTreeNodeBuilder__Extensions;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator__Nullable__std__Value

sealed class FB_Common__Sql_ETranslator__Nullable__std__Value
 :FB_Common__Sql_ETranslator_Member
{
 public FB_Common__Sql_ETranslator__Nullable__std__Value
                                           (RelationalTypeMapping valueTypeMapping)
 {
  Debug.Assert(!Object.ReferenceEquals(valueTypeMapping,null));

  //----------------------------------------
  m_ValueTypeMapping=valueTypeMapping;
 }//FB_Common__Sql_ETranslator__Nullable__std__Value

 //IMemberTranslator interface -------------------------------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.Instance,null));

#if DEBUG
  //opData.DEBUG_CheckMemberId(this.MemberId);
#endif

  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));

  //------------------------------------------------------------
  var exprValue
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(opData.Instance);

  Debug.Assert(!Object.ReferenceEquals(exprValue,null));
  Debug.Assert(!Object.ReferenceEquals(exprValue.Type,null));
  Debug.Assert(!Object.ReferenceEquals(exprValue.TypeMapping,null));

  //------------------------------------------------------------
  var exprBadCast
   =Nodes.FB_Common__Sql_ENode_Function__SQL__CAST_AS.Create
     (FB_Common__Data.sm_SqlConstantExpression__VARCHAR___TRAP_FOR_NULL,
      m_ValueTypeMapping);

  Debug.Assert(!Object.ReferenceEquals(exprBadCast,null));
  Debug.Assert(!Object.ReferenceEquals(exprBadCast.Type,null));
  Debug.Assert(!Object.ReferenceEquals(exprBadCast.TypeMapping,null));

  //------------------------------------------------------------
  var exprResult
   =opData.SqlTreeNodeBuilder.Extension__MakeBinary__Coalesce__Throw
     (exprValue,
      exprBadCast);

  Debug.Assert(!Object.ReferenceEquals(exprResult,null));
  Debug.Assert(!Object.ReferenceEquals(exprResult.Type,null));
  Debug.Assert(!Object.ReferenceEquals(exprResult.TypeMapping,null));

  return exprResult;
 }//Translate

 //private data ----------------------------------------------------------
 private readonly RelationalTypeMapping m_ValueTypeMapping;
};//class FB_Common__Sql_ETranslator__Nullable__std__Value

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Internal

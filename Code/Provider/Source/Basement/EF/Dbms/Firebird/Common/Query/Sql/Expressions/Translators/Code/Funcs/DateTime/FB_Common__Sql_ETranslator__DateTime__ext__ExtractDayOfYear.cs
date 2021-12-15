////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 27.03.2019.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_MethodInfoCache
 =Structure.Structure_MethodInfoCache;

using Structure_MethodIdCache
 =Structure.Structure_MethodIdCache;

using Structure_TypeCache
 =Structure.Structure_TypeCache;

using Root.Query.Sql.Extensions.LcpiOleDb__ISqlTreeNodeBuilder__Extensions;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator__DateTime__ext__ExtractDayOfYear

sealed class FB_Common__Sql_ETranslator__DateTime__ext__ExtractDayOfYear
 :FB_Common__Sql_ETranslator_MethodCall
{
 public static readonly FB_Common__Sql_ETranslator_MethodCall.tagDescr
  Instance
   =new FB_Common__Sql_ETranslator_MethodCall.tagDescr
     (Structure_MethodIdCache.MethodIdOf__DateTime__ext__ExtractDayOfYear,
      new FB_Common__Sql_ETranslator__DateTime__ext__ExtractDayOfYear());

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator__DateTime__ext__ExtractDayOfYear()
 {
 }//FB_Common__Sql_ETranslator__DateTime__ext__ExtractDayOfYear

 //FB_Common__Sql_ETranslator_MethodCall interface -----------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.MethodId,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlTreeNodeBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));

  Debug.Assert(opData.MethodId.Equals(Structure_MethodInfoCache.MethodInfoOf__DateTime__ext__ExtractDayOfYear));

  //----------------------------------------
  Debug.Assert(Object.ReferenceEquals(opData.Instance,null));

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(opData.Arguments,null));
  Debug.Assert(opData.Arguments.Count==1);

  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[0],null));

  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[0].Type,null));

  Debug.Assert(opData.Arguments[0].Type==Structure_TypeCache.TypeOf__System_DateTime);

  //----------------------------------------
  var exprArg0
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(opData.Arguments[0]);

  Debug.Assert(!Object.ReferenceEquals(exprArg0,null));
  Debug.Assert(!Object.ReferenceEquals(exprArg0.Type,null));
  Debug.Assert(!Object.ReferenceEquals(exprArg0.TypeMapping,null));

  Debug.Assert(exprArg0.Type==Structure_TypeCache.TypeOf__System_DateTime);

  //----------------------------------------
  var nodeExtract
   =Nodes.FB_Common__Sql_ENode_Function__SQL__EXTRACT.Create
     (exprArg0,
      "YEARDAY");

  Debug.Assert(!Object.ReferenceEquals(nodeExtract,null));
  Debug.Assert(!Object.ReferenceEquals(nodeExtract.Type,null));
  Debug.Assert(!Object.ReferenceEquals(nodeExtract.TypeMapping,null));

  //----------------------------------------
  var nodeResult
   =opData.SqlTreeNodeBuilder.Extension__MakeBinary__Add__Throw
     (nodeExtract,
      FB_Common__Data.sm_SqlConstantExpression__Int32__ONE);

  Debug.Assert(!Object.ReferenceEquals(nodeResult,null));
  Debug.Assert(!Object.ReferenceEquals(nodeResult.Type,null));
  Debug.Assert(!Object.ReferenceEquals(nodeResult.TypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(nodeResult.TypeMapping.ClrType,null));

  //----------------------------------------
  return nodeResult;
 }//Translate
};//class FB_Common__Sql_ETranslator__DateTime__ext__ExtractDayOfYear

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code

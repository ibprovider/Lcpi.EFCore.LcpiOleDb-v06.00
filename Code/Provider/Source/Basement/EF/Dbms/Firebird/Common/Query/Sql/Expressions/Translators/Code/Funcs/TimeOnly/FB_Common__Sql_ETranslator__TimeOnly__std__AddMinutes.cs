////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 18.07.2021.
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

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator__TimeOnly__std__AddMinutes

sealed class FB_Common__Sql_ETranslator__TimeOnly__std__AddMinutes
 :FB_Common__Sql_ETranslator_MethodCall
{
 public static readonly FB_Common__Sql_ETranslator_MethodCall.tagDescr
  Instance
   =new FB_Common__Sql_ETranslator_MethodCall.tagDescr
     (Structure_MethodIdCache.MethodIdOf__TimeOnly__std__AddMinutes,
      new FB_Common__Sql_ETranslator__TimeOnly__std__AddMinutes());

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator__TimeOnly__std__AddMinutes()
 {
 }//FB_Common__Sql_ETranslator__TimeOnly__std__AddMinutes

 //FB_Common__Sql_ETranslator_MethodCall interface -----------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.MethodId,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));

  Debug.Assert(opData.MethodId.Equals(Structure_MethodInfoCache.MethodInfoOf__TimeOnly__std__AddMinutes));

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(opData.Instance,null));
  Debug.Assert(!Object.ReferenceEquals(opData.Instance.Type,null));

  Debug.Assert(opData.Instance.Type==Structure_TypeCache.TypeOf__System_TimeOnly);

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(opData.Arguments,null));
  Debug.Assert(opData.Arguments.Count==1);

  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[0],null));
  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[0].Type,null));

  Debug.Assert(opData.Arguments[0].Type==Structure_TypeCache.TypeOf__System_Double);

  //----------------------------------------
  var exprObject
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(opData.Instance);

  Debug.Assert(!Object.ReferenceEquals(exprObject,null));
  Debug.Assert(!Object.ReferenceEquals(exprObject.Type,null));
  Debug.Assert(!Object.ReferenceEquals(exprObject.TypeMapping,null));

  Debug.Assert(exprObject.Type==Structure_TypeCache.TypeOf__System_TimeOnly);

  //----------------------------------------
  var exprArg0
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(opData.Arguments[0]);

  Debug.Assert(!Object.ReferenceEquals(exprArg0,null));
  Debug.Assert(!Object.ReferenceEquals(exprArg0.Type,null));
  Debug.Assert(!Object.ReferenceEquals(exprArg0.TypeMapping,null));

  Debug.Assert(exprArg0.Type==Structure_TypeCache.TypeOf__System_Double);

  //----------------------------------------
  var exprScale
   =FB_Common__Data.sm_SqlConstantExpression__Int32__MillisecondsInMinute;

  Debug.Assert(!Object.ReferenceEquals(exprScale,null));
  Debug.Assert(!Object.ReferenceEquals(exprScale.Type,null));
  Debug.Assert(!Object.ReferenceEquals(exprScale.TypeMapping,null));

  //----------------------------------------
  var resultTypeMapping
   =opData.SqlExpressionFactory.GetTypeMapping__Throw
     (Structure_TypeCache.TypeOf__System_TimeOnly);

  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));

  //----------------------------------------
  var r
   =Nodes.FB_Common__Sql_ENode_Function__SQL__DATEADD.Create4
     (opData.SqlTreeNodeBuilder,
      exprObject,
      exprArg0,
      exprScale,
      resultTypeMapping);

  Debug.Assert(!Object.ReferenceEquals(r,null));
  Debug.Assert(!Object.ReferenceEquals(r.Type,null));
  Debug.Assert(!Object.ReferenceEquals(r.TypeMapping,null));

  Debug.Assert(r.Type==Structure_TypeCache.TypeOf__System_TimeOnly);
  Debug.Assert(r.TypeMapping.ClrType==Structure_TypeCache.TypeOf__System_TimeOnly);

  return r;
 }//Translate
};//class FB_Common__Sql_ETranslator__TimeOnly__std__AddMinutes

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code

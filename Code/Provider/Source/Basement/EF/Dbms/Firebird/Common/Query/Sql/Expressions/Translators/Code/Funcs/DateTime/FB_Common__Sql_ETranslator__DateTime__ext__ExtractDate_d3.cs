////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 19.09.2021.
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
//class FB_Common__Sql_ETranslator__DateTime__ext__ExtractDate_d3

sealed class FB_Common__Sql_ETranslator__DateTime__ext__ExtractDate_d3
 :FB_Common__Sql_ETranslator_MethodCall
{
 public static readonly FB_Common__Sql_ETranslator_MethodCall.tagDescr
  Instance
   =new FB_Common__Sql_ETranslator_MethodCall.tagDescr
     (Structure_MethodIdCache.MethodIdOf__DateTime__ext__ExtractDate,
      new FB_Common__Sql_ETranslator__DateTime__ext__ExtractDate_d3());

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator__DateTime__ext__ExtractDate_d3()
 {
 }//FB_Common__Sql_ETranslator__DateTime__ext__ExtractDate_d3

 //FB_Common__Sql_ETranslator_MethodCall interface -----------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.MethodId,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));

  Debug.Assert(opData.MethodId.Equals(Structure_MethodInfoCache.MethodInfoOf__DateTime__ext__ExtractDate));

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

  //------------------------------------------------------------
  var typeMapping1
   =opData.SqlExpressionFactory.GetTypeMapping__Throw
     (Structure.Structure_TypeCache.TypeOf__System_DateOnly);

  Debug.Assert(!Object.ReferenceEquals(typeMapping1,null));

  var expr1
   =Nodes.FB_Common__Sql_ENode_Function__SQL__CAST_AS.Create
     (exprArg0,
      typeMapping1);

  Debug.Assert(!Object.ReferenceEquals(expr1,null));

  //------------------------------------------------------------
  var typeMapping2
   =opData.SqlExpressionFactory.GetTypeMapping__Throw
     (Structure.Structure_TypeCache.TypeOf__System_DateTime);

  Debug.Assert(!Object.ReferenceEquals(typeMapping1,null));

  var expr2
   =Nodes.FB_Common__Sql_ENode_Function__SQL__CAST_AS.Create
     (expr1,
      typeMapping2);

  Debug.Assert(!Object.ReferenceEquals(expr2,null));

  //------------------------------------------------------------
  return expr2;
 }//Translate
};//class FB_Common__Sql_ETranslator__DateTime__ext__ExtractDate_d3

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code

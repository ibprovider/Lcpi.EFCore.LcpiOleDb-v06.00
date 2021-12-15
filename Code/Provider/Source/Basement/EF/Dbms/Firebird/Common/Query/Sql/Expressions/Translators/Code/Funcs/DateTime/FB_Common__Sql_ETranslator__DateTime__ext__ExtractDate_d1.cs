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
//class FB_Common__Sql_ETranslator__DateTime__ext__ExtractDate_d1

sealed class FB_Common__Sql_ETranslator__DateTime__ext__ExtractDate_d1
 :FB_Common__Sql_ETranslator_MethodCall
{
 public static readonly FB_Common__Sql_ETranslator_MethodCall.tagDescr
  Instance
   =new FB_Common__Sql_ETranslator_MethodCall.tagDescr
     (Structure_MethodIdCache.MethodIdOf__DateTime__ext__ExtractDate,
      new FB_Common__Sql_ETranslator__DateTime__ext__ExtractDate_d1());

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator__DateTime__ext__ExtractDate_d1()
 {
 }//FB_Common__Sql_ETranslator__DateTime__ext__ExtractDate_d1

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
  var array_with_expr1
   =new SqlExpression[]
    {
     exprArg0
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

  //------------------------------------------------------------
  return expr5__CAST_TO_TIMESTAMP;
 }//Translate
};//class FB_Common__Sql_ETranslator__DateTime__ext__ExtractDate_d1

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code

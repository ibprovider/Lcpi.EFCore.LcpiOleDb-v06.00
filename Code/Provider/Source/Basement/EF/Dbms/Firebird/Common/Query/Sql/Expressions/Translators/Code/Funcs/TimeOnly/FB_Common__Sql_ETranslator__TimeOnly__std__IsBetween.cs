////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 04.09.2021.
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
//class FB_Common__Sql_ETranslator__TimeOnly__std__IsBetween

sealed class FB_Common__Sql_ETranslator__TimeOnly__std__IsBetween
 :FB_Common__Sql_ETranslator_MethodCall
{
 public static readonly FB_Common__Sql_ETranslator_MethodCall.tagDescr
  Instance
   =new FB_Common__Sql_ETranslator_MethodCall.tagDescr
     (Structure_MethodIdCache.MethodIdOf__TimeOnly__std__IsBetween,
      new FB_Common__Sql_ETranslator__TimeOnly__std__IsBetween());

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator__TimeOnly__std__IsBetween()
 {
 }//FB_Common__Sql_ETranslator__TimeOnly__std__IsBetween

 //FB_Common__Sql_ETranslator_MethodCall interface -----------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.MethodId,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));

  Debug.Assert(opData.MethodId.Equals(Structure_MethodInfoCache.MethodInfoOf__TimeOnly__std__IsBetween));

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(opData.Instance,null));
  Debug.Assert(!Object.ReferenceEquals(opData.Instance.Type,null));

  Debug.Assert(opData.Instance.Type==Structure_TypeCache.TypeOf__System_TimeOnly);

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(opData.Arguments,null));
  Debug.Assert(opData.Arguments.Count==2);

  //---------
  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[0],null));
  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[0].Type,null));

  Debug.Assert(opData.Arguments[0].Type==Structure_TypeCache.TypeOf__System_TimeOnly);

  //---------
  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[1],null));
  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[1].Type,null));

  Debug.Assert(opData.Arguments[1].Type==Structure_TypeCache.TypeOf__System_TimeOnly);

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

  Debug.Assert(exprArg0.Type==Structure_TypeCache.TypeOf__System_TimeOnly);

  //----------------------------------------
  var exprArg1
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(opData.Arguments[1]);

  Debug.Assert(!Object.ReferenceEquals(exprArg1,null));
  Debug.Assert(!Object.ReferenceEquals(exprArg1.Type,null));
  Debug.Assert(!Object.ReferenceEquals(exprArg1.TypeMapping,null));

  Debug.Assert(exprArg1.Type==Structure_TypeCache.TypeOf__System_TimeOnly);

  //----------------------------------------
  //
  // Generated SQL:
  //
  // CASE
  //  WHEN exprArg0 is null or exprArg1 is null THEN NULL
  //  WHEN exprArg0<=exprArg1                   THEN (exprArg0<=exprObject AND exprObject<exprArg1)
  //  ELSE                                           (exprArg0<=exprObject OR  exprObject<exprArg1)
  // END
  //

  //----------------------------------------
  var expr__Arg0_IS_NULL
   =opData.SqlTreeNodeBuilder.Extension__MakeUnary__IsNull__Throw
     (exprArg0);

  Debug.Assert(!Object.ReferenceEquals(expr__Arg0_IS_NULL,null));
  Debug.Assert(!Object.ReferenceEquals(expr__Arg0_IS_NULL.Type,null));
  Debug.Assert(!Object.ReferenceEquals(expr__Arg0_IS_NULL.TypeMapping,null));
  Debug.Assert( Object.ReferenceEquals(expr__Arg0_IS_NULL.TypeMapping,FB_Common__TypeMappingCache.TypeMapping__BOOLEAN));

  //----------------------------------------
  var expr__Arg1_IS_NULL
   =opData.SqlTreeNodeBuilder.Extension__MakeUnary__IsNull__Throw
     (exprArg1);

  Debug.Assert(!Object.ReferenceEquals(expr__Arg1_IS_NULL,null));
  Debug.Assert(!Object.ReferenceEquals(expr__Arg1_IS_NULL.Type,null));
  Debug.Assert(!Object.ReferenceEquals(expr__Arg1_IS_NULL.TypeMapping,null));
  Debug.Assert( Object.ReferenceEquals(expr__Arg1_IS_NULL.TypeMapping,FB_Common__TypeMappingCache.TypeMapping__BOOLEAN));

  //----------------------------------------
  var expr__WhenCond1
   =opData.SqlTreeNodeBuilder.Extension__MakeBinary__OrElse__Throw
     (expr__Arg0_IS_NULL,
      expr__Arg1_IS_NULL);

  Debug.Assert(!Object.ReferenceEquals(expr__WhenCond1,null));
  Debug.Assert(!Object.ReferenceEquals(expr__WhenCond1.Type,null));
  Debug.Assert(!Object.ReferenceEquals(expr__WhenCond1.TypeMapping,null));
  Debug.Assert( Object.ReferenceEquals(expr__WhenCond1.TypeMapping,FB_Common__TypeMappingCache.TypeMapping__BOOLEAN));

  //----------------------------------------
  var expr__WhenCond2
   =opData.SqlTreeNodeBuilder.Extension__MakeBinary__LessThanOrEqual__Throw
     (exprArg0,
      exprArg1);

  Debug.Assert(!Object.ReferenceEquals(expr__WhenCond2,null));
  Debug.Assert(!Object.ReferenceEquals(expr__WhenCond2.Type,null));
  Debug.Assert(!Object.ReferenceEquals(expr__WhenCond2.TypeMapping,null));
  Debug.Assert( Object.ReferenceEquals(expr__WhenCond2.TypeMapping,FB_Common__TypeMappingCache.TypeMapping__BOOLEAN));

  //----------------------------------------
  var expr__CondPart_test_exprArg0
   =opData.SqlTreeNodeBuilder.Extension__MakeBinary__LessThanOrEqual__Throw
     (exprArg0,
      exprObject);

  Debug.Assert(!Object.ReferenceEquals(expr__CondPart_test_exprArg0,null));
  Debug.Assert(!Object.ReferenceEquals(expr__CondPart_test_exprArg0.Type,null));
  Debug.Assert(!Object.ReferenceEquals(expr__CondPart_test_exprArg0.TypeMapping,null));
  Debug.Assert( Object.ReferenceEquals(expr__CondPart_test_exprArg0.TypeMapping,FB_Common__TypeMappingCache.TypeMapping__BOOLEAN));

  //----------------------------------------
  var expr__CondPart_test_exprArg1
   =opData.SqlTreeNodeBuilder.Extension__MakeBinary__LessThan__Throw
     (exprObject,
      exprArg1);

  Debug.Assert(!Object.ReferenceEquals(expr__CondPart_test_exprArg1,null));
  Debug.Assert(!Object.ReferenceEquals(expr__CondPart_test_exprArg1.Type,null));
  Debug.Assert(!Object.ReferenceEquals(expr__CondPart_test_exprArg1.TypeMapping,null));
  Debug.Assert( Object.ReferenceEquals(expr__CondPart_test_exprArg1.TypeMapping,FB_Common__TypeMappingCache.TypeMapping__BOOLEAN));

  //----------------------------------------
  var expr__Result1
   =FB_Common__Data.sm_SqlConstantExpression__Boolean__NULL;

  Debug.Assert(!Object.ReferenceEquals(expr__Result1,null));
  Debug.Assert(!Object.ReferenceEquals(expr__Result1.Type,null));
  Debug.Assert(!Object.ReferenceEquals(expr__Result1.TypeMapping,null));
  Debug.Assert( Object.ReferenceEquals(expr__Result1.TypeMapping,FB_Common__TypeMappingCache.TypeMapping__BOOLEAN));

  //----------------------------------------
  var expr__Result2
   =opData.SqlTreeNodeBuilder.Extension__MakeBinary__AndAlso__Throw
     (expr__CondPart_test_exprArg0,
      expr__CondPart_test_exprArg1);

  Debug.Assert(!Object.ReferenceEquals(expr__Result2,null));
  Debug.Assert(!Object.ReferenceEquals(expr__Result2.Type,null));
  Debug.Assert(!Object.ReferenceEquals(expr__Result2.TypeMapping,null));
  Debug.Assert( Object.ReferenceEquals(expr__Result2.TypeMapping,FB_Common__TypeMappingCache.TypeMapping__BOOLEAN));

  //----------------------------------------
  var expr__Result3
   =opData.SqlTreeNodeBuilder.Extension__MakeBinary__OrElse__Throw
     (expr__CondPart_test_exprArg0,
      expr__CondPart_test_exprArg1);

  Debug.Assert(!Object.ReferenceEquals(expr__Result3,null));
  Debug.Assert(!Object.ReferenceEquals(expr__Result3.Type,null));
  Debug.Assert(!Object.ReferenceEquals(expr__Result3.TypeMapping,null));
  Debug.Assert( Object.ReferenceEquals(expr__Result3.TypeMapping,FB_Common__TypeMappingCache.TypeMapping__BOOLEAN));

  //----------------------------------------
  var r
   =opData.SqlExpressionFactory.Case
     (new []
       {new CaseWhenClause(expr__WhenCond1,expr__Result1),
        new CaseWhenClause(expr__WhenCond2,expr__Result2)},
      expr__Result3);

  Debug.Assert(!Object.ReferenceEquals(r,null));
  Debug.Assert(!Object.ReferenceEquals(r.Type,null));
  Debug.Assert(!Object.ReferenceEquals(r.TypeMapping,null));

  Debug.Assert(r.Type==Structure_TypeCache.TypeOf__System_Boolean);
  Debug.Assert(r.TypeMapping.ClrType==Structure_TypeCache.TypeOf__System_Boolean);

  return r;
 }//Translate
};//class FB_Common__Sql_ETranslator__TimeOnly__std__IsBetween

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code

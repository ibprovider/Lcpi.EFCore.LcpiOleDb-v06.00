////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 12.09.2018.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

using Structure_MethodIdCache
 =Structure.Structure_MethodIdCache;

using Structure_MethodInfoCache
 =Structure.Structure_MethodInfoCache;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator__String__std__Trim__chars

sealed class FB_Common__Sql_ETranslator__String__std__Trim__chars
 :FB_Common__Sql_ETranslator_MethodCall
{
 public static readonly FB_Common__Sql_ETranslator_MethodCall.tagDescr
  Instance
   =new FB_Common__Sql_ETranslator_MethodCall.tagDescr
     (Structure_MethodIdCache.MethodIdOf__String__std__Trim__chars,
      new FB_Common__Sql_ETranslator__String__std__Trim__chars());

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator__String__std__Trim__chars()
 {
 }//FB_Common__Sql_ETranslator__String__std__Trim__chars

 //FB_Common__Sql_ETranslator_MethodCall interface -----------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.Instance,null));

  Debug.Assert(!Object.ReferenceEquals(opData.MethodId,null));
  Debug.Assert(opData.MethodId.Equals(Structure_MethodInfoCache.MethodInfoOf__String__std__Trim__chars));

  Debug.Assert(!Object.ReferenceEquals(opData.Arguments,null));
  Debug.Assert(opData.Arguments.Count==1);
  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[0],null));

  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));

  //---------------------------------------
  var exprSource
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(opData.Instance);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (exprSource,
    Structure_TypeCache.TypeOf__System_String);
#endif

  //---------------------------------------
  for(;;)
  {
   if(opData.Arguments[0] is SqlConstantExpression arg0_arr)
   {
    if(Object.ReferenceEquals(arg0_arr.Value,null))
     break; //STD

    Debug.Assert(arg0_arr.Value is char[]);

    var arr=(char[])arg0_arr.Value;

    Debug.Assert(!Object.ReferenceEquals(arr,null));

    if(arr.Length==0)
     break; //STD

    if(arr.Length==1)
    {
     if(arr[0]==' ')
      break; //STD

     var arg0_arr_m
      =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(arg0_arr);

#if DEBUG
     Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
      (arg0_arr_m);
#endif

     return Helper__CreateExpression_CH1
      (exprSource,
       arg0_arr_m);
    }//if arr.Length==1

    Debug.Assert(arr.Length>1);

    return null; //ByEF
   }//if ConstantExpression

   return null; //ByEF
  }//for[ever]

  return Helper__CreateExpression_STD
          (exprSource);
 }//Translate

 //Helper methods --------------------------------------------------------
 private static SqlExpression Helper__CreateExpression_STD(SqlExpression value)
 {
  Debug.Assert(!Object.ReferenceEquals(value,null));

  return new Nodes.FB_Common__Sql_ENode_Function__SQL__TRIM
           (value);
 }//Helper__CreateExpression_STD

 //-----------------------------------------------------------------------
 private static SqlExpression Helper__CreateExpression_CH1(SqlExpression value,
                                                           SqlExpression ch1)
 {
  Debug.Assert(!Object.ReferenceEquals(value,null));
  Debug.Assert(!Object.ReferenceEquals(ch1,null));

  return new Nodes.FB_Common__Sql_ENode_Function__SQL__TRIM__ch1
          (value,
           ch1);
 }//Helper__CreateExpression_CH1
};//class FB_Common__Sql_ETranslator__String__std__Trim__chars

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code

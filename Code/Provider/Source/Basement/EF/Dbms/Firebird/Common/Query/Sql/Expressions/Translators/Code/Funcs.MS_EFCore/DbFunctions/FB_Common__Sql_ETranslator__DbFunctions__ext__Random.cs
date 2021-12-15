////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 28.11.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code.MS_EFCore{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

using Structure_MethodIdCache
 =Structure.Structure_MethodIdCache;

using Structure_MethodInfoCache
 =Structure.Structure_MethodInfoCache;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator__DbFunctions__ext__Random

sealed class FB_Common__Sql_ETranslator__DbFunctions__ext__Random
 :FB_Common__Sql_ETranslator_MethodCall
{
 public static readonly FB_Common__Sql_ETranslator_MethodCall.tagDescr
  Instance
   =new FB_Common__Sql_ETranslator_MethodCall.tagDescr
     (Structure_MethodIdCache.MethodIdOf__MS_EFCore__DbFunctions__ext__Random,
      new FB_Common__Sql_ETranslator__DbFunctions__ext__Random());

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator__DbFunctions__ext__Random()
 {
 }//FB_Common__Sql_ETranslator__DbFunctions__ext__Random

 //FB_Common__Sql_ETranslator_MethodCall interface -----------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(Object.ReferenceEquals(opData.Instance,null));

  Debug.Assert(!Object.ReferenceEquals(opData.MethodId,null));
  Debug.Assert(opData.MethodId.Equals(Structure_MethodInfoCache.MethodInfoOf__MS_EFCore__DbFunctions__ext__Random));

  Debug.Assert(!Object.ReferenceEquals(opData.Arguments,null));
  Debug.Assert(opData.Arguments.Count==1);

  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[0],null));

  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));

  //----------------------------------------
  var result
   =Nodes.FB_Common__Sql_ENode_Function__SQL__RAND.Create
     ();

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (result,
    Structure_TypeCache.TypeOf__System_Double);
#endif

  return result;
 }//Translate
};//class FB_Common__Sql_ETranslator__DbFunctions__ext__Random

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code.MS_EFCore

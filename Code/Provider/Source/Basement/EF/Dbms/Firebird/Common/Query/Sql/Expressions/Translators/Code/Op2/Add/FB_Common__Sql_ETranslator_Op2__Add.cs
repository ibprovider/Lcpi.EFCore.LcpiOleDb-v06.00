////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 26.12.2020.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator_Op2__Add

sealed class FB_Common__Sql_ETranslator_Op2__Add
 :FB_Common__Sql_ETranslator_Op2
{
 public static readonly FB_Common__Sql_ETranslator_Op2
  Instance
   =new FB_Common__Sql_ETranslator_Op2__Add();

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator_Op2__Add()
 {
 }//FB_Common__Sql_ETranslator_Op2__Add

 //FB_Common__Sql_ETranslator_Op2 interface ------------------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(opData.OperationType==LcpiOleDb__ExpressionType.Add);

  Debug.Assert(!Object.ReferenceEquals(opData.SqlLeft,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlRight,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlResultTypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));

  //------------------------------------------------------------
#if DEBUG

  //
  // Not expected. Must be processed by translator for Concat
  //

  Debug.Assert
   (Core.SQL.Core_SQL__ExpressionUtils.DEBUG__GetSqlType(opData.SqlLeft)
     !=Structure_TypeCache.TypeOf__System_String);

  Debug.Assert
   (Core.SQL.Core_SQL__ExpressionUtils.DEBUG__GetSqlType(opData.SqlRight)
     !=Structure_TypeCache.TypeOf__System_String);
#endif

  //------------------------------------------------------------

  //
  // [2021-01-02] No idea how to send here the arguments without TypeMapping.
  //

  //------------------------------------------------------------
#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (opData.SqlLeft);

  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (opData.SqlRight);
#endif

  //------------------------------------------------------------
  var r
   =Nodes.FB_Common__Sql_ENode_Binary__Add.Create
     (opData.SqlLeft,
      opData.SqlRight,
      opData.SqlResultTypeMapping);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping__IsExpected
   (r,
    opData.SqlResultTypeMapping);
#endif

  return r;
 }//Translate
};//class FB_Common__Sql_ETranslator_Op2__Add

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code

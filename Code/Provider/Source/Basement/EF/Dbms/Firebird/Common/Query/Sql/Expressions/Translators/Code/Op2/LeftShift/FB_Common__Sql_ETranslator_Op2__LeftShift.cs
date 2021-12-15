////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 22.11.2020.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code{
////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator_Op2__LeftShift

sealed class FB_Common__Sql_ETranslator_Op2__LeftShift
 :FB_Common__Sql_ETranslator_Op2
{
 public static readonly FB_Common__Sql_ETranslator_Op2
  Instance
   =new FB_Common__Sql_ETranslator_Op2__LeftShift();

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator_Op2__LeftShift()
 {
 }//FB_Common__Sql_ETranslator_Op2__LeftShift

 //FB_Common__Sql_ETranslator_Op2 interface ------------------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(opData.OperationType==LcpiOleDb__ExpressionType.LeftShift);

  Debug.Assert(!Object.ReferenceEquals(opData.SqlLeft,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlRight,null));
  //Debug.Assert(!Object.ReferenceEquals(opData.SqlResultTypeMapping,null));

  var r
   =Nodes.FB_Common__Sql_ENode_Function__SQL__BIN_SHL.Create
     (opData.SqlLeft,
      opData.SqlRight);

  Debug.Assert(!Object.ReferenceEquals(r,null));

  return r;
 }//Translate
};//class FB_Common__Sql_ETranslator_Op2__LeftShift

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code

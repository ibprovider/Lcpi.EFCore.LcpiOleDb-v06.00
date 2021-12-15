////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 02.10.2021.
using System;
using System.Diagnostics;
using System.Linq;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code{
////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator_Unary__Equal

sealed partial class FB_Common__Sql_ETranslator_Unary__Equal
 :FB_Common__Sql_ETranslator_Unary
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__Sql_ETranslator_Unary__Equal;

 //-----------------------------------------------------------------------
 public static readonly FB_Common__Sql_ETranslator_Unary
  Instance
   =new FB_Common__Sql_ETranslator_Unary__Equal();

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator_Unary__Equal()
 {
 }//FB_Common__Sql_ETranslator_Unary__Equal

 //interface FB_Common__Sql_ETranslator_Unary ----------------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.SqlOperand,null));

  Debug.Assert(opData.OperatorType==LcpiOleDb__ExpressionType.Equal);

  //-------------------------------------------------------
  const string c_bugcheck_src
   ="FB_Common__Sql_ETranslator_Unary__Equal::Translate";

  //-------------------------------------------------------
  Check.BugCheck_Value_NotNull
   (c_ErrSrcID,
    c_bugcheck_src,
    "#001",
    "opData.SqlOperand",
    opData.SqlOperand);

  //-------------------------------------------------------
  var exprOperand
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping
     (opData.SqlOperand);

  Debug.Assert(!Object.ReferenceEquals(exprOperand,null));

  //-------------------------------------------------------
  var r
   =Nodes.FB_Common__Sql_ENode_Unary__SQL__IS_NULL.Create
     (exprOperand); //throw

  Debug.Assert(!Object.ReferenceEquals(r,null));

  return r;
 }//Translate
};//class FB_Common__Sql_ETranslator_Unary__Equal

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code

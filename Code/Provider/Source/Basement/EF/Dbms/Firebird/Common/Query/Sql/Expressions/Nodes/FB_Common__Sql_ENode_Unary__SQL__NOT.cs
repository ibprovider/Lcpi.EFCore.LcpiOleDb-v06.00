////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 08.10.2021.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes{
////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ENode_Unary__SQL__NOT

sealed class FB_Common__Sql_ENode_Unary__SQL__NOT
 :SqlUnaryExpression
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__Sql_ENode_Unary__SQL__NOT;

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ENode_Unary__SQL__NOT
                        (SqlExpression         sqlOperand,
                         RelationalTypeMapping resultTypeMapping)
  :base(ExpressionType.Not,
        sqlOperand,
        resultTypeMapping.ClrType,
        resultTypeMapping)
 {
 }//FB_Common__Sql_ENode_Unary__SQL__NOT

 //-----------------------------------------------------------------------
 public static SqlUnaryExpression Create(SqlExpression sqlOperand)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlOperand,null));

  //------------------------------------------------------------
  const string c_bugcheck_src
   ="FB_Common__Sql_ENode_Unary__SQL__NOT::Create";

  //------------------------------------------------------------
  Check.BugCheck_Value_NotNull
   (c_ErrSrcID,
    c_bugcheck_src,
    "#001",
    nameof(sqlOperand),
    sqlOperand);

  //------------------------------------------------------------
  var r
   =new FB_Common__Sql_ENode_Unary__SQL__NOT
     (sqlOperand,
      FB_Common__TypeMappingCache.TypeMapping__BOOLEAN); //throw (OOM)

  return r;
 }//Create

 //Expression interface --------------------------------------------------
 public override bool CanReduce
 {
  get
  {
#if TRACE
   Core.Core_Trace.Method
    ("FB_Common__Sql_ENode_Unary__SQL__NOT::get_CanReduce - false");
#endif

   //----------------------------------------
#if DEBUG
   this.DEBUG__CheckState();
#endif

   //----------------------------------------
   return false;
  }//get
 }//CanReduce

 //-----------------------------------------------------------------------
 protected override Expression Accept(ExpressionVisitor visitor)
 {
  Debug.Assert(!Object.ReferenceEquals(visitor,null));

#if TRACE
  Core.Core_Trace.Method_Enter
   ("FB_Common__Sql_ENode_Unary__SQL__NOT::Accept"
   +" (visitorType: {0})",
    visitor.GetType());
#endif

  Expression r;

  if(visitor is Sql.FB_Common__QuerySqlGenerator x)
  {
   r=this.Helper__Accept__GenerateSql(x);
  }
  else
  {
   r=base.Accept(visitor);
  }//else

#if TRACE
  Core.Core_Trace.Method_Exit
   ("FB_Common__Sql_ENode_Unary__SQL__NOT::Accept"
   +" (visitorType: {0}) - {1}",
    visitor.GetType(),
    r?.GetType());
#endif

  return r;
 }//Accept

 //-----------------------------------------------------------------------
 protected override Expression VisitChildren(ExpressionVisitor visitor)
 {
  Debug.Assert(!Object.ReferenceEquals(visitor,null));

  //----------------------------------------
  const string c_bugcheck_src
   ="FB_Common__Sql_ENode_Unary__SQL__NOT::VisitChildren";

  //----------------------------------------
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Unary__SQL__NOT::VisitChildren\n"
   +" ({0})",
    visitor);
#endif

  //-------------------------------------------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(VisitChildren),
    nameof(visitor),
    visitor);

  //----------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif

  //-------------------------------------------------------
  Expression newOperand_e = visitor.Visit(this.Operand);

  //----------------------------------------
  var newOperand
   =Check.BugCheck_Value_NotNullAndInstanceOf<SqlExpression,Expression>
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      nameof(newOperand_e),
      newOperand_e);

  Debug.Assert(!Object.ReferenceEquals(newOperand,null));

  //----------------------------------------
  for(;;)
  {
   if(newOperand!=this.Operand)
    break;

   return this;
  }//for[ever]

  //create new instance
  var r
   =Create
     (newOperand);

  Debug.Assert(!Object.ReferenceEquals(r,null));

  return r;
 }//VisitChildren

 //SqlUnaryExpression interface ------------------------------------------
 public override SqlUnaryExpression Update(SqlExpression operand)
 {
  Debug.Assert(!Object.ReferenceEquals(operand,null));

  //-------------------------------------------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Update),
    nameof(operand),
    operand);

  //-------------------------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif

  //----------------------------------------
  for(;;)
  {
   if(!Object.ReferenceEquals(this.Operand,operand))
    break;

   return this;
  }//for[ever]

  //create new instance

  var r
   =Create
     (operand);

  Debug.Assert(!Object.ReferenceEquals(r,null));

  return r;
 }//Update

 //-----------------------------------------------------------------------
 protected override void Print(ExpressionPrinter expressionPrinter)
 {
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Unary__SQL__NOT::Print(...)");
#endif

  //------------------------------------------------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Print),
    nameof(expressionPrinter),
    expressionPrinter);

  //------------------------------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif

  //------------------------------------------------------------
  expressionPrinter.Append("UNARY_NOT(");
  expressionPrinter.Visit(this.Operand);
  expressionPrinter.Append(")");
 }//Print

 //Object interface ------------------------------------------------------
 public override bool Equals(object obj)
 {
  var r
   =base.Equals(obj);

  return r;
 }//Equals

 //-----------------------------------------------------------------------
 public override int GetHashCode()
 {
  var r
   =base.GetHashCode();

  return r;
 }//GetHashCode

 //Helper methods --------------------------------------------------------
 private Expression Helper__Accept__GenerateSql(Sql.FB_Common__QuerySqlGenerator querySqlGenerator)
 {
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Unary__SQL__NOT::Helper__Accept__GenerateSql(...)");
#endif

  //------------------------------------------------------------
  Debug.Assert(!Object.ReferenceEquals(querySqlGenerator,null));

#if DEBUG
  this.DEBUG__CheckState();
#endif

  //------------------------------------------------------------
  querySqlGenerator.Sql.Append("NOT ");

  querySqlGenerator.VisitAndWrapIntoBrackets(this.Operand,/*parent*/this);

  return this;
 }//Helper__Accept__GenerateSql

 //Debug methods ---------------------------------------------------------
#if DEBUG
 private void DEBUG__CheckState()
 {
  Debug.Assert(!Object.ReferenceEquals(this.Operand,null));

  Debug.Assert(!Object.ReferenceEquals(this.TypeMapping,null));

  Debug.Assert(!Object.ReferenceEquals(this.TypeMapping.ClrType,null));
 }//DEBUG__CheckState
#endif
};//class FB_Common__Sql_ENode_Unary__SQL__NOT

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes
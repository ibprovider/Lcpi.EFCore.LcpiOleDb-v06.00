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
//using

using FB_Common__Sql_ETag__RequiresBrackets
 =Tags.FB_Common__Sql_ETag__RequiresBrackets;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ENode_Unary__SQL__NEGATE

sealed class FB_Common__Sql_ENode_Unary__SQL__NEGATE
 :SqlUnaryExpression
 ,FB_Common__Sql_ETag__RequiresBrackets
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__Sql_ENode_Unary__SQL__NEGATE;

 //-----------------------------------------------------------------------
 public delegate RelationalTypeMapping TGetResultTypeMapping(SqlExpression sqlSource);

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ENode_Unary__SQL__NEGATE
                        (SqlExpression         sqlOperand,
                         RelationalTypeMapping resultTypeMapping,
                         TGetResultTypeMapping getResultTypeMapping)
  :base(ExpressionType.Negate,
        sqlOperand,
        resultTypeMapping.ClrType,
        resultTypeMapping)
 {
  Debug.Assert(!Object.ReferenceEquals(getResultTypeMapping,null));

  //----------------------------------------
  m_GetResultTypeMapping=getResultTypeMapping;

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(m_GetResultTypeMapping,null));
 }//FB_Common__Sql_ENode_Unary__SQL__NEGATE

 //-----------------------------------------------------------------------
 public static SqlExpression Create(SqlExpression         sqlOperand,
                                    TGetResultTypeMapping getResultTypeMapping)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlOperand,null));
  Debug.Assert(!Object.ReferenceEquals(getResultTypeMapping,null));

  //------------------------------------------------------------
  const string c_bugcheck_src
   ="FB_Common__Sql_ENode_Unary__SQL__NEGATE::Create";

  //------------------------------------------------------------
  Check.BugCheck_Value_NotNull
   (c_ErrSrcID,
    c_bugcheck_src,
    "#001",
    nameof(sqlOperand),
    sqlOperand);

  //------------------------------------------------------------
  if(sqlOperand is FB_Common__Sql_ENode_Unary__SQL__NEGATE x)
  {
   Debug.Assert(!Object.ReferenceEquals(x.Operand,null));

   Debug.Assert(Object.ReferenceEquals(x.m_GetResultTypeMapping,getResultTypeMapping));

   return x.Operand;
  }//if

  //------------------------------------------------------------
  var resultTypeMapping
   =getResultTypeMapping
     (sqlOperand);

  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));

  var r
   =new FB_Common__Sql_ENode_Unary__SQL__NEGATE
     (sqlOperand,
      resultTypeMapping,
      getResultTypeMapping); //throw (OOM)

  return r;
 }//Create

 //FB_Common__Sql_ETag__RequiresBrackets interface -----------------------
 bool FB_Common__Sql_ETag__RequiresBrackets.RequiresBrackets(SqlExpression sqlParentExpression)
 {
  if(sqlParentExpression is FB_Common__Sql_ENode_Unary__SQL__NEGATE x)
  {
   Debug.Assert(Object.ReferenceEquals(x.m_GetResultTypeMapping,m_GetResultTypeMapping));

   return true;
  }//if

#if DEBUG
  if(sqlParentExpression is SqlUnaryExpression unaryExpression)
  {
   Debug.Assert(unaryExpression.OperatorType!=ExpressionType.Negate);
   Debug.Assert(unaryExpression.OperatorType!=ExpressionType.NegateChecked);
   Debug.Assert(unaryExpression.OperatorType!=ExpressionType.UnaryPlus);
  }//if
#endif

  return false;
 }//RequiresBrackets

 //Expression interface --------------------------------------------------
 public override bool CanReduce
 {
  get
  {
#if TRACE
   Core.Core_Trace.Method
    ("FB_Common__Sql_ENode_Unary__SQL__NEGATE::get_CanReduce - false");
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
   ("FB_Common__Sql_ENode_Unary__SQL__NEGATE::Accept"
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
   ("FB_Common__Sql_ENode_Unary__SQL__NEGATE::Accept"
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
   ="FB_Common__Sql_ENode_Unary__SQL__NEGATE::VisitChildren";

  //----------------------------------------
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Unary__SQL__NEGATE::VisitChildren\n"
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
     (newOperand,
      m_GetResultTypeMapping);

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

  //
  // [2021-11-10] Sh...
  //

  var resultTypeMapping
   =m_GetResultTypeMapping
     (operand); //throw

  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));

  var r
   =new FB_Common__Sql_ENode_Unary__SQL__NEGATE
     (operand,
      resultTypeMapping,
      m_GetResultTypeMapping); //throw (OOM)

  return r;
 }//Update

 //-----------------------------------------------------------------------
 protected override void Print(ExpressionPrinter expressionPrinter)
 {
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Unary__SQL__NEGATE::Print(...)");
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
  expressionPrinter.Append("UNARY_NEGATE(");
  expressionPrinter.Visit(this.Operand);
  expressionPrinter.Append(")");
 }//Print

 //Object interface ------------------------------------------------------
 public override bool Equals(object obj)
 {
  var r
   =base.Equals(obj);

#if DEBUG
  if(r)
  {
   Debug.Assert(!Object.ReferenceEquals(obj,null));
   Debug.Assert(obj is FB_Common__Sql_ENode_Unary__SQL__NEGATE);

   var obj_t
    =(FB_Common__Sql_ENode_Unary__SQL__NEGATE)obj;

   //[2021-10-13] Expected!
   Debug.Assert(Object.ReferenceEquals(obj_t.m_GetResultTypeMapping,m_GetResultTypeMapping));

   Debug.Assert(obj_t.GetHashCode()==this.GetHashCode());
  }//if r
#endif

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
   ("FB_Common__Sql_ENode_Unary__SQL__NEGATE::Helper__Accept__GenerateSql(...)");
#endif

  //------------------------------------------------------------
  Debug.Assert(!Object.ReferenceEquals(querySqlGenerator,null));

#if DEBUG
  this.DEBUG__CheckState();
#endif

  //------------------------------------------------------------
  querySqlGenerator.Sql.Append("-");

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

  Debug.Assert(!Object.ReferenceEquals(this.m_GetResultTypeMapping,null));
 }//DEBUG__CheckState
#endif

 //private data ----------------------------------------------------------
 private readonly TGetResultTypeMapping m_GetResultTypeMapping;
};//class FB_Common__Sql_ENode_Unary__SQL__NEGATE

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes
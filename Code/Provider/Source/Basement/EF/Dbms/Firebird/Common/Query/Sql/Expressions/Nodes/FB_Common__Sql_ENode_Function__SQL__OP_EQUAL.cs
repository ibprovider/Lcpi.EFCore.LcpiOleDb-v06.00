////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 03.06.2021.
using System;
using System.Diagnostics;
using System.Collections.Generic;
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
//class FB_Common__Sql_ENode_Function__SQL__OP_EQUAL

sealed class FB_Common__Sql_ENode_Function__SQL__OP_EQUAL
 :FB_Common__Sql_ENode_Function
 ,FB_Common__Sql_ETag__RequiresBrackets
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__Sql_ENode_Function__SQL__OP_EQUAL;

 //-----------------------------------------------------------------------
 private const int c_ArgCount=2;

 private const int c_ArgIdx__left=0;

 private const int c_ArgIdx__right=1;

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ENode_Function__SQL__OP_EQUAL
           (System.String              functionName,
            IEnumerable<SqlExpression> arguments,
            System.Type                resultType,
            RelationalTypeMapping      resultTypeMapping)
  :base(functionName,
        arguments,
        Core.SQL.Core_SQL__TestNullable.TestNullable_ANY(arguments),
        sm_argumentsPropagateNullability,
        resultType,
        resultTypeMapping)
 {
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Function__SQL__OP_EQUAL::FB_Common__Sql_ENode_Function__SQL__OP_EQUAL(...) - clone");
#endif

  //----------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif
 }//FB_Common__Sql_ENode_Function__SQL__OP_EQUAL

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ENode_Function__SQL__OP_EQUAL
                                           (SqlExpression leftExpression,
                                            SqlExpression rightExpression)
  :this("SQL_OP_EQUAL",
        new[]{leftExpression,rightExpression},
        FB_Common__TypeMappingCache.TypeMapping__BOOLEAN.ClrType,
        FB_Common__TypeMappingCache.TypeMapping__BOOLEAN)
 {
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Function__SQL__OP_EQUAL::FB_Common__Sql_ENode_Function__SQL__OP_EQUAL\n"
   +" (leftExpression  : {0},\n"
   +"  rightExpression : {1})",
    leftExpression,
    rightExpression);
#endif

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(leftExpression,null));
  Debug.Assert(!Object.ReferenceEquals(rightExpression,null));

#if DEBUG
  this.DEBUG__CheckState();
#endif

  Debug.Assert(Object.ReferenceEquals(this.Arguments[c_ArgIdx__left]  ,leftExpression));
  Debug.Assert(Object.ReferenceEquals(this.Arguments[c_ArgIdx__right] ,rightExpression));
 }//FB_Common__Sql_ENode_Function__SQL__OP_EQUAL

 //-----------------------------------------------------------------------
 public static SqlExpression Create(SqlExpression         leftExpression,
                                    SqlExpression         rightExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(leftExpression,null));
  Debug.Assert(!Object.ReferenceEquals(leftExpression.Type,null));
  Debug.Assert(!Object.ReferenceEquals(leftExpression.TypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(leftExpression.TypeMapping.ClrType,null));

  Debug.Assert(!Object.ReferenceEquals(rightExpression,null));
  Debug.Assert(!Object.ReferenceEquals(rightExpression.Type,null));
  Debug.Assert(!Object.ReferenceEquals(rightExpression.TypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(rightExpression.TypeMapping.ClrType,null));

  return new FB_Common__Sql_ENode_Function__SQL__OP_EQUAL
          (leftExpression,
           rightExpression);
 }//Create

 //FB_Common__Sql_ETag__RequiresBrackets interface -----------------------
 bool FB_Common__Sql_ETag__RequiresBrackets.RequiresBrackets(SqlExpression sqlParentExpression)
 {
  return true;
 }//RequiresBrackets

 //Expression interface --------------------------------------------------
 public override bool CanReduce
 {
  get
  {
#if TRACE
   Core.Core_Trace.Method
    ("FB_Common__Sql_ENode_Function__SQL__OP_EQUAL::get_CanReduce - false");
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
   ("FB_Common__Sql_ENode_Function__SQL__OP_EQUAL::Accept"
   +" (visitorType: {0})",
    visitor.GetType());
#endif

  //----------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif

  //----------------------------------------
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
   ("FB_Common__Sql_ENode_Function__SQL__OP_EQUAL::Accept"
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
   ="FB_Common__Sql_ENode_Function__SQL__OP_EQUAL::VisitChildren";

  //----------------------------------------
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Function__SQL__OP_EQUAL::VisitChildren\n"
   +" ({0})",
    visitor);
#endif

  //----------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif

  //----------------------------------------
  Expression newLeftExpression_e    = visitor.Visit(this.Arguments[c_ArgIdx__left]);
  Expression newRightExpression_e   = visitor.Visit(this.Arguments[c_ArgIdx__right]);

  //----------------------------------------
  var newLeftExpression
   =Check.BugCheck_Value_NotNullAndInstanceOf<SqlExpression,Expression>
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      "newLeftExpression_e",
      newLeftExpression_e);

  var newRightExpression
   =Check.BugCheck_Value_NotNullAndInstanceOf<SqlExpression,Expression>
     (c_ErrSrcID,
      c_bugcheck_src,
      "#002",
      "newRightExpression_e",
      newRightExpression_e);

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(newLeftExpression,null));
  Debug.Assert(!Object.ReferenceEquals(newRightExpression,null));

  //----------------------------------------
  for(;;)
  {
   if(newLeftExpression!=this.Arguments[c_ArgIdx__left])
    break;

   if(newRightExpression!=this.Arguments[c_ArgIdx__right])
    break;

   return this;
  }//for

  //create new instance
  return new FB_Common__Sql_ENode_Function__SQL__OP_EQUAL
              (this.Name,
               new[]{newLeftExpression,newRightExpression},
               this.Type,
               this.TypeMapping);
 }//VisitChildren

 //-----------------------------------------------------------------------
 public override SqlFunctionExpression ApplyTypeMapping(RelationalTypeMapping typeMapping)
 {
  //[2020-12-03] Call of this method not expected
  Debug.Assert(false);

#if DEBUG
  this.DEBUG__CheckState();
#endif

  ThrowSysError.method_not_impl
   (c_ErrSrcID,
    nameof(ApplyTypeMapping));

  return null;
 }//ApplyTypeMapping

 //-----------------------------------------------------------------------
 public override SqlFunctionExpression Update(SqlExpression                instance,
                                              IReadOnlyList<SqlExpression> arguments)
 {
  Check.Arg_IsNull
   (c_ErrSrcID,
    nameof(Update),
    nameof(instance),
    instance);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Update),
    nameof(arguments),
    arguments);

  Check.Arg_ListSize
   (c_ErrSrcID,
    nameof(Update),
    nameof(arguments),
    arguments.Count,
    c_ArgCount);

  Debug.Assert(c_ArgIdx__left==0);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Update),
    nameof(arguments)+"[0]",
    arguments[c_ArgIdx__left]);

  Debug.Assert(c_ArgIdx__right==1);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Update),
    nameof(arguments)+"[1]",
    arguments[c_ArgIdx__right]);

  //------------------------------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif

  //------------------------------------------------------------
  for(;;)
  {
   if(!Object.ReferenceEquals(this.Arguments[c_ArgIdx__left],arguments[c_ArgIdx__left]))
    break;

   if(!Object.ReferenceEquals(this.Arguments[c_ArgIdx__right],arguments[c_ArgIdx__right]))
    break;

   return this;
  }//for[ever]

  return new FB_Common__Sql_ENode_Function__SQL__OP_EQUAL
              (this.Name,
               arguments,
               this.Type,
               this.TypeMapping);
 }//Update

 //-----------------------------------------------------------------------
 protected override void Print(ExpressionPrinter expressionPrinter)
 {
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Function__SQL__OP_EQUAL::Print(...)");
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
  expressionPrinter.Append("SQL_OP_EQUAL(");
  expressionPrinter.Visit(this.Arguments[c_ArgIdx__left]);
  expressionPrinter.Append(", ");
  expressionPrinter.Visit(this.Arguments[c_ArgIdx__right]);
  expressionPrinter.Append(")");
 }//Print

 //Helper methods --------------------------------------------------------
 private Expression Helper__Accept__GenerateSql(Sql.FB_Common__QuerySqlGenerator querySqlGenerator)
 {
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Function__SQL__OP_EQUAL::Helper__Accept__GenerateSql(...)");
#endif

  //------------------------------------------------------------
  Debug.Assert(!Object.ReferenceEquals(querySqlGenerator,null));

#if DEBUG
  this.DEBUG__CheckState();
#endif

  //------------------------------------------------------------
  querySqlGenerator.VisitAndWrapIntoBrackets(this.Arguments[c_ArgIdx__left],/*Parent*/this);

  querySqlGenerator.Sql.Append(" = ");

  querySqlGenerator.VisitAndWrapIntoBrackets(this.Arguments[c_ArgIdx__right],/*Parent*/this);

  return this;
 }//Helper__Accept__GenerateSql

 //Debug methods ---------------------------------------------------------
#if DEBUG
 private void DEBUG__CheckState()
 {
  Debug.Assert(Object.ReferenceEquals(this.Instance,null));

  Debug.Assert(!Object.ReferenceEquals(this.Arguments,null));

  Debug.Assert(this.Arguments.Count==c_ArgCount);

  Debug.Assert(!Object.ReferenceEquals(this.Arguments[c_ArgIdx__left],null));
  Debug.Assert(!Object.ReferenceEquals(this.Arguments[c_ArgIdx__right],null));
 }//DEBUG__CheckState
#endif

 //private data ----------------------------------------------------------
 private static readonly bool[] sm_argumentsPropagateNullability
  =new bool[c_ArgCount]{true,true};
};//class FB_Common__Sql_ENode_Function__SQL__OP_EQUAL

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes

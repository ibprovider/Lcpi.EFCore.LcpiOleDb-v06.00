////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 27.11.2021.
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
//class FB_Common__Sql_ENode_Function__SQL__LIKE_escape

sealed class FB_Common__Sql_ENode_Function__SQL__LIKE_escape
 :FB_Common__Sql_ENode_Function
 ,FB_Common__Sql_ETag__RequiresBrackets
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__Sql_ENode_Function__SQL__LIKE_escape;

 //-----------------------------------------------------------------------
 private const int c_ArgCount=3;

 private const int c_ArgIdx__value=0;

 private const int c_ArgIdx__pattern=1;

 private const int c_ArgIdx__escape=2;

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ENode_Function__SQL__LIKE_escape
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
   ("FB_Common__Sql_ENode_Function__SQL__LIKE_escape::FB_Common__Sql_ENode_Function__SQL__LIKE_escape(...) - clone");
#endif

  //----------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif
 }//FB_Common__Sql_ENode_Function__SQL__LIKE_escape

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ENode_Function__SQL__LIKE_escape
                                           (SqlExpression valueExpression,
                                            SqlExpression patternExpression,
                                            SqlExpression escapeExpression)
  :this("LIKE",
        new[]{valueExpression,patternExpression,escapeExpression},
        FB_Common__TypeMappingCache.TypeMapping__BOOLEAN.ClrType,
        FB_Common__TypeMappingCache.TypeMapping__BOOLEAN)
 {
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Function__SQL__LIKE_escape::FB_Common__Sql_ENode_Function__SQL__LIKE_escape\n"
   +" (valueExpression  : {0},\n"
   +"  patternExpression: {1},\n"
   +"  escapeExpression : {2})",
    valueExpression,
    patternExpression,
    escapeExpression);
#endif

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(valueExpression,null));
  Debug.Assert(!Object.ReferenceEquals(patternExpression,null));
  Debug.Assert(!Object.ReferenceEquals(escapeExpression,null));

#if DEBUG
  this.DEBUG__CheckState();
#endif

  Debug.Assert(Object.ReferenceEquals(this.Arguments[c_ArgIdx__value],valueExpression));
  Debug.Assert(Object.ReferenceEquals(this.Arguments[c_ArgIdx__pattern],patternExpression));
  Debug.Assert(Object.ReferenceEquals(this.Arguments[c_ArgIdx__escape],escapeExpression));
 }//FB_Common__Sql_ENode_Function__SQL__LIKE_escape

 //-----------------------------------------------------------------------
 public static SqlExpression Create(SqlExpression valueExpression,
                                    SqlExpression patternExpression,
                                    SqlExpression escapeExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(valueExpression,null));
  Debug.Assert(!Object.ReferenceEquals(valueExpression.Type,null));
  Debug.Assert(!Object.ReferenceEquals(valueExpression.TypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(valueExpression.TypeMapping.ClrType,null));

  Debug.Assert(!Object.ReferenceEquals(patternExpression,null));
  Debug.Assert(!Object.ReferenceEquals(patternExpression.Type,null));
  Debug.Assert(!Object.ReferenceEquals(patternExpression.TypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(patternExpression.TypeMapping.ClrType,null));

  Debug.Assert(!Object.ReferenceEquals(escapeExpression,null));
  Debug.Assert(!Object.ReferenceEquals(escapeExpression.Type,null));
  Debug.Assert(!Object.ReferenceEquals(escapeExpression.TypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(escapeExpression.TypeMapping.ClrType,null));

  return new FB_Common__Sql_ENode_Function__SQL__LIKE_escape
          (valueExpression,
           patternExpression,
           escapeExpression);
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
    ("FB_Common__Sql_ENode_Function__SQL__LIKE_escape::get_CanReduce - false");
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
   ("FB_Common__Sql_ENode_Function__SQL__LIKE_escape::Accept"
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
   ("FB_Common__Sql_ENode_Function__SQL__LIKE_escape::Accept"
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
   ="FB_Common__Sql_ENode_Function__SQL__LIKE_escape::VisitChildren";

  //----------------------------------------
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Function__SQL__LIKE_escape::VisitChildren\n"
   +" ({0})",
    visitor);
#endif

  //----------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif

  //----------------------------------------
  Expression newValueExpression_e    = visitor.Visit(this.Arguments[c_ArgIdx__value]);
  Expression newPatternExpression_e  = visitor.Visit(this.Arguments[c_ArgIdx__pattern]);
  Expression newEscapeExpression_e   = visitor.Visit(this.Arguments[c_ArgIdx__escape]);

  //----------------------------------------
  var newValueExpression
   =Check.BugCheck_Value_NotNullAndInstanceOf<SqlExpression,Expression>
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      "newValueExpression_e",
      newValueExpression_e);

  var newPatternExpression
   =Check.BugCheck_Value_NotNullAndInstanceOf<SqlExpression,Expression>
     (c_ErrSrcID,
      c_bugcheck_src,
      "#002",
      "newPatternExpression_e",
      newPatternExpression_e);

  var newEscapeExpression
   =Check.BugCheck_Value_NotNullAndInstanceOf<SqlExpression,Expression>
     (c_ErrSrcID,
      c_bugcheck_src,
      "#003",
      "newEscapeExpression_e",
      newEscapeExpression_e);

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(newValueExpression,null));
  Debug.Assert(!Object.ReferenceEquals(newPatternExpression,null));
  Debug.Assert(!Object.ReferenceEquals(newEscapeExpression,null));

  //----------------------------------------
  for(;;)
  {
   if(newValueExpression!=this.Arguments[c_ArgIdx__value])
    break;

   if(newPatternExpression!=this.Arguments[c_ArgIdx__pattern])
    break;

   if(newEscapeExpression!=this.Arguments[c_ArgIdx__escape])
    break;

   return this;
  }//for

  //create new instance
  return new FB_Common__Sql_ENode_Function__SQL__LIKE_escape
              (this.Name,
               new[]{newValueExpression,newPatternExpression,newEscapeExpression},
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

  Debug.Assert(c_ArgIdx__value==0);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Update),
    nameof(arguments)+"[0]",
    arguments[c_ArgIdx__value]);

  Debug.Assert(c_ArgIdx__pattern==1);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Update),
    nameof(arguments)+"[1]",
    arguments[c_ArgIdx__pattern]);

  Debug.Assert(c_ArgIdx__escape==2);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Update),
    nameof(arguments)+"[2]",
    arguments[c_ArgIdx__escape]);

  //------------------------------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif

  //------------------------------------------------------------
  for(;;)
  {
   if(!Object.ReferenceEquals(this.Arguments[c_ArgIdx__value],arguments[c_ArgIdx__value]))
    break;

   if(!Object.ReferenceEquals(this.Arguments[c_ArgIdx__pattern],arguments[c_ArgIdx__pattern]))
    break;

   if(!Object.ReferenceEquals(this.Arguments[c_ArgIdx__escape],arguments[c_ArgIdx__escape]))
    break;

   return this;
  }//for[ever]

  return new FB_Common__Sql_ENode_Function__SQL__LIKE_escape
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
   ("FB_Common__Sql_ENode_Function__SQL__LIKE_escape::Print(...)");
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
  expressionPrinter.Append("LIKE(");
  expressionPrinter.Visit(this.Arguments[c_ArgIdx__value]);
  expressionPrinter.Append(", ");
  expressionPrinter.Visit(this.Arguments[c_ArgIdx__pattern]);
  expressionPrinter.Append(", ");
  expressionPrinter.Visit(this.Arguments[c_ArgIdx__escape]);
  expressionPrinter.Append(")");
 }//Print

 //Helper methods --------------------------------------------------------
 private Expression Helper__Accept__GenerateSql(Sql.FB_Common__QuerySqlGenerator querySqlGenerator)
 {
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Function__SQL__LIKE_escape::Helper__Accept__GenerateSql(...)");
#endif

  //------------------------------------------------------------
  Debug.Assert(!Object.ReferenceEquals(querySqlGenerator,null));

#if DEBUG
  this.DEBUG__CheckState();
#endif

  //------------------------------------------------------------
  querySqlGenerator.VisitAndWrapIntoBrackets(this.Arguments[c_ArgIdx__value],/*parent*/this);

  querySqlGenerator.Sql.Append(" LIKE ");

  querySqlGenerator.VisitAndWrapIntoBrackets(this.Arguments[c_ArgIdx__pattern],/*parent*/this);

  querySqlGenerator.Sql.Append(" ESCAPE ");

  querySqlGenerator.VisitAndWrapIntoBrackets(this.Arguments[c_ArgIdx__escape],/*parent*/this);

  return this;
 }//Helper__Accept__GenerateSql

 //Debug methods ---------------------------------------------------------
#if DEBUG
 private void DEBUG__CheckState()
 {
  Debug.Assert(Object.ReferenceEquals(this.Instance,null));

  Debug.Assert(!Object.ReferenceEquals(this.Arguments,null));

  Debug.Assert(this.Arguments.Count==c_ArgCount);

  Debug.Assert(!Object.ReferenceEquals(this.Arguments[c_ArgIdx__value],null));
  Debug.Assert(!Object.ReferenceEquals(this.Arguments[c_ArgIdx__pattern],null));
  Debug.Assert(!Object.ReferenceEquals(this.Arguments[c_ArgIdx__escape],null));
 }//DEBUG__CheckState
#endif

 //private data ----------------------------------------------------------
 private static readonly bool[] sm_argumentsPropagateNullability
  =new bool[c_ArgCount]{true,true,true};
};//class FB_Common__Sql_ENode_Function__SQL__LIKE_escape

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes

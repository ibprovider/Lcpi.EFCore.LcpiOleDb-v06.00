////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 26.05.2021.
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes{
////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ENode_Function__SQL__SUBSTRING_from_for

sealed class FB_Common__Sql_ENode_Function__SQL__SUBSTRING_from_for
 :FB_Common__Sql_ENode_Function
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__Sql_ENode_Function__SQL__SUBSTRING_from_for;

 //-----------------------------------------------------------------------
 private const int c_ArgCount=3;

 private const int c_ArgIdx__value=0;

 private const int c_ArgIdx__from=1;

 private const int c_ArgIdx__for=2;

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ENode_Function__SQL__SUBSTRING_from_for
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
   ("FB_Common__Sql_ENode_Function__SQL__SUBSTRING_from_for::FB_Common__Sql_ENode_Function__SQL__SUBSTRING_from_for(...) - clone");
#endif

  //----------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif
 }//FB_Common__Sql_ENode_Function__SQL__SUBSTRING_from_for

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ENode_Function__SQL__SUBSTRING_from_for
                                           (SqlExpression         valueExpression,
                                            SqlExpression         fromExpression,
                                            SqlExpression         forExpression,
                                            RelationalTypeMapping resultTypeMapping)
  :this("SUBSTRING",
        new[]{valueExpression,fromExpression,forExpression},
        resultTypeMapping.ClrType,
        resultTypeMapping)
 {
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Function__SQL__SUBSTRING_from_for::FB_Common__Sql_ENode_Function__SQL__SUBSTRING_from_for\n"
   +" (valueExpression   : {0},\n"
   +"  fromExpression    : {1},\n"
   +"  forExpression     : {2},\n"
   +"  resultTypeMapping : {3})",
    valueExpression,
    fromExpression,
    forExpression,
    resultTypeMapping.StoreType);
#endif

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(valueExpression,null));
  Debug.Assert(!Object.ReferenceEquals(fromExpression,null));
  Debug.Assert(!Object.ReferenceEquals(forExpression,null));

#if DEBUG
  this.DEBUG__CheckState();
#endif

  Debug.Assert(Object.ReferenceEquals(this.Arguments[c_ArgIdx__value] ,valueExpression));
  Debug.Assert(Object.ReferenceEquals(this.Arguments[c_ArgIdx__from]  ,fromExpression));
  Debug.Assert(Object.ReferenceEquals(this.Arguments[c_ArgIdx__for]   ,forExpression));
 }//FB_Common__Sql_ENode_Function__SQL__SUBSTRING_from_for

 //-----------------------------------------------------------------------
 public static SqlExpression Create(SqlExpression         valueExpression,
                                    SqlExpression         fromExpression,
                                    SqlExpression         forExpression,
                                    RelationalTypeMapping resultTypeMapping)
 {
#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (valueExpression);

  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (fromExpression);

  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping.ClrType,null));
#endif

  //------------------------------------------------------------
  return new FB_Common__Sql_ENode_Function__SQL__SUBSTRING_from_for
              (valueExpression,
               fromExpression,
               forExpression,
               resultTypeMapping);
 }//Create

 //Expression interface --------------------------------------------------
 public override bool CanReduce
 {
  get
  {
#if TRACE
   Core.Core_Trace.Method
    ("FB_Common__Sql_ENode_Function__SQL__SUBSTRING_from_for::get_CanReduce - false");
#endif

   return false;
  }//get
 }//CanReduce

 //-----------------------------------------------------------------------
 protected override Expression Accept(ExpressionVisitor visitor)
 {
  Debug.Assert(!Object.ReferenceEquals(visitor,null));

#if TRACE
  Core.Core_Trace.Method_Enter
   ("FB_Common__Sql_ENode_Function__SQL__SUBSTRING_from_for::Accept"
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
  }

#if TRACE
  Core.Core_Trace.Method_Exit
   ("FB_Common__Sql_ENode_Function__SQL__SUBSTRING_from_for::Accept"
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
   ="FB_Common__Sql_ENode_Function__SQL__SUBSTRING_from_for::VisitChildren";

  //----------------------------------------
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Function__SQL__SUBSTRING_from_for::VisitChildren\n"
   +" ({0})",
    visitor);
#endif

  //----------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif

  //----------------------------------------
  Expression newValueExpression_e = visitor.Visit(this.Arguments[c_ArgIdx__value]);
  Expression newFromExpression_e  = visitor.Visit(this.Arguments[c_ArgIdx__from]);
  Expression newForExpression_e   = visitor.Visit(this.Arguments[c_ArgIdx__for]);

  //----------------------------------------
  var newValueExpression
   =Check.BugCheck_Value_NotNullAndInstanceOf<SqlExpression,Expression>
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      "newValueExpression_e",
      newValueExpression_e);

  var newFromExpression
   =Check.BugCheck_Value_NotNullAndInstanceOf<SqlExpression,Expression>
     (c_ErrSrcID,
      c_bugcheck_src,
      "#002",
      "newFromExpression_e",
      newFromExpression_e);

  var newForExpression
   =Check.BugCheck_Value_NotNullAndInstanceOf<SqlExpression,Expression>
     (c_ErrSrcID,
      c_bugcheck_src,
      "#003",
      "newForExpression_e",
      newForExpression_e);

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(newValueExpression,null));
  Debug.Assert(!Object.ReferenceEquals(newFromExpression,null));
  Debug.Assert(!Object.ReferenceEquals(newForExpression,null));

  //----------------------------------------
  if(newValueExpression != this.Arguments[c_ArgIdx__value] ||
     newFromExpression  != this.Arguments[c_ArgIdx__from]  ||
     newForExpression   != this.Arguments[c_ArgIdx__for])
  {
   //create new instance

   return new FB_Common__Sql_ENode_Function__SQL__SUBSTRING_from_for
               (this.Name,
                new[]{newValueExpression,newFromExpression,newForExpression},
                this.Type,
                this.TypeMapping);
  }//if

  Debug.Assert(newValueExpression == this.Arguments[c_ArgIdx__value]);
  Debug.Assert(newFromExpression  == this.Arguments[c_ArgIdx__from]);
  Debug.Assert(newForExpression   == this.Arguments[c_ArgIdx__for]);

  return this;
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

  Debug.Assert(c_ArgIdx__from==1);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Update),
    nameof(arguments)+"[1]",
    arguments[c_ArgIdx__from]);

  Debug.Assert(c_ArgIdx__for==2);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Update),
    nameof(arguments)+"[2]",
    arguments[c_ArgIdx__for]);

  //------------------------------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif

  //------------------------------------------------------------
  for(;;)
  {
   if(!Object.ReferenceEquals(this.Arguments[c_ArgIdx__value],arguments[c_ArgIdx__value]))
    break;

   if(!Object.ReferenceEquals(this.Arguments[c_ArgIdx__from],arguments[c_ArgIdx__from]))
    break;

   if(!Object.ReferenceEquals(this.Arguments[c_ArgIdx__for],arguments[c_ArgIdx__for]))
    break;

   return this;
  }//for[ever]

  return new FB_Common__Sql_ENode_Function__SQL__SUBSTRING_from_for
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
   ("FB_Common__Sql_ENode_Function__SQL__SUBSTRING_from_for::Print(...)");
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
  expressionPrinter.Append("SUBSTRING(");
  expressionPrinter.Visit(this.Arguments[c_ArgIdx__value]);
  expressionPrinter.Append(" FROM ");
  expressionPrinter.Visit(this.Arguments[c_ArgIdx__from]);
  expressionPrinter.Append(" FOR ");
  expressionPrinter.Visit(this.Arguments[c_ArgIdx__for]);
  expressionPrinter.Append(")");
 }//Print

 //Helper methods --------------------------------------------------------
 private Expression Helper__Accept__GenerateSql(Sql.FB_Common__QuerySqlGenerator querySqlGenerator)
 {
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Function__SQL__SUBSTRING_from_for::Helper__Accept__GenerateSql(...)");
#endif

  //------------------------------------------------------------
  Debug.Assert(!Object.ReferenceEquals(querySqlGenerator,null));

#if DEBUG
  this.DEBUG__CheckState();
#endif

  //------------------------------------------------------------
  querySqlGenerator.Sql.Append("SUBSTRING(");

  querySqlGenerator.Visit(this.Arguments[c_ArgIdx__value]);

  querySqlGenerator.Sql.Append(" FROM ");

  querySqlGenerator.Visit(this.Arguments[c_ArgIdx__from]);

  querySqlGenerator.Sql.Append(" FOR ");

  querySqlGenerator.Visit(this.Arguments[c_ArgIdx__for]);

  querySqlGenerator.Sql.Append(")");

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
  Debug.Assert(!Object.ReferenceEquals(this.Arguments[c_ArgIdx__from],null));
  Debug.Assert(!Object.ReferenceEquals(this.Arguments[c_ArgIdx__for],null));
 }//DEBUG__CheckState
#endif

 //private data ----------------------------------------------------------
 private static readonly bool[] sm_argumentsPropagateNullability
  =new bool[c_ArgCount]{true,true,true};
};//class FB_Common__Sql_ENode_Function__SQL__SUBSTRING_from_for

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes

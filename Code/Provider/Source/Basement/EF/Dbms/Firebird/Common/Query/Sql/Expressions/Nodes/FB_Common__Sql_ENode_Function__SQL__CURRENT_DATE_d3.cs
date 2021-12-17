////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 03.11.2020.
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes{
////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ENode_Function__SQL__CURRENT_DATE_d3

sealed class FB_Common__Sql_ENode_Function__SQL__CURRENT_DATE_d3
 :FB_Common__Sql_ENode_Function
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__Sql_ENode_Function__SQL__CURRENT_DATE_d3;

 //-----------------------------------------------------------------------
 private const int c_ArgCount=0;

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ENode_Function__SQL__CURRENT_DATE_d3
           (System.String              functionName,
            IEnumerable<SqlExpression> arguments,
            bool                       nullable,
            IEnumerable<bool>          argumentsPropagateNullability,
            System.Type                resultType,
            RelationalTypeMapping      resultTypeMapping)
  :base(functionName,
        arguments,
        nullable,
        argumentsPropagateNullability,
        resultType,
        resultTypeMapping)
 {
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Function__SQL__CURRENT_DATE_d3::FB_Common__Sql_ENode_Function__SQL__CURRENT_DATE_d3(...) - clone");
#endif

  //----------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif
 }//FB_Common__Sql_ENode_Function__SQL__CURRENT_DATE_d3

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ENode_Function__SQL__CURRENT_DATE_d3()
  :this("CURRENT_DATE",
        Structure.Structure_ConstData.Array_SqlExpression__EMPTY, /*arguments*/
        false, /*nullable*/
        Structure.Structure_ConstData.Array_Boolean__EMPTY, /*argumentsPropagateNullability*/
        Common.FB_Common__TypeMappingCache.TypeMapping_D3__TYPE_DATE__as_DateOnly.ClrType,
        Common.FB_Common__TypeMappingCache.TypeMapping_D3__TYPE_DATE__as_DateOnly)
 {
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Function__SQL__CURRENT_DATE_d3::FB_Common__Sql_ENode_Function__SQL__CURRENT_DATE_d3()");
#endif

  //----------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif
 }//FB_Common__Sql_ENode_Function__SQL__CURRENT_DATE_d3

 //-----------------------------------------------------------------------
 public static SqlExpression Create()
 {
  Debug.Assert(!Object.ReferenceEquals(sm_Instance,null));

  return sm_Instance;
 }//Create

 //Expression interface --------------------------------------------------
 public override bool CanReduce
 {
  get
  {
#if TRACE
   Core.Core_Trace.Method
    ("FB_Common__Sql_ENode_Function__SQL__CURRENT_DATE_d3::get_CanReduce - false");
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
   ("FB_Common__Sql_ENode_Function__SQL__CURRENT_DATE_d3::Accept"
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
   ("FB_Common__Sql_ENode_Function__SQL__CURRENT_DATE_d3::Accept"
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
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Function__SQL__CURRENT_DATE_d3::VisitChildren\n"
   +" ({0})",
    visitor);
#endif

  //----------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif

  //----------------------------------------
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
    /*expected*/c_ArgCount);

  //------------------------------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif

  //------------------------------------------------------------
  return this;
 }//Update

 //-----------------------------------------------------------------------
 protected override void Print(ExpressionPrinter expressionPrinter)
 {
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Function__SQL__CURRENT_DATE_d3::Print(...)");
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
  expressionPrinter.Append("CURRENT_DATE");
 }//Print

 //Helper methods --------------------------------------------------------
 private Expression Helper__Accept__GenerateSql(Sql.FB_Common__QuerySqlGenerator querySqlGenerator)
 {
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Function__SQL__CURRENT_DATE_d3::Helper__Accept__GenerateSql(...)");
#endif

  //------------------------------------------------------------
  Debug.Assert(!Object.ReferenceEquals(querySqlGenerator,null));

#if DEBUG
  this.DEBUG__CheckState();
#endif

  //------------------------------------------------------------
  querySqlGenerator.Sql.Append("CURRENT_DATE");

  return this;
 }//Helper__Accept__GenerateSql

 //Debug methods ---------------------------------------------------------
#if DEBUG
 private void DEBUG__CheckState()
 {
  Debug.Assert(Object.ReferenceEquals(this.Instance,null));

  Debug.Assert(!Object.ReferenceEquals(this.Arguments,null));

  Debug.Assert(this.Arguments.Count==c_ArgCount);
 }//DEBUG__CheckState
#endif

 //private data ----------------------------------------------------------
 private static readonly SqlExpression
  sm_Instance
   =new FB_Common__Sql_ENode_Function__SQL__CURRENT_DATE_d3();
};//class FB_Common__Sql_ENode_Function__SQL__CURRENT_DATE_d3

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes

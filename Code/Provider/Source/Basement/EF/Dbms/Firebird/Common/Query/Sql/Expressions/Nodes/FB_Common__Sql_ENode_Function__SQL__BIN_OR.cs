////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 21.11.2020.
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

using Structure_TypeCache
 =Structure.Structure_TypeCache;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ENode_Function__SQL__BIN_OR

sealed class FB_Common__Sql_ENode_Function__SQL__BIN_OR
 :FB_Common__Sql_ENode_Function
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__Sql_ENode_Function__SQL__BIN_OR;

 //-----------------------------------------------------------------------
 private const int c_ArgCount=2;

 private const int c_ArgIdx__left=0;

 private const int c_ArgIdx__right=1;

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ENode_Function__SQL__BIN_OR
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
   ("FB_Common__Sql_ENode_Function__SQL__BIN_OR::FB_Common__Sql_ENode_Function__SQL__BIN_OR(...) - clone");
#endif

  //----------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif
 }//FB_Common__Sql_ENode_Function__SQL__BIN_OR

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ENode_Function__SQL__BIN_OR
                                           (SqlExpression         leftExpression,
                                            SqlExpression         rightExpression,
                                            RelationalTypeMapping resultTypeMapping)
  :this("BIN_OR",
        new[]{leftExpression,rightExpression},
        resultTypeMapping.ClrType,
        resultTypeMapping)
 {
  Debug.Assert(!Object.ReferenceEquals(leftExpression,null));
  Debug.Assert(!Object.ReferenceEquals(rightExpression,null));
  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping.ClrType,null));

  Debug.Assert(!Object.ReferenceEquals(this.TypeMapping,null));

  //----------------------------------------
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Function__SQL__BIN_OR::FB_Common__Sql_ENode_Function__SQL__BIN_OR\n"
   +" (leftExpression  : {0},\n"
   +"  rightExpression : {1},\n"
   +"  resultType      : {2})",
    leftExpression,
    rightExpression,
    resultTypeMapping.ClrType);
#endif

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(leftExpression,null));
  Debug.Assert(!Object.ReferenceEquals(rightExpression,null));

#if DEBUG
  this.DEBUG__CheckState();
#endif

  Debug.Assert(Object.ReferenceEquals(this.Arguments[c_ArgIdx__left]   ,leftExpression));
  Debug.Assert(Object.ReferenceEquals(this.Arguments[c_ArgIdx__right]  ,rightExpression));
 }//FB_Common__Sql_ENode_Function__SQL__BIN_OR

//-----------------------------------------------------------------------
 public static SqlExpression Create(SqlExpression leftExpression,
                                    SqlExpression rightExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(leftExpression,null));
  Debug.Assert(!Object.ReferenceEquals(rightExpression,null));

  //------------------------------------------------------------
  var resultTypeMapping
   =Helper__BuildResultTypeMapping
     (leftExpression,
      rightExpression); //throw

  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping.ClrType,null));

  return new FB_Common__Sql_ENode_Function__SQL__BIN_OR
              (leftExpression,
               rightExpression,
               resultTypeMapping);
 }//Create

 //Expression interface --------------------------------------------------
 public override bool CanReduce
 {
  get
  {
#if TRACE
   Core.Core_Trace.Method
    ("FB_Common__Sql_ENode_Function__SQL__BIN_OR::get_CanReduce - false");
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
   ("FB_Common__Sql_ENode_Function__SQL__BIN_OR::Accept"
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
   ("FB_Common__Sql_ENode_Function__SQL__BIN_OR::Accept"
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
   ="FB_Common__Sql_ENode_Function__SQL__BIN_OR::VisitChildren";

  //----------------------------------------
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Function__SQL__BIN_OR::VisitChildren\n"
   +" ({0})",
    visitor);
#endif

  //----------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif

  //----------------------------------------
  Expression newLeftExpression_e  = visitor.Visit(this.Arguments[c_ArgIdx__left]);
  Expression newRightExpression_e = visitor.Visit(this.Arguments[c_ArgIdx__right]);

  //----------------------------------------
  var newLeftExpression
   =Check.BugCheck_Value_NotNullAndInstanceOf<SqlExpression,Expression>
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      "newLeftExpression_e",
      newLeftExpression_e);

  Debug.Assert(!Object.ReferenceEquals(newLeftExpression,null));

  //----------------------------------------
  var newRightExpression
   =Check.BugCheck_Value_NotNullAndInstanceOf<SqlExpression,Expression>
     (c_ErrSrcID,
      c_bugcheck_src,
      "#002",
      "newRightExpression_e",
      newRightExpression_e);

  Debug.Assert(!Object.ReferenceEquals(newRightExpression,null));

  //----------------------------------------
  for(;;)
  {
   if(newLeftExpression!=this.Arguments[c_ArgIdx__left])
    break;

   if(newRightExpression!=this.Arguments[c_ArgIdx__right])
    break;

   Debug.Assert(this.Arguments.Count==2);

   return this;
  }//for[ever]

  //create new instance

  var resultTypeMapping
   =Helper__BuildResultTypeMapping
     (newLeftExpression,
      newRightExpression); //throw

  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping.ClrType,null));

  return new FB_Common__Sql_ENode_Function__SQL__BIN_OR
              (this.Name,
               new[]{newLeftExpression, newRightExpression},
               resultTypeMapping.ClrType,
               resultTypeMapping);
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

   Debug.Assert(this.Arguments.Count==2);

   return this;
  }//for[ever]

  //create new instance

  var resultTypeMapping
   =Helper__BuildResultTypeMapping
     (arguments[c_ArgIdx__left],
      arguments[c_ArgIdx__right]); //throw

  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping.ClrType,null));

  return new FB_Common__Sql_ENode_Function__SQL__BIN_OR
              (this.Name,
               arguments,
               resultTypeMapping.ClrType,
               resultTypeMapping);
 }//Update

 //-----------------------------------------------------------------------
 protected override void Print(ExpressionPrinter expressionPrinter)
 {
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Function__SQL__BIN_OR::Print(...)");
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
  expressionPrinter.Append("BIN_OR(");
  expressionPrinter.Visit(this.Arguments[c_ArgIdx__left]);
  expressionPrinter.Append(",");
  expressionPrinter.Visit(this.Arguments[c_ArgIdx__right]);
  expressionPrinter.Append(")");
 }//Print

 //Helper methods --------------------------------------------------------
 private Expression Helper__Accept__GenerateSql(Sql.FB_Common__QuerySqlGenerator querySqlGenerator)
 {
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Function__SQL__BIN_OR::Helper__Accept__GenerateSql(...)");
#endif

  //------------------------------------------------------------
  Debug.Assert(!Object.ReferenceEquals(querySqlGenerator,null));

#if DEBUG
  this.DEBUG__CheckState();
#endif

  //------------------------------------------------------------
  querySqlGenerator.Sql.Append("BIN_OR(");

  querySqlGenerator.Visit(this.Arguments[c_ArgIdx__left]);

  querySqlGenerator.Sql.Append(", ");

  querySqlGenerator.Visit(this.Arguments[c_ArgIdx__right]);

  querySqlGenerator.Sql.Append(")");

  return this;
 }//Helper__Accept__GenerateSql

 //-----------------------------------------------------------------------
 private static RelationalTypeMapping Helper__BuildResultTypeMapping
                                           (SqlExpression leftExpression,
                                            SqlExpression rightExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(leftExpression,null));
  Debug.Assert(!Object.ReferenceEquals(rightExpression,null));

  Debug.Assert(!Object.ReferenceEquals(sm_SupportedStates,null));

  return sm_SupportedStates.BuildResultTypeMapping
          (c_ErrSrcID,
           "BIN_OR",
           leftExpression,
           rightExpression);
 }//Helper__BuildResultTypeMapping

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
 private static readonly bool[]
  sm_argumentsPropagateNullability
   =new bool[c_ArgCount]{true,true};

 //-----------------------------------------------------------------------
 private static readonly Helpers.Map_Op2ResultTypeMappings
  sm_SupportedStates
   =new Helpers.Map_Op2ResultTypeMappings()
     .Add(Structure_TypeCache.TypeOf__System_Int16   ,Structure_TypeCache.TypeOf__System_Int16   ,FB_Common__TypeMappingCache.TypeMapping__INT16)
     .Add(Structure_TypeCache.TypeOf__System_Int16   ,Structure_TypeCache.TypeOf__System_Int32   ,FB_Common__TypeMappingCache.TypeMapping__INT32)
     .Add(Structure_TypeCache.TypeOf__System_Int16   ,Structure_TypeCache.TypeOf__System_Int64   ,FB_Common__TypeMappingCache.TypeMapping__INT64)

     .Add(Structure_TypeCache.TypeOf__System_Int32   ,Structure_TypeCache.TypeOf__System_Int16   ,FB_Common__TypeMappingCache.TypeMapping__INT32)
     .Add(Structure_TypeCache.TypeOf__System_Int32   ,Structure_TypeCache.TypeOf__System_Int32   ,FB_Common__TypeMappingCache.TypeMapping__INT32)
     .Add(Structure_TypeCache.TypeOf__System_Int32   ,Structure_TypeCache.TypeOf__System_Int64   ,FB_Common__TypeMappingCache.TypeMapping__INT64)

     .Add(Structure_TypeCache.TypeOf__System_Int64   ,Structure_TypeCache.TypeOf__System_Int16   ,FB_Common__TypeMappingCache.TypeMapping__INT64)
     .Add(Structure_TypeCache.TypeOf__System_Int64   ,Structure_TypeCache.TypeOf__System_Int32   ,FB_Common__TypeMappingCache.TypeMapping__INT64)
     .Add(Structure_TypeCache.TypeOf__System_Int64   ,Structure_TypeCache.TypeOf__System_Int64   ,FB_Common__TypeMappingCache.TypeMapping__INT64)

     // [2020-12-24] Object for NULL value?

     /*END*/
     ;
};//class FB_Common__Sql_ENode_Function__SQL__BIN_OR

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes

////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 01.04.2019.
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
//class FB_Common__Sql_ENode_Function__SQL__ROUND_scale

sealed class FB_Common__Sql_ENode_Function__SQL__ROUND_scale
 :FB_Common__Sql_ENode_Function
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__Sql_ENode_Function__SQL__ROUND_scale;

 //-----------------------------------------------------------------------
 private const int c_ArgCount=2;

 private const int c_ArgIdx__value=0;

 private const int c_ArgIdx__scale=1;

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ENode_Function__SQL__ROUND_scale
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
   ("FB_Common__Sql_ENode_Function__SQL__ROUND_scale::FB_Common__Sql_ENode_Function__SQL__ROUND_scale(...) - clone");
#endif

  //----------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif
 }//FB_Common__Sql_ENode_Function__SQL__ROUND_scale

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ENode_Function__SQL__ROUND_scale
                                           (SqlExpression         valueExpression,
                                            SqlExpression         scaleExpression,
                                            RelationalTypeMapping resultTypeMapping)
  :this("ROUND",
        new[]{valueExpression,scaleExpression},
        resultTypeMapping.ClrType,
        resultTypeMapping)
 {
  Debug.Assert(!Object.ReferenceEquals(valueExpression,null));
  Debug.Assert(!Object.ReferenceEquals(scaleExpression,null));
  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping.ClrType,null));

  Debug.Assert(!Object.ReferenceEquals(this.TypeMapping,null));

  //----------------------------------------
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Function__SQL__ROUND_scale::FB_Common__Sql_ENode_Function__SQL__ROUND_scale\n"
   +" (valueExpression  : {0},\n"
   +"  scaleExpression  : {1},\n"
   +"  resultType       : {2})",
    valueExpression,
    scaleExpression,
    resultTypeMapping.ClrType);
#endif

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(valueExpression,null));
  Debug.Assert(!Object.ReferenceEquals(scaleExpression,null));

#if DEBUG
  this.DEBUG__CheckState();
#endif

  Debug.Assert(Object.ReferenceEquals(this.Arguments[c_ArgIdx__value],valueExpression));
  Debug.Assert(Object.ReferenceEquals(this.Arguments[c_ArgIdx__scale],scaleExpression));
 }//FB_Common__Sql_ENode_Function__SQL__ROUND_scale

//-----------------------------------------------------------------------
 public static SqlExpression Create(SqlExpression         valueExpression,
                                    SqlExpression         scaleExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(valueExpression,null));
  Debug.Assert(!Object.ReferenceEquals(valueExpression.Type,null));
  Debug.Assert(!Object.ReferenceEquals(valueExpression.TypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(valueExpression.TypeMapping.ClrType,null));

  Debug.Assert(!Object.ReferenceEquals(scaleExpression,null));
  Debug.Assert(!Object.ReferenceEquals(scaleExpression.Type,null));
  Debug.Assert(!Object.ReferenceEquals(scaleExpression.TypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(scaleExpression.TypeMapping.ClrType,null));

  //------------------------------------------------------------
  var resultTypeMapping
   =Helper__BuildResultTypeMapping
     (valueExpression,
      scaleExpression); //throw

  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping.ClrType,null));

  return new FB_Common__Sql_ENode_Function__SQL__ROUND_scale
              (valueExpression,
               scaleExpression,
               resultTypeMapping);
 }//Create

 //Expression interface --------------------------------------------------
 public override bool CanReduce
 {
  get
  {
#if TRACE
   Core.Core_Trace.Method
    ("FB_Common__Sql_ENode_Function__SQL__ROUND_scale::get_CanReduce - false");
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
   ("FB_Common__Sql_ENode_Function__SQL__ROUND_scale::Accept"
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
   ("FB_Common__Sql_ENode_Function__SQL__ROUND_scale::Accept"
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
   ="FB_Common__Sql_ENode_Function__SQL__ROUND_scale::VisitChildren";

  //----------------------------------------
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Function__SQL__ROUND_scale::VisitChildren\n"
   +" ({0})",
    visitor);
#endif

  //----------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif

  //----------------------------------------
  Expression newValueExpression_e = visitor.Visit(this.Arguments[c_ArgIdx__value]);
  Expression newScaleExpression_e = visitor.Visit(this.Arguments[c_ArgIdx__scale]);

  //----------------------------------------
  var newValueExpression
   =Check.BugCheck_Value_NotNullAndInstanceOf<SqlExpression,Expression>
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      "newValueExpression_e",
      newValueExpression_e);

  Debug.Assert(!Object.ReferenceEquals(newValueExpression,null));

  //----------------------------------------
  var newScaleExpression
   =Check.BugCheck_Value_NotNullAndInstanceOf<SqlExpression,Expression>
     (c_ErrSrcID,
      c_bugcheck_src,
      "#002",
      "newScaleExpression_e",
      newScaleExpression_e);

  Debug.Assert(!Object.ReferenceEquals(newScaleExpression,null));

  //----------------------------------------
  for(;;)
  {
   if(newValueExpression!=this.Arguments[c_ArgIdx__value])
    break;

   if(newScaleExpression!=this.Arguments[c_ArgIdx__scale])
    break;

   Debug.Assert(this.Arguments.Count==2);

   return this;
  }//for[ever]

  //create new instance

  var resultTypeMapping
   =Helper__BuildResultTypeMapping
     (newValueExpression,
      newScaleExpression); //throw

  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping.ClrType,null));

  return new FB_Common__Sql_ENode_Function__SQL__ROUND_scale
              (this.Name,
               new[]{newValueExpression,newScaleExpression},
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

  Debug.Assert(c_ArgIdx__value==0);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Update),
    nameof(arguments)+"[0]",
    arguments[c_ArgIdx__value]);

  Debug.Assert(c_ArgIdx__scale==1);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Update),
    nameof(arguments)+"[1]",
    arguments[c_ArgIdx__scale]);

  //------------------------------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif

  //------------------------------------------------------------
  for(;;)
  {
   if(!Object.ReferenceEquals(this.Arguments[c_ArgIdx__value],arguments[c_ArgIdx__value]))
    break;

   if(!Object.ReferenceEquals(this.Arguments[c_ArgIdx__scale],arguments[c_ArgIdx__scale]))
    break;

   Debug.Assert(this.Arguments.Count==2);

   return this;
  }//for[ever]

  //create new instance

  var resultTypeMapping
   =Helper__BuildResultTypeMapping
     (arguments[c_ArgIdx__value],
      arguments[c_ArgIdx__scale]); //throw

  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping.ClrType,null));

  return new FB_Common__Sql_ENode_Function__SQL__ROUND_scale
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
   ("FB_Common__Sql_ENode_Function__SQL__ROUND_scale::Print(...)");
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
  expressionPrinter.Append("ROUND(");
  expressionPrinter.Visit(this.Arguments[c_ArgIdx__value]);
  expressionPrinter.Append(", ");
  expressionPrinter.Visit(this.Arguments[c_ArgIdx__scale]);
  expressionPrinter.Append(")");
 }//Print

 //Helper methods --------------------------------------------------------
 private Expression Helper__Accept__GenerateSql(Sql.FB_Common__QuerySqlGenerator querySqlGenerator)
 {
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Function__SQL__ROUND_scale::Helper__Accept__GenerateSql(...)");
#endif

  //------------------------------------------------------------
  Debug.Assert(!Object.ReferenceEquals(querySqlGenerator,null));

#if DEBUG
  this.DEBUG__CheckState();
#endif

  //------------------------------------------------------------
  querySqlGenerator.Sql.Append("ROUND(");

  querySqlGenerator.Visit(this.Arguments[c_ArgIdx__value]);

  querySqlGenerator.Sql.Append(", ");

  querySqlGenerator.Visit(this.Arguments[c_ArgIdx__scale]);

  querySqlGenerator.Sql.Append(")");

  return this;
 }//Helper__Accept__GenerateSql

 //-----------------------------------------------------------------------
 private static RelationalTypeMapping Helper__BuildResultTypeMapping
                                           (SqlExpression valueExpression,
                                            SqlExpression scaleExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(valueExpression,null));
  Debug.Assert(!Object.ReferenceEquals(scaleExpression,null));

  //------------------------------------------------------------
  const string c_bugcheck_src
   ="FB_Common__Sql_ENode_Function__SQL__ROUND_scale::Helper__BuildResultTypeMapping";

  //------------------------------------------------------------
  //check type of scale

  for(;;)
  {
   var scaleType
    =Core.SQL.Core_SQL__ExpressionUtils.GetSqlType
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      scaleExpression);

   Debug.Assert(!Object.ReferenceEquals(scaleType,null));

   if(scaleType==Structure_TypeCache.TypeOf__System_Int16)
    break;

   if(scaleType==Structure_TypeCache.TypeOf__System_Int32)
    break;

   if(scaleType==Structure_TypeCache.TypeOf__System_Int64)
    break;

   if(scaleType==Structure_TypeCache.TypeOf__System_Decimal)
    break;

   // [2020-12-24] Object for NULL value?

   Helper__ThrowBugCheck__UnsupportedArgTypes
    (valueExpression,
     scaleExpression);
  }//for

  //------------------------------------------------------------
  var valueType
   =Core.SQL.Core_SQL__ExpressionUtils.GetSqlType
    (c_ErrSrcID,
     c_bugcheck_src,
     "#002",
     valueExpression);

  Debug.Assert(!Object.ReferenceEquals(valueType,null));

  if(valueType==Structure_TypeCache.TypeOf__System_Int16)
   return FB_Common__TypeMappingCache.TypeMapping__INT16;

  if(valueType==Structure_TypeCache.TypeOf__System_Int32)
   return FB_Common__TypeMappingCache.TypeMapping__INT32;

  if(valueType==Structure_TypeCache.TypeOf__System_Int64)
   return FB_Common__TypeMappingCache.TypeMapping__INT64;

  if(valueType==Structure_TypeCache.TypeOf__System_Single)
   return FB_Common__TypeMappingCache.TypeMapping__FLOAT;

  if(valueType==Structure_TypeCache.TypeOf__System_Double)
   return FB_Common__TypeMappingCache.TypeMapping__DOUBLE;

  if(valueType==Structure_TypeCache.TypeOf__System_Decimal)
   return FB_Common__TypeMappingCache.TypeMapping__DECIMAL;

  // [2020-12-24] Object for NULL value?

  Helper__ThrowBugCheck__UnsupportedArgTypes
   (valueExpression,
    scaleExpression);

  return null;
 }//Helper__BuildResultTypeMapping

 //-----------------------------------------------------------------------
 private static void Helper__ThrowBugCheck__UnsupportedArgTypes
                                           (SqlExpression valueExpression,
                                            SqlExpression scaleExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(valueExpression,null));
  Debug.Assert(!Object.ReferenceEquals(scaleExpression,null));

  //------------------------------------------------------------
  ThrowBugCheck.SqlENode__UnsupportedArgTypes
   (c_ErrSrcID,
    "ROUND",
    valueExpression,
    scaleExpression);
 }//Helper__ThrowBugCheck__UnsupportedArgTypes

 //Debug methods ---------------------------------------------------------
#if DEBUG
 private void DEBUG__CheckState()
 {
  Debug.Assert(Object.ReferenceEquals(this.Instance,null));

  Debug.Assert(!Object.ReferenceEquals(this.Arguments,null));

  Debug.Assert(this.Arguments.Count==c_ArgCount);

  Debug.Assert(!Object.ReferenceEquals(this.Arguments[c_ArgIdx__value],null));
  Debug.Assert(!Object.ReferenceEquals(this.Arguments[c_ArgIdx__scale],null));
 }//DEBUG__CheckState
#endif

 //private data ----------------------------------------------------------
 private static readonly bool[] sm_argumentsPropagateNullability
  =new bool[c_ArgCount]{true,true};
};//class FB_Common__Sql_ENode_Function__SQL__ROUND_scale

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes

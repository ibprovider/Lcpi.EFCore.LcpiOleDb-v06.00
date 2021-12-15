////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 14.09.2021.
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D3.Expressions.Nodes{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

using FB_Common__Sql_ENode_Function
 =Common.Query.Sql.Expressions.Nodes.FB_Common__Sql_ENode_Function;

using FB_Common__QuerySqlGenerator
 =Common.Query.Sql.FB_Common__QuerySqlGenerator;

using FB_Common__TypeMappingCache
 =Common.FB_Common__TypeMappingCache;

////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0_D3__Sql_ENode_Function__SQL__SUM

sealed class FB_V03_0_0_D3__Sql_ENode_Function__SQL__SUM
 :FB_Common__Sql_ENode_Function
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_V03_0_0_D3__Sql_ENode_Function__SQL__SUM;

 //-----------------------------------------------------------------------
 private const string c_FuncName="SUM";

 private const int c_ArgCount=1;

 private const int c_ArgIdx__value=0;

 //-----------------------------------------------------------------------
 private FB_V03_0_0_D3__Sql_ENode_Function__SQL__SUM
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
   ("FB_V03_0_0_D3__Sql_ENode_Function__SQL__SUM::FB_V03_0_0_D3__Sql_ENode_Function__SQL__SUM(...) - clone");
#endif

  //----------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif
 }//FB_V03_0_0_D3__Sql_ENode_Function__SQL__SUM

 //-----------------------------------------------------------------------
 private FB_V03_0_0_D3__Sql_ENode_Function__SQL__SUM
                                           (SqlExpression         valueExpression,
                                            RelationalTypeMapping resultTypeMapping)
  :this(c_FuncName,
        new[]{valueExpression},
        true, /*nullable*/
        sm_argumentsPropagateNullability,
        resultTypeMapping.ClrType,
        resultTypeMapping)
 {
  Debug.Assert(!Object.ReferenceEquals(valueExpression,null));
  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping.ClrType,null));

  Debug.Assert(!Object.ReferenceEquals(this.TypeMapping,null));

  //----------------------------------------
#if TRACE
  Core.Core_Trace.Method
   ("FB_V03_0_0_D3__Sql_ENode_Function__SQL__SUM::FB_V03_0_0_D3__Sql_ENode_Function__SQL__SUM\n"
   +" (valueExpression  : {0},\n"
   +"  resultType       : {1})",
    valueExpression,
    resultTypeMapping.ClrType);
#endif

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(valueExpression,null));

#if DEBUG
  this.DEBUG__CheckState();
#endif

  Debug.Assert(Object.ReferenceEquals(this.Arguments[c_ArgIdx__value],valueExpression));
 }//FB_V03_0_0_D3__Sql_ENode_Function__SQL__SUM

//-----------------------------------------------------------------------
 public static SqlExpression Create(SqlExpression valueExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(valueExpression,null));
  Debug.Assert(!Object.ReferenceEquals(valueExpression.Type,null));
  Debug.Assert(!Object.ReferenceEquals(valueExpression.TypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(valueExpression.TypeMapping.ClrType,null));

  // [2020-11-30] Expected
  Debug.Assert(valueExpression.Type.Extension__UnwrapNullableType()==valueExpression.Type);

  //------------------------------------------------------------
  if(valueExpression is FB_V03_0_0_D3__Sql_ENode_Function__SQL__SUM e)
  {
#if DEBUG
   e.DEBUG__CheckState();
#endif

   return e;
  }//if

  //------------------------------------------------------------
  var resultTypeMapping
   =Helper__BuildResultTypeMapping
     (valueExpression); //throw

  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping.ClrType,null));

  return new FB_V03_0_0_D3__Sql_ENode_Function__SQL__SUM
              (valueExpression,
               resultTypeMapping);
 }//Create

 //Expression interface --------------------------------------------------
 public override bool CanReduce
 {
  get
  {
#if TRACE
   Core.Core_Trace.Method
    ("FB_V03_0_0_D3__Sql_ENode_Function__SQL__SUM::get_CanReduce - false");
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
   ("FB_V03_0_0_D3__Sql_ENode_Function__SQL__SUM::Accept"
   +" (visitorType: {0})",
    visitor.GetType());
#endif

  Expression r;

  if(visitor is FB_Common__QuerySqlGenerator x)
  {
   r=this.Helper__Accept__GenerateSql(x);
  }
  else
  {
   r=base.Accept(visitor);
  }//else

#if TRACE
  Core.Core_Trace.Method_Exit
   ("FB_V03_0_0_D3__Sql_ENode_Function__SQL__SUM::Accept"
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
   ="FB_V03_0_0_D3__Sql_ENode_Function__SQL__SUM::VisitChildren";

  //----------------------------------------
#if TRACE
  Core.Core_Trace.Method
   ("FB_V03_0_0_D3__Sql_ENode_Function__SQL__SUM::VisitChildren\n"
   +" ({0})",
    visitor);
#endif

  //----------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif

  //----------------------------------------
  Expression newValueExpression_e = visitor.Visit(this.Arguments[c_ArgIdx__value]);

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
  for(;;)
  {
   if(newValueExpression!=this.Arguments[c_ArgIdx__value])
    break;

   Debug.Assert(this.Arguments.Count==1);

   return this;
  }//for[ever]

  //create new instance

  var resultTypeMapping
   =Helper__BuildResultTypeMapping
     (newValueExpression); //throw

  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping.ClrType,null));

  return new FB_V03_0_0_D3__Sql_ENode_Function__SQL__SUM
              (this.Name,
               new[]{newValueExpression},
               this.IsNullable,
               this.ArgumentsPropagateNullability,
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

  //------------------------------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif

  //------------------------------------------------------------
  for(;;)
  {
   if(!Object.ReferenceEquals(this.Arguments[c_ArgIdx__value],arguments[c_ArgIdx__value]))
    break;

   Debug.Assert(this.Arguments.Count==1);

   return this;
  }//for[ever]

  //create new instance

  var resultTypeMapping
   =Helper__BuildResultTypeMapping
     (arguments[c_ArgIdx__value]); //throw

  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping.ClrType,null));

  return new FB_V03_0_0_D3__Sql_ENode_Function__SQL__SUM
              (this.Name,
               arguments,
               this.IsNullable,
               this.ArgumentsPropagateNullability,
               resultTypeMapping.ClrType,
               resultTypeMapping);
 }//Update

 //-----------------------------------------------------------------------
 protected override void Print(ExpressionPrinter expressionPrinter)
 {
#if TRACE
  Core.Core_Trace.Method
   ("FB_V03_0_0_D3__Sql_ENode_Function__SQL__SUM::Print(...)");
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
  expressionPrinter.Append(c_FuncName+'(');
  expressionPrinter.Visit(this.Arguments[c_ArgIdx__value]);
  expressionPrinter.Append(")");
 }//Print

 //Helper methods --------------------------------------------------------
 private Expression Helper__Accept__GenerateSql(FB_Common__QuerySqlGenerator querySqlGenerator)
 {
#if TRACE
  Core.Core_Trace.Method
   ("FB_V03_0_0_D3__Sql_ENode_Function__SQL__SUM::Helper__Accept__GenerateSql(...)");
#endif

  //------------------------------------------------------------
  Debug.Assert(!Object.ReferenceEquals(querySqlGenerator,null));

#if DEBUG
  this.DEBUG__CheckState();
#endif

  //------------------------------------------------------------
  querySqlGenerator.Sql.Append(c_FuncName+'(');

  querySqlGenerator.Visit(this.Arguments[c_ArgIdx__value]);

  querySqlGenerator.Sql.Append(")");

  return this;
 }//Helper__Accept__GenerateSql

 //-----------------------------------------------------------------------
 private static RelationalTypeMapping Helper__BuildResultTypeMapping
                                           (SqlExpression valueExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(valueExpression,null));

  //------------------------------------------------------------
  const string c_bugcheck_src
   ="FB_V03_0_0_D3__Sql_ENode_Function__SQL__SUM::Helper__BuildResultTypeMapping";

  //------------------------------------------------------------
  var valueType
   =Core.SQL.Core_SQL__ExpressionUtils.GetSqlType
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      valueExpression);

  Debug.Assert(!Object.ReferenceEquals(valueType,null));

  //[2020-11-30] Research
  //[2020-12-01] Ok, Enums.
  //Debug.Assert(valueExpression.Type==valueType);

  if(valueType==Structure_TypeCache.TypeOf__System_Int16)
   return FB_Common__TypeMappingCache.TypeMapping__INT64;

  if(valueType==Structure_TypeCache.TypeOf__System_Int32)
   return FB_Common__TypeMappingCache.TypeMapping__INT64;

  if(valueType==Structure_TypeCache.TypeOf__System_Int64)
   return FB_Common__TypeMappingCache.TypeMapping__INT64;

  if(valueType==Structure_TypeCache.TypeOf__System_Single)
   return FB_Common__TypeMappingCache.TypeMapping__DOUBLE;

  if(valueType==Structure_TypeCache.TypeOf__System_Double)
   return FB_Common__TypeMappingCache.TypeMapping__DOUBLE;

  if(valueType==Structure_TypeCache.TypeOf__System_Decimal)
  {
   return Helper__GetResultTypeMapping__Decimal(valueExpression);
  }//if

  // [2020-12-24] Object for NULL value?

  ThrowBugCheck.SqlENode__UnsupportedArgTypes
   (c_ErrSrcID,
    c_FuncName,
    valueExpression);

  return null;
 }//Helper__BuildResultTypeMapping

 //-----------------------------------------------------------------------
 private static RelationalTypeMapping Helper__GetResultTypeMapping__Decimal(SqlExpression sqlArg)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlArg,null));

  // [2021-09-12] Expected
  Debug.Assert(!Object.ReferenceEquals(sqlArg.TypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(sqlArg.TypeMapping.ClrType,null));

  var sqlArgTypeMapping
   =sqlArg.TypeMapping;

  if(!sqlArgTypeMapping.Precision.HasValue)
  {
   Debug.Assert(!sqlArgTypeMapping.Scale.HasValue);

   return
    Common.Storage.Mapping.FB_Common__TypeMapping__NUMERIC.Create
     (/*precision*/Core.Engines.Dbms.IscBase.IscBase_Const.c_max_numeric_precision,
      /*scale*/0);
  }//if

  Debug.Assert(sqlArgTypeMapping.Precision.HasValue);
  Debug.Assert(sqlArgTypeMapping.Precision.Value<=Core.Engines.Dbms.IscBase.IscBase_Const.c_max_numeric_precision);

  if(!sqlArgTypeMapping.Scale.HasValue)
  {
   return
    Common.Storage.Mapping.FB_Common__TypeMapping__NUMERIC.Create
     (/*precision*/Core.Engines.Dbms.IscBase.IscBase_Const.c_max_numeric_precision,
      /*scale*/0);
  }//if

  Debug.Assert(sqlArgTypeMapping.Scale.HasValue);
  Debug.Assert(sqlArgTypeMapping.Scale.Value<=Core.Engines.Dbms.IscBase.IscBase_Const.c_max_numeric_precision);

  return
   Common.Storage.Mapping.FB_Common__TypeMapping__NUMERIC.Create
    (/*precision*/Core.Engines.Dbms.IscBase.IscBase_Const.c_max_numeric_precision,
     /*scale*/sqlArgTypeMapping.Scale.Value);
 }//Helper__GetResultTypeMapping__Decimal

 //Debug methods ---------------------------------------------------------
#if DEBUG
 private void DEBUG__CheckState()
 {
  Debug.Assert(Object.ReferenceEquals(this.Instance,null));

  Debug.Assert(!Object.ReferenceEquals(this.Arguments,null));

  Debug.Assert(this.Arguments.Count==c_ArgCount);

  Debug.Assert(!Object.ReferenceEquals(this.Arguments[c_ArgIdx__value],null));
 }//DEBUG__CheckState
#endif

 //private data ----------------------------------------------------------
 private static readonly bool[]
  sm_argumentsPropagateNullability
   =new bool[c_ArgCount]{false};                                // <------ FALSE !!!
};//class FB_V03_0_0_D3__Sql_ENode_Function__SQL__SUM

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D3.Expressions.Nodes

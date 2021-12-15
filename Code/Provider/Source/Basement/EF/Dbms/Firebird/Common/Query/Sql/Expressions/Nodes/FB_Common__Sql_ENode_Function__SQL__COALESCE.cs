////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 23.06.2021.
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes{
////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ENode_Function__SQL__COALESCE

sealed class FB_Common__Sql_ENode_Function__SQL__COALESCE
 :FB_Common__Sql_ENode_Function
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__Sql_ENode_Function__SQL__COALESCE;

 //-----------------------------------------------------------------------
 private const int c_MinArgCount=2;

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ENode_Function__SQL__COALESCE
           (System.String                     functionName,
            IReadOnlyList<SqlExpression>      arguments,
            System.Type                       resultType,
            RelationalTypeMapping             resultTypeMapping,
            Helpers.Map_Op2ResultTypeMappings supportedStates)
  :base(functionName,
        Helper__RepackArguments(arguments),
        Core.SQL.Core_SQL__TestNullable.TestNullable_ALL(arguments),
        Helper__CreateArgumentsPropagateNullability(arguments),
        resultType,
        resultTypeMapping)
 {
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Function__SQL__COALESCE::FB_Common__Sql_ENode_Function__SQL__COALESCE(...) - clone");
#endif

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(supportedStates,null));

  //----------------------------------------
  m_SupportedStates=supportedStates;

  //----------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif
 }//FB_Common__Sql_ENode_Function__SQL__COALESCE

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ENode_Function__SQL__COALESCE
                                           (IReadOnlyList<SqlExpression>      arguments,
                                            RelationalTypeMapping             resultTypeMapping,
                                            Helpers.Map_Op2ResultTypeMappings supportedStates)
  :this("COALESCE",
        arguments,
        resultTypeMapping.ClrType,
        resultTypeMapping,
        supportedStates)
 {
  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping.ClrType,null));

  Debug.Assert(!Object.ReferenceEquals(this.TypeMapping,null));

  //----------------------------------------
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Function__SQL__COALESCE::FB_Common__Sql_ENode_Function__SQL__COALESCE(...)");
#endif

  //----------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif
 }//FB_Common__Sql_ENode_Function__SQL__COALESCE

//-----------------------------------------------------------------------
 public static SqlExpression Create(IReadOnlyList<SqlExpression>      expressions,
                                    Helpers.Map_Op2ResultTypeMappings resultRules)
 {
  Debug.Assert(!Object.ReferenceEquals(expressions,null));
  Debug.Assert(expressions.Count>=c_MinArgCount);

  Debug.Assert(!Object.ReferenceEquals(resultRules,null));

  //------------------------------------------------------------
  var resultTypeMapping
   =resultRules.BuildResultTypeMapping
     (c_ErrSrcID,
      "COALESCE",
      expressions); //throw

  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping.ClrType,null));

  return new FB_Common__Sql_ENode_Function__SQL__COALESCE
              (expressions,
               resultTypeMapping,
               resultRules);
 }//Create

 //Expression interface --------------------------------------------------
 public override bool CanReduce
 {
  get
  {
#if TRACE
   Core.Core_Trace.Method
    ("FB_Common__Sql_ENode_Function__SQL__COALESCE::get_CanReduce - false");
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
   ("FB_Common__Sql_ENode_Function__SQL__COALESCE::Accept"
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
   ("FB_Common__Sql_ENode_Function__SQL__COALESCE::Accept"
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
   ="FB_Common__Sql_ENode_Function__SQL__COALESCE::VisitChildren";

  //----------------------------------------
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Function__SQL__COALESCE::VisitChildren\n"
   +" ({0})",
    visitor);
#endif

  //----------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(this.Arguments,null));
  Debug.Assert(this.Arguments.Count>1);

  var newExpressions
   =new SqlExpression[this.Arguments.Count];

  for(int i=0,_c=this.Arguments.Count;i!=_c;++i)
  {
   var newExpression_e
    =visitor.Visit
      (this.Arguments[i]);

   var newExpression
    =Check.BugCheck_Value_NotNullAndInstanceOf<SqlExpression,Expression>
      (c_ErrSrcID,
       c_bugcheck_src,
       "#001",
       nameof(newExpression_e)+"["+i+"]",
       newExpression_e);

   Debug.Assert(!Object.ReferenceEquals(newExpression,null));

   newExpressions[i]
    =newExpression;
  }//for i

  //----------------------------------------
  if(newExpressions.SequenceEqual(this.Arguments))
   return this;

  //create new instance

  var resultTypeMapping
   =Helper__BuildResultTypeMapping
     (newExpressions); //throw

  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping.ClrType,null));

  return new FB_Common__Sql_ENode_Function__SQL__COALESCE
              (this.Name,
               newExpressions,
               resultTypeMapping.ClrType,
               resultTypeMapping,
               m_SupportedStates);
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

  Check.Arg_ListSize__GreaterThanOrEqual
   (c_ErrSrcID,
    nameof(Update),
    nameof(arguments),
    arguments.Count,
    c_MinArgCount);

  //------------------------------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif

  //------------------------------------------------------------
  if(this.Arguments.SequenceEqual(arguments))
   return this;

  //create new instance

  var resultTypeMapping
   =Helper__BuildResultTypeMapping
     (arguments); //throw

  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping.ClrType,null));

  return new FB_Common__Sql_ENode_Function__SQL__COALESCE
              (this.Name,
               arguments,
               resultTypeMapping.ClrType,
               resultTypeMapping,
               m_SupportedStates);
 }//Update

 //-----------------------------------------------------------------------
 protected override void Print(ExpressionPrinter expressionPrinter)
 {
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Function__SQL__COALESCE::Print(...)");
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
  expressionPrinter.Append("COALESCE(");

  string sep="";

  foreach(var e in this.Arguments)
  {
   Debug.Assert(!Object.ReferenceEquals(e,null));

   expressionPrinter.Append(sep);

   expressionPrinter.Visit(e);

   sep=", ";
  }//for e

  expressionPrinter.Append(")");
 }//Print

 //Object interface ------------------------------------------------------
 public override bool Equals(object obj)
 {
#if TRACE
  Core.Core_Trace.Method_Enter
   ("FB_Common__Sql_ENode_Function__SQL__COALESCE::Equals\n"
   +" ({0})",
    obj);
#endif

  //------------------------------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif

  //------------------------------------------------------------
  bool r;

  if(Object.ReferenceEquals(obj,null))
  {
   r=false;
  }
  else
  if(Object.ReferenceEquals(obj,this))
  {
   r=true;
  }
  else
  if(obj.GetType()!=this.GetType())
  {
   r=false;
  }
  else
  {
   var typedObj=(FB_Common__Sql_ENode_Function__SQL__COALESCE)obj;

   Debug.Assert(!Object.ReferenceEquals(typedObj,null));

   Debug.Assert(!Object.ReferenceEquals(typedObj.m_SupportedStates,null));

   if(!base.Helper__Equals(typedObj))
   {
    r=false;
   }
   else
   if(!Object.ReferenceEquals(typedObj.m_SupportedStates,m_SupportedStates))
   {
    r=false;
   }
   else
   {
    r=true;
   }//else
  }//else

#if TRACE
  Core.Core_Trace.Method_Exit
   ("FB_Common__Sql_ENode_Function__SQL__COALESCE::Equals\n"
   +" ({0}) - {1}",
    obj,
    r);
#endif

  return r;
 }//Equals

 //-----------------------------------------------------------------------
 public override int GetHashCode()
 {
#if TRACE
  Core.Core_Trace.Method_Enter
   ("FB_Common__Sql_ENode_Function__SQL__COALESCE::GetHashCode()");
#endif

  //------------------------------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif

  //------------------------------------------------------------
  unchecked
  {
   Debug.Assert(!Object.ReferenceEquals(m_SupportedStates,null));

   //-----
   var hashCode=base.GetHashCode();

   hashCode=(hashCode*397)^m_SupportedStates.GetHashCode();

#if TRACE
  Core.Core_Trace.Method_Exit
   ("FB_Common__Sql_ENode_Function__SQL__COALESCE::GetHashCode() - {0}",
    hashCode);
#endif

   return hashCode;
  }//unchecked
 }//GetHashCode

 //Helper methods --------------------------------------------------------
 private Expression Helper__Accept__GenerateSql(Sql.FB_Common__QuerySqlGenerator querySqlGenerator)
 {
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Function__SQL__COALESCE::Helper__Accept__GenerateSql(...)");
#endif

  //------------------------------------------------------------
  Debug.Assert(!Object.ReferenceEquals(querySqlGenerator,null));

#if DEBUG
  this.DEBUG__CheckState();
#endif

  //------------------------------------------------------------
  querySqlGenerator.Sql.Append("COALESCE(");

  string sep="";

  foreach(var e in this.Arguments)
  {
   Debug.Assert(!Object.ReferenceEquals(e,null));

   querySqlGenerator.Sql.Append(sep);

   querySqlGenerator.Visit(e);

   sep=", ";
  }//for e

  querySqlGenerator.Sql.Append(")");

  return this;
 }//Helper__Accept__GenerateSql

 //-----------------------------------------------------------------------
 private static IReadOnlyCollection<SqlExpression> Helper__RepackArguments(IReadOnlyList<SqlExpression> arguments)
 {
  Debug.Assert(!Object.ReferenceEquals(arguments,null));

  int iArg=0;
  int cArgs=arguments.Count;

  for(;iArg!=cArgs;++iArg)
  {
   var a=arguments[iArg];

   Debug.Assert(!Object.ReferenceEquals(a,null));

   var a2=a as FB_Common__Sql_ENode_Function__SQL__COALESCE;

   if(Object.ReferenceEquals(a2,null))
    continue;

   var newArguments
    =new List<SqlExpression>();

   Helper__Append_N(newArguments,arguments,iArg);

   Helper__Append(newArguments,a2.Arguments);

   ++iArg;

   Debug.Assert(iArg<=cArgs);

   for(;iArg!=cArgs;++iArg)
   {
    a=arguments[iArg];

    Debug.Assert(!Object.ReferenceEquals(a,null));

    a2=a as FB_Common__Sql_ENode_Function__SQL__COALESCE;

    if(Object.ReferenceEquals(a2,null))
     newArguments.Add(a);
    else
     Helper__Append(newArguments,a2.Arguments);
   }//for iArg

   return newArguments;
  }//for iArg

  return arguments;
 }//Helper__RepackArguments

 //-----------------------------------------------------------------------
 private static void Helper__Append(List<SqlExpression>          target,
                                    IReadOnlyList<SqlExpression> source)
 {
  Debug.Assert(!Object.ReferenceEquals(target,null));
  Debug.Assert(!Object.ReferenceEquals(source,null));

  Helper__Append_N
   (target,
    source,
    source.Count);
 }//Helper__Append

 //-----------------------------------------------------------------------
 private static void Helper__Append_N(List<SqlExpression>          target,
                                      IReadOnlyList<SqlExpression> source,
                                      int                          count)
 {
  Debug.Assert(!Object.ReferenceEquals(target,null));
  Debug.Assert(!Object.ReferenceEquals(source,null));

  Debug.Assert(count>=0);
  Debug.Assert(count<=source.Count);

  for(int i=0;i!=count;++i)
  {
   var a=source[i];

   Debug.Assert(!Object.ReferenceEquals(a,null));

   target.Add(a);
  }//foreach x
 }//Helper__Append_N

 //-----------------------------------------------------------------------
 private RelationalTypeMapping Helper__BuildResultTypeMapping
                                           (IReadOnlyList<SqlExpression> arguments)
 {
  Debug.Assert(!Object.ReferenceEquals(arguments,null));
  Debug.Assert(arguments.Count>0);

  Debug.Assert(!Object.ReferenceEquals(m_SupportedStates,null));

  return m_SupportedStates.BuildResultTypeMapping
          (c_ErrSrcID,
           "COALESCE",
           arguments);
 }//Helper__BuildResultTypeMapping

 //-----------------------------------------------------------------------
 private static bool[] Helper__CreateArgumentsPropagateNullability(IReadOnlyCollection<SqlExpression> arguments)
 {
  Debug.Assert(!Object.ReferenceEquals(arguments,null));
  Debug.Assert(arguments.Count>0);

  var result
   =new bool[arguments.Count];

  for(int i=0,_c=arguments.Count;i!=_c;++i)
  {
   result[i]=false;
  }//for[ever]

  return result;
 }//Helper__CreateArgumentsPropagateNullability

 //Debug methods ---------------------------------------------------------
#if DEBUG
 private void DEBUG__CheckState()
 {
  Debug.Assert(!Object.ReferenceEquals(m_SupportedStates,null));

  Debug.Assert(Object.ReferenceEquals(this.Instance,null));

  Debug.Assert(!Object.ReferenceEquals(this.Arguments,null));

  Debug.Assert(this.Arguments.Count>=c_MinArgCount);

  foreach(var e in this.Arguments)
  {
   Debug.Assert(!Object.ReferenceEquals(e,null));
  }
 }//DEBUG__CheckState
#endif

 //private data ----------------------------------------------------------
 private readonly Helpers.Map_Op2ResultTypeMappings
  m_SupportedStates;
};//class FB_Common__Sql_ENode_Function__SQL__COALESCE

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes

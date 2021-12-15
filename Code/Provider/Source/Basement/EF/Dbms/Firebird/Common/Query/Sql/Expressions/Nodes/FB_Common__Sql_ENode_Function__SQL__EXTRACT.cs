////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 26.03.2019.
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes{
////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ENode_Function__SQL__EXTRACT

sealed class FB_Common__Sql_ENode_Function__SQL__EXTRACT
 :FB_Common__Sql_ENode_Function
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__Sql_ENode_Function__SQL__EXTRACT;

 //-----------------------------------------------------------------------
 private const int c_ArgCount=1;

 private const int c_ArgIdx__value=0;

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ENode_Function__SQL__EXTRACT
           (System.String              functionName,
            IEnumerable<SqlExpression> arguments,
            System.Type                resultType,
            RelationalTypeMapping      resultTypeMapping,
            string                     partName)
  :base(functionName,
        arguments,
        Core.SQL.Core_SQL__TestNullable.TestNullable_ANY(arguments),
        sm_argumentsPropagateNullability,
        resultType,
        resultTypeMapping)
 {
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Function__SQL__EXTRACT::FB_Common__Sql_ENode_Function__SQL__EXTRACT(...) - clone");
#endif

  //----------------------------------------
  m_PartName=partName;

  //----------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif
 }//FB_Common__Sql_ENode_Function__SQL__EXTRACT

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ENode_Function__SQL__EXTRACT
                                           (SqlExpression         valueExpression,
                                            string                partName,
                                            RelationalTypeMapping resultTypeMapping)
  :this("EXTRACT_"+partName,
        new[]{valueExpression},
        resultTypeMapping.ClrType,
        resultTypeMapping,
        partName)
 {
  Debug.Assert(!Object.ReferenceEquals(valueExpression,null));
  Debug.Assert(!string.IsNullOrWhiteSpace(partName));
  Debug.Assert(partName.Trim()==partName);
  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping.ClrType,null));

  //----------------------------------------
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Function__SQL__EXTRACT::FB_Common__Sql_ENode_Function__SQL__EXTRACT\n"
   +" (valueExpression  : {0},\n"
   +"  partName         : {1},\n"
   +"  resultType       : {2})",
    valueExpression,
    partName,
    resultTypeMapping.ClrType);
#endif

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(valueExpression,null));

#if DEBUG
  this.DEBUG__CheckState();
#endif

  Debug.Assert(Object.ReferenceEquals(this.Arguments[c_ArgIdx__value],valueExpression));
 }//FB_Common__Sql_ENode_Function__SQL__EXTRACT

 //-----------------------------------------------------------------------
 public static SqlExpression Create__Second(SqlExpression valueExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(valueExpression,null));

  Debug.Assert(!Object.ReferenceEquals(FB_Common__TypeMappingCache.TypeMapping__TimePart__Second,null));
  Debug.Assert(!Object.ReferenceEquals(FB_Common__TypeMappingCache.TypeMapping__TimePart__Second.ClrType,null));

  return new FB_Common__Sql_ENode_Function__SQL__EXTRACT
              (valueExpression,
               "SECOND",
               FB_Common__TypeMappingCache.TypeMapping__TimePart__Second);
 }//Create__Second

 //-----------------------------------------------------------------------
 public static SqlExpression Create__Millisecond
                                           (SqlExpression valueExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(valueExpression,null));

  Debug.Assert(!Object.ReferenceEquals(FB_Common__TypeMappingCache.TypeMapping__TimePart__Millisecond,null));
  Debug.Assert(!Object.ReferenceEquals(FB_Common__TypeMappingCache.TypeMapping__TimePart__Millisecond.ClrType,null));

  return new FB_Common__Sql_ENode_Function__SQL__EXTRACT
              (valueExpression,
               "MILLISECOND",
               FB_Common__TypeMappingCache.TypeMapping__TimePart__Millisecond);
 }//Create__Millisecond

 //-----------------------------------------------------------------------
 public static SqlExpression Create__DayOfWeek
                                           (SqlExpression valueExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(valueExpression,null));

  return new FB_Common__Sql_ENode_Function__SQL__EXTRACT
              (valueExpression,
               "WEEKDAY",
               FB_Common__TypeMappingCache.TypeMapping__INT32);
 }//Create__DayOfWeek

 //-----------------------------------------------------------------------
 public static SqlExpression Create(SqlExpression valueExpression,
                                    string        partName)
 {
  Debug.Assert(!Object.ReferenceEquals(valueExpression,null));
  Debug.Assert(!string.IsNullOrWhiteSpace(partName));
  Debug.Assert(partName.Trim()==partName);

  return new FB_Common__Sql_ENode_Function__SQL__EXTRACT
              (valueExpression,
               partName,
               FB_Common__TypeMappingCache.TypeMapping__INT32);
 }//Create

 //Expression interface --------------------------------------------------
 public override bool CanReduce
 {
  get
  {
#if TRACE
   Core.Core_Trace.Method
    ("FB_Common__Sql_ENode_Function__SQL__EXTRACT::get_CanReduce - false");
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
   ("FB_Common__Sql_ENode_Function__SQL__EXTRACT::Accept"
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
   ("FB_Common__Sql_ENode_Function__SQL__EXTRACT::Accept"
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
   ="FB_Common__Sql_ENode_Function__SQL__EXTRACT::VisitChildren";

  //----------------------------------------
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Function__SQL__EXTRACT::VisitChildren\n"
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

   Debug.Assert(c_ArgCount==1);

   return this;
  }//for[ever]

  //create new instance

  return new FB_Common__Sql_ENode_Function__SQL__EXTRACT
              (this.Name,
               new[]{newValueExpression},
               this.Type,
               this.TypeMapping,
               m_PartName);
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

   Debug.Assert(c_ArgCount==1);

   return this;
  }//for[ever]

  return new FB_Common__Sql_ENode_Function__SQL__EXTRACT
              (this.Name,
               arguments,
               this.Type,
               this.TypeMapping,
               m_PartName);
 }//Update

 //-----------------------------------------------------------------------
 protected override void Print(ExpressionPrinter expressionPrinter)
 {
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Function__SQL__EXTRACT::Print(...)");
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
  expressionPrinter.Append("EXTRACT(");
  expressionPrinter.Append(m_PartName);
  expressionPrinter.Append(" FROM ");
  expressionPrinter.Visit(this.Arguments[c_ArgIdx__value]);
  expressionPrinter.Append(")");
 }//Print

 //Object interface ------------------------------------------------------
 public override bool Equals(object obj)
 {
#if TRACE
  Core.Core_Trace.Method_Enter
   ("FB_Common__Sql_ENode_Function__SQL__EXTRACT::Equals\n"
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
   var typedObj=(FB_Common__Sql_ENode_Function__SQL__EXTRACT)obj;

   Debug.Assert(!Object.ReferenceEquals(typedObj,null));

   Debug.Assert(!string.IsNullOrWhiteSpace(typedObj.m_PartName));

   if(!base.Helper__Equals(typedObj))
   {
    r=false;
   }
   else
   if(!typedObj.m_PartName.Equals(m_PartName))
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
   ("FB_Common__Sql_ENode_Function__SQL__EXTRACT::Equals\n"
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
   ("FB_Common__Sql_ENode_Function__SQL__EXTRACT::GetHashCode()");
#endif

  //------------------------------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif

  //------------------------------------------------------------
  unchecked
  {
   Debug.Assert(!string.IsNullOrWhiteSpace(m_PartName));

   //-----
   var hashCode=base.GetHashCode();

   hashCode=(hashCode*397)^m_PartName.GetHashCode();

#if TRACE
  Core.Core_Trace.Method_Exit
   ("FB_Common__Sql_ENode_Function__SQL__EXTRACT::GetHashCode() - {0}",
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
   ("FB_Common__Sql_ENode_Function__SQL__EXTRACT::Helper__Accept__GenerateSql(...)");
#endif

  //------------------------------------------------------------
  Debug.Assert(!Object.ReferenceEquals(querySqlGenerator,null));

#if DEBUG
  this.DEBUG__CheckState();
#endif

  //------------------------------------------------------------
  querySqlGenerator.Sql.Append("EXTRACT(");

  querySqlGenerator.Sql.Append(m_PartName);

  querySqlGenerator.Sql.Append(" FROM ");

  querySqlGenerator.Visit(this.Arguments[c_ArgIdx__value]);

  querySqlGenerator.Sql.Append(")");

  return this;
 }//Helper__Accept__GenerateSql

 //Debug methods ---------------------------------------------------------
#if DEBUG
 private void DEBUG__CheckState()
 {
  Debug.Assert(Object.ReferenceEquals(this.Instance,null));

  Debug.Assert(!string.IsNullOrWhiteSpace(m_PartName));
  Debug.Assert(m_PartName.Trim()==m_PartName);

  Debug.Assert(!Object.ReferenceEquals(this.Arguments,null));

  Debug.Assert(this.Arguments.Count==c_ArgCount);

  Debug.Assert(!Object.ReferenceEquals(this.Arguments[c_ArgIdx__value],null));
 }//DEBUG__CheckState
#endif

 //private data ----------------------------------------------------------
 private readonly string m_PartName;

 private static readonly bool[] sm_argumentsPropagateNullability
  =new bool[c_ArgCount]{true};
};//class FB_Common__Sql_ENode_Function__SQL__EXTRACT

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes

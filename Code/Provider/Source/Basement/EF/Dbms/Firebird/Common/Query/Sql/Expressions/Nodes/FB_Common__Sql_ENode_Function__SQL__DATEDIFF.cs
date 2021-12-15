////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 29.11.2020.
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes{
////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ENode_Function__SQL__DATEDIFF

sealed class FB_Common__Sql_ENode_Function__SQL__DATEDIFF
 :FB_Common__Sql_ENode_Function
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__Sql_ENode_Function__SQL__DATEDIFF;

 //-----------------------------------------------------------------------
 private const int c_ArgCount=2;

 private const int c_ArgIdx__moment1 =0;
 private const int c_ArgIdx__moment2 =1;

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ENode_Function__SQL__DATEDIFF
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
   ("FB_Common__Sql_ENode_Function__SQL__DATEDIFF::FB_Common__Sql_ENode_Function__SQL__DATEDIFF(...) - clone");
#endif

  //----------------------------------------
  m_PartName=partName;

  //----------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif
 }//FB_Common__Sql_ENode_Function__SQL__DATEDIFF

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ENode_Function__SQL__DATEDIFF(SqlExpression         moment1Expression,
                                                      SqlExpression         moment2Expression,
                                                      string                partName,
                                                      RelationalTypeMapping resultTypeMapping)
  :this("DATEDIFF_"+partName,
        new[]{moment1Expression,moment2Expression},
        resultTypeMapping.ClrType,
        resultTypeMapping,
        partName)
 {
  Debug.Assert(!Object.ReferenceEquals(moment1Expression,null));
  Debug.Assert(!Object.ReferenceEquals(moment2Expression,null));
  Debug.Assert(!string.IsNullOrWhiteSpace(partName));
  Debug.Assert(partName.Trim()==partName);

  //----------------------------------------
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Function__SQL__DATEDIFF::FB_Common__Sql_ENode_Function__SQL__DATEDIFF\n"
   +" (valueExpression  : {0},\n"
   +"  amountExpression : {1},\n"
   +"  partName         : {2})",
   moment1Expression,
   moment2Expression,
   partName);
#endif

  //----------------------------------------
  m_PartName=partName;

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(moment1Expression,null));
  Debug.Assert(!Object.ReferenceEquals(moment2Expression,null));

#if DEBUG
  this.DEBUG__CheckState();
#endif

  Debug.Assert(Object.ReferenceEquals(this.Arguments[c_ArgIdx__moment1],moment1Expression));
  Debug.Assert(Object.ReferenceEquals(this.Arguments[c_ArgIdx__moment2],moment2Expression));
 }//FB_Common__Sql_ENode_Function__SQL__DATEDIFF

 //-----------------------------------------------------------------------
 public static SqlExpression Create(SqlExpression         moment1Expression,
                                    SqlExpression         moment2Expression,
                                    string                partName,
                                    RelationalTypeMapping resultTypeMapping)
 {
#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (moment1Expression);

  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (moment2Expression);

  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping.ClrType,null));

  Debug.Assert(!string.IsNullOrWhiteSpace(partName));
  Debug.Assert(partName.Trim()==partName);
#endif

  //------------------------------------------------------------
  return new FB_Common__Sql_ENode_Function__SQL__DATEDIFF
              (moment1Expression,
               moment2Expression,
               partName,
               resultTypeMapping);
 }//Create

 //-----------------------------------------------------------------------
 //
 // Generation: DATEDIFF(MILLISECOND, amountExpression, valueExpression)
 //
 public static SqlExpression Create4(SqlExpression         moment1Expression,
                                     SqlExpression         moment2Expression,
                                     RelationalTypeMapping resultTypeMapping)
 {
#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (moment1Expression);

  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (moment2Expression);

  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping.ClrType,null));
#endif

  //------------------------------------------------------------
  return new FB_Common__Sql_ENode_Function__SQL__DATEDIFF
              (moment1Expression,
               moment2Expression,
               "MILLISECOND",
               resultTypeMapping);
 }//Create4

 //Expression interface --------------------------------------------------
 public override bool CanReduce
 {
  get
  {
#if TRACE
   Core.Core_Trace.Method
    ("FB_Common__Sql_ENode_Function__SQL__DATEDIFF::get_CanReduce - false");
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
   ("FB_Common__Sql_ENode_Function__SQL__DATEDIFF::Accept"
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
   ("FB_Common__Sql_ENode_Function__SQL__DATEDIFF::Accept"
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
   ="FB_Common__Sql_ENode_Function__SQL__DATEDIFF::VisitChildren";

  //----------------------------------------
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Function__SQL__DATEDIFF::VisitChildren\n"
   +" ({0})",
    visitor);
#endif

  //----------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif

  //----------------------------------------
  Expression newMoment1Expression_e  = visitor.Visit(this.Arguments[c_ArgIdx__moment1]);
  Expression newMoment2Expression_e = visitor.Visit(this.Arguments[c_ArgIdx__moment2]);

  //----------------------------------------
  var newMoment1Expression
   =Check.BugCheck_Value_NotNullAndInstanceOf<SqlExpression,Expression>
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      nameof(newMoment1Expression_e),
      newMoment1Expression_e);

  var newMoment2Expression
   =Check.BugCheck_Value_NotNullAndInstanceOf<SqlExpression,Expression>
     (c_ErrSrcID,
      c_bugcheck_src,
      "#002",
      nameof(newMoment2Expression_e),
      newMoment2Expression_e);

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(newMoment1Expression,null));
  Debug.Assert(!Object.ReferenceEquals(newMoment2Expression,null));

  //----------------------------------------
  for(;;)
  {
   if(newMoment1Expression!=this.Arguments[c_ArgIdx__moment1])
    break;

   if(newMoment2Expression!=this.Arguments[c_ArgIdx__moment2])
    break;

   Debug.Assert(c_ArgCount==2);

   return this;
  }//for[ever]

  //create new instance

  return new FB_Common__Sql_ENode_Function__SQL__DATEDIFF
              (this.Name,
               new[]{newMoment1Expression,newMoment2Expression},
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

  Debug.Assert(c_ArgIdx__moment1==0);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Update),
    nameof(arguments)+"[0]",
    arguments[c_ArgIdx__moment1]);

  Debug.Assert(c_ArgIdx__moment2==1);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Update),
    nameof(arguments)+"[1]",
    arguments[c_ArgIdx__moment2]);

  //------------------------------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif

  //------------------------------------------------------------
  for(;;)
  {
   if(!Object.ReferenceEquals(this.Arguments[c_ArgIdx__moment1],arguments[c_ArgIdx__moment1]))
    break;

   if(!Object.ReferenceEquals(this.Arguments[c_ArgIdx__moment2],arguments[c_ArgIdx__moment2]))
    break;

   Debug.Assert(c_ArgCount==2);

   return this;
  }//for[ever]

  return new FB_Common__Sql_ENode_Function__SQL__DATEDIFF
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
   ("FB_Common__Sql_ENode_Function__SQL__DATEDIFF::Print(...)");
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
  expressionPrinter.Append("DATEDIFF(");
  expressionPrinter.Append(m_PartName);
  expressionPrinter.Append(",");
  expressionPrinter.Visit(this.Arguments[c_ArgIdx__moment1]);
  expressionPrinter.Append(",");
  expressionPrinter.Visit(this.Arguments[c_ArgIdx__moment2]);
  expressionPrinter.Append(")");
 }//Print

 //Object interface ------------------------------------------------------
 public override bool Equals(object obj)
 {
#if TRACE
  Core.Core_Trace.Method_Enter
   ("FB_Common__Sql_ENode_Function__SQL__DATEDIFF::Equals\n"
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
   var typedObj=(FB_Common__Sql_ENode_Function__SQL__DATEDIFF)obj;

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
   ("FB_Common__Sql_ENode_Function__SQL__DATEDIFF::Equals\n"
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
   ("FB_Common__Sql_ENode_Function__SQL__DATEDIFF::GetHashCode()");
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
   ("FB_Common__Sql_ENode_Function__SQL__DATEDIFF::GetHashCode() - {0}",
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
   ("FB_Common__Sql_ENode_Function__SQL__DATEDIFF::Helper__Accept__GenerateSql(...)");
#endif

  Debug.Assert(!Object.ReferenceEquals(querySqlGenerator,null));

  //------------------------------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif

  //------------------------------------------------------------
  querySqlGenerator.Sql.Append("DATEDIFF(");

  querySqlGenerator.Sql.Append(m_PartName);

  querySqlGenerator.Sql.Append(",");

  querySqlGenerator.Visit(this.Arguments[c_ArgIdx__moment1]);

  querySqlGenerator.Sql.Append(",");

  querySqlGenerator.Visit(this.Arguments[c_ArgIdx__moment2]);

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

  Debug.Assert(!Object.ReferenceEquals(this.Arguments[c_ArgIdx__moment1],null));
  Debug.Assert(!Object.ReferenceEquals(this.Arguments[c_ArgIdx__moment2],null));

  Debug.Assert(c_ArgCount==2);
 }//DEBUG__CheckState
#endif

 //private data ----------------------------------------------------------
 private readonly string m_PartName;

 //private data ----------------------------------------------------------
 private static readonly bool[] sm_argumentsPropagateNullability
  =new bool[c_ArgCount]{true,true};
};//class FB_Common__Sql_ENode_Function__SQL__DATEDIFF

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes

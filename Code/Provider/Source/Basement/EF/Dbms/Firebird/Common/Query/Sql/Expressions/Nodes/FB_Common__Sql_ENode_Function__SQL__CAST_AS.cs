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
//class FB_Common__Sql_ENode_Function__SQL__CAST_AS

sealed class FB_Common__Sql_ENode_Function__SQL__CAST_AS
 :FB_Common__Sql_ENode_Function
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__Sql_ENode_Function__SQL__CAST_AS;

 //-----------------------------------------------------------------------
 private const int c_ArgCount=1;

 private const int c_ArgIdx__value=0;

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ENode_Function__SQL__CAST_AS
           (System.String              functionName,
            IEnumerable<SqlExpression> arguments,
            string                     resultTypeName,
            System.Type                resultType,
            RelationalTypeMapping      resultTypeMapping)
  :base(functionName,
        arguments,
        /*nullable*/Core.SQL.Core_SQL__TestNullable.TestNullable_ANY(arguments),
        sm_argumentsPropagateNullability,
        resultType,
        resultTypeMapping)
 {
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Function__SQL__CAST_AS::FB_Common__Sql_ENode_Function__SQL__CAST_AS(...) - clone");
#endif

  //----------------------------------------
  m_ResultTypeName=resultTypeName;

  //----------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif
 }//FB_Common__Sql_ENode_Function__SQL__CAST_AS

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ENode_Function__SQL__CAST_AS
           (SqlExpression         valueExpression,
            RelationalTypeMapping resultTypeMapping,
            string                resultTypeName)
  :this("DBCAST_AS",
        new[]{valueExpression},
        resultTypeName,
        resultTypeMapping.ClrType,
        resultTypeMapping)
 {
  Debug.Assert(!Object.ReferenceEquals(valueExpression,null));

  Debug.Assert(!Object.ReferenceEquals(this.Type,null));
  Debug.Assert(!Object.ReferenceEquals(this.TypeMapping,null));

  //----------------------------------------
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Function__SQL__CAST_AS::FB_Common__Sql_ENode_Function__SQL__CAST_AS\n"
   +" (valueExpression   : {0},\n"
   +"  resultTypeMapping : {1},\n"
   +"  resultTypeName    : {2})",
    valueExpression,
    resultTypeMapping.StoreType,
    resultTypeName);
#endif

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(valueExpression,null));

#if DEBUG
  this.DEBUG__CheckState();
#endif

  Debug.Assert(Object.ReferenceEquals(this.Arguments[c_ArgIdx__value],valueExpression));
 }//FB_Common__Sql_ENode_Function__SQL__CAST_AS

 //-----------------------------------------------------------------------
 public static SqlExpression Helper__Create(SqlExpression         valueExpression,
                                            RelationalTypeMapping resultTypeMapping,
                                            string                resultTypeName)
 {
  Debug.Assert(!Object.ReferenceEquals(valueExpression,null));
  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));

  if(valueExpression is FB_Common__Sql_ENode_Function__SQL__CAST_AS e)
  {
   Debug.Assert(!Object.ReferenceEquals(e.Type,null));

#if DEBUG
   e.DEBUG__CheckState();
#endif

   Debug.Assert(!Object.ReferenceEquals(e.TypeMapping,null));

   for(;;)
   {
    if(!e.TypeMapping.Equals(resultTypeMapping))
     break;

    // Ignore the difference in resultTypeName

    return e;
   }//for[ever]
  }//if

  return new FB_Common__Sql_ENode_Function__SQL__CAST_AS
          (valueExpression,
           resultTypeMapping,
           resultTypeName);
 }//Helper__Create

 //-----------------------------------------------------------------------
 public static SqlExpression Create(SqlExpression         valueExpression,
                                    RelationalTypeMapping resultTypeMapping)
 {
  Debug.Assert(!Object.ReferenceEquals(valueExpression,null));
  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));

  return Helper__Create
          (valueExpression,
           resultTypeMapping,
           /*resultTypeName*/null);
 }//Create - valueExpression, resultTypeMapping

 //-----------------------------------------------------------------------
 public static SqlExpression Create(SqlExpression         valueExpression,
                                    RelationalTypeMapping resultTypeMapping,
                                    string                resultTypeName)
 {
  Debug.Assert(!Object.ReferenceEquals(valueExpression,null));
  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));

  return Helper__Create
          (valueExpression,
           resultTypeMapping,
           resultTypeName);
 }//Create - valueExpression, resultTypeMapping, resultTypeName

 //Expression interface --------------------------------------------------
 public override bool CanReduce
 {
  get
  {
#if TRACE
   Core.Core_Trace.Method
    ("FB_Common__Sql_ENode_Function__SQL__CAST_AS::get_CanReduce - false");
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
   ("FB_Common__Sql_ENode_Function__SQL__CAST_AS::Accept"
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
   ("FB_Common__Sql_ENode_Function__SQL__CAST_AS::Accept"
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
   ="FB_Common__Sql_ENode_Function__SQL__CAST_AS::VisitChildren";

  //----------------------------------------
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Function__SQL__CAST_AS::VisitChildren\n"
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

  return new FB_Common__Sql_ENode_Function__SQL__CAST_AS
              (this.Name,
               new[]{newValueExpression},
               m_ResultTypeName,
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

  return new FB_Common__Sql_ENode_Function__SQL__CAST_AS
              (this.Name,
               arguments,
               m_ResultTypeName,
               this.Type,
               this.TypeMapping);
 }//Update

 //-----------------------------------------------------------------------
 protected override void Print(ExpressionPrinter expressionPrinter)
 {
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Function__SQL__CAST_AS::Print(...)");
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
  expressionPrinter.Append("CAST(");
  expressionPrinter.Visit(this.Arguments[c_ArgIdx__value]);
  expressionPrinter.Append(" AS ");
  expressionPrinter.Append(this.Helper__GetResultTypeName());
  expressionPrinter.Append(")");
 }//Print

 //Object interface ------------------------------------------------------
 public override bool Equals(object obj)
 {
#if TRACE
  Core.Core_Trace.Method_Enter
   ("FB_Common__Sql_ENode_Function__SQL__CAST_AS::Equals\n"
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
   var typedObj=(FB_Common__Sql_ENode_Function__SQL__CAST_AS)obj;

   Debug.Assert(!Object.ReferenceEquals(typedObj,null));

   if(!base.Helper__Equals(typedObj))
   {
    r=false;
   }
   else
   if(!StringComparer.Ordinal.Equals(typedObj.m_ResultTypeName,m_ResultTypeName))
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
   ("FB_Common__Sql_ENode_Function__SQL__CAST_AS::Equals\n"
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
   ("FB_Common__Sql_ENode_Function__SQL__CAST_AS::GetHashCode()");
#endif

  //------------------------------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif

  //------------------------------------------------------------
  unchecked
  {
   var hashCode=base.GetHashCode();

   if(!Object.ReferenceEquals(m_ResultTypeName,null))
    hashCode=(hashCode*397)^m_ResultTypeName.GetHashCode();

#if TRACE
  Core.Core_Trace.Method_Exit
   ("FB_Common__Sql_ENode_Function__SQL__CAST_AS::GetHashCode() - {0}",
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
   ("FB_Common__Sql_ENode_Function__SQL__CAST_AS::Helper__Accept__GenerateSql(...)");
#endif

  //------------------------------------------------------------
  Debug.Assert(!Object.ReferenceEquals(querySqlGenerator,null));

#if DEBUG
  this.DEBUG__CheckState();
#endif

  //------------------------------------------------------------
  querySqlGenerator.Sql.Append("CAST(");

  querySqlGenerator.VisitAndWrapIntoBrackets
   (this.Arguments[c_ArgIdx__value],
    /*sqlParent*/null);

  querySqlGenerator.Sql.Append(" AS ");

  querySqlGenerator.Sql.Append(this.Helper__GetResultTypeName());

  querySqlGenerator.Sql.Append(")");

  return this;
 }//Helper__Accept__GenerateSql

 //-----------------------------------------------------------------------
 private string Helper__GetResultTypeName()
 {
  Debug.Assert(!Object.ReferenceEquals(this.TypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(this.TypeMapping.StoreType,null));

  if(Object.ReferenceEquals(m_ResultTypeName,null))
   return this.TypeMapping.StoreType;

  Debug.Assert(!Object.ReferenceEquals(m_ResultTypeName,null));
  Debug.Assert(m_ResultTypeName.Length>0);
  Debug.Assert(m_ResultTypeName.Trim()==m_ResultTypeName);

  return m_ResultTypeName;
 }//Helper__GetResultTypeName

 //Debug methods ---------------------------------------------------------
#if DEBUG
 private void DEBUG__CheckState()
 {
  Debug.Assert(Object.ReferenceEquals(this.Instance,null));

  Debug.Assert(!Object.ReferenceEquals(this.Arguments,null));

  Debug.Assert(this.Arguments.Count==c_ArgCount);

  Debug.Assert(!Object.ReferenceEquals(this.Arguments[c_ArgIdx__value],null));

  //--------------------------
  Debug.Assert(!Object.ReferenceEquals(this.Type,null));
  Debug.Assert(!Object.ReferenceEquals(this.TypeMapping,null));
 }//DEBUG__CheckState
#endif

 //private data ----------------------------------------------------------
 
 // Explicit name of target type. Can be null.
 private readonly string m_ResultTypeName;

 //-----------------------------------------------------------------------
 private static readonly bool[] sm_argumentsPropagateNullability
  =new bool[c_ArgCount]{true};
};//class FB_Common__Sql_ENode_Function__SQL__CAST_AS

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes

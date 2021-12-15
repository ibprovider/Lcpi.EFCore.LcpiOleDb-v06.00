////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 03.10.2021.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes{
////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ENode_Unary__Convert

sealed partial class FB_Common__Sql_ENode_Unary__Convert
 :SqlUnaryExpression
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__Sql_ENode_Unary__Convert;

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ENode_Unary__Convert
                        (SqlExpression         sqlOperand,
                         RelationalTypeMapping resultTypeMapping,
                         SSCodes               ssCodes,
                         SSCode                ssCode)
  :base(ExpressionType.Convert,
        sqlOperand,
        resultTypeMapping.ClrType,
        resultTypeMapping)
 {
  Debug.Assert(!Object.ReferenceEquals(ssCodes,null));
  Debug.Assert(!Object.ReferenceEquals(ssCode,null));

  m_SSCodes=ssCodes;
  m_SSCode =ssCode;
 }//FB_Common__Sql_ENode_Unary__Convert

 //-----------------------------------------------------------------------
 public static SqlUnaryExpression Create(SqlExpression         sqlOperand,
                                         RelationalTypeMapping resultTypeMapping,
                                         SSCodes               ssCodes)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlOperand,null));
  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping.ClrType,null));
  Debug.Assert(!Object.ReferenceEquals(ssCodes,null));

  //------------------------------------------------------------
  const string c_bugcheck_src
   ="FB_Common__Sql_ENode_Unary__Convert::Create";

  //------------------------------------------------------------
  Check.BugCheck_Value_NotNull
   (c_ErrSrcID,
    c_bugcheck_src,
    "#001",
    nameof(sqlOperand),
    sqlOperand);

  Check.BugCheck_Value_NotNull
   (c_ErrSrcID,
    c_bugcheck_src,
    "#002",
    nameof(resultTypeMapping),
    resultTypeMapping);

  Check.BugCheck_Value_NotNull
   (c_ErrSrcID,
    c_bugcheck_src,
    "#003",
    "resultTypeMapping.ClrType",
    resultTypeMapping.ClrType);

  //------------------------------------------------------------
  var ssCode
   =Helper__GetSSCode
     (sqlOperand,
      resultTypeMapping,
      ssCodes); //throw

  Debug.Assert(!Object.ReferenceEquals(ssCode,null));

  var r
   =new FB_Common__Sql_ENode_Unary__Convert
     (sqlOperand,
      resultTypeMapping,
      ssCodes,
      ssCode); //throw (OOM)

  return r;
 }//Create

 //Expression interface --------------------------------------------------
 public override bool CanReduce
 {
  get
  {
#if TRACE
   Core.Core_Trace.Method
    ("FB_Common__Sql_ENode_Unary__Convert::get_CanReduce - false");
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
   ("FB_Common__Sql_ENode_Unary__Convert::Accept"
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
   ("FB_Common__Sql_ENode_Unary__Convert::Accept"
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
   ="FB_Common__Sql_ENode_Unary__Convert::VisitChildren";

  //----------------------------------------
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Unary__Convert::VisitChildren\n"
   +" ({0})",
    visitor);
#endif

  //-------------------------------------------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(VisitChildren),
    nameof(visitor),
    visitor);

  //----------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif

  //-------------------------------------------------------
  Expression newOperand_e = visitor.Visit(this.Operand);

  //----------------------------------------
  var newOperand
   =Check.BugCheck_Value_NotNullAndInstanceOf<SqlExpression,Expression>
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      nameof(newOperand_e),
      newOperand_e);

  Debug.Assert(!Object.ReferenceEquals(newOperand,null));

  //----------------------------------------
  for(;;)
  {
   if(newOperand!=this.Operand)
    break;

   return this;
  }//for[ever]

  //create new instance
  var r
   =Create
     (newOperand,
      this.TypeMapping,
      m_SSCodes);

  Debug.Assert(!Object.ReferenceEquals(r,null));

  return r;
 }//VisitChildren

 //SqlUnaryExpression interface ------------------------------------------
 public override SqlUnaryExpression Update(SqlExpression operand)
 {
  Debug.Assert(!Object.ReferenceEquals(operand,null));

  //-------------------------------------------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Update),
    nameof(operand),
    operand);

  //-------------------------------------------------------
#if DEBUG
  this.DEBUG__CheckState();
#endif

  //----------------------------------------
  for(;;)
  {
   if(!Object.ReferenceEquals(this.Operand,operand))
    break;

   return this;
  }//for[ever]

  //create new instance

  var r
   =Create
     (operand,
      this.TypeMapping,
      m_SSCodes);

  Debug.Assert(!Object.ReferenceEquals(r,null));

  return r;
 }//Update

 //-----------------------------------------------------------------------
 protected override void Print(ExpressionPrinter expressionPrinter)
 {
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Unary__Convert::Print(...)");
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
  expressionPrinter.Append("UNARY_CONVERT(");
  expressionPrinter.Visit(this.Operand);
  expressionPrinter.Append(" TO ");
  expressionPrinter.Append(this.TypeMapping.StoreType);
  expressionPrinter.Append(")");
 }//Print

 //Object interface ------------------------------------------------------
 public override bool Equals(object obj)
 {
  var r
   =base.Equals(obj);

#if DEBUG
  if(r)
  {
   Debug.Assert(!Object.ReferenceEquals(obj,null));
   Debug.Assert(obj is FB_Common__Sql_ENode_Unary__Convert);

   var typedObj
    =(FB_Common__Sql_ENode_Unary__Convert)obj;

   //[2021-10-03] Expected SAME objects!
   Debug.Assert(Object.ReferenceEquals(typedObj.m_SSCode  ,m_SSCode));
   Debug.Assert(Object.ReferenceEquals(typedObj.m_SSCodes ,m_SSCodes));

   Debug.Assert(typedObj.GetHashCode()==this.GetHashCode());
  }//if r
#endif

  return r;
 }//Equals

 //-----------------------------------------------------------------------
 public override int GetHashCode()
 {
  var r
   =base.GetHashCode();

  return r;
 }//GetHashCode

 //Helper methods --------------------------------------------------------
 private Expression Helper__Accept__GenerateSql(Sql.FB_Common__QuerySqlGenerator querySqlGenerator)
 {
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__Sql_ENode_Unary__Convert::Helper__Accept__GenerateSql(...)");
#endif

  //------------------------------------------------------------
  Debug.Assert(!Object.ReferenceEquals(querySqlGenerator,null));

#if DEBUG
  this.DEBUG__CheckState();
#endif

  //------------------------------------------------------------
  m_SSCode.GenerateSQL
   (querySqlGenerator,
    this);

  return this;
 }//Helper__Accept__GenerateSql

 //-----------------------------------------------------------------------
 private static SSCode Helper__GetSSCode
                        (SqlExpression         sqlOperand,
                         RelationalTypeMapping resultTypeMapping,
                         SSCodes               ssCodes)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlOperand,null));
  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping.ClrType,null));
  Debug.Assert(!Object.ReferenceEquals(ssCodes,null));

  //-------------------------------------------------------
  const string c_bugcheck_src
   ="FB_Common__Sql_ENode_Unary__Convert::Helper__GetSSCode";

  //-------------------------------------------------------
  var fromSqlType
   =Core.SQL.Core_SQL__ExpressionUtils.GetSqlType
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      sqlOperand);

  Debug.Assert(!Object.ReferenceEquals(fromSqlType,null));

  //-------------------------------------------------------
  var toSqlType
   =resultTypeMapping.ClrType.Extension__UnwrapMappingClrType();

  Debug.Assert(!Object.ReferenceEquals(toSqlType,null));

  //-------------------------------------------------------
  bool    cvt__CanIgnore=false;
  SSCode  cvt__SSCode=null;

  if(!ssCodes.TryGet(fromSqlType,toSqlType,out cvt__CanIgnore,out cvt__SSCode))
  {
   ThrowError.SqlGenErr__UnsupportedCastAsBetweenTypes
    (c_ErrSrcID,
     fromSqlType,
     toSqlType);
  }//if

  Debug.Assert(!Object.ReferenceEquals(cvt__SSCode,null));

  if(cvt__CanIgnore)
   return Nodes.SSCodes.Unary__Convert.SSCode_Unary_Convert__CastAs__None.Instance;

  return cvt__SSCode;
 }//Helper__GetSSCode

 //Debug methods ---------------------------------------------------------
#if DEBUG
 private void DEBUG__CheckState()
 {
  Debug.Assert(!Object.ReferenceEquals(this.Operand,null));

  Debug.Assert(!Object.ReferenceEquals(this.TypeMapping,null));

  Debug.Assert(!Object.ReferenceEquals(this.TypeMapping.ClrType,null));
 }//DEBUG__CheckState
#endif

 //private data ----------------------------------------------------------
 private readonly SSCodes m_SSCodes;

 private readonly SSCode m_SSCode;
};//class FB_Common__Sql_ENode_Unary__Convert

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes
////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 18.05.2018.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Expressions{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__SqlStubExpression

sealed class LcpiOleDb__SqlStubExpression:Expression
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.LcpiOleDb__SqlStubExpression;

 //-----------------------------------------------------------------------
 public LcpiOleDb__SqlStubExpression(Expression  innerExpression,
                                     System.Type type)
 {
  Debug.Assert(!Object.ReferenceEquals(innerExpression,null));
  Debug.Assert(!Object.ReferenceEquals(type,null));

  m_InnerExpression=innerExpression;

  m_Type=type;
 }//LcpiOleDb__SqlStubExpression

 //own interface ---------------------------------------------------------
 public Expression InnerExpression
 {
  get
  {
   Debug.Assert(!Object.ReferenceEquals(m_InnerExpression,null));

   return m_InnerExpression;
  }//get
 }//InnerExpression

 //Expression interface --------------------------------------------------
 public override ExpressionType NodeType
 {
  get
  {
   return ExpressionType.Extension;
  }//get
 }//NodeType

 //-----------------------------------------------------------------------
 public override System.Type Type
 {
  get
  {
   return m_Type;
  }//get
 }//Type

 //-----------------------------------------------------------------------
 protected override Expression VisitChildren(ExpressionVisitor visitor)
 {
  Debug.Assert(!Object.ReferenceEquals(visitor,null));

  Debug.Assert(!Object.ReferenceEquals(m_InnerExpression,null));

  //------------------------------------------------------------
  var newInnerExpression
   =visitor.Visit(m_InnerExpression);

  Check.BugCheck_Value_NotNull
   (c_ErrSrcID,
    "LcpiOleDb__SqlStubExpression::VisitChildren",
    "#001",
    nameof(newInnerExpression),
    newInnerExpression);

  Debug.Assert(!Object.ReferenceEquals(newInnerExpression,null));

  //------------------------------------------------------------
  for(;;)
  {
   if(m_InnerExpression!=newInnerExpression)
    break;

   return this;
  }//for[ever]

  return new LcpiOleDb__SqlStubExpression
          (newInnerExpression,
           m_Type);
 }//VisitChildren

 //Object interface ------------------------------------------------------
 public override bool Equals(System.Object obj)
 {
#if TRACE
  Core.Core_Trace.Method_Enter
   ("LcpiOleDb__SqlStubExpression::Equals\n"
   +" ({0})",
    obj);
#endif

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
   var typedObj=(LcpiOleDb__SqlStubExpression)obj;

   Debug.Assert(!Object.ReferenceEquals(typedObj,null));
   Debug.Assert(!Object.ReferenceEquals(typedObj.m_InnerExpression,null));

   if(!base.Equals(typedObj))
   {
    r=false;
   }
   else
   if(!m_InnerExpression.Equals(typedObj.m_InnerExpression))
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
   ("LcpiOleDb__SqlStubExpression::Equals\n"
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
   ("LcpiOleDb__SqlStubExpression::GetHashCode()");
#endif

  //------------------------------------------------------------
  unchecked
  {
   Debug.Assert(!Object.ReferenceEquals(m_InnerExpression,null));

   //-----
   var hashCode=base.GetHashCode();

   hashCode=(hashCode*397)^m_InnerExpression.GetHashCode();

#if TRACE
   Core.Core_Trace.Method_Exit
    ("LcpiOleDb__SqlStubExpression::GetHashCode() - {0}",
     hashCode);
#endif

   return hashCode;
  }//unchecked
 }//GetHasCode

 //-----------------------------------------------------------------------
 public override string ToString()
 {
  Debug.Assert(!Object.ReferenceEquals(m_InnerExpression,null));

  var sb=new System.Text.StringBuilder();

  sb.Append("sql_stub{");
  sb.Append(m_InnerExpression.ToString());
  sb.Append("}");
 
  return sb.ToString();
 }//ToString

 //private data ----------------------------------------------------------
 private readonly System.Type m_Type;

 private readonly Expression m_InnerExpression;
};//class LcpiOleDb__SqlStubExpression

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Expressions

////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 05.10.2018.
using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Svcs{
////////////////////////////////////////////////////////////////////////////////
//Using

using Structure_MemberId
 =Structure.Structure_MemberId;

using LcpiOleDb__LocalEval_MemberTranslator
 =Root.Query.Local.LcpiOleDb__LocalEval_MemberTranslator;

////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__LocalSvc__PrepareForLocalEvaluation

sealed partial class LcpiOleDb__LocalSvc__PrepareForLocalEvaluation
{
 protected override Expression VisitMember(MemberExpression node)
 {
  Debug.Assert(!Object.ReferenceEquals(node,null));
  Debug.Assert(!Object.ReferenceEquals(node.Member,null));

  const string c_bugcheck_src
   ="LcpiOleDb__LocalSvc__PrepareForLocalEvaluation::VisitMember";

  //----------------------------------------
  //
  //! \todo [2021-06-08] Use reflection for get object of type 'System.Linq.Expressions.FieldExpression' ?
  //
  if(node.GetType().FullName=="System.Linq.Expressions.FieldExpression")
   return node;

  //----------------------------------------
  var exprObject
   =node.Expression;

  var exprObject2
   =this.Visit(exprObject);

  if(Object.ReferenceEquals(exprObject,null)!=Object.ReferenceEquals(exprObject2,null))
  {
   //ERROR - mutation

   ThrowBugCheck.LocalEvalErr__mutation_of_expression
    (c_ErrSrcID,
     c_bugcheck_src,
     "#001",
     exprObject,
     exprObject2);
  }//if

  Structure_MemberId memberId2=null;

  if(Object.ReferenceEquals(exprObject,exprObject2))
  {
   //same object OR nulls

   memberId2=new Structure_MemberId(node);
  }
  else
  if(exprObject.Type==exprObject2.Type)
  {
   //same type. just rebuild node

   memberId2=new Structure_MemberId(node);
  }
  else
  {
   Debug.Assert(!Object.ReferenceEquals(exprObject2,null));

   //rebuild instance property

   //[2021-01-12] just try to use our member with a new instance

   memberId2
    =Structure_MemberId.Create_ObjectMember
     (exprObject2.Type,
      node.Member.Name);

   Debug.Assert(!Object.ReferenceEquals(memberId2,null));
  }//else

  Debug.Assert(!Object.ReferenceEquals(memberId2,null));

  LcpiOleDb__LocalEval_MemberTranslator
   translator
    =null;

  Debug.Assert(!Object.ReferenceEquals(m_MemberTranslators,null));

  if(m_MemberTranslators.TryGetValue(memberId2,out translator))
  {
   Debug.Assert(!Object.ReferenceEquals(translator,null));
   Debug.Assert(!Object.ReferenceEquals(translator.MemberId,null));
   Debug.Assert(translator.MemberId==memberId2);

   var opData
    =new LcpiOleDb__LocalEval_MemberTranslator.tagOpData
      (memberId2,
       exprObject2,
       m_ExpressionServices);

   Expression
    result
     =translator.Translate(opData);

   Debug.Assert(!Object.ReferenceEquals(result,null));

   return result;
  }//if TryGetValue

  if(m_ExecutionOfUnknownMethods)
  {
   if(Object.ReferenceEquals(exprObject2,exprObject))
   {
    //
    // Instance not changed.
    //
    // Just return original node.
    //

    return node;
   }//if exprObject2 != exprObject

   Debug.Assert(!Object.ReferenceEquals(exprObject2,exprObject));

   MemberInfo
    memberInfo2
     =memberId2.ObjectType.GetProperty(memberId2.MemberName);

   if(Object.ReferenceEquals(memberInfo2,null))
   {
    ThrowError.LocalEvalErr__MemberNotSupported
     (c_ErrSrcID,
      memberId2);
   }//if

   var result
    =Expression.MakeMemberAccess
      (exprObject2,
       memberInfo2); //throw

   Debug.Assert(!Object.ReferenceEquals(result,null));

   return result;
  }//if m_ExecutionOfUnknownMethods

  Debug.Assert(!m_ExecutionOfUnknownMethods);

  ThrowError.LocalEvalErr__MemberNotSupported
   (c_ErrSrcID,
    memberId2);

  Debug.Assert(false);

  return null;
 }//VisitMember
};//class LcpiOleDb__LocalSvc__PrepareForLocalEvaluation

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Svcs

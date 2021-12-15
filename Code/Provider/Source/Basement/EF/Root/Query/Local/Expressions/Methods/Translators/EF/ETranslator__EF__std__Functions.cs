////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 08.06.2021.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Translators{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_MemberIdCache
 =Structure.Structure_MemberIdCache;

////////////////////////////////////////////////////////////////////////////////
//class ETranslator__EF__std__Functions

sealed class ETranslator__EF__std__Functions
 :LcpiOleDb__LocalEval_MemberTranslator
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Root_Query_Local_Expressions_Methods__ETranslator__EF__std__Functions;

 //-----------------------------------------------------------------------
 public static readonly LcpiOleDb__LocalEval_MemberTranslator
  Instance
   =new ETranslator__EF__std__Functions();

 //-----------------------------------------------------------------------
 private ETranslator__EF__std__Functions()
  :base(Structure_MemberIdCache.MemberIdOf__EF__Functions)
 {
 }//ETranslator__EF__std__Functions

 //interface -------------------------------------------------------------
 public override Expression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.MemberId,null));
  Debug.Assert(Object.ReferenceEquals(opData.Expression,null));

#if DEBUG
  Debug.Assert(opData.MemberId==Structure_MemberIdCache.MemberIdOf__EF__Functions);
#endif

  //----------------------------------------
  Debug.Assert(Object.ReferenceEquals(opData.Expression,null));

  //----------------------------------------
  var memberInfo2
   =opData.MemberId.ObjectType.GetProperty
     (opData.MemberId.MemberName);

  if(Object.ReferenceEquals(memberInfo2,null))
  {
   ThrowError.LocalEvalErr__MemberNotSupported
    (c_ErrSrcID,
     opData.MemberId);
  }//if

  var result
   =Expression.MakeMemberAccess
     (null,
      memberInfo2); //throw

  Debug.Assert(!Object.ReferenceEquals(result,null));

  return result;
 }//Translate
};//class ETranslator__EF__std__Functions

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Translators

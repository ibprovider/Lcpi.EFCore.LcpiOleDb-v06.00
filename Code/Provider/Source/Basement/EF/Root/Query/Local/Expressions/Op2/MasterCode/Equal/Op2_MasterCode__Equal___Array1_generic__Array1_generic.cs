////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 02.12.2021.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.MasterCode{
////////////////////////////////////////////////////////////////////////////////

using T_RESULT
 =System.Boolean;

////////////////////////////////////////////////////////////////////////////////
//class Op2_MasterCode__Equal___Array1_generic__Array1_generic

static class Op2_MasterCode__Equal___Array1_generic__Array1_generic<T_ARG1_E,T_ARG2_E>
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Root_Query_Local_Expressions__Op2_MasterCode__Equal___Array1_generic__Array1_generic;

 //-----------------------------------------------------------------------
 public static T_RESULT Exec(Core.Core_OperationCtx opCtx,
                             T_ARG1_E[]             a,
                             T_ARG2_E[]             b)
 {
  Debug.Assert(!Object.ReferenceEquals(opCtx,null));
  Debug.Assert(!Object.ReferenceEquals(a,null));
  Debug.Assert(!Object.ReferenceEquals(b,null));

  //----------------------------------------
  const string c_bugcheck_src
   ="Op2_MasterCode__Equal___Array1_generic__Array1_generic::Exec";

  //----------------------------------------
  if(a.Length!=b.Length)
  {
   //ERROR - Comparison of arrays with different length not supported.

   ThrowError.LocalEvalErr__ComparisonOfArraysWithDifferentLengthNotSupported
    (c_ErrSrcID,
     a.Length,
     b.Length);
  }//if

  Debug.Assert(a.Length==b.Length);

  //----------------------------------------
  Core.Core_Op2Provider
   op2Provider
    =Core.Core_SvcUtils.QuerySvc<Core.Core_Op2Provider>
      (opCtx,
       Core.Core_SvcID.Core_Op2Provider); //throw

  Debug.Assert(!Object.ReferenceEquals(op2Provider,null));

  //----------------------------------------
  var typeOfElementA=typeof(T_ARG1_E);
  var typeOfElementB=typeof(T_ARG2_E);

  Debug.Assert(!Object.ReferenceEquals(typeOfElementA,null));
  Debug.Assert(!Object.ReferenceEquals(typeOfElementB,null));

  //----------------------------------------
  var op2
   =op2Provider.GetOp2
     (LcpiOleDb__ExpressionType.Equal,
      typeOfElementA,
      typeOfElementB); //no throw

  if(Object.ReferenceEquals(op2,null))
  {
   ThrowError.LocalEvalErr__BinaryOperatorNotSupported
    (c_ErrSrcID,
     LcpiOleDb__ExpressionType.Equal,
     typeOfElementA,
     typeOfElementB);
  }//if

  Debug.Assert(!Object.ReferenceEquals(op2,null));

  //----------------------------------------
  var op2_t
   =Check.BugCheck_Value_NotNullAndInstanceOf<Core.Core_Op2<T_ARG1_E,T_ARG2_E,T_RESULT>,Core.Core_Op2>
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      nameof(op2),
      op2);

  Debug.Assert(!Object.ReferenceEquals(op2_t,null));

  //----------------------------------------
  Debug.Assert(a.Length==b.Length);

  for(int i=0,_c=a.Length;i!=_c;++i)
  {
   var elementA
    =a[i];

   var elementB
    =b[i];

   T_RESULT
    resultOfElementComparison
     =false;

   try
   {
    op2_t.Exec
     (opCtx,
      elementA,
      elementB,
      out resultOfElementComparison); //throw
   }
   catch(Exception e)
   {
    ThrowError.LocalEvalErr__FailedToCompareElementOfArrays
     (c_ErrSrcID,
      new[]{i},
      e);

    Debug.Assert(false);
   }//catch

   if(!resultOfElementComparison)
    return false;
  }//for i

  return true;
 }//Exec
};//class Op2_MasterCode__Equal___Array1_generic__Array1_generic

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.MasterCode

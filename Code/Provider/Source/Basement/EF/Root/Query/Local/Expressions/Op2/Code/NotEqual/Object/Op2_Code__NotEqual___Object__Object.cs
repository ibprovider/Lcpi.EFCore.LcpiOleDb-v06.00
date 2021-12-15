////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 19.05.2021.
using System;
using System.Diagnostics;
using System.Reflection;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1
 =System.Object;

using T_ARG2
 =System.Object;

using T_RESULT
 =System.Boolean;

////////////////////////////////////////////////////////////////////////////////
//class Op2_Code__NotEqual___Object__Object

sealed class Op2_Code__NotEqual___Object__Object
 :Core.Core_Op2<T_ARG1,T_ARG2,T_RESULT>
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Root_Query_Local_Expressions__Op2_Code__NotEqual___Object__Object;

 //-----------------------------------------------------------------------
 public static readonly Op2_Code__NotEqual___Object__Object
  Instance
   =new Op2_Code__NotEqual___Object__Object();

 //-----------------------------------------------------------------------
 public static readonly System.Reflection.MethodInfo MethodInfo_V_V
  =typeof(Op2_Code__NotEqual___Object__Object)
    .GetTypeInfo()
    .GetDeclaredMethod(nameof(Exec_V_V));

 //-----------------------------------------------------------------------
 private Op2_Code__NotEqual___Object__Object()
 {
 }//Op2_Code__NotEqual___Object__Object

 //Interface -------------------------------------------------------------
 public void Exec(Core.Core_OperationCtx opCtx,
                  T_ARG1                 a,
                  T_ARG2                 b,
                  out T_RESULT           result)
 {
  Debug.Assert(!Object.ReferenceEquals(opCtx,null));

  result=Exec_V_V(opCtx,a,b);

  return;
 }//Exec - T_ARG1, T_ARG2

 //-----------------------------------------------------------------------
 private static T_RESULT Exec_V_V(Core.Core_OperationCtx opCtx,
                                  T_ARG1                 a,
                                  T_ARG2                 b)
 {
  Debug.Assert(!Object.ReferenceEquals(opCtx,null));

  //----------------------------------------
  const string c_bugcheck_src
   ="Op2_Code__NotEqual___Object__Object::Exec_V_V";

  //----------------------------------------
  if(Object.Equals(a,null))
  {
   if(Object.ReferenceEquals(b,null))
    return Op2_MasterResults__NotEqual.NULL__NULL;

   return Op2_MasterResults__NotEqual.NULL__VALUE;
  }//if

  Debug.Assert(!Object.ReferenceEquals(a,null));

  //----------------------------------------
  if(Object.ReferenceEquals(b,null))
  {
   return Op2_MasterResults__NotEqual.VALUE__NULL;
  }//if

  Debug.Assert(!Object.ReferenceEquals(b,null));

  //----------------------------------------
  Core.Core_Op2Provider
   op2Provider
    =Core.Core_SvcUtils.QuerySvc<Core.Core_Op2Provider>
      (opCtx,
       Core.Core_SvcID.Core_Op2Provider); //throw

  Debug.Assert(!Object.ReferenceEquals(op2Provider,null));

  //----------------------------------------
  var typeA=a.GetType().Extension__SwitchToUnderlying();
  var typeB=b.GetType().Extension__SwitchToUnderlying();

  Debug.Assert(!Object.ReferenceEquals(typeA,null));
  Debug.Assert(!Object.ReferenceEquals(typeB,null));

  //----------------------------------------
  var op2
   =op2Provider.GetOp2
     (LcpiOleDb__ExpressionType.NotEqual,
      typeA,
      typeB); //no throw

  if(Object.ReferenceEquals(op2,null))
  {
   ThrowError.LocalEvalErr__BinaryOperatorNotSupported
    (c_ErrSrcID,
     LcpiOleDb__ExpressionType.NotEqual,
     typeA,
     typeB);
  }//if

  Debug.Assert(!Object.ReferenceEquals(op2,null));

  //
  // [2021-05-19] Protection for recursive call.
  //
  Debug.Assert
   (typeA!=Structure.Structure_TypeCache.TypeOf__System_Object ||
    typeB!=Structure.Structure_TypeCache.TypeOf__System_Object);

  //----------------------------------------
  var op2_t
   =Check.BugCheck_Value_NotNullAndInstanceOf<Core.Core_Op2<T_ARG1,T_ARG2,T_RESULT>,Core.Core_Op2>
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      nameof(op2),
      op2);

  Debug.Assert(!Object.ReferenceEquals(op2_t,null));

  //----------------------------------------
  T_RESULT result;

  op2_t.Exec
   (opCtx,
    a,
    b,
    out result); //throw?

  return result;
 }//Exec_V_V
};//class Op2_Code__NotEqual___Object__Object

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Code

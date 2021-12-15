////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 03.12.2021.
using System;
using System.Diagnostics;
using System.Reflection;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1_E
 =System.Object;

using T_ARG2_E
 =System.Object;

using T_RESULT
 =System.Boolean;

////////////////////////////////////////////////////////////////////////////////
//class Op2_Code__NotEqual___Array1_Object__Array1_Object

sealed class Op2_Code__NotEqual___Array1_Object__Array1_Object
 :Core.Core_Op2<T_ARG1_E[],T_ARG2_E[],T_RESULT>
 ,Core.Core_Op2<object,object,T_RESULT>
{
 public static readonly Op2_Code__NotEqual___Array1_Object__Array1_Object
  Instance
   =new Op2_Code__NotEqual___Array1_Object__Array1_Object();

 //-----------------------------------------------------------------------
 public static readonly System.Reflection.MethodInfo
  MethodInfo_V_V
   =typeof(Op2_Code__NotEqual___Array1_Object__Array1_Object)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec_V_V));

 //-----------------------------------------------------------------------
 private Op2_Code__NotEqual___Array1_Object__Array1_Object()
 {
 }//Op2_Code__NotEqual___Array1_Object__Array1_Object

 //Interface -------------------------------------------------------------
 public void Exec(Core.Core_OperationCtx opCtx,
                  T_ARG1_E[]             a,
                  T_ARG2_E[]             b,
                  out T_RESULT           result)
 {
  Debug.Assert(!Object.ReferenceEquals(opCtx,null));

  result=Exec_V_V(opCtx,a,b);

  return;
 }//Exec - T_ARG1, T_ARG2

 //-----------------------------------------------------------------------
 public void Exec(Core.Core_OperationCtx opCtx,
                  object                 a,
                  object                 b,
                  out T_RESULT           result)
 {
  Debug.Assert(!Object.ReferenceEquals(opCtx,null));

#if DEBUG
  if(!Object.ReferenceEquals(a,null))
   Debug.Assert(a.GetType()==typeof(T_ARG1_E[]));

  if(!Object.ReferenceEquals(b,null))
   Debug.Assert(b.GetType()==typeof(T_ARG2_E[]));
#endif

  var a_t=(T_ARG1_E[]) a;
  var b_t=(T_ARG2_E[]) b;

  result=Exec_V_V(opCtx,a_t,b_t);

  return;
 }//Exec - object, object

 //-----------------------------------------------------------------------
 private static T_RESULT Exec_V_V(Core.Core_OperationCtx opCtx,
                                  T_ARG1_E[]             a,
                                  T_ARG2_E[]             b)
 {
  Debug.Assert(!Object.ReferenceEquals(opCtx,null));

  //----------------------------------------
  if(Object.ReferenceEquals(a,null))
  {
   if(Object.ReferenceEquals(b,null))
    return Op2_MasterResults__NotEqual.NULL__NULL;

   return Op2_MasterResults__NotEqual.NULL__VALUE;
  }//if

  Debug.Assert(!Object.ReferenceEquals(a,null));

  if(Object.ReferenceEquals(b,null))
  {
   return Op2_MasterResults__NotEqual.VALUE__NULL;
  }//if

  Debug.Assert(!Object.ReferenceEquals(b,null));

  //----------------------------------------
  return MasterCode.Op2_MasterCode__NotEqual___Array1_generic__Array1_generic<T_ARG1_E,T_ARG2_E>.Exec
          (opCtx,
           a,
           b);
 }//Exec_V_V
};//class Op2_Code__NotEqual___Array1_Object__Array1_Object

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Code

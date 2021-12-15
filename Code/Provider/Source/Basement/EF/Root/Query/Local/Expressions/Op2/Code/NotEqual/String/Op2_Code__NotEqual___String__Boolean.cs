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
 =System.String;

using T_ARG2
 =System.Boolean;

using T_RESULT
 =System.Boolean;

//------------------------------------------------------------------------
using T_ARG1X
 =System.Nullable<System.Boolean>;

////////////////////////////////////////////////////////////////////////////////
//class Op2_Code__NotEqual___String__Boolean

sealed class Op2_Code__NotEqual___String__Boolean
 :Core.Core_Op2<object,object,T_RESULT>
{
 public static readonly Op2_Code__NotEqual___String__Boolean
  Instance
   =new Op2_Code__NotEqual___String__Boolean();

 //-----------------------------------------------------------------------
 public static readonly System.Reflection.MethodInfo
  MethodInfo_V_V
   =typeof(Op2_Code__NotEqual___String__Boolean)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec_V_V));

 //-----------------------------------------------------------------------
 private Op2_Code__NotEqual___String__Boolean()
 {
 }//Op2_Code__NotEqual___String__Boolean

 //Interface -------------------------------------------------------------
 public void Exec(Core.Core_OperationCtx opCtx,
                  object                 a,
                  object                 b,
                  out T_RESULT           result)
 {
  Debug.Assert(!Object.ReferenceEquals(opCtx,null));
  Debug.Assert(!Object.ReferenceEquals(b,null));

#if DEBUG
  if(!Object.ReferenceEquals(a,null))
   Debug.Assert(System.Type.GetTypeCode(a.GetType())==System.Type.GetTypeCode(typeof(T_ARG1)));
#endif

  Debug.Assert(System.Type.GetTypeCode(b.GetType())==System.Type.GetTypeCode(typeof(T_ARG2)));

  var a_t=(T_ARG1) a;
  var b_t=(T_ARG2) b;

  result=Exec_V_V(opCtx,a_t,b_t);

  return;
 }//Exec - object, object

 //-----------------------------------------------------------------------
 private static T_RESULT Exec_V_V(Core.Core_OperationCtx opCtx,
                                  T_ARG1                 a,
                                  T_ARG2                 b)
 {
  return MasterCode.Op2_MasterCode__ANY___TEXT__VALUE<T_RESULT,T_ARG1,T_ARG2,T_ARG1X>.Exec
          (opCtx,
           LcpiOleDb__ExpressionType.NotEqual,
           a,
           b);
 }//Exec_V_V
};//class Op2_Code__NotEqual___String__Boolean

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Code

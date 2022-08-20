////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 19.04.2022.
using System;
using System.Diagnostics;
using System.Reflection;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1_V
 =System.Boolean;

using T_ARG1
 =System.Nullable<System.Boolean>;

using T_ARG2
 =System.String;

using T_RESULT
 =System.Boolean;

//------------------------------------------------------------------------
using T_ARG2X
 =System.Nullable<System.Boolean>;

////////////////////////////////////////////////////////////////////////////////
//class Op2_Code__Equal___NullableBoolean__String

sealed class Op2_Code__Equal___NullableBoolean__String
 :Core.Core_Op2<object,object,T_RESULT>
{
 public static readonly Op2_Code__Equal___NullableBoolean__String
  Instance
   =new Op2_Code__Equal___NullableBoolean__String();

 //-----------------------------------------------------------------------
 public static readonly System.Reflection.MethodInfo
  MethodInfo_V_V
   =typeof(Op2_Code__Equal___NullableBoolean__String)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec_V_V));

 //-----------------------------------------------------------------------
 private Op2_Code__Equal___NullableBoolean__String()
 {
 }//Op2_Code__Equal___NullableBoolean__String

 //Interface -------------------------------------------------------------
 public void Exec(Core.Core_OperationCtx opCtx,
                  object                 a,
                  object                 b,
                  out T_RESULT           result)
 {
  Debug.Assert(!Object.ReferenceEquals(opCtx,null));

#if DEBUG
  if(!Object.ReferenceEquals(a,null))
   Debug.Assert(a.GetType()==typeof(T_ARG1_V));
#endif

#if DEBUG
  if(!Object.ReferenceEquals(b,null))
   Debug.Assert(b.GetType()==typeof(T_ARG2));
#endif

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
  return MasterCode.Op2_MasterCode__ANY___VALUE__TEXT<T_RESULT,T_ARG1,T_ARG2,T_ARG2X>.Exec
          (opCtx,
           LcpiOleDb__ExpressionType.Equal,
           a,
           b);
 }//Exec_V_V
};//class Op2_Code__Equal___NullableBoolean__String

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Code

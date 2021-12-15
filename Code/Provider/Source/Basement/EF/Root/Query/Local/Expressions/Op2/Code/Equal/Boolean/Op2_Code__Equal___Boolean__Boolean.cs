////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 18.10.2018.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1
 =System.Boolean;

using T_ARG2
 =System.Boolean;

using T_RESULT
 =System.Boolean;

////////////////////////////////////////////////////////////////////////////////
//class Op2_Code__Equal___Boolean__Boolean

sealed class Op2_Code__Equal___Boolean__Boolean
 :Core.Core_Op2<object,object,T_RESULT>
{
 public static readonly Op2_Code__Equal___Boolean__Boolean
  Instance
   =new Op2_Code__Equal___Boolean__Boolean();

 //-----------------------------------------------------------------------
 public static readonly System.Reflection.MethodInfo
  MethodInfo_V_V
   =typeof(Op2_Code__Equal___Boolean__Boolean)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec_V_V));

 //-----------------------------------------------------------------------
 private Op2_Code__Equal___Boolean__Boolean()
 {
 }//Op2_Code__Equal___Boolean__Boolean

 //Interface -------------------------------------------------------------
 public void Exec(Core.Core_OperationCtx opCtx,
                  object                 a,
                  object                 b,
                  out T_RESULT           result)
 {
  Debug.Assert(!Object.ReferenceEquals(opCtx,null));
  Debug.Assert(!Object.ReferenceEquals(a,null));
  Debug.Assert(!Object.ReferenceEquals(b,null));

  Debug.Assert(System.Type.GetTypeCode(a.GetType())==System.Type.GetTypeCode(typeof(T_ARG1)));
  Debug.Assert(System.Type.GetTypeCode(b.GetType())==System.Type.GetTypeCode(typeof(T_ARG2)));

  var a_t=(T_ARG1) a;
  var b_t=(T_ARG2) b;

  result=Exec_V_V(a_t,b_t);

  return;
 }//Exec - object, object

 //-----------------------------------------------------------------------
 private static T_RESULT Exec_V_V(T_ARG1 a,T_ARG2 b)
 {
  return MasterCode.Op2_MasterCode__Equal___Boolean__Boolean.Exec
          (a,
           b);
 }//Exec_V_V
};//class Op2_Code__Equal___Boolean__Boolean

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Code

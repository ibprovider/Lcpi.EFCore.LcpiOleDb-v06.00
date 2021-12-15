////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 11.05.2021.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1
 =System.TimeSpan;

using T_ARG2
 =System.TimeSpan;

using T_RESULT
 =System.Boolean;

////////////////////////////////////////////////////////////////////////////////

using Structure_ADP
 =Structure.Structure_ADP;

////////////////////////////////////////////////////////////////////////////////
//class Op2_Code__Equal___TimeSpan__TimeSpan

sealed class Op2_Code__Equal___TimeSpan__TimeSpan
 :Core.Core_Op2<object,object,T_RESULT>
{
 public static readonly Op2_Code__Equal___TimeSpan__TimeSpan
  Instance
   =new Op2_Code__Equal___TimeSpan__TimeSpan();

 //-----------------------------------------------------------------------
 public static readonly System.Reflection.MethodInfo
  MethodInfo_V_V
   =typeof(Op2_Code__Equal___TimeSpan__TimeSpan)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec_V_V));

 //-----------------------------------------------------------------------
 private Op2_Code__Equal___TimeSpan__TimeSpan()
 {
 }//Op2_Code__Equal___TimeSpan__TimeSpan

 //Interface -------------------------------------------------------------
 public void Exec(Core.Core_OperationCtx opCtx,
                  object                 a,
                  object                 b,
                  out T_RESULT           result)
 {
  Debug.Assert(!Object.ReferenceEquals(opCtx,null));
  Debug.Assert(!Object.ReferenceEquals(a,null));
  Debug.Assert(!Object.ReferenceEquals(b,null));

  Debug.Assert(a.GetType()==typeof(T_ARG1));
  Debug.Assert(b.GetType()==typeof(T_ARG2));

  var a_t=(T_ARG1) a;
  var b_t=(T_ARG2) b;

  result=Exec_V_V(a_t,b_t);

  return;
 }//Exec - object, object

 //-----------------------------------------------------------------------
 private static T_RESULT Exec_V_V(T_ARG1 a,T_ARG2 b)
 {
  return MasterCode.Op2_MasterCode__Equal___TimeSpan__TimeSpan.Exec
          (a,
           b);
 }//Exec_V_V
};//class Op2_Code__Equal___TimeSpan__TimeSpan

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.Code

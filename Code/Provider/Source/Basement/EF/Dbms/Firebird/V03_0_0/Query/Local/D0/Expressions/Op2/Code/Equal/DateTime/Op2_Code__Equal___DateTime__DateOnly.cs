////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 01.07.2021.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1
 =System.DateTime;

using T_ARG2
 =System.DateOnly;

using T_RESULT
 =System.Boolean;

////////////////////////////////////////////////////////////////////////////////
//class Op2_Code__Equal___DateTime__DateOnly

sealed class Op2_Code__Equal___DateTime__DateOnly
 :Core.Core_Op2<object,object,T_RESULT>
{
 public static readonly Op2_Code__Equal___DateTime__DateOnly
  Instance
   =new Op2_Code__Equal___DateTime__DateOnly();

 //-----------------------------------------------------------------------
 public static readonly System.Reflection.MethodInfo
  MethodInfo_V_V
   =typeof(Op2_Code__Equal___DateTime__DateOnly)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec_V_V));

 //-----------------------------------------------------------------------
 private Op2_Code__Equal___DateTime__DateOnly()
 {
 }//Op2_Code__Equal___DateTime__DateOnly

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
  Debug.Assert(b.GetType()==typeof(T_ARG2));

  var a_t=(T_ARG1) a;
  var b_t=(T_ARG2) b;

  result=Exec_V_V(a_t,b_t);

  return;
 }//Exec - object, object

 //-----------------------------------------------------------------------
 private static T_RESULT Exec_V_V(T_ARG1 a,T_ARG2 b)
 {
  //
  // Firebird compares "TIMESTAMP and DATE" as "TIMESTAMP and (TIMESTAMP)DATE"
  //
  
  //
  // Direct conversion of DateOnly to DateTime
  //
  T_ARG1 b2
   =new T_ARG1
     (b.Year,
      b.Month,
      b.Day);

  Debug.Assert(b.Year ==b2.Year);
  Debug.Assert(b.Month==b2.Month);
  Debug.Assert(b.Day  ==b2.Day);

  return MasterCode.Op2_MasterCode__Equal___DateTime__DateTime.Exec
          (a,
           b2);
 }//Exec_V_V
};//class Op2_Code__Equal___DateTime__DateOnly

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.Code

////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 04.07.2021.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1
 =System.Nullable<System.TimeOnly>;

using T_ARG2
 =System.Nullable<System.TimeOnly>;

using T_RESULT
 =System.Boolean;

////////////////////////////////////////////////////////////////////////////////

using Structure_ADP
 =Structure.Structure_ADP;

////////////////////////////////////////////////////////////////////////////////
//class Op2_Code__NotEqual___NullableTimeOnly__NullableTimeOnly

sealed class Op2_Code__NotEqual___NullableTimeOnly__NullableTimeOnly
 :Core.Core_Op2<T_ARG1,T_ARG2,T_RESULT>
{
 public static readonly Op2_Code__NotEqual___NullableTimeOnly__NullableTimeOnly
  Instance
   =new Op2_Code__NotEqual___NullableTimeOnly__NullableTimeOnly();

 //-----------------------------------------------------------------------
 public static readonly System.Reflection.MethodInfo
  MethodInfo_V_V
   =typeof(Op2_Code__NotEqual___NullableTimeOnly__NullableTimeOnly)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec_V_V));

 //Interface -------------------------------------------------------------
 public void Exec(Core.Core_OperationCtx opCtx,
                  T_ARG1                 a,
                  T_ARG2                 b,
                  out T_RESULT           result)
 {
  Debug.Assert(!Object.ReferenceEquals(opCtx,null));

  result=Exec_V_V(a,b);

  return;
 }//Exec - T_ARG1, T_ARG2

 //-----------------------------------------------------------------------
 private static T_RESULT Exec_V_V(T_ARG1 a,T_ARG2 b)
 {
#if DEBUG

  if(a.HasValue)
  {
   Debug.Assert(Structure_ADP.DEBUG__TimeOnlyContainsValidSqlTime(a.Value));
  }//if

  if(b.HasValue)
  {
   Debug.Assert(Structure_ADP.DEBUG__TimeOnlyContainsValidSqlTime(b.Value));
  }//if

#endif //DEBUG

  //-------------------------------------------------------
  if(!a.HasValue)
  {
   if(!b.HasValue)
    return Op2_MasterResults__NotEqual.NULL__NULL;

   Debug.Assert(b.HasValue);

   return Op2_MasterResults__NotEqual.NULL__VALUE;
  }//if

  Debug.Assert(a.HasValue);

  if(!b.HasValue)
  {
   return Op2_MasterResults__NotEqual.VALUE__NULL;
  }//if

  Debug.Assert(b.HasValue);

  return MasterCode.Op2_MasterCode__NotEqual___TimeOnly__TimeOnly.Exec
          (a.Value,
           b.Value);
 }//Exec_V_V
};//class Op2_Code__NotEqual___NullableTimeOnly__NullableTimeOnly

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.Code

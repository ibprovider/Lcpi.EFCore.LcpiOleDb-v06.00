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
 =System.Nullable<System.TimeOnly>;

using T_ARG2
 =System.Nullable<System.TimeOnly>;

using T_RESULT
 =System.Boolean;

////////////////////////////////////////////////////////////////////////////////

using Structure_ADP
 =Structure.Structure_ADP;

////////////////////////////////////////////////////////////////////////////////
//class Op2_Code__Equal___NullableTimeOnly__NullableTimeOnly

static class Op2_Code__Equal___NullableTimeOnly__NullableTimeOnly
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo_V_V
   =typeof(Op2_Code__Equal___NullableTimeOnly__NullableTimeOnly)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec_V_V));

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
    return Op2_MasterResults__Equal.NULL__NULL;

   Debug.Assert(b.HasValue);

   return Op2_MasterResults__Equal.NULL__VALUE;
  }//if

  Debug.Assert(a.HasValue);

  if(!b.HasValue)
  {
   return Op2_MasterResults__Equal.VALUE__NULL;
  }//if

  Debug.Assert(b.HasValue);

  return MasterCode.Op2_MasterCode__Equal___TimeOnly__TimeOnly.Exec
          (a.Value,
           b.Value);
 }//Exec_V_V
};//class Op2_Code__Equal___NullableTimeOnly__NullableTimeOnly

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.Code

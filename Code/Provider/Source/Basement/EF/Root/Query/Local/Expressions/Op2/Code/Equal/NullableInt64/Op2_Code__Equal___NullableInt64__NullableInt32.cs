////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 29.04.2019.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1
 =System.Nullable<System.Int64>;

using T_ARG2
 =System.Nullable<System.Int32>;

using T_RESULT
 =System.Boolean;

////////////////////////////////////////////////////////////////////////////////
//class Op2_Code__Equal___NullableInt64__NullableInt32

static class Op2_Code__Equal___NullableInt64__NullableInt32
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo_V_V
   =typeof(Op2_Code__Equal___NullableInt64__NullableInt32)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec_V_V));

 //-----------------------------------------------------------------------
 private static T_RESULT Exec_V_V(T_ARG1 a,T_ARG2 b)
 {
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

  return MasterCode.Op2_MasterCode__Equal___Int64__Int64.Exec
          (a.Value,
           b.Value);
 }//Exec_V_V
};//class Op2_Code__Equal___NullableInt64__NullableInt32

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Code

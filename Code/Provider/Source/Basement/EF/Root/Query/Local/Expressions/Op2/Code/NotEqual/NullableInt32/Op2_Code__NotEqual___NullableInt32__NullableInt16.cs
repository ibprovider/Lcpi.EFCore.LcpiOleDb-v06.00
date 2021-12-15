////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 15.05.2021.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1
 =System.Nullable<System.Int32>;

using T_ARG2
 =System.Nullable<System.Int16>;

using T_RESULT
 =System.Boolean;

////////////////////////////////////////////////////////////////////////////////
//class Op2_Code__NotEqual___NullableInt32__NullableInt16

static class Op2_Code__NotEqual___NullableInt32__NullableInt16
{
 public static readonly System.Reflection.MethodInfo MethodInfo_V_V
  =typeof(Op2_Code__NotEqual___NullableInt32__NullableInt16)
    .GetTypeInfo()
    .GetDeclaredMethod(nameof(Exec_V_V));

 //-----------------------------------------------------------------------
 private static T_RESULT Exec_V_V(T_ARG1 a,T_ARG2 b)
 {
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

  return MasterCode.Op2_MasterCode__NotEqual___Int32__Int32.Exec
          (a.Value,
           b.Value);
 }//Exec_V_V
};//class Op2_Code__NotEqual___NullableInt32__NullableInt16

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Code

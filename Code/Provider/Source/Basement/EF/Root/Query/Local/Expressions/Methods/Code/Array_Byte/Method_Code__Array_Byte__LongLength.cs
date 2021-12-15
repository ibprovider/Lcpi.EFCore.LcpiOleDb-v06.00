////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 24.05.2021.
using System;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG_E
 =System.Byte;

using T_RESULT
 =System.Nullable<System.Int64>;

////////////////////////////////////////////////////////////////////////////////
//class Method_Code__Array_Byte__LongLength

static class Method_Code__Array_Byte__LongLength
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Method_Code__Array_Byte__LongLength)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static T_RESULT Exec(T_ARG_E[] v)
 {
  if(Object.ReferenceEquals(v,null))
   return null;
 
  return v.LongLength;
 }//Exec
};//class Method_Code__Array_Byte__LongLength

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code

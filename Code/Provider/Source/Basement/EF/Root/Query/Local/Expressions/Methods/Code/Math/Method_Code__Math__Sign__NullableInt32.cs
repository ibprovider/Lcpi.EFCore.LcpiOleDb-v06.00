////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 02.05.2019.
using System;
using System.Diagnostics;
using System.Reflection;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code{
////////////////////////////////////////////////////////////////////////////////
//class Method_Code__Math__Sign__NullableInt32

static class Method_Code__Math__Sign__NullableInt32
{
 private static readonly System.Reflection.MethodInfo sm_MethodInfo
  =typeof(Method_Code__Math__Sign__NullableInt32)
    .GetTypeInfo()
    .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static Nullable<Int32> Exec(Nullable<Int32> value)
 {
  if(!value.HasValue)
   return null;

  return Math.Sign(value.Value);
 }//Exec

 //-----------------------------------------------------------------------
 public static MethodCallExpression CreateCallExpression(Expression e)
 {
  Debug.Assert(!Object.ReferenceEquals(e,null));
  Debug.Assert(!Object.ReferenceEquals(e.Type,null));
  Debug.Assert(e.Type==Structure.Structure_TypeCache.TypeOf__System_NullableInt32);

  Debug.Assert(!Object.ReferenceEquals(sm_MethodInfo,null));

  if(e is MethodCallExpression x)
  {
   Debug.Assert(!Object.ReferenceEquals(x.Method,null));

   //SIGN(SIGN(intValue) -> SIGN(intValue)
   if(Object.ReferenceEquals(x.Method,sm_MethodInfo))
    return x;

   //SIGN(SIGN(sbyteValue) -> SIGN(sbyteValue)
   if(Object.ReferenceEquals(x.Method,Method_Code__Math__Sign__NullableSByte.GetMethodInfo()))
    return x;

   //SIGN(SIGN(shortValue) -> SIGN(shortValue)
   if(Object.ReferenceEquals(x.Method,Method_Code__Math__Sign__NullableInt16.GetMethodInfo()))
    return x;

   //SIGN(SIGN(longValue) -> SIGN(longValue)
   if(Object.ReferenceEquals(x.Method,Method_Code__Math__Sign__NullableInt64.GetMethodInfo()))
    return x;

   //SIGN(SIGN(decimalValue) -> SIGN(decimalValue)
   if(Object.ReferenceEquals(x.Method,Method_Code__Math__Sign__NullableDecimal.GetMethodInfo()))
    return x;

   //SIGN(SIGN(floatValue) -> SIGN(floatValue)
   if(Object.ReferenceEquals(x.Method,Method_Code__Math__Sign__NullableSingle.GetMethodInfo()))
    return x;

   //SIGN(SIGN(doubleValue) -> SIGN(doubleValue)
   if(Object.ReferenceEquals(x.Method,Method_Code__Math__Sign__NullableDouble.GetMethodInfo()))
    return x;
  }//if

  return Expression.Call(sm_MethodInfo,e);
 }//CreateCallExpression
};//class Method_Code__Math__Sign__NullableInt32

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code

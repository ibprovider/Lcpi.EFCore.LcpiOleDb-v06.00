////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 29.03.2019.
using System;
using System.Diagnostics;
using System.Reflection;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code{
////////////////////////////////////////////////////////////////////////////////
//class Method_Code__Math__Truncate__Decimal

static class Method_Code__Math__Truncate__Decimal
{
 private static readonly System.Reflection.MethodInfo sm_MethodInfo
  =typeof(Method_Code__Math__Truncate__Decimal)
    .GetTypeInfo()
    .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static Decimal Exec(Decimal value)
 {
  return Math.Truncate(value);
 }//Exec

 //-----------------------------------------------------------------------
 public static MethodCallExpression CreateCallExpression(Expression e)
 {
  Debug.Assert(!Object.ReferenceEquals(e,null));
  Debug.Assert(!Object.ReferenceEquals(e.Type,null));
  Debug.Assert(e.Type==Structure.Structure_TypeCache.TypeOf__System_Decimal);

  Debug.Assert(!Object.ReferenceEquals(sm_MethodInfo,null));

  if(e is MethodCallExpression x)
  {
   Debug.Assert(!Object.ReferenceEquals(x.Method,null));

   if(Object.ReferenceEquals(x.Method,sm_MethodInfo))
    return x;
  }//if

  return Expression.Call(sm_MethodInfo,e);
 }//CreateCallExpression
};//class Method_Code__Math__Truncate__Decimal

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code

////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 30.04.2019.
using System;
using System.Diagnostics;
using System.Reflection;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code{
////////////////////////////////////////////////////////////////////////////////
//class Method_Code__Math__Sign__Single

static class Method_Code__Math__Sign__Single
{
 private static readonly System.Reflection.MethodInfo sm_MethodInfo
  =typeof(Method_Code__Math__Sign__Single)
    .GetTypeInfo()
    .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static Int32 Exec(Single value)
 {
  return Math.Sign(value);
 }//Exec

 //-----------------------------------------------------------------------
 public static MethodCallExpression CreateCallExpression(Expression e)
 {
  Debug.Assert(!Object.ReferenceEquals(e,null));
  Debug.Assert(!Object.ReferenceEquals(e.Type,null));
  Debug.Assert(e.Type==Structure.Structure_TypeCache.TypeOf__System_Single);

  Debug.Assert(!Object.ReferenceEquals(sm_MethodInfo,null));

  return Expression.Call(sm_MethodInfo,e);
 }//CreateCallExpression

 //-----------------------------------------------------------------------
 public static System.Reflection.MethodInfo GetMethodInfo()
 {
  Debug.Assert(!Object.ReferenceEquals(sm_MethodInfo,null));

  return sm_MethodInfo;
 }//GetMethodInfo
};//class Method_Code__Math__Sign__Single

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code

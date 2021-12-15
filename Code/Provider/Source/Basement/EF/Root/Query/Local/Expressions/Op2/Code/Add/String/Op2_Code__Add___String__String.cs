////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 26.09.2018.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Code{
////////////////////////////////////////////////////////////////////////////////
//class Op2_Code__Add___String__String

static class Op2_Code__Add___String__String
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo_V_V
   =typeof(Op2_Code__Add___String__String)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec_V_V));

 //-----------------------------------------------------------------------
 private static String Exec_V_V(String a,String b)
 {
  // C#: (string)null + null == "" !!!

  Debug.Assert(((string)null+(string)null)=="");
  Debug.Assert(((string)null+(string)"")  =="");
  Debug.Assert(((string)""  +(string)null)=="");

  return a+b;
 }//Exec_V_V
};//class Op2_Code__Add___String__String

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Code

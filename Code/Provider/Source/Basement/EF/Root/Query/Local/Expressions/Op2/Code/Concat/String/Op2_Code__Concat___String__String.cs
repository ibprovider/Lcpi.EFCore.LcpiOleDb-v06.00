////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 10.12.2021.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Code{
////////////////////////////////////////////////////////////////////////////////

using T_ARG1
 =System.String;

using T_ARG2
 =System.String;

using T_RESULT
 =System.String;

////////////////////////////////////////////////////////////////////////////////
//class Op2_Code__Concat___String__String

static class Op2_Code__Concat___String__String
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Op2_Code__Concat___String__String)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static T_RESULT Exec(T_ARG1 str0,T_ARG2 str1)
 {
  Debug.Assert(!Object.ReferenceEquals(string.Concat((T_ARG1)null ,(T_ARG2)null),null));
  Debug.Assert(!Object.ReferenceEquals(string.Concat((T_ARG1)""   ,(T_ARG2)null),null));
  Debug.Assert(!Object.ReferenceEquals(string.Concat((T_ARG1)null ,(T_ARG2)""  ),null));

  var r=string.Concat(str0,str1);

  Debug.Assert(!Object.ReferenceEquals(r,null));

  return r;
 }//Exec
};//class Op2_Code__Concat___String__String

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Code

////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 14.06.2021.
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1
 =System.Collections.Generic.IEnumerable<System.Byte>;

using T_ARG2
 =System.Collections.Generic.IEnumerable<System.Byte>;

using T_RESULT
 =System.Nullable<System.Boolean>;

////////////////////////////////////////////////////////////////////////////////
//class Method_Code__IEnumerableByte__SequenceEqual

static class Method_Code__IEnumerableByte__SequenceEqual
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Method_Code__IEnumerableByte__SequenceEqual)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static T_RESULT Exec(T_ARG1 collection,
                              T_ARG2 testValue)
 {
  if(Object.ReferenceEquals(collection,null))
   return null;

  if(Object.ReferenceEquals(testValue,null))
   return null;

  var resultValue
   =collection.SequenceEqual
     (testValue);

  return resultValue;
 }//Exec
};//class Method_Code__IEnumerableByte__SequenceEqual

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code

////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 14.06.2021.
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1_E
 =System.Byte;

using T_RESULT
 =System.Nullable<System.Byte>;

////////////////////////////////////////////////////////////////////////////////
//class Method_Code__IEnumerableByte__First

static class Method_Code__IEnumerableByte__First
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Root_Query_Local_Expressions__Method_Code__IEnumerableByte__First;

 //-----------------------------------------------------------------------
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Method_Code__IEnumerableByte__First)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static T_RESULT Exec(IEnumerable<T_ARG1_E> values)
 {
  if(Object.ReferenceEquals(values,null))
   return null;

  foreach(var x in values)
  {
   return x;
  }//foreach x

  ThrowError.EmptyListOfValues
   (c_ErrSrcID);

  Debug.Assert(false);

  return null;
 }//Exec
};//class Method_Code__IEnumerableByte__First

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code

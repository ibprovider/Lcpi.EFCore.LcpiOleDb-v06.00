////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 16.09.2021.
using System;
using System.Diagnostics;
using System.Linq;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.MasterCode{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1_E
 =System.Char;

using T_ARG2_E
 =System.Char;

using T_RESULT
 =System.Boolean;

////////////////////////////////////////////////////////////////////////////////
//class Op2_MasterCode__NotEqual___Array1_Char__Array1_Char

static class Op2_MasterCode__NotEqual___Array1_Char__Array1_Char
{
 public static T_RESULT Exec(T_ARG1_E[] a,T_ARG2_E[] b)
 {
  Debug.Assert(!Object.ReferenceEquals(a,null));
  Debug.Assert(!Object.ReferenceEquals(b,null));

  // Console.WriteLine("---------------------------");
  // Console.WriteLine("a: {0}",a);
  // Console.WriteLine("b: {0}",b);
  // Console.WriteLine("---------------------------");

  if(a.Length!=b.Length)
   return true;

  var isEqual
   =a.SequenceEqual(b);

  if(!isEqual)
   return true;

  Debug.Assert(isEqual);

  return false;
 }//Exec
};//class Op2_MasterCode__NotEqual___Array1_Char__Array1_Char

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.MasterCode
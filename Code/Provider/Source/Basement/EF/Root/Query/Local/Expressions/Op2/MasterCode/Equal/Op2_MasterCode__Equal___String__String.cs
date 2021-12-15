////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 10.05.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.MasterCode{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1
 =System.String;

using T_ARG2
 =System.String;

using T_RESULT
 =System.Boolean;

////////////////////////////////////////////////////////////////////////////////
//class Op2_MasterCode__Equal___String__String

static class Op2_MasterCode__Equal___String__String
{
 public static T_RESULT Exec(T_ARG1 a,T_ARG2 b)
 {
  Debug.Assert(!Object.ReferenceEquals(a,null));
  Debug.Assert(!Object.ReferenceEquals(b,null));

  // Console.WriteLine("---------------------------");
  // Console.WriteLine("a: {0}",a);
  // Console.WriteLine("b: {0}",b);
  // Console.WriteLine("---------------------------");

  if(a.Length!=b.Length)
   return false;

  var compareResult
   =String.CompareOrdinal(a,b);

  if(compareResult!=0)
   return false;

  Debug.Assert(compareResult==0);

  return true;
 }//Exec
};//class Op2_MasterCode__Equal___String__String

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.MasterCode
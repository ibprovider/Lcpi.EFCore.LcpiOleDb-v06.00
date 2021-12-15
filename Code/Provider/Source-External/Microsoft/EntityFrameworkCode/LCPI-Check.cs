////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 23.12.2020.
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

#nullable enable

namespace Lcpi.EXT.Microsoft.EntityFrameworkCore{
////////////////////////////////////////////////////////////////////////////////
//class Check

static class Check
{
 public static T NotNull<T>(T? value,string valueName) where T: class
 {
  Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Check.Arg_NotNull
   (Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.ErrSourceID.EXT,
    "NO DATA",
    valueName,
    value);

  Debug.Assert(!Object.ReferenceEquals(value,null));

  return value!;
 }//NotNull

 //--------------------------------------------------------
 [Conditional("DEBUG")]
 public static void DebugAssert([DoesNotReturnIf(false)] bool condition,
                                string                        message)
 {
  if(condition)
   return;

  throw new Exception($"Check.DebugAssert failed: {message}");
 }//DebugAssert
};//class Check

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EXT.Microsoft.EntityFrameworkCore

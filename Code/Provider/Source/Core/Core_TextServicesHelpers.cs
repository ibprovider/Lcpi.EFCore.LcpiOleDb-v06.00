////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core.
//                                      IBProvider and Contributors. 17.02.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core{
////////////////////////////////////////////////////////////////////////////////
//class Core_TextServicesHelpers

static class Core_TextServicesHelpers
{
 public static int Skip__EmptySymbols(Core_TextServices textServices,
                                      string            text,
                                      int               offset)
 {
  Debug.Assert(!Object.ReferenceEquals(textServices,null));
  Debug.Assert(!Object.ReferenceEquals(text,null));

  Debug.Assert(offset>=0);
  Debug.Assert(offset<=text.Length);

  while(offset<text.Length)
  {
   int n=textServices.Test_Empty_Symbol(text,offset);

   if(n==0)
    break;

   Debug.Assert(n<=(text.Length-offset));

   offset+=n;
  }//while

  return offset;
 }//Skip__EmptySymbols
};//class Core_TextServicesHelpers

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core

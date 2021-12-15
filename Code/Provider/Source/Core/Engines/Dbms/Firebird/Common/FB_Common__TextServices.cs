////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core. Engines. Dbms. Firebird.
//                                      IBProvider and Contributors. 16.02.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common{
////////////////////////////////////////////////////////////////////////////////
//class FB_Common__TextServices

sealed class FB_Common__TextServices:Core_TextServices
{
 public static readonly FB_Common__TextServices
  Instance
   =new FB_Common__TextServices();

 //private constructor ---------------------------------------------------
 private FB_Common__TextServices()
 {
 }//FB_Common__TextServices

 //Interface -------------------------------------------------------------
 public int Test_Empty_Symbol(string text,
                              int    offset)
 {
  Debug.Assert(!Object.ReferenceEquals(text,null));
  Debug.Assert(offset>=0);
  Debug.Assert(offset<text.Length);

  switch(text[offset])
  {
   case ' ' :
   case '\t':
   case '\n':
   case '\r':
    return 1;

   default:
    return 0;
  }//switch
 }//Test_Empty_Symbol
};//class FB_Common__TextServices

////////////////////////////////////////////////////////////////////////////////
}//Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common

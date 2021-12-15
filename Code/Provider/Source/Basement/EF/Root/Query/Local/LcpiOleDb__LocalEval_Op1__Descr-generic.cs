////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 12.10.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__LocalEval_Op1__Descr<TRANSLATOR>

struct LcpiOleDb__LocalEval_Op1__Descr<TRANSLATOR>
 where TRANSLATOR:LcpiOleDb__LocalEval_UnaryTranslator
{
 public readonly TRANSLATOR Translator;

 //Can be null.
 public readonly Core.Core_Op1 Op1;

 //constructor -----------------------------------------------------------
 public LcpiOleDb__LocalEval_Op1__Descr(TRANSLATOR    translator,
                                        Core.Core_Op1 op1)
 {
  Debug.Assert(!Object.ReferenceEquals(translator,null));

  this.Translator =translator;
  this.Op1        =op1;
 }//LcpiOleDb__LocalEval_Op1__Descr

 //-----------------------------------------------------------------------
 public LcpiOleDb__LocalEval_Op1__Descr(TRANSLATOR translator)
 {
  Debug.Assert(!Object.ReferenceEquals(translator,null));

  this.Translator =translator;
  this.Op1        =null;
 }//LcpiOleDb__LocalEval_Op1__Descr
};//struct LcpiOleDb__LocalEval_Op1__Descr<TRANSLATOR>

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local

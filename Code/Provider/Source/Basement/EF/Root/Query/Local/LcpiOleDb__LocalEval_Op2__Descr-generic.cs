////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 12.02.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__LocalEval_Op2__Descr<TRANSLATOR>

struct LcpiOleDb__LocalEval_Op2__Descr<TRANSLATOR>
 where TRANSLATOR:LcpiOleDb__LocalEval_BinaryTranslator
{
 public readonly TRANSLATOR Translator;

 //Can be null.
 public readonly Core.Core_Op2 Op2;

 //constructor -----------------------------------------------------------
 public LcpiOleDb__LocalEval_Op2__Descr(TRANSLATOR    translator,
                                        Core.Core_Op2 op2)
 {
  Debug.Assert(!Object.ReferenceEquals(translator,null));

  this.Translator =translator;
  this.Op2        =op2;
 }//LcpiOleDb__LocalEval_Op2__Descr

 //-----------------------------------------------------------------------
 public LcpiOleDb__LocalEval_Op2__Descr(TRANSLATOR translator)
 {
  Debug.Assert(!Object.ReferenceEquals(translator,null));

  this.Translator =translator;
  this.Op2        =null;
 }//LcpiOleDb__LocalEval_Op2__Descr
};//struct LcpiOleDb__LocalEval_Op2__Descr<TRANSLATOR>

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local

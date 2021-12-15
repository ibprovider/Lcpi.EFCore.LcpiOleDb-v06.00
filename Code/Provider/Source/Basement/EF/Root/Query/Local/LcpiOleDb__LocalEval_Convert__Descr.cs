////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 05.01.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__LocalEval_Convert__Descr

struct LcpiOleDb__LocalEval_Convert__Descr
{
 public readonly LcpiOleDb__LocalEval_ConvertTranslator Translator;

 //[2021-01-08] Devel time: can be null.
 public readonly Core.Core_ValueCvt ValueCvt;

 //constructor -----------------------------------------------------------
 public LcpiOleDb__LocalEval_Convert__Descr(LcpiOleDb__LocalEval_ConvertTranslator translator,
                                            Core.Core_ValueCvt                     valueCvt)
 {
  Debug.Assert(!Object.ReferenceEquals(translator,null));

  this.Translator =translator;
  this.ValueCvt   =valueCvt;
 }//LcpiOleDb__LocalEval_Convert__Descr
};//struct LcpiOleDb__LocalEval_Convert__Descr

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local

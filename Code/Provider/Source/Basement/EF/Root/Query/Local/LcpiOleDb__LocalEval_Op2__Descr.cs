////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 12.02.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__LocalEval_Op2__Descr

struct LcpiOleDb__LocalEval_Op2__Descr
{
 public readonly LcpiOleDb__LocalEval_BinaryTranslator Translator;

 //Can be null.
 public readonly Core.Core_Op2 Op2;

 //constructor -----------------------------------------------------------
 public LcpiOleDb__LocalEval_Op2__Descr(LcpiOleDb__LocalEval_BinaryTranslator translator,
                                        Core.Core_Op2                         op2)
 {
  Debug.Assert(!Object.ReferenceEquals(translator,null));

  this.Translator =translator;
  this.Op2        =op2;
 }//LcpiOleDb__LocalEval_Op2__Descr

 //-----------------------------------------------------------------------
 public static LcpiOleDb__LocalEval_Op2__Descr Create<T>(in LcpiOleDb__LocalEval_Op2__Descr<T> descr)
  where T:LcpiOleDb__LocalEval_BinaryTranslator
 {
  Debug.Assert(!Object.ReferenceEquals(descr.Translator,null));

  return new LcpiOleDb__LocalEval_Op2__Descr
          (descr.Translator,
           descr.Op2);
 }//Create
};//struct LcpiOleDb__LocalEval_Op2__Descr

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local

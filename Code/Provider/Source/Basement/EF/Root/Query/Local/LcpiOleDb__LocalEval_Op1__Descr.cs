////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 12.10.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__LocalEval_Op1__Descr

struct LcpiOleDb__LocalEval_Op1__Descr
{
 public readonly LcpiOleDb__LocalEval_UnaryTranslator Translator;

 //Can be null.
 public readonly Core.Core_Op1 Op1;

 //constructor -----------------------------------------------------------
 public LcpiOleDb__LocalEval_Op1__Descr(LcpiOleDb__LocalEval_UnaryTranslator translator,
                                        Core.Core_Op1                        op1)
 {
  Debug.Assert(!Object.ReferenceEquals(translator,null));

  this.Translator =translator;
  this.Op1        =op1;
 }//LcpiOleDb__LocalEval_Op1__Descr

 //-----------------------------------------------------------------------
 public static LcpiOleDb__LocalEval_Op1__Descr Create<T>(in LcpiOleDb__LocalEval_Op1__Descr<T> descr)
  where T:LcpiOleDb__LocalEval_UnaryTranslator
 {
  Debug.Assert(!Object.ReferenceEquals(descr.Translator,null));

  return new LcpiOleDb__LocalEval_Op1__Descr
          (descr.Translator,
           descr.Op1);
 }//Create
};//struct LcpiOleDb__LocalEval_Op1__Descr

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local

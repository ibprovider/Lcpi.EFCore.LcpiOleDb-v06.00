////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 12.10.2021.
using System;
using System.Linq.Expressions;
using System.Diagnostics;
using System.Collections.Generic;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__LocalEval_Op1__Map

sealed partial class LcpiOleDb__LocalEval_Op1__Map
{
 private sealed class tagLevel1_Single:tagLevel1
 {
  public tagLevel1_Single(in LcpiOleDb__LocalEval_Op1__Descr op1Descr)
  {
   Debug.Assert(!Object.ReferenceEquals(op1Descr.Translator,null));

   m_Op1Descr=op1Descr;
  }//tagLevel1_Single

  //tagLevel1 interface --------------------------------------------------
  public override void Reg(System.Type                        operandType,
                           in LcpiOleDb__LocalEval_Op1__Descr op1Descr)
  {
   Debug.Assert(false);

   ThrowBugCheck.incorrect_call_of_method
    (ErrSourceID.common,
     "LcpiOleDb__LocalEval_Op1__Map.tagLevel1_Single.Reg",
     "#001");
  }//Reg

  //----------------------------------------------------------------------
  public override bool TryGet(System.Type                         operandType,
                              out LcpiOleDb__LocalEval_Op1__Descr op1Descr)
  {
   op1Descr=m_Op1Descr;

   Debug.Assert(!Object.ReferenceEquals(op1Descr.Translator,null));

   return true;
  }//TryGet

  //private data ---------------------------------------------------------
  private readonly LcpiOleDb__LocalEval_Op1__Descr m_Op1Descr;
 };//class tagLevel1_Single
};//class LcpiOleDb__LocalEval_Op1__Map

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local

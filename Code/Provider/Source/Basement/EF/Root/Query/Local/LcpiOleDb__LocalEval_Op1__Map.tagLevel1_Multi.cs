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
 private sealed class tagLevel1_Multi:tagLevel1
 {
  public tagLevel1_Multi()
  {
   m_Items=new tagItems();
  }//tagLevel1_Multi

  //tagLevel1 interface --------------------------------------------------
  public override void Reg(System.Type                        operandType,
                           in LcpiOleDb__LocalEval_Op1__Descr op1Descr)
  {
   Debug.Assert(!Object.ReferenceEquals(m_Items,null));

   Debug.Assert(!Object.ReferenceEquals(operandType,null));
   Debug.Assert(!Object.ReferenceEquals(op1Descr.Translator,null));

   Debug.Assert(!m_Items.ContainsKey(operandType));

   m_Items.Add(operandType,op1Descr);
  }//Reg

  //----------------------------------------------------------------------
  public override bool TryGet(System.Type                         operandType,
                              out LcpiOleDb__LocalEval_Op1__Descr op1Descr)
  {
   Debug.Assert(!Object.ReferenceEquals(m_Items,null));

   op1Descr=default;

   if(!m_Items.TryGetValue(operandType,out op1Descr))
    return false;

   Debug.Assert(!Object.ReferenceEquals(op1Descr.Translator,null));

   return true;
  }//TryGet

  //private types --------------------------------------------------------
  private sealed class tagItems:Dictionary<System.Type,LcpiOleDb__LocalEval_Op1__Descr>{};

  //private data ---------------------------------------------------------
  private readonly tagItems m_Items;
 };//class tagLevel1_Multi
};//class LcpiOleDb__LocalEval_Op1__Map

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local

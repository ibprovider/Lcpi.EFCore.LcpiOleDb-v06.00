////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 04.10.2018.
using System;
using System.Linq.Expressions;
using System.Diagnostics;
using System.Collections.Generic;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__LocalEval_Op2__Map

sealed class LcpiOleDb__LocalEval_Op2__Map
{
 public struct tagRegOperator
 {
  private readonly LcpiOleDb__LocalEval_Op2__Map m_Map;
  private readonly LcpiOleDb__ExpressionType     m_OpId;

  //----------------------------------------------------------------------
  public tagRegOperator(LcpiOleDb__LocalEval_Op2__Map Map,
                        LcpiOleDb__ExpressionType     OpId)
  {
   Debug.Assert(!Object.ReferenceEquals(Map,null));

   m_Map  =Map;
   m_OpId =OpId;
  }//tagRegOperator

  //----------------------------------------------------------------------
  public tagRegOperator Add<T>(System.Type                           typeLeft,
                               System.Type                           typeRight,
                               in LcpiOleDb__LocalEval_Op2__Descr<T> op2Descr)
   where T:LcpiOleDb__LocalEval_BinaryTranslator
  {
   Debug.Assert(!Object.ReferenceEquals(typeLeft,null));
   Debug.Assert(!Object.ReferenceEquals(typeRight,null));
   Debug.Assert(!Object.ReferenceEquals(op2Descr.Translator,null));
   Debug.Assert(!Object.ReferenceEquals(m_Map,null));

   m_Map.Helper__Reg
    (m_OpId,
     typeLeft,
     typeRight,
     LcpiOleDb__LocalEval_Op2__Descr.Create(op2Descr));

   return this;
  }//Add

  //----------------------------------------------------------------------
  public tagRegOperator Reg(LcpiOleDb__ExpressionType OpId)
  {
   return new tagRegOperator(m_Map,OpId);
  }//Reg

  //----------------------------------------------------------------------
  public LcpiOleDb__LocalEval_Op2__Map Done()
  {
   Debug.Assert(!Object.ReferenceEquals(m_Map,null));

   return m_Map;
  }//Done
 };//struct tagRegOperator

 //-----------------------------------------------------------------------
 public LcpiOleDb__LocalEval_Op2__Map()
 {
 }//LcpiOleDb__LocalEval_Op2__Map

 //interface -------------------------------------------------------------
 public tagRegOperator Reg(LcpiOleDb__ExpressionType OpId)
 {
  return new tagRegOperator(this,OpId);
 }//Reg

 //-----------------------------------------------------------------------
 public bool TryGetValue(LcpiOleDb__ExpressionType           opID,
                         System.Type                         type1,
                         System.Type                         type2,
                         out LcpiOleDb__LocalEval_Op2__Descr op2Descr)
 {
  Debug.Assert(!Object.ReferenceEquals(type1,null));
  Debug.Assert(!Object.ReferenceEquals(type2,null));

  Debug.Assert(!Object.ReferenceEquals(m_Items,null));

  op2Descr=default;

  tagLevel1 level1=null;

  if(!m_Items.TryGetValue(opID,out level1))
   return false;

  Debug.Assert(!Object.ReferenceEquals(level1,null));

  tagLevel2 level2=null;

  if(!level1.TryGetValue(type1,out level2))
   return false;

  Debug.Assert(!Object.ReferenceEquals(level1,null));

  if(!level2.TryGetValue(type2,out op2Descr))
   return false;

  Debug.Assert(!Object.ReferenceEquals(op2Descr.Translator,null));

  return true;
 }//TryGetValue

 //Helper methods --------------------------------------------------------
 private LcpiOleDb__LocalEval_Op2__Map Helper__Reg
                                           (LcpiOleDb__ExpressionType          opID,
                                            System.Type                        typeLeft,
                                            System.Type                        typeRight,
                                            in LcpiOleDb__LocalEval_Op2__Descr op2Descr)
 {
  Debug.Assert(!Object.ReferenceEquals(typeLeft,null));
  Debug.Assert(!Object.ReferenceEquals(typeRight,null));
  Debug.Assert(!Object.ReferenceEquals(op2Descr.Translator,null));

  Debug.Assert(!Object.ReferenceEquals(m_Items,null));

  tagLevel1 level1=null;

  if(!m_Items.TryGetValue(opID,out level1))
  {
   level1=new tagLevel1();

   m_Items.Add(opID,level1); //throw
  }//if

  Debug.Assert(!Object.ReferenceEquals(level1,null));

  tagLevel2 level2=null;

  if(!level1.TryGetValue(typeLeft,out level2))
  {
   level2=new tagLevel2();

   level1.Add(typeLeft,level2); //throw
  }//if

  Debug.Assert(!Object.ReferenceEquals(level2,null));

  Debug.Assert(!level2.ContainsKey(typeRight));

  level2.Add(typeRight,op2Descr); //throw

  return this;
 }//Helper__Reg

 //private type ----------------------------------------------------------
 private sealed class tagLevel2:Dictionary<System.Type,LcpiOleDb__LocalEval_Op2__Descr>{};
 private sealed class tagLevel1:Dictionary<System.Type,tagLevel2>{};
 private sealed class tagLevel0:Dictionary<LcpiOleDb__ExpressionType,tagLevel1>{};

 //private data ----------------------------------------------------------
 private tagLevel0 m_Items=new tagLevel0();
};//class LcpiOleDb__LocalEval_Op2__Map

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local
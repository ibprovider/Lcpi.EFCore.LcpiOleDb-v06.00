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
 public struct tagRegOperator
 {
  private readonly LcpiOleDb__LocalEval_Op1__Map m_Map;
  private readonly ExpressionType                m_OpId;

  //----------------------------------------------------------------------
  public tagRegOperator(LcpiOleDb__LocalEval_Op1__Map Map,
                        ExpressionType                OpId)
  {
   Debug.Assert(!Object.ReferenceEquals(Map,null));

   m_Map  =Map;
   m_OpId =OpId;
  }//tagRegOperator

  //----------------------------------------------------------------------
  public tagRegOperator Add<T>(in LcpiOleDb__LocalEval_Op1__Descr<T> op1Descr)
   where T:LcpiOleDb__LocalEval_UnaryTranslator
  {
   Debug.Assert(!Object.ReferenceEquals(op1Descr.Translator,null));
   Debug.Assert(!Object.ReferenceEquals(m_Map,null));

   m_Map.Helper__Reg_Single
    (m_OpId,
     LcpiOleDb__LocalEval_Op1__Descr.Create(op1Descr));

   return this;
  }//Add

  //----------------------------------------------------------------------
  public tagRegOperator Add<T>(System.Type                           typeOperand,
                               in LcpiOleDb__LocalEval_Op1__Descr<T> op1Descr)
   where T:LcpiOleDb__LocalEval_UnaryTranslator
  {
   Debug.Assert(!Object.ReferenceEquals(typeOperand,null));
   Debug.Assert(!Object.ReferenceEquals(op1Descr.Translator,null));
   Debug.Assert(!Object.ReferenceEquals(m_Map,null));

   m_Map.Helper__Reg_Multi
    (m_OpId,
     typeOperand,
     LcpiOleDb__LocalEval_Op1__Descr.Create(op1Descr));

   return this;
  }//Add

  //----------------------------------------------------------------------
  public tagRegOperator Reg(ExpressionType OpId)
  {
   return new tagRegOperator(m_Map,OpId);
  }//Reg

  //----------------------------------------------------------------------
  public LcpiOleDb__LocalEval_Op1__Map Done()
  {
   Debug.Assert(!Object.ReferenceEquals(m_Map,null));

   return m_Map;
  }//Done
 };//struct tagRegOperator

 //-----------------------------------------------------------------------
 public LcpiOleDb__LocalEval_Op1__Map()
 {
 }//LcpiOleDb__LocalEval_Op1__Map

 //interface -------------------------------------------------------------
 public tagRegOperator Reg(ExpressionType OpId)
 {
  return new tagRegOperator(this,OpId);
 }//Reg

 //-----------------------------------------------------------------------
 public bool TryGetValue(ExpressionType                      opID,
                         System.Type                         type1,
                         out LcpiOleDb__LocalEval_Op1__Descr op1Descr)
 {
  Debug.Assert(!Object.ReferenceEquals(type1,null));

  Debug.Assert(!Object.ReferenceEquals(m_Items,null));

  op1Descr=default;

  tagLevel1 level1=null;

  if(!m_Items.TryGetValue(opID,out level1))
   return false;

  Debug.Assert(!Object.ReferenceEquals(level1,null));

  if(!level1.TryGet(type1,out op1Descr))
   return false;

  Debug.Assert(!Object.ReferenceEquals(op1Descr.Translator,null));

  return true;
 }//TryGetValue

 //Helper methods --------------------------------------------------------
 private LcpiOleDb__LocalEval_Op1__Map Helper__Reg_Single
                                           (ExpressionType                     opID,
                                            in LcpiOleDb__LocalEval_Op1__Descr op1Descr)
 {
  Debug.Assert(!Object.ReferenceEquals(op1Descr.Translator,null));

  Debug.Assert(!Object.ReferenceEquals(m_Items,null));

  Debug.Assert(!m_Items.ContainsKey(opID));

  var level1=new tagLevel1_Single(op1Descr);

  m_Items.Add(opID,level1); //throw

  return this;
 }//Helper__Reg_Single

 //-----------------------------------------------------------------------
 private LcpiOleDb__LocalEval_Op1__Map Helper__Reg_Multi
                                           (ExpressionType                     opID,
                                            System.Type                        typeOperand,
                                            in LcpiOleDb__LocalEval_Op1__Descr op1Descr)
 {
  Debug.Assert(!Object.ReferenceEquals(typeOperand,null));
  Debug.Assert(!Object.ReferenceEquals(op1Descr.Translator,null));

  Debug.Assert(!Object.ReferenceEquals(m_Items,null));

  tagLevel1 level1=null;

  if(!m_Items.TryGetValue(opID,out level1))
  {
   level1=new tagLevel1_Multi();

   m_Items.Add(opID,level1); //throw
  }//if

  Debug.Assert(!Object.ReferenceEquals(level1,null));

  level1.Reg(typeOperand,op1Descr); //throw

  return this;
 }//Helper__Reg_Multi

 //private types ---------------------------------------------------------
 private abstract class tagLevel1
 {
  public abstract void Reg(System.Type                        operandType,
                           in LcpiOleDb__LocalEval_Op1__Descr op1Descr);

  public abstract bool TryGet(System.Type                         operandType,
                              out LcpiOleDb__LocalEval_Op1__Descr op1Descr);
 };//class tagLevel1

 //-----------------------------------------------------------------------
 private sealed class tagLevel0:Dictionary<ExpressionType,tagLevel1>{};

 //private data ----------------------------------------------------------
 private tagLevel0 m_Items=new tagLevel0();
};//class LcpiOleDb__LocalEval_Op1__Map

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local

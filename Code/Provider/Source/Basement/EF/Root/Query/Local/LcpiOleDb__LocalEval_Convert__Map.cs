////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 14.10.2018.
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__LocalEval_Convert__Map

sealed class LcpiOleDb__LocalEval_Convert__Map
{
 public LcpiOleDb__LocalEval_Convert__Map()
 {
 }//LcpiOleDb__LocalEval_Convert__Map

 //interface -------------------------------------------------------------
 public LcpiOleDb__LocalEval_Convert__Map Add(in LcpiOleDb__LocalEval_Convert__Descr cvtDescr)
 {
  this.Helper__Add(cvtDescr);

  return this;
 }//Add

 //-----------------------------------------------------------------------
 public bool TryGetValue(System.Type                             typeFrom,
                         System.Type                             typeTo,
                         out LcpiOleDb__LocalEval_Convert__Descr cvtDescr)
 {
  Debug.Assert(!Object.ReferenceEquals(typeFrom,null));
  Debug.Assert(!Object.ReferenceEquals(typeTo,null));

  Debug.Assert(!Object.ReferenceEquals(m_Items,null));

  cvtDescr=default;

  tagLevel1 level1=null;

  if(!m_Items.TryGetValue(typeFrom,out level1))
   return false;

  Debug.Assert(!Object.ReferenceEquals(level1,null));

  if(!level1.TryGetValue(typeTo,out cvtDescr))
   return false;

#if DEBUG
  Debug.Assert(!Object.ReferenceEquals(cvtDescr.Translator,null));

  Debug.Assert(!Object.ReferenceEquals(cvtDescr.Translator.SourceType,null));

  Debug.Assert(cvtDescr.Translator.SourceType==typeFrom);

  Debug.Assert(!Object.ReferenceEquals(cvtDescr.Translator.TargetType,null));

  Debug.Assert(cvtDescr.Translator.TargetType==typeTo);
#endif

  return true;
 }//TryGetValue

 //Helper methods --------------------------------------------------------
 void Helper__Add(in LcpiOleDb__LocalEval_Convert__Descr cvtDescr)
 {
  Debug.Assert(!Object.ReferenceEquals(cvtDescr.Translator,null));
  Debug.Assert(!Object.ReferenceEquals(cvtDescr.Translator.SourceType,null));
  Debug.Assert(!Object.ReferenceEquals(cvtDescr.Translator.TargetType,null));

  //----------------------------------------
  var typeFrom=cvtDescr.Translator.SourceType;

  Debug.Assert(!Object.ReferenceEquals(typeFrom,null));

  //----------------------------------------
  var typeTo=cvtDescr.Translator.TargetType;

  Debug.Assert(!Object.ReferenceEquals(typeTo,null));

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(m_Items,null));

  tagLevel1 level1=null;

  if(!m_Items.TryGetValue(typeFrom,out level1))
  {
   level1=new tagLevel1();

   m_Items.Add(typeFrom,level1); //throw
  }//if

  Debug.Assert(!Object.ReferenceEquals(level1,null));

  Debug.Assert(!level1.ContainsKey(typeTo));

  level1.Add(typeTo,cvtDescr); //throw
 }//Helper__Add

 //private type ----------------------------------------------------------
 private sealed class tagLevel1:Dictionary<System.Type,LcpiOleDb__LocalEval_Convert__Descr>{};
 private sealed class tagLevel0:Dictionary<System.Type,tagLevel1>{};

 //private data ----------------------------------------------------------
 private readonly tagLevel0 m_Items=new tagLevel0();
};//class LcpiOleDb__LocalEval_Convert__Map

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local

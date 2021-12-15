////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 04.10.2018.
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_MethodId
 =Structure.Structure_MethodId;

////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__LocalEval_MethodCallTranslators

sealed class LcpiOleDb__LocalEval_MethodCallTranslators
{
 public LcpiOleDb__LocalEval_MethodCallTranslators()
 {
 }//LcpiOleDb__LocalEval_MethodCallTranslators

 //interface -------------------------------------------------------------
 public IReadOnlyList<Structure_MethodId> GetMethodIDs(string methodName)
 {
  Debug.Assert(!string.IsNullOrEmpty(methodName));

  Debug.Assert(!Object.ReferenceEquals(m_Names,null));

  tagIDs ids;

  if(!m_Names.TryGetValue(methodName,out ids))
   return sm_EmptyIDs;

  Debug.Assert(!Object.ReferenceEquals(ids,null));

  Debug.Assert(ids.Count>0);

  return ids;
 }//GetMethodIDs

 //-----------------------------------------------------------------------
 public LcpiOleDb__LocalEval_MethodCallTranslators Add(LcpiOleDb__LocalEval_MethodCallTranslator x)
 {
  Debug.Assert(!Object.ReferenceEquals(x,null));
  Debug.Assert(!Object.ReferenceEquals(x.MethodId,null));

  Debug.Assert(!Object.ReferenceEquals(m_Items,null));
  Debug.Assert(!Object.ReferenceEquals(m_Names,null));

  Debug.Assert(!m_Items.ContainsKey(x.MethodId));

  m_Items.Add(x.MethodId,x);

  tagIDs ids;

  if(!m_Names.TryGetValue(x.MethodId.MethodName,out ids))
  {
   ids=new tagIDs();

   m_Names.Add(x.MethodId.MethodName,ids);
  }//if

  Debug.Assert(!Object.ReferenceEquals(ids,null));

  Debug.Assert(!ids.Contains(x.MethodId));

  ids.Add(x.MethodId);

  return this;
 }//Add

 //-----------------------------------------------------------------------
 public bool TryGetValue(Structure_MethodId                            methodId,
                         out LcpiOleDb__LocalEval_MethodCallTranslator translator)
 {
  Debug.Assert(!Object.ReferenceEquals(methodId,null));
  Debug.Assert(!Object.ReferenceEquals(m_Items,null));

  if(!m_Items.TryGetValue(methodId,out translator))
   return false;
  
  Debug.Assert(!Object.ReferenceEquals(translator,null));

  Debug.Assert(translator.MethodId.Equals(methodId));

  return true;
 }//TryGetValue

 //private types ---------------------------------------------------------
 private sealed class tagItems:Dictionary<Structure_MethodId,LcpiOleDb__LocalEval_MethodCallTranslator>{};

 private sealed class tagIDs:List<Structure_MethodId>{};

 private sealed class tagNames:Dictionary<string,tagIDs>{};

 //private data ----------------------------------------------------------
 private readonly tagItems m_Items=new tagItems();

 private readonly tagNames m_Names=new tagNames();

 //-----------------------------------------------------------------------
 private static readonly Structure_MethodId[] sm_EmptyIDs=new Structure_MethodId[0];
};//class LcpiOleDb__LocalEval_MethodCallTranslators

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local

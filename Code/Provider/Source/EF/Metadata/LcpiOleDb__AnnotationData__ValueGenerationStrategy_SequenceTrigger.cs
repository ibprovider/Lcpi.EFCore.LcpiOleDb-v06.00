////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core.
//                                      IBProvider and Contributors. 05.11.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.MetaData{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__AnnotationData__ValueGenerationStrategy_SequenceTrigger

sealed class LcpiOleDb__AnnotationData__ValueGenerationStrategy_SequenceTrigger
 :LcpiOleDb__AnnotationData__ValueGenerationStrategy
{
 private LcpiOleDb__AnnotationData__ValueGenerationStrategy_SequenceTrigger
                            (string triggerName,
                             string sequenceName)
 {
  Debug.Assert(!string.IsNullOrEmpty(triggerName));
  Debug.Assert(!string.IsNullOrEmpty(sequenceName));

  m_TriggerName  =triggerName;
  m_SequenceName =sequenceName;
 }//LcpiOleDb__AnnotationData__ValueGenerationStrategy_SequenceTrigger

 //-----------------------------------------------------------------------
 internal static LcpiOleDb__AnnotationData__ValueGenerationStrategy Create
                            (string triggerName,
                             string sequenceName)
 {
  Debug.Assert(!string.IsNullOrEmpty(triggerName));
  Debug.Assert(!string.IsNullOrEmpty(sequenceName));

  return new LcpiOleDb__AnnotationData__ValueGenerationStrategy_SequenceTrigger
          (triggerName,
           sequenceName);
 }//Create

 //VGS interface ---------------------------------------------------------
 internal override string Internal__GetStrategyName()
 {
  return c_StrategyName;
 }//Internal__GetStrategyName

 //interface -------------------------------------------------------------
 public string TriggerName
 {
  get
  {
   return m_TriggerName;
  }
 }//TriggerName

 //-----------------------------------------------------------------------
 public string SequenceName
 {
  get
  {
   return m_SequenceName;
  }
 }//SequenceName

 //-----------------------------------------------------------------------
 public bool EqualTo(LcpiOleDb__AnnotationData__ValueGenerationStrategy_SequenceTrigger valueGenerationStrategy)
 {
  Debug.Assert(!Object.ReferenceEquals(valueGenerationStrategy,null));

  if(!System.StringComparer.Ordinal.Equals(valueGenerationStrategy.m_TriggerName,m_TriggerName))
   return false;

  if(!System.StringComparer.Ordinal.Equals(valueGenerationStrategy.m_SequenceName,m_SequenceName))
   return false;

  return true;
 }//EqualTo

 //Object interface ------------------------------------------------------
 public override bool Equals(object obj)
 {
  bool resultValue=false;

  if(Object.ReferenceEquals(obj,this))
  {
   resultValue=true;
  }
  else
  if(Object.ReferenceEquals(obj,null))
  {
   Debug.Assert(!resultValue);
  }
  else
  if(obj.GetType()==this.GetType())
  {
   var obj_t
    =(LcpiOleDb__AnnotationData__ValueGenerationStrategy_SequenceTrigger)obj;

   if(this.EqualTo(obj_t))
   {
    resultValue=true;
   }//if
  }
  else
  {
   Debug.Assert(!resultValue);
  }//else

  return resultValue;
 }//Equals

 //-----------------------------------------------------------------------
 public override int GetHashCode()
 {
  Debug.Assert(!Object.ReferenceEquals(c_StrategyName,null));
  Debug.Assert(!Object.ReferenceEquals(m_TriggerName,null));
  Debug.Assert(!Object.ReferenceEquals(m_SequenceName,null));

  unchecked
  {
   var hashCode=GetType().GetHashCode();

   hashCode=(hashCode*397)^c_StrategyName.GetHashCode();
   hashCode=(hashCode*397)^m_TriggerName.GetHashCode();
   hashCode=(hashCode*397)^m_SequenceName.GetHashCode();

   return hashCode;
  }//unchecked
 }//GetHashCode

 //private data ----------------------------------------------------------
 private const string c_StrategyName
  ="SequenceTrigger";

 //private data ----------------------------------------------------------
 private readonly string m_TriggerName;
 private readonly string m_SequenceName;
};//class LcpiOleDb__AnnotationData__ValueGenerationStrategy_SequenceTrigger

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.MetaData

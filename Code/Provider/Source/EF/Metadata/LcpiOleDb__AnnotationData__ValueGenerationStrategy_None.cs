////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core.
//                                      IBProvider and Contributors. 05.11.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.MetaData{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__AnnotationData__ValueGenerationStrategy_None

sealed class LcpiOleDb__AnnotationData__ValueGenerationStrategy_None
 :LcpiOleDb__AnnotationData__ValueGenerationStrategy
{
 private LcpiOleDb__AnnotationData__ValueGenerationStrategy_None()
 {
 }//LcpiOleDb__AnnotationData__ValueGenerationStrategy_None

 //-----------------------------------------------------------------------
 internal static LcpiOleDb__AnnotationData__ValueGenerationStrategy Create()
 {
  Debug.Assert(!Object.ReferenceEquals(sm_Instance,null));

  return sm_Instance;
 }//Create

 //VGS interface ---------------------------------------------------------
 internal override string Internal__GetStrategyName()
 {
  return c_StrategyName;
 }//Internal__GetStrategyName

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
   resultValue=true;
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

  unchecked
  {
   var hashCode=GetType().GetHashCode();

   hashCode=(hashCode*397)^c_StrategyName.GetHashCode();

   return hashCode;
  }//unchecked
 }//GetHashCode

 //private data ----------------------------------------------------------
 private const string c_StrategyName
  ="None";

 //-----------------------------------------------------------------------
 private static readonly LcpiOleDb__AnnotationData__ValueGenerationStrategy
  sm_Instance
   =new LcpiOleDb__AnnotationData__ValueGenerationStrategy_None();
};//class LcpiOleDb__AnnotationData__ValueGenerationStrategy_None

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.MetaData

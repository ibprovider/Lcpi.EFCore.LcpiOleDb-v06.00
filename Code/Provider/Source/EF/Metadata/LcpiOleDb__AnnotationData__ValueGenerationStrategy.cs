////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core.
//                                      IBProvider and Contributors. 05.11.2021.
using System;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.MetaData{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__AnnotationData__ValueGenerationStrategy

public abstract class LcpiOleDb__AnnotationData__ValueGenerationStrategy
 :LcpiOleDb__AnnotationData
{
 internal LcpiOleDb__AnnotationData__ValueGenerationStrategy()
 {
 }//LcpiOleDb__AnnotationData__ValueGenerationStrategy

 //interface -------------------------------------------------------------
 internal abstract string Internal__GetStrategyName();

 //Object interface ------------------------------------------------------
 public override abstract bool Equals(object obj);
 
 //-----------------------------------------------------------------------
 public override abstract int GetHashCode();

 //-----------------------------------------------------------------------
 public static bool operator == (LcpiOleDb__AnnotationData__ValueGenerationStrategy a,
                                 LcpiOleDb__AnnotationData__ValueGenerationStrategy b)
 {
  if(Object.ReferenceEquals(a,null))
  {
   if(Object.ReferenceEquals(b,null))
    return true;

   return false;
  }//if

  if(Object.ReferenceEquals(b,null))
  {
   return false;
  }//if

  return a.Equals(b);
 }//operator ==

 //-----------------------------------------------------------------------
 public static bool operator != (LcpiOleDb__AnnotationData__ValueGenerationStrategy a,
                                 LcpiOleDb__AnnotationData__ValueGenerationStrategy b)
 {
  return !(a==b);
 }//operator !=
};//class LcpiOleDb__AnnotationData__ValueGenerationStrategy

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.MetaData

////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 13.11.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb{
////////////////////////////////////////////////////////////////////////////////

using LcpiOleDb__AnnotationNames
 =MetaData.Internal.LcpiOleDb__AnnotationNames;

using LcpiOleDb__AnnotationData__VGS
 =MetaData.LcpiOleDb__AnnotationData__ValueGenerationStrategy;

////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__Common___AnnotationHelpers

static class LcpiOleDb__Common___AnnotationHelpers
{
 public static LcpiOleDb__AnnotationData__VGS GetValueGenerationStrategyOrNull
                            (ErrSourceID                        errSrcID,
                             IReadOnlyAnnotatable               sourceObject)
 {
  Debug.Assert(!Object.ReferenceEquals(sourceObject,null));

  return Helper__GetAnnotationValueOrNull<LcpiOleDb__AnnotationData__VGS>
          (errSrcID,
           sourceObject,
           LcpiOleDb__AnnotationNames.ValueGenerationStrategy);
 }//GetValueGenerationStrategyOrNull

 //-----------------------------------------------------------------------
 public static bool TryGetValueGenerationStrategy
                            (ErrSourceID                        errSrcID,
                             IReadOnlyAnnotatable               sourceObject,
                             out LcpiOleDb__AnnotationData__VGS annotationValue)
 {
  Debug.Assert(!Object.ReferenceEquals(sourceObject,null));

  return Helper__TryGetAnnotationValue
          (errSrcID,
           sourceObject,
           LcpiOleDb__AnnotationNames.ValueGenerationStrategy,
           out annotationValue);
 }//TryGetValueGenerationStrategy

 //-----------------------------------------------------------------------
 public static bool NeedSetValueGenerationStrategy
                            (ErrSourceID                    errSrcID,
                             IReadOnlyAnnotatable           annotableObject,
                             LcpiOleDb__AnnotationData__VGS valueGenerationStrategy)
 {
  Debug.Assert(!Object.ReferenceEquals(annotableObject,null));

  if(TryGetValueGenerationStrategy(errSrcID,annotableObject,out var currentVGS))
  {
   Debug.Assert(!Object.ReferenceEquals(currentVGS,null));

   if(!Object.ReferenceEquals(valueGenerationStrategy,null))
   {
    if(valueGenerationStrategy.Equals(currentVGS))
     return false;

    return true;
   }//if

   Debug.Assert(Object.ReferenceEquals(valueGenerationStrategy,null));

   return true;
  }//if

  Debug.Assert(Object.ReferenceEquals(currentVGS,null));

  if(!Object.ReferenceEquals(valueGenerationStrategy,null))
  {
   return true;
  }//if

  Debug.Assert(Object.ReferenceEquals(valueGenerationStrategy,null));

  return false;
 }//NeedSetValueGenerationStrategy

 //Helper methods --------------------------------------------------------
 private static T_ANNOTATION_VALUE Helper__GetAnnotationValueOrNull<T_ANNOTATION_VALUE>
                            (ErrSourceID          errSrcID,
                             IReadOnlyAnnotatable sourceObject,
                             string               annotationName)
  where T_ANNOTATION_VALUE:class
 {
  Debug.Assert(!Object.ReferenceEquals(sourceObject,null));
  Debug.Assert(!Object.ReferenceEquals(annotationName,null));

  Debug.Assert(annotationName.Length>0);

  var annotationValue_obj
   =sourceObject[annotationName];

  if(Object.ReferenceEquals(annotationValue_obj,null))
   return null;

  var annotationValue
   =annotationValue_obj as T_ANNOTATION_VALUE;

  if(Object.ReferenceEquals(annotationValue,null))
  {
   ThrowError.AnnotationHasValueWithUnexpectedType
    (errSrcID,
     annotationName,
     annotationValue_obj.GetType(),
     typeof(T_ANNOTATION_VALUE));
  }//if

  Debug.Assert(!Object.ReferenceEquals(annotationValue,null));

  return annotationValue;
 }//Helper__GetAnnotationValueOrNull<T_ANNOTATION_VALUE>

 //-----------------------------------------------------------------------
 private static bool Helper__TryGetAnnotationValue<T_ANNOTATION_VALUE>
                            (ErrSourceID            errSrcID,
                             IReadOnlyAnnotatable   sourceObject,
                             string                 annotationName,
                             out T_ANNOTATION_VALUE annotationValue)
  where T_ANNOTATION_VALUE:class
 {
  Debug.Assert(!Object.ReferenceEquals(sourceObject,null));
  Debug.Assert(!Object.ReferenceEquals(annotationName,null));

  Debug.Assert(annotationName.Length>0);

  annotationValue
   =null;

  var annotationValue_obj
   =sourceObject[annotationName];

  if(Object.ReferenceEquals(annotationValue_obj,null))
   return false;

  annotationValue
   =annotationValue_obj as T_ANNOTATION_VALUE;

  if(Object.ReferenceEquals(annotationValue,null))
  {
   ThrowError.AnnotationHasValueWithUnexpectedType
    (errSrcID,
     annotationName,
     annotationValue_obj.GetType(),
     typeof(T_ANNOTATION_VALUE));
  }//if

  return true;
 }//Helper__TryGetAnnotationValue<T_ANNOTATION_VALUE>
};//class LcpiOleDb__Common___AnnotationHelpers

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb

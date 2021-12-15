////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 14.05.2018.
using System;
using System.Diagnostics;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb{
////////////////////////////////////////////////////////////////////////////////
//class Check

static partial class Check
{
 public static void Arg_NotNull
                        (ErrSourceID errSrcID,
                         string      methodName,
                         string      paramName,
                         object      value)
 {
  // [2020-10-14] Tested.

  Debug.Assert(!string.IsNullOrEmpty(methodName));
  Debug.Assert(!string.IsNullOrEmpty(paramName));

  if(Object.ReferenceEquals(value,null))
  {
   ThrowSysError.argument_is_null
    (errSrcID,
     methodName,
     paramName);
  }//if

  Debug.Assert(!Object.ReferenceEquals(value,null));
 }//Arg_NotNull

 //-----------------------------------------------------------------------
 public static void Arg_IsNull
                        (ErrSourceID errSrcID,
                         string      methodName,
                         string      paramName,
                         object      value)
 {
  // [2020-10-20] Tested.

  Debug.Assert(!string.IsNullOrEmpty(methodName));
  Debug.Assert(!string.IsNullOrEmpty(paramName));

  if(!Object.ReferenceEquals(value,null))
  {
   ThrowSysError.argument_is_not_null
    (errSrcID,
     methodName,
     paramName);
  }//if

  Debug.Assert(Object.ReferenceEquals(value,null));
 }//Arg_IsNull

 //-----------------------------------------------------------------------
 public static void Arg_IsNullOrNotEmpty
                        (ErrSourceID errSrcID,
                         string      methodName,
                         string      paramName,
                         string      value)
 {
  // [2021-11-03] Tested.

  Debug.Assert(!string.IsNullOrEmpty(methodName));
  Debug.Assert(!string.IsNullOrEmpty(paramName));

  if(Object.ReferenceEquals(value,null))
   return;

  Debug.Assert(!Object.ReferenceEquals(value,null));

  if(value.Length==0)
  {
   ThrowSysError.argument_is_empty
    (errSrcID,
     methodName,
     paramName);
  }//if

  Debug.Assert(value.Length>0);
 }//Arg_IsNullOrNotEmpty

 //-----------------------------------------------------------------------
 public static void Arg_IsNullOrNotEmpty<T>
                        (ErrSourceID            errSrcID,
                         string                 methodName,
                         string                 paramName,
                         IReadOnlyCollection<T> valueCollection)
 {
  Debug.Assert(!string.IsNullOrEmpty(methodName));
  Debug.Assert(!string.IsNullOrEmpty(paramName));

  if(Object.ReferenceEquals(valueCollection,null))
   return;

  Debug.Assert(!Object.ReferenceEquals(valueCollection,null));

  if(valueCollection.Count==0)
  {
   ThrowSysError.argument_is_empty
    (errSrcID,
     methodName,
     paramName);
  }//if

  Debug.Assert(valueCollection.Count>0);
 }//Arg_IsNullOrNotEmpty<T>

 //-----------------------------------------------------------------------
 public static void Arg_NotNullAndNotEmpty
                        (ErrSourceID errSrcID,
                         string      methodName,
                         string      paramName,
                         string      value)
 {
  // [2020-10-14] Tested.

  Debug.Assert(!string.IsNullOrEmpty(methodName));
  Debug.Assert(!string.IsNullOrEmpty(paramName));

  Arg_NotNull
   (errSrcID,
    methodName,
    paramName,
    value);

  Debug.Assert(!Object.ReferenceEquals(value,null));

  if(value.Length==0)
  {
   ThrowSysError.argument_is_empty
    (errSrcID,
     methodName,
     paramName);
  }//if

  Debug.Assert(value.Length>0);
 }//Arg_NotNullAndNotEmpty

 //-----------------------------------------------------------------------
 public static void Arg_NotNullAndNotEmpty<T>
                        (ErrSourceID            errSrcID,
                         string                 methodName,
                         string                 paramName,
                         IReadOnlyCollection<T> valueCollection)
 {
  // [2021-11-03] Tested.

  Debug.Assert(!string.IsNullOrEmpty(methodName));
  Debug.Assert(!string.IsNullOrEmpty(paramName));

  Arg_NotNull
   (errSrcID,
    methodName,
    paramName,
    valueCollection);

  Debug.Assert(!Object.ReferenceEquals(valueCollection,null));

  if(valueCollection.Count==0)
  {
   ThrowSysError.argument_is_empty
    (errSrcID,
     methodName,
     paramName);
  }//if

  Debug.Assert(valueCollection.Count>0);
 }//Arg_NotNullAndNotEmpty<T>

 //-----------------------------------------------------------------------
 public static T Arg_NotNullAndInstanceOf<T,T1>
                        (ErrSourceID errSrcID,
                         string      methodName,
                         string      paramName,
                         T1          value)
                    where T:class, T1
                    where T1:class
 {
  // [2020-10-14] Tested.

  Debug.Assert(!string.IsNullOrEmpty(methodName));
  Debug.Assert(!string.IsNullOrEmpty(paramName));

  Arg_NotNull
   (errSrcID,
    methodName,
    paramName,
    value);

  Debug.Assert(!Object.ReferenceEquals(value,null));

  var value_x=value as T;

  if(Object.ReferenceEquals(value_x,null))
  {
   ThrowError.ArgErr__BadValueType
    (errSrcID,
     methodName,
     paramName,
     value.GetType(),
     typeof(T));
  }//if

  Debug.Assert(!Object.ReferenceEquals(value_x,null));

  return value_x;
 }//Arg_NotNullAndInstanceOf

 //-----------------------------------------------------------------------
 public static T Arg_NullOrInstanceOf<T,T1>
                        (ErrSourceID errSrcID,
                         string      methodName,
                         string      paramName,
                         T1          value)
                    where T:class, T1
                    where T1:class
 {
  // [2020-10-14] Tested.

  Debug.Assert(!string.IsNullOrEmpty(methodName));
  Debug.Assert(!string.IsNullOrEmpty(paramName));

  if(Object.ReferenceEquals(value,null))
   return null;

  Debug.Assert(!Object.ReferenceEquals(value,null));

  var value_x=value as T;

  if(Object.ReferenceEquals(value_x,null))
  {
   ThrowError.ArgErr__BadValueType
    (errSrcID,
     methodName,
     paramName,
     value.GetType(),
     typeof(T));
  }//if

  Debug.Assert(!Object.ReferenceEquals(value_x,null));

  return value_x;
 }//Arg_NullOrInstanceOf

 //-----------------------------------------------------------------------
 public static void Arg_ListSize
                        (ErrSourceID      errSrcID,
                         string           methodName,
                         string           paramName,
                         int              actualSize,
                         int              expectedSize)
 {
  // [2020-10-21] Tested.

  Debug.Assert(!string.IsNullOrEmpty(methodName));
  Debug.Assert(!string.IsNullOrEmpty(paramName));

  if(actualSize==expectedSize)
  {
   return;
  }//if

  Debug.Assert(actualSize!=expectedSize);

  ThrowError.ArgErr__BadListSize
   (errSrcID,
    methodName,
    paramName,
    actualSize,
    expectedSize);

  Debug.Assert(false);
 }//Arg_ListSize

 //-----------------------------------------------------------------------
 public static void Arg_ListSize__GreaterThanOrEqual
                        (ErrSourceID      errSrcID,
                         string           methodName,
                         string           paramName,
                         int              actualSize,
                         int              minSize)
 {
  Debug.Assert(!string.IsNullOrEmpty(methodName));
  Debug.Assert(!string.IsNullOrEmpty(paramName));

  //Expected
  Debug.Assert(minSize>0);

  if(minSize<=actualSize)
  {
   return;
  }//if

  Debug.Assert(actualSize<minSize);

  ThrowError.ArgErr__BadListSize
   (errSrcID,
    methodName,
    paramName,
    actualSize);

  Debug.Assert(false);
 }//Arg_ListSize__GreaterThanOrEqual

 //-----------------------------------------------------------------------
 public static void BugCheck_Value_NotNull
                        (ErrSourceID errSrcID,
                         string      place,
                         string      point,
                         string      valueName,
                         object      value)
 {
  // [2020-10-21] Tested.

  Debug.Assert(!string.IsNullOrEmpty(place));
  Debug.Assert(!string.IsNullOrEmpty(point));
  Debug.Assert(!string.IsNullOrEmpty(valueName));

  if(Object.ReferenceEquals(value,null))
  {
   ThrowBugCheck.value_is_null
    (errSrcID,
     place,
     point,
     valueName);
  }//if

  Debug.Assert(!Object.ReferenceEquals(value,null));
 }//BugCheck_Value_NotNull

 //-----------------------------------------------------------------------
 public static void BugCheck_Value_NotNullAndNotEmpty
                        (ErrSourceID errSrcID,
                         string      place,
                         string      point,
                         string      valueName,
                         string      value)
 {
  // [2021-11-30] Tested.

  Debug.Assert(!string.IsNullOrEmpty(place));
  Debug.Assert(!string.IsNullOrEmpty(point));
  Debug.Assert(!string.IsNullOrEmpty(valueName));

  BugCheck_Value_NotNull
   (errSrcID,
    place,
    point,
    valueName,
    value);

  if(value.Length==0)
  {
   ThrowBugCheck.value_is_empty
    (errSrcID,
     place,
     point,
     valueName);
  }//if

  Debug.Assert(!Object.ReferenceEquals(value,null));
  Debug.Assert(value.Length>0);
 }//BugCheck_Value_NotNullAndNotEmpty

 //-----------------------------------------------------------------------
 public static T BugCheck_Value_NotNullAndInstanceOf<T,T1>
                        (ErrSourceID errSrcID,
                         string      place,
                         string      point,
                         string      valueName,
                         T1          value)
                    where T:class, T1
                    where T1:class
 {
  // [2020-10-21] Tested.

  Debug.Assert(!string.IsNullOrEmpty(place));
  Debug.Assert(!string.IsNullOrEmpty(point));
  Debug.Assert(!string.IsNullOrEmpty(valueName));

  BugCheck_Value_NotNull
   (errSrcID,
    place,
    point,
    valueName,
    value);

  Debug.Assert(!Object.ReferenceEquals(value,null));

  var value_x=value as T;

  if(Object.ReferenceEquals(value_x,null))
  {
   ThrowBugCheck.bad_value_type
    (errSrcID,
     place,
     point,
     valueName,
     value.GetType(),
     typeof(T));
  }//if

  Debug.Assert(!Object.ReferenceEquals(value_x,null));

  return value_x;
 }//BugCheck_Value_NotNullAndInstanceOf

 //-----------------------------------------------------------------------
 public static void Annotation__SetupOnceNotNullBasedOn<T>
                        (ErrSourceID                              errSrcID,
                         Annotation                               annotation,
                         ref Structure.Structure_ValueWithNull<T> annotationValue)
 {
  Debug.Assert(!Object.ReferenceEquals(annotation,null));

  if(Object.ReferenceEquals(annotation.Value,null))
  {
   //ERROR - annotation contains null value.

   ThrowError.AnnotationHasNullValue
    (errSrcID,
     annotation.Name);
  }//if

  Debug.Assert(!Object.ReferenceEquals(annotation.Value,null));

  if(!typeof(T).IsAssignableFrom(annotation.Value.GetType()))
  {
   //ERROR - annotation contains value with unexpected type.

   ThrowError.AnnotationHasValueWithUnexpectedType
    (errSrcID,
     annotation.Name,
     /*actualType*/annotation.Value.GetType(),
     /*expectedType*/typeof(T));
  }//if

  T value_t=(T)annotation.Value;

  if(!annotationValue.IsNull)
  {
   //ERROR - multiple definition of annotation.

   ThrowError.MultipleDefinitionOfAnnotation
    (errSrcID,
     annotation.Name,
     /*prev*/annotationValue.Value,
     /*new*/value_t);
  }//if

  Debug.Assert(annotationValue.IsNull);

  annotationValue.SetValue(value_t);

  Debug.Assert(!annotationValue.IsNull);
 }//Annotation__SetupOnceNotNullBasedOn<T>
};//class Check

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb

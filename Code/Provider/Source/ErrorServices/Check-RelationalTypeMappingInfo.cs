////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 02.10.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_ADP
 =Structure.Structure_ADP;

////////////////////////////////////////////////////////////////////////////////
//class Check

static partial class Check
{
 public static void RelationalTypeMappingInfo__StoreTypeName
                        (ErrSourceID                  err_src,
                         in RelationalTypeMappingInfo mappingInfo,
                         string                       storeTypeName)
 {
  // [2020-10-14] Tested.

  //Debug.Assert(!Object.ReferenceEquals(mappingInfo,null));
  Debug.Assert(mappingInfo.GetType().IsValueType);
  Debug.Assert(!string.IsNullOrEmpty(storeTypeName));

  if(Object.ReferenceEquals(mappingInfo.StoreTypeName,null))
   return;

  Debug.Assert(!Object.ReferenceEquals(mappingInfo.StoreTypeName,null));

  if(Structure_ADP.EqualDatabaseTypeName(mappingInfo.StoreTypeName,storeTypeName))
   return;

  //ERROR - unexpected StoreTypeName

  ThrowError.TypeMappingErr__UnexpectedStoreTypeName
   (err_src,
    mappingInfo.StoreTypeNameBase,
    storeTypeName);

  Debug.Assert(false);
 }//RelationalTypeMappingInfo__StoreTypeName

 //-----------------------------------------------------------------------
 public static void RelationalTypeMappingInfo__StoreTypeNames
                        (ErrSourceID                  err_src,
                         in RelationalTypeMappingInfo mappingInfo,
                         params string[]              storeTypeNames)
 {
  // [2020-10-14] Tested.

  //Debug.Assert(!Object.ReferenceEquals(mappingInfo,null));
  Debug.Assert(mappingInfo.GetType().IsValueType);
  Debug.Assert(!string.ReferenceEquals(storeTypeNames,null));
  Debug.Assert(storeTypeNames.Length>0);

  if(Object.ReferenceEquals(mappingInfo.StoreTypeName,null))
   return;

  Debug.Assert(!Object.ReferenceEquals(mappingInfo.StoreTypeName,null));

  foreach(var storeTypeName in storeTypeNames)
  {
   Debug.Assert(!string.IsNullOrEmpty(storeTypeName));

   if(Structure_ADP.EqualDatabaseTypeName(mappingInfo.StoreTypeName,storeTypeName))
    return;
  }//foreach storeTypeName

  //ERROR - unexpected StoreTypeName

  ThrowError.TypeMappingErr__UnexpectedStoreTypeName
   (err_src,
    mappingInfo.StoreTypeNameBase,
    storeTypeNames[0]);

  Debug.Assert(false);
 }//RelationalTypeMappingInfo__StoreTypeNames

 //-----------------------------------------------------------------------
 public static void RelationalTypeMappingInfo__StoreTypeNameBase
                        (ErrSourceID                  err_src,
                         in RelationalTypeMappingInfo mappingInfo,
                         string                       storeTypeNameBase)
 {
  // [2020-10-14] Tested.

  //Debug.Assert(!Object.ReferenceEquals(mappingInfo,null));
  Debug.Assert(mappingInfo.GetType().IsValueType);
  Debug.Assert(!string.IsNullOrEmpty(storeTypeNameBase));

  if(Object.ReferenceEquals(mappingInfo.StoreTypeNameBase,null))
   return;

  Debug.Assert(!Object.ReferenceEquals(mappingInfo.StoreTypeNameBase,null));

  if(Structure_ADP.EqualDatabaseTypeName(mappingInfo.StoreTypeNameBase,storeTypeNameBase))
   return;

  //ERROR - unexpected StoreTypeNameBase

  ThrowError.TypeMappingErr__UnexpectedStoreTypeNameBase
   (err_src,
    mappingInfo.StoreTypeNameBase,
    storeTypeNameBase);

  Debug.Assert(false);
 }//RelationalTypeMappingInfo__StoreTypeNameBase

 //-----------------------------------------------------------------------
 public static void RelationalTypeMappingInfo__StoreTypeNameBases
                        (ErrSourceID                  err_src,
                         in RelationalTypeMappingInfo mappingInfo,
                         params string[]              storeTypeNameBases)
 {
  // [2020-10-14] Tested.

  //Debug.Assert(!Object.ReferenceEquals(mappingInfo,null));
  Debug.Assert(mappingInfo.GetType().IsValueType);
  Debug.Assert(!string.ReferenceEquals(storeTypeNameBases,null));
  Debug.Assert(storeTypeNameBases.Length>0);

  if(Object.ReferenceEquals(mappingInfo.StoreTypeName,null))
   return;

  Debug.Assert(!Object.ReferenceEquals(mappingInfo.StoreTypeNameBase,null));

  foreach(var storeTypeNameBase in storeTypeNameBases)
  {
   Debug.Assert(!string.IsNullOrEmpty(storeTypeNameBase));

   if(Structure_ADP.EqualDatabaseTypeName(mappingInfo.StoreTypeNameBase,storeTypeNameBase))
    return;
  }//foreach storeTypeNameBase

  //ERROR - unexpected StoreTypeNameBase

  ThrowError.TypeMappingErr__UnexpectedStoreTypeNameBase
   (err_src,
    mappingInfo.StoreTypeNameBase,
    storeTypeNameBases[0]);

  Debug.Assert(false);
 }//RelationalTypeMappingInfo__StoreTypeNameBases

 //-----------------------------------------------------------------------
 public static void RelationalTypeMappingInfo__SizeIsNull
                        (ErrSourceID                  err_src,
                         in RelationalTypeMappingInfo mappingInfo)
 {
  // [2020-10-14] Tested.

  //Debug.Assert(!Object.ReferenceEquals(mappingInfo,null));
  Debug.Assert(mappingInfo.GetType().IsValueType);

  if(!mappingInfo.Size.HasValue)
   return;

  Debug.Assert(mappingInfo.Size.HasValue);

  //ERROR - unexpected Size

  ThrowError.TypeMappingErr__UnexpectedSize
   (err_src,
    mappingInfo.Size.Value);

  Debug.Assert(false);
 }//RelationalTypeMappingInfo__SizeIsNull

 //-----------------------------------------------------------------------
 public static void RelationalTypeMappingInfo__SizeIsNullOrExpected
                        (ErrSourceID                  err_src,
                         in RelationalTypeMappingInfo mappingInfo,
                         int                          expectedLength)
 {
  // [2020-10-14] Tested.

  //Debug.Assert(!Object.ReferenceEquals(mappingInfo,null));
  Debug.Assert(mappingInfo.GetType().IsValueType);

  if(!mappingInfo.Size.HasValue)
   return;

  Debug.Assert(mappingInfo.Size.HasValue);

  if(mappingInfo.Size.Value!=expectedLength)
  {
   //ERROR - unexpected Size

   ThrowError.TypeMappingErr__UnexpectedSize
    (err_src,
     mappingInfo.Size.Value);

   Debug.Assert(false);
  }//if

  Debug.Assert(mappingInfo.Size.Value==expectedLength);
 }//RelationalTypeMappingInfo__SizeIsNullOrExpected

 //-----------------------------------------------------------------------
 public static void RelationalTypeMappingInfo__SizeIsPositive
                        (ErrSourceID                  err_src,
                         in RelationalTypeMappingInfo mappingInfo,
                         int                          maxLength)
 {
  // [2020-10-14] Tested.

  //Debug.Assert(!Object.ReferenceEquals(mappingInfo,null));
  Debug.Assert(mappingInfo.GetType().IsValueType);
  Debug.Assert(maxLength>0);

  if(!mappingInfo.Size.HasValue)
  {
   //ERROR - not defined Size

   ThrowError.TypeMappingErr__NotDefinedSize
    (err_src);
  }//if

  Debug.Assert(mappingInfo.Size.HasValue);

  if(mappingInfo.Size.Value<=0)
  {
   //ERROR - invalid Size

   ThrowError.TypeMappingErr__UnexpectedSize
    (err_src,
     mappingInfo.Size.Value);
  }//if

  Debug.Assert(mappingInfo.Size.Value>0);

  if(maxLength<mappingInfo.Size.Value)
  {
   //ERROR - too large Size

   ThrowError.TypeMappingErr__TooLargeSize
    (err_src,
     mappingInfo.Size.Value,
     maxLength);
  }//if

  Debug.Assert(mappingInfo.Size.Value<=maxLength);
 }//RelationalTypeMappingInfo__SizeIsPositive

 //-----------------------------------------------------------------------
 public static void RelationalTypeMappingInfo__IsFixedLength__optional
                        (ErrSourceID                  err_src,
                         in RelationalTypeMappingInfo mappingInfo,
                         bool                         isFixedLength)
 {
  //Debug.Assert(!Object.ReferenceEquals(mappingInfo,null));
  Debug.Assert(mappingInfo.GetType().IsValueType);

  if(!mappingInfo.IsFixedLength.HasValue)
   return;

  if(mappingInfo.IsFixedLength.Value==isFixedLength)
   return;

  ThrowError.TypeMappingErr__UnexpectedIsFixedLength
   (err_src,
    mappingInfo.IsFixedLength.Value,
    isFixedLength);

  Debug.Assert(false);
 }//RelationalTypeMappingInfo__IsFixedLength__optional

 //-----------------------------------------------------------------------
 public static void RelationalTypeMappingInfo__IsUnicode
                        (ErrSourceID                  err_src,
                         in RelationalTypeMappingInfo mappingInfo,
                         bool                         isUnicode)
 {
  // [2020-10-14] Tested.

  //Debug.Assert(!Object.ReferenceEquals(mappingInfo,null));
  Debug.Assert(mappingInfo.GetType().IsValueType);

  if(!mappingInfo.IsUnicode.HasValue)
   return;

  if(mappingInfo.IsUnicode.Value==isUnicode)
   return;

  ThrowError.TypeMappingErr__UnexpectedIsUnicode
   (err_src,
    mappingInfo.IsUnicode.Value,
    isUnicode);

  Debug.Assert(false);
 }//RelationalTypeMappingInfo__IsUnicode

 //-----------------------------------------------------------------------
 public static void RelationalTypeMappingInfo__Precision_and_Scale__optional
                        (ErrSourceID                  errSrcID,
                         in RelationalTypeMappingInfo mappingInfo,
                         int                          maxPrecision)
 {
  if(!mappingInfo.Precision.HasValue)
  {
   if(mappingInfo.Scale.HasValue)
   {
    ThrowError.TypeMappingErr__NotAllowedDefinitionOfScaleWithoutPrecision
     (errSrcID,
      mappingInfo.Scale.Value);
   }

   Debug.Assert(!mappingInfo.Scale.HasValue);
  }
  else
  {
   Debug.Assert(mappingInfo.Precision.HasValue);

   Check.RelationalTypeMappingInfo__Precision
    (errSrcID,
     mappingInfo,
     maxPrecision);

   Check.RelationalTypeMappingInfo__Scale__optional
    (errSrcID,
     mappingInfo);
  }//else
 }//RelationalTypeMappingInfo__Precision_and_Scale__optional

 //-----------------------------------------------------------------------
 public static void RelationalTypeMappingInfo__PrecisionIsNull
                        (ErrSourceID                  err_src,
                         in RelationalTypeMappingInfo mappingInfo)
 {
  // [2020-10-14] Tested.

  //Debug.Assert(!Object.ReferenceEquals(mappingInfo,null));
  Debug.Assert(mappingInfo.GetType().IsValueType);

  if(!mappingInfo.Precision.HasValue)
   return;

  Debug.Assert(mappingInfo.Precision.HasValue);

  //ERROR - unexpected Precision

  ThrowError.TypeMappingErr__UnexpectedPrecision
   (err_src,
    mappingInfo.Precision.Value);

  Debug.Assert(false);
 }//RelationalTypeMappingInfo__PrecisionIsNull

 //-----------------------------------------------------------------------
 public static void RelationalTypeMappingInfo__PrecisionExactOrNull
                        (ErrSourceID                  err_src,
                         in RelationalTypeMappingInfo mappingInfo,
                         int                          expectedPrecision)
 {
  //Debug.Assert(!Object.ReferenceEquals(mappingInfo,null));
  Debug.Assert(mappingInfo.GetType().IsValueType);
  Debug.Assert(expectedPrecision>0);

  if(!mappingInfo.Precision.HasValue)
  {
   return;
  }//if

  Debug.Assert(mappingInfo.Precision.HasValue);

  if(mappingInfo.Precision.Value!=expectedPrecision)
  {
   //ERROR - invalid precision

   ThrowError.TypeMappingErr__UnexpectedPrecision
    (err_src,
     mappingInfo.Precision.Value);
  }//if

  Debug.Assert(mappingInfo.Precision.Value==expectedPrecision);
 }//RelationalTypeMappingInfo__PrecisionExactOrNull

 //-----------------------------------------------------------------------
 public static void RelationalTypeMappingInfo__Precision
                        (ErrSourceID                  err_src,
                         in RelationalTypeMappingInfo mappingInfo,
                         int                          maxPrecision)
 {
  // [2020-10-14] Tested.

  //Debug.Assert(!Object.ReferenceEquals(mappingInfo,null));
  Debug.Assert(mappingInfo.GetType().IsValueType);
  Debug.Assert(maxPrecision>0);

  if(!mappingInfo.Precision.HasValue)
  {
   //ERROR - no precision

   ThrowError.TypeMappingErr__NotDefinedPrecision
    (err_src);
  }//if

  Debug.Assert(mappingInfo.Precision.HasValue);

  if(mappingInfo.Precision.Value<=0)
  {
   //ERROR - invalid precision

   ThrowError.TypeMappingErr__UnexpectedPrecision
    (err_src,
     mappingInfo.Precision.Value);
  }//if

  Debug.Assert(mappingInfo.Precision.Value>0);

  if(maxPrecision<mappingInfo.Precision.Value)
  {
   //ERROR - too large precision

   ThrowError.TypeMappingErr__TooLargePrecision
    (err_src,
     mappingInfo.Precision.Value,
     maxPrecision);
  }//if

  Debug.Assert(mappingInfo.Precision.Value<=maxPrecision);
 }//RelationalTypeMappingInfo__Precision

 //-----------------------------------------------------------------------
 public static void RelationalTypeMappingInfo__ScaleIsNull
                        (ErrSourceID                  err_src,
                         in RelationalTypeMappingInfo mappingInfo)
 {
  // [2020-10-14] Tested.

  //Debug.Assert(!Object.ReferenceEquals(mappingInfo,null));
  Debug.Assert(mappingInfo.GetType().IsValueType);

  if(!mappingInfo.Scale.HasValue)
   return;

  Debug.Assert(mappingInfo.Scale.HasValue);

  //ERROR - unexpected Scale

  ThrowError.TypeMappingErr__UnexpectedScale
   (err_src,
    mappingInfo.Scale.Value);

  Debug.Assert(false);
 }//RelationalTypeMappingInfo__ScaleIsNull

 //-----------------------------------------------------------------------
 public static void RelationalTypeMappingInfo__ScaleExactOrNull
                        (ErrSourceID                  err_src,
                         in RelationalTypeMappingInfo mappingInfo,
                         int                          expectedScale)
 {
  //Debug.Assert(!Object.ReferenceEquals(mappingInfo,null));
  Debug.Assert(mappingInfo.GetType().IsValueType);

  Debug.Assert(expectedScale>=0);

  if(!mappingInfo.Scale.HasValue)
  {
   return;
  }//if

  Debug.Assert(mappingInfo.Scale.HasValue);

  if(!mappingInfo.Precision.HasValue)
  {
   ThrowError.TypeMappingErr__NotAllowedDefinitionOfScaleWithoutPrecision
    (err_src,
     mappingInfo.Scale.Value);
  }//if

  Debug.Assert(mappingInfo.Precision.HasValue);
  Debug.Assert(mappingInfo.Precision.Value>0);

  if(mappingInfo.Scale.Value!=expectedScale)
  {
   //ERROR - invalid scale

   ThrowError.TypeMappingErr__UnexpectedScale
    (err_src,
     mappingInfo.Scale.Value);
  }//if

  Debug.Assert(mappingInfo.Scale.Value==expectedScale);

  Debug.Assert(mappingInfo.Scale.Value<=mappingInfo.Precision.Value);
 }//RelationalTypeMappingInfo__ScaleExactOrNull

 //-----------------------------------------------------------------------
 public static void RelationalTypeMappingInfo__Scale
                        (ErrSourceID                  err_src,
                         in RelationalTypeMappingInfo mappingInfo)
 {
  // [2020-10-14] Tested.

  //Debug.Assert(!Object.ReferenceEquals(mappingInfo,null));
  Debug.Assert(mappingInfo.GetType().IsValueType);
  Debug.Assert(mappingInfo.Precision.HasValue);
  Debug.Assert(mappingInfo.Precision.Value>0);

  if(!mappingInfo.Scale.HasValue)
  {
   //ERROR - no scale

   ThrowError.TypeMappingErr__NotDefinedScale
    (err_src);
  }//if

  Debug.Assert(mappingInfo.Scale.HasValue);

  if(mappingInfo.Scale.Value<0)
  {
   //ERROR - invalid scale

   ThrowError.TypeMappingErr__UnexpectedScale
    (err_src,
     mappingInfo.Scale.Value);
  }//if

  Debug.Assert(mappingInfo.Scale.Value>=0);

  if(mappingInfo.Precision.Value<mappingInfo.Scale.Value)
  {
   //ERROR - too large scale

   ThrowError.TypeMappingErr__TooLargeScale
    (err_src,
     mappingInfo.Scale.Value,
     mappingInfo.Precision.Value);

   Debug.Assert(false);
  }//if

  Debug.Assert(mappingInfo.Scale.Value<=mappingInfo.Precision.Value);
 }//RelationalTypeMappingInfo__Scale

 //-----------------------------------------------------------------------
 public static void RelationalTypeMappingInfo__Scale__optional
                        (ErrSourceID                  err_src,
                         in RelationalTypeMappingInfo mappingInfo)
 {
  // [2020-10-14] Tested.

  //Debug.Assert(!Object.ReferenceEquals(mappingInfo,null));
  Debug.Assert(mappingInfo.GetType().IsValueType);
  Debug.Assert(mappingInfo.Precision.HasValue);
  Debug.Assert(mappingInfo.Precision.Value>0);

  if(!mappingInfo.Scale.HasValue)
  {
   //No scale. OK

   return;
  }//if

  Debug.Assert(mappingInfo.Scale.HasValue);

  if(mappingInfo.Scale.Value<0)
  {
   //ERROR - invalid scale

   ThrowError.TypeMappingErr__UnexpectedScale
    (err_src,
     mappingInfo.Scale.Value);
  }//if

  Debug.Assert(mappingInfo.Scale.Value>=0);

  if(mappingInfo.Precision.Value<mappingInfo.Scale.Value)
  {
   //ERROR - too large scale

   ThrowError.TypeMappingErr__TooLargeScale
    (err_src,
     mappingInfo.Scale.Value,
     mappingInfo.Precision.Value);

   Debug.Assert(false);
  }//if

  Debug.Assert(mappingInfo.Scale.Value<=mappingInfo.Precision.Value);
 }//RelationalTypeMappingInfo__Scale__optional

 //-----------------------------------------------------------------------
 public static void RelationalTypeMappingInfo__IsRowVersion
                        (ErrSourceID                  err_src,
                         in RelationalTypeMappingInfo mappingInfo,
                         bool                         IsRowVersion)
 {
  // [2020-10-14] Tested.

  //Debug.Assert(!Object.ReferenceEquals(mappingInfo,null));
  Debug.Assert(mappingInfo.GetType().IsValueType);

  if(!mappingInfo.IsRowVersion.HasValue)
   return;

  Debug.Assert(mappingInfo.IsRowVersion.HasValue);

  if(mappingInfo.IsRowVersion.Value==IsRowVersion)
   return;

  Debug.Assert(mappingInfo.IsRowVersion.Value!=IsRowVersion);

  //ERROR - unexpected value

  ThrowError.TypeMappingErr__UnexpectedIsRowVersion
   (err_src,
    mappingInfo.IsRowVersion.Value,
    IsRowVersion);

  Debug.Assert(false);
 }//RelationalTypeMappingInfo__IsRowVersion

 //-----------------------------------------------------------------------
 public static void RelationalTypeMappingInfo__ClrType
                        (ErrSourceID                  err_src,
                         in RelationalTypeMappingInfo mappingInfo,
                         Type                         clrType)
 {
  // [2020-10-14] Tested.

  //Debug.Assert(!Object.ReferenceEquals(mappingInfo,null));
  Debug.Assert(mappingInfo.GetType().IsValueType);
  Debug.Assert(!Object.ReferenceEquals(clrType,null));

  if(Object.ReferenceEquals(mappingInfo.ClrType,null))
   return;

  if(mappingInfo.ClrType==clrType)
   return;

  Debug.Assert(mappingInfo.ClrType!=clrType);

  //ERROR - unexpected ClrType
  ThrowError.TypeMappingErr__UnexpectedClrType
   (err_src,
    mappingInfo.ClrType,
    clrType);

  Debug.Assert(false);
 }//RelationalTypeMappingInfo__ClrType
};//class Check

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb

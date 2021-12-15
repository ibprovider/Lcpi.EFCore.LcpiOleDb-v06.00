////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 01.10.2021.
using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Storage.Mapping{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__TypeMapping

abstract partial class LcpiOleDb__TypeMapping:RelationalTypeMapping
{
 protected static class HelperCheck
 {
  public static void RelationalTypeMappingParameters__Precision_and_Scale__optional
                         (ErrSourceID                        errSrcID,
                          in RelationalTypeMappingParameters mappingParams,
                          int                                maxPrecision)
  {
   if(!mappingParams.Precision.HasValue)
   {
    if(mappingParams.Scale.HasValue)
    {
     ThrowError.TypeMappingErr__NotAllowedDefinitionOfScaleWithoutPrecision
      (errSrcID,
       mappingParams.Scale.Value);
    }

    Debug.Assert(!mappingParams.Scale.HasValue);
   }
   else
   {
    Debug.Assert(mappingParams.Precision.HasValue);

    HelperCheck.RelationalTypeMappingParameters__Precision
     (errSrcID,
      mappingParams,
      maxPrecision);

    HelperCheck.RelationalTypeMappingParameters__Scale__optional
     (errSrcID,
      mappingParams);
   }//else
  }//RelationalTypeMappingParameters__Precision_and_Scale__optional

  //-----------------------------------------------------------------------
  public static void RelationalTypeMappingParameters__Precision
                         (ErrSourceID                        errSrcID,
                          in RelationalTypeMappingParameters mappingParams,
                          int                                maxPrecision)
  {
   //Debug.Assert(!Object.ReferenceEquals(mappingInfo,null));
   Debug.Assert(mappingParams.GetType().IsValueType);
   Debug.Assert(maxPrecision>0);

   if(!mappingParams.Precision.HasValue)
   {
    //ERROR - no precision

    ThrowError.TypeMappingErr__NotDefinedPrecision
     (errSrcID);
   }//if

   Debug.Assert(mappingParams.Precision.HasValue);

   if(mappingParams.Precision.Value<=0)
   {
    //ERROR - invalid precision

    ThrowError.TypeMappingErr__UnexpectedPrecision
     (errSrcID,
      mappingParams.Precision.Value);
   }//if

   Debug.Assert(mappingParams.Precision.Value>0);

   if(maxPrecision<mappingParams.Precision.Value)
   {
    //ERROR - too large precision

    ThrowError.TypeMappingErr__TooLargePrecision
     (errSrcID,
      mappingParams.Precision.Value,
      maxPrecision);
   }//if

   Debug.Assert(mappingParams.Precision.Value<=maxPrecision);
  }//RelationalTypeMappingParameters__Precision

  //-----------------------------------------------------------------------
  public static void RelationalTypeMappingParameters__Scale__optional
                         (ErrSourceID                        errSrcID,
                          in RelationalTypeMappingParameters mappingParams)
  {
   //Debug.Assert(!Object.ReferenceEquals(mappingInfo,null));
   Debug.Assert(mappingParams.GetType().IsValueType);
   Debug.Assert(mappingParams.Precision.HasValue);
   Debug.Assert(mappingParams.Precision.Value>0);

   if(!mappingParams.Scale.HasValue)
   {
    //No scale. OK

    return;
   }//if

   Debug.Assert(mappingParams.Scale.HasValue);

   if(mappingParams.Scale.Value<0)
   {
    //ERROR - invalid scale

    ThrowError.TypeMappingErr__UnexpectedScale
     (errSrcID,
      mappingParams.Scale.Value);
   }//if

   Debug.Assert(mappingParams.Scale.Value>=0);

   if(mappingParams.Precision.Value<mappingParams.Scale.Value)
   {
    //ERROR - too large scale

    ThrowError.TypeMappingErr__TooLargeScale
     (errSrcID,
      mappingParams.Scale.Value,
      mappingParams.Precision.Value);

    Debug.Assert(false);
   }//if

   Debug.Assert(mappingParams.Scale.Value<=mappingParams.Precision.Value);
  }//RelationalTypeMappingParameters__Scale__optional
 };//class HelperCheck
};//class LcpiOleDb__TypeMapping

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Storage.Mapping

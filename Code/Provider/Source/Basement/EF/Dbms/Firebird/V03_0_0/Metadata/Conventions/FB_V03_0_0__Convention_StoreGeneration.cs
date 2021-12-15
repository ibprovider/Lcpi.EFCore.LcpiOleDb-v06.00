////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 17.11.2021.
using System;
using System.Diagnostics;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Metadata.Conventions{
////////////////////////////////////////////////////////////////////////////////

using LcpiOleDb__AnnotationNames
 =DataProvider.LcpiOleDb.MetaData.Internal.LcpiOleDb__AnnotationNames;

using LcpiOleDb__ValueGenerationStrategy
 =DataProvider.LcpiOleDb.MetaData.LcpiOleDb__ValueGenerationStrategy;

////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0__Convention_StoreGeneration

sealed class FB_V03_0_0__Convention_StoreGeneration
 :StoreGenerationConvention
 ,IModelAnnotationChangedConvention
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Basement_EF_Dbms_Firebird_V03_0_0_Metadata_Conventions___FB_V03_0_0__Convention_StoreGeneration;

 //-----------------------------------------------------------------------
 public FB_V03_0_0__Convention_StoreGeneration
                            (ProviderConventionSetBuilderDependencies   dependencies,
                             RelationalConventionSetBuilderDependencies relationalDependencies)
  :base(dependencies,relationalDependencies)
 {
 }//FB_V03_0_0__Convention_StoreGeneration

 //StoreGenerationConvention interface -----------------------------------
 public override void ProcessPropertyAnnotationChanged
                            (IConventionPropertyBuilder                propertyBuilder,
                             string                                    name,
                             IConventionAnnotation                     annotation,
                             IConventionAnnotation                     oldAnnotation,
                             IConventionContext<IConventionAnnotation> context)
 {
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(ProcessPropertyAnnotationChanged),
    nameof(propertyBuilder),
    propertyBuilder);

  Check.Arg_NotNullAndNotEmpty
   (c_ErrSrcID,
    nameof(ProcessPropertyAnnotationChanged),
    nameof(name),
    name);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(ProcessPropertyAnnotationChanged),
    nameof(context),
    context);

  //-----------------------------------------------------------------
  if(Object.ReferenceEquals(annotation,null))
  {
   return;
  }//if

  if(!Object.ReferenceEquals(oldAnnotation,null))
  {
   if(!Object.ReferenceEquals(oldAnnotation.Value,null))
    return;
  }//if

  //-----------------------------------------------------------------
  var configurationSource
   =annotation.GetConfigurationSource();

  var fromDataAnnotation
   =(configurationSource!=ConfigurationSource.Convention);

  //-----------------------------------------------------------------
  switch(name)
  {
   case RelationalAnnotationNames.DefaultValue:
   {
    if(propertyBuilder.HasValueGenerationStrategy(null,fromDataAnnotation) == null
       && propertyBuilder.HasDefaultValue(null,fromDataAnnotation) != null)
    {
     context.StopProcessing();
     return;
    }

    break;
   }//DefaultValue

   case RelationalAnnotationNames.DefaultValueSql:
   {
    if(propertyBuilder.HasValueGenerationStrategy(null,fromDataAnnotation) == null
       && propertyBuilder.HasDefaultValueSql(null,fromDataAnnotation) != null)
    {
     context.StopProcessing();
     return;
    }

    break;
   }//DefaultValueSql

   case RelationalAnnotationNames.ComputedColumnSql:
   {
    if(propertyBuilder.HasValueGenerationStrategy(null,fromDataAnnotation) == null
       && propertyBuilder.HasComputedColumnSql(null,fromDataAnnotation) != null)
    {
     context.StopProcessing();
     return;
    }

    break;
   }//ComputedColumnSql

   case LcpiOleDb__AnnotationNames.ValueGenerationStrategy:
   {
    if((propertyBuilder.HasDefaultValue(null,fromDataAnnotation) == null
        | propertyBuilder.HasDefaultValueSql(null,fromDataAnnotation) == null
        | propertyBuilder.HasComputedColumnSql(null,fromDataAnnotation) == null)
       && propertyBuilder.HasValueGenerationStrategy(null,fromDataAnnotation) != null)
    {
     context.StopProcessing();
     return;
    }

    break;
   }//ValueGenerationStrategy
  }//switch name

  base.ProcessPropertyAnnotationChanged
   (propertyBuilder,
    name,
    annotation,
    oldAnnotation,
    context);
 }//ProcessPropertyAnnotationChanged

 //-----------------------------------------------------------------------
 protected override void Validate(IConventionProperty      property,
                                  in StoreObjectIdentifier storeObject)
 {
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Validate),
    nameof(property),
    property);

  //-----------------------------------------------------------------
  Helper__Validate__VGS
   (property,
    storeObject);

  base.Validate
   (property,
    storeObject);
 }//Validate

 //IModelAnnotationChangedConvention -------------------------------------
 public void ProcessModelAnnotationChanged
                            (IConventionModelBuilder                   modelBuilder,
                             string                                    name,
                             IConventionAnnotation                     annotation,
                             IConventionAnnotation                     oldAnnotation,
                             IConventionContext<IConventionAnnotation> context)
 {
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(ProcessModelAnnotationChanged),
    nameof(modelBuilder),
    modelBuilder);

  Check.Arg_NotNullAndNotEmpty
   (c_ErrSrcID,
    nameof(ProcessModelAnnotationChanged),
    nameof(name),
    name);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(ProcessModelAnnotationChanged),
    nameof(context),
    context);

  //-----------------------------------------------------------------
  if(Object.ReferenceEquals(annotation,null))
  {
   return;
  }//if

  //-----------------------------------------------------------------
  if(name==LcpiOleDb__AnnotationNames.ValueGenerationStrategy)
  {
   //Verification of new global value generation strategy
   
   var modelVGS
    =modelBuilder.Metadata.GetValueGenerationStrategyOrNull();

   modelBuilder.Metadata.Internal__CheckValueGenerationStrategy
    (modelVGS); //throw

   return;
  }//if name==VGS
 }//ProcessModelAnnotationChanged

 //Helper methods --------------------------------------------------------
 private void Helper__Validate__VGS(IConventionProperty      property,
                                    in StoreObjectIdentifier storeObject)
 {
  Debug.Assert(!Object.ReferenceEquals(property,null));

  if(property.GetValueGenerationStrategyConfigurationSource()==null)
   return;

  var generationStrategy
   =property.Internal__SelectValueGenerationStrategy
     (storeObject,
      Dependencies.TypeMappingSource);

  if(Object.ReferenceEquals(generationStrategy,null))
   return;

  if(generationStrategy==LcpiOleDb__ValueGenerationStrategy.None)
   return;

  Debug.Assert(!generationStrategy.Equals(LcpiOleDb__ValueGenerationStrategy.None));

  List<Core.Core_ExceptionRecord>
   errRecords
    =null;

  if(property.TryGetDefaultValue(storeObject,out _))
  {
   ErrorUtils.Add
    (ref errRecords,
     ErrorRecordCreator.CommonErr__EntityPropertyHasConflictOfValueGenerationStrategies
      (c_ErrSrcID,
       property,
       generationStrategy.Internal__GetStrategyName(),
       "DefaultValue"));
  }//if

  if(property.GetDefaultValueSql(storeObject)!=null)
  {
   ErrorUtils.Add
    (ref errRecords,
     ErrorRecordCreator.CommonErr__EntityPropertyHasConflictOfValueGenerationStrategies
      (c_ErrSrcID,
       property,
       generationStrategy.Internal__GetStrategyName(),
       "DefaultValueSql"));
  }//if

  if(property.GetComputedColumnSql(storeObject)!=null)
  {
   ErrorUtils.Add
    (ref errRecords,
     ErrorRecordCreator.CommonErr__EntityPropertyHasConflictOfValueGenerationStrategies
      (c_ErrSrcID,
       property,
       generationStrategy.Internal__GetStrategyName(),
       "ComputedColumnSql"));
  }//if

  ErrorUtils.ThrowIfNotEmpty
   (errRecords);
 }//Helper__Validate__VGS
};//class FB_V03_0_0__Convention_StoreGeneration

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Metadata.Conventions

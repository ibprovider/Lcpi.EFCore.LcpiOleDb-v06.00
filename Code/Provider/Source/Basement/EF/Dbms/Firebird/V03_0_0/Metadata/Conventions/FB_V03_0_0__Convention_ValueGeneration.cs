////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 18.11.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Metadata.Conventions{
////////////////////////////////////////////////////////////////////////////////

using LcpiOleDb__AnnotationNames
 =DataProvider.LcpiOleDb.MetaData.Internal.LcpiOleDb__AnnotationNames;

using LcpiOleDb__ValueGenerationStrategy
 =DataProvider.LcpiOleDb.MetaData.LcpiOleDb__ValueGenerationStrategy;

////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0__Convention_ValueGeneration

sealed class FB_V03_0_0__Convention_ValueGeneration
 :RelationalValueGenerationConvention
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Basement_EF_Dbms_Firebird_V03_0_0_Metadata_Conventions___FB_V03_0_0__Convention_ValueGeneration;

 //-----------------------------------------------------------------------
 public FB_V03_0_0__Convention_ValueGeneration
         (ProviderConventionSetBuilderDependencies   dependencies,
          RelationalConventionSetBuilderDependencies relationalDependencies)
  :base(dependencies,relationalDependencies)
 {
 }//FB_V03_0_0__Convention_ValueGeneration

 //RelationalValueGenerationConvention interface -------------------------
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
  if(name==LcpiOleDb__AnnotationNames.ValueGenerationStrategy)
  {
   //
   // [2021-11-18]
   //
   //propertyBuilder.ValueGenerated(GetValueGenerated(propertyBuilder.Metadata));

   return;
  }//if ValueGenerationStrategy

  base.ProcessPropertyAnnotationChanged
   (propertyBuilder,
    name,
    annotation,
    oldAnnotation,
    context);
 }//ProcessPropertyAnnotationChanged

 //-----------------------------------------------------------------------
 protected override Nullable<ValueGenerated> GetValueGenerated(IConventionProperty property)
 {
  const string c_method_sign
   =nameof(GetValueGenerated)+"(property)";

  //-----------------------------------------------------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    c_method_sign,
    nameof(property),
    property);

  Check.Arg_NotNull
   (c_ErrSrcID,
    c_method_sign,
    nameof(property)+".DeclaringEntityType",
    property.DeclaringEntityType);

  //-----------------------------------------------------------------
  StoreObjectIdentifier storeObject;

  if(!LcpiOleDb__Common__StoreObjectIdentifierHelper.TryBuildEntityStoreIdThatCompatibleWithValueGenerationStrategy
                            (property.DeclaringEntityType,
                             out storeObject))
  {
   return null;
  }//if

  return Helper__GetValueGenerated
   (property,
    storeObject,
    this.Dependencies.TypeMappingSource);
 }//GetValueGenerated

 //Helper methods --------------------------------------------------------
 private static Nullable<ValueGenerated> Helper__GetValueGenerated
                            (IReadOnlyProperty        property,
                             in StoreObjectIdentifier storeObject,
                             ITypeMappingSource       typeMappingSource)
 {
  var baseResult
   =RelationalValueGenerationConvention.GetValueGenerated(property, storeObject);

  if(baseResult.HasValue)
   return baseResult.Value;

  var vgs
   =property.Internal__SelectValueGenerationStrategy
     (storeObject,
      typeMappingSource);

  if(Object.ReferenceEquals(vgs,null))
   return null;

  if(vgs==LcpiOleDb__ValueGenerationStrategy.None)
   return null;

  return ValueGenerated.OnAdd;
 }//Helper__GetValueGenerated
};//class FB_V03_0_0__Convention_ValueGeneration

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Metadata.Conventions

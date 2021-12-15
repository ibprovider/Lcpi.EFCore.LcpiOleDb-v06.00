////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 12.11.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

using xEFCore
 =Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace Microsoft.EntityFrameworkCore{
////////////////////////////////////////////////////////////////////////////////

using xEFCore;

using LcpiOleDb__AnnotationNames
 =xEFCore.MetaData.Internal.LcpiOleDb__AnnotationNames;

using LcpiOleDb__ValueGenerationStrategy
 =xEFCore.MetaData.LcpiOleDb__ValueGenerationStrategy;

using LcpiOleDb__AnnotationData__ValueGenerationStrategy
 =xEFCore.MetaData.LcpiOleDb__AnnotationData__ValueGenerationStrategy;

////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__Extensions__PropertyBuilder

public static partial class LcpiOleDb__Extensions__PropertyBuilder
{
 public static IConventionPropertyBuilder HasValueGenerationStrategy
    (this IConventionPropertyBuilder                    propertyBuilder,
     LcpiOleDb__AnnotationData__ValueGenerationStrategy valueGenerationStrategy,
     bool                                               fromDataAnnotation=false)
 {
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(HasValueGenerationStrategy),
    nameof(propertyBuilder),
    propertyBuilder);

  if(!propertyBuilder.CanSetAnnotation
                            (LcpiOleDb__AnnotationNames.ValueGenerationStrategy,
                             valueGenerationStrategy,
                             fromDataAnnotation))
  {
   return null;
  }//if

  propertyBuilder.Metadata.SetValueGenerationStrategy
   (valueGenerationStrategy,
    fromDataAnnotation);

  return propertyBuilder;
 }//HasValueGenerationStrategy

 //-----------------------------------------------------------------------
 public static T_PROP_BUILDER UseIdentityByDefault<T_PROP_BUILDER>
                                           (this T_PROP_BUILDER propertyBuilder)
  where T_PROP_BUILDER:PropertyBuilder
 {
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(UseIdentityByDefault),
    nameof(propertyBuilder),
    propertyBuilder);

  Debug.Assert(!Object.ReferenceEquals(propertyBuilder.Metadata,null));

  propertyBuilder.Metadata.SetValueGenerationStrategy
   (LcpiOleDb__ValueGenerationStrategy.IdentityByDefaultColumn);

  return propertyBuilder;
 }//UseIdentityByDefault<T_PROP_BUILDER>

 //-----------------------------------------------------------------------
 public static T_PROP_BUILDER UseSequenceTrigger<T_PROP_BUILDER>
                                           (this T_PROP_BUILDER propertyBuilder,
                                            string              triggerName,
                                            string              sequenceName)
  where T_PROP_BUILDER:PropertyBuilder
 {
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(UseSequenceTrigger),
    nameof(propertyBuilder),
    propertyBuilder);

  Check.Arg_NotNullAndNotEmpty
   (c_ErrSrcID,
    nameof(UseSequenceTrigger),
    nameof(triggerName),
    triggerName);

  Check.Arg_NotNullAndNotEmpty
   (c_ErrSrcID,
    nameof(UseSequenceTrigger),
    nameof(sequenceName),
    sequenceName);

  Debug.Assert(!Object.ReferenceEquals(propertyBuilder.Metadata,null));

  propertyBuilder.Metadata.SetValueGenerationStrategy
   (LcpiOleDb__ValueGenerationStrategy.SequenceTrigger
     (triggerName,
      sequenceName));

  return propertyBuilder;
 }//UseSequenceTrigger<T_PROP_BUILDER>
};//class LcpiOleDb__Extensions__PropertyBuilder

////////////////////////////////////////////////////////////////////////////////
}//namespace Microsoft.EntityFrameworkCore

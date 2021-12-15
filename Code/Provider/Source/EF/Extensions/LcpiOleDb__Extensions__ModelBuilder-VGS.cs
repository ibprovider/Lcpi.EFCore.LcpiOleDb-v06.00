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

using LcpiOleDb__AnnotationNames
 =xEFCore.MetaData.Internal.LcpiOleDb__AnnotationNames;

using LcpiOleDb__AnnotationData__VGS
 =xEFCore.MetaData.LcpiOleDb__AnnotationData__ValueGenerationStrategy;

////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__Extensions__ModelBuilder

public static partial class LcpiOleDb__Extensions__ModelBuilder
{
 public static IConventionModelBuilder HasValueGenerationStrategy
                            (this IConventionModelBuilder   modelBuilder,
                             LcpiOleDb__AnnotationData__VGS valueGenerationStrategy,
                             bool                           fromDataAnnotation=false)
 {
  xEFCore.Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(HasValueGenerationStrategy),
    nameof(modelBuilder),
    modelBuilder);

  if(!modelBuilder.CanSetAnnotation(LcpiOleDb__AnnotationNames.ValueGenerationStrategy,
                                    valueGenerationStrategy,
                                    fromDataAnnotation))
  {
   return null;
  }//if

  modelBuilder.Metadata.SetValueGenerationStrategy
   (valueGenerationStrategy,
    fromDataAnnotation);

  return modelBuilder;
 }//HasValueGenerationStrategy

 //-----------------------------------------------------------------------
 public static ModelBuilder UseIdentityByDefault
                            (this ModelBuilder modelBuilder)
 {
  xEFCore.Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(UseIdentityByDefault),
    nameof(modelBuilder),
    modelBuilder);

  Debug.Assert(!Object.ReferenceEquals(modelBuilder.Model,null));

  modelBuilder.Model.SetValueGenerationStrategy
   (xEFCore.MetaData.LcpiOleDb__ValueGenerationStrategy.IdentityByDefaultColumn);

  return modelBuilder;
 }//UseIdentityByDefault
};//class LcpiOleDb__Extensions__ModelBuilder

////////////////////////////////////////////////////////////////////////////////
}//namespace Microsoft.EntityFrameworkCore

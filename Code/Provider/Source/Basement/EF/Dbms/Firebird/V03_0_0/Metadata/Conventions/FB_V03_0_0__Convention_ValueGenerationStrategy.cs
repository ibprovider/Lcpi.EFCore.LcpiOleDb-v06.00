////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 12.11.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Metadata.Conventions{
////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0__Convention_ValueGenerationStrategy

sealed class FB_V03_0_0__Convention_ValueGenerationStrategy
 :IModelInitializedConvention
 ,IModelFinalizingConvention
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Basement_EF_Dbms_Firebird_V03_0_0_Metadata_Conventions___FB_V03_0_0__Convention_ValueGenerationStrategy;

 //-----------------------------------------------------------------------
 public FB_V03_0_0__Convention_ValueGenerationStrategy
                            (ProviderConventionSetBuilderDependencies dependencies)
 {
  m_Dependencies=dependencies;
 }//FB_V03_0_0__Convention_ValueGenerationStrategy

 //IModelInitializedConvention interface ---------------------------------
 public void ProcessModelInitialized
                            (IConventionModelBuilder                     modelBuilder,
                             IConventionContext<IConventionModelBuilder> context)
 {
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(ProcessModelInitialized),
    nameof(modelBuilder),
    modelBuilder);

  //
  // [2021-11-17]
  //  Do not set default VGS. Please setup it by explicit.
  //
  // modelBuilder.HasValueGenerationStrategy
  //  (DataProvider.LcpiOleDb.MetaData.LcpiOleDb__ValueGenerationStrategy.IdentityByDefaultColumn);
 }//ProcessModelInitialized

 //IModelFinalizingConvention interface ---------------------------------
 public void ProcessModelFinalizing
                            (IConventionModelBuilder                     modelBuilder,
                             IConventionContext<IConventionModelBuilder> context)
 {
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(ProcessModelFinalizing),
    nameof(modelBuilder),
    modelBuilder);

  foreach(var entityType in modelBuilder.Metadata.GetEntityTypes())
  {
   Debug.Assert(!Object.ReferenceEquals(entityType,null));

   StoreObjectIdentifier storeObject;

   if(!LcpiOleDb__Common__StoreObjectIdentifierHelper.TryBuildEntityStoreIdThatCompatibleWithValueGenerationStrategy
                            (entityType,
                             out storeObject))
   {
    continue;
   }

#if DEBUG
   switch(storeObject.StoreObjectType)
   {
    case StoreObjectType.Table:
    case StoreObjectType.View:
     break;

    default:
     Debug.Assert(false);
     break;
   }//switch storeObject.StoreObjectType
#endif

   Helper__ProcessModelFinalizing__TableOrView
    (entityType,
     storeObject);

   break;
  }//for entityType
 }//ProcessModelFinalizing

 //Helper methods --------------------------------------------------------
 private bool Helper__TryGetTableName(IConventionEntityType entityType,out string name)
 {
  name=entityType.GetTableName();

  return !Object.ReferenceEquals(name,null);
 }//Helper__TryGetTableName

 //-----------------------------------------------------------------------
 private void Helper__ProcessModelFinalizing__TableOrView
                            (IConventionEntityType entityType,
                             StoreObjectIdentifier storeObject)
 {
  Debug.Assert(!Object.ReferenceEquals(entityType,null));
  Debug.Assert(!Object.ReferenceEquals(storeObject.Name,null));

  foreach(var property in entityType.GetDeclaredProperties())
  {
   Debug.Assert(!Object.ReferenceEquals(property,null));

   var strategy
    =property.Internal__SelectValueGenerationStrategy
      (storeObject,
       m_Dependencies.TypeMappingSource);

   if(Object.ReferenceEquals(strategy,null))
    continue;

   property.Builder.HasValueGenerationStrategy
    (strategy);
  }//foreach property
 }//Helper__ProcessModelFinalizing__TableOrView

 //private data ----------------------------------------------------------
 private readonly ProviderConventionSetBuilderDependencies m_Dependencies;
};//class FB_V03_0_0__Convention_ValueGenerationStrategy

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Metadata.Conventions

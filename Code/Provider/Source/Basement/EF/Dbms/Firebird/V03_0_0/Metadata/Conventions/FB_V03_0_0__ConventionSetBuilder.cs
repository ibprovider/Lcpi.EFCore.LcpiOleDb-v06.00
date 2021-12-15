////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 16.10.2020.
using System;
using System.Diagnostics;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Metadata.Conventions{
////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0__ConventionSetBuilder

sealed class FB_V03_0_0__ConventionSetBuilder:RelationalConventionSetBuilder
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Basement_EF_Dbms_Firebird_V03_0_0_Metadata_Conventions___FB_V03_0_0__ConventionSetBuilder;

 //-----------------------------------------------------------------------
 public FB_V03_0_0__ConventionSetBuilder(ProviderConventionSetBuilderDependencies   dependencies,
                                         RelationalConventionSetBuilderDependencies relationalDependencies)
  :base(dependencies,relationalDependencies)
 {
#if TRACE
  Core.Core_Trace.Method
   ("FB_V03_0_0__ConventionSetBuilder::FB_V03_0_0__ConventionSetBuilder\n"
   +" (dependencies           : {0},\n"
   +"  relationalDependencies : {1})",
   dependencies,
   relationalDependencies);
#endif
 }//FB_V03_0_0__ConventionSetBuilder

 //RelationalConventionSetBuilder interface ------------------------------
 public override ConventionSet CreateConventionSet()
 {
#if TRACE
  Core.Core_Trace.Method
   ("FB_V03_0_0__ConventionSetBuilder::CreateConventionSet()");
#endif

  //----------------------------------------
  var conventionSet
   =base.CreateConventionSet();

  //---------------------------------------- [INIT] FB_V03_0_0__ValueGenerationStrategyConvention

  var valueGenerationStrategyConvention
   =new FB_V03_0_0__Convention_ValueGenerationStrategy
     (this.Dependencies);

  Helper__CheckedAddConvention
   (conventionSet.ModelInitializedConventions,
    valueGenerationStrategyConvention);

  //---------------------------------------- [INIT] RelationalMaxIdentifierLengthConvention

  Helper__CheckedAddConvention
   (conventionSet.ModelInitializedConventions,
    new RelationalMaxIdentifierLengthConvention
     (FB_V03_0_0__Consts.c_MaxDatabaseObjectLength,
      this.Dependencies,
      this.RelationalDependencies));

  //----------------------------------------

  var valueGenerationConvention
   =new FB_V03_0_0__Convention_ValueGeneration
     (Dependencies,
      RelationalDependencies);

  Helper__CheckedReplacingConventionToNew
   (conventionSet.EntityTypeBaseTypeChangedConventions,
    valueGenerationConvention);

  Helper__CheckedReplacingConventionToNew
   (conventionSet.EntityTypePrimaryKeyChangedConventions,
    valueGenerationConvention);

  Helper__CheckedReplacingConventionToNew
   (conventionSet.ForeignKeyAddedConventions,
    valueGenerationConvention);

  Helper__CheckedReplacingConventionToNew
   (conventionSet.ForeignKeyRemovedConventions,
    valueGenerationConvention);

  Helper__CheckedReplacingConventionToNew
   (conventionSet.PropertyAnnotationChangedConventions,
    valueGenerationConvention);

  Helper__CheckedReplacingConventionToNew
   (conventionSet.EntityTypeAnnotationChangedConventions,
    valueGenerationConvention);

  //LCPI specific [complete replacing of RelationalValueGenerationConvention]

  Helper__CheckedReplacingConventionToNew
   (conventionSet.ForeignKeyPropertiesChangedConventions,
    valueGenerationConvention);

  Helper__CheckedReplacingConventionToNew
   (conventionSet.ForeignKeyOwnershipChangedConventions,
    valueGenerationConvention);

  //---------------------------------------- [FINI] FB_V03_0_0__ValueGenerationStrategyConvention

  Helper__CheckedAddConvention
   (conventionSet.ModelFinalizingConventions,
    valueGenerationStrategyConvention);

  //----------------------------------------
  var storeGenerationConvention
    =new FB_V03_0_0__Convention_StoreGeneration
      (Dependencies,
       RelationalDependencies);

  //checking of global (model) value generation strategy
  Helper__CheckedAddConvention
   (conventionSet.ModelAnnotationChangedConventions,
    storeGenerationConvention);

  Helper__CheckedReplacingConventionToNew
   (conventionSet.PropertyAnnotationChangedConventions,
    storeGenerationConvention);

  Helper__CheckedReplacingConventionToNew
   (conventionSet.ModelFinalizingConventions,
    storeGenerationConvention);

  //----------------------------------------
  return conventionSet;
 }//CreateConventionSet

 //Helper methods --------------------------------------------------------
 private static void Helper__CheckedReplacingConventionToNew<TConvention,TImplementation>
                            (IList<TConvention> conventionsList,
                             TImplementation    newConvention)
  where TImplementation:TConvention
 {
  Debug.Assert(!Object.ReferenceEquals(conventionsList,null));
  Debug.Assert(!Object.ReferenceEquals(newConvention,null));

  //--------------------------------------------------
  const string c_bugcheck_src
   ="FB_V03_0_0__ConventionSetBuilder::Helper__CheckedReplacingConventionToNew";

  //--------------------------------------------------
  var typeOf_TImplementation
   =typeof(TImplementation);

  Debug.Assert(!Object.ReferenceEquals(typeOf_TImplementation,null));

  //--------------------------------------------------
  Nullable<int> indexForReplace=null; 

  for(var i=0;i!=conventionsList.Count;++i)
  {
   Debug.Assert(!Object.ReferenceEquals(conventionsList[i],null));

   if(!conventionsList[i].GetType().IsAssignableFrom(typeOf_TImplementation))
    continue;
  
   if(indexForReplace.HasValue)
   {
    //ERROR - multiple point with same convention!

    ThrowBugCheck.ConventionErr__MultipleConventionsForReplacing
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      typeof(TConvention),
      typeOf_TImplementation,
      conventionsList[indexForReplace.Value].GetType(),
      conventionsList[i].GetType());
   }//if

   Debug.Assert(!indexForReplace.HasValue);

   indexForReplace=i;
  }//for i

  if(!indexForReplace.HasValue)
  {
   //ERROR - convention cant be replaced!

   ThrowBugCheck.ConventionErr__NoConventionForReplacing
    (c_ErrSrcID,
     c_bugcheck_src,
     "#002",
     typeof(TConvention),
     typeOf_TImplementation);
  }//if

  Debug.Assert(indexForReplace.HasValue);
  Debug.Assert(indexForReplace.Value>=0);
  Debug.Assert(indexForReplace.Value<conventionsList.Count);

  conventionsList[indexForReplace.Value]=newConvention;
 }//Helper__CheckedReplacingConventionToNew

 //-----------------------------------------------------------------------
 private static void Helper__CheckedAddConvention<TConvention,TImplementation>
                            (IList<TConvention> conventionsList,
                             TImplementation    newConvention)
  where TImplementation:TConvention
 {
  Debug.Assert(!Object.ReferenceEquals(conventionsList,null));
  Debug.Assert(!Object.ReferenceEquals(newConvention,null));

  //--------------------------------------------------
  const string c_bugcheck_src
   ="FB_V03_0_0__ConventionSetBuilder::Helper__CheckedAddConvention";

  //--------------------------------------------------
  var typeOf_TImplementation
   =typeof(TImplementation);

  Debug.Assert(!Object.ReferenceEquals(typeOf_TImplementation,null));

  //--------------------------------------------------
  for(var i=0;i!=conventionsList.Count;++i)
  {
   Debug.Assert(!Object.ReferenceEquals(conventionsList[i],null));

   if(!conventionsList[i].GetType().IsAssignableFrom(typeOf_TImplementation))
    continue;
  
   ThrowBugCheck.ConventionErr__ConventionAlreadyDefined
    (c_ErrSrcID,
     c_bugcheck_src,
     "#001",
     typeof(TConvention),
     typeOf_TImplementation,
     conventionsList[i].GetType());
  }//for i

  conventionsList.Add
   (newConvention);
 }//Helper__CheckedAddConvention
};//class FB_V03_0_0__ConventionSetBuilder

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Metadata.Conventions

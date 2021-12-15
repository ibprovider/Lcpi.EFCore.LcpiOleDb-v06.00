////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 12.11.2021.
using System;
using System.Diagnostics;
using System.Linq;

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;

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

using Structure_TypeCache
 =xEFCore.Structure.Structure_TypeCache;

////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__Extensions__Property

public static partial class LcpiOleDb__Extensions__Property
{
 public static Nullable<ConfigurationSource> GetValueGenerationStrategyConfigurationSource
                            (this IConventionProperty property)
 {
  Check.Arg_NotNull
   (c_ErrSrcID,
    "GetValueGenerationStrategyConfigurationSource(property)",
    nameof(property),
    property);

  var annotation
   =property.FindAnnotation
     (LcpiOleDb__AnnotationNames.ValueGenerationStrategy);

  if(Object.ReferenceEquals(annotation,null))
   return null;

  return annotation.GetConfigurationSource();
 }//GetValueGenerationStrategyConfigurationSource

 //-----------------------------------------------------------------------
 public static LcpiOleDb__AnnotationData__ValueGenerationStrategy GetValueGenerationStrategy
                            (this IReadOnlyProperty property)
 {
  Check.Arg_NotNull
   (c_ErrSrcID,
    "GetValueGenerationStrategy(property)",
    nameof(property),
    property);

  var vgs
   =Internal__SelectValueGenerationStrategy
     (property);

  if(Object.ReferenceEquals(vgs,null))
   return LcpiOleDb__ValueGenerationStrategy.None;

  return vgs;
 }//GetValueGenerationStrategy - property

 //-----------------------------------------------------------------------
 public static LcpiOleDb__AnnotationData__ValueGenerationStrategy GetValueGenerationStrategy
                            (this IReadOnlyProperty   property,
                             in StoreObjectIdentifier storeObject)
 {
  xEFCore.Check.Arg_NotNull
   (c_ErrSrcID,
    "GetValueGenerationStrategy(property, storeObject)",
    nameof(property),
    property);

  var vgs
   =Helper__SelectValueGenerationStrategy
     (property,
      storeObject,
      /*typeMappingSource*/null);

  if(Object.ReferenceEquals(vgs,null))
   return LcpiOleDb__ValueGenerationStrategy.None;

  return vgs;
 }//GetValueGenerationStrategy - property, storeObject

 //-----------------------------------------------------------------------
 /// <summary>
 ///  Select ValueGenerationStrategy for property.
 /// </summary>
 /// <param name="property">Not null</param>
 /// <param name="storeObject">Store object identifier</param>
 /// <param name="typeMappingSource">Can be null</param>
 /// <returns>
 ///  Not null.
 /// </returns>
 internal static LcpiOleDb__AnnotationData__ValueGenerationStrategy Internal__GetValueGenerationStrategy
                            (this IReadOnlyProperty   property,
                             in StoreObjectIdentifier storeObject,
                             ITypeMappingSource       typeMappingSource)
 {
  Debug.Assert(!Object.ReferenceEquals(property,null));

  var vgs
   =Helper__SelectValueGenerationStrategy
     (property,
      storeObject,
      typeMappingSource);

  if(Object.ReferenceEquals(vgs,null))
   return LcpiOleDb__ValueGenerationStrategy.None;

  return vgs;
 }//Internal__GetValueGenerationStrategy

 //-----------------------------------------------------------------------
 /// <summary>
 ///  Select ValueGenerationStrategy for property.
 /// </summary>
 /// <param name="property">Not null</param>
 /// <returns>
 ///  Null, if VGS not applicatible.
 /// </returns>
 internal static LcpiOleDb__AnnotationData__ValueGenerationStrategy Internal__SelectValueGenerationStrategy
                            (this IReadOnlyProperty property)
 {
  Debug.Assert(!Object.ReferenceEquals(property,null));

  if(xEFCore.LcpiOleDb__Common___AnnotationHelpers.TryGetValueGenerationStrategy
                            (c_ErrSrcID,
                             property,
                             out var annotationValue))
  {
   Debug.Assert(!Object.ReferenceEquals(annotationValue,null));

   return annotationValue;
  }//if

  StoreObjectIdentifier storeObject;

  if(!LcpiOleDb__Common__StoreObjectIdentifierHelper.TryBuildEntityStoreIdThatCompatibleWithValueGenerationStrategy
                            (property.DeclaringEntityType,
                             out storeObject))
  {
   return null;
  }//if

  return Helper__SelectValueGenerationStrategy__STEP2
   (property,
    storeObject,
    /*typeMappingSource*/null);
 }//Internal__SelectValueGenerationStrategy - property

 //-----------------------------------------------------------------------
 /// <summary>
 ///  Select ValueGenerationStrategy for property.
 /// </summary>
 /// <param name="property">Not null</param>
 /// <param name="storeObject"></param>
 /// <param name="typeMappingSource"></param>
 /// <returns>
 ///  Null, if VGS not applicatible.
 /// </returns>
 internal static LcpiOleDb__AnnotationData__ValueGenerationStrategy Internal__SelectValueGenerationStrategy
                            (this IReadOnlyProperty   property,
                             in StoreObjectIdentifier storeObject,
                             ITypeMappingSource       typeMappingSource)
 {
  Debug.Assert(!Object.ReferenceEquals(property,null));

  return Helper__SelectValueGenerationStrategy
   (property,
    storeObject,
    typeMappingSource);
 }//Internal__SelectValueGenerationStrategy

 //-----------------------------------------------------------------------
 public static void SetValueGenerationStrategy
                            (this IConventionProperty                           property,
                             LcpiOleDb__AnnotationData__ValueGenerationStrategy valueGenerationStrategy,
                             bool                                               fromDataAnnotation=false)
 {
  xEFCore.Check.Arg_NotNull
   (c_ErrSrcID,
    "SetValueGenerationStrategy(IConventionProperty ...)",
    nameof(property),
    property);

  if(!xEFCore.LcpiOleDb__Common___AnnotationHelpers.NeedSetValueGenerationStrategy
                            (c_ErrSrcID,
                             property,
                             valueGenerationStrategy))
  {
   return;
  }//if

  Helper__CheckValueGenerationStrategy
   (property,
    valueGenerationStrategy);

  property.SetOrRemoveAnnotation
   (LcpiOleDb__AnnotationNames.ValueGenerationStrategy,
    valueGenerationStrategy,
    fromDataAnnotation);
 }//SetValueGenerationStrategy - IConventionProperty

 //-----------------------------------------------------------------------
 public static void SetValueGenerationStrategy
                            (this IMutableProperty                              property,
                             LcpiOleDb__AnnotationData__ValueGenerationStrategy valueGenerationStrategy)
 {
  xEFCore.Check.Arg_NotNull
   (c_ErrSrcID,
    "SetValueGenerationStrategy(IMutableProperty ...)",
    nameof(property),
    property);

  if(!xEFCore.LcpiOleDb__Common___AnnotationHelpers.NeedSetValueGenerationStrategy
                            (c_ErrSrcID,
                             property,
                             valueGenerationStrategy))
  {
   return;
  }//if

  Helper__CheckValueGenerationStrategy
   (property,
    valueGenerationStrategy);

  property.SetOrRemoveAnnotation
   (LcpiOleDb__AnnotationNames.ValueGenerationStrategy,
    valueGenerationStrategy);
 }//SetValueGenerationStrategy - IMutableProperty

 //-----------------------------------------------------------------------
 internal static void Internal__CheckValueGenerationStrategy
                            (this IReadOnlyProperty property)
 {
  Debug.Assert(!Object.ReferenceEquals(property,null));

  var valueGenerationStrategy
   =property.Internal__SelectValueGenerationStrategy();

  Helper__CheckValueGenerationStrategy
   (property,
    valueGenerationStrategy);
 }//Internal__CheckValueGenerationStrategy

 //Helper methods --------------------------------------------------------
 private static LcpiOleDb__AnnotationData__ValueGenerationStrategy Helper__SelectValueGenerationStrategy
                            (this IReadOnlyProperty   property,
                             in StoreObjectIdentifier storeObject,
                             ITypeMappingSource       typeMappingSource)
 {
  Debug.Assert(!Object.ReferenceEquals(property,null));

  if(xEFCore.LcpiOleDb__Common___AnnotationHelpers.TryGetValueGenerationStrategy
                            (c_ErrSrcID,
                             property,
                             out var annotationValue))
  {
   Debug.Assert(!Object.ReferenceEquals(annotationValue,null));

   return annotationValue;
  }//if

  return Helper__SelectValueGenerationStrategy__STEP2
   (property,
    storeObject,
    typeMappingSource);
 }//Helper__SelectValueGenerationStrategy

 //-----------------------------------------------------------------------
 private static LcpiOleDb__AnnotationData__ValueGenerationStrategy Helper__SelectValueGenerationStrategy__STEP2
                            (this IReadOnlyProperty   property,
                             in StoreObjectIdentifier storeObject,
                             ITypeMappingSource       typeMappingSource)
 {
  Debug.Assert(!Object.ReferenceEquals(property,null));

  if(!Helper__PropertyCanHasVGS(property,storeObject))
  {
   //VGS not applicatible

   return null;
  }//if

  IReadOnlyProperty
   sharedTableRootProperty
    =property.FindSharedStoreObjectRootProperty
      (storeObject);

  if(!Object.ReferenceEquals(sharedTableRootProperty,null))
  {
   var valueGenerationStrategy
    =sharedTableRootProperty.Helper__SelectValueGenerationStrategy
      (storeObject,
       typeMappingSource);

   Debug.Assert(!Object.ReferenceEquals(valueGenerationStrategy,null));

   return valueGenerationStrategy;
  }//if

  return Helper__GetDefaultValueGenerationStrategy
          (property,
           storeObject,
           typeMappingSource);
 }//Helper__SelectValueGenerationStrategy__STEP2

 //-----------------------------------------------------------------------
 private static void Helper__CheckValueGenerationStrategy
                            (this IReadOnlyProperty                             property,
                             LcpiOleDb__AnnotationData__ValueGenerationStrategy valueGenerationStrategy)
 {
  Debug.Assert(!Object.ReferenceEquals(property,null));

  if(Object.ReferenceEquals(valueGenerationStrategy,null))
   return;

  if(valueGenerationStrategy.GetType()==Structure_TypeCache.TypeOf__LcpiEF___LcpiOleDb__AnnotationData__ValueGenerationStrategy_None)
   return;

  if(Helper__IsCompatibleWithValueGeneration2(property))
   return;

  //ERROR - property is not compatible with ValueGenerationStrategy

  ThrowError.PropertyWithDataTypeIsNotCompatiblyWithValueGenerationStrategy
   (c_ErrSrcID,
    valueGenerationStrategy.Internal__GetStrategyName(),
    property.DeclaringEntityType.ClrType,
    property.Name,
    property.ClrType);
 }//Helper__CheckValueGenerationStrategy

 //-----------------------------------------------------------------------
 private static bool Helper__PropertyCanHasVGS
                            (IReadOnlyProperty        property,
                             in StoreObjectIdentifier storeObject)
 {
  Debug.Assert(!Object.ReferenceEquals(property,null));

  if(property.ValueGenerated!=ValueGenerated.OnAdd)
  {
   return false;
  }//Helper__PropertyCanHasVGS

  //--------------------------------------------------
  //
  // IsBaseLinking:
  //
  //   Returns a value indicating whether the foreign key is defined on the primary
  //   key and pointing to the same primary key.
  //
  if(property.GetContainingForeignKeys().Any(fk => !fk.IsBaseLinking()))
   return false;

  if(property.TryGetDefaultValue(storeObject,out _))
   return false;

  if(!Object.ReferenceEquals(property.GetDefaultValueSql(storeObject),null))
   return false;

  if(!Object.ReferenceEquals(property.GetComputedColumnSql(storeObject),null))
   return false;

  return true;
 }//Helper__PropertyCanHasVGS

 //-----------------------------------------------------------------------
 private static LcpiOleDb__AnnotationData__ValueGenerationStrategy Helper__GetDefaultValueGenerationStrategy
                            (IReadOnlyProperty        property,
                             in StoreObjectIdentifier storeObject,
                             ITypeMappingSource       typeMappingSource)
 {
  Debug.Assert(!Object.ReferenceEquals(property,null));
  Debug.Assert(!Object.ReferenceEquals(property.DeclaringEntityType,null));
  Debug.Assert(!Object.ReferenceEquals(property.DeclaringEntityType.Model,null));

  LcpiOleDb__AnnotationData__ValueGenerationStrategy
   modelVGS
    =property.DeclaringEntityType.Model.GetValueGenerationStrategyOrNull();

  if(Object.ReferenceEquals(modelVGS,null))
  {
   return LcpiOleDb__ValueGenerationStrategy.None;
  }//if null

  Debug.Assert(!Object.ReferenceEquals(modelVGS,null));

  //Check global VGS

  var typeOfModelVGS
   =modelVGS.GetType();

  Debug.Assert(!Object.ReferenceEquals(typeOfModelVGS,null));

  if(typeOfModelVGS==xEFCore.Structure.Structure_TypeCache.TypeOf__LcpiEF___LcpiOleDb__AnnotationData__ValueGenerationStrategy_None)
  {
   return modelVGS;
  }//if None

  if(typeOfModelVGS==xEFCore.Structure.Structure_TypeCache.TypeOf__LcpiEF___LcpiOleDb__AnnotationData__ValueGenerationStrategy_IdentityByDefaultColumn)
  {
   if(!Helper__IsCompatibleWithValueGeneration2(property,storeObject,typeMappingSource))
    return LcpiOleDb__ValueGenerationStrategy.None;

   return modelVGS;
  }//if IdentityByDefaultColumn

  //ERROR - incorrect global VGS
  ThrowError.ModelDefinesIncorrectGlobalValueGenerationStrategy
   (c_ErrSrcID,
    modelVGS.Internal__GetStrategyName());

  Debug.Assert(false);

  return null;
 }//Helper__GetDefaultValueGenerationStrategy

 //-----------------------------------------------------------------------
 private static bool Helper__IsCompatibleWithValueGeneration2
                            (IReadOnlyProperty property)
 {
  Debug.Assert(!Object.ReferenceEquals(property,null));
  Debug.Assert(!Object.ReferenceEquals(property.DeclaringEntityType,null));

  StoreObjectIdentifier storeObject;

  if(!LcpiOleDb__Common__StoreObjectIdentifierHelper.TryBuildEntityStoreIdThatCompatibleWithValueGenerationStrategy
                            (property.DeclaringEntityType,
                             out storeObject))
  {
   return false;
  }//if

  return Helper__IsCompatibleWithValueGeneration2
   (property,
    storeObject,
    /*typeMappingSource*/null);
 }//Helper__IsCompatibleWithValueGeneration2

 //-----------------------------------------------------------------------
 private static bool Helper__IsCompatibleWithValueGeneration2
                            (IReadOnlyProperty        property,
                             in StoreObjectIdentifier storeObject,
                             ITypeMappingSource       typeMappingSource)
 {
  Debug.Assert(!Object.ReferenceEquals(property,null));
  Debug.Assert(!Object.ReferenceEquals(property.ClrType,null));

  const string c_bugcheck_src
   ="LcpiOleDb__Extensions__Property::Helper__IsCompatibleWithValueGeneration";

  // var valueConverter
  //  =property.GetValueConverter()
  //    ?? (property.FindRelationalTypeMapping(storeObject)
  //        ?? typeMappingSource?.FindMapping((IProperty)property))?.Converter;
  //
  // var type = (valueConverter?.ProviderClrType ?? property.ClrType).UnwrapNullableType();
  //
  // return type.IsInteger();

  if(Helper__TryGetIsCompatibleWithValueGeneration(property.GetValueConverter(),out bool r1))
   return r1;

  if(Helper__TryGetIsCompatibleWithValueGeneration__ForRelationalTypeMapping(property.FindRelationalTypeMapping(storeObject),out bool r2))
   return r2;

  if(!Object.ReferenceEquals(typeMappingSource,null))
  {
   //
   // See issue https://github.com/dotnet/efcore/issues/26671
   //

   var property_p
    =property as IProperty;

   if(Object.ReferenceEquals(property_p,null))
   {
    xEFCore.ThrowBugCheck.bad_value_type
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      nameof(property),
      property.GetType(),
      typeof(IProperty));
   }//if

   Debug.Assert(!Object.ReferenceEquals(property_p,null));

   if(Helper__TryGetIsCompatibleWithValueGeneration__ForCoreTypeMapping(typeMappingSource.FindMapping(property_p),out bool r3))
    return r3;
  }//if

#if DEBUG
  {
   // [2021-11-14] ClrType with enum not expected here ...

   var t1=property.ClrType.Extension__SwitchToUnderlying();
   var t2=property.ClrType;

   Debug.Assert(!Object.ReferenceEquals(t1,null));
   Debug.Assert(!Object.ReferenceEquals(t2,null));

   Debug.Assert(t1==t2);
  }//local
#endif

  //--------------------------------------------------
  var propertyClrType_u
   =property.ClrType.Extension__UnwrapNullableType();

  Debug.Assert(!Object.ReferenceEquals(propertyClrType_u,null));

  if(propertyClrType_u.Extension__IsInteger__Exact())
  {
   return true;
  }//if IsInteger

  if(propertyClrType_u==xEFCore.Structure.Structure_TypeCache.TypeOf__System_Decimal)
  {
   if(property.GetScale().GetValueOrDefault(0)==0)
   {
    return true;
   }//if

   return false;
  }//if decimal

  return false;
 }//Helper__IsCompatibleWithValueGeneration2

 //-----------------------------------------------------------------------
 private static bool Helper__TryGetIsCompatibleWithValueGeneration__ForCoreTypeMapping
                            (Storage.CoreTypeMapping typeMapping,
                             out bool                isCompatibleWithVG)
 {
  isCompatibleWithVG
   =false;

  if(Object.ReferenceEquals(typeMapping,null))
   return false;

  if(Helper__TryGetIsCompatibleWithValueGeneration(typeMapping.Converter,out isCompatibleWithVG))
   return true;

  return false;
 }//Helper__TryGetIsCompatibleWithValueGeneration__ForCoreTypeMapping

 //-----------------------------------------------------------------------
 private static bool Helper__TryGetIsCompatibleWithValueGeneration__ForRelationalTypeMapping
                            (Storage.RelationalTypeMapping typeMapping,
                             out bool                      isCompatibleWithVG)
 {
  isCompatibleWithVG
   =false;

  if(Object.ReferenceEquals(typeMapping,null))
   return false;

  if(Helper__TryGetIsCompatibleWithValueGeneration(typeMapping.Converter,out isCompatibleWithVG))
   return true;

  isCompatibleWithVG
   =Helper__IsCompatibleWithValueGeneration
     (new tagTypeInfoProvider__ForTypeMapping(typeMapping));

  return true;
 }//Helper__TryGetIsCompatibleWithValueGeneration__ForRelationalTypeMapping

 //-----------------------------------------------------------------------
 private static bool Helper__TryGetIsCompatibleWithValueGeneration
                            (Storage.ValueConversion.ValueConverter valueConverter,
                             out bool                               isCompatibleWithVG)
 {
  isCompatibleWithVG
   =false;

  if(Object.ReferenceEquals(valueConverter,null))
   return false;

  isCompatibleWithVG
   =Helper__IsCompatibleWithValueGeneration
     (new tagTypeInfoProvider__ForValueConverter(valueConverter));

  return true;
 }//Helper__TryGetIsCompatibleWithValueGeneration

 //-----------------------------------------------------------------------
 private static bool Helper__IsCompatibleWithValueGeneration
                            (tagTypeInfoProvider typeInfoProvider)
 {
  Debug.Assert(!Object.ReferenceEquals(typeInfoProvider,null));

  var clrType
   =typeInfoProvider.GetClrType();

  //Expected
  Debug.Assert(clrType==clrType.Extension__UnwrapNullableType());
  Debug.Assert(clrType==clrType.Extension__SwitchToUnderlying());

  if(clrType.Extension__IsInteger__Exact())
  {
   //OK
  }
  else
  if(clrType==xEFCore.Structure.Structure_TypeCache.TypeOf__System_Decimal)
  {
   if(typeInfoProvider.CanProvidePrecisionAndScale())
   {
    if(typeInfoProvider.GetScale().GetValueOrDefault(0)!=0)
    {
     return false;
    }//if
   }//if
  }//if Decimal

  return true;
 }//Helper__TryGetIsCompatibleWithValueGeneration
};//class LcpiOleDb__Extensions__Property

////////////////////////////////////////////////////////////////////////////////
}//namespace Microsoft.EntityFrameworkCore

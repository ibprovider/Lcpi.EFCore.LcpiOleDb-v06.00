////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 12.11.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Metadata;

using xEFCore
 =Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace Microsoft.EntityFrameworkCore{
////////////////////////////////////////////////////////////////////////////////

using xEFCore;

using LcpiOleDb__AnnotationNames
 =xEFCore.MetaData.Internal.LcpiOleDb__AnnotationNames;

using LcpiOleDb__AnnotationData__ValueGenerationStrategy
 =xEFCore.MetaData.LcpiOleDb__AnnotationData__ValueGenerationStrategy;

using Structure_TypeCache
 =xEFCore.Structure.Structure_TypeCache;

////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__Extensions__Model

public static partial class LcpiOleDb__Extensions__Model
{
 public static void SetValueGenerationStrategy
                            (this IConventionModel                              model,
                             LcpiOleDb__AnnotationData__ValueGenerationStrategy valueGenerationStrategy,
                             bool                                               fromDataAnnotation=false)
 {
  xEFCore.Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(SetValueGenerationStrategy)+"(IConventionModel...)",
    nameof(model),
    model);

  if(!xEFCore.LcpiOleDb__Common___AnnotationHelpers.NeedSetValueGenerationStrategy
                            (c_ErrSrcID,
                             model,
                             valueGenerationStrategy))
  {
   return;
  }//if

  Helper__CheckValueGenerationStrategy
   (model,
    valueGenerationStrategy);

  model.SetOrRemoveAnnotation
   (LcpiOleDb__AnnotationNames.ValueGenerationStrategy,
    valueGenerationStrategy,
    fromDataAnnotation);
 }//SetValueGenerationStrategy - IConventionModel

 //-----------------------------------------------------------------------
 public static void SetValueGenerationStrategy
                            (this IMutableModel                                 model,
                             LcpiOleDb__AnnotationData__ValueGenerationStrategy valueGenerationStrategy)
 {
  xEFCore.Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(SetValueGenerationStrategy)+"(IMutableModel...)",
    nameof(model),
    model);

  if(!xEFCore.LcpiOleDb__Common___AnnotationHelpers.NeedSetValueGenerationStrategy
                            (c_ErrSrcID,
                             model,
                             valueGenerationStrategy))
  {
   return;
  }//if

  Helper__CheckValueGenerationStrategy
   (model,
    valueGenerationStrategy);

  model.SetOrRemoveAnnotation
   (LcpiOleDb__AnnotationNames.ValueGenerationStrategy,
    valueGenerationStrategy);
 }//SetValueGenerationStrategy - IMutableModel

 //-----------------------------------------------------------------------
 public static LcpiOleDb__AnnotationData__ValueGenerationStrategy GetValueGenerationStrategyOrNull
                            (this IReadOnlyModel model)
 {
  xEFCore.Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(GetValueGenerationStrategyOrNull)+"(IReadOnlyModel...)",
    nameof(model),
    model);

  return xEFCore.LcpiOleDb__Common___AnnotationHelpers.GetValueGenerationStrategyOrNull
           (c_ErrSrcID,
            model);
 }//GetValueGenerationStrategyOrNull - IReadOnlyModel

 //-----------------------------------------------------------------------
 internal static void Internal__CheckValueGenerationStrategy
                            (this IReadOnlyModel                                model,
                             LcpiOleDb__AnnotationData__ValueGenerationStrategy valueGenerationStrategy)
 {
  Debug.Assert(!Object.ReferenceEquals(model,null));

  Helper__CheckValueGenerationStrategy
   (model,
    valueGenerationStrategy); //throw
 }//Internal__CheckValueGenerationStrategy

 //Helper methods --------------------------------------------------------
 private static void Helper__CheckValueGenerationStrategy
                            (IReadOnlyModel                                     model,
                             LcpiOleDb__AnnotationData__ValueGenerationStrategy valueGenerationStrategy)
 {
  Debug.Assert(!Object.ReferenceEquals(model,null));

  if(Helper__IsCompatibleValueGenerationStrategy(model,valueGenerationStrategy))
   return;

  Debug.Assert(!Object.ReferenceEquals(valueGenerationStrategy,null));

  //ERROR - incompatible value generation strategy

  ThrowError.ValueGenerationStrategyCantBeDefinedAtModelLevel
   (c_ErrSrcID,
    valueGenerationStrategy.Internal__GetStrategyName());
 }//Helper__CheckValueGenerationStrategy

 //-----------------------------------------------------------------------
 private static bool Helper__IsCompatibleValueGenerationStrategy
                            (IReadOnlyModel                                     model,
                             LcpiOleDb__AnnotationData__ValueGenerationStrategy valueGenerationStrategy)
 {
  Debug.Assert(!Object.ReferenceEquals(model,null));

  if(Object.ReferenceEquals(valueGenerationStrategy,null))
   return true;

  Debug.Assert(!Object.ReferenceEquals(valueGenerationStrategy,null));

  System.Type
   valueGenerationStrategyType
    =valueGenerationStrategy.GetType();

  Debug.Assert(!Object.ReferenceEquals(valueGenerationStrategyType,null));

  if(valueGenerationStrategyType==Structure_TypeCache.TypeOf__LcpiEF___LcpiOleDb__AnnotationData__ValueGenerationStrategy_None)
   return true;

  if(valueGenerationStrategyType==Structure_TypeCache.TypeOf__LcpiEF___LcpiOleDb__AnnotationData__ValueGenerationStrategy_IdentityByDefaultColumn)
   return true;

  return false;
 }//Helper__IsCompatibleValueGenerationStrategy
};//class LcpiOleDb__Extensions__Model

////////////////////////////////////////////////////////////////////////////////
}//namespace Microsoft.EntityFrameworkCore

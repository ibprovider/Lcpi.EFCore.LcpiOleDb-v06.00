////////////////////////////////////////////////////////////////////////////////
//EF.Core Provider for LCPI OLE DB and Firebird.
//                                      IBProvider and Contributors. 29.09.2021.
using System;
using System.Diagnostics;
using System.Reflection;

using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.Mapping{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

using Structure_ADP
 =Structure.Structure_ADP;

using LcpiOleDb__IGetUnderlyingTypeMapping
 =Root.Storage.LcpiOleDb__IGetUnderlyingTypeMapping;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__TypeMapping__TimeSpan__as_Decimal18_4

// Mapping of System.TimeSpan to NUMERIC(18,4)

sealed class FB_Common__TypeMapping__TimeSpan__as_Decimal18_4
 :FB_Common__TypeMapping
 ,LcpiOleDb__IGetUnderlyingTypeMapping
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__TypeMapping__TimeSpan__as_Decimal18_4;

 //-----------------------------------------------------------------------
 private FB_Common__TypeMapping__TimeSpan__as_Decimal18_4(in RelationalTypeMappingParameters parameters)
  :base(parameters)
 {
 }

 //-----------------------------------------------------------------------
 public static string DatabaseStoreType
 {
  get
  {
   Debug.Assert(!Object.ReferenceEquals(sm_UnderlyingTypeMapping,null));
   Debug.Assert(!Object.ReferenceEquals(sm_UnderlyingTypeMapping.StoreType,null));

   return sm_UnderlyingTypeMapping.StoreType;
  }//get
 }//DatabaseStoreType

 //-----------------------------------------------------------------------
 public static bool Is(Type clrType)
 {
  Debug.Assert(!Object.ReferenceEquals(clrType,null));

  return clrType==sm_ClrType;
 }//Is - clrType

 //-----------------------------------------------------------------------
 private static bool Is(string storeTypeNameBase)
 {
  Debug.Assert(!Object.ReferenceEquals(storeTypeNameBase,null));

  return Structure_ADP.EqualDatabaseTypeName(storeTypeNameBase,sm_UnderlyingTypeMapping.StoreTypeNameBase);
 }//Is - storeTypeNameBase

 //-----------------------------------------------------------------------
 public static bool Is(Type clrType,string storeTypeNameBase,int precision,int scale)
 {
  Debug.Assert(!Object.ReferenceEquals(clrType,null));
  Debug.Assert(!Object.ReferenceEquals(storeTypeNameBase,null));

  Debug.Assert(!Object.ReferenceEquals(sm_UnderlyingTypeMapping,null));
  Debug.Assert(sm_UnderlyingTypeMapping.Precision.HasValue);
  Debug.Assert(sm_UnderlyingTypeMapping.Scale.HasValue);

  if(!Is(clrType))
   return false;

  if(!Is(storeTypeNameBase))
   return false;

  if(sm_UnderlyingTypeMapping.Precision.Value!=precision)
   return false;

  if(sm_UnderlyingTypeMapping.Scale.Value!=scale)
   return false;

  return true;
 }//Is - clrType, storeTypeNameBase, precision, scale

 //-----------------------------------------------------------------------
 public static RelationalTypeMapping Create()
 {
  Debug.Assert(!Object.ReferenceEquals(sm_Instance,null));

  return sm_Instance;
 }//Create

 //-----------------------------------------------------------------------
 public static RelationalTypeMapping Create(in RelationalTypeMappingInfo mappingInfo)
 {
  //Debug.Assert(!Object.ReferenceEquals(mappingInfo,null));
  Debug.Assert(mappingInfo.GetType().IsValueType);

  Debug.Assert(!Object.ReferenceEquals(sm_UnderlyingTypeMapping,null));
  Debug.Assert(sm_UnderlyingTypeMapping.Precision.HasValue);
  Debug.Assert(sm_UnderlyingTypeMapping.Scale.HasValue);
  Debug.Assert(sm_UnderlyingTypeMapping.IsFixedLength==true);

  //StoreTypeName
  //StoreTypeNameBase
  //Size
  //IsFixedLength
  //IsUnicode
  //Precision
  //Scale
  //IsRowVersion
  //ClrType

  Check.RelationalTypeMappingInfo__StoreTypeName
   (c_ErrSrcID,
    mappingInfo,
    sm_UnderlyingTypeMapping.StoreType);

  Check.RelationalTypeMappingInfo__StoreTypeNameBase
   (c_ErrSrcID,
    mappingInfo,
    sm_UnderlyingTypeMapping.StoreTypeNameBase);

  Check.RelationalTypeMappingInfo__SizeIsNull
   (c_ErrSrcID,
    mappingInfo);

  Check.RelationalTypeMappingInfo__IsFixedLength__optional
   (c_ErrSrcID,
    mappingInfo,
    true);

  Check.RelationalTypeMappingInfo__IsUnicode
   (c_ErrSrcID,
    mappingInfo,
    false);

  Check.RelationalTypeMappingInfo__PrecisionExactOrNull
   (c_ErrSrcID,
    mappingInfo,
    sm_UnderlyingTypeMapping.Precision.Value);

  Check.RelationalTypeMappingInfo__ScaleExactOrNull
   (c_ErrSrcID,
    mappingInfo,
    sm_UnderlyingTypeMapping.Scale.Value);

  Check.RelationalTypeMappingInfo__IsRowVersion
   (c_ErrSrcID,
    mappingInfo,
    false);

  Check.RelationalTypeMappingInfo__ClrType
   (c_ErrSrcID,
    mappingInfo,
    sm_ClrType);

  Debug.Assert(!Object.ReferenceEquals(sm_Instance,null));

  return sm_Instance;
 }//Create - mappingInfo

 //LcpiOleDb__IGetUnderlyingTypeMapping interface ------------------------
 RelationalTypeMapping LcpiOleDb__IGetUnderlyingTypeMapping.GetUnderlyingTypeMapping()
 {
  Debug.Assert(!Object.ReferenceEquals(sm_UnderlyingTypeMapping,null));

  return sm_UnderlyingTypeMapping;
 }//GetUnderlyingTypeMapping

 //RelationalTypeMapping interface ---------------------------------------
 protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
 {
  //Debug.Assert(!Object.ReferenceEquals(parameters,null));
  Debug.Assert(parameters.GetType().IsValueType);

#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__TypeMapping__TimeSpan__as_Decimal18_4::Clone(...)");
#endif

  // [2020-12-01] Research
  Debug.Assert(parameters.CoreParameters.ClrType == this.ClrType);
  Debug.Assert(parameters.FixedLength            == this.IsFixedLength);
  Debug.Assert(parameters.Unicode                == this.IsUnicode);
  Debug.Assert(parameters.DbType                 == this.DbType);
  Debug.Assert(parameters.StoreType              == this.StoreType);
  Debug.Assert(parameters.StoreTypePostfix       == this.StoreTypePostfix);
  Debug.Assert(parameters.Size                   == this.Size);
  Debug.Assert(parameters.Precision              == this.Precision);
  Debug.Assert(parameters.Scale                  == this.Scale);

  return new FB_Common__TypeMapping__TimeSpan__as_Decimal18_4(parameters);
 }//Clone

 //-----------------------------------------------------------------------
 protected override string GenerateNonNullSqlLiteral(object value)
 {
  Debug.Assert(!Object.ReferenceEquals(value,null));

  if(value.GetType()!=sm_ProviderType)
  {
   //ERROR - wrong value type

   ThrowError.ArgErr__BadValueType
     (c_ErrSrcID,
      nameof(GenerateNonNullSqlLiteral),
      nameof(value),
      value.GetType(),
      sm_ProviderType);
  }//if

  Debug.Assert(value.GetType()==sm_ProviderType);

  Debug.Assert(value.GetType()==sm_ProviderType);

  System.Decimal typedValue=(System.Decimal)value;

  var r=typedValue.ToString(FB_Common__TypeMappingConfig.CvtCulture);

  //
  // [2021-09-29]
  //
  //  Explicit definition of value type for avoiding any unexpected problem at server side.
  //
  Debug.Assert(!Object.ReferenceEquals(sm_UnderlyingTypeMapping,null));

  var r2="CAST("+r+" AS "+sm_UnderlyingTypeMapping.StoreType+")";

  Debug.Assert(!string.IsNullOrEmpty(r2));

  return r2;
 }//GenerateNonNullSqlLiteral

 //-----------------------------------------------------------------------
 public override MethodInfo GetDataReaderMethod()
 {
  Debug.Assert(!Object.ReferenceEquals(sm_UnderlyingTypeMapping,null));

  return sm_UnderlyingTypeMapping.GetDataReaderMethod();
 }//GetDataReaderMethod

 //FB_Common__TypeMapping interface --------------------------------------
 protected sealed override string Internal__GetStoreTypeNameBase()
 {
  Debug.Assert(!Object.ReferenceEquals(sm_UnderlyingTypeMapping,null));

  return sm_UnderlyingTypeMapping.StoreTypeNameBase;
 }//Internal__GetStoreTypeNameBase

 //Helper methods --------------------------------------------------------
 private static RelationalTypeMappingParameters Helper__CreateDefaultRTMP()
 {
  Debug.Assert(!Object.ReferenceEquals(sm_UnderlyingTypeMapping,null));

  var CTMP
   =new CoreTypeMappingParameters
     (/*clrType*/              sm_ClrType,
      /*converter*/            ValueConversion.FB_Common__ValueConversion__TimeSpanToDecimal18_4.Instance,
      /*comparer*/             null,
      /*keyComparer*/          null,
      /*valueGeneratorFactory*/null);

  var RTMP
   =new RelationalTypeMappingParameters
     (/*coreParameters*/   CTMP,
      /*storeType*/        sm_UnderlyingTypeMapping.StoreType,
      /*storeTypePostfix*/ StoreTypePostfix.None,
      /*dbType*/           System.Data.DbType.Time,
      /*unicode*/          false,
      /*size*/             null,
      /*fixedLength*/      true,
      /*precision*/        null,
      /*scale*/            null);

  return RTMP;
 }//Helper__CreateDefaultRTMP

 //private data ----------------------------------------------------------
 private static readonly Type sm_ClrType
  =Structure_TypeCache.TypeOf__System_TimeSpan;

 private static readonly Type sm_ProviderType
  =Structure_TypeCache.TypeOf__System_Decimal;

 //-----------------------------------------------------------------------
 private static readonly RelationalTypeMapping
  sm_UnderlyingTypeMapping
   =FB_Common__TypeMappingCache.TypeMapping__NUMERIC_18_4;

 //-----------------------------------------------------------------------
 private static readonly RelationalTypeMapping
  sm_Instance
   =new FB_Common__TypeMapping__TimeSpan__as_Decimal18_4
     (Helper__CreateDefaultRTMP());
};//class FB_Common__TypeMapping__TimeSpan__as_Decimal18_4

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.Mapping

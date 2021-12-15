////////////////////////////////////////////////////////////////////////////////
//EF.Core Provider for LCPI OLE DB and Firebird.
//                                      IBProvider and Contributors. 07.10.2021.
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
//class FB_Common__TypeMapping__GUID__as_bytes

sealed class FB_Common__TypeMapping__GUID__as_bytes
 :FB_Common__TypeMapping
 ,LcpiOleDb__IGetUnderlyingTypeMapping
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__TypeMapping__GUID__as_bytes;

 //-----------------------------------------------------------------------
 private FB_Common__TypeMapping__GUID__as_bytes(in RelationalTypeMappingParameters parameters)
  :base(parameters)
 {
 }

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
 public static bool Is(Type clrType,string storeTypeNameBase,int size)
 {
  Debug.Assert(!Object.ReferenceEquals(clrType,null));
  Debug.Assert(!Object.ReferenceEquals(storeTypeNameBase,null));

  Debug.Assert(!Object.ReferenceEquals(sm_UnderlyingTypeMapping,null));
  Debug.Assert(sm_UnderlyingTypeMapping.Size.HasValue);

  if(!Is(clrType))
   return false;

  if(!Is(storeTypeNameBase))
   return false;

  if(sm_UnderlyingTypeMapping.Size.Value!=size)
   return false;

  return true;
 }//Is - clrType, storeTypeNameBase, size

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
  Debug.Assert(sm_UnderlyingTypeMapping.IsFixedLength==true);
  Debug.Assert(sm_UnderlyingTypeMapping.Size.HasValue);
  Debug.Assert(sm_UnderlyingTypeMapping.Size.Value==16);

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

  Check.RelationalTypeMappingInfo__SizeIsNullOrExpected
   (c_ErrSrcID,
    mappingInfo,
    sm_UnderlyingTypeMapping.Size.Value);

  Check.RelationalTypeMappingInfo__IsFixedLength__optional
   (c_ErrSrcID,
    mappingInfo,
    sm_UnderlyingTypeMapping.IsFixedLength);

  Check.RelationalTypeMappingInfo__IsUnicode
   (c_ErrSrcID,
    mappingInfo,
    false);

  Check.RelationalTypeMappingInfo__PrecisionIsNull
   (c_ErrSrcID,
    mappingInfo);

  Check.RelationalTypeMappingInfo__ScaleIsNull
   (c_ErrSrcID,
    mappingInfo);

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
   ("FB_Common__TypeMapping__GUID__as_bytes::Clone(...)");
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

  return new FB_Common__TypeMapping__GUID__as_bytes(parameters);
 }//Clone

 //-----------------------------------------------------------------------
 protected override string GenerateNonNullSqlLiteral(object value)
 {
  Debug.Assert(!Object.ReferenceEquals(value,null));

  if(value.GetType()!=sm_UnderlyingTypeMapping.ClrType)
  {
   //ERROR - wrong value type

   ThrowError.ArgErr__BadValueType
     (c_ErrSrcID,
      nameof(GenerateNonNullSqlLiteral),
      nameof(value),
      value.GetType(),
      sm_UnderlyingTypeMapping.ClrType);
  }//if

  Debug.Assert(value.GetType()==sm_UnderlyingTypeMapping.ClrType);

  return sm_UnderlyingTypeMapping.GenerateProviderValueSqlLiteral(value);
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
      /*converter*/            ValueConversion.FB_Common__ValueConversion__GuidToBytes.Instance,
      /*comparer*/             null,
      /*keyComparer*/          null,
      /*valueGeneratorFactory*/null);

  var RTMP
   =new RelationalTypeMappingParameters
     (/*coreParameters*/   CTMP,
      /*storeType*/        sm_UnderlyingTypeMapping.StoreType,
      /*storeTypePostfix*/ StoreTypePostfix.None,
      /*dbType*/           sm_UnderlyingTypeMapping.DbType,
      /*unicode*/          false,
      /*size*/             null,
      /*fixedLength*/      true,
      /*precision*/        null,
      /*scale*/            null);

  return RTMP;
 }//Helper__CreateDefaultRTMP

 //private data ----------------------------------------------------------
 private static readonly Type sm_ClrType
  =Structure_TypeCache.TypeOf__System_Guid;

 //-----------------------------------------------------------------------
 private static readonly RelationalTypeMapping
  sm_UnderlyingTypeMapping
   =FB_Common__TypeMappingCache.TypeMapping__BINARY16;

 //-----------------------------------------------------------------------
 private static readonly RelationalTypeMapping
  sm_Instance
   =new FB_Common__TypeMapping__GUID__as_bytes
     (Helper__CreateDefaultRTMP());
};//class FB_Common__TypeMapping__GUID__as_bytes

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.Mapping

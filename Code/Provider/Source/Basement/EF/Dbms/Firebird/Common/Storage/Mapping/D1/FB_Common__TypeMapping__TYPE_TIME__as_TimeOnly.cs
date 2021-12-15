////////////////////////////////////////////////////////////////////////////////
//EF.Core Provider for LCPI OLE DB and Firebird.
//                                      IBProvider and Contributors. 01.07.2021.
using System;
using System.Diagnostics;
using System.Reflection;

using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.Mapping.D1{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_MethodInfoCache
 =Structure.Structure_MethodInfoCache;

using Structure_TypeCache
 =Structure.Structure_TypeCache;

using Structure_ADP
 =Structure.Structure_ADP;

using FB_Common__SqlDataTypeNames
 =Core.Engines.Dbms.Firebird.Common.FB_Common__SqlDataTypeNames;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__TypeMapping__TYPE_TIME__as_TimeOnly

sealed class FB_Common__TypeMapping__TYPE_TIME__as_TimeOnly
 :FB_Common__TypeMapping
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__TypeMapping_D1__TYPE_TIME__as_TimeOnly;

 //-----------------------------------------------------------------------
 private FB_Common__TypeMapping__TYPE_TIME__as_TimeOnly(in RelationalTypeMappingParameters parameters)
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
 public static bool Is(string storeTypeNameBase)
 {
  Debug.Assert(!Object.ReferenceEquals(storeTypeNameBase,null));

  return Structure_ADP.EqualDatabaseTypeName(storeTypeNameBase,c_StoreTypeNameBase);
 }//Is - storeTypeNameBase

 //-----------------------------------------------------------------------
 public static bool Is(Type clrType,string storeTypeNameBase)
 {
  Debug.Assert(!Object.ReferenceEquals(clrType,null));
  Debug.Assert(!Object.ReferenceEquals(storeTypeNameBase,null));

  if(!Is(clrType))
   return false;

  if(!Is(storeTypeNameBase))
   return false;

  return true;
 }//Is - clrType, storeTypeNameBase

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
    c_StoreTypeNameBase);

  Check.RelationalTypeMappingInfo__StoreTypeNameBase
   (c_ErrSrcID,
    mappingInfo,
    c_StoreTypeNameBase);

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

 //-----------------------------------------------------------------------
 protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
 {
  //Debug.Assert(!Object.ReferenceEquals(parameters,null));
  Debug.Assert(parameters.GetType().IsValueType);

#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__TypeMapping__TYPE_TIME__as_TimeOnly::Clone(...)");
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

  return new FB_Common__TypeMapping__TYPE_TIME__as_TimeOnly(parameters);
 }//Clone

 //-----------------------------------------------------------------------
 protected override string GenerateNonNullSqlLiteral(object value)
 {
  Debug.Assert(!Object.ReferenceEquals(value,null));

  if(value.GetType()!=sm_ClrType)
  {
   //ERROR - wrong value type

   ThrowError.ArgErr__BadValueType
     (c_ErrSrcID,
      nameof(GenerateNonNullSqlLiteral),
      nameof(value),
      value.GetType(),
      sm_ClrType);
  }//if

  Debug.Assert(value.GetType()==sm_ClrType);

  TimeOnly typedValue=(TimeOnly)value;

#if DEBUG
  Debug.Assert(Structure_ADP.DEBUG__TimeOnlyContainsValidSqlTime(typedValue));
#endif

  ThrowError.SqlGenErr__DefinitionOfValueInSqlNotSupported
   (c_ErrSrcID,
    c_StoreTypeNameBase); //throw!

  Debug.Assert(false);

  return null;
 }//GenerateNonNullSqlLiteral

 //-----------------------------------------------------------------------
 public override MethodInfo GetDataReaderMethod()
 {
  Debug.Assert(!Object.ReferenceEquals(Structure_MethodInfoCache.MethodInfoOf__LcpiDataOleDb__OleDbDataReader__GetTimeOnly,null));

  return Structure_MethodInfoCache.MethodInfoOf__LcpiDataOleDb__OleDbDataReader__GetTimeOnly;
 }//GetDataReaderMethod

 //FB_Common__TypeMapping interface --------------------------------------
 protected sealed override string Internal__GetStoreTypeNameBase()
 {
  return c_StoreTypeNameBase;
 }//Internal__GetStoreTypeNameBase

 //Helper methods --------------------------------------------------------
 private static RelationalTypeMappingParameters Helper__CreateDefaultRTMP()
 {
  var CTMP
   =new CoreTypeMappingParameters
     (/*clrType*/              sm_ClrType,
      /*converter*/            null,
      /*comparer*/             null,
      /*keyComparer*/          null,
      /*valueGeneratorFactory*/null);

  var RTMP
   =new RelationalTypeMappingParameters
     (/*coreParameters*/   CTMP,
      /*storeType*/        c_StoreTypeNameBase,
      /*storeTypePostfix*/ StoreTypePostfix.None,
      /*dbType*/           System.Data.DbType.Time,
      /*unicode*/          false,
      /*size*/             null,
      /*fixedLength*/      true,
      /*precision*/        null,
      /*scale*/            null);

  return RTMP;
 }//Helper__CreateDefaultRTMP

 //-----------------------------------------------------------------------
 private const string c_StoreTypeNameBase
  =FB_Common__SqlDataTypeNames.TYPE_TIME;

 //-----------------------------------------------------------------------
 private static readonly Type sm_ClrType
  =Structure_TypeCache.TypeOf__System_TimeOnly;

 //-----------------------------------------------------------------------
 private static readonly RelationalTypeMapping
  sm_Instance
   =new FB_Common__TypeMapping__TYPE_TIME__as_TimeOnly
     (Helper__CreateDefaultRTMP());
};//class FB_Common__TypeMapping__TYPE_TIME__as_TimeOnly

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.Mapping.D1

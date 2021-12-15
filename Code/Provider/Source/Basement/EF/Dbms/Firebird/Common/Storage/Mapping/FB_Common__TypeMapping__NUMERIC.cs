////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 29.05.2018.
using System;
using System.Diagnostics;
using System.Reflection;

using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.Mapping{
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
//class FB_Common__TypeMapping__NUMERIC

sealed class FB_Common__TypeMapping__NUMERIC
 :FB_Common__TypeMapping
 ,FB_Common__ITypeMapping__IsCompatiblyWithIdentity
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__TypeMapping__NUMERIC;

 //-----------------------------------------------------------------------
 private FB_Common__TypeMapping__NUMERIC(in RelationalTypeMappingParameters parameters)
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

  //Check.RelationalTypeMappingInfo__StoreTypeName
  // (c_ErrSrcID,
  //  mappingInfo,
  //  c_StoreTypeNameBase);

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

  Check.RelationalTypeMappingInfo__Precision_and_Scale__optional
   (c_ErrSrcID,
    mappingInfo,
    c_MaxNumericPrecision);

  Check.RelationalTypeMappingInfo__IsRowVersion
   (c_ErrSrcID,
    mappingInfo,
    false);

  Check.RelationalTypeMappingInfo__ClrType
   (c_ErrSrcID,
    mappingInfo,
    sm_ClrType);

  //----------------------------------------
  var parameters
   =Helper__CreateRTMP
     (mappingInfo.Precision,
      mappingInfo.Scale);

  return new FB_Common__TypeMapping__NUMERIC(parameters);
 }//Create - mappingInfo

 //-----------------------------------------------------------------------
 public static RelationalTypeMapping Create(int precision,
                                            int scale)
 {
  Debug.Assert(0<=scale);
  Debug.Assert(scale<=precision);
  Debug.Assert(precision<=Core.Engines.Dbms.IscBase.IscBase_Const.c_max_numeric_precision);

  var parameters=Helper__CreateRTMP(precision,scale);

  return new FB_Common__TypeMapping__NUMERIC(parameters);
 }//Create - precision, scale

 //FB_Common__ITypeMapping__IsCompatiblyWithIdentity interface -----------
 bool FB_Common__ITypeMapping__IsCompatiblyWithIdentity.IsCompatiblyWithIdentity()
 {
  if(!this.Precision.HasValue)
  {
   Debug.Assert(!this.Scale.HasValue);

   //No precision and no scale.
   return true;
  }//if

  Debug.Assert(this.Precision.HasValue);
  Debug.Assert(this.Precision.Value>0);

  if(!this.Scale.HasValue)
  {
   //No scale.
   return true;
  }//if

  Debug.Assert(this.Scale.HasValue);

  Debug.Assert(this.Scale.Value<=this.Precision.Value);

  if(this.Scale.Value==0)
  {
   //ZERO scale
   return true;
  }//if

  Debug.Assert(this.Scale.Value>0);

  return false;
 }//IsCompatiblyWithIdentity

 //RelationalTypeMapping interface ---------------------------------------
 protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
 {
  //Debug.Assert(!Object.ReferenceEquals(parameters,null));
  Debug.Assert(parameters.GetType().IsValueType);

#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__TypeMapping__NUMERIC::Clone(...)");
#endif

  // [2020-12-01] Research
  Debug.Assert(parameters.CoreParameters.ClrType == this.ClrType);
  Debug.Assert(parameters.FixedLength            == this.IsFixedLength);
  Debug.Assert(parameters.Unicode                == this.IsUnicode);
  Debug.Assert(parameters.DbType                 == this.DbType);
  Debug.Assert(parameters.StoreType              == this.StoreType);
  Debug.Assert(parameters.StoreTypePostfix       == this.StoreTypePostfix);
  Debug.Assert(parameters.Size                   == this.Size);

  HelperCheck.RelationalTypeMappingParameters__Precision_and_Scale__optional
   (c_ErrSrcID,
    parameters,
    Core.Engines.Dbms.IscBase.IscBase_Const.c_max_numeric_precision);

  //---------------------------------------- rebuild parameters
  var storeName
   =Helper__BuildStoreName
     (parameters.Precision,
      parameters.Scale);

  var RTMP
   =new RelationalTypeMappingParameters
     (/*coreParameters*/   parameters.CoreParameters,
      /*storeType*/        storeName,       // <----- NEW
      /*storeTypePostfix*/ parameters.StoreTypePostfix,
      /*dbType*/           parameters.DbType,
      /*unicode*/          parameters.Unicode,
      /*size*/             parameters.Size,
      /*fixedLength*/      parameters.FixedLength,
      /*precision*/        parameters.Precision,
      /*scale*/            parameters.Scale);

  //------------------------------------------------------------
  return new FB_Common__TypeMapping__NUMERIC(RTMP);
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
      this.ClrType);
  }//if

  Debug.Assert(value.GetType()==sm_ClrType);

  System.Decimal typedValue=(System.Decimal)value;

  var r
   =typedValue.ToString
     (FB_Common__TypeMappingConfig.CvtCulture);

  Debug.Assert(!string.IsNullOrEmpty(r));

  return r;
 }//GenerateNonNullSqlLiteral

 //-----------------------------------------------------------------------
 public override MethodInfo GetDataReaderMethod()
 {
  Debug.Assert(!Object.ReferenceEquals(Structure_MethodInfoCache.MethodInfoOf__SystemDataCommon__DbDataReader__GetDecimal,null));

  return Structure_MethodInfoCache.MethodInfoOf__SystemDataCommon__DbDataReader__GetDecimal;
 }//GetDataReaderMethod

 //FB_Common__TypeMapping interface --------------------------------------
 protected sealed override string Internal__GetStoreTypeNameBase()
 {
  return c_StoreTypeNameBase;
 }//Internal__GetStoreTypeNameBase

 //Helper methods --------------------------------------------------------
 private static RelationalTypeMappingParameters Helper__CreateRTMP
                                                  (Nullable<int> precision,
                                                   Nullable<int> scale)
 {
#if DEBUG
  if(!precision.HasValue)
  {
   Debug.Assert(!scale.HasValue);
  }
  else
  {
   Debug.Assert(precision.HasValue);
   Debug.Assert(precision.Value>0);
   Debug.Assert(precision.Value<=c_MaxNumericPrecision);

   if(scale.HasValue)
   {
    Debug.Assert(scale.Value>=0);
    Debug.Assert(scale.Value<=precision.Value);
   }//else
  }//else
#endif

  var CTMP
   =new CoreTypeMappingParameters
     (/*clrType*/              sm_ClrType,
      /*converter*/            null,
      /*comparer*/             null,
      /*keyComparer*/          null,
      /*valueGeneratorFactory*/null);

  //build: NUMERIC(precision,scale)
  var storeName
   =Helper__BuildStoreName
     (precision,
      scale);

  var RTMP
   =new RelationalTypeMappingParameters
     (/*coreParameters*/   CTMP,
      /*storeType*/        storeName,
      /*storeTypePostfix*/ StoreTypePostfix.None,
      /*dbType*/           System.Data.DbType.Decimal,
      /*unicode*/          false,
      /*size*/             null,
      /*fixedLength*/      true,
      /*precision*/        precision,
      /*scale*/            scale);

  return RTMP;
 }//Helper__CreateRTMP

 //-----------------------------------------------------------------------
 private static string Helper__BuildStoreName(Nullable<int> precision,
                                              Nullable<int> scale)
 {
  if(!precision.HasValue)
  {
   Debug.Assert(!scale.HasValue);

   return c_StoreTypeNameBase;
  }//if

  Debug.Assert(precision.HasValue);
  Debug.Assert(precision>0);

  //build: NUMERIC(precision,scale)
  var sb
   =new System.Text.StringBuilder
     (c_StoreTypeNameBase.Length+1+2+1+2+1);

  sb.Append(c_StoreTypeNameBase);
  sb.Append('(');
  sb.Append(precision.Value.ToString(FB_Common__TypeMappingConfig.CvtCulture));

  if(scale.HasValue)
  {
   Debug.Assert(scale.Value>=0);
   Debug.Assert(scale.Value<=precision.Value);

   sb.Append(',');
   sb.Append(scale.Value.ToString(FB_Common__TypeMappingConfig.CvtCulture));
  }//if

  sb.Append(')');

  return sb.ToString();
 }//Helper__BuildStoreName

 //-----------------------------------------------------------------------
 private const string c_StoreTypeNameBase
  =FB_Common__SqlDataTypeNames.NUMERIC;

 private const int c_MaxNumericPrecision
  =Core.Engines.Dbms.IscBase.IscBase_Const.c_max_numeric_precision;

 //-----------------------------------------------------------------------
 private static readonly Type sm_ClrType
  =Structure_TypeCache.TypeOf__System_Decimal;
};//class FB_Common__TypeMapping__NUMERIC

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.Mapping

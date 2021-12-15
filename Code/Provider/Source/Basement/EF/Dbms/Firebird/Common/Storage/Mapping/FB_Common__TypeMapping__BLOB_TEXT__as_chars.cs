////////////////////////////////////////////////////////////////////////////////
//EF.Core Provider for LCPI OLE DB and Firebird.
//                                      IBProvider and Contributors. 18.05.2018.
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
//class FB_Common__TypeMapping__BLOB_TEXT__as_chars

sealed class FB_Common__TypeMapping__BLOB_TEXT__as_chars
 :FB_Common__TypeMapping
 ,FB_Common__ITypeMapping__BLOB
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__TypeMapping__BLOB_TEXT__as_chars;

 //-----------------------------------------------------------------------
 private FB_Common__TypeMapping__BLOB_TEXT__as_chars(in RelationalTypeMappingParameters parameters)
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
 public static RelationalTypeMapping Create(string charsetName)
 {
  return Helper__Create(charsetName);
 }//Create

 //-----------------------------------------------------------------------
 public static RelationalTypeMapping Create(in RelationalTypeMappingInfo mappingInfo,
                                            string                       charsetName)
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

  //Check.RelationalTypeMappingInfo__StoreTypeNames
  // (c_ErrSrcID,
  //  mappingInfo,
  //  c_StoreTypeName);

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
    false);

  Check.RelationalTypeMappingInfo__IsUnicode
   (c_ErrSrcID,
    mappingInfo,
    true);

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

  return Helper__Create(charsetName);
 }//Create - mappingInfo

 //-----------------------------------------------------------------------
 private static RelationalTypeMapping Helper__Create(string charsetName)
 {
  Debug.Assert(!Object.ReferenceEquals(sm_Instance_default,null));

  if(Object.ReferenceEquals(charsetName,null))
   return sm_Instance_default;

  var parameters
   =Helper__CreateRTMP
     (charsetName);

  return new FB_Common__TypeMapping__BLOB_TEXT__as_chars(parameters);
 }//Helper__Create

 //-----------------------------------------------------------------------
 protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
 {
  //Debug.Assert(!Object.ReferenceEquals(parameters,null));
  Debug.Assert(parameters.GetType().IsValueType);

#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__TypeMapping__BLOB_TEXT__as_chars::Clone(...)");
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

  return new FB_Common__TypeMapping__BLOB_TEXT__as_chars(parameters);
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

  return FB_Common__Utilities.TextToSqlLiteral((char[])value);
 }//GenerateNonNullSqlLiteral

 //-----------------------------------------------------------------------
 public override MethodInfo GetDataReaderMethod()
 {
  Debug.Assert(!Object.ReferenceEquals(Structure_MethodInfoCache.MethodInfoOf__LcpiDataOleDb__OleDbDataReader__GetChars,null));

  return Structure_MethodInfoCache.MethodInfoOf__LcpiDataOleDb__OleDbDataReader__GetChars;
 }//GetDataReaderMethod

 //FB_Common__TypeMapping interface --------------------------------------
 protected sealed override string Internal__GetStoreTypeNameBase()
 {
  return c_StoreTypeNameBase;
 }//Internal__GetStoreTypeNameBase

 //Helper methods --------------------------------------------------------
 private static RelationalTypeMappingParameters Helper__CreateRTMP
                                                          (string charsetName)
 {
  var CTMP
   =new CoreTypeMappingParameters
     (/*clrType*/              sm_ClrType,
      /*converter*/            null,
      /*comparer*/             null,
      /*keyComparer*/          null,
      /*valueGeneratorFactory*/null);

  var storeTypeName
   =Helper__BuildStoreTypeName
     (charsetName);

  Debug.Assert(!string.IsNullOrEmpty(storeTypeName));

  var RTMP
   =new RelationalTypeMappingParameters
     (/*coreParameters*/   CTMP,
      /*storeType*/        storeTypeName,
      /*storeTypePostfix*/ StoreTypePostfix.None,
      /*dbType*/           System.Data.DbType.String,
      /*unicode*/          false,
      /*size*/             null,
      /*fixedLength*/      false,
      /*precision*/        null,
      /*scale*/            null);

  return RTMP;
 }//Helper__CreateRTMP

 //-----------------------------------------------------------------------
 private static string Helper__BuildStoreTypeName(string charsetName)
 {
  return FB_Common__TypeMappingHelpers.AppendCharSetName
          (c_StoreTypeNameBase+" SUB_TYPE TEXT",
           charsetName);
 }//Helper__BuildStoreTypeName
 
 //private data ----------------------------------------------------------
 private const string c_StoreTypeNameBase
  =FB_Common__SqlDataTypeNames.BLOB;

 //-----------------------------------------------------------------------
 private static readonly Type sm_ClrType
  =Structure_TypeCache.TypeOf__System_Array_Char;

 //-----------------------------------------------------------------------
 private static readonly RelationalTypeMapping
  sm_Instance_default
   =new FB_Common__TypeMapping__BLOB_TEXT__as_chars
     (Helper__CreateRTMP(null));
};//class FB_Common__TypeMapping__BLOB_TEXT__as_chars

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.Mapping

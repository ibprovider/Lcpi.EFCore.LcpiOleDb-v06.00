////////////////////////////////////////////////////////////////////////////////
//EF.Core Provider for LCPI OLE DB and Firebird.
//                                      IBProvider and Contributors. 28.05.2018.
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

using FB_Common__SqlDataTypeNames
 =Core.Engines.Dbms.Firebird.Common.FB_Common__SqlDataTypeNames;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__TypeMapping__BINARY

sealed class FB_Common__TypeMapping__BINARY
 :FB_Common__TypeMapping
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__TypeMapping__BINARY;

 //-----------------------------------------------------------------------
 private FB_Common__TypeMapping__BINARY(in RelationalTypeMappingParameters parameters)
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
 public static RelationalTypeMapping Create(int length)
 {
  Debug.Assert(length>0);
  Debug.Assert(length<=Core.Engines.Dbms.IscBase.IscBase_Const.c_max_char_size);

  var parameters
   =Helper__CreateRTMP
     (length);

  return new FB_Common__TypeMapping__BINARY(parameters);
 }//Create - length

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

  Check.RelationalTypeMappingInfo__SizeIsPositive
   (c_ErrSrcID,
    mappingInfo,
    Core.Engines.Dbms.IscBase.IscBase_Const.c_max_char_size);

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

  var parameters
   =Helper__CreateRTMP
     (mappingInfo.Size.Value);

  return new FB_Common__TypeMapping__BINARY(parameters);
 }//Create - mappingInfo

 //-----------------------------------------------------------------------
 protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
 {
  //Debug.Assert(!Object.ReferenceEquals(parameters,null));
  Debug.Assert(parameters.GetType().IsValueType);

#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__TypeMapping__BINARY::Clone(...)");
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

  return new FB_Common__TypeMapping__BINARY(parameters);
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

  return FB_Common__Utilities.BytesToSqlLiteral((byte[])value);
 }//GenerateNonNullSqlLiteral

 //-----------------------------------------------------------------------
 public override MethodInfo GetDataReaderMethod()
 {
  Debug.Assert(!Object.ReferenceEquals(Structure_MethodInfoCache.MethodInfoOf__LcpiDataOleDb__OleDbDataReader__GetBytes,null));

  return Structure_MethodInfoCache.MethodInfoOf__LcpiDataOleDb__OleDbDataReader__GetBytes;
 }//GetDataReaderMethod

 //FB_Common__TypeMapping interface --------------------------------------
 protected sealed override string Internal__GetStoreTypeNameBase()
 {
  return c_StoreTypeNameBase;
 }//Internal__GetStoreTypeNameBase

 //Helper methods --------------------------------------------------------
 private static RelationalTypeMappingParameters Helper__CreateRTMP(int length)
 {
  Debug.Assert(length>0);
  Debug.Assert(length<=Core.Engines.Dbms.IscBase.IscBase_Const.c_max_char_size);

  var CTMP
   =new CoreTypeMappingParameters
     (/*clrType*/              sm_ClrType,
      /*converter*/            null,
      /*comparer*/             null,
      /*keyComparer*/          null,
      /*valueGeneratorFactory*/null);

  var sb
   =new System.Text.StringBuilder
     (5+5+22);

  sb.Append(c_StoreTypeNameBase+'(');
  sb.Append(length);
  sb.Append(") CHARACTER SET OCTETS");

  var RTMP
   =new RelationalTypeMappingParameters
     (/*coreParameters*/   CTMP,
      /*storeType*/        sb.ToString(),
      /*storeTypePostfix*/ StoreTypePostfix.None,
      /*dbType*/           System.Data.DbType.Binary,
      /*unicode*/          false,
      /*size*/             length,
      /*fixedLength*/      true,
      /*precision*/        null,
      /*scale*/            null);

  return RTMP;
 }//Helper__CreateRTMP

 //private data ----------------------------------------------------------
 private const string c_StoreTypeNameBase
  =FB_Common__SqlDataTypeNames.CHAR;

 //-----------------------------------------------------------------------
 private static readonly Type sm_ClrType
  =Structure_TypeCache.TypeOf__System_Array_Byte;
};//class FB_Common__TypeMapping__BINARY

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.Mapping

////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 26.10.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Storage.D2{
////////////////////////////////////////////////////////////////////////////////

using T_FB_DATATYPE_DESCR
 =Core.Engines.Dbms.Firebird.Common.FB_Common__DataTypeDescr;

using T_FB_DATATYPE_ID
 =Core.Engines.Dbms.Firebird.Common.FB_Common__DataTypeID;

using T_FB_CHARSET_NAMES
 =Core.Engines.Dbms.Firebird.Common.FB_Common__CharSetNames;

using T_FB_CHARSET_UTILS
 =Core.Engines.Dbms.Firebird.Common.FB_Common__CharSetUtils;

using T_FB_BLOB_SUBTYPE_ID
 =Core.Engines.Dbms.Firebird.Common.FB_Common__BlobSubTypeID;

////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0_D2__TypeMappingSource__Base

abstract class FB_V03_0_0_D2__TypeMappingSource__Base
 :FB_V03_0_0__TypeMappingSource__Base
{
 private static ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_V03_0_0_D2__TypeMappingSource__Base;

 //-----------------------------------------------------------------------
 public FB_V03_0_0_D2__TypeMappingSource__Base(TypeMappingSourceDependencies           dependencies,
                                               RelationalTypeMappingSourceDependencies relationalDependencies)
  :base(dependencies,relationalDependencies)
 {
 }

 //FB_V03_0_0__TypeMappingSource__Base interface -------------------------
 protected override sealed RelationalTypeMapping Internal__FindMapping__ByStoreDataTypeInfo
                        (in T_FB_DATATYPE_DESCR       storeDataTypeInfo,
                         in RelationalTypeMappingInfo mappingInfo)
 {
  const string c_bugcheck_src
   ="FB_V03_0_0_D2__TypeMappingSource__Base::Internal__FindMapping__ByStoreDataTypeInfo";

  //------------------------------------------------------------
  if(!Object.ReferenceEquals(mappingInfo.ClrType,null) &&
     mappingInfo.Precision.HasValue &&
     mappingInfo.Scale.HasValue)
  {
   if(Common.Storage.Mapping.FB_Common__TypeMapping__TimeSpan__as_Decimal18_4.Is(mappingInfo.ClrType,mappingInfo.StoreTypeNameBase,mappingInfo.Precision.Value,mappingInfo.Scale.Value))
    return Internal__GetTypeMapping__TimeSpan__as_Decimal18_4(mappingInfo);
  }//if

  if(!Object.ReferenceEquals(mappingInfo.ClrType,null) &&
     mappingInfo.Size.HasValue)
  {
   if(Common.Storage.Mapping.FB_Common__TypeMapping__GUID__as_bytes.Is(mappingInfo.ClrType,mappingInfo.StoreTypeNameBase,mappingInfo.Size.Value))
    return Internal__GetTypeMapping__GUID__as_bytes(mappingInfo);
  }//if

  //------------------------------------------------------------
  if(storeDataTypeInfo.DataTypeID==T_FB_DATATYPE_ID.BLOB)
  {
   if(!storeDataTypeInfo.BlobSubTypeID.HasValue)
    return Internal__GetTypeMapping__BLOB_BINARY(mappingInfo);

   if(storeDataTypeInfo.BlobSubTypeID==T_FB_BLOB_SUBTYPE_ID.BINARY)
    return Internal__GetTypeMapping__BLOB_BINARY(mappingInfo);
  
   if(storeDataTypeInfo.BlobSubTypeID==T_FB_BLOB_SUBTYPE_ID.TEXT)
    return Helper__Select__BLOB__SUBTYPE_TEXT(storeDataTypeInfo,mappingInfo);

   //ERROR - unknown blob subtype ID!

   ThrowBugCheck.UnknownBlobSubTypeID
    (c_ErrSrcID,
     c_bugcheck_src,
     "#001",
     storeDataTypeInfo.BlobSubTypeID);

   Debug.Assert(false);
  }//if BLOB

  //------------------------------------------------------------
  if(storeDataTypeInfo.DataTypeID==T_FB_DATATYPE_ID.CHAR)
   return Helper__Select__CHAR(storeDataTypeInfo,mappingInfo);

  if(storeDataTypeInfo.DataTypeID==T_FB_DATATYPE_ID.VARCHAR)
   return Helper__Select__VARCHAR(storeDataTypeInfo,mappingInfo);

  //------------------------------------------------------------
  if(storeDataTypeInfo.DataTypeID==T_FB_DATATYPE_ID.BINARY)
   return Internal__GetTypeMapping__BINARY(mappingInfo);

  if(storeDataTypeInfo.DataTypeID==T_FB_DATATYPE_ID.VARBINARY)
   return Internal__GetTypeMapping__VARBINARY(mappingInfo);

  //------------------------------------------------------------
  if(storeDataTypeInfo.DataTypeID==T_FB_DATATYPE_ID.SMALLINT)
   return Internal__GetTypeMapping__SMALLINT(mappingInfo);

  if(storeDataTypeInfo.DataTypeID==T_FB_DATATYPE_ID.INTEGER)
   return Internal__GetTypeMapping__INTEGER(mappingInfo);

  if(storeDataTypeInfo.DataTypeID==T_FB_DATATYPE_ID.BIGINT)
   return Internal__GetTypeMapping__BIGINT(mappingInfo);

  if(storeDataTypeInfo.DataTypeID==T_FB_DATATYPE_ID.FLOAT)
   return Internal__GetTypeMapping__FLOAT(mappingInfo);

  if(storeDataTypeInfo.DataTypeID==T_FB_DATATYPE_ID.DOUBLE)
   return Internal__GetTypeMapping__DOUBLE(mappingInfo);

  if(storeDataTypeInfo.DataTypeID==T_FB_DATATYPE_ID.DECIMAL)
   return Internal__GetTypeMapping__DECIMAL(mappingInfo);

  if(storeDataTypeInfo.DataTypeID==T_FB_DATATYPE_ID.NUMERIC)
   return Internal__GetTypeMapping__NUMERIC(mappingInfo);

  if(storeDataTypeInfo.DataTypeID==T_FB_DATATYPE_ID.BOOLEAN)
   return Internal__GetTypeMapping__BOOLEAN(mappingInfo);

  if(storeDataTypeInfo.DataTypeID==T_FB_DATATYPE_ID.TIMESTAMP)
   return Internal__GetTypeMapping__TIMESTAMP(mappingInfo);

  if(storeDataTypeInfo.DataTypeID==T_FB_DATATYPE_ID.DATE)
   return Internal__GetTypeMapping__TYPE_DATE__as_DateOnly(mappingInfo);

  if(storeDataTypeInfo.DataTypeID==T_FB_DATATYPE_ID.TIME)
   return Internal__GetTypeMapping__TYPE_TIME__as_TimeOnly(mappingInfo);

  //
  // Expected that we processed all known DataTypeID
  //
  ThrowBugCheck.UnknownDataTypeID
   (c_ErrSrcID,
    c_bugcheck_src,
    "#002",
    storeDataTypeInfo.DataTypeID);

  return null;
 }//Internal__FindMapping__ByStoreDataTypeInfo

 //-----------------------------------------------------------------------
 protected override sealed RelationalTypeMapping Internal__FindMapping__ByClrType
                        (in RelationalTypeMappingInfo mappingInfo)
 {
  Debug.Assert(!Object.ReferenceEquals(mappingInfo.ClrType,null));

  //----------------------------------------------------------------------
  if(mappingInfo.Size.HasValue)
  {
   if(!mappingInfo.IsFixedLength.GetValueOrDefault(false))
   {   
    //VARIABLE LENGTH [PREFERED]

    if(Common.Storage.Mapping.FB_Common__TypeMapping__VARCHAR.Is(mappingInfo.ClrType))
     return Internal__GetTypeMapping__VARCHAR(mappingInfo,T_FB_CHARSET_NAMES.UTF8);

    if(Common.Storage.Mapping.FB_Common__TypeMapping__VARCHAR__as_chars.Is(mappingInfo.ClrType))
     return Internal__GetTypeMapping__VARCHAR__as_chars(mappingInfo,T_FB_CHARSET_NAMES.UTF8);

    if(Common.Storage.Mapping.FB_Common__TypeMapping__VARBINARY.Is(mappingInfo.ClrType))
     return Internal__GetTypeMapping__VARBINARY(mappingInfo);
   }
   else
   {
    //FIXED LENGTH

    if(Common.Storage.Mapping.FB_Common__TypeMapping__CHAR.Is(mappingInfo.ClrType))
     return Internal__GetTypeMapping__CHAR(mappingInfo,T_FB_CHARSET_NAMES.UTF8);

    if(Common.Storage.Mapping.FB_Common__TypeMapping__CHAR__as_chars.Is(mappingInfo.ClrType))
     return Internal__GetTypeMapping__CHAR__as_chars(mappingInfo,T_FB_CHARSET_NAMES.UTF8);

    if(Common.Storage.Mapping.FB_Common__TypeMapping__BINARY.Is(mappingInfo.ClrType))
     return Internal__GetTypeMapping__BINARY(mappingInfo);
   }//else
  }//if mappingInfo.Size.HasValue

  //----------------------------------------------------------------------
  if(Common.Storage.Mapping.FB_Common__TypeMapping__SMALLINT.Is(mappingInfo.ClrType))
   return Internal__GetTypeMapping__SMALLINT(mappingInfo);

  if(Common.Storage.Mapping.FB_Common__TypeMapping__INTEGER.Is(mappingInfo.ClrType))
   return Internal__GetTypeMapping__INTEGER(mappingInfo);

  if(Common.Storage.Mapping.FB_Common__TypeMapping__BIGINT.Is(mappingInfo.ClrType))
   return Internal__GetTypeMapping__BIGINT(mappingInfo);

  if(Common.Storage.Mapping.FB_Common__TypeMapping__FLOAT.Is(mappingInfo.ClrType))
   return Internal__GetTypeMapping__FLOAT(mappingInfo);

  if(Common.Storage.Mapping.FB_Common__TypeMapping__DOUBLE.Is(mappingInfo.ClrType))
   return Internal__GetTypeMapping__DOUBLE(mappingInfo);

  if(Common.Storage.Mapping.FB_Common__TypeMapping__DECIMAL.Is(mappingInfo.ClrType))
   return Internal__GetTypeMapping__DECIMAL(mappingInfo);

  if(Common.Storage.Mapping.FB_Common__TypeMapping__BOOLEAN.Is(mappingInfo.ClrType))
   return Internal__GetTypeMapping__BOOLEAN(mappingInfo);

  if(Common.Storage.Mapping.D3.FB_Common__TypeMapping__TYPE_DATE__as_DateOnly.Is(mappingInfo.ClrType))
   return Internal__GetTypeMapping__TYPE_DATE__as_DateOnly(mappingInfo);

  if(Common.Storage.Mapping.D3.FB_Common__TypeMapping__TYPE_TIME__as_TimeOnly.Is(mappingInfo.ClrType))
   return Internal__GetTypeMapping__TYPE_TIME__as_TimeOnly(mappingInfo);

  if(Common.Storage.Mapping.FB_Common__TypeMapping__TimeSpan__as_Decimal18_4.Is(mappingInfo.ClrType))
   return Internal__GetTypeMapping__TimeSpan__as_Decimal18_4(mappingInfo);

  if(Common.Storage.Mapping.FB_Common__TypeMapping__TIMESTAMP.Is(mappingInfo.ClrType))
   return Internal__GetTypeMapping__TIMESTAMP(mappingInfo);

  if(Common.Storage.Mapping.FB_Common__TypeMapping__GUID__as_bytes.Is(mappingInfo.ClrType))
   return Internal__GetTypeMapping__GUID__as_bytes(mappingInfo);

  if(Common.Storage.Mapping.FB_Common__TypeMapping__BLOB_TEXT.Is(mappingInfo.ClrType))
   return Internal__GetTypeMapping__BLOB_TEXT(mappingInfo,T_FB_CHARSET_NAMES.UTF8);

  //specific
  if(Common.Storage.Mapping.FB_Common__TypeMapping__BLOB_TEXT__as_chars.Is(mappingInfo.ClrType))
   return Internal__GetTypeMapping__BLOB_TEXT__as_chars(mappingInfo,T_FB_CHARSET_NAMES.UTF8);

  if(Common.Storage.Mapping.FB_Common__TypeMapping__BLOB_BINARY.Is(mappingInfo.ClrType))
   return Internal__GetTypeMapping__BLOB_BINARY(mappingInfo);

  //specific
  if(Common.Storage.Mapping.FB_Common__TypeMapping__CHAR1.Is(mappingInfo.ClrType))
   return Internal__GetTypeMapping__CHAR1(mappingInfo,T_FB_CHARSET_NAMES.UTF8);

  return null;
 }//Internal__FindMapping__ByClrType

 //Selector methods ------------------------------------------------------
 private RelationalTypeMapping Helper__Select__BLOB__SUBTYPE_TEXT
                        (in T_FB_DATATYPE_DESCR       storeDataTypeInfo,
                         in RelationalTypeMappingInfo mappingInfo)
 {
  Debug.Assert(storeDataTypeInfo.DataTypeID==T_FB_DATATYPE_ID.BLOB);
  Debug.Assert(storeDataTypeInfo.BlobSubTypeID==T_FB_BLOB_SUBTYPE_ID.TEXT);

  if(!Object.ReferenceEquals(storeDataTypeInfo.CharSetName,null))
  {
   //
   // Special case
   //
   if(T_FB_CHARSET_UTILS.TestCsName__Is_OCTETS(storeDataTypeInfo.CharSetName))
    return Internal__GetTypeMapping__BLOB_BINARY(mappingInfo);
  }//if storeDataTypeInfo.CharSetName!=null

  if(!Object.ReferenceEquals(mappingInfo.ClrType,null))
  {
   if(Common.Storage.Mapping.FB_Common__TypeMapping__BLOB_TEXT__as_chars.Is(mappingInfo.ClrType))
    return Internal__GetTypeMapping__BLOB_TEXT__as_chars(mappingInfo,storeDataTypeInfo.CharSetName);

   //
   // default
   //
   //if(Common.Storage.Mapping.FB_Common__TypeMapping__BLOB_TEXT.Is(mappingInfo.ClrType))
   // return Internal__GetTypeMapping__BLOB_TEXT(mappingInfo);
  }//if

  //default
  return Internal__GetTypeMapping__BLOB_TEXT(mappingInfo,storeDataTypeInfo.CharSetName);
 }//Helper__Select__BLOB__SUBTYPE_TEXT

 //-----------------------------------------------------------------------
 private RelationalTypeMapping Helper__Select__CHAR
                        (in T_FB_DATATYPE_DESCR       storeDataTypeInfo,
                         in RelationalTypeMappingInfo mappingInfo)
 {
  Debug.Assert(storeDataTypeInfo.DataTypeID==T_FB_DATATYPE_ID.CHAR);

  if(!Object.ReferenceEquals(storeDataTypeInfo.CharSetName,null))
  {
   //
   // Special case
   //
   if(T_FB_CHARSET_UTILS.TestCsName__Is_OCTETS(storeDataTypeInfo.CharSetName))
    return Internal__GetTypeMapping__BINARY(mappingInfo);
  }//if storeDataTypeInfo.CharSetName!=null

  if(!Object.ReferenceEquals(mappingInfo.ClrType,null))
  {
   if(Common.Storage.Mapping.FB_Common__TypeMapping__CHAR1.Is(mappingInfo.ClrType))
    return Internal__GetTypeMapping__CHAR1(mappingInfo,storeDataTypeInfo.CharSetName);

   if(Common.Storage.Mapping.FB_Common__TypeMapping__CHAR__as_chars.Is(mappingInfo.ClrType))
    return Internal__GetTypeMapping__CHAR__as_chars(mappingInfo,storeDataTypeInfo.CharSetName);

   //
   // default
   //
   //if(Common.Storage.Mapping.FB_Common__TypeMapping__CHAR.Is(mappingInfo.ClrType))
   // return Internal__GetTypeMapping__CHAR(mappingInfo);
  }//if

  //default
  return Internal__GetTypeMapping__CHAR(mappingInfo,storeDataTypeInfo.CharSetName);
 }//Helper__Select__CHAR

 //-----------------------------------------------------------------------
 private RelationalTypeMapping Helper__Select__VARCHAR
                        (in T_FB_DATATYPE_DESCR       storeDataTypeInfo,
                         in RelationalTypeMappingInfo mappingInfo)
 {
  Debug.Assert(storeDataTypeInfo.DataTypeID==T_FB_DATATYPE_ID.VARCHAR);

  if(!Object.ReferenceEquals(storeDataTypeInfo.CharSetName,null))
  {
   //
   // Special case
   //
   if(T_FB_CHARSET_UTILS.TestCsName__Is_OCTETS(storeDataTypeInfo.CharSetName))
    return Internal__GetTypeMapping__VARBINARY(mappingInfo);
  }//if storeDataTypeInfo.CharSetName!=null

  if(!Object.ReferenceEquals(mappingInfo.ClrType,null))
  {
   if(Common.Storage.Mapping.FB_Common__TypeMapping__VARCHAR__as_chars.Is(mappingInfo.ClrType))
    return Internal__GetTypeMapping__VARCHAR__as_chars(mappingInfo,storeDataTypeInfo.CharSetName);

   //
   // default
   //
   //if(Common.Storage.Mapping.FB_Common__TypeMapping__VARCHAR.Is(mappingInfo.ClrType))
   // return Internal__GetTypeMapping__VARCHAR(mappingInfo);
  }//if

  //default
  return Internal__GetTypeMapping__VARCHAR(mappingInfo,storeDataTypeInfo.CharSetName);
 }//Helper__Select__VARCHAR

 //Factory methods -------------------------------------------------------
protected abstract RelationalTypeMapping Internal__GetTypeMapping__BIGINT
                                           (in RelationalTypeMappingInfo mappingInfo);

 //-----------------------------------------------------------------------
 protected abstract RelationalTypeMapping Internal__GetTypeMapping__BINARY
                                           (in RelationalTypeMappingInfo mappingInfo);

 //-----------------------------------------------------------------------
 protected abstract RelationalTypeMapping Internal__GetTypeMapping__BLOB_BINARY
                                           (in RelationalTypeMappingInfo mappingInfo);

 //-----------------------------------------------------------------------
 protected abstract RelationalTypeMapping Internal__GetTypeMapping__BLOB_TEXT
                                           (in RelationalTypeMappingInfo mappingInfo,
                                            string                       charsetName);

 //-----------------------------------------------------------------------
 protected abstract RelationalTypeMapping Internal__GetTypeMapping__BLOB_TEXT__as_chars
                                           (in RelationalTypeMappingInfo mappingInfo,
                                            string                       charsetName);

 //-----------------------------------------------------------------------
 protected abstract RelationalTypeMapping Internal__GetTypeMapping__BOOLEAN
                                           (in RelationalTypeMappingInfo mappingInfo);

 //-----------------------------------------------------------------------
 protected abstract RelationalTypeMapping Internal__GetTypeMapping__CHAR
                                           (in RelationalTypeMappingInfo mappingInfo,
                                            string                       charsetName);

 //-----------------------------------------------------------------------
 protected abstract RelationalTypeMapping Internal__GetTypeMapping__CHAR__as_chars
                                           (in RelationalTypeMappingInfo mappingInfo,
                                            string                       charsetName);

 //-----------------------------------------------------------------------
 protected abstract RelationalTypeMapping Internal__GetTypeMapping__CHAR1
                                           (in RelationalTypeMappingInfo mappingInfo,
                                            string                       charsetName);

 //-----------------------------------------------------------------------
 protected abstract RelationalTypeMapping Internal__GetTypeMapping__DECIMAL
                                           (in RelationalTypeMappingInfo mappingInfo);

 //-----------------------------------------------------------------------
 protected abstract RelationalTypeMapping Internal__GetTypeMapping__DOUBLE
                                           (in RelationalTypeMappingInfo mappingInfo);

 //-----------------------------------------------------------------------
 protected abstract RelationalTypeMapping Internal__GetTypeMapping__FLOAT
                                           (in RelationalTypeMappingInfo mappingInfo);

 //-----------------------------------------------------------------------
 protected abstract RelationalTypeMapping Internal__GetTypeMapping__GUID__as_bytes
                                           (in RelationalTypeMappingInfo mappingInfo);

 //-----------------------------------------------------------------------
 protected abstract RelationalTypeMapping Internal__GetTypeMapping__INTEGER
                                           (in RelationalTypeMappingInfo mappingInfo);

 //-----------------------------------------------------------------------
 protected abstract RelationalTypeMapping Internal__GetTypeMapping__NUMERIC
                                           (in RelationalTypeMappingInfo mappingInfo);

 //-----------------------------------------------------------------------
 protected abstract RelationalTypeMapping Internal__GetTypeMapping__SMALLINT
                                           (in RelationalTypeMappingInfo mappingInfo);

 //-----------------------------------------------------------------------
 protected abstract RelationalTypeMapping Internal__GetTypeMapping__TimeSpan__as_Decimal18_4
                                           (in RelationalTypeMappingInfo mappingInfo);

 //-----------------------------------------------------------------------
 protected abstract RelationalTypeMapping Internal__GetTypeMapping__TIMESTAMP
                                           (in RelationalTypeMappingInfo mappingInfo);

 //-----------------------------------------------------------------------
 protected abstract RelationalTypeMapping Internal__GetTypeMapping__VARBINARY
                                           (in RelationalTypeMappingInfo mappingInfo);

 //-----------------------------------------------------------------------
 protected abstract RelationalTypeMapping Internal__GetTypeMapping__VARCHAR
                                           (in RelationalTypeMappingInfo mappingInfo,
                                            string                       charsetName);

 //-----------------------------------------------------------------------
 protected abstract RelationalTypeMapping Internal__GetTypeMapping__VARCHAR__as_chars
                                           (in RelationalTypeMappingInfo mappingInfo,
                                            string                       charsetName);

 //-----------------------------------------------------------------------
 protected abstract RelationalTypeMapping Internal__GetTypeMapping__TYPE_DATE__as_DateOnly
                                           (in RelationalTypeMappingInfo mappingInfo);

 //-----------------------------------------------------------------------
 protected abstract RelationalTypeMapping Internal__GetTypeMapping__TYPE_TIME__as_TimeOnly
                                           (in RelationalTypeMappingInfo mappingInfo);
};//class FB_V03_0_0_D2__TypeMappingSource__Base

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Storage.D2

////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 18.10.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Storage.D1{
////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0_D1__TypeMappingSourceForDML

sealed class FB_V03_0_0_D1__TypeMappingSourceForDML
 :FB_V03_0_0_D1__TypeMappingSource__Base
{
 public FB_V03_0_0_D1__TypeMappingSourceForDML(TypeMappingSourceDependencies           dependencies,
                                               RelationalTypeMappingSourceDependencies relationalDependencies)
  :base(dependencies,relationalDependencies)
 {
 }

 //Factory methods -------------------------------------------------------
 protected override RelationalTypeMapping Internal__GetTypeMapping__BIGINT
                                           (in RelationalTypeMappingInfo mappingInfo)
 {
  return Common.Storage.Mapping.FB_Common__TypeMapping__BIGINT.Create(mappingInfo);
 }//Internal__GetTypeMapping__BIGINT

 //-----------------------------------------------------------------------
 protected override RelationalTypeMapping Internal__GetTypeMapping__BINARY
                                           (in RelationalTypeMappingInfo mappingInfo)
 {
  return Common.Storage.Mapping.FB_Common__TypeMapping__BINARY.Create(mappingInfo);
 }//Internal__GetTypeMapping__BINARY

 //-----------------------------------------------------------------------
 protected override RelationalTypeMapping Internal__GetTypeMapping__BLOB_BINARY
                                           (in RelationalTypeMappingInfo mappingInfo)
 {
  return Common.Storage.Mapping.FB_Common__TypeMapping__BLOB_BINARY.Create(mappingInfo);
 }//Internal__GetTypeMapping__BLOB_BINARY

 //-----------------------------------------------------------------------
 protected override RelationalTypeMapping Internal__GetTypeMapping__BLOB_TEXT
                                           (in RelationalTypeMappingInfo mappingInfo,
                                            string                       charsetName)
 {
  return Common.Storage.Mapping.FB_Common__TypeMapping__BLOB_TEXT.Create
          (mappingInfo,
           charsetName);
 }//Internal__GetTypeMapping__BLOB_TEXT

 //-----------------------------------------------------------------------
 protected override RelationalTypeMapping Internal__GetTypeMapping__BLOB_TEXT__as_chars
                                           (in RelationalTypeMappingInfo mappingInfo,
                                            string                       charsetName)
 {
  return Common.Storage.Mapping.FB_Common__TypeMapping__BLOB_TEXT__as_chars.Create
          (mappingInfo,
           charsetName);
 }//Internal__GetTypeMapping__BLOB_TEXT__as_chars

 //-----------------------------------------------------------------------
 protected override RelationalTypeMapping Internal__GetTypeMapping__BOOLEAN
                                           (in RelationalTypeMappingInfo mappingInfo)
 {
  return Common.Storage.Mapping.FB_Common__TypeMapping__BOOLEAN.Create(mappingInfo);
 }//Internal__GetTypeMapping__BOOLEAN

 //-----------------------------------------------------------------------
 protected override RelationalTypeMapping Internal__GetTypeMapping__CHAR
                                           (in RelationalTypeMappingInfo mappingInfo,
                                            string                       charsetName)
 {
  return Common.Storage.Mapping.FB_Common__TypeMapping__CHAR.Create
          (mappingInfo,
           charsetName);
 }//Internal__GetTypeMapping__CHAR

 //-----------------------------------------------------------------------
 protected override RelationalTypeMapping Internal__GetTypeMapping__CHAR__as_chars
                                           (in RelationalTypeMappingInfo mappingInfo,
                                            string                       charsetName)
 {
  return Common.Storage.Mapping.FB_Common__TypeMapping__CHAR__as_chars.Create
          (mappingInfo,
           charsetName);
 }//Internal__GetTypeMapping__CHAR__as_chars

 //-----------------------------------------------------------------------
 protected override RelationalTypeMapping Internal__GetTypeMapping__CHAR1
                                           (in RelationalTypeMappingInfo mappingInfo,
                                            string                       charsetName)
 {
  return Common.Storage.Mapping.FB_Common__TypeMapping__CHAR1.Create
          (mappingInfo,
           charsetName);
 }//Internal__GetTypeMapping__CHAR1

 //-----------------------------------------------------------------------
 protected override RelationalTypeMapping Internal__GetTypeMapping__DECIMAL
                                           (in RelationalTypeMappingInfo mappingInfo)
 {
  return Common.Storage.Mapping.FB_Common__TypeMapping__DECIMAL.Create(mappingInfo);
 }//Internal__GetTypeMapping__DECIMAL

 //-----------------------------------------------------------------------
 protected override RelationalTypeMapping Internal__GetTypeMapping__DOUBLE
                                           (in RelationalTypeMappingInfo mappingInfo)
 {
  return Common.Storage.Mapping.FB_Common__TypeMapping__DOUBLE.Create(mappingInfo);
 }//Internal__GetTypeMapping__DOUBLE

 //-----------------------------------------------------------------------
 protected override RelationalTypeMapping Internal__GetTypeMapping__FLOAT
                                           (in RelationalTypeMappingInfo mappingInfo)
 {
  return Common.Storage.Mapping.FB_Common__TypeMapping__FLOAT.Create(mappingInfo);
 }//Internal__GetTypeMapping__FLOAT

 //-----------------------------------------------------------------------
 protected override RelationalTypeMapping Internal__GetTypeMapping__GUID__as_bytes
                                           (in RelationalTypeMappingInfo mappingInfo)
 {
  return Common.Storage.Mapping.FB_Common__TypeMapping__GUID__as_bytes.Create(mappingInfo);
 }//Internal__GetTypeMapping__GUID__as_bytes

 //-----------------------------------------------------------------------
 protected override RelationalTypeMapping Internal__GetTypeMapping__INTEGER
                                           (in RelationalTypeMappingInfo mappingInfo)
 {
  return Common.Storage.Mapping.FB_Common__TypeMapping__INTEGER.Create(mappingInfo);
 }//Internal__GetTypeMapping__INTEGER

 //-----------------------------------------------------------------------
 protected override RelationalTypeMapping Internal__GetTypeMapping__NUMERIC
                                           (in RelationalTypeMappingInfo mappingInfo)
 {
  return Common.Storage.Mapping.FB_Common__TypeMapping__NUMERIC.Create(mappingInfo);
 }//Internal__GetTypeMapping__NUMERIC

 //-----------------------------------------------------------------------
 protected override RelationalTypeMapping Internal__GetTypeMapping__SMALLINT
                                           (in RelationalTypeMappingInfo mappingInfo)
 {
  return Common.Storage.Mapping.FB_Common__TypeMapping__SMALLINT.Create(mappingInfo);
 }//Internal__GetTypeMapping__SMALLINT

 //-----------------------------------------------------------------------
 protected override RelationalTypeMapping Internal__GetTypeMapping__TimeSpan__as_Decimal9_4
                                           (in RelationalTypeMappingInfo mappingInfo)
 {
  return Common.Storage.Mapping.FB_Common__TypeMapping__TimeSpan__as_Decimal9_4.Create(mappingInfo);
 }//Internal__GetTypeMapping__TimeSpan__as_Decimal9_4

 //-----------------------------------------------------------------------
 protected override RelationalTypeMapping Internal__GetTypeMapping__TIMESTAMP
                                           (in RelationalTypeMappingInfo mappingInfo)
 {
  return Common.Storage.Mapping.FB_Common__TypeMapping__TIMESTAMP.Create(mappingInfo);
 }//Internal__GetTypeMapping__TIMESTAMP

 //-----------------------------------------------------------------------
 protected override RelationalTypeMapping Internal__GetTypeMapping__VARBINARY
                                           (in RelationalTypeMappingInfo mappingInfo)
 {
  return Common.Storage.Mapping.FB_Common__TypeMapping__VARBINARY.Create(mappingInfo);
 }//Internal__GetTypeMapping__VARBINARY

 //-----------------------------------------------------------------------
 protected override RelationalTypeMapping Internal__GetTypeMapping__VARCHAR
                                           (in RelationalTypeMappingInfo mappingInfo,
                                            string                       charsetName)
 {
  return Common.Storage.Mapping.FB_Common__TypeMapping__VARCHAR.Create
          (mappingInfo,
           charsetName);
 }//Internal__GetTypeMapping__VARCHAR

 //-----------------------------------------------------------------------
 protected override RelationalTypeMapping Internal__GetTypeMapping__VARCHAR__as_chars
                                           (in RelationalTypeMappingInfo mappingInfo,
                                            string                       charsetName)
 {
  return Common.Storage.Mapping.FB_Common__TypeMapping__VARCHAR__as_chars.Create
          (mappingInfo,
           charsetName);
 }//Internal__GetTypeMapping__VARCHAR__as_chars

 //-----------------------------------------------------------------------
 protected override RelationalTypeMapping Internal__GetTypeMapping__TYPE_DATE__as_DateOnly
                                           (in RelationalTypeMappingInfo mappingInfo)
 {
  return Common.Storage.Mapping.D1.FB_Common__TypeMapping__TYPE_DATE__as_DateOnly.Create(mappingInfo);
 }//Internal__GetTypeMapping__TYPE_DATE__as_DateOnly

 //-----------------------------------------------------------------------
 protected override RelationalTypeMapping Internal__GetTypeMapping__TYPE_TIME__as_TimeOnly
                                           (in RelationalTypeMappingInfo mappingInfo)
 {
  return Common.Storage.Mapping.D1.FB_Common__TypeMapping__TYPE_TIME__as_TimeOnly.Create(mappingInfo);
 }//Internal__GetTypeMapping__TYPE_TIME__as_TimeOnly
};//class FB_V03_0_0_D1__TypeMappingSourceForDML

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Storage.D1

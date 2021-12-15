////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 14.05.2018.
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Globalization;
using System.Data;

using System.Reflection;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore.Update;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

using com_lib=lcpi.lib.com;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_ADP
 =Structure.Structure_ADP;

using Structure_MethodId
 =Structure.Structure_MethodId;

using Structure_MemberId
 =Structure.Structure_MemberId;

////////////////////////////////////////////////////////////////////////////////
//class ThrowError

static class ThrowError
{
 public static void ArgErr__BadValueType(ErrSourceID errSrcID,
                                         string      methodName,
                                         string      paramName,
                                         Type        paramValueType,
                                         Type        expectedType)
 {
  // [2020-10-14] Tested.

  Debug.Assert(!string.IsNullOrEmpty(methodName));
  Debug.Assert(!string.IsNullOrEmpty(paramName));
  Debug.Assert(!Object.ReferenceEquals(paramValueType,null));
  Debug.Assert(!Object.ReferenceEquals(expectedType,null));

  Debug.Assert(paramValueType!=expectedType);

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_INVALIDARG,
      errSrcID,
      ErrMessageID.common_err__bad_argument_type_4);

  errRec
   .push(methodName)
   .push(paramName)
   .push(paramValueType)
   .push(expectedType);

  ThrowSysError.invalid_arg
   (errRec,
    paramName);
 }//ArgErr__BadValueType

 //-----------------------------------------------------------------------
 public static void ArgErr__StringLiteralContainsZeroChar
                                           (ErrSourceID errSrcID,
                                            string      paramName,
                                            int         position)
 {
  // [2020-10-14] Tested.

  Debug.Assert(!string.IsNullOrEmpty(paramName));
  Debug.Assert(position>=0);

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_INVALIDARG,
      errSrcID,
      ErrMessageID.common_err__zero_symbol_in_string_literal_1);

  errRec
   .push(position);

  ThrowSysError.invalid_arg
   (errRec,
    paramName);
 }//ArgErr__StringLiteralContainsZeroChar

 //-----------------------------------------------------------------------
 public static void ArgErr__BadListSize(ErrSourceID errSrcID,
                                        string      methodName,
                                        string      paramName,
                                        int         actualListSize)
 {
  Debug.Assert(!string.IsNullOrEmpty(methodName));
  Debug.Assert(methodName.Trim()==methodName);

  Debug.Assert(!string.IsNullOrEmpty(paramName));
  Debug.Assert(paramName.Trim()==paramName);

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_INVALIDARG,
      errSrcID,
      ErrMessageID.common_err__bad_argument_list_size_3);

  errRec
   .push(methodName)
   .push(paramName)
   .push(actualListSize);

  ThrowSysError.invalid_arg
   (errRec,
    paramName);
 }//ArgErr__BadListSize

 //-----------------------------------------------------------------------
 public static void ArgErr__BadListSize(ErrSourceID errSrcID,
                                        string      methodName,
                                        string      paramName,
                                        int         actualListSize,
                                        int         expectedListSize)
 {
  // [2020-10-21] Tested.

  Debug.Assert(!string.IsNullOrEmpty(methodName));
  Debug.Assert(methodName.Trim()==methodName);

  Debug.Assert(!string.IsNullOrEmpty(paramName));
  Debug.Assert(paramName.Trim()==paramName);

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_INVALIDARG,
      errSrcID,
      ErrMessageID.common_err__bad_argument_list_size_4);

  errRec
   .push(methodName)
   .push(paramName)
   .push(actualListSize)
   .push(expectedListSize);

  ThrowSysError.invalid_arg
   (errRec,
    paramName);
 }//ArgErr__BadListSize

 //-----------------------------------------------------------------------
 public static void FeatureNotSupported(ErrSourceID errSrcID,
                                        string      featureName)
 {
  // [2021-11-29] Tested.

  Debug.Assert(!string.IsNullOrEmpty(featureName));
  Debug.Assert(featureName.Trim()==featureName);

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.DB_E_NOTSUPPORTED,
      errSrcID,
      ErrMessageID.common_err__feature_not_supported__1);

  errRec
   .push(featureName);

  ThrowSysError.not_supported
   (errRec);
 }//FeatureNotSupported

 //-----------------------------------------------------------------------
 public static void FeatureNotSupported__DesignTimeServices
                                       (ErrSourceID errSrcID)
 {
  // [2021-11-29] Tested.

  FeatureNotSupported
   (errSrcID,
    LcpiOleDb__Common___FeatureNames.DesignTimeServices);
 }//FeatureNotSupported__DesignTimeServices

 //-----------------------------------------------------------------------
 public static void InvalidOp__DirectCallOfLinqMethodNotAllowed
                                           (ErrSourceID errSrcID,
                                            string      methodSign)
 {
  // [2020-10-14] Tested.

  Debug.Assert(!string.IsNullOrEmpty(methodSign));
  Debug.Assert(methodSign.Trim()==methodSign);

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.common_err__direct_call_of_linq_method_not_allowed_1);

  errRec
   .push(methodSign);

  ThrowSysError.invalid_operation
   (errRec);
 }//InvalidOp__DirectCallOfLinqMethodNotAllowed

 //-----------------------------------------------------------------------
 public static void NoSourceForLoadCnInfo(ErrSourceID errSrcID)
 {
  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.common_err__no_source_for_load_connection_info_0);

  ThrowSysError.invalid_operation(errRec);
 }//NoSourceForLoadCnInfo

 //-----------------------------------------------------------------------
 public static void UnknownDbmsName(ErrSourceID errSrcID,
                                    string      DbmsName)
 {
  // [2020-10-14] Tested.

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.common_err__unknown_dbms_name_1);

  exc
   .push(DbmsName)
   .raise();
 }//UnknownDbmsName

 //-----------------------------------------------------------------------
 public static void UnsupportedDbmsVersion(ErrSourceID errSrcID,
                                           string      DbmsName,
                                           Version     DbmsVersion)
 {
  // [2020-10-14] Tested.

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.common_err__unsupported_dbms_version_2);

  exc
   .push(DbmsName)
   .push(DbmsVersion)
   .raise();
 }//UnsupportedDbmsVersion

 //-----------------------------------------------------------------------
 public static void UnsupportedConnectionDialect(ErrSourceID errSrcID,
                                                 int         connectionDialect)
 {
  // [2020-10-14] Tested.

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.common_err__unsupported_connection_dialect_1);

  exc
   .push(connectionDialect)
   .raise();
 }//UnsupportedConnectionDialect

 //-----------------------------------------------------------------------
 public static void EmptyObjectName(ErrSourceID errSrcID)
 {
  // [2020-10-15] Tested.

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.common_err__empty_object_name_0);

  ThrowSysError.invalid_operation
   (errRec);
 }//EmptyObjectName

 //-----------------------------------------------------------------------
 public static void BadSymbolInUnquotedObjectName(ErrSourceID errSrcID,
                                                  string      name,
                                                  int         position)
 {
  // [2020-10-14] Tested.

  Debug.Assert(!Object.ReferenceEquals(name,null));
  Debug.Assert(position<name.Length);

  var errRec
   =new Core.Core_ExceptionRecord
    (com_lib.HResultCode.E_FAIL,
     errSrcID,
     ErrMessageID.common_err__bad_symbol_in_unquoted_object_name_2);

  errRec
   .push(position)
   .push((int)name[position]);

  ThrowSysError.invalid_operation
   (errRec);
 }//BadSymbolInUnquotedObjectName

 //-----------------------------------------------------------------------
 public static void BadSymbolInQuotedObjectName(ErrSourceID errSrcID,
                                                string      name,
                                                int         position)
 {
  // [2020-10-14] Tested.

  Debug.Assert(!Object.ReferenceEquals(name,null));
  Debug.Assert(position<name.Length);

  var errRec
   =new Core.Core_ExceptionRecord
    (com_lib.HResultCode.E_FAIL,
     errSrcID,
     ErrMessageID.common_err__bad_symbol_in_quoted_object_name_2);

  errRec
   .push(position)
   .push((int)name[position]);

  ThrowSysError.invalid_operation
   (errRec);
 }//BadSymbolInQuotedObjectName

 //-----------------------------------------------------------------------
 public static void NotDefinedNamedParameterPrefix(ErrSourceID errSrcID)
 {
  // [2020-10-14] Tested.

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.common_err__not_defined_cmd_parameter_prefix_0);

  ThrowSysError.invalid_operation
   (errRec);
 }//NotDefinedNamedParameterPrefix

 //-----------------------------------------------------------------------
 public static void BadFormatOfCmdParameterName(ErrSourceID errSrcID,
                                                string      cmdParameterName)
 {
  // [2021-09-02] Tested.

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.common_err__bad_cmd_parameter_name_format_1);

  errRec.push(cmdParameterName);

  ThrowSysError.invalid_operation
   (errRec);
 }//BadFormatOfCmdParameterName

 //-----------------------------------------------------------------------
 public static void BadFormatOfCmdParameterName_IncorrectPrefix
                                           (ErrSourceID errSrcID,
                                            string      cmdParameterName)
 {
  // [2021-09-02] Tested.

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.common_err__bad_cmd_parameter_name_format__incorrect_prefix_1);

  errRec.push(cmdParameterName);

  ThrowSysError.invalid_operation
   (errRec);
 }//BadFormatOfCmdParameterName_IncorrectPrefix

 //-----------------------------------------------------------------------
 public static void NoProviderConfigured(ErrSourceID errSrcID)
 {
  // [2020-10-14] Tested.

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.common_err__no_provider_configured_0);

  ThrowSysError.invalid_operation
   (errRec);
 }//NoProviderConfigured

 //-----------------------------------------------------------------------
 public static void MultipleProviderConfigured(ErrSourceID errSrcID)
 {
  // [2020-10-14] Tested.

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.common_err__multiple_provider_configured_0);

  ThrowSysError.invalid_operation
   (errRec);
 }//MultipleProviderConfigured

 //-----------------------------------------------------------------------
 public static void UnkColumnName(ErrSourceID           SrcID,
                                  System.Data.DataTable Table,
                                  string                ColumnName)
 {
  // [2020-10-14] Tested.

  Debug.Assert(!Object.ReferenceEquals(Table,null));
  Debug.Assert(!Object.ReferenceEquals(ColumnName,null));

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      SrcID,
      ErrMessageID.common_err__unk_column_name__2);

  exc
   .push(Table.TableName)
   .push(ColumnName)
   .raise();
 }//UnkColumnName

 //-----------------------------------------------------------------------
 public static void InvalidColumnValue(ErrSourceID         SrcID,
                                       System.Data.DataRow Row,
                                       int                 ColumnIndex)
 {
  // [2020-10-14] Tested.

  Debug.Assert(!Object.ReferenceEquals(Row,null));
  Debug.Assert(!Object.ReferenceEquals(Row.Table,null));
  Debug.Assert(!Object.ReferenceEquals(Row.Table.Columns,null));
  Debug.Assert(ColumnIndex>=0);
  Debug.Assert(ColumnIndex<Row.Table.Columns.Count);

  Debug.Assert(!Object.ReferenceEquals(Row.Table.Columns[ColumnIndex],null));

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      SrcID,
      ErrMessageID.common_err__invalid_column_value__4);

  exc
   .push(Row.Table.TableName)
   .push(ColumnIndex)
   .push(Row.Table.Columns[ColumnIndex].ColumnName)
   .push_object(Row[ColumnIndex])
   .raise();
 }//InvalidColumnValue

 //-----------------------------------------------------------------------
 public static void InvalidColumnValueType(ErrSourceID         SrcID,
                                           System.Data.DataRow Row,
                                           int                 ColumnIndex,
                                           Type                ExpectedType)
 {
  // [2020-10-14] Tested.

  Debug.Assert(!Object.ReferenceEquals(Row,null));
  Debug.Assert(!Object.ReferenceEquals(Row.Table,null));
  Debug.Assert(!Object.ReferenceEquals(Row.Table.Columns,null));
  Debug.Assert(ColumnIndex>=0);
  Debug.Assert(ColumnIndex<Row.Table.Columns.Count);
  Debug.Assert(!Object.ReferenceEquals(ExpectedType,null));

  Debug.Assert(!Object.ReferenceEquals(Row[ColumnIndex],null));

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      SrcID,
      ErrMessageID.common_err__invalid_column_value_type__5);

  exc
   .push(Row.Table.TableName)
   .push(ColumnIndex)
   .push(Row.Table.Columns[ColumnIndex].ColumnName)
   .push(Row[ColumnIndex].GetType())
   .push(ExpectedType)
   .raise();
 }//InvalidColumnValueType

 //-----------------------------------------------------------------------
 public static void UnsupportedDataTypesConversion
                                           (ErrSourceID         errSrcID,
                                            Type                sourceType,
                                            Type                targetType)
 {
  // [2020-10-14] Tested.

  Debug.Assert(!Object.ReferenceEquals(sourceType,null));
  Debug.Assert(!Object.ReferenceEquals(targetType,null));

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.DB_E_UNSUPPORTEDCONVERSION,
      errSrcID,
      ErrMessageID.common_err__unsupported_datatypes_conversion_2);

  errRec
   .push(sourceType)
   .push(targetType);

  ThrowSysError.invalid_operation(errRec);
 }//UnsupportedDataTypesConversion

 //-----------------------------------------------------------------------
 public static void FailedToConvertValueBetweenTypes__overflow
                                           (ErrSourceID         errSrcID,
                                            Type                sourceType,
                                            Type                targetType,
                                            Exception           innerException)
 {
  // [2020-10-14] Tested.

  Debug.Assert(!Object.ReferenceEquals(sourceType,null));
  Debug.Assert(!Object.ReferenceEquals(targetType,null));

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.DB_E_DATAOVERFLOW,
      errSrcID,
      ErrMessageID.common_err__cant_convert_value_between_types_2);

  errRec
   .push(sourceType)
   .push(targetType);

  ThrowSysError.overflow
   (errRec,
    innerException);
 }//FailedToConvertValueBetweenTypes__overflow

 //-----------------------------------------------------------------------
 public static void FailedToConvertValueBetweenTypes
                                           (ErrSourceID         errSrcID,
                                            Type                sourceType,
                                            Type                targetType,
                                            Exception           innerException)
 {
  Debug.Assert(!Object.ReferenceEquals(sourceType,null));
  Debug.Assert(!Object.ReferenceEquals(targetType,null));

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.DB_E_CANTCONVERTVALUE,
      errSrcID,
      ErrMessageID.common_err__cant_convert_value_between_types_2);

  errRec
   .push(sourceType)
   .push(targetType);

  ThrowSysError.invalid_operation
   (errRec,
    innerException);
 }//FailedToConvertValueBetweenTypes

 //-----------------------------------------------------------------------
 public static void FailedToConvertValueBetweenTypes
                                           (ErrSourceID         errSrcID,
                                            Type                sourceType,
                                            Type                targetType)
 {
  FailedToConvertValueBetweenTypes
   (errSrcID,
    sourceType,
    targetType,
    /*innerException*/null);
 }//FailedToConvertValueBetweenTypes

 //-----------------------------------------------------------------------
 public static void FailedToConvertValueBetweenTypes__OverflowInCalcOfNumberScale
                                           (ErrSourceID         errSrcID,
                                            Type                sourceType,
                                            Type                targetType)
 {
  var errRec1
   =new Core.Core_ExceptionRecord
     (lcpi.lib.com.HResultCode.DB_E_DATAOVERFLOW,
      errSrcID,
      ErrMessageID.common_err__overflow_in_number_scale_calculation_0);

  var exc1
   =new lcpi.lib.structure.exceptions.t_overflow_exception
     (errRec1);

  FailedToConvertValueBetweenTypes__overflow
   (errSrcID,
    sourceType,
    targetType,
    /*innerException*/exc1);
 }//FailedToConvertValueBetweenTypes__OverflowInCalcOfNumberScale

 //-----------------------------------------------------------------------
 public static void FailedToConvertValueBetweenTypes__overflow
                                           (ErrSourceID         errSrcID,
                                            Type                sourceType,
                                            Type                targetType)
 {
  // [2020-10-14] Tested.

  Debug.Assert(!Object.ReferenceEquals(sourceType,null));
  Debug.Assert(!Object.ReferenceEquals(targetType,null));

  FailedToConvertValueBetweenTypes__overflow
   (errSrcID,
    sourceType,
    targetType,
    /*innerException*/null);
 }//FailedToConvertValueBetweenTypes__overflow

 //-----------------------------------------------------------------------
 public static void TargetPropertyNotAcceptNullValue
                                           (ErrSourceID errSrcID)
 {
  // [2020-10-14] Tested.

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.DB_E_BADVALUES,
      errSrcID,
      ErrMessageID.common_err__target_property_not_accept_null_value_0);

  ThrowSysError.invalid_operation
   (errRec);
 }//TargetPropertyNotAcceptNullValue

 //-----------------------------------------------------------------------
 public static void FailedToProcessValue(ErrSourceID errSrcID,
                                         string      valueName,
                                         Exception   innerException)
 {
  // [2020-10-19] Tested.

  Debug.Assert(!string.IsNullOrEmpty(valueName));
  Debug.Assert(valueName.Trim()==valueName);
  Debug.Assert(!Object.ReferenceEquals(innerException,null));

  var exc
   =new LcpiOleDb__DataToolException
     (innerException);

  exc.add_error
   (com_lib.HResultCode.E_FAIL,
    errSrcID,
    ErrMessageID.common_err__failed_to_process_value_1);

  exc.push(valueName);

  exc.raise();
 }//FailedToProcessValue

 //-----------------------------------------------------------------------
 public static void  IndexOutOfRange<TA1,TA2>
                             (ErrSourceID    errSrcID,
                              TA1            index,
                              TA2            countOfElements)
 {
  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.common_err__index_out_of_range__2);

  errRec
   .push_object(index)
   .push_object(countOfElements);

  ThrowSysError.invalid_operation
   (errRec);
 }//IndexOutOfRange

 //-----------------------------------------------------------------------
 public static void EmptyListOfValues
                             (ErrSourceID errSrcID)
 {
  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.common_err__empty_list_of_values__0);

  ThrowSysError.invalid_operation
   (errRec);
 }//EmptyListOfValues

 //-----------------------------------------------------------------------
 public static void MethodNotSupported
                             (ErrSourceID   srcID,
                              System.Type   declaringType,
                              string        methodName,
                              System.Type[] parameterTypes)
 {
  Debug.Assert(!Object.ReferenceEquals(declaringType,null));
  Debug.Assert(!Object.ReferenceEquals(methodName,null));
  Debug.Assert(!Object.ReferenceEquals(parameterTypes,null));

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      srcID,
      ErrMessageID.common_err__type_not_support_method_3);

  errRec
   .push(declaringType)
   .push(methodName)
   .push(Structure_ADP.BuildParamsSign(parameterTypes));

  ThrowSysError.invalid_operation
   (errRec);
 }//MethodNotSupported

 //-----------------------------------------------------------------------
 public static void CantRemapNormalMethodCall
                             (ErrSourceID   errSrcID,
                              MethodInfo    method,
                              System.Type   new_DeclaringType,
                              System.Type[] new_Parameters)
 {
  Debug.Assert(!Object.ReferenceEquals(method,null));
  Debug.Assert(!Object.ReferenceEquals(new_DeclaringType,null));
  Debug.Assert(!Object.ReferenceEquals(new_Parameters,null));

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.common_err__cant_remap_normal_method_3);

  errRec
   .push(method)
   .push(new_DeclaringType)
   .push(Structure_ADP.BuildParamsSign(new_Parameters));

  ThrowSysError.invalid_operation(errRec);
 }//CantRemapNormalMethodCall

 //-----------------------------------------------------------------------
 public static void CantRemapGenericMethodCall
                             (ErrSourceID   errSrcID,
                              MethodInfo    method,
                              System.Type   new_DeclaringType,
                              System.Type[] new_Parameters,
                              System.Type[] new_GenericArgs)
 {
  Debug.Assert(!Object.ReferenceEquals(method,null));
  Debug.Assert(!Object.ReferenceEquals(new_DeclaringType,null));
  Debug.Assert(!Object.ReferenceEquals(new_Parameters,null));
  Debug.Assert(!Object.ReferenceEquals(new_GenericArgs,null));
  Debug.Assert(new_GenericArgs.Length>0);

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.common_err__cant_remap_generic_method_4);

  errRec
   .push(method)
   .push(new_DeclaringType)
   .push(Structure_ADP.BuildParamsSign(new_Parameters))
   .push(Structure_ADP.BuildParamsSign(new_GenericArgs));

  ThrowSysError.invalid_operation
   (errRec);
 }//CantRemapGenericMethodCall

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__CantMapClrTypeToProviderDatatype
                                           (ErrSourceID errSrcID,
                                            Type        clrType)
 {
  // [2020-10-14] Tested.

  Debug.Assert(!Object.ReferenceEquals(clrType,null));

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.type_mapping_err__cant_map_clr_type_to_provider_data_type_1);

  errRec
   .push(clrType);

  ThrowSysError.invalid_operation
   (errRec);
 }//TypeMappingErr__CantMapClrTypeToProviderDatatype

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__CantMapInfoToProviderDatatype
                                           (ErrSourceID errSrcID,
                                            Type        clrType,
                                            string      baseTypeName)
 {
  // [2020-10-14] Tested.

  Debug.Assert(!Object.ReferenceEquals(clrType,null));

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.type_mapping_err__cant_map_info_to_provider_data_type_2);

  errRec
   .push(clrType)
   .push(baseTypeName);

  ThrowSysError.invalid_operation
   (errRec);
 }//TypeMappingErr__CantMapInfoToProviderDatatype

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__UnknownStoreTypeName
                                           (ErrSourceID errSrcID,
                                            string      storeTypeName)
 {
  // [2021-10-22] Tested.

  Debug.Assert(!Object.ReferenceEquals(storeTypeName,null));

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.type_mapping_err__unknown_StoreTypeName_1);

  exc
   .push(storeTypeName)
   .raise();
 }//TypeMappingErr__UnknownStoreTypeName

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__UnknownStoreTypeName
                                           (ErrSourceID errSrcID,
                                            string      storeTypeName,
                                            string      columnSign)
 {
  // [2021-11-30] Tested.

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.type_mapping_err__unknown_StoreTypeName_2);

  exc
   .push(storeTypeName)
   .push(columnSign)
   .raise();
 }//TypeMappingErr__UnknownStoreTypeName

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__UnknownStoreTypeName
                            (ErrSourceID errSrcID,
                             string      storeTypeName,
                             string      columnName,
                             string      tableName,
                             string      schema)
 {
  // [2021-11-30] Tested.

  var columnSign='{'+columnName+'}';

  if(!Object.ReferenceEquals(tableName,null))
  {
   columnSign='{'+tableName+"}."+columnSign;

   if(!Object.ReferenceEquals(schema,null))
   {
    columnSign='{'+schema+"}."+columnSign;
   }//if
  }//if

  TypeMappingErr__UnknownStoreTypeName
   (errSrcID,
    storeTypeName,
    columnSign);
 }//TypeMappingErr__UnknownStoreTypeName

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__UnexpectedStoreTypeName
                                           (ErrSourceID errSrcID,
                                            string      actualName,
                                            string      expectedName)
 {
  // [2020-10-14] Tested.

  Debug.Assert(!Object.ReferenceEquals(actualName,null));
  Debug.Assert(!Object.ReferenceEquals(expectedName,null));

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.type_mapping_err__unexpected_StoreTypeName_2);

  exc
   .push(actualName)
   .push(expectedName)
   .raise();
 }//TypeMappingErr__UnexpectedStoreTypeName

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__UnexpectedStoreTypeNameBase
                                           (ErrSourceID errSrcID,
                                            string      actualName,
                                            string      expectedName)
 {
  // [2020-10-14] Tested.

  Debug.Assert(!Object.ReferenceEquals(actualName,null));
  Debug.Assert(!Object.ReferenceEquals(expectedName,null));

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.type_mapping_err__unexpected_StoreTypeNameBase_2);

  exc
   .push(actualName)
   .push(expectedName)
   .raise();
 }//TypeMappingErr__UnexpectedStoreTypeNameBase

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__UnexpectedSize
                                           (ErrSourceID errSrcID,
                                            int         size)
 {
  // [2020-10-14] Tested.

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.type_mapping_err__unexpected_Size_1);

  exc
   .push(size)
   .raise();
 }//TypeMappingErr__UnexpectedSize

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__NotDefinedSize
                                           (ErrSourceID errSrcID)
 {
  // [2020-10-14] Tested.

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.type_mapping_err__not_defined_Size_0);

  exc.raise();
 }//TypeMappingErr__NotDefinedSize

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__TooLargeSize
                                           (ErrSourceID errSrcID,
                                            int         actualSize,
                                            int         maxSize)
 {
  // [2020-10-14] Tested.

  Debug.Assert(maxSize<actualSize);

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.type_mapping_err__too_large_Size_2);

  exc
   .push(actualSize)
   .push(maxSize)
   .raise();
 }//TypeMappingErr__TooLargeSize

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__UnexpectedIsFixedLength
                                           (ErrSourceID errSrcID,
                                            bool        actualValue,
                                            bool        expectedValue)
 {
  Debug.Assert(actualValue!=expectedValue);

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.type_mapping_err__unexpected_IsFixedLength_2);

  exc
   .push(actualValue)
   .push(expectedValue)
   .raise();
 }//TypeMappingErr__UnexpectedIsFixedLength

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__UnexpectedIsUnicode
                                           (ErrSourceID errSrcID,
                                            bool        actualValue,
                                            bool        expectedValue)
 {
  // [2020-10-14] Tested.

  Debug.Assert(actualValue!=expectedValue);

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.type_mapping_err__unexpected_IsUnicode_2);

  exc
   .push(actualValue)
   .push(expectedValue)
   .raise();
 }//TypeMappingErr__UnexpectedIsUnicode

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__UnexpectedClrType
                                           (ErrSourceID errSrcID,
                                            Type        actualClrType,
                                            Type        expectedClrType)
 {
  // [2020-10-14] Tested.

  Debug.Assert(!Object.ReferenceEquals(actualClrType,null));
  Debug.Assert(!Object.ReferenceEquals(expectedClrType,null));

  Debug.Assert(actualClrType!=expectedClrType);

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.type_mapping_err__unexpected_ClrType_2);

  exc
   .push(actualClrType)
   .push(expectedClrType)
   .raise();
 }//TypeMappingErr__UnexpectedClrType

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__UnexpectedIsRowVersion
                                           (ErrSourceID errSrcID,
                                            bool        actualValue,
                                            bool        expectedValue)
 {
  // [2020-10-14] Tested.

  Debug.Assert(actualValue!=expectedValue);

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.type_mapping_err__unexpected_IsRowVersion_2);

  exc
   .push(actualValue)
   .push(expectedValue)
   .raise();
 }//TypeMappingErr__UnexpectedIsRowVersion

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__UnexpectedPrecision
                                           (ErrSourceID errSrcID,
                                            int         precision)
 {
  // [2020-10-14] Tested.

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.type_mapping_err__unexpected_Precision_1);

  exc
   .push(precision)
   .raise();
 }//TypeMappingErr__UnexpectedPrecision

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__NotDefinedPrecision
                                           (ErrSourceID errSrcID)
 {
  // [2020-10-14] Tested.

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.type_mapping_err__not_defined_Precision_0);

  exc.raise();
 }//TypeMappingErr__NotDefinedPrecision

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__TooLargePrecision
                                           (ErrSourceID errSrcID,
                                            int         actualPrecision,
                                            int         maxPrecision)
 {
  // [2020-10-14] Tested.

  Debug.Assert(maxPrecision<actualPrecision);

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.type_mapping_err__too_large_Precision_2);

  exc
   .push(actualPrecision)
   .push(maxPrecision)
   .raise();
 }//TypeMappingErr__TooLargePrecision

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__NotAllowedDefinitionOfScaleWithoutPrecision
                                           (ErrSourceID errSrcID,
                                            int         scale)
 {
  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.type_mapping_err__not_allowed_definition_of_Scale_without_Precision_1);

  exc
   .push(scale)
   .raise();
 }//TypeMappingErr__NotAllowedDefinitionOfScaleWithoutPrecision

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__UnexpectedScale
                                           (ErrSourceID errSrcID,
                                            int         scale)
 {
  // [2020-10-14] Tested.

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.type_mapping_err__unexpected_Scale_1);

  exc
   .push(scale)
   .raise();
 }//TypeMappingErr__UnexpectedScale

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__NotDefinedScale
                                           (ErrSourceID errSrcID)
 {
  // [2020-10-14] Tested.

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.type_mapping_err__not_defined_Scale_0);

  exc.raise();
 }//TypeMappingErr__NotDefinedScale

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__TooLargeScale
                                           (ErrSourceID errSrcID,
                                            int         actualScale,
                                            int         maxScale)
 {
  // [2020-10-14] Tested.

  Debug.Assert(maxScale<actualScale);

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.type_mapping_err__too_large_Scale_2);

  exc
   .push(actualScale)
   .push(maxScale)
   .raise();
 }//TypeMappingErr__TooLargeScale

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__CantConvertTimeSpanToDatabaseFormat__OutOfRange
                                           (ErrSourceID     errSrcID,
                                            System.TimeSpan actualValue,
                                            string          databaseTypeName,
                                            System.TimeSpan minValidValue,
                                            System.TimeSpan maxValidValue)
 {
  // [2021-09-29] Tested.

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.type_mapping_err__cant_convert_TimeSpan_to_database_format__out_of_range__4);

  exc
   .push(actualValue)
   .push(databaseTypeName)
   .push(minValidValue)
   .push(maxValidValue)
   .raise();
 }//TypeMappingErr__CantConvertTimeSpanToDatabaseFormat__OutOfRange

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__CantConvertDatabaseValueToTimeSpan__OutOfRange
                                           (ErrSourceID     errSrcID,
                                            System.Decimal  actualValue,
                                            string          databaseTypeName,
                                            System.Decimal  minValidValue,
                                            System.Decimal  maxValidValue)
 {
  // [2021-09-29] Tested.

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.type_mapping_err__cant_convert_database_value_to_TimeSpan__out_of_range__4);

  exc
   .push(actualValue)
   .push(databaseTypeName)
   .push(minValidValue)
   .push(maxValidValue)
   .raise();
 }//TypeMappingErr__CantConvertDatabaseValueToTimeSpan__OutOfRange

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__CnDialectNotAllowUsageTypeInDDL
                                           (ErrSourceID     errSrcID,
                                            long            connectionDialect,
                                            string          databaseTypeName)
 {
  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.type_mapping_err__cn_dialect_does_not_support_usage_of_type_in_DDL_query_2);

  exc
   .push(connectionDialect)
   .push(databaseTypeName)
   .raise();
 }//TypeMappingErr__CnDialectNotAllowUsageTypeInDDL

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__MultipleDefinitionOfTypeProperty
                                           (ErrSourceID errSrcID,
                                            string      propertyName,
                                            object      propertyValue1,
                                            object      propertyValue2)
 {
  // [2021-10-22] Tested.

  Debug.Assert(!Object.ReferenceEquals(propertyName,null));
  Debug.Assert(propertyName.Length>0);
  Debug.Assert(propertyName.Trim()==propertyName);

  var errRec
   =ErrorRecordCreator.TypeMappingErr__MultipleDefinitionOfTypeProperty
      (errSrcID,
       propertyName,
       propertyValue1,
       propertyValue2);

  var exc
   =new LcpiOleDb__DataToolException
     (errRec);

  exc.raise();
 }//TypeMappingErr__MultipleDefinitionOfTypeProperty

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__FailedToParseDataTypeLength
                                           (ErrSourceID errSrcID,
                                            string      dataTypeSign)
 {
  // [2021-10-22] Tested.

  Debug.Assert(!Object.ReferenceEquals(dataTypeSign,null));
  Debug.Assert(dataTypeSign.Length>0);
  Debug.Assert(dataTypeSign.Trim()==dataTypeSign);

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.type_mapping_err__failed_to_parse_datatype_length_1);

  exc
   .push(dataTypeSign)
   .raise();
 }//TypeMappingErr__FailedToParseDataTypeLength

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__FailedToParseDataTypePrecision
                                           (ErrSourceID errSrcID,
                                            string      dataTypeSign)
 {
  // [2021-10-22] Tested.

  Debug.Assert(!Object.ReferenceEquals(dataTypeSign,null));
  Debug.Assert(dataTypeSign.Length>0);
  Debug.Assert(dataTypeSign.Trim()==dataTypeSign);

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.type_mapping_err__failed_to_parse_datatype_precision_1);

  exc
   .push(dataTypeSign)
   .raise();
 }//TypeMappingErr__FailedToParseDataTypePrecision

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__FailedToParseDataTypeScale
                                           (ErrSourceID errSrcID,
                                            string      dataTypeSign)
 {
  // [2021-10-22] Tested.

  Debug.Assert(!Object.ReferenceEquals(dataTypeSign,null));
  Debug.Assert(dataTypeSign.Length>0);
  Debug.Assert(dataTypeSign.Trim()==dataTypeSign);

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.type_mapping_err__failed_to_parse_datatype_scale_1);

  exc
   .push(dataTypeSign)
   .raise();
 }//TypeMappingErr__FailedToParseDataTypeScale

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__TooLargeLengthOfDataType
                                           (ErrSourceID errSrcID,
                                            string      dataTypeSign)
 {
  // [2021-10-22] Tested.

  Debug.Assert(!Object.ReferenceEquals(dataTypeSign,null));
  Debug.Assert(dataTypeSign.Length>0);
  Debug.Assert(dataTypeSign.Trim()==dataTypeSign);

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.type_mapping_err__too_large_length_of_datatype_1);

  exc
   .push(dataTypeSign)
   .raise();
 }//TypeMappingErr__TooLargeLengthOfDataType

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__TooLargePrecisionOfDataType
                                           (ErrSourceID errSrcID,
                                            string      dataTypeSign)
 {
  // [2021-10-22] Tested.

  Debug.Assert(!Object.ReferenceEquals(dataTypeSign,null));
  Debug.Assert(dataTypeSign.Length>0);
  Debug.Assert(dataTypeSign.Trim()==dataTypeSign);

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.type_mapping_err__too_large_precision_of_datatype_1);

  exc
   .push(dataTypeSign)
   .raise();
 }//TypeMappingErr__TooLargePrecisionOfDataType

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__TooLargeScaleOfDataType
                                           (ErrSourceID errSrcID,
                                            string      dataTypeSign)
 {
  // [2021-10-22] Tested.

  Debug.Assert(!Object.ReferenceEquals(dataTypeSign,null));
  Debug.Assert(dataTypeSign.Length>0);
  Debug.Assert(dataTypeSign.Trim()==dataTypeSign);

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.type_mapping_err__too_large_scale_of_datatype_1);

  exc
   .push(dataTypeSign)
   .raise();
 }//TypeMappingErr__TooLargeScaleOfDataType

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__IncompletedDataTypeDefinition
                                           (ErrSourceID errSrcID)
 {
  // [2021-10-22] Tested.

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.type_mapping_err__incompleted_datatype_definition_0);

  exc
   .raise();
 }//TypeMappingErr__IncompletedDataTypeDefinition

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__IncompletedDataTypeDefinition
                                           (ErrSourceID errSrcID,
                                            string      dataTypeSign)
 {
  // [2021-10-22] Tested.

  Debug.Assert(!Object.ReferenceEquals(dataTypeSign,null));
  Debug.Assert(dataTypeSign.Length>0);
  Debug.Assert(dataTypeSign.Trim()==dataTypeSign);

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.type_mapping_err__incompleted_datatype_definition_1);

  exc
   .push(dataTypeSign)
   .raise();
 }//TypeMappingErr__IncompletedDataTypeDefinition

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__BadDataTypeDefinition
                                           (ErrSourceID errSrcID,
                                            string      dataTypeSign)
 {
  // [2021-10-22] Tested.

  Debug.Assert(!Object.ReferenceEquals(dataTypeSign,null));
  Debug.Assert(dataTypeSign.Length>0);
  Debug.Assert(dataTypeSign.Trim()==dataTypeSign);

  var errRec
   =ErrorRecordCreator.TypeMappingErr__BadDataTypeDefinition
     (errSrcID,
      dataTypeSign);

  Debug.Assert(!Object.ReferenceEquals(errRec,null));

  var exc
   =new LcpiOleDb__DataToolException
     (errRec);

  exc.raise();
 }//TypeMappingErr__BadDataTypeDefinition

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__NoCharSetName
                                           (ErrSourceID errSrcID,
                                            string      dataTypeSign)
 {
  // [2021-10-22] Tested.

  Debug.Assert(!Object.ReferenceEquals(dataTypeSign,null));
  Debug.Assert(dataTypeSign.Length>0);
  Debug.Assert(dataTypeSign.Trim()==dataTypeSign);

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.type_mapping_err__not_defined_charset_name_1);

  exc
   .push(dataTypeSign)
   .raise();
 }//TypeMappingErr__NoCharSetName

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__NoSubTypeName
                                           (ErrSourceID errSrcID,
                                            string      dataTypeSign)
 {
  // [2021-10-22] Tested.

  Debug.Assert(!Object.ReferenceEquals(dataTypeSign,null));
  Debug.Assert(dataTypeSign.Length>0);
  Debug.Assert(dataTypeSign.Trim()==dataTypeSign);

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.type_mapping_err__not_defined_subtype_name_1);

  exc
   .push(dataTypeSign)
   .raise();
 }//TypeMappingErr__NoSubTypeName

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__UnknownBlobSubType
                                           (ErrSourceID errSrcID,
                                            string      blobSubType)
 {
  // [2021-10-22] Tested.

  Debug.Assert(!Object.ReferenceEquals(blobSubType,null));
  Debug.Assert(blobSubType.Length>0);
  Debug.Assert(blobSubType.Trim()==blobSubType);

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.type_mapping_err__unknown_blob_subtype_1);

  exc
   .push(blobSubType)
   .raise();
 }//TypeMappingErr__UnknownBlobSubType

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__DefinitionOfBlobCharsetAllowedOnlyForSubTypeText
                                           (ErrSourceID errSrcID)
 {
  // [2021-10-22] Tested.

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.type_mapping_err__definition_of_blob_charset_allowed_only_for_subtype_text_0);

  exc.raise();
 }//TypeMappingErr__DefinitionOfBlobCharsetAllowedOnlyForSubTypeText

 //-----------------------------------------------------------------------
 public static void TypeMappingErr__UnexpectedDataAtEndOfDataTypeDefinition
                                           (ErrSourceID errSrcID,
                                            string      dataTypeSign)
 {
  // [2021-10-22] Tested.

  Debug.Assert(!Object.ReferenceEquals(dataTypeSign,null));
  Debug.Assert(dataTypeSign.Length>0);
  Debug.Assert(dataTypeSign.Trim()==dataTypeSign);

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.type_mapping_err__unexpected_data_at_end_of_datatype_definition_1);

  exc
   .push(dataTypeSign)
   .raise();
 }//TypeMappingErr__UnexpectedDataAtEndOfDataTypeDefinition

 //-----------------------------------------------------------------------
 public static void UnexpectedCommandParameterDirection
                                            (ErrSourceID        errSrcID,
                                             string             parameterName,
                                             ParameterDirection parameterDirection)
 {
  //[2020-10-18] Tested.

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.common_err__unexpected_command_param_direction_2);

  errRec
   .push(parameterName)
   .push(parameterDirection);

  ThrowSysError.invalid_operation
   (errRec);
 }//UnexpectedCommandParameterDirection

 //-----------------------------------------------------------------------
 public static void NoCommandParameterValue(ErrSourceID        errSrcID,
                                            string             parameterName)
 {
  //[2020-10-18] Tested.

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.common_err__no_command_param_value_1);

  errRec
   .push(parameterName);

  ThrowSysError.invalid_operation
   (errRec);
 }//NoCommandParameterValue

 //-----------------------------------------------------------------------
 // public static void NoConnectionObject(ErrSourceID errSrcID)
 // {
 //  var exc=new LcpiOleDb__DataToolException
 //               (com_lib.HResultCode.E_FAIL,
 //                errSrcID,
 //                ErrMessageID.common_err__no_connection_object__0);
 //
 //  exc.raise();
 // }//NoConnectionObject
 //
 //-----------------------------------------------------------------------
 // public static void UnexpectedConnectionObjectType
 //                                           (ErrSourceID errSrcID,
 //                                            object      connectionObj)
 // {
 //  Debug.Assert(!Object.ReferenceEquals(connectionObj,null));
 //
 //  var exc=new LcpiOleDb__DataToolException
 //               (com_lib.HResultCode.E_FAIL,
 //                errSrcID,
 //                ErrMessageID.common_err__unexpected_connection_object_type__2);
 //
 //  exc.push(connectionObj.GetType())
 //     .push(Structure_TypeCache.TypeOf__LcpiDataOleDb__OleDbConnection)
 //     .raise();
 // }//UnexpectedConnectionObjectType
 //
 //-----------------------------------------------------------------------
 // public static void UnknownTableType(ErrSourceID errSrcID,
 //                                     string      tableId,
 //                                     string      tableType)
 // {
 //  Debug.Assert(!Object.ReferenceEquals(tableId,null));
 //  Debug.Assert(!Object.ReferenceEquals(tableType,null));
 //
 //  var exc=new LcpiOleDb__DataToolException
 //               (com_lib.HResultCode.E_FAIL,
 //                errSrcID,
 //                ErrMessageID.schema_err__unknown_table_type__2);
 //
 //  exc.push(tableId)
 //     .push(tableType)
 //     .raise();
 // }//UnknownTableType

 //-----------------------------------------------------------------------
 public static void LocalEvalErr__MemberNotSupported
                                           (ErrSourceID        errSrcID,
                                            Structure_MemberId memberId)
 {
  Debug.Assert(!Object.ReferenceEquals(memberId,null));

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.DB_E_NOTSUPPORTED,
      errSrcID,
      ErrMessageID.local_eval_err__member_not_supported_2);

  errRec
   .push(memberId.ObjectType)
   .push(memberId.MemberName);

  ThrowSysError.invalid_operation(errRec);
 }//LocalEvalErr__MemberNotSupported

 //-----------------------------------------------------------------------
 public static void LocalEvalErr__UnaryOperatorNotSupported
                                           (ErrSourceID    errSrcID,
                                            ExpressionType nodeType)
 {
  // [2021-04-30] Tested.

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.DB_E_NOTSUPPORTED,
      errSrcID,
      ErrMessageID.local_eval_err__unary_operator_not_supported_1);

  errRec
   .push(nodeType);

  ThrowSysError.invalid_operation
   (errRec);
 }//LocalEvalErr__UnaryOperatorNotSupported

 //-----------------------------------------------------------------------
 public static void LocalEvalErr__UnaryOperatorNotSupported
                                           (ErrSourceID    errSrcID,
                                            ExpressionType nodeType,
                                            Type           opType)
 {
  // [2021-04-30] Tested.

  Debug.Assert(!Object.ReferenceEquals(opType,null));

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.DB_E_NOTSUPPORTED,
      errSrcID,
      ErrMessageID.local_eval_err__unary_operator_not_supported_2);

  errRec
   .push(nodeType)
   .push(opType);

  ThrowSysError.invalid_operation
   (errRec);
 }//LocalEvalErr__UnaryOperatorNotSupported

 //-----------------------------------------------------------------------
 public static void LocalEvalErr__BinaryOperatorNotSupported
                                           (ErrSourceID    errSrcID,
                                            ExpressionType nodeType,
                                            Type           leftType,
                                            Type           rightType)
 {
  // [2021-04-30] Tested.

  Debug.Assert(!Object.ReferenceEquals(leftType,null));
  Debug.Assert(!Object.ReferenceEquals(rightType,null));

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.DB_E_NOTSUPPORTED,
      errSrcID,
      ErrMessageID.local_eval_err__binary_operator_not_supported_3);

  errRec
   .push(nodeType)
   .push(leftType)
   .push(rightType);

  ThrowSysError.invalid_operation
   (errRec);
 }//LocalEvalErr__BinaryOperatorNotSupported

 //-----------------------------------------------------------------------
 public static void LocalEvalErr__BinaryOperatorNotSupported
                                           (ErrSourceID               errSrcID,
                                            LcpiOleDb__ExpressionType nodeType,
                                            System.Type               leftType,
                                            System.Type               rightType)
 {
  // [2021-12-10] Tested.

  Debug.Assert(!Object.ReferenceEquals(leftType,null));
  Debug.Assert(!Object.ReferenceEquals(rightType,null));

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.DB_E_NOTSUPPORTED,
      errSrcID,
      ErrMessageID.local_eval_err__binary_operator_not_supported_3);

  errRec
   .push(nodeType)
   .push(leftType)
   .push(rightType);

  ThrowSysError.invalid_operation
   (errRec);
 }//LocalEvalErr__BinaryOperatorNotSupported

 //-----------------------------------------------------------------------
 public static void LocalEvalErr__MethodNotSupported
                                           (ErrSourceID  errSrcID,
                                            MethodInfo   methodInfo)
 {
  // [2021-04-30] Tested.

  Debug.Assert(!Object.ReferenceEquals(methodInfo,null));

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.DB_E_NOTSUPPORTED,
      errSrcID,
      ErrMessageID.local_eval_err__method_not_supported_1);

  errRec
   .push(methodInfo);

  ThrowSysError.invalid_operation
   (errRec);
 }//LocalEvalErr__MethodNotSupported

 //-----------------------------------------------------------------------
 public static void LocalEvalErr__UnexpectedResultTypeOfLogicalExpression
                                           (ErrSourceID errSrcID,
                                            Type        resultType)
 {
  // [2021-04-30] Tested.

  Debug.Assert(!Object.ReferenceEquals(resultType,null));

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.local_eval_err__unexpected_result_type_of_logical_expression_1);

  errRec
   .push(resultType);

  ThrowSysError.invalid_operation
   (errRec);
 }//LocalEvalErr__UnexpectedResultTypeOfLogicalExpression

 //-----------------------------------------------------------------------
 public static void LocalEvalErr__CantRemapMethodCall
                                           (ErrSourceID   errSrcID,
                                            MethodInfo    method,
                                            Expression    newObject,
                                            Expression[]  newArguments)
 {
  // [2021-06-07] Tested.

  Debug.Assert(!Object.ReferenceEquals(method,null));
  Debug.Assert(!Object.ReferenceEquals(newArguments,null));

  if(Object.ReferenceEquals(newObject,null))
  {
   var errRec
    =new Core.Core_ExceptionRecord
      (com_lib.HResultCode.E_FAIL,
       errSrcID,
       ErrMessageID.local_eval_err__cant_remap_static_method_2);

   errRec
    .push(method)
    .push(Helper__BuildCommaSepTypeList(newArguments));

   ThrowSysError.invalid_operation
    (errRec);
  }//if

  Debug.Assert(!Object.ReferenceEquals(newObject,null));
  Debug.Assert(!Object.ReferenceEquals(newObject.Type,null));

  {
   var errRec
    =new Core.Core_ExceptionRecord
      (com_lib.HResultCode.E_FAIL,
       errSrcID,
       ErrMessageID.local_eval_err__cant_remap_instance_method_3);

   errRec
    .push(method)
    .push(newObject.Type)
    .push(Helper__BuildCommaSepTypeList(newArguments));

   ThrowSysError.invalid_operation
    (errRec);
  }//local
 }//LocalEvalErr__CantRemapMethodCall

 //-----------------------------------------------------------------------
 // public static void LocalEvalErr__AmbiguousRemapMethodCall
 //                                           (ErrSourceID   errSrcID,
 //                                            MethodInfo    method,
 //                                            Expression[]  newArguments,
 //                                            MethodInfo[]  variants)
 // {
 //  Debug.Assert(!Object.ReferenceEquals(method,null));
 //  Debug.Assert(!Object.ReferenceEquals(newArguments,null));
 //  Debug.Assert(!Object.ReferenceEquals(variants,null));
 //
 //  var exc=new LcpiOleDb__DataToolException
 //               (com_lib.HResultCode.E_FAIL,
 //                errSrcID,
 //                ErrMessageID.local_eval_err__ambiguous_remap_method_3);
 //
 //  exc.push(method)
 //     .push(Helper__BuildCommaSepTypeList(newArguments));
 //
 //  var sb=new System.Text.StringBuilder();
 //
 //  for(int i=0;i!=variants.Length;++i)
 //  {
 //   sb.Append("\n")
 //     .Append(i+1)
 //     .Append(". ")
 //     .Append(Structure_ADP.BuildMethodSign(variants[i]));
 //  }//for i
 //
 //  exc.push(sb.ToString());
 //
 //  exc.raise();
 // }//LocalEvalErr__AmbiguousRemapMethodCall

 //-----------------------------------------------------------------------
 public static void LocalEvalErr__CantRemapObjectCreation
                                           (ErrSourceID   errSrcID,
                                            System.Type   originalType,
                                            System.Type   targetType,
                                            Expression[]  targetArguments)
 {
  // [2021-04-30] Tested.

  Debug.Assert(!Object.ReferenceEquals(originalType,null));
  Debug.Assert(!Object.ReferenceEquals(targetType,null));
  Debug.Assert(!Object.ReferenceEquals(targetArguments,null));

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.local_eval_err__cant_remap_object_construction_3);

  errRec
   .push(originalType)
   .push(targetType)
   .push(Helper__BuildCommaSepTypeList(targetArguments));

  ThrowSysError.invalid_operation
   (errRec);
 }//LocalEvalErr__CantRemapNew

 //-----------------------------------------------------------------------
 public static void LocalEvalErr__ComparisonOfArraysWithDifferentLengthNotSupported
                                           (ErrSourceID   errSrcID,
                                            int           length1,
                                            int           length2)
 {
  // [2021-12-02] Tested.

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.local_eval_err__comparison_of_arrays_with_different_length_not_supported_2);

  errRec
   .push(length1)
   .push(length2);

  ThrowSysError.invalid_operation
   (errRec);
 }//LocalEvalErr__ComparisonOfArraysWithDifferentLengthNotSupported

 //-----------------------------------------------------------------------
 public static void LocalEvalErr__FailedToCompareElementOfArrays
                                           (ErrSourceID              errSrcID,
                                            IReadOnlyCollection<int> elementIndex,
                                            Exception                innerException)
 {
  // [2021-12-02] Tested.

  Debug.Assert(!Object.ReferenceEquals(elementIndex,null));
  Debug.Assert(!Object.ReferenceEquals(innerException,null));

  Debug.Assert(elementIndex.Count>0);

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.local_eval_err__failed_to_compare_element_of_arrays_1);

  errRec
   .push(Helper__BuildCommaSepList(elementIndex));

  ThrowSysError.invalid_operation
   (errRec,
    innerException);
 }//LocalEvalErr__FailedToCompareElementOfArrays

 //-----------------------------------------------------------------------
 public static void LocalEvalErr__CantConvertArrayElementValueToRequiredType
                                           (ErrSourceID              errSrcID,
                                            IReadOnlyCollection<int> elementIndex,
                                            System.Type              elementValueType,
                                            System.Type              requiredType)
 {
  Debug.Assert(!Object.ReferenceEquals(elementIndex,null));
  Debug.Assert(!Object.ReferenceEquals(elementValueType,null));
  Debug.Assert(!Object.ReferenceEquals(requiredType,null));

  Debug.Assert(elementIndex.Count>0);

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.DB_E_UNSUPPORTEDCONVERSION,
      errSrcID,
      ErrMessageID.local_eval_err__cant_convert_array_element_value_to_required_type_3);

  errRec
   .push(Helper__BuildCommaSepList(elementIndex))
   .push(elementValueType)
   .push(requiredType);

  ThrowSysError.invalid_operation
   (errRec);
 }//LocalEvalErr__CantConvertArrayElementValueToRequiredType

 //-----------------------------------------------------------------------
 public static void CsUtf16Err__BadSequence(ErrSourceID errSrcID,
                                            string      checkPoint,
                                            int         offset)
 {
  // [2020-10-19] Tested.

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.cs_utf16_err__bad_sequence__2);

  exc
   .push(checkPoint)
   .push(offset)
   .raise();
 }//CsUtf16Err__BadSequence

 //-----------------------------------------------------------------------
 public static void SqlTranslatorErr__MethodNotSupported
                                           (ErrSourceID        errSrcID,
                                            Structure_MethodId methodId)
 {
  Debug.Assert(!Object.ReferenceEquals(methodId,null));

  var errRec
   =new Core.Core_ExceptionRecord
    (com_lib.HResultCode.DB_E_NOTSUPPORTED,
     errSrcID,
     ErrMessageID.sql_translator_err__method_not_supported_1);

  errRec
   .push(methodId.ToString());

  ThrowSysError.invalid_operation
   (errRec);
 }//SqlTranslatorErr__MethodNotSupported

 //-----------------------------------------------------------------------
 public static void SqlTranslatorErr__MemberNotSupported
                                           (ErrSourceID        errSrcID,
                                            Structure_MemberId memberId)
 {
  Debug.Assert(!Object.ReferenceEquals(memberId,null));

  var errRec
   =new Core.Core_ExceptionRecord
    (com_lib.HResultCode.DB_E_NOTSUPPORTED,
     errSrcID,
     ErrMessageID.sql_translator_err__member_not_supported_2);

  errRec
   .push(memberId.ObjectType)
   .push(memberId.MemberName);

  ThrowSysError.invalid_operation
   (errRec);
 }//SqlTranslatorErr__MemberNotSupported

 //-----------------------------------------------------------------------
 public static void SqlTranslatorErr__UnsupportedBinaryOperatorType
                                           (ErrSourceID         errSrcID,
                                            ExpressionType      operatorType)
 {
  // [2020-12-28] Tested.

  var errRec
   =new Core.Core_ExceptionRecord
    (com_lib.HResultCode.DB_E_NOTSUPPORTED,
     errSrcID,
     ErrMessageID.sql_translator_err__unsupported_binary_operator_type_1);

  errRec
   .push(operatorType);

  ThrowSysError.invalid_operation
   (errRec);
 }//SqlTranslatorErr__UnsupportedBinaryOperatorType

 //-----------------------------------------------------------------------
 public static void SqlTranslatorErr__UnsupportedBinaryOperatorType
                                           (ErrSourceID               errSrcID,
                                            LcpiOleDb__ExpressionType operatorType,
                                            System.Type               leftType,
                                            System.Type               rightType)
 {
  Debug.Assert(!Object.ReferenceEquals(leftType,null));
  Debug.Assert(!Object.ReferenceEquals(rightType,null));

  var errRec
   =new Core.Core_ExceptionRecord
    (com_lib.HResultCode.DB_E_NOTSUPPORTED,
     errSrcID,
     ErrMessageID.sql_translator_err__unsupported_binary_operator_type_3);

  errRec
   .push(operatorType)
   .push(leftType)
   .push(rightType);

  ThrowSysError.invalid_operation
   (errRec);
 }//SqlTranslatorErr__UnsupportedBinaryOperatorType

 //-----------------------------------------------------------------------
 public static void SqlTranslatorErr__UnsupportedUnaryOperatorType
                                           (ErrSourceID               errSrcID,
                                            ExpressionType            operatorType)
 {
  var errRec
   =new Core.Core_ExceptionRecord
    (com_lib.HResultCode.DB_E_NOTSUPPORTED,
     errSrcID,
     ErrMessageID.sql_translator_err__unsupported_unary_operator_type_1);

  errRec
   .push(operatorType);

  ThrowSysError.invalid_operation
   (errRec);
 }//SqlTranslatorErr__UnsupportedUnaryOperatorType

 //-----------------------------------------------------------------------
 public static void SqlTranslatorErr__UnsupportedUnaryOperatorType
                                           (ErrSourceID               errSrcID,
                                            LcpiOleDb__ExpressionType operatorType)
 {
  var errRec
   =new Core.Core_ExceptionRecord
    (com_lib.HResultCode.DB_E_NOTSUPPORTED,
     errSrcID,
     ErrMessageID.sql_translator_err__unsupported_unary_operator_type_1);

  errRec
   .push(operatorType);

  ThrowSysError.invalid_operation
   (errRec);
 }//SqlTranslatorErr__UnsupportedUnaryOperatorType

 //-----------------------------------------------------------------------
 public static void SqlTranslatorErr__UnsupportedUnaryOperatorType
                                           (ErrSourceID               errSrcID,
                                            LcpiOleDb__ExpressionType operatorType,
                                            System.Type               operandType,
                                            System.Type               resultType)
 {
  Debug.Assert(!Object.ReferenceEquals(operandType,null));
  Debug.Assert(!Object.ReferenceEquals(resultType,null));

  var errRec
   =new Core.Core_ExceptionRecord
    (com_lib.HResultCode.DB_E_NOTSUPPORTED,
     errSrcID,
     ErrMessageID.sql_translator_err__unsupported_unary_operator_type_3);

  errRec
   .push(operatorType)
   .push(operandType)
   .push(resultType);

  ThrowSysError.invalid_operation
   (errRec);
 }//SqlTranslatorErr__UnsupportedUnaryOperatorType

 //-----------------------------------------------------------------------
 public static void SqlTranslatorErr__CantPresentSqlUnaryOperationAsSqlUnaryExpression
                                           (ErrSourceID         errSrcID,
                                            ExpressionType      operationID,
                                            System.Type         operandType,
                                            System.Type         clrResultType)
 {
  Debug.Assert(!Object.ReferenceEquals(operandType,null));
  Debug.Assert(!Object.ReferenceEquals(clrResultType,null));

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.sql_translator_err__cant_present_unary_operation_as_SqlUnaryExpression_3);

  errRec
   .push(operationID)
   .push(operandType)
   .push(clrResultType);

  ThrowSysError.invalid_operation
   (errRec);
 }//SqlTranslatorErr__CantPresentSqlUnaryOperationAsSqlUnaryExpression

 //-----------------------------------------------------------------------
 public static void SqlTranslatorErr__CantPresentSqlBinaryOperationAsSqlBinaryExpression
                                           (ErrSourceID         errSrcID,
                                            ExpressionType      operationID,
                                            System.Type         leftClrType,
                                            System.Type         rightClrType)
 {
  Debug.Assert(!Object.ReferenceEquals(leftClrType,null));
  Debug.Assert(!Object.ReferenceEquals(rightClrType,null));

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.sql_translator_err__cant_present_binary_operation_as_SqlBinaryExpression_3);

  errRec
   .push(operationID)
   .push(leftClrType)
   .push(rightClrType);

  ThrowSysError.invalid_operation
   (errRec);
 }//SqlTranslatorErr__CantPresentSqlBinaryOperationAsSqlBinaryExpression

 //-----------------------------------------------------------------------
 public static void SqlTranslatorErr__CantPresentSqlFunctionAsSqlFunctionExpression
                                           (ErrSourceID errSrcID,
                                            string      functionName)
 {
  Debug.Assert(!Object.ReferenceEquals(functionName,null));
  Debug.Assert(functionName.Length>=0);
  Debug.Assert(functionName.Trim()==functionName);

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.sql_translator_err__cant_present_function_as_SqlFunctionExpression_1);

  errRec
   .push(functionName);

  ThrowSysError.invalid_operation
   (errRec);
 }//SqlTranslatorErr__CantPresentSqlFunctionAsSqlFunctionExpression

 //-----------------------------------------------------------------------
 public static void SqlGenErr__UnsupportedCastAsBetweenTypes
                                           (ErrSourceID         errSrcID,
                                            System.Type         sourceType,
                                            System.Type         targetType)
 {
  // [2020-10-18] Tested.

  Debug.Assert(!Object.ReferenceEquals(sourceType,null));
  Debug.Assert(!Object.ReferenceEquals(targetType,null));

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.DB_E_UNSUPPORTEDCONVERSION,
      errSrcID,
      ErrMessageID.sql_gen_err__unsupported_cast_as_between_types_2);

  errRec
   .push(sourceType)
   .push(targetType);

  ThrowSysError.invalid_operation
   (errRec);
 }//SqlGenErr__UnsupportedCastAsBetweenTypes

 //-----------------------------------------------------------------------
 public static void SqlGenErr__DefinitionOfValueInSqlNotSupported
                                           (ErrSourceID         errSrcID,
                                            string              sqlTypeName)
 {
  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.DB_E_NOTSUPPORTED,
      errSrcID,
      ErrMessageID.sql_gen_err__definition_of_value_in_sql_not_supported__1);

  errRec
   .push(sqlTypeName);

  ThrowSysError.not_supported
   (errRec);
 }//SqlGenErr__DefinitionOfValueInSqlNotSupported

 //-----------------------------------------------------------------------
 // removing from public surface
 private static void SqlGenErr__NotSupportedSqlOperator
                                           (ErrSourceID errSrcID,
                                            string      sqlOperatorSign)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlOperatorSign,null));
  Debug.Assert(sqlOperatorSign.Length>0);
  Debug.Assert(sqlOperatorSign==sqlOperatorSign.Trim());

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.DB_E_NOTSUPPORTED,
      errSrcID,
      ErrMessageID.sql_gen_err__not_supported_sql_operator__1);

  (errRec).push(sqlOperatorSign);

  ThrowSysError.not_supported
   (errRec);
 }//SqlGenErr__NotSupportedSqlOperator

 //-----------------------------------------------------------------------
 public static void SqlGenErr__NotSupportedSqlOperator__APPLY
                                           (ErrSourceID errSrcID)
 {
  SqlGenErr__NotSupportedSqlOperator
   (errSrcID,
    "APPLY");
 }//SqlGenErr__NotSupportedSqlOperator__APPLY

 //-----------------------------------------------------------------------
 public static void SqlGenErr__NotSupportedSqlOperator__INTERSECT
                                           (ErrSourceID errSrcID)
 {
  SqlGenErr__NotSupportedSqlOperator
   (errSrcID,
    "INTERSECT");
 }//SqlGenErr__NotSupportedSqlOperator__INTERSECT

 //-----------------------------------------------------------------------
 public static void SqlGenErr__NotSupportedSqlOperator__EXCEPT
                                           (ErrSourceID errSrcID)
 {
  SqlGenErr__NotSupportedSqlOperator
   (errSrcID,
    "EXCEPT");
 }//SqlGenErr__NotSupportedSqlOperator__EXCEPT

 //-----------------------------------------------------------------------
 public static void SqlGenErr__TranslationOfMemberNotSupportedInCurrentCnDialect
                                           (ErrSourceID         errSrcID,
                                            int                 cnDialect,
                                            MemberInfo          memberInfo)
 {
  // [2020-10-18] Tested.

  Debug.Assert(!Object.ReferenceEquals(memberInfo,null));

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.DB_E_NOTSUPPORTED,
      errSrcID,
      ErrMessageID.sql_gen_err__translation_of_member_not_supported_in_current_cn_dialect_2);

  errRec
   .push(cnDialect)
   .push(Structure.Structure_ReflectionUtils.BuildMemberSign(memberInfo));

  ThrowSysError.not_supported
   (errRec);
 }//SqlGenErr__TranslationOfMemberNotSupportedInCurrentCnDialect

 //-----------------------------------------------------------------------
 public static void SqlGenErr__TranslationOfMemberNotSupportedInCurrentCnDialect
                                           (ErrSourceID         errSrcID,
                                            int                 cnDialect,
                                            Structure_MethodId  methodId)
 {
  Debug.Assert(!Object.ReferenceEquals(methodId,null));

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.DB_E_NOTSUPPORTED,
      errSrcID,
      ErrMessageID.sql_gen_err__translation_of_member_not_supported_in_current_cn_dialect_2);

  errRec
   .push(cnDialect)
   .push(methodId.ToString());

  ThrowSysError.not_supported
   (errRec);
 }//SqlGenErr__TranslationOfMemberNotSupportedInCurrentCnDialect

 //-----------------------------------------------------------------------
 public static void SqlGenErr__DecimalPrecisionNotSupportedInCurrentCnDialect
                                           (ErrSourceID         errSrcID,
                                            int                 cnDialect,
                                            string              sqlTypeName,
                                            int                 precision)
 {
  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.DB_E_NOTSUPPORTED,
      errSrcID,
      ErrMessageID.sql_gen_err__decimal_precision_not_supported_in_current_cn_dialect_3);

  errRec
   .push(cnDialect)
   .push(sqlTypeName)
   .push(precision);

  ThrowSysError.not_supported
   (errRec);
 }//SqlGenErr__DecimalPrecisionNotSupportedInCurrentCnDialect

 //-----------------------------------------------------------------------
 public static void MSqlGenErr__ComputedColumnNotSupported
                                           (ErrSourceID errSrcID)
 {
  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.DB_E_NOTSUPPORTED,
      errSrcID,
      ErrMessageID.msql_gen_err__computed_column_not_supported__0);

  ThrowSysError.not_supported
   (errRec);
 }//MSqlGenErr__ComputedColumnNotSupported

 //-----------------------------------------------------------------------
 public static void MSqlGenErr__CantFindTypeMappingForColumn
                                           (ErrSourceID errSrcID,
                                            string      tableName,
                                            string      columnName)
 {
  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.msql_gen_err__cant_find_type_mapping_for_column__2);

  exc
   .push(tableName)
   .push(columnName)
   .raise();
 }//MSqlGenErr__CantFindTypeMappingForColumn

 //-----------------------------------------------------------------------
 public static void MSqlGenErr__DifferentSizeOfFkColumnLists
                                           (ErrSourceID errSrcID,
                                            int         cColumns,
                                            int         cPrincipalColumns)
 {
  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.msql_gen_err__bad_fk_definition__different_size_of_column_lists__2);

  exc
   .push(cColumns)
   .push(cPrincipalColumns)
   .raise();
 }//MSqlGenErr__CantFindTypeMappingForColumn

 //-----------------------------------------------------------------------
 public static void MSqlGenErr__UnknownFkReferentialAction
                                           (ErrSourceID       errSrcID,
                                            ReferentialAction referentialAction)
 {
  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.msql_gen_err__unknown_fk_referential_action__1);

  exc
   .push(referentialAction)
   .raise();
 }//MSqlGenErr__UnknownFkReferentialAction

 //-----------------------------------------------------------------------
 public static void MSqlGenErr__CantFindTypeMappingForDefaultValue
                                           (ErrSourceID errSrcID,
                                            System.Type defaultValueClrType)
 {
  Debug.Assert(!Object.ReferenceEquals(defaultValueClrType, null));

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.msql_gen_err__cant_find_type_mapping_for_default_value__1);

  exc
   .push(defaultValueClrType)
   .raise();
 }//MSqlGenErr__CantFindTypeMappingForDefaultValue

 //-----------------------------------------------------------------------
 public static void MSqlGenErr__DetectedMultipleDefinitionOfDefaultValue
                                           (ErrSourceID errSrcID)
 {
  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.msql_gen_err__detected_multiple_definition_of_default_value__0);

  exc.raise();
 }//MSqlGenErr__DetectedMultipleDefinitionOfDefaultValue

 //-----------------------------------------------------------------------
 public static void MSqlGenErr__OverflowInCalculationOfAdjustedSequenceStartValue
                                           (ErrSourceID             errSrcID,
                                            CreateSequenceOperation operation)
 {
  // [2021-11-10] Tested.

  Debug.Assert(!Object.ReferenceEquals(operation,null));

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.msql_gen_err__overflow_in_calculation_of_adjusted_sequence_start_value__3);

  exc
   .push(operation.Name)
   .push(operation.StartValue)
   .push(operation.IncrementBy)
   .raise();
 }//MSqlGenErr__OverflowInCalculationOfAdjustedSequenceStartValue

 //-----------------------------------------------------------------------
 public static void MSqlGenErr__InconsistentTableNamesInAlterColumnOperation
                                           (ErrSourceID  errSrcID,
                                            string       oldDataTableName,
                                            string       newDataTableName)
 {
  // [2021-11-10] Tested.

  //Expected
  Debug.Assert(!Object.ReferenceEquals(oldDataTableName,null));
  Debug.Assert(!Object.ReferenceEquals(newDataTableName,null));

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.msql_gen_err__inconsistent_table_names_in_alter_column_operation__2);

  exc
   .push(oldDataTableName)
   .push(newDataTableName)
   .raise();
 }//MSqlGenErr__InconsistentTableNamesInAlterColumnOperation

 //-----------------------------------------------------------------------
 public static void MSqlGenErr__ColumnDataUsesIncorrectTableName
                                           (ErrSourceID  errSrcID,
                                            int          columnIndex,
                                            string       columnName,
                                            string       actualTableName,
                                            string       expectedTableName)
 {
  // [2021-11-10] Tested.

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.msql_gen_err__column_data_uses_incorrect_table_name__4);

  exc
   .push(columnIndex)
   .push(columnName)
   .push(actualTableName)
   .push(expectedTableName)
   .raise();
 }//MSqlGenErr__ColumnDataUsesIncorrectTableName

 //-----------------------------------------------------------------------
 public static void MSqlGenErr__BadIndexDefinition_MultipleData
                                           (ErrSourceID  errSrcID,
                                            string       indexName,
                                            string       tableName)
 {
  // [2021-11-11] Tested.

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.msql_gen_err__bad_index_definition__multiple_data__2);

  exc
   .push(indexName)
   .push(tableName)
   .raise();
 }//MSqlGenErr__BadIndexDefinition_MultipleData

 //-----------------------------------------------------------------------
 public static void MSqlGenErr__BadIndexDefinition_NoData
                                           (ErrSourceID  errSrcID,
                                            string       indexName,
                                            string       tableName)
 {
  // [2021-11-11] Tested.

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.msql_gen_err__bad_index_definition__no_data__2);

  exc
   .push(indexName)
   .push(tableName)
   .raise();
 }//MSqlGenErr__BadIndexDefinition_NoData

 //-----------------------------------------------------------------------
 public static void MSqlGenErr__TableNameNotDefined(ErrSourceID errSrcID)
 {
  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.msql_gen_err__table_name_not_defined__0);

  exc
   .raise();
 }//MSqlGenErr__TableNameNotDefined

 //-----------------------------------------------------------------------
 public static void ColumnModification__ConflictingRowValuesSensitive
                                           (ErrSourceID         errSrcID,
                                            IColumnModification columnModification1,
                                            IColumnModification columnModification2)
 {
  Debug.Assert(!Object.ReferenceEquals(columnModification1,null));
  Debug.Assert(!Object.ReferenceEquals(columnModification1.Entry,null));
  Debug.Assert(!Object.ReferenceEquals(columnModification1.Entry.EntityType,null));
  Debug.Assert(!Object.ReferenceEquals(columnModification1.Property,null));
  Debug.Assert(!Object.ReferenceEquals(columnModification1.ColumnName,null));

  Debug.Assert(!Object.ReferenceEquals(columnModification2,null));
  Debug.Assert(!Object.ReferenceEquals(columnModification2.Entry,null));
  Debug.Assert(!Object.ReferenceEquals(columnModification2.Entry.EntityType,null));
  Debug.Assert(!Object.ReferenceEquals(columnModification2.Property,null));

  //-------------------------------------------------------
  var primaryKeys
   =columnModification1.Entry.EntityType.FindPrimaryKey();

  Debug.Assert(!Object.ReferenceEquals(primaryKeys,null));
  Debug.Assert(!Object.ReferenceEquals(primaryKeys.Properties,null));

  var errRec
   =new Core.Core_ExceptionRecord
    (com_lib.HResultCode.E_FAIL,
     errSrcID,
     ErrMessageID.common_err__ConflictingRowValuesSensitive_6);

  errRec
   .push(columnModification1.Entry.EntityType.DisplayName())
   .push(columnModification2.Entry.EntityType.DisplayName())
   .push(columnModification1.Entry.Helper__BuildCurrentValuesString(primaryKeys.Properties))
   .push(columnModification1.Entry.Helper__BuildCurrentValuesString(new[] { columnModification1.Property }))
   .push(columnModification2.Entry.Helper__BuildCurrentValuesString(new[] { columnModification2.Property }))
   .push(columnModification1.ColumnName);

  ThrowSysError.invalid_operation
   (errRec);
 }//ColumnModification__ConflictingRowValuesSensitive

 //-----------------------------------------------------------------------
 public static void ColumnModification__ConflictingRowValues
                                           (ErrSourceID         errSrcID,
                                            IColumnModification columnModification1,
                                            IColumnModification columnModification2)
 {
  Debug.Assert(!Object.ReferenceEquals(columnModification1,null));
  Debug.Assert(!Object.ReferenceEquals(columnModification1.Entry,null));
  Debug.Assert(!Object.ReferenceEquals(columnModification1.Entry.EntityType,null));
  Debug.Assert(!Object.ReferenceEquals(columnModification1.Property,null));
  Debug.Assert(!Object.ReferenceEquals(columnModification1.ColumnName,null));

  Debug.Assert(!Object.ReferenceEquals(columnModification2,null));
  Debug.Assert(!Object.ReferenceEquals(columnModification2.Entry,null));
  Debug.Assert(!Object.ReferenceEquals(columnModification2.Entry.EntityType,null));
  Debug.Assert(!Object.ReferenceEquals(columnModification2.Property,null));

  //-------------------------------------------------------
  var errRec
   =new Core.Core_ExceptionRecord
    (com_lib.HResultCode.E_FAIL,
     errSrcID,
     ErrMessageID.common_err__ConflictingRowValues_5);

  errRec
   .push(columnModification1.Entry.EntityType.DisplayName())
   .push(columnModification2.Entry.EntityType.DisplayName())
   .push(new[] { columnModification1.Property }.Helper__Format())
   .push(new[] { columnModification2.Property }.Helper__Format())
   .push(columnModification1.ColumnName);

  ThrowSysError.invalid_operation
   (errRec);
 }//ColumnModification__ConflictingRowValues

 //-----------------------------------------------------------------------
 public static void ColumnModification__ConflictingOriginalRowValuesSensitive
                                           (ErrSourceID         errSrcID,
                                            IColumnModification columnModification1,
                                            IColumnModification columnModification2)
 {
  Debug.Assert(!Object.ReferenceEquals(columnModification1,null));
  Debug.Assert(!Object.ReferenceEquals(columnModification1.Entry,null));
  Debug.Assert(!Object.ReferenceEquals(columnModification1.Entry.EntityType,null));
  Debug.Assert(!Object.ReferenceEquals(columnModification1.Property,null));
  Debug.Assert(!Object.ReferenceEquals(columnModification1.ColumnName,null));

  Debug.Assert(!Object.ReferenceEquals(columnModification2,null));
  Debug.Assert(!Object.ReferenceEquals(columnModification2.Entry,null));
  Debug.Assert(!Object.ReferenceEquals(columnModification2.Entry.EntityType,null));
  Debug.Assert(!Object.ReferenceEquals(columnModification2.Property,null));

  //-------------------------------------------------------
  var primaryKeys
   =columnModification1.Entry.EntityType.FindPrimaryKey();

  Debug.Assert(!Object.ReferenceEquals(primaryKeys,null));
  Debug.Assert(!Object.ReferenceEquals(primaryKeys.Properties,null));

  var errRec
   =new Core.Core_ExceptionRecord
    (com_lib.HResultCode.E_FAIL,
     errSrcID,
     ErrMessageID.common_err__ConflictingOriginalRowValuesSensitive_6);

  errRec
   .push(columnModification1.Entry.EntityType.DisplayName())
   .push(columnModification2.Entry.EntityType.DisplayName())
   .push(columnModification1.Entry.Helper__BuildCurrentValuesString  (primaryKeys.Properties))
   .push(columnModification1.Entry.Helper__BuildOriginalValuesString (new[] { columnModification1.Property }))
   .push(columnModification2.Entry.Helper__BuildOriginalValuesString (new[] { columnModification2.Property }))
   .push(columnModification1.ColumnName);

  ThrowSysError.invalid_operation
   (errRec);
 }//ColumnModification__ConflictingOriginalRowValuesSensitive

 //-----------------------------------------------------------------------
 public static void ColumnModification__ConflictingOriginalRowValues
                                           (ErrSourceID         errSrcID,
                                            IColumnModification columnModification1,
                                            IColumnModification columnModification2)
 {
  Debug.Assert(!Object.ReferenceEquals(columnModification1,null));
  Debug.Assert(!Object.ReferenceEquals(columnModification1.Entry,null));
  Debug.Assert(!Object.ReferenceEquals(columnModification1.Entry.EntityType,null));
  Debug.Assert(!Object.ReferenceEquals(columnModification1.Property,null));
  Debug.Assert(!Object.ReferenceEquals(columnModification1.ColumnName,null));

  Debug.Assert(!Object.ReferenceEquals(columnModification2,null));
  Debug.Assert(!Object.ReferenceEquals(columnModification2.Entry,null));
  Debug.Assert(!Object.ReferenceEquals(columnModification2.Entry.EntityType,null));
  Debug.Assert(!Object.ReferenceEquals(columnModification2.Property,null));

  //-------------------------------------------------------
  var primaryKeys
   =columnModification1.Entry.EntityType.FindPrimaryKey();

  Debug.Assert(!Object.ReferenceEquals(primaryKeys,null));
  Debug.Assert(!Object.ReferenceEquals(primaryKeys.Properties,null));

  var errRec
   =new Core.Core_ExceptionRecord
    (com_lib.HResultCode.E_FAIL,
     errSrcID,
     ErrMessageID.common_err__ConflictingOriginalRowValues_5);

  errRec
   .push(columnModification1.Entry.EntityType.DisplayName())
   .push(columnModification2.Entry.EntityType.DisplayName())
   .push(new[] { columnModification1.Property }.Helper__Format())
   .push(new[] { columnModification2.Property }.Helper__Format())
   .push(columnModification1.ColumnName);

  ThrowSysError.invalid_operation
   (errRec);
 }//ColumnModification__ConflictingOriginalRowValues

 //-----------------------------------------------------------------------
 public static void Schema__DataProviderNotSupportReqRestriction
                                            (ErrSourceID errSrcID,
                                             string      schemaName,
                                             string      restrictionName)
 {
  // [2021-09-23] Tested.

  Debug.Assert(!string.IsNullOrEmpty(schemaName));
  Debug.Assert(!string.IsNullOrEmpty(restrictionName));

  var errRec
   =new Core.Core_ExceptionRecord
    (com_lib.HResultCode.E_FAIL,
     errSrcID,
     ErrMessageID.schema_err__data_provider_not_support_req_restriction_2);

  errRec
   .push(schemaName)
   .push(restrictionName);

  ThrowSysError.invalid_operation
   (errRec);
 }//Schema__DataProviderNotSupportReqRestriction

 //-----------------------------------------------------------------------
 public static void UnknownAnnotation(ErrSourceID errSrcID,
                                      string      annotationName)
 {
  // [2021-09-23] Tested.

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.common_err__unknown_annotation__1);

  exc
   .push(annotationName)
   .raise();
 }//UnknownAnnotation

 //-----------------------------------------------------------------------
 public static void AnnotationHasUnknownValue<T>(ErrSourceID errSrcID,
                                                 string      annotationName,
                                                 T           annotationValue)
 {
  // [2021-09-23] Tested.

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.common_err__annotation_has_unknown_value__2);

  exc
   .push(annotationName)
   .push_object(annotationValue)
   .raise();
 }//AnnotationHasUnknownValue<T>

 //-----------------------------------------------------------------------
 public static void AnnotationHasNullValue(ErrSourceID errSrcID,
                                           string      annotationName)
 {
  // [2021-09-23] Tested.

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.common_err__annotation_has_null_value__1);

  exc
   .push(annotationName)
   .raise();
 }//AnnotationHasNullValue

 //-----------------------------------------------------------------------
 public static void AnnotationHasValueWithUnexpectedType
                                           (ErrSourceID errSrcID,
                                            string      annotationName,
                                            System.Type actualValueType)
 {
  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.common_err__annotation_has_value_with_unexpected_type__2);

  exc
   .push(annotationName)
   .push(actualValueType)
   .raise();
 }//AnnotationHasValueWithUnexpectedType

 //-----------------------------------------------------------------------
 public static void AnnotationHasValueWithUnexpectedType
                                           (ErrSourceID errSrcID,
                                            string      annotationName,
                                            System.Type actualValueType,
                                            System.Type expectedValueType)
 {
  // [2021-09-23] Tested.

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.common_err__annotation_has_value_with_unexpected_type__3);

  exc
   .push(annotationName)
   .push(actualValueType)
   .push(expectedValueType)
   .raise();
 }//AnnotationHasValueWithUnexpectedType

 //-----------------------------------------------------------------------
 public static void MultipleDefinitionOfAnnotation<T>
                                           (ErrSourceID errSrcID,
                                            string      annotationName,
                                            T           prevValue,
                                            T           newValue)
 {
  // [2021-09-23] Tested.

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.common_err__multiple_definition_of_annotation__3);

  exc
   .push(annotationName)
   .push_object(prevValue)
   .push_object(newValue)
   .raise();
 }//AnnotationHasValueWithUnexpectedType<T>

 //-----------------------------------------------------------------------
 public static void ModelDefinesIncorrectGlobalValueGenerationStrategy
                                           (ErrSourceID errSrcID,
                                            string      strategySign)
 {
  // [2021-11-16] Tested.

  Debug.Assert(!Object.ReferenceEquals(strategySign,null));

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.common_err__model_defines_incorrect_global_value_generation_strategy__1);

  exc
   .push(strategySign)
   .raise();
 }//ModelDefinesIncorrectGlobalValueGenerationStrategy

 //-----------------------------------------------------------------------
 public static void PropertyWithDataTypeIsNotCompatiblyWithValueGenerationStrategy
                                           (ErrSourceID errSrcID,
                                            string      strategySign,
                                            System.Type declaringClrType,
                                            string      propertyName,
                                            System.Type propertyDataClrDataType)
 {
  // [2021-11-16] Tested.

  Debug.Assert(!Object.ReferenceEquals(strategySign,null));
  Debug.Assert(!Object.ReferenceEquals(declaringClrType,null));
  Debug.Assert(!Object.ReferenceEquals(propertyName,null));
  Debug.Assert(!Object.ReferenceEquals(propertyDataClrDataType,null));

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.common_err__property_with_datatype_is_not_compatible_with_value_generation_strategy__4);

  exc
   .push(strategySign)
   .push(declaringClrType)
   .push(propertyName)
   .push(propertyDataClrDataType)
   .raise();
 }//PropertyWithDataTypeIsNotCompatiblyWithValueGenerationStrategy

 //-----------------------------------------------------------------------
 public static void ValueGenerationStrategyCantBeDefinedAtModelLevel
                                           (ErrSourceID errSrcID,
                                            string      strategySign)
 {
  // [2021-11-16] Tested.

  Debug.Assert(!Object.ReferenceEquals(strategySign,null));

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.common_err__value_generation_strategy_cant_be_defined_at_model_level__1);

  exc
   .push(strategySign)
   .raise();
 }//ValueGenerationStrategyCantBeDefinedAtModelLevel

 //-----------------------------------------------------------------------
 public static void DbmsErr__FB__FirebirdDoesNotSupportDropIdentityAttributeFromColumn
                                           (ErrSourceID  errSrcID)
 {
  // [2021-11-10] Tested.

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.dbms_err__fb__firebird_does_not_support_drop_identity_attribute_from_column__0);

  exc
   .raise();
 }//DbmsErr__FB__FirebirdDoesNotSupportDropIdentityAttributeFromColumn

 //-----------------------------------------------------------------------
 public static void DbmsErr__FB__FirebirdDoesNotSupportAddIdentityAttributeToColumn
                                           (ErrSourceID  errSrcID)
 {
  // [2021-11-10] Tested.

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.dbms_err__fb__firebird_does_not_support_add_identity_attribute_to_column__0);

  exc
   .raise();
 }//DbmsErr__FB__FirebirdDoesNotSupportAddIdentityAttributeToColumn

 //-----------------------------------------------------------------------
 public static void DbmsErr__FB__FirebirdDoesNotSupportRenamingOfTables
                                           (ErrSourceID  errSrcID)
 {
  // [2021-11-11] Tested.

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.DB_E_NOTSUPPORTED,
      errSrcID,
      ErrMessageID.dbms_err__fb__firebird_does_not_support_renaming_of_tables__0);

  ThrowSysError.not_supported
   (errRec);
 }//DbmsErr__FB__FirebirdDoesNotSupportRenamingOfTables

 //-----------------------------------------------------------------------
 public static void DbmsErr__FB__FirebirdDoesNotSupportRenamingOfSequences
                                           (ErrSourceID  errSrcID)
 {
  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.DB_E_NOTSUPPORTED,
      errSrcID,
      ErrMessageID.dbms_err__fb__firebird_does_not_support_renaming_of_sequences__0);

  ThrowSysError.not_supported
   (errRec);
 }//DbmsErr__FB__FirebirdDoesNotSupportRenamingOfSequences

 //-----------------------------------------------------------------------
 public static void DbmsErr__FB__FirebirdDoesNotSupportRenamingOfIndexes
                                           (ErrSourceID  errSrcID)
 {
  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.DB_E_NOTSUPPORTED,
      errSrcID,
      ErrMessageID.dbms_err__fb__firebird_does_not_support_renaming_of_indexes__0);

  ThrowSysError.not_supported
   (errRec);
 }//DbmsErr__FB__FirebirdDoesNotSupportRenamingOfIndexes

 //-----------------------------------------------------------------------
 public static void DbmsErr__FB__FirebirdDoesNotSupportSchemas
                                           (ErrSourceID  errSrcID)
 {
  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.DB_E_NOTSUPPORTED,
      errSrcID,
      ErrMessageID.dbms_err__fb__firebird_does_not_support_schemas__0);

  ThrowSysError.not_supported
   (errRec);
 }//DbmsErr__FB__FirebirdDoesNotSupportSchemas

 //helper methods --------------------------------------------------------
 private static string Helper__BuildCommaSepTypeList
                                            (Expression[] arguments)
 {
  Debug.Assert(!Object.ReferenceEquals(arguments,null));

  string comma="";

  var sb=new System.Text.StringBuilder();

  foreach(var a in arguments)
  {
   Debug.Assert(!Object.ReferenceEquals(a,null));

   sb.Append(comma);

   sb.Append(a.Type.Extension__BuildHumanName());

   comma=", ";
  }//foreach a

  return sb.ToString();
 }//Helper__BuildCommaSepTypeList

 //-----------------------------------------------------------------------
 private static string Helper__BuildCommaSepList
                                            (IReadOnlyCollection<int> values)
 {
  Debug.Assert(!Object.ReferenceEquals(values,null));

  string comma=null;  //why not ...

  var sb=new System.Text.StringBuilder();

  foreach(var v in values)
  {
   sb.Append(comma);

   sb.Append(v);

   comma=", ";
  }//foreach v

  return sb.ToString();
 }//Helper__BuildCommaSepList

 //-----------------------------------------------------------------------
 private static string Helper__BuildCurrentValuesString
                                           (this IUpdateEntry          entry,
                                            IEnumerable<IPropertyBase> properties)
 {
  Debug.Assert(!Object.ReferenceEquals(entry,null));
  Debug.Assert(!Object.ReferenceEquals(properties,null));

  string comma="";

  var sb=new System.Text.StringBuilder();

  sb.Append('{');

  foreach(var p in properties)
  {
   Debug.Assert(!Object.ReferenceEquals(p,null));
   Debug.Assert(!Object.ReferenceEquals(p.Name,null));

   sb.Append(comma);

   var currentValue=entry.GetCurrentValue(p);

   sb.Append(p.Name);
   sb.Append(": ");
   sb.Append(Helper__BuildValueString(currentValue));

   comma=", ";
  }//foreach

  sb.Append('}');

  return sb.ToString();
 }//Helper__BuildCurrentValuesString

 //-----------------------------------------------------------------------
 private static string Helper__BuildOriginalValuesString
                                           (this IUpdateEntry          entry,
                                            IEnumerable<IPropertyBase> properties)
 {
  Debug.Assert(!Object.ReferenceEquals(entry,null));
  Debug.Assert(!Object.ReferenceEquals(properties,null));

  string comma="";

  var sb=new System.Text.StringBuilder();

  sb.Append('{');

  foreach(var p in properties)
  {
   Debug.Assert(!Object.ReferenceEquals(p,null));
   Debug.Assert(!Object.ReferenceEquals(p.Name,null));

   sb.Append(comma);

   var originalValue=entry.GetOriginalValue(p);

   sb.Append(p.Name);
   sb.Append(": ");
   sb.Append(Helper__BuildValueString(originalValue));

   comma=", ";
  }//foreach

  sb.Append('}');

  return sb.ToString();
 }//Helper__BuildOriginalValuesString

 //-----------------------------------------------------------------------
 private static string Helper__BuildValueString(object propertyValue)
 {
  if(Object.ReferenceEquals(propertyValue, null))
   return "<null>";

  return Convert.ToString(propertyValue, CultureInfo.InvariantCulture);
 }//Helper__BuildValueString

 //-----------------------------------------------------------------------
 private static string Helper__Format
                             (this IEnumerable<IReadOnlyPropertyBase> properties,
                              bool                                    includeTypes=false)
 {
  Debug.Assert(!Object.ReferenceEquals(properties,null));

  string comma="";

  var sb=new System.Text.StringBuilder();

  sb.Append('{');

  foreach(var p in properties)
  {
   Debug.Assert(!Object.ReferenceEquals(p,null));
   Debug.Assert(!Object.ReferenceEquals(p.Name,null));
   Debug.Assert(!Object.ReferenceEquals(p.ClrType,null));

   sb.Append(comma);

   sb.Append('\'');
   sb.Append(p.Name);
   sb.Append('\'');

   if(includeTypes)
   {
    sb.Append(" : ");
    sb.Append(p.ClrType.DisplayName(fullName: false));
   }//if

   comma=", ";
  }//foreach p

  sb.Append('}');

  return sb.ToString();
 }//Helper__Format
};//class ThrowError

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb

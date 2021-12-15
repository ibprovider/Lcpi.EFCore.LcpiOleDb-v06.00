////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 15.05.2018.
using System;
using System.Data;
using System.Linq.Expressions;

using NUnit.Framework;

using com_lib=lcpi.lib.com;
using structure_lib=lcpi.lib.structure;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.ThrowError{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_01

public static class TestSet_01
{
 [Test]
 public static void ArgErr__BadValueType()
 {
  try
  {
   xEFCore.ThrowError.ArgErr__BadValueType
    (xEFCore.ErrSourceID.FB_Common__TypeMapping__NUMERIC,
     "mmm",
     "ppp",
     typeof(int),
     typeof(decimal));
  }
  catch(ArgumentException e)
  {
   CheckErrors.PrintException_OK(e);

   CheckErrors.CheckException__BadArgumentValueType
    (e,
     CheckErrors.c_src__EFCoreDataProvider__FB_Common__TypeMapping__NUMERIC,
     "mmm",
     "ppp",
     typeof(int),
     typeof(decimal));

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//ArgErr__BadValueType

 //-----------------------------------------------------------------------
 [Test]
 public static void ArgErr__StringLiteralContainsZeroChar()
 {
  try
  {
   xEFCore.ThrowError.ArgErr__StringLiteralContainsZeroChar
    (xEFCore.ErrSourceID.FB_Common__TypeMapping__VARCHAR,
     "ppp",
     123);
  }
  catch(ArgumentException e)
  {
   CheckErrors.PrintException_OK(e);

   CheckErrors.CheckException__StringLiteralContainsZeroSymbol
    (e,
     CheckErrors.c_src__EFCoreDataProvider__FB_Common__TypeMapping__VARCHAR,
     "ppp",
     123);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//ArgErr__StringLiteralContainsZeroChar

 //-----------------------------------------------------------------------
 [Test]
 public static void ArgErr__BadListSize__3()
 {
  try
  {
   xEFCore.ThrowError.ArgErr__BadListSize
    (xEFCore.ErrSourceID.common,
     "m",
     "a",
     1);
  }
  catch(ArgumentException e)
  {
   CheckErrors.PrintException_OK(e);

   CheckErrors.CheckException__ArgErr_BadListSize
    (e,
     CheckErrors.c_src__EFCoreDataProvider__common,
     "m",
     "a",
     1);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//ArgErr__BadListSize__3

 //-----------------------------------------------------------------------
 [Test]
 public static void ArgErr__BadListSize__4()
 {
  try
  {
   xEFCore.ThrowError.ArgErr__BadListSize
    (xEFCore.ErrSourceID.common,
     "m",
     "a",
     123,
     321);
  }
  catch(ArgumentException e)
  {
   CheckErrors.PrintException_OK(e);

   CheckErrors.CheckException__ArgErr_BadListSize
    (e,
     CheckErrors.c_src__EFCoreDataProvider__common,
     "m",
     "a",
     123,
     321);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//ArgErr__BadListSize__4

 //-----------------------------------------------------------------------
 [Test]
 public static void FeatureNotSupported()
 {
  try
  {
   xEFCore.ThrowError.FeatureNotSupported
    (xEFCore.ErrSourceID.common,
     "FFF");
  }
  catch(structure_lib.exceptions.t_not_supported_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__common_err__feature_not_supported__1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "FFF");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//FeatureNotSupported

 //-----------------------------------------------------------------------
 [Test]
 public static void FeatureNotSupported__DesignTimeServices()
 {
  try
  {
   xEFCore.ThrowError.FeatureNotSupported__DesignTimeServices
    (xEFCore.ErrSourceID.common);
  }
  catch(structure_lib.exceptions.t_not_supported_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__common_err__feature_not_supported__1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "Design Time Services");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//FeatureNotSupported__DesignTimeServices

 //-----------------------------------------------------------------------
 [Test]
 public static void InvalidOp__DirectCallOfLinqMethodNotAllowed()
 {
  try
  {
   xEFCore.ThrowError.InvalidOp__DirectCallOfLinqMethodNotAllowed
    (xEFCore.ErrSourceID.DataTypes_Extensions__System_DateTime,
     "m1");
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__common_err__direct_call_of_linq_method_not_allowed_1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__DataTypes_Extensions__System_DateTime,
     "m1");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//InvalidOp__DirectCallOfLinqMethodNotAllowed

 //-----------------------------------------------------------------------
 [Test]
 public static void UnknownDbmsName()
 {
  try
  {
   xEFCore.ThrowError.UnknownDbmsName
    (xEFCore.ErrSourceID.Core_ConnectionOptionsInitializer,
     "ppp");
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__CommonErr__UnknownDbmsName
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__Core_ConnectionOptionsInitializer,
     "ppp");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//UnknownDbmsName

 //-----------------------------------------------------------------------
 [Test]
 public static void UnsupportedDbmsVersion()
 {
  try
  {
   xEFCore.ThrowError.UnsupportedDbmsVersion
    (xEFCore.ErrSourceID.Core_ConnectionOptionsInitializer,
     "ppp",
     new Version("1.2.3.4"));
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__CommonErr__UnsupportedDbmsName
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__Core_ConnectionOptionsInitializer,
     "ppp",
     new Version("1.2.3.4"));

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//UnsupportedDbmsVersion

 //-----------------------------------------------------------------------
 [Test]
 public static void UnsupportedConnectionDialect()
 {
  try
  {
   xEFCore.ThrowError.UnsupportedConnectionDialect
    (xEFCore.ErrSourceID.Core_ConnectionOptionsInitializer,
     4);
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__CommonErr__UnsupportedConnectionDialect
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__Core_ConnectionOptionsInitializer,
     4);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//UnsupportedConnectionDialect

 //-----------------------------------------------------------------------
 [Test]
 public static void EmptyObjectName()
 {
  try
  {
   xEFCore.ThrowError.EmptyObjectName
    (xEFCore.ErrSourceID.IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d1);
  }
  catch(InvalidOperationException e)
  {
   CheckErrors.PrintException_OK(e);

   CheckErrors.CheckException__common_err__empty_object_name_0
    (e,
     CheckErrors.c_src__EFCoreDataProvider__IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d1);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//BadSymbolInUnquotedObjectName

 //-----------------------------------------------------------------------
 [Test]
 public static void BadSymbolInUnquotedObjectName()
 {
  try
  {
   xEFCore.ThrowError.BadSymbolInUnquotedObjectName
    (xEFCore.ErrSourceID.IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d1,
     "1\00",
     1);
  }
  catch(InvalidOperationException e)
  {
   CheckErrors.PrintException_OK(e);

   CheckErrors.CheckException__common_err__bad_symbol_in_unquoted_object_name_2
    (e,
     CheckErrors.c_src__EFCoreDataProvider__IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d1,
     1,
     0);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//BadSymbolInUnquotedObjectName

 //-----------------------------------------------------------------------
 [Test]
 public static void BadSymbolInQuotedObjectName()
 {
  try
  {
   xEFCore.ThrowError.BadSymbolInQuotedObjectName
    (xEFCore.ErrSourceID.IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d3,
     "1\00",
     1);
  }
  catch(InvalidOperationException e)
  {
   CheckErrors.PrintException_OK(e);

   CheckErrors.CheckException__common_err__bad_symbol_in_quoted_object_name_2
    (e,
     CheckErrors.c_src__EFCoreDataProvider__IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d3,
     1,
     0);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//BadSymbolInQuotedObjectName

 //-----------------------------------------------------------------------
 [Test]
 public static void NotDefinedNamedParameterPrefix()
 {
  try
  {
   xEFCore.ThrowError.NotDefinedNamedParameterPrefix
    (xEFCore.ErrSourceID.Common_EngineSvc__CommandParamereterNameBuilder__Error_NoPrefix);
  }
  catch(InvalidOperationException e)
  {
   CheckErrors.PrintException_OK(e);

   CheckErrors.CheckException__common_err__not_defined_cmd_parameter_prefix_0
    (e,
     CheckErrors.c_src__EFCoreDataProvider__Common_EngineSvc__CommandParamereterNameBuilder__Error_NoPrefix);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//NotDefinedNamedParameterPrefix

 //-----------------------------------------------------------------------
 [Test]
 public static void BadFormatOfCmdParameterName()
 {
  try
  {
   xEFCore.ThrowError.BadFormatOfCmdParameterName
    (xEFCore.ErrSourceID.Common_EngineSvc__CommandParamereterNameBuilder__Error_NoPrefix,
     "abcd");
  }
  catch(InvalidOperationException e)
  {
   CheckErrors.PrintException_OK(e);

   CheckErrors.CheckException__common_err__bad_cmd_parameter_name_format_1
    (e,
     CheckErrors.c_src__EFCoreDataProvider__Common_EngineSvc__CommandParamereterNameBuilder__Error_NoPrefix,
     "abcd");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//BadFormatOfCmdParameterName

 //-----------------------------------------------------------------------
 [Test]
 public static void BadFormatOfCmdParameterName_IncorrectPrefix()
 {
  try
  {
   xEFCore.ThrowError.BadFormatOfCmdParameterName_IncorrectPrefix
    (xEFCore.ErrSourceID.Common_EngineSvc__CommandParamereterNameBuilder__Error_NoPrefix,
     "abcd");
  }
  catch(InvalidOperationException e)
  {
   CheckErrors.PrintException_OK(e);

   CheckErrors.CheckException__common_err__bad_cmd_parameter_name_format__incorrect_prefix_1
    (e,
     CheckErrors.c_src__EFCoreDataProvider__Common_EngineSvc__CommandParamereterNameBuilder__Error_NoPrefix,
     "abcd");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//BadFormatOfCmdParameterName_IncorrectPrefix

 //-----------------------------------------------------------------------
 [Test]
 public static void NoProviderConfigured()
 {
  try
  {
   xEFCore.ThrowError.NoProviderConfigured
    (xEFCore.ErrSourceID.LcpiOleDb__DbContextOptionsExtension);
  }
  catch(InvalidOperationException e)
  {
   CheckErrors.PrintException_OK(e);

   CheckErrors.CheckException__common_err__no_provider_configured_0
    (e,
     CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__DbContextOptionsExtension);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//NoProviderConfigured

 //-----------------------------------------------------------------------
 [Test]
 public static void MultipleProviderConfigured()
 {
  try
  {
   xEFCore.ThrowError.MultipleProviderConfigured
    (xEFCore.ErrSourceID.LcpiOleDb__DbContextOptionsExtension);
  }
  catch(InvalidOperationException e)
  {
   CheckErrors.PrintException_OK(e);

   CheckErrors.CheckException__common_err__multiple_provider_configured_0
    (e,
     CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__DbContextOptionsExtension);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//MultipleProviderConfigured

 //-----------------------------------------------------------------------
 [Test]
 public static void UnkColumnName()
 {
  var table=new DataTable("ttt");

  var col=table.Columns.Add("ccc1",typeof(string));

  var row=table.NewRow();

  try
  {
   xEFCore.ThrowError.UnkColumnName
    (xEFCore.ErrSourceID.common,
     table,
     "cccc");
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__common_err__unk_column_name__2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "ttt",
     "cccc");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//UnkColumnName

 //-----------------------------------------------------------------------
 [Test]
 public static void InvalidColumnValue()
 {
  var table=new DataTable("ttt");

  var col=table.Columns.Add("ccc1",typeof(string));

  var row=table.NewRow();

  try
  {
   xEFCore.ThrowError.InvalidColumnValue
    (xEFCore.ErrSourceID.common,
     row,
     0);
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__common_err__invalid_column_value__4
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "ttt",
     0,
     "ccc1",
     "#DBNULL");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//InvalidColumnValue

 //-----------------------------------------------------------------------
 [Test]
 public static void InvalidColumnValueType()
 {
  var table=new DataTable("ttt");

  var col=table.Columns.Add("ccc1",typeof(object));

  var row=table.NewRow();

  row[0]=1;

  try
  {
   xEFCore.ThrowError.InvalidColumnValueType
    (xEFCore.ErrSourceID.common,
     row,
     0,
     typeof(string));
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__common_err__invalid_column_value_type__5
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "ttt",
     0,
     "ccc1",
     typeof(int),
     typeof(string));

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//InvalidColumnValueType

 //-----------------------------------------------------------------------
 [Test]
 public static void UnsupportedDataTypesConversion()
 {
  try
  {
   xEFCore.ThrowError.UnsupportedDataTypesConversion
    (xEFCore.ErrSourceID.Core_ValueInstaller,
     typeof(Int64),
     typeof(Int16));
  }
  catch(InvalidOperationException e)
  {
   CheckErrors.PrintException_OK(e);

   CheckErrors.CheckException__common_err__unsupported_datatypes_conversion_2
    (e,
     CheckErrors.c_src__EFCoreDataProvider__Core_ValueInstaller,
     typeof(Int64),
     typeof(Int16));

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//UnsupportedDataTypesConversion

 //-----------------------------------------------------------------------
 [Test]
 public static void FailedToConvertValueBetweenTypes__overflow()
 {
  try
  {
   xEFCore.ThrowError.FailedToConvertValueBetweenTypes__overflow
    (xEFCore.ErrSourceID.Core_ValueCvt__Int64__Int32,
     typeof(Int64),
     typeof(Int16));
  }
  catch(OverflowException e)
  {
   CheckErrors.PrintException_OK(e);

   CheckErrors.CheckException__common_err__failed_to_convert_value_between_types_2
    (e,
     CheckErrors.c_src__EFCoreDataProvider__Core_ValueCvt__Int64__Int32,
     com_lib.HResultCode.DB_E_DATAOVERFLOW,
     typeof(Int64),
     typeof(Int16));

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//FailedToConvertValueBetweenTypes__overflow

 //-----------------------------------------------------------------------
 [Test]
 public static void TargetPropertyNotAcceptNullValue()
 {
  try
  {
   xEFCore.ThrowError.TargetPropertyNotAcceptNullValue
    (xEFCore.ErrSourceID.Core_ValueInstaller);
  }
  catch(InvalidOperationException e)
  {
   CheckErrors.PrintException_OK(e);

   CheckErrors.CheckException__common_err__target_property_not_accept_null_value_0
    (e,
     CheckErrors.c_src__EFCoreDataProvider__Core_ValueInstaller);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TargetPropertyNotAcceptNullValue

 //-----------------------------------------------------------------------
 [Test]
 public static void FailedToProcessValue()
 {
  try
  {
   try
   {
    xEFCore.ThrowError.CsUtf16Err__BadSequence
     (xEFCore.ErrSourceID.common,
      "CCC",
     321); //throw
   }
   catch(xEFCore.LcpiOleDb__DataToolException e)
   {
    xEFCore.ThrowError.FailedToProcessValue
     (xEFCore.ErrSourceID.common,
      "MY_VALUE",
      e);
   }//catch
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (2,
     TestUtils.GetRecordCount(e));

   Assert.IsNotNull
    (TestUtils.GetRecord(e,0));

   Assert.IsNotNull
    (TestUtils.GetRecord(e,1));

   CheckErrors.CheckErrorRecord__cs_utf16_err__bad_sequence__2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "CCC",
     321);

   CheckErrors.CheckErrorRecord__common_err__failed_to_process_value_1
    (TestUtils.GetRecord(e,1),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "MY_VALUE");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//FailedToProcessValue

 //-----------------------------------------------------------------------
 [Test]
 public static void IndexOutOfRange()
 {
  try
  {
   xEFCore.ThrowError.IndexOutOfRange
    (xEFCore.ErrSourceID.common,
     3,
     2);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (TestUtils.GetRecordCount(e),
     1);

   CheckErrors.CheckErrorRecord__common_err__index_out_of_range__2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     3,
     2);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//IndexOutOfRange

 //-----------------------------------------------------------------------
 [Test]
 public static void EmptyListOfValues()
 {
  try
  {
   xEFCore.ThrowError.EmptyListOfValues
    (xEFCore.ErrSourceID.common);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (TestUtils.GetRecordCount(e),
     1);

   CheckErrors.CheckErrorRecord__common_err__empty_list_of_values__0
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//EmptyListOfValues

 //-----------------------------------------------------------------------
 [Test]
 public static void MethodNotSupported()
 {
  try
  {
   xEFCore.ThrowError.MethodNotSupported
    (xEFCore.ErrSourceID.common,
     typeof(object),
     "ADD",
     new System.Type[]{typeof(string),typeof(short)});
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (TestUtils.GetRecordCount(e),
     1);

   CheckErrors.CheckErrorRecord__common_err__type_not_support_method_3
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "System.Object",
     "ADD",
     "System.String, System.Int16");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//MethodNotSupported

 //-----------------------------------------------------------------------
 [Test]
 public static void CantRemapNormalMethodCall()
 {
  try
  {
   xEFCore.ThrowError.CantRemapNormalMethodCall
    (xEFCore.ErrSourceID.common,
     xEFCore.Structure.Structure_MethodInfoCache.MethodInfoOf__Object__std__Equals__object,
     typeof(int),
     new System.Type[]{typeof(string),typeof(short)});
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (TestUtils.GetRecordCount(e),
     1);

   CheckErrors.CheckErrorRecord__common_err__cant_remap_normal_method_3
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "System.Object.Equals(System.Object)",
     "System.Int32",
     "System.String, System.Int16");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//CantRemapNormalMethodCall

 //-----------------------------------------------------------------------
 [Test]
 public static void CantRemapGenericMethodCall()
 {
  try
  {
   xEFCore.ThrowError.CantRemapGenericMethodCall
    (xEFCore.ErrSourceID.common,
     xEFCore.Structure.Structure_MethodInfoCache.MethodInfoOf__NullableInt16__std__GetValueOrDefault,
     typeof(int),
     new System.Type[]{typeof(string),typeof(short)},
     new System.Type[]{typeof(short),typeof(string)});
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (TestUtils.GetRecordCount(e),
     1);

   CheckErrors.CheckErrorRecord__common_err__cant_remap_generic_method_4
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "Nullable<System.Int16>.GetValueOrDefault()",
     "System.Int32",
     "System.String, System.Int16",
     "System.Int16, System.String");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//CantRemapGenericMethodCall

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__CantMapClrTypeToProviderDatatype()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__CantMapClrTypeToProviderDatatype
    (xEFCore.ErrSourceID.FB_V03_0_0_D3__TypeMappingSource,
     typeof(Int64));
  }
  catch(InvalidOperationException e)
  {
   CheckErrors.PrintException_OK(e);

   CheckErrors.CheckException__type_mapping_err__cant_map_clr_type_to_provider_data_type_1
    (e,
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0_D3__TypeMappingSource,
     typeof(Int64));

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__CantMapClrTypeToProviderDatatype

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__CantMapInfoToProviderDatatype__1()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__CantMapInfoToProviderDatatype
    (xEFCore.ErrSourceID.FB_V03_0_0_D3__TypeMappingSource,
     typeof(Int64),
     "asdfg");
  }
  catch(InvalidOperationException e)
  {
   CheckErrors.PrintException_OK(e);

   CheckErrors.CheckException__type_mapping_err__cant_map_info_to_provider_data_type_2
    (e,
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0_D3__TypeMappingSource,
     typeof(Int64),
     "asdfg");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__CantMapInfoToProviderDatatype__1

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__UnknownStoreTypeName()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__UnknownStoreTypeName
    (xEFCore.ErrSourceID.FB_V03_0_0_D3__TypeMappingSource,
     "AAA212");
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__unknown_StoreTypeName_1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0_D3__TypeMappingSource,
     "AAA212");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__UnknownStoreTypeName

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__UnknownStoreTypeName__2()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__UnknownStoreTypeName
    (xEFCore.ErrSourceID.FB_V03_0_0_D3__TypeMappingSource,
     "AAA212",
     "COLUMN_SIGN");
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__unknown_StoreTypeName_2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0_D3__TypeMappingSource,
     "AAA212",
     "COLUMN_SIGN");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__UnknownStoreTypeName__2

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__UnknownStoreTypeName__4()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__UnknownStoreTypeName
    (xEFCore.ErrSourceID.FB_V03_0_0_D3__TypeMappingSource,
     "AAA212",
     "COLUMN_NAME",
     "TABLE_NAME",
     "SCHEMA_NAME");
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__unknown_StoreTypeName_2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0_D3__TypeMappingSource,
     "AAA212",
     "{SCHEMA_NAME}.{TABLE_NAME}.{COLUMN_NAME}");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__UnknownStoreTypeName__2

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__UnexpectedStoreTypeName()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__UnexpectedStoreTypeName
    (xEFCore.ErrSourceID.FB_V03_0_0_D3__TypeMappingSource,
     "AAA",
     "BBB");
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__unexpected_StoreTypeName_2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0_D3__TypeMappingSource,
     "AAA",
     "BBB");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__UnexpectedStoreTypeName

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__UnexpectedStoreTypeNameBase()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__UnexpectedStoreTypeNameBase
    (xEFCore.ErrSourceID.FB_V03_0_0_D3__TypeMappingSource,
     "AAA1",
     "BBB1");
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__unexpected_StoreTypeNameBase_2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0_D3__TypeMappingSource,
     "AAA1",
     "BBB1");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__UnexpectedStoreTypeNameBase

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__UnexpectedSize()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__UnexpectedSize
    (xEFCore.ErrSourceID.FB_V03_0_0_D3__TypeMappingSource,
     123);
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__unexpected_Size_1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0_D3__TypeMappingSource,
     123);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__UnexpectedSize

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__NotDefinedSize()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__NotDefinedSize
    (xEFCore.ErrSourceID.FB_V03_0_0_D3__TypeMappingSource);
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__not_defined_Size_0
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0_D3__TypeMappingSource);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__NotDefinedSize

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__TooLargeSize()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__TooLargeSize
    (xEFCore.ErrSourceID.FB_V03_0_0_D3__TypeMappingSource,
    4,
    1);
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__too_large_Size_2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0_D3__TypeMappingSource,
     4,
     1);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__TooLargeSize

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__UnexpectedIsFixedLength()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__UnexpectedIsFixedLength
    (xEFCore.ErrSourceID.FB_V03_0_0_D3__TypeMappingSource,
    true,
    false);
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__unexpected_IsFixedLength_2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0_D3__TypeMappingSource,
     true,
     false);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__UnexpectedIsFixedLength

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__UnexpectedIsUnicode()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__UnexpectedIsUnicode
    (xEFCore.ErrSourceID.FB_V03_0_0_D3__TypeMappingSource,
    true,
    false);
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__unexpected_IsUnicode_2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0_D3__TypeMappingSource,
     true,
     false);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__UnexpectedIsUnicode

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__UnexpectedClrType()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__UnexpectedClrType
    (xEFCore.ErrSourceID.FB_V03_0_0_D3__TypeMappingSource,
    typeof(int),
    typeof(string));
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__unexpected_ClrType_2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0_D3__TypeMappingSource,
     typeof(int),
     typeof(string));

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__UnexpectedClrType

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__UnexpectedIsRowVersion()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__UnexpectedIsRowVersion
    (xEFCore.ErrSourceID.FB_V03_0_0_D3__TypeMappingSource,
    false,
    true);
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__unexpected_IsRowVersion_2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0_D3__TypeMappingSource,
     false,
     true);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__UnexpectedIsRowVersion

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__UnexpectedPrecision()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__UnexpectedPrecision
    (xEFCore.ErrSourceID.FB_V03_0_0_D3__TypeMappingSource,
    321);
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__unexpected_Precision_1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0_D3__TypeMappingSource,
     321);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__UnexpectedPrecision

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__NotDefinedPrecision()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__NotDefinedPrecision
    (xEFCore.ErrSourceID.FB_V03_0_0_D3__TypeMappingSource);
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__not_defined_Precision_0
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0_D3__TypeMappingSource);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__NotDefinedPrecision

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__TooLargePrecision()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__TooLargePrecision
    (xEFCore.ErrSourceID.FB_V03_0_0_D3__TypeMappingSource,
    4,
    2);
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__too_large_Precision_2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0_D3__TypeMappingSource,
     4,
     2);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__TooLargePrecision

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__NotAllowedDefinitionOfScaleWithoutPrecision()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__NotAllowedDefinitionOfScaleWithoutPrecision
    (xEFCore.ErrSourceID.common,
    4);
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__not_allowed_definition_of_Scale_without_Precision_1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     4);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__NotAllowedDefinitionOfScaleWithoutPrecision

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__UnexpectedScale()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__UnexpectedScale
    (xEFCore.ErrSourceID.FB_V03_0_0_D3__TypeMappingSource,
    4);
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__unexpected_Scale_1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0_D3__TypeMappingSource,
     4);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__UnexpectedScale

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__NotDefinedScale()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__NotDefinedScale
    (xEFCore.ErrSourceID.FB_V03_0_0_D3__TypeMappingSource);
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__not_defined_Scale_0
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0_D3__TypeMappingSource);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__NotDefinedScale

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__TooLargeScale()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__TooLargeScale
    (xEFCore.ErrSourceID.FB_V03_0_0_D3__TypeMappingSource,
     5,
     3);
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__too_large_Scale_2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0_D3__TypeMappingSource,
     5,
     3);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__TooLargeScale

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__CantConvertTimeSpanToDatabaseFormat__OutOfRange()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__CantConvertTimeSpanToDatabaseFormat__OutOfRange
    (xEFCore.ErrSourceID.common,
     new System.TimeSpan(999,1,2,3,123)+new System.TimeSpan(4*1000),
     "DATABASE_TYPE(9,4)",
     new System.TimeSpan(-999999999L*1000),
     new System.TimeSpan(+999999999L*1000));
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__cant_convert_TimeSpan_to_database_format__out_of_range__4
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "999.01:02:03.1234000",
     "DATABASE_TYPE(9,4)",
     "-1.03:46:39.9999000",
     "1.03:46:39.9999000");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__CantConvertTimeSpanToDatabaseFormat__OutOfRange

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__CantConvertDatabaseValueToTimeSpan__OutOfRange()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__CantConvertDatabaseValueToTimeSpan__OutOfRange
    (xEFCore.ErrSourceID.common,
     123456789.987654321m,
     "DATABASE_TYPE(9,4)",
     -999999.999m,
     +999999.999m);
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__cant_convert_database_value_to_TimeSpan__out_of_range__4
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "123456789.987654321",
     "DATABASE_TYPE(9,4)",
     "-999999.999",
     "999999.999");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__CantConvertDatabaseValueToTimeSpan__OutOfRange

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__CnDialectNotAllowUsageTypeInDDL()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__CnDialectNotAllowUsageTypeInDDL
    (xEFCore.ErrSourceID.common,
     1,
     "TYPENAME");
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__cn_dialect_does_not_support_usage_of_type_in_DDL_query_2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     1,
     "TYPENAME");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__CantConvertDatabaseValueToTimeSpan__OutOfRange

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__MultipleDefinitionOfTypeProperty()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__MultipleDefinitionOfTypeProperty
    (xEFCore.ErrSourceID.common,
     "PROPNAME",
     "v1",
     "v2");
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__multiple_definition_of_type_property_3
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "PROPNAME",
     "v1",
     "v2");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__MultipleDefinitionOfTypeProperty

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__FailedToParseDataTypeLength()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__FailedToParseDataTypeLength
    (xEFCore.ErrSourceID.common,
     "DATATYPESIGN");
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__failed_to_parse_datatype_length_1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "DATATYPESIGN");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__FailedToParseDataTypeLength

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__FailedToParseDataTypePrecision()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__FailedToParseDataTypePrecision
    (xEFCore.ErrSourceID.common,
     "DATATYPESIGN1");
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__failed_to_parse_datatype_precision_1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "DATATYPESIGN1");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__FailedToParseDataTypePrecision

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__FailedToParseDataTypeScale()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__FailedToParseDataTypeScale
    (xEFCore.ErrSourceID.common,
     "DATATYPESIGN2");
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__failed_to_parse_datatype_scale_1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "DATATYPESIGN2");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__FailedToParseDataTypeScale

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__TooLargeLengthOfDataType()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__TooLargeLengthOfDataType
    (xEFCore.ErrSourceID.common,
     "DATATYPESIGN3");
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__too_large_length_of_datatype_1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "DATATYPESIGN3");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__TooLargeLengthOfDataType

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__TooLargePrecisionOfDataType()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__TooLargePrecisionOfDataType
    (xEFCore.ErrSourceID.common,
     "DATATYPESIGN4");
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__too_large_precision_of_datatype_1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "DATATYPESIGN4");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__TooLargePrecisionOfDataType

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__TooLargeScaleOfDataType()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__TooLargeScaleOfDataType
    (xEFCore.ErrSourceID.common,
     "DATATYPESIGN5");
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__too_large_scale_of_datatype_1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "DATATYPESIGN5");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__TooLargeScaleOfDataType

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__IncompletedDataTypeDefinition_n0()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__IncompletedDataTypeDefinition
    (xEFCore.ErrSourceID.common);
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__incompleted_datatype_definition_0
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__IncompletedDataTypeDefinition_n0

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__IncompletedDataTypeDefinition_n1()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__IncompletedDataTypeDefinition
    (xEFCore.ErrSourceID.common,
     "BLABLABLA");
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__incompleted_datatype_definition_1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "BLABLABLA");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__IncompletedDataTypeDefinition_n1

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__BadDataTypeDefinition()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__BadDataTypeDefinition
    (xEFCore.ErrSourceID.common,
     "BLABLABLA");
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__bad_datatype_definition_1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "BLABLABLA");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__BadDataTypeDefinition

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__NoCharSetName()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__NoCharSetName
    (xEFCore.ErrSourceID.common,
     "BLABLABLA");
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__not_defined_charset_name_1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "BLABLABLA");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__NoCharSetName

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__NoSubTypeName()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__NoSubTypeName
    (xEFCore.ErrSourceID.common,
     "BLABLABLA");
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__not_defined_subtype_name_1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "BLABLABLA");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__NoSubTypeName

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__UnknownBlobSubType()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__UnknownBlobSubType
    (xEFCore.ErrSourceID.common,
     "UNKNOWNBLOBSUBTYPE");
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__unknown_blob_subtype_1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "UNKNOWNBLOBSUBTYPE");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__UnknownBlobSubType

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__DefinitionOfBlobCharsetAllowedOnlyForSubTypeText()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__DefinitionOfBlobCharsetAllowedOnlyForSubTypeText
    (xEFCore.ErrSourceID.common);
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__definition_of_blob_charset_allowed_only_for_subtype_text_0
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__DefinitionOfBlobCharsetAllowedOnlyForSubTypeText

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMappingErr__UnexpectedDataAtEndOfDataTypeDefinition()
 {
  try
  {
   xEFCore.ThrowError.TypeMappingErr__UnexpectedDataAtEndOfDataTypeDefinition
    (xEFCore.ErrSourceID.common,
     "UNKNOWNDATA");
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__unexpected_data_at_end_of_datatype_definition_1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "UNKNOWNDATA");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMappingErr__UnexpectedDataAtEndOfDataTypeDefinition

 //-----------------------------------------------------------------------
 [Test]
 public static void UnexpectedCommandParameterDirection()
 {
  try
  {
   xEFCore.ThrowError.UnexpectedCommandParameterDirection
    (xEFCore.ErrSourceID.common,
     "param3",
     System.Data.ParameterDirection.ReturnValue);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckException__common_err__unexpected_command_param_direction_2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "param3",
     System.Data.ParameterDirection.ReturnValue);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//UnexpectedCommandParameterDirection

 //-----------------------------------------------------------------------
 [Test]
 public static void NoCommandParameterValue()
 {
  try
  {
   xEFCore.ThrowError.NoCommandParameterValue
    (xEFCore.ErrSourceID.common,
     "param5");
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckException__common_err__no_command_param_value_1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "param5");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//NoCommandParameterValue

 //-----------------------------------------------------------------------
 // [Test]
 // public static void LocalEvalErr__MemberNotSupported()
 // {
 //  try
 //  {
 //   xEFCore.ThrowError.LocalEvalErr__MemberNotSupported
 //    (xEFCore.ErrSourceID.LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,
 //     xEFCore.Structure.Structure_MemberIdCache.MemberIdOf__String_Length);
 //  }
 //  catch(xEFCore.LcpiOleDb__DataToolException e)
 //  {
 //   CheckErrors.PrintException_OK(e);
 //
 //   Assert.AreEqual
 //    (1,
 //     TestUtils.GetRecordCount(e));
 //
 //   CheckErrors.CheckErrorRecord__local_eval_err__member_not_supported_2
 //    (TestUtils.GetRecord(e,0),
 //     CheckErrors.c_src__EFCoreDataProvider__Common_EngineSvc__ExpressionTree__PrepareForLocalEvaluation,
 //     typeof(string),
 //     "Length");
 //
 //   return;
 //  }//catch
 //
 //  TestServices.ThrowWeWaitError();
 // }//LocalEvalErr__MemberNotSupported

 //-----------------------------------------------------------------------
 [Test]
 public static void LocalEvalErr__UnaryOperatorNotSupported()
 {
  try
  {
   xEFCore.ThrowError.LocalEvalErr__UnaryOperatorNotSupported
    (xEFCore.ErrSourceID.LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,
     System.Linq.Expressions.ExpressionType.Not);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__local_eval_err__unary_operator_not_supported_1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,
     System.Linq.Expressions.ExpressionType.Not);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//LocalEvalErr__BinaryOperatorNotSupported

 //-----------------------------------------------------------------------
 [Test]
 public static void LocalEvalErr__UnaryOperatorNotSupported_2()
 {
  try
  {
   xEFCore.ThrowError.LocalEvalErr__UnaryOperatorNotSupported
    (xEFCore.ErrSourceID.LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,
     System.Linq.Expressions.ExpressionType.Not,
     typeof(int));
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__local_eval_err__unary_operator_not_supported_2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,
     System.Linq.Expressions.ExpressionType.Not,
     typeof(int));

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//LocalEvalErr__UnaryOperatorNotSupported_2

 //-----------------------------------------------------------------------
 [Test]
 public static void LocalEvalErr__BinaryOperatorNotSupported___sys_etype()
 {
  try
  {
   xEFCore.ThrowError.LocalEvalErr__BinaryOperatorNotSupported
    (xEFCore.ErrSourceID.LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,
     System.Linq.Expressions.ExpressionType.Add,
     typeof(string),
     typeof(int));
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__local_eval_err__binary_operator_not_supported_3
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,
     System.Linq.Expressions.ExpressionType.Add,
     typeof(string),
     typeof(int));

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//LocalEvalErr__BinaryOperatorNotSupported___sys_etype

 //-----------------------------------------------------------------------
 [Test]
 public static void LocalEvalErr__BinaryOperatorNotSupported___lcpi_etype()
 {
  try
  {
   xEFCore.ThrowError.LocalEvalErr__BinaryOperatorNotSupported
    (xEFCore.ErrSourceID.LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,
     xEFCore.LcpiOleDb__ExpressionType.Subtract,
     typeof(string),
     typeof(int));
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__local_eval_err__binary_operator_not_supported_3
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,
     xEFCore.LcpiOleDb__ExpressionType.Subtract,
     "System.String",
     "System.Int32");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//LocalEvalErr__BinaryOperatorNotSupported___lcpi_etype

 //-----------------------------------------------------------------------
 [Test]
 public static void LocalEvalErr__MethodNotSupported()
 {
  try
  {
   xEFCore.ThrowError.LocalEvalErr__MethodNotSupported
    (xEFCore.ErrSourceID.LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,
     xEFCore.Structure.Structure_MethodInfoCache.MethodInfoOf__String__std__TrimEnd__chars);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__local_eval_err__method_not_supported_1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,
     "System.String.TrimEnd(System.Char[])");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//LocalEvalErr__MethodNotSupported

 //-----------------------------------------------------------------------
 [Test]
 public static void LocalEvalErr__MemberNotSupported()
 {
  try
  {
   xEFCore.ThrowError.LocalEvalErr__MemberNotSupported
    (xEFCore.ErrSourceID.LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,
     xEFCore.Structure.Structure_MemberIdCache.MemberIdOf__String__std__Length);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__local_eval_err__member_not_supported_2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,
     xEFCore.Structure.Structure_MemberIdCache.MemberIdOf__String__std__Length.ObjectType,
     xEFCore.Structure.Structure_MemberIdCache.MemberIdOf__String__std__Length.MemberName);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//LocalEvalErr__MemberNotSupported

 //-----------------------------------------------------------------------
 [Test]
 public static void LocalEvalErr__UnexpectedResultTypeOfLogicalExpression()
 {
  try
  {
   xEFCore.ThrowError.LocalEvalErr__UnexpectedResultTypeOfLogicalExpression
    (xEFCore.ErrSourceID.common,
     typeof(string));
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__local_eval_err__unexpected_result_type_of_logical_expression_1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     typeof(string));

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//LocalEvalErr__UnexpectedResultTypeOfLogicalExpression

 //-----------------------------------------------------------------------
 [Test]
 public static void LocalEvalErr__CantRemapMethodCall___static()
 {
  try
  {
   xEFCore.ThrowError.LocalEvalErr__CantRemapMethodCall
    (xEFCore.ErrSourceID.LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,
     xEFCore.Structure.Structure_MethodInfoCache.MethodInfoOf__String__std__Substring__from,
     /*newObject*/null,
     new System.Linq.Expressions.Expression[]
     {
      System.Linq.Expressions.Expression.Constant(""),
      System.Linq.Expressions.Expression.Constant(1)
     });
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__local_eval_err__cant_remap_static_method_2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,
     "System.String.Substring(System.Int32)",
     "System.String, System.Int32");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//LocalEvalErr__CantRemapMethodCall___static

 //-----------------------------------------------------------------------
 [Test]
 public static void LocalEvalErr__CantRemapMethodCall___instance()
 {
  try
  {
   xEFCore.ThrowError.LocalEvalErr__CantRemapMethodCall
    (xEFCore.ErrSourceID.LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,
     xEFCore.Structure.Structure_MethodInfoCache.MethodInfoOf__String__std__Substring__from,
     /*newObject*/System.Linq.Expressions.Expression.Constant(2),
     new System.Linq.Expressions.Expression[]
     {
      System.Linq.Expressions.Expression.Constant(""),
      System.Linq.Expressions.Expression.Constant(1)
     });
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__local_eval_err__cant_remap_instance_method_2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,
     "System.String.Substring(System.Int32)",
     "System.Int32",
     "System.String, System.Int32");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//LocalEvalErr__CantRemapMethodCall___instance

 //-----------------------------------------------------------------------
 // [Test]
 // public static void LocalEvalErr__AmbiguousRemapMethodCall()
 // {
 //  try
 //  {
 //   xEFCore.ThrowError.LocalEvalErr__AmbiguousRemapMethodCall
 //    (xEFCore.ErrSourceID.LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,
 //     xEFCore.Structure.Structure_MethodInfoCache.MethodInfoOf__String__std__Substring__from,
 //     new System.Linq.Expressions.Expression[]
 //     {
 //      System.Linq.Expressions.Expression.Constant(""),
 //      System.Linq.Expressions.Expression.Constant(1)
 //     },
 //     new System.Reflection.MethodInfo[]
 //     {
 //      xEFCore.Structure.Structure_MethodInfoCache.MethodInfoOf__String__std__Substring__from,
 //      xEFCore.Structure.Structure_MethodInfoCache.MethodInfoOf__String__ext__Substring__from,
 //     });
 //  }
 //  catch(xEFCore.LcpiOleDb__DataToolException e)
 //  {
 //   CheckErrors.PrintException_OK(e);
 //
 //   Assert.AreEqual
 //    (1,
 //     TestUtils.GetRecordCount(e));
 //
 //   CheckErrors.CheckErrorRecord__local_eval_err__ambiguous_remap_method_3
 //    (TestUtils.GetRecord(e,0),
 //     CheckErrors.c_src__EFCoreDataProvider__Common_EngineSvc__ExpressionTree__PrepareForLocalEvaluation,
 //     "System.String.Substring(System.Int32)",
 //     "System.String, System.Int32",
 //     "\n"
 //    +"1. System.String.Substring(System.Int32)\n"
 //    +"2. Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DataTypes.Extensions.System_String.Substring(this System.String, Nullable<System.Int32>)");
 //
 //   return;
 //  }//catch
 //
 //  TestServices.ThrowWeWaitError();
 // }//LocalEvalErr__AmbiguousRemapMethodCall

 //-----------------------------------------------------------------------
 [Test]
 public static void LocalEvalErr__CantRemapObjectCreation()
 {
  try
  {
   xEFCore.ThrowError.LocalEvalErr__CantRemapObjectCreation
    (xEFCore.ErrSourceID.LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,
     typeof(TestTypes.Enums.EnumInt16?),
     typeof(short?),
     new System.Linq.Expressions.Expression[]
     {
      System.Linq.Expressions.Expression.Constant((short)1)
     });
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__local_eval_err__cant_remap_object_construction_3
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,
     "Nullable<EFCore_LcpiOleDb_Tests.General.TestTypes.Enums.EnumInt16>",
     "Nullable<System.Int16>",
     "System.Int16");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//LocalEvalErr__CantRemapObjectCreation

 //-----------------------------------------------------------------------
 [Test]
 public static void LocalEvalErr__ComparisonOfArraysWithDifferentLEngthNotSupported()
 {
  try
  {
   xEFCore.ThrowError.LocalEvalErr__ComparisonOfArraysWithDifferentLengthNotSupported
    (xEFCore.ErrSourceID.Root_Query_Local_Expressions__Op2_MasterCode__Equal___Array1_generic__Array1_generic,
     2,
     3);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__local_eval_err__comparison_of_arrays_with_different_length_not_supported_2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Op2_MasterCode__Equal___Array1_generic__Array1_generic,
     2,
     3);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//LocalEvalErr__ComparisonOfArraysWithDifferentLEngthNotSupported

 //-----------------------------------------------------------------------
 [Test]
 public static void LocalEvalErr__FailedToCompareElementOfArrays__pt1()
 {
  Exception
   innerException
    =new InvalidOperationException("OHOHO");

  var pt
   =new[]{123};

  try
  {
   xEFCore.ThrowError.LocalEvalErr__FailedToCompareElementOfArrays
    (xEFCore.ErrSourceID.Root_Query_Local_Expressions__Op2_MasterCode__Equal___Array1_generic__Array1_generic,
     pt,
     innerException);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreSame
    (innerException,
     e.InnerException);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__local_eval_err__failed_to_compare_element_of_arrays_1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Op2_MasterCode__Equal___Array1_generic__Array1_generic,
     pt);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//LocalEvalErr__FailedToCompareElementOfArrays__pt1

 //-----------------------------------------------------------------------
 [Test]
 public static void LocalEvalErr__FailedToCompareElementOfArrays__pt2()
 {
  Exception
   innerException
    =new InvalidOperationException("OHOHO321");

  var pt
   =new[]{123,321};

  try
  {
   xEFCore.ThrowError.LocalEvalErr__FailedToCompareElementOfArrays
    (xEFCore.ErrSourceID.Root_Query_Local_Expressions__Op2_MasterCode__Equal___Array1_generic__Array1_generic,
     pt,
     innerException);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreSame
    (innerException,
     e.InnerException);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__local_eval_err__failed_to_compare_element_of_arrays_1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Op2_MasterCode__Equal___Array1_generic__Array1_generic,
     pt);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//LocalEvalErr__FailedToCompareElementOfArrays__pt2

 //-----------------------------------------------------------------------
 [Test]
 public static void LocalEvalErr__CantConvertArrayElementValueToRequiredType__pt1()
 {
  var pt
   =new[]{123};

  try
  {
   xEFCore.ThrowError.LocalEvalErr__CantConvertArrayElementValueToRequiredType
    (xEFCore.ErrSourceID.LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,
     pt,
     typeof(System.DateTime),
     typeof(System.Int32));
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreSame
    (null,
     e.InnerException);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__local_eval_err__cant_convert_array_element_value_to_required_type_3
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,
     pt,
     "System.DateTime",
     "System.Int32");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//LocalEvalErr__CantConvertArrayElementValueToRequiredType__pt1

 //-----------------------------------------------------------------------
 [Test]
 public static void LocalEvalErr__CantConvertArrayElementValueToRequiredType__pt3()
 {
  var pt
   =new[]{123,444,543};

  try
  {
   xEFCore.ThrowError.LocalEvalErr__CantConvertArrayElementValueToRequiredType
    (xEFCore.ErrSourceID.LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,
     pt,
     typeof(System.DateTime),
     typeof(System.Int32));
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreSame
    (null,
     e.InnerException);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__local_eval_err__cant_convert_array_element_value_to_required_type_3
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,
     pt,
     "System.DateTime",
     "System.Int32");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//LocalEvalErr__CantConvertArrayElementValueToRequiredType__pt3

 //-----------------------------------------------------------------------
 [Test]
 public static void CsUtf16Err__BadSequence()
 {
  try
  {
   xEFCore.ThrowError.CsUtf16Err__BadSequence
    (xEFCore.ErrSourceID.common,
     "ABC",
     123);
  }
  catch(xEFCore.LcpiOleDb__DataToolException exc)
  {
   CheckErrors.PrintException_OK(exc);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(exc));

   CheckErrors.CheckErrorRecord__cs_utf16_err__bad_sequence__2
    (TestUtils.GetRecord(exc,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "ABC",
     123);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//CsUtf16Err__BadSequence

 //-----------------------------------------------------------------------
 [Test]
 public static void SqlTranslatorErr__UnsupportedBinaryOperatorType__n1()
 {
  try
  {
   xEFCore.ThrowError.SqlTranslatorErr__UnsupportedBinaryOperatorType
    (xEFCore.ErrSourceID.common,
     ExpressionType.Coalesce);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__sql_translator_err__unsupported_binary_operator_type_1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     ExpressionType.Coalesce);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//SqlTranslatorErr__UnsupportedBinaryOperatorType__n1

 //-----------------------------------------------------------------------
 [Test]
 public static void SqlTranslatorErr__MethodNotSupported()
 {
  try
  {
   xEFCore.ThrowError.SqlTranslatorErr__MethodNotSupported
    (xEFCore.ErrSourceID.common,
     xEFCore.Structure.Structure_MethodIdCache.MethodIdOf__String__std__ToLower);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__sql_translator_err__method_not_supported_1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "System.String.ToLower()");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//SqlTranslatorErr__MethodNotSupported

 //-----------------------------------------------------------------------
 [Test]
 public static void SqlTranslatorErr__MemberNotSupported()
 {
  try
  {
   xEFCore.ThrowError.SqlTranslatorErr__MemberNotSupported
    (xEFCore.ErrSourceID.common,
     xEFCore.Structure.Structure_MemberIdCache.MemberIdOf__String__std__Length);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__sql_translator_err__member_not_supported_2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "System.String",
     "Length");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//SqlTranslatorErr__MemberNotSupported

 //-----------------------------------------------------------------------
 [Test]
 public static void SqlTranslatorErr__UnsupportedBinaryOperatorType__n3()
 {
  try
  {
   xEFCore.ThrowError.SqlTranslatorErr__UnsupportedBinaryOperatorType
    (xEFCore.ErrSourceID.common,
     xEFCore.LcpiOleDb__ExpressionType.Subtract,
     typeof(string),
     typeof(int));
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__sql_translator_err__unsupported_binary_operator_type_3
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     xEFCore.LcpiOleDb__ExpressionType.Subtract,
     typeof(string),
     typeof(int));

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//SqlTranslatorErr__UnsupportedBinaryOperatorType__n3

 //-----------------------------------------------------------------------
 [Test]
 public static void SqlTranslatorErr__UnsupportedUnaryOperatorType__n1__std_eType()
 {
  try
  {
   xEFCore.ThrowError.SqlTranslatorErr__UnsupportedUnaryOperatorType
    (xEFCore.ErrSourceID.common,
     ExpressionType.ArrayLength);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__sql_translator_err__unsupported_unary_operator_type_1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     ExpressionType.ArrayLength);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//SqlTranslatorErr__UnsupportedUnaryOperatorType__n1__std_eType

 //-----------------------------------------------------------------------
 [Test]
 public static void SqlTranslatorErr__UnsupportedUnaryOperatorType__n1__lcpi_eType()
 {
  try
  {
   xEFCore.ThrowError.SqlTranslatorErr__UnsupportedUnaryOperatorType
    (xEFCore.ErrSourceID.common,
     xEFCore.LcpiOleDb__ExpressionType.ArrayLength);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__sql_translator_err__unsupported_unary_operator_type_1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     xEFCore.LcpiOleDb__ExpressionType.ArrayLength);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//SqlTranslatorErr__UnsupportedUnaryOperatorType__n1__lcpi_eType

 //-----------------------------------------------------------------------
 [Test]
 public static void SqlTranslatorErr__UnsupportedUnaryOperatorType__n3()
 {
  try
  {
   xEFCore.ThrowError.SqlTranslatorErr__UnsupportedUnaryOperatorType
    (xEFCore.ErrSourceID.common,
     xEFCore.LcpiOleDb__ExpressionType.ArrayLength,
     typeof(string),
     typeof(int));
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__sql_translator_err__unsupported_unary_operator_type_3
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     xEFCore.LcpiOleDb__ExpressionType.ArrayLength,
     typeof(string),
     typeof(int));

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//SqlTranslatorErr__UnsupportedUnaryOperatorType__n3

 //-----------------------------------------------------------------------
 [Test]
 public static void SqlTranslatorErr__CantPresentSqlUnaryOperationAsSqlUnaryExpression()
 {
  try
  {
   xEFCore.ThrowError.SqlTranslatorErr__CantPresentSqlUnaryOperationAsSqlUnaryExpression
    (xEFCore.ErrSourceID.common,
     ExpressionType.ArrayLength,
     typeof(string),
     typeof(int));
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__sql_translator_err__cant_present_unary_operation_as_SqlUnaryExpression_3
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     xEFCore.LcpiOleDb__ExpressionType.ArrayLength,
     "System.String",
     "System.Int32");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//SqlTranslatorErr__CantPresentSqlUnaryOperationAsSqlUnaryExpression

 //-----------------------------------------------------------------------
 [Test]
 public static void SqlTranslatorErr__CantPresentSqlBinaryOperationAsSqlBinaryExpression()
 {
  try
  {
   xEFCore.ThrowError.SqlTranslatorErr__CantPresentSqlBinaryOperationAsSqlBinaryExpression
    (xEFCore.ErrSourceID.common,
     ExpressionType.Add,
     typeof(string),
     typeof(int));
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__sql_translator_err__cant_present_binary_operation_as_SqlBinaryExpression_3
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     xEFCore.LcpiOleDb__ExpressionType.Add,
     "System.String",
     "System.Int32");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//SqlTranslatorErr__CantPresentSqlBinaryOperationAsSqlBinaryExpression

 //-----------------------------------------------------------------------
 [Test]
 public static void SqlTranslatorErr__CantPresentSqlFunctionAsSqlFunctionExpression()
 {
  try
  {
   xEFCore.ThrowError.SqlTranslatorErr__CantPresentSqlFunctionAsSqlFunctionExpression
    (xEFCore.ErrSourceID.common,
     "HAHA");
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__sql_translator_err__cant_present_function_as_SqlFunctionExpression_1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "HAHA");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//SqlTranslatorErr__CantPresentSqlFunctionAsSqlFunctionExpression

 //-----------------------------------------------------------------------
 [Test]
 public static void SqlGenErr__UnsupportedCastAsBetweenTypes()
 {
  try
  {
   xEFCore.ThrowError.SqlGenErr__UnsupportedCastAsBetweenTypes
    (xEFCore.ErrSourceID.FB_Common__QuerySqlGenerator,
     typeof(System.Int32),
     typeof(System.DateTime));
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__sql_gen_err__unsupported_cast_as_between_types_2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_Common__QuerySqlGenerator,
     "System.Int32",
     "System.DateTime");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//SqlGenErr__UnsupportedCastAsBetweenTypes

 //-----------------------------------------------------------------------
 [Test]
 public static void SqlGenErr__DefinitionOfValueInSqlNotSupported()
 {
  try
  {
   xEFCore.ThrowError.SqlGenErr__DefinitionOfValueInSqlNotSupported
    (xEFCore.ErrSourceID.FB_Common__TypeMapping_D1__TYPE_TIME__as_TimeOnly,
     "TIME");
  }
  catch(structure_lib.exceptions.t_not_supported_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__sql_gen_err__definition_of_value_in_sql_not_supported__1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_Common__TypeMapping_D1__TYPE_TIME__as_TimeOnly,
     "TIME");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//SqlGenErr__DefinitionOfValueInSqlNotSupported

 //-----------------------------------------------------------------------
 [Test]
 public static void SqlGenErr__NotSupportedSqlOperator__APPLY()
 {
  try
  {
   xEFCore.ThrowError.SqlGenErr__NotSupportedSqlOperator__APPLY
    (xEFCore.ErrSourceID.common);
  }
  catch(structure_lib.exceptions.t_not_supported_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__sql_gen_err__not_supported_sql_operator__1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "APPLY");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//SqlGenErr__NotSupportedSqlOperator__APPLY

 //-----------------------------------------------------------------------
 [Test]
 public static void SqlGenErr__NotSupportedSqlOperator__INTERSECT()
 {
  try
  {
   xEFCore.ThrowError.SqlGenErr__NotSupportedSqlOperator__INTERSECT
    (xEFCore.ErrSourceID.common);
  }
  catch(structure_lib.exceptions.t_not_supported_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__sql_gen_err__not_supported_sql_operator__1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "INTERSECT");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//SqlGenErr__NotSupportedSqlOperator__INTERSECT

 //-----------------------------------------------------------------------
 [Test]
 public static void SqlGenErr__NotSupportedSqlOperator__EXCEPT()
 {
  try
  {
   xEFCore.ThrowError.SqlGenErr__NotSupportedSqlOperator__EXCEPT
    (xEFCore.ErrSourceID.common);
  }
  catch(structure_lib.exceptions.t_not_supported_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__sql_gen_err__not_supported_sql_operator__1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "EXCEPT");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//SqlGenErr__NotSupportedSqlOperator__EXCEPT

 //-----------------------------------------------------------------------
 [Test]
 public static void SqlGenErr__TranslationOfMemberNotSupportedInCurrentCnDialect()
 {
  try
  {
   xEFCore.ThrowError.SqlGenErr__TranslationOfMemberNotSupportedInCurrentCnDialect
    (xEFCore.ErrSourceID.FB_Common__Sql_ETranslator__Dummy__MemberNotSupportedInCurrentCnDialect,
     123,
     typeof(System.Nullable<int>).GetMember("Value")[0]);
  }
  catch(structure_lib.exceptions.t_not_supported_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__sql_gen_err__translation_of_member_not_supported_in_current_cn_dialect_2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_Common__Sql_ETranslator__Dummy__MemberNotSupportedInCurrentCnDialect,
     123,
     "Nullable<System.Int32>.Value");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//SqlGenErr__TranslationOfMemberNotSupportedInCurrentCnDialect

 //-----------------------------------------------------------------------
 [Test]
 public static void SqlGenErr__DecimalPrecisionNotSupportedInCurrentCnDialect()
 {
  try
  {
   xEFCore.ThrowError.SqlGenErr__DecimalPrecisionNotSupportedInCurrentCnDialect
    (xEFCore.ErrSourceID.common,
     123,
     "QWERTY",
     321);
  }
  catch(structure_lib.exceptions.t_not_supported_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__sql_gen_err__decimal_precision_not_supported_in_current_cn_dialect_3
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     123,
     "QWERTY",
     321);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//SqlGenErr__DecimalPrecisionNotSupportedInCurrentCnDialect

 //-----------------------------------------------------------------------
 [Test]
 public static void MSqlGenErr__ComputedColumnNotSupported()
 {
  try
  {
   xEFCore.ThrowError.MSqlGenErr__ComputedColumnNotSupported
    (xEFCore.ErrSourceID.common);
  }
  catch(structure_lib.exceptions.t_not_supported_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__msql_gen_err__computed_column_not_supported__0
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//MSqlGenErr__ComputedColumnNotSupported

 //-----------------------------------------------------------------------
 [Test]
 public static void MSqlGenErr__CantFindTypeMappingForColumn()
 {
  try
  {
   xEFCore.ThrowError.MSqlGenErr__CantFindTypeMappingForColumn
    (xEFCore.ErrSourceID.common,
     "AAA",
     "BBB");
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__msql_gen_err__cant_find_type_mapping_for_column__2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "AAA",
     "BBB");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//MSqlGenErr__CantFindTypeMappingForColumn

 //-----------------------------------------------------------------------
 [Test]
 public static void MSqlGenErr__CantFindTypeMappingForDefaultValue()
 {
  try
  {
   xEFCore.ThrowError.MSqlGenErr__CantFindTypeMappingForDefaultValue
    (xEFCore.ErrSourceID.common,
     typeof(int));
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__msql_gen_err__cant_find_type_mapping_for_default_value__1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "System.Int32");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//MSqlGenErr__CantFindTypeMappingForDefaultValue

 //-----------------------------------------------------------------------
 [Test]
 public static void MSqlGenErr__DetectedMultipleDefinitionOfDefaultValue()
 {
  try
  {
   xEFCore.ThrowError.MSqlGenErr__DetectedMultipleDefinitionOfDefaultValue
    (xEFCore.ErrSourceID.common);
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__msql_gen_err__detected_multiple_definition_of_default_value__0
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//MSqlGenErr__DetectedMultipleDefinitionOfDefaultValue

 //-----------------------------------------------------------------------
 [Test]
 public static void MSqlGenErr__UnknownFkReferentialAction()
 {
  try
  {
   xEFCore.ThrowError.MSqlGenErr__UnknownFkReferentialAction
    (xEFCore.ErrSourceID.common,
     Microsoft.EntityFrameworkCore.Migrations.ReferentialAction.Restrict);
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__msql_gen_err__unknown_fk_referential_action__1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "Restrict");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//MSqlGenErr__UnknownFkReferentialAction

 //-----------------------------------------------------------------------
 [Test]
 public static void MSqlGenErr__OverflowInCalculationOfAdjustedSequenceStartValue()
 {
  var op
   =new Microsoft.EntityFrameworkCore.Migrations.Operations.CreateSequenceOperation
    {
     Name        = "Q",
     StartValue  = 1,
     IncrementBy = 2,
    };

  try
  {
   xEFCore.ThrowError.MSqlGenErr__OverflowInCalculationOfAdjustedSequenceStartValue
    (xEFCore.ErrSourceID.common,
     op);
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__msql_gen_err__overflow_in_calculation_of_adjusted_sequence_start_value__3
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     op.Name,
     op.StartValue,
     op.IncrementBy);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//MSqlGenErr__OverflowInCalculationOfAdjustedSequenceStartValue

 //-----------------------------------------------------------------------
 [Test]
 public static void MSqlGenErr__InconsistentTableNamesInAlterColumnOperation()
 {
  try
  {
   xEFCore.ThrowError.MSqlGenErr__InconsistentTableNamesInAlterColumnOperation
    (xEFCore.ErrSourceID.common,
     "name1",
     "name2");
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__msql_gen_err__inconsistent_table_names_in_alter_column_operation__2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "name1",
     "name2");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//MSqlGenErr__InconsistentTableNamesInAlterColumnOperation

 //-----------------------------------------------------------------------
 [Test]
 public static void MSqlGenErr__ColumnDataUsesIncorrectTableName()
 {
  try
  {
   xEFCore.ThrowError.MSqlGenErr__ColumnDataUsesIncorrectTableName
    (xEFCore.ErrSourceID.common,
     123,
     "CC",
     "A1",
     "A2");
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__msql_gen_err__column_data_uses_incorrect_table_name__4
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     123,
     "CC",
     "A1",
     "A2");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//MSqlGenErr__ColumnDataUsesIncorrectTableName

 //-----------------------------------------------------------------------
 [Test]
 public static void MSqlGenErr__BadIndexDefinition_MultipleData()
 {
  try
  {
   xEFCore.ThrowError.MSqlGenErr__BadIndexDefinition_MultipleData
    (xEFCore.ErrSourceID.common,
     "INDEX",
     "TABLE");
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__msql_gen_err__bad_index_definition__multiple_data__2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "INDEX",
     "TABLE");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//MSqlGenErr__BadIndexDefinition_MultipleData

 //-----------------------------------------------------------------------
 [Test]
 public static void MSqlGenErr__BadIndexDefinition_NoData()
 {
  try
  {
   xEFCore.ThrowError.MSqlGenErr__BadIndexDefinition_NoData
    (xEFCore.ErrSourceID.common,
     "INDEX",
     "TABLE");
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__msql_gen_err__bad_index_definition__no_data__2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "INDEX",
     "TABLE");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//MSqlGenErr__BadIndexDefinition_NoData

 //-----------------------------------------------------------------------
 [Test]
 public static void MSqlGenErr__TableNameNotDefined()
 {
  try
  {
   xEFCore.ThrowError.MSqlGenErr__TableNameNotDefined
    (xEFCore.ErrSourceID.common);
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__msql_gen_err__table_name_not_defined__0
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//MSqlGenErr__TableNameNotDefined

 //-----------------------------------------------------------------------
 [Test]
 public static void Schema__DataProviderNotSupportReqRestriction()
 {
  try
  {
   xEFCore.ThrowError.Schema__DataProviderNotSupportReqRestriction
    (xEFCore.ErrSourceID.common,
     "SCHEMA_name",
     "restriction_NAME");
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__schema_err__data_provider_not_support_req_restriction_2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "SCHEMA_name",
     "restriction_NAME");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Schema__DataProviderNotSupportReqRestriction

 //-----------------------------------------------------------------------
 [Test]
 public static void UnknownAnnotation()
 {
  try
  {
   xEFCore.ThrowError.UnknownAnnotation
    (xEFCore.ErrSourceID.common,
     "AA");
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__common_err__unknown_annotation__1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "AA");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//UnknownAnnotation

 //-----------------------------------------------------------------------
 [Test]
 public static void AnnotationHasUnknownValue__int()
 {
  try
  {
   xEFCore.ThrowError.AnnotationHasUnknownValue<int>
    (xEFCore.ErrSourceID.common,
     "AA",
     333);
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__common_err__annotation_has_unknown_value__2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "AA",
     "333");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//AnnotationHasUnknownValue__int

 //-----------------------------------------------------------------------
 [Test]
 public static void AnnotationHasNullValue()
 {
  try
  {
   xEFCore.ThrowError.AnnotationHasNullValue
    (xEFCore.ErrSourceID.common,
     "AA");
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__common_err__annotation_has_null_value__1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "AA");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//AnnotationHasNullValue

 //-----------------------------------------------------------------------
 [Test]
 public static void AnnotationHasValueWithUnexpectedType()
 {
  try
  {
   xEFCore.ThrowError.AnnotationHasValueWithUnexpectedType
    (xEFCore.ErrSourceID.common,
     "AABB",
     typeof(int),
     typeof(string));
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__common_err__annotation_has_value_with_unexpected_type__3
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "AABB",
     "System.Int32",
     "System.String");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//AnnotationHasValueWithUnexpectedType

 //-----------------------------------------------------------------------
 [Test]
 public static void MultipleDefinitionOfAnnotation__string()
 {
  try
  {
   xEFCore.ThrowError.MultipleDefinitionOfAnnotation<string>
    (xEFCore.ErrSourceID.common,
     "AABB",
     "aa",
     "bb");
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__common_err__multiple_definition_of_annotation__3
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "AABB",
     "aa",
     "bb");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//MultipleDefinitionOfAnnotation__string

 //-----------------------------------------------------------------------
 [Test]
 public static void ModelDefinesIncorrectGlobalValueGenerationStrategy()
 {
  try
  {
   xEFCore.ThrowError.ModelDefinesIncorrectGlobalValueGenerationStrategy
    (xEFCore.ErrSourceID.common,
     "VGS2");
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__common_err__model_defines_incorrect_global_value_generation_strategy__1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "VGS2");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//ModelDefinesIncorrectGlobalValueGenerationStrategy

 //-----------------------------------------------------------------------
 [Test]
 public static void PropertyWithDataTypeIsNotCompatiblyWithValueGenerationStrategy()
 {
  try
  {
   xEFCore.ThrowError.PropertyWithDataTypeIsNotCompatiblyWithValueGenerationStrategy
    (xEFCore.ErrSourceID.common,
     "VGS3",
     typeof(int),
     "propName",
     typeof(string));
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__common_err__property_with_datatype_is_not_compatible_with_value_generation_strategy__4
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "VGS3",
     "System.Int32",
     "propName",
     "System.String");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//PropertyWithDataTypeIsNotCompatiblyWithValueGenerationStrategy

 //-----------------------------------------------------------------------
 [Test]
 public static void ValueGenerationStrategyCantBeDefinedAtModelLevel()
 {
  try
  {
   xEFCore.ThrowError.ValueGenerationStrategyCantBeDefinedAtModelLevel
    (xEFCore.ErrSourceID.common,
     "VGS4");
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__common_err__value_generation_strategy_cant_be_defined_at_model_level__1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "VGS4");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//ValueGenerationStrategyCantBeDefinedAtModelLevel

 //-----------------------------------------------------------------------
 [Test]
 public static void DbmsErr__FB__FirebirdDoesNotSupportDropIdentityAttributeFromColumn()
 {
  try
  {
   xEFCore.ThrowError.DbmsErr__FB__FirebirdDoesNotSupportDropIdentityAttributeFromColumn
    (xEFCore.ErrSourceID.common);
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__dbms_err__fb__firebird_does_not_support_drop_identity_attribute_from_column__0
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//DbmsErr__FB__FirebirdDoesNotSupportDropIdentityAttributeFromColumn

 //-----------------------------------------------------------------------
 [Test]
 public static void DbmsErr__FB__FirebirdDoesNotSupportAddIdentityAttributeToColumn()
 {
  try
  {
   xEFCore.ThrowError.DbmsErr__FB__FirebirdDoesNotSupportAddIdentityAttributeToColumn
    (xEFCore.ErrSourceID.common);
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__dbms_err__fb__firebird_does_not_support_add_identity_attribute_to_column__0
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//DbmsErr__FB__FirebirdDoesNotSupportAddIdentityAttributeToColumn

 //-----------------------------------------------------------------------
 [Test]
 public static void DbmsErr__FB__FirebirdDoesNotSupportRenamingOfTables()
 {
  try
  {
   xEFCore.ThrowError.DbmsErr__FB__FirebirdDoesNotSupportRenamingOfTables
    (xEFCore.ErrSourceID.common);
  }
  catch(structure_lib.exceptions.t_not_supported_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__dbms_err__fb__firebird_does_not_support_renaming_of_tables__0
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//DbmsErr__FB__FirebirdDoesNotSupportRenamingOfTables

 //-----------------------------------------------------------------------
 [Test]
 public static void DbmsErr__FB__FirebirdDoesNotSupportRenamingOfSequences()
 {
  try
  {
   xEFCore.ThrowError.DbmsErr__FB__FirebirdDoesNotSupportRenamingOfSequences
    (xEFCore.ErrSourceID.common);
  }
  catch(structure_lib.exceptions.t_not_supported_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__dbms_err__fb__firebird_does_not_support_renaming_of_sequences__0
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//DbmsErr__FB__FirebirdDoesNotSupportRenamingOfSequences

 //-----------------------------------------------------------------------
 [Test]
 public static void DbmsErr__FB__FirebirdDoesNotSupportRenamingOfIndexes()
 {
  try
  {
   xEFCore.ThrowError.DbmsErr__FB__FirebirdDoesNotSupportRenamingOfIndexes
    (xEFCore.ErrSourceID.common);
  }
  catch(structure_lib.exceptions.t_not_supported_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__dbms_err__fb__firebird_does_not_support_renaming_of_indexes__0
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//DbmsErr__FB__FirebirdDoesNotSupportRenamingOfIndexes

 //-----------------------------------------------------------------------
 [Test]
 public static void DbmsErr__FB__FirebirdDoesNotSupportSchemas()
 {
  try
  {
   xEFCore.ThrowError.DbmsErr__FB__FirebirdDoesNotSupportSchemas
    (xEFCore.ErrSourceID.common);
  }
  catch(structure_lib.exceptions.t_not_supported_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__dbms_err__fb__firebird_does_not_support_schemas__0
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//DbmsErr__FB__FirebirdDoesNotSupportSchemas

 //-----------------------------------------------------------------------
// [Test]
// public static void Test__NoConnectionObject()
// {
//  try
//  {
//   xEFCore.ThrowError.NoConnectionObject
//    (xEFCore.ErrSourceID.OleDbTools);
//  }
//  catch(xEFCore.OleDbDataToolException e)
//  {
//   CheckErrors.PrintException_OK(e);
//
//   Assert.AreEqual
//    (1,
//     TestUtils.GetRecordCount(e));
//
//   CheckErrors.CheckErrorRecord__CommonErr__NoConnectionObject
//    (TestUtils.GetRecord(e,0),
//     CheckErrors.c_Linq2DbDataProvider__src__OleDbTools);
//
//   return;
//  }//catch
//
//  TestServices.ThrowWeWaitError();
// }//Test__NoConnectionObject

 //-----------------------------------------------------------------------
// [Test]
// public static void Test__UnexpectedConnectionObjectType()
// {
//  try
//  {
//   xEFCore.ThrowError.UnexpectedConnectionObjectType
//    (xEFCore.ErrSourceID.OleDbTools,
//     1);
//  }
//  catch(xEFCore.OleDbDataToolException e)
//  {
//   CheckErrors.PrintException_OK(e);
//
//   Assert.AreEqual
//    (1,
//     TestUtils.GetRecordCount(e));
//
//   CheckErrors.CheckErrorRecord__CommonErr__UnexpectedConnectionObjectType
//    (TestUtils.GetRecord(e,0),
//     CheckErrors.c_Linq2DbDataProvider__src__OleDbTools,
//     1.GetType().FullName);
//
//   return;
//  }//catch
//
//  TestServices.ThrowWeWaitError();
// }//Test__UnexpectedConnectionObjectType

 //-----------------------------------------------------------------------
// [Test]
// public static void Test__UnknownTableType()
// {
//  try
//  {
//   xEFCore.ThrowError.UnknownTableType
//    (xEFCore.ErrSourceID.Core_SchemaLoader__Tables,
//     "tableName",
//     "TableType");
//  }
//  catch(xEFCore.OleDbDataToolException e)
//  {
//   CheckErrors.PrintException_OK(e);
//
//   Assert.AreEqual
//    (1,
//     TestUtils.GetRecordCount(e));
//
//   CheckErrors.CheckErrorRecord__CommonErr__UnknownTableType
//    (TestUtils.GetRecord(e,0),
//     CheckErrors.c_Linq2DbDataProvider__src__Core_SchemaLoader__Tables,
//     "tableName",
//     "TableType",
//     com_lib.HResultCode.E_FAIL);
//
//   return;
//  }//catch
//
//  TestServices.ThrowWeWaitError();
// }//Test__UnknownTableType
};//class TestSet_01

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.ThrowError

////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 15.05.2018.
using System;
using System.Diagnostics;
using System.Threading;
using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;
using NUnit.Framework;
using System.Data;

using ResultSetMapping
 =Microsoft.EntityFrameworkCore.Update.ResultSetMapping;

using Expression
 =System.Linq.Expressions.Expression;

using ExpressionType
 =System.Linq.Expressions.ExpressionType;

using structure_lib=lcpi.lib.structure;
using com_lib=lcpi.lib.com;

using xdb=lcpi.data.oledb;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General{
////////////////////////////////////////////////////////////////////////////////
//class CheckErrors

static class CheckErrors
{
 public const string c_src__Firebird
  ="Firebird";

 public const string c_src__IBProvider
  ="LCPI.IBProvider.5";

 public const string c_src__structure_lib__DecimalUtils
  ="lcpi.lib.structure.DecimalUtils";

 public const string c_src__EFCoreDataProvider__Unknown
  ="Unknown Source";

 public const string c_src__EFCoreDataProvider__common
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb";

 public const string c_src__EFCoreDataProvider__LcpiOleDb__Extensions__DbContextOptions
  ="Microsoft.EntityFrameworkCore.LcpiOleDb__Extensions__DbContextOptions";

 public const string c_src__EFCoreDataProvider__LcpiOleDb__Extensions__Property
  ="Microsoft.EntityFrameworkCore.LcpiOleDb__Extensions__Property";

 public const string c_src__EFCoreDataProvider__LcpiOleDb__Extensions__Model
  ="Microsoft.EntityFrameworkCore.LcpiOleDb__Extensions__Model";

 public const string c_src__EFCoreDataProvider__LcpiOleDb__LocalEval_Services__Extensions
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Extensions.LcpiOleDb__LocalEval_Services__Extensions.LcpiOleDb__LocalEval_Services__Extensions";

 public const string c_src__EFCoreDataProvider__LcpiOleDb__Extensions__Type
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.LcpiOleDb__Extensions__Type";

 public const string c_src__EFCoreDataProvider__LcpiOleDb__DataToolException
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.LcpiOleDb__DataToolException";

 public const string c_src__EFCoreDataProvider__LcpiOleDb__DbContextOptionsExtension
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Infrastructure.LcpiOleDb__DbContextOptionsExtension";

 public const string c_src__EFCoreDataProvider__FB_Common__TypeMapping__NUMERIC
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.Mapping.FB_Common__TypeMapping__NUMERIC";

 public const string c_src__EFCoreDataProvider__FB_Common__TypeMapping__DECIMAL
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.Mapping.FB_Common__TypeMapping__DECIMAL";

 public const string c_src__EFCoreDataProvider__FB_Common__TypeMapping__DOUBLE
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.Mapping.FB_Common__TypeMapping__DOUBLE";

 public const string c_src__EFCoreDataProvider__FB_Common__TypeMapping__FLOAT
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.Mapping.FB_Common__TypeMapping__FLOAT";

 public const string c_src__EFCoreDataProvider__FB_Common__TypeMapping__SMALLINT
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.Mapping.FB_Common__TypeMapping__SMALLINT";

 public const string c_src__EFCoreDataProvider__FB_Common__TypeMapping__INTEGER
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.Mapping.FB_Common__TypeMapping__INTEGER";

 public const string c_src__EFCoreDataProvider__FB_Common__TypeMapping__BIGINT
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.Mapping.FB_Common__TypeMapping__BIGINT";

 public const string c_src__EFCoreDataProvider__FB_Common__TypeMapping__VARCHAR
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.Mapping.FB_Common__TypeMapping__VARCHAR";

 public const string c_src__EFCoreDataProvider__FB_Common__TypeMapping__CHAR
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.Mapping.FB_Common__TypeMapping__CHAR";

 public const string c_src__EFCoreDataProvider__FB_Common__TypeMapping__CHAR1
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.Mapping.FB_Common__TypeMapping__CHAR1";

 public const string c_src__EFCoreDataProvider__FB_Common__TypeMapping__VARBINARY
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.Mapping.FB_Common__TypeMapping__VARBINARY";

 public const string c_src__EFCoreDataProvider__FB_Common__TypeMapping__BINARY
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.Mapping.FB_Common__TypeMapping__BINARY";

 public const string c_src__EFCoreDataProvider__FB_Common__TypeMapping__BOOLEAN
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.Mapping.FB_Common__TypeMapping__BOOLEAN";

 public const string c_src__EFCoreDataProvider__FB_Common__TypeMapping__BLOB_BINARY
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.Mapping.FB_Common__TypeMapping__BLOB_BINARY";

 public const string c_src__EFCoreDataProvider__FB_Common__TypeMapping__GUAD__as_bytes
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.Mapping.FB_Common__TypeMapping__GUID__as_bytes";

 public const string c_src__EFCoreDataProvider__FB_Common__TypeMapping__TimeSpan__as_Decimal9_4
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.Mapping.FB_Common__TypeMapping__TimeSpan__as_Decimal9_4";

 public const string c_src__EFCoreDataProvider__FB_Common__TypeMapping__TimeSpan__as_Decimal18_4
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.Mapping.FB_Common__TypeMapping__TimeSpan__as_Decimal18_4";

 public const string c_src__EFCoreDataProvider__FB_Common__ValueConversion__TimeSpanToDecimal9_4
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.ValueConversion.FB_Common__ValueConversion__TimeSpanToDecimal9_4";

 public const string c_src__EFCoreDataProvider__FB_Common__ValueConversion__TimeSpanToDecimal18_4
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.ValueConversion.FB_Common__ValueConversion__TimeSpanToDecimal18_4";

 public const string c_src__EFCoreDataProvider__FB_Common__TypeMapping__BLOB_TEXT
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.Mapping.FB_Common__TypeMapping__BLOB_TEXT";

 public const string c_src__EFCoreDataProvider__FB_Common__TypeMapping_D1__TYPE_DATE__as_DateOnly
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.Mapping.D1.FB_Common__TypeMapping__TYPE_DATE__as_DateOnly";

 public const string c_src__EFCoreDataProvider__FB_Common__TypeMapping_D1__TYPE_TIME__as_TimeOnly
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.Mapping.D1.FB_Common__TypeMapping__TYPE_TIME__as_TimeOnly";

 public const string c_src__EFCoreDataProvider__FB_Common__Sql_ENode_Unary__Convert
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes.FB_Common__Sql_ENode_Unary__Convert";

 public const string c_src__EFCoreDataProvider__FB_Common__TypeMapping_D3__TYPE_DATE__as_DateOnly
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.Mapping.D3.FB_Common__TypeMapping__TYPE_DATE__as_DateOnly";

 public const string c_src__EFCoreDataProvider__FB_Common__ModificationCommandBatch
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Update.FB_Common__ModificationCommandBatch";

 public const string c_src__EFCoreDataProvider__FB_Common__QuerySqlGenerator
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.FB_Common__QuerySqlGenerator";

 public const string c_src__EFCoreDataProvider__FB_Common__TypeMapping__TIMESTAMP
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.Mapping.FB_Common__TypeMapping__TIMESTAMP";

 public const string c_src__EFCoreDataProvider__FB_Common__TypeMapping_D3__TYPE_TIME__as_TimeOnly
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.Mapping.D3.FB_Common__TypeMapping__TYPE_TIME__as_TimeOnly";

 public const string c_src__EFCoreDataProvider__FB_Common__BinaryOperatorTranslatorProvider
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.FB_Common__BinaryOperatorTranslatorProvider";

 public const string c_src__FB_Common__Sql_ETranslator__String__std__EndsWith__str___through_RIGHT
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code.FB_Common__Sql_ETranslator__String__std__EndsWith__str___through_RIGHT";

 public const string c_src__EFCoreDataProvider__FB_Common__Sql_ETranslator__Dummy__MemberNotSupportedInCurrentCnDialect
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Internal.FB_Common__Sql_ETranslator__Dummy__MemberNotSupportedInCurrentCnDialect";

 public const string c_src__EFCoreDataProvider__FB_Common__Sql_ETranslator__Dummy__MethodNotSupportedInCurrentCnDialect
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Internal.FB_Common__Sql_ETranslator__Dummy__MethodNotSupportedInCurrentCnDialect";

 public const string c_src__EFCoreDataProvider__FB_V03_0_0__TypeMappingSource__Base
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Storage.FB_V03_0_0__TypeMappingSource__Base";

 public const string c_src__EFCoreDataProvider__FB_V03_0_0_D1__TypeMappingSourceForDDL
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Storage.D1.FB_V03_0_0_D1__TypeMappingSourceForDDL";

 public const string c_src__EFCoreDataProvider__FB_V03_0_0_D2__TypeMappingSourceForDDL
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Storage.D2.FB_V03_0_0_D2__TypeMappingSourceForDDL";

 public const string c_src__EFCoreDataProvider__FB_V03_0_0_D3__TypeMappingSource
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Storage.D3.FB_V03_0_0_D3__TypeMappingSource";

 public const string c_src__EFCoreDataProvider__FB_V03_0_0__MigrationSqlGenerator
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Migrations.FB_V03_0_0__MigrationsSqlGenerator";

 public const string c_src__EFCoreDataProvider__Basement_EF_Root_Query_Local_Expressions_Unary_Translators_ETranslator__Convert
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Unary.Translators.ETranslator__Convert";

 public const string c_src__EFCoreDataProvider__Basement_EF_Dbms_Firebird_V03_0_0_Infrastructure___FB_V03_0_0__ModelValidator
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Infrastructure.FB_V03_0_0__ModelValidator";

 public const string c_src__EFCoreDataProvider__Basement_EF_Dbms_Firebird_V03_0_0_Metadata_Conventions___FB_V03_0_0__Convention_StoreGeneration
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Metadata.Conventions.FB_V03_0_0__Convention_StoreGeneration";

 public const string c_src__EFCoreDataProvider__Basement_EF_Dbms_Firebird_V03_0_0_Migrations_D1_Internal_SvcImpls___FB_V03_0_0__MigrationsSvcImpl__GenerateCreateSequence
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Migrations.D1.Internal.SvcImpls.FB_V03_0_0__MigrationsSvcImpl__GenerateCreateSequence";

 public const string c_src__EFCoreDataProvider__Basement_EF_Dbms_Firebird_V03_0_0_Migrations_D1_Internal_SvcImpls___FB_V03_0_0__MigrationsSvcImpl__GenerateRestartSequence
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Migrations.D1.Internal.SvcImpls.FB_V03_0_0__MigrationsSvcImpl__GenerateRestartSequence";

 public const string c_src__EFCoreDataProvider__Basement_EF_Dbms_Firebird_V03_0_0_Migrations_D1_Internal_SvcImpls___FB_V03_0_0__MigrationsSvcImpl__GenerateAlterSequence
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Migrations.D1.Internal.SvcImpls.FB_V03_0_0__MigrationsSvcImpl__GenerateAlterSequence";

 public const string c_src__EFCoreDataProvider__Basement_EF_Dbms_Firebird_V03_0_0_Migrations_D3_Internal_SvcImpls___FB_V03_0_0__MigrationsSvcImpl__GenerateCreateSequence
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Migrations.D3.Internal.SvcImpls.FB_V03_0_0__MigrationsSvcImpl__GenerateCreateSequence";

 public const string c_src__EFCoreDataProvider__Basement_EF_Dbms_Firebird_V03_0_0_Migrations_D3_Internal_SvcImpls___FB_V03_0_0__MigrationsSvcImpl__GenerateAlterSequence
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Migrations.D3.Internal.SvcImpls.FB_V03_0_0__MigrationsSvcImpl__GenerateAlterSequence";

 public const string c_src__EFCoreDataProvider__DataTypes_Extensions__System_DateTime
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DataTypes.Extensions.System_DateTime";

 public const string c_src__EFCoreDataProvider__DataTypes_Extensions__System_NullableDateTime
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DataTypes.Extensions.System_NullableDateTime";

 public const string c_src__EFCoreDataProvider__DataTypes_Extensions__System_DateOnly
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DataTypes.Extensions.System_DateOnly";

 public const string c_src__EFCoreDataProvider__DataTypes_Extensions__System_NullableDateOnly
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DataTypes.Extensions.System_NullableDateOnly";

 public const string c_src__EFCoreDataProvider__DataTypes_Extensions__System_TimeOnly
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DataTypes.Extensions.System_TimeOnly";

 public const string c_src__EFCoreDataProvider__DataTypes_Extensions__System_NullableTimeOnly
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DataTypes.Extensions.System_NullableTimeOnly";

 public const string c_src__EFCoreDataProvider__DataTypes_Extensions__System_String
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DataTypes.Extensions.System_String";

 public const string c_src__EFCoreDataProvider__DataTypes_Extensions__System_NullableInt16
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DataTypes.Extensions.System_NullableInt16";

 public const string c_src__EFCoreDataProvider__DataTypes_Extensions__System_NullableBoolean
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DataTypes.Extensions.System_NullableBoolean";

 public const string c_src__EFCoreDataProvider__DbFunctions__DbCast
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DbFunctions.DbCast";

 public const string c_src__EFCoreDataProvider__DbFunctions__DbMath
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DbFunctions.DbMath";

 public const string c_src__EFCoreDataProvider__Core_ConnectionOptionsInitializer
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Core_ConnectionOptionsInitializer";

 public const string c_src__EFCoreDataProvider__Core_ExceptionRecord
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Core_ExceptionRecord";

 public const string c_src__EFCoreDataProvider__Core_ValueInstaller
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Core_ValueInstaller";

 public const string c_src__EFCoreDataProvider__Core_ValueCvt__Int32__Int16
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Values.Converters.Core_ValueCvt__Int32__Int16";

 public const string c_src__EFCoreDataProvider__Core_ValueCvt__Int64__Int16
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Values.Converters.Core_ValueCvt__Int64__Int16";

 public const string c_src__EFCoreDataProvider__Core_ValueCvt__Int64__Int32
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Values.Converters.Core_ValueCvt__Int64__Int32";

 public const string c_src__EFCoreDataProvider__IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d1
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.IscBase.IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d1";

 public const string c_src__EFCoreDataProvider__IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d3
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.IscBase.IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d3";

 public const string c_src__EFCoreDataProvider__Common_EngineSvc__CommandParamereterNameBuilder__Error_NoPrefix
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Common.Common_EngineSvc__CommandParamereterNameBuilder__Error_NoPrefix";

 public const string c_src__EFCoreDataProvider__Common_EngineSvc__CommandParamereterNameBuilder__NameWithoutPrefix
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Common.Common_EngineSvc__CommandParamereterNameBuilder__NameWithoutPrefix";

 public const string c_src__EFCoreDataProvider__Common_EngineSvc__CommandParamereterNameBuilder__NameWithPrefix
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Common.Common_EngineSvc__CommandParamereterNameBuilder__NameWithPrefix";

 public const string c_src__EFCoreDataProvider__LcpiOleDb__LocalSvc__PrepareForLocalEvaluation
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Svcs.LcpiOleDb__LocalSvc__PrepareForLocalEvaluation";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Op2_Code__Equal___Object__Object
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Code.Op2_Code__Equal___Object__Object";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Op2_MasterCode__Equal___Array1_generic__Array1_generic
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.MasterCode.Op2_MasterCode__Equal___Array1_generic__Array1_generic";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Op2_MasterCode__NotEqual___Array1_generic__Array1_generic
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.MasterCode.Op2_MasterCode__NotEqual___Array1_generic__Array1_generic";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Op2_Code__NotEqual___Object__Object
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Code.Op2_Code__NotEqual___Object__Object";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Op1_MasterCode__Negate___Int64___checked
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op1.MasterCode.Op1_MasterCode__Negate___Int64___checked";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Op2_MasterCode__Add___Decimal__Decimal
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.MasterCode.Op2_MasterCode__Add___Decimal__Decimal";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Op2_MasterCode__Subtract___Decimal__Decimal
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.MasterCode.Op2_MasterCode__Subtract___Decimal__Decimal";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Op2_MasterCode__Multiply___Decimal__Decimal
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.MasterCode.Op2_MasterCode__Multiply___Decimal__Decimal";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Op2_MasterCode__ArrayIndex___Array_Byte__Int32
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.MasterCode.Op2_MasterCode__ArrayIndex___Array_Byte__Int32";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Op2_MasterCode__ArrayIndex___Array_Byte__Int64
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.MasterCode.Op2_MasterCode__ArrayIndex___Array_Byte__Int64";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_MasterCode__Int16__Byte
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.MasterCode.Convert_MasterCode__Int16__Byte";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_MasterCode__Int32__Byte
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.MasterCode.Convert_MasterCode__Int32__Byte";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_MasterCode__Int32__Int16
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.MasterCode.Convert_MasterCode__Int32__Int16";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_MasterCode__Int64__Byte
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.MasterCode.Convert_MasterCode__Int64__Byte";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_MasterCode__Int64__Int16
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.MasterCode.Convert_MasterCode__Int64__Int16";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_MasterCode__Int64__Int32
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.MasterCode.Convert_MasterCode__Int64__Int32";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_MasterCode__Decimal__Byte
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.MasterCode.Convert_MasterCode__Decimal__Byte";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_MasterCode__Double__Byte
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.MasterCode.Convert_MasterCode__Double__Byte";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_MasterCode__Double__Int16
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.MasterCode.Convert_MasterCode__Double__Int16";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_MasterCode__Double__Int32
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.MasterCode.Convert_MasterCode__Double__Int32";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_MasterCode__Double__Int64
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.MasterCode.Convert_MasterCode__Double__Int64";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_MasterCode__Double__Decimal
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.MasterCode.Convert_MasterCode__Double__Decimal";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_MasterCode__Double__Single
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.MasterCode.Convert_MasterCode__Double__Single";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_MasterCode__Single__Byte
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.MasterCode.Convert_MasterCode__Single__Byte";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_MasterCode__Single__Int16
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.MasterCode.Convert_MasterCode__Single__Int16";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_MasterCode__Single__Int32
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.MasterCode.Convert_MasterCode__Single__Int32";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_MasterCode__Single__Int64
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.MasterCode.Convert_MasterCode__Single__Int64";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_MasterCode__Single__Decimal
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.MasterCode.Convert_MasterCode__Single__Decimal";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_Code__Object__NULLABLE_VALUE
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Code.Convert_Code__Object__NULLABLE_VALUE";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_Code__Object__String
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Code.Convert_Code__Object__String";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_Code__String__NullableDecimal
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Code.Convert_Code__String__NullableDecimal";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_Code__String__NullableDouble
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Code.Convert_Code__String__NullableDouble";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_Code__String__NullableSingle
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Code.Convert_Code__String__NullableSingle";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_Code__String__NullableInt16
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Code.Convert_Code__String__NullableInt16";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_Code__String__NullableInt32
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Code.Convert_Code__String__NullableInt32";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_Code__String__NullableInt64
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Code.Convert_Code__String__NullableInt64";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Method_Code__IEnumerableByte__First
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code.Method_Code__IEnumerableByte__First";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Method_Code__String__Length
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code.Method_Code__String__Length";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Method_Code__String__Substring___startIndex
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code.Method_Code__String__Substring___startIndex";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Method_Code__String__Substring___startIndex__length
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code.Method_Code__String__Substring___startIndex__length";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Method_Code__String__Substring___nullableStartIndex
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code.Method_Code__String__Substring___nullableStartIndex";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Method_Code__String__Substring___nullableStartIndex__nullableLength
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code.Method_Code__String__Substring___nullableStartIndex__nullableLength";

 public const string c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Method_MasterCode__Object__ToString
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.MasterCode.Method_MasterCode__Object__ToString";

 public const string c_src__EFCoreDataProvider__FB_V03_0_0__Query_Local_D0_Expressions__Op2_MasterCode__Add___Int64__Int64___checked
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.MasterCode.Op2_MasterCode__Add___Int64__Int64___checked";

 public const string c_src__EFCoreDataProvider__FB_V03_0_0__Query_Local_D0_Expressions__Op2_MasterCode__Add___Double__Double
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.MasterCode.Op2_MasterCode__Add___Double__Double";

 public const string c_src__EFCoreDataProvider__FB_V03_0_0__Query_Local_D0_Expressions__Op2_MasterCode__Add___DateTime__TimeSpan
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.MasterCode.Op2_MasterCode__Add___DateTime__TimeSpan";

 public const string c_src__EFCoreDataProvider__FB_V03_0_0__Query_Local_D0_Expressions__Op2_MasterCode__Add___TimeSpan__TimeSpan
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.MasterCode.Op2_MasterCode__Add___TimeSpan__TimeSpan";

 public const string c_src__EFCoreDataProvider__FB_V03_0_0__Query_Local_D0_Expressions__Op2_MasterCode__Subtract___Int64__Int64___checked
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.MasterCode.Op2_MasterCode__Subtract___Int64__Int64___checked";

 public const string c_src__EFCoreDataProvider__FB_V03_0_0__Query_Local_D0_Expressions__Op2_MasterCode__Subtract___Double__Double
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.MasterCode.Op2_MasterCode__Subtract___Double__Double";

 public const string c_src__EFCoreDataProvider__FB_V03_0_0__Query_Local_D0_Expressions__Op2_MasterCode__Subtract___DateTime__TimeSpan
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.MasterCode.Op2_MasterCode__Subtract___DateTime__TimeSpan";

 public const string c_src__EFCoreDataProvider__FB_V03_0_0__Query_Local_D0_Expressions__Op2_MasterCode__Subtract___TimeSpan__TimeSpan
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.MasterCode.Op2_MasterCode__Subtract___TimeSpan__TimeSpan";

 public const string c_src__EFCoreDataProvider__FB_V03_0_0__Query_Local_D0_Expressions__Op2_MasterCode__Multiply___Int64__Int64___checked
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.MasterCode.Op2_MasterCode__Multiply___Int64__Int64___checked";

 public const string c_src__EFCoreDataProvider__FB_V03_0_0__Query_Local_D0_Expressions__Op2_MasterCode__Multiply___Double__Double
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.MasterCode.Op2_MasterCode__Multiply___Double__Double";

 public const string c_src__EFCoreDataProvider__FB_V03_0_0__Query_Local_D0_Expressions__Op2_MasterCode__Divide___Int64__Int64___checked
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.MasterCode.Op2_MasterCode__Divide___Int64__Int64___checked";

 public const string c_src__EFCoreDataProvider__FB_V03_0_0__Query_Local_D0_Expressions__Op2_MasterCode__Divide___Double__Double
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.MasterCode.Op2_MasterCode__Divide___Double__Double";

 // public const string c_Linq2DbDataProvider__src__Core_SchemaLoader__Tables
 //  ="LinqToDB.DataProvider.Lcpi.OleDb.Firebird.Core.SchemaLoaders.Core_SchemaLoader__Tables";
 //
 // public const string c_Linq2DbDataProvider__src__Core_SchemaLoader__ArrayDescrs
 //  ="LinqToDB.DataProvider.Lcpi.OleDb.Firebird.Core.SchemaLoaders.Core_SchemaLoader__ArrayDescrs";
 //
 // public const string c_Linq2DbDataProvider__src__Core_DataType__Helpers
 //  ="LinqToDB.DataProvider.Lcpi.OleDb.Firebird.Core.DataType.Core_DataType__Helpers";

 public const string c_src__EFCoreDataProvider__Structure_CS_UTF16
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure.Structure_CS_UTF16";

 public const string c_src__EFCoreDataProvider__Structure_NumericDigits_RW
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure.Structure_NumericDigits.RW";

 public const string c_src__EFCoreDataProvider__Structure_SwitchToUnderlying
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure.Structure_SwitchToUnderlying";

 public const string c_src__Core_Engines_Dbms_FB_Common_Mirror__Convert_Code__STRING__BOOLEAN
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Code.Convert_Code__STRING__BOOLEAN";

 public const string c_src__Core_Engines_Dbms_FB_Common_Mirror__Convert_Code__STRING__TYPE_TIME_as_TimeOnly
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Code.Convert_Code__STRING__TYPE_TIME_as_TimeOnly";

 public const string c_src__Core_Engines_Dbms_FB_Common_Mirror__Convert_Code__STRING__TYPE_DATE
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Code.Convert_Code__STRING__TYPE_DATE";

 public const string c_src__Core_Engines_Dbms_FB_Common_Mirror__Convert_Code__STRING__TIMESTAMP___D1
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Code.Convert_Code__STRING__TIMESTAMP___D1";

 public const string c_src__Core_Engines_Dbms_FB_Common_Mirror__Convert_Code__STRING__TIMESTAMP___D3
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Code.Convert_Code__STRING__TIMESTAMP___D3";

 public const string c_src__Core_Engines_Dbms_FB_V03_0_0__FB_DataTypeParser
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.V03_0_0.FB_DataTypeParser";

 //-----------------------------------------------------------------------
 public static void PrintException_OK(Exception exc)
 {
  Assert.That(exc,Is.Not.Null);

  Console.WriteLine("OK. We got the exception:");

  PrintException(exc);
 }//PrintException_OK

 //-----------------------------------------------------------------------
 public static void PrintException(Exception exc)
 {
  Assert.That(exc,Is.Not.Null);

  int n=0;

  for(;exc!=null;exc=exc.InnerException)
  {
   ++n;

   Console.WriteLine("[{0}] --------------------------",n);

   PrintException_Single(exc);
  }//for n
 }//PrintException

 //-----------------------------------------------------------------------
 private static void PrintException_Single(Exception exc)
 {
  TestTracer.Trace
   ("Exception class: {0}",exc.GetType().Name);

  TestTracer.Trace
   ("Source: {0}. Message:\n{1}",
    TestUtils.CStrSN(exc.Source),
    exc.Message);

  {
   var x=exc as xdb.OleDbException;

   if(!Object.ReferenceEquals(x,null))
   {
    var recs=x.Errors;

    for(int i=0,_c=recs.Count;i!=_c;++i)
    {
     TestTracer.Trace("------ err {0}",i+1);

     var rec=recs[i];

     TestTracer.Trace("source : {0}",rec.Source);
     TestTracer.Trace("message: {0}",rec.Message);
    }//for
   }//if
  }//local
 }//PrintException_Single

 //-----------------------------------------------------------------------
 public static void ErrorRecord__CheckEqual(structure_lib.IErrorRecord rec1,
                                            structure_lib.IErrorRecord rec2,
                                            bool                       rec2_is_clone)
 {
  Assert.That(rec1,Is.Not.Null);
  Assert.That(rec2,Is.Not.Null);

  if(rec2_is_clone)
   Assert.AreNotSame(rec1,rec2);

  if(object.ReferenceEquals(rec1,rec2))
   return;

  Assert.That(rec1.GetType().Name,
              Is.EqualTo(rec2.GetType().Name));

  Assert.That(rec1.GetSystemID(),
              Is.EqualTo(rec2.GetSystemID()));

  Assert.That(rec1.GetSubSystemID(),
              Is.EqualTo(rec2.GetSubSystemID()));

  Assert.That(rec1.GetErrorCode(),
              Is.EqualTo(rec2.GetErrorCode()));

  Assert.That(rec1.GetSource(null),
              Is.EqualTo(rec2.GetSource(null)));

  Assert.That(rec1.GetDescription(null),
              Is.EqualTo(rec2.GetDescription(null)));

  Assert.That(rec1.GetMessage(null),
              Is.EqualTo(rec2.GetMessage(null)));

  Assert.AreEqual(rec1.GetHelpFile(null),
                  rec2.GetHelpFile(null));

  Assert.AreEqual(rec1.GetHelpContextID(null),
                  rec2.GetHelpContextID(null));
 }//ErrorRecord__CheckEqual

 //-----------------------------------------------------------------------
 public static void Exception__CheckEqual(Exception exc1,
                                          Exception exc2,
                                          bool      exc2_is_clone)
 {
  Assert.That(exc1,Is.Not.Null);
  Assert.That(exc2,Is.Not.Null);

  for(;;)
  {
   if(exc2_is_clone)
    Assert.AreNotSame(exc1,exc2);

   if(object.ReferenceEquals(exc1,exc2))
    break;

   Assert.That(exc1.GetType().Name,
               Is.EqualTo(exc2.GetType().Name));

   Assert.That(exc1.Source,
               Is.EqualTo(exc2.Source));

   Assert.That(exc1.Message,
               Is.EqualTo(exc2.Message));

   //---------------------------------------
   var recs1=exc1 as structure_lib.IErrorRecords;
   var recs2=exc2 as structure_lib.IErrorRecords;

   if(Object.ReferenceEquals(recs1,null))
   {
    Assert.IsNull(recs2);
   }
   else
   {
    Assert.IsNotNull(recs2);

    Assert.AreEqual(recs1.GetRecordCount(),
                    recs2.GetRecordCount());

    for(int i=0,_c=recs1.GetRecordCount();i!=_c;++i)
    {
     ErrorRecord__CheckEqual(recs1.GetRecord(i),recs2.GetRecord(i),exc2_is_clone);
    }//for
   }//if recs1!=null

   //--------------------------------------- next
   exc1=exc1.InnerException;
   exc2=exc2.InnerException;

   if(Object.ReferenceEquals(exc1,null))
   {
    Assert.IsNull(exc2);

    break;
   }//if

   Assert.IsNotNull(exc2);
  }//for[ever]
 }//Exception__CheckEqual

 //-----------------------------------------------------------------------
 public static void TestErrRecordSrcAndDescr2_RU(structure_lib.IErrorRecord err_rec,
                                                 string                     src,
                                                 string                     descr,
                                                 com_lib.HResultCode        hr)
 {
  TestErrRecordSrcAndDescr
   (err_rec,
    "RU",
    src,
    descr,
    descr
    +Environment.NewLine
    +Environment.NewLine
    +"Код ошибки COM: "+com_lib.HResultUtils.ToHumanName(hr)+".");
 }//TestErrRecordSrcAndDescr2_RU

 //-----------------------------------------------------------------------
 public static void TestErrRecordSrcAndDescr2_EN(structure_lib.IErrorRecord err_rec,
                                                 string                     src,
                                                 string                     descr,
                                                 com_lib.HResultCode        hr)
 {
  TestErrRecordSrcAndDescr
   (err_rec,
    "EN",
    src,
    descr,
    descr
    +Environment.NewLine
    +Environment.NewLine
    +"The COM error code: "+com_lib.HResultUtils.ToHumanName(hr)+".");
 }//TestErrRecordSrcAndDescr2_EN

 //-----------------------------------------------------------------------
 public static void TestErrRecordSrcAndDescr2_RU_EN
                                           (structure_lib.IErrorRecord err_rec,
                                            string                     src,
                                            string                     descr_ru,
                                            string                     descr_en,
                                            com_lib.HResultCode        hr)
 {
  TestErrRecordSrcAndDescr2_RU
   (err_rec,
    src,
    descr_ru,
    hr);

  TestErrRecordSrcAndDescr2_EN
   (err_rec,
    src,
    descr_en,
    hr);
 }//TestErrRecordSrcAndDescr2_RU_EN

 //-----------------------------------------------------------------------
 public static void TestBugCheck_RU_EN(structure_lib.IErrorRecord err_rec,
                                       string                     src,
                                       string                     place,
                                       string                     point,
                                       string                     reason,
                                       com_lib.HResultCode        hr)
 {
  Assert.NotNull
   (err_rec);

  var args=new object[]
            {place,
             point,
             reason};

  var msg_ru=String.Format
   ("[BUG CHECK] Некорректное состояние в точке проверки [{0}][{1}]. Причина - {2}.",
    args);

  var msg_en=String.Format
   ("[BUG CHECK] Wrong state in check point [{0}][{1}]. Reason - {2}.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    src,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//TestBugCheck_RU_EN

 //-----------------------------------------------------------------------
 public static void TestErrRecordSrcAndDescr(structure_lib.IErrorRecord err_rec,
                                             object                     culture_id,
                                             string                     src,
                                             string                     descr,
                                             string                     msg)
 {
  Assert.NotNull
   (err_rec);

  Assert.That(err_rec.GetSource(culture_id),Is.EqualTo(src));

  var d=err_rec.GetDescription(culture_id);

  Assert.That(d,Is.EqualTo(descr));

  var m=err_rec.GetMessage(culture_id);

  Assert.That(m,Is.EqualTo(msg));
 }//TestErrRecordSrcAndDescr

 //-----------------------------------------------------------------------
 public static void TestExceptionSrcAndDescr(Exception exc,
                                             string    culture_id,
                                             string    src,
                                             string    descr,
                                             string    msg)
 {
  Assert.That(exc,Is.Not.Null);

  var oldCultureUI=Thread.CurrentThread.CurrentUICulture;

  try
  {
   Thread.CurrentThread.CurrentUICulture=new CultureInfo(culture_id);

   Assert.AreEqual(src,
                   exc.Source);

   Assert.AreEqual(msg,
                   exc.Message);
  }
  finally
  {
   if(!Object.ReferenceEquals(Thread.CurrentThread.CurrentUICulture,oldCultureUI))
    Thread.CurrentThread.CurrentUICulture=oldCultureUI;
  }//finally
 }//TestExceptionSrcAndDescr

 //-----------------------------------------------------------------------
 public static void TestExceptionSrcAndDescr__RU_EN
                                           (Exception           exc,
                                            string              src,
                                            string              descr_ru,
                                            string              descr_en,
                                            com_lib.HResultCode comErrCode)
 {
  Assert.That(exc,Is.Not.Null);

  //----------------------------------------
  TestExceptionSrcAndDescr
   (exc,
    "RU",
    src,
    descr_ru,
    descr_ru
    +Environment.NewLine
    +Environment.NewLine
    +"Код ошибки COM: "+com_lib.HResultUtils.ToHumanName(comErrCode)+".");

  TestExceptionSrcAndDescr
   (exc,
    "EN",
    src,
    descr_en,
    descr_en
    +Environment.NewLine
    +Environment.NewLine
    +"The COM error code: "+com_lib.HResultUtils.ToHumanName(comErrCode)+".");
 }//TestExceptionSrcAndDescr__RU_EN

 //-----------------------------------------------------------------------
 public static void TestExceptionSrcAndDescr(Exception exc,
                                             string    culture_id,
                                             string    src,
                                             string    descr)
 {
  TestExceptionSrcAndDescr
   (exc,
    culture_id,
    src,
    descr,
    descr);
 }//TestExceptionSrcAndDescr

 //-----------------------------------------------------------------------
 public static void TestExceptionSrcAndDescr2__RU
                                           (Exception           exc,
                                            string              src,
                                            string              descr)
 {
  TestExceptionSrcAndDescr
   (exc,
    "RU",
    src,
    descr);
 }//TestExceptionSrcAndDescr2__RU

 //-----------------------------------------------------------------------
 public static void TestExceptionSrcAndDescr2__EN
                                           (Exception           exc,
                                            string              src,
                                            string              descr)
 {
  TestExceptionSrcAndDescr
   (exc,
    "EN",
    src,
    descr);
 }//TestExceptionSrcAndDescr2__EN

 //-----------------------------------------------------------------------
 public static void TestExceptionSrcAndDescr2__RU_EN
                                           (Exception           exc,
                                            string              src,
                                            string              descr_ru,
                                            string              descr_en)
 {
  TestExceptionSrcAndDescr2__RU
   (exc,
    src,
    descr_ru);

  TestExceptionSrcAndDescr2__EN
   (exc,
    src,
    descr_en);
 }//TestExceptionSrcAndDescr2__RU_EN

 //-----------------------------------------------------------------------
 public static void CheckException__ArgumentNullException
                           (ArgumentNullException   exc,
                            string                  src_name,
                            string                  method_name,
                            string                  arg_name)
 {
  Assert.That(exc,Is.Not.Null);

  Assert.That(exc.ParamName,Is.EqualTo(arg_name));

  var args=new object[]{method_name,arg_name};

  var src=src_name;

  var msg_ru
   =string.Format
     ("Метод \"{0}\". Аргумент \"{1}\" содержит null.",
      args);

  var msg_en
   =string.Format
     ("Method \"{0}\". Argument \"{1}\" is null.",
      args);

  //----------------------------------------
  TestExceptionSrcAndDescr__RU_EN
   (exc,
    src,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_POINTER);
 }//CheckException__ArgumentNullException

 //-----------------------------------------------------------------------
 public static void CheckException__ArgumentIsNotNull
                           (ArgumentException   exc,
                            string              src_name,
                            string              method_name,
                            string              arg_name)
 {
  Assert.That(exc,Is.Not.Null);

  Assert.That(exc.ParamName,Is.EqualTo(arg_name));

  var args=new object[]{method_name,arg_name};

  var src=src_name;

  var msg_ru
   =string.Format
     ("Метод \"{0}\". Аргумент \"{1}\" не содержит null [ожидается null].",
      args);

  var msg_en
   =string.Format
     ("Method \"{0}\". Argument \"{1}\" is not null [expected null].",
      args);

  //----------------------------------------
  TestExceptionSrcAndDescr__RU_EN
   (exc,
    src,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_INVALIDARG);
 }//CheckException__ArgumentIsNotNull

 //-----------------------------------------------------------------------
 public static void CheckException__ArgumentIsEmpty
                           (ArgumentException   exc,
                            string              src_name,
                            string              method_name,
                            string              arg_name)
 {
  Assert.That(exc,Is.Not.Null);

  Assert.That(exc.ParamName,Is.EqualTo(arg_name));

  var args=new object[]{method_name,arg_name};

  var src=src_name;

  var msg_ru
   =string.Format
     ("Метод \"{0}\". Аргумент \"{1}\" не содержит данных.",
      args);

  var msg_en
   =string.Format
     ("Method \"{0}\". Argument \"{1}\" is empty.",
      args);

  //----------------------------------------
  TestExceptionSrcAndDescr__RU_EN
   (exc,
    src,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_INVALIDARG);
 }//CheckException__ArgumentIsEmpty

 //-----------------------------------------------------------------------
 public static void CheckException__BadArgumentValueType
                           (ArgumentException   exc,
                            string              src_name,
                            string              method_name,
                            string              param_name,
                            Type                param_value_type,
                            Type                expected_type)
 {
  Assert.That(exc,Is.Not.Null);

  Assert.That(exc.ParamName,Is.EqualTo(param_name));

  var src=src_name;

  var msg_args
   =new object[]
     {method_name,
      param_name,
      param_value_type.FullName,
      expected_type.FullName};

  var msg_ru
   =string.Format
     ("Метод \"{0}\". Недопустимый тип значения аргумента \"{1}\": {2}. Ожидается значение с типом: {3}.",
      msg_args);

  var msg_en
   =string.Format
    ("Method \"{0}\". Bad value type of argument \"{1}\": {2}. Expected value with type: {3}.",
     msg_args);

  //----------------------------------------
  TestExceptionSrcAndDescr__RU_EN
   (exc,
    src,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_INVALIDARG);
 }//CheckException__BadArgumentValueType

 //-----------------------------------------------------------------------
 public static void CheckException__ArgumentOutOfRange__negative_value
                           (ArgumentOutOfRangeException exc,
                            string                      src_name,
                            string                      method_name,
                            string                      arg_name,
                            object                      actualValue)
 {
  Assert.NotNull
   (exc);

  Assert.AreEqual
   (arg_name,
    exc.ParamName);

  Assert.AreEqual
   (actualValue,
    exc.ActualValue);

  var src=src_name;

  var args=new object[]{method_name,arg_name,actualValue};

  var msg_ru
   =string.Format
     ("Метод \"{0}\". Аргумент \"{1}\" содержит отрицательное значение [{2}].",
      args);

  var msg_en
   =string.Format
     ("Method \"{0}\". Argument \"{1}\" contains negative value [{2}].",
      args);

  //----------------------------------------
  TestExceptionSrcAndDescr__RU_EN
   (exc,
    src,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_INVALIDARG);
 }//CheckException__ArgumentOutOfRange__negative_value

 //-----------------------------------------------------------------------
 public static void CheckException__InvalidOperationException__NullableObjectMustHaveValue
                           (InvalidOperationException exc)
 {
  Assert.IsNotNull
   (exc);

  Assert.AreEqual
   ("Nullable object must have a value.",
    exc.Message);
 }//CheckException__InvalidOperationException__NullableObjectMustHaveValue

 //-----------------------------------------------------------------------
 public static void CheckException__StringLiteralContainsZeroSymbol
                           (ArgumentException exc,
                            string            src_name,
                            string            arg_name,
                            int               position)
 {
  Assert.That(exc,Is.Not.Null);

  Assert.That(exc.ParamName,Is.EqualTo(arg_name));

  var src=src_name;

  var msg_ru
   =string.Format
     ("Нулевой символ [позиция: {0}] в текстовом значении.",
      position);

  var msg_en
   =string.Format
     ("Zero symbol [position: {0}] in string literal.",
      position);

  //----------------------------------------
  TestExceptionSrcAndDescr__RU_EN
   (exc,
    src,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_INVALIDARG);
 }//CheckException__StringLiteralContainsZeroSymbol

 //-----------------------------------------------------------------------
 public static void CheckException__ArgErr_BadListSize
                           (ArgumentException exc,
                            string            src_name,
                            string            method_name,
                            string            arg_name,
                            int               actualSize)
 {
  Assert.That(exc,Is.Not.Null);

  Assert.That(exc.ParamName,Is.EqualTo(arg_name));

  var src=src_name;

  var args=new object[]{method_name,arg_name,actualSize};

  var msg_ru
   =string.Format
     ("Метод \"{0}\". Некорректный размер списка в аргументе \"{1}\": {2}.",
      args);

  var msg_en
   =string.Format
     ("Method \"{0}\". Bad size of list in argument \"{1}\": {2}.",
      args);

  //----------------------------------------
  TestExceptionSrcAndDescr__RU_EN
   (exc,
    src,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_INVALIDARG);
 }//CheckException__ArgErr_BadListSize

 //-----------------------------------------------------------------------
 public static void CheckException__ArgErr_BadListSize
                           (ArgumentException exc,
                            string            src_name,
                            string            method_name,
                            string            arg_name,
                            int               actualSize,
                            int               expectedSize)
 {
  Assert.That(exc,Is.Not.Null);

  Assert.That(exc.ParamName,Is.EqualTo(arg_name));

  var src=src_name;

  var args=new object[]{method_name,arg_name,actualSize,expectedSize};

  var msg_ru
   =string.Format
     ("Метод \"{0}\". Некорректный размер списка в аргументе \"{1}\": {2}. Ожидается список с размером: {3}.",
      args);

  var msg_en
   =string.Format
     ("Method \"{0}\". Bad size of list in argument \"{1}\": {2}. Expected list size: {3}.",
      args);

  //----------------------------------------
  TestExceptionSrcAndDescr__RU_EN
   (exc,
    src,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_INVALIDARG);
 }//CheckException__ArgErr_BadListSize

 //-----------------------------------------------------------------------
 public static void CheckException__DeserializationError
                                           (SerializationException exc,
                                            string                 src_id,
                                            string                 check_point)
 {
  Assert.That(exc,Is.Not.Null);

  string msg_ru=string.Format
   ("[BUG CHECK] Некорректное состояние десериализированного объекта [{0}]. "
    +"Точка проверки: \"{1}\".",
    src_id,
    check_point);

  string msg_en=string.Format
   ("[BUG CHECK] Wrong state of deserialized object [{0}]. "
    +"Check point: \"{1}\".",
    src_id,
    check_point);

  //----------------------------------------
  TestExceptionSrcAndDescr__RU_EN
   (exc,
    src_id,
    msg_ru,
    msg_en,
    com_lib.HResultCode.COR_E_SERIALIZATION);
 }//CheckException__DeserializationError

 //-----------------------------------------------------------------------
 public static void CheckException__DeserializationError__NullPtrToObject
                                           (SerializationException exc,
                                            string                 src_id,
                                            string                 object_name)
 {
  Assert.That(exc,Is.Not.Null);

  var args=new object[]{src_id,object_name};

  string msg_ru=string.Format
   ( "[BUG CHECK] Ошибка десериализации объекта [{0}]. "
     +"Восстановлен нулевой указатель на объект [{1}].",
    args);

  string msg_en=string.Format
   ("[BUG CHECK] Wrong state of deserialized object [{0}]. "
     +"Restored the null pointer to object [{1}].",
    args);

  //----------------------------------------
  TestExceptionSrcAndDescr__RU_EN
   (exc,
    src_id,
    msg_ru,
    msg_en,
    com_lib.HResultCode.COR_E_SERIALIZATION);
 }//CheckException__DeserializationError__NullPtrToObject

 //-----------------------------------------------------------------------
 public static void CheckException__DeserializationError__NullPtrToElement
                                           (SerializationException exc,
                                            string                 src_id,
                                            int                    element_index,
                                            string                 container_name)
 {
  Assert.That(exc,Is.Not.Null);

  string msg_ru=string.Format
   ("[BUG CHECK] Ошибка десериализации объекта [{0}]. "
    +"Восстановлен нулевой указатель в элементе [{1}] контейнера [{2}].",
    src_id,
    element_index,
    container_name);

  string msg_en=string.Format
   ("[BUG CHECK] Wrong state of deserialized object [{0}]. "
    +"Restored a null pointer in element [{1}] of container [{2}].",
    src_id,
    element_index,
    container_name);

  //----------------------------------------
  TestExceptionSrcAndDescr__RU_EN
   (exc,
    src_id,
    msg_ru,
    msg_en,
    com_lib.HResultCode.COR_E_SERIALIZATION);
 }//CheckException__DeserializationError__NullPtrToElement

 //-----------------------------------------------------------------------
 public static void CheckException__DecimalUtils__FailedToTransformMpNum10ToDecimal
                                            (OverflowException exc)
 {
  Assert.NotNull(exc);

  PrintException_OK(exc);

  string src=c_src__structure_lib__DecimalUtils;

  var msg_ru=
   string.Format
     ("Невозможно преобразовать MpNum10 в Decimal.");

  var msg_en=
   string.Format
     ("Failed to transform MpNum10 to Decimal.");

  TestExceptionSrcAndDescr2__RU_EN
   (exc,
    src,
    msg_ru,
    msg_en);

  return;
 }//CheckException__DecimalUtils__FailedToTransformMpNum10ToDecimal

 //-----------------------------------------------------------------------
 public static void CheckException__common_err__empty_object_name_0
                           (InvalidOperationException exc,
                            string                    src_name)
 {
  Assert.That(exc,Is.Not.Null);

  var src=src_name;

  var msg_ru
   =string.Format
     ("Пустое имя объекта.");

  var msg_en
   =string.Format
     ("Empty object name.");

  //----------------------------------------
  TestExceptionSrcAndDescr__RU_EN
   (exc,
    src,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckException__common_err__empty_object_name_0

 //-----------------------------------------------------------------------
 public static void CheckException__common_err__bad_symbol_in_unquoted_object_name_2
                           (InvalidOperationException exc,
                            string                    src_name,
                            int                       position,
                            int                       charCode)
 {
  Assert.That(exc,Is.Not.Null);

  var src=src_name;

  var msg_ru
   =string.Format
     ("Недопустимый символ в неквотированном имени объекта [позиция: {0}, код символа: {1}].",
      position,charCode);

  var msg_en
   =string.Format
     ("Bad symbol in unquoted object name [position: {0}, char code: {1}].",
      position,charCode);

  //----------------------------------------
  TestExceptionSrcAndDescr__RU_EN
   (exc,
    src,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckException__common_err__bad_symbol_in_unquoted_object_name_2

 //-----------------------------------------------------------------------
 public static void CheckException__common_err__bad_symbol_in_quoted_object_name_2
                           (InvalidOperationException exc,
                            string                    src_name,
                            int                       position,
                            int                       charCode)
 {
  Assert.That(exc,Is.Not.Null);

  var src=src_name;

  var msg_ru
   =string.Format
     ("Недопустимый символ в квотированном имени объекта [позиция: {0}, код символа: {1}].",
      position,charCode);

  var msg_en
   =string.Format
     ("Bad symbol in quoted object name [position: {0}, char code: {1}].",
      position,charCode);

  //----------------------------------------
  TestExceptionSrcAndDescr__RU_EN
   (exc,
    src,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckException__common_err__bad_symbol_in_quoted_object_name_2

 //-----------------------------------------------------------------------
 public static void CheckException__common_err__not_defined_cmd_parameter_prefix_0
                           (InvalidOperationException exc,
                            string                    src_name)
 {
  Assert.That(exc,Is.Not.Null);

  var src=src_name;

  var msg_ru
   =string.Format
     ("Не определен префикс именованных параметров.");

  var msg_en
   =string.Format
     ("Not defined named parameter prefix.");

  //----------------------------------------
  TestExceptionSrcAndDescr__RU_EN
   (exc,
    src,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckException__common_err__not_defined_cmd_parameter_prefix_0

 //-----------------------------------------------------------------------
 public static void CheckException__common_err__bad_cmd_parameter_name_format_1
                           (InvalidOperationException exc,
                            string                    src_name,
                            string                    parameterName)
 {
  Assert.That(exc,Is.Not.Null);

  var src
   =src_name;

  var args
   =new object[]
     {
      parameterName,
     };

  var msg_ru
   =string.Format
     ("Некорректный формат имени параметра команды: [{0}].",
      args);

  var msg_en
   =string.Format
     ("Bad format of command parameter name: [{0}].",
      args);

  //----------------------------------------
  TestExceptionSrcAndDescr__RU_EN
   (exc,
    src,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckException__common_err__bad_cmd_parameter_name_format_1

 //-----------------------------------------------------------------------
 public static void CheckException__common_err__bad_cmd_parameter_name_format__incorrect_prefix_1
                           (InvalidOperationException exc,
                            string                    src_name,
                            string                    parameterName)
 {
  Assert.That(exc,Is.Not.Null);

  var src
   =src_name;

  var args
   =new object[]
     {
      parameterName,
     };

  var msg_ru
   =string.Format
     ("Некорректный формат имени параметра команды, неправильный префикс: [{0}].",
      args);

  var msg_en
   =string.Format
     ("Bad format of command parameter name, incorrect prefix: [{0}].",
      args);

  //----------------------------------------
  TestExceptionSrcAndDescr__RU_EN
   (exc,
    src,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckException__common_err__bad_cmd_parameter_name_format__incorrect_prefix_1

 //-----------------------------------------------------------------------
 public static void CheckException__common_err__no_provider_configured_0
                           (InvalidOperationException exc,
                            string                    src_name)
 {
  Assert.That(exc,Is.Not.Null);

  var src=src_name;

  var msg_ru
   =string.Format
     ("Отсутствует конфигурация провайдера LcpiOleDb.");

  var msg_en
   =string.Format
     ("No configuration for LcpiOleDb provider.");

  //----------------------------------------
  TestExceptionSrcAndDescr__RU_EN
   (exc,
    src,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckException__common_err__no_provider_configured_0

 //-----------------------------------------------------------------------
 public static void CheckException__common_err__multiple_provider_configured_0
                           (InvalidOperationException exc,
                            string                    src_name)
 {
  Assert.That(exc,Is.Not.Null);

  var src=src_name;

  var msg_ru
   =string.Format
     ("Несколько конфигураций провайдера LcpiOleDb.");

  var msg_en
   =string.Format
     ("Multiple configurations for LcpiOleDb provider.");

  //----------------------------------------
  TestExceptionSrcAndDescr__RU_EN
   (exc,
    src,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckException__common_err__multiple_provider_configured_0

 //-----------------------------------------------------------------------
 public static void CheckException__common_err__unsupported_datatypes_conversion_2
                           (InvalidOperationException exc,
                            string                    src_name,
                            System.Type               sourceType,
                            System.Type               targetType)
 {
  Assert.That(exc,Is.Not.Null);

  var src=src_name;

  var args=new string[]
   {
    sourceType.FullName,
    targetType.FullName
   };

  var msg_ru
   =string.Format
     ("Конвертирование значения из типа [{0}] в тип [{1}] не поддерживается.",
       args);

  var msg_en
   =string.Format
     ("Conversion of value from [{0}] to [{1}] isn't supported.",
       args);

  //----------------------------------------
  TestExceptionSrcAndDescr__RU_EN
   (exc,
    src,
    msg_ru,
    msg_en,
    com_lib.HResultCode.DB_E_UNSUPPORTEDCONVERSION);
 }//CheckException__common_err__unsupported_datatypes_conversion_2

 //-----------------------------------------------------------------------
 public static void CheckException__common_err__failed_to_convert_value_between_types_2
                           (OverflowException         exc,
                            string                    src_name,
                            com_lib.HResultCode       errCode,
                            System.Type               sourceType,
                            System.Type               targetType)
 {
  Assert.That(exc,Is.Not.Null);

  var src=src_name;

  var args=new string[]
   {
    sourceType.FullName,
    targetType.FullName
   };

  var msg_ru
   =string.Format
     ("Ошибка конвертирования значения из типа [{0}] в тип [{1}].",
       args);

  var msg_en
   =string.Format
     ("Failed to convert a value from type [{0}] to type [{1}].",
       args);

  //----------------------------------------
  TestExceptionSrcAndDescr__RU_EN
   (exc,
    src,
    msg_ru,
    msg_en,
    errCode);
 }//CheckException__common_err__failed_to_convert_value_between_types_2

 //-----------------------------------------------------------------------
 public static void CheckException__common_err__target_property_not_accept_null_value_0
                           (InvalidOperationException exc,
                            string                    src_name)
 {
  Assert.That(exc,Is.Not.Null);

  var src=src_name;

  var args=new string[]
   {
   };

  var msg_ru
   =string.Format
     ("Целевое свойство не допускает установку NULL-значений.",
       args);

  var msg_en
   =string.Format
     ("Target property does not allow NULL value.",
       args);

  //----------------------------------------
  TestExceptionSrcAndDescr__RU_EN
   (exc,
    src,
    msg_ru,
    msg_en,
    com_lib.HResultCode.DB_E_BADVALUES);
 }//CheckException__common_err__target_property_not_accept_null_value_0

 //-----------------------------------------------------------------------
 public static void CheckException__type_mapping_err__cant_map_clr_type_to_provider_data_type_1
                           (InvalidOperationException exc,
                            string                    src_name,
                            System.Type               clrType)
 {
  Assert.That(exc,Is.Not.Null);

  var src=src_name;

  var args=new string[]
   {
    clrType.FullName
   };

  var msg_ru
   =string.Format
     ("Невозможно отобразить CLR-тип [{0}] на тип данных провайдера.",
       args);

  var msg_en
   =string.Format
     ("Can't map CLR-type [{0}] to provider datatype.",
       args);

  //----------------------------------------
  TestExceptionSrcAndDescr__RU_EN
   (exc,
    src,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckException__type_mapping_err__cant_map_clr_type_to_provider_data_type_1

 //-----------------------------------------------------------------------
 public static void CheckException__type_mapping_err__cant_map_info_to_provider_data_type_2
                           (InvalidOperationException exc,
                            string                    src_name,
                            System.Type               clrType,
                            string                    baseTypeName)
 {
  Assert.That(exc,Is.Not.Null);

  var src=src_name;

  var args=new string[]
   {
    Object.ReferenceEquals(clrType,null)?"#NULL":clrType.FullName,
    Object.ReferenceEquals(baseTypeName,null)?"#NULL":baseTypeName,
   };

  var msg_ru
   =string.Format
     ("Невозможно отобразить описание [clrType: {0}].[baseTypeName: \"{1}\"] на тип данных провайдера.",
       args);

  var msg_en
   =string.Format
     ("Can't map description [clrType: {0}].[baseTypeName: \"{1}\"] to provider datatype.",
       args);

  //----------------------------------------
  TestExceptionSrcAndDescr__RU_EN
   (exc,
    src,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckException__type_mapping_err__cant_map_info_to_provider_data_type_2

 //-----------------------------------------------------------------------
 public static void CheckException__common_err__unexpected_command_param_direction_2
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     paramName,
                     ParameterDirection         paramDirection)
 {
  Assert.NotNull
   (err_rec);

  var args=new object[]{paramName,paramDirection};

  var msg_ru=String.Format
   ("Неожиданное направление параметра команды [{0}]: {1}.",
    args);

  var msg_en=String.Format
   ("Unexpected direction of command parameter [{0}]: {1}.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckException__common_err__unexpected_command_param_direction_2

 //-----------------------------------------------------------------------
 public static void CheckException__common_err__no_command_param_value_1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     paramName)
 {
  Assert.NotNull
   (err_rec);

  var args=new object[]{paramName};

  var msg_ru=String.Format
   ("Не определено значение параметра команды [{0}].",
    args);

  var msg_en=String.Format
   ("No value of command parameter [{0}].",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckException__common_err__no_command_param_value_1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__common_err__argument_is_null__2
                           (structure_lib.IErrorRecord err_rec,
                            string                     src_name,
                            string                     method_name,
                            string                     arg_name)
 {
  Assert.NotNull(err_rec);

  var src=src_name;

  var args
   =new object[]
    {
     method_name,
     arg_name
    };

  var msg_ru
   =string.Format
     ("Метод \"{0}\". Аргумент \"{1}\" содержит null.",
      args);

  var msg_en
   =string.Format
     ("Method \"{0}\". Argument \"{1}\" is null.",
      args);

  //----------------------------------------
  TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    src,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_POINTER);
 }//CheckErrorRecord__common_err__argument_is_null__2

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__common_err__unsupported_datatypes_conversion_2
                           (structure_lib.IErrorRecord err_rec,
                            string                     src_name,
                            string                     sourceTypeSign,
                            string                     targetTypeSign)
 {
  Assert.NotNull
   (err_rec);

  var src=src_name;

  var args=new string[]
   {
    sourceTypeSign,
    targetTypeSign
   };

  var msg_ru
   =string.Format
     ("Конвертирование значения из типа [{0}] в тип [{1}] не поддерживается.",
       args);

  var msg_en
   =string.Format
     ("Conversion of value from [{0}] to [{1}] isn't supported.",
       args);

  //----------------------------------------
  TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    src,
    msg_ru,
    msg_en,
    com_lib.HResultCode.DB_E_UNSUPPORTEDCONVERSION);
 }//CheckErrorRecord__common_err__unsupported_datatypes_conversion_2

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__common_err__overflow_in_arithmetic_op1__3<TA1>
                           (structure_lib.IErrorRecord err_rec,
                            string                     srcID,
                            ExpressionType             opType,
                            object                     argument)
 {
  Assert.NotNull
   (err_rec);

  var args=new object[]
   {
    opType,
    typeof(TA1).FullName,
    argument
   };

  var msg_ru
   =string.Format
     ("Переполнение при вычислении унарной арифметической операции [{0}]. Аргумент: [{1}] {2}.",
       args);

  var msg_en
   =string.Format
     ("Overflow in calculation of unary arithmetic operation [{0}]. Argument: [{1}] {2}.",
       args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.COR_E_OVERFLOW);
 }//CheckErrorRecord__common_err__overflow_in_arithmetic_op1__3

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__common_err__overflow_in_arithmetic_op2__5<TA1,TA2>
                           (structure_lib.IErrorRecord err_rec,
                            string                     srcID,
                            ExpressionType             opType,
                            object                     leftArgument,
                            object                     rightArgument)
 {
  Assert.NotNull
   (err_rec);

  var args=new object[]
   {
    opType,
    typeof(TA1).FullName,
    leftArgument,
    typeof(TA2).FullName,
    rightArgument
   };

  var msg_ru
   =string.Format
     ("Переполнение при вычислении бинарной арифметической операции [{0}]. Левый аргумент: [{1}] {2}. Правый аргумент: [{3}] {4}.",
       args);

  var msg_en
   =string.Format
     ("Overflow in calculation of binary arithmetic operation [{0}]. Left argument: [{1}] {2}. Right argument: [{3}] {4}.",
       args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.COR_E_OVERFLOW);
 }//CheckErrorRecord__common_err__overflow_in_arithmetic_op2__5

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__common_err__divide_by_zero
                           (structure_lib.IErrorRecord err_rec,
                            string                     srcID)
 {
  Assert.NotNull
   (err_rec);

  var args=new object[]
   {
   };

  var msg_ru
   =string.Format
     ("Деление на ноль.",
       args);

  var msg_en
   =string.Format
     ("Divide by zero.",
       args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.COR_E_DIVIDEBYZERO);
 }//CheckErrorRecord__common_err__divide_by_zero

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__common_err__out_of_range_in_arithmetic_op2__5<TA1,TA2>
                           (structure_lib.IErrorRecord err_rec,
                            string                     srcID,
                            ExpressionType             opType,
                            object                     leftArgument,
                            object                     rightArgument)
 {
  Assert.NotNull
   (err_rec);

  var args=new object[]
   {
    opType,
    typeof(TA1).FullName,
    leftArgument,
    typeof(TA2).FullName,
    rightArgument
   };

  var msg_ru
   =string.Format
     ("Результат арифметической операции [{0}] выходит за допустимый диапазон. Левый аргумент: [{1}] {2}. Правый аргумент: [{3}] {4}.",
       args);

  var msg_en
   =string.Format
     ("Result of arithmetic operation [{0}] is out of range. Left argument: [{1}] {2}. Right argument: [{3}] {4}.",
       args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.COR_E_OVERFLOW);
 }//CheckErrorRecord__common_err__out_of_range_in_arithmetic_op2__5

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__common_err__index_out_of_range__2
                           (structure_lib.IErrorRecord err_rec,
                            string                     srcID,
                            object                     index,
                            object                     countOfElements)
 {
  Assert.NotNull
   (err_rec);

  var args=new object[]
   {
    index,
    countOfElements
   };

  var msg_ru
   =string.Format
     ("Индекс элемента [{0}] вне допустимого диапазона. Количество элементов: {1}.",
       args);

  var msg_en
   =string.Format
     ("The index [{0}] of the element is out of range. Count of elements: {1}.",
       args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__common_err__index_out_of_range__2

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__common_err__empty_list_of_values__0
                           (structure_lib.IErrorRecord err_rec,
                            string                     srcID)
 {
  Assert.NotNull
   (err_rec);

  var args=new object[]
   {
   };

  var msg_ru
   =string.Format
     ("Пустой список значений.",
       args);

  var msg_en
   =string.Format
     ("Empty list of values.",
       args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__common_err__empty_list_of_values__0

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__common_err__type_not_support_method_3
                           (structure_lib.IErrorRecord err_rec,
                            string                     srcID,
                            string                     typeSign,
                            string                     methodSign,
                            string                     methodParams)
 {
  Assert.NotNull
   (err_rec);

  var args=new object[]
   {
    typeSign,
    methodSign,
    methodParams
   };

  var msg_ru
   =string.Format
     ("Тип {0} не предоставляет метод {1} с аргументами ({2}).",
       args);

  var msg_en
   =string.Format
     ("Type {0} does not provide a method {1} with parameters ({2}).",
       args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__common_err__type_not_support_method_3

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__common_err__cant_remap_normal_method_3
                           (structure_lib.IErrorRecord err_rec,
                            string                     srcID,
                            string                     sourceMethodSign,
                            string                     targetTypeSign,
                            string                     targetMethodParams)
 {
  Assert.NotNull
   (err_rec);

  var args=new object[]
   {
    sourceMethodSign,
    targetTypeSign,
    targetMethodParams
   };

  var msg_ru
   =string.Format
     ("Не получается отобразить метод [{0}] на метод класса {1} c параметрами ({2}).",
       args);

  var msg_en
   =string.Format
     ("Can't remap method [{0}] to method of class {1} with parameters ({2}).",
       args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__common_err__cant_remap_normal_method_3

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__common_err__cant_remap_generic_method_4
                           (structure_lib.IErrorRecord err_rec,
                            string                     srcID,
                            string                     sourceMethodSign,
                            string                     targetTypeSign,
                            string                     targetMethodParams,
                            string                     targetMethodGenericArgs)
 {
  Assert.NotNull
   (err_rec);

  var args=new object[]
   {
    sourceMethodSign,
    targetTypeSign,
    targetMethodParams,
    targetMethodGenericArgs
   };

  var msg_ru
   =string.Format
     ("Не получается отобразить метод [{0}] на метод класса {1} c параметрами <{3}>({2}).",
       args);

  var msg_en
   =string.Format
     ("Can't remap method [{0}] to method of class {1} with parameters <{3}>({2}).",
       args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__common_err__cant_remap_generic_method_4

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__common_err__cant_alloc_new_array__overflow__2
                           (structure_lib.IErrorRecord err_rec,
                            string                     srcID,
                            string                     checkPlace,
                            string                     checkPoint)
 {
  Assert.NotNull
   (err_rec);

  var args=new string[]
   {
    checkPlace,
    checkPoint
   };

  var msg_ru
   =string.Format
     ("Ошибка создания массива. Слишком большое число элементов. Точка проверки [{0}][{1}].",
       args);

  var msg_en
   =string.Format
     ("Failed to allocate array. Too many elements. Check point [{0}][{1}].",
       args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__common_err__cant_alloc_new_array__overflow__2

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__bug_check__value_is_null
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     bugCheckPlace,
                     string                     bugCheckPoint,
                     string                     valueName)
 {
  Assert.NotNull
   (err_rec);

  var reason=String.Format
   ("value [{0}] is null",
    valueName);

  CheckErrors.TestBugCheck_RU_EN
   (err_rec,
    srcID,
    bugCheckPlace,
    bugCheckPoint,
    reason,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__bug_check__value_is_null

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__bug_check__value_is_empty
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     bugCheckPlace,
                     string                     bugCheckPoint,
                     string                     valueName)
 {
  Assert.NotNull
   (err_rec);

  var reason=String.Format
   ("value [{0}] is empty",
    valueName);

  CheckErrors.TestBugCheck_RU_EN
   (err_rec,
    srcID,
    bugCheckPlace,
    bugCheckPoint,
    reason,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__bug_check__value_is_empty

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__bug_check__unexpected_value_type
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     bugCheckPlace,
                     string                     bugCheckPoint,
                     string                     valueName,
                     Type                       valueType)
 {
  Assert.NotNull
   (err_rec);

  var reason=String.Format
   ("unexpected value [{0}] type: {1}",
    valueName,
    valueType.FullName);

  CheckErrors.TestBugCheck_RU_EN
   (err_rec,
    srcID,
    bugCheckPlace,
    bugCheckPoint,
    reason,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__bug_check__unexpected_value_type

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__bug_check__unexpected_value<T>
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     bugCheckPlace,
                     string                     bugCheckPoint,
                     string                     valueName,
                     T                          value)
 {
  Assert.NotNull
   (err_rec);

  var reason=String.Format
   ("unexpected value of [{0}]: [{1}]",
    valueName,
    value);

  CheckErrors.TestBugCheck_RU_EN
   (err_rec,
    srcID,
    bugCheckPlace,
    bugCheckPoint,
    reason,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__bug_check__unexpected_value<T>

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__bug_check__bad_value_type
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     bugCheckPlace,
                     string                     bugCheckPoint,
                     string                     valueName,
                     Type                       valueType,
                     Type                       expectedType)
 {
  Assert.NotNull
   (err_rec);

  var reason=String.Format
   ("bad value [{0}] type: {1}. Expected type: {2}",
    valueName,
    valueType.FullName,
    expectedType.FullName);

  CheckErrors.TestBugCheck_RU_EN
   (err_rec,
    srcID,
    bugCheckPlace,
    bugCheckPoint,
    reason,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__bug_check__bad_value_type

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__bug_check__unexpected_type
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     bugCheckPlace,
                     string                     bugCheckPoint,
                     Type                       valueType)
 {
  Assert.NotNull
   (err_rec);

  var reason=String.Format
   ("unexpected type: {0}",
    valueType.FullName);

  CheckErrors.TestBugCheck_RU_EN
   (err_rec,
    srcID,
    bugCheckPlace,
    bugCheckPoint,
    reason,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__bug_check__unexpected_type

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__bug_check__unexpected_operator_type
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     bugCheckPlace,
                     string                     bugCheckPoint,
                     ExpressionType             operatorType)
 {
  Assert.NotNull
   (err_rec);

  var reason=String.Format
   ("unexpected operator type: {0}",
    operatorType);

  CheckErrors.TestBugCheck_RU_EN
   (err_rec,
    srcID,
    bugCheckPlace,
    bugCheckPoint,
    reason,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__bug_check__unexpected_operator_type

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__bug_check__TypeMapping_ClrType_Is_Null
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     bugCheckPlace,
                     string                     bugCheckPoint)
 {
  Assert.NotNull
   (err_rec);

  var reason
   =String.Format
     ("TypeMapping.ClrType is null");

  CheckErrors.TestBugCheck_RU_EN
   (err_rec,
    srcID,
    bugCheckPlace,
    bugCheckPoint,
    reason,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__bug_check__TypeMapping_ClrType_Is_Null

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__bug_check__Unexpected_SqlExpression_Value_Type
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     bugCheckPlace,
                     string                     bugCheckPoint,
                     System.Type                type)
 {
  Assert.NotNull
   (err_rec);

  var reason
   =String.Format
     ("unexpected sql expression value type: {0}",
      type.FullName);

  CheckErrors.TestBugCheck_RU_EN
   (err_rec,
    srcID,
    bugCheckPlace,
    bugCheckPoint,
    reason,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__bug_check__Unexpected_SqlExpression_Value_Type

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__bug_check__sql_translation_of_member_not_supported
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     bugCheckPlace,
                     string                     bugCheckPoint,
                     string                     memberSign)
 {
  Assert.NotNull
   (err_rec);

  var reason
   =String.Format
     ("sql-translation of member {0} not supported",
      memberSign);

  CheckErrors.TestBugCheck_RU_EN
   (err_rec,
    srcID,
    bugCheckPlace,
    bugCheckPoint,
    reason,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__bug_check__sql_translation_of_member_not_supported

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__bug_check__SqlConstantExpression_contains_not_null_value
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     bugCheckPlace,
                     string                     bugCheckPoint)
 {
  Assert.NotNull
   (err_rec);

  var reason
   =String.Format
     ("SqlConstantExpression contains not null value");

  CheckErrors.TestBugCheck_RU_EN
   (err_rec,
    srcID,
    bugCheckPlace,
    bugCheckPoint,
    reason,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__bug_check__SqlConstantExpression_contains_not_null_value

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__bug_check__Unexpected_SqlExpression_Class_Type
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     bugCheckPlace,
                     string                     bugCheckPoint,
                     System.Type                type)
 {
  Assert.NotNull
   (err_rec);

  var reason
   =String.Format
     ("unexpected sql expression class type: {0}",
      type.FullName);

  CheckErrors.TestBugCheck_RU_EN
   (err_rec,
    srcID,
    bugCheckPlace,
    bugCheckPoint,
    reason,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__bug_check__Unexpected_SqlExpression_Class_Type

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__bug_check__Unexpected_Expression_NodeType
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     bugCheckPlace,
                     string                     bugCheckPoint,
                     ExpressionType             nodeType)
 {
  Assert.NotNull
   (err_rec);

  var reason
   =String.Format
     ("unexpected expression node type: {0}",
      nodeType);

  CheckErrors.TestBugCheck_RU_EN
   (err_rec,
    srcID,
    bugCheckPlace,
    bugCheckPoint,
    reason,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__bug_check__Unexpected_Expression_NodeType

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__bug_check__engine_svc_not_supported_1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     Guid                       svcID)
 {
  Assert.NotNull
   (err_rec);

  var args=new object[]{svcID};

  var msg_ru=String.Format
   ("[BUG CHECK] Сервис [id: {0}] не поддерживается текущим подключением.",
    args);

  var msg_en=String.Format
   ("[BUG CHECK] Service [id: {0}] is not supported by current connection.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__bug_check__engine_svc_not_supported_1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__bug_check__engine_svc_not_supported_req_interface_2
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     Guid                       svcID,
                     Type                       reqSvcType)
 {
  Assert.NotNull
   (err_rec);

  Debug.Assert(!Object.ReferenceEquals(reqSvcType,null));

  var args=new object[]{svcID,reqSvcType.FullName};

  var msg_ru=String.Format
   ("[BUG CHECK] Сервис [id: {0}] не поддерживает интерфейс [{1}].",
    args);

  var msg_en=String.Format
   ("[BUG CHECK] Service [id: {0}] is not supports the required interface [{1}].",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__bug_check__engine_svc_not_supported_req_interface_2

 //-----------------------------------------------------------------------
 // public static void CheckErrorRecord__CommonErr__NoConnectionObject
 //                    (structure_lib.IErrorRecord err_rec,
 //                     string                     srcID)
 // {
 //  Assert.NotNull
 //   (err_rec);
 //
 //  var msg_ru=String.Format
 //   ("Нет объект подключения к базе данных.");
 //
 //  var msg_en=String.Format
 //   ("No object of connection to database.");
 //
 //  var err_code=com_lib.HResultCode.E_FAIL;
 //
 //  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
 //   (err_rec,
 //    srcID,
 //    msg_ru,
 //    msg_en,
 //    err_code);
 // }//CheckErrorRecord__CommonErr__NoConnection
 //
 //-----------------------------------------------------------------------
 // public static void CheckErrorRecord__CommonErr__UnexpectedConnectionObjectType
 //                    (structure_lib.IErrorRecord err_rec,
 //                     string                     srcID,
 //                     string                     objectFullTypeName)
 // {
 //  Assert.NotNull
 //   (err_rec);
 //
 //  var args=new string[]
 //   {
 //    objectFullTypeName,
 //    typeof(xdb.OleDbConnection).FullName
 //   };
 //
 //  var msg_ru=String.Format
 //   ("Некорректный тип объекта подключения к базе данных: [{0}]. Ожидался объект с типом: [{1}].",
 //    args);
 //
 //  var msg_en=String.Format
 //   ("Incorrect type of database connection object: [{0}]. Expected to object with type: [{1}].",
 //    args);
 //
 //  var err_code=com_lib.HResultCode.E_FAIL;
 //
 //  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
 //   (err_rec,
 //    srcID,
 //    msg_ru,
 //    msg_en,
 //    err_code);
 // }//CheckErrorRecord__CommonErr__UnexpectedConnectionObjectType
 //
 //-----------------------------------------------------------------------
 // public static void CheckErrorRecord__CommonErr__UnknownTableType
 //                    (structure_lib.IErrorRecord err_rec,
 //                     string                     srcID,
 //                     string                     tableId,
 //                     string                     tableType,
 //                     com_lib.HResultCode        err_code)
 // {
 //  Assert.NotNull
 //   (err_rec);
 //
 //  var args=new string[]{tableId,tableType};
 //
 //  var msg_ru=String.Format
 //   ("Неизвестный тип таблицы [{0}]: [{1}].",
 //    args);
 //
 //  var msg_en=String.Format
 //   ("Unknown table type [{0}]: [{1}].",
 //    args);
 //
 //  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
 //   (err_rec,
 //    srcID,
 //    msg_ru,
 //    msg_en,
 //    err_code);
 // }//CheckErrorRecord__CommonErr__UnknownTableType
 //
 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__CommonErr__UnknownDbmsName
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     dbmsName)
 {
  Assert.NotNull
   (err_rec);

  var args=new string[]{dbmsName};

  var msg_ru=String.Format
   ("Неизвестное имя сервера баз данных: [{0}].",
    args);

  var msg_en=String.Format
   ("Unknown DBMS name: [{0}].",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__CommonErr__UnknownDbmsName

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__CommonErr__UnsupportedDbmsName
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     dbmsName,
                     Version                    dbmsVersion)
 {
  Assert.NotNull
   (err_rec);

  var args=new object[]{dbmsName,dbmsVersion};

  var msg_ru=String.Format
   ("Неподдерживаемая версия сервера баз данных [{0}]: [{1}].",
    args);

  var msg_en=String.Format
   ("Unsupported version of DBMS [{0}]: [{1}].",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__CommonErr__UnsupportedDbmsName

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__CommonErr__UnsupportedConnectionDialect
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     int                        connectionDialect)
 {
  Assert.NotNull
   (err_rec);

  var args=new object[]{connectionDialect};

  var msg_ru=String.Format
   ("Неподдерживаемый диалект подключения [{0}].",
    args);

  var msg_en=String.Format
   ("Unsupported connection dialect [{0}].",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__CommonErr__UnsupportedConnectionDialect

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__common_err__cant_convert_value_between_types_2
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     com_lib.HResultCode        errCode,
                     System.Type                sourceType,
                     System.Type                targetType)
 {
  Assert.NotNull
   (err_rec);

  var args=new string[]
   {
    sourceType.FullName,
    targetType.FullName
   };

  var msg_ru
   =string.Format
     ("Ошибка конвертирования значения из типа [{0}] в тип [{1}].",
       args);

  var msg_en
   =string.Format
     ("Failed to convert a value from type [{0}] to type [{1}].",
       args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    errCode);
 }//CheckErrorRecord__common_err__cant_convert_value_between_types_2

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__common_err__cant_convert_value_between_types_2
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     com_lib.HResultCode        errCode,
                     string                     sourceTypeSign,
                     string                     targetTypeSign)
 {
  Assert.NotNull
   (err_rec);

  var args=new string[]
   {
    sourceTypeSign,
    targetTypeSign
   };

  var msg_ru
   =string.Format
     ("Ошибка конвертирования значения из типа [{0}] в тип [{1}].",
       args);

  var msg_en
   =string.Format
     ("Failed to convert a value from type [{0}] to type [{1}].",
       args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    errCode);
 }//CheckErrorRecord__common_err__cant_convert_value_between_types_2

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__common_err__overflow_in_number_scale_calculation_0
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     com_lib.HResultCode        errCode)
 {
  Assert.NotNull
   (err_rec);

  var args=new string[]
   {
   };

  var msg_ru
   =string.Format
     ("Переполнение при вычислении масштаба числа.",
       args);

  var msg_en
   =string.Format
     ("Overflow in calculation of number scale.",
       args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    errCode);
 }//CheckErrorRecord__common_err__overflow_in_number_scale_calculation_0

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__common_err__failed_to_set_property_value_3
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     efRecordName,
                     string                     efRecordFieldName,
                     string                     columnName)
 {
  Assert.NotNull
   (err_rec);

  var args=new object[]
   {
    efRecordName,
    efRecordFieldName,
    columnName
   };

  var msg_ru=String.Format
   ("Ошибка установки значения свойства [{0}].[{1}], привязанного к колонке [{2}].",
    args);

  var msg_en=String.Format
   ("Failed to set value of property [{0}][{1}], which linked to column [{2}].",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__common_err__failed_to_set_property_value_3

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__common_err__direct_call_of_linq_method_not_allowed_1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     methodSign)
 {
  Assert.NotNull
   (err_rec);

  var args=new string[]
   {
    methodSign
   };

  var msg_ru=String.Format
   ("Непосредственный вызов метода [{0}] не допускается. Вы можете его вызывать только через linq-выражения.",
    args);

  var msg_en=String.Format
   ("Direct call of method [{0}] not allowed. You may call this method in linq-expressions only.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__common_err__direct_call_of_linq_method_not_allowed_1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__type_mapping_err__unknown_StoreTypeName_1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     storeTypeName)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new string[]
     {
      storeTypeName
     };

  var msg_ru=String.Format
   ("Неизвестный тип данных БД (StoreTypeName): [{0}].",
    args);

  var msg_en=String.Format
   ("Unknown database datatype (StoreTypeName): [{0}].",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__type_mapping_err__unknown_StoreTypeName_1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__type_mapping_err__unknown_StoreTypeName_2
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     storeTypeName,
                     string                     columnSign)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new string[]
     {
      storeTypeName,
      columnSign
     };

  var msg_ru=String.Format
   ("Неизвестный тип данных БД (StoreTypeName): [{0}]. Связанная колонка: [{1}].",
    args);

  var msg_en=String.Format
   ("Unknown database datatype (StoreTypeName): [{0}]. Linked column: [{1}].",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__type_mapping_err__unknown_StoreTypeName_2

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__type_mapping_err__unexpected_StoreTypeName_2
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     actualStoreTypeName,
                     string                     expectedStoreTypeName)
 {
  Assert.NotNull
   (err_rec);

  var args=new string[]{actualStoreTypeName,expectedStoreTypeName};

  var msg_ru=String.Format
   ("Недопустимое значение mappingInfo.StoreTypeName: [{0}]. Ожидалось имя: [{1}].",
    args);

  var msg_en=String.Format
   ("Unexpected value of mappingInfo.StoreTypeName: [{0}]. Expected name: [{1}].",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__type_mapping_err__unexpected_StoreTypeName_2

 //-----------------------------------------------------------------------
 // public static void CheckErrorRecord__type_mapping_err__cant_map_clr_type_to_provider_data_type_1
 //                    (structure_lib.IErrorRecord err_rec,
 //                     string                     srcID,
 //                     Type                       clrType)
 // {
 //  Assert.NotNull
 //   (err_rec);
 //
 //  var args=new string[]{clrType.FullName};
 //
 //  var msg_ru=String.Format
 //   ("Невозможно отобразить CLR-тип [{0}] на тип данных провайдера.",
 //    args);
 //
 //  var msg_en=String.Format
 //   ("Can't map CLR-type [{0}] to provider data type.",
 //    args);
 //
 //  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
 //   (err_rec,
 //    srcID,
 //    msg_ru,
 //    msg_en,
 //    com_lib.HResultCode.E_FAIL);
 // }//CheckErrorRecord__type_mapping_err__cant_map_clr_type_to_provider_data_type_1
 //
 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__type_mapping_err__unexpected_StoreTypeNameBase_2
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     actualStoreTypeName,
                     string                     expectedStoreTypeName)
 {
  Assert.NotNull
   (err_rec);

  var args=new string[]{actualStoreTypeName,expectedStoreTypeName};

  var msg_ru=String.Format
   ("Недопустимое значение mappingInfo.StoreTypeNameBase: [{0}]. Ожидалось имя: [{1}].",
    args);

  var msg_en=String.Format
   ("Unexpected value of mappingInfo.StoreTypeNameBase: [{0}]. Expected name: [{1}].",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__type_mapping_err__unexpected_StoreTypeNameBase_2

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__type_mapping_err__unexpected_Size_1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     int                        actualSize)
 {
  Assert.NotNull
   (err_rec);

  var args=new object[]{actualSize};

  var msg_ru=String.Format
   ("Недопустимое значение mappingInfo.Size: {0}.",
    args);

  var msg_en=String.Format
   ("Unexpected value of mappingInfo.Size: {0}.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__type_mapping_err__unexpected_Size_1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__type_mapping_err__not_defined_Size_0
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID)
 {
  Assert.NotNull
   (err_rec);

  var args=new string[]{};

  var msg_ru=String.Format
   ("mappingInfo.Size содержит null.",
    args);

  var msg_en=String.Format
   ("mappingInfo.Size contains null.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__type_mapping_err__not_defined_Size_0

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__type_mapping_err__too_large_Size_2
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     int                        actualSize,
                     int                        maxSize)
 {
  Assert.NotNull
   (err_rec);

  var args=new object[]{actualSize,maxSize};

  var msg_ru=String.Format
   ("Недопустимое значение mappingInfo.Size: {0}. Максимально допустимое значение: {1}.",
    args);

  var msg_en=String.Format
   ("Unexpected value of mappingInfo.Size: {0}. Max allowed value: {1}.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__type_mapping_err__too_large_Size_2

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__type_mapping_err__unexpected_IsUnicode_2
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     bool                       actualValue,
                     bool                       expectedValue)
 {
  Assert.NotNull
   (err_rec);

  var args=new object[]
  {
   TestUtils.ToString(actualValue),
   TestUtils.ToString(expectedValue)
  };

  var msg_ru=String.Format
   ("Недопустимое значение mappingInfo.IsUnicode: {0}. Ожидаемое значение: {1}.",
    args);

  var msg_en=String.Format
   ("Unexpected value of mappingInfo.IsUnicode: {0}. Expected value: {1}.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__type_mapping_err__unexpected_IsUnicode_2

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__type_mapping_err__unexpected_IsFixedLength_2
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     bool                       actualValue,
                     bool                       expectedValue)
 {
  Assert.NotNull
   (err_rec);

  var args=new object[]
  {
   TestUtils.ToString(actualValue),
   TestUtils.ToString(expectedValue)
  };

  var msg_ru=String.Format
   ("Недопустимое значение mappingInfo.IsFixedLength: {0}. Ожидаемое значение: {1}.",
    args);

  var msg_en=String.Format
   ("Unexpected value of mappingInfo.IsFixedLength: {0}. Expected value: {1}.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__type_mapping_err__unexpected_IsFixedLength_2

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__type_mapping_err__unexpected_ClrType_2
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     Type                       actualType,
                     Type                       expectedType)
 {
  Assert.NotNull
   (err_rec);

  var args=new object[]
  {
   actualType.FullName,
   expectedType.FullName
  };

  var msg_ru=String.Format
   ("Недопустимое значение mappingInfo.ClrType: {0}. Ожидаемый тип: {1}.",
    args);

  var msg_en=String.Format
   ("Unexpected value of mappingInfo.ClrType: {0}. Expected type: {1}.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__type_mapping_err__unexpected_ClrType_2

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__type_mapping_err__unexpected_IsRowVersion_2
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     bool                       actualValue,
                     bool                       expectedValue)
 {
  Assert.NotNull
   (err_rec);

  var args=new object[]
  {
   TestUtils.ToString(actualValue),
   TestUtils.ToString(expectedValue)
  };

  var msg_ru=String.Format
   ("Недопустимое значение mappingInfo.IsRowVersion: {0}. Ожидаемое значение: {1}.",
    args);

  var msg_en=String.Format
   ("Unexpected value of mappingInfo.IsRowVersion: {0}. Expected value: {1}.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__type_mapping_err__unexpected_IsRowVersion_2

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__type_mapping_err__unexpected_Precision_1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     int                        actualSize)
 {
  Assert.NotNull
   (err_rec);

  var args=new object[]{actualSize};

  var msg_ru=String.Format
   ("Недопустимое значение mappingInfo.Precision: {0}.",
    args);

  var msg_en=String.Format
   ("Unexpected value of mappingInfo.Precision: {0}.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__type_mapping_err__unexpected_Precision_1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__type_mapping_err__not_defined_Precision_0
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID)
 {
  Assert.NotNull
   (err_rec);

  var args=new string[]{};

  var msg_ru=String.Format
   ("mappingInfo.Precision содержит null.",
    args);

  var msg_en=String.Format
   ("mappingInfo.Precision contains null.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__type_mapping_err__not_defined_Precision_0

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__type_mapping_err__too_large_Precision_2
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     int                        actualPrecision,
                     int                        maxPrecision)
 {
  Assert.NotNull
   (err_rec);

  var args=new object[]{actualPrecision,maxPrecision};

  var msg_ru=String.Format
   ("Недопустимое значение mappingInfo.Precision: {0}. Максимально допустимое значение: {1}.",
    args);

  var msg_en=String.Format
   ("Unexpected value of mappingInfo.Precision: {0}. Max allowed value: {1}.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__type_mapping_err__too_large_Precision_2

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__type_mapping_err__not_allowed_definition_of_Scale_without_Precision_1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     int                        actualSсale)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
     {
      actualSсale
     };

  var msg_ru
   =String.Format
    ("Не допускается указание масштаба [{0}] без указания точности.",
     args);

  var msg_en
   =String.Format
    ("It is not allowed to definition the scale [{0}] without precision.",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__type_mapping_err__not_allowed_definition_of_Scale_without_Precision_1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__type_mapping_err__unexpected_Scale_1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     int                        actualSсale)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
     {
      actualSсale
     };

  var msg_ru
   =String.Format
    ("Недопустимое значение mappingInfo.Scale: {0}.",
     args);

  var msg_en
   =String.Format
    ("Unexpected value of mappingInfo.Scale: {0}.",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__type_mapping_err__unexpected_Scale_1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__type_mapping_err__not_defined_Scale_0
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID)
 {
  Assert.NotNull
   (err_rec);

  var args=new string[]{};

  var msg_ru=String.Format
   ("mappingInfo.Scale содержит null.",
    args);

  var msg_en=String.Format
   ("mappingInfo.Scale contains null.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__type_mapping_err__not_defined_Scale_0

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__type_mapping_err__too_large_Scale_2
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     int                        actualScale,
                     int                        maxScale)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
     {actualScale,
      maxScale};

  var msg_ru
   =String.Format
     ("Недопустимое значение mappingInfo.Scale: {0}. Максимально допустимое значение: {1}.",
      args);

  var msg_en
   =String.Format
     ("Unexpected value of mappingInfo.Scale: {0}. Max allowed value: {1}.",
      args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__type_mapping_err__too_large_Scale_2

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__type_mapping_err__multiple_definition_of_type_property_3
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     propertyName,
                     string                     value1Sign,
                     string                     value2Sign)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
     {
      propertyName,
      value1Sign,
      value2Sign
     };

  var msg_ru
   =String.Format
     ("Многократное определение значения свойства [{0}] в описании типа данных. Одно значение равно [{1}]. Другое значение равно [{2}].",
      args);

  var msg_en
   =String.Format
     ("Multiple definition of property [{0}] value in datatype description. One value is [{1}]. Second value is [{2}].",
      args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__type_mapping_err__multiple_definition_of_type_property_3

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__type_mapping_err__cant_convert_TimeSpan_to_database_format__out_of_range__4
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     actualValue,
                     string                     databaseTypeName,
                     string                     minValidValue,
                     string                     maxValidValue)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new string[]
    {actualValue,
     databaseTypeName,
     minValidValue,
     maxValidValue};

  var msg_ru
   =String.Format
    ("Невозможно привести TimeSpan значение [{0}] к формату {1}. Выход за пределы допустимого диапазона значений - [{2} .. {3}].",
     args);

  var msg_en
   =String.Format
    ("Unable to convert TimeSpan value [{0}] to format {1}. Out of range - [{2} .. {3}].",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__type_mapping_err__cant_convert_TimeSpan_to_database_format__out_of_range__4

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__type_mapping_err__cant_convert_database_value_to_TimeSpan__out_of_range__4
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     actualValue,
                     string                     databaseTypeName,
                     string                     minValidValue,
                     string                     maxValidValue)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new string[]
    {actualValue,
     databaseTypeName,
     minValidValue,
     maxValidValue};

  var msg_ru
   =String.Format
    ("Невозможно привести значение [{0}] с форматом хранения в базе данных {1} к TimeSpan. "
    +"Выход за пределы допустимого диапазона значений - [{2} .. {3}].",
     args);

  var msg_en
   =String.Format
    ("Unable to convert database value [{0}] with format {1} to TimeSpan. Out of range - [{2} .. {3}].",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__type_mapping_err__cant_convert_database_value_to_TimeSpan__out_of_range__4

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__type_mapping_err__cn_dialect_does_not_support_usage_of_type_in_DDL_query_2
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     long                       connectionDialect,
                     string                     databaseTypeName)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {connectionDialect,
     databaseTypeName};

  var msg_ru
   =String.Format
    ("Текущий диалект подключения [{0}] не разрешает использовать тип данных [{1}] в DDL запросах.",
     args);

  var msg_en
   =String.Format
    ("Current connection dialect [{0}] does not allow usage a datatype [{1}] in DDL queries.",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__type_mapping_err__cn_dialect_does_not_support_usage_of_type_in_DDL_query_2

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__type_mapping_err__unexpected_data_at_end_of_datatype_definition_1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     databaseTypeNameSign)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {databaseTypeNameSign};

  var msg_ru
   =String.Format
    ("Неизвестные данные в конце определения типа данных [{0}].",
     args);

  var msg_en
   =String.Format
    ("Unexpected data at end of datatype definition [{0}].",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__type_mapping_err__unexpected_data_at_end_of_datatype_definition_1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__type_mapping_err__incompleted_datatype_definition_0
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
    };

  var msg_ru
   =String.Format
    ("Незавершенное описание типа данных.",
     args);

  var msg_en
   =String.Format
    ("Incompleted datatype definition.",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__type_mapping_err__incompleted_datatype_definition_0

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__type_mapping_err__incompleted_datatype_definition_1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     databaseTypeNameSign)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {databaseTypeNameSign};

  var msg_ru
   =String.Format
    ("Незавершенное описание типа данных [{0}].",
     args);

  var msg_en
   =String.Format
    ("Incompleted datatype definition [{0}].",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__type_mapping_err__incompleted_datatype_definition_1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__type_mapping_err__bad_datatype_definition_1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     databaseTypeNameSign)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {databaseTypeNameSign};

  var msg_ru
   =String.Format
    ("Некорректное описание типа данных [{0}].",
     args);

  var msg_en
   =String.Format
    ("Bad datatype definition [{0}].",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__type_mapping_err__bad_datatype_definition_1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__type_mapping_err__not_defined_charset_name_1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     databaseTypeNameSign)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {databaseTypeNameSign};

  var msg_ru
   =String.Format
    ("В описании типа данных [{0}] не указано имя кодовой страницы.",
     args);

  var msg_en
   =String.Format
    ("In datatype definition [{0}] not defined a character set name.",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__type_mapping_err__not_defined_charset_name_1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__type_mapping_err__not_defined_subtype_name_1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     databaseTypeNameSign)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {databaseTypeNameSign};

  var msg_ru
   =String.Format
    ("В описании типа данных [{0}] не указано имя подтипа.",
     args);

  var msg_en
   =String.Format
    ("In datatype definition [{0}] not defined a subtype name.",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__type_mapping_err__not_defined_subtype_name_1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__type_mapping_err__unknown_blob_subtype_1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     databaseTypeNameSign)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {databaseTypeNameSign};

  var msg_ru
   =String.Format
    ("Неизвестное имя подтипа блоба: [{0}].",
     args);

  var msg_en
   =String.Format
    ("Unknown name of BLOB subtype: [{0}].",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__type_mapping_err__unknown_blob_subtype_1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__type_mapping_err__definition_of_blob_charset_allowed_only_for_subtype_text_0
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
     {};

  var msg_ru
   =String.Format
    ("Указание кодовой страницы BLOB допускается только для подтипа TEXT.",
     args);

  var msg_en
   =String.Format
    ("Definition of BLOB charset allowed only for subtype TEXT.",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__type_mapping_err__definition_of_blob_charset_allowed_only_for_subtype_text_0

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__type_mapping_err__failed_to_parse_datatype_length_1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     databaseTypeNameSign)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {databaseTypeNameSign};

  var msg_ru
   =String.Format
    ("Ошибка обработки длины типа данных [{0}].",
     args);

  var msg_en
   =String.Format
    ("Failed to parse length of datatype [{0}].",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__type_mapping_err__failed_to_parse_datatype_length_1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__type_mapping_err__failed_to_parse_datatype_precision_1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     databaseTypeNameSign)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {databaseTypeNameSign};

  var msg_ru
   =String.Format
    ("Ошибка обработки точности типа данных [{0}].",
     args);

  var msg_en
   =String.Format
    ("Failed to parse precision of datatype [{0}].",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__type_mapping_err__failed_to_parse_datatype_precision_1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__type_mapping_err__failed_to_parse_datatype_scale_1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     databaseTypeNameSign)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {databaseTypeNameSign};

  var msg_ru
   =String.Format
    ("Ошибка обработки масштаба типа данных [{0}].",
     args);

  var msg_en
   =String.Format
    ("Failed to parse scale of datatype [{0}].",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__type_mapping_err__failed_to_parse_datatype_scale_1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__type_mapping_err__too_large_length_of_datatype_1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     databaseTypeNameSign)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {databaseTypeNameSign};

  var msg_ru
   =String.Format
    ("Слишком большая длина типа данных [{0}].",
     args);

  var msg_en
   =String.Format
    ("Too large length of datatype [{0}].",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__type_mapping_err__too_large_length_of_datatype_1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__type_mapping_err__too_large_precision_of_datatype_1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     databaseTypeNameSign)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {databaseTypeNameSign};

  var msg_ru
   =String.Format
    ("Слишком большая точность типа данных [{0}].",
     args);

  var msg_en
   =String.Format
    ("Too large precision of datatype [{0}].",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__type_mapping_err__too_large_precision_of_datatype_1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__type_mapping_err__too_large_scale_of_datatype_1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     databaseTypeNameSign)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {databaseTypeNameSign};

  var msg_ru
   =String.Format
    ("Слишком большой масштаб типа данных [{0}].",
     args);

  var msg_en
   =String.Format
    ("Too large scale of datatype [{0}].",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__type_mapping_err__too_large_scale_of_datatype_1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__local_eval_err__member_not_supported_2
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     Type                       objectType,
                     string                     memberName)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new string[]
    {
     objectType.FullName,
     memberName
    };

  var msg_ru=String.Format
   ("Локальное вычисление свойства [{0}].[{1}] не поддерживается.",
    args);

  var msg_en=String.Format
   ("Local evaluation of member [{0}].[{1}] not supported.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.DB_E_NOTSUPPORTED);
 }//CheckErrorRecord__local_eval_err__member_not_supported_2

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__local_eval_err__unary_operator_not_supported_1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     ExpressionType             nodeType)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new string[]
    {
     nodeType.ToString()
    };

  var msg_ru=String.Format
   ("Локальное вычисление унарной операции [{0}] не поддерживается.",
    args);

  var msg_en=String.Format
   ("Local evaluation of unary operation [{0}] not supported.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.DB_E_NOTSUPPORTED);
 }//CheckErrorRecord__local_eval_err__unary_operator_not_supported_1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__local_eval_err__unary_operator_not_supported_2
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     ExpressionType             nodeType,
                     Type                       opType)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new string[]
    {
     nodeType.ToString(),
     opType.FullName
    };

  var msg_ru=String.Format
   ("Локальное вычисление унарной операции [{0}] не поддерживается. Связанное значение имеет тип [{1}].",
    args);

  var msg_en=String.Format
   ("Local evaluation of unary operation [{0}] not supported. Linked value has type [{1}].",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.DB_E_NOTSUPPORTED);
 }//CheckErrorRecord__local_eval_err__unary_operator_not_supported_1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__local_eval_err__binary_operator_not_supported_3
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     ExpressionType             nodeType,
                     Type                       leftType,
                     Type                       rightType)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new string[]
    {
     nodeType.ToString(),
     leftType.FullName,
     rightType.FullName,
    };

  var msg_ru=String.Format
   ("Локальное вычисление бинарной операции [{0}] не поддерживается. Левый аргумент: [тип: {1}]. Правый аргумент: [тип: {2}].",
    args);

  var msg_en=String.Format
   ("Local evaluation of binary operation [{0}] not supported. Left argument: [type: {1}]. Right argument: [type: {2}].",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.DB_E_NOTSUPPORTED);
 }//CheckErrorRecord__local_eval_err__binary_operator_not_supported_3

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__local_eval_err__binary_operator_not_supported_3
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     ExpressionType             nodeType,
                     string                     leftTypeSign,
                     string                     rightTypeSign)
 {
  Assert.NotNull
   (err_rec);

  var args=new string[]
   {
    nodeType.ToString(),
    leftTypeSign,
    rightTypeSign,
   };

  var msg_ru=String.Format
   ("Локальное вычисление бинарной операции [{0}] не поддерживается. Левый аргумент: [тип: {1}]. Правый аргумент: [тип: {2}].",
    args);

  var msg_en=String.Format
   ("Local evaluation of binary operation [{0}] not supported. Left argument: [type: {1}]. Right argument: [type: {2}].",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.DB_E_NOTSUPPORTED);
 }//CheckErrorRecord__local_eval_err__binary_operator_not_supported_3

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__local_eval_err__binary_operator_not_supported_3
                    (structure_lib.IErrorRecord        err_rec,
                     string                            srcID,
                     xEFCore.LcpiOleDb__ExpressionType nodeType,
                     string                            leftTypeSign,
                     string                            rightTypeSign)
 {
  Assert.NotNull
   (err_rec);

  var args=new string[]
   {
    nodeType.ToString(),
    leftTypeSign,
    rightTypeSign,
   };

  var msg_ru=String.Format
   ("Локальное вычисление бинарной операции [{0}] не поддерживается. Левый аргумент: [тип: {1}]. Правый аргумент: [тип: {2}].",
    args);

  var msg_en=String.Format
   ("Local evaluation of binary operation [{0}] not supported. Left argument: [type: {1}]. Right argument: [type: {2}].",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.DB_E_NOTSUPPORTED);
 }//CheckErrorRecord__local_eval_err__binary_operator_not_supported_3

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__local_eval_err__method_not_supported_1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     methodSign)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new string[]
    {
     methodSign
    };

  var msg_ru=String.Format
   ("Локальное вычисление метода [{0}] не поддерживается.",
    args);

  var msg_en=String.Format
   ("Local evaluation of method [{0}] not supported.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.DB_E_NOTSUPPORTED);
 }//CheckErrorRecord__local_eval_err__method_not_supported_1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__local_eval_err__unexpected_result_type_of_logical_expression_1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     Type                       resultType)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new string[]
    {
     resultType.FullName
    };

  var msg_ru=String.Format
   ("Неожиданный тип результата логического выражения: {0}.",
    args);

  var msg_en=String.Format
   ("Unexpected result type of logical expression: {0}.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__local_eval_err__unexpected_result_type_of_logical_expression_1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__local_eval_err__cant_remap_static_method_2
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     methodSign,
                     string                     newArgs)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new string[]
    {
     methodSign,
     newArgs
    };

  var msg_ru=String.Format
   ("Невозможно переназначить метод [{0}] на метод с аргументами [{1}].",
    args);

  var msg_en=String.Format
   ("Can't remap method [{0}] to method with arguments [{1}].",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__local_eval_err__cant_remap_static_method_2

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__local_eval_err__cant_remap_instance_method_2
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     methodSign,
                     string                     newObjectSign,
                     string                     newArgs)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new string[]
    {
     methodSign,
     newObjectSign,
     newArgs
    };

  var msg_ru=String.Format
   ("Невозможно переназначить метод [{0}] на метод класса [{1}] с аргументами [{2}].",
    args);

  var msg_en=String.Format
   ("Can't remap method [{0}] to method of class [{1}] with arguments [{2}].",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__local_eval_err__cant_remap_instance_method_2

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__local_eval_err__ambiguous_remap_method_3
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     methodSign,
                     string                     newArgs,
                     string                     variants)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new string[]
    {
     methodSign,
     newArgs,
     variants
    };

  var msg_ru=String.Format
   ("Неоднозначный выбор переназначений метода [{0}] для новых аргументов [{1}]. Возможные варианты:{2}.",
    args);

  var msg_en=String.Format
   ("Ambiguous selection of method remapping [{0}] for new arguments [{1}]. Possible options:{2}.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__local_eval_err__ambiguous_remap_method_3

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__local_eval_err__cant_remap_object_construction_3
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     originalTypeSign,
                     string                     mappedTypeSign,
                     string                     mappedArgs)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new string[]
    {
     originalTypeSign,
     mappedTypeSign,
     mappedArgs
    };

  var msg_ru=String.Format
   ("Не удалось преобразовать создание объекта с типом [{0}] в создание объекта с типом [{1}]. Не найден конструктор с параметрами [{2}].",
    args);

  var msg_en=String.Format
   ("Can't transform creation of object with type [{0}] to creation of object with type [{1}]. Constructor with arguments [{2}] not found.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__local_eval_err__cant_remap_object_construction_3

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__local_eval_err__comparison_of_arrays_with_different_length_not_supported_2
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     int                        length1,
                     int                        length2)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
     length1,
     length2,
    };

  var msg_ru
   =String.Format
    ("Локальное сравнение линейных массивов с разной длиной не поддерживается. Длина первого массива: {0}. Длина второго массива: {1}.",
     args);

  var msg_en
   =String.Format
    ("Local comparison of linear arrays with different length not supported. First array length: {0}. Second array length: {1}.",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__local_eval_err__comparison_of_arrays_with_different_length_not_supported_2

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__local_eval_err__failed_to_compare_element_of_arrays_1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     int[]                      elementIndex)
 {
  Assert.NotNull
   (err_rec);

  Debug.Assert(!Object.ReferenceEquals(elementIndex,null));
  Debug.Assert(elementIndex.Length>0);

  var args
   =new object[]
    {
     string.Join(", ",elementIndex)
    };

  var msg_ru
   =String.Format
    ("Ошибка сравнения элемента [{0}] массивов.",
     args);

  var msg_en
   =String.Format
    ("Failed to compare element [{0}] of arrays.",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__local_eval_err__failed_to_compare_element_of_arrays_1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__local_eval_err__cant_convert_array_element_value_to_required_type_3
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     int[]                      elementIndex,
                     string                     elementValueTypeSign,
                     string                     expectedTypeSign)
 {
  Assert.NotNull
   (err_rec);

  Debug.Assert(!Object.ReferenceEquals(elementIndex,null));
  Debug.Assert(elementIndex.Length>0);

  var args
   =new object[]
    {
     string.Join(", ",elementIndex),
     elementValueTypeSign,
     expectedTypeSign,
    };

  var msg_ru
   =String.Format
    ("Ошибка приведения значения элемента массива [индекс: {0}] с типом [{1}] к типу [{2}].",
     args);

  var msg_en
   =String.Format
    ("Failed to convert array element value [index: {0}] with type [{1}] to type [{2}].",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.DB_E_UNSUPPORTEDCONVERSION);
 }//CheckErrorRecord__local_eval_err__cant_convert_array_element_value_to_required_type_3

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__common_err__unk_column_name__2
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     tableName,
                     string                     columnName)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new string[]
    {
     tableName,
     columnName,
    };

  var msg_ru=String.Format
   ("Таблица [{0}] не содержит колонку с именем [{1}].",
    args);

  var msg_en=String.Format
   ("Table [{0}] not contains the column with name [{1}].",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__common_err__unk_column_name__2

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__common_err__invalid_column_value__4
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     tableName,
                     int                        columnIndex,
                     string                     columnName,
                     string                     columnValueSign)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
     tableName,
     columnIndex,
     columnName,
     columnValueSign
    };

  var msg_ru=String.Format
   ("Недопустимое значение колонки [индекс: {1}][имя: {2}] таблицы [{0}]: {3}.",
    args);

  var msg_en=String.Format
   ("Invalid value of column [index: {1}][name: {2}] of table [{0}]: {3}.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__common_err__invalid_column_value__4

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__common_err__invalid_column_value_type__5
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     tableName,
                     int                        columnIndex,
                     string                     columnName,
                     Type                       columnType,
                     Type                       extectedType)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
     tableName,
     columnIndex,
     columnName,
     columnType.FullName,
     extectedType.FullName,
    };

  var msg_ru=String.Format
   ("Недопустимый тип значения колонки [индекс: {1}][имя: {2}] таблицы [{0}]: {3}. Ожидалось значение с типом: {4}.",
    args);

  var msg_en=String.Format
   ("Invalid value type in column [index: {1}][name: {2}] of table [{0}]: {3}. Expected to value with type: {4}.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__common_err__invalid_column_value__4

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__common_err__failed_to_process_value_1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     valueName)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
     valueName
    };

  var msg_ru=String.Format
   ("Ошибка обработки значения [{0}].",
    args);

  var msg_en=String.Format
   ("Failed to process value [{0}].",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__common_err__failed_to_process_value_1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__common_err__unknown_annotation__1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     annotationName)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
     annotationName,
    };

  var msg_ru=String.Format
   ("Неизвестная аннотация [{0}].",
    args);

  var msg_en=String.Format
   ("Unknown annotation [{0}].",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__common_err__unknown_annotation__1

 public static void CheckErrorRecord__common_err__annotation_has_value_with_unexpected_type__3
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     annotationName,
                     string                     actualTypeSign,
                     string                     expectedTypeSign)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
     annotationName,
     actualTypeSign,
     expectedTypeSign
    };

  var msg_ru=String.Format
   ("Аннотация [{0}] имеет значение с неизвестным типом: [{1}]. Ожидаемый тип: [{2}].",
    args);

  var msg_en=String.Format
   ("Annotation [{0}] has value with unexpected type: [{1}]. Expected type: [{2}].",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__common_err__annotation_has_value_with_unexpected_type__3

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__common_err__multiple_definition_of_annotation__3
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     annotationName,
                     string                     prevValueSign,
                     string                     newValueSign)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
     annotationName,
     prevValueSign,
     newValueSign
    };

  var msg_ru=String.Format
   ("Аннотация [{0}] уже определена со значением [{1}]. Новое значение: [{2}].",
    args);

  var msg_en=String.Format
   ("Annotation [{0}] already defined with value [{1}]. New value: [{2}].",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__common_err__multiple_definition_of_annotation__3

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__common_err__annotation_has_unknown_value__2
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     annotationName,
                     string                     valueSign)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
     annotationName,
     valueSign
    };

  var msg_ru=String.Format
   ("Аннотация [{0}] имеет неизвестное значение: [{1}].",
    args);

  var msg_en=String.Format
   ("Annotation [{0}] has unknown value: [{1}].",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__common_err__annotation_has_unknown_value__2

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__common_err__annotation_has_null_value__1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     annotationName)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
     annotationName
    };

  var msg_ru=String.Format
   ("Аннотация [{0}] имеет null-значение.",
    args);

  var msg_en=String.Format
   ("Annotation [{0}] has null value.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__common_err__annotation_has_null_value__1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__common_err__model_defines_incorrect_global_value_generation_strategy__1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     strategySign)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
     strategySign
    };

  var msg_ru=String.Format
   ("Модель определяет некорректную глобальную стратегию генерации значений [{0}].",
    args);

  var msg_en=String.Format
   ("Model defines incorrect global value generation strategy [{0}].",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__common_err__model_defines_incorrect_global_value_generation_strategy__1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__common_err__property_with_datatype_is_not_compatible_with_value_generation_strategy__4
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     strategySign,
                     string                     declaringClrTypeSign,
                     string                     propertyName,
                     string                     propertyClrDataTypeSign)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
     strategySign,
     declaringClrTypeSign,
     propertyName,
     propertyClrDataTypeSign
    };

  var msg_ru=String.Format
   ("Свойство [{2}] с типом данных [{3}] несовместимо со стратегией генерации значений [{0}]. Свойство определено в типе {1}.",
    args);

  var msg_en=String.Format
   ("Property [{2}] with datatype [{3}] is not compatible with value generation strategy [{0}]. Property declared in type {1}.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__common_err__property_with_datatype_is_not_compatible_with_value_generation_strategy__4

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__common_err__value_generation_strategy_cant_be_defined_at_model_level__1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     strategySign)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
     strategySign
    };

  var msg_ru=String.Format
   ("Стратегия генерации значений [{0}] не может быть определена на уровне модели данных.",
    args);

  var msg_en=String.Format
   ("Value generation strategy [{0}] can't be defined at data model level.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__common_err__value_generation_strategy_cant_be_defined_at_model_level__1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__common_err__entity_property_has_conflict_of_value_generation_strategies__4
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     entitySign,
                     string                     propertyName,
                     string                     firstVGS,
                     string                     secondVGS)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
     entitySign,
     propertyName,
     firstVGS,
     secondVGS
    };

  var msg_ru=String.Format
   ("Свойство [{1}] cущности (entity) [{0}] определяет конфликтующие стратегии генерации значения: [{2}] и [{3}].",
    args);

  var msg_en=String.Format
   ("Both the value generation strategy [{2}] and [{3}] have been set on property [{1}] of entity type [{0}].",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__common_err__entity_property_has_conflict_of_value_generation_strategies__4

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__common_err__feature_not_supported__1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     featureName)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
     featureName
    };

  var msg_ru=String.Format
   ("Функциональность [{0}] не поддерживается.",
    args);

  var msg_en=String.Format
   ("Feature [{0}] not supported.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.DB_E_NOTSUPPORTED);
 }//CheckErrorRecord__common_err__feature_not_supported__1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__validation_err__failed_to_entity_validation_1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     entityName)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
     entityName
    };

  var msg_ru=String.Format
   ("Ошибка проверки cущности (entity) [{0}].",
    args);

  var msg_en=String.Format
   ("Failed to validate entity [{0}].",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__validation_err__failed_to_entity_validation_1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__validation_err__failed_to_entity_property_validation_2
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     entityName,
                     string                     propertyName)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
     entityName,
     propertyName
    };

  var msg_ru=String.Format
   ("Ошибка проверки свойства cущности (entity) [{0}]::[{1}].",
    args);

  var msg_en=String.Format
   ("Failed to validate entity property [{0}]::[{1}].",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__validation_err__failed_to_entity_property_validation_2

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__cs_utf16_err__bad_sequence__2
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     checkPoint,
                     int                        offset)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
     checkPoint,
     offset,
    };//args

  var msg_ru=String.Format
   ("Некорректная последовательность UTF-16 символов. Смещение [{1}]. Точка проверки [{0}].",
    args);

  var msg_en=String.Format
   ("Bad UTF-16 symbols sequential. Offset [{1}]. Check point [{0}].",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__cs_utf16_err__bad_sequence__2

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__sql_translator_err__method_not_supported_1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     methodSign)
 {
  Assert.IsNotNull
   (err_rec);

  var args
   =new object[]
    {
     methodSign,
    };

  var msg_ru=String.Format
   ("Ошибка трансляции в SQL. Метод {0} не поддерживается.",
    args);

  var msg_en=String.Format
   ("Failed translation to SQL. Method {0} not supported.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.DB_E_NOTSUPPORTED);
 }//CheckErrorRecord__sql_translator_err__method_not_supported_1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__sql_translator_err__member_not_supported_2
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     objectTypeSign,
                     string                     memberName)
 {
  Assert.IsNotNull
   (err_rec);

  var args
   =new object[]
    {
     objectTypeSign,
     memberName,
    };

  var msg_ru=String.Format
   ("Ошибка трансляции в SQL. Свойство [{0}].[{1}] не поддерживается.",
    args);

  var msg_en=String.Format
   ("Failed translation to SQL. Member [{0}].[{1}] not supported.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.DB_E_NOTSUPPORTED);
 }//CheckErrorRecord__sql_translator_err__member_not_supported_2

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__sql_translator_err__unsupported_binary_operator_type_1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     ExpressionType             operatorType)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
     operatorType,
    };

  var msg_ru=String.Format
   ("Ошибка трансляции в SQL. Неподдерживаемый тип бинарной операции: {0}.",
    args);

  var msg_en=String.Format
   ("Failed translation to SQL. Unsupported binary operation type: {0}.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.DB_E_NOTSUPPORTED);
 }//CheckErrorRecord__sql_translator_err__unsupported_binary_operator_type_1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__sql_translator_err__unsupported_binary_operator_type_3
                    (structure_lib.IErrorRecord        err_rec,
                     string                            srcID,
                     xEFCore.LcpiOleDb__ExpressionType operatorType,
                     System.Type                       leftType,
                     System.Type                       rightType)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
     operatorType,
     leftType,
     rightType,
    };

  var msg_ru=String.Format
   ("Ошибка трансляции в SQL. Неподдерживаемый тип бинарной операции: {0}. Тип левого аргумента: {1}. Тип правого аргумента: {2}.",
    args);

  var msg_en=String.Format
   ("Failed translation to SQL. Unsupported binary operation type: {0}. Left argument type: {1}. Right argument type: {2}.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.DB_E_NOTSUPPORTED);
 }//CheckErrorRecord__sql_translator_err__unsupported_binary_operator_type_3

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__sql_translator_err__unsupported_binary_operator_type_3
                    (structure_lib.IErrorRecord        err_rec,
                     string                            srcID,
                     xEFCore.LcpiOleDb__ExpressionType operatorType,
                     string                            leftTypeSign,
                     string                            rightTypeSign)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
     operatorType,
     leftTypeSign,
     rightTypeSign,
    };

  var msg_ru=String.Format
   ("Ошибка трансляции в SQL. Неподдерживаемый тип бинарной операции: {0}. Тип левого аргумента: {1}. Тип правого аргумента: {2}.",
    args);

  var msg_en=String.Format
   ("Failed translation to SQL. Unsupported binary operation type: {0}. Left argument type: {1}. Right argument type: {2}.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.DB_E_NOTSUPPORTED);
 }//CheckErrorRecord__sql_translator_err__unsupported_binary_operator_type_3

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__sql_translator_err__unsupported_unary_operator_type_1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     ExpressionType             operatorType)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
     operatorType,
    };

  var msg_ru=String.Format
   ("Ошибка трансляции в SQL. Неподдерживаемый тип унарной операции: {0}.",
    args);

  var msg_en=String.Format
   ("Failed translation to SQL. Unsupported unary operation type: {0}.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.DB_E_NOTSUPPORTED);
 }//CheckErrorRecord__sql_translator_err__unsupported_unary_operator_type_1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__sql_translator_err__unsupported_unary_operator_type_1
                    (structure_lib.IErrorRecord        err_rec,
                     string                            srcID,
                     xEFCore.LcpiOleDb__ExpressionType operatorType)
 {
  Assert.NotNull
   (err_rec);

  var args=new object[]
   {
    operatorType,
   };

  var msg_ru=String.Format
   ("Ошибка трансляции в SQL. Неподдерживаемый тип унарной операции: {0}.",
    args);

  var msg_en=String.Format
   ("Failed translation to SQL. Unsupported unary operation type: {0}.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.DB_E_NOTSUPPORTED);
 }//CheckErrorRecord__sql_translator_err__unsupported_unary_operator_type_1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__sql_translator_err__unsupported_unary_operator_type_3
                    (structure_lib.IErrorRecord        err_rec,
                     string                            srcID,
                     xEFCore.LcpiOleDb__ExpressionType operatorType,
                     System.Type                       argumentType,
                     System.Type                       resultType)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
     operatorType,
     argumentType,
     resultType,
    };

  var msg_ru=String.Format
   ("Ошибка трансляции в SQL. Неподдерживаемый тип унарной операции: {0}. Тип аргумента: {1}. Тип результата: {2}.",
    args);

  var msg_en=String.Format
   ("Failed translation to SQL. Unsupported unary operation type: {0}. Argument type: {1}. Result type: {2}.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.DB_E_NOTSUPPORTED);
 }//CheckErrorRecord__sql_translator_err__unsupported_unary_operator_type_3

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__sql_translator_err__cant_present_unary_operation_as_SqlUnaryExpression_3
                    (structure_lib.IErrorRecord        err_rec,
                     string                            srcID,
                     xEFCore.LcpiOleDb__ExpressionType operationID,
                     string                            argumentTypeSign,
                     string                            resultTypeSign)
 {
  Assert.IsNotNull
   (err_rec);

  var args=new object[]
   {
    operationID,
    argumentTypeSign,
    resultTypeSign,
   };

  var msg_ru=String.Format
   ("SQL-трансляция унарной операции [{0}][аргумент: {1}][результат: {2}] поддерживается, но не может быть представлена в виде класса SqlUnaryExpression.",
    args);

  var msg_en=String.Format
   ("SQL-translation of unary operation [{0}][operand: {1}][result: {2}] is supported, but can't be present as SqlUnaryExpression class.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__sql_translator_err__cant_present_unary_operation_as_SqlUnaryExpression_3

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__sql_translator_err__cant_present_binary_operation_as_SqlBinaryExpression_3
                    (structure_lib.IErrorRecord        err_rec,
                     string                            srcID,
                     xEFCore.LcpiOleDb__ExpressionType operationID,
                     string                            leftTypeSign,
                     string                            rightTypeSign)
 {
  Assert.IsNotNull
   (err_rec);

  var args=new object[]
   {
    operationID,
    leftTypeSign,
    rightTypeSign,
   };

  var msg_ru=String.Format
   ("SQL-трансляция бинарной операции [{0}][left: {1}][right: {2}] поддерживается, но не может быть представлена в виде класса SqlBinaryExpression.",
    args);

  var msg_en=String.Format
   ("SQL-translation of binary operation [{0}][left: {1}][right: {2}] is supported, but can't be present as SqlBinaryExpression class.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__sql_translator_err__cant_present_binary_operation_as_SqlBinaryExpression_3

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__sql_translator_err__cant_present_function_as_SqlFunctionExpression_1
                    (structure_lib.IErrorRecord        err_rec,
                     string                            srcID,
                     string                            functionName)
 {
  Assert.IsNotNull
   (err_rec);

  var args=new object[]
   {
    functionName,
   };

  var msg_ru=String.Format
   ("SQL-трансляция функции [{0}] поддерживается, но не может быть представлена в виде класса SqlFunctionExpression.",
    args);

  var msg_en=String.Format
   ("SQL-translation of function [{0}] is supported, but can't be present as SqlFunctionExpression class.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__sql_translator_err__cant_present_binary_operation_as_SqlBinaryExpression_3

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__sql_gen_err__unsupported_cast_as_between_types_2
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     sourceTypeSign,
                     string                     targetTypeSign)
 {
  Assert.NotNull
   (err_rec);

  var args=new object[]
   {
    sourceTypeSign,
    targetTypeSign,
   };

  var msg_ru=String.Format
   ("Генерация SQL-оператора \"CAST AS\" для преобразования типа [{0}] в тип [{1}] не поддерживается.",
    args);

  var msg_en=String.Format
   ("Generation of SQL-operator \"CAST AS\" for conversion from type [{0}] to type [{1}] is not supported.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.DB_E_UNSUPPORTEDCONVERSION);
 }//CheckErrorRecord__sql_gen_err__unsupported_cast_as_between_types_2

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__sql_gen_err__translation_of_member_not_supported_in_current_cn_dialect_2
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     int                        cnDialect,
                     string                     methodSign)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
     cnDialect,
     methodSign,
    };

  var msg_ru=String.Format
   ("SQL-трансляция конструкции [{1}] не поддерживается текущим диалектом подключения [{0}] к базе данных.",
    args);

  var msg_en=String.Format
   ("SQL-translation of member [{1}] not supported by current database connection dialect [{0}].",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.DB_E_NOTSUPPORTED);
 }//CheckErrorRecord__sql_gen_err__translation_of_member_not_supported_in_current_cn_dialect_2

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__sql_gen_err__decimal_precision_not_supported_in_current_cn_dialect_3
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     int                        cnDialect,
                     string                     sqlTypeName,
                     int                        precision)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
     cnDialect,
     sqlTypeName,
     precision
    };

  var msg_ru=String.Format
   ("Точность [{2}] SQL типа данных [{1}] не поддерживается текущим диалектом подключения [{0}] к базе данных.",
    args);

  var msg_en=String.Format
   ("Precision [{2}] of SQL data type [{1}] not supported by current database connection dialect [{0}].",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.DB_E_NOTSUPPORTED);
 }//CheckErrorRecord__sql_gen_err__decimal_precision_not_supported_in_current_cn_dialect_3

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__sql_gen_err__definition_of_value_in_sql_not_supported__1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     sqlTypeName)
 {
  Assert.NotNull
   (err_rec);

  var args=new object[]
   {
    sqlTypeName
   };

  var msg_ru=String.Format
   ("Передача значения с типом [{0}] в тексте SQL запроса не поддерживается. Попробуйте передать это значение через параметр.",
    args);

  var msg_en=String.Format
   ("Pass of value with type [{0}] as text in SQL is not supported. Try to pass this value through parameter.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.DB_E_NOTSUPPORTED);
 }//CheckErrorRecord__sql_gen_err__definition_of_value_in_sql_not_supported__1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__sql_gen_err__not_supported_sql_operator__1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     sqlOperatorSign)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
     sqlOperatorSign
    };

  var msg_ru
   =String.Format
    ("Трансляция этого запроса требует SQL-оператор [{0}], который не поддерживается.",
     args);

  var msg_en
   =String.Format
    ("Translating this query requires the SQL-operation [{0}], which is not supported.",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.DB_E_NOTSUPPORTED);
 }//CheckErrorRecord__sql_gen_err__not_supported_sql_operator__1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__msql_gen_err__computed_column_not_supported__0
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
    };

  var msg_ru=String.Format
   ("Генерация SQL для вычисляемого столбца не поддерживается.",
    args);

  var msg_en=String.Format
   ("Generation of SQL for computed column isn't supported.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.DB_E_NOTSUPPORTED);
 }//CheckErrorRecord__msql_gen_err__computed_column_not_supported__0

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__msql_gen_err__cant_find_type_mapping_for_column__2
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     tableName,
                     string                     columnName)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
     {
      tableName,
      columnName
     };

  var msg_ru
   =String.Format
    ("Не найдено описание типа (TypeMapping) для колонки [{0}][{1}].",
     args);

  var msg_en
   =String.Format
    ("Can't find type description (TypeMapping) for column [{0}][{1}].",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__msql_gen_err__cant_find_type_mapping_for_column__2

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__msql_gen_err__cant_find_type_mapping_for_default_value__1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     defaultValueClrTypeSign)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
     {
      defaultValueClrTypeSign
     };

  var msg_ru
   =String.Format
    ("Не найдено описание типа (TypeMapping) для значения по умолчанию с CLR-типом [{0}].",
     args);

  var msg_en
   =String.Format
    ("Can't find type description (TypeMapping) for default value with CLR-type [{0}].",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__msql_gen_err__cant_find_type_mapping_for_default_value__1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__msql_gen_err__failed_to_generate_table_definition__1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     tableName)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
     tableName
    };

  var msg_ru
   =String.Format
    ("Ошибка генерации определения таблицы [{0}].",
     args);

  var msg_en
   =String.Format
    ("Failed to generate a definition of table [{0}].",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__msql_gen_err__failed_to_generate_table_definition__1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__msql_gen_err__failed_to_generate_column_definition__2
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     tableName,
                     string                     columnName)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
     tableName,
     columnName
    };

  var msg_ru
   =String.Format
    ("Ошибка генерации определения колонки [{0}][{1}].",
     args);

  var msg_en
   =String.Format
    ("Failed to generate a definition of column [{0}][{1}].",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__msql_gen_err__failed_to_generate_column_definition__2

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__msql_gen_err__detected_multiple_definition_of_default_value__0
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
    };

  var msg_ru
   =String.Format
    ("Указано несколько вариантов с определением значения по умолчанию. Используйте только один.",
     args);

  var msg_en
   =String.Format
    ("Detected multiple variants with definition of default value. Please use only one option.",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__msql_gen_err__detected_multiple_definition_of_default_value__0

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__msql_gen_err__identity_column_cant_be_created_with_required_data_type__2
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     clrTypeSign,
                     string                     sqlTypeSign)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
     clrTypeSign,
     sqlTypeSign
    };

  var msg_ru
   =String.Format
    ("Недопустимый тип данных IDENTITY-колонки [clrType: {0}][sqlType: {1}].",
     args);

  var msg_en
   =String.Format
    ("Invalid IDENTITY-column datatype [clrType: {0}][sqlType: {1}].",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__msql_gen_err__identity_column_cant_be_created_with_required_data_type__2

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__msql_gen_err__identity_column_cant_be_has_default_value__0
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
    };

  var msg_ru
   =String.Format
    ("Недопускается указание DEFAULT значения у IDENTITY-колонки.",
     args);

  var msg_en
   =String.Format
    ("It is not allowed to specify a DEFAULT value for an IDENTITY-column.",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__msql_gen_err__identity_column_cant_be_has_default_value__0

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__msql_gen_err__identity_column_cant_be_nullable__0
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
    };

  var msg_ru
   =String.Format
    ("IDENTITY-колонка не может быть nullable.",
     args);

  var msg_en
   =String.Format
    ("IDENTITY-column can't be nullable.",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__msql_gen_err__identity_column_cant_be_nullable__0

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__msql_gen_err__failed_to_generate_fk_definition__3
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     tableName,
                     string                     fkName,
                     string                     principalTableName)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new string[]
    {
     tableName,
     fkName,
     principalTableName
    };

  var msg_ru
   =String.Format
    ("Ошибка генерации определения внешнего ключа [таблица: {0}][fk: {1}][внешняя таблица: {2}].",
     args);

  var msg_en
   =String.Format
    ("Failed to generate a definition of foreign key [table: {0}][fk: {1}][foreign table: {2}].",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__msql_gen_err__failed_to_generate_fk_definition__3

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__msql_gen_err__bad_fk_definition__different_size_of_column_lists__2
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     int                        cColumns,
                     int                        cPrincipalColumns)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
     cColumns,
     cPrincipalColumns,
    };

  var msg_ru
   =String.Format
    ("Разное число колонок в списках определения внешнего ключа: {0} и {1}.",
     args);

  var msg_en
   =String.Format
    ("Different column count in lists of foreign key definition: {0} and {1}.",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__msql_gen_err__bad_fk_definition__different_size_of_column_lists__2

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__msql_gen_err__unknown_fk_referential_action__1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     actionSign)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new string[]
    {
     actionSign
    };

  var msg_ru
   =String.Format
    ("Неизвестный идентификатор ссылочного правила внешнего ключа: {0}.",
     args);

  var msg_en
   =String.Format
    ("Unknown identifier of foreign key referential action: {0}.",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__msql_gen_err__unknown_fk_referential_action__1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__msql_gen_err__failed_to_generate_create_sequence_statement__1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     seqName)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new string[]
    {
     seqName
    };

  var msg_ru
   =String.Format
    ("Ошибка генерации запроса CREATE SEQUENCE [{0}].",
     args);

  var msg_en
   =String.Format
    ("Failed to generate CREATE SEQUENCE [{0}] statement.",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__msql_gen_err__failed_to_generate_create_sequence_statement__1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__msql_gen_err__failed_to_generate_restart_sequence_statement__1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     seqName)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new string[]
    {
     seqName
    };

  var msg_ru
   =String.Format
    ("Ошибка генерации запроса ALTER SEQUENCE [{0}] RESTART.",
     args);

  var msg_en
   =String.Format
    ("Failed to generate ALTER SEQUENCE [{0}] RESTART statement.",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__msql_gen_err__failed_to_generate_restart_sequence_statement__1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__msql_gen_err__failed_to_generate_alter_sequence_statement__1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     seqName)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new string[]
    {
     seqName
    };

  var msg_ru
   =String.Format
    ("Ошибка генерации запроса ALTER SEQUENCE [{0}].",
     args);

  var msg_en
   =String.Format
    ("Failed to generate ALTER SEQUENCE [{0}] statement.",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__msql_gen_err__failed_to_generate_alter_sequence_statement__1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__msql_gen_err__overflow_in_calculation_of_adjusted_sequence_start_value__3
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     seqName,
                     long                       startValue,
                     int                        incrementBy)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
     seqName,
     startValue,
     incrementBy,
    };

  var msg_ru
   =String.Format
    ("Переполнение в процессе вычисления откорректированного начального значения SEQUENCE [{0}]. Пользовательские данные - [startValue: {1}][incrementBy: {2}].",
     args);

  var msg_en
   =String.Format
    ("Overflow when calculating the adjusted SEQUENCE [{0}] initial value. User data - [startValue: {1}][incrementBy: {2}].",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__msql_gen_err__overflow_in_calculation_of_adjusted_sequence_start_value__3

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__msql_gen_err__firebird_does_not_support_non_cyclic_sequence__1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     seqName)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new string[]
    {
     seqName,
    };

  var msg_ru
   =String.Format
    ("Firebird не поддерживает последовательности значений (SEQUENCE) с контролем зацикливания. Установите в определении последовательности [{0}] значение свойства IsCyclic равным true.",
     args);

  var msg_en
   =String.Format
    ("Firebird does not support sequence with control of cycling. Setup in definition of sequence [{0}] a value of property IsCyclic equal to true.",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.DB_E_NOTSUPPORTED);
 }//CheckErrorRecord__msql_gen_err__firebird_does_not_support_non_cyclic_sequence__1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__msql_gen_err__firebird_does_not_support_configuration_of_sequence_bound_value__3
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     boundName,
                     string                     seqName,
                     long                       allowedValue)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
     boundName,
     seqName,
     allowedValue
    };

  var msg_ru
   =String.Format
    ("Firebird не поддерживает конфигурирование свойства {0} у последовательнсти значений (SEQUENCE). Установите в определении последовательности [{1}] значение свойства {0} равным NULL или {2}.",
     args);

  var msg_en
   =String.Format
    ("Firebird does not support configuration of sequence property {0}. Setup in definition of sequence [{1}] a value of property {0} equal to NULL or {2}.",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.DB_E_NOTSUPPORTED);
 }//CheckErrorRecord__msql_gen_err__firebird_does_not_support_configuration_of_sequence_bound_value__3

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__msql_gen_err__unexpected_sequence_ClrType__3
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     seqName,
                     string                     actualSeqClrType,
                     string                     expectedSeqClrType)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new string[]
    {
     seqName,
     actualSeqClrType,
     expectedSeqClrType
    };

  var msg_ru
   =String.Format
    ("Недопустимый clr тип последовательности (sequence) [{0}]: {1}. Ожидаемый clr тип: {2}.",
     args);

  var msg_en
   =String.Format
    ("Unexpected clr type of sequence [{0}]: {1}. Expected clr type: {2}.",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__msql_gen_err__unexpected_sequence_ClrType__3

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__msql_gen_err__incorrect_sequence_start_value__4
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     seqName,
                     long                       actualStartValue,
                     long                       minStartValue,
                     long                       maxStartValue)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
     seqName,
     actualStartValue,
     minStartValue,
     maxStartValue
    };

  var msg_ru
   =String.Format
    ("Недопустимое начальное значение последовательности значение (SEQUENCE) [{0}]: {1}. Минимальное значение: {2}. Максимальное значение: {3}.",
     args);

  var msg_en
   =String.Format
    ("Invalid start value of sequence [{0}]: {1}. Minimal value: {2}. Maximal value: {3}.",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__msql_gen_err__incorrect_sequence_start_value__4

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__msql_gen_err__failed_to_generate_alter_column_statement__3
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     tableName,
                     string                     newColumnName,
                     string                     oldColumnName)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new string[]
    {
     tableName,
     newColumnName,
     oldColumnName,
    };

  var msg_ru
   =String.Format
    ("Ошибка генерации запроса ALTER COLUMN [table: {0}][new column: {1}][old column: {2}].",
     args);

  var msg_en
   =String.Format
    ("Failed to generate ALTER COLUMN [table: {0}][new column: {1}][old column: {2}] statement.",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__msql_gen_err__failed_to_generate_alter_column_statement__3

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__msql_gen_err__inconsistent_table_names_in_alter_column_operation__2
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     oldDataTableName,
                     string                     newDataTableName)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
     oldDataTableName,
     newDataTableName,
    };

  var msg_ru
   =String.Format
    ("Несогласованные названия таблиц в операции ALTER COLUMN. Имя таблицы в старых данных: [{0}]. Имя таблицы в новых данных: [{1}].",
     args);

  var msg_en
   =String.Format
    ("Inconsistent table names in ALTER COLUMN operation. Old data table name: [{0}]. New data table name: [{1}].",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__msql_gen_err__inconsistent_table_names_in_alter_column_operation__2

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__msql_gen_err__failed_to_generate_table_creation_script__1
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     tableName)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new string[]
    {
     tableName,
    };

  var msg_ru
   =String.Format
    ("Ошибка генерации скрипта для создания таблицы [{0}].",
     args);

  var msg_en
   =String.Format
    ("Failed to generate script for creation of table [{0}].",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__msql_gen_err__failed_to_generate_table_creation_script__1

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__msql_gen_err__column_data_uses_incorrect_table_name__4
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     int                        columnIndex,
                     string                     columnName,
                     string                     actualTableName,
                     string                     expectedTableName)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
     columnIndex,
     columnName,
     actualTableName,
     expectedTableName,
    };

  var msg_ru
   =String.Format
    ("Некорректное имя таблицы в описании колонки [индекс: {0}][имя: {1}]: [{2}]. Ожидается имя таблицы [{3}].",
     args);

  var msg_en
   =String.Format
    ("Incorrect table name in description of column [index: {0}][name: {1}]: [{2}]. Expected table name [{3}].",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__msql_gen_err__column_data_uses_incorrect_table_name_4

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__msql_gen_err__failed_to_generate_create_index_statement__2
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     indexName,
                     string                     tableName)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new string[]
    {
     indexName,
     tableName,
    };

  var msg_ru
   =String.Format
    ("Ошибка генерации запроса CREATE INDEX [имя: {0}][таблица: {1}].",
     args);

  var msg_en
   =String.Format
    ("Failed to generate CREATE INDEX [name: {0}][table: {1}] statement.",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__msql_gen_err__failed_to_generate_create_index_statement__2

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__msql_gen_err__bad_index_definition__multiple_data__2
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     indexName,
                     string                     tableName)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new string[]
    {
     indexName,
     tableName,
    };

  var msg_ru
   =String.Format
    ("Некорректное описание индекса [имя: {0}][таблица: {1}]. Указано несколько вариантов данных для индекcации.",
     args);

  var msg_en
   =String.Format
    ("Incorrect definition of index [name: {0}][table: {1}]. Definition contains multiple variants of data for indexing.",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__msql_gen_err__bad_index_definition__multiple_data__2

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__msql_gen_err__bad_index_definition__no_data__2
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID,
                     string                     indexName,
                     string                     tableName)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new string[]
    {
     indexName,
     tableName,
    };

  var msg_ru
   =String.Format
    ("Некорректное описание индекса [имя: {0}][таблица: {1}]. Не указаны данные для индекcации.",
     args);

  var msg_en
   =String.Format
    ("Incorrect definition of index [name: {0}][table: {1}]. No data for indexing.",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__msql_gen_err__bad_index_definition__no_data__2

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__msql_gen_err__table_name_not_defined__0
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
    };

  var msg_ru
   =String.Format
    ("Не определено имя таблицы.",
     args);

  var msg_en
   =String.Format
    ("Table name not defined.",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__msql_gen_err__table_name_not_defined__0

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__schema_err__data_provider_not_support_req_restriction_2
                          (structure_lib.IErrorRecord err_rec,
                           string                     srcID,
                           string                     schemaName,
                           string                     restrictionName)
 {
  Assert.NotNull
   (err_rec);

  var args=new object[]
            {schemaName,
             restrictionName};

  var msg_ru=String.Format
   ("Провайдер данных не поддерживает ограничение [{1}] для схемы [{0}].",
    args);

  var msg_en=String.Format
   ("Data provider does not support restriction [{1}] for schema [{0}].",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__schema_err__data_provider_not_support_req_restriction_2

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__dbms_err__fb__firebird_does_not_support_drop_identity_attribute_from_column__0
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
    };

  var msg_ru
   =String.Format
    ("Firebird не поддерживает удаление атрибута IDENTITY у колонки таблицы.",
     args);

  var msg_en
   =String.Format
    ("Firebird does not support removing IDENTITY attribute from table column.",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__dbms_err__fb__firebird_does_not_support_drop_identity_attribute_from_column__0

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__dbms_err__fb__firebird_does_not_support_add_identity_attribute_to_column__0
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
    };

  var msg_ru
   =String.Format
    ("Firebird не поддерживает добавления атрибута IDENTITY к колонке таблицы.",
     args);

  var msg_en
   =String.Format
    ("Firebird does not support adding IDENTITY attribute to table column.",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__dbms_err__fb__firebird_does_not_support_add_identity_attribute_to_column__0

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__dbms_err__fb__firebird_does_not_support_renaming_of_tables__0
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
    };

  var msg_ru
   =String.Format
    ("Firebird не поддерживает переименование таблиц.",
     args);

  var msg_en
   =String.Format
    ("Firebird does not support renaming of tables.",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.DB_E_NOTSUPPORTED);
 }//CheckErrorRecord__dbms_err__fb__firebird_does_not_support_renaming_of_tables__0

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__dbms_err__fb__firebird_does_not_support_renaming_of_sequences__0
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
    };

  var msg_ru
   =String.Format
    ("Firebird не поддерживает переименование последовательностей значений (SEQUENCES).",
     args);

  var msg_en
   =String.Format
    ("Firebird does not support renaming of sequences.",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.DB_E_NOTSUPPORTED);
 }//CheckErrorRecord__dbms_err__fb__firebird_does_not_support_renaming_of_sequences__0

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__dbms_err__fb__firebird_does_not_support_renaming_of_indexes__0
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
    };

  var msg_ru
   =String.Format
    ("Firebird не поддерживает переименование индексов.",
     args);

  var msg_en
   =String.Format
    ("Firebird does not support renaming of indexes.",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.DB_E_NOTSUPPORTED);
 }//CheckErrorRecord__dbms_err__fb__firebird_does_not_support_renaming_of_indexes__0

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__dbms_err__fb__firebird_does_not_support_schemas__0
                    (structure_lib.IErrorRecord err_rec,
                     string                     srcID)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
    {
    };

  var msg_ru
   =String.Format
    ("Firebird не поддерживает схемы.",
     args);

  var msg_en
   =String.Format
    ("Firebird does not support schemas.",
     args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.DB_E_NOTSUPPORTED);
 }//CheckErrorRecord__dbms_err__fb__firebird_does_not_support_schemas__0

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__BugCheck__schema_contains_unexpected_row_count
                          (structure_lib.IErrorRecord err_rec,
                           string                     srcID,
                           string                     place,
                           string                     point,
                           string                     schemaName,
                           int                        rowCount)
 {
  Assert.NotNull
   (err_rec);

  var args=new object[]
            {place,
             point,
             schemaName,
             rowCount};

  var msg_ru=String.Format
   ("[BUG CHECK] Неожиданное количество строк в схеме [{2}]: {3}. Точка проверки: [{0}][{1}].",
    args);

  var msg_en=String.Format
   ("[BUG CHECK] Unexpected row count in schema [{2}]: {3}. Check point: [{0}][{1}].",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__BugCheck__schema_contains_unexpected_row_count

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__BugCheck__incorrect_schema_restriction_number
                          (structure_lib.IErrorRecord err_rec,
                           string                     srcID,
                           string                     place,
                           string                     point,
                           string                     schemaName,
                           string                     restrictionName,
                           int                        restrictionNumber)
 {
  Assert.NotNull
   (err_rec);

  var args=new object[]
            {place,
             point,
             schemaName,
             restrictionName,
             restrictionNumber};

  var msg_ru=String.Format
   ("[BUG CHECK] Некорректный номер ограничения [{3}] схемы метаданных [{2}]: {4}. Точка проверки: [{0}][{1}].",
    args);

  var msg_en=String.Format
   ("[BUG CHECK] Incorrect number of restriction [{3}] of metadata schema [{2}]: {4}. Check point: [{0}][{1}].",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__BugCheck__incorrect_schema_restriction_number

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__BugCheck__not_empty_argument_list
                          (structure_lib.IErrorRecord     err_rec,
                           string                         srcID,
                           string                         place,
                           string                         point,
                           int                            count)
 {
  Assert.NotNull
   (err_rec);

  string reason
   =string.Format
     ("not empty argument list ({0})",
      count);

  CheckErrors.TestBugCheck_RU_EN
   (err_rec,
    srcID,
    place,
    point,
    reason,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__BugCheck__not_empty_argument_list

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__BugCheck__incorrect_call_of_method
                          (structure_lib.IErrorRecord     err_rec,
                           string                         srcID,
                           string                         place,
                           string                         point)
 {
  Assert.NotNull
   (err_rec);

  string reason
   =string.Format
     ("incorrect call of method");

  CheckErrors.TestBugCheck_RU_EN
   (err_rec,
    srcID,
    place,
    point,
    reason,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__BugCheck__incorrect_call_of_method

 //-----------------------------------------------------------------------
 // public static void CheckErrorRecord__BugCheck__array_err__unexpected_dimension_number
 //                          (structure_lib.IErrorRecord err_rec,
 //                           string                     srcID,
 //                           string                     catalog_name,
 //                           string                     schema_name,
 //                           string                     relation_name,
 //                           string                     field_name,
 //                           UInt32                     actual_dim_number,
 //                           UInt32                     expected_dim_number)
 // {
 //  Assert.NotNull
 //   (err_rec);
 //
 //  var args=new object[]
 //            {catalog_name,
 //             schema_name,
 //             relation_name,
 //             field_name,
 //             actual_dim_number,
 //             expected_dim_number};
 //
 //  var msg_ru=String.Format
 //   ("[BUG CHECK] Неожиданный номер размерности массива [{0}].[{1}].[{2}].[{3}]: {4}. "
 //    +"Ожидался номер: {5}.",
 //    args);
 //
 //  var msg_en=String.Format
 //   ("[BUG CHECK] Unexpected dimension number of array [{0}].[{1}].[{2}].[{3}]: {4}. "
 //    +"Expected number: {5}.",
 //    args);
 //
 //  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
 //   (err_rec,
 //    srcID,
 //    msg_ru,
 //    msg_en,
 //    com_lib.HResultCode.E_FAIL);
 // }//CheckErrorRecord__BugCheck__array_err__unexpected_dimension_number
 //
 //-----------------------------------------------------------------------
 // public static void CheckErrorRecord__BugCheck__array_err__bad_sort_of_schema
 //                          (structure_lib.IErrorRecord err_rec,
 //                           string                     srcID,
 //                           string                     metadata_name,
 //                           string                     prev_catalog_name,
 //                           string                     prev_schema_name,
 //                           string                     prev_relation_name,
 //                           string                     prev_field_name,
 //                           string                     cur_catalog_name,
 //                           string                     cur_schema_name,
 //                           string                     cur_relation_name,
 //                           string                     cur_field_name)
 // {
 //  Assert.NotNull
 //   (err_rec);
 //
 //  var args=new string[]
 //            {metadata_name,
 //             prev_catalog_name,
 //             prev_schema_name,
 //             prev_relation_name,
 //             prev_field_name,
 //             cur_catalog_name,
 //             cur_schema_name,
 //             cur_relation_name,
 //             cur_field_name};
 //
 //  var msg_ru=String.Format
 //   ("[BUG CHECK] Некорректная сортировка схемы [{0}]. Предыдущий элемент [{1}].[{2}].[{3}].[{4}]. Текущий элемент [{5}].[{6}].[{7}].[{8}].",
 //    args);
 //
 //  var msg_en=String.Format
 //   ("[BUG CHECK] Incorrect sort of schema [{0}]. Previous element [{1}].[{2}].[{3}].[{4}]. Current element [{5}].[{6}].[{7}].[{8}].",
 //    args);
 //
 //  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
 //   (err_rec,
 //    srcID,
 //    msg_ru,
 //    msg_en,
 //    com_lib.HResultCode.E_FAIL);
 // }//CheckErrorRecord__BugCheck__array_err__bad_sort_of_schema
 //
 //-----------------------------------------------------------------------
 // public static void CheckErrorRecord__BugCheck__array_err__bad_range
 //                          (structure_lib.IErrorRecord err_rec,
 //                           string                     srcID,
 //                           string                     catalog_name,
 //                           string                     schema_name,
 //                           string                     relation_name,
 //                           string                     field_name,
 //                           UInt32                     dimension_number,
 //                           Int32                      lower_bound,
 //                           Int32                      upper_bound)
 // {
 //  Assert.NotNull
 //   (err_rec);
 //
 //  var args=new object[]
 //            {catalog_name,
 //             schema_name,
 //             relation_name,
 //             field_name,
 //             dimension_number,
 //             lower_bound,
 //             upper_bound};
 //
 //  var msg_ru=String.Format
 //   ("[BUG CHECK] Некорректный диапазон размерности [{4}] массива [{0}].[{1}].[{2}].[{3}]: {5}..{6}.",
 //    args);
 //
 //  var msg_en=String.Format
 //   ("[BUG CHECK] Incorrect range of dimension [{4}] of array [{0}].[{1}].[{2}].[{3}]: {5}..{6}.",
 //    args);
 //
 //  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
 //   (err_rec,
 //    srcID,
 //    msg_ru,
 //    msg_en,
 //    com_lib.HResultCode.E_FAIL);
 // }//CheckErrorRecord__BugCheck__array_err__bad_range
 //
 //-----------------------------------------------------------------------
 // public static void CheckErrorRecord__BugCheck__array_err__no_descr
 //                          (structure_lib.IErrorRecord err_rec,
 //                           string                     srcID,
 //                           string                     catalog_name,
 //                           string                     schema_name,
 //                           string                     relation_name,
 //                           string                     field_name)
 // {
 //  Assert.NotNull
 //   (err_rec);
 //
 //  var args=new string[]
 //            {catalog_name,
 //             schema_name,
 //             relation_name,
 //             field_name};
 //
 //  var msg_ru=String.Format
 //   ("[BUG CHECK] Отсутствует описание массива [{0}].[{1}].[{2}].[{3}].",
 //    args);
 //
 //  var msg_en=String.Format
 //   ("[BUG CHECK] No description for array [{0}].[{1}].[{2}].[{3}].",
 //    args);
 //
 //  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
 //   (err_rec,
 //    srcID,
 //    msg_ru,
 //    msg_en,
 //    com_lib.HResultCode.E_FAIL);
 // }//CheckErrorRecord__BugCheck__array_err__no_descr
 //
 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__BugCheck__ModificationCommandBatch__unexpected_ResultSetMapping
                          (structure_lib.IErrorRecord err_rec,
                           string                     srcID,
                           string                     place,
                           string                     point,
                           int                        commandIndex,
                           string                     commandText,
                           ResultSetMapping           resultSetMapping)
 {
  Assert.NotNull
   (err_rec);

  string reason
   =string.Format
     ("unexpected result set mapping: {2}. "
     +"Command text [{0}]: [{1}]",
      commandIndex,
      commandText,
      resultSetMapping);

  CheckErrors.TestBugCheck_RU_EN
   (err_rec,
    srcID,
    place,
    point,
    reason,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__BugCheck__ModificationCommandBatch__unexpected_ResultSetMapping

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__BugCheck__ModificationCommandBatch__found_a_read_op
                          (structure_lib.IErrorRecord err_rec,
                           string                     srcID,
                           string                     place,
                           string                     point,
                           int                        commandIndex,
                           string                     commandText,
                           string                     entryName,
                           string                     propertyName)
 {
  Assert.NotNull
   (err_rec);

  string reason
   =string.Format
     ("found a read operation. "
     +"Command text [{0}]: [{1}]. "
     +"Name of entry property: [{2}].[{3}]",
      commandIndex,
      commandText,
      entryName,
      propertyName);

  CheckErrors.TestBugCheck_RU_EN
   (err_rec,
    srcID,
    place,
    point,
    reason,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__BugCheck__ModificationCommandBatch__found_a_read_op

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__BugCheck__ModificationCommandBatch__we_not_expected_result_set
                          (structure_lib.IErrorRecord err_rec,
                           string                     srcID,
                           string                     place,
                           string                     point,
                           int                        commandIndex,
                           string                     commandText,
                           int                        columnCount)
 {
  Assert.NotNull
   (err_rec);

  string reason
   =string.Format
     ("we not expected result set. Number of columns: {2}. "
     +"Command text [{0}]: [{1}]",
      commandIndex,
      commandText,
      columnCount);

  CheckErrors.TestBugCheck_RU_EN
   (err_rec,
    srcID,
    place,
    point,
    reason,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__BugCheck__ModificationCommandBatch__we_not_expected_result_set

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__BugCheck__ModificationCommandBatch__unexpected_parameter_direction
                          (structure_lib.IErrorRecord     err_rec,
                           string                         srcID,
                           string                         place,
                           string                         point,
                           int                            commandIndex,
                           string                         commandText,
                           string                         parameterName,
                           System.Data.ParameterDirection parameterDirection)
 {
  Assert.NotNull
   (err_rec);

  string reason
   =string.Format
     ("unexpected parameter direction [{2}]: {3}. "
     +"Command text [{0}]: [{1}]",
      commandIndex,
      commandText,
      parameterName,
      parameterDirection);

  CheckErrors.TestBugCheck_RU_EN
   (err_rec,
    srcID,
    place,
    point,
    reason,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__BugCheck__ModificationCommandBatch__unexpected_parameter_direction

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__BugCheck__LocalEvalErr__mutation_of_expression
                          (structure_lib.IErrorRecord     err_rec,
                           string                         srcID,
                           string                         place,
                           string                         point,
                           Expression                     oldExpression,
                           Expression                     newExpression)
 {
  Assert.NotNull
   (err_rec);

  string oldESign
   =Object.ReferenceEquals(oldExpression,null)
    ?"#NULL"
    :oldExpression.ToString();

  string newESign
   =Object.ReferenceEquals(newExpression,null)
    ?"#NULL"
    :newExpression.ToString();

  string reason
   =string.Format
     ("detected mutation of expression [{0}]. New expression is [{1}]",
      oldESign,
      newESign);

  CheckErrors.TestBugCheck_RU_EN
   (err_rec,
    srcID,
    place,
    point,
    reason,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__BugCheck__LocalEvalErr__mutation__null_ptr_to_new_expression

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__BugCheck__LocalEvalErr__mutation__null_ptr_to_new_expression
                          (structure_lib.IErrorRecord     err_rec,
                           string                         srcID,
                           string                         place,
                           string                         point,
                           Expression                     oldExpression)
 {
  Assert.NotNull
   (err_rec);

  string reason
   =string.Format
     ("detected mutation of expression [{0}]. New expression is null",
      oldExpression.ToString());

  CheckErrors.TestBugCheck_RU_EN
   (err_rec,
    srcID,
    place,
    point,
    reason,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__BugCheck__LocalEvalErr__mutation__null_ptr_to_new_expression

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__BugCheck__LocalEvalErr__unsupported_conversion
                          (structure_lib.IErrorRecord     err_rec,
                           string                         srcID,
                           string                         place,
                           string                         point,
                           string                         sourceTypeSign,
                           string                         targetTypeSign)
 {
  Assert.NotNull
   (err_rec);

  string reason
   =string.Format
     ("unsupported local conversion from [{0}] to [{1}]",
      sourceTypeSign,
      targetTypeSign);

  CheckErrors.TestBugCheck_RU_EN
   (err_rec,
    srcID,
    place,
    point,
    reason,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__BugCheck__LocalEvalErr__unsupported_conversion

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__BugCheck__LocalEvalErr__unsupported_method
                          (structure_lib.IErrorRecord     err_rec,
                           string                         srcID,
                           string                         place,
                           string                         point,
                           string                         methodSign)
 {
  Assert.NotNull
   (err_rec);

  string reason
   =string.Format
     ("unsupported local method {0}",
      methodSign);

  CheckErrors.TestBugCheck_RU_EN
   (err_rec,
    srcID,
    place,
    point,
    reason,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__BugCheck__LocalEvalErr__unsupported_method

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__BugCheck__LocalEvalErr__mutation__changed_result_type_of_expression
                          (structure_lib.IErrorRecord     err_rec,
                           string                         srcID,
                           string                         place,
                           string                         point,
                           Expression                     oldExpression,
                           Expression                     newExpression)
 {
  Assert.NotNull
   (err_rec);

  string reason
   =string.Format
     ("detected mutation of expression [{0}][result type: {1}]. "
     +"New expression [{2}] has result type {3}",
      oldExpression.ToString(),
      oldExpression.Type.FullName,
      newExpression.ToString(),
      newExpression.Type.FullName);

  CheckErrors.TestBugCheck_RU_EN
   (err_rec,
    srcID,
    place,
    point,
    reason,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__BugCheck__LocalEvalErr__mutation__changed_result_type_of_expression

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__BugCheck__LocalEvalErr__mutation__changed_node_type_of_expression
                          (structure_lib.IErrorRecord     err_rec,
                           string                         srcID,
                           string                         place,
                           string                         point,
                           Expression                     oldExpression,
                           Expression                     newExpression)
 {
  Assert.NotNull
   (err_rec);

  string reason
   =string.Format
     ("detected mutation of expression [{0}][node type: {1}]. "
     +"New expression [{2}] has node type {3}",
      oldExpression.ToString(),
      oldExpression.NodeType,
      newExpression.ToString(),
      newExpression.NodeType);

  CheckErrors.TestBugCheck_RU_EN
   (err_rec,
    srcID,
    place,
    point,
    reason,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__BugCheck__LocalEvalErr__mutation__changed_node_type_of_expression

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__bug_check__unexpected_result_type_of_binary_operator_5
                          (structure_lib.IErrorRecord err_rec,
                           string                     srcID,
                           ExpressionType             operationType,
                           Type                       resultType,
                           Type                       expectedType,
                           Type                       leftType,
                           Type                       rightType)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
     {
      operationType,
      resultType,
      expectedType,
      leftType,
      rightType
     };

  var msg_ru=String.Format
   ("[BUG CHECK] Неожиданный тип результата бинарной операции [{0}]: {1}. Ожидаемый базовый тип: {2}. Тип левого аргумента: {3}. Тип правого аргумента: {4}.",
    args);

  var msg_en=String.Format
   ("[BUG CHECK] Unexpected result type of binary operator [{0}]: {1}. Expected base type: {2}. Left argument type: {3}. Right argument type: {4}.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__bug_check__unexpected_result_type_of_binary_operator_5

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__bug_check__bind_to_type_method__not_found_4
                          (structure_lib.IErrorRecord err_rec,
                           string                     srcID,
                           Type                       type,
                           string                     name,
                           string                     parametersSign,
                           BindingFlags               bindFlags)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
     {
      type,
      name,
      parametersSign,
      bindFlags
     };

  var msg_ru=String.Format
   ("[BUG CHECK] Ошибка привязки к методу [{0}].[{1}] со списком параметров {{{2}}}. BindingFlags: {3}. Метод не найден.",
    args);

  var msg_en=String.Format
   ("[BUG CHECK] Failed to bind to method [{0}].[{1}] with parameter list {{{2}}}. BindingFlags: {3}. Method not found.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__bug_check__bind_to_type_method__not_found_4

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__bug_check__bind_to_type_method__bad_return_type_6
                          (structure_lib.IErrorRecord err_rec,
                           string                     srcID,
                           Type                       type,
                           string                     name,
                           string                     parametersSign,
                           BindingFlags               bindFlags,
                           string                     expectedReturnTypeSign,
                           string                     actualReturnTypeSign)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
     {
      type,
      name,
      parametersSign,
      bindFlags,
      expectedReturnTypeSign,
      actualReturnTypeSign,
     };

  var msg_ru=String.Format
   ("[BUG CHECK] Ошибка привязки к методу [{0}].[{1}] со списком параметров {{{2}}}. BindingFlags: {3}. Метод возвращает {5} вместо {4}.",
    args);

  var msg_en=String.Format
   ("[BUG CHECK] Failed to bind to method [{0}].[{1}] with parameter list {{{2}}}. BindingFlags: {3}. Method returns {5} instead {4}.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__bug_check__bind_to_type_method__bad_return_type_6

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__bug_check__get_nested_type__not_found_3
                          (structure_lib.IErrorRecord err_rec,
                           string                     srcID,
                           Type                       type,
                           string                     name,
                           BindingFlags               bindFlags)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
     {
      type,
      name,
      bindFlags
     };

  var msg_ru=String.Format
   ("[BUG CHECK] Ошибка получения описания вложенного типа [{0}].[{1}]. BindingFlags: {2}. Тип не найден.",
    args);

  var msg_en=String.Format
   ("[BUG CHECK] Failed to get type of nested type [{0}].[{1}]. BindingFlags: {2}. Type not found.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__bug_check__get_nested_type__not_found_3

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__bug_check__sql_enode__unsupported_arg_types__2
                          (structure_lib.IErrorRecord err_rec,
                           string                     srcID,
                           string                     sqlENodeSign,
                           string                     parametersSign)
 {
  Assert.NotNull
   (err_rec);

  var args
   =new object[]
     {
      sqlENodeSign,
      parametersSign,
     };

  var msg_ru=String.Format
   ("[BUG CHECK] SQL Expression Node [{0}]. Неподдерживаемые типы аргументов {{{1}}}.",
    args);

  var msg_en=String.Format
   ("[BUG CHECK] SQL Expression Node [{0}]. Unsupported argument types {{{1}}}.",
    args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    srcID,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__bug_check__sql_enode__unsupported_arg_types__2

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__BugCheck__No_TypeMapping
                          (structure_lib.IErrorRecord     err_rec,
                           string                         srcID,
                           string                         place,
                           string                         point)
 {
  Assert.NotNull
   (err_rec);

  string reason
   =string.Format
     ("no TypeMapping information");

  CheckErrors.TestBugCheck_RU_EN
   (err_rec,
    srcID,
    place,
    point,
    reason,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__BugCheck__No_TypeMapping

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__BugCheck__No_TypeMapping_ClrType
                          (structure_lib.IErrorRecord     err_rec,
                           string                         srcID,
                           string                         place,
                           string                         point)
 {
  Assert.NotNull
   (err_rec);

  string reason
   =string.Format
     ("no TypeMapping.ClrType information");

  CheckErrors.TestBugCheck_RU_EN
   (err_rec,
    srcID,
    place,
    point,
    reason,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__BugCheck__No_TypeMapping_ClrType

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__BugCheck__UnknownParserResultCode<T>
                          (structure_lib.IErrorRecord     err_rec,
                           string                         srcID,
                           string                         place,
                           string                         point,
                           T                              code)
 {
  Assert.NotNull
   (err_rec);

  string reason
   =string.Format
     ("unknown parser result code [{0}]",
      code);

  CheckErrors.TestBugCheck_RU_EN
   (err_rec,
    srcID,
    place,
    point,
    reason,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__BugCheck__UnknownParserResultCode<T>

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__BugCheck__UnknownDataTypeID<T>
                          (structure_lib.IErrorRecord     err_rec,
                           string                         srcID,
                           string                         place,
                           string                         point,
                           T                              dataTypeID)
 {
  Assert.NotNull
   (err_rec);

  string reason
   =string.Format
     ("unknown data type id [{0}]",
      dataTypeID);

  CheckErrors.TestBugCheck_RU_EN
   (err_rec,
    srcID,
    place,
    point,
    reason,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__BugCheck__UnknownDataTypeID<T>

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__BugCheck__UnknownBlobSubTypeID<T>
                          (structure_lib.IErrorRecord     err_rec,
                           string                         srcID,
                           string                         place,
                           string                         point,
                           T                              blobSubTypeID)
 {
  Assert.NotNull
   (err_rec);

  string reason
   =string.Format
     ("unknown blob subtype id [{0}]",
      blobSubTypeID);

  CheckErrors.TestBugCheck_RU_EN
   (err_rec,
    srcID,
    place,
    point,
    reason,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__BugCheck__UnknownBlobSubTypeID<T>

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__BugCheck__ColumnHasMultipleVGS
                          (structure_lib.IErrorRecord     err_rec,
                           string                         srcID,
                           string                         place,
                           string                         point,
                           string                         tableName,
                           string                         columnName)
 {
  Assert.NotNull
   (err_rec);

  string reason
   =string.Format
     ("column [{0}].[{1}] has multiple value generation strategies",
      tableName,
      columnName);

  CheckErrors.TestBugCheck_RU_EN
   (err_rec,
    srcID,
    place,
    point,
    reason,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__BugCheck__ColumnHasMultipleVGS

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__BugCheck__MultipleConventionsForReplacing
                          (structure_lib.IErrorRecord     err_rec,
                           string                         srcID,
                           string                         place,
                           string                         point,
                           string                         conventionTypeSign,
                           string                         newImplTypeSign,
                           string                         firstConventionTypeSign,
                           string                         secondConventionTypeSign)
 {
  Assert.NotNull
   (err_rec);

  string reason
   =string.Format
     ("Convention [{0}] can't be replaced to implementation [{1}]. "
      +"Multiple conventions were found. "
      +"Type of first convention: [{2}]. "
      +"Type of second convention: [{3}]",
      conventionTypeSign,
      newImplTypeSign,
      firstConventionTypeSign,
      secondConventionTypeSign);

  CheckErrors.TestBugCheck_RU_EN
   (err_rec,
    srcID,
    place,
    point,
    reason,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__BugCheck__MultipleConventionsForReplacing

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__BugCheck__ConventionErr__NoConventionForReplacing
                          (structure_lib.IErrorRecord     err_rec,
                           string                         srcID,
                           string                         place,
                           string                         point,
                           string                         conventionTypeSign,
                           string                         newImplTypeSign)
 {
  Assert.NotNull
   (err_rec);

  string reason
   =string.Format
     ("No instance of convention [{0}] for replacing by implementation [{1}]",
      conventionTypeSign,
      newImplTypeSign);

  CheckErrors.TestBugCheck_RU_EN
   (err_rec,
    srcID,
    place,
    point,
    reason,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__BugCheck__ConventionErr__NoConventionForReplacing

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__BugCheck__ConventionErr__ConventionAlreadyDefined
                          (structure_lib.IErrorRecord     err_rec,
                           string                         srcID,
                           string                         place,
                           string                         point,
                           string                         conventionTypeSign,
                           string                         newImplTypeSign,
                           string                         existConventionTypeSign)
 {
  Assert.NotNull
   (err_rec);

  string reason
   =string.Format
     ("Convention [{0}] can't be defined as [{1}]. "
     +"Implementation was already defined as [{2}]",
      conventionTypeSign,
      newImplTypeSign,
      existConventionTypeSign);

  CheckErrors.TestBugCheck_RU_EN
   (err_rec,
    srcID,
    place,
    point,
    reason,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__BugCheck__ConventionErr__ConventionAlreadyDefined

 //-----------------------------------------------------------------------
 public static void CheckOleDbError__Firebird__DataTypeUnknown
                         (xdb.OleDbError err)
 {
  Assert.IsNotNull
   (err);

  StringAssert.Contains
   (c_src__Firebird,
    err.Source);

  StringAssert.Contains
   ("Data type unknown",
    err.Message);

  Assert.AreEqual
   ("HY004",
    err.SQLState);
 }//CheckOleDbError__Firebird__DataTypeUnknown

 //-----------------------------------------------------------------------
 public static void CheckOleDbError__Firebird__ExpressionEvaluationNotSupported
                         (xdb.OleDbError err)
 {
  Assert.IsNotNull
   (err);

  StringAssert.Contains
   (c_src__Firebird,
    err.Source);

  StringAssert.Contains
   ("expression evaluation not supported",
    err.Message);

  Assert.AreEqual
   ("42000",
    err.SQLState);
 }//CheckOleDbError__Firebird__ExpressionEvaluationNotSupported

 //-----------------------------------------------------------------------
 public static void CheckOleDbError__Firebird__IntegerDivideByZero
                         (xdb.OleDbError err)
 {
  Assert.IsNotNull
   (err);

  StringAssert.Contains
   (c_src__Firebird,
    err.Source);

  StringAssert.Contains
   ("Integer divide by zero.  The code attempted to divide an integer value by an integer divisor of zero.",
    err.Message);

  Assert.AreEqual
   ("22012",
    err.SQLState);
 }//CheckOleDbError__Firebird__IntegerDivideByZero

 //-----------------------------------------------------------------------
 public static void CheckOleDbError__Firebird__FloatDivideByZero
                         (xdb.OleDbError err)
 {
  Assert.IsNotNull
   (err);

  StringAssert.Contains
   (c_src__Firebird,
    err.Source);

  StringAssert.Contains
   ("Floating-point divide by zero.  The code attempted to divide a floating-point value by zero.",
    err.Message);

  Assert.AreEqual
   ("22012",
    err.SQLState);
 }//CheckOleDbError__Firebird__FloatDivideByZero

 //-----------------------------------------------------------------------
 public static void CheckOleDbError__Firebird__ConversionErrorFromString
                         (xdb.OleDbError err)
 {
  Assert.IsNotNull
   (err);

  StringAssert.Contains
   (c_src__Firebird,
    err.Source);

  StringAssert.Contains
   ("conversion error from string",
    err.Message);

  Assert.AreEqual
   ("22018",
    err.SQLState);
 }//CheckOleDbError__Firebird__ConversionErrorFromString

 //-----------------------------------------------------------------------
 public static void CheckOleDbError__Firebird__CannotTranslateCharBetweenCSs
                         (xdb.OleDbError err)
 {
  Assert.IsNotNull
   (err);

  StringAssert.Contains
   (c_src__Firebird,
    err.Source);

  StringAssert.Contains
   ("Cannot transliterate character between character sets",
    err.Message);

  Assert.AreEqual
   ("22018",
    err.SQLState);
 }//CheckOleDbError__Firebird__CannotTranslateCharBetweenCSs

 //-----------------------------------------------------------------------
 public static void CheckOleDbError__Firebird__BlobTruncationWhenCvtToString_LenLimitExceeded
                         (xdb.OleDbError err)
 {
  Assert.IsNotNull
   (err);

  StringAssert.Contains
   (c_src__Firebird,
    err.Source);

  StringAssert.Contains
   ("blob truncation when converting to a string: length limit exceeded",
    err.Message);

  Assert.AreEqual
   ("22001",
    err.SQLState);
 }//CheckOleDbError__Firebird__BlobTruncationWhenCvtToString_LenLimitExceeded

 //-----------------------------------------------------------------------
 public static void CheckOleDbError__Firebird__TRAP_FOR_NULL
                         (xdb.OleDbError err)
 {
  Assert.IsNotNull
   (err);

  StringAssert.Contains
   (c_src__Firebird,
    err.Source);

  StringAssert.Contains
   ("conversion error from string \"TRAP FOR NULL\"",
    err.Message);

  Assert.AreEqual
   ("22018",
    err.SQLState);
 }//CheckOleDbError__Firebird__TRAP_FOR_NULL

 //-----------------------------------------------------------------------
 public static void CheckOleDbError__Firebird__OUT_OF_RANGE
                         (xdb.OleDbError err)
 {
  Assert.IsNotNull
   (err);

  StringAssert.Contains
   (c_src__Firebird,
    err.Source);

  StringAssert.Contains
   ("conversion error from string \"OUT OF RANGE\"",
    err.Message);

  Assert.AreEqual
   ("22018",
    err.SQLState);
 }//CheckOleDbError__Firebird__OUT_OF_RANGE

 //-----------------------------------------------------------------------
 public static void CheckOleDbError__Firebird__CANNOT_CONVERT_VALUE_TO_BYTE__OVERFLOW_ERROR
                         (xdb.OleDbError err)
 {
  Assert.IsNotNull
   (err);

  StringAssert.Contains
   (c_src__Firebird,
    err.Source);

  StringAssert.Contains
   ("conversion error from string \"CANNOT CONVERT VALUE TO BYTE. OVERFLOW ERROR.\"",
    err.Message);

  Assert.AreEqual
   ("22018",
    err.SQLState);

  Assert.AreEqual
   (335544334,
    err.NativeError);
 }//CheckOleDbError__Firebird__CANNOT_CONVERT_VALUE_TO_BYTE__OVERFLOW_ERROR

 //-----------------------------------------------------------------------
 public static void CheckOleDbError__Firebird__IntOpOverflow
                         (xdb.OleDbError err)
 {
  Assert.IsNotNull
   (err);

  StringAssert.Contains
   (c_src__Firebird,
    err.Source);

  StringAssert.Contains
   ("Integer overflow.  The result of an integer operation caused the most significant bit of the result to carry.",
    err.Message);

  Assert.AreEqual
   ("22003",
    err.SQLState);
 }//CheckOleDbError__Firebird__IntOpOverflow

 //-----------------------------------------------------------------------
 public static void CheckOleDbError__Firebird__FloatOpOverflow
                         (xdb.OleDbError err)
 {
  Assert.IsNotNull
   (err);

  StringAssert.Contains
   (c_src__Firebird,
    err.Source);

  StringAssert.Contains
   ("Floating-point overflow.  The exponent of a floating-point operation is greater than the magnitude allowed.",
    err.Message);

  Assert.AreEqual
   ("22003",
    err.SQLState);
 }//CheckOleDbError__Firebird__FloatOpOverflow

 //-----------------------------------------------------------------------
 public static void CheckOleDbError__Firebird__NumericValueOutOfRange
                         (xdb.OleDbError err)
 {
  Assert.IsNotNull
   (err);

  StringAssert.Contains
   (c_src__Firebird,
    err.Source);

  StringAssert.Contains
   ("arithmetic exception, numeric overflow, or string truncation\n"
    +"numeric value is out of range",
    err.Message);

  Assert.AreEqual
   ("22003",
    err.SQLState);
 }//CheckOleDbError__Firebird__NumericValueOutOfRange

 //-----------------------------------------------------------------------
 public static void CheckOleDbError__Firebird__ExceedsRangeForValidTimestamps
                         (xdb.OleDbError err)
 {
  Assert.IsNotNull
   (err);

  StringAssert.Contains
   (c_src__Firebird,
    err.Source);

  StringAssert.Contains
   ("value exceeds the range for valid timestamps",
    err.Message);

  Assert.AreEqual
   ("22008",
    err.SQLState);
 }//CheckOleDbError__Firebird__ExceedsRangeForValidTimestamps

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__IBP__FailedToBuildIbParamValue__CantConvert
                    (structure_lib.IErrorRecord err_rec,
                     int                        position,
                     string                     src_type_name,
                     string                     dest_type_name,
                     com_lib.HResultCode        error_code)
 {
  Assert.NotNull
   (err_rec);

  var src=c_src__IBProvider;

  var args=new object[]{position,src_type_name,dest_type_name};

  var msg_ru
   =string.Format
     ("Ошибка формирования ib-значения входящего параметра. Позиция {0}.\r\n"
      +"Конвертирование из [{1}] в [{2}].",
      args);

  var msg_en
   =string.Format
     ("IB-native IN-parameter value create failed. Position {0}.\r\n"
      +"Conversion from [{1}] to [{2}].",
      args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    src,
    msg_ru,
    msg_en,
    error_code);
 }//CheckErrorRecord__IBP__FailedToBuildIbParamValue__CantConvert

 //-----------------------------------------------------------------------
 public static void CheckErrorRecord__IBP__FailedToFetchResultSetData
                    (structure_lib.IErrorRecord err_rec)
 {
  Assert.NotNull
   (err_rec);

  var src=c_src__IBProvider;

  var args=new object[]{};

  var msg_ru
   =string.Format
     ("Ошибка выборки данных результирующего множества.",
      args);

  var msg_en
   =string.Format
     ("Failed to fetch a row from cursor.",
      args);

  CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
   (err_rec,
    src,
    msg_ru,
    msg_en,
    com_lib.HResultCode.E_FAIL);
 }//CheckErrorRecord__IBP__FailedToFetchResultSetData

 //-----------------------------------------------------------------------
 public static void CheckException__EFCore__SequenceContainsNoElements
                        (InvalidOperationException e)
 {
  Assert.AreEqual
   ("Sequence contains no elements.",
    e.Message);
 }//CheckException__EFCore__SequenceContainsNoElements
};//class CheckErrors

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General

////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 14.05.2018.

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb{
////////////////////////////////////////////////////////////////////////////////
//enum ErrSourceID

enum ErrSourceID
{
 common,

 multiple_sources,

 unknown_source,

 EXT,

 //----------------------------------------- extensions
 LcpiOleDb__Extensions__DbContextOptions,

 LcpiOleDb__Extensions__Property,

 LcpiOleDb__Extensions__PropertyBuilder,

 LcpiOleDb__Extensions__Model,

 LcpiOleDb__Extensions__ModelBuilder,

 //----------------------------------------- Common
 LcpiOleDb__Extensions__Type,

 //----------------------------------------- EF
 LcpiOleDb__DataToolException,

 LcpiOleDb__DbContextOptionsExtension,

 LcpiOleDb__DbContextOptionsExtension_tagExtensionInfo,

 LcpiOleDb__ValueGenerationStrategy,

 LcpiOleDb__AnnotationProvider,

 LcpiOleDb__DesignTimeServices,

 //----------------------------------------- Root
 LcpiOleDb__EntityFrameworkServicesBuilder,

 LcpiOleDb__RelationalConnection,

 LcpiOleDb__RelationalCommandBuilderFactory,

 LcpiOleDb__RelationalCommandBuilder,

 LcpiOleDb__RelationalCommand,

 LcpiOleDb__RelationalDatabaseCreator,

 LcpiOleDb__QueryCompiler,

 LcpiOleDb__QueryTranslationPreprocessor,

 LcpiOleDb__QueryTranslationPreprocessorFactory,

 LcpiOleDb__SqlTranslatingExpressionVisitorFactory,

 LcpiOleDb__SqlTranslatingExpressionVisitor,

 LcpiOleDb__FromSqlParameterExpandingExpressionVisitor,

 LcpiOleDb__ParameterExtractingExpressionVisitor,

 LcpiOleDb__SqlStubExpression,

 LcpiOleDb__SqlNullabilityProcessor,

 LcpiOleDb__SqlExpressionFactory,

 LcpiOleDb__ParameterBasedSqlProcessor,

 LcpiOleDb__ParameterBasedSqlProcessorFactory,

 LcpiOleDb__ColumnModification,

 LcpiOleDb__MethodCallTranslatorProvider,

 LcpiOleDb__MemberTranslatorProvider,

 LcpiOleDb__TestSafeSqlConversion,

 LcpiOleDb__ISqlTreeNodeBuilder__Extensions,

 //----------------------------------------- root.query.local
 LcpiOleDb__LocalEval_Services__Extensions,

 LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,

 //-----------------------------------------
 Root_Query_Local_Expressions_Methods__ETranslator__EF__std__Functions,

 Root_Query_Local_Expressions_Methods__ETranslator__String__std__Equals__str,

 Root_Query_Local_Expressions_Unary__ETranslator__Convert,

 Root_Query_Local_Expressions_Unary__ETranslator__Op1,

 //-----------------------------------------
 Root_Query_Local_Expressions__Op2_Code__Equal___Object__Object,

 Root_Query_Local_Expressions__Op2_Code__NotEqual___Object__Object,

 //-----------------------------------------
 Root_Query_Local_Expressions__Op1_MasterCode__Negate___Int64___checked,

 Root_Query_Local_Expressions__Op2_MasterCode__ANY___VALUE__TEXT,

 Root_Query_Local_Expressions__Op2_MasterCode__ANY___TEXT__VALUE,

 Root_Query_Local_Expressions__Op2_MasterCode__Add___Decimal__Decimal,

 Root_Query_Local_Expressions__Op2_MasterCode__Subtract___Decimal__Decimal,

 Root_Query_Local_Expressions__Op2_MasterCode__Multiply___Decimal__Decimal,

 Root_Query_Local_Expressions__Op2_MasterCode__ArrayIndex___Array_Byte__Int32,

 Root_Query_Local_Expressions__Op2_MasterCode__ArrayIndex___Array_Byte__Int64,

 Root_Query_Local_Expressions__Op2_MasterCode__Equal___Array1_generic__Array1_generic,

 Root_Query_Local_Expressions__Op2_MasterCode__NotEqual___Array1_generic__Array1_generic,

 //-----------------------------------------
 Root_Query_Local_Expressions__Method_Code__IEnumerableByte__First,

 Root_Query_Local_Expressions__Method_Code__String__Length,

 Root_Query_Local_Expressions__Method_Code__String__Substring___startIndex,

 Root_Query_Local_Expressions__Method_Code__String__Substring___startIndex__length,

 Root_Query_Local_Expressions__Method_Code__String__Substring___nullableStartIndex,

 Root_Query_Local_Expressions__Method_Code__String__Substring___nullableStartIndex__nullableLength,

//-----------------------------------------
 Root_Query_Local_Expressions__Method_MasterCode__IEnumerable_generic__Contains,

 Root_Query_Local_Expressions__Method_MasterCode__Object__ToString,

//-----------------------------------------
 Root_Query_Local_Expressions__Cvt_Code__Object__NullableBoolean,

 Root_Query_Local_Expressions__Cvt_Code__Object__NullableGuid,

 Root_Query_Local_Expressions__Cvt_Code__Object__NullableDateOnly,

 Root_Query_Local_Expressions__Cvt_Code__Object__NullableDateTime,

 Root_Query_Local_Expressions__Cvt_Code__Object__NullableTimeOnly,

 Root_Query_Local_Expressions__Cvt_Code__Object__NullableTimeSpan,

 Root_Query_Local_Expressions__Cvt_Code__Object__NullableByte,

 Root_Query_Local_Expressions__Cvt_Code__Object__NullableSByte,

 Root_Query_Local_Expressions__Cvt_Code__Object__NullableInt16,

 Root_Query_Local_Expressions__Cvt_Code__Object__NullableInt32,

 Root_Query_Local_Expressions__Cvt_Code__Object__NullableInt64,

 Root_Query_Local_Expressions__Cvt_Code__Object__NullableDecimal,

 Root_Query_Local_Expressions__Cvt_Code__Object__NullableSingle,

 Root_Query_Local_Expressions__Cvt_Code__Object__NullableDouble,

 Root_Query_Local_Expressions__Cvt_Code__Object__String,

 Root_Query_Local_Expressions__Cvt_Code__Object__Array1_Char,

 Root_Query_Local_Expressions__Cvt_Code__String__NullableDecimal,

 Root_Query_Local_Expressions__Cvt_Code__String__NullableInt16,

 Root_Query_Local_Expressions__Cvt_Code__String__NullableInt32,

 Root_Query_Local_Expressions__Cvt_Code__String__NullableInt64,

 Root_Query_Local_Expressions__Cvt_Code__String__NullableSingle,

 Root_Query_Local_Expressions__Cvt_Code__String__NullableDouble,

 //-----------------------------------------
 Root_Query_Local_Expressions__Cvt_MasterCode__Byte__SByte,

 Root_Query_Local_Expressions__Cvt_MasterCode__SByte__Byte,

 Root_Query_Local_Expressions__Cvt_MasterCode__Int16__Byte,

 Root_Query_Local_Expressions__Cvt_MasterCode__Int16__SByte,

 Root_Query_Local_Expressions__Cvt_MasterCode__Int32__Byte,

 Root_Query_Local_Expressions__Cvt_MasterCode__Int32__SByte,

 Root_Query_Local_Expressions__Cvt_MasterCode__Int32__Int16,

 Root_Query_Local_Expressions__Cvt_MasterCode__Int64__Byte,

 Root_Query_Local_Expressions__Cvt_MasterCode__Int64__SByte,

 Root_Query_Local_Expressions__Cvt_MasterCode__Int64__Int16,

 Root_Query_Local_Expressions__Cvt_MasterCode__Int64__Int32,

 Root_Query_Local_Expressions__Cvt_MasterCode__Decimal__Byte,

 Root_Query_Local_Expressions__Cvt_MasterCode__Double__Decimal,

 Root_Query_Local_Expressions__Cvt_MasterCode__Double__Byte,

 Root_Query_Local_Expressions__Cvt_MasterCode__Double__SByte,

 Root_Query_Local_Expressions__Cvt_MasterCode__Double__Int16,

 Root_Query_Local_Expressions__Cvt_MasterCode__Double__Int32,

 Root_Query_Local_Expressions__Cvt_MasterCode__Double__Int64,

 Root_Query_Local_Expressions__Cvt_MasterCode__Double__Single,

 Root_Query_Local_Expressions__Cvt_MasterCode__Single__Decimal,

 Root_Query_Local_Expressions__Cvt_MasterCode__Single__Byte,

 Root_Query_Local_Expressions__Cvt_MasterCode__Single__SByte,

 Root_Query_Local_Expressions__Cvt_MasterCode__Single__Int16,

 Root_Query_Local_Expressions__Cvt_MasterCode__Single__Int32,

 Root_Query_Local_Expressions__Cvt_MasterCode__Single__Int64,

 //----------------------------------------- firebird.common
 FB_Common__Initializer,

 FB_Common__BatchExecutor,

 FB_Common__UpdateSqlGenerator,

 FB_Common__ModificationCommandBatch,

 FB_Common__QuerySqlGenerator,

 FB_Common__SqlExpressionUtils,

 FB_Common__BinaryOperatorTranslatorProvider,

 FB_Common__UnaryOperatorTranslatorProvider,

 FB_Common__TypeMappingUtils,

 FB_Common__TypeMapping__BIGINT,

 FB_Common__TypeMapping__BLOB_BINARY,

 FB_Common__TypeMapping__BLOB_TEXT,

 FB_Common__TypeMapping__BLOB_TEXT__as_chars,

 FB_Common__TypeMapping__BOOLEAN,

 FB_Common__TypeMapping__DOUBLE,

 FB_Common__TypeMapping__FLOAT,

 FB_Common__TypeMapping__GUID__as_bytes,

 FB_Common__TypeMapping__INTEGER,

 FB_Common__TypeMapping__SMALLINT,

 FB_Common__TypeMapping__TIMESTAMP,

 FB_Common__TypeMapping__CHAR,

 FB_Common__TypeMapping__CHAR__as_chars,

 FB_Common__TypeMapping__CHAR1,

 FB_Common__TypeMapping__VARCHAR,

 FB_Common__TypeMapping__VARCHAR__as_chars,

 FB_Common__TypeMapping__BINARY,

 FB_Common__TypeMapping__VARBINARY,

 FB_Common__TypeMapping__NUMERIC,

 FB_Common__TypeMapping__DECIMAL,

 FB_Common__TypeMapping__TimeSpan__as_Decimal9_4,

 FB_Common__TypeMapping__TimeSpan__as_Decimal18_4,

 FB_Common__TypeMapping_D1__TYPE_DATE__as_DateOnly,

 FB_Common__TypeMapping_D1__TYPE_DATE__as_DateTime,

 FB_Common__TypeMapping_D1__TYPE_TIME__as_TimeOnly,

 FB_Common__TypeMapping_D3__TYPE_DATE__as_DateOnly,

 FB_Common__TypeMapping_D3__TYPE_DATE__as_DateTime,

 FB_Common__TypeMapping_D3__TYPE_TIME__as_TimeOnly,

 FB_Common__TypeMapping_D3__TYPE_TIME__as_TimeSpan,

 FB_Common__ValueConversion__TimeSpanToDecimal9_4,

 FB_Common__ValueConversion__TimeSpanToDecimal18_4,

 FB_Common__Sql_ETranslator_Unary__Op1,

 FB_Common__Sql_ETranslator_Unary__Convert,

 FB_Common__Sql_ETranslator_Unary__Equal,

 FB_Common__Sql_ETranslator_Unary__NotEqual,

 FB_Common__Sql_ETranslator_Op1__Not,

 FB_Common__Sql_ETranslator__String__std__EndsWith__str___through_RIGHT,

 FB_Common__Sql_ETranslator__Dummy__MemberNotSupportedInCurrentCnDialect,

 FB_Common__Sql_ETranslator__Dummy__MethodNotSupportedInCurrentCnDialect,

 FB_Common__Sql_ENode_Function,

 FB_Common__Sql_ENode_Function__Nullable_Value,

 FB_Common__Sql_ENode_Function__SQL__ABS,

 FB_Common__Sql_ENode_Function__SQL__ASCII_CHAR,

 FB_Common__Sql_ENode_Function__SQL__ASCII_VAL,

 FB_Common__Sql_ENode_Function__SQL__CAST_AS,

 FB_Common__Sql_ENode_Function__SQL__CHARACTER_LENGTH,

 FB_Common__Sql_ENode_Function__SQL__SIGN,

 FB_Common__Sql_ENode_Function__SQL__STARTING_WITH,

 FB_Common__Sql_ENode_Function__SQL__SUBSTRING_from,

 FB_Common__Sql_ENode_Function__SQL__SUBSTRING_from_for,

 FB_Common__Sql_ENode_Function__SQL__ROUND,

 FB_Common__Sql_ENode_Function__SQL__ROUND_scale,

 FB_Common__Sql_ENode_Function__SQL__TRUNC,

 FB_Common__Sql_ENode_Function__SQL__FLOOR,

 FB_Common__Sql_ENode_Function__SQL__LIKE,

 FB_Common__Sql_ENode_Function__SQL__LIKE_escape,

 FB_Common__Sql_ENode_Function__SQL__CEILING,

 FB_Common__Sql_ENode_Function__SQL__COALESCE,

 FB_Common__Sql_ENode_Function__SQL__CURRENT_TIMESTAMP,

 FB_Common__Sql_ENode_Function__SQL__CURRENT_DATE_d3,

 FB_Common__Sql_ENode_Function__SQL__BIN_XOR,

 FB_Common__Sql_ENode_Function__SQL__BIN_AND,

 FB_Common__Sql_ENode_Function__SQL__BIN_OR,

 FB_Common__Sql_ENode_Function__SQL__BIN_SHL,

 FB_Common__Sql_ENode_Function__SQL__BIN_SHR,

 FB_Common__Sql_ENode_Function__SQL__MOD,

 FB_Common__Sql_ENode_Function__SQL__OCTET_LENGTH,

 FB_Common__Sql_ENode_Function__SQL__OP_CONCAT,

 FB_Common__Sql_ENode_Function__SQL__OP_DIV,

 FB_Common__Sql_ENode_Function__SQL__OP_EQUAL,

 FB_Common__Sql_ENode_Function__SQL__OP_MUL,

 FB_Common__Sql_ENode_Function__SQL__OP_SUB,

 FB_Common__Sql_ENode_Function__SQL__POSITION,

 FB_Common__Sql_ENode_Function__SQL__RAND,

 FB_Common__Sql_ENode_Function__SQL__RIGHT,

 FB_Common__Sql_ENode_Function__SQL__DATEADD,

 FB_Common__Sql_ENode_Function__SQL__DATEDIFF,

 FB_Common__Sql_ENode_Function__SQL__EXTRACT,

 FB_Common__Sql_ENode_Function__SQL__TRIM,

 FB_Common__Sql_ENode_Function__SQL__TRIM__ch1,

 FB_Common__Sql_ENode_Function__SQL__TRIM_START,

 FB_Common__Sql_ENode_Function__SQL__TRIM_START__ch1,

 FB_Common__Sql_ENode_Function__SQL__TRIM_END,

 FB_Common__Sql_ENode_Function__SQL__TRIM_END__ch1,

 FB_Common__Sql_ENode_Unary__Convert,

 FB_Common__Sql_ENode_Unary__SQL__IS_NULL,

 FB_Common__Sql_ENode_Unary__SQL__IS_NOT_NULL,

 FB_Common__Sql_ENode_Unary__SQL__NEGATE,

 FB_Common__Sql_ENode_Unary__SQL__NOT,

 FB_Common__Sql_ENode_Helpers__SqlExpressionFactory__STD,

 //-----------------------------------------
 FB_DatabaseModelFactory,

 FB_DataReaderExtension,

 FB_ScaffoldingCodeGenerator,

 FB_IndexModelAnnotations,

 FB_DatabaseColumnAnnotations,

 //----------------------------------------- firebird.common.query.local
 FB_Common__Query_Local_Expressions__DbCast_Cvt__Int64__Int32,

 FB_Common__Query_Local_Expressions__DbCast_Cvt__Decimal__Int32,

 FB_Common__Query_Local_Expressions__DbCast_Cvt__Double__Int32,

 //-----------------------------------------
 FB_Common__Query_Local_Expressions__Method_Code__DbCast__AsInteger,

 FB_Common__Query_Local_Expressions__Method_Code__DbCast__AsDouble,

 //----------------------------------------- firebird.v03_0_0
 FB_V03_0_0__Initializer,

 FB_V03_0_0__TypeMappingSource__Base,

 FB_V03_0_0_D1__TypeMappingSource__Base,

 FB_V03_0_0_D1__TypeMappingSourceForDDL,

 FB_V03_0_0_D2__TypeMappingSource__Base,

 FB_V03_0_0_D2__TypeMappingSourceForDDL,

 FB_V03_0_0_D3__TypeMappingSource,

 FB_V03_0_0__SqlGenerationHelper,

 FB_V03_0_0__MigrationsSqlGenerator,

 FB_V03_0_0__HistoryRepository,

 FB_V03_0_0__QueryTranslationPostprocessor,

 //----------------------------------------- firebird.v03_0_0.D0
 FB_V03_0_0_D0__Sql_ETranslator__QUERABLE__AVG,

 FB_V03_0_0_D0__Sql_ETranslator__QUERABLE__SUM,

 //----------------------------------------- firebird.v03_0_0.D1
 FB_V03_0_0_D1__Sql_ENode__SSCode_Unary_Convert__CastAs__FloatToDecimal,

 FB_V03_0_0_D1__Sql_ENode__SSCode_Unary_Convert__CastAs__Int16ToDecimal,

 FB_V03_0_0_D1__Sql_ENode__SSCode_Unary_Convert__CastAs__Int32ToDecimal,

 FB_V03_0_0_D1__Sql_ENode__SSCode_Unary_Convert__CastAs__Int64ToDecimal,

 //-------
 FB_V03_0_0_D1__Sql_ENode_Function__SQL__AVG,

 FB_V03_0_0_D1__Sql_ENode_Function__SQL__SUM,

 //-------
 FB_V03_0_0_D1__Sql_ETranslator_Op1__Negate__STD,

 //----------------------------------------- firebird.v03_0_0.D2

 //----------------------------------------- firebird.v03_0_0.D3
 FB_V03_0_0_D3__Sql_ENode__SSCode_Unary_Convert__CastAs__FloatToDecimal,

 FB_V03_0_0_D3__Sql_ENode__SSCode_Unary_Convert__CastAs__Int16ToDecimal,

 FB_V03_0_0_D3__Sql_ENode__SSCode_Unary_Convert__CastAs__Int32ToDecimal,

 FB_V03_0_0_D3__Sql_ENode__SSCode_Unary_Convert__CastAs__Int64ToDecimal,

 //-------
 FB_V03_0_0_D3__Sql_ENode_Function__SQL__AVG,

 FB_V03_0_0_D3__Sql_ENode_Function__SQL__SUM,

 //-------
 FB_V03_0_0_D3__Sql_ETranslator_Op1__Negate__STD,

 //-----------------------------------------
 FB_V03_0_0__Query_Local_D0_Expressions__Op2_MasterCode__Add___Int64__Int64___checked,

 FB_V03_0_0__Query_Local_D0_Expressions__Op2_MasterCode__Add___Double__Double,

 FB_V03_0_0__Query_Local_D0_Expressions__Op2_MasterCode__Add___DateTime__TimeSpan,

 FB_V03_0_0__Query_Local_D0_Expressions__Op2_MasterCode__Add___TimeSpan__TimeSpan,

 //-----------------------------------------
 FB_V03_0_0__Query_Local_D0_Expressions__Op2_MasterCode__Subtract___Int64__Int64___checked,

 FB_V03_0_0__Query_Local_D0_Expressions__Op2_MasterCode__Subtract___Double__Double,

 FB_V03_0_0__Query_Local_D0_Expressions__Op2_MasterCode__Subtract___DateTime__TimeSpan,

 FB_V03_0_0__Query_Local_D0_Expressions__Op2_MasterCode__Subtract___TimeSpan__TimeSpan,

 //-----------------------------------------
 FB_V03_0_0__Query_Local_D0_Expressions__Op2_MasterCode__Multiply___Int64__Int64___checked,

 FB_V03_0_0__Query_Local_D0_Expressions__Op2_MasterCode__Multiply___Double__Double,

 //-----------------------------------------
 FB_V03_0_0__Query_Local_D0_Expressions__Op2_MasterCode__Divide___Int64__Int64___checked,

 FB_V03_0_0__Query_Local_D0_Expressions__Op2_MasterCode__Divide___Double__Double,

 //-----------------------------------------
 Basement_EF_Dbms_Firebird_V03_0_0_Infrastructure___FB_V03_0_0__ModelValidator,

 //-----------------------------------------
 Basement_EF_Dbms_Firebird_V03_0_0_Metadata_Conventions___FB_V03_0_0__ConventionSetBuilder,

 Basement_EF_Dbms_Firebird_V03_0_0_Metadata_Conventions___FB_V03_0_0__Convention_ValueGenerationStrategy,

 Basement_EF_Dbms_Firebird_V03_0_0_Metadata_Conventions___FB_V03_0_0__Convention_StoreGeneration,

 Basement_EF_Dbms_Firebird_V03_0_0_Metadata_Conventions___FB_V03_0_0__Convention_ValueGeneration,

 //-----------------------------------------
 Basement_EF_Dbms_Firebird_V03_0_0_Migrations_D1_Internal_SvcImpls___FB_V03_0_0__MigrationsSvcImpl__GenerateCreateSequence,

 Basement_EF_Dbms_Firebird_V03_0_0_Migrations_D1_Internal_SvcImpls___FB_V03_0_0__MigrationsSvcImpl__GenerateRestartSequence,

 Basement_EF_Dbms_Firebird_V03_0_0_Migrations_D1_Internal_SvcImpls___FB_V03_0_0__MigrationsSvcImpl__GenerateAlterSequence,

 //-----------------------------------------
 Basement_EF_Dbms_Firebird_V03_0_0_Migrations_D3_Internal_SvcImpls___FB_V03_0_0__MigrationsSvcImpl__GenerateCreateSequence,

 Basement_EF_Dbms_Firebird_V03_0_0_Migrations_D3_Internal_SvcImpls___FB_V03_0_0__MigrationsSvcImpl__GenerateAlterSequence,

 //-----------------------------------------
 DataTypes_Extensions__System_DateTime,

 DataTypes_Extensions__System_DateOnly,

 DataTypes_Extensions__System_TimeOnly,

 DataTypes_Extensions__System_NullableDateTime,

 DataTypes_Extensions__System_NullableDateOnly,

 DataTypes_Extensions__System_NullableTimeOnly,

 DataTypes_Extensions__System_String,

 DataTypes_Extensions__System_NullableInt16,

 DataTypes_Extensions__System_NullableBoolean,

 //-----------------------------------------
 DbFunctions__DbCast,

 DbFunctions__DbMath,

 //----------------------------------------- core
 Core_ExceptionRecord,

 Core_ConnectionOptions,

 Core_ConnectionOptionsInitializer,

 Core_ValueInstaller,

 //----------------------------------------- core.sql
 Core_SQL__ExpressionUtils,

 Core_SQL__TestExpressionKind,

 Core_SQL__TestNullable,

 //-----------------------------------------
 Core_Engines_Dbms_FB_ConnectionInitializer,

 //-----------------------------------------
 Core_Engines_Dbms_FB_Common_Mirror__Convert_Code__STRING__BOOLEAN,

 Core_Engines_Dbms_FB_Common_Mirror__Convert_Code__STRING__TYPE_DATE,

 Core_Engines_Dbms_FB_Common_Mirror__Convert_Code__STRING__TYPE_TIME_as_TimeOnly,

 Core_Engines_Dbms_FB_Common_Mirror__Convert_Code__STRING__TIMESTAMP___D1,

 Core_Engines_Dbms_FB_Common_Mirror__Convert_Code__STRING__TIMESTAMP___D3,

 Core_Engines_Dbms_FB_Common_Mirror__Convert_Helper__DOUBLE__STRING,

 Core_Engines_Dbms_FB_Common_Mirror__Convert_Helper__ParserPart__STRING_DATE___D1,

 Core_Engines_Dbms_FB_Common_Mirror__Convert_Helper__ParserPart__STRING_DATE___D3,
 
 //-----------------------------------------
 Core_Engines_Dbms_FB_V03_0_0__ConnectionInitializer,

 Core_Engines_Dbms_FB_V03_0_0__DataTypeParser,

 //-----------------------------------------
 IscBase_EngineSvc__ConnectionInfo,

 IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d1,

 IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d3,

 //-----------------------------------------
 Common_EngineSvc__CommandParamereterNameBuilder__Error_NoPrefix,

 Common_EngineSvc__CommandParamereterNameBuilder__NameWithoutPrefix,

 Common_EngineSvc__CommandParamereterNameBuilder__NameWithPrefix,

 //-----------------------------------------
 Core_ValueCvt__Int32__Int16,

 Core_ValueCvt__Int64__Int16,

 Core_ValueCvt__Int64__Int32,

 Core_ValueCvt__Double__Int32,

 //-----------------------------------------
 Structure_CS_UTF16,

 Structure_NumericDigits_RW,

 Structure_SwitchToUnderlying,
};//enum ErrSourceID

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb

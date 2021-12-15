////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 14.05.2018.

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb{
////////////////////////////////////////////////////////////////////////////////
//enum ErrMessageID

enum ErrMessageID
{
 //----------------------------------------- Text parts
 text__not_avail__tag_style,

 //----------------------------------------- Common errors
 //Params: method name, arg name
 common_err__argument_is_null__2,

 //Params: method name, arg name
 common_err__argument_is_not_null__2,

 //Params: method name, arg name
 common_err__argument_is_empty__2,

 //Params: method name, arg name, argument value
 common_err__argument_is_negative__3,

 //Params: method name, arg name, arg value type, expected type
 common_err__bad_argument_type_4,

 //Params: method name, arg name, actual element count
 common_err__bad_argument_list_size_3,

 //Params: method name, arg name, actual element count, expected element count
 common_err__bad_argument_list_size_4,

 //NOT USED | Params: object name
 common_err__object_was_disposed__1,

 //NOT USED | Params: object name, method name
 common_err__object_was_disposed__cant_exec_method__2,

 //Params: feature name
 common_err__feature_not_supported__1,

 //Params: method name
 common_err__method_not_impl__1,

 //Params: method name, point
 common_err__method_not_impl__2,

 //Params: operation type, type1, arg1
 common_err__overflow_in_arithmetic_op1__3,

 //Params: operation type, type1, arg1, type2, arg2
 common_err__overflow_in_arithmetic_op2__5,

 //Params: operation type, type1, arg1, type2, arg2
 common_err__out_of_range_in_arithmetic_op2__5,

 //Params: index, element count
 common_err__index_out_of_range__2,

 common_err__empty_list_of_values__0,

 common_err__divide_by_zero__0,

 //Params: method name, point
 common_err__cant_alloc_new_array__overflow__2,

 //NOT USED | Params: table name, column name
 common_err__unk_column_name__2,

 //NOT USED | Params: table name, column index, column name, value sign
 common_err__invalid_column_value__4,

 //NOT USED | Params: table name, column index, column name, value type name, expected type name
 common_err__invalid_column_value_type__5,

 //NOT USED
 common_err__no_connection_object__0,

 //NOT USED | Params: connection object type name, expected type name
 common_err__unexpected_connection_object_type__2,

 //Params: connection state
 common_err__unexpected_connection_state_1,

 common_err__failed_to_read_connection_properties_0,

 common_err__connection_object_contains_empty_connection_string_0,

 common_err__no_source_for_load_connection_info_0,

 //NOT USED
 common_err__object_already_initialized_0,

 //NOT USED
 //Params: extension class name
 common_err__extension_not_found_1,

 //NOT USED
 //Params: member name
 common_err__cant_work_with_uninitialized_object_1,

 //Params: position
 common_err__zero_symbol_in_string_literal_1,

 //Params: dbms name
 common_err__unknown_dbms_name_1,

 //Params: dbms name, dbms version
 common_err__unsupported_dbms_version_2,

 //Params: dialect number
 common_err__unsupported_connection_dialect_1,

 common_err__empty_object_name_0,

 //Params: position, char code
 common_err__bad_symbol_in_unquoted_object_name_2,

 //Params: position, char code
 common_err__bad_symbol_in_quoted_object_name_2,

 //No params
 common_err__not_defined_cmd_parameter_prefix_0,

 //No params
 common_err__no_provider_configured_0,

 //No params
 common_err__multiple_provider_configured_0,

 //Params: source type, target type
 common_err__unsupported_datatypes_conversion_2,

 //Params: source type, target type
 common_err__cant_convert_value_between_types_2,

 //No params
 common_err__target_property_not_accept_null_value_0,

 //Params: ef record type, ef record field, column name
 common_err__failed_to_set_property_value_3,

 //Params: name, direction
 common_err__unexpected_command_param_direction_2,

 //Params: name
 common_err__no_command_param_value_1,

 //Params: method sign
 common_err__direct_call_of_linq_method_not_allowed_1,

 //Params: value name
 common_err__failed_to_process_value_1,

 common_err__overflow_in_number_scale_calculation_0,

 //Params: firstEntityType, secondEntityType, {keyValues}, {firstConflictingValue}, {secondConflictingValue}, columnName
 common_err__ConflictingRowValuesSensitive_6,

 //Params: firstEntityType, secondEntityType, {firstProperty}, {secondProperty}, columnName
 common_err__ConflictingRowValues_5,

 //Params: firstEntityType, secondEntityType, {keyValues}, {firstConflictingValue}, {secondConflictingValue}, columnName
 common_err__ConflictingOriginalRowValuesSensitive_6,

 //Params: firstEntityType, secondEntityType, {firstProperty}, {secondProperty}, columnName
 common_err__ConflictingOriginalRowValues_5,

 //Params: declaringType, method name, parameters
 common_err__type_not_support_method_3,

 //Params: method, new declaring type, new args list
 common_err__cant_remap_normal_method_3,

 //Params: method, new declaring type, new args list, new generic args
 common_err__cant_remap_generic_method_4,

 //Params: parameter name
 common_err__bad_cmd_parameter_name_format_1,

 //Params: parameter name
 common_err__bad_cmd_parameter_name_format__incorrect_prefix_1,

 //Params: annotation name
 common_err__unknown_annotation__1,

 //Params: annotation name, annotation value
 common_err__annotation_has_unknown_value__2,

 //Params: annotation name
 common_err__annotation_has_null_value__1,

 //Params: annotation name, actual value type
 common_err__annotation_has_value_with_unexpected_type__2,

 //Params: annotation name, actual value type, expected value type
 common_err__annotation_has_value_with_unexpected_type__3,

 //Params: annotation name, prev value, new value
 common_err__multiple_definition_of_annotation__3,

 //Params: strategy sign
 common_err__model_defines_incorrect_global_value_generation_strategy__1,

 //Params: strategy sign, declaring clr type, property name, property clr datatype name
 common_err__property_with_datatype_is_not_compatible_with_value_generation_strategy__4,

 //Params: strategy sign
 common_err__value_generation_strategy_cant_be_defined_at_model_level__1,

 //Params: entity name, prop name, first strategy sign, second strategy sign
 common_err__entity_property_has_conflict_of_value_generation_strategies__4,

 //-----------------------------------------------------------------------
 //Params: seq name
 dbms_err__fb__firebird_does_not_support_non_cyclic_sequence__1,

 //Params: bound name, seq name, allowed value
 dbms_err__fb__firebird_does_not_support_configuration_of_sequence_bound_value__3,

 dbms_err__fb__firebird_does_not_support_drop_identity_attribute_from_column__0,

 dbms_err__fb__firebird_does_not_support_add_identity_attribute_to_column__0,

 dbms_err__fb__firebird_does_not_support_renaming_of_tables__0,

 dbms_err__fb__firebird_does_not_support_renaming_of_sequences__0,

 dbms_err__fb__firebird_does_not_support_renaming_of_indexes__0,

 dbms_err__fb__firebird_does_not_support_schemas__0,

 //-----------------------------------------------------------------------

 //Params: entity name
 validation_err__failed_to_entity_validation_1,

 //Params: entity name, property name
 validation_err__failed_to_entity_property_validation_2,

 //-----------------------------------------------------------------------

 //Params: methodId
 sql_translator_err__method_not_supported_1,

 //Params: object type, member name
 sql_translator_err__member_not_supported_2,

 //Params: operator type
 sql_translator_err__unsupported_binary_operator_type_1,

 //Params: operator type, left type, right type
 sql_translator_err__unsupported_binary_operator_type_3,

 //Params: operator type
 sql_translator_err__unsupported_unary_operator_type_1,

 //Params: operator type, operandType, resultType
 sql_translator_err__unsupported_unary_operator_type_3,

 //Params: operation ID, operand clrType, result clrType
 sql_translator_err__cant_present_unary_operation_as_SqlUnaryExpression_3,

 //Params: operation ID, left clrType, right ClrType
 sql_translator_err__cant_present_binary_operation_as_SqlBinaryExpression_3,

 //Params: function name
 sql_translator_err__cant_present_function_as_SqlFunctionExpression_1,

 //-----------------------------------------------------------------------

 //Params: source type, target type
 sql_gen_err__unsupported_cast_as_between_types_2,

 //Params: cn dialect, member sign
 sql_gen_err__translation_of_member_not_supported_in_current_cn_dialect_2,

 //Params: cn dialect, sql type name (DECIMAL/NUMERIC), precision
 sql_gen_err__decimal_precision_not_supported_in_current_cn_dialect_3,

 //Params: value sql type
 sql_gen_err__definition_of_value_in_sql_not_supported__1,

 //Params: sql operator sign
 sql_gen_err__not_supported_sql_operator__1,

 //----------------------------------------- Migration SQL generation errors

 //Params: table name
 msql_gen_err__failed_to_generate_table_definition__1,

 //Params: table name, column name
 msql_gen_err__failed_to_generate_column_definition__2,

 msql_gen_err__computed_column_not_supported__0,

 //Params: table name, column name
 msql_gen_err__cant_find_type_mapping_for_column__2,

 //Params: default value CLR type
 msql_gen_err__cant_find_type_mapping_for_default_value__1,

 msql_gen_err__detected_multiple_definition_of_default_value__0,

 msql_gen_err__identity_column_cant_be_created_with_required_data_type__2,

 msql_gen_err__identity_column_cant_be_has_default_value__0,

 msql_gen_err__identity_column_cant_be_nullable__0,

 //Params: table name, fk name, principal table name
 msql_gen_err__failed_to_generate_fk_definition__3,

 //Params: column count, principal column count
 msql_gen_err__bad_fk_definition__different_size_of_column_lists__2,

 //Params: action id
 msql_gen_err__unknown_fk_referential_action__1,

 //Params: seq name
 msql_gen_err__failed_to_generate_create_sequence_statement__1,

 //Params: seq name
 msql_gen_err__failed_to_generate_restart_sequence_statement__1,

 //Params: seq name
 msql_gen_err__failed_to_generate_alter_sequence_statement__1,

 //Params: seq name, start value, increment value
 msql_gen_err__overflow_in_calculation_of_adjusted_sequence_start_value__3,

 //Params: seq name, actual ClrType, expected ClrType
 msql_gen_err__unexpected_sequence_ClrType__3,

 //Params: seq name, actual start value, min start value, max start value
 msql_gen_err__incorrect_sequence_start_value__4,

 //Params: old column table, new column table
 msql_gen_err__inconsistent_table_names_in_alter_column_operation__2,

 //Params: table name, new column name, old column name
 msql_gen_err__failed_to_generate_alter_column_statement__3,

 //Params: table name
 msql_gen_err__failed_to_generate_table_creation_script__1,

 //Params: column index, column name, actual table name, expected table name
 msql_gen_err__column_data_uses_incorrect_table_name__4,

 //Params: index name, table name
 msql_gen_err__failed_to_generate_create_index_statement__2,

 //Params: index name, table name
 msql_gen_err__bad_index_definition__multiple_data__2,

 //Params: index name, table name
 msql_gen_err__bad_index_definition__no_data__2,

 msql_gen_err__table_name_not_defined__0,

 //-----------------------------------------------------------------------

 //Params: clrType
 type_mapping_err__cant_map_clr_type_to_provider_data_type_1,

 //Params: clrType, baseTypeName
 type_mapping_err__cant_map_info_to_provider_data_type_2,

 //Params: store type name
 type_mapping_err__unknown_StoreTypeName_1,

 //Params: store type name, column sign
 type_mapping_err__unknown_StoreTypeName_2,

 //Params: actual name, expected name
 type_mapping_err__unexpected_StoreTypeName_2,

 //Params: actual name, expected name
 type_mapping_err__unexpected_StoreTypeNameBase_2,

 //Params: size
 type_mapping_err__unexpected_Size_1,

 type_mapping_err__not_defined_Size_0,

 //Params: size, max size
 type_mapping_err__too_large_Size_2,

 //Params: actual value, expected value
 type_mapping_err__unexpected_IsFixedLength_2,

 //Params: actual value, expected value
 type_mapping_err__unexpected_IsUnicode_2,

 //Params: actual type, expected type
 type_mapping_err__unexpected_ClrType_2,

 //Params: actual value, expected value
 type_mapping_err__unexpected_IsRowVersion_2,

 //Params: precision
 type_mapping_err__unexpected_Precision_1,

 type_mapping_err__not_defined_Precision_0,

 //Params: precision, max precision
 type_mapping_err__too_large_Precision_2,

 //Params: scale
 type_mapping_err__not_allowed_definition_of_Scale_without_Precision_1,

 //Params: scale
 type_mapping_err__unexpected_Scale_1,

 type_mapping_err__not_defined_Scale_0,

 //Params: scale, max scale
 type_mapping_err__too_large_Scale_2,

 //Params: property name, value1, value2
 type_mapping_err__multiple_definition_of_type_property_3,

 // Params: value, database format, min valid value, max valid value.
 type_mapping_err__cant_convert_TimeSpan_to_database_format__out_of_range__4,

 // Params: value, database format, min valid value, max valid value.
 type_mapping_err__cant_convert_database_value_to_TimeSpan__out_of_range__4,

 // Params: connection dialect, database type name
 type_mapping_err__cn_dialect_does_not_support_usage_of_type_in_DDL_query_2,

 // Params: datatype sign
 type_mapping_err__failed_to_parse_datatype_length_1,

 // Params: datatype sign
 type_mapping_err__failed_to_parse_datatype_precision_1,

 // Params: datatype sign
 type_mapping_err__failed_to_parse_datatype_scale_1,

 // Params: datatype sign
 type_mapping_err__too_large_length_of_datatype_1,

 // Params: datatype sign
 type_mapping_err__too_large_precision_of_datatype_1,

 // Params: datatype sign
 type_mapping_err__too_large_scale_of_datatype_1,

 type_mapping_err__incompleted_datatype_definition_0,

 // Params: datatype sign
 type_mapping_err__incompleted_datatype_definition_1,

 // Params: datatype sign
 type_mapping_err__bad_datatype_definition_1,

 // Params: datatype sign
 type_mapping_err__not_defined_charset_name_1,

 // Params: datatype sign
 type_mapping_err__not_defined_subtype_name_1,

 // Params: subtype
 type_mapping_err__unknown_blob_subtype_1,

 type_mapping_err__definition_of_blob_charset_allowed_only_for_subtype_text_0,

 // Params: datatype sign
 type_mapping_err__unexpected_data_at_end_of_datatype_definition_1,

 //-----------------------------------------------------------------------

 //Params: schema name, restriction name
 schema_err__data_provider_not_support_req_restriction_2,

 //NOT USED | Params: table id, table type
 schema_err__unknown_table_type__2,

 //NOT USED | Params: proc id, proc type
 schema_err__unknown_proc_type__2,

 //NOT USED | Params: catalog name, schema name, table name, column name
 schema_err__failed_to_build_column_info_4,

 //NOT USED | Params: catalog name, schema name, proc name, param name
 schema_err__failed_to_build_parameter_info_4,

 //NOT USED | Params: oledb type code, oledb column flags
 schema_err__failed_to_process_column_oledb_datatype_2,

 //NOT USED | Params: oledb type code, oledb (column) flags
 schema_err__failed_to_process_parameter_oledb_datatype_2,

 //NOT USED | Params: oledb datatype id
 schema_err__provider_datatype_not_supported_1,

 //NOT USED | Params: oledb parameter type
 schema_err__unknown_parameter_oledb_type_1,

 //NOT USED | Params: data type name
 schema_err__unknown_data_type_1,

 //-----------------------------------------------------------------------
 //Params: object type, member name
 local_eval_err__member_not_supported_2,

 //Params: node type
 local_eval_err__unary_operator_not_supported_1,

 //Params: node type, operand type
 local_eval_err__unary_operator_not_supported_2,

 //Params: node type, left type, right type
 local_eval_err__binary_operator_not_supported_3,

 //Params: method
 local_eval_err__method_not_supported_1,

 //Params: result type
 local_eval_err__unexpected_result_type_of_logical_expression_1,

 //Params: method, new args list
 local_eval_err__cant_remap_static_method_2,

 //Params: method, instance, new args list
 local_eval_err__cant_remap_instance_method_3,

 //Params: method, new args list, variants
 local_eval_err__ambiguous_remap_method_3,

 //Params: originalType, targetType, targetArguments
 local_eval_err__cant_remap_object_construction_3,

 //Params: first array length, second array length
 local_eval_err__comparison_of_arrays_with_different_length_not_supported_2,

 //Params: element index
 local_eval_err__failed_to_compare_element_of_arrays_1,

 //Params: element index, value type, required type
 local_eval_err__cant_convert_array_element_value_to_required_type_3,

 //-----------------------------------------------------------------------
 //NOT USED | Params: hr
 com_err__com_code_error_1,

 //-----------------------------------------------------------------------
 //NOT USED
 data_type_err__failed_to_build_data_type_sign_1,

 //-----------------------------------------------------------------------
 //Params: check point, offset
 cs_utf16_err__bad_sequence__2,

 //-----------------------------------------------------------------------
 //Params: source name, check point name, reason
 bug_check__generic_error_3,

 //Params: source name, check point name
 bug_check__deserialization__wrong_state_2,

 //NOT USED | Params: source name, object name
 bug_check__deserialization__null_obj_ptr_2,

 //Params: source name, prop name, item index
 bug_check__deserialization__null_item_ptr_3,

 //NOT USED | Params: catalog, schema, relation, field, actual dim number, expected dim number
 bug_check__array_err__unexpected_dim_number_6,

 //NOT USED | Params: metadata_name, prev_catalog, prev_schema, prev_relation, prev_field, next_catalog, next_schema, next_relation, next_field
 bug_check__array_err__bad_sort_of_schema_9,

 //NOT USED | Params: catalog, schema, relation, field, dimension number, lower bound, upper bound
 bug_check__array_err__bad_range_of_dimension_7,

 //NOT USED | Params: catalog, schema, relation, field
 bug_check__array_err__no_descr_4,

 //-----------------------------------------
 //Params: svc id
 bug_check__engine_svc_not_supported_1,

 //Params: svc id, interface name
 bug_check__engine_svc_not_supported_req_interface_2,

 //-----------------------------------------
 //Params: check place, check point, schema name, row count
 bug_check__schema_contains_unexpected_row_count_4,

 //Params: check place, check point, schema name, restriction name, restriction number
 bug_check__incorrect_schema_restriction_number_5,

 //-----------------------------------------
 //Params: operatorType, resultType, expectedBaseType, leftType, rightType
 bug_check__unexpected_result_type_of_binary_operator_5,

 //-----------------------------------------
 //Params: type name, method name, parameters, bind flags
 bug_check__bind_to_type_method__not_found_4,

 //Params: type name, method name, parameters, bind flags, expected return type, actual return type
 bug_check__bind_to_type_method__bad_return_type_6,

 //Params: type name, nested type name, bind flags
 bug_check__get_nested_type__not_found_3,

 //-----------------------------------------------------------------------

 //Params: enode sign, argument types list
 bug_check__sql_enode__unsupported_arg_types__2,

};//enum ErrMessageID

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb

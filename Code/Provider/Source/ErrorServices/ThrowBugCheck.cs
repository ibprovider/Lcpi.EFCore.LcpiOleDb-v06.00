////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 14.05.2018.
using System;
using System.Diagnostics;
using System.Data;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

using ResultSetMapping
 =Microsoft.EntityFrameworkCore.Update.ResultSetMapping;

using SqlExpression
 =Microsoft.EntityFrameworkCore.Query.SqlExpressions.SqlExpression;

using SqlFunctionExpression
 =Microsoft.EntityFrameworkCore.Query.SqlExpressions.SqlFunctionExpression;

using com_lib
 =lcpi.lib.com;

using exception_lib
 =lcpi.lib.structure.exceptions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_MethodId
 =Structure.Structure_MethodId;

using Structure_ADP
 =Structure.Structure_ADP;

////////////////////////////////////////////////////////////////////////////////
//class ThrowBugCheck

static class ThrowBugCheck
{
 public static void generic_error(ErrSourceID errSrcID,
                                  string      place,
                                  string      point,
                                  string      reason)
 {
  //[2020-10-13] Tested.

  Debug.Assert(!string.IsNullOrEmpty(place));
  Debug.Assert(!string.IsNullOrEmpty(point));
  Debug.Assert(!string.IsNullOrEmpty(reason));

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.bug_check__generic_error_3);

  errRec
   .push(place)
   .push(point)
   .push(reason);

  ThrowSysError.invalid_operation
   (errRec);
 }//generic_error

 //-----------------------------------------------------------------------
 public static void not_empty_argument_list(ErrSourceID errSrcID,
                                            string      place,
                                            string      point,
                                            int         count)
 {
  Debug.Assert(!string.IsNullOrEmpty(place));
  Debug.Assert(!string.IsNullOrEmpty(point));

  var msg
   =string.Format
      ("not empty argument list ({0})",
       count);

  generic_error
   (errSrcID,
    place,
    point,
    msg);
 }//not_empty_argument_list

 //-----------------------------------------------------------------------
 public static void incorrect_call_of_method(ErrSourceID errSrcID,
                                             string      place,
                                             string      point)
 {
  //[2021-04-28] Tested.

  Debug.Assert(!string.IsNullOrEmpty(place));
  Debug.Assert(!string.IsNullOrEmpty(point));

  generic_error
   (errSrcID,
    place,
    point,
    "incorrect call of method");
 }//incorrect_call_of_method

 //-----------------------------------------------------------------------
 public static void deserialization__wrong_state(ErrSourceID errSrcID,
                                                 string      check_point)
 {
  //[2020-10-13] Tested.

  Debug.Assert(!string.IsNullOrEmpty(check_point));

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.COR_E_SERIALIZATION,
      errSrcID,
      ErrMessageID.bug_check__deserialization__wrong_state_2);

  errRec
   .push(errSrcID)
   .push(check_point);

  exception_lib.throw_error.serialization
   (errRec,
    null);
 }//deserialization__wrong_state

 //-----------------------------------------------------------------------
 public static void deserialization__null_obj_ptr(ErrSourceID errSrcID,
                                                  string      prop_name)
 {
  //[2020-10-13] Tested.

  Debug.Assert(!string.IsNullOrEmpty(prop_name));

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.COR_E_SERIALIZATION,
      errSrcID,
      ErrMessageID.bug_check__deserialization__null_obj_ptr_2);

  errRec
   .push(errSrcID)
   .push(prop_name);

  exception_lib.throw_error.serialization
   (errRec,
    null);
 }//deserialize__null_obj_ptr

 //-----------------------------------------------------------------------
 public static void deserialization__null_item_ptr(ErrSourceID errSrcID,
                                                   string      prop_name,
                                                   int         index)
 {
  //[2020-10-13] Tested.

  Debug.Assert(!string.IsNullOrEmpty(prop_name));

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.COR_E_SERIALIZATION,
      errSrcID,
      ErrMessageID.bug_check__deserialization__null_item_ptr_3);

  errRec
   .push(errSrcID)
   .push(prop_name)
   .push(index);

  exception_lib.throw_error.serialization
   (errRec,
    null);
 }//deserialization__null_item_ptr

 //-----------------------------------------------------------------------
 public static void engine_svc_not_supported(ErrSourceID errSrcID,
                                             Guid        svcID)
 {
  //[2020-10-18] Tested.

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.bug_check__engine_svc_not_supported_1);

  errRec.push(svcID);

  ThrowSysError.invalid_operation
   (errRec);
 }//engine_svc_not_supported

 //-----------------------------------------------------------------------
 public static void engine_svc_not_supported_req_interface<T>(ErrSourceID errSrcID,
                                                              Guid        svcID)
 {
  //[2020-10-18] Tested.

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.bug_check__engine_svc_not_supported_req_interface_2);

  errRec
   .push(svcID)
   .push(typeof(T).Extension__BuildHumanName());

  ThrowSysError.invalid_operation(errRec);
 }//engine_svc_not_supported_req_interface

 //-----------------------------------------------------------------------
 public static void schema_contains_unexpected_row_count
                                           (ErrSourceID errSrcID,
                                            string      place,
                                            string      point,
                                            string      schemaName,
                                            int         rowCount)
 {
  //[2020-10-13] Tested.

  Debug.Assert(!string.IsNullOrEmpty(place));
  Debug.Assert(!string.IsNullOrEmpty(point));
  Debug.Assert(!string.IsNullOrEmpty(schemaName));

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.bug_check__schema_contains_unexpected_row_count_4);

  exc
   .push(place)
   .push(point)
   .push(schemaName)
   .push(rowCount)
   .raise();
 }//schema_contains_unexpected_row_count

 //-----------------------------------------------------------------------
 public static void incorrect_schema_restriction_number
                                           (ErrSourceID errSrcID,
                                            string      place,
                                            string      point,
                                            string      schemaName,
                                            string      restrictionName,
                                            int         restrictionNumber)
 {
  //[2021-04-29] Tested.

  Debug.Assert(!string.IsNullOrEmpty(place));
  Debug.Assert(!string.IsNullOrEmpty(point));
  Debug.Assert(!string.IsNullOrEmpty(schemaName));

  var exc
   =new LcpiOleDb__DataToolException
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.bug_check__incorrect_schema_restriction_number_5);

  exc
   .push(place)
   .push(point)
   .push(schemaName)
   .push(restrictionName)
   .push(restrictionNumber)
   .raise();
 }//incorrect_schema_restriction_number

 //-----------------------------------------------------------------------
 public static void value_is_null(ErrSourceID errSrcID,
                                  string      place,
                                  string      point,
                                  string      valueName)
 {
  //[2020-10-21] Tested.

  Debug.Assert(!string.IsNullOrEmpty(place));
  Debug.Assert(!string.IsNullOrEmpty(point));
  Debug.Assert(!string.IsNullOrEmpty(valueName));

  string reason
   =string.Format
     ("value [{0}] is null",
      valueName);

  generic_error
   (errSrcID,
    place,
    point,
    reason);
 }//value_is_null

 //-----------------------------------------------------------------------
 public static void value_is_empty(ErrSourceID errSrcID,
                                   string      place,
                                   string      point,
                                   string      valueName)
 {
  //[2020-11-30] Tested.

  Debug.Assert(!string.IsNullOrEmpty(place));
  Debug.Assert(!string.IsNullOrEmpty(point));
  Debug.Assert(!string.IsNullOrEmpty(valueName));

  string reason
   =string.Format
     ("value [{0}] is empty",
      valueName);

  generic_error
   (errSrcID,
    place,
    point,
    reason);
 }//value_is_empty

 //-----------------------------------------------------------------------
 public static void unexpected_value_type(ErrSourceID errSrcID,
                                          string      place,
                                          string      point,
                                          string      valueName,
                                          System.Type valueType)
 {
  //[2021-11-29] Tested.

  Debug.Assert(!string.IsNullOrEmpty(place));
  Debug.Assert(!string.IsNullOrEmpty(point));
  Debug.Assert(!string.IsNullOrEmpty(valueName));
  Debug.Assert(!Object.ReferenceEquals(valueType,null));

  string reason
   =string.Format
     ("unexpected value [{0}] type: {1}",
      valueName,
      valueType.Extension__BuildHumanName());

  generic_error
   (errSrcID,
    place,
    point,
    reason);
 }//unexpected_value_type

 //-----------------------------------------------------------------------
 public static void bad_value_type(ErrSourceID errSrcID,
                                   string      place,
                                   string      point,
                                   string      valueName,
                                   Type        valueType,
                                   Type        expectedType)
 {
  //[2020-10-21] Tested.

  Debug.Assert(!string.IsNullOrEmpty(place));
  Debug.Assert(!string.IsNullOrEmpty(point));
  Debug.Assert(!string.IsNullOrEmpty(valueName));
  Debug.Assert(!Object.ReferenceEquals(expectedType,null));
  Debug.Assert(!Object.ReferenceEquals(valueType,null));

  string reason
   =string.Format
     ("bad value [{0}] type: {1}. Expected type: {2}",
      valueName,
      valueType.Extension__BuildHumanName(),
      expectedType.Extension__BuildHumanName());

  generic_error
   (errSrcID,
    place,
    point,
    reason);
 }//bad_value_type

 //-----------------------------------------------------------------------
 public static void unexpected_value<T>(ErrSourceID errSrcID,
                                        string      place,
                                        string      point,
                                        string      valueName,
                                        T           value)
 {
  Debug.Assert(!string.IsNullOrEmpty(place));
  Debug.Assert(!string.IsNullOrEmpty(point));
  Debug.Assert(!string.IsNullOrEmpty(valueName));

  string reason
   =string.Format
     ("unexpected value of [{0}]: [{1}]",
      valueName,
      value);

  generic_error
   (errSrcID,
    place,
    point,
    reason);
 }//unexpected_value

 //-----------------------------------------------------------------------
 public static void unexpected_type(ErrSourceID errSrcID,
                                    string      place,
                                    string      point,
                                    Type        type)
 {
  //[2020-12-23] Tested.

  Debug.Assert(!string.IsNullOrEmpty(place));
  Debug.Assert(!string.IsNullOrEmpty(point));
  Debug.Assert(!Object.ReferenceEquals(type,null));

  string reason
   =string.Format
     ("unexpected type: {0}",
      type.Extension__BuildHumanName());

  generic_error
   (errSrcID,
    place,
    point,
    reason);
 }//unexpected_type

 //-----------------------------------------------------------------------
 public static void unexpected_operator_type(ErrSourceID     errSrcID,
                                             string          place,
                                             string          point,
                                             ExpressionType  operatorType)
 {
  //[2020-12-23] Tested.

  Debug.Assert(!string.IsNullOrEmpty(place));
  Debug.Assert(!string.IsNullOrEmpty(point));

  string reason
   =string.Format
     ("unexpected operator type: {0}",
      operatorType);

  generic_error
   (errSrcID,
    place,
    point,
    reason);
 }//unexpected_operator_type

 //-----------------------------------------------------------------------
 public static void TypeMapping_ClrType_Is_Null(ErrSourceID errSrcID,
                                                string      place,
                                                string      point)
 {
  Debug.Assert(!string.IsNullOrEmpty(place));
  Debug.Assert(!string.IsNullOrEmpty(point));

  generic_error
   (errSrcID,
    place,
    point,
    "TypeMapping.ClrType is null");
 }//TypeMapping_ClrType_Is_Null

 //-----------------------------------------------------------------------
 public static void Unexpected_SqlExpression_Value_Type
                                           (ErrSourceID errSrcID,
                                            string      place,
                                            string      point,
                                            System.Type type)
 {
  Debug.Assert(!string.IsNullOrEmpty(place));
  Debug.Assert(!string.IsNullOrEmpty(point));
  Debug.Assert(!Object.ReferenceEquals(type,null));

  string reason
   =string.Format
     ("unexpected sql expression value type: {0}",
      type.Extension__BuildHumanName());

  generic_error
   (errSrcID,
    place,
    point,
    reason);
 }//Unexpected_SqlExpression_Value_Type

 //-----------------------------------------------------------------------
 public static void SqlConstantExpression_contains_not_null_value
                                           (ErrSourceID errSrcID,
                                            string      place,
                                            string      point)
 {
  Debug.Assert(!string.IsNullOrEmpty(place));
  Debug.Assert(!string.IsNullOrEmpty(point));

  generic_error
   (errSrcID,
    place,
    point,
    "SqlConstantExpression contains not null value");
 }//SqlConstantExpression_contains_not_null_value

 //-----------------------------------------------------------------------
 public static void Unexpected_SqlExpression_Class_Type
                                           (ErrSourceID errSrcID,
                                            string      place,
                                            string      point,
                                            System.Type type)
 {
  Debug.Assert(!string.IsNullOrEmpty(place));
  Debug.Assert(!string.IsNullOrEmpty(point));
  Debug.Assert(!Object.ReferenceEquals(type,null));

  string reason
   =string.Format
     ("unexpected sql expression class type: {0}",
      type.Extension__BuildHumanName());

  generic_error
   (errSrcID,
    place,
    point,
    reason);
 }//Unexpected_SqlExpression_Class_Type

 //-----------------------------------------------------------------------
 public static void Unexpected_Expression_NodeType(ErrSourceID    errSrcID,
                                                   string         place,
                                                   string         point,
                                                   ExpressionType nodeType)
 {
  Debug.Assert(!string.IsNullOrEmpty(place));
  Debug.Assert(!string.IsNullOrEmpty(point));

  string reason
   =string.Format
     ("unexpected expression node type: {0}",
      nodeType);

  generic_error
   (errSrcID,
    place,
    point,
    reason);
 }//Unexpected_Expression_NodeType

 //-----------------------------------------------------------------------
 public static void ModificationCommandBatch__unexpected_ResultSetMapping
                                           (ErrSourceID      errSrcID,
                                            string           place,
                                            string           point,
                                            int              commandIndex,
                                            string           commandText,
                                            ResultSetMapping resultSetMapping)
 {
  //[2020-10-18] Tested.

  Debug.Assert(!string.IsNullOrEmpty(place));
  Debug.Assert(!string.IsNullOrEmpty(point));
  Debug.Assert(commandIndex>=0);

  string reason
   =string.Format
     ("unexpected result set mapping: {2}. "
     +"Command text [{0}]: [{1}]",
      commandIndex,
      commandText,
      resultSetMapping);

  generic_error
   (errSrcID,
    place,
    point,
    reason);
 }//ModificationCommandBatch__unexpected_ResultSetMapping

 //-----------------------------------------------------------------------
 public static void ModificationCommandBatch__found_a_read_op
                                           (ErrSourceID         errSrcID,
                                            string              place,
                                            string              point,
                                            int                 commandIndex,
                                            string              commandText,
                                            string              entryName,
                                            string              propertyName)
 {
  //[2020-10-13] Tested.

  Debug.Assert(!string.IsNullOrEmpty(place));
  Debug.Assert(!string.IsNullOrEmpty(point));
  Debug.Assert(commandIndex>=0);
  Debug.Assert(!string.IsNullOrEmpty(entryName));
  Debug.Assert(!string.IsNullOrEmpty(propertyName));

  string reason
   =string.Format
     ("found a read operation. "
     +"Command text [{0}]: [{1}]. "
     +"Name of entry property: [{2}].[{3}]",
      commandIndex,
      commandText,
      entryName,
      propertyName);

  generic_error
   (errSrcID,
    place,
    point,
    reason);
 }//ModificationCommandBatch__found_a_read_op

 //-----------------------------------------------------------------------
 public static void ModificationCommandBatch__we_not_expected_result_set
                                           (ErrSourceID errSrcID,
                                            string      place,
                                            string      point,
                                            int         commandIndex,
                                            string      commandText,
                                            int         columnCount)
 {
  //[2020-10-13] Tested.

  Debug.Assert(!string.IsNullOrEmpty(place));
  Debug.Assert(!string.IsNullOrEmpty(point));
  Debug.Assert(commandIndex>=0);
  Debug.Assert(columnCount>0);

  string reason
   =string.Format
     ("we not expected result set. Number of columns: {2}. "
     +"Command text [{0}]: [{1}]",
      commandIndex,
      commandText,
      columnCount);

  generic_error
   (errSrcID,
    place,
    point,
    reason);
 }//ModificationCommandBatch__we_not_expected_result_set

 //-----------------------------------------------------------------------
 public static void ModificationCommandBatch__unexpected_parameter_direction
                                           (ErrSourceID        errSrcID,
                                            string             place,
                                            string             point,
                                            int                commandIndex,
                                            string             commandText,
                                            string             parameterName,
                                            ParameterDirection parameterDirection)
 {
  //[2020-10-13] Tested.

  Debug.Assert(!string.IsNullOrEmpty(place));
  Debug.Assert(!string.IsNullOrEmpty(point));
  Debug.Assert(commandIndex>=0);

  string reason
   =string.Format
     ("unexpected parameter direction [{2}]: {3}. "
     +"Command text [{0}]: [{1}]",
      commandIndex,
      commandText,
      parameterName,
      parameterDirection);

  generic_error
   (errSrcID,
    place,
    point,
    reason);
 }//ModificationCommandBatch__unexpected_parameter_direction

 //-----------------------------------------------------------------------
 public static void LocalEvalErr__mutation_of_expression
                                           (ErrSourceID errSrcID,
                                            string      place,
                                            string      point,
                                            Expression  oldExpression,
                                            Expression  newExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(oldExpression,null));

  static string localBuildESign(Expression e)
  {
   if(Object.ReferenceEquals(e,null))
    return "#NULL";

   return e.ToString();
  }//localBuildESign

  string oldESign
   =localBuildESign(oldExpression);

  string newESign
   =localBuildESign(newExpression);

  string reason
   =string.Format
     ("detected mutation of expression [{0}]. New expression is [{1}]",
      oldESign,
      newESign);

  generic_error
   (errSrcID,
    place,
    point,
    reason);
 }//LocalEvalErr__mutation_of_expression

 //-----------------------------------------------------------------------
 public static void LocalEvalErr__mutation__null_ptr_to_new_expression
                                           (ErrSourceID errSrcID,
                                            string      place,
                                            string      point,
                                            Expression  oldExpression)
 {
  // [2020-10-16] Tested.

  Debug.Assert(!Object.ReferenceEquals(oldExpression,null));

  string reason
   =string.Format
     ("detected mutation of expression [{0}]. New expression is null",
      oldExpression.ToString());

  generic_error
   (errSrcID,
    place,
    point,
    reason);
 }//LocalEvalErr__mutation__null_ptr_to_new_expression

 //-----------------------------------------------------------------------
 public static void LocalEvalErr__unsupported_conversion
                                           (ErrSourceID errSrcID,
                                            string      place,
                                            string      point,
                                            System.Type sourceType,
                                            System.Type targetType)
 {
  Debug.Assert(!Object.ReferenceEquals(sourceType,null));
  Debug.Assert(!Object.ReferenceEquals(targetType,null));

  string reason
   =string.Format
     ("unsupported local conversion from [{0}] to [{1}]",
      sourceType.Extension__BuildHumanName(),
      targetType.Extension__BuildHumanName());

  generic_error
   (errSrcID,
    place,
    point,
    reason);
 }//LocalEvalErr__unsupported_conversion

 //-----------------------------------------------------------------------
 public static void LocalEvalErr__unsupported_method
                                           (ErrSourceID        errSrcID,
                                            string             place,
                                            string             point,
                                            Structure_MethodId methodId)
 {
  Debug.Assert(!Object.ReferenceEquals(methodId,null));

  string reason
   =string.Format
     ("unsupported local method {0}",
      methodId.ToString());

  generic_error
   (errSrcID,
    place,
    point,
    reason);
 }//LocalEvalErr__unsupported_conversion

 //-----------------------------------------------------------------------
 public static void LocalEvalErr__mutation__changed_result_type_of_expression
                                           (ErrSourceID errSrcID,
                                            string      place,
                                            string      point,
                                            Expression  oldExpression,
                                            Expression  newExpression)
 {
  // [2020-10-16] Tested.

  Debug.Assert(!Object.ReferenceEquals(oldExpression,null));
  Debug.Assert(!Object.ReferenceEquals(newExpression,null));

  string reason
   =string.Format
     ("detected mutation of expression [{0}][result type: {1}]. "
     +"New expression [{2}] has result type {3}",
      oldExpression.ToString(),
      oldExpression.Type.Extension__BuildHumanName(),
      newExpression.ToString(),
      newExpression.Type.Extension__BuildHumanName());

  generic_error
   (errSrcID,
    place,
    point,
    reason);
 }//LocalEvalErr__mutation__changed_result_type_of_expression

 //-----------------------------------------------------------------------
 public static void LocalEvalErr__mutation__changed_node_type_of_expression
                                           (ErrSourceID errSrcID,
                                            string      place,
                                            string      point,
                                            Expression  oldExpression,
                                            Expression  newExpression)
 {
  // [2020-10-16] Tested.

  Debug.Assert(!Object.ReferenceEquals(oldExpression,null));
  Debug.Assert(!Object.ReferenceEquals(newExpression,null));

  string reason
   =string.Format
     ("detected mutation of expression [{0}][node type: {1}]. "
     +"New expression [{2}] has node type {3}",
      oldExpression.ToString(),
      oldExpression.NodeType,
      newExpression.ToString(),
      newExpression.NodeType);

  generic_error
   (errSrcID,
    place,
    point,
    reason);
 }//LocalEvalErr__mutation__changed_node_type_of_expression

 //-----------------------------------------------------------------------
 public static void UnexpectedResultTypeOfBinaryOperator
                                           (ErrSourceID    errSrcID,
                                            ExpressionType operationType,
                                            Type           resultType,
                                            Type           expectedBaseType,
                                            Type           leftType,
                                            Type           rightType)
 {
  //[2020-12-23] NOT USED

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.bug_check__unexpected_result_type_of_binary_operator_5);

  errRec
   .push(operationType)
   .push(resultType)
   .push(expectedBaseType)
   .push(leftType)
   .push(rightType);

  ThrowSysError.invalid_operation
   (errRec);
 }//UnexpectedResultTypeOfBinaryOperator

 //-----------------------------------------------------------------------
 public static void BindToTypeMethod__NotFound
                                           (ErrSourceID  errSrcID,
                                            Type         type,
                                            string       name,
                                            Type[]       parameters,
                                            BindingFlags bindFlags)
 {
  Debug.Assert(!Object.ReferenceEquals(type,null));
  Debug.Assert(!Object.ReferenceEquals(name,null));

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.bug_check__bind_to_type_method__not_found_4);

  errRec
   .push(type)
   .push(name)
   .push(Structure_ADP.BuildParamsSign(parameters))
   .push(bindFlags);

  ThrowSysError.invalid_operation
   (errRec);
 }//BindToTypeMethod__NotFound

 //-----------------------------------------------------------------------
 public static void BindToTypeMethod__BadReturnType
                                           (ErrSourceID  errSrcID,
                                            Type         type,
                                            string       name,
                                            Type[]       parameters,
                                            BindingFlags bindFlags,
                                            Type         expectedReturnType,
                                            Type         actualReturnType)
 {
  Debug.Assert(!Object.ReferenceEquals(type,null));
  Debug.Assert(!Object.ReferenceEquals(name,null));

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.bug_check__bind_to_type_method__bad_return_type_6);

  errRec
   .push(type)
   .push(name)
   .push(Structure_ADP.BuildParamsSign(parameters))
   .push(bindFlags)
   .push(expectedReturnType)
   .push(actualReturnType);

  ThrowSysError.invalid_operation
   (errRec);
 }//BindToTypeMethod__BadReturnType

 //-----------------------------------------------------------------------
 public static void GetNestedType__NotFound(ErrSourceID  errSrcID,
                                            Type         type,
                                            string       name,
                                            BindingFlags bindFlags)
 {
  Debug.Assert(!Object.ReferenceEquals(type,null));
  Debug.Assert(!Object.ReferenceEquals(name,null));

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.bug_check__get_nested_type__not_found_3);

  errRec
   .push(type)
   .push(name)
   .push(bindFlags);

  ThrowSysError.invalid_operation
   (errRec);
 }//GetNestedType__NotFound

 //-----------------------------------------------------------------------
 public static void SqlENode__UnsupportedArgTypes
                                           (ErrSourceID            errSrcID,
                                            string                 sqlENodeSign,
                                            params SqlExpression[] parameters)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlENodeSign,null));
  Debug.Assert(!Object.ReferenceEquals(parameters,null));

  Debug.Assert(sqlENodeSign.Length>0);

  //--------------------------
  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.bug_check__sql_enode__unsupported_arg_types__2);

  errRec
   .push(sqlENodeSign);

  //--------------------------
  {
   var sb=new StringBuilder();

   var sep="";

   foreach(var e in parameters)
   {
    Debug.Assert(!Object.ReferenceEquals(e,null));
    Debug.Assert(!Object.ReferenceEquals(e.Type,null));
    Debug.Assert(!Object.ReferenceEquals(e.TypeMapping,null));
    Debug.Assert(!Object.ReferenceEquals(e.TypeMapping.ClrType,null));

    sb.Append(sep);

    var clrType=e.TypeMapping.ClrType.Extension__UnwrapMappingClrType();

    Debug.Assert(!Object.ReferenceEquals(clrType,null));

    sb.Append(clrType.Extension__BuildHumanName());

    sep=", ";
   }//foreach

   errRec.push(sb.ToString());
  }//local

  //--------------------------
  ThrowSysError.invalid_operation
   (errRec);
 }//SqlENode__UnsupportedArgTypes

 //-----------------------------------------------------------------------
 public static void SqlENode__UnsupportedArgTypes
                                           (ErrSourceID          errSrcID,
                                            string               sqlENodeSign,
                                            params System.Type[] parameterTypes)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlENodeSign,null));
  Debug.Assert(!Object.ReferenceEquals(parameterTypes,null));

  Debug.Assert(sqlENodeSign.Length>0);

  //--------------------------
  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.bug_check__sql_enode__unsupported_arg_types__2);

  errRec
   .push(sqlENodeSign);

  errRec
   .push(Structure_ADP.BuildParamsSign(parameterTypes));

  //--------------------------
  ThrowSysError.invalid_operation
   (errRec);
 }//SqlENode__UnsupportedArgTypes

 //-----------------------------------------------------------------------
 public static void No_TypeMapping(ErrSourceID           errSrcID,
                                   string                place,
                                   string                point)
 {
  // [2021-10-22] Tested.

  Debug.Assert(!Object.ReferenceEquals(place,null));
  Debug.Assert(!Object.ReferenceEquals(point,null));

  var msg
   ="no TypeMapping information";

  generic_error
   (errSrcID,
    place,
    point,
    msg);
 }//No_TypeMapping

 //-----------------------------------------------------------------------
 public static void No_TypeMapping_ClrType(ErrSourceID           errSrcID,
                                           string                place,
                                           string                point)
 {
  // [2021-10-22] Tested.

  Debug.Assert(!Object.ReferenceEquals(place,null));
  Debug.Assert(!Object.ReferenceEquals(point,null));

  var msg
   ="no TypeMapping.ClrType information";

  generic_error
   (errSrcID,
    place,
    point,
    msg);
 }//No_TypeMapping_ClrType

 //-----------------------------------------------------------------------
 public static void UnknownParserResultCode<T_CODE>(ErrSourceID errSrcID,
                                                    string      place,
                                                    string      point,
                                                    T_CODE      code)
 {
  // [2021-10-22] Tested.

  Debug.Assert(!Object.ReferenceEquals(place,null));
  Debug.Assert(!Object.ReferenceEquals(point,null));

  var msg
   =string.Format
     ("unknown parser result code [{0}]",
      code);

  generic_error
   (errSrcID,
    place,
    point,
    msg);
 }//UnknownParserResultCode

 //-----------------------------------------------------------------------
 public static void UnknownDataTypeID<T_ID>(ErrSourceID errSrcID,
                                            string      place,
                                            string      point,
                                            T_ID        dataTypeID)
 {
  // [2021-10-22] Tested.

  Debug.Assert(!Object.ReferenceEquals(place,null));
  Debug.Assert(!Object.ReferenceEquals(point,null));

  var msg
   =string.Format
     ("unknown data type id [{0}]",
      dataTypeID);

  generic_error
   (errSrcID,
    place,
    point,
    msg);
 }//UnknownDataTypeID

 //-----------------------------------------------------------------------
 public static void UnknownBlobSubTypeID<T_ID>(ErrSourceID errSrcID,
                                               string      place,
                                               string      point,
                                               T_ID        blobSubTypeID)
 {
  // [2021-10-22] Tested.

  Debug.Assert(!Object.ReferenceEquals(place,null));
  Debug.Assert(!Object.ReferenceEquals(point,null));

  var msg
   =string.Format
     ("unknown blob subtype id [{0}]",
      blobSubTypeID);

  generic_error
   (errSrcID,
    place,
    point,
    msg);
 }//UnknownBlobSubTypeID

 //-----------------------------------------------------------------------
 public static void ColumnHasMultipleVGS(ErrSourceID errSrcID,
                                         string      place,
                                         string      point,
                                         string      tableName,
                                         string      columnName)
 {
  // [2021-11-22] Tested.

  Debug.Assert(!Object.ReferenceEquals(place,null));
  Debug.Assert(!Object.ReferenceEquals(point,null));
  Debug.Assert(!Object.ReferenceEquals(tableName,null));
  Debug.Assert(!Object.ReferenceEquals(columnName,null));

  var msg
   =string.Format
     ("column [{0}].[{1}] has multiple value generation strategies",
      tableName,
      columnName);

  generic_error
   (errSrcID,
    place,
    point,
    msg);
 }//ColumnHasMultipleVGS

 //-----------------------------------------------------------------------
 public static void ConventionErr__MultipleConventionsForReplacing
                            (ErrSourceID errSrcID,
                             string      place,
                             string      point,
                             System.Type conventionType,
                             System.Type newConventionImplementationType,
                             System.Type firstExistConventionType,
                             System.Type secondExistConventionType)
 {
  // [2021-11-22] Tested.

  Debug.Assert(!Object.ReferenceEquals(place,null));
  Debug.Assert(!Object.ReferenceEquals(point,null));

  Debug.Assert(!Object.ReferenceEquals(conventionType,null));
  Debug.Assert(!Object.ReferenceEquals(newConventionImplementationType,null));
  Debug.Assert(!Object.ReferenceEquals(firstExistConventionType,null));
  Debug.Assert(!Object.ReferenceEquals(secondExistConventionType,null));

  //Expected
  Debug.Assert(conventionType.IsAssignableFrom(newConventionImplementationType));
  Debug.Assert(conventionType.IsAssignableFrom(firstExistConventionType));
  Debug.Assert(conventionType.IsAssignableFrom(secondExistConventionType));

  //Expected
  Debug.Assert(firstExistConventionType.IsAssignableFrom(newConventionImplementationType));
  Debug.Assert(secondExistConventionType.IsAssignableFrom(newConventionImplementationType));

  //--------------------------------------------------
  var msg
   =string.Format
     ("Convention [{0}] can't be replaced to implementation [{1}]. "
     +"Multiple conventions were found. "
     +"Type of first convention: [{2}]. "
     +"Type of second convention: [{3}]",
      conventionType.Extension__BuildHumanName(),
      newConventionImplementationType.Extension__BuildHumanName(),
      firstExistConventionType.Extension__BuildHumanName(),
      secondExistConventionType.Extension__BuildHumanName());

  generic_error
   (errSrcID,
    place,
    point,
    msg);
 }//ConventionErr__MultipleConventionsForReplacing

 //-----------------------------------------------------------------------
 public static void ConventionErr__NoConventionForReplacing
                            (ErrSourceID errSrcID,
                             string      place,
                             string      point,
                             System.Type conventionType,
                             System.Type newConventionImplementationType)
 {
  // [2021-11-22] Tested.

  Debug.Assert(!Object.ReferenceEquals(place,null));
  Debug.Assert(!Object.ReferenceEquals(point,null));

  Debug.Assert(!Object.ReferenceEquals(conventionType,null));
  Debug.Assert(!Object.ReferenceEquals(newConventionImplementationType,null));

  //Expected
  Debug.Assert(conventionType.IsAssignableFrom(newConventionImplementationType));

  //--------------------------------------------------
  var msg
   =string.Format
     ("No instance of convention [{0}] for replacing by implementation [{1}]",
      conventionType.Extension__BuildHumanName(),
      newConventionImplementationType.Extension__BuildHumanName());

  generic_error
   (errSrcID,
    place,
    point,
    msg);
 }//ConventionErr__NoConventionForReplacing

 //-----------------------------------------------------------------------
 public static void ConventionErr__ConventionAlreadyDefined
                            (ErrSourceID errSrcID,
                             string      place,
                             string      point,
                             System.Type conventionType,
                             System.Type newConventionImplementationType,
                             System.Type existConventionType)
 {
  // [2021-11-22] Tested.

  Debug.Assert(!Object.ReferenceEquals(place,null));
  Debug.Assert(!Object.ReferenceEquals(point,null));

  Debug.Assert(!Object.ReferenceEquals(conventionType,null));
  Debug.Assert(!Object.ReferenceEquals(newConventionImplementationType,null));
  Debug.Assert(!Object.ReferenceEquals(existConventionType,null));

  //Expected
  Debug.Assert(conventionType.IsAssignableFrom(newConventionImplementationType));
  Debug.Assert(conventionType.IsAssignableFrom(existConventionType));

  //Expected
  Debug.Assert(existConventionType.IsAssignableFrom(newConventionImplementationType));

  //--------------------------------------------------
  var msg
   =string.Format
     ("Convention [{0}] can't be defined as [{1}]. "
     +"Implementation was already defined as [{2}]",
      conventionType.Extension__BuildHumanName(),
      newConventionImplementationType.Extension__BuildHumanName(),
      existConventionType.Extension__BuildHumanName());

  generic_error
   (errSrcID,
    place,
    point,
    msg);
 }//ConventionErr__ConventionAlreadyDefined

 //Helper methods --------------------------------------------------------

// //-----------------------------------------------------------------------
// public static void array_err__unexpected_dimension_number
//                                           (ErrSourceID errSrcID,
//                                            string      catalog_name,
//                                            string      schema_name,
//                                            string      relation_name,
//                                            string      field_name,
//                                            UInt32      actual_dim_number,
//                                            UInt32      expected_dim_number)
// {
//  Debug.Assert(!string.IsNullOrEmpty(relation_name));
//  Debug.Assert(!string.IsNullOrEmpty(field_name));
//  Debug.Assert(actual_dim_number!=expected_dim_number);
//
//  var exc=new LcpiOleDb__DataToolException
//               (com_lib.HResultCode.E_FAIL,
//                errSrcID,
//                ErrMessageID.bug_check__array_err__unexpected_dim_number_6);
//
//  exc.push(catalog_name)
//     .push(schema_name)
//     .push(relation_name)
//     .push(field_name)
//     .push(actual_dim_number)
//     .push(expected_dim_number)
//     .raise();
// }//array_err__incorrect_dimension_number
//
// //-----------------------------------------------------------------------
// public static void array_err__bad_sort_of_schema
//                                           (ErrSourceID errSrcID,
//                                            string      metadata_name,
//                                            string      prev_catalog_name,
//                                            string      prev_schema_name,
//                                            string      prev_relation_name,
//                                            string      prev_field_name,
//                                            string      cur_catalog_name,
//                                            string      cur_schema_name,
//                                            string      cur_relation_name,
//                                            string      cur_field_name)
// {
//  Debug.Assert(!string.IsNullOrEmpty(prev_relation_name));
//  Debug.Assert(!string.IsNullOrEmpty(prev_field_name));
//  Debug.Assert(!string.IsNullOrEmpty(cur_relation_name));
//  Debug.Assert(!string.IsNullOrEmpty(cur_field_name));
//
//  var exc=new LcpiOleDb__DataToolException
//               (com_lib.HResultCode.E_FAIL,
//                errSrcID,
//                ErrMessageID.bug_check__array_err__bad_sort_of_schema_9);
//
//  exc.push(metadata_name)
//     .push(prev_catalog_name)
//     .push(prev_schema_name)
//     .push(prev_relation_name)
//     .push(prev_field_name)
//     .push(cur_catalog_name)
//     .push(cur_schema_name)
//     .push(cur_relation_name)
//     .push(cur_field_name)
//     .raise();
// }//array_err__bad_sort_of_schema
//
// //-----------------------------------------------------------------------
// public static void array_err__bad_range_of_dimension
//                                           (ErrSourceID errSrcID,
//                                            string      catalog_name,
//                                            string      schema_name,
//                                            string      relation_name,
//                                            string      field_name,
//                                            UInt32      dimension_number,
//                                            Int32       lower_bound,
//                                            Int32       upper_bound)
// {
//  Debug.Assert(!string.IsNullOrEmpty(relation_name));
//  Debug.Assert(!string.IsNullOrEmpty(field_name));
//  Debug.Assert(dimension_number>0);
//  Debug.Assert(upper_bound<lower_bound);
//
//  var exc=new LcpiOleDb__DataToolException
//               (com_lib.HResultCode.E_FAIL,
//                errSrcID,
//                ErrMessageID.bug_check__array_err__bad_range_of_dimension_7);
//
//  exc.push(catalog_name)
//     .push(schema_name)
//     .push(relation_name)
//     .push(field_name)
//     .push(dimension_number)
//     .push(lower_bound)
//     .push(upper_bound)
//     .raise();
// }//array_err__bad_range_of_dimension
//
// //-----------------------------------------------------------------------
// public static void array_err__no_descr(ErrSourceID errSrcID,
//                                        string      catalog_name,
//                                        string      schema_name,
//                                        string      relation_name,
//                                        string      field_name)
// {
//  Debug.Assert(!string.IsNullOrEmpty(relation_name));
//  Debug.Assert(!string.IsNullOrEmpty(field_name));
//
//  var exc=new LcpiOleDb__DataToolException
//               (com_lib.HResultCode.E_FAIL,
//                errSrcID,
//                ErrMessageID.bug_check__array_err__no_descr_4);
//
//  exc.push(catalog_name)
//     .push(schema_name)
//     .push(relation_name)
//     .push(field_name)
//     .raise();
// }//array_err__no_descr
};//class ThrowBugCheck

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb

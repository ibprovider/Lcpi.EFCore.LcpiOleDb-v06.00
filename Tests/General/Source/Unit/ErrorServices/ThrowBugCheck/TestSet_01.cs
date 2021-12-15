////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 15.05.2018.
using System;
using System.Linq.Expressions;
using System.Reflection;
using NUnit.Framework;

using com_lib=lcpi.lib.com;
using structure_lib=lcpi.lib.structure;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.ThrowBugCheck{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_01

public static class TestSet_01
{
 [Test]
 public static void generic_error()
 {
  try
  {
   xEFCore.ThrowBugCheck.generic_error
    (xEFCore.ErrSourceID.Core_ConnectionOptionsInitializer,
     "x1",
     "x2",
     "x3");
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.TestBugCheck_RU_EN
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__Core_ConnectionOptionsInitializer,
     "x1",
     "x2",
     "x3",
     com_lib.HResultCode.E_FAIL);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//generic_error

 //-----------------------------------------------------------------------
 [Test]
 public static void not_empty_argument_list()
 {
  try
  {
   xEFCore.ThrowBugCheck.not_empty_argument_list
    (xEFCore.ErrSourceID.common,
     "a:b",
     "#001",
     3);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__BugCheck__not_empty_argument_list
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "a:b",
     "#001",
     3);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//not_empty_argument_list

 //-----------------------------------------------------------------------
 [Test]
 public static void incorrect_call_of_method()
 {
  try
  {
   xEFCore.ThrowBugCheck.incorrect_call_of_method
    (xEFCore.ErrSourceID.common,
     "a:b",
     "#001");
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__BugCheck__incorrect_call_of_method
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "a:b",
     "#001");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//incorrect_call_of_method

 //-----------------------------------------------------------------------
 [Test]
 public static void deserialization__wrong_state()
 {
  try
  {
   xEFCore.ThrowBugCheck.deserialization__wrong_state
    (xEFCore.ErrSourceID.Core_ConnectionOptionsInitializer,
     "x1");
  }
  catch(System.Runtime.Serialization.SerializationException e)
  {
   CheckErrors.PrintException_OK(e);

   CheckErrors.CheckException__DeserializationError
    (e,
     CheckErrors.c_src__EFCoreDataProvider__Core_ConnectionOptionsInitializer,
     "x1");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//deserialization__wrong_state

 //-----------------------------------------------------------------------
 [Test]
 public static void deserialization__null_obj_ptr()
 {
  try
  {
   xEFCore.ThrowBugCheck.deserialization__null_obj_ptr
    (xEFCore.ErrSourceID.Core_ConnectionOptionsInitializer,
     "x1");
  }
  catch(System.Runtime.Serialization.SerializationException e)
  {
   CheckErrors.PrintException_OK(e);

   CheckErrors.CheckException__DeserializationError__NullPtrToObject
    (e,
     CheckErrors.c_src__EFCoreDataProvider__Core_ConnectionOptionsInitializer,
     "x1");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//deserialization__null_obj_ptr

 //-----------------------------------------------------------------------
 [Test]
 public static void deserialization__null_item_ptr()
 {
  try
  {
   xEFCore.ThrowBugCheck.deserialization__null_item_ptr
    (xEFCore.ErrSourceID.Core_ConnectionOptionsInitializer,
     "x1",
     0);
  }
  catch(System.Runtime.Serialization.SerializationException e)
  {
   CheckErrors.PrintException_OK(e);

   CheckErrors.CheckException__DeserializationError__NullPtrToElement
    (e,
     CheckErrors.c_src__EFCoreDataProvider__Core_ConnectionOptionsInitializer,
     0,
     "x1");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//deserialization__null_item_ptr

 //-----------------------------------------------------------------------
 [Test]
 public static void schema_contains_unexpected_row_count()
 {
  try
  {
   xEFCore.ThrowBugCheck.schema_contains_unexpected_row_count
    (xEFCore.ErrSourceID.Core_ConnectionOptionsInitializer,
     "x1",
     "x2",
     "x3",
     123);
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__BugCheck__schema_contains_unexpected_row_count
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__Core_ConnectionOptionsInitializer,
     "x1",
     "x2",
     "x3",
     123);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//schema_contains_unexpected_row_count

 //-----------------------------------------------------------------------
 [Test]
 public static void incorrect_schema_restriction_number()
 {
  try
  {
   xEFCore.ThrowBugCheck.incorrect_schema_restriction_number
    (xEFCore.ErrSourceID.common,
     "x1",
     "x2",
     "x3",
     "x4",
     123);
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__BugCheck__incorrect_schema_restriction_number
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "x1",
     "x2",
     "x3",
     "x4",
     123);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//incorrect_schema_restriction_number

 //-----------------------------------------------------------------------
 [Test]
 public static void value_is_null()
 {
  try
  {
   xEFCore.ThrowBugCheck.value_is_null
    (xEFCore.ErrSourceID.common,
     "place",
     "point",
     "valueName");
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__bug_check__value_is_null
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "place",
     "point",
     "valueName");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//value_is_null

 //-----------------------------------------------------------------------
 [Test]
 public static void value_is_empty()
 {
  try
  {
   xEFCore.ThrowBugCheck.value_is_empty
    (xEFCore.ErrSourceID.common,
     "place",
     "point",
     "valueName");
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__bug_check__value_is_empty
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "place",
     "point",
     "valueName");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//value_is_empty

 //-----------------------------------------------------------------------
 [Test]
 public static void unexpected_value_type()
 {
  try
  {
   xEFCore.ThrowBugCheck.unexpected_value_type
    (xEFCore.ErrSourceID.common,
     "place1",
     "point2",
     "valueName3",
     typeof(string));
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__bug_check__unexpected_value_type
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "place1",
     "point2",
     "valueName3",
     typeof(string));

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//unexpected_value_type

 //-----------------------------------------------------------------------
 [Test]
 public static void bad_value_type()
 {
  try
  {
   xEFCore.ThrowBugCheck.bad_value_type
    (xEFCore.ErrSourceID.common,
     "place1",
     "point2",
     "valueName3",
     typeof(string),
     typeof(int));
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__bug_check__bad_value_type
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "place1",
     "point2",
     "valueName3",
     typeof(string),
     typeof(int));

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//bad_value_type

 //-----------------------------------------------------------------------
 [Test]
 public static void unexpected_value___Int32()
 {
  try
  {
   xEFCore.ThrowBugCheck.unexpected_value
    (xEFCore.ErrSourceID.common,
     "place1",
     "point2",
     "valueName3",
     (int)123);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__bug_check__unexpected_value
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "place1",
     "point2",
     "valueName3",
     123);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//unexpected_value___Int32

 //-----------------------------------------------------------------------
 [Test]
 public static void unexpected_type()
 {
  try
  {
   xEFCore.ThrowBugCheck.unexpected_type
    (xEFCore.ErrSourceID.common,
     "place1",
     "point2",
     typeof(string));
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__bug_check__unexpected_type
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "place1",
     "point2",
     typeof(string));

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//unexpected_type

 //-----------------------------------------------------------------------
 [Test]
 public static void unexpected_operator_type()
 {
  try
  {
   xEFCore.ThrowBugCheck.unexpected_operator_type
    (xEFCore.ErrSourceID.common,
     "place1",
     "point2",
     ExpressionType.Multiply);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__bug_check__unexpected_operator_type
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "place1",
     "point2",
     ExpressionType.Multiply);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//unexpected_operator_type

 //-----------------------------------------------------------------------
 [Test]
 public static void TypeMapping_ClrType_Is_Null()
 {
  try
  {
   xEFCore.ThrowBugCheck.TypeMapping_ClrType_Is_Null
    (xEFCore.ErrSourceID.common,
     "place2",
     "point3");
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__bug_check__TypeMapping_ClrType_Is_Null
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "place2",
     "point3");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//TypeMapping_ClrType_Is_Null

 //-----------------------------------------------------------------------
 [Test]
 public static void Unexpected_SqlExpression_Value_Type()
 {
  try
  {
   xEFCore.ThrowBugCheck.Unexpected_SqlExpression_Value_Type
    (xEFCore.ErrSourceID.common,
     "place2a",
     "point3a",
     typeof(int));
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__bug_check__Unexpected_SqlExpression_Value_Type
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "place2a",
     "point3a",
     typeof(int));

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Unexpected_SqlExpression_Value_Type

 //-----------------------------------------------------------------------
 [Test]
 public static void SqlConstantExpression_contains_not_null_value()
 {
  try
  {
   xEFCore.ThrowBugCheck.SqlConstantExpression_contains_not_null_value
    (xEFCore.ErrSourceID.common,
     "place22",
     "point33");
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__bug_check__SqlConstantExpression_contains_not_null_value
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "place22",
     "point33");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//SqlConstantExpression_contains_not_null_value

 //-----------------------------------------------------------------------
 [Test]
 public static void Unexpected_SqlExpression_Class_Type()
 {
  try
  {
   xEFCore.ThrowBugCheck.Unexpected_SqlExpression_Class_Type
    (xEFCore.ErrSourceID.common,
     "place2b",
     "point3b",
     typeof(float));
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__bug_check__Unexpected_SqlExpression_Class_Type
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "place2b",
     "point3b",
     typeof(float));

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Unexpected_SqlExpression_Class_Type

 //-----------------------------------------------------------------------
 [Test]
 public static void Unexpected_Expression_NodeType()
 {
  try
  {
   xEFCore.ThrowBugCheck.Unexpected_Expression_NodeType
    (xEFCore.ErrSourceID.LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,
     "place2c",
     "point3c",
     ExpressionType.NewArrayBounds);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__bug_check__Unexpected_Expression_NodeType
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,
     "place2c",
     "point3c",
     ExpressionType.NewArrayBounds);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Unexpected_Expression_NodeType

 //-----------------------------------------------------------------------
 [Test]
 public static void ModificationCommandBatch__unexpected_ResultSetMapping()
 {
  try
  {
   xEFCore.ThrowBugCheck.ModificationCommandBatch__unexpected_ResultSetMapping
    (xEFCore.ErrSourceID.FB_Common__ModificationCommandBatch,
     "pl",
     "#0022",
     0,
     "sql",
     Microsoft.EntityFrameworkCore.Update.ResultSetMapping.NotLastInResultSet);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__BugCheck__ModificationCommandBatch__unexpected_ResultSetMapping
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_Common__ModificationCommandBatch,
     "pl",
     "#0022",
     0,
     "sql",
     Microsoft.EntityFrameworkCore.Update.ResultSetMapping.NotLastInResultSet);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//ModificationCommandBatch__unexpected_ResultSetMapping

 //-----------------------------------------------------------------------
 [Test]
 public static void ModificationCommandBatch__found_a_read_op()
 {
  try
  {
   xEFCore.ThrowBugCheck.ModificationCommandBatch__found_a_read_op
    (xEFCore.ErrSourceID.FB_Common__ModificationCommandBatch,
     "pl",
     "#0022",
     0,
     "sql",
     "entry",
     "property");
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__BugCheck__ModificationCommandBatch__found_a_read_op
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_Common__ModificationCommandBatch,
     "pl",
     "#0022",
     0,
     "sql",
     "entry",
     "property");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//ModificationCommandBatch__found_a_read_op

 //-----------------------------------------------------------------------
 [Test]
 public static void ModificationCommandBatch__we_not_expected_result_set()
 {
  try
  {
   xEFCore.ThrowBugCheck.ModificationCommandBatch__we_not_expected_result_set
    (xEFCore.ErrSourceID.FB_Common__ModificationCommandBatch,
     "pl",
     "#0022",
     0,
     "sql",
     23);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__BugCheck__ModificationCommandBatch__we_not_expected_result_set
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_Common__ModificationCommandBatch,
     "pl",
     "#0022",
     0,
     "sql",
     23);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//ModificationCommandBatch__we_not_expected_result_set

 //-----------------------------------------------------------------------
 [Test]
 public static void ModificationCommandBatch__unexpected_parameter_direction()
 {
  try
  {
   xEFCore.ThrowBugCheck.ModificationCommandBatch__unexpected_parameter_direction
    (xEFCore.ErrSourceID.FB_Common__ModificationCommandBatch,
     "pl",
     "#0022",
     0,
     "sql",
     "pppp",
     System.Data.ParameterDirection.ReturnValue);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__BugCheck__ModificationCommandBatch__unexpected_parameter_direction
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_Common__ModificationCommandBatch,
     "pl",
     "#0022",
     0,
     "sql",
     "pppp",
     System.Data.ParameterDirection.ReturnValue);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//ModificationCommandBatch__unexpected_parameter_direction

 //-----------------------------------------------------------------------
 [Test]
 public static void engine_svc_not_supported()
 {
  try
  {
   xEFCore.ThrowBugCheck.engine_svc_not_supported
    (xEFCore.ErrSourceID.common,
     Guid.Empty);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__bug_check__engine_svc_not_supported_1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     Guid.Empty);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//engine_svc_not_supported

 //-----------------------------------------------------------------------
 [Test]
 public static void engine_svc_not_supported_req_interface()
 {
  try
  {
   xEFCore.ThrowBugCheck.engine_svc_not_supported_req_interface<string>
    (xEFCore.ErrSourceID.common,
     Guid.Empty);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__bug_check__engine_svc_not_supported_req_interface_2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     Guid.Empty,
     typeof(string));

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//engine_svc_not_supported_req_interface

 //-----------------------------------------------------------------------
 [Test]
 public static void LocalEvalErr__mutation_of_expression()
 {
  var expr=Expression.MakeBinary(ExpressionType.Equal,Expression.Constant(1),Expression.Constant(2));

  try
  {
   xEFCore.ThrowBugCheck.LocalEvalErr__mutation_of_expression
    (xEFCore.ErrSourceID.common,
     "pl",
     "#0022",
     expr,
     null);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__BugCheck__LocalEvalErr__mutation_of_expression
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "pl",
     "#0022",
     expr,
     null);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//LocalEvalErr__mutation_of_expression

 //-----------------------------------------------------------------------
 [Test]
 public static void LocalEvalErr__mutation__null_ptr_to_new_expression()
 {
  var expr=Expression.MakeBinary(ExpressionType.Equal,Expression.Constant(1),Expression.Constant(2));

  try
  {
   xEFCore.ThrowBugCheck.LocalEvalErr__mutation__null_ptr_to_new_expression
    (xEFCore.ErrSourceID.common,
     "pl",
     "#0022",
     expr);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__BugCheck__LocalEvalErr__mutation__null_ptr_to_new_expression
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "pl",
     "#0022",
     expr);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//LocalEvalErr__mutation__null_ptr_to_new_expression

 //-----------------------------------------------------------------------
 [Test]
 public static void LocalEvalErr__unsupported_conversion()
 {
  var expr=Expression.MakeBinary(ExpressionType.Equal,Expression.Constant(1),Expression.Constant(2));

  try
  {
   xEFCore.ThrowBugCheck.LocalEvalErr__unsupported_conversion
    (xEFCore.ErrSourceID.common,
     "p2",
     "#0033",
     typeof(System.Collections.Generic.List<Nullable<DateTime>>),
     typeof(System.Collections.Generic.IEnumerable<Nullable<DateTime>[][]>));
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__BugCheck__LocalEvalErr__unsupported_conversion
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "p2",
     "#0033",
     "System.Collections.Generic.List<Nullable<System.DateTime>>",
     "System.Collections.Generic.IEnumerable<Nullable<System.DateTime>[][]>");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//LocalEvalErr__unsupported_conversion

 //-----------------------------------------------------------------------
 [Test]
 public static void LocalEvalErr__unsupported_method()
 {
  var expr=Expression.MakeBinary(ExpressionType.Equal,Expression.Constant(1),Expression.Constant(2));

  try
  {
   xEFCore.ThrowBugCheck.LocalEvalErr__unsupported_method
    (xEFCore.ErrSourceID.common,
     "p3",
     "#0034",
     xEFCore.Structure.Structure_MethodIdCache.MethodIdOf__IEnumerableNullableInt32__vrt__Contains);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__BugCheck__LocalEvalErr__unsupported_method
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "p3",
     "#0034",
     "System.Collections.Generic.IEnumerable<Nullable<System.Int32>>.Contains(Nullable<System.Int32>)");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//LocalEvalErr__unsupported_method

 //-----------------------------------------------------------------------
 [Test]
 public static void LocalEvalErr__mutation__changed_result_type_of_expression()
 {
  var oldExpr=Expression.MakeBinary(ExpressionType.Add,Expression.Constant(1),Expression.Constant(2));
  var newExpr=Expression.MakeBinary(ExpressionType.Equal,Expression.Constant(1),Expression.Constant(2));

  try
  {
   xEFCore.ThrowBugCheck.LocalEvalErr__mutation__changed_result_type_of_expression
    (xEFCore.ErrSourceID.common,
     "pl2",
     "#0023",
     oldExpr,
     newExpr);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__BugCheck__LocalEvalErr__mutation__changed_result_type_of_expression
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "pl2",
     "#0023",
     oldExpr,
     newExpr);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//LocalEvalErr__mutation__changed_result_type_of_expression

 //-----------------------------------------------------------------------
 [Test]
 public static void LocalEvalErr__mutation__changed_node_type_of_expression()
 {
  var oldExpr=Expression.MakeBinary(ExpressionType.Subtract,Expression.Constant(1),Expression.Constant(2));
  var newExpr=Expression.MakeBinary(ExpressionType.Equal,Expression.Constant(1),Expression.Constant(2));

  try
  {
   xEFCore.ThrowBugCheck.LocalEvalErr__mutation__changed_node_type_of_expression
    (xEFCore.ErrSourceID.common,
     "pl3",
     "#0024",
     oldExpr,
     newExpr);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__BugCheck__LocalEvalErr__mutation__changed_node_type_of_expression
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "pl3",
     "#0024",
     oldExpr,
     newExpr);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//LocalEvalErr__mutation__changed_node_type_of_expression

 //-----------------------------------------------------------------------
 [Test]
 public static void UnexpectedResultTypeOfBinaryOperator()
 {
  try
  {
   xEFCore.ThrowBugCheck.UnexpectedResultTypeOfBinaryOperator
    (xEFCore.ErrSourceID.common,
     ExpressionType.And,
     typeof(int),
     typeof(short),
     typeof(sbyte),
     typeof(byte));
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__bug_check__unexpected_result_type_of_binary_operator_5
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     ExpressionType.And,
     typeof(int),
     typeof(short),
     typeof(sbyte),
     typeof(byte));

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//UnexpectedResultTypeOfBinaryOperator

 //-----------------------------------------------------------------------
 [Test]
 public static void BindToTypeMethod__NotFound__none()
 {
  try
  {
   xEFCore.ThrowBugCheck.BindToTypeMethod__NotFound
    (xEFCore.ErrSourceID.common,
     typeof(string),
     "TEST",
     null,
     BindingFlags.NonPublic);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__bug_check__bind_to_type_method__not_found_4
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     typeof(string),
     "TEST",
     "<NONE>",
     BindingFlags.NonPublic);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//BindToTypeMethod__NotFound__none

 //-----------------------------------------------------------------------
 [Test]
 public static void BindToTypeMethod__NotFound__args0()
 {
  try
  {
   xEFCore.ThrowBugCheck.BindToTypeMethod__NotFound
    (xEFCore.ErrSourceID.common,
     typeof(string),
     "TEST",
     new Type[]{},
     BindingFlags.NonPublic);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__bug_check__bind_to_type_method__not_found_4
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     typeof(string),
     "TEST",
     "<EMPTY LIST>",
     BindingFlags.NonPublic);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//BindToTypeMethod__NotFound__args0

 //-----------------------------------------------------------------------
 [Test]
 public static void BindToTypeMethod__NotFound__args1()
 {
  try
  {
   xEFCore.ThrowBugCheck.BindToTypeMethod__NotFound
    (xEFCore.ErrSourceID.common,
     typeof(string),
     "TEST",
     new Type[]{typeof(int)},
     BindingFlags.NonPublic);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__bug_check__bind_to_type_method__not_found_4
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     typeof(string),
     "TEST",
     "System.Int32",
     BindingFlags.NonPublic);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//BindToTypeMethod__NotFound__args1

 //-----------------------------------------------------------------------
 [Test]
 public static void BindToTypeMethod__NotFound__args2()
 {
  try
  {
   xEFCore.ThrowBugCheck.BindToTypeMethod__NotFound
    (xEFCore.ErrSourceID.common,
     typeof(string),
     "TEST",
     new Type[]{typeof(int),typeof(short)},
     BindingFlags.NonPublic);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__bug_check__bind_to_type_method__not_found_4
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     typeof(string),
     "TEST",
     "System.Int32, System.Int16",
     BindingFlags.NonPublic);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//BindToTypeMethod__NotFound__args2

 //-----------------------------------------------------------------------
 [Test]
 public static void BindToTypeMethod__BadReturnType__args2___null__type()
 {
  try
  {
   xEFCore.ThrowBugCheck.BindToTypeMethod__BadReturnType
    (xEFCore.ErrSourceID.common,
     typeof(string),
     "TEST",
     new Type[]{typeof(int),typeof(short)},
     BindingFlags.NonPublic,
     null,
     typeof(double));
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__bug_check__bind_to_type_method__bad_return_type_6
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     typeof(string),
     "TEST",
     "System.Int32, System.Int16",
     BindingFlags.NonPublic,
     "#NULL",
     "System.Double");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//BindToTypeMethod__BadReturnType__args2___null__type

 //-----------------------------------------------------------------------
 [Test]
 public static void BindToTypeMethod__BadReturnType__args2___type__void()
 {
  try
  {
   xEFCore.ThrowBugCheck.BindToTypeMethod__BadReturnType
    (xEFCore.ErrSourceID.common,
     typeof(string),
     "TEST",
     new Type[]{typeof(int),typeof(short)},
     BindingFlags.NonPublic,
     typeof(double),
     null);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__bug_check__bind_to_type_method__bad_return_type_6
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     typeof(string),
     "TEST",
     "System.Int32, System.Int16",
     BindingFlags.NonPublic,
     "System.Double",
     "#NULL");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//BindToTypeMethod__BadReturnType__args2___type__void

 //-----------------------------------------------------------------------
 [Test]
 public static void GetNestedType__NotFound()
 {
  try
  {
   xEFCore.ThrowBugCheck.GetNestedType__NotFound
    (xEFCore.ErrSourceID.common,
     typeof(string),
     "TEST",
     BindingFlags.NonPublic);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__bug_check__get_nested_type__not_found_3
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     typeof(string),
     "TEST",
     BindingFlags.NonPublic);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//GetNestedType__NotFound

 //-----------------------------------------------------------------------
 [Test]
 public static void SqlENode__UnsupportedArgTypes()
 {
  try
  {
   xEFCore.ThrowBugCheck.SqlENode__UnsupportedArgTypes
    (xEFCore.ErrSourceID.common,
     "TEST",
     new Microsoft.EntityFrameworkCore.Query.SqlExpressions.SqlConstantExpression
      (System.Linq.Expressions.Expression.Constant(1),
       xEFCore.Basement.EF.Dbms.Firebird.Common.Storage.Mapping.FB_Common__TypeMapping__INTEGER.Create()),
     new Microsoft.EntityFrameworkCore.Query.SqlExpressions.SqlConstantExpression
      (System.Linq.Expressions.Expression.Constant(1.0D),
       xEFCore.Basement.EF.Dbms.Firebird.Common.Storage.Mapping.FB_Common__TypeMapping__DOUBLE.Create()));
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   CheckErrors.CheckErrorRecord__bug_check__sql_enode__unsupported_arg_types__2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "TEST",
     "System.Int32, System.Double");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//BindToTypeMethod__BadReturnType__args2___type__void

 //-----------------------------------------------------------------------
 [Test]
 public static void No_TypeMapping()
 {
  try
  {
   xEFCore.ThrowBugCheck.No_TypeMapping
    (xEFCore.ErrSourceID.common,
     "a",
     "b");
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__BugCheck__No_TypeMapping
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "a",
     "b");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//No_TypeMapping

 //-----------------------------------------------------------------------
 [Test]
 public static void No_TypeMapping_ClrType()
 {
  try
  {
   xEFCore.ThrowBugCheck.No_TypeMapping_ClrType
    (xEFCore.ErrSourceID.common,
     "a",
     "b");
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__BugCheck__No_TypeMapping_ClrType
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "a",
     "b");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//No_TypeMapping_ClrType

 //-----------------------------------------------------------------------
 [Test]
 public static void UnknownParserResultCode()
 {
  try
  {
   xEFCore.ThrowBugCheck.UnknownParserResultCode
    (xEFCore.ErrSourceID.common,
     "a",
     "b",
     123);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__BugCheck__UnknownParserResultCode
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "a",
     "b",
     123);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//UnknownParserResultCode

 //-----------------------------------------------------------------------
 [Test]
 public static void UnknownDataTypeID()
 {
  try
  {
   xEFCore.ThrowBugCheck.UnknownDataTypeID
    (xEFCore.ErrSourceID.common,
     "a",
     "b",
     321);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__BugCheck__UnknownDataTypeID
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "a",
     "b",
     321);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//UnknownDataTypeID

 //-----------------------------------------------------------------------
 [Test]
 public static void UnknownBlobSubTypeID()
 {
  try
  {
   xEFCore.ThrowBugCheck.UnknownBlobSubTypeID
    (xEFCore.ErrSourceID.common,
     "a",
     "b",
     333);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__BugCheck__UnknownBlobSubTypeID
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "a",
     "b",
     333);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//UnknownBlobSubTypeID

 //-----------------------------------------------------------------------
 [Test]
 public static void ColumnHasMultipleVGS()
 {
  try
  {
   xEFCore.ThrowBugCheck.ColumnHasMultipleVGS
    (xEFCore.ErrSourceID.common,
     "a",
     "b",
     "tt",
     "cc");
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__BugCheck__ColumnHasMultipleVGS
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "a",
     "b",
     "tt",
     "cc");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//ColumnHasMultipleVGS

 //-----------------------------------------------------------------------
 private interface tagTest_IConvention{ };

 private class tagTest_Convention1:tagTest_IConvention{ };
 private class tagTest_Convention2:tagTest_Convention1{ };

 private class tagTest_NewConvention:tagTest_Convention2{ };

 //-----------------------------------------------------------------------
 [Test]
 public static void ConventionErr__MultipleConventionsForReplacing()
 {
  try
  {
   xEFCore.ThrowBugCheck.ConventionErr__MultipleConventionsForReplacing
    (xEFCore.ErrSourceID.common,
     "place",
     "point",
     typeof(tagTest_IConvention),
     typeof(tagTest_NewConvention),
     typeof(tagTest_Convention1),
     typeof(tagTest_Convention2));
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__BugCheck__MultipleConventionsForReplacing
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "place",
     "point",
     "EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.ThrowBugCheck.TestSet_01+tagTest_IConvention",
     "EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.ThrowBugCheck.TestSet_01+tagTest_NewConvention",
     "EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.ThrowBugCheck.TestSet_01+tagTest_Convention1",
     "EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.ThrowBugCheck.TestSet_01+tagTest_Convention2");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//ConventionErr__MultipleConventionsForReplacing

 //-----------------------------------------------------------------------
 [Test]
 public static void ConventionErr__NoConventionForReplacing()
 {
  try
  {
   xEFCore.ThrowBugCheck.ConventionErr__NoConventionForReplacing
    (xEFCore.ErrSourceID.common,
     "place",
     "point",
     typeof(tagTest_IConvention),
     typeof(tagTest_NewConvention));
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__BugCheck__ConventionErr__NoConventionForReplacing
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "place",
     "point",
     "EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.ThrowBugCheck.TestSet_01+tagTest_IConvention",
     "EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.ThrowBugCheck.TestSet_01+tagTest_NewConvention");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//ConventionErr__NoConventionForReplacing

 //-----------------------------------------------------------------------
 [Test]
 public static void ConventionErr__ConventionAlreadyDefined()
 {
  try
  {
   xEFCore.ThrowBugCheck.ConventionErr__ConventionAlreadyDefined
    (xEFCore.ErrSourceID.common,
     "place",
     "point",
     typeof(tagTest_IConvention),
     typeof(tagTest_NewConvention),
     typeof(tagTest_Convention1));
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__BugCheck__ConventionErr__ConventionAlreadyDefined
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "place",
     "point",
     "EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.ThrowBugCheck.TestSet_01+tagTest_IConvention",
     "EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.ThrowBugCheck.TestSet_01+tagTest_NewConvention",
     "EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.ThrowBugCheck.TestSet_01+tagTest_Convention1");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//ConventionErr__ConventionAlreadyDefined

 //-----------------------------------------------------------------------
// [Test]
// public static void Test__array_err__unexpected_dimension_number()
// {
//  try
//  {
//   xEFCore.ThrowBugCheck.array_err__unexpected_dimension_number
//    (xEFCore.ErrSourceID.Core_SchemaLoader__ArrayDescrs,
//     "x1",
//     "x2",
//     "x3",
//     "x4",
//     2,
//     1);
//  }
//  catch(xEFCore.OleDbDataToolException e)
//  {
//   CheckErrors.PrintException_OK(e);
//
//   Assert.AreEqual
//    (1,
//     TestServices.GetRecordCount(e));
//
//   CheckErrors.CheckErrorRecord__BugCheck__array_err__unexpected_dimension_number
//    (TestServices.GetRecord(e,0),
//     CheckErrors.c_Linq2DbDataProvider__src__Core_SchemaLoader__ArrayDescrs,
//     "x1",
//     "x2",
//     "x3",
//     "x4",
//     2,
//     1);
//
//   return;
//  }//catch
//
//  TestServices.ThrowWeWaitError();
// }//Test__array_err__unexpected_dimension_number

 //-----------------------------------------------------------------------
// [Test]
// public static void array_err__bad_sort_of_schema()
// {
//  try
//  {
//   xEFCore.ThrowBugCheck.array_err__bad_sort_of_schema
//    (xEFCore.ErrSourceID.Core_SchemaLoader__ArrayDescrs,
//     "s",
//     "x1",
//     "x2",
//     "x3",
//     "x4",
//     "y1",
//     "y2",
//     "y3",
//     "y4");
//  }
//  catch(xEFCore.OleDbDataToolException e)
//  {
//   CheckErrors.PrintException_OK(e);
//
//   Assert.AreEqual
//    (1,
//     TestServices.GetRecordCount(e));
//
//   CheckErrors.CheckErrorRecord__BugCheck__array_err__bad_sort_of_schema
//    (TestServices.GetRecord(e,0),
//     CheckErrors.c_Linq2DbDataProvider__src__Core_SchemaLoader__ArrayDescrs,
//     "s",
//     "x1",
//     "x2",
//     "x3",
//     "x4",
//     "y1",
//     "y2",
//     "y3",
//     "y4");
//
//   return;
//  }//catch
//
//  TestServices.ThrowWeWaitError();
// }//array_err__bad_sort_of_schema

 //-----------------------------------------------------------------------
// [Test]
// public static void array_err__bad_range_of_dimension()
// {
//  try
//  {
//   xEFCore.ThrowBugCheck.array_err__bad_range_of_dimension
//    (xEFCore.ErrSourceID.Core_SchemaLoader__ArrayDescrs,
//     "x1",
//     "x2",
//     "x3",
//     "x4",
//     1,
//     3,
//     2);
//  }
//  catch(xEFCore.OleDbDataToolException e)
//  {
//   CheckErrors.PrintException_OK(e);
//
//   Assert.AreEqual
//    (1,
//     TestServices.GetRecordCount(e));
//
//   CheckErrors.CheckErrorRecord__BugCheck__array_err__bad_range
//    (TestServices.GetRecord(e,0),
//     CheckErrors.c_Linq2DbDataProvider__src__Core_SchemaLoader__ArrayDescrs,
//     "x1",
//     "x2",
//     "x3",
//     "x4",
//     1,
//     3,
//     2);
//
//   return;
//  }//catch
//
//  TestServices.ThrowWeWaitError();
// }//array_err__bad_range_of_dimension

 //-----------------------------------------------------------------------
// [Test]
// public static void array_err__no_descr()
// {
//  try
//  {
//   xEFCore.ThrowBugCheck.array_err__no_descr
//    (xEFCore.ErrSourceID.Core_DataType__Helpers,
//     "x1",
//     "x2",
//     "x3",
//     "x4");
//  }
//  catch(xEFCore.OleDbDataToolException e)
//  {
//   CheckErrors.PrintException_OK(e);
//
//   Assert.AreEqual
//    (1,
//     TestServices.GetRecordCount(e));
//
//   CheckErrors.CheckErrorRecord__BugCheck__array_err__no_descr
//    (TestServices.GetRecord(e,0),
//     CheckErrors.c_Linq2DbDataProvider__src__Core_DataType__Helpers,
//     "x1",
//     "x2",
//     "x3",
//     "x4");
//
//   return;
//  }//catch
//
//  TestServices.ThrowWeWaitError();
// }//array_err__no_descr
};//class TestSet_01

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.ThrowBugCheck

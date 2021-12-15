////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 14.05.2018.
using System;
using System.Diagnostics;

using com_lib=lcpi.lib.com;
using structure_lib=lcpi.lib.structure;
using exception_lib=lcpi.lib.structure.exceptions;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb{
////////////////////////////////////////////////////////////////////////////////
//class ThrowSysError

static class ThrowSysError
{
 private const com_lib.HResultCode c_ComErrCode__ObjectWasDisposed
  =com_lib.HResultCode.E_FAIL;

 private const com_lib.HResultCode c_ComErrCode__BadArg
  =com_lib.HResultCode.E_INVALIDARG;

 private const com_lib.HResultCode c_ComErrCode__ArgIsNull
  =com_lib.HResultCode.E_POINTER;

 private const com_lib.HResultCode c_ComErrCode__ArgNotNull
  =com_lib.HResultCode.E_INVALIDARG;

 private const com_lib.HResultCode c_ComErrCode__ArgIsEmpty
  =com_lib.HResultCode.E_INVALIDARG;

 private const com_lib.HResultCode c_ComErrCode__NotImplemented
  =com_lib.HResultCode.E_NOTIMPL;

 private const com_lib.HResultCode c_ComErrCode__InvalidOperation
  =com_lib.HResultCode.E_FAIL;

 private const com_lib.HResultCode c_ComErrCode__Overflow
  =com_lib.HResultCode.COR_E_OVERFLOW;

 private const com_lib.HResultCode c_ComErrCode__DivideByZero
  =com_lib.HResultCode.COR_E_DIVIDEBYZERO;

 //-----------------------------------------------------------------------
 public static void invalid_arg(structure_lib.IErrorRecord err_rec,
                                string                     arg_name)
 {
  Debug.Assert(!Object.ReferenceEquals(err_rec,null));
  Debug.Assert(!string.IsNullOrEmpty(arg_name));

  exception_lib.throw_error.invalid_argument
   (err_rec,
    arg_name,
    null);
 }//invalid_arg - err_rec, arg_name

 //-----------------------------------------------------------------------
 public static void argument_is_null(ErrSourceID errSrcID,
                                     string      method_name,
                                     string      arg_name)
 {
  // [2020-10-20] Tested.

  Debug.Assert(!string.IsNullOrEmpty(method_name));
  Debug.Assert(method_name==method_name.Trim());

  Debug.Assert(!string.IsNullOrEmpty(arg_name));
  Debug.Assert(arg_name==arg_name.Trim());

  var rec
   =new Core.Core_ExceptionRecord
     (c_ComErrCode__ArgIsNull,
      errSrcID,
      ErrMessageID.common_err__argument_is_null__2);

  rec.push(method_name)
     .push(arg_name);

  exception_lib.throw_error.argument_is_null
   (rec,
    arg_name);
 }//argument_is_null

 //-----------------------------------------------------------------------
 public static void argument_is_not_null(ErrSourceID errSrcID,
                                         string      method_name,
                                        string      arg_name)
 {
  // [2020-10-20] Tested.

  Debug.Assert(!string.IsNullOrEmpty(method_name));
  Debug.Assert(method_name==method_name.Trim());

  Debug.Assert(!string.IsNullOrEmpty(arg_name));
  Debug.Assert(arg_name==arg_name.Trim());

  var rec
   =new Core.Core_ExceptionRecord
     (c_ComErrCode__ArgNotNull,
      errSrcID,
      ErrMessageID.common_err__argument_is_not_null__2);

  rec.push(method_name)
     .push(arg_name);

  exception_lib.throw_error.invalid_argument
   (rec,
    arg_name,
    /*innerException*/null);
 }//argument_is_not_null

 //-----------------------------------------------------------------------
 public static void argument_is_empty(ErrSourceID errSrcID,
                                      string      method_name,
                                      string      arg_name)
 {
  // [2020-10-20] Tested.

  Debug.Assert(!string.IsNullOrEmpty(method_name));
  Debug.Assert(method_name==method_name.Trim());

  Debug.Assert(!string.IsNullOrEmpty(arg_name));
  Debug.Assert(arg_name==arg_name.Trim());

  var rec
   =new Core.Core_ExceptionRecord
     (c_ComErrCode__ArgIsEmpty,
      errSrcID,
      ErrMessageID.common_err__argument_is_empty__2);

  rec.push(method_name)
     .push(arg_name);

  invalid_arg
   (rec,
    arg_name);
 }//argument_is_empty

 //-----------------------------------------------------------------------
 public static void argument_out_of_range(structure_lib.IErrorRecord err_rec,
                                          string                     arg_name,
                                          object                     actualValue)
 {
  Debug.Assert(!Object.ReferenceEquals(err_rec,null));

  exception_lib.throw_error.argument_out_of_range
   (err_rec,
    arg_name,
    actualValue);
 }//argument_out_of_range

 //-----------------------------------------------------------------------
 public static void argument_out_of_range___negative_value
                                           (ErrSourceID errSrcID,
                                            string      method_name,
                                            string      arg_name,
                                            object      actualValue)
 {
  Debug.Assert(!string.IsNullOrEmpty(method_name));
  Debug.Assert(method_name==method_name.Trim());

  Debug.Assert(!string.IsNullOrEmpty(arg_name));
  Debug.Assert(arg_name==arg_name.Trim());

  var rec
   =new Core.Core_ExceptionRecord
     (c_ComErrCode__BadArg,
      errSrcID,
      ErrMessageID.common_err__argument_is_negative__3);

  rec.push(method_name)
     .push(arg_name)
     .push_object(actualValue);

  argument_out_of_range
   (rec,
    arg_name,
    actualValue);
 }//argument_out_of_range___negative_value

 //-----------------------------------------------------------------------
 public static void object_was_disposed(ErrSourceID errSrcID)
 {
  var rec
   =new Core.Core_ExceptionRecord
     (c_ComErrCode__ObjectWasDisposed,
      errSrcID,
      ErrMessageID.common_err__object_was_disposed__1);

  rec.push(errSrcID);

  var obj_name=rec.GetSource(null);

  exception_lib.throw_error.object_disposed
   (rec,
    obj_name);
 }//object_was_disposed

 //-----------------------------------------------------------------------
 public static void object_was_disposed__cant_exec_method(ErrSourceID errSrcID,
                                                          string      method_name)
 {
  if(Object.ReferenceEquals(method_name,null))
   object_was_disposed(errSrcID);

  Debug.Assert(method_name!="");

  var rec
   =new Core.Core_ExceptionRecord
     (c_ComErrCode__ObjectWasDisposed,
      errSrcID,
      ErrMessageID.common_err__object_was_disposed__cant_exec_method__2);

  rec.push(errSrcID).push(method_name);

  var obj_name=rec.GetSource(null);

  exception_lib.throw_error.object_disposed
   (rec,
    obj_name);
 }//object_was_disposed__cant_exec_method

 //-----------------------------------------------------------------------
 public static void invalid_operation(structure_lib.IErrorRecord err_rec,
                                      Exception                  innerException)
 {
  Debug.Assert(!Object.ReferenceEquals(err_rec,null));

  exception_lib.throw_error.invalid_operation
   (err_rec,
    innerException);
 }//invalid_operation - err_rec, innerException

 //-----------------------------------------------------------------------
 public static void invalid_operation(structure_lib.IErrorRecord err_rec)
 {
  Debug.Assert(!Object.ReferenceEquals(err_rec,null));

  invalid_operation
   (err_rec,
    /*innerException*/null);
 }//invalid_operation - err_rec

 //-----------------------------------------------------------------------
 public static void invalid_operation(ErrSourceID  errSrcID,
                                      ErrMessageID msg_id_0)
 {
  var err_rec
   =new Core.Core_ExceptionRecord
     (c_ComErrCode__InvalidOperation,
      errSrcID,
      msg_id_0);

  invalid_operation(err_rec);
 }//invalid_operation - errSrcID, msg_id_0

 //-----------------------------------------------------------------------
 public static void not_implemented(structure_lib.IErrorRecord err_rec)
 {
  Debug.Assert(!Object.ReferenceEquals(err_rec,null));

  exception_lib.throw_error.not_implemented
   (err_rec,
    null);
 }//not_implemented

 //-----------------------------------------------------------------------
 public static void method_not_impl(ErrSourceID errSrcID,
                                    string      method_name)
 {
  Debug.Assert(!string.IsNullOrEmpty(method_name));

  var err_rec
   =new Core.Core_ExceptionRecord
     (c_ComErrCode__NotImplemented,
      errSrcID,
      ErrMessageID.common_err__method_not_impl__1);

  err_rec.push(method_name);

  not_implemented(err_rec);
 }//method_not_impl

 //-----------------------------------------------------------------------
 public static void method_not_impl(ErrSourceID errSrcID,
                                    string      method_name,
                                    string      point)
 {
  Debug.Assert(!string.IsNullOrEmpty(method_name));
  Debug.Assert(!string.IsNullOrEmpty(point));

  var err_rec
   =new Core.Core_ExceptionRecord
     (c_ComErrCode__NotImplemented,
      errSrcID,
      ErrMessageID.common_err__method_not_impl__2);

  err_rec
   .push(method_name)
   .push(point);

  not_implemented(err_rec);
 }//method_not_impl

 //-----------------------------------------------------------------------
 public static void overflow(structure_lib.IErrorRecord err_rec,
                             Exception                  innerException)
 {
  Debug.Assert(!Object.ReferenceEquals(err_rec,null));

  exception_lib.throw_error.overflow
   (err_rec,
    innerException);
 }//overflow

 //-----------------------------------------------------------------------
 public static void overflow(structure_lib.IErrorRecord err_rec)
 {
  Debug.Assert(!Object.ReferenceEquals(err_rec,null));

  overflow
   (err_rec,
    /*innerException*/null);
 }//overflow

 //-----------------------------------------------------------------------
 public static void overflow_in_arithmetic_op1<TA1>
                             (ErrSourceID    errSrcID,
                              ExpressionType opType,
                              TA1            arg1,
                              Exception      innerException)
 {
  var err_rec
   =new Core.Core_ExceptionRecord
     (c_ComErrCode__Overflow,
      errSrcID,
      ErrMessageID.common_err__overflow_in_arithmetic_op1__3);

  err_rec
   .push(opType)
   .push(typeof(TA1))
   .push_object(arg1);

  overflow
   (err_rec,
    innerException);
 }//overflow_in_arithmetic_op1<TA1>

 //-----------------------------------------------------------------------
 public static void overflow_in_arithmetic_op2<TA1,TA2>
                             (ErrSourceID    errSrcID,
                              ExpressionType opType,
                              TA1            arg1,
                              TA2            arg2,
                              Exception      innerException)
 {
  var err_rec
   =new Core.Core_ExceptionRecord
     (c_ComErrCode__Overflow,
      errSrcID,
      ErrMessageID.common_err__overflow_in_arithmetic_op2__5);

  err_rec
   .push(opType)
   .push(typeof(TA1))
   .push_object(arg1)
   .push(typeof(TA2))
   .push_object(arg2);

  overflow
   (err_rec,
    innerException);
 }//overflow_in_arithmetic_op2

 //-----------------------------------------------------------------------
 public static void out_of_range_in_arithmetic_op2<TA1,TA2>
                             (ErrSourceID    errSrcID,
                              ExpressionType opType,
                              TA1            arg1,
                              TA2            arg2)
 {
  var err_rec
   =new Core.Core_ExceptionRecord
     (c_ComErrCode__Overflow,
      errSrcID,
      ErrMessageID.common_err__out_of_range_in_arithmetic_op2__5);

  err_rec
   .push(opType)
   .push(typeof(TA1))
   .push_object(arg1)
   .push(typeof(TA2))
   .push_object(arg2);

  overflow
   (err_rec);
 }//out_of_range_in_arithmetic_op2

 //-----------------------------------------------------------------------
 public static void divide_by_zero
                             (ErrSourceID           errSrcID,
                              DivideByZeroException innerException)
 {
  var err_rec
   =new Core.Core_ExceptionRecord
     (c_ComErrCode__DivideByZero,
      errSrcID,
      ErrMessageID.common_err__divide_by_zero__0);

  invalid_operation
   (err_rec,
    innerException);
 }//divide_by_zero
 
 //-----------------------------------------------------------------------
 public static void not_supported(structure_lib.IErrorRecord err_rec)
 {
  Debug.Assert(!Object.ReferenceEquals(err_rec,null));

  exception_lib.throw_error.not_supported
   (err_rec,
    /*innerException*/null);
 }//not_supported - err_rec

 //-----------------------------------------------------------------------
 public static void cant_alloc_new_array__overflow(ErrSourceID errSrcID,
                                                   string      method_name,
                                                   string      point)
 {
  // [2021-03-02] Tested.

  Debug.Assert(!string.IsNullOrEmpty(method_name));
  Debug.Assert(!string.IsNullOrEmpty(point));

  var err_rec
   =new Core.Core_ExceptionRecord
     (c_ComErrCode__InvalidOperation,
      errSrcID,
      ErrMessageID.common_err__cant_alloc_new_array__overflow__2);

  err_rec
   .push(method_name)
   .push(point);

  invalid_operation
   (err_rec);
 }//method_not_impl
};//class ThrowSysError

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb

////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 20.10.2020.
using System;
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

using structure_lib=lcpi.lib.structure;

namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.ThrowSysError{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_01

public static class TestSet_01
{
 [Test]
 public static void argument_is_null()
 {
  try
  {
   xEFCore.ThrowSysError.argument_is_null
    (xEFCore.ErrSourceID.common,
     "mmm",
     "ppp");
  }
  catch(ArgumentNullException e)
  {
   CheckErrors.PrintException_OK(e);

   CheckErrors.CheckException__ArgumentNullException
    (e,
     CheckErrors.c_src__EFCoreDataProvider__common,
     "mmm",
     "ppp");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//argument_is_null

 //-----------------------------------------------------------------------
 [Test]
 public static void argument_is_not_null()
 {
  try
  {
   xEFCore.ThrowSysError.argument_is_not_null
    (xEFCore.ErrSourceID.common,
     "mmm",
     "ppp");
  }
  catch(ArgumentException e)
  {
   CheckErrors.PrintException_OK(e);

   CheckErrors.CheckException__ArgumentIsNotNull
    (e,
     CheckErrors.c_src__EFCoreDataProvider__common,
     "mmm",
     "ppp");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//argument_is_not_null

 //-----------------------------------------------------------------------
 [Test]
 public static void argument_is_empty()
 {
  try
  {
   xEFCore.ThrowSysError.argument_is_empty
    (xEFCore.ErrSourceID.common,
     "mmm",
     "ppp");
  }
  catch(ArgumentException e)
  {
   CheckErrors.PrintException_OK(e);

   CheckErrors.CheckException__ArgumentIsEmpty
    (e,
     CheckErrors.c_src__EFCoreDataProvider__common,
     "mmm",
     "ppp");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//argument_is_empty

 //-----------------------------------------------------------------------
 [Test]
 public static void cant_alloc_new_array__overflow()
 {
  try
  {
   xEFCore.ThrowSysError.cant_alloc_new_array__overflow
    (xEFCore.ErrSourceID.common,
     "PLACE",
     "#POINT");
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception exc)
  {
   CheckErrors.PrintException_OK(exc);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(exc));

   CheckErrors.CheckErrorRecord__common_err__cant_alloc_new_array__overflow__2
    (TestUtils.GetRecord(exc,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     "PLACE",
     "#POINT");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//cant_alloc_new_array__overflow

 //-----------------------------------------------------------------------
 [Test]
 public static void overflow_in_arithmetic_op2__TA1__TA2()
 {
  var innerException=new ApplicationException("ASDF");

  try
  {
   xEFCore.ThrowSysError.overflow_in_arithmetic_op2
    (xEFCore.ErrSourceID.common,
     System.Linq.Expressions.ExpressionType.Add,
     1,
     2,
     innerException);
  }
  catch(structure_lib.exceptions.t_overflow_exception exc)
  {
   CheckErrors.PrintException_OK(exc);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(exc));

   CheckErrors.CheckErrorRecord__common_err__overflow_in_arithmetic_op2__5<int,int>
    (TestUtils.GetRecord(exc,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     System.Linq.Expressions.ExpressionType.Add,
     1,
     2);

   Assert.AreSame
    (innerException,
     exc.InnerException);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//overflow_in_arithmetic_op2__TA1__TA2

 //-----------------------------------------------------------------------
 [Test]
 public static void out_of_range_in_arithmetic_op2__TA1__TA2()
 {
  try
  {
   xEFCore.ThrowSysError.out_of_range_in_arithmetic_op2
    (xEFCore.ErrSourceID.common,
     System.Linq.Expressions.ExpressionType.Add,
     1,
     2);
  }
  catch(structure_lib.exceptions.t_overflow_exception exc)
  {
   CheckErrors.PrintException_OK(exc);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(exc));

   CheckErrors.CheckErrorRecord__common_err__out_of_range_in_arithmetic_op2__5<int,int>
    (TestUtils.GetRecord(exc,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     System.Linq.Expressions.ExpressionType.Add,
     1,
     2);

   Assert.IsNull
    (exc.InnerException);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//out_of_range_in_arithmetic_op2__TA1__TA2

 //-----------------------------------------------------------------------
 [Test]
 public static void divide_by_zero()
 {
  var innerException=new DivideByZeroException("ASSASA");

  try
  {
   xEFCore.ThrowSysError.divide_by_zero
    (xEFCore.ErrSourceID.common,
     innerException);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception exc)
  {
   CheckErrors.PrintException_OK(exc);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(exc));

   CheckErrors.CheckErrorRecord__common_err__divide_by_zero
    (TestUtils.GetRecord(exc,0),
     CheckErrors.c_src__EFCoreDataProvider__common);

   Assert.AreSame
    (innerException,
     exc.InnerException);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//divide_by_zero
};//class TestSet_01

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.ThrowSysError

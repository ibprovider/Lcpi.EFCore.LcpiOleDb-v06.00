////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 15.05.2018.
using NUnit.Framework;

using com_lib=lcpi.lib.com;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Objects.OleDbDataToolException{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_01__Constructors

public static class TestSet_01__Constructors
{
 [Test]
 public static void Test_01__hr_src_msg()
 {
  var exc=new xEFCore.LcpiOleDb__DataToolException
                (com_lib.HResultCode.E_FAIL,
                 xEFCore.ErrSourceID.LcpiOleDb__DataToolException,
                 xEFCore.ErrMessageID.common_err__method_not_impl__1);

  exc.push("aaaaa");

  Assert.AreEqual(com_lib.HResultCode.E_FAIL,
                  exc.ErrorCode);

  Assert.AreEqual
   (1,
    TestUtils.GetRecordCount(exc));

  Assert.NotNull
   (TestUtils.GetRecord(exc,0));

  //----------------------------------------
  CheckErrors.PrintException(exc);

  //----------------------------------------
  var c_src
   =CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__DataToolException;

  var ru_msg
   ="Метод \"aaaaa\" не реализован.";

  var en_msg
   ="Method \"aaaaa\" was not implemented.";

  //------
  CheckErrors.TestExceptionSrcAndDescr__RU_EN
   (exc,
    c_src,
    ru_msg,
    en_msg,
    com_lib.HResultCode.E_FAIL);
 }//Test_01__hr_src_msg

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02__hr()
 {
  var exc=new xEFCore.LcpiOleDb__DataToolException(com_lib.HResultCode.E_ABORT);

  Assert.AreEqual
   (com_lib.HResultCode.E_ABORT,
    exc.ErrorCode);

  Assert.AreEqual
   (0,
    TestUtils.GetRecordCount(exc));

  //----------------------------------------
  CheckErrors.PrintException(exc);

  //------
  var c_src
   =CheckErrors.c_src__EFCoreDataProvider__Unknown;

  //------
  CheckErrors.TestExceptionSrcAndDescr
   (exc,
    "RU",
    c_src,
    null,
    "Код ошибки COM: E_ABORT.");

  CheckErrors.TestExceptionSrcAndDescr
   (exc,
    "EN",
    c_src,
    null,
    "The COM error code: E_ABORT.");
 }//Test_02__hr

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_03__two_recs()
 {
  var exc=new xEFCore.LcpiOleDb__DataToolException(com_lib.HResultCode.E_ABORT);

  exc.add_error(com_lib.HResultCode.E_NOTIMPL,
                xEFCore.ErrSourceID.LcpiOleDb__DataToolException,
                xEFCore.ErrMessageID.common_err__method_not_impl__1);

  exc.push("aaaaa");

  exc.add_error(com_lib.HResultCode.E_INVALIDARG,
                xEFCore.ErrSourceID.Core_ExceptionRecord,
                xEFCore.ErrMessageID.common_err__method_not_impl__1);

  exc.push("bbbbb");

  //----------------------------------------
  Assert.AreEqual(com_lib.HResultCode.E_ABORT,
                  exc.ErrorCode);

  Assert.AreEqual(2,
                  TestUtils.GetRecordCount(exc));

  Assert.NotNull(TestUtils.GetRecord(exc,0));
  Assert.NotNull(TestUtils.GetRecord(exc,1));

  //----------------------------------------
  CheckErrors.PrintException(exc);

  //----------------------------------------
  {
   var c_src
    =CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__DataToolException;

   var ru_msg
    ="Метод \"aaaaa\" не реализован.";

   var en_msg
    ="Method \"aaaaa\" was not implemented.";

   //------
   CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
    (TestUtils.GetRecord(exc,0),
     c_src,
     ru_msg,
     en_msg,
     com_lib.HResultCode.E_NOTIMPL);
  }//local

  //----------------------------------------
  {
   var c_src
    =CheckErrors.c_src__EFCoreDataProvider__Core_ExceptionRecord;

   var ru_msg
    ="Метод \"bbbbb\" не реализован.";

   var en_msg
    ="Method \"bbbbb\" was not implemented.";

   //------
   CheckErrors.TestErrRecordSrcAndDescr2_RU_EN
    (TestUtils.GetRecord(exc,1),
     c_src,
     ru_msg,
     en_msg,
     com_lib.HResultCode.E_INVALIDARG);
  }//local

 }//Test_03__two_recs
};//class TestSet_01__Constructors

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Objects.OleDbDataToolException

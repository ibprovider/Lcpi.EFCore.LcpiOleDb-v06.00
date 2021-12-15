////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 15.05.2018.

#if   BUILD_CONF__NET5_0_0
//# define LOCAL_BUILD_CONF__support_bin_serialization
#elif BUILD_CONF__NET6_0_0
//# define LOCAL_BUILD_CONF__support_bin_serialization
#else
# error "Unexpected Target Platform!"
#endif

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NUnit.Framework;

using com_lib=lcpi.lib.com;
using structure_lib=lcpi.lib.structure;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Objects.OleDbDataToolException{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_02__Serialization_bin

public static class TestSet_02__Serialization_bin
{
#if LOCAL_BUILD_CONF__support_bin_serialization

 [Test]
 public static void Test_01__hr_src_msg()
 {
  var exc=new xEFCore.LcpiOleDb__DataToolException
               (com_lib.HResultCode.E_FAIL,
                xEFCore.ErrSourceID.LcpiOleDb__DataToolException,
                xEFCore.ErrMessageID.common_err__method_not_impl__1);

  exc.push("aaaaa");

  //----------------------------------------
  TestServices.Exception__TestSerialization_bin(exc);
 }//Test_01__hr_src_msg

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02__hr()
 {
  var exc=new xEFCore.LcpiOleDb__DataToolException(com_lib.HResultCode.E_NOTIMPL);

  //----------------------------------------
  TestServices.Exception__TestSerialization_bin(exc);
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

  exc.add_error(com_lib.HResultCode.E_NOTIMPL,
                xEFCore.ErrSourceID.Core_ExceptionRecord,
                xEFCore.ErrMessageID.common_err__method_not_impl__1);

  exc.push("bbbbb");

  //----------------------------------------
  TestServices.Exception__TestSerialization_bin(exc);
 }//Test_03__two_recs

#endif //LOCAL_BUILD_CONF__support_bin_serialization

 //-----------------------------------------------------------------------
 [Serializable]
 private class tag_bad_exc:Exception
 {
  public tag_bad_exc(List<structure_lib.IErrorRecord> records,
                     structure_lib.IErrorRecord       cur_record)
  {
   m_records=records;

   m_cur_record=cur_record;
  }//null

  //----------------------------------------
  public override void GetObjectData(SerializationInfo si,
                                     StreamingContext  sc)
  {
   base.GetObjectData(si,sc);

   Assert.That(si,Is.Not.Null);

   //----
   structure_lib.SerializationUtils.WriteValue
    (si,
     c_prop_name__m_records,
     m_records);

   structure_lib.SerializationUtils.WriteValue
    (si,
     c_prop_name__m_cur_record,
     m_cur_record);

   //----
   si.SetType(typeof(xEFCore.LcpiOleDb__DataToolException));
  }//GetObjectData

  //----------------------------------------
  private const string c_prop_name__m_records
   =CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__DataToolException+".m_Records";

  private const string c_prop_name__m_cur_record
   =CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__DataToolException+".m_CurRecord";

  //----------------------------------------
  private readonly List<structure_lib.IErrorRecord> m_records;

  private readonly structure_lib.IErrorRecord m_cur_record;
 };//class tag_bad_oledb_exc

 //-----------------------------------------------------------------------
#if LOCAL_BUILD_CONF__support_bin_serialization

 [Test]
 public static void Test_10__BugCheck__state_001()
 {
  var err_rec=new xEFCore.Core.Core_ExceptionRecord
                   (com_lib.HResultCode.E_NOTIMPL,
                    xEFCore.ErrSourceID.Core_ExceptionRecord,
                    xEFCore.ErrMessageID.common_err__method_not_impl__1);

  err_rec.push("m1");

  var bad_exc=new tag_bad_exc
                    (null,
                     err_rec);

  try
  {
   var x=TestServices.CloneThroughSerialization_bin(bad_exc); //throw!
  }
  catch(SerializationException exc)
  {
   CheckErrors.CheckException__DeserializationError
    (exc,
     CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__DataToolException,
     "#001");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_10__BugCheck__state_001

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_11__BugCheck__state_002()
 {
  var err_rec=new xEFCore.Core.Core_ExceptionRecord
                   (com_lib.HResultCode.E_NOTIMPL,
                    xEFCore.ErrSourceID.Core_ExceptionRecord,
                    xEFCore.ErrMessageID.common_err__method_not_impl__1);

  err_rec.push("m1");

  var bad_exc=new tag_bad_exc
                    (new List<structure_lib.IErrorRecord>(),
                     err_rec);

  try
  {
   var x=TestServices.CloneThroughSerialization_bin(bad_exc); //throw!
  }
  catch(SerializationException exc)
  {
   CheckErrors.CheckException__DeserializationError
    (exc,
     CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__DataToolException,
     "#002");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_11__BugCheck__state_002

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_12__BugCheck__state_003()
 {
  var err_rec1=new xEFCore.Core.Core_ExceptionRecord
                    (com_lib.HResultCode.E_NOTIMPL,
                     xEFCore.ErrSourceID.Core_ExceptionRecord,
                     xEFCore.ErrMessageID.common_err__method_not_impl__1);

  err_rec1.push("m1");

  //----------
  var err_rec2=new xEFCore.Core.Core_ExceptionRecord
                    (com_lib.HResultCode.E_NOTIMPL,
                     xEFCore.ErrSourceID.Core_ExceptionRecord,
                     xEFCore.ErrMessageID.common_err__method_not_impl__1);

  err_rec2.push("m2");

  //----------
  var bad_exc=new tag_bad_exc
                   (new List<structure_lib.IErrorRecord>(1){err_rec1},
                    err_rec2);

  try
  {
   var x=TestServices.CloneThroughSerialization_bin(bad_exc); //throw!
  }
  catch(SerializationException exc)
  {
   CheckErrors.CheckException__DeserializationError
    (exc,
     CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__DataToolException,
     "#003");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_12__BugCheck__state_003

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_13__BugCheck__null_element_ptr()
 {
  var bad_exc=new tag_bad_exc
                   (new List<structure_lib.IErrorRecord>(0){null},
                    null);

  try
  {
   var x=TestServices.CloneThroughSerialization_bin(bad_exc); //throw!
  }
  catch(SerializationException exc)
  {
   CheckErrors.CheckException__DeserializationError__NullPtrToElement
    (exc,
     CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__DataToolException,
     0,
     CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__DataToolException+".m_Records");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_13__BugCheck__null_element_ptr

#endif //LOCAL_BUILD_CONF__support_bin_serialization
};//class TestSet_02__Serialization_bin

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Objects.OleDbDataToolException

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
using System.Runtime.Serialization;
using System.Globalization;
using System.Collections.Generic;
using NUnit.Framework;

using com_lib=lcpi.lib.com;
using structure_lib=lcpi.lib.structure;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Core.Core_ExceptionRecord{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_02__serialization_bin

public static class TestSet_02__serialization_bin
{
#if LOCAL_BUILD_CONF__support_bin_serialization

 [Test]
 public static void Test_01()
 {
  var rec1=new xEFCore.Core.Core_ExceptionRecord
                 (com_lib.HResultCode.E_FAIL,
                  xEFCore.ErrSourceID.Core_ExceptionRecord,
                  xEFCore.ErrMessageID.common_err__argument_is_null__2);

  rec1.push("Method1");
  rec1.push("Arg1");

  var obj_rec2=TestServices.CloneThroughSerialization_bin(rec1);

  Assert.NotNull(obj_rec2);
  Assert.IsInstanceOf<xEFCore.Core.Core_ExceptionRecord>(obj_rec2);

  Assert.AreNotSame(rec1,
                    obj_rec2);

  var rec2=(xEFCore.Core.Core_ExceptionRecord)obj_rec2;

  CheckErrors.ErrorRecord__CheckEqual
   (rec1,
    rec2,
    /*rec2_is_clone*/true);

  Assert.AreEqual(rec1.GetErrorCode(),
                  rec2.GetErrorCode());

  Assert.AreEqual(rec1.GetSource(CultureInfo.InvariantCulture),
                  rec2.GetSource(CultureInfo.InvariantCulture));

  Assert.AreEqual(rec1.GetDescription(CultureInfo.InvariantCulture),
                  rec2.GetDescription(CultureInfo.InvariantCulture));

  //----
  Assert.AreEqual(rec1.GetSystemID(),
                  rec2.GetSystemID());

  Assert.AreEqual(rec1.GetSubSystemID(),
                  rec2.GetSubSystemID());

  Assert.AreEqual(rec1.GetHelpFile(CultureInfo.InvariantCulture),
                  rec2.GetHelpFile(CultureInfo.InvariantCulture));

  Assert.AreEqual(rec1.GetHelpContextID(CultureInfo.InvariantCulture),
                  rec2.GetHelpContextID(CultureInfo.InvariantCulture));
 }//Test_01

#endif //LOCAL_BUILD_CONF__support_bin_serialization

 //-----------------------------------------------------------------------
 [Serializable]
 private sealed class bad_core_exc_record:ISerializable
 {
  public bad_core_exc_record(bool save__m_ComErrorCode,
                             bool save__m_SourceID,
                             bool save__m_MessageID,
                             bool save__m_Args)
  {
   m_save__m_ComErrorCode   = save__m_ComErrorCode ;
   m_save__m_SourceID       = save__m_SourceID     ;
   m_save__m_MessageID      = save__m_MessageID    ;
   m_save__m_Args           = save__m_Args         ;
  }//bad_core_exc_record

  //----------------------------------------
  public void GetObjectData(SerializationInfo si,
                            StreamingContext  sc)
  {
   Assert.That(si,Is.Not.Null);

   //---------------------------------------
   if(m_save__m_ComErrorCode)
   {
     structure_lib.SerializationUtils.WriteValue
     (si,
      c_prop_name__m_ComErrorCode,
      com_lib.HResultCode.E_FAIL);
   }//if

   //---------------------------------------
   if(m_save__m_SourceID)
   {
    structure_lib.SerializationUtils.WriteValue
     (si,
      c_prop_name__m_SourceID,
      xEFCore.ErrSourceID.Core_ExceptionRecord);
   }//if

   //---------------------------------------
   if(m_save__m_MessageID)
   {
    structure_lib.SerializationUtils.WriteValue
     (si,
      c_prop_name__m_MessageID,
      xEFCore.ErrMessageID.com_err__com_code_error_1);
   }//if

   //---------------------------------------
   if(m_save__m_Args)
   {
    structure_lib.SerializationUtils.WriteValue
     (si,
      c_prop_name__m_Args,
      (List<object>)null);
   }//if

   //---------------------------------------
   si.SetType(typeof(xEFCore.Core.Core_ExceptionRecord));
  }//GetObjectData

  //----------------------------------------
  private const string c_prop_name__m_ComErrorCode
    =CheckErrors.c_src__EFCoreDataProvider__Core_ExceptionRecord+".m_ComErrorCode";

  private const string c_prop_name__m_SourceID
    =CheckErrors.c_src__EFCoreDataProvider__Core_ExceptionRecord+".m_SourceID";

  private const string c_prop_name__m_MessageID
    =CheckErrors.c_src__EFCoreDataProvider__Core_ExceptionRecord+".m_MessageID";

  private const string c_prop_name__m_Args
    =CheckErrors.c_src__EFCoreDataProvider__Core_ExceptionRecord+".m_Args";

  //----------------------------------------
  private readonly bool m_save__m_ComErrorCode;
  private readonly bool m_save__m_SourceID;
  private readonly bool m_save__m_MessageID;
  private readonly bool m_save__m_Args;
 };//class bad_core_exc_record

 //-----------------------------------------------------------------------
#if LOCAL_BUILD_CONF__support_bin_serialization

 [Test]
 public static void Test_02__err__no_m_ComErrorCode()
 {
  var rec=new bad_core_exc_record(/*save__m_ComErrorCode*/false,
                                  /*save__m_SourceID    */true,
                                  /*save__m_MessageID   */true,
                                  /*save__m_Args        */true);

  try
  {
   TestServices.CloneThroughSerialization_bin(rec); //throw!
  }
  catch(Exception e)
  {
   Helper__CheckDeserializationError
    (e,
     CheckErrors.c_src__EFCoreDataProvider__Core_ExceptionRecord+".m_ComErrorCode");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_02__err__no_m_ComErrorCode

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_03__err__no_m_SourceID()
 {
  var rec=new bad_core_exc_record(/*save__m_ComErrorCode*/true,
                                  /*save__m_SourceID    */false,
                                  /*save__m_MessageID   */true,
                                  /*save__m_Args        */true);

  try
  {
   TestServices.CloneThroughSerialization_bin(rec); //throw!
  }
  catch(Exception e)
  {
   Helper__CheckDeserializationError
    (e,
     CheckErrors.c_src__EFCoreDataProvider__Core_ExceptionRecord+".m_SourceID");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_03__err__no_m_SourceID

#endif //LOCAL_BUILD_CONF__support_bin_serialization

 //-----------------------------------------------------------------------
#if LOCAL_BUILD_CONF__support_bin_serialization

 [Test]
 public static void Test_04__err__no_m_MessageID()
 {
  var rec=new bad_core_exc_record(/*save__m_ComErrorCode*/true,
                                  /*save__m_SourceID    */true,
                                  /*save__m_MessageID   */false,
                                  /*save__m_Args        */true);

  try
  {
   TestServices.CloneThroughSerialization_bin(rec); //throw!
  }
  catch(Exception e)
  {
   Helper__CheckDeserializationError
    (e,
     CheckErrors.c_src__EFCoreDataProvider__Core_ExceptionRecord+".m_MessageID");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_04__err__no_m_MessageID

#endif //LOCAL_BUILD_CONF__support_bin_serialization

 //-----------------------------------------------------------------------
#if LOCAL_BUILD_CONF__support_bin_serialization

 [Test]
 public static void Test_05__err__no_m_Args()
 {
  var rec=new bad_core_exc_record(/*save__m_ComErrorCode*/true,
                                  /*save__m_SourceID    */true,
                                  /*save__m_MessageID   */true,
                                  /*save__m_Args        */false);

  try
  {
   TestServices.CloneThroughSerialization_bin(rec); //throw!
  }
  catch(Exception e)
  {
   Helper__CheckDeserializationError
    (e,
     CheckErrors.c_src__EFCoreDataProvider__Core_ExceptionRecord+".m_Args");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_05__err__no_m_Args

#endif //LOCAL_BUILD_CONF__support_bin_serialization

 //-----------------------------------------------------------------------
 private static void Helper__CheckDeserializationError(Exception e,
                                                       string    MemberSign)
 {
  CheckErrors.PrintException_OK(e);

  Assert.IsInstanceOf<System.Reflection.TargetInvocationException>(e);

  Assert.IsInstanceOf<SerializationException>(e.InnerException);

  Assert.IsTrue(e.InnerException.Message.Contains(MemberSign));
 }//Helper__CheckDeserializationError
};//class TestSet_02__serialization_bin

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Core.Core_ExceptionRecord

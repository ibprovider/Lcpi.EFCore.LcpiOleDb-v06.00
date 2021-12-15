////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 30.11.2021.
using NUnit.Framework;

using structure_lib=lcpi.lib.structure;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.Check{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__BugCheck_Value_NotNullAndNotEmpty

public static class TestsFor__BugCheck_Value_NotNullAndNotEmpty
{
 [Test]
 public static void Test_01__ok()
 {
  xEFCore.Check.BugCheck_Value_NotNullAndNotEmpty
   (xEFCore.ErrSourceID.Core_ConnectionOptionsInitializer,
    "place",
    "point",
    "valueName",
    "value");
 }//Test_01__ok

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02__err__null()
 {
  try
  {
  xEFCore.Check.BugCheck_Value_NotNullAndNotEmpty
   (xEFCore.ErrSourceID.common,
    "place",
    "point",
    "valueName",
    null);
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
 }//Test_02__err__null

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_03__err__empty()
 {
  try
  {
  xEFCore.Check.BugCheck_Value_NotNullAndNotEmpty
   (xEFCore.ErrSourceID.common,
    "place",
    "point",
    "valueName1",
    "");
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
     "valueName1");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_03__err__empty
};//class TestsFor__BugCheck_Value_NotNullAndNotEmpty

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.Check

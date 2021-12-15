////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 21.10.2020.
using NUnit.Framework;

using structure_lib=lcpi.lib.structure;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.Check{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__BugCheck_Value_NotNull

public static class TestsFor__BugCheck_Value_NotNull
{
 [Test]
 public static void Test_01__ok()
 {
  xEFCore.Check.BugCheck_Value_NotNull
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
  xEFCore.Check.BugCheck_Value_NotNull
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
};//class TestsFor__BugCheck_Value_NotNull

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.Check

////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 14.10.2020.
using NUnit.Framework;

using structure_lib=lcpi.lib.structure;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.Check{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__BugCheck_Value_NotNullAndInstanceOf

public static class TestsFor__BugCheck_Value_NotNullAndInstanceOf
{
 class TBase
 {
 };//class TBase

 //-----------------------------------------------------------------------
 class TObj:TBase
 {
 };//class TObj

 //-----------------------------------------------------------------------
 class TObj2:TBase
 {
 };//class TObj2

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_01__ok()
 {
  TBase b=new TObj();

  TObj x
   =xEFCore.Check.BugCheck_Value_NotNullAndInstanceOf<TObj,TBase>
     (xEFCore.ErrSourceID.common,
      "place",
      "point",
      "valueName",
      b);

  Assert.NotNull(x);
  Assert.AreSame(b,x);
 }//Test_01__ok

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02__err__null()
 {
  try
  {
   xEFCore.Check.BugCheck_Value_NotNullAndInstanceOf<TObj,TBase>
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
 public static void Test_03__err__bad()
 {
  TBase b=new TObj2();

  try
  {
   xEFCore.Check.BugCheck_Value_NotNullAndInstanceOf<TObj,TBase>
    (xEFCore.ErrSourceID.common,
     "place",
     "point",
     "valueName",
     b);
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
     "place",
     "point",
     "valueName",
     b.GetType(),
     typeof(TObj));

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_03__err__bad
};//class TestsFor__BugCheck_Value_NotNullAndInstanceOf

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.Check

////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 21.10.2020.
using NUnit.Framework;

using structure_lib=lcpi.lib.structure;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.Check{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__Arg_ListSize__GreaterThanOrEqual

public static class TestsFor__Arg_ListSize__GreaterThanOrEqual
{
 [Test]
 public static void Test_01__ok()
 {
  xEFCore.Check.Arg_ListSize__GreaterThanOrEqual
   (xEFCore.ErrSourceID.common,
    "x1",
    "x2",
    2,
    2);
 }//Test_01__ok

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02__ok()
 {
  xEFCore.Check.Arg_ListSize__GreaterThanOrEqual
   (xEFCore.ErrSourceID.common,
    "x1",
    "x2",
    3,
    2);
 }//Test_02__ok

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_ERR01()
 {
  try
  {
   xEFCore.Check.Arg_ListSize__GreaterThanOrEqual
    (xEFCore.ErrSourceID.common,
     "x1",
     "x2",
     2,
     3);
  }
  catch(structure_lib.exceptions.t_argument_exception e)
  {
   CheckErrors.PrintException_OK(e);

   CheckErrors.CheckException__ArgErr_BadListSize
    (e,
     CheckErrors.c_src__EFCoreDataProvider__common,
     "x1",
     "x2",
     2);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_ERR01
};//class TestsFor__Arg_ListSize__GreaterThanOrEqual

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.Check

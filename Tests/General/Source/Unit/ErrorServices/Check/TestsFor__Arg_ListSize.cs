////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 21.10.2020.
using NUnit.Framework;

using structure_lib=lcpi.lib.structure;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.Check{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__Arg_ListSize

public static class TestsFor__Arg_ListSize
{
 [Test]
 public static void Test_01__ok()
 {
  xEFCore.Check.Arg_ListSize
   (xEFCore.ErrSourceID.common,
    "x1",
    "x2",
    1,
    1);
 }//Test_01__ok

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02__err()
 {
  try
  {
   xEFCore.Check.Arg_ListSize
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
     2,
     3);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_02__err__not_null
};//class TestsFor__Arg_ListSize

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.Check

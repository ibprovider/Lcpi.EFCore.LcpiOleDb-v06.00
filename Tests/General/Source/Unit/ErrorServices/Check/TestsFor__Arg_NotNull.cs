////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 14.10.2020.
using NUnit.Framework;

using structure_lib=lcpi.lib.structure;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.Check{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__Arg_NotNull

public static class TestsFor__Arg_NotNull
{
 [Test]
 public static void Test_01__ok()
 {
  xEFCore.Check.Arg_NotNull
   (xEFCore.ErrSourceID.Core_ConnectionOptionsInitializer,
    "x1",
    "x2",
    "value");
 }//Test_01__ok

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02__err__null()
 {
  try
  {
   xEFCore.Check.Arg_NotNull
    (xEFCore.ErrSourceID.Core_ConnectionOptionsInitializer,
     "x1",
     "x2",
     null);
  }
  catch(structure_lib.exceptions.t_argument_null_exception e)
  {
   CheckErrors.PrintException_OK(e);

   CheckErrors.CheckException__ArgumentNullException
    (e,
     CheckErrors.c_src__EFCoreDataProvider__Core_ConnectionOptionsInitializer,
     "x1",
     "x2");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_02__err__null
};//class TestsFor__Arg_NotNull

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.Check

////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 03.11.2021.
using System.Collections.Generic;

using NUnit.Framework;

using structure_lib=lcpi.lib.structure;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.Check{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__Arg_NotNullAndNotEmpty___T

public static class TestsFor__Arg_NotNullAndNotEmpty___T
{
 [Test]
 public static void Test_01__ok()
 {
  IReadOnlyCollection<int>
   value
    =new[]{1,2,3};

  xEFCore.Check.Arg_NotNullAndNotEmpty
   (xEFCore.ErrSourceID.Core_ConnectionOptionsInitializer,
    "y1",
    "y2",
    value);
 }//Test_01__ok

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02__err__null()
 {
  IReadOnlyCollection<int>
   value
    =null;

  try
  {
   xEFCore.Check.Arg_NotNullAndNotEmpty
    (xEFCore.ErrSourceID.Core_ConnectionOptionsInitializer,
     "y1",
     "y2",
     value);
  }
  catch(structure_lib.exceptions.t_argument_null_exception e)
  {
   CheckErrors.PrintException_OK(e);

   CheckErrors.CheckException__ArgumentNullException
    (e,
     CheckErrors.c_src__EFCoreDataProvider__Core_ConnectionOptionsInitializer,
     "y1",
     "y2");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_02__err__null

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_03__err__empty()
 {
  IReadOnlyCollection<int>
   value
    =new int[]{};

  try
  {
   xEFCore.Check.Arg_NotNullAndNotEmpty
    (xEFCore.ErrSourceID.Core_ConnectionOptionsInitializer,
     "y1",
     "y2",
     value);
  }
  catch(structure_lib.exceptions.t_argument_exception e)
  {
   CheckErrors.PrintException_OK(e);

   CheckErrors.CheckException__ArgumentIsEmpty
    (e,
     CheckErrors.c_src__EFCoreDataProvider__Core_ConnectionOptionsInitializer,
     "y1",
     "y2");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_03__err__empty
};//class TestsFor__Arg_NotNullAndNotEmpty___T

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.Check

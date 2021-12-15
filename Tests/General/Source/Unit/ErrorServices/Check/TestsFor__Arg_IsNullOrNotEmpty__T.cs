////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 03.11.2021.
using System.Collections.Generic;
using NUnit.Framework;

using structure_lib=lcpi.lib.structure;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.Check{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__Arg_IsNullOrNotEmpty__T

public static class TestsFor__Arg_IsNullOrNotEmpty__T
{
 [Test]
 public static void Test_01__ok__null()
 {
  IReadOnlyCollection<int>
   value
    =null;

  xEFCore.Check.Arg_IsNullOrNotEmpty
   (xEFCore.ErrSourceID.common,
    "x1",
    "x2",
    value);
 }//Test_01__ok__null

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02__ok__not_empty()
 {
  IReadOnlyCollection<int>
   value
    =new[]{1,2,3};

  xEFCore.Check.Arg_IsNullOrNotEmpty
   (xEFCore.ErrSourceID.common,
    "x1",
    "x2",
    value);
 }//Test_02__ok__not_empty

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_03__err__Empty()
 {
  IReadOnlyCollection<int>
   value
    =new int[0];

  try
  {
   xEFCore.Check.Arg_IsNullOrNotEmpty
    (xEFCore.ErrSourceID.common,
     "x1",
     "x2",
     value);
  }
  catch(structure_lib.exceptions.t_argument_exception e)
  {
   CheckErrors.PrintException_OK(e);

   CheckErrors.CheckException__ArgumentIsEmpty
    (e,
     CheckErrors.c_src__EFCoreDataProvider__common,
     "x1",
     "x2");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_03__err__Empty
};//class TestsFor__Arg_IsNullOrNotEmpty__T

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.Check

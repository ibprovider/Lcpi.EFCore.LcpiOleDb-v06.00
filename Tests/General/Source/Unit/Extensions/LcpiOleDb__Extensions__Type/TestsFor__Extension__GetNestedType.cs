////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 30.04.2021.
using System.Reflection;
using NUnit.Framework;

using Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

using structure_lib=lcpi.lib.structure;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Extensions.LcpiOleDb__Extensions__Type{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__Extension__GetNestedType

public static class TestsFor__Extension__GetNestedType
{
 private class tagObj
 {
  private void method(int a,out long b)
  {
   b=-a;
  }

  private int method(short r)
  {
   return -r;
  }
 };//class tagObj

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_01()
 {
  var x=new tagObj();

  var t
   =typeof(TestsFor__Extension__GetNestedType).Extension__GetNestedType
     ("tagObj",
      BindingFlags.NonPublic);

  Assert.NotNull
   (t);

  Assert.AreEqual
   (typeof(tagObj),
    t);
 }//Test_01

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_E01__not_found()
 {
  var x
   =new tagObj();

  try
  {
   var t
    =typeof(TestsFor__Extension__GetNestedType).Extension__GetNestedType
      ("tagobj",
       BindingFlags.NonPublic);

   TestServices.ThrowWeWaitError();
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__bug_check__get_nested_type__not_found_3
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__Extensions__Type,
     typeof(TestsFor__Extension__GetNestedType),
     "tagobj",
     BindingFlags.NonPublic);

   return;
  }//catch
 }//Test_E01__not_found
};//class TestsFor__Extension__GetNestedType

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Extensions.LcpiOleDb__Extensions__Type

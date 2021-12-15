////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 22.10.2021.
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_StrHelpers{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__TestStrRange__ASCII_UPPER__span

public static class TestsFor__TestStrRange__ASCII_UPPER__span
{
 [Test]
 public static void Test_001()
 {
  Assert.IsTrue
   (xEFCore.Structure.Structure_StrHelpers.TestStrRange__ASCII_UPPER
     ("ABCD",
      "ABCD"));
 }//Test_001

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002()
 {
  Assert.IsTrue
   (xEFCore.Structure.Structure_StrHelpers.TestStrRange__ASCII_UPPER
     ("abcd",
      "ABCD"));
 }//Test_002

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_003()
 {
  Assert.IsFalse
   (xEFCore.Structure.Structure_StrHelpers.TestStrRange__ASCII_UPPER
     ("abce",
      "ABCD"));
 }//Test_003

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_004()
 {
  Assert.IsFalse
   (xEFCore.Structure.Structure_StrHelpers.TestStrRange__ASCII_UPPER
     ("ABCDE",
      "ABCD"));
 }//Test_004

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_005()
 {
  Assert.IsFalse
   (xEFCore.Structure.Structure_StrHelpers.TestStrRange__ASCII_UPPER
     ("ABC",
      "ABCD"));
 }//Test_005
};//class TestsFor__TestStrRange__ASCII_UPPER__span

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_StrHelpers

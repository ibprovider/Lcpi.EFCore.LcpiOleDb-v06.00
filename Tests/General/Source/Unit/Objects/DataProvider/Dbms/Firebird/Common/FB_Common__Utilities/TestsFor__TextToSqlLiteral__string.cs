////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 18.10.2020.
using NUnit.Framework;

using xEFCore_c
 =Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Objects.DataProvider.Dbms.Firebird.Common.FB_Common__Utilities{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__TextToSqlLiteral__string

public static class TestsFor__TextToSqlLiteral__string
{
 [Test]
 public static void Test_01__empty()
 {
  Assert.AreEqual
   ("_utf8 ''",
    xEFCore_c.FB_Common__Utilities.TextToSqlLiteral(""));
 }//Test_01__from_0_to_32

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02()
 {
  Assert.AreEqual
   ("_utf8 x'00'",
    xEFCore_c.FB_Common__Utilities.TextToSqlLiteral("\0"));
 }//Test_02

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_03()
 {
  Assert.AreEqual
   ("_utf8 x'000D'",
    xEFCore_c.FB_Common__Utilities.TextToSqlLiteral("\0\r"));
 }//Test_03

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_04()
 {
  Assert.AreEqual
   ("_utf8 x'000D0A'",
    xEFCore_c.FB_Common__Utilities.TextToSqlLiteral("\0\r\n"));
 }//Test_04

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_05()
 {
  Assert.AreEqual
   ("_utf8 x'00'||_utf8 'A'||_utf8 x'0D'||_utf8 'B'||_utf8 x'0A'",
    xEFCore_c.FB_Common__Utilities.TextToSqlLiteral("\0A\rB\n"));
 }//Test_05

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_06()
 {
  Assert.AreEqual
   ("_utf8 x'00'||_utf8 'A'||_utf8 x'0D'||_utf8 'B'||_utf8 x'0A'||_utf8 'C'",
    xEFCore_c.FB_Common__Utilities.TextToSqlLiteral("\0A\rB\nC"));
 }//Test_06

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_07()
 {
  Assert.AreEqual
   ("_utf8 'ABC'",
    xEFCore_c.FB_Common__Utilities.TextToSqlLiteral("ABC"));
 }//Test_07

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_08()
 {
  Assert.AreEqual
   ("_utf8 'A'||_utf8 x'00'||_utf8 'B'||_utf8 x'0D'||_utf8 'C'",
    xEFCore_c.FB_Common__Utilities.TextToSqlLiteral("A\0B\rC"));
 }//Test_08

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_09()
 {
  Assert.AreEqual
   ("_utf8 'A'||_utf8 x'00'||_utf8 'B'||_utf8 x'0D'||_utf8 'C'||_utf8 x'0A'",
    xEFCore_c.FB_Common__Utilities.TextToSqlLiteral("A\0B\rC\n"));
 }//Test_09

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_10()
 {
  Assert.AreEqual
   ("_utf8 'A''B''''C'",
    xEFCore_c.FB_Common__Utilities.TextToSqlLiteral("A'B''C"));
 }//Test_10

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_11()
 {
  Assert.AreEqual
   ("_utf8 '''A''B''''C'",
    xEFCore_c.FB_Common__Utilities.TextToSqlLiteral("'A'B''C"));
 }//Test_11

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_12()
 {
  Assert.AreEqual
   ("_utf8 '''''A''B''''C'",
    xEFCore_c.FB_Common__Utilities.TextToSqlLiteral("''A'B''C"));
 }//Test_12

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_13()
 {
  Assert.AreEqual
   ("_utf8 x'0A'||_utf8 '''''A''B''''C'",
    xEFCore_c.FB_Common__Utilities.TextToSqlLiteral("\n''A'B''C"));
 }//Test_13
};//class TestsFor__TextToSqlLiteral__string

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Objects.DataProvider.Dbms.Firebird.Common.FB_Common__Utilities

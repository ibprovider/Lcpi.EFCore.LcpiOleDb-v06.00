////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 13.10.2020.
using NUnit.Framework;

using Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Extensions.LcpiOleDb__Extensions__Type{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__Extension__IsInteger__Exact

public static class TestsFor__Extension__IsInteger__Exact
{
 [Test]
 public static void Test_001__SByte()
 {
  Assert.IsTrue
   (typeof(System.SByte).Extension__IsInteger__Exact());
 }//Test_001__SByte

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002__Int16()
 {
  Assert.IsTrue
   (typeof(System.Int16).Extension__IsInteger__Exact());
 }//Test_002__Int16

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_003__Int32()
 {
  Assert.IsTrue
   (typeof(System.Int32).Extension__IsInteger__Exact());
 }//Test_003__Int32

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_004__Int64()
 {
  Assert.IsTrue
   (typeof(System.Int64).Extension__IsInteger__Exact());
 }//Test_004__Int64

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_005__Byte()
 {
  Assert.IsTrue
   (typeof(System.Byte).Extension__IsInteger__Exact());
 }//Test_005__Byte

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_006__UInt16()
 {
  Assert.IsTrue
   (typeof(System.UInt16).Extension__IsInteger__Exact());
 }//Test_006__UInt16

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_007__UInt32()
 {
  Assert.IsTrue
   (typeof(System.UInt32).Extension__IsInteger__Exact());
 }//Test_007__UInt32

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_008__UInt64()
 {
  Assert.IsTrue
   (typeof(System.UInt64).Extension__IsInteger__Exact());
 }//Test_008__UInt64

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_100__Single()
 {
  Assert.IsFalse
   (typeof(System.Single).Extension__IsInteger__Exact());
 }//Test_100__Single

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_101__Double()
 {
  Assert.IsFalse
   (typeof(System.Double).Extension__IsInteger__Exact());
 }//Test_101__Double
};//class TestsFor__Extension__IsInteger__Exact

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Extensions.LcpiOleDb__Extensions__Type

////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 13.10.2020.
using NUnit.Framework;

using Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Extensions.LcpiOleDb__Extensions__Type{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__Extension__IsNullableType

public static class TestsFor__Extension__IsNullableType
{
 [Test]
 public static void Test_01__Int16()
 {
  Assert.IsFalse
   (typeof(System.Int16).Extension__IsNullableType());
 }//Test_01__Int16

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02__Nullable_Int16()
 {
  Assert.IsTrue
   (typeof(System.Nullable<System.Int16>).Extension__IsNullableType());
 }//Test_02__Nullable_Int16

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_03__Object()
 {
  Assert.IsTrue
   (typeof(System.Object).Extension__IsNullableType());
 }//Test_03__Object

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_04__String()
 {
  Assert.IsTrue
   (typeof(System.String).Extension__IsNullableType());
 }//Test_04__String

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_05__Enum()
 {
  Assert.IsFalse
   (typeof(System.Enum).Extension__IsNullableType());
 }//Test_05__Enum

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_06__EnumInt16()
 {
  Assert.IsFalse
   (typeof(TestTypes.Enums.EnumInt16).Extension__IsNullableType());
 }//Test_06__EnumInt16

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_07__EnumInt32()
 {
  Assert.IsFalse
   (typeof(TestTypes.Enums.EnumInt32).Extension__IsNullableType());
 }//Test_07__EnumInt32

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_08__EnumInt64()
 {
  Assert.IsFalse
   (typeof(TestTypes.Enums.EnumInt64).Extension__IsNullableType());
 }//Test_08__EnumInt64

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_09__Nullable_EnumInt16()
 {
  Assert.IsTrue
   (typeof(System.Nullable<TestTypes.Enums.EnumInt16>).Extension__IsNullableType());
 }//Test_09__Nullable_EnumInt16

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_10__Nullable_EnumInt32()
 {
  Assert.IsTrue
   (typeof(System.Nullable<TestTypes.Enums.EnumInt32>).Extension__IsNullableType());
 }//Test_10__Nullable_EnumInt32

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_11__Nullable_EnumInt64()
 {
  Assert.IsTrue
   (typeof(System.Nullable<TestTypes.Enums.EnumInt64>).Extension__IsNullableType());
 }//Test_11__Nullable_EnumInt64
};//class TestsFor__Extension__IsNullableType

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Extensions.LcpiOleDb__Extensions__Type

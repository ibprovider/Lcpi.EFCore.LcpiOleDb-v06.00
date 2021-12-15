////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 12.06.2021.
using NUnit.Framework;

using Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Extensions.LcpiOleDb__Extensions__Type{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__Extension__IsNullableValueType

public static class TestsFor__Extension__IsNullableValueType
{
 [Test]
 public static void Test_01__Int16()
 {
  Assert.IsFalse
   (typeof(System.Int16).Extension__IsNullableValueType());
 }//Test_01__Int16

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02__Nullable_Int16()
 {
  Assert.IsTrue
   (typeof(System.Nullable<System.Int16>).Extension__IsNullableValueType());
 }//Test_02__Nullable_Int16

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_03__Object()
 {
  Assert.IsFalse
   (typeof(System.Object).Extension__IsNullableValueType());
 }//Test_03__Object

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_04__String()
 {
  Assert.IsFalse
   (typeof(System.String).Extension__IsNullableValueType());
 }//Test_04__String

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_05__Enum()
 {
  Assert.IsFalse
   (typeof(System.Enum).Extension__IsNullableValueType());
 }//Test_05__Enum

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_06__EnumInt16()
 {
  Assert.IsFalse
   (typeof(TestTypes.Enums.EnumInt16).Extension__IsNullableValueType());
 }//Test_06__EnumInt16

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_07__EnumInt32()
 {
  Assert.IsFalse
   (typeof(TestTypes.Enums.EnumInt32).Extension__IsNullableValueType());
 }//Test_07__EnumInt32

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_08__EnumInt64()
 {
  Assert.IsFalse
   (typeof(TestTypes.Enums.EnumInt64).Extension__IsNullableValueType());
 }//Test_08__EnumInt64

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_09__Nullable_EnumInt16()
 {
  Assert.IsTrue
   (typeof(System.Nullable<TestTypes.Enums.EnumInt16>).Extension__IsNullableValueType());
 }//Test_09__Nullable_EnumInt16

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_10__Nullable_EnumInt32()
 {
  Assert.IsTrue
   (typeof(System.Nullable<TestTypes.Enums.EnumInt32>).Extension__IsNullableValueType());
 }//Test_10__Nullable_EnumInt32

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_11__Nullable_EnumInt64()
 {
  Assert.IsTrue
   (typeof(System.Nullable<TestTypes.Enums.EnumInt64>).Extension__IsNullableValueType());
 }//Test_11__Nullable_EnumInt64

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_12__Nullable_generic()
 {
  Assert.IsFalse
   (typeof(System.Nullable<>).Extension__IsNullableValueType());
 }//Test_12__Nullable_generic
};//class TestsFor__Extension__IsNullableValueType

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Extensions.LcpiOleDb__Extensions__Type

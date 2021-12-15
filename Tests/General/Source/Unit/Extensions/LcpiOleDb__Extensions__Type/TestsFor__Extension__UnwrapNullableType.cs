////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 13.10.2020.
using NUnit.Framework;

using Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Extensions.LcpiOleDb__Extensions__Type{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__Extension__UnwrapNullableType

public static class TestsFor__Extension__UnwrapNullableType
{
 [Test]
 public static void Test_01__Int16()
 {
  Assert.AreEqual
   (typeof(System.Int16).Extension__UnwrapNullableType(),
    typeof(System.Int16));
 }//Test_01__Int16

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02__Nullable_DateTime()
 {
  Assert.AreEqual
   (typeof(System.Nullable<System.DateTime>).Extension__UnwrapNullableType(),
    typeof(System.DateTime));
 }//Test_02__Nullable_DateTime

 //-----------------------------------------------------------------------
 enum tagEnum03:uint
 {
  a,
  b,
  c,
 };//enum tagEnum03

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_03__tagEnum03()
 {
  Assert.AreEqual
   (typeof(tagEnum03).Extension__UnwrapNullableType(),
    typeof(tagEnum03));
 }//Test_03__tagEnum03

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_04__Nullable_tagEnum03()
 {
  Assert.AreEqual
   (typeof(System.Nullable<tagEnum03>).Extension__UnwrapNullableType(),
    typeof(tagEnum03));
 }//Test_04__Nullable_tagEnum03
};//class TestsFor__Extension__UnwrapNullableType

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Extensions.LcpiOleDb__Extensions__Type

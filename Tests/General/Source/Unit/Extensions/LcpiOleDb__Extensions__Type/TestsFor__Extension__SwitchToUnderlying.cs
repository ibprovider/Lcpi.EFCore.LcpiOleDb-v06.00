////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 12.06.2021.
using NUnit.Framework;

using Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Extensions.LcpiOleDb__Extensions__Type{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__Extension__SwitchToUnderlying

public static class TestsFor__Extension__SwitchToUnderlying
{
 [Test]
 public static void Test_01__Int16()
 {
  Assert.AreEqual
   (typeof(System.Int16).Extension__SwitchToUnderlying(),
    typeof(System.Int16));
 }//Test_01__Int16

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02__Nullable_DateTime()
 {
  Assert.AreEqual
   (typeof(System.Nullable<System.DateTime>).Extension__SwitchToUnderlying(),
    typeof(System.Nullable<System.DateTime>));
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
   (typeof(tagEnum03).Extension__SwitchToUnderlying(),
    typeof(uint));
 }//Test_03__tagEnum03

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_04__Nullable_tagEnum03()
 {
  Assert.AreEqual
   (typeof(System.Nullable<tagEnum03>).Extension__SwitchToUnderlying(),
    typeof(System.Nullable<uint>));
 }//Test_04__Nullable_tagEnum03

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_05__Array_Of_Nullable_tagEnum03()
 {
  Assert.AreEqual
   (typeof(System.Nullable<tagEnum03>[]).Extension__SwitchToUnderlying(),
    typeof(System.Nullable<uint>[]));
 }//Test_05__Array_Of_Nullable_tagEnum03
};//class TestsFor__Extension__SwitchToUnderlying

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Extensions.LcpiOleDb__Extensions__Type

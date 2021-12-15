////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 08.22.2020.
using NUnit.Framework;

using Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Extensions.LcpiOleDb__Extensions__Type{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__Extension__UnwrapMappingClrType

public static class TestsFor__Extension__UnwrapMappingClrType
{
 [Test]
 public static void Test_01__string()
 {
  Assert.AreEqual
   (typeof(string),
    typeof(string).Extension__UnwrapMappingClrType());
 }//Test_01__string

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02__Int32()
 {
  Assert.AreEqual
   (typeof(System.Int32),
    typeof(System.Int32).Extension__UnwrapMappingClrType());
 }//Test_02__Int32

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_03__DayOfWeek()
 {
  Assert.AreEqual
   (typeof(System.Int32),
    typeof(System.DayOfWeek).Extension__UnwrapMappingClrType());
 }//Test_03__DayOfWeek

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_04__self_type()
 {
  Assert.AreEqual
   (typeof(TestsFor__Extension__UnwrapMappingClrType),
    typeof(TestsFor__Extension__UnwrapMappingClrType).Extension__UnwrapMappingClrType());
 }//Test_04__self_type
};//class TestsFor__Extension__UnwrapMappingClrType

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Extensions.LcpiOleDb__Extensions__Type

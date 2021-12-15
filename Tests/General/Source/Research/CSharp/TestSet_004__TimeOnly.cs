////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 19.07.2021.
using NUnit.Framework;

namespace EFCore_LcpiOleDb_Tests.General.Research.CSharp{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_004__TimeOnly

public static class TestSet_004__TimeOnly
{
 [Test]
 public static void Test_01__Add_TimeSpan__01()
 {
  Assert.AreEqual
   (new System.TimeOnly(1,0,0),
    new System.TimeOnly(13,0,0).Add(new System.TimeSpan(12,0,0)));
 }//Test_01__Add_TimeSpan__01

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_01__Add_TimeSpan__02()
 {
  Assert.AreEqual
   (new System.TimeOnly(1,0,0),
    new System.TimeOnly(13,0,0).Add(new System.TimeSpan(1,12,0,0)));
 }//Test_01__Add_TimeSpan__02

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02__Subtract_TimeSpan__01()
 {
  Assert.AreEqual
   (new System.TimeOnly(1,0,0),
    new System.TimeOnly(13,0,0).Add(-new System.TimeSpan(12,0,0)));
 }//Test_02__Subtract_TimeSpan__01

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02__Subtract_TimeSpan__02()
 {
  Assert.AreEqual
   (new System.TimeOnly(1,0,0),
    new System.TimeOnly(13,0,0).Add(-new System.TimeSpan(1,12,0,0)));
 }//Test_02__Subtract_TimeSpan__02
};//class TestSet_004__TimeOnly

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Research.CSharp

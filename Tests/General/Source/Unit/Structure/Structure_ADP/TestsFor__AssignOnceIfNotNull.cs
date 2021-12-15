////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 22.10.2021.
using System;
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_ADP{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__AssignOnceIfNotNull

public static class TestsFor__AssignOnceIfNotNull
{
 [Test]
 public static void Test_01()
 {
  Nullable<int>
   storage
    =null;

 Assert.IsTrue
  (xEFCore.Structure.Structure_ADP.AssignOnceIfNotNull
   (ref storage,
    123));

  Assert.AreEqual
   (123,
    storage);
 }//Test_01

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02()
 {
  Nullable<int>
   storage
    =123;

 Assert.IsTrue
  (xEFCore.Structure.Structure_ADP.AssignOnceIfNotNull
   (ref storage,
    123));

  Assert.AreEqual
   (123,
    storage);
 }//Test_02

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_03()
 {
  Nullable<int>
   storage
    =123;

 Assert.IsFalse
  (xEFCore.Structure.Structure_ADP.AssignOnceIfNotNull
   (ref storage,
    1234));

  Assert.AreEqual
   (123,
    storage);
 }//Test_03

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_04()
 {
  Nullable<int>
   storage
    =123;

 Assert.IsTrue
  (xEFCore.Structure.Structure_ADP.AssignOnceIfNotNull
   (ref storage,
    null));

  Assert.AreEqual
   (123,
    storage);
 }//Test_04
};//class TestsFor__AssignOnceIfNotNull

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_ADP

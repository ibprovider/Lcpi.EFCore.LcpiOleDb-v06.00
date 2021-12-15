////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 26.09.2021.
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_ADP{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__ConstructDecimalFromLongValue

public static class TestsFor__ConstructDecimalFromLongValue
{
 [Test]
 public static void Test_01()
 {
  System.Decimal
   testValue
    =xEFCore.Structure.Structure_ADP.ConstructDecimalFromLongValue
      (/*value*/0,
       /*scale*/0);

  Assert.AreEqual
   (0m,
    testValue);
 }//Test_01

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02__i4Max_4()
 {
  System.Decimal
   testValue
    =xEFCore.Structure.Structure_ADP.ConstructDecimalFromLongValue
      (/*value*/long.MaxValue,
       /*scale*/4);

  Assert.AreEqual
   (922337203685477.5807m,
    testValue);
 }//Test_02__i4Max_4

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_03__i4Min_4()
 {
  System.Decimal
   testValue
    =xEFCore.Structure.Structure_ADP.ConstructDecimalFromLongValue
      (/*value*/long.MinValue,
       /*scale*/4);

  Assert.AreEqual
   (-922337203685477.5808m,
    testValue);
 }//Test_03__i4Min_4
};//class TestsFor__ConstructDecimalFromLongValue

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_ADP

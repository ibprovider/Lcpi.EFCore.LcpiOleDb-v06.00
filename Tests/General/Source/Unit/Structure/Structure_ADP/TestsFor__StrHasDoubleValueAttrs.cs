////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 18.11.2020.
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_ADP{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__StrHasDoubleValueAttrs

public static class TestsFor__StrHasDoubleValueAttrs
{
 [Test]
 public static void Test_01__yes__E()
 {
  Assert.IsTrue
   (xEFCore.Structure.Structure_ADP.StrHasDoubleValueAttrs
     (0,
      "0E+1"));
 }//Test_01__yes__E

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02__yes__e()
 {
  Assert.IsTrue
   (xEFCore.Structure.Structure_ADP.StrHasDoubleValueAttrs
     (0,
      "0e+1"));
 }//Test_02__yes__e

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_03__yes__point()
 {
  Assert.IsTrue
   (xEFCore.Structure.Structure_ADP.StrHasDoubleValueAttrs
     (0,
      "0.0"));
 }//Test_03__yes__point

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_04__yes__NaN()
 {
  Assert.IsTrue
   (xEFCore.Structure.Structure_ADP.StrHasDoubleValueAttrs
     (double.NaN,
      double.NaN.ToString(System.Globalization.CultureInfo.InvariantCulture)));
 }//Test_04__yes__NaN

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_05__yes__NegativeInfinity()
 {
  Assert.IsTrue
   (xEFCore.Structure.Structure_ADP.StrHasDoubleValueAttrs
     (double.NegativeInfinity,
      double.NegativeInfinity.ToString(System.Globalization.CultureInfo.InvariantCulture)));
 }//Test_05__yes__NegativeInfinity

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_06__yes__PositiveInfinity()
 {
  Assert.IsTrue
   (xEFCore.Structure.Structure_ADP.StrHasDoubleValueAttrs
     (double.PositiveInfinity,
      double.PositiveInfinity.ToString(System.Globalization.CultureInfo.InvariantCulture)));
 }//Test_06__yes__PositiveInfinity

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_07__NO()
 {
  Assert.IsFalse
   (xEFCore.Structure.Structure_ADP.StrHasDoubleValueAttrs
     (123,
      "123"));
 }//Test_07__NO
};//class TestsFor__StrHasDoubleValueAttrs

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_ADP

////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 02.03.2021.
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

using structure_lib
 =lcpi.lib.structure;

namespace EFCore_LcpiOleDb_Tests.General.Research.CSharp{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_003__Decimal

public static class TestSet_003__Decimal
{
 [Test]
 public static void Test_001()
 {
  System.Double r8=1e-255;

  System.Decimal dec=(decimal)r8;

  Assert.IsTrue
   (dec==0m);
 }//Test_001

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002()
 {
  System.Decimal dec
   =System.Convert.ToDecimal("1");

  Assert.IsTrue
   (dec!=0m);
 }//Test_002

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_003()
 {
  var oldC
   =System.Threading.Thread.CurrentThread.CurrentCulture;

  try
  {
   System.Threading.Thread.CurrentThread.CurrentCulture
    =System.Globalization.CultureInfo.InvariantCulture;

   System.Decimal dec
    =System.Convert.ToDecimal("7.9228162514264337593543950335");

   Assert.AreEqual
    ("7.9228162514264337593543950335",
     dec.ToString());
  }
  finally
  {
   System.Threading.Thread.CurrentThread.CurrentCulture
    =oldC;
  }//finally
 }//Test_003

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_004()
 {
  var oldC
   =System.Threading.Thread.CurrentThread.CurrentCulture;

  try
  {
   System.Threading.Thread.CurrentThread.CurrentCulture
    =System.Globalization.CultureInfo.InvariantCulture;

   System.Decimal dec
    =System.Convert.ToDecimal("0.79228162514264337593543950335");

   Assert.AreEqual
    ("0.7922816251426433759354395034",
     dec.ToString());
  }
  finally
  {
   System.Threading.Thread.CurrentThread.CurrentCulture
    =oldC;
  }//finally
 }//Test_004

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_004__looong()
 {
  var oldC
   =System.Threading.Thread.CurrentThread.CurrentCulture;

  try
  {
   System.Threading.Thread.CurrentThread.CurrentCulture
    =System.Globalization.CultureInfo.InvariantCulture;

   System.Decimal dec
    =System.Convert.ToDecimal("0.792281625142643375935439503350000000000000000000000000000000");

   Assert.AreEqual
    ("0.7922816251426433759354395034",
     dec.ToString());
  }
  finally
  {
   System.Threading.Thread.CurrentThread.CurrentCulture
    =oldC;
  }//finally
 }//Test_004__looong

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_005__minminmin()
 {
  var pnum1
   =new structure_lib.MpNum10.RW();

  pnum1[0]=1;

  try
  {
   var dec1
    =structure_lib.DecimalUtils.ToDecimal(pnum1,true,29);
  }
  catch(ArgumentOutOfRangeException exc)
  {
   CheckErrors.PrintException_OK(exc);

   StringAssert.Contains
   ("Decimal's scale value must be between 0 and 28, inclusive.",
    exc.Message);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_005__minminmin

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_006()
 {
  var oldC
   =System.Threading.Thread.CurrentThread.CurrentCulture;

  try
  {
   System.Threading.Thread.CurrentThread.CurrentCulture
    =System.Globalization.CultureInfo.InvariantCulture;

   System.Decimal dec
    =System.Convert.ToDecimal("79228162514264337593543950335");

   Assert.AreEqual
    ("79228162514264337593543950335",
     dec.ToString());
  }
  finally
  {
   System.Threading.Thread.CurrentThread.CurrentCulture
    =oldC;
  }//finally
 }//Test_006

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_006__err()
 {
  try
  {
   var oldC
    =System.Threading.Thread.CurrentThread.CurrentCulture;

   try
   {
    System.Threading.Thread.CurrentThread.CurrentCulture
     =System.Globalization.CultureInfo.InvariantCulture;

    System.Decimal dec
     =System.Convert.ToDecimal("792281625142643375935439503350E-1");
   }
   finally
   {
    System.Threading.Thread.CurrentThread.CurrentCulture
     =oldC;
   }//finally
  }
  catch(Exception exc)
  {
   StringAssert.Contains
    ("Input string was not in a correct format.",
     exc.Message);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_006__err

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_007__err()
 {
  try
  {
   var oldC
    =System.Threading.Thread.CurrentThread.CurrentCulture;

   try
   {
    System.Threading.Thread.CurrentThread.CurrentCulture
     =System.Globalization.CultureInfo.InvariantCulture;

    System.Decimal dec
     =System.Convert.ToDecimal("1E1");
   }
   finally
   {
    System.Threading.Thread.CurrentThread.CurrentCulture
     =oldC;
   }//finally
  }
  catch(Exception exc)
  {
   StringAssert.Contains
    ("Input string was not in a correct format.",
     exc.Message);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_007__err
};//class TestSet_003__Decimal

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Research.CSharp

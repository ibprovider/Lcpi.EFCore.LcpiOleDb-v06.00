////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 02.03.2021.
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_NumericDigits{
////////////////////////////////////////////////////////////////////////////////

using Structure_NumericDigits
 =xEFCore.Structure.Structure_NumericDigits;

////////////////////////////////////////////////////////////////////////////////
//class TestsFor__Clamp

public static class TestsFor__Clamp
{
 [Test]
 public static void Test_001__empty()
 {
  var numd=new Structure_NumericDigits.RW(0);

  TestServices.Structure_NumericDigits___CheckState
   (numd,
    0,
    0,
    xEFCore.Structure.Structure_NumberSign.Undefined);

  //----------------------------------------
  numd.Clamp();

  //----------------------------------------
  TestServices.Structure_NumericDigits___CheckState
   (numd,
    0,
    0,
    xEFCore.Structure.Structure_NumberSign.Undefined);
 }//Test_001__empty

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002()
 {
  var numd=new Structure_NumericDigits.RW(1);

  numd.SetDigit(0,0);
  numd.SetScale(-1);
  numd.SetMantisseSign(xEFCore.Structure.Structure_NumberSign.Negative);

  TestServices.Structure_NumericDigits___CheckState
   (numd,
    new byte[]{0},
    -1,
    xEFCore.Structure.Structure_NumberSign.Negative);

  //----------------------------------------
  numd.Clamp();

  //----------------------------------------
  TestServices.Structure_NumericDigits___CheckState
   (numd,
    0,
    -1,
    xEFCore.Structure.Structure_NumberSign.Negative);
 }//Test_002

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_003()
 {
  var numd=new Structure_NumericDigits.RW(4);

  numd.SetDigit(0,3);
  numd.SetDigit(1,2);
  numd.SetDigit(2,0);
  numd.SetDigit(3,0);
  numd.SetScale(-1);
  numd.SetMantisseSign(xEFCore.Structure.Structure_NumberSign.Negative);

  TestServices.Structure_NumericDigits___CheckState
   (numd,
    new byte[]{3,2,0,0},
    -1,
    xEFCore.Structure.Structure_NumberSign.Negative);

  //----------------------------------------
  numd.Clamp();

  //----------------------------------------
  TestServices.Structure_NumericDigits___CheckState
   (numd,
    new byte[]{3,2},
    -1,
    xEFCore.Structure.Structure_NumberSign.Negative);
 }//Test_003
};//class TestsFor__Clamp

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_NumericDigits

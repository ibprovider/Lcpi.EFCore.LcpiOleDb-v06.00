////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 02.03.2021.
using System;
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

using structure_lib=lcpi.lib.structure;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_NumericDigits{
////////////////////////////////////////////////////////////////////////////////

using Structure_NumericDigits
 =xEFCore.Structure.Structure_NumericDigits;

////////////////////////////////////////////////////////////////////////////////
//class TestsFor__ShiftOnPositiveScale

public static class TestsFor__ShiftOnPositiveScale
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
  for(uint n=0;n!=5;++n)
  {
   Console.WriteLine("----------------- n: {0}", n);

   numd.ShiftOnPositiveScale(n);

   TestServices.Structure_NumericDigits___CheckState
    (numd,
     0,
     0,
     xEFCore.Structure.Structure_NumberSign.Undefined);
  }//for n
 }//Test_001__empty

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002()
 {
  for(int nReserved=1;nReserved!=5;++nReserved)
  {
   for(byte x=0;x!=10;++x)
   {
    Console.WriteLine("----------------- nReserved: {0}; x: {1}", nReserved, x);
   
    var numd=new Structure_NumericDigits.RW(nReserved);
   
    numd.SetDigit(0,x);
    numd.SetScale(1);
    numd.SetMantisseSign(xEFCore.Structure.Structure_NumberSign.Positive);
   
    TestServices.Structure_NumericDigits___CheckState
     (numd,
      new byte[]{x},
      1,
      xEFCore.Structure.Structure_NumberSign.Positive);
    
    //----------------------------------------
    numd.ShiftOnPositiveScale(2);
    
    //----------------------------------------
    TestServices.Structure_NumericDigits___CheckState
     (numd,
      new byte[]{0,0,x},
      1,
      xEFCore.Structure.Structure_NumberSign.Positive);
   }//for x
  }//for nReserved
 }//Test_002

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_003()
 {
  for(int nReserved=2;nReserved!=5;++nReserved)
  {
   for(byte x=0;x!=10;++x)
   {
    Console.WriteLine("----------------- nReserved: {0}; x: {1}", nReserved, x);
   
    var numd=new Structure_NumericDigits.RW(nReserved);
   
    byte x2=(byte)((x+1)%10);

    numd.SetDigit(0,x);
    numd.SetDigit(1,x2);

    numd.SetScale(1);
    numd.SetMantisseSign(xEFCore.Structure.Structure_NumberSign.Positive);
   
    TestServices.Structure_NumericDigits___CheckState
     (numd,
      new byte[]{x,x2},
      1,
      xEFCore.Structure.Structure_NumberSign.Positive);
    
    //----------------------------------------
    numd.ShiftOnPositiveScale(2);
    
    //----------------------------------------
    TestServices.Structure_NumericDigits___CheckState
     (numd,
      new byte[]{0,0,x,x2},
      1,
      xEFCore.Structure.Structure_NumberSign.Positive);
   }//for x
  }//for nReserved
 }//Test_003

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_004()
 {
  for(int nReserved=5;nReserved!=20;++nReserved)
  {
   for(uint nShift=0;nShift!=20;++nShift)
   {
    Console.WriteLine("----------------- nReserved: {0}; nShift: {1}", nReserved, nShift);
   
    var numd=new Structure_NumericDigits.RW(nReserved);
  
    numd.SetDigit(0,3);
    numd.SetDigit(1,0);
    numd.SetDigit(2,5);
    numd.SetDigit(3,2);
    numd.SetDigit(4,0);
  
    numd.SetScale(1);
    numd.SetMantisseSign(xEFCore.Structure.Structure_NumberSign.Positive);
    
    TestServices.Structure_NumericDigits___CheckState
     (numd,
      new byte[]{3,0,5,2,0},
      1,
      xEFCore.Structure.Structure_NumberSign.Positive);
    
    //----------------------------------------
    numd.ShiftOnPositiveScale(nShift);
    
    //----------------------------------------
    var expectedDigits=new byte[5+nShift];

    expectedDigits[5+nShift-1]=0;
    expectedDigits[5+nShift-2]=2;
    expectedDigits[5+nShift-3]=5;
    expectedDigits[5+nShift-4]=0;
    expectedDigits[5+nShift-5]=3;

    TestServices.Structure_NumericDigits___CheckState
     (numd,
      expectedDigits,
      1,
      xEFCore.Structure.Structure_NumberSign.Positive);
   }//for nShift
  }//for nReserved
 }//Test_004

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_005()
 {
  var numd=new Structure_NumericDigits.RW(5);
  
  numd.SetDigit(1,0);

  try
  {
   numd.ShiftOnPositiveScale(int.MaxValue);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception exc)
  {
   CheckErrors.PrintException_OK(exc);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(exc));

   CheckErrors.CheckErrorRecord__common_err__cant_alloc_new_array__overflow__2
    (TestUtils.GetRecord(exc,0),
     CheckErrors.c_src__EFCoreDataProvider__Structure_NumericDigits_RW,
     "ShiftOnPositiveScale",
     "#001");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_005
};//class TestsFor__ShiftOnPositiveScale

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_NumericDigits

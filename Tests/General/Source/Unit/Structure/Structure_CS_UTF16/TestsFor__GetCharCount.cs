////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 19.11.2020.
using NUnit.Framework;
using System;
using System.Diagnostics;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_CS_UTF16{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__GetCharCount

public static class TestsFor__GetCharCount
{
 [Test]
 public static void Test_01__empty()
 {
  Assert.AreEqual
   (0,
    xEFCore.Structure.Structure_CS_UTF16.GetCharCount
     (""));
 }//Test_01__empty

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02__ch1()
 {
  Assert.AreEqual
   (1,
    xEFCore.Structure.Structure_CS_UTF16.GetCharCount
     ("\0"));
 }//Test_02__ch1

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_03__uchar1__ok()
 {
  for(UInt16 x=0;;++x)
  {
   if(x>=0xD800 && x<=0xDFFF)
   {
    //Surrogate
   }
   else
   {
    Assert.AreEqual
     (1,
      xEFCore.Structure.Structure_CS_UTF16.GetCharCount
       (""+(char)x));
   }//if

   if(x==0xFFFF)
    break;
  }//for x
 }//Test_03__uchar1__ok

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_04__uchar2__ok()
 {
  var chars=new char[2];

  for(UInt32 x=0x10000;;++x)
  {
   UInt32 x1=x-0x10000;

   Debug.Assert(x1>=0 && x1<=0xFFFFF);

   var w1=(x1>>10)+0xD800;

   Debug.Assert(w1>=0xD800 && w1<=0xDBFF);

   var w2=(x1&0x03FF)+0xDC00;

   Debug.Assert(w1>=0xD800 && w1<=0xDFFF);

   chars[0]=(char)w1;
   chars[1]=(char)w2;

    Assert.AreEqual
     (1,
      xEFCore.Structure.Structure_CS_UTF16.GetCharCount
       (""+(char)w1+(char)w2));

   if(x==0x10FFFF)
    break;
  }//for x
 }//Test_04__uchar2__ok

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_05__two_chars()
 {
  Assert.AreEqual
   (2,
    xEFCore.Structure.Structure_CS_UTF16.GetCharCount
     ("ab"));
 }//Test_05__two_chars

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_E1__GCC_001()
 {
  //Low surrogate at first place

  for(System.UInt16 x=0xDC00;;++x)
  {
   try
   {
    xEFCore.Structure.Structure_CS_UTF16.GetCharCount(""+(char)x);

    TestServices.ThrowWeWaitError();
   }
   catch(xEFCore.LcpiOleDb__DataToolException exc)
   {
    //OK

    Assert.AreEqual
     (1,
      TestUtils.GetRecordCount(exc));

    Assert.IsNotNull
     (TestUtils.GetRecord(exc,0));

    CheckErrors.CheckErrorRecord__cs_utf16_err__bad_sequence__2
     (TestUtils.GetRecord(exc,0),
      CheckErrors.c_src__EFCoreDataProvider__Structure_CS_UTF16,
      "#GCC.001",
      /*offset*/0);
   }//catch
   
   if(x==0xDFFF)
    break;
  }//for x
 }//Test_E1__GCC_001

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_E2__GCC_002()
 {
  //No second surrogate

  for(System.UInt16 x=0xD800;;++x)
  {
   try
   {
    xEFCore.Structure.Structure_CS_UTF16.GetCharCount(""+(char)x);

    TestServices.ThrowWeWaitError();
   }
   catch(xEFCore.LcpiOleDb__DataToolException exc)
   {
    //OK

    Assert.AreEqual
     (1,
      TestUtils.GetRecordCount(exc));

    Assert.IsNotNull
     (TestUtils.GetRecord(exc,0));

    CheckErrors.CheckErrorRecord__cs_utf16_err__bad_sequence__2
     (TestUtils.GetRecord(exc,0),
      CheckErrors.c_src__EFCoreDataProvider__Structure_CS_UTF16,
      "#GCC.002",
      /*offset*/1);
   }//catch
   
   if(x==0xDBFF)
    break;
  }//for x
 }//Test_E2__GCC_002

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_E3__GCC_003()
 {
  //int n=0;

  //for(System.UInt16 x=0xD800;;++x)
  {
   //chars[0]=(char)x;

   for(System.UInt16 x2=0;;++x2)
   {
    if(x2>=0xDC00 && x2<=0xDFFF) //valid surrogate2
     continue;

    //INVALID SURROGATE2

    //++n;
    //
    //if((n%100000)==0)
    //{
    // Console.WriteLine("PROCESSED {0} case(s).",n);
    //}

    try
    {
     xEFCore.Structure.Structure_CS_UTF16.GetCharCount(""+(char)0xD800+(char)x2);
    
     TestServices.ThrowWeWaitError();
    }
    catch(xEFCore.LcpiOleDb__DataToolException exc)
    {
     //OK
    
     Assert.AreEqual
      (1,
       TestUtils.GetRecordCount(exc));
    
     Assert.IsNotNull
      (TestUtils.GetRecord(exc,0));
    
     CheckErrors.CheckErrorRecord__cs_utf16_err__bad_sequence__2
      (TestUtils.GetRecord(exc,0),
       CheckErrors.c_src__EFCoreDataProvider__Structure_CS_UTF16,
       "#GCC.003",
       /*offset*/1);
    }//catch

    if(x2==0xFFFF)
     break;
   }//for x2

   //if(x==0xDBFF)
   // break;
  }//local
 }//Test_E3__GCC_003
};//class TestsFor__GetCharCount

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_CS_UTF16

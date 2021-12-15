////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 19.11.2020.
using NUnit.Framework;
using System;
using System.Diagnostics;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_CS_UTF16{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__GetOffset

public static class TestsFor__GetOffset
{
 [Test]
 public static void Test_01__empty__0__0()
 {
  int n=-1;

  int r=xEFCore.Structure.Structure_CS_UTF16.GetOffset
         ("",
          /*initialOffset*/0,
          /*symbolIndex*/0,
          out n);

  Assert.AreEqual
   (0,
    r);

  Assert.AreEqual
   (0,
    n);
 }//Test_01__empty__0__0

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_01__empty__0__1()
 {
  int n=-1;

  int r=xEFCore.Structure.Structure_CS_UTF16.GetOffset
         ("",
          /*initialOffset*/0,
          /*symbolIndex*/1,
          out n);

  Assert.AreEqual
   (0,
    r);

  Assert.AreEqual
   (0,
    n);
 }//Test_01__empty__0__1

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02__len1__0__0()
 {
  int n=-1;

  int r=xEFCore.Structure.Structure_CS_UTF16.GetOffset
         ("1",
          /*initialOffset*/0,
          /*symbolIndex*/0,
          out n);

  Assert.AreEqual
   (0,
    r);

  Assert.AreEqual
   (0,
    n);
 }//Test_02__len1__0__0

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02__len1__0__1()
 {
  int n=-1;

  int r=xEFCore.Structure.Structure_CS_UTF16.GetOffset
         ("1",
          /*initialOffset*/0,
          /*symbolIndex*/1,
          out n);

  Assert.AreEqual
   (1,
    r);

  Assert.AreEqual
   (1,
    n);
 }//Test_02__len1__0__1

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02__ulen1__0__1()
 {
  int n=-1;

  int r=xEFCore.Structure.Structure_CS_UTF16.GetOffset
         ("\uD800\uDC00",
          /*initialOffset*/0,
          /*symbolIndex*/1,
          out n);

  Assert.AreEqual
   (2,
    r);

  Assert.AreEqual
   (1,
    n);
 }//Test_02__len1__0__1

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02__ulen1__0__2()
 {
  int n=-1;

  int r=xEFCore.Structure.Structure_CS_UTF16.GetOffset
         ("\uD800\uDC00",
          /*initialOffset*/0,
          /*symbolIndex*/2,
          out n);

  Assert.AreEqual
   (2,
    r);

  Assert.AreEqual
   (1,
    n);
 }//Test_02__len1__0__2

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_03__mlen3__0__2()
 {
  int n=-1;

  int r=xEFCore.Structure.Structure_CS_UTF16.GetOffset
         ("A\uD800\uDC00B",
          /*initialOffset*/0,
          /*symbolIndex*/2,
          out n);

  Assert.AreEqual
   (3,
    r);

  Assert.AreEqual
   (2,
    n);
 }//Test_03__mlen3__0__2

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_03__mlen3__0__3()
 {
  int n=-1;

  int r=xEFCore.Structure.Structure_CS_UTF16.GetOffset
         ("A\uD800\uDC00B",
          /*initialOffset*/0,
          /*symbolIndex*/3,
          out n);

  Assert.AreEqual
   (4,
    r);

  Assert.AreEqual
   (3,
    n);
 }//Test_03__mlen3__0__3

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_04__mlen3__1__0()
 {
  int n=-1;

  int r=xEFCore.Structure.Structure_CS_UTF16.GetOffset
         ("A\uD800\uDC00B",
          /*initialOffset*/1,
          /*symbolIndex*/0,
          out n);

  Assert.AreEqual
   (1,
    r);

  Assert.AreEqual
   (0,
    n);
 }//Test_04__mlen3__1__0

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_04__mlen3__1__1()
 {
  int n=-1;

  int r=xEFCore.Structure.Structure_CS_UTF16.GetOffset
         ("A\uD800\uDC00B",
          /*initialOffset*/1,
          /*symbolIndex*/1,
          out n);

  Assert.AreEqual
   (3,
    r);

  Assert.AreEqual
   (1,
    n);
 }//Test_04__mlen3__1__1

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_04__mlen3__1__2()
 {
  int n=-1;

  int r=xEFCore.Structure.Structure_CS_UTF16.GetOffset
         ("A\uD800\uDC00B",
          /*initialOffset*/1,
          /*symbolIndex*/2,
          out n);

  Assert.AreEqual
   (4,
    r);

  Assert.AreEqual
   (2,
    n);
 }//Test_04__mlen3__1__2

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_04__mlen3__1__3()
 {
  int n=-1;

  int r=xEFCore.Structure.Structure_CS_UTF16.GetOffset
         ("A\uD800\uDC00B",
          /*initialOffset*/1,
          /*symbolIndex*/3,
          out n);

  Assert.AreEqual
   (4,
    r);

  Assert.AreEqual
   (2,
    n);
 }//Test_04__mlen3__1__3

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_04__mlen3__3__3()
 {
  int n=-1;

  int r=xEFCore.Structure.Structure_CS_UTF16.GetOffset
         ("A\uD800\uDC00B",
          /*initialOffset*/3,
          /*symbolIndex*/3,
          out n);

  Assert.AreEqual
   (4,
    r);

  Assert.AreEqual
   (1,
    n);
 }//Test_04__mlen3__3__3

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_04__mlen3__4__3()
 {
  int n=-1;

  int r=xEFCore.Structure.Structure_CS_UTF16.GetOffset
         ("A\uD800\uDC00B",
          /*initialOffset*/4,
          /*symbolIndex*/3,
          out n);

  Assert.AreEqual
   (4,
    r);

  Assert.AreEqual
   (0,
    n);
 }//Test_04__mlen3__4__3

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_E1__GO_001()
 {
  //Low surrogate at first place

  for(System.UInt16 x=0xDC00;;++x)
  {
   int nChars=-1;

   try
   {
    xEFCore.Structure.Structure_CS_UTF16.GetOffset
     (""+(char)x,
      0,
      1,
      out nChars);

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
      "#GO.001",
      /*offset*/0);
   }//catch

   Assert.AreEqual
    (0,
     nChars); //must be initialized
   
   if(x==0xDFFF)
    break;
  }//for x
 }//Test_E1__GO_001

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_E2__GO_002()
 {
  //No second surrogate

  for(System.UInt16 x=0xD800;;++x)
  {
   int nChars=-1;

   try
   {
    xEFCore.Structure.Structure_CS_UTF16.GetOffset
     (""+(char)x,
      0,
      1,
      out nChars);

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
      "#GO.002",
      /*offset*/1);
   }//catch
   
   Assert.AreEqual
    (0,
     nChars); //must be initialized
   
   if(x==0xDBFF)
    break;
  }//for x
 }//Test_E2__GO_002

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_E3__GO_003()
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

    int nChars=-1;

    try
    {
     xEFCore.Structure.Structure_CS_UTF16.GetOffset
      (""+(char)0xD800+(char)x2,
       0,
       1,
       out nChars);

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
       "#GO.003",
       /*offset*/1);
    }//catch

    Assert.AreEqual
     (0,
      nChars); //must be initialized

    if(x2==0xFFFF)
     break;
   }//for x2

   //if(x==0xDBFF)
   // break;
  }//local
 }//Test_E3__GO_003
};//class TestsFor__GetOffset

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_CS_UTF16

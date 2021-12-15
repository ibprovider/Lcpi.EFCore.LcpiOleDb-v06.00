////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 02.03.2021.
using System;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_NumericDigits{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_NumericDigits
 =xEFCore.Structure.Structure_NumericDigits;

using T_DATA_003
 =System.Tuple<uint,bool,byte[],byte[]>;

////////////////////////////////////////////////////////////////////////////////
//class TestsFor__ShiftOnNegativeScale

public static class TestsFor__ShiftOnNegativeScale
{
 [Test]
 public static void Test_001__empty__no_round()
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

   numd.ShiftOnNegativeScale(n,false);

   TestServices.Structure_NumericDigits___CheckState
    (numd,
     0,
     0,
     xEFCore.Structure.Structure_NumberSign.Undefined);
  }//for n
 }//Test_001__empty__no_round

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002__empty__with_round()
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

   numd.ShiftOnNegativeScale(n,true);

   TestServices.Structure_NumericDigits___CheckState
    (numd,
     0,
     0,
     xEFCore.Structure.Structure_NumberSign.Undefined);
  }//for n
 }//Test_002__empty__with_round

 //-----------------------------------------------------------------------
 private static readonly T_DATA_003[]
  sm_Data_003
   =new T_DATA_003[]
    {
     new T_DATA_003
      (
       1,
       false,
       "021".ToNumData(),
       "02".ToNumData()
      ),

     new T_DATA_003
      (
       5,
       false,
       "0654321".ToNumData(),
       "06".ToNumData()
      ),

     new T_DATA_003
      (
       5,
       true,
       "0654321".ToNumData(),
       "07".ToNumData()
      ),

     new T_DATA_003
      (
       5,
       true,
       "654321".ToNumData(),
       "7".ToNumData()
      ),

     new T_DATA_003
      (
       5,
       true,
       "954321".ToNumData(),
       "10".ToNumData()
      ),

     new T_DATA_003
      (
       5,
       true,
       "89954321".ToNumData(),
       "900".ToNumData()
      ),

     new T_DATA_003
      (
       5,
       true,
       "0189954321".ToNumData(),
       "01900".ToNumData()
      ),

     new T_DATA_003
      (
       50,
       true,
       "01899654321".ToNumData(),
       "".ToNumData()
      ),

     new T_DATA_003
      (
       1,
       true,
       "1234".ToNumData(),
       "123".ToNumData()
      ),

     new T_DATA_003
      (
       1,
       true,
       "12345".ToNumData(),
       "1235".ToNumData()
      ),
    };//sm_Data_003

 //-----------------------------------------------------------------------
 private static byte[] ToNumData(this string str)
 {
  Debug.Assert(!Object.ReferenceEquals(str,null));

  var bytes=new byte[str.Length];

  for(int i=0;i!=str.Length;++i)
  {
   Debug.Assert(str[i]>='0');
   Debug.Assert(str[i]<='9');

   bytes[bytes.Length-1-i]=(byte)(str[i]-'0');
  }//for i 

  return bytes;
 }//ToNumData

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_003()
 {
  for(int iData=0;iData!=sm_Data_003.Length;++iData)
  {
   var data=sm_Data_003[iData];

   var numd=new Structure_NumericDigits.RW(data.Item3.Length);

   for(int i=0;i!=data.Item3.Length;++i)
    numd.SetDigit(i,data.Item3[i]);

   try
   {
    TestServices.Structure_NumericDigits___CheckState
     (numd,
      data.Item3,
      0,
      xEFCore.Structure.Structure_NumberSign.Undefined);
    
    numd.ShiftOnNegativeScale
     (data.Item1,
      data.Item2);
    
    TestServices.Structure_NumericDigits___CheckState
     (numd,
      data.Item4,
      0,
      xEFCore.Structure.Structure_NumberSign.Undefined);
   }
   catch(Exception e)
   {
    var sb=new System.Text.StringBuilder();

    sb.Append("Problem with data ["+iData+"] {");
    
    foreach(var x in data.Item3) sb.Append(x+" ");

    sb.Append("}");

    throw new ApplicationException(sb.ToString(),e);
   }//catch
  }//for iData
 }//Test_003
};//class TestsFor__ShiftOnNegativeScale

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_NumericDigits

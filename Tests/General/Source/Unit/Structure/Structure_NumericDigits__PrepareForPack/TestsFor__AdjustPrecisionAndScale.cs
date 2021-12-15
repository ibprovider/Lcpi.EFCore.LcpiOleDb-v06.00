////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 03.03.2021.
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_NumericDigits__PrepareForPack{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_NumericDigits
 =xEFCore.Structure.Structure_NumericDigits;

using Structure_NumericDigits__PrepareForPack
 =xEFCore.Structure.Structure_NumericDigits__PrepareForPack;

using T_DATA_003
 =System.Tuple<uint,bool,byte[],byte[]>;

////////////////////////////////////////////////////////////////////////////////
//class TestsFor__AdjustPrecisionAndScale

public static class TestsFor__AdjustPrecisionAndScale
{
 private struct tagData001
 {
  public readonly uint DesiredPrecision;
  public readonly uint DesiredScale;

  public readonly Structure_NumericDigits SourceNum;

  public readonly Structure_NumericDigits__PrepareForPack.ExecResultCode ResultCode;

  public readonly Structure_NumericDigits ResultNum;

  //------------------------------------------------------------
  public tagData001
          (uint                                                   desiredPrecision,
           uint                                                   desiredScale,
           Structure_NumericDigits                                sourceNum,
           Structure_NumericDigits__PrepareForPack.ExecResultCode resultCode,
           Structure_NumericDigits                                resultNum)
  {
   this.DesiredPrecision = desiredPrecision;
   this.DesiredScale     = desiredScale;
   this.SourceNum        = sourceNum;
   this.ResultCode       = resultCode;
   this.ResultNum        = resultNum;
  }//tagData001
 };//struct tagData001

 //-----------------------------------------------------------------------
 private static System.Collections.Generic.List<tagData001> Helper__BuildData001()
 {
  var arr=new System.Collections.Generic.List<tagData001>();

  //----------------------------------------
  const uint c_MaxDecimalPrecision=29;

  const uint c_MaxDecimalScale=28;

  //---------------------------------------- 0
  arr.Add
   (new tagData001
     (c_MaxDecimalPrecision,
      c_MaxDecimalScale,

      TestServices.Structure_NumericDigits___Create
          (new byte[0],
           0,
           xEFCore.Structure.Structure_NumberSign.Positive),

      Structure_NumericDigits__PrepareForPack.ExecResultCode.Ok,

      TestServices.Structure_NumericDigits___Create
          (new byte[0],
           0,
           xEFCore.Structure.Structure_NumberSign.Undefined)));

  //---------------------------------------- 1
  arr.Add
   (new tagData001
     (c_MaxDecimalPrecision,
      c_MaxDecimalScale,

      TestServices.Structure_NumericDigits___Create
          (new byte[]{0,0,0,0,0},
           0,
           xEFCore.Structure.Structure_NumberSign.Positive),

      Structure_NumericDigits__PrepareForPack.ExecResultCode.Ok,

      TestServices.Structure_NumericDigits___Create
          (new byte[0],
           0,
           xEFCore.Structure.Structure_NumberSign.Undefined)));

  //---------------------------------------- 2
  arr.Add
   (new tagData001
     (c_MaxDecimalPrecision,
      c_MaxDecimalScale,

      TestServices.Structure_NumericDigits___Create
          ("0001".ToNumData(),
           0,
           xEFCore.Structure.Structure_NumberSign.Positive),

      Structure_NumericDigits__PrepareForPack.ExecResultCode.Ok,

      TestServices.Structure_NumericDigits___Create
          ("1".ToNumData(),
           0,
           xEFCore.Structure.Structure_NumberSign.Positive)));

  //---------------------------------------- 3
  arr.Add
   (new tagData001
     (c_MaxDecimalPrecision,
      c_MaxDecimalScale,

      TestServices.Structure_NumericDigits___Create
          ("0000012345678901234567890123456789".ToNumData(),
           0,
           xEFCore.Structure.Structure_NumberSign.Positive),

      Structure_NumericDigits__PrepareForPack.ExecResultCode.Ok,

      TestServices.Structure_NumericDigits___Create
          ("12345678901234567890123456789".ToNumData(),
           0,
           xEFCore.Structure.Structure_NumberSign.Positive)));

  //---------------------------------------- 4
  arr.Add
   (new tagData001
     (c_MaxDecimalPrecision,
      c_MaxDecimalScale,

      TestServices.Structure_NumericDigits___Create
          ("1234567890123456789012345678".ToNumData(),
           1,
           xEFCore.Structure.Structure_NumberSign.Positive),

      Structure_NumericDigits__PrepareForPack.ExecResultCode.Ok,

      TestServices.Structure_NumericDigits___Create
          ("12345678901234567890123456780".ToNumData(),
           0,
           xEFCore.Structure.Structure_NumberSign.Positive)));

  //---------------------------------------- 5
  arr.Add
   (new tagData001
     (c_MaxDecimalPrecision,
      c_MaxDecimalScale,

      TestServices.Structure_NumericDigits___Create
          ("1234567890123456789012345678".ToNumData(),
           2,
           xEFCore.Structure.Structure_NumberSign.Positive),

      Structure_NumericDigits__PrepareForPack.ExecResultCode.Err__Overflow,

      null));

  //---------------------------------------- 6
  arr.Add
   (new tagData001
     (c_MaxDecimalPrecision,
      c_MaxDecimalScale,

      TestServices.Structure_NumericDigits___Create
          ("123456789012345678901234567890".ToNumData(),
           0,
           xEFCore.Structure.Structure_NumberSign.Positive),

      Structure_NumericDigits__PrepareForPack.ExecResultCode.Err__Overflow,

      null));

  //---------------------------------------- 7
  arr.Add
   (new tagData001
     (11,
      10,

      TestServices.Structure_NumericDigits___Create
          ("12345678901".ToNumData(),
           -1,
           xEFCore.Structure.Structure_NumberSign.Positive),

      Structure_NumericDigits__PrepareForPack.ExecResultCode.Ok,

      TestServices.Structure_NumericDigits___Create
          ("12345678901".ToNumData(),
           -1,
           xEFCore.Structure.Structure_NumberSign.Positive)));

  //---------------------------------------- 8
  arr.Add
   (new tagData001
     (11,
      10,

      TestServices.Structure_NumericDigits___Create
          ("123456789014".ToNumData(),
           -2,
           xEFCore.Structure.Structure_NumberSign.Positive),

      Structure_NumericDigits__PrepareForPack.ExecResultCode.Ok,

      TestServices.Structure_NumericDigits___Create
          ("12345678901".ToNumData(),
           -1,
           xEFCore.Structure.Structure_NumberSign.Positive)));

  //---------------------------------------- 9
  arr.Add
   (new tagData001
     (11,
      10,

      TestServices.Structure_NumericDigits___Create
          ("123456789015".ToNumData(),
           -2,
           xEFCore.Structure.Structure_NumberSign.Positive),

      Structure_NumericDigits__PrepareForPack.ExecResultCode.Ok,

      TestServices.Structure_NumericDigits___Create
          ("12345678902".ToNumData(),
           -1,
           xEFCore.Structure.Structure_NumberSign.Positive)));

  //---------------------------------------- 10
  arr.Add
   (new tagData001
     (11,
      10,

      TestServices.Structure_NumericDigits___Create
          ("1234567890150000000000".ToNumData(),
           -12,
           xEFCore.Structure.Structure_NumberSign.Positive),

      Structure_NumericDigits__PrepareForPack.ExecResultCode.Ok,

      TestServices.Structure_NumericDigits___Create
          ("12345678902".ToNumData(),
           -1,
           xEFCore.Structure.Structure_NumberSign.Positive)));

  //---------------------------------------- 11
  arr.Add
   (new tagData001
     (11,
      10,

      TestServices.Structure_NumericDigits___Create
          ("000000000001234567890150000000000".ToNumData(),
           -12,
           xEFCore.Structure.Structure_NumberSign.Positive),

      Structure_NumericDigits__PrepareForPack.ExecResultCode.Ok,

      TestServices.Structure_NumericDigits___Create
          ("12345678902".ToNumData(),
           -1,
           xEFCore.Structure.Structure_NumberSign.Positive)));

  //---------------------------------------- 12
  arr.Add
   (new tagData001
     (11,
      10,

      TestServices.Structure_NumericDigits___Create
          ("91234567890150000000000".ToNumData(),
           -12,
           xEFCore.Structure.Structure_NumberSign.Positive),

      Structure_NumericDigits__PrepareForPack.ExecResultCode.Ok,

      //whole part only
      TestServices.Structure_NumericDigits___Create
          ("91234567890".ToNumData(),
           0,
           xEFCore.Structure.Structure_NumberSign.Positive)));

  //---------------------------------------- 13
  arr.Add
   (new tagData001
     (11,
      10,

      TestServices.Structure_NumericDigits___Create
          ("191234567890150000000000".ToNumData(),
           -12,
           xEFCore.Structure.Structure_NumberSign.Positive),

      Structure_NumericDigits__PrepareForPack.ExecResultCode.Err__Overflow,

      null));

  //---------------------------------------- 14

  //truncation of fractional part

  arr.Add
   (new tagData001
     (11,
      5,

      TestServices.Structure_NumericDigits___Create
          ("1234567890".ToNumData(),
           -10,
           xEFCore.Structure.Structure_NumberSign.Positive),

      Structure_NumericDigits__PrepareForPack.ExecResultCode.Ok,

      TestServices.Structure_NumericDigits___Create
          ("12346".ToNumData(),
           -5,
           xEFCore.Structure.Structure_NumberSign.Positive)));

  //---------------------------------------- 15

  //truncation of fractional part

  arr.Add
   (new tagData001
     (11,
      5,

      TestServices.Structure_NumericDigits___Create
          ("1234567890".ToNumData(),
           -100,
           xEFCore.Structure.Structure_NumberSign.Positive),

      Structure_NumericDigits__PrepareForPack.ExecResultCode.Ok,

      TestServices.Structure_NumericDigits___Create
          ("".ToNumData(),
           0,
           xEFCore.Structure.Structure_NumberSign.Undefined)));

  //---------------------------------------- 16

  //truncation of fractional part

  arr.Add
   (new tagData001
     (11,
      5,

      TestServices.Structure_NumericDigits___Create
          ("1234567890".ToNumData(),
           int.MinValue,
           xEFCore.Structure.Structure_NumberSign.Positive),

      Structure_NumericDigits__PrepareForPack.ExecResultCode.Ok,

      TestServices.Structure_NumericDigits___Create
          ("".ToNumData(),
           0,
           xEFCore.Structure.Structure_NumberSign.Undefined)));

  //---------------------------------------- 17

  //truncation of fractional part

  arr.Add
   (new tagData001
     (11,
      5,

      TestServices.Structure_NumericDigits___Create
          ("1".ToNumData(),
           int.MinValue,
           xEFCore.Structure.Structure_NumberSign.Positive),

      Structure_NumericDigits__PrepareForPack.ExecResultCode.Ok,

      TestServices.Structure_NumericDigits___Create
          ("".ToNumData(),
           0,
           xEFCore.Structure.Structure_NumberSign.Undefined)));

  //----------------------------------------
  return arr;
 }//Helper__BuildData001

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
 public static void Test_001()
 {
  var dataArr=Helper__BuildData001();

  for(int iData=0;iData!=dataArr.Count;++iData)
  {
   var data=dataArr[iData];

   try
   {
    var r
     =Structure_NumericDigits__PrepareForPack.AdjustPrecisionAndScale
       (data.SourceNum,
        data.DesiredPrecision,
        data.DesiredScale);

    Assert.AreEqual
     (data.ResultCode,
      r.Code);

    if(r.Code!=Structure_NumericDigits__PrepareForPack.ExecResultCode.Ok)
    {
     Assert.IsNull
      (r.NumericDigits);
    }
    else
    {
     TestServices.Structure_NumericDigits___CheckEqual
      (data.ResultNum,
       r.NumericDigits);
    }//else
   }
   catch(Exception e)
   {
    var sb=new System.Text.StringBuilder();

    sb.Append("Problem with data ["+iData+"]");

    throw new ApplicationException(sb.ToString(),e);
   }//catch
  }//for iData
 }//Test_001
};//class TestsFor__AdjustPrecisionAndScale

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_NumericDigits

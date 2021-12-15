////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 27.01.2021.
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;
using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.CastAs.SET_001.Single.String{
////////////////////////////////////////////////////////////////////////////////

using T_SOURCE_VALUE=System.Single;
using T_TARGET_VALUE=System.String;

////////////////////////////////////////////////////////////////////////////////
//class TestSet__000

public static class TestSet__000
{
 private struct tagData
 {
  public T_SOURCE_VALUE  Value;
  public T_TARGET_VALUE  Text;

  public tagData(T_SOURCE_VALUE value,
                 T_TARGET_VALUE text)
  {
   this.Value=value;
   this.Text =text;
  }//tagData
 };//struct tagData

 //-----------------------------------------------------------------------
 private static readonly tagData[] sm_Data=
 {
  /*    0 */ new tagData(0F                       ,"0.0000000"),
  /*    1 */ new tagData(1F                       ,"1.0000000"),
  /*    2 */ new tagData(1.2000000F               ,"1.2000000"),
  /*    3 */ new tagData(1.2300000F               ,"1.2300000"),
  /*    4 */ new tagData(1.2340000F               ,"1.2340000"),
  /*    5 */ new tagData(1.2345000F               ,"1.2345001"),
  /*    6 */ new tagData(1.2345600F               ,"1.2345600"),
  /*    7 */ new tagData(1.2345670F               ,"1.2345670"),
  /*    8 */ new tagData(1.2345678F               ,"1.2345678"),
  /*    9 */ new tagData(1.2345679F               ,"1.2345679"),
  /*   10 */ new tagData(1.23456790F              ,"1.2345679"),
  /*   11 */ new tagData(1.23456791F              ,"1.2345679"),
  /*   12 */ new tagData(1.23456792F              ,"1.2345679"),
  /*   13 */ new tagData(1.23456793F              ,"1.2345679"),
  /*   14 */ new tagData(1.23456794F              ,"1.2345679"),
  /*   15 */ new tagData(1.23456795F              ,"1.2345680"),
  /*   16 */ new tagData(1.23456796F              ,"1.2345680"),
  /*   17 */ new tagData(1.23456797F              ,"1.2345680"),
  /*   18 */ new tagData(1.23456798F              ,"1.2345680"),
  /*   19 */ new tagData(1.23456799F              ,"1.2345680"),

  /*   20 */ new tagData(10000.0000F              ,"10000.000"),
  /*   21 */ new tagData(12000.0000F              ,"12000.000"),
  /*   22 */ new tagData(12300.0000F              ,"12300.000"),
  /*   23 */ new tagData(12340.0000F              ,"12340.000"),
  /*   24 */ new tagData(12345.0000F              ,"12345.000"),
  /*   25 */ new tagData(12345.6000F              ,"12345.600"),
  /*   26 */ new tagData(12345.6700F              ,"12345.670"),
  /*   27 */ new tagData(12345.6780F              ,"12345.678"),
  /*   28 */ new tagData(12345.6790F              ,"12345.679"),
  /*   29 */ new tagData(12345.6791F              ,"12345.679"),
  /*   30 */ new tagData(12345.6792F              ,"12345.680"),
  /*   31 */ new tagData(12345.6793F              ,"12345.680"),
  /*   32 */ new tagData(12345.6794F              ,"12345.680"),
  /*   33 */ new tagData(12345.6795F              ,"12345.680"),
  /*   34 */ new tagData(12345.6796F              ,"12345.680"),
  /*   35 */ new tagData(12345.6797F              ,"12345.680"),
  /*   36 */ new tagData(12345.6798F              ,"12345.680"),
  /*   37 */ new tagData(12345.6799F              ,"12345.680"),

  /*   38 */ new tagData(1000000.00F              ,"1000000.0"),
  /*   39 */ new tagData(1200000.00F              ,"1200000.0"),
  /*   40 */ new tagData(1230000.00F              ,"1230000.0"),
  /*   41 */ new tagData(1234000.00F              ,"1234000.0"),
  /*   42 */ new tagData(1234500.00F              ,"1234500.0"),
  /*   43 */ new tagData(1234560.00F              ,"1234560.0"),
  /*   44 */ new tagData(1234567.00F              ,"1234567.0"),
  /*   45 */ new tagData(1234567.80F              ,"1234567.8"),
  /*   46 */ new tagData(1234567.90F              ,"1234567.9"),
  /*   47 */ new tagData(1234567.91F              ,"1234567.9"),
  /*   48 */ new tagData(1234567.92F              ,"1234567.9"),
  /*   49 */ new tagData(1234567.93F              ,"1234567.9"),
  /*   50 */ new tagData(1234567.94F              ,"1234568.0"),
  /*   51 */ new tagData(1234567.95F              ,"1234568.0"),
  /*   52 */ new tagData(1234567.96F              ,"1234568.0"),
  /*   53 */ new tagData(1234567.97F              ,"1234568.0"),
  /*   54 */ new tagData(1234567.98F              ,"1234568.0"),
  /*   55 */ new tagData(1234567.99F              ,"1234568.0"),

  /*   56 */ new tagData(10000000.0F              ,"10000000."),
  /*   57 */ new tagData(12000000.0F              ,"12000000."),
  /*   58 */ new tagData(12300000.0F              ,"12300000."),
  /*   59 */ new tagData(12340000.0F              ,"12340000."),
  /*   60 */ new tagData(12345000.0F              ,"12345000."),
  /*   61 */ new tagData(12345600.0F              ,"12345600."),
  /*   62 */ new tagData(12345670.0F              ,"12345670."),
  /*   63 */ new tagData(12345678.0F              ,"12345678."),
  /*   64 */ new tagData(12345679.0F              ,"12345679."),
  /*   65 */ new tagData(12345679.1F              ,"12345679."),
  /*   66 */ new tagData(12345679.2F              ,"12345679."),
  /*   67 */ new tagData(12345679.3F              ,"12345679."),
  /*   68 */ new tagData(12345679.4F              ,"12345679."),
  /*   69 */ new tagData(12345679.5F              ,"12345680."),
  /*   70 */ new tagData(12345679.6F              ,"12345680."),
  /*   71 */ new tagData(12345679.7F              ,"12345680."),
  /*   72 */ new tagData(12345679.8F              ,"12345680."),
  /*   73 */ new tagData(12345679.9F              ,"12345680."),

  /*   74 */ new tagData(99999999.0F              ,"1.0000000e+08"),
  /*   75 */ new tagData(99999999.1F              ,"1.0000000e+08"),
  /*   76 */ new tagData(99999999.2F              ,"1.0000000e+08"),
  /*   77 */ new tagData(99999999.3F              ,"1.0000000e+08"),
  /*   78 */ new tagData(99999999.4F              ,"1.0000000e+08"),
  /*   79 */ new tagData(99999999.5F              ,"1.0000000e+08"),
  /*   80 */ new tagData(99999999.6F              ,"1.0000000e+08"),
  /*   81 */ new tagData(99999999.7F              ,"1.0000000e+08"),
  /*   82 */ new tagData(99999999.8F              ,"1.0000000e+08"),
  /*   83 */ new tagData(99999999.9F              ,"1.0000000e+08"),

  /*   84 */ new tagData(999999999.0F             ,"1.0000000e+09"),
  /*   85 */ new tagData(999999999.9F             ,"1.0000000e+09"),

  /*   86 */ new tagData(1.00000000e+9F           ,"1.0000000e+09"),
  /*   87 */ new tagData(1.00000001e+9F           ,"1.0000000e+09"),

  /*   88 */ new tagData(9.99999987e+9F           ,"1.0000000e+10"),

  /*   89 */ new tagData(float.MinValue           ,"-3.4028235e+38"),
  /*   90 */ new tagData(float.MaxValue           ,"3.4028235e+38"),
  /*   91 */ new tagData(float.Epsilon            ,"1.4012985e-45"),
  
  /*   92 */ new tagData(4.1231231E-28F           ,"4.1231233e-28"),

  /*   93 */ new tagData(float.NaN               ,"nan(ind)"),
  /*   94 */ new tagData(float.PositiveInfinity  ,"inf"),

  /*   95 */ new tagData(-float.NaN              ,"nan(ind)"),
  /*   96 */ new tagData(-float.PositiveInfinity ,"-inf"),

  /*   97 */ new tagData(123456F                 ,"123456.00"),
 };//sm_Data

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_001__SERVER()
 {
  var errList=new List<string>();

  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    using(var cmd=cn.CreateCommand())
    {
     cmd.Transaction=tr;

     cmd.CommandText
      ="select CAST(CAST(:v AS FLOAT) AS VARCHAR(32)) from DUAL";

     cmd.Prepare();

     for(int idx=0;idx!=sm_Data.Length;++idx)
     {
      var testData=sm_Data[idx];

      cmd["v"].Value=testData.Value;
      
      var objValue=cmd.ExecuteScalar();

      if(!(objValue is string))
       throw new ApplicationException("INCORRECT RESULT!");

      var strValue=(string)objValue;

      var expectedStr=testData.Text;

      if(expectedStr!=strValue)
      {
       string err
        =string.Format
         ("[{0}] {1} -> [{2}]\"{3}\". Expected [{4}]\"{5}\"",
          idx,
          testData.Value,
          strValue.Length,
          strValue,
          expectedStr.Length,
          expectedStr);

       errList.Add(err);
      }//
      else
      {
       Console.WriteLine
        ("[{0}] OK. {1} -> \"{2}\"",
         idx,
         testData.Value,
         strValue);
      }//else
     }//foreach testData
    }//using cmd
   }//using tr
  }//using cn

  if(errList.Count>0)
  {
   var sb=new StringBuilder();

   sb.Append("FAILED OPERATIONS:");

   errList
    .Aggregate
      (sb,(current,next)=>current.Append(Environment.NewLine).Append(next))
    .ToString();

   throw new ApplicationException(sb.ToString());
  }//if
 }//Test_001__SERVER

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002__SERVER___negative()
 {
  var errList=new List<string>();

  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    using(var cmd=cn.CreateCommand())
    {
     cmd.Transaction=tr;

     cmd.CommandText
      ="select CAST(CAST(:v AS FLOAT) AS VARCHAR(32)) from DUAL";

     cmd.Prepare();

     for(int idx=0;idx!=sm_Data.Length;++idx)
     {
      var testData=sm_Data[idx];

      if(double.IsInfinity(testData.Value))
       continue;

      if(double.IsNaN(testData.Value))
       continue;

      if(double.IsNegative(testData.Value))
       continue;

      if(testData.Value==0)
       continue;

      cmd["v"].Value=-testData.Value;
      
      var objValue=cmd.ExecuteScalar();

      if(!(objValue is string))
       throw new ApplicationException("INCORRECT RESULT!");

      var strValue=(string)objValue;

      var expectedStr='-'+testData.Text;

      if(expectedStr!=strValue)
      {
       string err
        =string.Format
         ("[{0}] {1} -> [{2}]\"{3}\". Expected [{4}]\"{5}\"",
          idx,
          -testData.Value,
          strValue.Length,
          strValue,
          expectedStr.Length,
          expectedStr);

       errList.Add(err);
      }//
      else
      {
       Console.WriteLine
        ("[{0}] OK. {1} -> \"{2}\"",
         idx,
         -testData.Value,
         strValue);
      }//else
     }//foreach testData
    }//using cmd
   }//using tr
  }//using cn

  if(errList.Count>0)
  {
   var sb=new StringBuilder();

   sb.Append("FAILED OPERATIONS:");

   errList
    .Aggregate
      (sb,(current,next)=>current.Append(Environment.NewLine).Append(next))
    .ToString();

   throw new ApplicationException(sb.ToString());
  }//if
 }//Test_002__SERVER___negative

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_100__LOCAL()
 {
  var errList=new List<string>();

  for(int idx=0;idx!=sm_Data.Length;++idx)
  {
   var testData=sm_Data[idx];

   var strValue
    =xEFCore.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Code.Convert_Code__FLOAT__STRING.Exec
      (testData.Value);

   var expectedStr=testData.Text;

   if(expectedStr!=strValue)
   {
    string err
     =string.Format
      ("[{0}] {1} -> [{2}]\"{3}\". Expected [{4}]\"{5}\"",
       idx,
       testData.Value,
       strValue.Length,
       strValue,
       expectedStr.Length,
       expectedStr);

    errList.Add(err);
   }//
   else
   {
    Console.WriteLine
     ("[{0}] OK. {1} -> \"{2}\"",
      idx,
      testData.Value,
      strValue);
   }//else
  }//foreach testData

  if(errList.Count>0)
  {
   var sb=new StringBuilder();

   sb.Append("FAILED OPERATIONS:");

   errList
    .Aggregate
      (sb,(current,next)=>current.Append(Environment.NewLine).Append(next))
    .ToString();

   throw new ApplicationException(sb.ToString());
  }//if
 }//Test_100__LOCAL

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_101__LOCAL___negative()
 {
  var errList=new List<string>();

  for(int idx=0;idx!=sm_Data.Length;++idx)
  {
   var testData=sm_Data[idx];

   if(double.IsInfinity(testData.Value))
    continue;

   if(double.IsNaN(testData.Value))
    continue;

   if(double.IsNegative(testData.Value))
    continue;

   if(testData.Value==0)
    continue;

   var strValue
    =xEFCore.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Code.Convert_Code__FLOAT__STRING.Exec
      (-testData.Value);

   var expectedStr='-'+testData.Text;

   if(expectedStr!=strValue)
   {
    string err
     =string.Format
      ("[{0}] {1} -> [{2}]\"{3}\". Expected [{4}]\"{5}\"",
       idx,
       -testData.Value,
       strValue.Length,
       strValue,
       expectedStr.Length,
       expectedStr);

    errList.Add(err);
   }//
   else
   {
    Console.WriteLine
     ("[{0}] OK. {1} -> \"{2}\"",
      idx,
      -testData.Value,
      strValue);
   }//else
  }//foreach testData

  if(errList.Count>0)
  {
   var sb=new StringBuilder();

   sb.Append("FAILED OPERATIONS:");

   errList
    .Aggregate
      (sb,(current,next)=>current.Append(Environment.NewLine).Append(next))
    .ToString();

   throw new ApplicationException(sb.ToString());
  }//if
 }//Test_101__LOCAL___negative
};//class TestSet_001__verify_result_type

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.CastAs.SET_001.Single.String

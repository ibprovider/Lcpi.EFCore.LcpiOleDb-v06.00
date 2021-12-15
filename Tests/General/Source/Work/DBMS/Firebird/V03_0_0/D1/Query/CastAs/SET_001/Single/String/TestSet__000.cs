////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 26.01.2021.
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;
using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.CastAs.SET_001.Single.String{
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
  /*    0 */ new tagData(0F                        ,"0.0000000"),
  /*    1 */ new tagData(1F                        ,"1.0000000"),
  /*    2 */ new tagData(1.20000000F               ,"1.2000000"),
  /*    3 */ new tagData(1.23000000F               ,"1.2300000"),
  /*    4 */ new tagData(1.23400000F               ,"1.2340000"),
  /*    5 */ new tagData(1.23450000F               ,"1.2345001"),
  /*    6 */ new tagData(1.23456000F               ,"1.2345600"),
  /*    7 */ new tagData(1.23456700F               ,"1.2345670"),
  /*    8 */ new tagData(1.23456780F               ,"1.2345678"),
  /*    9 */ new tagData(1.23456789F               ,"1.2345679"),
  /*   10 */ new tagData(1.23456790F               ,"1.2345679"),
  /*   11 */ new tagData(1.23456791F               ,"1.2345679"),
  /*   12 */ new tagData(1.23456792F               ,"1.2345679"),
  /*   13 */ new tagData(1.23456793F               ,"1.2345679"),
  /*   14 */ new tagData(1.23456794F               ,"1.2345679"),
  /*   15 */ new tagData(1.23456795F               ,"1.2345680"),
  /*   16 */ new tagData(1.23456796F               ,"1.2345680"),
  /*   17 */ new tagData(1.23456797F               ,"1.2345680"),
  /*   18 */ new tagData(1.23456798F               ,"1.2345680"),
  /*   19 */ new tagData(1.23456799F               ,"1.2345680"),

  /*   20 */ new tagData(1200.00000F               ,"1200.0000"),
  /*   21 */ new tagData(1230.00000F               ,"1230.0000"),
  /*   22 */ new tagData(1234.00000F               ,"1234.0000"),
  /*   23 */ new tagData(1234.50000F               ,"1234.5000"),
  /*   24 */ new tagData(1234.56000F               ,"1234.5601"),
  /*   25 */ new tagData(1234.56700F               ,"1234.5670"),
  /*   26 */ new tagData(1234.56780F               ,"1234.5677"),
  /*   27 */ new tagData(1234.56789F               ,"1234.5679"),
  /*   28 */ new tagData(1234.56790F               ,"1234.5679"),
  /*   29 */ new tagData(1234.56791F               ,"1234.5679"),
  /*   30 */ new tagData(1234.56792F               ,"1234.5679"),
  /*   31 */ new tagData(1234.56793F               ,"1234.5679"),
  /*   32 */ new tagData(1234.56794F               ,"1234.5680"),
  /*   33 */ new tagData(1234.56795F               ,"1234.5680"),
  /*   34 */ new tagData(1234.56796F               ,"1234.5680"),
  /*   35 */ new tagData(1234.56797F               ,"1234.5680"),
  /*   36 */ new tagData(1234.56798F               ,"1234.5680"),
  /*   37 */ new tagData(1234.56799F               ,"1234.5680"),
                                                  
  /*   38 */ new tagData(120000.000F               ,"120000.00"),
  /*   39 */ new tagData(123000.000F               ,"123000.00"),
  /*   40 */ new tagData(123400.000F               ,"123400.00"),
  /*   41 */ new tagData(123450.000F               ,"123450.00"),
  /*   42 */ new tagData(123456.000F               ,"123456.00"),
  /*   43 */ new tagData(123456.700F               ,"123456.70"),
  /*   44 */ new tagData(123456.780F               ,"123456.78"),
  /*   45 */ new tagData(123456.789F               ,"123456.79"),
  /*   46 */ new tagData(123456.790F               ,"123456.79"),
  /*   47 */ new tagData(123456.791F               ,"123456.79"),
  /*   48 */ new tagData(123456.792F               ,"123456.79"),
  /*   49 */ new tagData(123456.793F               ,"123456.80"),
  /*   50 */ new tagData(123456.794F               ,"123456.80"),
  /*   51 */ new tagData(123456.795F               ,"123456.80"),
  /*   52 */ new tagData(123456.796F               ,"123456.80"),
  /*   53 */ new tagData(123456.797F               ,"123456.80"),
  /*   54 */ new tagData(123456.798F               ,"123456.80"),
  /*   55 */ new tagData(123456.799F               ,"123456.80"),
                                                  
  /*   56 */ new tagData(1200000.00F               ,"1200000.0"),
  /*   57 */ new tagData(1230000.00F               ,"1230000.0"),
  /*   58 */ new tagData(1234000.00F               ,"1234000.0"),
  /*   59 */ new tagData(1234500.00F               ,"1234500.0"),
  /*   60 */ new tagData(1234560.00F               ,"1234560.0"),
  /*   61 */ new tagData(1234567.00F               ,"1234567.0"),
  /*   62 */ new tagData(1234567.80F               ,"1234567.8"),
  /*   63 */ new tagData(1234567.89F               ,"1234567.9"),
  /*   64 */ new tagData(1234567.90F               ,"1234567.9"),
  /*   65 */ new tagData(1234567.91F               ,"1234567.9"),
  /*   66 */ new tagData(1234567.92F               ,"1234567.9"),
  /*   67 */ new tagData(1234567.93F               ,"1234567.9"),
  /*   68 */ new tagData(1234567.94F               ,"1234568.0"),
  /*   69 */ new tagData(1234567.95F               ,"1234568.0"),
  /*   70 */ new tagData(1234567.96F               ,"1234568.0"),
  /*   71 */ new tagData(1234567.97F               ,"1234568.0"),
  /*   72 */ new tagData(1234567.98F               ,"1234568.0"),
  /*   73 */ new tagData(1234567.99F               ,"1234568.0"),
                                                  
  /*   74 */ new tagData(12000000.0F               ,"12000000."),
  /*   75 */ new tagData(12300000.0F               ,"12300000."),
  /*   76 */ new tagData(12340000.0F               ,"12340000."),
  /*   77 */ new tagData(12345000.0F               ,"12345000."),
  /*   78 */ new tagData(12345600.0F               ,"12345600."),
  /*   79 */ new tagData(12345670.0F               ,"12345670."),
  /*   80 */ new tagData(12345678.0F               ,"12345678."),
  /*   81 */ new tagData(12345678.9F               ,"12345679."),
  /*   82 */ new tagData(12345679.0F               ,"12345679."),
  /*   83 */ new tagData(12345679.1F               ,"12345679."),
  /*   84 */ new tagData(12345679.2F               ,"12345679."),
  /*   85 */ new tagData(12345679.3F               ,"12345679."),
  /*   86 */ new tagData(12345679.4F               ,"12345679."),
  /*   87 */ new tagData(12345679.5F               ,"12345680."),
  /*   88 */ new tagData(12345679.6F               ,"12345680."),
  /*   89 */ new tagData(12345679.7F               ,"12345680."),
  /*   90 */ new tagData(12345679.8F               ,"12345680."),
  /*   91 */ new tagData(12345679.9F               ,"12345680."),
                                                  
  /*   92 */ new tagData(99999999.0F               ,"1.0000000e+08"),
  /*   93 */ new tagData(999999999.0F              ,"1.0000000e+09"),

  /*   94 */ new tagData(1.000000e+8F              ,"1.0000000e+08"),
  /*   95 */ new tagData(9.999999e+8F              ,"9.9999987e+08"),

  /*   96 */ new tagData(1.4F                      ,"1.4000000"),
  /*   97 */ new tagData(1.5F                      ,"1.5000000"),
  /*   97 */ new tagData(1.6F                      ,"1.6000000"),

  /*  133 */ new tagData(1.000000000000000e+17F    ,"9.9999998e+16"),
  /*  134 */ new tagData(9.999999999999987e+17F    ,"9.9999998e+17"),

  /*  135 */ new tagData(float.MinValue            ,"-3.4028235e+38"),
  /*  136 */ new tagData(float.MaxValue            ,"3.4028235e+38"),
  /*  137 */ new tagData(float.Epsilon             ,"1.4012985e-45"),

  /*  138 */ new tagData(5.82342349082234E-264F    ,"0.0000000"),

  /*  139 */ new tagData(float.NaN                 ,"nan(ind)"),
  /*  140 */ new tagData(float.PositiveInfinity    ,"inf"),

  /*  141 */ new tagData(-float.NaN                ,"nan(ind)"),
  /*  142 */ new tagData(-float.PositiveInfinity   ,"-inf"),
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

      if(float.IsInfinity(testData.Value))
       continue;

      if(float.IsNaN(testData.Value))
       continue;

      if(float.IsNegative(testData.Value))
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

   if(float.IsInfinity(testData.Value))
    continue;

   if(float.IsNaN(testData.Value))
    continue;

   if(float.IsNegative(testData.Value))
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
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.CastAs.SET_001.Single.String

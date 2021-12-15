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

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.CastAs.SET_001.Double.String{
////////////////////////////////////////////////////////////////////////////////

using T_SOURCE_VALUE=System.Double;
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
  /*    0 */ new tagData(0                        ,"0.000000000000000"),
  /*    1 */ new tagData(1                        ,"1.000000000000000"),
  /*    2 */ new tagData(1.200000000000000        ,"1.200000000000000"),
  /*    3 */ new tagData(1.230000000000000        ,"1.230000000000000"),
  /*    4 */ new tagData(1.234000000000000        ,"1.234000000000000"),
  /*    5 */ new tagData(1.234500000000000        ,"1.234500000000000"),
  /*    6 */ new tagData(1.234560000000000        ,"1.234560000000000"),
  /*    7 */ new tagData(1.234567000000000        ,"1.234567000000000"),
  /*    8 */ new tagData(1.234567800000000        ,"1.234567800000000"),
  /*    9 */ new tagData(1.234567890000000        ,"1.234567890000000"),
  /*   10 */ new tagData(1.234567890100000        ,"1.234567890100000"),
  /*   11 */ new tagData(1.234567890120000        ,"1.234567890120000"),
  /*   12 */ new tagData(1.234567890123000        ,"1.234567890123000"),
  /*   13 */ new tagData(1.234567890123400        ,"1.234567890123400"),
  /*   14 */ new tagData(1.234567890123450        ,"1.234567890123450"),
  /*   15 */ new tagData(1.234567890123451        ,"1.234567890123451"),
  /*   16 */ new tagData(1.234567890123452        ,"1.234567890123452"),
  /*   17 */ new tagData(1.234567890123453        ,"1.234567890123453"),
  /*   18 */ new tagData(1.234567890123454        ,"1.234567890123454"),
  /*   19 */ new tagData(1.234567890123455        ,"1.234567890123455"),
  /*   20 */ new tagData(1.234567890123456        ,"1.234567890123456"),
  /*   21 */ new tagData(1.234567890123457        ,"1.234567890123457"),
  /*   22 */ new tagData(1.234567890123458        ,"1.234567890123458"),
  /*   23 */ new tagData(1.234567890123459        ,"1.234567890123459"),
  /*   24 */ new tagData(1.2345678901234590       ,"1.234567890123459"),
  /*   25 */ new tagData(1.2345678901234591       ,"1.234567890123459"),
  /*   26 */ new tagData(1.2345678901234592       ,"1.234567890123459"),
  /*   27 */ new tagData(1.2345678901234593       ,"1.234567890123459"),
  /*   28 */ new tagData(1.2345678901234594       ,"1.234567890123459"),
  /*   29 */ new tagData(1.2345678901234595       ,"1.234567890123460"),
  /*   30 */ new tagData(1.2345678901234596       ,"1.234567890123460"),
  /*   31 */ new tagData(1.2345678901234597       ,"1.234567890123460"),
  /*   32 */ new tagData(1.2345678901234598       ,"1.234567890123460"),
  /*   33 */ new tagData(1.2345678901234599       ,"1.234567890123460"),
  /*   34 */ new tagData(12000000000.00000        ,"12000000000.00000"),
  /*   35 */ new tagData(12300000000.00000        ,"12300000000.00000"),
  /*   36 */ new tagData(12340000000.00000        ,"12340000000.00000"),
  /*   37 */ new tagData(12345000000.00000        ,"12345000000.00000"),
  /*   38 */ new tagData(12345600000.00000        ,"12345600000.00000"),
  /*   39 */ new tagData(12345670000.00000        ,"12345670000.00000"),
  /*   40 */ new tagData(12345678000.00000        ,"12345678000.00000"),
  /*   41 */ new tagData(12345678900.00000        ,"12345678900.00000"),
  /*   42 */ new tagData(12345678901.00000        ,"12345678901.00000"),
  /*   43 */ new tagData(12345678901.20000        ,"12345678901.20000"),
  /*   44 */ new tagData(12345678901.23000        ,"12345678901.23000"),
  /*   45 */ new tagData(12345678901.23400        ,"12345678901.23400"),
  /*   46 */ new tagData(12345678901.23450        ,"12345678901.23450"),
  /*   47 */ new tagData(12345678901.23451        ,"12345678901.23451"),
  /*   48 */ new tagData(12345678901.23452        ,"12345678901.23452"),
  /*   49 */ new tagData(12345678901.23453        ,"12345678901.23453"),
  /*   50 */ new tagData(12345678901.23454        ,"12345678901.23454"),
  /*   51 */ new tagData(12345678901.23455        ,"12345678901.23455"),
  /*   52 */ new tagData(12345678901.23456        ,"12345678901.23456"),
  /*   53 */ new tagData(12345678901.23457        ,"12345678901.23457"),
  /*   54 */ new tagData(12345678901.23458        ,"12345678901.23458"),
  /*   55 */ new tagData(12345678901.23459        ,"12345678901.23459"),
  /*   56 */ new tagData(12345678901.234590       ,"12345678901.23459"),
  /*   57 */ new tagData(12345678901.234591       ,"12345678901.23459"),
  /*   58 */ new tagData(12345678901.234592       ,"12345678901.23459"),
  /*   59 */ new tagData(12345678901.234593       ,"12345678901.23459"),
  /*   60 */ new tagData(12345678901.234594       ,"12345678901.23459"),
  /*   61 */ new tagData(12345678901.234595       ,"12345678901.23459"),
  /*   62 */ new tagData(12345678901.234596       ,"12345678901.23460"),
  /*   63 */ new tagData(12345678901.234597       ,"12345678901.23460"),
  /*   64 */ new tagData(12345678901.234598       ,"12345678901.23460"),
  /*   65 */ new tagData(12345678901.234599       ,"12345678901.23460"),
  /*   66 */ new tagData(120000000000000.0        ,"120000000000000.0"),
  /*   67 */ new tagData(123000000000000.0        ,"123000000000000.0"),
  /*   68 */ new tagData(123400000000000.0        ,"123400000000000.0"),
  /*   69 */ new tagData(123450000000000.0        ,"123450000000000.0"),
  /*   70 */ new tagData(123456000000000.0        ,"123456000000000.0"),
  /*   71 */ new tagData(123456700000000.0        ,"123456700000000.0"),
  /*   72 */ new tagData(123456780000000.0        ,"123456780000000.0"),
  /*   73 */ new tagData(123456789000000.0        ,"123456789000000.0"),
  /*   74 */ new tagData(123456789010000.0        ,"123456789010000.0"),
  /*   75 */ new tagData(123456789012000.0        ,"123456789012000.0"),
  /*   76 */ new tagData(123456789012300.0        ,"123456789012300.0"),
  /*   77 */ new tagData(123456789012340.0        ,"123456789012340.0"),
  /*   78 */ new tagData(123456789012345.0        ,"123456789012345.0"),
  /*   79 */ new tagData(123456789012345.1        ,"123456789012345.1"),
  /*   80 */ new tagData(123456789012345.2        ,"123456789012345.2"),
  /*   81 */ new tagData(123456789012345.3        ,"123456789012345.3"),
  /*   82 */ new tagData(123456789012345.4        ,"123456789012345.4"),
  /*   83 */ new tagData(123456789012345.5        ,"123456789012345.5"),
  /*   84 */ new tagData(123456789012345.6        ,"123456789012345.6"),
  /*   85 */ new tagData(123456789012345.7        ,"123456789012345.7"),
  /*   86 */ new tagData(123456789012345.8        ,"123456789012345.8"),
  /*   87 */ new tagData(123456789012345.9        ,"123456789012345.9"),
  /*   88 */ new tagData(123456789012345.90       ,"123456789012345.9"),
  /*   89 */ new tagData(123456789012345.91       ,"123456789012345.9"),
  /*   90 */ new tagData(123456789012345.92       ,"123456789012345.9"),
  /*   91 */ new tagData(123456789012345.93       ,"123456789012345.9"),
  /*   92 */ new tagData(123456789012345.94       ,"123456789012345.9"),
  /*   93 */ new tagData(123456789012345.95       ,"123456789012346.0"),
  /*   94 */ new tagData(123456789012345.96       ,"123456789012346.0"),
  /*   95 */ new tagData(123456789012345.97       ,"123456789012346.0"),
  /*   96 */ new tagData(123456789012345.98       ,"123456789012346.0"),
  /*   97 */ new tagData(123456789012345.99       ,"123456789012346.0"),
  /*   98 */ new tagData(1200000000000000.0       ,"1200000000000000."),
  /*   99 */ new tagData(1230000000000000.0       ,"1230000000000000."),
  /*  100 */ new tagData(1234000000000000.0       ,"1234000000000000."),
  /*  101 */ new tagData(1234500000000000.0       ,"1234500000000000."),
  /*  102 */ new tagData(1234560000000000.0       ,"1234560000000000."),
  /*  103 */ new tagData(1234567000000000.0       ,"1234567000000000."),
  /*  104 */ new tagData(1234567800000000.0       ,"1234567800000000."),
  /*  105 */ new tagData(1234567890000000.0       ,"1234567890000000."),
  /*  106 */ new tagData(1234567890100000.0       ,"1234567890100000."),
  /*  107 */ new tagData(1234567890120000.0       ,"1234567890120000."),
  /*  108 */ new tagData(1234567890123000.0       ,"1234567890123000."),
  /*  109 */ new tagData(1234567890123400.0       ,"1234567890123400."),
  /*  110 */ new tagData(1234567890123450.0       ,"1234567890123450."),
  /*  111 */ new tagData(1234567890123451.0       ,"1234567890123451."),
  /*  112 */ new tagData(1234567890123452.0       ,"1234567890123452."),
  /*  113 */ new tagData(1234567890123453.0       ,"1234567890123453."),
  /*  114 */ new tagData(1234567890123454.0       ,"1234567890123454."),
  /*  115 */ new tagData(1234567890123455.0       ,"1234567890123455."),
  /*  116 */ new tagData(1234567890123456.0       ,"1234567890123456."),
  /*  117 */ new tagData(1234567890123457.0       ,"1234567890123457."),
  /*  118 */ new tagData(1234567890123458.0       ,"1234567890123458."),
  /*  119 */ new tagData(1234567890123459.0       ,"1234567890123459."),
  /*  120 */ new tagData(1234567890123459.0       ,"1234567890123459."),
  /*  121 */ new tagData(1234567890123459.1       ,"1234567890123459."),
  /*  122 */ new tagData(1234567890123459.2       ,"1234567890123459."),
  /*  123 */ new tagData(1234567890123459.3       ,"1234567890123459."),
  /*  124 */ new tagData(1234567890123459.4       ,"1234567890123460."),
  /*  125 */ new tagData(1234567890123459.5       ,"1234567890123460."),
  /*  126 */ new tagData(1234567890123459.6       ,"1234567890123460."),
  /*  127 */ new tagData(1234567890123459.7       ,"1234567890123460."),
  /*  128 */ new tagData(1234567890123459.8       ,"1234567890123460."),
  /*  129 */ new tagData(1234567890123459.9       ,"1234567890123460."),
                                                  
  /*  130 */ new tagData(9999999999999999.0       ,"1.000000000000000e+16"),
  /*  131 */ new tagData(9999999999999999.9       ,"1.000000000000000e+16"),
  /*  132 */ new tagData(99999999999999999.9      ,"1.000000000000000e+17"),

  /*  133 */ new tagData(1.000000000000000e+17    ,"1.000000000000000e+17"),
  /*  134 */ new tagData(9.999999999999987e+17    ,"9.999999999999987e+17"),

  /*  135 */ new tagData(double.MinValue          ,"-1.797693134862316e+308"),
  /*  136 */ new tagData(double.MaxValue          ,"1.797693134862316e+308"),
  /*  137 */ new tagData(double.Epsilon           ,"4.940656458412465e-324"),

  /*  138 */ new tagData(5.82342349082234E-264    ,"5.823423490822340e-264"),

  /*  139 */ new tagData(double.NaN               ,"nan(ind)"),
  /*  140 */ new tagData(double.PositiveInfinity  ,"inf"),

  /*  141 */ new tagData(-double.NaN              ,"nan(ind)"),
  /*  142 */ new tagData(-double.PositiveInfinity ,"-inf"),
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
      ="select CAST(CAST(:v AS DOUBLE PRECISION) AS VARCHAR(32)) from DUAL";

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
      ="select CAST(CAST(:v AS DOUBLE PRECISION) AS VARCHAR(32)) from DUAL";

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
    =xEFCore.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Code.Convert_Code__DOUBLE__STRING.Exec
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
    =xEFCore.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Code.Convert_Code__DOUBLE__STRING.Exec
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
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.CastAs.SET_001.Double.String

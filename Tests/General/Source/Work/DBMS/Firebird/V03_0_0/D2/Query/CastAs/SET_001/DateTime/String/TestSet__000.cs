////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 28.01.2021.
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;
using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D2.Query.CastAs.SET_001.DateTime.String{
////////////////////////////////////////////////////////////////////////////////

using T_SOURCE_VALUE=System.DateTime;
using T_TARGET_VALUE=System.String;

using T_LOCAL_CVT
 =Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Code.Convert_Code__TIMESTAMP__STRING___D3;

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
 const long c_ticks_for_MicroSecond
  =1000;

 //-----------------------------------------------------------------------
 private static readonly tagData[] sm_Data=
 {
  /*    0 */ new tagData(new T_SOURCE_VALUE(2021,  1, 03), "2021-01-03 00:00:00.0000"),
  /*    1 */ new tagData(new T_SOURCE_VALUE(2021,  2, 03), "2021-02-03 00:00:00.0000"),
  /*    2 */ new tagData(new T_SOURCE_VALUE(2021,  3, 03), "2021-03-03 00:00:00.0000"),
  /*    3 */ new tagData(new T_SOURCE_VALUE(2021,  4, 03), "2021-04-03 00:00:00.0000"),
  /*    4 */ new tagData(new T_SOURCE_VALUE(2021,  5, 03), "2021-05-03 00:00:00.0000"),
  /*    5 */ new tagData(new T_SOURCE_VALUE(2021,  6, 03), "2021-06-03 00:00:00.0000"),
  /*    6 */ new tagData(new T_SOURCE_VALUE(2021,  7, 03), "2021-07-03 00:00:00.0000"),
  /*    7 */ new tagData(new T_SOURCE_VALUE(2021,  8, 03), "2021-08-03 00:00:00.0000"),
  /*    8 */ new tagData(new T_SOURCE_VALUE(2021,  9, 03), "2021-09-03 00:00:00.0000"),
  /*    9 */ new tagData(new T_SOURCE_VALUE(2021, 10, 03), "2021-10-03 00:00:00.0000"),
  /*   10 */ new tagData(new T_SOURCE_VALUE(2021, 11, 03), "2021-11-03 00:00:00.0000"),
  /*   11 */ new tagData(new T_SOURCE_VALUE(2021, 12, 03), "2021-12-03 00:00:00.0000"),

  /*   12 */ new tagData
              (new T_SOURCE_VALUE(2021, 1, 23, 2, 0, 0),
               "2021-01-23 02:00:00.0000"),

  /*   13 */ new tagData
              (new T_SOURCE_VALUE(2021, 1, 23, 2, 3, 0),
               "2021-01-23 02:03:00.0000"),

  /*   14 */ new tagData
              (new T_SOURCE_VALUE(2021, 1, 23, 2, 3, 4),
               "2021-01-23 02:03:04.0000"),

  /*   15 */ new tagData
              (new T_SOURCE_VALUE(2021, 1, 23, 2, 3, 4, 5),
               "2021-01-23 02:03:04.0050"),

  /*   16 */ new tagData
              (new T_SOURCE_VALUE(2021, 1, 23, 2, 3, 4, 0).AddTicks(9*c_ticks_for_MicroSecond),
               "2021-01-23 02:03:04.0009"),

  /*   17 */ new tagData
              (new T_SOURCE_VALUE(2021, 1, 23, 0, 0, 0).AddTicks(c_ticks_for_MicroSecond),
               "2021-01-23 00:00:00.0001"),

  /*   18 */ new tagData
              (new T_SOURCE_VALUE(2021, 1, 23, 0, 0, 0).AddTicks(c_ticks_for_MicroSecond-1),
               "2021-01-23 00:00:00.0000"),

  /*   19 */ new tagData
              (new T_SOURCE_VALUE( 985,12,  3, 0, 0, 0).AddTicks(c_ticks_for_MicroSecond-1),
               "0985-12-03 00:00:00.0000"),

  /*   20 */ new tagData
              (new T_SOURCE_VALUE(  85,12,  3, 0, 0, 0).AddTicks(c_ticks_for_MicroSecond-1),
               "0085-12-03 00:00:00.0000"),

  /*   20 */ new tagData
              (new T_SOURCE_VALUE(   2,12,  3, 0, 0, 0).AddTicks(c_ticks_for_MicroSecond-1),
               "0002-12-03 00:00:00.0000"),

  /*   21 */ new tagData
              (new T_SOURCE_VALUE(2021, 1, 23, 12, 18, 56).AddTicks(4321*c_ticks_for_MicroSecond),
               "2021-01-23 12:18:56.4321"),
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
      ="select CAST(CAST(:v AS TIMESTAMP) AS VARCHAR(64)) from DUAL";

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
 public static void Test_100__LOCAL()
 {
  var errList=new List<string>();

  for(int idx=0;idx!=sm_Data.Length;++idx)
  {
   var testData=sm_Data[idx];

   var strValue
    =T_LOCAL_CVT.Exec
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
};//class TestSet_001__verify_result_type

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D2.Query.CastAs.SET_001.DateTime.String

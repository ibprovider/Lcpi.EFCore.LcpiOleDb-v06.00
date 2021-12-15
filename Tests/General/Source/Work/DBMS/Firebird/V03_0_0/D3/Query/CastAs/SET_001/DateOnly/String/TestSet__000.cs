////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 02.07.2021.
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;
using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.CastAs.SET_001.DateOnly.String{
////////////////////////////////////////////////////////////////////////////////

using T_SOURCE_VALUE=System.DateOnly;
using T_TARGET_VALUE=System.String;

using T_LOCAL_CVT
 =Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Code.Convert_Code__TYPE_DATE__STRING;

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
  /*    0 */ new tagData(new T_SOURCE_VALUE(2021,  1, 03), "2021-01-03"),
  /*    1 */ new tagData(new T_SOURCE_VALUE(2021,  2, 03), "2021-02-03"),
  /*    2 */ new tagData(new T_SOURCE_VALUE(2021,  3, 03), "2021-03-03"),
  /*    3 */ new tagData(new T_SOURCE_VALUE(2021,  4, 03), "2021-04-03"),
  /*    4 */ new tagData(new T_SOURCE_VALUE(2021,  5, 03), "2021-05-03"),
  /*    5 */ new tagData(new T_SOURCE_VALUE(2021,  6, 03), "2021-06-03"),
  /*    6 */ new tagData(new T_SOURCE_VALUE(2021,  7, 03), "2021-07-03"),
  /*    7 */ new tagData(new T_SOURCE_VALUE(2021,  8, 03), "2021-08-03"),
  /*    8 */ new tagData(new T_SOURCE_VALUE(2021,  9, 03), "2021-09-03"),
  /*    9 */ new tagData(new T_SOURCE_VALUE(2021, 10, 03), "2021-10-03"),
  /*   10 */ new tagData(new T_SOURCE_VALUE(2021, 11, 03), "2021-11-03"),
  /*   11 */ new tagData(new T_SOURCE_VALUE(2021, 12, 03), "2021-12-03"),
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
    var cmd1=cn.CreateCommand();

    cmd1.Transaction=tr;

    cmd1.CommandText
     ="insert into TEST_MODIFY_ROW (COL_TYPE_DATE) VALUES(:v) RETURNING TEST_ID INTO :id";

    cmd1.Parameters.Refresh();

    var cmd2=cn.CreateCommand();

    cmd2.Transaction=tr;

    cmd2.CommandText
     ="select CAST(COL_TYPE_DATE AS VARCHAR(64)) from TEST_MODIFY_ROW where TEST_ID=:id";

    cmd2.Parameters.Refresh();

    for(int idx=0;idx!=sm_Data.Length;++idx)
    {
     var testData=sm_Data[idx];

     cmd1["v"].Value=testData.Value;

     cmd1.ExecuteNonQuery();

     cmd2["id"].Value=cmd1["id"].Value;

     var objValue=cmd2.ExecuteScalar();

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

    cmd2.Dispose();
    cmd1.Dispose();
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
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.CastAs.SET_001.DateOnly.String

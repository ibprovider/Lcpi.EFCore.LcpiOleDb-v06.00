////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 06.12.2020.
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Operators.SET_001.Divide.Complete{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_001__verify_result_type

public static class TestSet_001__verify_result_type
{
 private struct tagData
 {
  public string         LeftType;
  public object         LeftValue;

  public string         RightType;
  public object         RightValue;

  public xdb.OleDbType  ResultOleDbType;

  public object         ResultValue;

  public string         ResultAsStr;

  public tagData(string        left,
                 object        leftValue,
                 string        right,
                 object        rightValue,
                 xdb.OleDbType resultType,
                 object        resultValue,
                 string        resultAsStr)
  {
   this.LeftType        =left;
   this.LeftValue       =leftValue;

   this.RightType       =right;
   this.RightValue      =rightValue;

   this.ResultOleDbType =resultType;
   this.ResultValue     =resultValue;
   this.ResultAsStr     =resultAsStr;
  }//tagData
 };//struct tagData

 private static readonly tagData[] sm_Data_000=
 {
  new tagData("SMALLINT"          ,  2, "SMALLINT"         ,  1, xdb.OleDbType.BigInt  ,           2L , "2"),
  new tagData("SMALLINT"          ,  2, "INTEGER"          ,  1, xdb.OleDbType.BigInt  ,           2L , "2"),
  new tagData("SMALLINT"          ,  2, "BIGINT"           ,  1, xdb.OleDbType.BigInt  ,           2L , "2"),
  new tagData("SMALLINT"          ,  2, "FLOAT"            ,  1, xdb.OleDbType.Double  ,          2.0 , "2.000000000000000"),
  new tagData("SMALLINT"          ,  2, "DOUBLE PRECISION" ,  1, xdb.OleDbType.Double  ,          2.0 , "2.000000000000000"),
  new tagData("SMALLINT"          ,  2, "NUMERIC(1)"       ,  1, xdb.OleDbType.BigInt  ,           2L , "2"),
  new tagData("SMALLINT"          ,  2, "NUMERIC(1,0)"     ,  1, xdb.OleDbType.BigInt  ,           2L , "2"),
  new tagData("SMALLINT"          ,  2, "NUMERIC(2,1)"     ,  1, xdb.OleDbType.Numeric ,           2m , "2.0"),

  new tagData("INTEGER"           ,  2, "SMALLINT"         ,  1, xdb.OleDbType.BigInt  ,           2L , "2"),
  new tagData("INTEGER"           ,  2, "INTEGER"          ,  1, xdb.OleDbType.BigInt  ,           2L , "2"),
  new tagData("INTEGER"           ,  2, "BIGINT"           ,  1, xdb.OleDbType.BigInt  ,           2L , "2"),
  new tagData("INTEGER"           ,  2, "FLOAT"            ,  1, xdb.OleDbType.Double  ,          2.0 , "2.000000000000000"),
  new tagData("INTEGER"           ,  2, "DOUBLE PRECISION" ,  1, xdb.OleDbType.Double  ,          2.0 , "2.000000000000000"),
  new tagData("INTEGER"           ,  2, "NUMERIC(1)"       ,  1, xdb.OleDbType.BigInt  ,           2L , "2"),
  new tagData("INTEGER"           ,  2, "NUMERIC(1,0)"     ,  1, xdb.OleDbType.BigInt  ,           2L , "2"),
  new tagData("INTEGER"           ,  2, "NUMERIC(2,1)"     ,  1, xdb.OleDbType.Numeric ,           2m , "2.0"),

  new tagData("BIGINT"            ,  2, "SMALLINT"         ,  1, xdb.OleDbType.BigInt  ,           2L , "2"),
  new tagData("BIGINT"            ,  2, "INTEGER"          ,  1, xdb.OleDbType.BigInt  ,           2L , "2"),
  new tagData("BIGINT"            ,  2, "BIGINT"           ,  1, xdb.OleDbType.BigInt  ,           2L , "2"),
  new tagData("BIGINT"            ,  2, "FLOAT"            ,  1, xdb.OleDbType.Double  ,          2.0 , "2.000000000000000"),
  new tagData("BIGINT"            ,  2, "DOUBLE PRECISION" ,  1, xdb.OleDbType.Double  ,          2.0 , "2.000000000000000"),
  new tagData("BIGINT"            ,  2, "NUMERIC(1)"       ,  1, xdb.OleDbType.BigInt  ,           2L , "2"),
  new tagData("BIGINT"            ,  2, "NUMERIC(1,0)"     ,  1, xdb.OleDbType.BigInt  ,           2L , "2"),
  new tagData("BIGINT"            ,  2, "NUMERIC(2,1)"     ,  1, xdb.OleDbType.Numeric ,           2m , "2.0"),

  new tagData("FLOAT"             ,  2, "SMALLINT"         ,  1, xdb.OleDbType.Double  ,          2.0 , "2.000000000000000"),
  new tagData("FLOAT"             ,  2, "INTEGER"          ,  1, xdb.OleDbType.Double  ,          2.0 , "2.000000000000000"),
  new tagData("FLOAT"             ,  2, "BIGINT"           ,  1, xdb.OleDbType.Double  ,          2.0 , "2.000000000000000"),
  new tagData("FLOAT"             ,  2, "FLOAT"            ,  1, xdb.OleDbType.Double  ,          2.0 , "2.000000000000000"),
  new tagData("FLOAT"             ,  2, "DOUBLE PRECISION" ,  1, xdb.OleDbType.Double  ,          2.0 , "2.000000000000000"),
  new tagData("FLOAT"             ,  2, "NUMERIC(1)"       ,  1, xdb.OleDbType.Double  ,          2.0 , "2.000000000000000"),
  new tagData("FLOAT"             ,  2, "NUMERIC(1,0)"     ,  1, xdb.OleDbType.Double  ,          2.0 , "2.000000000000000"),
  new tagData("FLOAT"             ,  2, "NUMERIC(2,1)"     ,  1, xdb.OleDbType.Double  ,          2.0 , "2.000000000000000"),

  new tagData("DOUBLE PRECISION"  ,  2, "SMALLINT"         ,  1, xdb.OleDbType.Double  ,          2.0 , "2.000000000000000"),
  new tagData("DOUBLE PRECISION"  ,  2, "INTEGER"          ,  1, xdb.OleDbType.Double  ,          2.0 , "2.000000000000000"),
  new tagData("DOUBLE PRECISION"  ,  2, "BIGINT"           ,  1, xdb.OleDbType.Double  ,          2.0 , "2.000000000000000"),
  new tagData("DOUBLE PRECISION"  ,  2, "FLOAT"            ,  1, xdb.OleDbType.Double  ,          2.0 , "2.000000000000000"),
  new tagData("DOUBLE PRECISION"  ,  2, "DOUBLE PRECISION" ,  1, xdb.OleDbType.Double  ,          2.0 , "2.000000000000000"),
  new tagData("DOUBLE PRECISION"  ,  2, "NUMERIC(1)"       ,  1, xdb.OleDbType.Double  ,          2.0 , "2.000000000000000"),
  new tagData("DOUBLE PRECISION"  ,  2, "NUMERIC(1,0)"     ,  1, xdb.OleDbType.Double  ,          2.0 , "2.000000000000000"),
  new tagData("DOUBLE PRECISION"  ,  2, "NUMERIC(2,1)"     ,  1, xdb.OleDbType.Double  ,          2.0 , "2.000000000000000"),

  new tagData("NUMERIC(1)"        ,  2, "SMALLINT"         ,  1, xdb.OleDbType.BigInt  ,           2L , "2"),
  new tagData("NUMERIC(1)"        ,  2, "INTEGER"          ,  1, xdb.OleDbType.BigInt  ,           2L , "2"),
  new tagData("NUMERIC(1)"        ,  2, "BIGINT"           ,  1, xdb.OleDbType.BigInt  ,           2L , "2"),
  new tagData("NUMERIC(1)"        ,  2, "FLOAT"            ,  1, xdb.OleDbType.Double  ,          2.0 , "2.000000000000000"),
  new tagData("NUMERIC(1)"        ,  2, "DOUBLE PRECISION" ,  1, xdb.OleDbType.Double  ,          2.0 , "2.000000000000000"),
  new tagData("NUMERIC(1)"        ,  2, "NUMERIC(1)"       ,  1, xdb.OleDbType.BigInt  ,           2L , "2"),
  new tagData("NUMERIC(1)"        ,  2, "NUMERIC(1,0)"     ,  1, xdb.OleDbType.BigInt  ,           2L , "2"),
  new tagData("NUMERIC(1)"        ,  2, "NUMERIC(2,1)"     ,  1, xdb.OleDbType.Numeric ,           2m , "2.0"),

  new tagData("NUMERIC(1,0)"      ,  2, "SMALLINT"         ,  1, xdb.OleDbType.BigInt  ,           2L , "2"),
  new tagData("NUMERIC(1,0)"      ,  2, "INTEGER"          ,  1, xdb.OleDbType.BigInt  ,           2L , "2"),
  new tagData("NUMERIC(1,0)"      ,  2, "BIGINT"           ,  1, xdb.OleDbType.BigInt  ,           2L , "2"),
  new tagData("NUMERIC(1,0)"      ,  2, "FLOAT"            ,  1, xdb.OleDbType.Double  ,          2.0 , "2.000000000000000"),
  new tagData("NUMERIC(1,0)"      ,  2, "DOUBLE PRECISION" ,  1, xdb.OleDbType.Double  ,          2.0 , "2.000000000000000"),
  new tagData("NUMERIC(1,0)"      ,  2, "NUMERIC(1)"       ,  1, xdb.OleDbType.BigInt  ,           2L , "2"),
  new tagData("NUMERIC(1,0)"      ,  2, "NUMERIC(1,0)"     ,  1, xdb.OleDbType.BigInt  ,           2L , "2"),
  new tagData("NUMERIC(1,0)"      ,  2, "NUMERIC(2,1)"     ,  1, xdb.OleDbType.Numeric ,           2m , "2.0"),

  new tagData("NUMERIC(2,1)"      ,  2, "SMALLINT"         ,  1, xdb.OleDbType.Numeric ,           2m , "2.0"),
  new tagData("NUMERIC(2,1)"      ,  2, "INTEGER"          ,  1, xdb.OleDbType.Numeric ,           2m , "2.0"),
  new tagData("NUMERIC(2,1)"      ,  2, "BIGINT"           ,  1, xdb.OleDbType.Numeric ,           2m , "2.0"),
  new tagData("NUMERIC(2,1)"      ,  2, "FLOAT"            ,  1, xdb.OleDbType.Double  ,          2.0 , "2.000000000000000"),
  new tagData("NUMERIC(2,1)"      ,  2, "DOUBLE PRECISION" ,  1, xdb.OleDbType.Double  ,          2.0 , "2.000000000000000"),
  new tagData("NUMERIC(2,1)"      ,  2, "NUMERIC(1)"       ,  1, xdb.OleDbType.Numeric ,           2m , "2.0"),
  new tagData("NUMERIC(2,1)"      ,  2, "NUMERIC(1,0)"     ,  1, xdb.OleDbType.Numeric ,           2m , "2.0"),
  new tagData("NUMERIC(2,1)"      ,  2, "NUMERIC(2,1)"     ,  1, xdb.OleDbType.Numeric ,           2m , "2.00"),

  new tagData("DOUBLE PRECISION"  ,  0, "DOUBLE PRECISION" ,  1, xdb.OleDbType.Double  ,          0.0 , "0.000000000000000"),
 };//sm_Data_000

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_000()
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

     foreach(var testData in sm_Data_000)
     {
      string sql
       ="select CAST(2 AS "+testData.LeftType+")/CAST(1 AS "+testData.RightType+") from DUAL";

      cmd.CommandText
       =sql;

      cmd.Prepare();

      using(var reader=cmd.ExecuteReader(System.Data.CommandBehavior.SchemaOnly))
      {
       Assert.IsNotNull
        (reader);

       var schema=reader.GetSchemaTable();

       Assert.IsNotNull
        (schema);

       Assert.AreEqual
        (1,
         schema.Rows.Count);

       var actualOleDbType
        =(xdb.OleDbType)schema.Rows[0][xdb.OleDbDataReaderSchemaColumnNames.ProviderType];

       if(testData.ResultOleDbType != actualOleDbType)
       {
        string err
         =string.Format
          ("{0} / {1} == {2}. Expected {3}",
           testData.LeftType,
           testData.RightType,
           actualOleDbType,
           testData.ResultOleDbType);

        errList.Add(err);
       }//if
      }//using reader
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
 }//Test_000

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_000__check_result()
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

     foreach(var testData in sm_Data_000)
     {
      string sql
       ="select CAST("+testData.LeftValue+" AS "+testData.LeftType+")/CAST("+testData.RightValue+" AS "+testData.RightType+") from DUAL";

      cmd.CommandText
       =sql;

      cmd.Prepare();

      using(var reader=cmd.ExecuteReader())
      {
       Assert.IsNotNull
        (reader);

       Assert.IsTrue
        (reader.Read());

       var actualValue
        =reader[0];

       Assert.NotNull
        (actualValue);

       Assert.NotNull
        (testData.ResultValue);

       if(!testData.ResultValue.Equals(actualValue))
       {
        string err
         =string.Format
          ("{0} / {1} == {2}. Expected \"{3}\"",
           testData.LeftType,
           testData.RightType,
           actualValue,
           testData.ResultValue);

        errList.Add(err);
       }//if

       if(!testData.ResultValue.GetType().Equals(actualValue.GetType()))
       {
        string err
         =string.Format
          ("{0} / {1} -> {2}. Expected \"{3}\"",
           testData.LeftType,
           testData.RightType,
           actualValue.GetType(),
           testData.ResultValue.GetType());

        errList.Add(err);
       }//if
      }//using reader
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
 }//Test_000__check_result

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_000__as_string()
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

     foreach(var testData in sm_Data_000)
     {
      string sql
       ="select CAST(CAST("+testData.LeftValue+" AS "+testData.LeftType+")/CAST("+testData.RightValue+" AS "+testData.RightType+") AS VARCHAR(64)) from DUAL";

      cmd.CommandText
       =sql;

      cmd.Prepare();

      using(var reader=cmd.ExecuteReader())
      {
       Assert.IsNotNull
        (reader);

       Assert.IsTrue
        (reader.Read());

       var actualStr
        =reader.GetString(0);

       if(testData.ResultAsStr != actualStr)
       {
        string err
         =string.Format
          ("{0} / {1} == \"{2}\". Expected \"{3}\"",
           testData.LeftType,
           testData.RightType,
           actualStr,
           testData.ResultAsStr);

        errList.Add(err);
       }//if
      }//using reader
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
 }//Test_000__as_string
};//class TestSet_001__verify_result_type

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Operators.SET_001.Divide.Complete

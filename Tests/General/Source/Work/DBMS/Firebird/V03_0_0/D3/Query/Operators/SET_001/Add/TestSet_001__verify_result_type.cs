////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 26.11.2020.
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Operators.SET_001.Add{
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

  public string         ResultAsStr;

  public tagData(string        left,
                 object        leftValue,
                 string        right,
                 object        rightValue,
                 xdb.OleDbType result,
                 string        resultAsStr)
  {
   this.LeftType        =left;
   this.LeftValue       =leftValue;

   this.RightType       =right;
   this.RightValue      =rightValue;

   this.ResultOleDbType =result;
   this.ResultAsStr     =resultAsStr;
  }//tagData
 };//struct tagData

 //-----------------------------------------------------------------------
 private const string c_TypeName_BIGINT
  ="BIGINT";

 //-----------------------------------------------------------------------
 private static readonly tagData[] sm_Data_000=
 {
  new tagData("SMALLINT"          ,  2, "SMALLINT"         ,  1, xdb.OleDbType.BigInt  , "3"),
  new tagData("SMALLINT"          ,  2, "INTEGER"          ,  1, xdb.OleDbType.BigInt  , "3"),
  new tagData("SMALLINT"          ,  2, c_TypeName_BIGINT  ,  1, xdb.OleDbType.BigInt  , "3"),
  new tagData("SMALLINT"          ,  2, "FLOAT"            ,  1, xdb.OleDbType.Double  , "3.000000000000000"),
  new tagData("SMALLINT"          ,  2, "DOUBLE PRECISION" ,  1, xdb.OleDbType.Double  , "3.000000000000000"),
  new tagData("SMALLINT"          ,  2, "NUMERIC(1)"       ,  1, xdb.OleDbType.BigInt  , "3"),
  new tagData("SMALLINT"          ,  2, "NUMERIC(1,0)"     ,  1, xdb.OleDbType.BigInt  , "3"),
  new tagData("SMALLINT"          ,  2, "NUMERIC(2,0)"     ,  1, xdb.OleDbType.BigInt  , "3"),
  new tagData("SMALLINT"          ,  2, "NUMERIC(3,0)"     ,  1, xdb.OleDbType.BigInt  , "3"),
  new tagData("SMALLINT"          ,  2, "NUMERIC(4,0)"     ,  1, xdb.OleDbType.BigInt  , "3"),
  new tagData("SMALLINT"          ,  2, "NUMERIC(5,0)"     ,  1, xdb.OleDbType.BigInt  , "3"),
  new tagData("SMALLINT"          ,  2, "NUMERIC(6,0)"     ,  1, xdb.OleDbType.BigInt  , "3"),
  new tagData("SMALLINT"          ,  2, "NUMERIC(7,0)"     ,  1, xdb.OleDbType.BigInt  , "3"),
  new tagData("SMALLINT"          ,  2, "NUMERIC(8,0)"     ,  1, xdb.OleDbType.BigInt  , "3"),
  new tagData("SMALLINT"          ,  2, "NUMERIC(9,0)"     ,  1, xdb.OleDbType.BigInt  , "3"),
  new tagData("SMALLINT"          ,  2, "NUMERIC(10,0)"    ,  1, xdb.OleDbType.BigInt  , "3"),
  new tagData("SMALLINT"          ,  2, "NUMERIC(11,0)"    ,  1, xdb.OleDbType.BigInt  , "3"),

  new tagData("SMALLINT"          ,  2, "NUMERIC(2,1)"     ,  1, xdb.OleDbType.Numeric , "3.0"),
  new tagData("SMALLINT"          ,  2, "NUMERIC(7,1)"     ,  1, xdb.OleDbType.Numeric , "3.0"),

  new tagData("INTEGER"           ,  2, "SMALLINT"         ,  1, xdb.OleDbType.BigInt  , "3"),
  new tagData("INTEGER"           ,  2, "INTEGER"          ,  1, xdb.OleDbType.BigInt  , "3"),
  new tagData("INTEGER"           ,  2, c_TypeName_BIGINT  ,  1, xdb.OleDbType.BigInt  , "3"),
  new tagData("INTEGER"           ,  2, "FLOAT"            ,  1, xdb.OleDbType.Double  , "3.000000000000000"),
  new tagData("INTEGER"           ,  2, "DOUBLE PRECISION" ,  1, xdb.OleDbType.Double  , "3.000000000000000"),
  new tagData("INTEGER"           ,  2, "NUMERIC(1)"       ,  1, xdb.OleDbType.BigInt  , "3"),
  new tagData("INTEGER"           ,  2, "NUMERIC(1,0)"     ,  1, xdb.OleDbType.BigInt  , "3"),
  new tagData("INTEGER"           ,  2, "NUMERIC(2,1)"     ,  1, xdb.OleDbType.Numeric , "3.0"),

  new tagData(c_TypeName_BIGINT   ,  2, "SMALLINT"         ,  1, xdb.OleDbType.BigInt  , "3"),
  new tagData(c_TypeName_BIGINT   ,  2, "INTEGER"          ,  1, xdb.OleDbType.BigInt  , "3"),
  new tagData(c_TypeName_BIGINT   ,  2, c_TypeName_BIGINT  ,  1, xdb.OleDbType.BigInt  , "3"),
  new tagData(c_TypeName_BIGINT   ,  2, "FLOAT"            ,  1, xdb.OleDbType.Double  , "3.000000000000000"),
  new tagData(c_TypeName_BIGINT   ,  2, "DOUBLE PRECISION" ,  1, xdb.OleDbType.Double  , "3.000000000000000"),
  new tagData(c_TypeName_BIGINT   ,  2, "NUMERIC(1)"       ,  1, xdb.OleDbType.BigInt  , "3"),
  new tagData(c_TypeName_BIGINT   ,  2, "NUMERIC(1,0)"     ,  1, xdb.OleDbType.BigInt  , "3"),
  new tagData(c_TypeName_BIGINT   ,  2, "NUMERIC(2,1)"     ,  1, xdb.OleDbType.Numeric , "3.0"),

  new tagData("FLOAT"             ,  2, "SMALLINT"         ,  1, xdb.OleDbType.Double  , "3.000000000000000"),
  new tagData("FLOAT"             ,  2, "INTEGER"          ,  1, xdb.OleDbType.Double  , "3.000000000000000"),
  new tagData("FLOAT"             ,  2, c_TypeName_BIGINT  ,  1, xdb.OleDbType.Double  , "3.000000000000000"),
  new tagData("FLOAT"             ,  2, "FLOAT"            ,  1, xdb.OleDbType.Double  , "3.000000000000000"),
  new tagData("FLOAT"             ,  2, "DOUBLE PRECISION" ,  1, xdb.OleDbType.Double  , "3.000000000000000"),
  new tagData("FLOAT"             ,  2, "NUMERIC(1)"       ,  1, xdb.OleDbType.Double  , "3.000000000000000"),
  new tagData("FLOAT"             ,  2, "NUMERIC(1,0)"     ,  1, xdb.OleDbType.Double  , "3.000000000000000"),
  new tagData("FLOAT"             ,  2, "NUMERIC(2,1)"     ,  1, xdb.OleDbType.Double  , "3.000000000000000"),

  new tagData("DOUBLE PRECISION"  ,  2, "SMALLINT"         ,  1, xdb.OleDbType.Double  , "3.000000000000000"),
  new tagData("DOUBLE PRECISION"  ,  2, "INTEGER"          ,  1, xdb.OleDbType.Double  , "3.000000000000000"),
  new tagData("DOUBLE PRECISION"  ,  2, c_TypeName_BIGINT  ,  1, xdb.OleDbType.Double  , "3.000000000000000"),
  new tagData("DOUBLE PRECISION"  ,  2, "FLOAT"            ,  1, xdb.OleDbType.Double  , "3.000000000000000"),
  new tagData("DOUBLE PRECISION"  ,  2, "DOUBLE PRECISION" ,  1, xdb.OleDbType.Double  , "3.000000000000000"),
  new tagData("DOUBLE PRECISION"  ,  2, "NUMERIC(1)"       ,  1, xdb.OleDbType.Double  , "3.000000000000000"),
  new tagData("DOUBLE PRECISION"  ,  2, "NUMERIC(1,0)"     ,  1, xdb.OleDbType.Double  , "3.000000000000000"),
  new tagData("DOUBLE PRECISION"  ,  2, "NUMERIC(2,1)"     ,  1, xdb.OleDbType.Double  , "3.000000000000000"),

  //------------------------------------------------------------
  new tagData("TIME",
              "'00:00:00.0000'",
              "SMALLINT",
              "'0'",
              xdb.OleDbType.DBTime,
              "00:00:00.0000"),

  new tagData("TIME",
              "'00:00:00.0000'",
              "INTEGER",
              "'0'",
              xdb.OleDbType.DBTime,
              "00:00:00.0000"),

  new tagData("TIME",
              "'00:00:00.0000'",
              c_TypeName_BIGINT,
              "'0'",
              xdb.OleDbType.DBTime,
              "00:00:00.0000"),

  new tagData("TIME",
              "'00:00:00.0000'",
              "FLOAT",
              "'0'",
              xdb.OleDbType.DBTime,
              "00:00:00.0000"),

  new tagData("TIME",
              "'00:00:00.0000'",
              "DOUBLE PRECISION",
              "'0'",
              xdb.OleDbType.DBTime,
              "00:00:00.0000"),

  new tagData("TIME",
              "'00:00:00.0000'",
              "NUMERIC",
              "'0'",
              xdb.OleDbType.DBTime,
              "00:00:00.0000"),

  //------------------------------------------------------------
  new tagData("TIMESTAMP",
              "'2020-12-08 20:43:08.0000'",
              "SMALLINT",
              "'0'",
              xdb.OleDbType.DBTimeStamp,
              "2020-12-08 20:43:08.0000"),

  new tagData("TIMESTAMP",
              "'2020-12-08 20:43:08.0000'",
              "INTEGER",
              "'0'",
              xdb.OleDbType.DBTimeStamp,
              "2020-12-08 20:43:08.0000"),

  new tagData("TIMESTAMP",
              "'2020-12-08 20:43:08.0000'",
              c_TypeName_BIGINT,
              "'0'",
              xdb.OleDbType.DBTimeStamp,
              "2020-12-08 20:43:08.0000"),

  new tagData("TIMESTAMP",
              "'2020-12-08 20:43:08.0000'",
              "FLOAT",
              "'0'",
              xdb.OleDbType.DBTimeStamp,
              "2020-12-08 20:43:08.0000"),

  new tagData("TIMESTAMP",
              "'2020-12-08 20:43:08.0000'",
              "DOUBLE PRECISION",
              "'0'",
              xdb.OleDbType.DBTimeStamp,
              "2020-12-08 20:43:08.0000"),

  new tagData("TIMESTAMP",
              "'2020-12-08 20:43:08.0000'",
              "NUMERIC",
              "'0'",
              xdb.OleDbType.DBTimeStamp,
              "2020-12-08 20:43:08.0000"),
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
       ="select CAST("+testData.LeftValue+" AS "+testData.LeftType+")+CAST("+testData.RightValue+" AS "+testData.RightType+") from DUAL";

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
          ("{0} + {1} == {2}. Expected {3}",
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
       ="select CAST(CAST("+testData.LeftValue+" AS "+testData.LeftType+")+CAST("+testData.RightValue+" AS "+testData.RightType+") AS VARCHAR(64)) from DUAL";

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
          ("{0} + {1} == \"{2}\". Expected \"{3}\"",
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

 //-----------------------------------------------------------------------
 private static readonly tagData[] sm_Data_001=
 {
  new tagData("VARCHAR(1)"        ,"'-'", "SMALLINT"          ,    1, xdb.OleDbType.VarWChar ,""),
  new tagData("VARCHAR(1)"        ,"'-'", "INTEGER"           ,    1, xdb.OleDbType.VarWChar ,""),
  new tagData("VARCHAR(1)"        ,"'-'", c_TypeName_BIGINT   ,    1, xdb.OleDbType.VarWChar ,""),
  new tagData("VARCHAR(1)"        ,"'-'", "FLOAT"             ,    1, xdb.OleDbType.VarWChar ,""),
  new tagData("VARCHAR(1)"        ,"'-'", "DOUBLE PRECISION"  ,    1, xdb.OleDbType.VarWChar ,""),
  new tagData("VARCHAR(1)"        ,"'-'", "NUMERIC(1)"        ,    1, xdb.OleDbType.VarWChar ,""),
  new tagData("VARCHAR(1)"        ,"'-'", "NUMERIC(1,0)"      ,    1, xdb.OleDbType.VarWChar ,""),
  new tagData("VARCHAR(1)"        ,"'-'", "NUMERIC(2,1)"      ,    1, xdb.OleDbType.VarWChar ,""),

  //------------------------------------------------------------
  new tagData("SMALLINT"          ,    1, "VARCHAR(1)"        ,"'-'", xdb.OleDbType.VarWChar ,""),
  new tagData("INTEGER"           ,    1, "VARCHAR(1)"        ,"'-'", xdb.OleDbType.VarWChar ,""),
  new tagData(c_TypeName_BIGINT   ,    1, "VARCHAR(1)"        ,"'-'", xdb.OleDbType.VarWChar ,""),
  new tagData("FLOAT"             ,    1, "VARCHAR(1)"        ,"'-'", xdb.OleDbType.VarWChar ,""),
  new tagData("DOUBLE PRECISION"  ,    1, "VARCHAR(1)"        ,"'-'", xdb.OleDbType.VarWChar ,""),
  new tagData("NUMERIC(1)"        ,    1, "VARCHAR(1)"        ,"'-'", xdb.OleDbType.VarWChar ,""),
  new tagData("NUMERIC(1,0)"      ,    1, "VARCHAR(1)"        ,"'-'", xdb.OleDbType.VarWChar ,""),
  new tagData("NUMERIC(2,1)"      ,    1, "VARCHAR(1)"        ,"'-'", xdb.OleDbType.VarWChar ,""),

  //------------------------------------------------------------
  new tagData("VARCHAR(1)",
              "'*'",
              "TIME",
              "'00:00:00.0000'",
              xdb.OleDbType.VarWChar,
              ""),

  new tagData("TIME",
              "'00:00:00.0000'",
              "VARCHAR(1)",
              "'*'",
              xdb.OleDbType.VarWChar,
              ""),

  //------------------------------------------------------------
  new tagData("VARCHAR(1)",
              "'*'",
              "TIMESTAMP",
              "'2020-12-08 20:43:08.0000'",
              xdb.OleDbType.VarWChar,
              ""),

  new tagData("TIMESTAMP",
              "'2020-12-08 20:43:08.0000'",
              "VARCHAR(1)",
              "'*'",
              xdb.OleDbType.VarWChar,
              ""),
 };//sm_Data_001

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_001()
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

     foreach(var testData in sm_Data_001)
     {
      string sql
       ="select CAST("+testData.LeftValue+" AS "+testData.LeftType+")||CAST("+testData.RightValue+" AS "+testData.RightType+") from DUAL";

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
          ("{0} || {1} == {2}. Expected {3}",
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
 }//Test_001
};//class TestSet_001__verify_result_type

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Operators.SET_001.Add

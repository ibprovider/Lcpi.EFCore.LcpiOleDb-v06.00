////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 01.02.2021.
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

using xdb=lcpi.data.oledb;
using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Operators.SET_001.Multiply{
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

 //-----------------------------------------------------------------------
 private const string c_TN_BIGINT
  =xEFCore.Basement.EF.Dbms.Firebird.V03_0_0.FB_V03_0_0__Consts.c_TypeOf_BIGINT_D1;

 //-----------------------------------------------------------------------
 private static readonly object sm_NO_EVAL
  =new object();

 private static readonly tagData[] sm_Data_000=
 {
  new tagData("SMALLINT"          ,                     2, "SMALLINT"          ,            1, xdb.OleDbType.Integer  ,             2, "2"),
  new tagData("SMALLINT"          ,                     2, "INTEGER"           ,            1, xdb.OleDbType.Integer  ,             2, "2"),
  new tagData("SMALLINT"          ,                     2, c_TN_BIGINT         ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),
  new tagData("SMALLINT"          ,                     2, "FLOAT"             ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),
  new tagData("SMALLINT"          ,                     2, "DOUBLE PRECISION"  ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),
  new tagData("SMALLINT"          ,                     2, "NUMERIC(1)"        ,            1, xdb.OleDbType.Integer  ,             2, "2"),
  new tagData("SMALLINT"          ,                     2, "NUMERIC(1,0)"      ,            1, xdb.OleDbType.Integer  ,             2, "2"),
  new tagData("SMALLINT"          ,                     2, "NUMERIC(2,0)"      ,            1, xdb.OleDbType.Integer  ,             2, "2"),
  new tagData("SMALLINT"          ,                     2, "NUMERIC(3,0)"      ,            1, xdb.OleDbType.Integer  ,             2, "2"),
  new tagData("SMALLINT"          ,                     2, "NUMERIC(4,0)"      ,            1, xdb.OleDbType.Integer  ,             2, "2"),
  new tagData("SMALLINT"          ,                     2, "NUMERIC(5,0)"      ,            1, xdb.OleDbType.Integer  ,             2, "2"),
  new tagData("SMALLINT"          ,                     2, "NUMERIC(6,0)"      ,            1, xdb.OleDbType.Integer  ,             2, "2"),
  new tagData("SMALLINT"          ,                     2, "NUMERIC(7,0)"      ,            1, xdb.OleDbType.Integer  ,             2, "2"),
  new tagData("SMALLINT"          ,                     2, "NUMERIC(8,0)"      ,            1, xdb.OleDbType.Integer  ,             2, "2"),
  new tagData("SMALLINT"          ,                     2, "NUMERIC(9,0)"      ,            1, xdb.OleDbType.Integer  ,             2, "2"),
  new tagData("SMALLINT"          ,                   100, "NUMERIC(9,0)"      ,    123456789, xdb.OleDbType.Integer  ,    sm_NO_EVAL, "12345678900.00000"),
  //new tagData("SMALLINT"          ,  2, "NUMERIC(10,0)"    ,  1, xdb.OleDbType.Integer , "2.000000000000000"),
  //new tagData("SMALLINT"          ,  2, "NUMERIC(11,0)"    ,  1, xdb.OleDbType.Integer , "2.000000000000000"),

  new tagData("SMALLINT"          ,                     2, "NUMERIC(2,1)"      ,            1, xdb.OleDbType.Numeric  ,            2m, "2.0"),
  new tagData("SMALLINT"          ,                     2, "NUMERIC(7,1)"      ,            1, xdb.OleDbType.Numeric  ,            2m, "2.0"),

  new tagData("SMALLINT"          ,                     2, "DECIMAL(1)"        ,            1, xdb.OleDbType.Integer  ,             2, "2"),
  new tagData("SMALLINT"          ,                     2, "DECIMAL(1,0)"      ,            1, xdb.OleDbType.Integer  ,             2, "2"),
  new tagData("SMALLINT"          ,                     2, "DECIMAL(2,0)"      ,            1, xdb.OleDbType.Integer  ,             2, "2"),
  new tagData("SMALLINT"          ,                     2, "DECIMAL(3,0)"      ,            1, xdb.OleDbType.Integer  ,             2, "2"),
  new tagData("SMALLINT"          ,                     2, "DECIMAL(4,0)"      ,            1, xdb.OleDbType.Integer  ,             2, "2"),
  new tagData("SMALLINT"          ,                     2, "DECIMAL(5,0)"      ,            1, xdb.OleDbType.Integer  ,             2, "2"),
  new tagData("SMALLINT"          ,                     2, "DECIMAL(6,0)"      ,            1, xdb.OleDbType.Integer  ,             2, "2"),
  new tagData("SMALLINT"          ,                     2, "DECIMAL(7,0)"      ,            1, xdb.OleDbType.Integer  ,             2, "2"),
  new tagData("SMALLINT"          ,                     2, "DECIMAL(8,0)"      ,            1, xdb.OleDbType.Integer  ,             2, "2"),
  new tagData("SMALLINT"          ,                     2, "DECIMAL(9,0)"      ,            1, xdb.OleDbType.Integer  ,             2, "2"),

  new tagData("INTEGER"           ,                     2, "SMALLINT"          ,            1, xdb.OleDbType.Integer  ,             2, "2"),
  new tagData("INTEGER"           ,                     2, "INTEGER"           ,            1, xdb.OleDbType.Integer  ,             2, "2"),
  new tagData("INTEGER"           , System.Int32.MaxValue, "INTEGER"           ,            1, xdb.OleDbType.Integer  ,    2147483647, "2147483647"),
  new tagData("INTEGER"           ,             123456789, "INTEGER"           ,          100, xdb.OleDbType.Integer  ,    sm_NO_EVAL, "12345678900.00000"),
  new tagData("INTEGER"           ,             123456789, "INTEGER"           ,    987654321, xdb.OleDbType.Integer  ,    sm_NO_EVAL, "1.219326311126353e+17"),
  new tagData("INTEGER"           ,                      2, c_TN_BIGINT        ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),
  new tagData("INTEGER"           ,                      2, "FLOAT"            ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),
  new tagData("INTEGER"           ,                      2, "DOUBLE PRECISION" ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),

  new tagData("INTEGER"           ,                      2, "NUMERIC(1)"       ,            1, xdb.OleDbType.Integer  ,             2, "2"),
  new tagData("INTEGER"           ,                      2, "NUMERIC(1,0)"     ,            1, xdb.OleDbType.Integer  ,             2, "2"),
  new tagData("INTEGER"           ,                      2, "NUMERIC(2,1)"     ,            1, xdb.OleDbType.Numeric  ,            2m, "2.0"),

  new tagData("INTEGER"           ,                      2, "DECIMAL(1)"       ,            1, xdb.OleDbType.Integer  ,             2, "2"),
  new tagData("INTEGER"           ,                      2, "DECIMAL(1,0)"     ,            1, xdb.OleDbType.Integer  ,             2, "2"),
  new tagData("INTEGER"           ,                      2, "DECIMAL(2,1)"     ,            1, xdb.OleDbType.Numeric  ,            2m, "2.0"),

  new tagData(c_TN_BIGINT         ,                      2, "SMALLINT"         ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),
  new tagData(c_TN_BIGINT         ,                      2, "INTEGER"          ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),
  new tagData(c_TN_BIGINT         ,                      2, c_TN_BIGINT        ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),
  new tagData(c_TN_BIGINT         ,                      2, "FLOAT"            ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),

  new tagData(c_TN_BIGINT         ,                      2, "DOUBLE PRECISION" ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),
  new tagData(c_TN_BIGINT         ,                      2, "NUMERIC(1)"       ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),
  new tagData(c_TN_BIGINT         ,                      2, "NUMERIC(1,0)"     ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),
  new tagData(c_TN_BIGINT         ,                      2, "NUMERIC(2,1)"     ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),

  new tagData(c_TN_BIGINT         ,                      2, "DECIMAL(1)"       ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),
  new tagData(c_TN_BIGINT         ,                      2, "DECIMAL(1,0)"     ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),
  new tagData(c_TN_BIGINT         ,                      2, "DECIMAL(2,1)"     ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),

  new tagData("FLOAT"             ,                      2, "SMALLINT"         ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),
  new tagData("FLOAT"             ,                      2, "INTEGER"          ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),
  new tagData("FLOAT"             ,                      2, c_TN_BIGINT        ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),
  new tagData("FLOAT"             ,                      2, "FLOAT"            ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),
  new tagData("FLOAT"             ,                      2, "DOUBLE PRECISION" ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),
  new tagData("FLOAT"             ,                      2, "NUMERIC(1)"       ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),
  new tagData("FLOAT"             ,                      2, "NUMERIC(1,0)"     ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),
  new tagData("FLOAT"             ,                      2, "NUMERIC(2,1)"     ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),

  new tagData("FLOAT"             ,                      2, "DECIMAL(1)"       ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),
  new tagData("FLOAT"             ,                      2, "DECIMAL(1,0)"     ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),
  new tagData("FLOAT"             ,                      2, "DECIMAL(2,1)"     ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),

  new tagData("DOUBLE PRECISION"  ,                      2, "SMALLINT"         ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),
  new tagData("DOUBLE PRECISION"  ,                      2, "INTEGER"          ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),
  new tagData("DOUBLE PRECISION"  ,                      2, c_TN_BIGINT        ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),
  new tagData("DOUBLE PRECISION"  ,                      2, "FLOAT"            ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),
  new tagData("DOUBLE PRECISION"  ,                      2, "DOUBLE PRECISION" ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),
  new tagData("DOUBLE PRECISION"  ,                      2, "NUMERIC(1)"       ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),
  new tagData("DOUBLE PRECISION"  ,                      2, "NUMERIC(1,0)"     ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),
  new tagData("DOUBLE PRECISION"  ,                      2, "NUMERIC(2,1)"     ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),

  new tagData("DOUBLE PRECISION"  ,                      2, "DECIMAL(1)"       ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),
  new tagData("DOUBLE PRECISION"  ,                      2, "DECIMAL(1,0)"     ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),
  new tagData("DOUBLE PRECISION"  ,                      2, "DECIMAL(2,1)"     ,            1, xdb.OleDbType.Double   ,            2D, "2.000000000000000"),

  //------------------------------------------------------------
  new tagData("NUMERIC(2,0)"      ,                      2, "NUMERIC(2,0)"     ,            1, xdb.OleDbType.Integer  ,             2, "2"),

  new tagData("NUMERIC(2,0)"      ,                      2, "DECIMAL(2,0)"     ,            1, xdb.OleDbType.Integer  ,             2, "2"),

  new tagData("NUMERIC(2,1)"      ,                      2, "NUMERIC(2,1)"     ,            1, xdb.OleDbType.Numeric  ,            2m, "2.00"),

  new tagData("NUMERIC(2,1)"      ,                      2, "DECIMAL(2,1)"     ,            1, xdb.OleDbType.Numeric  ,            2m, "2.00"),

  //------------------------------------------------------------
  new tagData("DECIMAL(2,0)"      ,                      2, "DECIMAL(2,0)"     ,            1, xdb.OleDbType.Integer  ,             2, "2"),

  new tagData("DECIMAL(2,0)"      ,                      2, "NUMERIC(2,0)"     ,            1, xdb.OleDbType.Integer  ,             2, "2"),

  new tagData("DECIMAL(2,1)"      ,                      2, "DECIMAL(2,1)"     ,            1, xdb.OleDbType.Numeric  ,            2m, "2.00"),

  new tagData("DECIMAL(2,1)"      ,                      2, "NUMERIC(2,1)"     ,            1, xdb.OleDbType.Numeric  ,            2m, "2.00"),
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
       ="select CAST("+testData.LeftValue+" AS "+testData.LeftType+")*CAST("+testData.RightValue+" AS "+testData.RightType+") from DUAL";

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
          ("{0} * {1} == {2}. Expected {3}",
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
      if(Object.ReferenceEquals(testData.ResultValue,sm_NO_EVAL))
       continue;

      string sql
       ="select CAST("+testData.LeftValue+" AS "+testData.LeftType+")*CAST("+testData.RightValue+" AS "+testData.RightType+") from DUAL";

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
          ("{0} * {1} == {2}. Expected \"{3}\"",
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
          ("{0} * {1} -> {2}. Expected \"{3}\"",
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
       ="select CAST(CAST("+testData.LeftValue+" AS "+testData.LeftType+")*CAST("+testData.RightValue+" AS "+testData.RightType+") AS VARCHAR(64)) from DUAL";

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
          ("{0} * {1} == \"{2}\". Expected \"{3}\"",
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
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Operators.SET_001.Multiply

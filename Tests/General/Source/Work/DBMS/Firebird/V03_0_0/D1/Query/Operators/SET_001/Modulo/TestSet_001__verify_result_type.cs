////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 10.12.2020.
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

using xEFCore_FB3=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Operators.SET_001.Modulo{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_001__verify_result_type

public static class TestSet_001__verify_result_type
{
 private const string c_FB_BIGINT
  =xEFCore_FB3.FB_V03_0_0__Consts.c_TypeOf_BIGINT_D1;

 private struct tagData
 {
  public string         LeftType;
  public object         LeftValue;

  public string         RightType;
  public object         RightValue;

  public xdb.OleDbType  ResultOleDbType;

  public Nullable<int>  ResultPrecision;
  public Nullable<int>  ResultScale;

  public tagData(string        left,
                 object        leftValue,
                 string        right,
                 object        rightValue,
                 xdb.OleDbType resultOleDbType,
                 Nullable<int> resultPrecision,
                 Nullable<int> resultScale)
  {
   this.LeftType        =left;
   this.LeftValue       =leftValue;

   this.RightType       =right;
   this.RightValue      =rightValue;

   this.ResultOleDbType =resultOleDbType;

   this.ResultPrecision =resultPrecision;
   this.ResultScale     =resultScale;
  }//tagData
 };//struct tagData

 private static readonly tagData[] sm_Data=
 {
  new tagData("SMALLINT"          ,  2, "SMALLINT"         ,  1, xdb.OleDbType.SmallInt  ,    5,  null),
  new tagData("SMALLINT"          ,  2, "INTEGER"          ,  1, xdb.OleDbType.SmallInt  ,    5,  null),
  new tagData("SMALLINT"          ,  2, c_FB_BIGINT        ,  1, xdb.OleDbType.SmallInt  ,    5,  null),
  new tagData("SMALLINT"          ,  2, "FLOAT"            ,  1, xdb.OleDbType.SmallInt  ,    5,  null),
  new tagData("SMALLINT"          ,  2, "DOUBLE PRECISION" ,  1, xdb.OleDbType.SmallInt  ,    5,  null),
  new tagData("SMALLINT"          ,  2, "NUMERIC(1)"       ,  1, xdb.OleDbType.SmallInt  ,    5,  null),
  new tagData("SMALLINT"          ,  2, "NUMERIC(1,0)"     ,  1, xdb.OleDbType.SmallInt  ,    5,  null),
  new tagData("SMALLINT"          ,  2, "NUMERIC(2,1)"     ,  1, xdb.OleDbType.SmallInt  ,    5,  null),
                                                                 
  new tagData("INTEGER"           ,  2, "SMALLINT"         ,  1, xdb.OleDbType.Integer   ,   10,  null),
  new tagData("INTEGER"           ,  2, "INTEGER"          ,  1, xdb.OleDbType.Integer   ,   10,  null),
  new tagData("INTEGER"           ,  2, c_FB_BIGINT        ,  1, xdb.OleDbType.Integer   ,   10,  null),
  new tagData("INTEGER"           ,  2, "FLOAT"            ,  1, xdb.OleDbType.Integer   ,   10,  null),
  new tagData("INTEGER"           ,  2, "DOUBLE PRECISION" ,  1, xdb.OleDbType.Integer   ,   10,  null),
  new tagData("INTEGER"           ,  2, "NUMERIC(1)"       ,  1, xdb.OleDbType.Integer   ,   10,  null),
  new tagData("INTEGER"           ,  2, "NUMERIC(1,0)"     ,  1, xdb.OleDbType.Integer   ,   10,  null),
  new tagData("INTEGER"           ,  2, "NUMERIC(2,1)"     ,  1, xdb.OleDbType.Integer   ,   10,  null),
                                                                 
  new tagData(c_FB_BIGINT         ,  2, "SMALLINT"         ,  1, xdb.OleDbType.BigInt    ,   19,  null),
  new tagData(c_FB_BIGINT         ,  2, "INTEGER"          ,  1, xdb.OleDbType.BigInt    ,   19,  null),
  new tagData(c_FB_BIGINT         ,  2, c_FB_BIGINT        ,  1, xdb.OleDbType.BigInt    ,   19,  null),
  new tagData(c_FB_BIGINT         ,  2, "FLOAT"            ,  1, xdb.OleDbType.BigInt    ,   19,  null),
  new tagData(c_FB_BIGINT         ,  2, "DOUBLE PRECISION" ,  1, xdb.OleDbType.BigInt    ,   19,  null),
  new tagData(c_FB_BIGINT         ,  2, "NUMERIC(1)"       ,  1, xdb.OleDbType.BigInt    ,   19,  null),
  new tagData(c_FB_BIGINT         ,  2, "NUMERIC(1,0)"     ,  1, xdb.OleDbType.BigInt    ,   19,  null),
  new tagData(c_FB_BIGINT         ,  2, "NUMERIC(2,1)"     ,  1, xdb.OleDbType.BigInt    ,   19,  null),

  new tagData("NUMERIC(1)"        ,  2, "SMALLINT"         ,  1, xdb.OleDbType.Numeric   ,    4,  0),
  new tagData("NUMERIC(1)"        ,  2, "INTEGER"          ,  1, xdb.OleDbType.Numeric   ,    4,  0),
  new tagData("NUMERIC(1)"        ,  2, c_FB_BIGINT        ,  1, xdb.OleDbType.Numeric   ,    4,  0),
  new tagData("NUMERIC(1)"        ,  2, "FLOAT"            ,  1, xdb.OleDbType.Numeric   ,    4,  0),
  new tagData("NUMERIC(1)"        ,  2, "DOUBLE PRECISION" ,  1, xdb.OleDbType.Numeric   ,    4,  0),
  new tagData("NUMERIC(1)"        ,  2, "NUMERIC(1)"       ,  1, xdb.OleDbType.Numeric   ,    4,  0),
  new tagData("NUMERIC(1)"        ,  2, "NUMERIC(1,0)"     ,  1, xdb.OleDbType.Numeric   ,    4,  0),
  new tagData("NUMERIC(1)"        ,  2, "NUMERIC(2,1)"     ,  1, xdb.OleDbType.Numeric   ,    4,  0),

  new tagData("NUMERIC(2,0)"      ,  2, "SMALLINT"         ,  1, xdb.OleDbType.Numeric   ,    4,  0),
  new tagData("NUMERIC(2,0)"      ,  2, "INTEGER"          ,  1, xdb.OleDbType.Numeric   ,    4,  0),
  new tagData("NUMERIC(2,0)"      ,  2, c_FB_BIGINT        ,  1, xdb.OleDbType.Numeric   ,    4,  0),
  new tagData("NUMERIC(2,0)"      ,  2, "FLOAT"            ,  1, xdb.OleDbType.Numeric   ,    4,  0),
  new tagData("NUMERIC(2,0)"      ,  2, "DOUBLE PRECISION" ,  1, xdb.OleDbType.Numeric   ,    4,  0),
  new tagData("NUMERIC(2,0)"      ,  2, "NUMERIC(1)"       ,  1, xdb.OleDbType.Numeric   ,    4,  0),
  new tagData("NUMERIC(2,0)"      ,  2, "NUMERIC(1,0)"     ,  1, xdb.OleDbType.Numeric   ,    4,  0),
  new tagData("NUMERIC(2,0)"      ,  2, "NUMERIC(2,1)"     ,  1, xdb.OleDbType.Numeric   ,    4,  0),

  new tagData("NUMERIC(2,1)"      ,  2, "SMALLINT"         ,  1, xdb.OleDbType.Numeric   ,    4,  0),
  new tagData("NUMERIC(2,1)"      ,  2, "INTEGER"          ,  1, xdb.OleDbType.Numeric   ,    4,  0),
  new tagData("NUMERIC(2,1)"      ,  2, c_FB_BIGINT        ,  1, xdb.OleDbType.Numeric   ,    4,  0),
  new tagData("NUMERIC(2,1)"      ,  2, "FLOAT"            ,  1, xdb.OleDbType.Numeric   ,    4,  0),
  new tagData("NUMERIC(2,1)"      ,  2, "DOUBLE PRECISION" ,  1, xdb.OleDbType.Numeric   ,    4,  0),
  new tagData("NUMERIC(2,1)"      ,  2, "NUMERIC(1)"       ,  1, xdb.OleDbType.Numeric   ,    4,  0),
  new tagData("NUMERIC(2,1)"      ,  2, "NUMERIC(1,0)"     ,  1, xdb.OleDbType.Numeric   ,    4,  0),
  new tagData("NUMERIC(2,1)"      ,  2, "NUMERIC(2,1)"     ,  1, xdb.OleDbType.Numeric   ,    4,  0),
 };//sm_Data

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

     foreach(var testData in sm_Data)
     {
      string sql
       ="select MOD(CAST("+testData.LeftValue+" AS "+testData.LeftType+"),CAST("+testData.RightValue+" AS "+testData.RightType+")) from DUAL";

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
          ("{0} % {1} == {2}. Expected {3}",
           testData.LeftType,
           testData.RightType,
           actualOleDbType,
           testData.ResultOleDbType);
       
        errList.Add(err);
       }//if

       var actualNumericPrecision
        =schema.Rows[0][xdb.OleDbDataReaderSchemaColumnNames.NumericPrecision].ToField<short>();
       
       if(testData.ResultPrecision != actualNumericPrecision)
       {
        string err
         =string.Format
          ("{0} % {1} has precision {2}. Expected {3}",
           testData.LeftType,
           testData.RightType,
           (object)actualNumericPrecision??(object)"null",
           (object)testData.ResultPrecision.ToString()??(object)"null");
       
        errList.Add(err);
       }//if

       var actualNumericScale
        =(Nullable<short>)schema.Rows[0][xdb.OleDbDataReaderSchemaColumnNames.NumericScale].ToField<short>();
       
       if(testData.ResultScale != actualNumericScale)
       {
        string err
         =string.Format
          ("{0} % {1} has scale {2}. Expected {3}",
           testData.LeftType,
           testData.RightType,
           (object)actualNumericScale??(object)"null",
           (object)testData.ResultScale??(object)"null");
       
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

 //Helper ----------------------------------------------------------------
 private static Nullable<T> ToField<T>(this object value) where T:struct
 {
  if(Object.ReferenceEquals(value,null))
   return null;

  if(DBNull.Value.Equals(value))
   return null;

  return (T)value;
 }//ToField
};//class TestSet_001__verify_result_type

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Operators.SET_001.Modulo

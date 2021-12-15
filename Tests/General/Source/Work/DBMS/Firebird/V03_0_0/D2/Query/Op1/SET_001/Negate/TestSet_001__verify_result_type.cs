////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 11.10.2021.
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D2.Query.Op1.SET_001.Negate{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_001__verify_result_type

public static class TestSet_001__verify_result_type
{
 private struct tagData
 {
  public string         TableName;
  public string         ColumnName;
  public xdb.OleDbType  ResultOleDbType;
  public int?           ResultPrecision;
  public int?           ResultScale;

  public tagData(string        tableName,
                 string        columnName,
                 xdb.OleDbType result,
                 int?          precision,
                 int?          scale)
  {
   this.TableName       =tableName;
   this.ColumnName      =columnName;
   this.ResultOleDbType =result;
   this.ResultPrecision =precision;
   this.ResultScale     =scale;
  }
 };//struct tagData

 private static readonly tagData[] sm_Data=
 {
  new tagData("TEST_MODIFY_ROW"      ,"COL_SMALLINT",  xdb.OleDbType.SmallInt,   5,   null),
  new tagData("TEST_MODIFY_ROW"      ,"COL_INTEGER" ,  xdb.OleDbType.Integer,   10,   null),
  new tagData("TEST_MODIFY_ROW"      ,"COL_BIGINT"  ,  xdb.OleDbType.BigInt,    19,   null),
  new tagData("TEST_MODIFY_ROW"      ,"COL_FLOAT"   ,  xdb.OleDbType.Single,     7,   null),
  new tagData("TEST_MODIFY_ROW"      ,"COL_DOUBLE"  ,  xdb.OleDbType.Double,    15,   null),

  new tagData("NUM"                  ,"N_1_0"       ,  xdb.OleDbType.Numeric,    4,   0),
  new tagData("NUM"                  ,"N_1_1"       ,  xdb.OleDbType.Numeric,    4,   1),

  new tagData("NUM"                  ,"N_8_0"       ,  xdb.OleDbType.Numeric,    9,   0),
  new tagData("NUM"                  ,"N_8_1"       ,  xdb.OleDbType.Numeric,    9,   1),

  new tagData("NUM"                  ,"N_9_0"       ,  xdb.OleDbType.Numeric,    9,   0),
  new tagData("NUM"                  ,"N_9_1"       ,  xdb.OleDbType.Numeric,    9,   1),

  new tagData("NUM"                  ,"N_17_7"     ,  xdb.OleDbType.Numeric,    18,   7),
  new tagData("NUM"                  ,"N_17_8"     ,  xdb.OleDbType.Numeric,    18,   8),

  new tagData("NUM"                  ,"N_18_17"     ,  xdb.OleDbType.Numeric,   18,   17),
  new tagData("NUM"                  ,"N_18_18"     ,  xdb.OleDbType.Numeric,   18,   18),

  new tagData("TEST_MODIFY_ROW",
              "CAST(COL_SMALLINT AS DECIMAL)",
              xdb.OleDbType.Numeric,
              9,
              0),

  new tagData("TEST_MODIFY_ROW",
              "CAST(COL_SMALLINT AS DECIMAL(6,1))",
              xdb.OleDbType.Numeric,
              9,
              1),

  new tagData("TEST_MODIFY_ROW",
              "CHARACTER_LENGTH(COL_VARCHAR_10)",
              xdb.OleDbType.Integer,
              10,
              null),
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
       ="select -("+testData.ColumnName+") from "+testData.TableName;

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

       var curErrCount=errList.Count;

       //-------------------------------------------------------
       var actualOleDbType
        =(xdb.OleDbType)schema.Rows[0][xdb.OleDbDataReaderSchemaColumnNames.ProviderType];

       if(testData.ResultOleDbType != actualOleDbType)
       {
        string err
         =string.Format
          ("-({0}.{1}) -> type: {2}. Expected type: {3}.",
           testData.TableName,
           testData.ColumnName,
           actualOleDbType,
           testData.ResultOleDbType);

        errList.Add(err);
       }//if

       //-------------------------------------------------------
       var actualPrecision
        =Helper_GetFieldValue<short>(schema.Rows[0][xdb.OleDbDataReaderSchemaColumnNames.NumericPrecision]);

       if(testData.ResultPrecision != actualPrecision)
       {
        string err
         =string.Format
          ("-({0}.{1}) -> precision: {2}. Expected precision: {3}.",
           testData.TableName,
           testData.ColumnName,
           actualPrecision,
           testData.ResultPrecision);

        errList.Add(err);
       }//if

       //-------------------------------------------------------
       var actualScale
        =Helper_GetFieldValue<short>(schema.Rows[0][xdb.OleDbDataReaderSchemaColumnNames.NumericScale]);

       if(testData.ResultScale != actualScale)
       {
        string err
         =string.Format
          ("-({0}.{1}) -> Scale: {2}. Expected Scale: {3}.",
           testData.TableName,
           testData.ColumnName,
           actualScale,
           testData.ResultScale);

        errList.Add(err);
       }//if

       //-------------------------------------------------------
       if(errList.Count==curErrCount)
       {
        Console.WriteLine
         ("-({0}.{1}) -> OK. type: {2}, precision: {3}, scale: {4}",
          testData.TableName,
          testData.ColumnName,
          testData.ResultOleDbType,
          testData.ResultPrecision,
          testData.ResultScale);
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
 static T? Helper_GetFieldValue<T>(object v) where T:struct
 {
  if(DBNull.Value==v)
   return null;

  return (T)v;
 }//Helper_GetFieldValue
};//class TestSet_001__verify_result_type

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D2.Query.Op1.SET_001.Negate

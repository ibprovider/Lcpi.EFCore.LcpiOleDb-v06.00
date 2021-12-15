////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 14.10.2021.
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Operators.SET_001.Coalesce.Complete{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_001__verify_result_type

public static class TestSet_001__verify_result_type
{
 private struct tagData
 {
  public string         TableName;
  public string         ColumnName1;
  public string         ColumnName2;
  public xdb.OleDbType  ResultOleDbType;
  public int            ResultSize;
  public int?           ResultPrecision;
  public int?           ResultScale;

  public tagData(string        tableName,
                 string        columnName1,
                 string        columnName2,
                 xdb.OleDbType result,
                 int           size,
                 int?          precision,
                 int?          scale)
  {
   this.TableName       =tableName;
   this.ColumnName1     =columnName1;
   this.ColumnName2     =columnName2;
   this.ResultOleDbType =result;
   this.ResultSize      =size;
   this.ResultPrecision =precision;
   this.ResultScale     =scale;
  }
 };//struct tagData

 private static readonly tagData[] sm_Data=
 {
  //------------------------------------------------------- SMALLINT
  new tagData("TEST_MODIFY_ROW2",
              "COL_SMALLINT",
              "COL2_SMALLINT",
              xdb.OleDbType.SmallInt,
              2,
              5,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_SMALLINT",
              "COL2_INTEGER",
              xdb.OleDbType.Integer,
              4,
              10,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_SMALLINT",
              "COL2_BIGINT",
              xdb.OleDbType.BigInt,
              8,
              19,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_SMALLINT",
              "COL2_FLOAT",
              xdb.OleDbType.Single,
              4,
              7,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_SMALLINT",
              "COL2_DOUBLE",
              xdb.OleDbType.Double,
              8,
              15,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_SMALLINT",
              "COL2_NUM_6_1",
              xdb.OleDbType.Numeric,
              19,
              9,
              1),

  new tagData("TEST_MODIFY_ROW2",
              "COL_SMALLINT",
              "''",
              xdb.OleDbType.VarWChar,
              6,
              null,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_SMALLINT",
              "COL_CHAR_1",
              xdb.OleDbType.VarWChar,
              6,
              null,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_SMALLINT",
              "COL_CHAR_32",
              xdb.OleDbType.VarWChar,
              32,
              null,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_SMALLINT",
              "COL2_TEXT_BLOB",
              xdb.OleDbType.LongVarWChar,
              int.MaxValue,
              null,
              null),

  //------------------------------------------------------- INTEGER
  new tagData("TEST_MODIFY_ROW2",
              "COL_INTEGER",
              "COL2_SMALLINT",
              xdb.OleDbType.Integer,
              4,
              10,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_INTEGER",
              "COL2_INTEGER",
              xdb.OleDbType.Integer,
              4,
              10,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_INTEGER",
              "COL2_BIGINT",
              xdb.OleDbType.BigInt,
              8,
              19,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_INTEGER",
              "COL2_FLOAT",
              xdb.OleDbType.Single,
              4,
              7,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_INTEGER",
              "COL2_DOUBLE",
              xdb.OleDbType.Double,
              8,
              15,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_INTEGER",
              "COL2_NUM_6_1",
              xdb.OleDbType.Numeric,
              19,
              9,
              1),

  new tagData("TEST_MODIFY_ROW2",
              "COL_INTEGER",
              "''",
              xdb.OleDbType.VarWChar,
              11,
              null,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_INTEGER",
              "COL_CHAR_1",
              xdb.OleDbType.VarWChar,
              11,
              null,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_INTEGER",
              "COL_CHAR_32",
              xdb.OleDbType.VarWChar,
              32,
              null,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_INTEGER",
              "COL2_TEXT_BLOB",
              xdb.OleDbType.LongVarWChar,
              int.MaxValue,
              null,
              null),

  //------------------------------------------------------- BIGINT
  new tagData("TEST_MODIFY_ROW2",
              "COL_BIGINT",
              "COL2_SMALLINT",
              xdb.OleDbType.BigInt,
              8,
              19,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_BIGINT",
              "COL2_INTEGER",
              xdb.OleDbType.BigInt,
              8,
              19,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_BIGINT",
              "COL2_BIGINT",
              xdb.OleDbType.BigInt,
              8,
              19,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_BIGINT",
              "COL2_FLOAT",
              xdb.OleDbType.Single,
              4,
              7,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_BIGINT",
              "COL2_DOUBLE",
              xdb.OleDbType.Double,
              8,
              15,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_BIGINT",
              "COL2_NUM_6_1",
              xdb.OleDbType.Numeric,
              19,
              18,
              1),

  new tagData("TEST_MODIFY_ROW2",
              "COL_BIGINT",
              "''",
              xdb.OleDbType.VarWChar,
              20,
              null,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_BIGINT",
              "COL_CHAR_1",
              xdb.OleDbType.VarWChar,
              20,
              null,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_BIGINT",
              "COL_CHAR_32",
              xdb.OleDbType.VarWChar,
              32,
              null,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_BIGINT",
              "COL2_TEXT_BLOB",
              xdb.OleDbType.LongVarWChar,
              int.MaxValue,
              null,
              null),

  //------------------------------------------------------- FLOAT
  new tagData("TEST_MODIFY_ROW2",
              "COL_FLOAT",
              "COL2_SMALLINT",
              xdb.OleDbType.Single,
              4,
              7,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_FLOAT",
              "COL2_INTEGER",
              xdb.OleDbType.Single,
              4,
              7,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_FLOAT",
              "COL2_BIGINT",
              xdb.OleDbType.Single,
              4,
              7,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_FLOAT",
              "COL2_FLOAT",
              xdb.OleDbType.Single,
              4,
              7,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_FLOAT",
              "COL2_DOUBLE",
              xdb.OleDbType.Double,
              8,
              15,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_FLOAT",
              "COL2_NUM_6_1",
              xdb.OleDbType.Single,
              4,
              7,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_FLOAT",
              "''",
              xdb.OleDbType.VarWChar,
              15,
              null,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_FLOAT",
              "COL_CHAR_1",
              xdb.OleDbType.VarWChar,
              15,
              null,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_FLOAT",
              "COL_CHAR_32",
              xdb.OleDbType.VarWChar,
              32,
              null,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_FLOAT",
              "COL2_TEXT_BLOB",
              xdb.OleDbType.LongVarWChar,
              int.MaxValue,
              null,
              null),

  //------------------------------------------------------- DOUBLE
  new tagData("TEST_MODIFY_ROW2",
              "COL_DOUBLE",
              "COL2_SMALLINT",
              xdb.OleDbType.Double,
              8,
              15,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_DOUBLE",
              "COL2_INTEGER",
              xdb.OleDbType.Double,
              8,
              15,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_DOUBLE",
              "COL2_BIGINT",
              xdb.OleDbType.Double,
              8,
              15,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_DOUBLE",
              "COL2_FLOAT",
              xdb.OleDbType.Double,
              8,
              15,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_DOUBLE",
              "COL2_DOUBLE",
              xdb.OleDbType.Double,
              8,
              15,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_DOUBLE",
              "COL2_NUM_6_1",
              xdb.OleDbType.Double,
              8,
              15,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_DOUBLE",
              "''",
              xdb.OleDbType.VarWChar,
              24,
              null,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_DOUBLE",
              "COL_CHAR_1",
              xdb.OleDbType.VarWChar,
              24,
              null,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_DOUBLE",
              "COL_CHAR_32",
              xdb.OleDbType.VarWChar,
              32,
              null,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_DOUBLE",
              "COL2_TEXT_BLOB",
              xdb.OleDbType.LongVarWChar,
              int.MaxValue,
              null,
              null),

  //------------------------------------------------------- NUMERIC(6,1)
  new tagData("TEST_MODIFY_ROW2",
              "COL_NUM_6_1",
              "COL2_SMALLINT",
              xdb.OleDbType.Numeric,
              19,
              9,
              1),

  new tagData("TEST_MODIFY_ROW2",
              "COL_NUM_6_1",
              "COL2_INTEGER",
              xdb.OleDbType.Numeric,
              19,
              9,
              1),

  new tagData("TEST_MODIFY_ROW2",
              "COL_NUM_6_1",
              "COL2_BIGINT",
              xdb.OleDbType.Numeric,
              19,
              18,
              1),

  new tagData("TEST_MODIFY_ROW2",
              "COL_NUM_6_1",
              "COL2_FLOAT",
              xdb.OleDbType.Single,
              4,
              7,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_NUM_6_1",
              "COL2_DOUBLE",
              xdb.OleDbType.Double,
              8,
              15,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_NUM_6_1",
              "COL2_NUM_6_1",
              xdb.OleDbType.Numeric,
              19,
              9,
              1),

  new tagData("TEST_MODIFY_ROW2",
              "COL_NUM_6_1",
              "''",
              xdb.OleDbType.VarWChar,
              12,
              null,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_NUM_6_1",
              "COL_CHAR_1",
              xdb.OleDbType.VarWChar,
              12,
              null,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_NUM_6_1",
              "COL_CHAR_32",
              xdb.OleDbType.VarWChar,
              32,
              null,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_NUM_6_1",
              "COL2_TEXT_BLOB",
              xdb.OleDbType.LongVarWChar,
              int.MaxValue,
              null,
              null),

  //------------------------------------------------------- TIME
  new tagData("TEST_MODIFY_ROW2",
              "COL_TYPE_TIME",
              "COL_TYPE_TIME",
              xdb.OleDbType.DBTime2,
              12,
              null,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_TYPE_TIME",
              "''",
              xdb.OleDbType.VarWChar,
              13,
              null,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_TYPE_TIME",
              "COL_CHAR_1",
              xdb.OleDbType.VarWChar,
              13,
              null,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_TYPE_TIME",
              "COL_CHAR_32",
              xdb.OleDbType.VarWChar,
              32,
              null,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_TYPE_TIME",
              "COL_TEXT_BLOB",
              xdb.OleDbType.LongVarWChar,
              int.MaxValue,
              null,
              null),

  //------------------------------------------------------- DATE
  new tagData("TEST_MODIFY_ROW2",
              "COL_TYPE_DATE",
              "COL_TYPE_DATE",
              xdb.OleDbType.DBDate,
              6,
              null,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_TYPE_DATE",
              "''",
              xdb.OleDbType.VarWChar,
              10,
              null,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_TYPE_DATE",
              "COL_CHAR_1",
              xdb.OleDbType.VarWChar,
              10,
              null,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_TYPE_DATE",
              "COL_CHAR_32",
              xdb.OleDbType.VarWChar,
              32,
              null,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_TYPE_DATE",
              "COL_TEXT_BLOB",
              xdb.OleDbType.LongVarWChar,
              int.MaxValue,
              null,
              null),

  //------------------------------------------------------- TIMESTAMP
  new tagData("TEST_MODIFY_ROW2",
              "COL_TIMESTAMP",
              "COL_TIMESTAMP",
              xdb.OleDbType.DBTimeStamp,
              16,
              null,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_TIMESTAMP",
              "''",
              xdb.OleDbType.VarWChar,
              25,
              null,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_TIMESTAMP",
              "COL_CHAR_1",
              xdb.OleDbType.VarWChar,
              25,
              null,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_TIMESTAMP",
              "COL_CHAR_32",
              xdb.OleDbType.VarWChar,
              32,
              null,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_TIMESTAMP",
              "COL_TEXT_BLOB",
              xdb.OleDbType.LongVarWChar,
              int.MaxValue,
              null,
              null),

  //------------------------------------------------------- BOOLEAN
  new tagData("TEST_MODIFY_ROW2",
              "COL_BOOLEAN",
              "COL_BOOLEAN",
              xdb.OleDbType.Boolean,
              2,
              null,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_BOOLEAN",
              "''",
              xdb.OleDbType.VarWChar,
              5,
              null,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_BOOLEAN",
              "COL_CHAR_1",
              xdb.OleDbType.VarWChar,
              5,
              null,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_BOOLEAN",
              "COL_CHAR_32",
              xdb.OleDbType.VarWChar,
              32,
              null,
              null),

  new tagData("TEST_MODIFY_ROW2",
              "COL_BOOLEAN",
              "COL_TEXT_BLOB",
              xdb.OleDbType.LongVarWChar,
              int.MaxValue,
              null,
              null),
 };//sm_Data

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_000()
 {
  var errList=new List<string>();

  using(var cn=LocalCnHelper.CreateCn("dbtime_rules=1"))
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
       ="select COALESCE("+testData.ColumnName1+","+testData.ColumnName2+") from "+testData.TableName;

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
          ("COALESCE({0}, {1}) -> type: {2}. Expected type: {3}.",
           testData.ColumnName1,
           testData.ColumnName2,
           Helper_Print(actualOleDbType),
           Helper_Print(testData.ResultOleDbType));

        errList.Add(err);
       }//if

       //-------------------------------------------------------
       var actualSize
        =Helper_GetFieldValue<int>(schema.Rows[0][xdb.OleDbDataReaderSchemaColumnNames.ColumnSize]);

       if(testData.ResultSize != actualSize)
       {
        string err
         =string.Format
          ("COALESCE({0}, {1}) -> size: {2}. Expected size: {3}.",
           testData.ColumnName1,
           testData.ColumnName2,
           Helper_Print(actualSize),
           Helper_Print(testData.ResultSize));

        errList.Add(err);
       }//if

       //-------------------------------------------------------
       var actualPrecision
        =Helper_GetFieldValue<short>(schema.Rows[0][xdb.OleDbDataReaderSchemaColumnNames.NumericPrecision]);

       if(testData.ResultPrecision != actualPrecision)
       {
        string err
         =string.Format
          ("COALESCE({0}, {1}) -> precision: {2}. Expected precision: {3}.",
           testData.ColumnName1,
           testData.ColumnName2,
           Helper_Print(actualPrecision),
           Helper_Print(testData.ResultPrecision));

        errList.Add(err);
       }//if

       //-------------------------------------------------------
       var actualScale
        =Helper_GetFieldValue<short>(schema.Rows[0][xdb.OleDbDataReaderSchemaColumnNames.NumericScale]);

       if(testData.ResultScale != actualScale)
       {
        string err
         =string.Format
          ("COALESCE({0}, {1}) -> Scale: {2}. Expected Scale: {3}.",
           testData.ColumnName1,
           testData.ColumnName2,
           Helper_Print(actualScale),
           Helper_Print(testData.ResultScale));

        errList.Add(err);
       }//if

       //-------------------------------------------------------
       if(errList.Count==curErrCount)
       {
        Console.WriteLine
         ("COALESCE({0}, {1}) -> OK. type: {2}, size: {3}, precision: {4}, scale: {5}",
          testData.ColumnName1,
          testData.ColumnName2,
          testData.ResultOleDbType,
          Helper_Print(testData.ResultSize),
          Helper_Print(testData.ResultPrecision),
          Helper_Print(testData.ResultScale));
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
 private static T? Helper_GetFieldValue<T>(object v) where T:struct
 {
  if(DBNull.Value==v)
   return null;

  return (T)v;
 }//Helper_GetFieldValue

 //-----------------------------------------------------------------------
 private static string Helper_Print(object v)
 {
  return (v??(object)"null").ToString();
 }//Helper_Print
};//class TestSet_001__verify_result_type

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Operators.SET_001.Coalesce.Complete

////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 10.12.2020.
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Operators.SET_001.LeftShift{
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

  public tagData(string        left,
                 object        leftValue,
                 string        right,
                 object        rightValue,
                 xdb.OleDbType result)
  {
   this.LeftType        =left;
   this.LeftValue       =leftValue;

   this.RightType       =right;
   this.RightValue      =rightValue;

   this.ResultOleDbType =result;
  }//tagData
 };//struct tagData

 private static readonly tagData[] sm_Data=
 {
  new tagData("SMALLINT"          ,  2, "SMALLINT"         ,  1, xdb.OleDbType.BigInt),
  new tagData("SMALLINT"          ,  2, "INTEGER"          ,  1, xdb.OleDbType.BigInt),
  new tagData("SMALLINT"          ,  2, "BIGINT"           ,  1, xdb.OleDbType.BigInt),
  new tagData("SMALLINT"          ,  2, "NUMERIC(1)"       ,  1, xdb.OleDbType.BigInt),
  new tagData("SMALLINT"          ,  2, "NUMERIC(1,0)"     ,  1, xdb.OleDbType.BigInt),
                                                                 
  new tagData("INTEGER"           ,  2, "SMALLINT"         ,  1, xdb.OleDbType.BigInt),
  new tagData("INTEGER"           ,  2, "INTEGER"          ,  1, xdb.OleDbType.BigInt),
  new tagData("INTEGER"           ,  2, "BIGINT"           ,  1, xdb.OleDbType.BigInt),
  new tagData("INTEGER"           ,  2, "NUMERIC(1)"       ,  1, xdb.OleDbType.BigInt),
  new tagData("INTEGER"           ,  2, "NUMERIC(1,0)"     ,  1, xdb.OleDbType.BigInt),
                                                                 
  new tagData("BIGINT"            ,  2, "SMALLINT"         ,  1, xdb.OleDbType.BigInt),
  new tagData("BIGINT"            ,  2, "INTEGER"          ,  1, xdb.OleDbType.BigInt),
  new tagData("BIGINT"            ,  2, "BIGINT"           ,  1, xdb.OleDbType.BigInt),
  new tagData("BIGINT"            ,  2, "NUMERIC(1)"       ,  1, xdb.OleDbType.BigInt),
  new tagData("BIGINT"            ,  2, "NUMERIC(1,0)"     ,  1, xdb.OleDbType.BigInt),

  new tagData("NUMERIC(1)"        ,  2, "SMALLINT"         ,  1, xdb.OleDbType.BigInt),
  new tagData("NUMERIC(1)"        ,  2, "INTEGER"          ,  1, xdb.OleDbType.BigInt),
  new tagData("NUMERIC(1)"        ,  2, "BIGINT"           ,  1, xdb.OleDbType.BigInt),
  new tagData("NUMERIC(1)"        ,  2, "NUMERIC(1)"       ,  1, xdb.OleDbType.BigInt),
  new tagData("NUMERIC(1)"        ,  2, "NUMERIC(1,0)"     ,  1, xdb.OleDbType.BigInt),

  new tagData("NUMERIC(1,0)"      ,  2, "SMALLINT"         ,  1, xdb.OleDbType.BigInt),
  new tagData("NUMERIC(1,0)"      ,  2, "INTEGER"          ,  1, xdb.OleDbType.BigInt),
  new tagData("NUMERIC(1,0)"      ,  2, "BIGINT"           ,  1, xdb.OleDbType.BigInt),
  new tagData("NUMERIC(1,0)"      ,  2, "NUMERIC(1)"       ,  1, xdb.OleDbType.BigInt),
  new tagData("NUMERIC(1,0)"      ,  2, "NUMERIC(1,0)"     ,  1, xdb.OleDbType.BigInt),

  new tagData("NUMERIC(18)"       ,  2, "SMALLINT"         ,  1, xdb.OleDbType.BigInt),
  new tagData("NUMERIC(18)"       ,  2, "INTEGER"          ,  1, xdb.OleDbType.BigInt),
  new tagData("NUMERIC(18)"       ,  2, "BIGINT"           ,  1, xdb.OleDbType.BigInt),
  new tagData("NUMERIC(18)"       ,  2, "NUMERIC(1)"       ,  1, xdb.OleDbType.BigInt),
  new tagData("NUMERIC(18)"       ,  2, "NUMERIC(1,0)"     ,  1, xdb.OleDbType.BigInt),
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
       ="select BIN_SHL(CAST("+testData.LeftValue+" AS "+testData.LeftType+"),CAST("+testData.RightValue+" AS "+testData.RightType+")) from DUAL";

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
          ("{0} << {1} == {2}. Expected {3}",
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
};//class TestSet_001__verify_result_type

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Operators.SET_001.LeftShift

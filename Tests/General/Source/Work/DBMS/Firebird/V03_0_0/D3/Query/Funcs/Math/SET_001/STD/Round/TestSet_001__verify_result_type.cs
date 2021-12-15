////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 12.12.2020.
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.Math.SET_001.STD.Round{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_001__verify_result_type

public static class TestSet_001__verify_result_type
{
 private struct tagData
 {
  public string         ArgType;
  public xdb.OleDbType  ResultOleDbType;

  public tagData(string argType, xdb.OleDbType result)
  {
   this.ArgType         =argType;
   this.ResultOleDbType =result;
  }
 };//struct tagData

 private static readonly tagData[] sm_Data=
 {
  new tagData("SMALLINT"          ,xdb.OleDbType.SmallInt),

  new tagData("INTEGER"           ,xdb.OleDbType.Integer),

  new tagData("BIGINT"            ,xdb.OleDbType.BigInt),

  new tagData("FLOAT"             ,xdb.OleDbType.Single),

  new tagData("DOUBLE PRECISION"  ,xdb.OleDbType.Double),

  new tagData("NUMERIC(1)"        ,xdb.OleDbType.Numeric),

  new tagData("NUMERIC(1,0)"      ,xdb.OleDbType.Numeric),

  new tagData("NUMERIC(2,1)"      ,xdb.OleDbType.Numeric),

  new tagData("NUMERIC(5,4)"      ,xdb.OleDbType.Numeric),
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
       ="select ROUND(CAST(1 AS "+testData.ArgType+")) from DUAL";

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
          ("ROUND({0}) == {1}. Expected {2}",
           testData.ArgType,
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
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.Math.SET_001.STD.Round

////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 14.10.2021.
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D2.Query.Op2.SET_002__AS_STR.Negate{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_001__verify_result_type

public static class TestSet_001__verify_result_type
{
 private struct tagData
 {
  public string         OperandType;
  public object         OperandValue;

  public string         ResultAsStr;

  public tagData(string operandType,
                 object operandValue,
                 string resultAsStr)
  {
   this.OperandType       =operandType;
   this.OperandValue      =operandValue;

   this.ResultAsStr       =resultAsStr;
  }//tagData
 };//struct tagData

 private static readonly tagData[] sm_Data_000=
 {
  new tagData("SMALLINT"          ,  2,"-2"),

  new tagData("INTEGER"           ,  2,"-2"),

  new tagData("BIGINT"            ,  2,"-2"),

  new tagData("FLOAT"             ,  2,"-2.0000000"),

  new tagData("DOUBLE PRECISION"  ,  2,"-2.000000000000000"),

  new tagData("DECIMAL(3,2)"      ,  2,"-2.00"),

  new tagData("NUMERIC(3,2)"      ,  2,"-2.00"),
 };//sm_Data_000

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
       ="select CAST(-CAST("+testData.OperandValue+" AS "+testData.OperandType+") AS VARCHAR(64)) from DUAL";

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
          ("-{0} == \"{1}\". Expected \"{2}\"",
           testData.OperandType,
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
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D2.Query.Op2.SET_002__AS_STR.Negate

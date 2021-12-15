////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 18.02.2021.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D2.Query.CastAs.SET_001.String.TimeSpan{
////////////////////////////////////////////////////////////////////////////////

using T_SOURCE_VALUE=System.String;
using T_TARGET_VALUE=System.TimeSpan;

using DB_TABLE=LocalDbObjNames.TEST_MODIFY_ROW2;

////////////////////////////////////////////////////////////////////////////////
//class TestSet__T001__field

public static class TestSet__T001__field
{
 private const string c_NameOf__TABLE="TEST_MODIFY_ROW2";

 private const string c_NameOf__COL_SOURCE="COL_VARCHAR_32";
 private const string c_NameOf__COL_TARGET=DB_TABLE.Columns.COL2_for_TimeSpan;

 private sealed class MyContext:TestBaseDbContext
 {
  [Table(c_NameOf__TABLE)]
  public sealed class TEST_RECORD
  {
   [Key]
   [Column("TEST_ID")]
   public System.Int64? TEST_ID { get; set; }

   [Column(c_NameOf__COL_SOURCE,TypeName="VARCHAR(32)")]
   public T_SOURCE_VALUE COL_SOURCE { get; set; }

   [Column(c_NameOf__COL_TARGET)]
   public T_TARGET_VALUE COL_TARGET { get; set; }
  };//class TEST_RECORD

  //----------------------------------------------------------------------
  public DbSet<TEST_RECORD> testTable { get; set; }

  //----------------------------------------------------------------------
  public MyContext(xdb.OleDbTransaction tr)
   :base(tr)
  {
  }//MyContext
 };//class MyContext

 //-----------------------------------------------------------------------
 private struct tagData001
 {
  public readonly T_SOURCE_VALUE  SourceValue;
  public readonly T_TARGET_VALUE TargetValue;

  public tagData001(T_SOURCE_VALUE  sourceValue,
                    T_TARGET_VALUE targetValue)
  {
   this.SourceValue=sourceValue;
   this.TargetValue=targetValue;
  }//tagData001
 };//struct tagData001

 //-----------------------------------------------------------------------
 private static readonly tagData001[]
  sm_Data001
   =new tagData001[]
     {
      new tagData001("1:2"                       ,new T_TARGET_VALUE(0,1,2,0,0)),
      new tagData001("1:2:3"                     ,new T_TARGET_VALUE(0,1,2,3,0)),
      new tagData001("1:2:3.1"                   ,new T_TARGET_VALUE(0,1,2,3,100)),
      new tagData001("1:2:3.12"                  ,new T_TARGET_VALUE(0,1,2,3,120)),
      new tagData001("1:2:3.123"                 ,new T_TARGET_VALUE(0,1,2,3,123)),
      new tagData001("1:2:3.1234"                ,new T_TARGET_VALUE(0,1,2,3,0)+new System.TimeSpan(1234*1000)),
      new tagData001("1:2:3.1234\0"              ,new T_TARGET_VALUE(0,1,2,3,0)+new System.TimeSpan(1234*1000)),

      //------------------------------------
      new tagData001(" 1 : 2 "                   ,new T_TARGET_VALUE(0,1,2,0,0)),
      new tagData001(" 1 : 2 : 3 "               ,new T_TARGET_VALUE(0,1,2,3,0)),
      new tagData001(" 1 : 2 : 3 . 1 "           ,new T_TARGET_VALUE(0,1,2,3,100)),
      new tagData001(" 1 : 2 : 3 . 12 "          ,new T_TARGET_VALUE(0,1,2,3,120)),
      new tagData001(" 1 : 2 : 3 . 123 "         ,new T_TARGET_VALUE(0,1,2,3,123)),
      new tagData001(" 1 : 2 : 3 . 1234 "        ,new T_TARGET_VALUE(0,1,2,3,0)+new System.TimeSpan(1234*1000)),
      new tagData001(" 1 : 2 : 3 . 1234\0 "      ,new T_TARGET_VALUE(0,1,2,3,0)+new System.TimeSpan(1234*1000)),

      //------------------------------------
      new tagData001("\t1\t:\t2\t"                   ,new T_TARGET_VALUE(0,1,2,0,0)),
      new tagData001("\t1\t:\t2\t:\t3\t"             ,new T_TARGET_VALUE(0,1,2,3,0)),
      new tagData001("\t1\t:\t2\t:\t3\t.\t1\t"       ,new T_TARGET_VALUE(0,1,2,3,100)),
      new tagData001("\t1\t:\t2\t:\t3\t.\t12\t"      ,new T_TARGET_VALUE(0,1,2,3,120)),
      new tagData001("\t1\t:\t2\t:\t3\t.\t123\t"     ,new T_TARGET_VALUE(0,1,2,3,123)),
      new tagData001("\t1\t:\t2\t:\t3\t.\t1234\t"    ,new T_TARGET_VALUE(0,1,2,3,0)+new System.TimeSpan(1234*1000)),
      new tagData001("\t1\t:\t2\t:\t3\t.\t1234\0\t"  ,new T_TARGET_VALUE(0,1,2,3,0)+new System.TimeSpan(1234*1000)),

      //------------------------------------
      new tagData001("  \t\t  1  :  2  \t\t  "   ,new T_TARGET_VALUE(0,1,2,0,0)),
     };//sm_Data001

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_001__OK()
 {
  using(var cn=LocalCnHelper.CreateCn__UTF8())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     for(int iData=0;iData!=sm_Data001.Length;++iData)
     {
      var testData=sm_Data001[iData];

      try
      {
       System.Int64? testID=Helper__InsertRow(db,testData.SourceValue,testData.TargetValue);

       var recs=db.testTable.Where(r => (T_TARGET_VALUE)(object)r.COL_SOURCE==r.COL_TARGET && r.TEST_ID==testID);

       try
       {
        foreach(var r in recs)
        {
         TestServices.ThrowSelectedRow();
        }//foreach

        TestServices.ThrowWeWaitError();
       }
       catch(lcpi.lib.structure.exceptions.t_invalid_operation_exception e)
       {
        CheckErrors.PrintException_OK
         (e);

        Assert.AreEqual
         (1,
          TestUtils.GetRecordCount(e));

        CheckErrors.CheckErrorRecord__sql_gen_err__unsupported_cast_as_between_types_2
         (TestUtils.GetRecord(e,0),
          CheckErrors.c_src__EFCoreDataProvider__FB_Common__Sql_ENode_Unary__Convert,
          "System.String",
          "System.TimeSpan");
       }//catch
      }
      catch(Exception e)
      {
       var msg
        =string.Format
          ("Failed to process test data [{0}] - \"{1}\".",
           iData,
           testData.SourceValue);

       throw new System.ApplicationException(msg,e);
      }//catch

      tr.RollbackRetaining();
     }//for iData
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_001__OK

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002__ERR()
 {
  string[] testDataArray
   =new string[]
    {
     "",
     " ",
     "1",
     "1:",
     " 1#2#3#4 ",
     "1:2\0",
     "1:2:3\0",
     "123:2:3",
     "1:245:3",
     "1:2:345",
     "1:2:3.12345",
     //" 1:2:3.4\0 ",
     //"😚",      // <----- !!!
    }; //testDataArray

  //------------------------------------------------------------
  using(var cn=LocalCnHelper.CreateCn__UTF8())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     for(int iData=0;iData!=testDataArray.Length;++iData)
     {
      var testData=testDataArray[iData];

      Console.WriteLine("------------------------------------- [{0}]", iData);

      System.Int64? testID=Helper__InsertRow(db,testData,new T_TARGET_VALUE(0));

      var recs=db.testTable.Where(r => (T_TARGET_VALUE)(object)r.COL_SOURCE==r.COL_TARGET && r.TEST_ID==testID);

      try
      {
       foreach(var r in recs)
       {
        TestServices.ThrowSelectedRow();
       }//foreach

       TestServices.ThrowWeWaitError();
      }
      catch(lcpi.lib.structure.exceptions.t_invalid_operation_exception e)
      {
       CheckErrors.PrintException_OK
        (e);

       Assert.AreEqual
        (1,
         TestUtils.GetRecordCount(e));

       CheckErrors.CheckErrorRecord__sql_gen_err__unsupported_cast_as_between_types_2
        (TestUtils.GetRecord(e,0),
         CheckErrors.c_src__EFCoreDataProvider__FB_Common__Sql_ENode_Unary__Convert,
        "System.String",
        "System.TimeSpan");
      }//catch

      tr.RollbackRetaining();
     }//for iData
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_002__ERR

 //-----------------------------------------------------------------------
 private static System.Int64 Helper__InsertRow(MyContext      db,
                                               T_SOURCE_VALUE valueForColSource,
                                               T_TARGET_VALUE valueForColTarget)
 {
  var newRecord=new MyContext.TEST_RECORD();

  newRecord.COL_SOURCE =valueForColSource;
  newRecord.COL_TARGET =valueForColTarget;

  db.testTable.Add(newRecord);

  db.SaveChanges();

  db.CheckTextOfLastExecutedCommand
   (new TestSqlTemplate()
     .T("INSERT INTO ").N(c_NameOf__TABLE).T(" (").N(c_NameOf__COL_SOURCE).T(", ").N(c_NameOf__COL_TARGET).T(")").EOL()
     .T("VALUES (").P("p0").T(", ").P("p1").T(")").EOL()
     .T("RETURNING ").N("TEST_ID").EOL()
     .T("INTO ").P("p2").T(";"));

  Assert.IsTrue
   (newRecord.TEST_ID.HasValue);

  Console.WriteLine("TEST_ID: {0}",newRecord.TEST_ID.Value);

  return newRecord.TEST_ID.Value;
 }//Helper__InsertRow
};//class TestSet__T001__field

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D2.Query.CastAs.SET_001.String.TimeSpan

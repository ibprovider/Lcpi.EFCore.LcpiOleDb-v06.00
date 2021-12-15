////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 20.02.2021.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.CastAs.SET_001.String.DateOnly{
////////////////////////////////////////////////////////////////////////////////

using T_SOURCE_VALUE=System.String;
using T_TARGET_VALUE=System.DateOnly;

////////////////////////////////////////////////////////////////////////////////
//class TestSet__T004__param

public static class TestSet__T004__param
{
 private const string c_NameOf__TABLE="TEST_MODIFY_ROW2";

 private const string c_NameOf__COL_SOURCE="COL_VARCHAR_128__UTF8";
 private const string c_NameOf__COL_TARGET="COL2_TYPE_DATE";

 private sealed class MyContext:TestBaseDbContext
 {
  [Table(c_NameOf__TABLE)]
  public sealed class TEST_RECORD
  {
   [Key]
   [Column("TEST_ID")]
   public System.Int64? TEST_ID { get; set; }

   [Column(c_NameOf__COL_SOURCE,TypeName="VARCHAR(128)")]
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
 private static tagData001[] Helper__Build_Data001()
 {
  var result
   =new System.Collections.Generic.List<tagData001>
     {
      new tagData001("2021-02-20"                                        ,new T_TARGET_VALUE(2021,2,20)),
     
      //------------------------------------
      new tagData001(" 2021 - 02 - 20 "                                  ,new T_TARGET_VALUE(2021,2,20)),
     
      //------------------------------------
      new tagData001("\t2021\t-\t02\t-\t20\t"                            ,new T_TARGET_VALUE(2021,2,20)),
     
      //------------------------------------
      new tagData001("  \t\t 2021  \t\t  -  \t\t  2  \t\t  -  \t\t  20 \t\t  ",new T_TARGET_VALUE(2021,2,20)),
     
      //------------------------------------
      new tagData001("20.2.2021"                                         ,new T_TARGET_VALUE(2021,2,20)),
     
      new tagData001("20.02.2021"                                        ,new T_TARGET_VALUE(2021,2,20)),
     
      new tagData001("5.3.2021"                                          ,new T_TARGET_VALUE(2021,3,5)),

      //------------------------------------------------------------------
      new tagData001("17-jan    -2021"                                    ,new T_TARGET_VALUE(2021,1,17)),
      new tagData001("17-january-2021"                                    ,new T_TARGET_VALUE(2021,1,17)),

      new tagData001("17-feb     -2021"                                   ,new T_TARGET_VALUE(2021,2,17)),
      new tagData001("17-february-2021"                                   ,new T_TARGET_VALUE(2021,2,17)),

      new tagData001("17-mar     -2021"                                   ,new T_TARGET_VALUE(2021,3,17)),
      new tagData001("17-march   -2021"                                   ,new T_TARGET_VALUE(2021,3,17)),

      new tagData001("17-apr     -2021"                                   ,new T_TARGET_VALUE(2021,4,17)),
      new tagData001("17-april   -2021"                                   ,new T_TARGET_VALUE(2021,4,17)),

      new tagData001("17-may     -2021"                                   ,new T_TARGET_VALUE(2021,5,17)),

      new tagData001("17-jun     -2021"                                   ,new T_TARGET_VALUE(2021,6,17)),
      new tagData001("17-june    -2021"                                   ,new T_TARGET_VALUE(2021,6,17)),

      new tagData001("17-jul     -2021"                                   ,new T_TARGET_VALUE(2021,7,17)),
      new tagData001("17-july    -2021"                                   ,new T_TARGET_VALUE(2021,7,17)),

      new tagData001("17-aug       -2021"                                 ,new T_TARGET_VALUE(2021,8,17)),
      new tagData001("17-august    -2021"                                 ,new T_TARGET_VALUE(2021,8,17)),

      new tagData001("17-sep       -2021"                                 ,new T_TARGET_VALUE(2021,9,17)),
      new tagData001("17-september -2021"                                 ,new T_TARGET_VALUE(2021,9,17)),

      new tagData001("17-oct       -2021"                                 ,new T_TARGET_VALUE(2021,10,17)),
      new tagData001("17-october   -2021"                                 ,new T_TARGET_VALUE(2021,10,17)),

      new tagData001("17-nov       -2021"                                 ,new T_TARGET_VALUE(2021,11,17)),
      new tagData001("17-november  -2021"                                 ,new T_TARGET_VALUE(2021,11,17)),

      new tagData001("17-dec       -2021"                                 ,new T_TARGET_VALUE(2021,12,17)),
      new tagData001("17-december  -2021"                                 ,new T_TARGET_VALUE(2021,12,17)),
     };//result

   //------------------------------------------------------
   // var currentYear=T_TARGET_VALUE.Today.Year;
   // 
   // for(int testYear=currentYear-50;testYear<=currentYear+49;++testYear)
   // {
   //  string str
   //   =string.Format("2-JAN-{0}",testYear%100);
   // 
   //  result.Add
   //   (new tagData001
   //     (str,
   //      new T_TARGET_VALUE(testYear,1,2)));
   // }//for testYear
   // 
   // for(int testYear=currentYear-50;testYear<=currentYear+49;++testYear)
   // {
   //  string str
   //   =string.Format("2-JAN-{0:D2}",testYear%100);
   // 
   //  result.Add
   //   (new tagData001
   //     (str,
   //      new T_TARGET_VALUE(testYear,1,2)));
   // }//for testYear

   //------------------------------------------------------
   for(int testYear=1;testYear<=999;++testYear)
   {
    string str
     =string.Format("2-JAN-{0}",testYear);
   
    result.Add
     (new tagData001
       (str,
        new T_TARGET_VALUE(testYear,1,2)));
   }//for testYear

   //------------------------------------------------------
   return result.ToArray();
 }//Helper__Build_Data001

 //-----------------------------------------------------------------------
 private static readonly tagData001[]
  sm_Data001
   =Helper__Build_Data001();

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

       T_SOURCE_VALUE vv=testData.SourceValue;
       
       var recs=db.testTable.Where(r => (T_TARGET_VALUE)(object)vv==r.COL_TARGET && r.TEST_ID==testID);
       
       int nRecs=0;
       
       foreach(var r in recs)
       {
        Assert.AreEqual
         (0,
          nRecs);
       
        ++nRecs;
       
        Assert.IsTrue
         (r.TEST_ID.HasValue);
       
        Assert.AreEqual
         (testID,
          r.TEST_ID.Value);
       
        Assert.AreEqual
         (testData.SourceValue,
          r.COL_SOURCE);
       
        Assert.AreEqual
         (testData.TargetValue,
          r.COL_TARGET);
       }//foreach r
       
       db.CheckTextOfLastExecutedCommand
        (new TestSqlTemplate()
          .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_SOURCE).T(", ").N("t",c_NameOf__COL_TARGET).EOL()
          .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
          .T("WHERE (").P("__Exec_0").T(" = ").N("t",c_NameOf__COL_TARGET).T(") AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));
       
       Assert.AreEqual
        (1,
         nRecs);
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
     "2021",
     "2021-",
     "2021-2",
     "2021-2-",
     "2021-2-20 1",
     "2021-2-20 1:",
     "2021-2-20 1:2\0",
     " 2021#2#20 ",
     "2021-2-20 1:2\0",
     "2021-2-20 1:2:3\0",

     "20211-2-20 1:2:3",
     "2021-222-20 1:2:3",
     "2021-2-201 1:2:3",

     "2021-2-20 123:2:3",
     "2021-2-20 1:245:3",
     "2021-2-20 1:2:345",
     "2021-2-20 1:2:3.12345",
     //"2021-2-20  1:2:3.4\0 ",
     "2021-2-20 😚",      // <----- !!!

     "17-JA        -2021",
     "17-JANU      -2021",
     "17-JANUA     -2021",
     "17-JANUAR    -2021",
     "17-JANUARYY  -2021",
                   
     "17-FE        -2021",
     "17-FEBR      -2021",
     "17-FEBRU     -2021",
     "17-FEBRUA    -2021",
     "17-FEBRUAR   -2021",
     "17-FEBRUARYY -2021",
                   
     "17-MA        -2021",
     "17-MARC    -2021",
     "17-MARCHH    -2021",
                   
     "17-AP        -2021",
     "17-APRI      -2021",
     "17-APRILL    -2021",
                   
     "17-MA        -2021",
     "17-MAYY      -2021",
                   
     "17-JU        -2021",
     "17-JUNEE     -2021",
                   
     "17-JU        -2021",
     "17-JULYY     -2021",
                   
     "17-AU        -2021",
     "17-AUGU      -2021",
     "17-AUGUS     -2021",
     "17-AUGUSTT   -2021",

     "17-SE        -2021",
     "17-SEPT      -2021",
     "17-SEPTE     -2021",
     "17-SEPTEM    -2021",
     "17-SEPTEMB   -2021",
     "17-SEPTEMBE  -2021",
     "17-SEPTEMBERR-2021",

     "17-OC        -2021",
     "17-OCTO      -2021",
     "17-OCTOB     -2021",
     "17-OCTOBE    -2021",
     "17-OCTOBERR  -2021",

     "17-NO        -2021",
     "17-NOVE      -2021",
     "17-NOVEM     -2021",
     "17-NOVEMB    -2021",
     "17-NOVEMBE   -2021",
     "17-NOVEMBERR -2021",

     "17-DE        -2021",
     "17-DECE      -2021",
     "17-DECEM     -2021",
     "17-DECEMB    -2021",
     "17-DECEMBE   -2021",
     "17-DECEMBERR -2021",

     //---------------------------------------------------- NOT SUPP0RTED
     "2021-02-20 1:2",
     "2021-02-20 1:2:3",
     "2021-02-20 1:2:3.1",
     "2021-02-20 1:2:3.12",
     "2021-02-20 1:2:3.123",
     "2021-02-20 1:2:3.1234",
     
     "2021-02-20 1:2\0",
     "2021-02-20 1:2:3\0",
     "2021-02-20 1:2:3.1\0",
     "2021-02-20 1:2:3.12\0",
     "2021-02-20 1:2:3.123\0",
     "2021-02-20 1:2:3.1234\0",
     
     //------------------------------------
     " 2021 - 02 - 20 1 : 2 ",
     " 2021 - 02 - 20 1 : 2 : 3 ",
     " 2021 - 02 - 20 1 : 2 : 3 . 1 ",
     " 2021 - 02 - 20 1 : 2 : 3 . 12 ",
     " 2021 - 02 - 20 1 : 2 : 3 . 123 ",
     " 2021 - 02 - 20 1 : 2 : 3 . 1234 ",
     " 2021 - 02 - 20 1 : 2 : 3 . 1234\0 ",
     
     //------------------------------------
     "\t2021\t-\t02\t-\t20\t1\t:\t2\t",
     "\t2021\t-\t02\t-\t20\t1\t:\t2\t:\t3\t",
     "\t2021\t-\t02\t-\t20\t1\t:\t2\t:\t3\t.\t1\t",
     "\t2021\t-\t02\t-\t20\t1\t:\t2\t:\t3\t.\t12\t",
     "\t2021\t-\t02\t-\t20\t1\t:\t2\t:\t3\t.\t123\t",
     "\t2021\t-\t02\t-\t20\t1\t:\t2\t:\t3\t.\t1234\t",
     "\t2021\t-\t02\t-\t20\t1\t:\t2\t:\t3\t.\t1234\0\t",
     
     //------------------------------------
     "  \t\t 2021  \t\t  -  \t\t  2  \t\t  -  \t\t  20 \t\t  1  :  2  \t\t  ",
     
     //------------------------------------
     "20.2.2021 1:2",
     "20.2.2021 1:2:3",
     "20.2.2021 1:2:3.1",
     "20.2.2021 1:2:3.12",
     "20.2.2021 1:2:3.123",
     "20.2.2021 1:2:3.1234",
     
     "20.02.2021 1:2",
     "20.02.2021 1:2:3",
     "20.02.2021 1:2:3.1",
     "20.02.2021 1:2:3.12",
     "20.02.2021 1:2:3.123",
     "20.02.2021 1:2:3.1234",
     
     "5.3.2021 01:02",
     "5.3.2021 01:02:03",
     "5.3.2021 01:02:03.1",
     "5.3.2021 01:02:03.12",
     "5.3.2021 01:02:03.123",
     "5.3.2021 01:02:03.1234",

     //------------------------------------
     "20.2.2021 1:2\0",
     "20.2.2021 1:2:3\0",
     "20.2.2021 1:2:3.1\0",
     "20.2.2021 1:2:3.12\0",
     "20.2.2021 1:2:3.123\0",
     "20.2.2021 1:2:3.1234\0",
     
     "20.02.2021 1:2\0",
     "20.02.2021 1:2:3\0",
     "20.02.2021 1:2:3.1\0",
     "20.02.2021 1:2:3.12\0",
     "20.02.2021 1:2:3.123\0",
     "20.02.2021 1:2:3.1234\0",
     
     "5.3.2021 01:02",
     "5.3.2021 01:02:03\0",
     "5.3.2021 01:02:03.1\0",
     "5.3.2021 01:02:03.12\0",
     "5.3.2021 01:02:03.123\0",
     "5.3.2021 01:02:03.1234\0",
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

      System.Int64? testID=Helper__InsertRow(db,testData,new T_TARGET_VALUE(2021,2,20));

      T_SOURCE_VALUE vv=testData;

      try
      {
       var recs=db.testTable.Where(r => (T_TARGET_VALUE)(object)vv==r.COL_TARGET && r.TEST_ID==testID);
       
       foreach(var r in recs)
       {
        TestServices.ThrowSelectedRow();
       }//foreach r
       
       TestServices.ThrowWeWaitError();
      }
      catch(InvalidOperationException e)
      {
       CheckErrors.PrintException_OK(e);

       Assert.IsNotNull
        (e.InnerException);

       Assert.IsInstanceOf<lcpi.lib.structure.exceptions.t_invalid_operation_exception>
        (e.InnerException);

       var e2=(lcpi.lib.structure.exceptions.t_invalid_operation_exception)(e.InnerException);

       Assert.AreEqual
        (1,
         TestUtils.GetRecordCount(e2));

       CheckErrors.CheckErrorRecord__common_err__cant_convert_value_between_types_2
        (TestUtils.GetRecord(e2,0),
         CheckErrors.c_src__Core_Engines_Dbms_FB_Common_Mirror__Convert_Code__STRING__TYPE_DATE,
         lcpi.lib.com.HResultCode.DB_E_CANTCONVERTVALUE,
         typeof(string),
         typeof(T_TARGET_VALUE));
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
};//class TestSet__T004__param

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.CastAs.SET_001.String.DateOnly

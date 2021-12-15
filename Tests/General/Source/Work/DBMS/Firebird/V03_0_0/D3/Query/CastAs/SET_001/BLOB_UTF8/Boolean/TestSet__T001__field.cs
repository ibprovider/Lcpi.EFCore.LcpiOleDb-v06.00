////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 16.02.2021.
//
// (bool)string_column==bool_column
//
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using lcpi.data.oledb;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.CastAs.SET_001.BLOB_UTF8.Boolean{
////////////////////////////////////////////////////////////////////////////////

using T_SOURCE_VALUE=System.String;
using T_TARGET_VALUE=System.Boolean;

////////////////////////////////////////////////////////////////////////////////
//class TestSet__T001__field

public static class TestSet__T001__field
{
 private const string c_NameOf__TABLE="TEST_MODIFY_ROW2";

 private const string c_NameOf__COL_SOURCE="COL_TEXT__UTF8";
 private const string c_NameOf__COL_TARGET="COL2_BOOLEAN";

 private const string c_NameOf__TARGET_SQL_TYPE="BOOLEAN";

 private sealed class MyContext:TestBaseDbContext
 {
  [Table(c_NameOf__TABLE)]
  public sealed class TEST_RECORD
  {
   [Key]
   [Column("TEST_ID")]
   public System.Int64? TEST_ID { get; set; }

   [Column(c_NameOf__COL_SOURCE,TypeName="BLOB SUB_TYPE TEXT")]
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
  public readonly System.String  SourceValue;
  public readonly System.Boolean TargetValue;

  public tagData001(System.String  sourceValue,
                    System.Boolean targetValue)
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
      new tagData001("TRUE"       ,true),
      new tagData001("FALSE"      ,false),

      new tagData001(" TRUE "     ,true),
      new tagData001(" FALSE "    ,false),

      new tagData001("\nTRUE\n"   ,true),
      new tagData001("\nFALSE\n"  ,false),

      new tagData001("\rTRUE\r"   ,true),
      new tagData001("\rFALSE\r"  ,false),

      new tagData001("\tTRUE\t"   ,true),
      new tagData001("\tFALSE\t"  ,false),

      //------------------------------------
      new tagData001("true"       ,true),
      new tagData001("false"      ,false),

      new tagData001(" true "     ,true),
      new tagData001(" false "    ,false),

      new tagData001("\ntrue\n"   ,true),
      new tagData001("\nfalse\n"  ,false),

      new tagData001("\rtrue\r"   ,true),
      new tagData001("\rfalse\r"  ,false),

      new tagData001("\ttrue\t"   ,true),
      new tagData001("\tfalse\t"  ,false),

      //------------------------------------
      new tagData001("   \n \r \t TRUE    \n \r \t "   ,true),
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
          .T("WHERE (CAST(").N("t",c_NameOf__COL_SOURCE).T(" AS "+c_NameOf__TARGET_SQL_TYPE+") = ").N("t",c_NameOf__COL_TARGET).T(") AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));
       
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
 enum EnumFbErrKind
 {
  cvtError           =0,
  csTranslationError =1,
  blobTruncation     =2,
 };//enum EnumFbErrKind

 [Test]
 public static void Test_002__ERR()
 {
  System.Tuple<EnumFbErrKind,string>[]
   testDataArray
    =new System.Tuple<EnumFbErrKind,string>[]
      {
       new System.Tuple<EnumFbErrKind,string>
        (EnumFbErrKind.cvtError, " "),
     
       new System.Tuple<EnumFbErrKind,string>
        (EnumFbErrKind.cvtError, " T.R.U.E "),
     
       new System.Tuple<EnumFbErrKind,string>
        (EnumFbErrKind.cvtError, " TRUE\0 "),
     
       new System.Tuple<EnumFbErrKind,string>
        (EnumFbErrKind.cvtError, " \0TRUE "),
     
       //
       // PROBLEM WITH CONVERSION TO ASCII AT STAGE OF BLOB READING.
       //
       new System.Tuple<EnumFbErrKind,string>
        (EnumFbErrKind.csTranslationError, "😚"),
     
       new System.Tuple<EnumFbErrKind,string>
        (EnumFbErrKind.blobTruncation, new string(' ',100*1024*1024)),
     
       new System.Tuple<EnumFbErrKind,string>
        (EnumFbErrKind.cvtError, new string(' ',32*1024-1)),
      };//testDataArray

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

      System.Int64? testID=Helper__InsertRow(db,testData.Item2,false);

      try
      {
       var recs=db.testTable.Where(r => (T_TARGET_VALUE)(object)r.COL_SOURCE==r.COL_TARGET && r.TEST_ID==testID);
       
       foreach(var r in recs)
       {
        TestServices.ThrowSelectedRow();
       }//foreach r
       
       TestServices.ThrowWeWaitError();
      }
      catch(OleDbException e)
      {
       CheckErrors.PrintException_OK(e);

       Assert.AreEqual
        (3,
         TestUtils.GetRecordCount(e));

       switch(testData.Item1)
       {
        case EnumFbErrKind.cvtError:
          CheckErrors.CheckOleDbError__Firebird__ConversionErrorFromString
            (e.Errors[0]);
          break;

        case EnumFbErrKind.csTranslationError:
          CheckErrors.CheckOleDbError__Firebird__CannotTranslateCharBetweenCSs
            (e.Errors[0]);
          break;

        case EnumFbErrKind.blobTruncation:
         CheckErrors.CheckOleDbError__Firebird__BlobTruncationWhenCvtToString_LenLimitExceeded
            (e.Errors[0]);
          break;

        default:
         throw new ApplicationException("Unexpected error kind: "+testData.Item1);
       }//switch
      }//catch

      tr.RollbackRetaining();

      db.CheckTextOfLastExecutedCommand
       (new TestSqlTemplate()
         .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_SOURCE).T(", ").N("t",c_NameOf__COL_TARGET).EOL()
         .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
         .T("WHERE (CAST(").N("t",c_NameOf__COL_SOURCE).T(" AS "+c_NameOf__TARGET_SQL_TYPE+") = ").N("t",c_NameOf__COL_TARGET).T(") AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));
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
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.CastAs.SET_001.BLOB_UTF8.Boolean

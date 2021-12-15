////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 19.11.2020.
//
// <field>.StartsWith(...)
//
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.String.SET_001.STD.EndsWith__str{
////////////////////////////////////////////////////////////////////////////////
//using

using T_DATA=System.String;

////////////////////////////////////////////////////////////////////////////////
//class TestSet___VARCHAR_UTF8

public static class TestSet___VARCHAR_UTF8
{
 private const string c_NameOf__TABLE="TBL_CS__UTF8";

 private const string c_NameOf__COL_DATA8="VARCHAR__8";
 
 private const string c_NameOf__COL_DATA32="VARCHAR__32";

 //-----------------------------------------------------------------------
 private sealed class MyContext:TestBaseDbContext
 {
  [Table(c_NameOf__TABLE)]
  public sealed class TEST_RECORD
  {
   [Key]
   [Column("TEST_ID")]
   public System.Int64? TEST_ID { get; set; }

   [Column(c_NameOf__COL_DATA8, TypeName="VARCHAR(8)")]
   public T_DATA DATA8 { get; set; }

   [Column(c_NameOf__COL_DATA32, TypeName="VARCHAR(32)")]
   public T_DATA DATA32 { get; set; }
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
 private static xdb.OleDbConnection Helper__CreateCn()
 {
  return LocalCnHelper.CreateCn__UTF8();
 }//Helper__CreateCn

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_001()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     string c_uchar1=""+((char)0xD800)+((char)0xDC00);
     string c_uchar2=""+((char)0xD801)+((char)0xDC00);
     string c_uchar3=""+((char)0xD802)+((char)0xDC00);
     string c_uchar4=""+((char)0xD803)+((char)0xDC00);

     string c_data8  =c_uchar3+c_uchar4+"B";
     string c_data32 ="A"+c_uchar1+c_uchar2+c_data8;

     System.Int64 testID=Helper__InsertRow(db,c_data8,c_data32);

     var recs=db.testTable.Where(r => r.DATA32.EndsWith(r.DATA8) && r.TEST_ID==testID);

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
       (c_data8,
        r.DATA8);

      Assert.AreEqual
       (c_data32,
        r.DATA32);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA32).T(", ").N("t",c_NameOf__COL_DATA8).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (RIGHT(").N("t",c_NameOf__COL_DATA32).T(", CHARACTER_LENGTH(").N("t",c_NameOf__COL_DATA8).T(")) = ").N("t",c_NameOf__COL_DATA8).T(") AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_001

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     string c_uchar1=""+((char)0xD800)+((char)0xDC00);
     string c_uchar2=""+((char)0xD801)+((char)0xDC00);
     string c_uchar3=""+((char)0xD802)+((char)0xDC00);
     string c_uchar4=""+((char)0xD803)+((char)0xDC00);

     string c_data8  =c_uchar3+c_uchar4+"B";
     string c_data32 ="A"+c_uchar1+c_uchar2+c_data8;

     System.Int64 testID=Helper__InsertRow(db,c_data8,c_data32);

     var recs=db.testTable.Where(r => r.DATA32.EndsWith("\uD802\uDC00\uD803\uDC00B") && r.TEST_ID==testID);

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
       (c_data8,
        r.DATA8);

      Assert.AreEqual
       (c_data32,
        r.DATA32);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA32).T(", ").N("t",c_NameOf__COL_DATA8).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (RIGHT(").N("t",c_NameOf__COL_DATA32).T(", 3) = _utf8 '\uD802\uDC00\uD803\uDC00B') AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_002

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_E1__const()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     string c_uchar1=""+((char)0xD800)+((char)0xDC00);
     string c_uchar2=""+((char)0xD801)+((char)0xDC00);
     string c_uchar3=""+((char)0xD802)+((char)0xDC00);
     string c_uchar4=""+((char)0xD803)+((char)0xDC00);

     string c_data8  =c_uchar3+c_uchar4+"B";
     string c_data32 ="A"+c_uchar1+c_uchar2+c_data8;

     System.Int64 testID=Helper__InsertRow(db,c_data8,c_data32);

     var recs=db.testTable.Where(r => r.DATA32.EndsWith("\uD802") && r.TEST_ID==testID);

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(xEFCore.LcpiOleDb__DataToolException exc)
     {
      CheckErrors.PrintException_OK(exc);

      Assert.AreEqual
       (2,
        TestUtils.GetRecordCount(exc));

      Assert.IsNotNull
       (TestUtils.GetRecord(exc,0));

      Assert.IsNotNull
       (TestUtils.GetRecord(exc,1));

      CheckErrors.CheckErrorRecord__cs_utf16_err__bad_sequence__2
       (TestUtils.GetRecord(exc,0),
        CheckErrors.c_src__EFCoreDataProvider__Structure_CS_UTF16,
        "#GCC.002",
        1);

      CheckErrors.CheckErrorRecord__common_err__failed_to_process_value_1
       (TestUtils.GetRecord(exc,1),
        CheckErrors.c_src__FB_Common__Sql_ETranslator__String__std__EndsWith__str___through_RIGHT,
        "patternString");
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_E1__const

 //-----------------------------------------------------------------------
 private static System.Int64 Helper__InsertRow(MyContext db,
                                               T_DATA    valueOfData8,
                                               T_DATA    valueOfData32)
 {
  var newRecord=new MyContext.TEST_RECORD();

  newRecord.DATA8 =valueOfData8;
  newRecord.DATA32=valueOfData32;

  db.testTable.Add(newRecord);

  db.SaveChanges();

  db.CheckTextOfLastExecutedCommand
   (new TestSqlTemplate()
     .T("INSERT INTO ").N(c_NameOf__TABLE).T(" (").N(c_NameOf__COL_DATA32).T(", ").N(c_NameOf__COL_DATA8).T(")").EOL()
     .T("VALUES (").P("p0").T(", ").P("p1").T(")").EOL()
     .T("RETURNING ").N("TEST_ID").EOL()
     .T("INTO ").P("p2").T(";"));

  Assert.IsTrue
   (newRecord.TEST_ID.HasValue);

  Console.WriteLine("TEST_ID: {0}",newRecord.TEST_ID.Value);

  return newRecord.TEST_ID.Value;
 }//Helper__InsertRow
};//class TestSet___VARCHAR_UTF8

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.String.SET_001.STD.EndsWith__str

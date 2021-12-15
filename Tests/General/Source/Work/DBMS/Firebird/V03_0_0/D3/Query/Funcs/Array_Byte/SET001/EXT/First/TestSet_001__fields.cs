////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 14.06.2021.
using System;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.Array_Byte.SET001.EXT.First{
////////////////////////////////////////////////////////////////////////////////

using T_DATA1_E =System.Byte;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_001__fields

public static class TestSet_001__fields
{
 private const string c_NameOf__TABLE            ="TEST_MODIFY_ROW2";
 private const string c_NameOf__COL_DATA1        ="COL_BYTES_BLOB";

 private sealed class MyContext:TestBaseDbContext
 {
  [Table(c_NameOf__TABLE)]
  public sealed class TEST_RECORD
  {
   [Key]
   [Column("TEST_ID")]
   public System.Int64? TEST_ID { get; set; }

   [Column(c_NameOf__COL_DATA1, TypeName="BLOB")]
   public T_DATA1_E[] COL_DATA1 { get; set; }
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
 [Test]
 public static void Test_001()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA1_E[] c_value1=new T_DATA1_E[]{10,20,30,40,50,60,70};

     System.Int64? testID=Helper__InsertRow(db,c_value1);

     var recs=db.testTable.Where(r => r.COL_DATA1.First()==10 && r.TEST_ID==testID);

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
       (c_value1,
        r.COL_DATA1);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA1).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (CASE").EOL()
        .T("    WHEN COALESCE(0 < OCTET_LENGTH(").N("t",c_NameOf__COL_DATA1).T("), TRUE) THEN ASCII_VAL(SUBSTRING(").N("t",c_NameOf__COL_DATA1).T(" FROM 1 FOR 1))").EOL()
        .T("    ELSE CAST(_utf8 'OUT OF RANGE' AS SMALLINT)").EOL()
        .T("END = 10) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

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
 public static void Test_001__r()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA1_E[]     c_value1=new T_DATA1_E[]{10,20,30,40,50,60,70};

     System.Int64? testID=Helper__InsertRow(db,c_value1);

     var recs=db.testTable.Where(r => 10==r.COL_DATA1.First() && r.TEST_ID==testID);

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
       (c_value1,
        r.COL_DATA1);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA1).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (10 = CASE").EOL()
        .T("    WHEN COALESCE(0 < OCTET_LENGTH(").N("t",c_NameOf__COL_DATA1).T("), TRUE) THEN ASCII_VAL(SUBSTRING(").N("t",c_NameOf__COL_DATA1).T(" FROM 1 FOR 1))").EOL()
        .T("    ELSE CAST(_utf8 'OUT OF RANGE' AS SMALLINT)").EOL()
        .T("END) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_001__r

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002__null()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA1_E[] c_value1=null;

     System.Int64? testID=Helper__InsertRow(db,c_value1);

     var recs=db.testTable.Where(r => r.COL_DATA1.First()==0 && r.TEST_ID==testID);

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA1).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (CASE").EOL()
        .T("    WHEN COALESCE(0 < OCTET_LENGTH(").N("t",c_NameOf__COL_DATA1).T("), TRUE) THEN ASCII_VAL(SUBSTRING(").N("t",c_NameOf__COL_DATA1).T(" FROM 1 FOR 1))").EOL()
        .T("    ELSE CAST(_utf8 'OUT OF RANGE' AS SMALLINT)").EOL()
        .T("END = 0) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_002__null

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_004__err__out_of_range()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA1_E[] c_value1=new T_DATA1_E[0];

     System.Int64? testID=Helper__InsertRow(db,c_value1);

     var recs=db.testTable.Where(r => r.COL_DATA1.First()==0 && r.TEST_ID==testID);

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(xdb.OleDbException e)
     {
      CheckErrors.PrintException_OK(e);

      Assert.AreEqual
       (3,
        TestUtils.GetRecordCount(e));

      CheckErrors.CheckOleDbError__Firebird__OUT_OF_RANGE
       (e.Errors[0]);
     }//catch

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA1).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (CASE").EOL()
        .T("    WHEN COALESCE(0 < OCTET_LENGTH(").N("t",c_NameOf__COL_DATA1).T("), TRUE) THEN ASCII_VAL(SUBSTRING(").N("t",c_NameOf__COL_DATA1).T(" FROM 1 FOR 1))").EOL()
        .T("    ELSE CAST(_utf8 'OUT OF RANGE' AS SMALLINT)").EOL()
        .T("END = 0) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_004__err__out_of_range

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_005__each_byte()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA1_E[] bytes=new T_DATA1_E[]{10,20,30};

     for(T_DATA1_E byteValue=0;;++byteValue)
     {
      Console.WriteLine("-------------------------------- test byte: {0}",byteValue);

      bytes[0]=byteValue;

      System.Int64? testID=Helper__InsertRow(db,bytes);

      short expectedByte=bytes[0];

      var recs=db.testTable.Where(r => r.COL_DATA1.First()==expectedByte && r.TEST_ID==testID);

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
        (bytes,
         r.COL_DATA1);
      }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA1).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (CASE").EOL()
        .T("    WHEN COALESCE(0 < OCTET_LENGTH(").N("t",c_NameOf__COL_DATA1).T("), TRUE) THEN ASCII_VAL(SUBSTRING(").N("t",c_NameOf__COL_DATA1).T(" FROM 1 FOR 1))").EOL()
        .T("    ELSE CAST(_utf8 'OUT OF RANGE' AS SMALLINT)").EOL()
        .T("END = ").P_I2("__expectedByte_0").T(") AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));

      Assert.AreEqual
       (1,
        nRecs);

      tr.RollbackRetaining();

      if(byteValue==T_DATA1_E.MaxValue)
       break;
     }//for iByte
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_005__each_byte

 //-----------------------------------------------------------------------
 private static System.Int64 Helper__InsertRow(MyContext db,
                                               T_DATA1_E[] valueForColData1)
 {
  var newRecord=new MyContext.TEST_RECORD();

  newRecord.COL_DATA1=valueForColData1;

  db.testTable.Add(newRecord);

  db.SaveChanges();

  var sqlt
   =new TestSqlTemplate()
     .T("INSERT INTO ").N(c_NameOf__TABLE).T(" (").N(c_NameOf__COL_DATA1).T(")").EOL()
     .T("VALUES (").P("p0").T(")").EOL()
     .T("RETURNING ").N("TEST_ID").EOL()
     .T("INTO ").P("p1").T(";");

  db.CheckTextOfLastExecutedCommand
   (sqlt);

  Assert.IsTrue
   (newRecord.TEST_ID.HasValue);

  Console.WriteLine("TEST_ID: {0}",newRecord.TEST_ID.Value);

  return newRecord.TEST_ID.Value;
 }//Helper__InsertRow
};//class TestSet_001__fields

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.Array_Byte.SET001.EXT.First

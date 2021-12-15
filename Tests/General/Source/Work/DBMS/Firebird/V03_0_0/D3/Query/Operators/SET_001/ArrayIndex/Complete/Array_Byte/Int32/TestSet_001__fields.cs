////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 26.05.2021.
using System;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Operators.SET_001.ArrayIndex.Complete.Array_Byte.Int32{
////////////////////////////////////////////////////////////////////////////////

using T_DATA1_E =System.Byte;
using T_DATA2   =System.Int32;

using T_DATA2_U =System.Int32;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_001__fields

public static class TestSet_001__fields
{
 private const string c_NameOf__TABLE            ="TEST_MODIFY_ROW2";
 private const string c_NameOf__COL_DATA1        ="COL_BYTES_BLOB";
 private const string c_NameOf__COL_DATA2        ="COL2_INTEGER";

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

   [Column(c_NameOf__COL_DATA2)]
   public T_DATA2 COL_DATA2 { get; set; }
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
     T_DATA1_E[]     c_value1=new T_DATA1_E[]{10,20,30,40,50,60,70};
     const T_DATA2_U c_value2=3;

     System.Int64? testID=Helper__InsertRow(db,c_value1,c_value2);

     var recs=db.testTable.Where(r => r.COL_DATA1[r.COL_DATA2]==40 && r.TEST_ID==testID);

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

      Assert.AreEqual
       (c_value2,
        r.COL_DATA2);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA1).T(", ").N("t",c_NameOf__COL_DATA2).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (CASE").EOL()
        .T("    WHEN COALESCE((0 <= ").N("t",c_NameOf__COL_DATA2).T(") AND (").N("t",c_NameOf__COL_DATA2).T(" < OCTET_LENGTH(").N("t",c_NameOf__COL_DATA1).T(")), TRUE) THEN ASCII_VAL(SUBSTRING(").N("t",c_NameOf__COL_DATA1).T(" FROM ").N("t",c_NameOf__COL_DATA2).T(" + 1 FOR 1))").EOL()
        .T("    ELSE CAST(_utf8 'OUT OF RANGE' AS SMALLINT)").EOL()
        .T("END = 40) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

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
     const T_DATA2_U c_value2=3;

     System.Int64? testID=Helper__InsertRow(db,c_value1,c_value2);

     var recs=db.testTable.Where(r => 40==r.COL_DATA1[r.COL_DATA2] && r.TEST_ID==testID);

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

      Assert.AreEqual
       (c_value2,
        r.COL_DATA2);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA1).T(", ").N("t",c_NameOf__COL_DATA2).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (40 = CASE").EOL()
        .T("    WHEN COALESCE((0 <= ").N("t",c_NameOf__COL_DATA2).T(") AND (").N("t",c_NameOf__COL_DATA2).T(" < OCTET_LENGTH(").N("t",c_NameOf__COL_DATA1).T(")), TRUE) THEN ASCII_VAL(SUBSTRING(").N("t",c_NameOf__COL_DATA1).T(" FROM ").N("t",c_NameOf__COL_DATA2).T(" + 1 FOR 1))").EOL()
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
     T_DATA1_E[]     c_value1=null;
     const T_DATA2_U c_value2=3;

     System.Int64? testID=Helper__InsertRow(db,c_value1,c_value2);

     var recs=db.testTable.Where(r => r.COL_DATA1[r.COL_DATA2].Equals(null) && r.TEST_ID==testID);

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

      Assert.AreEqual
       (c_value2,
        r.COL_DATA2);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA1).T(", ").N("t",c_NameOf__COL_DATA2).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (CASE").EOL()
        .T("    WHEN COALESCE((0 <= ").N("t",c_NameOf__COL_DATA2).T(") AND (").N("t",c_NameOf__COL_DATA2).T(" < OCTET_LENGTH(").N("t",c_NameOf__COL_DATA1).T(")), TRUE) THEN ASCII_VAL(SUBSTRING(").N("t",c_NameOf__COL_DATA1).T(" FROM ").N("t",c_NameOf__COL_DATA2).T(" + 1 FOR 1))").EOL()
        .T("    ELSE CAST(_utf8 'OUT OF RANGE' AS SMALLINT)").EOL()
        .T("END").IS_NULL().T(") AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_002__null

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_003__each_element()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA1_E[] bytes=new T_DATA1_E[]{10,20,30,40,50,60,70};

     for(T_DATA2_U iByte=0;iByte!=bytes.Length;++iByte)
     {
      System.Int64? testID=Helper__InsertRow(db,bytes,iByte);

      int expectedByte=bytes[iByte];

      var recs=db.testTable.Where(r => r.COL_DATA1[r.COL_DATA2]==expectedByte && r.TEST_ID==testID);

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

       Assert.AreEqual
        (iByte,
         r.COL_DATA2);
      }//foreach r

      db.CheckTextOfLastExecutedCommand
       (new TestSqlTemplate()
         .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA1).T(", ").N("t",c_NameOf__COL_DATA2).EOL()
         .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
         .T("WHERE (CASE").EOL()
         .T("    WHEN COALESCE((0 <= ").N("t",c_NameOf__COL_DATA2).T(") AND (").N("t",c_NameOf__COL_DATA2).T(" < OCTET_LENGTH(").N("t",c_NameOf__COL_DATA1).T(")), TRUE) THEN ASCII_VAL(SUBSTRING(").N("t",c_NameOf__COL_DATA1).T(" FROM ").N("t",c_NameOf__COL_DATA2).T(" + 1 FOR 1))").EOL()
         .T("    ELSE CAST(_utf8 'OUT OF RANGE' AS SMALLINT)").EOL()
         .T("END = ").P_I4("__expectedByte_0").T(") AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));

      Assert.AreEqual
       (1,
        nRecs);

      tr.RollbackRetaining();
     }//for iByte
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_003__each_element

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
     T_DATA1_E[] c_value1=new T_DATA1_E[]{10,20,30,40,50,60,70};
     T_DATA2_U   c_value2=c_value1.Length;

     System.Int64? testID=Helper__InsertRow(db,c_value1,c_value2);

     var recs=db.testTable.Where(r => r.COL_DATA1[r.COL_DATA2]==40 && r.TEST_ID==testID);

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
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA1).T(", ").N("t",c_NameOf__COL_DATA2).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (CASE").EOL()
        .T("    WHEN COALESCE((0 <= ").N("t",c_NameOf__COL_DATA2).T(") AND (").N("t",c_NameOf__COL_DATA2).T(" < OCTET_LENGTH(").N("t",c_NameOf__COL_DATA1).T(")), TRUE) THEN ASCII_VAL(SUBSTRING(").N("t",c_NameOf__COL_DATA1).T(" FROM ").N("t",c_NameOf__COL_DATA2).T(" + 1 FOR 1))").EOL()
        .T("    ELSE CAST(_utf8 'OUT OF RANGE' AS SMALLINT)").EOL()
        .T("END = 40) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));
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

      bytes[1]=byteValue;

      System.Int64? testID=Helper__InsertRow(db,bytes,1);

      short expectedByte=bytes[1];

      var recs=db.testTable.Where(r => r.COL_DATA1[r.COL_DATA2]==expectedByte && r.TEST_ID==testID);

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

       Assert.AreEqual
        (1,
         r.COL_DATA2);
      }//foreach r

      db.CheckTextOfLastExecutedCommand
       (new TestSqlTemplate()
         .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA1).T(", ").N("t",c_NameOf__COL_DATA2).EOL()
         .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
         .T("WHERE (CASE").EOL()
         .T("    WHEN COALESCE((0 <= ").N("t",c_NameOf__COL_DATA2).T(") AND (").N("t",c_NameOf__COL_DATA2).T(" < OCTET_LENGTH(").N("t",c_NameOf__COL_DATA1).T(")), TRUE) THEN ASCII_VAL(SUBSTRING(").N("t",c_NameOf__COL_DATA1).T(" FROM ").N("t",c_NameOf__COL_DATA2).T(" + 1 FOR 1))").EOL()
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
 [Test]
 public static void Test_006__err__out_of_range___m1()
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
     T_DATA2_U   c_value2=-1;

     System.Int64? testID=Helper__InsertRow(db,c_value1,c_value2);

     var recs=db.testTable.Where(r => r.COL_DATA1[r.COL_DATA2]==40 && r.TEST_ID==testID);

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
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA1).T(", ").N("t",c_NameOf__COL_DATA2).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (CASE").EOL()
        .T("    WHEN COALESCE((0 <= ").N("t",c_NameOf__COL_DATA2).T(") AND (").N("t",c_NameOf__COL_DATA2).T(" < OCTET_LENGTH(").N("t",c_NameOf__COL_DATA1).T(")), TRUE) THEN ASCII_VAL(SUBSTRING(").N("t",c_NameOf__COL_DATA1).T(" FROM ").N("t",c_NameOf__COL_DATA2).T(" + 1 FOR 1))").EOL()
        .T("    ELSE CAST(_utf8 'OUT OF RANGE' AS SMALLINT)").EOL()
        .T("END = 40) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_006__err__out_of_range___m1

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_007__err__out_of_range___m1()
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
     T_DATA2_U   c_value2=-1;

     System.Int64? testID=Helper__InsertRow(db,c_value1,c_value2);

     var recs=db.testTable.Where(r => r.COL_DATA1[r.COL_DATA2]==40 && r.TEST_ID==testID);

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
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA1).T(", ").N("t",c_NameOf__COL_DATA2).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (CASE").EOL()
        .T("    WHEN COALESCE((0 <= ").N("t",c_NameOf__COL_DATA2).T(") AND (").N("t",c_NameOf__COL_DATA2).T(" < OCTET_LENGTH(").N("t",c_NameOf__COL_DATA1).T(")), TRUE) THEN ASCII_VAL(SUBSTRING(").N("t",c_NameOf__COL_DATA1).T(" FROM ").N("t",c_NameOf__COL_DATA2).T(" + 1 FOR 1))").EOL()
        .T("    ELSE CAST(_utf8 'OUT OF RANGE' AS SMALLINT)").EOL()
        .T("END = 40) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_007__err__out_of_range___m1

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_008__err__out_of_range___p1()
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
     T_DATA2_U   c_value2=1;

     System.Int64? testID=Helper__InsertRow(db,c_value1,c_value2);

     var recs=db.testTable.Where(r => r.COL_DATA1[r.COL_DATA2]==40 && r.TEST_ID==testID);

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
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA1).T(", ").N("t",c_NameOf__COL_DATA2).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (CASE").EOL()
        .T("    WHEN COALESCE((0 <= ").N("t",c_NameOf__COL_DATA2).T(") AND (").N("t",c_NameOf__COL_DATA2).T(" < OCTET_LENGTH(").N("t",c_NameOf__COL_DATA1).T(")), TRUE) THEN ASCII_VAL(SUBSTRING(").N("t",c_NameOf__COL_DATA1).T(" FROM ").N("t",c_NameOf__COL_DATA2).T(" + 1 FOR 1))").EOL()
        .T("    ELSE CAST(_utf8 'OUT OF RANGE' AS SMALLINT)").EOL()
        .T("END = 40) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_008__err__out_of_range___p1

 //-----------------------------------------------------------------------
 private static System.Int64 Helper__InsertRow(MyContext db,
                                               T_DATA1_E[] valueForColData1,
                                               T_DATA2     valueForColData2)
 {
  var newRecord=new MyContext.TEST_RECORD();

  newRecord.COL_DATA1 =valueForColData1;
  newRecord.COL_DATA2 =valueForColData2;

  db.testTable.Add(newRecord);

  db.SaveChanges();

  db.CheckTextOfLastExecutedCommand
   (new TestSqlTemplate()
     .T("INSERT INTO ").N(c_NameOf__TABLE).T(" (").N(c_NameOf__COL_DATA1).T(", ").N(c_NameOf__COL_DATA2).T(")").EOL()
     .T("VALUES (").P("p0").T(", ").P("p1").T(")").EOL()
     .T("RETURNING ").N("TEST_ID").EOL()
     .T("INTO ").P("p2").T(";"));

  Assert.IsTrue
   (newRecord.TEST_ID.HasValue);

  Console.WriteLine("TEST_ID: {0}",newRecord.TEST_ID.Value);

  return newRecord.TEST_ID.Value;
 }//Helper__InsertRow
};//class TestSet_001__fields

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Operators.SET_001.ArrayIndex.Complete.Array_Byte.Int32

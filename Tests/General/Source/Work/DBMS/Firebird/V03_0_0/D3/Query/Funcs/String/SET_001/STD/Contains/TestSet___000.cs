////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 17.09.2018.
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.String.SET_001.STD.Contains{
////////////////////////////////////////////////////////////////////////////////
//using

using T_DATA=System.String;

////////////////////////////////////////////////////////////////////////////////
//class TestSet___000

public static class TestSet___000
{
 private const string c_NameOf__TABLE="TEST_MODIFY_ROW";

 private const string c_NameOf__COL_DATA="COL_VARCHAR_10";

 //-----------------------------------------------------------------------
 private sealed class MyContext:TestBaseDbContext
 {
  [Table(c_NameOf__TABLE)]
  public sealed class TEST_RECORD
  {
   [Key]
   [Column("TEST_ID")]
   public System.Int64? TEST_ID { get; set; }

   [Column(c_NameOf__COL_DATA, TypeName="VARCHAR(10)")]
   public T_DATA DATA { get; set; }
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
 public static void Test___field__null___ByDBMS()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64? testID=Helper__InsertRow(db,"ABC\0123");

     var recs=db.testTable.Where(r => r.DATA.Contains(null) && r.TEST_ID==testID);

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (POSITION(NULL, ").N("t",c_NameOf__COL_DATA).T(") > 0) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___field__null___ByDBMS

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___null__field___ByDBMS()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64? testID=Helper__InsertRow(db,"ABC\0123");

     var recs=db.testTable.Where(r => ((string)null).Contains(r.DATA) && r.TEST_ID==testID);

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (POSITION(").N("t",c_NameOf__COL_DATA).T(", NULL) > 0) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___null__field___ByDBMS

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___field__text___ByDBMS()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64? testID=Helper__InsertRow(db,"ABC\0123");

     {
      var recs=db.testTable.Where(r => r.DATA.Contains("BC") && r.TEST_ID==testID);

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
        ("ABC\0123",
         r.DATA);
      }//foreach r

      db.CheckTextOfLastExecutedCommand
       (new TestSqlTemplate()
         .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
         .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
         .T("WHERE (POSITION(_utf8 'BC', ").N("t",c_NameOf__COL_DATA).T(") > 0) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

      Assert.AreEqual
       (1,
        nRecs);
     }//local

     //-------------------------------------------------------------------
     {
      var recs=db.testTable.Where(r => r.DATA.Contains("C\01") && r.TEST_ID==testID);

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
        ("ABC\0123",
         r.DATA);
      }//foreach r

      db.CheckTextOfLastExecutedCommand
       (new TestSqlTemplate()
         .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
         .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
         .T("WHERE (POSITION(_utf8 'C'||_utf8 x'00'||_utf8 '1', ").N("t",c_NameOf__COL_DATA).T(") > 0) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

      Assert.AreEqual
       (1,
        nRecs);
     }//local
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___field__text___ByDBMS

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___text__field___ByDBMS()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64? testID=Helper__InsertRow(db,"BC");

     {
      var recs=db.testTable.Where(r => "ABC\0123".Contains(r.DATA) && r.TEST_ID==testID);

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
        ("BC",
         r.DATA);
      }//foreach r

      db.CheckTextOfLastExecutedCommand
       (new TestSqlTemplate()
         .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
         .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
         .T("WHERE (POSITION(").N("t",c_NameOf__COL_DATA).T(", _utf8 'ABC'||_utf8 x'00'||_utf8 '123') > 0) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

      Assert.AreEqual
       (1,
        nRecs);
     }//local
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___field__text___ByDBMS

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___field__field___ByDBMS()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64? testID=Helper__InsertRow(db,"BC");

     {
      var recs=db.testTable.Where(r => r.DATA.Contains(r.DATA) && r.TEST_ID==testID);

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
        ("BC",
         r.DATA);
      }//foreach r

      db.CheckTextOfLastExecutedCommand
       (new TestSqlTemplate()
         .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
         .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
         .T("WHERE (POSITION(").N("t",c_NameOf__COL_DATA).T(", ").N("t",c_NameOf__COL_DATA).T(") > 0) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

      Assert.AreEqual
       (1,
        nRecs);
     }//local
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___field__text___ByDBMS

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___Expr__field___ByDBMS()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64? testID=Helper__InsertRow(db,"ABC\0123");

     //-------------------------------------------------------------------
     {
      var recs=db.testTable.Where(r => r.DATA.Replace("C\0","VZN").Contains("BVZN1") && r.TEST_ID==testID);

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
        ("ABC\0123",
         r.DATA);
      }//foreach r

      db.CheckTextOfLastExecutedCommand
       (new TestSqlTemplate()
         .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
         .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
         .T("WHERE (POSITION(_utf8 'BVZN1', REPLACE(").N("t",c_NameOf__COL_DATA).T(", _utf8 'C'||_utf8 x'00', _utf8 'VZN')) > 0) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

      Assert.AreEqual
       (1,
        nRecs);
     }//local
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___Expr__field___ByDBMS

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___ExprWithParam__field___ByDBMS()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64? testID=Helper__InsertRow(db,"ABC\0123");

     //-------------------------------------------------------------------
     T_DATA vv="VZN";

     var recs=db.testTable.Where(r => r.DATA.Replace("C",vv).Contains("BVZN\01") && r.TEST_ID==testID);

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
       ("ABC\0123",
        r.DATA);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (POSITION(_utf8 'BVZN'||_utf8 x'00'||_utf8 '1', REPLACE(").N("t",c_NameOf__COL_DATA).T(", _utf8 'C', ").P_TXT("__vv_0").T(")) > 0) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___ExprWithParam__field___ByDBMS

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___ExprWithParamZ__field___ByDBMS()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64? testID=Helper__InsertRow(db,"ABC\0123");

     //-------------------------------------------------------------------
     T_DATA vv="\0C";

     var recs=db.testTable.Where(r => r.DATA.Replace("C\0",vv).Contains("B\0C1") && r.TEST_ID==testID);

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
       ("ABC\0123",
        r.DATA);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (POSITION(_utf8 'B'||_utf8 x'00'||_utf8 'C1', REPLACE(").N("t",c_NameOf__COL_DATA).T(", _utf8 'C'||_utf8 x'00', ").P_TXT("__vv_0").T(")) > 0) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___ExprWithParamZ__field___ByDBMS

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___field__Expr___ByDBMS()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64? testID=Helper__InsertRow(db,"ABC\0123");

     //-------------------------------------------------------------------
     var recs=db.testTable.Where(r => r.DATA.Contains(r.DATA.Replace("ABC\0123","C\01")) && r.TEST_ID==testID);

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
       ("ABC\0123",
        r.DATA);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (POSITION(REPLACE(").N("t",c_NameOf__COL_DATA).T(", _utf8 'ABC'||_utf8 x'00'||_utf8 '123', _utf8 'C'||_utf8 x'00'||_utf8 '1'), ").N("t",c_NameOf__COL_DATA).T(") > 0) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___field__Expr___ByDBMS

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___field__ExprWithParam___ByDBMS()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64? testID=Helper__InsertRow(db,"ABC\0123");

     //-------------------------------------------------------------------
     T_DATA vv="";

     var recs=db.testTable.Where(r => r.DATA.Contains(r.DATA.Replace("ABC",vv)) && r.TEST_ID==testID);

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
       ("ABC\0123",
        r.DATA);
     }//foreach r

     Assert.AreEqual
      (1,
       nRecs);

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (POSITION(REPLACE(").N("t",c_NameOf__COL_DATA).T(", _utf8 'ABC', ").P_TXT("__vv_0").T("), ").N("t",c_NameOf__COL_DATA).T(") > 0) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___field__ExprWithParam___ByDBMS

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___field__ExprWithParamZ___ByDBMS()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64? testID=Helper__InsertRow(db,"ABC\0123");

     //-------------------------------------------------------------------
     T_DATA vv="C\01";

     var recs=db.testTable.Where(r => r.DATA.Contains(r.DATA.Replace("ABC\0123",vv)) && r.TEST_ID==testID);

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
       ("ABC\0123",
        r.DATA);
     }//foreach r

     Assert.AreEqual
      (1,
       nRecs);

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (POSITION(REPLACE(").N("t",c_NameOf__COL_DATA).T(", _utf8 'ABC'||_utf8 x'00'||_utf8 '123', ").P_TXT("__vv_0").T("), ").N("t",c_NameOf__COL_DATA).T(") > 0) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___field__ExprWithParamZ___ByDBMS

 //-----------------------------------------------------------------------
 private static System.Int64 Helper__InsertRow(MyContext db,
                                               T_DATA    valueOfData)
 {
  var newRecord=new MyContext.TEST_RECORD();

  newRecord.DATA=valueOfData;

  db.testTable.Add(newRecord);

  db.SaveChanges();

  db.CheckTextOfLastExecutedCommand
   (new TestSqlTemplate()
     .T("INSERT INTO ").N(c_NameOf__TABLE).T(" (").N(c_NameOf__COL_DATA).T(")").EOL()
     .T("VALUES (").P("p0").T(")").EOL()
     .T("RETURNING ").N("TEST_ID").EOL()
     .T("INTO ").P("p1").T(";"));

  Assert.IsTrue
   (newRecord.TEST_ID.HasValue);

  Console.WriteLine("TEST_ID: {0}",newRecord.TEST_ID.Value);

  return newRecord.TEST_ID.Value;
 }//Helper__InsertRow
};//class TestSet___000

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.String.SET_001.STD.Contains

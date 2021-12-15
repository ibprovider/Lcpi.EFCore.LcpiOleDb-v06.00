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

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.String.SET_001.STD.IsNullOrEmpty{
////////////////////////////////////////////////////////////////////////////////
//using

using T_DATA=System.String;

////////////////////////////////////////////////////////////////////////////////
//class TestSet___VARCHAR

public static class TestSet___VARCHAR
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
 public static void Test___fieldWithSpaces___ByDBMS()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64 testID=Helper__InsertRow(db,"  ");

     var recs=db.testTable.Where(r => string.IsNullOrEmpty(r.DATA) && r.TEST_ID==testID);

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE ((").N("t",c_NameOf__COL_DATA).IS_NULL().T(") OR (OCTET_LENGTH(").N("t",c_NameOf__COL_DATA).T(") = 0)) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___fieldWithSpaces___ByDBMS

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___fieldWithEmptyStr___ByDBMS()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64 testID=Helper__InsertRow(db,"");

     {
      var recs=db.testTable.Where(r => string.IsNullOrEmpty(r.DATA) && r.TEST_ID==testID);

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
        ("",
         r.DATA);
      }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE ((").N("t",c_NameOf__COL_DATA).IS_NULL().T(") OR (OCTET_LENGTH(").N("t",c_NameOf__COL_DATA).T(") = 0)) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

      Assert.AreEqual
       (1,
        nRecs);
     }//local
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___fieldWithEmptyStr___ByDBMS

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___fieldWithNULL___ByDBMS()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64 testID=Helper__InsertRow(db,null);

     {
      var recs=db.testTable.Where(r => string.IsNullOrEmpty(r.DATA) && r.TEST_ID==testID);

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

       Assert.IsNull
        (r.DATA);
      }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE ((").N("t",c_NameOf__COL_DATA).IS_NULL().T(") OR (OCTET_LENGTH(").N("t",c_NameOf__COL_DATA).T(") = 0)) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

      Assert.AreEqual
       (1,
        nRecs);
     }//local
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___fieldWithNULL___ByDBMS

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___fieldWithTextZ___ByDBMS()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64 testID=Helper__InsertRow(db,"\0");

     var recs=db.testTable.Where(r => string.IsNullOrEmpty(r.DATA) && r.TEST_ID==testID);

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE ((").N("t",c_NameOf__COL_DATA).IS_NULL().T(") OR (OCTET_LENGTH(").N("t",c_NameOf__COL_DATA).T(") = 0)) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___fieldWithTextZ___ByDBMS

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___VarWithEmptyStr___ByEF()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64 testID=Helper__InsertRow(db,"  ");

     string v="";

     var recs=db.testTable.Where(r => string.IsNullOrEmpty(v) && r.TEST_ID==testID);

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
       ("  ",
        r.DATA);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE ").N("t","TEST_ID").T(" = ").P_ID("__testID_0"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___VarWithEmptyStr___ByEF

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___TextWithEmptyStr___ByEF()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64 testID=Helper__InsertRow(db,"  ");

     var recs=db.testTable.Where(r => string.IsNullOrEmpty("") && r.TEST_ID==testID);

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
       ("  ",
        r.DATA);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE ").N("t","TEST_ID").T(" = ").P_ID("__testID_0"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___TextWithEmptyStr___ByEF

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___concatFieldAndEmptyText___ByDBMS()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64 testID=Helper__InsertRow(db,"");

     var recs=db.testTable.Where(r => string.IsNullOrEmpty(r.DATA+"") && r.TEST_ID==testID);

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
       ("",
        r.DATA);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (OCTET_LENGTH(").N_TXT_NP("t",c_NameOf__COL_DATA).T("||_utf8 '') = 0) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___concatFieldAndEmptyText___ByDBMS

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___concatFieldAndTextZ___ByDBMS()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64 testID=Helper__InsertRow(db,"");

     var recs=db.testTable.Where(r => string.IsNullOrEmpty(r.DATA+"\0") && r.TEST_ID==testID);

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (OCTET_LENGTH(").N_TXT_NP("t",c_NameOf__COL_DATA).T("||_utf8 x'00') = 0) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___concatFieldAndTextZ___ByDBMS

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___ExprE___ByDBMS()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //test
    using(var cmd=new xdb.OleDbCommand("",cn,tr))
    {
     cmd.CommandText="select ID from DUAL where REPLACE(NULL,'d','b') IS NULL";

     using(var reader=cmd.ExecuteReader())
     {
      Assert.IsTrue(reader.Read());

      Assert.AreEqual(1,reader[0]);
     }//using tr
    }//using cmd

    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64 testID=Helper__InsertRow(db,"123\0ABC");

     var recs=db.testTable.Where(r => string.IsNullOrEmpty(r.DATA.Replace("123\0ABC","")) && r.TEST_ID==testID);

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
       ("123\0ABC",
        r.DATA);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE ((").N("t",c_NameOf__COL_DATA).IS_NULL().T(") OR (OCTET_LENGTH(REPLACE(").N("t",c_NameOf__COL_DATA).T(", _utf8 '123'||_utf8 x'00'||_utf8 'ABC', _utf8 '')) = 0)) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___ExprE___ByDBMS

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___ExprN___ByDBMS()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //test
    using(var cmd=new xdb.OleDbCommand("",cn,tr))
    {
     cmd.CommandText="select ID from DUAL where REPLACE('abc','d',NULL) IS NULL";

     using(var reader=cmd.ExecuteReader())
     {
      Assert.IsTrue(reader.Read());

      Assert.AreEqual(1,reader[0]);
     }//using tr
    }//using cmd

    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64 testID=Helper__InsertRow(db,"123\0ABC");

     var recs=db.testTable.Where(r => string.IsNullOrEmpty(r.DATA.Replace("123\0ABC",null)) && r.TEST_ID==testID);

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
       ("123\0ABC",
        r.DATA);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE ").N("t","TEST_ID").T(" = ").P_ID("__testID_0"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___ExprN___ByDBMS

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___ExprN2___ByDBMS()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //test
    using(var cmd=new xdb.OleDbCommand("",cn,tr))
    {
     cmd.CommandText="select ID from DUAL where REPLACE('abc','d',NULL) IS NULL";

     using(var reader=cmd.ExecuteReader())
     {
      Assert.IsTrue(reader.Read());

      Assert.AreEqual(1,reader[0]);
     }//using tr
    }//using cmd

    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64 testID=Helper__InsertRow(db,"123\0ABC");

     T_DATA vv="abv";

     var recs=db.testTable.Where(r => string.IsNullOrEmpty(r.DATA.Replace("123\0ABC",vv+null)) && r.TEST_ID==testID);

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE ((").N("t",c_NameOf__COL_DATA).IS_NULL().T(") OR (OCTET_LENGTH(REPLACE(").N("t",c_NameOf__COL_DATA).T(", _utf8 '123'||_utf8 x'00'||_utf8 'ABC', ").P_TXT("__Exec_V_V_0").T(")) = 0)) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___ExprN2___ByDBMS

 //-----------------------------------------------------------------------
#if BUILD_CONF__TESTS_FOR_DBNULL

 [Test]
 public static void Test___ExprN3___ByDBMS()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //test
    using(var cmd=new xdb.OleDbCommand("",cn,tr))
    {
     cmd.CommandText="select ID from DUAL where REPLACE('abc','d',NULL) IS NULL";

     using(var reader=cmd.ExecuteReader())
     {
      Assert.IsTrue(reader.Read());

      Assert.AreEqual(1,reader[0]);
     }//using tr
    }//using cmd

    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64 testID=Helper__InsertRow(db,"123\0ABC");

     var recs=db.testTable.Where(r => string.IsNullOrEmpty(r.DATA.Replace("123ABC","abv"+DBNull.Value)) && r.TEST_ID==testID);

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
       ("123\0ABC",
        r.DATA);
     }//foreach r

     //db.log.CheckTextOfLastExecutedCommand_F__tQ
     // ("SELECT {0}.\"TEST_ID\", {0}.\"COL_VARCHAR_10\"\n"
     // +"FROM \"TEST_MODIFY_ROW\" AS {0}\n"
     // +"WHERE (REPLACE({0}.\"COL_VARCHAR_10\", _utf8 '123'||_utf8 x'00'||_utf8 'ABC', NULL) "
     //     +"IS NULL OR (OCTET_LENGTH(REPLACE({0}.\"COL_VARCHAR_10\", _utf8 '123'||_utf8 x'00'||_utf8 'ABC', NULL)) = 0)) "
     //     +"AND ({0}.\"TEST_ID\" = :__testID_0)");

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (").N("t",c_NameOf__COL_DATA).IS_NULL().T(") AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___ExprN3___ByDBMS

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___ExprN3r___ByDBMS()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //test
    using(var cmd=new xdb.OleDbCommand("",cn,tr))
    {
     cmd.CommandText="select ID from DUAL where REPLACE('abc','d',NULL) IS NULL";

     using(var reader=cmd.ExecuteReader())
     {
      Assert.IsTrue(reader.Read());

      Assert.AreEqual(1,reader[0]);
     }//using tr
    }//using cmd

    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64 testID=Helper__InsertRow(db,"123\0ABC");

     var recs=db.testTable.Where(r => string.IsNullOrEmpty(r.DATA.Replace("123ABC",DBNull.Value+"abv")) && r.TEST_ID==testID);

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
       ("123\0ABC",
        r.DATA);
     }//foreach r

     //db.log.CheckTextOfLastExecutedCommand_F__tQ
     // ("SELECT {0}.\"TEST_ID\", {0}.\"COL_VARCHAR_10\"\n"
     // +"FROM \"TEST_MODIFY_ROW\" AS {0}\n"
     // +"WHERE (REPLACE({0}.\"COL_VARCHAR_10\", _utf8 '123'||_utf8 x'00'||_utf8 'ABC', NULL) "
     //     +"IS NULL OR (OCTET_LENGTH(REPLACE({0}.\"COL_VARCHAR_10\", _utf8 '123'||_utf8 x'00'||_utf8 'ABC', NULL)) = 0)) "
     //     +"AND ({0}.\"TEST_ID\" = :__testID_0)");

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (").N("t",c_NameOf__COL_DATA).IS_NULL().T(") AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___ExprN3___ByDBMS

#endif //BUILD_CONF__TESTS_FOR_DBNULL

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
};//class TestSet___VARCHAR

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.String.SET_001.STD.IsNullOrEmpty

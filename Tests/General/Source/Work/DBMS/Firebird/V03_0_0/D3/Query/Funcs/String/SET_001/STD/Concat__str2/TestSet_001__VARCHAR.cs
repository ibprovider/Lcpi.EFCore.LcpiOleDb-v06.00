////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 25.12.2020.
//
// string.Concat(str1, str2)
//
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.String.SET_001.STD.Concat__str2{
////////////////////////////////////////////////////////////////////////////////
//using

using T_DATA=System.String;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_001__VARCHAR

public static class TestSet_001__VARCHAR
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
 public static void Test_001__field_field()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_DATA c_data="ABC\0123";

     System.Int64 testID=Helper__InsertRow(db,c_data);

     var recs=db.testTable.Where(r => string.Concat(r.DATA,r.DATA)=="ABC\0123ABC\0123" && r.TEST_ID==testID);

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
        .T("WHERE ((").N_TXT_NP("t",c_NameOf__COL_DATA).T("||").N_TXT_NP("t",c_NameOf__COL_DATA).T(") = _utf8 'ABC'||_utf8 x'00'||_utf8 '123ABC'||_utf8 x'00'||_utf8 '123') AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_001__field_field

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002__fieldN_fieldN()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_DATA c_data=null;

     System.Int64 testID=Helper__InsertRow(db,c_data);

     var recs=db.testTable.Where(r => string.Concat(r.DATA,r.DATA)=="ABC\0123ABC\0123" && r.TEST_ID==testID);

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE ((").N_TXT_NP("t",c_NameOf__COL_DATA).T("||").N_TXT_NP("t",c_NameOf__COL_DATA).T(") = _utf8 'ABC'||_utf8 x'00'||_utf8 '123ABC'||_utf8 x'00'||_utf8 '123') AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_002__fieldN_fieldN

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_101__null_field()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_DATA c_data=null;

     System.Int64 testID=Helper__InsertRow(db,c_data);

     var recs=db.testTable.Where(r => string.Concat(null,r.DATA)=="ABC\0123" && r.TEST_ID==testID);

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE ((_utf8 ''||").N_TXT_NP("t",c_NameOf__COL_DATA).T(") = _utf8 'ABC'||_utf8 x'00'||_utf8 '123') AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_101__null_field

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_102__field_null()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_DATA c_data=null;

     System.Int64 testID=Helper__InsertRow(db,c_data);

     var recs=db.testTable.Where(r => string.Concat(r.DATA,null)=="ABC\0123" && r.TEST_ID==testID);

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE ((").N_TXT_NP("t",c_NameOf__COL_DATA).T("||_utf8 '') = _utf8 'ABC'||_utf8 x'00'||_utf8 '123') AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_102__field_null

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_201__str_field()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_DATA c_data="ABC\0123";

     System.Int64 testID=Helper__InsertRow(db,c_data);

     var recs=db.testTable.Where(r => string.Concat("--",r.DATA)=="--ABC\0123" && r.TEST_ID==testID);

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
        .T("WHERE ((_utf8 '--'||").N_TXT_NP("t",c_NameOf__COL_DATA).T(") = _utf8 '--ABC'||_utf8 x'00'||_utf8 '123') AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_201__str_field

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_202__field_str()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_DATA c_data="ABC\0123";

     System.Int64 testID=Helper__InsertRow(db,c_data);

     var recs=db.testTable.Where(r => string.Concat(r.DATA,"--")=="ABC\0123--" && r.TEST_ID==testID);

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
        .T("WHERE ((").N_TXT_NP("t",c_NameOf__COL_DATA).T("||_utf8 '--') = _utf8 'ABC'||_utf8 x'00'||_utf8 '123--') AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_202__field_str

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_301__param_field()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_DATA c_data="ABC\0123";

     System.Int64 testID=Helper__InsertRow(db,c_data);

     T_DATA vv="--";

     var recs=db.testTable.Where(r => string.Concat(vv,r.DATA)=="--ABC\0123" && r.TEST_ID==testID);

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
        .T("WHERE ((").P_TXT("__vv_0").T("||").N_TXT_NP("t",c_NameOf__COL_DATA).T(") = _utf8 '--ABC'||_utf8 x'00'||_utf8 '123') AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_301__param_field

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_302__field_param()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_DATA c_data="ABC\0123";

     System.Int64 testID=Helper__InsertRow(db,c_data);

     T_DATA vv="--";

     var recs=db.testTable.Where(r => string.Concat(r.DATA,vv)=="ABC\0123--" && r.TEST_ID==testID);

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
        .T("WHERE ((").N_TXT_NP("t",c_NameOf__COL_DATA).T("||").P_TXT("__vv_0").T(") = _utf8 'ABC'||_utf8 x'00'||_utf8 '123--') AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_302__field_param

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_401__paramN_field()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_DATA c_data="ABC\0123";

     System.Int64 testID=Helper__InsertRow(db,c_data);

     T_DATA vv=null;

     var recs=db.testTable.Where(r => string.Concat(vv,r.DATA)=="--ABC\0123" && r.TEST_ID==testID);

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE ((_utf8 ''||").N_TXT_NP("t",c_NameOf__COL_DATA).T(") = _utf8 '--ABC'||_utf8 x'00'||_utf8 '123') AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_401__paramN_field

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_402__field_paramN()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_DATA c_data="ABC\0123";

     System.Int64 testID=Helper__InsertRow(db,c_data);

     T_DATA vv=null;

     var recs=db.testTable.Where(r => string.Concat(r.DATA,vv)=="ABC\0123--" && r.TEST_ID==testID);

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE ((").N_TXT_NP("t",c_NameOf__COL_DATA).T("||_utf8 '') = _utf8 'ABC'||_utf8 x'00'||_utf8 '123--') AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_402__field_paramN

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_501__paramN_field___is_null()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_DATA c_data="ABC\0123";

     System.Int64 testID=Helper__InsertRow(db,c_data);

     T_DATA vv=null;

     var recs=db.testTable.Where(r => string.Concat(vv,r.DATA)==null && r.TEST_ID==testID);

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE FALSE"));
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_501__paramN_field___is_null

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_502__field_paramN___is_null()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_DATA c_data="ABC\0123";

     System.Int64 testID=Helper__InsertRow(db,c_data);

     T_DATA vv=null;

     var recs=db.testTable.Where(r => string.Concat(r.DATA,vv)==null && r.TEST_ID==testID);

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE FALSE"));
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_502__field_paramN___is_null

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_Expr_01()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_DATA c_data="ABC\0123";

     System.Int64 testID=Helper__InsertRow(db,c_data);

     var recs=db.testTable.Where(r => string.Concat(r.DATA,"--"+r.DATA+"++")=="ABC\0123--ABC\0123++" && r.TEST_ID==testID);

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
        .T("WHERE ((").N_TXT_NP("t",c_NameOf__COL_DATA).T("||_utf8 '--'||").N_TXT_NP("t",c_NameOf__COL_DATA).T("||_utf8 '++') = _utf8 'ABC'||_utf8 x'00'||_utf8 '123--ABC'||_utf8 x'00'||_utf8 '123++') AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_Expr_01

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_Expr_02()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_DATA c_data="ABC\0123";

     System.Int64 testID=Helper__InsertRow(db,c_data);

     string vv="++";

     var recs=db.testTable.Where(r => string.Concat(r.DATA,"--"+r.DATA+vv)=="ABC\0123--ABC\0123++" && r.TEST_ID==testID);

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
        .T("WHERE ((").N_TXT_NP("t",c_NameOf__COL_DATA).T("||_utf8 '--'||").N_TXT_NP("t",c_NameOf__COL_DATA).T("||").P_TXT("__vv_0").T(") = _utf8 'ABC'||_utf8 x'00'||_utf8 '123--ABC'||_utf8 x'00'||_utf8 '123++') AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_Expr_02

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_Expr_03()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_DATA c_data="ABC\0123";

     System.Int64 testID=Helper__InsertRow(db,c_data);

     System.Int32 vv=7;

     var recs=db.testTable.Where(r => string.Concat(0+r.DATA+4+5,6+r.DATA+vv)=="0ABC\0123456ABC\01237" && r.TEST_ID==testID);

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
        .T("WHERE ((0||").N_TXT_NP("t",c_NameOf__COL_DATA).T("||4||5||6||").N_TXT_NP("t",c_NameOf__COL_DATA).T("||").P_I4("__vv_0").T(") = _utf8 '0ABC'||_utf8 x'00'||_utf8 '123456ABC'||_utf8 x'00'||_utf8 '1237') AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_Expr_03

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_Expr_04()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_DATA c_data="ABC\0123";

     System.Int64 testID=Helper__InsertRow(db,c_data);

     System.Int32 vv=7;

     var recs=db.testTable.Where(r => string.Concat(0+r.DATA+(4+5),6+r.DATA+vv)=="0ABC\012396ABC\01237" && r.TEST_ID==testID);

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
        .T("WHERE ((0||").N_TXT_NP("t",c_NameOf__COL_DATA).T("||9||6||").N_TXT_NP("t",c_NameOf__COL_DATA).T("||").P_I4("__vv_0").T(") = _utf8 '0ABC'||_utf8 x'00'||_utf8 '12396ABC'||_utf8 x'00'||_utf8 '1237') AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_Expr_04

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_Expr_05()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_DATA c_data="ABC\0123";

     System.Int64 testID=Helper__InsertRow(db,c_data);

     System.Int32 vv1=4;
     System.Int32 vv2=7;

     var recs=db.testTable.Where(r => string.Concat(0+r.DATA+(vv1+5),6+r.DATA+vv2)=="0ABC\012396ABC\01237" && r.TEST_ID==testID);

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
        .T("WHERE ((0||").N_TXT_NP("t",c_NameOf__COL_DATA).T("||").P_I8("__Exec_V_V_0").T("||6||").N_TXT_NP("t",c_NameOf__COL_DATA).T("||").P_I4("__vv2_1").T(") = _utf8 '0ABC'||_utf8 x'00'||_utf8 '12396ABC'||_utf8 x'00'||_utf8 '1237') AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_2").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_Expr_05

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
};//class TestSet_001__VARCHAR

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.String.SET_001.STD.Concat__str2

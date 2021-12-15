////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 23.09.2018.
//
// <field+"text">.Substring(<string>,<string>)
//
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.String.SET_001.STD.Replace__str__str{
////////////////////////////////////////////////////////////////////////////////
//using

using T_DATA=System.String;

////////////////////////////////////////////////////////////////////////////////
//class TestSet___Expr

public static class TestSet___Expr
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
 public static void Test___Text__Text___ByDBMS()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64 testID=Helper__InsertRow(db,"ASDFGH123");

     var recs=db.testTable.Where(r => (r.DATA+" QWSDF\0Y").Replace("SDF","FDS")=="AFDSGH123 QWFDS\0Y" && r.TEST_ID==testID);

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
       ("ASDFGH123",
        r.DATA);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (REPLACE(").N_TXT_NP("t",c_NameOf__COL_DATA).T("||_utf8 ' QWSDF'||_utf8 x'00'||_utf8 'Y', _utf8 'SDF', _utf8 'FDS') = _utf8 'AFDSGH123 QWFDS'||_utf8 x'00'||_utf8 'Y') AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___Text__Text___ByDBMS

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___Text2__Text___ByDBMS()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64 testID=Helper__InsertRow(db,"1AS2AS3");

     var recs=db.testTable.Where(r => (r.DATA+" QWEASY").Replace("AS","_|")=="1_|2_|3 QWE_|Y" && r.TEST_ID==testID);

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
       ("1AS2AS3",
        r.DATA);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (REPLACE(").N_TXT_NP("t",c_NameOf__COL_DATA).T("||_utf8 ' QWEASY', _utf8 'AS', _utf8 '_|') = _utf8 '1_|2_|3 QWE_|Y') AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___Text2__Text___ByDBMS

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___TextZ__TextZ___ByDBMS()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64 testID=Helper__InsertRow(db,"ASD\0123");

     var recs=db.testTable.Where(r => (r.DATA+" QWERDDDDDDDDD\01").Replace("D\01","\0ZX")=="AS\0ZX23 QWERDDDDDDDD\0ZX" && r.TEST_ID==testID);

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
       ("ASD\0123",
        r.DATA);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (REPLACE(").N_TXT_NP("t",c_NameOf__COL_DATA).T("||_utf8 ' QWERDDDDDDDDD'||_utf8 x'00'||_utf8 '1', _utf8 'D'||_utf8 x'00'||_utf8 '1', _utf8 x'00'||_utf8 'ZX') = _utf8 'AS'||_utf8 x'00'||_utf8 'ZX23 QWERDDDDDDDD'||_utf8 x'00'||_utf8 'ZX') AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___TextZ__TextZ___ByDBMS

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___ParamZ__TextZ___ByDBMS()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64 testID=Helper__InsertRow(db,"ASD\0123");

     T_DATA vv1="D\01";

     var recs=db.testTable.Where(r => (r.DATA+" QWERDDDDDDDDD\01").Replace(vv1,"\0ZX")=="AS\0ZX23 QWERDDDDDDDD\0ZX" && r.TEST_ID==testID);

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
       ("ASD\0123",
        r.DATA);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (REPLACE(").N_TXT_NP("t",c_NameOf__COL_DATA).T("||_utf8 ' QWERDDDDDDDDD'||_utf8 x'00'||_utf8 '1', ").P_TXT("__vv1_0").T(", _utf8 x'00'||_utf8 'ZX') = _utf8 'AS'||_utf8 x'00'||_utf8 'ZX23 QWERDDDDDDDD'||_utf8 x'00'||_utf8 'ZX') AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___ParamZ__TextZ___ByDBMS

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___TextZ__ParamZ___ByDBMS()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64 testID=Helper__InsertRow(db,"ASD\0123");

     T_DATA vv2="\0ZX";

     var recs=db.testTable.Where(r => (r.DATA+" QWERDDDDDDDDD\01").Replace("D\01",vv2)=="AS\0ZX23 QWERDDDDDDDD\0ZX" && r.TEST_ID==testID);

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
       ("ASD\0123",
        r.DATA);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (REPLACE(").N_TXT_NP("t",c_NameOf__COL_DATA).T("||_utf8 ' QWERDDDDDDDDD'||_utf8 x'00'||_utf8 '1', _utf8 'D'||_utf8 x'00'||_utf8 '1', ").P_TXT("__vv2_0").T(") = _utf8 'AS'||_utf8 x'00'||_utf8 'ZX23 QWERDDDDDDDD'||_utf8 x'00'||_utf8 'ZX') AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___TextZ__ParamZ___ByDBMS

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___ParamZ__ParamZ___ByDBMS()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64 testID=Helper__InsertRow(db,"ASD\0123");

     T_DATA vv1="D\01";
     T_DATA vv2="\0ZX";

     var recs=db.testTable.Where(r => (r.DATA+" QWERDDDDDDDDD\01").Replace(vv1,vv2)=="AS\0ZX23 QWERDDDDDDDD\0ZX" && r.TEST_ID==testID);

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
       ("ASD\0123",
        r.DATA);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (REPLACE(").N_TXT_NP("t",c_NameOf__COL_DATA).T("||_utf8 ' QWERDDDDDDDDD'||_utf8 x'00'||_utf8 '1', ").P_TXT("__vv1_0").T(", ").P_TXT("__vv2_1").T(") = _utf8 'AS'||_utf8 x'00'||_utf8 'ZX23 QWERDDDDDDDD'||_utf8 x'00'||_utf8 'ZX') AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_2").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___ParamZ__ParamZ___ByDBMS

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___Field__Field___ByDBMS()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64 testID=Helper__InsertRow(db,"ASDFGH123");

     var recs=db.testTable.Where(r => (r.DATA+" QASDFGH123Y").Replace(r.DATA,r.DATA)=="ASDFGH123 QASDFGH123Y" && r.TEST_ID==testID);

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
       ("ASDFGH123",
        r.DATA);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (REPLACE(").N_TXT_NP("t",c_NameOf__COL_DATA).T("||_utf8 ' QASDFGH123Y', ").N("t",c_NameOf__COL_DATA).T(", ").N("t",c_NameOf__COL_DATA).T(") = _utf8 'ASDFGH123 QASDFGH123Y') AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___Field__Field___ByDBMS

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___concatFieldAndE__Field___ByDBMS()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64 testID=Helper__InsertRow(db,"ASDFGH123");

     var recs=db.testTable.Where(r => (r.DATA+" QASDFGH123_YY").Replace(r.DATA+"",r.DATA)=="ASDFGH123 QASDFGH123_YY" && r.TEST_ID==testID);

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
       ("ASDFGH123",
        r.DATA);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (REPLACE(").N_TXT_NP("t",c_NameOf__COL_DATA).T("||_utf8 ' QASDFGH123_YY', ").N_TXT_NP("t",c_NameOf__COL_DATA).T("||_utf8 '', ").N("t",c_NameOf__COL_DATA).T(") = _utf8 'ASDFGH123 QASDFGH123_YY') AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___concatFieldAndE__Field___ByDBMS

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___concatFieldAndZ__Text___ByDBMS()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64 testID=Helper__InsertRow(db,"ASDFGH123");

     var recs=db.testTable.Where(r => (r.DATA+" ASDFGH123\0Z").Replace(r.DATA+"\0","1")=="ASDFGH123 1Z" && r.TEST_ID==testID);

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
       ("ASDFGH123",
        r.DATA);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (REPLACE(").N_TXT_NP("t",c_NameOf__COL_DATA).T("||_utf8 ' ASDFGH123'||_utf8 x'00'||_utf8 'Z', ").N_TXT_NP("t",c_NameOf__COL_DATA).T("||_utf8 x'00', _utf8 '1') = _utf8 'ASDFGH123 1Z') AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___concatFieldAndZ__Text___ByDBMS

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___concatFieldAndParamZ__Text___ByDBMS()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64 testID=Helper__InsertRow(db,"ASDFGH123");

     T_DATA vv="\0";

     var recs=db.testTable.Where(r => (r.DATA+" ASDFGH123\0Z").Replace(r.DATA+vv,"1")=="ASDFGH123 1Z" && r.TEST_ID==testID);

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
       ("ASDFGH123",
        r.DATA);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (REPLACE(").N_TXT_NP("t",c_NameOf__COL_DATA).T("||_utf8 ' ASDFGH123'||_utf8 x'00'||_utf8 'Z', ").N_TXT_NP("t",c_NameOf__COL_DATA).T("||").P_TXT("__vv_0").T(", _utf8 '1') = _utf8 'ASDFGH123 1Z') AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___concatFieldAndParamZ__Text___ByDBMS

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___concatFieldAndParam__Text___ByDBMS()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64 testID=Helper__InsertRow(db,"ASDFGH123");

     T_DATA vv="1";

     var recs=db.testTable.Where(r => (r.DATA+" ASDFGH1231Y").Replace(r.DATA+vv,"_")=="ASDFGH123 _Y" && r.TEST_ID==testID);

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
       ("ASDFGH123",
        r.DATA);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (REPLACE(").N_TXT_NP("t",c_NameOf__COL_DATA).T("||_utf8 ' ASDFGH1231Y', ").N_TXT_NP("t",c_NameOf__COL_DATA).T("||").P_TXT("__vv_0").T(", _utf8 '_') = _utf8 'ASDFGH123 _Y') AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___concatFieldAndParam__Text___ByDBMS

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___Field__concatFieldAndParamZ___ByDBMS()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64 testID=Helper__InsertRow(db,"ASDFGH123");

     T_DATA vv="\0";

     var recs=db.testTable.Where(r => (r.DATA+" ASDFGH123Y").Replace(r.DATA,r.DATA+vv)=="ASDFGH123\0 ASDFGH123\0Y" && r.TEST_ID==testID);

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
       ("ASDFGH123",
        r.DATA);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (REPLACE(").N_TXT_NP("t",c_NameOf__COL_DATA).T("||_utf8 ' ASDFGH123Y', ").N("t",c_NameOf__COL_DATA).T(", ").N_TXT_NP("t",c_NameOf__COL_DATA).T("||").P_TXT("__vv_0").T(") = _utf8 'ASDFGH123'||_utf8 x'00'||_utf8 ' ASDFGH123'||_utf8 x'00'||_utf8 'Y') AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___Field__concatFieldAndParamZ___ByDBMS

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___Field__concatFieldAndParam___ByDBMS()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64 testID=Helper__InsertRow(db,"ASDFGH123");

     T_DATA vv="_";

     var recs=db.testTable.Where(r => (r.DATA+" ASDFGH123Y").Replace(r.DATA,r.DATA+vv)=="ASDFGH123_ ASDFGH123_Y" && r.TEST_ID==testID);

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
       ("ASDFGH123",
        r.DATA);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (REPLACE(").N_TXT_NP("t",c_NameOf__COL_DATA).T("||_utf8 ' ASDFGH123Y', ").N("t",c_NameOf__COL_DATA).T(", ").N_TXT_NP("t",c_NameOf__COL_DATA).T("||").P_TXT("__vv_0").T(") = _utf8 'ASDFGH123_ ASDFGH123_Y') AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___Field__concatFieldAndParamZ___ByDBMS

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
};//class TestSet___Expr

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.String.SET_001.STD.Replace__str__str

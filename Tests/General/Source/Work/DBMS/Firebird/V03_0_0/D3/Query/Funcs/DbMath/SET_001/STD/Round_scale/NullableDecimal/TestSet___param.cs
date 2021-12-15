////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 02.04.2019.
//
// <field>.ExtractYear()
//
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdbfunc=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DbFunctions;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.DbMath.SET_001.STD.Round_scale.NullableDecimal{
////////////////////////////////////////////////////////////////////////////////
//using

using T_DATA=System.Nullable<System.Decimal>;

////////////////////////////////////////////////////////////////////////////////
//class TestSet___param

public static class TestSet___param
{
 private const string c_NameOf__TABLE="NUM";

 private const string c_NameOf__COL_DATA="N_7_4";

 //-----------------------------------------------------------------------
 private sealed class MyContext:TestBaseDbContext
 {
  [Table(c_NameOf__TABLE)]
  public sealed class TEST_RECORD
  {
   [Key]
   [Column("TEST_ID")]
   public System.Int64? TEST_ID { get; set; }

   [Column(c_NameOf__COL_DATA,TypeName ="NUMERIC(7,4)")]
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
 public static void Test___01___ByEF()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA c_data=1.9M;

     System.Int64? testID=Helper__InsertRow(db,c_data);

     decimal? vv_src=c_data;

     var recs=db.testTable.Where(r => xdbfunc.DbMath.Round(vv_src,0)==2 && r.TEST_ID==testID);

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
       (c_data,
        r.DATA);
     }//foreach r

     var sqlt
      =new TestSqlTemplate()
        .T("SELECT ").N("n","TEST_ID").T(", ").N("n",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("n").EOL()
        .T("WHERE ").N("n","TEST_ID").T(" = ").P_ID("__testID_0");

     db.CheckTextOfLastExecutedCommand
      (sqlt);

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___01___ByEF

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___01___ByEF____r()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA c_data=1.9M;

     System.Int64? testID=Helper__InsertRow(db,c_data);

     decimal? vv_src=c_data;

     var recs=db.testTable.Where(r => 2==xdbfunc.DbMath.Round(vv_src,0) && r.TEST_ID==testID);

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
       (c_data,
        r.DATA);
     }//foreach r

     var sqlt
      =new TestSqlTemplate()
        .T("SELECT ").N("n","TEST_ID").T(", ").N("n",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("n").EOL()
        .T("WHERE ").N("n","TEST_ID").T(" = ").P_ID("__testID_0");

     db.CheckTextOfLastExecutedCommand
      (sqlt);

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___01___ByEF____r

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___01___ByEF___2()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA c_data=1.9M;

     System.Int64? testID=Helper__InsertRow(db,c_data);

     decimal? vv_src=c_data;

     var recs=db.testTable.Where(r => xdbfunc.DbMath.Round(vv_src,0)==new Nullable<int>(2) && r.TEST_ID==testID);

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
       (c_data,
        r.DATA);
     }//foreach r

     var sqlt
      =new TestSqlTemplate()
        .T("SELECT ").N("n","TEST_ID").T(", ").N("n",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("n").EOL()
        .T("WHERE ").N("n","TEST_ID").T(" = ").P_ID("__testID_0");

     db.CheckTextOfLastExecutedCommand
      (sqlt);

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___01___ByEF___2

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___02___ByEF()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA c_data=1.9M;

     System.Int64? testID=Helper__InsertRow(db,c_data);

     decimal? vv_src=c_data;

     var recs=db.testTable.Where(r => xdbfunc.DbMath.Round(xdbfunc.DbMath.Round(vv_src,0),0)==2 && r.TEST_ID==testID);

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
       (c_data,
        r.DATA);
     }//foreach r

     var sqlt
      =new TestSqlTemplate()
        .T("SELECT ").N("n","TEST_ID").T(", ").N("n",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("n").EOL()
        .T("WHERE ").N("n","TEST_ID").T(" = ").P_ID("__testID_0");

     db.CheckTextOfLastExecutedCommand
      (sqlt);

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___02___ByEF

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___03___ByEF()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA c_data=1.9M;

     System.Int64? testID=Helper__InsertRow(db,c_data);

     decimal? vv_src=c_data;

     var recs=db.testTable.Where(r => xdbfunc.DbMath.Round(2*xdbfunc.DbMath.Round(vv_src,0),0)==4 && r.TEST_ID==testID);

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
       (c_data,
        r.DATA);
     }//foreach r

     var sqlt
      =new TestSqlTemplate()
        .T("SELECT ").N("n","TEST_ID").T(", ").N("n",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("n").EOL()
        .T("WHERE ").N("n","TEST_ID").T(" = ").P_ID("__testID_0");

     db.CheckTextOfLastExecutedCommand
      (sqlt);

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___03___ByEF

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___04___ByEF()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA c_data=1.9M;

     System.Int64? testID=Helper__InsertRow(db,c_data);

     decimal? vv_src=c_data;

     var recs=db.testTable.Where(r => xdbfunc.DbMath.Round(vv_src,1)==new decimal(1.9) && r.TEST_ID==testID);

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
       (c_data,
        r.DATA);
     }//foreach r

     var sqlt
      =new TestSqlTemplate()
        .T("SELECT ").N("n","TEST_ID").T(", ").N("n",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("n").EOL()
        .T("WHERE ").N("n","TEST_ID").T(" = ").P_ID("__testID_0");

     db.CheckTextOfLastExecutedCommand
      (sqlt);

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___04___ByEF

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___04___ByEF____r()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA c_data=1.9M;

     System.Int64? testID=Helper__InsertRow(db,c_data);

     decimal? vv_src=c_data;

     var recs=db.testTable.Where(r => new decimal(1.9)==xdbfunc.DbMath.Round(vv_src,1) && r.TEST_ID==testID);

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
       (c_data,
        r.DATA);
     }//foreach r

     var sqlt
      =new TestSqlTemplate()
        .T("SELECT ").N("n","TEST_ID").T(", ").N("n",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("n").EOL()
        .T("WHERE ").N("n","TEST_ID").T(" = ").P_ID("__testID_0");

     db.CheckTextOfLastExecutedCommand
      (sqlt);

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___04___ByEF____r

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___05___ByEF()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA c_data=1.9M;

     System.Int64? testID=Helper__InsertRow(db,c_data);

     decimal? vv_src=c_data;

     var recs=db.testTable.Where(r => xdbfunc.DbMath.Round(vv_src,null)==null && r.TEST_ID==testID);

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
       (c_data,
        r.DATA);
     }//foreach r

     var sqlt
      =new TestSqlTemplate()
        .T("SELECT ").N("n","TEST_ID").T(", ").N("n",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("n").EOL()
        .T("WHERE ").N("n","TEST_ID").T(" = ").P_ID("__testID_0");

     db.CheckTextOfLastExecutedCommand
      (sqlt);

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___05___ByEF

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___05___ByEF____r()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA c_data=1.9M;

     System.Int64? testID=Helper__InsertRow(db,c_data);

     decimal? vv_src=c_data;

     var recs=db.testTable.Where(r => null==xdbfunc.DbMath.Round(vv_src,null) && r.TEST_ID==testID);

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
       (c_data,
        r.DATA);
     }//foreach r

     var sqlt
      =new TestSqlTemplate()
        .T("SELECT ").N("n","TEST_ID").T(", ").N("n",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("n").EOL()
        .T("WHERE ").N("n","TEST_ID").T(" = ").P_ID("__testID_0");

     db.CheckTextOfLastExecutedCommand
      (sqlt);

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___05___ByEF____r

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___06___ByEF()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA c_data=1.9M;

     System.Int64? testID=Helper__InsertRow(db,c_data);

     decimal? vv_src=c_data;

     int? digits=0;

     var recs=db.testTable.Where(r => xdbfunc.DbMath.Round(vv_src,digits)==2 && r.TEST_ID==testID);

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
       (c_data,
        r.DATA);
     }//foreach r

     var sqlt
      =new TestSqlTemplate()
        .T("SELECT ").N("n","TEST_ID").T(", ").N("n",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("n").EOL()
        .T("WHERE ").N("n","TEST_ID").T(" = ").P_ID("__testID_0");

     db.CheckTextOfLastExecutedCommand
      (sqlt);

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___06___ByEF

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___07___ByEF()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA c_data=1.9M;

     System.Int64? testID=Helper__InsertRow(db,c_data);

     decimal? vv_src=c_data;

     int? digits=null;

     var recs=db.testTable.Where(r => xdbfunc.DbMath.Round(vv_src,digits)==null && r.TEST_ID==testID);

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
       (c_data,
        r.DATA);
     }//foreach r

     var sqlt
      =new TestSqlTemplate()
        .T("SELECT ").N("n","TEST_ID").T(", ").N("n",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("n").EOL()
        .T("WHERE ").N("n","TEST_ID").T(" = ").P_ID("__testID_0");

     db.CheckTextOfLastExecutedCommand
      (sqlt);

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___07___ByEF

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___08___ByEF()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA c_data=154.91M;

     System.Int64? testID=Helper__InsertRow(db,c_data);

     decimal? vv_src=c_data;

     var recs=db.testTable.Where(r => xdbfunc.DbMath.Round(vv_src,-2)==new decimal(200) && r.TEST_ID==testID);

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
       (c_data,
        r.DATA);
     }//foreach r

     var sqlt
      =new TestSqlTemplate()
        .T("SELECT ").N("n","TEST_ID").T(", ").N("n",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("n").EOL()
        .T("WHERE ").N("n","TEST_ID").T(" = ").P_ID("__testID_0");

     db.CheckTextOfLastExecutedCommand
      (sqlt);

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___08___ByEF

 //Helper methods --------------------------------------------------------
 private static System.Int64 Helper__InsertRow(MyContext db,
                                               T_DATA    valueOfData)
 {
  var newRecord=new MyContext.TEST_RECORD();

  newRecord.DATA=valueOfData;

  db.testTable.Add(newRecord);

  db.SaveChanges();

  var sqlt
   =new TestSqlTemplate()
     .T("INSERT INTO ").N(c_NameOf__TABLE).T(" (").N(c_NameOf__COL_DATA).T(")").EOL()
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
};//class TestSet___param

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.DbMath.SET_001.STD.Round.NullableDecimal_NullableScale

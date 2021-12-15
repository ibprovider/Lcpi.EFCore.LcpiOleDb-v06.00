////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 13.07.2021.
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.NullableTimeOnly.SET001.STD.HasValue{
////////////////////////////////////////////////////////////////////////////////

using T_DATA  =System.Nullable<System.TimeOnly>;

using T_DATA_U=System.TimeOnly;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_001

public static class TestSet_001
{
 private const string c_NameOf__TABLE="TEST_MODIFY_ROW";

 private const string c_NameOf__COL_DATA="COL_TYPE_TIME";

 //-----------------------------------------------------------------------
 private sealed class MyContext:TestBaseDbContext
 {
  [Table(c_NameOf__TABLE)]
  public sealed class TEST_RECORD
  {
   [Key]
   [Column("TEST_ID")]
   public System.Int64? TEST_ID { get; set; }

   [Column(c_NameOf__COL_DATA)]
   public T_DATA COL_DATA { get; set; }
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
  return LocalCnHelper.CreateCn();
 }//Helper__CreateCn

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_001___field___ByDBMS()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64 testID=Helper__InsertRow(db,new T_DATA_U(3,2,1));

     var recs=db.testTable.Where(r => r.TEST_ID==testID && r.COL_DATA.HasValue);

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
       (new System.TimeOnly(3,2,1),
        r.COL_DATA);
     }//foreach r

     var sqlt
      =new TestSqlTemplate()
       .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
       .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
       .T("WHERE (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(") AND (").N("t",c_NameOf__COL_DATA).IS_NOT_NULL().T(")");

     db.CheckTextOfLastExecutedCommand
      (sqlt);

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_001___field___ByDBMS

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002___field___ByDBMS()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64 testID=Helper__InsertRow(db,new T_DATA_U(3,2,1));

     var recs=db.testTable.Where(r => r.TEST_ID==testID && !r.COL_DATA.HasValue);

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     var sqlt
      =new TestSqlTemplate()
       .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
       .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
       .T("WHERE (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(") AND (").N("t",c_NameOf__COL_DATA).IS_NULL().T(")");

     db.CheckTextOfLastExecutedCommand
      (sqlt);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_002___field___ByDBMS

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_003___fieldWithNull___ByDBMS()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64 testID=Helper__InsertRow(db,null);

     var recs=db.testTable.Where(r => r.TEST_ID==testID && !r.COL_DATA.HasValue);

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
       (r.COL_DATA);
     }//foreach r

     var sqlt
      =new TestSqlTemplate()
       .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
       .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
       .T("WHERE (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(") AND (").N("t",c_NameOf__COL_DATA).IS_NULL().T(")");

     db.CheckTextOfLastExecutedCommand
      (sqlt);

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_003___fieldWithNull___ByDBMS

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_004___fieldWithNull___ByDBMS()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64 testID=Helper__InsertRow(db,null);

     var recs=db.testTable.Where(r => r.TEST_ID==testID && r.COL_DATA.HasValue);

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     var sqlt
      =new TestSqlTemplate()
       .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
       .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
       .T("WHERE (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(") AND (").N("t",c_NameOf__COL_DATA).IS_NOT_NULL().T(")");

     db.CheckTextOfLastExecutedCommand
      (sqlt);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_004___fieldWithNull___ByDBMS

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_011___param___ByEF()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64 testID=Helper__InsertRow(db,new T_DATA_U(3,2,1));

     T_DATA vv=new T_DATA_U(3,2,1);

     var recs=db.testTable.Where(r => r.TEST_ID==testID && vv.HasValue);

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
       (new System.TimeOnly(3,2,1),
        r.COL_DATA);
     }//foreach r

     var sqlt
      =new TestSqlTemplate()
       .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
       .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
       .T("WHERE ").N("t","TEST_ID").T(" = ").P_ID("__testID_0");

     db.CheckTextOfLastExecutedCommand
      (sqlt);

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_011___param___ByEF

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_012___param___ByEF()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64 testID=Helper__InsertRow(db,new T_DATA_U(3,2,1));

     T_DATA vv=new T_DATA_U(3,2,1);

     var recs=db.testTable.Where(r => r.TEST_ID==testID && !vv.HasValue);

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     var sqlt
      =new TestSqlTemplate()
       .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
       .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
       .T("WHERE FALSE");

     db.CheckTextOfLastExecutedCommand
      (sqlt);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_012___param___ByEF

 //-----------------------------------------------------------------------
 private static System.Int64 Helper__InsertRow(MyContext db,
                                               T_DATA    valueOfColData)
 {
  var newRecord=new MyContext.TEST_RECORD();

  newRecord.COL_DATA=valueOfColData;

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
};//class TestSet_001

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.NullableTimeOnly.SET001.STD.HasValue

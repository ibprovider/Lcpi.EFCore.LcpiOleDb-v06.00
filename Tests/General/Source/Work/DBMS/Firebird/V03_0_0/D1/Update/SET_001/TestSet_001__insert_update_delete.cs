////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 15.06.2021.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using NUnit.Framework;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Update.SET_001{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_001__insert_update_delete

public static class TestSet_001__insert_update_delete
{
 private const string c_NameOf__TABLE            ="TEST_MODIFY_ROW2";

 private const string c_NameOf__COL_ID1          ="TEST_ID";
 private const string c_NameOf__COL_ID2          ="COL_VARCHAR_32";

 private const string c_NameOf__COL_DATA1        ="COL_SMALLINT";
 private const string c_NameOf__COL_DATA2        ="COL_INTEGER";

 private sealed class MyContext:TestBaseDbContext
 {
  [Table(c_NameOf__TABLE)]
  public sealed class TEST_RECORD
  {
   [Column(c_NameOf__COL_ID1)]
   public System.Int64? ID1 { get; set; }

   [Column(c_NameOf__COL_ID2,TypeName = "VARCHAR(32)")]
   public string        ID2 { get; set; }

   [Column(c_NameOf__COL_DATA1)]
   public short         COL_DATA1 { get; set; }

   [Column(c_NameOf__COL_DATA2)]
   public int           COL_DATA2 { get; set; }

   public void CheckState(System.Int64 expectedID1,
                          string       expectedID2,
                          short        expectedDATA1,
                          int          expectedDATA2)
   {
    Assert.AreEqual
     (expectedID1,
      this.ID1);

    Assert.AreEqual
     (expectedID2,
      this.ID2);

    Assert.AreEqual
     (expectedDATA1,
      this.COL_DATA1);

    Assert.AreEqual
     (expectedDATA2,
      this.COL_DATA2);
   }//CheckState
  };//class TEST_RECORD

  //----------------------------------------------------------------------
  public DbSet<TEST_RECORD> testTable { get; set; }

  //----------------------------------------------------------------------
  public MyContext(xdb.OleDbTransaction tr)
   :base(tr)
  {
  }//MyContext

  //----------------------------------------------------------------------
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
   modelBuilder
    .Entity<TEST_RECORD>()
    .HasKey(new[]{"ID1","ID2"});
  }//OnModelCreating
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
    const int c_N=10;

    var startID=Convert.ToInt64(TestServices.GenID(tr,"GEN_ID_TEST_MODIFY_ROW2",c_N))-c_N+1;
    var endID=startID+c_N;

    Console.WriteLine("startID: {0}",startID);

    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     var ef_selectSQL
      =new TestSqlTemplate()
        .T("SELECT ").N("t",c_NameOf__COL_ID1).T(", ").N("t",c_NameOf__COL_ID2).T(", ").N("t",c_NameOf__COL_DATA1).T(", ").N("t",c_NameOf__COL_DATA2).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (").N("t",c_NameOf__COL_ID1).T(" >= ").P_ID("__startID_0").T(") AND (").N("t",c_NameOf__COL_ID1).T(" < ").P_ID("__endID_1").T(")");

     {
      Console.WriteLine("----------------------------- POINT #001");

      var rec1=new MyContext.TEST_RECORD();

      rec1.ID1=startID;
      rec1.ID2="A";

      rec1.COL_DATA1=22;
      rec1.COL_DATA2=4444;

      db.testTable.Add(rec1);

      db.SaveChanges();

      db.CheckTextOfLastExecutedCommand
       (new TestSqlTemplate()
         .T("INSERT INTO ").N(c_NameOf__TABLE).T(" (").N(c_NameOf__COL_ID1).T(", ").N(c_NameOf__COL_ID2).T(", ").N(c_NameOf__COL_DATA1).T(", ").N(c_NameOf__COL_DATA2).T(")").EOL()
         .T("VALUES (").P("p0").T(", ").P("p1").T(", ").P("p2").T(", ").P("p3").T(");"));
     }//local

     var selectSQL
      =new TestSqlTemplate()
        .T("SELECT ").N(c_NameOf__COL_ID1).T(", ").N(c_NameOf__COL_ID2).T(", ").N(c_NameOf__COL_DATA1).T(", ").N(c_NameOf__COL_DATA2).EOL()
        .T("FROM ").N(c_NameOf__TABLE).EOL()
        .T("WHERE ").N(c_NameOf__COL_ID1).T(">="+startID).T(" AND ").N(c_NameOf__COL_ID1).T("<"+endID).T(";")
        .BuildSql(cn);

     {
      Console.WriteLine("----------------------------- POINT #002");

      using var cmd
       =new xdb.OleDbCommand
         (selectSQL,cn,tr);

      using var reader
       =cmd.ExecuteReader();

      Assert.IsTrue(reader.Read());

      Assert.AreEqual
       (startID,
        reader[0]);

      Assert.AreEqual
       ("A",
        reader[1]);

      Assert.AreEqual
       (22,
        reader[2]);

      Assert.AreEqual
       (4444,
        reader[3]);

      Assert.IsFalse(reader.Read());
     }//local

     var queryRecs=db.testTable.Where(r => (r.ID1>=startID && r.ID1<endID));

     {
      Console.WriteLine("----------------------------- POINT #003");

      var recs=new List<MyContext.TEST_RECORD>();

      foreach(var r in queryRecs)
      {
       recs.Add(r);
      }//foreach r

      db.CheckTextOfLastExecutedCommand
       (ef_selectSQL);

      Assert.AreEqual
       (1,
        recs.Count);

      recs[0].CheckState
       (startID,
        "A",
        22,
        4444);

      Console.WriteLine("Change test record");

      recs[0].COL_DATA2=-4444;

      db.SaveChanges();

      db.CheckTextOfLastExecutedCommand
       (new TestSqlTemplate()
         .T("UPDATE ").N(c_NameOf__TABLE).T(" SET ").N(c_NameOf__COL_DATA2).T(" = ").P("p0").EOL()
         .T("WHERE (").N(c_NameOf__COL_ID1).T(" = ").P("p1").T(") AND (").N(c_NameOf__COL_ID2).T(" = ").P("p2").T(");"));
     }//local

     {
      Console.WriteLine("----------------------------- POINT #004");

      using var cmd
       =new xdb.OleDbCommand
         (selectSQL,cn,tr);

      using var reader
       =cmd.ExecuteReader();

      Assert.IsTrue(reader.Read());

      Assert.AreEqual
       (startID,
        reader[0]);

      Assert.AreEqual
       ("A",
        reader[1]);

      Assert.AreEqual
       (22,
        reader[2]);

      Assert.AreEqual
       (-4444,
        reader[3]);

      Assert.IsFalse(reader.Read());
     }//local

     {
      Console.WriteLine("----------------------------- POINT #005");

      var recs=new List<MyContext.TEST_RECORD>();

      foreach(var r in queryRecs)
      {
       recs.Add(r);
      }//foreach r

      db.CheckTextOfLastExecutedCommand
       (ef_selectSQL);

      Assert.AreEqual
       (1,
        recs.Count);

      recs[0].CheckState
       (startID,
        "A",
        22,
        -4444);

      Console.WriteLine("Delete test record");

      db.testTable.Remove(recs[0]);

      db.SaveChanges();

      db.CheckTextOfLastExecutedCommand
       (new TestSqlTemplate()
         .T("DELETE FROM ").N(c_NameOf__TABLE).EOL()
         .T("WHERE (").N(c_NameOf__COL_ID1).T(" = ").P("p0").T(") AND (").N(c_NameOf__COL_ID2).T(" = ").P("p1").T(");"));
     }//local

     {
      Console.WriteLine("----------------------------- POINT #006");

      using var cmd
       =new xdb.OleDbCommand
         (selectSQL,cn,tr);

      using var reader
       =cmd.ExecuteReader();

      Assert.IsFalse(reader.Read());
     }//local

     {
      Console.WriteLine("----------------------------- POINT #007");

      var recs=new List<MyContext.TEST_RECORD>();

      foreach(var r in queryRecs)
      {
       recs.Add(r);
      }//foreach r

      db.CheckTextOfLastExecutedCommand
       (ef_selectSQL);

      Assert.AreEqual
       (0,
        recs.Count);
     }//local
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_001
};//class TestSet_001__insert_update_delete

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Update.SET_001

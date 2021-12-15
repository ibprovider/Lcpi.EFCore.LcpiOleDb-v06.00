////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 28.05.2018.
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D2.TypeMapping.Group002.BIGINT{
////////////////////////////////////////////////////////////////////////////////

using TEST_COL_TYPE=Int64;

////////////////////////////////////////////////////////////////////////////////
//class TestSet__Int64

public static class TestSet__Int64
{
 private sealed class MyContext:TestBaseDbContext
 {
  [Table("TEST_MODIFY_ROW_WD")]
  public sealed class TEST_RECORD
  {
   [Key]
   [Column("TEST_ID")]
   public Int64? TEST_ID { get; set; }

   [Column("COL_BIGINT")]
   public TEST_COL_TYPE? TEST_COL { get; set; }
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
    .Property(b => b.TEST_COL)
    .HasDefaultValue();
  }//OnModelCreating
 };//class MyContext

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_01()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    Int64          recID;
    TEST_COL_TYPE  recData=-12345678901234567;

    var cmd=new xdb.OleDbCommand("",cn,tr);

    using(var db=new MyContext(tr))
    {
     var newRec=new MyContext.TEST_RECORD();

     db.testTable.Add(newRec);

     var nChanges=db.SaveChanges();

     Assert.AreEqual(1,nChanges);

     Assert.NotNull(newRec.TEST_ID);

     Assert.NotNull(newRec.TEST_COL);

     Assert.AreEqual(recData,newRec.TEST_COL);

     recID=newRec.TEST_ID.Value;
    }//using db

    //------------------
    cmd.CommandText="select COL_BIGINT from TEST_MODIFY_ROW_WD where TEST_ID="+recID.ToString();

    var rd=cmd.ExecuteReader();

    Assert.IsTrue(rd.Read());

    Assert.AreEqual(recData,rd.GetInt64(0));

    Assert.IsFalse(rd.Read());

    using(var db=new MyContext(tr))
    {
     var recs=db.testTable.Where(r => r.TEST_ID==recID && r.TEST_COL==recData);

     int nRecs=0;

     foreach(var rec in recs)
     {
      Assert.AreEqual(0,nRecs);

      ++nRecs;

      Assert.AreEqual(recID,rec.TEST_ID);

      Assert.AreEqual(recData,rec.TEST_COL);
     }//foreach

     Assert.AreEqual(1,nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_01
};//class TestSet__Int64

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D2.TypeMapping.Group002.BIGINT

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

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.TypeMapping.Group001{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_016__VARBINARY

public static class TestSet_016__VARBINARY
{
 private sealed class MyContext:TestBaseDbContext
 {
  [Table("TEST_MODIFY_ROW_WD")]
  public class TEST_MODIFY_ROW_WD
  {
   [Key]
   [Column("TEST_ID")]
   public Int64 TEST_ID { get; set; }

   [Column(TypeName="VARBINARY(10)")]
   public byte[] COL_VARBINARY_10 { get; set; }
  };//class TEST_MODIFY_ROW_WD

  //----------------------------------------------------------------------
  public DbSet<TEST_MODIFY_ROW_WD> testTable { get; set; }

  //----------------------------------------------------------------------
  public MyContext(xdb.OleDbTransaction tr)
   :base(tr)
  {
  }//MyContext
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
    object recID;

    using(var cmd=new xdb.OleDbCommand())
    {
     cmd.Connection=cn;
     cmd.Transaction=tr;

     cmd.CommandText
      ="insert into TEST_MODIFY_ROW_WD (COL_VARBINARY_10) values (x'010203040500')\n"
      +"returning TEST_ID\n"
      +"INTO :TEST_ID";

     cmd.Parameters.Refresh();

     cmd.ExecuteNonQuery();

     recID=cmd["TEST_ID"].Value;
    }//using cmd

    using(var db=new MyContext(tr))
    {
     int nRecs=0;

     foreach(var rec in db.testTable.Where(r=>r.TEST_ID==(Int64)recID))
     {
      Assert.AreEqual(0,nRecs);

      ++nRecs;

      Assert.AreEqual(recID,rec.TEST_ID);
      Assert.AreEqual(new byte[]{1,2,3,4,5,0},rec.COL_VARBINARY_10);
     }//foreach rec

     Assert.AreEqual(1,nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_01

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02()
 {
  var a=new byte[]{1,2,3,4,5,0};

  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    object recID;

    using(var cmd=new xdb.OleDbCommand("",cn,tr))
    {
     cmd.CommandText
      ="insert into TEST_MODIFY_ROW_WD (COL_VARBINARY_10) values (:a)\n"
      +"returning TEST_ID\n"
      +"INTO :TEST_ID";

     cmd["a"].Value=a;

     cmd.ExecuteNonQuery();

     recID=cmd["TEST_ID"].Value;
    }//using cmd

    using(var db=new MyContext(tr))
    {
     int nRecs=0;

     foreach(var rec in db.testTable.Where(r=>r.TEST_ID==(Int64)recID && r.COL_VARBINARY_10==a))
     {
      Assert.AreEqual(0,nRecs);

      ++nRecs;

      Assert.AreEqual(recID,rec.TEST_ID);
      Assert.AreEqual(a,rec.COL_VARBINARY_10);
     }//foreach rec

     Assert.AreEqual(1,nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_02
};//class TestSet_016__VARBINARY

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.TypeMapping.Group001

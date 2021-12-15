////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 03.10.2018.
//
// <field>.StartsWith(...)
//
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.String.SET_001.STD.EndsWith__str{
////////////////////////////////////////////////////////////////////////////////
//using

using T_DATA=System.String;

////////////////////////////////////////////////////////////////////////////////
//class TestSet___001

public static class TestSet___001
{
 private const string c_NameOf__TABLE="TBL_CS__WIN1251";

 private const string c_NameOf__COL_DATA8="VARCHAR__8";
 
 private const string c_NameOf__COL_DATA1="VARCHAR__1";

 //-----------------------------------------------------------------------
 private sealed class MyContext:TestBaseDbContext
 {
  [Table(c_NameOf__TABLE)]
  public sealed class TEST_RECORD
  {
   [Key]
   [Column("TEST_ID")]
   public System.Int64? TEST_ID { get; set; }

   [Column(c_NameOf__COL_DATA1, TypeName="VARCHAR(1)")]
   public T_DATA DATA1 { get; set; }

   [Column(c_NameOf__COL_DATA8, TypeName="VARCHAR(8)")]
   public T_DATA DATA8 { get; set; }
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
 public static void Test__01()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64? recID=null;

     {
      var newRec=new MyContext.TEST_RECORD();

      newRec.DATA1="";
      newRec.DATA8=null;

      db.testTable.Add(newRec);

      db.SaveChanges();

      recID=newRec.TEST_ID;
     }//local

     Assert.NotNull
      (recID.Value);

     Console.WriteLine("[#0] recID: {0}",recID);

     int nRecs1=0;

     foreach(var rec in db.testTable.Where(r => r.TEST_ID==recID && r.DATA8.EndsWith("")))
     {
      ++nRecs1;

      Console.WriteLine("[#1] Fetched Row");
     }

     Console.WriteLine("[#1] nRecs1: {0}", nRecs1);

     Assert.AreEqual
      (0,
       nRecs1);

     int nRecs2=0;

     foreach(var rec in db.testTable.Where(r => r.TEST_ID==recID && r.DATA8.EndsWith(r.DATA1)))
     {
      ++nRecs2;

      Console.WriteLine("[#2] Fetched Row");
     }

     Console.WriteLine("[#2] nRecs2: {0}", nRecs2);

     Assert.AreEqual
      (0,
       nRecs2);
    }//using db

    //tr.Commit();
    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___null___ByDBMS
};//class TestSet___001

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.String.SET_001.STD.EndsWith__str

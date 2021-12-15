////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 15.05.2018.
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace EFCore_LcpiOleDb_Tests.General.Work.Simple{
////////////////////////////////////////////////////////////////////////////////
//class Work_Simple__Test_001

public static class Work_Simple__Test_001
{
 private sealed class MyContext:TestBaseDbContext
 {
  [Table("DUAL")]
  public sealed class DUAL
  {
   public int ID { get; set; }
  };//class DUAL

  //----------------------------------------------------------------------
  public DbSet<DUAL> table_DUAL { get; set; }
 };//class MyContext

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_01()
 {
  using(var db=new MyContext())
  {
   int nRecs=0;

   foreach(var rec in db.table_DUAL)
   {
    Assert.AreEqual(0,nRecs);

    ++nRecs;

    var v=rec.ID;

    Console.WriteLine("ID: {0}",v);

    Assert.AreEqual(1,v);
   }//foreach

   Assert.AreEqual(1,nRecs);
  }//using db
 }//Test_01

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02()
 {
  using(var db=new MyContext())
  {
   int nRecs=0;

   var recs=db.table_DUAL.Where(r => r.ID==1);

   foreach(var rec in recs)
   {
    Assert.AreEqual(0,nRecs);

    ++nRecs;

    var v=rec.ID;

    Console.WriteLine("ID: {0}",v);

    Assert.AreEqual(1,v);
   }//foreach

   Assert.AreEqual(1,nRecs);
  }//using db
 }//Test_02

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02_b()
 {
  using(var db=new MyContext())
  {
   int C=2;

   int nRecs=0;

   var recs=db.table_DUAL.Where(r => r.ID+1==C);

   foreach(var rec in recs)
   {
    Assert.AreEqual(0,nRecs);

    ++nRecs;

    var v=rec.ID;

    Console.WriteLine("ID: {0}",v);

    Assert.AreEqual(1,v);
   }//foreach

   Assert.AreEqual(1,nRecs);
  }//using db
 }//Test_02_b

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_03()
 {
  using(var db=new MyContext())
  {
   int nRecs=0;

   var recs=db.table_DUAL.Where(r => r.ID==2);

   foreach(var rec in recs)
   {
    Assert.AreEqual(0,nRecs);

    ++nRecs;

    var v=rec.ID;

    Console.WriteLine("ID: {0}",v);

    Assert.AreEqual(1,v);
   }//foreach

   Assert.AreEqual(0,nRecs);
  }//using db
 }//Test_03

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_04()
 {
  using(var db=new MyContext())
  {
   int nRecs=0;

   foreach(var rec in db.table_DUAL.OrderBy(r => r.ID))
   {
    Assert.AreEqual(0,nRecs);

    ++nRecs;

    var v=rec.ID;

    Console.WriteLine("ID: {0}",v);

    Assert.AreEqual(1,v);
   }//foreach

   Assert.AreEqual(1,nRecs);
  }//using db
 }//Test_04

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_05()
 {
  using(var db=new MyContext())
  {
   int nRecs=0;

   Int32? recID=1;

   foreach(var rec in db.table_DUAL.Where(r => r.ID==recID))
   {
    Assert.AreEqual(0,nRecs);

    ++nRecs;

    var v=rec.ID;

    Console.WriteLine("ID: {0}",v);

    Assert.AreEqual(1,v);
   }//foreach

   db.CheckTextOfLastExecutedCommand
    (new TestSqlTemplate()
      .T("SELECT ").N("d","ID").EOL()
      .T("FROM ").N("DUAL").T(" AS ").N("d").EOL()
      .T("WHERE ").N("d","ID").T(" = ").P_I4("__recID_0"));

   Assert.AreEqual(1,nRecs);
  }//using db
 }//Test_05

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_06()
 {
  using(var db=new MyContext())
  {
   int nRecs=0;

#pragma warning disable CS1718
   var recs=db.table_DUAL.Where(r => r==r);
#pragma warning restore CS1718

   foreach(var rec in recs)
   {
    Assert.AreEqual(0,nRecs);

    ++nRecs;

    var v=rec.ID;

    Console.WriteLine("ID: {0}",v);

    Assert.AreEqual(1,v);
   }//foreach

   db.CheckTextOfLastExecutedCommand
    (new TestSqlTemplate()
      .T("SELECT ").N("d","ID").EOL()
      .T("FROM ").N("DUAL").T(" AS ").N("d"));

   Assert.AreEqual(1,nRecs);
  }//using db
 }//Test_06
};//class Work_Simple__Test_001

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.Simple

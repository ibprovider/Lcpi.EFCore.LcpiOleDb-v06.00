////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 26.07.2021.
//
// <field>.AddHours(...)
//
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

//using Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DataTypes.Extensions;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.DateTime.SET001.STD.AddHours{
////////////////////////////////////////////////////////////////////////////////
//using

using T_DATA  =System.DateTime;
using T_DATA_U=System.DateTime;

using T_AMOUNT=System.Double;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_004__params__01__V

public static class TestSet_004__params__01__V
{
 private const string c_NameOf__TABLE            ="DUAL";

 private sealed class MyContext:TestBaseDbContext
 {
  [Table(c_NameOf__TABLE)]
  public sealed class TEST_RECORD
  {
   [Key]
   [Column("ID")]
   public System.Int32? TEST_ID { get; set; }
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
 public static void Test_01()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA vv=new T_DATA_U(2021,7,26,14,27,53).AddTicks(1000+1);

     //var c_ticks
     // =new T_DATA_U(2021,7,26,15,27,53).AddTicks(1000).Ticks;

     const long c_ticks
      =637629100730001000+2;

     var recs=db.testTable.Where(r => vv.AddHours((T_AMOUNT)(1))==new T_DATA_U(c_ticks));

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
       (1,
        r.TEST_ID.Value);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("d","ID").EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("d").EOL()
        .T("WHERE ").P_BOOL("__Exec_V_V_0"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_01

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA vv=new T_DATA_U(2021,7,26,14,27,53).AddTicks(1000+1);

     //var c_ticks
     // =new T_DATA_U(2021,7,26,13,27,53).AddTicks(1000).Ticks;

     const long c_ticks
      =637629028730001000+2;

     var recs=db.testTable.Where(r => vv.AddHours((T_AMOUNT)(-1))==new T_DATA_U(c_ticks));

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
       (1,
        r.TEST_ID.Value);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("d","ID").EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("d").EOL()
        .T("WHERE ").P_BOOL("__Exec_V_V_0"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_02

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_04()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA vv=new T_DATA_U(2021,7,26,14,27,53);

     var recs=db.testTable.Where(r => vv.AddHours((T_AMOUNT)(-2.7777777777777777777777777777778e-7))==new T_DATA_U(2021,7,26,14,27,52,999));

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
       (1,
        r.TEST_ID.Value);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("d","ID").EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("d").EOL()
        .T("WHERE ").P_BOOL("__Exec_V_V_0"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_04

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_05()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA vv=new T_DATA_U(2021,7,26,14,27,53);

     //const long
     // c_ticks2
     //  =14*System.TimeSpan.TicksPerHour
     //  +27*System.TimeSpan.TicksPerMinute
     //  +52*System.TimeSpan.TicksPerSecond
     //  +9999*1000;
     //
     //long
     // c_ticks3
     //  =(new T_DATA_U(2021,7,26)).AddTicks(c_ticks2).Ticks;

     const long
      c_ticks3
       =637629064729999000;

     var recs=db.testTable.Where(r => vv.AddHours((T_AMOUNT)(-2.7777777777777777777777777777778e-8))==new T_DATA_U(c_ticks3));

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
       (1,
        r.TEST_ID.Value);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("d","ID").EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("d").EOL()
        .T("WHERE ").P_BOOL("__Exec_V_V_0"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_05

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_06()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA vv=new T_DATA_U(2021,7,26,14,27,53);

     //const long
     // c_ticks2
     //  =14*System.TimeSpan.TicksPerHour
     //  +27*System.TimeSpan.TicksPerMinute
     //  +52*System.TimeSpan.TicksPerSecond
     //  +9999*1000;
     //
     //long
     // c_ticks3
     //  =(new T_DATA_U(2021,7,26)).AddTicks(c_ticks2).Ticks;

     const long
      c_ticks3
       =637629064729999000+1;

     var recs=db.testTable.Where(r => vv.AddHours((T_AMOUNT)(-2.7777777777777777777777777777778e-8))==new T_DATA_U(c_ticks3));

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
       (1,
        r.TEST_ID.Value);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("d","ID").EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("d").EOL()
        .T("WHERE ").P_BOOL("__Exec_V_V_0"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_06
};//class TestSet_004__params__01__V

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.DateTime.SET001.STD.AddHours

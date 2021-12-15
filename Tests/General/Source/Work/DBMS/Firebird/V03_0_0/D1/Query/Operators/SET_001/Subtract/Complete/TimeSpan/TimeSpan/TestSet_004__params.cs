////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 29.11.2020.
using System;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Operators.SET_001.Subtract.Complete.TimeSpan.TimeSpan{
////////////////////////////////////////////////////////////////////////////////

using T_DATA1   =System.TimeSpan;
using T_DATA2   =System.TimeSpan;
using T_RESULT  =System.TimeSpan;

using T_DATA1_U =System.TimeSpan;
using T_DATA2_U =System.TimeSpan;
using T_RESULT_U=System.TimeSpan;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_004__params

public static class TestSet_004__params
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
 public static void Test_001()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA1 c_value1=new T_DATA1_U(12,10,8);
     T_DATA2 c_value2=new T_DATA2_U(5,3,59);

     T_DATA1 vv1=c_value1;
     T_DATA2 vv2=c_value2;

     var recs=db.testTable.Where(r => (vv1-vv2)==(T_RESULT)(new T_RESULT_U(7,6,9)));

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
 }//Test_001

  //-----------------------------------------------------------------------
 [Test]
 public static void Test_001__negative()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA1 c_value1=new T_DATA1_U(12,10,8);
     T_DATA2 c_value2=new T_DATA2_U()-new T_DATA2_U(5,3,59);

     T_DATA1 vv1=c_value1;
     T_DATA2 vv2=c_value2;

     var recs=db.testTable.Where(r => (vv1-vv2)==(T_RESULT)(new T_RESULT_U(17,14,7)));

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
 }//Test_001__negative

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002__non_zero_days()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA1 c_value1=new T_DATA1_U(12,10,8);
     T_DATA2 c_value2=new T_DATA2_U(2,5,3,59,0);

     T_DATA1 vv1=c_value1;
     T_DATA2 vv2=c_value2;

     var recs=db.testTable.Where(r => (vv1-vv2)==(T_RESULT)(new T_RESULT_U()-new T_RESULT_U(1,16,53,51)));

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
 }//Test_002__non_zero_days

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002__non_zero_days__negative()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA1 c_value1=new T_DATA1_U(12,10,8);
     T_DATA2 c_value2=new T_DATA2_U()-new T_DATA2_U(2,5,3,59,0);

     T_DATA1 vv1=c_value1;
     T_DATA2 vv2=c_value2;

     var recs=db.testTable.Where(r => (vv1-vv2)==(T_RESULT)(new T_RESULT_U(2,17,14,7,0)));

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
 }//Test_002__non_zero_days__negative

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_003__mcs()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA1 c_value1=new System.TimeSpan(12,10,8);
     T_DATA2 c_value2=new System.TimeSpan(5,3,59)+new System.TimeSpan(1000+1);

     T_DATA1 vv1=c_value1;
     T_DATA2 vv2=c_value2;

     var recs=db.testTable.Where(r => (vv1-vv2)==new System.TimeSpan(7,6,8)+new System.TimeSpan(9999000));

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
 }//Test_003__mcs
};//class TestSet_004__params

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Operators.SET_001.Subtract.Complete.TimeSpan.TimeSpan

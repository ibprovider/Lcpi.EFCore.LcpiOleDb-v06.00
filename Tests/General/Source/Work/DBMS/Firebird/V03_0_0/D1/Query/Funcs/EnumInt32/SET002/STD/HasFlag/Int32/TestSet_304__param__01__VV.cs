////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 04.06.2021.
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Funcs.EnumInt32.SET002.STD.HasFlag.Int32{
////////////////////////////////////////////////////////////////////////////////

using T_DATA1  =TestEnum001;
using T_DATA2  =System.Int32;

using T_DATA1_U=TestEnum001;
using T_DATA2_U=System.Int32;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_304__param__01__VV

public static class TestSet_304__param__01__VV
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
 private static xdb.OleDbConnection Helper__CreateCn()
 {
  return LocalCnHelper.CreateCn();
 }//Helper__CreateCn

 //-----------------------------------------------------------------------
 private static bool HasFlag(this T_DATA1 obj,T_DATA2 value)
 {
  throw new InvalidOperationException("Incorrect usage of DUMMY HasFlag method!");
 }//HasFlag

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0000___param__param()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_DATA1_U c_value1=TestEnum001.Flag1|TestEnum001.Flag2;
     const T_DATA2_U c_value2=0;

     Assert.IsTrue
      (c_value1.HasFlag((TestEnum001)c_value2));

     T_DATA1 vv1=c_value1;
     T_DATA2 vv2=c_value2;

     var recs=db.testTable.Where(r => vv1.HasFlag(vv2));

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
        .T("WHERE ").P_BOOL("__Exec_0"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Commit();
   }//using tr
  }//using cn
 }//Test_0000___param__param

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_A001___param__param()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_DATA1_U c_value1=TestEnum001.Flag1|TestEnum001.Flag2;
     const T_DATA2_U c_value2=(T_DATA2_U)(TestEnum001.Flag1|TestEnum001.Flag2);

     T_DATA1 vv1=c_value1;
     T_DATA2 vv2=c_value2;

     var recs=db.testTable.Where(r => vv1.HasFlag((T_DATA2)(object)vv2));

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
        .T("WHERE ").P_BOOL("__Exec_0"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Commit();
   }//using tr
  }//using cn
 }//Test_A001___param__param

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_A002___param__const()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_DATA1_U c_value1=TestEnum001.Flag1|TestEnum001.Flag2;
     const T_DATA2_U c_value2=(T_DATA2_U)(TestEnum001.Flag1|TestEnum001.Flag2);

     T_DATA1 vv1=c_value1;

     var recs=db.testTable.Where(r => vv1.HasFlag((T_DATA2)(object)c_value2));

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
        .T("WHERE ").P_BOOL("__Exec_0"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Commit();
   }//using tr
  }//using cn
 }//Test_A002___param__const

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_A003___param__const2()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_DATA1_U c_value1=TestEnum001.Flag1|TestEnum001.Flag2;

     T_DATA1 vv1=c_value1;

     var recs=db.testTable.Where(r => vv1.HasFlag((T_DATA2)(object)(T_DATA2)(TestEnum001.Flag1|TestEnum001.Flag2)));

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
        .T("WHERE ").P_BOOL("__Exec_0"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Commit();
   }//using tr
  }//using cn
 }//Test_A003___param__const2

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_B001___param__param()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_DATA1_U c_value1=TestEnum001.Flag1|TestEnum001.Flag2;
     const T_DATA2_U c_value2=(T_DATA2_U)(TestEnum001.Flag2|TestEnum001.Flag3);

     T_DATA1 vv1=c_value1;
     T_DATA2 vv2=c_value2;

     var recs=db.testTable.Where(r => vv1.HasFlag((T_DATA2)(object)vv2));

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("d","ID").EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("d").EOL()
        .T("WHERE ").P_BOOL("__Exec_0"));
    }//using db

    tr.Commit();
   }//using tr
  }//using cn
 }//Test_B001___param__param

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_B002___param__const()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_DATA1_U c_value1=TestEnum001.Flag1|TestEnum001.Flag2;
     const T_DATA2_U c_value2=(T_DATA2_U)(TestEnum001.Flag2|TestEnum001.Flag3);

     T_DATA1 vv1=c_value1;

     var recs=db.testTable.Where(r => vv1.HasFlag((T_DATA2)(object)c_value2));

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("d","ID").EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("d").EOL()
        .T("WHERE ").P_BOOL("__Exec_0"));
    }//using db

    tr.Commit();
   }//using tr
  }//using cn
 }//Test_B002___param__const

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_B003___param__const2()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_DATA1_U c_value1=TestEnum001.Flag1|TestEnum001.Flag2;

     T_DATA1 vv1=c_value1;

     var recs=db.testTable.Where(r => vv1.HasFlag((T_DATA2)(object)(T_DATA2)(TestEnum001.Flag2|TestEnum001.Flag3)));

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("d","ID").EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("d").EOL()
        .T("WHERE ").P_BOOL("__Exec_0"));
    }//using db

    tr.Commit();
   }//using tr
  }//using cn
 }//Test_B003___param__const2
};//class TestSet_304__param__01__VV

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Funcs.EnumInt32.SET002.STD.HasFlag.Int32

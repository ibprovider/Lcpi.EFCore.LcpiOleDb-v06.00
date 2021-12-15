////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 15.06.2021.
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

using structure_lib=lcpi.lib.structure;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.Array_Byte.SET001.EXT.Contains{
////////////////////////////////////////////////////////////////////////////////
//using

using T_DATA1_E =System.Byte;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_004__param

public static class TestSet_004__param
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
     T_DATA1_E[] vv1=new T_DATA1_E[]{10,20,30,40,50,60,70};

     var recs=db.testTable.Where(r => vv1.Contains((byte)30));

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
 }//Test_001

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002__null()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA1_E[] vv1=null;

     var recs=db.testTable.Where(r => vv1.Contains((byte)30));

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("d","ID").EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("d").EOL()
        .T("WHERE NULL"));
    }//using db

    tr.Commit();
   }//using tr
  }//using cn
 }//Test_002__null

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_003__NO()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA1_E[] vv1=new T_DATA1_E[]{10,20,30,40,50,60,70};

     var recs=db.testTable.Where(r => vv1.Contains((byte)255));

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
 }//Test_003__NO

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_004__NO__empty()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA1_E[] vv1=new T_DATA1_E[0];

     var recs=db.testTable.Where(r => vv1.Contains((byte)255));

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
 }//Test_004__NO__empty

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_005__each_byte()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     for(T_DATA1_E xElement=0;;++xElement)
     {
      T_DATA1_E[] vv1=new T_DATA1_E[]{70, xElement};

      var recs=db.testTable.Where(r => vv1.Contains(xElement));

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

      if(xElement==T_DATA1_E.MaxValue)
       break;
     }//for xElement
    }//using db

    tr.Commit();
   }//using tr
  }//using cn
 }//Test_005__each_byte

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_006__each_position()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA1_E[] vv1=new T_DATA1_E[]{10, 20, 30, 40, 50, 60};

     for(int i=0;i!=vv1.Length;++i)
     {
      var xElement=vv1[i];

      var recs=db.testTable.Where(r => vv1.Contains(xElement));

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

      if(xElement==T_DATA1_E.MaxValue)
       break;
     }//for xElement
    }//using db

    tr.Commit();
   }//using tr
  }//using cn
 }//Test_006__each_position
};//class TestSet_004__param

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.Array_Byte.SET001.EXT.Contains

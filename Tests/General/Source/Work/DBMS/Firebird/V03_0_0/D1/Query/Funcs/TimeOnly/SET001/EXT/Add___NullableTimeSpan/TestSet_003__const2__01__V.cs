////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 21.07.2021.
//
// <field>.Add___TimeSpan
//
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DataTypes.Extensions;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Funcs.TimeOnly.SET001.EXT.Add___NullableTimeSpan{
////////////////////////////////////////////////////////////////////////////////
//using

using T_DATA  =System.TimeOnly;
using T_DATA_U=System.TimeOnly;

using T_AMOUNT=System.Nullable<System.TimeSpan>;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_003__const2__01__V

public static class TestSet_003__const2__01__V
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
     T_DATA c_data=new T_DATA_U(14,27,53);

     var recs=db.testTable.Where(r => new T_DATA_U(14,27,53).Add((T_AMOUNT)new System.TimeSpan(1,2,3))==new T_DATA_U(15,29,56));

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
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("d"));

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
     const long
      c_ticks1
       =14*System.TimeSpan.TicksPerHour
       +27*System.TimeSpan.TicksPerMinute
       +53*System.TimeSpan.TicksPerSecond
       +1234*1000
       +999;

     T_DATA c_data=new T_DATA_U(c_ticks1);

     const long
      c_ticks2
       =15*System.TimeSpan.TicksPerHour
       +29*System.TimeSpan.TicksPerMinute
       +56*System.TimeSpan.TicksPerSecond
       +1234*1000;

     var recs=db.testTable.Where(r => new T_DATA_U(c_ticks1).Add((T_AMOUNT)new System.TimeSpan(1,2,3))==new T_DATA_U(c_ticks2));

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
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("d"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_02
};//class TestSet_003__const2__01__V

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Funcs.TimeOnly.SET001.EXT.Add___NullableTimeSpan

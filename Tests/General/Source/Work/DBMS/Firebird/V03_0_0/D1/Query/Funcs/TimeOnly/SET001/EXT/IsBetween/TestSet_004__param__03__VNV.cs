////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 04.09.2021.
//
// <field>.IsBetween
//
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DataTypes.Extensions;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Funcs.TimeOnly.SET001.EXT.IsBetween{
////////////////////////////////////////////////////////////////////////////////
//using

using T_DATA1  =System.TimeOnly;
using T_DATA2  =System.Nullable<System.TimeOnly>;
using T_DATA3  =System.Nullable<System.TimeOnly>;

using T_DATA1_U=System.TimeOnly;
using T_DATA2_U=System.TimeOnly;
using T_DATA3_U=System.TimeOnly;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_004__param__03__VNV

public static class TestSet_004__param__03__VNV
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
     T_DATA1 c_data1=new T_DATA1_U(14,27,53);
     T_DATA2 c_data2=null;
     T_DATA3 c_data3=new T_DATA3_U(14,27,54);

     T_DATA1 vv1=c_data1;
     T_DATA2 vv2=c_data2;
     T_DATA3 vv3=c_data3;

     var recs=db.testTable.Where(r => vv1.IsBetween(vv2,vv3)==true);

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("d","ID").EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("d").EOL()
        .T("WHERE ").P_BOOL("__Exec_V_V_0"));
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
     T_DATA1 c_data1=new T_DATA1_U(14,27,53);
     T_DATA2 c_data2=null;
     T_DATA3 c_data3=new T_DATA3_U(14,27,54);

     T_DATA1 vv1=c_data1;
     T_DATA2 vv2=c_data2;
     T_DATA3 vv3=c_data3;

     var recs=db.testTable.Where(r => vv1.IsBetween(vv2,vv3)==false);

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("d","ID").EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("d").EOL()
        .T("WHERE ").P_BOOL("__Exec_V_V_0"));
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_02

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_03()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA1 c_data1=new T_DATA1_U(14,27,53);
     T_DATA2 c_data2=null;
     T_DATA3 c_data3=new T_DATA3_U(14,27,54);

     T_DATA1 vv1=c_data1;
     T_DATA2 vv2=c_data2;
     T_DATA3 vv3=c_data3;

     var recs=db.testTable.Where(r => vv1.IsBetween(vv2,vv3)==null);

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
 }//Test_03
};//class TestSet_004__param__03__VNV

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Funcs.TimeOnly.SET001.EXT.IsBetween

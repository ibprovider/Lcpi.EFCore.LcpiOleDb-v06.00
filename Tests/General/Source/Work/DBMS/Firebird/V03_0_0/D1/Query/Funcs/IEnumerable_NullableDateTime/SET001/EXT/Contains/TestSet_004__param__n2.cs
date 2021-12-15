////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 15.06.2021.
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Funcs.IEnumerable_NullableDateTime.SET001.EXT.Contains{
////////////////////////////////////////////////////////////////////////////////
//using

using T_DATA  =System.Nullable<System.DateTime>;

using T_DATA_U=System.DateTime;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_004__param__n2

public static class TestSet_004__param__n2
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
     T_DATA c_data=null;

     T_DATA vv=c_data;

     IEnumerable<T_DATA> values
      =new T_DATA[]
       {
        new T_DATA_U(2021,9,16,15,40,12,123).AddTicks(3*1000+3),
        new T_DATA_U(2021,9,16,15,40,12,123).AddTicks(4*1000+3),
        null,
        new T_DATA_U(2021,9,16,15,40,12,123).AddTicks(5*1000+3),
       };

     var recs=db.testTable.Where(r => values.Contains(vv));

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

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_001

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002__const()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA c_data=null;

     T_DATA vv=c_data;

     // var v_ticks
     //  =new T_DATA_U(2021,9,16,15,40,12,123).Ticks;

     const long c_ticks
      =637674036121230000;

     const long c_ticks1
      =c_ticks+3*1000+3;

     const long c_ticks2
      =c_ticks+4*1000+3;

     const long c_ticks3
      =c_ticks+5*1000+3;

     var recs
      =db.testTable.Where
        (r => ((IEnumerable<T_DATA>)new T_DATA[]
                    {
                     new T_DATA_U(c_ticks1),
                     new T_DATA_U(c_ticks2),
                     null,
                     new T_DATA_U(c_ticks3),
                    }).Contains(vv));

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

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_002__const
};//class TestSet_004__param__n2

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Funcs.IEnumerable_NullableDateTime.SET001.EXT.Contains

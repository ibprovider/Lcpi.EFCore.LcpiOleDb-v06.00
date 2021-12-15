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

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.IEnumerable_NullableDateTime.SET001.EXT.Contains{
////////////////////////////////////////////////////////////////////////////////
//using

using T_DATA  =System.Nullable<System.DateTime>;

using T_DATA_U=System.DateTime;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_001__fields

public static class TestSet_001__fields
{
 private const string c_NameOf__TABLE="TEST_MODIFY_ROW";

 private const string c_NameOf__COL_DATA="COL_TIMESTAMP";

 private sealed class MyContext:TestBaseDbContext
 {
  [Table(c_NameOf__TABLE)]
  public sealed class TEST_RECORD
  {
   [Key]
   [Column("TEST_ID")]
   public System.Int64? TEST_ID { get; set; }

   [Column(c_NameOf__COL_DATA)]
   public T_DATA DATA { get; set; }
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
     T_DATA c_data=new T_DATA_U(2021,9,16,15,40,12,123).AddTicks(4*1000+1);

     System.Int64? testID=Helper__InsertRow(db,c_data);

     System.Collections.Generic.IEnumerable<T_DATA> values
      =new T_DATA[]
       {
        new T_DATA_U(2021,9,16,15,40,12,123).AddTicks(3*1000+3),
        new T_DATA_U(2021,9,16,15,40,12,123).AddTicks(4*1000+3),
        null,
        new T_DATA_U(2021,9,16,15,40,12,123).AddTicks(5*1000+3),
       };

     var recs=db.testTable.Where(r => values.Contains(r.DATA) && r.TEST_ID==testID);

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
       (testID,
        r.TEST_ID.Value);

      Assert.AreEqual
       (c_data,
        r.DATA);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (").N("t",c_NameOf__COL_DATA).T(" IN (timestamp '2021-09-16 15:40:12.1233', timestamp '2021-09-16 15:40:12.1234', timestamp '2021-09-16 15:40:12.1235') OR (").N("t",c_NameOf__COL_DATA).T(" IS NULL)) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));

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
     T_DATA c_data=new T_DATA_U(2021,9,16,15,40,12,123).AddTicks(4*1000+1);

     System.Int64? testID=Helper__InsertRow(db,c_data);

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
                    }).Contains(r.DATA) && r.TEST_ID==testID);

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
       (testID,
        r.TEST_ID.Value);

      Assert.AreEqual
       (c_data,
        r.DATA);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (").N("t",c_NameOf__COL_DATA).T(" IN (timestamp '2021-09-16 15:40:12.1233', timestamp '2021-09-16 15:40:12.1234', timestamp '2021-09-16 15:40:12.1235') OR (").N("t",c_NameOf__COL_DATA).T(" IS NULL)) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_002__const

 //-----------------------------------------------------------------------
 private static System.Int64 Helper__InsertRow(MyContext db,
                                               T_DATA    valueOfData)
 {
  var newRecord=new MyContext.TEST_RECORD();

  newRecord.DATA=valueOfData;

  db.testTable.Add(newRecord);

  db.SaveChanges();

  var sqlt
   =new TestSqlTemplate()
     .T("INSERT INTO ").N(c_NameOf__TABLE).T(" (").N(c_NameOf__COL_DATA).T(")").EOL()
     .T("VALUES (").P("p0").T(")").EOL()
     .T("RETURNING ").N("TEST_ID").EOL()
     .T("INTO ").P("p1").T(";");

  db.CheckTextOfLastExecutedCommand
   (sqlt);

  Assert.IsTrue
   (newRecord.TEST_ID.HasValue);

  Console.WriteLine("TEST_ID: {0}",newRecord.TEST_ID.Value);

  return newRecord.TEST_ID.Value;
 }//Helper__InsertRow
};//class TestSet_001__fields

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.IEnumerable_NullableDateTime.SET001.EXT.Contains

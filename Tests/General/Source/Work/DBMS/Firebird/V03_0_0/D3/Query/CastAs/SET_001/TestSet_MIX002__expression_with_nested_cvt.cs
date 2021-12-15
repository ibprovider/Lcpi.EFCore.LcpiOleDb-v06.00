////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 16.11.2020.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.CastAs.SET_001{
////////////////////////////////////////////////////////////////////////////////

using T_SOURCE_VALUE=System.Nullable<System.Double>;
using T_TARGET_VALUE=System.Int16;

using T_SOURCE_VALUE_U=System.Double;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_MIX002__expression_with_nested_cvt

public static class TestSet_MIX002__expression_with_nested_cvt
{
 private const string c_NameOf__TABLE="TEST_MODIFY_ROW2";

 private const string c_NameOf__COL_SOURCE="COL_DOUBLE";
 private const string c_NameOf__COL_TARGET="COL2_SMALLINT";

 private const string c_NameOf__TARGET_SQL_TYPE="SMALLINT";

 private sealed class MyContext:TestBaseDbContext
 {
  [Table(c_NameOf__TABLE)]
  public sealed class TEST_RECORD
  {
   [Key]
   [Column("TEST_ID")]
   public System.Int64? TEST_ID { get; set; }

   [Column(c_NameOf__COL_SOURCE)]
   public T_SOURCE_VALUE COL_SOURCE { get; set; }

   [Column(c_NameOf__COL_TARGET)]
   public T_TARGET_VALUE COL_TARGET { get; set; }
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
 public static void Test_001__with_consts()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_SOURCE_VALUE_U c_valueSource_=-1.6;
     const T_TARGET_VALUE   c_valueTarget=-1;

     System.Int64? testID=Helper__InsertRow(db,c_valueSource_,c_valueTarget);

     var recs=db.testTable.Where(r => ((T_TARGET_VALUE)(object)(r.COL_SOURCE-(T_TARGET_VALUE)(object)r.COL_SOURCE))==(T_TARGET_VALUE)(object)(new T_SOURCE_VALUE(-1.6D)-(T_TARGET_VALUE)(object)new T_SOURCE_VALUE(-1.6D)) && r.TEST_ID==testID);

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
       (c_valueSource_,
        r.COL_SOURCE);

      Assert.AreEqual
       (c_valueTarget,
        r.COL_TARGET);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_SOURCE).T(", ").N("t",c_NameOf__COL_TARGET).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (CAST(TRUNC(").N("t",c_NameOf__COL_SOURCE).T(" - CAST(CAST(TRUNC(").N("t",c_NameOf__COL_SOURCE).T(") AS "+c_NameOf__TARGET_SQL_TYPE+") AS DOUBLE PRECISION)) AS "+c_NameOf__TARGET_SQL_TYPE+") = 0) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_001__with_consts

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002__with_one_param()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_SOURCE_VALUE_U c_valueSource_=-1.6;
     const T_TARGET_VALUE   c_valueTarget=-1;

     System.Int64? testID=Helper__InsertRow(db,c_valueSource_,c_valueTarget);

     T_SOURCE_VALUE vv1=c_valueSource_;

     var recs=db.testTable.Where(r => ((T_TARGET_VALUE)(object)(r.COL_SOURCE-(T_TARGET_VALUE)(object)r.COL_SOURCE))==(T_TARGET_VALUE)(object)(vv1-(T_TARGET_VALUE)(object)vv1) && r.TEST_ID==testID);

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
       (c_valueSource_,
        r.COL_SOURCE);

      Assert.AreEqual
       (c_valueTarget,
        r.COL_TARGET);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_SOURCE).T(", ").N("t",c_NameOf__COL_TARGET).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (CAST(TRUNC(").N("t",c_NameOf__COL_SOURCE).T(" - CAST(CAST(TRUNC(").N("t",c_NameOf__COL_SOURCE).T(") AS "+c_NameOf__TARGET_SQL_TYPE+") AS DOUBLE PRECISION)) AS "+c_NameOf__TARGET_SQL_TYPE+") = ").P_I2("__Exec_0").T(") AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_002__with_one_param

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_003__with_two_params()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_SOURCE_VALUE_U c_valueSource_=-1.6;
     const T_TARGET_VALUE   c_valueTarget=-1;

     System.Int64? testID=Helper__InsertRow(db,c_valueSource_,c_valueTarget);

     T_SOURCE_VALUE vv1=c_valueSource_;
     T_TARGET_VALUE vv2=c_valueTarget;

     var recs=db.testTable.Where(r => ((T_TARGET_VALUE)(object)(r.COL_SOURCE-(T_TARGET_VALUE)(object)r.COL_SOURCE))==(T_TARGET_VALUE)(object)(vv1-(T_TARGET_VALUE)(object)vv2) && r.TEST_ID==testID);

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
       (c_valueSource_,
        r.COL_SOURCE);

      Assert.AreEqual
       (c_valueTarget,
        r.COL_TARGET);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_SOURCE).T(", ").N("t",c_NameOf__COL_TARGET).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (CAST(TRUNC(").N("t",c_NameOf__COL_SOURCE).T(" - CAST(CAST(TRUNC(").N("t",c_NameOf__COL_SOURCE).T(") AS "+c_NameOf__TARGET_SQL_TYPE+") AS DOUBLE PRECISION)) AS "+c_NameOf__TARGET_SQL_TYPE+") = ").P_I2("__Exec_0").T(") AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_003__with_two_params

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_004__sudden_null()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_SOURCE_VALUE_U c_valueSource_=-1.6;
     const T_TARGET_VALUE   c_valueTarget=-1;

     System.Int64? testID=Helper__InsertRow(db,c_valueSource_,c_valueTarget);

     T_SOURCE_VALUE vv1=c_valueSource_;

     string vv2=null;

     var recs=db.testTable.Where(r => ((T_TARGET_VALUE)(object)(r.COL_SOURCE-(T_TARGET_VALUE)(object)r.COL_SOURCE))==(T_TARGET_VALUE)(object)(vv1-(T_TARGET_VALUE)(object)vv2.Length) && r.TEST_ID==testID);

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_SOURCE).T(", ").N("t",c_NameOf__COL_TARGET).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (").N("t",c_NameOf__COL_SOURCE).IS_NULL().T(") AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_004__sudden_null

 //-----------------------------------------------------------------------
 private static System.Int64 Helper__InsertRow(MyContext      db,
                                               T_SOURCE_VALUE valueForColSource,
                                               T_TARGET_VALUE valueForColTarget)
 {
  var newRecord=new MyContext.TEST_RECORD();

  newRecord.COL_SOURCE =valueForColSource;
  newRecord.COL_TARGET =valueForColTarget;

  db.testTable.Add(newRecord);

  db.SaveChanges();

  db.CheckTextOfLastExecutedCommand
   (new TestSqlTemplate()
     .T("INSERT INTO ").N(c_NameOf__TABLE).T(" (").N(c_NameOf__COL_SOURCE).T(", ").N(c_NameOf__COL_TARGET).T(")").EOL()
     .T("VALUES (").P("p0").T(", ").P("p1").T(")").EOL()
     .T("RETURNING ").N("TEST_ID").EOL()
     .T("INTO ").P("p2").T(";"));

  Assert.IsTrue
   (newRecord.TEST_ID.HasValue);

  Console.WriteLine("TEST_ID: {0}",newRecord.TEST_ID.Value);

  return newRecord.TEST_ID.Value;
 }//Helper__InsertRow
};//class TestSet_MIX002__expression_with_nested_cvt

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.CastAs.SET_001

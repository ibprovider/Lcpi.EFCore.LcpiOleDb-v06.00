////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 26.11.2021.
//
// (target)source_column==(target)source_param
//
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using structure_lib=lcpi.lib.structure;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.CastAs.SET_001.Double.Byte{
////////////////////////////////////////////////////////////////////////////////

using T_SOURCE_VALUE=System.Double;
using T_TARGET_VALUE=System.Byte;

////////////////////////////////////////////////////////////////////////////////
//class TestSet__004__param

public static class TestSet__004__param
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
 public static void Test_001__m1_6()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_SOURCE_VALUE c_valueSource=-1.6;
     const T_TARGET_VALUE c_valueTarget=0;

     System.Int64? testID=Helper__InsertRow(db,c_valueSource,c_valueTarget);

     T_SOURCE_VALUE vv=c_valueSource;

     var recs=db.testTable.Where(r => (T_TARGET_VALUE)r.COL_SOURCE==(T_TARGET_VALUE)vv && r.TEST_ID==testID);

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(InvalidOperationException exc)
     {
      CheckErrors.PrintException_OK(exc);      

      Assert.NotNull
       (exc.InnerException);

      Assert.IsInstanceOf<structure_lib.exceptions.t_overflow_exception>
       (exc.InnerException);

      var e2=(structure_lib.exceptions.t_overflow_exception)exc.InnerException;

      Assert.NotNull
       (e2);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e2));

      Assert.NotNull
       (TestUtils.GetRecord(e2,0));

      CheckErrors.CheckErrorRecord__common_err__cant_convert_value_between_types_2
       (TestUtils.GetRecord(e2,0),
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_MasterCode__Double__Byte,
        lcpi.lib.com.HResultCode.DB_E_DATAOVERFLOW,
        typeof(T_SOURCE_VALUE),
        typeof(T_TARGET_VALUE));
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_001__m1_6

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002__m1_5()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_SOURCE_VALUE c_valueSource=-1.5;
     const T_TARGET_VALUE c_valueTarget=0;

     System.Int64? testID=Helper__InsertRow(db,c_valueSource,c_valueTarget);

     T_SOURCE_VALUE vv=c_valueSource;

     var recs=db.testTable.Where(r => (T_TARGET_VALUE)r.COL_SOURCE==(T_TARGET_VALUE)vv && r.TEST_ID==testID);

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(InvalidOperationException exc)
     {
      CheckErrors.PrintException_OK(exc);      

      Assert.NotNull
       (exc.InnerException);

      Assert.IsInstanceOf<structure_lib.exceptions.t_overflow_exception>
       (exc.InnerException);

      var e2=(structure_lib.exceptions.t_overflow_exception)exc.InnerException;

      Assert.NotNull
       (e2);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e2));

      Assert.NotNull
       (TestUtils.GetRecord(e2,0));

      CheckErrors.CheckErrorRecord__common_err__cant_convert_value_between_types_2
       (TestUtils.GetRecord(e2,0),
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_MasterCode__Double__Byte,
        lcpi.lib.com.HResultCode.DB_E_DATAOVERFLOW,
        typeof(T_SOURCE_VALUE),
        typeof(T_TARGET_VALUE));
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_002__m1_5

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_003__m1_4()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_SOURCE_VALUE c_valueSource=-1.4;
     const T_TARGET_VALUE c_valueTarget=0;

     System.Int64? testID=Helper__InsertRow(db,c_valueSource,c_valueTarget);

     T_SOURCE_VALUE vv=c_valueSource;

     var recs=db.testTable.Where(r => (T_TARGET_VALUE)r.COL_SOURCE==(T_TARGET_VALUE)vv && r.TEST_ID==testID);

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(InvalidOperationException exc)
     {
      CheckErrors.PrintException_OK(exc);      

      Assert.NotNull
       (exc.InnerException);

      Assert.IsInstanceOf<structure_lib.exceptions.t_overflow_exception>
       (exc.InnerException);

      var e2=(structure_lib.exceptions.t_overflow_exception)exc.InnerException;

      Assert.NotNull
       (e2);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e2));

      Assert.NotNull
       (TestUtils.GetRecord(e2,0));

      CheckErrors.CheckErrorRecord__common_err__cant_convert_value_between_types_2
       (TestUtils.GetRecord(e2,0),
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_MasterCode__Double__Byte,
        lcpi.lib.com.HResultCode.DB_E_DATAOVERFLOW,
        typeof(T_SOURCE_VALUE),
        typeof(T_TARGET_VALUE));
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_003__m1_4

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_004__m1()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_SOURCE_VALUE c_valueSource=-1.0;
     const T_TARGET_VALUE c_valueTarget=0;

     System.Int64? testID=Helper__InsertRow(db,c_valueSource,c_valueTarget);

     T_SOURCE_VALUE vv=c_valueSource;

     var recs=db.testTable.Where(r => (T_TARGET_VALUE)r.COL_SOURCE==(T_TARGET_VALUE)vv && r.TEST_ID==testID);

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(InvalidOperationException exc)
     {
      CheckErrors.PrintException_OK(exc);      

      Assert.NotNull
       (exc.InnerException);

      Assert.IsInstanceOf<structure_lib.exceptions.t_overflow_exception>
       (exc.InnerException);

      var e2=(structure_lib.exceptions.t_overflow_exception)exc.InnerException;

      Assert.NotNull
       (e2);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e2));

      Assert.NotNull
       (TestUtils.GetRecord(e2,0));

      CheckErrors.CheckErrorRecord__common_err__cant_convert_value_between_types_2
       (TestUtils.GetRecord(e2,0),
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_MasterCode__Double__Byte,
        lcpi.lib.com.HResultCode.DB_E_DATAOVERFLOW,
        typeof(T_SOURCE_VALUE),
        typeof(T_TARGET_VALUE));
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_004__m1

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_005__zero()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_SOURCE_VALUE c_valueSource=0.0;
     const T_TARGET_VALUE c_valueTarget=0;

     System.Int64? testID=Helper__InsertRow(db,c_valueSource,c_valueTarget);

     T_SOURCE_VALUE vv=c_valueSource;

     var recs=db.testTable.Where(r => (T_TARGET_VALUE)r.COL_SOURCE==(T_TARGET_VALUE)vv && r.TEST_ID==testID);

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
       (c_valueSource,
        r.COL_SOURCE);

      Assert.AreEqual
       (c_valueTarget,
        r.COL_TARGET);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_SOURCE).T(", ").N("t",c_NameOf__COL_TARGET).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (CASE WHEN COALESCE(TRUNC(").N("t",c_NameOf__COL_SOURCE).T(") BETWEEN 0 AND 255, TRUE) THEN CAST(TRUNC(").N("t",c_NameOf__COL_SOURCE).T(") AS SMALLINT) ELSE CAST('CANNOT CONVERT VALUE TO BYTE. OVERFLOW ERROR.' AS SMALLINT) END = ").P_I2("__p_0").T(") AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_005__zero

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_006__p1()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_SOURCE_VALUE c_valueSource=+1.0;
     const T_TARGET_VALUE c_valueTarget=+1;

     System.Int64? testID=Helper__InsertRow(db,c_valueSource,c_valueTarget);

     T_SOURCE_VALUE vv=c_valueSource;

     var recs=db.testTable.Where(r => (T_TARGET_VALUE)r.COL_SOURCE==(T_TARGET_VALUE)vv && r.TEST_ID==testID);

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
       (c_valueSource,
        r.COL_SOURCE);

      Assert.AreEqual
       (c_valueTarget,
        r.COL_TARGET);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_SOURCE).T(", ").N("t",c_NameOf__COL_TARGET).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (CASE WHEN COALESCE(TRUNC(").N("t",c_NameOf__COL_SOURCE).T(") BETWEEN 0 AND 255, TRUE) THEN CAST(TRUNC(").N("t",c_NameOf__COL_SOURCE).T(") AS SMALLINT) ELSE CAST('CANNOT CONVERT VALUE TO BYTE. OVERFLOW ERROR.' AS SMALLINT) END = ").P_I2("__p_0").T(") AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_006__p1

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_007__p1_4()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_SOURCE_VALUE c_valueSource=+1.4;
     const T_TARGET_VALUE c_valueTarget=+1;

     System.Int64? testID=Helper__InsertRow(db,c_valueSource,c_valueTarget);

     T_SOURCE_VALUE vv=c_valueSource;

     var recs=db.testTable.Where(r => (T_TARGET_VALUE)r.COL_SOURCE==(T_TARGET_VALUE)vv && r.TEST_ID==testID);

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
       (c_valueSource,
        r.COL_SOURCE);

      Assert.AreEqual
       (c_valueTarget,
        r.COL_TARGET);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_SOURCE).T(", ").N("t",c_NameOf__COL_TARGET).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (CASE WHEN COALESCE(TRUNC(").N("t",c_NameOf__COL_SOURCE).T(") BETWEEN 0 AND 255, TRUE) THEN CAST(TRUNC(").N("t",c_NameOf__COL_SOURCE).T(") AS SMALLINT) ELSE CAST('CANNOT CONVERT VALUE TO BYTE. OVERFLOW ERROR.' AS SMALLINT) END = ").P_I2("__p_0").T(") AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_007__p1_4

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_008__p1_5()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_SOURCE_VALUE c_valueSource=+1.5;
     const T_TARGET_VALUE c_valueTarget=+1;

     System.Int64? testID=Helper__InsertRow(db,c_valueSource,c_valueTarget);

     T_SOURCE_VALUE vv=c_valueSource;

     var recs=db.testTable.Where(r => (T_TARGET_VALUE)r.COL_SOURCE==(T_TARGET_VALUE)vv && r.TEST_ID==testID);

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
       (c_valueSource,
        r.COL_SOURCE);

      Assert.AreEqual
       (c_valueTarget,
        r.COL_TARGET);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_SOURCE).T(", ").N("t",c_NameOf__COL_TARGET).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (CASE WHEN COALESCE(TRUNC(").N("t",c_NameOf__COL_SOURCE).T(") BETWEEN 0 AND 255, TRUE) THEN CAST(TRUNC(").N("t",c_NameOf__COL_SOURCE).T(") AS SMALLINT) ELSE CAST('CANNOT CONVERT VALUE TO BYTE. OVERFLOW ERROR.' AS SMALLINT) END = ").P_I2("__p_0").T(") AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_008__p1_5

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_009__p1_6()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_SOURCE_VALUE c_valueSource=+1.6;
     const T_TARGET_VALUE c_valueTarget=+1;

     System.Int64? testID=Helper__InsertRow(db,c_valueSource,c_valueTarget);

     T_SOURCE_VALUE vv=c_valueSource;

     var recs=db.testTable.Where(r => (T_TARGET_VALUE)r.COL_SOURCE==(T_TARGET_VALUE)vv && r.TEST_ID==testID);

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
       (c_valueSource,
        r.COL_SOURCE);

      Assert.AreEqual
       (c_valueTarget,
        r.COL_TARGET);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_SOURCE).T(", ").N("t",c_NameOf__COL_TARGET).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (CASE WHEN COALESCE(TRUNC(").N("t",c_NameOf__COL_SOURCE).T(") BETWEEN 0 AND 255, TRUE) THEN CAST(TRUNC(").N("t",c_NameOf__COL_SOURCE).T(") AS SMALLINT) ELSE CAST('CANNOT CONVERT VALUE TO BYTE. OVERFLOW ERROR.' AS SMALLINT) END = ").P_I2("__p_0").T(") AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_009__p1_6

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_MM001__min()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_SOURCE_VALUE c_valueSource=T_TARGET_VALUE.MinValue;
     const T_TARGET_VALUE c_valueTarget=+1;

     System.Int64? testID=Helper__InsertRow(db,c_valueSource,c_valueTarget);

     T_SOURCE_VALUE vv=c_valueSource;

     var recs=db.testTable.Where(r => (T_TARGET_VALUE)r.COL_SOURCE==(T_TARGET_VALUE)vv && r.TEST_ID==testID);

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
       (c_valueSource,
        r.COL_SOURCE);

      Assert.AreEqual
       (c_valueTarget,
        r.COL_TARGET);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_SOURCE).T(", ").N("t",c_NameOf__COL_TARGET).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (CASE WHEN COALESCE(TRUNC(").N("t",c_NameOf__COL_SOURCE).T(") BETWEEN 0 AND 255, TRUE) THEN CAST(TRUNC(").N("t",c_NameOf__COL_SOURCE).T(") AS SMALLINT) ELSE CAST('CANNOT CONVERT VALUE TO BYTE. OVERFLOW ERROR.' AS SMALLINT) END = ").P_I2("__p_0").T(") AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_MM001__min

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_MM002__max()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_SOURCE_VALUE c_valueSource=T_TARGET_VALUE.MaxValue;
     const T_TARGET_VALUE c_valueTarget=+1;

     System.Int64? testID=Helper__InsertRow(db,c_valueSource,c_valueTarget);

     T_SOURCE_VALUE vv=c_valueSource;

     var recs=db.testTable.Where(r => (T_TARGET_VALUE)r.COL_SOURCE==(T_TARGET_VALUE)vv && r.TEST_ID==testID);

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
       (c_valueSource,
        r.COL_SOURCE);

      Assert.AreEqual
       (c_valueTarget,
        r.COL_TARGET);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_SOURCE).T(", ").N("t",c_NameOf__COL_TARGET).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (CASE WHEN COALESCE(TRUNC(").N("t",c_NameOf__COL_SOURCE).T(") BETWEEN 0 AND 255, TRUE) THEN CAST(TRUNC(").N("t",c_NameOf__COL_SOURCE).T(") AS SMALLINT) ELSE CAST('CANNOT CONVERT VALUE TO BYTE. OVERFLOW ERROR.' AS SMALLINT) END = ").P_I2("__p_0").T(") AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_MM002__max

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_MM003__minP9()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_SOURCE_VALUE c_valueSource=0.9D;
     const T_TARGET_VALUE c_valueTarget=+1;

     System.Int64? testID=Helper__InsertRow(db,c_valueSource,c_valueTarget);

     T_SOURCE_VALUE vv=c_valueSource;

     var recs=db.testTable.Where(r => (T_TARGET_VALUE)r.COL_SOURCE==(T_TARGET_VALUE)vv && r.TEST_ID==testID);

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
       (c_valueSource,
        r.COL_SOURCE);

      Assert.AreEqual
       (c_valueTarget,
        r.COL_TARGET);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_SOURCE).T(", ").N("t",c_NameOf__COL_TARGET).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (CASE WHEN COALESCE(TRUNC(").N("t",c_NameOf__COL_SOURCE).T(") BETWEEN 0 AND 255, TRUE) THEN CAST(TRUNC(").N("t",c_NameOf__COL_SOURCE).T(") AS SMALLINT) ELSE CAST('CANNOT CONVERT VALUE TO BYTE. OVERFLOW ERROR.' AS SMALLINT) END = ").P_I2("__p_0").T(") AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_MM003__minP9

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_MM004__maxP9()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_SOURCE_VALUE c_valueSource=255.9D;
     const T_TARGET_VALUE c_valueTarget=+1;

     System.Int64? testID=Helper__InsertRow(db,c_valueSource,c_valueTarget);

     T_SOURCE_VALUE vv=c_valueSource;

     var recs=db.testTable.Where(r => (T_TARGET_VALUE)r.COL_SOURCE==(T_TARGET_VALUE)vv && r.TEST_ID==testID);

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
       (c_valueSource,
        r.COL_SOURCE);

      Assert.AreEqual
       (c_valueTarget,
        r.COL_TARGET);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_SOURCE).T(", ").N("t",c_NameOf__COL_TARGET).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (CASE WHEN COALESCE(TRUNC(").N("t",c_NameOf__COL_SOURCE).T(") BETWEEN 0 AND 255, TRUE) THEN CAST(TRUNC(").N("t",c_NameOf__COL_SOURCE).T(") AS SMALLINT) ELSE CAST('CANNOT CONVERT VALUE TO BYTE. OVERFLOW ERROR.' AS SMALLINT) END = ").P_I2("__p_0").T(") AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_MM004__maxP9

 //-----------------------------------------------------------------------
 private static System.Int64 Helper__InsertRow(MyContext      db,
                                               T_SOURCE_VALUE valueForColSource,
                                               T_TARGET_VALUE valueForColTarget)
 {
  var newRecord=new MyContext.TEST_RECORD();

  newRecord.COL_SOURCE  =valueForColSource;
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
};//class TestSet__004__param

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.CastAs.SET_001.Double.Byte

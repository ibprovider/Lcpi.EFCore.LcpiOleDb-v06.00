////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 26.11.2020.
using System;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

using structure_lib=lcpi.lib.structure;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Operators.SET_002__AS_STR.Multiply.Complete.Int64.Double{
////////////////////////////////////////////////////////////////////////////////

using T_DATA1   =System.Int64;
using T_DATA2   =System.Double;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_001__fields

public static class TestSet_001__fields
{
 private const string c_NameOf__TABLE            ="TEST_MODIFY_ROW2";
 private const string c_NameOf__COL_DATA1        ="COL_BIGINT";
 private const string c_NameOf__COL_DATA2        ="COL2_DOUBLE";

 private sealed class MyContext:TestBaseDbContext
 {
  [Table(c_NameOf__TABLE)]
  public sealed class TEST_RECORD
  {
   [Key]
   [Column("TEST_ID")]
   public System.Int64? TEST_ID { get; set; }

   [Column(c_NameOf__COL_DATA1)]
   public T_DATA1 COL_DATA1 { get; set; }

   [Column(c_NameOf__COL_DATA2)]
   public T_DATA2 COL_DATA2 { get; set; }
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
     const T_DATA1 c_value1=7;
     const T_DATA2 c_value2=4;

     System.Int64? testID=Helper__InsertRow(db,c_value1,c_value2);

     Assert.AreEqual
      (11,
       c_value1+c_value2);

     var recs=db.testTable.Where(r => (string)(object)(r.COL_DATA1*r.COL_DATA2)=="28.00000000000000" && r.TEST_ID==testID);

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
       (c_value1,
        r.COL_DATA1);

      Assert.AreEqual
       (c_value2,
        r.COL_DATA2);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA1).T(", ").N("t",c_NameOf__COL_DATA2).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (CAST((").N_AS_DBL("t",c_NameOf__COL_DATA1).T(" * ").N("t",c_NameOf__COL_DATA2).T(") AS VARCHAR(32)) = _utf8 '28.00000000000000') AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

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
 public static void Test_MM001__min_min()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA1 vv1=T_DATA1.MinValue;
     T_DATA2 vv2=T_DATA2.MinValue;

     var recs=db.testTable.Where(r => (string)(object)(vv1*vv2)==MasterValues.c_Result__min_min);

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(InvalidOperationException e)
     {
      CheckErrors.PrintException_OK(e);

      Assert.NotNull
       (e.InnerException);

      Assert.IsInstanceOf<structure_lib.exceptions.t_overflow_exception>
       (e.InnerException);

      var e2
       =(structure_lib.exceptions.t_overflow_exception)e.InnerException;

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e2));

      CheckErrors.CheckErrorRecord__common_err__overflow_in_arithmetic_op2__5<double,double>
       (TestUtils.GetRecord(e2,0),
        CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0__Query_Local_D0_Expressions__Op2_MasterCode__Multiply___Double__Double,
        System.Linq.Expressions.ExpressionType.Multiply,
        "-9.223372036854776E+18",
        "-1.7976931348623157E+308");

      Assert.IsNull
       (e2.InnerException);
     }//catch
    }//using db

    tr.Commit();
   }//using tr
  }//using cn
 }//Test_MM001__min_min

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_MM002__max_max()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA1 vv1=T_DATA1.MaxValue;
     T_DATA2 vv2=T_DATA2.MaxValue;

     var recs=db.testTable.Where(r => (string)(object)(vv1*vv2)==MasterValues.c_Result__max_max);

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(InvalidOperationException e)
     {
      CheckErrors.PrintException_OK(e);

      Assert.NotNull
       (e.InnerException);

      Assert.IsInstanceOf<structure_lib.exceptions.t_overflow_exception>
       (e.InnerException);

      var e2
       =(structure_lib.exceptions.t_overflow_exception)e.InnerException;

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e2));

      CheckErrors.CheckErrorRecord__common_err__overflow_in_arithmetic_op2__5<double,double>
       (TestUtils.GetRecord(e2,0),
        CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0__Query_Local_D0_Expressions__Op2_MasterCode__Multiply___Double__Double,
        System.Linq.Expressions.ExpressionType.Multiply,
        "9.223372036854776E+18",
        "1.7976931348623157E+308");

      Assert.IsNull
       (e2.InnerException);
     }//catch
    }//using db

    tr.Commit();
   }//using tr
  }//using cn
 }//Test_MM002__max_max

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_MM003__min_max()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA1 vv1=T_DATA1.MinValue;
     T_DATA2 vv2=T_DATA2.MaxValue;

     var recs=db.testTable.Where(r => (string)(object)(vv1*vv2)==MasterValues.c_Result__min_max);

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(InvalidOperationException e)
     {
      CheckErrors.PrintException_OK(e);

      Assert.NotNull
       (e.InnerException);

      Assert.IsInstanceOf<structure_lib.exceptions.t_overflow_exception>
       (e.InnerException);

      var e2
       =(structure_lib.exceptions.t_overflow_exception)e.InnerException;

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e2));

      CheckErrors.CheckErrorRecord__common_err__overflow_in_arithmetic_op2__5<double,double>
       (TestUtils.GetRecord(e2,0),
        CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0__Query_Local_D0_Expressions__Op2_MasterCode__Multiply___Double__Double,
        System.Linq.Expressions.ExpressionType.Multiply,
        "-9.223372036854776E+18",
        "1.7976931348623157E+308");

      Assert.IsNull
       (e2.InnerException);
     }//catch
    }//using db

    tr.Commit();
   }//using tr
  }//using cn
 }//Test_MM003__min_max

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_MM004__max_min()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA1 vv1=T_DATA1.MaxValue;
     T_DATA2 vv2=T_DATA2.MinValue;

     var recs=db.testTable.Where(r => (string)(object)(vv1*vv2)==MasterValues.c_Result__max_min);

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(InvalidOperationException e)
     {
      CheckErrors.PrintException_OK(e);

      Assert.NotNull
       (e.InnerException);

      Assert.IsInstanceOf<structure_lib.exceptions.t_overflow_exception>
       (e.InnerException);

      var e2
       =(structure_lib.exceptions.t_overflow_exception)e.InnerException;

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e2));

      CheckErrors.CheckErrorRecord__common_err__overflow_in_arithmetic_op2__5<double,double>
       (TestUtils.GetRecord(e2,0),
        CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0__Query_Local_D0_Expressions__Op2_MasterCode__Multiply___Double__Double,
        System.Linq.Expressions.ExpressionType.Multiply,
        "9.223372036854776E+18",
        "-1.7976931348623157E+308");

      Assert.IsNull
       (e2.InnerException);
     }//catch
    }//using db

    tr.Commit();
   }//using tr
  }//using cn
 }//Test_MM004__max_min

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_A001()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_DATA1 c_value1=7;
     const T_DATA2 c_value2=4;

     System.Int64? testID=Helper__InsertRow(db,c_value1,c_value2);

     Assert.AreEqual
      (11,
       c_value1+c_value2);

     var recs=db.testTable.Where(r => (string)(object)(r.COL_DATA1*r.COL_DATA2*1)=="28.00000000000000" && r.TEST_ID==testID);

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
       (c_value1,
        r.COL_DATA1);

      Assert.AreEqual
       (c_value2,
        r.COL_DATA2);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA1).T(", ").N("t",c_NameOf__COL_DATA2).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (CAST(((").N_AS_DBL("t",c_NameOf__COL_DATA1).T(" * ").N("t",c_NameOf__COL_DATA2).T(") * 1.0) AS VARCHAR(32)) = _utf8 '28.00000000000000') AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_A001

 //Helper methdods -------------------------------------------------------
 private static System.Int64 Helper__InsertRow(MyContext db,
                                               T_DATA1   valueForColData1,
                                               T_DATA2   valueForColData2)
 {
  var newRecord=new MyContext.TEST_RECORD();

  newRecord.COL_DATA1 =valueForColData1;
  newRecord.COL_DATA2 =valueForColData2;

  db.testTable.Add(newRecord);

  db.SaveChanges();

  db.CheckTextOfLastExecutedCommand
   (new TestSqlTemplate()
     .T("INSERT INTO ").N(c_NameOf__TABLE).T(" (").N(c_NameOf__COL_DATA1).T(", ").N(c_NameOf__COL_DATA2).T(")").EOL()
     .T("VALUES (").P("p0").T(", ").P("p1").T(")").EOL()
     .T("RETURNING ").N("TEST_ID").EOL()
     .T("INTO ").P("p2").T(";"));

  Assert.IsTrue
   (newRecord.TEST_ID.HasValue);

  Console.WriteLine("TEST_ID: {0}",newRecord.TEST_ID.Value);

  return newRecord.TEST_ID.Value;
 }//Helper__InsertRow
};//class TestSet_001__fields

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Operators.SET_002__AS_STR.Multiply.Complete.Int64.Double

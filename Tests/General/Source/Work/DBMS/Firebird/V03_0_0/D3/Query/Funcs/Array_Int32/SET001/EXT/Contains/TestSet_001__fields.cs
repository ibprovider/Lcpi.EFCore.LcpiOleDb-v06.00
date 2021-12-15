////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 11.06.2021.
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.Array_Int32.SET001.EXT.Contains{
////////////////////////////////////////////////////////////////////////////////
//using

using T_DATA=System.Int32;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_001__fields

public static class TestSet_001__fields
{
 private const string c_NameOf__TABLE="TEST_MODIFY_ROW";

 private const string c_NameOf__COL_DATA="COL_INTEGER";

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
     const T_DATA c_data=123;

     System.Int64? testID=Helper__InsertRow(db,c_data);

     T_DATA[] values=new T_DATA[]{1,2,123,4};

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
        .T("WHERE ").N("t",c_NameOf__COL_DATA).T(" IN (1, 2, 123, 4) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));

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
     const T_DATA c_data=123;

     System.Int64? testID=Helper__InsertRow(db,c_data);

     var recs=db.testTable.Where(r => (new T_DATA[]{1,2,123,4}).Contains(r.DATA) && r.TEST_ID==testID);

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
        .T("WHERE ").N("t",c_NameOf__COL_DATA).T(" IN (1, 2, 123, 4) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_002__const

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_N001()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_DATA c_data=123;

     System.Int64? testID=Helper__InsertRow(db,c_data);

     T_DATA[] values=null;

     var recs=db.testTable.Where(r => values.Contains(r.DATA) && r.TEST_ID==testID);

     try
     {
      //
      // [2021-06-21] Current implementation of EF.Core throws NullReferenceException exception
      //
      // Call stack:
      //
      // SqlNullabilityProcessor.<VisitIn>g__ProcessInExpressionValues|27_0(SqlExpression valuesExpression, Boolean extractNullValues) line 718
      // SqlNullabilityProcessor.VisitIn(InExpression inExpression, Boolean allowOptimizedExpansion, Boolean& nullable) line 644
      // SqlNullabilityProcessor.Visit(SqlExpression sqlExpression, Boolean allowOptimizedExpansion, Boolean preserveNonNullableColumns, Boolean& nullable) line 387
      // SqlNullabilityProcessor.VisitSqlBinary(SqlBinaryExpression sqlBinaryExpression, Boolean allowOptimizedExpansion, Boolean& nullable) line 854
      //

      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(NullReferenceException e)
     {
      CheckErrors.PrintException_OK(e);
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_N001

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_N002__const()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_DATA c_data=123;

     System.Int64? testID=Helper__InsertRow(db,c_data);

     var recs=db.testTable.Where(r => ((T_DATA[])null).Contains(r.DATA) && r.TEST_ID==testID);

     try
     {
      //
      // [2021-06-21] Current implementation of EF.Core throws NullReferenceException exception
      //
      // Call stack:
      //
      // SqlNullabilityProcessor.<VisitIn>g__ProcessInExpressionValues|27_0(SqlExpression valuesExpression, Boolean extractNullValues) line 722
      // SqlNullabilityProcessor.VisitIn(InExpression inExpression, Boolean allowOptimizedExpansion, Boolean& nullable) line 644
      // SqlNullabilityProcessor.Visit(SqlExpression sqlExpression, Boolean allowOptimizedExpansion, Boolean preserveNonNullableColumns, Boolean& nullable) line 387
      // SqlNullabilityProcessor.VisitSqlBinary(SqlBinaryExpression sqlBinaryExpression, Boolean allowOptimizedExpansion, Boolean& nullable) line 854
      //

      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(NullReferenceException e)
     {
      CheckErrors.PrintException_OK(e);
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_N002__const

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
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.Array_Int32.SET001.EXT.Contains

////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 29.11.2020.
using System;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Operators.SET_001.Add.Complete.TimeSpan.NullableTimeSpan{
////////////////////////////////////////////////////////////////////////////////

using T_DATA1   =System.TimeSpan;
using T_DATA2   =System.Nullable<System.TimeSpan>;
using T_RESULT  =System.Nullable<System.TimeSpan>;

using T_DATA1_U =System.TimeSpan;
using T_DATA2_U =System.TimeSpan;
using T_RESULT_U=System.TimeSpan;

using DB_TABLE=LocalDbObjNames.TEST_MODIFY_ROW2;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_001__fields

public static class TestSet_001__fields
{
 private const string c_NameOf__TABLE            =DB_TABLE.Name;
 private const string c_NameOf__COL_DATA1        =DB_TABLE.Columns.COL_for_TimeSpan;
 private const string c_NameOf__COL_DATA2        =DB_TABLE.Columns.COL2_for_TimeSpan;

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
     T_DATA1 c_value1=new T_DATA1_U(12,10,8);
     T_DATA2 c_value2=new T_DATA2_U(5,3,59);

     System.Int64? testID=Helper__InsertRow(db,c_value1,c_value2);

     Assert.AreEqual
      (new System.TimeSpan(17,14,7),
       c_value1+c_value2);

     var recs=db.testTable.Where(r => (r.COL_DATA1+r.COL_DATA2)==(T_RESULT)new T_RESULT_U(17,14,7) && r.TEST_ID==testID);

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }

      TestServices.ThrowWeWaitError();
     }
     catch(lcpi.lib.structure.exceptions.t_invalid_operation_exception e)
     {
      CheckErrors.PrintException_OK(e);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e));

      CheckErrors.CheckErrorRecord__sql_translator_err__unsupported_binary_operator_type_3
       (TestUtils.GetRecord(e,0),
        CheckErrors.c_src__EFCoreDataProvider__FB_Common__BinaryOperatorTranslatorProvider,
        Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.LcpiOleDb__ExpressionType.Add,
        typeof(T_DATA1_U),
        typeof(T_DATA2_U));
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_001

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_001__negative()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA1 c_value1=new T_DATA1_U(12,10,8);
     T_DATA2 c_value2=new T_DATA2_U()-new T_DATA2_U(5,3,59);

     System.Int64? testID=Helper__InsertRow(db,c_value1,c_value2);

     Assert.AreEqual
      (new System.TimeSpan(7,6,9),
       c_value1+c_value2);

     var recs=db.testTable.Where(r => (r.COL_DATA1+r.COL_DATA2)==((T_RESULT)new T_RESULT_U(7,6,9)) && r.TEST_ID==testID);

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }

      TestServices.ThrowWeWaitError();
     }
     catch(lcpi.lib.structure.exceptions.t_invalid_operation_exception e)
     {
      CheckErrors.PrintException_OK(e);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e));

      CheckErrors.CheckErrorRecord__sql_translator_err__unsupported_binary_operator_type_3
       (TestUtils.GetRecord(e,0),
        CheckErrors.c_src__EFCoreDataProvider__FB_Common__BinaryOperatorTranslatorProvider,
        Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.LcpiOleDb__ExpressionType.Add,
        typeof(T_DATA1_U),
        typeof(T_DATA2_U));
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_001__negative

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002__non_zero_days_count()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA1 c_value1=new T_DATA1_U(12,10,8);
     T_DATA2 c_value2=new T_DATA2_U(1,1,3,59,0);

     System.Int64? testID=Helper__InsertRow(db,c_value1,c_value2);

     Assert.AreEqual
      (new System.TimeSpan(1,13,14,7,0),
       c_value1+c_value2);

     var recs=db.testTable.Where(r => (r.COL_DATA1+r.COL_DATA2)==((T_RESULT)new T_RESULT_U(3,17,14,7,0)) && r.TEST_ID==testID);

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }

      TestServices.ThrowWeWaitError();
     }
     catch(lcpi.lib.structure.exceptions.t_invalid_operation_exception e)
     {
      CheckErrors.PrintException_OK(e);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e));

      CheckErrors.CheckErrorRecord__sql_translator_err__unsupported_binary_operator_type_3
       (TestUtils.GetRecord(e,0),
        CheckErrors.c_src__EFCoreDataProvider__FB_Common__BinaryOperatorTranslatorProvider,
        Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.LcpiOleDb__ExpressionType.Add,
        typeof(T_DATA1_U),
        typeof(T_DATA2_U));
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_002__non_zero_days_count

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002__non_zero_days_count__negative()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA1 c_value1=new T_DATA1_U(12,10,8);
     T_DATA2 c_value2=new T_DATA2_U()-new T_DATA2_U(1,1,3,59,0);

     System.Int64? testID=Helper__InsertRow(db,c_value1,c_value2);

     Assert.AreEqual
      (-new System.TimeSpan(0,12,53,51),
       c_value1+c_value2);

     var recs=db.testTable.Where(r => (r.COL_DATA1+r.COL_DATA2)==((T_RESULT)(new T_RESULT_U()-new T_RESULT_U(2,16,53,51))) && r.TEST_ID==testID);

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }

      TestServices.ThrowWeWaitError();
     }
     catch(lcpi.lib.structure.exceptions.t_invalid_operation_exception e)
     {
      CheckErrors.PrintException_OK(e);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e));

      CheckErrors.CheckErrorRecord__sql_translator_err__unsupported_binary_operator_type_3
       (TestUtils.GetRecord(e,0),
        CheckErrors.c_src__EFCoreDataProvider__FB_Common__BinaryOperatorTranslatorProvider,
        Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.LcpiOleDb__ExpressionType.Add,
        typeof(T_DATA1_U),
        typeof(T_DATA2_U));
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_002__non_zero_days_count

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_003__mcs()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA1 c_value1=new T_DATA1_U(12,10,8);
     T_DATA2 c_value2=new T_DATA2_U(5,3,59).Add(new T_DATA2_U(2000));

     System.Int64? testID=Helper__InsertRow(db,c_value1,c_value2);

     Assert.AreEqual
      (new System.TimeSpan(17,14,7)+new System.TimeSpan(2000),
       c_value1+c_value2);

     var recs=db.testTable.Where(r => (r.COL_DATA1+r.COL_DATA2)==((T_RESULT)(new T_RESULT_U(17,14,7)+new T_RESULT_U(2000))) && r.TEST_ID==testID);

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }

      TestServices.ThrowWeWaitError();
     }
     catch(lcpi.lib.structure.exceptions.t_invalid_operation_exception e)
     {
      CheckErrors.PrintException_OK(e);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e));

      CheckErrors.CheckErrorRecord__sql_translator_err__unsupported_binary_operator_type_3
       (TestUtils.GetRecord(e,0),
        CheckErrors.c_src__EFCoreDataProvider__FB_Common__BinaryOperatorTranslatorProvider,
        Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.LcpiOleDb__ExpressionType.Add,
        typeof(T_DATA1_U),
        typeof(T_DATA2_U));
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_003__mcs

 //-----------------------------------------------------------------------
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
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Operators.SET_001.Add.Complete.TimeSpan.NullableTimeSpan

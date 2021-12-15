////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 30.03.2021.
using System;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Operators.SET_002__AS_STR.Divide.Complete.Double.Single{
////////////////////////////////////////////////////////////////////////////////

using T_DATA1   =System.Double;
using T_DATA2   =System.Single;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_ERR001__fields

public static class TestSet_ERR001__fields
{
 private const string c_NameOf__TABLE            ="TEST_MODIFY_ROW2";
 private const string c_NameOf__COL_DATA1        ="COL_DOUBLE";
 private const string c_NameOf__COL_DATA2        ="COL2_FLOAT";

 private const int c_RESULT_VCH_LEN=32;

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
 public static void Test_001___divide_by_zero()
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
     const T_DATA2 c_value2=0;

     System.Int64? testID=Helper__InsertRow(db,c_value1,c_value2);

     var recs=db.testTable.Where(r => (string)(object)(r.COL_DATA1/r.COL_DATA2)=="BLA-BLA-BLA" && r.TEST_ID==testID);

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//for r

      TestServices.ThrowWeWaitError();
     }
     catch(xdb.OleDbException exc)
     {
      CheckErrors.PrintException_OK(exc);

      Assert.AreEqual
       (2,
        exc.Errors.Count);

      CheckErrors.CheckOleDbError__Firebird__FloatDivideByZero
       (exc.Errors[0]);

      Assert.AreEqual
       (3,
        TestUtils.GetRecordCount(exc));

      CheckErrors.CheckErrorRecord__IBP__FailedToFetchResultSetData
       (TestUtils.GetRecord(exc,1));
     }//catch

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA1).T(", ").N("t",c_NameOf__COL_DATA2).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (").PUSH().N("t",c_NameOf__COL_DATA1).T(" / ").N("t",c_NameOf__COL_DATA2).W_BRKTS().W_CastAsVCH(c_RESULT_VCH_LEN).POP().T(" = _utf8 'BLA-BLA-BLA') AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_001___divide_by_zero

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002___overflow()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_DATA1 c_value1=T_DATA1.MaxValue;
     const T_DATA2 c_value2=0.1F;

     System.Int64? testID=Helper__InsertRow(db,c_value1,c_value2);

     var recs=db.testTable.Where(r => (string)(object)(r.COL_DATA1/r.COL_DATA2)=="BLA-BLA-BLA" && r.TEST_ID==testID);

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//for r

      TestServices.ThrowWeWaitError();
     }
     catch(xdb.OleDbException exc)
     {
      CheckErrors.PrintException_OK(exc);

      Assert.AreEqual
       (2,
        exc.Errors.Count);

      CheckErrors.CheckOleDbError__Firebird__FloatOpOverflow
       (exc.Errors[0]);

      Assert.AreEqual
       (3,
        TestUtils.GetRecordCount(exc));

      CheckErrors.CheckErrorRecord__IBP__FailedToFetchResultSetData
       (TestUtils.GetRecord(exc,1));
     }//catch

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA1).T(", ").N("t",c_NameOf__COL_DATA2).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (").PUSH().N("t",c_NameOf__COL_DATA1).T(" / ").N("t",c_NameOf__COL_DATA2).W_BRKTS().W_CastAsVCH(c_RESULT_VCH_LEN).POP().T(" = _utf8 'BLA-BLA-BLA') AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_002___overflow

 //Helper methods --------------------------------------------------------
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
};//class TestSet_ERR001__fields

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Operators.SET_002__AS_STR.Divide.Complete.Double.Single

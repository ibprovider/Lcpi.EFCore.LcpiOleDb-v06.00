////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 14.07.2021.
//
// <field>.AddMonths
//
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DataTypes.Extensions;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Funcs.DateOnly.SET001.EXT.AddMonths{
////////////////////////////////////////////////////////////////////////////////
//using

using T_DATA  =System.DateOnly;
using T_DATA_U=System.DateOnly;

using T_AMOUNT  =System.Nullable<System.Int32>;
using T_AMOUNT_U=System.Int32;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_001__fields__03__N2

public static class TestSet_001__fields__03__N2
{
 private const string c_NameOf__TABLE="TEST_MODIFY_ROW";

 private const string c_NameOf__COL_DATA="COL_TYPE_DATE";
 
 private const string c_NameOf__COL_AMOUNT="COL_INTEGER";

 //-----------------------------------------------------------------------
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

   [Column(c_NameOf__COL_AMOUNT)]
   public T_AMOUNT AMOUNT { get; set; }
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
     T_DATA c_data=new T_DATA_U(2021,7,17);

     System.Int64? testID=Helper__InsertRow(db,c_data,null);

     T_DATA vv=new T_DATA_U(2021,7,17);

     var recs=db.testTable.Where(r => r.DATA.AddMonths(r.AMOUNT)==vv && r.TEST_ID==testID);

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_AMOUNT).T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (DATEADD(MONTH,").N("t",c_NameOf__COL_AMOUNT).T(",").N("t",c_NameOf__COL_DATA).T(") = ").P("__vv_0").T(") AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_02

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_31()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA c_data=new T_DATA_U(2021,7,17);

     System.Int64? testID=Helper__InsertRow(db,c_data,null);

     var recs=db.testTable.Where(r => r.DATA.AddMonths(r.AMOUNT)==r.DATA.AddMonths(r.AMOUNT) && r.TEST_ID==testID);

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

     //! \todo Research - why r.DATA.AddMonths==r.DATA.AddMonths still exists in SQL?
     //!  Note that, problem with nullability of our AddMonths translation.

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_AMOUNT).T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE ((DATEADD(MONTH,").N("t",c_NameOf__COL_AMOUNT).T(",").N("t",c_NameOf__COL_DATA).T(") = DATEADD(MONTH,").N("t",c_NameOf__COL_AMOUNT).T(",").N("t",c_NameOf__COL_DATA).T(")) OR (").N("t",c_NameOf__COL_AMOUNT).IS_NULL().T(")) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_31

 //-----------------------------------------------------------------------
 private static System.Int64 Helper__InsertRow(MyContext db,
                                               T_DATA    valueOfData,
                                               T_AMOUNT  valueOfAmount)
 {
  var newRecord=new MyContext.TEST_RECORD();

  newRecord.DATA=valueOfData;

  newRecord.AMOUNT=valueOfAmount;

  db.testTable.Add(newRecord);

  db.SaveChanges();

  db.CheckTextOfLastExecutedCommand
   (new TestSqlTemplate()
     .T("INSERT INTO ").N(c_NameOf__TABLE).T(" (").N(c_NameOf__COL_AMOUNT).T(", ").N(c_NameOf__COL_DATA).T(")").EOL()
     .T("VALUES (").P("p0").T(", ").P("p1").T(")").EOL()
     .T("RETURNING ").N("TEST_ID").EOL()
     .T("INTO ").P("p2").T(";"));

  Assert.IsTrue
   (newRecord.TEST_ID.HasValue);

  Console.WriteLine("TEST_ID: {0}",newRecord.TEST_ID.Value);

  return newRecord.TEST_ID.Value;
 }//Helper__InsertRow
};//class TestSet_001__fields__03__N2

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Funcs.DateOnly.SET001.EXT.AddMonths

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

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Funcs.NullableTimeOnly.SET001.EXT.IsBetween{
////////////////////////////////////////////////////////////////////////////////
//using

using T_DATA1  =System.Nullable<System.TimeOnly>;
using T_DATA2  =System.Nullable<System.TimeOnly>;
using T_DATA3  =System.Nullable<System.TimeOnly>;

using T_DATA1_U=System.TimeOnly;
using T_DATA2_U=System.TimeOnly;
using T_DATA3_U=System.TimeOnly;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_001__fields__02__NVV

public static class TestSet_001__fields__02__NVV
{
 private const string c_NameOf__TABLE="TEST_MODIFY_ROW2";

 private const string c_NameOf__COL_DATA1="COL_TYPE_TIME";
 private const string c_NameOf__COL_DATA2="COL2_TYPE_TIME";
 private const string c_NameOf__COL_DATA3="COL3_TYPE_TIME";

 //-----------------------------------------------------------------------
 private sealed class MyContext:TestBaseDbContext
 {
  [Table(c_NameOf__TABLE)]
  public sealed class TEST_RECORD
  {
   [Key]
   [Column("TEST_ID")]
   public System.Int64? TEST_ID { get; set; }

   [Column(c_NameOf__COL_DATA1)]
   public T_DATA1 DATA1 { get; set; }

   [Column(c_NameOf__COL_DATA2)]
   public T_DATA2 DATA2 { get; set; }

   [Column(c_NameOf__COL_DATA3)]
   public T_DATA3 DATA3 { get; set; }
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
     T_DATA1 c_data1=null;
     T_DATA2 c_data2=new T_DATA1_U(14,27,53);
     T_DATA3 c_data3=new T_DATA3_U(14,27,54);

     System.Int64? testID=Helper__InsertRow(db,c_data1,c_data2,c_data3);

     var recs=db.testTable.Where(r => r.DATA1.IsBetween(r.DATA2,r.DATA3)==true && r.TEST_ID==testID);

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA1).T(", ").N("t",c_NameOf__COL_DATA2).T(", ").N("t",c_NameOf__COL_DATA3).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (CASE\n"
          +"    WHEN (").N("t",c_NameOf__COL_DATA2).IS_NULL().T(") OR (").N("t",c_NameOf__COL_DATA3).IS_NULL().T(") THEN NULL\n"
          +"    WHEN ").N("t",c_NameOf__COL_DATA2).T(" <= ").N("t",c_NameOf__COL_DATA3).T(" THEN (").N("t",c_NameOf__COL_DATA2).T(" <= ").N("t",c_NameOf__COL_DATA1).T(") AND (").N("t",c_NameOf__COL_DATA1).T(" < ").N("t",c_NameOf__COL_DATA3).T(")\n"
          +"    ELSE (").N("t",c_NameOf__COL_DATA2).T(" <= ").N("t",c_NameOf__COL_DATA1).T(") OR (").N("t",c_NameOf__COL_DATA1).T(" < ").N("t",c_NameOf__COL_DATA3).T(")\n"
          +"END = TRUE) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));
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
     T_DATA1 c_data1=null;
     T_DATA2 c_data2=new T_DATA1_U(14,27,53);
     T_DATA3 c_data3=new T_DATA3_U(14,27,54);

     System.Int64? testID=Helper__InsertRow(db,c_data1,c_data2,c_data3);

     var recs=db.testTable.Where(r => r.DATA1.IsBetween(r.DATA2,r.DATA3)==false && r.TEST_ID==testID);

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA1).T(", ").N("t",c_NameOf__COL_DATA2).T(", ").N("t",c_NameOf__COL_DATA3).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (CASE\n"
          +"    WHEN (").N("t",c_NameOf__COL_DATA2).IS_NULL().T(") OR (").N("t",c_NameOf__COL_DATA3).IS_NULL().T(") THEN NULL\n"
          +"    WHEN ").N("t",c_NameOf__COL_DATA2).T(" <= ").N("t",c_NameOf__COL_DATA3).T(" THEN (").N("t",c_NameOf__COL_DATA2).T(" <= ").N("t",c_NameOf__COL_DATA1).T(") AND (").N("t",c_NameOf__COL_DATA1).T(" < ").N("t",c_NameOf__COL_DATA3).T(")\n"
          +"    ELSE (").N("t",c_NameOf__COL_DATA2).T(" <= ").N("t",c_NameOf__COL_DATA1).T(") OR (").N("t",c_NameOf__COL_DATA1).T(" < ").N("t",c_NameOf__COL_DATA3).T(")\n"
          +"END = FALSE) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));
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
     T_DATA1 c_data1=null;
     T_DATA2 c_data2=new T_DATA1_U(14,27,53);
     T_DATA3 c_data3=new T_DATA3_U(14,27,54);

     System.Int64? testID=Helper__InsertRow(db,c_data1,c_data2,c_data3);

     var recs=db.testTable.Where(r => r.DATA1.IsBetween(r.DATA2,r.DATA3)==null && r.TEST_ID==testID);

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
       (c_data1,
        r.DATA1);

      Assert.AreEqual
       (c_data2,
        r.DATA2);

      Assert.AreEqual
       (c_data3,
        r.DATA3);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA1).T(", ").N("t",c_NameOf__COL_DATA2).T(", ").N("t",c_NameOf__COL_DATA3).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (CASE\n"
          +"    WHEN (").N("t",c_NameOf__COL_DATA2).IS_NULL().T(") OR (").N("t",c_NameOf__COL_DATA3).IS_NULL().T(") THEN NULL\n"
          +"    WHEN ").N("t",c_NameOf__COL_DATA2).T(" <= ").N("t",c_NameOf__COL_DATA3).T(" THEN (").N("t",c_NameOf__COL_DATA2).T(" <= ").N("t",c_NameOf__COL_DATA1).T(") AND (").N("t",c_NameOf__COL_DATA1).T(" < ").N("t",c_NameOf__COL_DATA3).T(")\n"
          +"    ELSE (").N("t",c_NameOf__COL_DATA2).T(" <= ").N("t",c_NameOf__COL_DATA1).T(") OR (").N("t",c_NameOf__COL_DATA1).T(" < ").N("t",c_NameOf__COL_DATA3).T(")\n"
          +"END").IS_NULL().T(") AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_03

 //-----------------------------------------------------------------------
 private static System.Int64 Helper__InsertRow(MyContext db,
                                               T_DATA1   valueOfData1,
                                               T_DATA2   valueOfData2,
                                               T_DATA3   valueOfData3)
 {
  var newRecord=new MyContext.TEST_RECORD();

  newRecord.DATA1=valueOfData1;
  newRecord.DATA2=valueOfData2;
  newRecord.DATA3=valueOfData3;

  db.testTable.Add(newRecord);

  db.SaveChanges();

  db.CheckTextOfLastExecutedCommand
   (new TestSqlTemplate()
     .T("INSERT INTO ").N(c_NameOf__TABLE).T(" (").N(c_NameOf__COL_DATA1).T(", ").N(c_NameOf__COL_DATA2).T(", ").N(c_NameOf__COL_DATA3).T(")").EOL()
     .T("VALUES (").P("p0").T(", ").P("p1").T(", ").P("p2").T(")").EOL()
     .T("RETURNING ").N("TEST_ID").EOL()
     .T("INTO ").P("p3").T(";"));

  Assert.IsTrue
   (newRecord.TEST_ID.HasValue);

  Console.WriteLine("TEST_ID: {0}",newRecord.TEST_ID.Value);

  return newRecord.TEST_ID.Value;
 }//Helper__InsertRow
};//class TestSet_001__fields__02__NVV

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Funcs.NullableTimeOnly.SET001.EXT.IsBetween

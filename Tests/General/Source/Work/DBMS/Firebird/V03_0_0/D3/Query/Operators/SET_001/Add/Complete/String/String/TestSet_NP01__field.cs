////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 29.12.2020.
using System;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Operators.SET_001.Add.Complete.String.String{
////////////////////////////////////////////////////////////////////////////////

using T_DATA1=System.String;
using T_DATA2=System.String;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_NP01__field

public static class TestSet_NP01__field
{
 private const string c_NameOf__TABLE            ="TEST_MODIFY_ROW2";
 private const string c_NameOf__COL_DATA1        ="COL_VARCHAR_10";
 private const string c_NameOf__COL_DATA2        ="COL2_VARCHAR_32";

 private sealed class MyContext:TestBaseDbContext
 {
  [Table(c_NameOf__TABLE)]
  public sealed class TEST_RECORD
  {
   [Key]
   [Column("TEST_ID")]
   public System.Int64? TEST_ID { get; set; }

   [Column(c_NameOf__COL_DATA1,TypeName="VARCHAR(10)")]
   public T_DATA1 COL_DATA1 { get; set; }

   [Column(c_NameOf__COL_DATA2,TypeName="VARCHAR(32)")]
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
 public static void Test_001__Null_Value___eq_null()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_DATA1 c_value1="1";
     const T_DATA2 c_value2="2";

     System.Int64? testID=Helper__InsertRow(db,c_value1,c_value2);

     T_DATA1 vv1=null;

     Assert.AreEqual
      (false,
       (vv1+c_value2)==null);

     var recs=db.testTable.Where(r => (vv1+r.COL_DATA2)==null && r.TEST_ID==testID);

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA1).T(", ").N("t",c_NameOf__COL_DATA2).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE FALSE"));
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_001__Null_Value___eq_null

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002__Value_Null___eq_null()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_DATA1 c_value1="1";
     const T_DATA2 c_value2="2";

     System.Int64? testID=Helper__InsertRow(db,c_value1,c_value2);

     T_DATA2 vv2=null;

     Assert.AreEqual
      (false,
       (c_value1+vv2)==null);

     var recs=db.testTable.Where(r => (r.COL_DATA1+vv2)==null && r.TEST_ID==testID);

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA1).T(", ").N("t",c_NameOf__COL_DATA2).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE FALSE"));
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_002__Value_Null___eq_null

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_101__NullToObjectToString_Value___eq_null()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_DATA1 c_value1="1";
     const T_DATA2 c_value2="2";

     System.Int64? testID=Helper__InsertRow(db,c_value1,c_value2);

     T_DATA1 vv1=null;

     Assert.AreEqual
      (false,
       ((string)(object)vv1+c_value2)==null);

     var recs=db.testTable.Where(r => ((string)(object)vv1+r.COL_DATA2)==null && r.TEST_ID==testID);

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA1).T(", ").N("t",c_NameOf__COL_DATA2).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE FALSE"));
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_101__NullToObjectToString_Value___eq_null

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_102__Value_NullToObjectToString___eq_null()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_DATA1 c_value1="1";
     const T_DATA2 c_value2="2";

     System.Int64? testID=Helper__InsertRow(db,c_value1,c_value2);

     T_DATA2 vv2=null;

     Assert.AreEqual
      (false,
       (c_value1+(string)(object)vv2)==null);

     var recs=db.testTable.Where(r => (r.COL_DATA1+(string)(object)vv2)==null && r.TEST_ID==testID);

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA1).T(", ").N("t",c_NameOf__COL_DATA2).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE FALSE"));
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_102__Value_NullToObjectToString___eq_null

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
};//class TestSet_NP01__field

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Operators.SET_001.Add.Complete.String.String

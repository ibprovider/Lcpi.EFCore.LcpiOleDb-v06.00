////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 18.11.2020.
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Funcs.String.SET_001.STD.Length{
////////////////////////////////////////////////////////////////////////////////
//using

using T_DATA=System.String;

////////////////////////////////////////////////////////////////////////////////
//class TestSet___VARCHAR_UTF8

public static class TestSet___VARCHAR_UTF8
{
 private const string c_NameOf__TABLE="TBL_CS__UTF8";

 private const string c_NameOf__COL_DATA="VARCHAR__32";

 //-----------------------------------------------------------------------
 private sealed class MyContext:TestBaseDbContext
 {
  [Table(c_NameOf__TABLE)]
  public sealed class TEST_RECORD
  {
   [Key]
   [Column("TEST_ID")]
   public System.Int64? TEST_ID { get; set; }

   [Column(c_NameOf__COL_DATA, TypeName="VARCHAR(32)")]
   public string DATA { get; set; }
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
 private static xdb.OleDbConnection Helper__CreateCn()
 {
  return LocalCnHelper.CreateCn__UTF8();
 }//Helper__CreateCn

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_001__field()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const string c_data="\uD800\uDC00";

     Assert.AreEqual
      (2,
       c_data.Length); // <----------- HO-HO!

     System.Int64 testID=Helper__InsertRow(db,c_data);

     var recs=db.testTable.Where(r => r.DATA.Length==1 && r.TEST_ID==testID);

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
        .T("WHERE (CHARACTER_LENGTH(").N("t",c_NameOf__COL_DATA).T(") = 1) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_001__field

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002__param()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const string c_data="\uD800\uDC00";

     Assert.AreEqual
      (2,
       c_data.Length); // <----------- HO-HO!

     System.Int64 testID=Helper__InsertRow(db,c_data);

     var vv=c_data;

     var recs=db.testTable.Where(r => r.DATA.Length==vv.Length && r.TEST_ID==testID);

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
        .T("WHERE (CHARACTER_LENGTH(").N("t",c_NameOf__COL_DATA).T(") = ").P_I4("__Exec_0").T(") AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_002__param

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_003__const()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const string c_data="\uD800\uDC00";

     Assert.AreEqual
      (2,
       c_data.Length); // <----------- HO-HO!

     System.Int64 testID=Helper__InsertRow(db,c_data);

     var recs=db.testTable.Where(r => r.DATA.Length==c_data.Length && r.TEST_ID==testID);

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
        .T("WHERE (CHARACTER_LENGTH(").N("t",c_NameOf__COL_DATA).T(") = ").P_I4("__Exec_0").T(") AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_003__const

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_004__const2()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const string c_data="\uD800\uDC00";

     Assert.AreEqual
      (2,
       c_data.Length); // <----------- HO-HO!

     System.Int64 testID=Helper__InsertRow(db,c_data);

     var recs=db.testTable.Where(r => r.DATA.Length=="\uD800\uDC00".Length && r.TEST_ID==testID);

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
        .T("WHERE (CHARACTER_LENGTH(").N("t",c_NameOf__COL_DATA).T(") = ").P_I4("__Exec_0").T(") AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_004__const2

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_005__const_only()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const string c_data="\uD800\uDC00";

     Assert.AreEqual
      (2,
       c_data.Length); // <----------- HO-HO!

     System.Int64 testID=Helper__InsertRow(db,c_data);

     var recs=db.testTable.Where(r => 1=="\uD800\uDC00".Length && r.TEST_ID==testID);

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
        .T("WHERE ").N("t","TEST_ID").T(" = ").P_ID("__testID_0"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_005__const_only

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_006__const_as_object_as_string()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const string c_data="\uD800\uDC00";

     Assert.AreEqual
      (2,
       c_data.Length); // <----------- HO-HO!

     System.Int64 testID=Helper__InsertRow(db,c_data);

     var recs=db.testTable.Where(r => 1==((string)(object)"\uD800\uDC00").Length && r.TEST_ID==testID);

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
        .T("WHERE ").N("t","TEST_ID").T(" = ").P_ID("__testID_0"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_006__const_as_object_as_string

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_E1__const()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const string c_bad_data="\uD800";

     System.Int64 testID=Helper__InsertRow(db,null);

     var recs=db.testTable.Where(r => c_bad_data.Length==1 && r.TEST_ID==testID);

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

      Assert.IsInstanceOf<xEFCore.LcpiOleDb__DataToolException>
       (exc.InnerException);

      var e2=exc.InnerException as xEFCore.LcpiOleDb__DataToolException;

      Assert.AreEqual
       (2,
        TestUtils.GetRecordCount(e2));

      Assert.IsNotNull
       (TestUtils.GetRecord(e2,0));

      Assert.IsNotNull
       (TestUtils.GetRecord(e2,1));

      CheckErrors.CheckErrorRecord__cs_utf16_err__bad_sequence__2
       (TestUtils.GetRecord(e2,0),
        CheckErrors.c_src__EFCoreDataProvider__Structure_CS_UTF16,
        "#GCC.002",
        1);

      CheckErrors.CheckErrorRecord__common_err__failed_to_process_value_1
       (TestUtils.GetRecord(e2,1),
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Method_Code__String__Length,
        "obj");
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_E1__const

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_E2__param()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     string c_bad_data=""+((char)0xD800);

     System.Int64 testID=Helper__InsertRow(db,null);

     var vv=c_bad_data;

     var recs=db.testTable.Where(r => vv.Length==1 && r.TEST_ID==testID);

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

      Assert.IsInstanceOf<xEFCore.LcpiOleDb__DataToolException>
       (exc.InnerException);

      var e2=exc.InnerException as xEFCore.LcpiOleDb__DataToolException;

      Assert.AreEqual
       (2,
        TestUtils.GetRecordCount(e2));

      Assert.IsNotNull
       (TestUtils.GetRecord(e2,0));

      Assert.IsNotNull
       (TestUtils.GetRecord(e2,1));

      CheckErrors.CheckErrorRecord__cs_utf16_err__bad_sequence__2
       (TestUtils.GetRecord(e2,0),
        CheckErrors.c_src__EFCoreDataProvider__Structure_CS_UTF16,
        "#GCC.002",
        1);

      CheckErrors.CheckErrorRecord__common_err__failed_to_process_value_1
       (TestUtils.GetRecord(e2,1),
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Method_Code__String__Length,
        "obj");
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_E2__param

 //-----------------------------------------------------------------------
 private static System.Int64 Helper__InsertRow(MyContext db,
                                               T_DATA    valueOfData)
 {
  var newRecord=new MyContext.TEST_RECORD();

  newRecord.DATA=valueOfData;

  db.testTable.Add(newRecord);

  db.SaveChanges();

  db.CheckTextOfLastExecutedCommand
   (new TestSqlTemplate()
     .T("INSERT INTO ").N(c_NameOf__TABLE).T(" (").N(c_NameOf__COL_DATA).T(")").EOL()
     .T("VALUES (").P("p0").T(")").EOL()
     .T("RETURNING ").N("TEST_ID").EOL()
     .T("INTO ").P("p1").T(";"));

  Assert.IsTrue
   (newRecord.TEST_ID.HasValue);

  Console.WriteLine("TEST_ID: {0}",newRecord.TEST_ID.Value);

  return newRecord.TEST_ID.Value;
 }//Helper__InsertRow
};//class TestSet___VARCHAR_UTF8

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Funcs.String.SET_001.STD.Length

////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 18.11.2020.
//
// <field>.Substring(<expression with startIndex>,<expression length>)
//
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;
using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.String.SET_001.STD.Substring__startIndex__length{
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
 public static void Test_001()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     string c_uchar1=""+((char)0xD800)+((char)0xDC00);
     string c_uchar2=""+((char)0xD801)+((char)0xDC00);
     string c_uchar3=""+((char)0xD802)+((char)0xDC00);
     string c_uchar4=""+((char)0xD803)+((char)0xDC00);

     string c_data="A"+c_uchar1+c_uchar2+c_uchar3+c_uchar4;

     System.Int64 testID=Helper__InsertRow(db,c_data);

     var recs=db.testTable.Where(r => r.DATA.Substring(2,2)=="\uD801\uDC00\uD802\uDC00" && r.TEST_ID==testID);

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
        .T("WHERE (SUBSTRING(").N("t",c_NameOf__COL_DATA).T(" FROM 2 + 1 FOR 2) = _utf8 '\uD801\uDC00\uD802\uDC00') AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

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
 public static void Test_002()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     string c_uchar1=""+((char)0xD800)+((char)0xDC00);
     string c_uchar2=""+((char)0xD801)+((char)0xDC00);
     string c_uchar3=""+((char)0xD802)+((char)0xDC00);
     string c_uchar4=""+((char)0xD803)+((char)0xDC00);

     string c_data="A"+c_uchar1+c_uchar2+c_uchar3+c_uchar4;

     T_DATA vv=c_data;

     System.Int64 testID=Helper__InsertRow(db,c_data);

     var recs=db.testTable.Where(r => r.DATA.Substring(2,2)==vv.Substring(2,2) && r.TEST_ID==testID);

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
        .T("WHERE (SUBSTRING(").N("t",c_NameOf__COL_DATA).T(" FROM 2 + 1 FOR 2) = ").P_TXT("__Exec_0").T(") AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_002

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_E01__const()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64 testID=Helper__InsertRow(db,null);

     var recs=db.testTable.Where(r => "A\uD800".Substring(2,100)=="" && r.TEST_ID==testID);

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
        "#GO.002",
        2);

      CheckErrors.CheckErrorRecord__common_err__failed_to_process_value_1
       (TestUtils.GetRecord(e2,1),
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Method_Code__String__Substring___startIndex__length,
        "obj");
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_E01__const

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_E02__param()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64 testID=Helper__InsertRow(db,null);

     T_DATA vv="A\uD800";

     var recs=db.testTable.Where(r => vv.Substring(2,100)=="" && r.TEST_ID==testID);

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
        "#GO.002",
        2);

      CheckErrors.CheckErrorRecord__common_err__failed_to_process_value_1
       (TestUtils.GetRecord(e2,1),
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Method_Code__String__Substring___startIndex__length,
        "obj");
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_E02__param

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_E11__const()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64 testID=Helper__InsertRow(db,null);

     var recs=db.testTable.Where(r => "A\uD800".Substring(1,100)=="" && r.TEST_ID==testID);

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
        "#GO.002",
        2);

      CheckErrors.CheckErrorRecord__common_err__failed_to_process_value_1
       (TestUtils.GetRecord(e2,1),
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Method_Code__String__Substring___startIndex__length,
        "obj");
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_E11__const

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_E22__param()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64 testID=Helper__InsertRow(db,null);

     T_DATA vv="A\uD800";

     var recs=db.testTable.Where(r => vv.Substring(1,100)=="" && r.TEST_ID==testID);

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
        "#GO.002",
        2);

      CheckErrors.CheckErrorRecord__common_err__failed_to_process_value_1
       (TestUtils.GetRecord(e2,1),
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Method_Code__String__Substring___startIndex__length,
        "obj");
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_E12__param

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
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.String.SET_001.STD.Substring__startIndex__length

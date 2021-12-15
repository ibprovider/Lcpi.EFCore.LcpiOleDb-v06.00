////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 07.07.2021.
//
// <field>.Equals(object)
//
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;
using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

using structure_lib=lcpi.lib.structure;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Funcs.NullableDateOnly.SET001.STD.Equals__object{
////////////////////////////////////////////////////////////////////////////////

using T_DATA  =System.Nullable<System.DateOnly>;

using T_DATA_U=System.DateOnly;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_001__field

public static class TestSet_001__field
{
 private const string c_NameOf__TABLE="TEST_MODIFY_ROW";

private const string c_NameOf__COL_DATA="COL_TYPE_DATE";

 private const string c_NameOf__COL_DATA_SQL_TYPE="DATE";

 private sealed class MyContext:TestBaseDbContext
 {
  [Table("TEST_MODIFY_ROW")]
  public sealed class TEST_RECORD
  {
   [Key]
   [Column("TEST_ID")]
   public System.Int64? TEST_ID { get; set; }

   [Column(c_NameOf__COL_DATA, TypeName=c_NameOf__COL_DATA_SQL_TYPE)]
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
 private static xdb.OleDbConnection Helper__CreateCn()
 {
  return LocalCnHelper.CreateCn();
 }//Helper__CreateCn

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_101__123_notEq_null__0()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA c_data=MasterTestData.DateOnly.Equals_object.TestValue__2018_10_09;

     System.Int64? testID=Helper__InsertRow(db,c_data);

     var recs=db.testTable.Where(r => r.DATA.Equals((object)null)==false && r.TEST_ID==testID);

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

     var sqlt
      =new TestSqlTemplate()
       .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
       .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
       .T("WHERE (").N("t",c_NameOf__COL_DATA).IS_NOT_NULL().T(") AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")");

     db.CheckTextOfLastExecutedCommand
      (sqlt);

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_101__123_notEq_null__0

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_101__123_notEq_null__1__r()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA c_data=MasterTestData.DateOnly.Equals_object.TestValue__2018_10_09;

     System.Int64? testID=Helper__InsertRow(db,c_data);

     var recs=db.testTable.Where(r => false==r.DATA.Equals((object)null) && r.TEST_ID==testID);

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

     var sqlt
      =new TestSqlTemplate()
       .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
       .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
       .T("WHERE (").N("t",c_NameOf__COL_DATA).IS_NOT_NULL().T(") AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")");

     db.CheckTextOfLastExecutedCommand
      (sqlt);

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_101__123_notEq_null__1__r

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_102()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA c_data=MasterTestData.DateOnly.Equals_object.TestValue__2018_10_09;

     System.Int64? testID=Helper__InsertRow(db,c_data);

     var recs=db.testTable.Where(r => !(r.DATA.Equals((object)null)!=false) && r.TEST_ID==testID);

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

     var sqlt
      =new TestSqlTemplate()
       .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
       .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
       .T("WHERE (").N("t",c_NameOf__COL_DATA).IS_NOT_NULL().T(") AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")");

     db.CheckTextOfLastExecutedCommand
      (sqlt);

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_102

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_103__0()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA c_data=MasterTestData.DateOnly.Equals_object.TestValue__2018_10_09;

     System.Int64? testID=Helper__InsertRow(db,c_data);

     var recs=db.testTable.Where(r => (!r.DATA.Equals((object)null))==true && r.TEST_ID==testID);

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

     var sqlt
      =new TestSqlTemplate()
       .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
       .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
       .T("WHERE (").N("t",c_NameOf__COL_DATA).IS_NOT_NULL().T(") AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")");

     db.CheckTextOfLastExecutedCommand
      (sqlt);

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_103__0

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_103__1__r()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA c_data=MasterTestData.DateOnly.Equals_object.TestValue__2018_10_09;

     System.Int64? testID=Helper__InsertRow(db,c_data);

     var recs=db.testTable.Where(r => true==(!r.DATA.Equals((object)null)) && r.TEST_ID==testID);

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

     var sqlt
      =new TestSqlTemplate()
       .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
       .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
       .T("WHERE (").N("t",c_NameOf__COL_DATA).IS_NOT_NULL().T(") AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")");

     db.CheckTextOfLastExecutedCommand
      (sqlt);

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_103__1__r

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_201()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA c_data=MasterTestData.DateOnly.Equals_object.TestValue__2018_10_09;

     System.Int64? testID=Helper__InsertRow(db,c_data);

     var recs=db.testTable.Where(r => r.DATA.Equals((object)new T_DATA_U(2018,10,9)) && r.TEST_ID==testID);

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(structure_lib.exceptions.t_not_supported_exception e)
     {
      CheckErrors.PrintException_OK
       (e);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e));

      CheckErrors.CheckErrorRecord__sql_gen_err__definition_of_value_in_sql_not_supported__1
       (TestUtils.GetRecord(e,0),
        CheckErrors.c_src__EFCoreDataProvider__FB_Common__TypeMapping_D1__TYPE_DATE__as_DateOnly,
        "DATE");
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_201

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_301___const_with_str()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA c_data=MasterTestData.DateOnly.Equals_object.TestValue__2018_10_09;

     System.Int64? testID=Helper__InsertRow(db,c_data);

     var recs=db.testTable.Where(r => r.DATA.Equals((object)"2018-10-09") && r.TEST_ID==testID);

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
        .T("WHERE (").N("t",c_NameOf__COL_DATA).T(" = _utf8 '2018-10-09') AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_301___const_with_str

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_401___param()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA c_data=MasterTestData.DateOnly.Equals_object.TestValue__2018_10_09;

     System.Int64? testID=Helper__InsertRow(db,c_data);

     object vv=c_data;

     var recs=db.testTable.Where(r => r.DATA.Equals(vv) && r.TEST_ID==testID);

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
        .T("WHERE (").N("t",c_NameOf__COL_DATA).T(" = ").P("__vv_0").T(") AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_401___param

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_402___param_with_not_null_object()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA c_data=MasterTestData.DateOnly.Equals_object.TestValue__2018_10_09;

     System.Int64? testID=Helper__InsertRow(db,c_data);

     object vv=new object();

     var recs=db.testTable.Where(r => r.DATA.Equals(vv) && r.TEST_ID==testID);

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }

      TestServices.ThrowWeWaitError();
     }
     catch(xdb.OleDbException e)
     {
      CheckErrors.PrintException_OK(e);

      Assert.AreEqual
       (lcpi.lib.com.HResultCode.DB_E_UNSUPPORTEDCONVERSION,
        e.ErrorCode);

      Assert.AreEqual
       (2,
        TestUtils.GetRecordCount(e));

      CheckErrors.CheckErrorRecord__IBP__FailedToBuildIbParamValue__CantConvert
       (TestUtils.GetRecord(e,0),
        0,
        "DBTYPE_IDISPATCH",
        "DBTYPE_DBDATE",
        lcpi.lib.com.HResultCode.DB_E_UNSUPPORTEDCONVERSION);
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_402___param_with_not_null_object

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_501___param__notEq()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA c_data=MasterTestData.DateOnly.Equals_object.TestValue__2018_10_09;

     System.Int64? testID=Helper__InsertRow(db,c_data);

     object vv=new System.TimeSpan(4,3,5);

     var recs=db.testTable.Where(r => !r.DATA.Equals(vv) && r.TEST_ID==testID);

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }

      TestServices.ThrowWeWaitError();
     }
     catch(structure_lib.exceptions.t_invalid_operation_exception e)
     {
      CheckErrors.PrintException_OK(e);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e));

      CheckErrors.CheckErrorRecord__sql_translator_err__unsupported_binary_operator_type_3
       (TestUtils.GetRecord(e,0),
        CheckErrors.c_src__EFCoreDataProvider__FB_Common__BinaryOperatorTranslatorProvider,
        xEFCore.LcpiOleDb__ExpressionType.Equal,
        typeof(System.DateOnly),
        typeof(System.TimeSpan));
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_501___param__notEq

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_601___field()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA c_data=MasterTestData.DateOnly.Equals_object.TestValue__2018_10_09;

     System.Int64? testID=Helper__InsertRow(db,c_data);

     var recs=db.testTable.Where(r => r.DATA.Equals((object)r.DATA) && r.TEST_ID==testID);

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

     var sqlt
      =new TestSqlTemplate()
       .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
       .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
       .T("WHERE ((").N("t",c_NameOf__COL_DATA).T(" = ").N("t",c_NameOf__COL_DATA).T(") OR (").N("t",c_NameOf__COL_DATA).IS_NULL().T(")) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")");

     db.CheckTextOfLastExecutedCommand
      (sqlt);

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_601___field

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_602___field()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA c_data=MasterTestData.DateOnly.Equals_object.TestValue__2018_10_09;

     System.Int64? testID=Helper__InsertRow(db,c_data);

     var recs=db.testTable.Where(r => r.DATA.Equals((object)r.DATA)==false && r.TEST_ID==testID);

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     var sqlt
      =new TestSqlTemplate()
       .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
       .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
       .T("WHERE ((").N("t",c_NameOf__COL_DATA).T(" <> ").N("t",c_NameOf__COL_DATA).T(") OR (").N("t",c_NameOf__COL_DATA).IS_NULL().T(")) AND (").N("t",c_NameOf__COL_DATA).IS_NOT_NULL().T(") AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")");

     db.CheckTextOfLastExecutedCommand
      (sqlt);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_602___field

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
};//class TestSet_001__field

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Funcs.NullableDateOnly.SET001.STD.Equals__object

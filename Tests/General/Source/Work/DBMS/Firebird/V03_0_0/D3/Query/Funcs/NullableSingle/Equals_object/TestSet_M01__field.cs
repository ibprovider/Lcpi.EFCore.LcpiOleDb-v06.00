////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 17.11.2020.
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

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.NullableSingle.Equals__object{
////////////////////////////////////////////////////////////////////////////////

using T_DATA=System.Nullable<System.Single>;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_M01__field

public static class TestSet_M01__field
{
 private const string c_NameOf__TABLE="TEST_MODIFY_ROW";

 private const string c_NameOf__COL_DATA="COL_FLOAT";

 private const string c_NameOf__COL_DATA_SQL_TYPE="FLOAT";

 private sealed class MyContext:TestBaseDbContext
 {
  [Table(c_NameOf__TABLE)]
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
 private struct tagData
 {
  public readonly object          ParamValue;
  public readonly TestSqlTemplate Sql;

  public tagData(object          paramValue,
                 TestSqlTemplate sql)
  {
   this.ParamValue=paramValue;
   this.Sql       =sql;
  }
 };//struct tagData

 //-----------------------------------------------------------------------
 private static readonly tagData[]
  sm_Data
   =new tagData[]
    {
     /*0*/
     new tagData
      (null,
       new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (").N("t",c_NameOf__COL_DATA).IS_NOT_NULL().T(") AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")")),

     /*1*/
     new tagData
      (4324,
       new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE ((").N("t",c_NameOf__COL_DATA).T(" <> ").P_I4("__vv_0").T(") OR (").N("t",c_NameOf__COL_DATA).IS_NULL().T(")) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")")),

     /*2*/
     new tagData
      (4324L,
       new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE ((").N("t",c_NameOf__COL_DATA).T(" <> ").P_I8("__vv_0").T(") OR (").N("t",c_NameOf__COL_DATA).IS_NULL().T(")) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_1").T(")")),
    };//sm_Data

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
     T_DATA c_data=12312;

     System.Int64? testID=Helper__InsertRow(db,c_data);

     object vv;

     for(int nPass=0;nPass!=3;)
     {
      ++nPass;

      for(int iTest=0;iTest!=sm_Data.Length;++iTest)
      {
       Console.WriteLine("----------------- PASS [{0}], TEST [{1}]",nPass,iTest);

       var testData=sm_Data[iTest];

       vv=testData.ParamValue;

       var recs=db.testTable.Where(r => !r.DATA.Equals(vv) && r.TEST_ID==testID);

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
        (testData.Sql);

       Assert.AreEqual
        (1,
         nRecs);
      }//for iTest
     }//for nPass
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_501___param__notEq

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_502___param__notEq()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA c_data=12312;

     System.Int64? testID=Helper__InsertRow(db,c_data);

     object vv=null;

     var recs=db.testTable.Where(r => !r.DATA.Equals(vv) && r.TEST_ID==testID);

     for(int nPass=0;nPass!=3;)
     {
      ++nPass;

      for(int iTest=0;iTest!=sm_Data.Length;++iTest)
      {
       Console.WriteLine("----------------- PASS [{0}], TEST [{1}]",nPass,iTest);

       var testData=sm_Data[iTest];

       vv=testData.ParamValue;

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
        (testData.Sql);

       Assert.AreEqual
        (1,
         nRecs);
      }//for iTest
     }//for nPass
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_502___param__notEq

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_503___param__notEq()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA c_data=12312;

     System.Int64? testID=Helper__InsertRow(db,c_data);

     object vv="qwerty";

     var recs=db.testTable.Where(r => !r.DATA.Equals(vv) && r.TEST_ID==testID);

     for(int nPass=0;nPass!=3;)
     {
      ++nPass;

      for(int iTest=0;iTest!=sm_Data.Length;++iTest)
      {
       Console.WriteLine("----------------- PASS [{0}], TEST [{1}]",nPass,iTest);

       var testData=sm_Data[iTest];

       vv=testData.ParamValue;

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
        (testData.Sql);

       Assert.AreEqual
        (1,
         nRecs);
      }//for iTest
     }//for nPass
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_503___param__notEq

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
};//class TestSet_M01__field

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.NullableSingle.Equals__object

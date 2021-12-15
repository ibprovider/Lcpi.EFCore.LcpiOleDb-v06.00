////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 09.12.2021.
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Funcs.String.SET_001.STD.Concat__str3{
////////////////////////////////////////////////////////////////////////////////
//using

using T_DATA=System.String;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_001__fields_02_VARCHAR_NN

public static class TestSet_001__fields_02_VARCHAR_NN
{
 private const string c_NameOf__TABLE="TEST_MODIFY_ROW2";

 private const string c_NameOf__COL_DATA1="COL_VARCHAR_10";
 private const string c_NameOf__COL_DATA2="COL2_VARCHAR_10";
 private const string c_NameOf__COL_DATA3="COL3_VARCHAR_10";

 //-----------------------------------------------------------------------
 private sealed class MyContext:TestBaseDbContext
 {
  [Table(c_NameOf__TABLE)]
  public sealed class TEST_RECORD
  {
   [Key]
   [Column("TEST_ID")]
   public System.Int64? TEST_ID { get; set; }

#nullable enable
   [Column(c_NameOf__COL_DATA1, TypeName="VARCHAR(10)")]
   public T_DATA DATA1 { get; set; }

   [Column(c_NameOf__COL_DATA2, TypeName="VARCHAR(10)")]
   public T_DATA DATA2 { get; set; }

   [Column(c_NameOf__COL_DATA3, TypeName="VARCHAR(10)")]
   public T_DATA DATA3 { get; set; }
#nullable restore

   public TEST_RECORD()
   {
    this.DATA1=string.Empty;
    this.DATA2=string.Empty;
    this.DATA3=string.Empty;
   }
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
 public static void Test_001__V_V_V()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_DATA c_data1="ABC\0123";
     const T_DATA c_data2=" ";
     const T_DATA c_data3="XYZ  ";

     System.Int64 testID=Helper__InsertRow(db,c_data1,c_data2,c_data3);

     var recs
      =db
       .testTable
       .Where(r => string.Concat(r.DATA1,r.DATA2,r.DATA3)=="ABC\0123 XYZ  " && r.TEST_ID==testID)
       .Select(x => new{TEST_ID=x.TEST_ID,CRL=string.Concat(x.DATA1,x.DATA2,x.DATA3).Length});

     int nRecs=0;

     foreach(var r in recs)
     {
      Assert.AreEqual
       (0,
        nRecs);

      ++nRecs;

      Assert.IsTrue
       (r. TEST_ID.HasValue);

      Assert.AreEqual
       (testID,
        r.TEST_ID.Value);

      Assert.AreEqual
       (13,
        r.CRL);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", CHARACTER_LENGTH(").N("t",c_NameOf__COL_DATA1).T("||").N("t",c_NameOf__COL_DATA2).T("||").N("t",c_NameOf__COL_DATA3).T(") AS ").N("CRL").EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE ((").N("t",c_NameOf__COL_DATA1).T("||").N("t",c_NameOf__COL_DATA2).T("||").N("t",c_NameOf__COL_DATA3).T(") = _utf8 'ABC'||_utf8 x'00'||_utf8 '123 XYZ  ') AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_001__V_V_V

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_EXP001()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_DATA c_data1="ABC\0123";
     const T_DATA c_data2=" ";
     const T_DATA c_data3="XYZ  ";

     System.Int64 testID=Helper__InsertRow(db,c_data1,c_data2,c_data3);

     var recs
      =db
       .testTable
       .Where(r => string.Concat(r.DATA1,r.DATA2,r.DATA3)=="ABC\0123 XYZ  " && r.TEST_ID==testID)
       .Select(x => new{TEST_ID=x.TEST_ID,CRL=(string)(object)string.Concat(x.DATA1,x.DATA2,x.DATA3).Length});

     int nRecs=0;

     foreach(var r in recs)
     {
      Assert.AreEqual
       (0,
        nRecs);

      ++nRecs;

      Assert.IsTrue
       (r. TEST_ID.HasValue);

      Assert.AreEqual
       (testID,
        r.TEST_ID.Value);

      Assert.AreEqual
       ("13",
        r.CRL);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", CAST(CHARACTER_LENGTH(").N("t",c_NameOf__COL_DATA1).T("||").N("t",c_NameOf__COL_DATA2).T("||").N("t",c_NameOf__COL_DATA3).T(") AS VARCHAR(20)) AS ").N("CRL").EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE ((").N("t",c_NameOf__COL_DATA1).T("||").N("t",c_NameOf__COL_DATA2).T("||").N("t",c_NameOf__COL_DATA3).T(") = _utf8 'ABC'||_utf8 x'00'||_utf8 '123 XYZ  ') AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_EXP001

 //-----------------------------------------------------------------------
 private static System.Int64 Helper__InsertRow(MyContext db,
                                               T_DATA    valueOfData1,
                                               T_DATA    valueOfData2,
                                               T_DATA    valueOfData3)
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
};//class TestSet_001__fields_02_VARCHAR_NN

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Funcs.String.SET_001.STD.Concat__str3

                                                        ////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 15.05.2018.
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace EFCore_LcpiOleDb_Tests.General.Work.Simple{
////////////////////////////////////////////////////////////////////////////////
//class Work_Simple__Test_012

public static class Work_Simple__Test_012
{
 private const string c_NameOf__TABLE="TEST_MODIFY_ROW";

 private const string c_NameOf__COL_DATA="COL_VARCHAR_10";

 private sealed class MyContext:TestBaseDbContext
 {
  [Table(c_NameOf__TABLE)]
  public sealed class TEST_RECORD
  {
   [Key]
   [Column("TEST_ID")]
   public Int64? TEST_ID { get; set; }

   [Column(c_NameOf__COL_DATA, TypeName="VARCHAR(10)")]
   public string DATA { get; set; }
  };//class TEST_RECORD

  //----------------------------------------------------------------------
  public DbSet<TEST_RECORD> testTable { get; set; }
 };//class MyContext

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_01()
 {
  using(var db=new MyContext())
  {
   Int64 testID=Helper__InsertRow(db,null);

   var recs1=db.testTable.Where(r => (!(r.DATA==null))==false && r.TEST_ID==testID);

   foreach(var r in recs1)
   {
   }//foreach

   db.CheckTextOfLastExecutedCommand
    (new TestSqlTemplate()
      .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
      .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
      .T("WHERE (").N("t",c_NameOf__COL_DATA).IS_NULL().T(") AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));

   var recs2=db.testTable.Where(r => false==(!(r.DATA==null)) && r.TEST_ID==testID);

   foreach(var r in recs2)
   {
   }//foreach

   db.CheckTextOfLastExecutedCommand
    (new TestSqlTemplate()
      .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA).EOL()
      .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
      .T("WHERE (").N("t",c_NameOf__COL_DATA).IS_NULL().T(") AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));
  }//using db
 }//Test_01

 //-----------------------------------------------------------------------
 private static Int64 Helper__InsertRow(MyContext db,
                                        string    valueOfData)
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
};//class Work_Simple__Test_012

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.Simple

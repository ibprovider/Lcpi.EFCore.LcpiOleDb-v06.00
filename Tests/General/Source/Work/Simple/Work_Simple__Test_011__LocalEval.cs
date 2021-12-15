                                                        ////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 15.05.2018.
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace EFCore_LcpiOleDb_Tests.General.Work.Simple{
////////////////////////////////////////////////////////////////////////////////
//class Work_Simple__Test_011__LocalEval

public static class Work_Simple__Test_011__LocalEval
{
 private sealed class MyContext:TestBaseDbContext
 {
  [Table("DUAL")]
  public sealed class DUAL
  {
   public int ID { get; set; }
  };//class DUAL

  //----------------------------------------------------------------------
  public DbSet<DUAL> table_DUAL { get; set; }
 };//class MyContext

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_01()
 {
  using(var db=new MyContext())
  {
   int nRecs=0;

   Int32? recID=null;

   foreach(var rec in db.table_DUAL.Where(r => r.ID==recID+1))
   {
    Assert.AreEqual(0,nRecs);

    ++nRecs;

    var v=rec.ID;

    Console.WriteLine("ID: {0}",v);

    Assert.AreEqual(1,v);
   }//foreach

   db.CheckTextOfLastExecutedCommand
    (new TestSqlTemplate()
      .T("SELECT ").N("d","ID").EOL()
      .T("FROM ").N("DUAL").T(" AS ").N("d").EOL()
      .T("WHERE FALSE"));

   Assert.AreEqual(0,nRecs);
  }//using db
 }//Test_01

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_01r()
 {
  using(var db=new MyContext())
  {
   int nRecs=0;

   Int32? recID=null;

   foreach(var rec in db.table_DUAL.Where(r => r.ID==1+recID))
   {
    Assert.AreEqual(0,nRecs);

    ++nRecs;

    var v=rec.ID;

    Console.WriteLine("ID: {0}",v);

    Assert.AreEqual(1,v);
   }//foreach

   db.CheckTextOfLastExecutedCommand
    (new TestSqlTemplate()
      .T("SELECT ").N("d","ID").EOL()
      .T("FROM ").N("DUAL").T(" AS ").N("d").EOL()
      .T("WHERE FALSE"));

   Assert.AreEqual(0,nRecs);
  }//using db
 }//Test_01r

 //-----------------------------------------------------------------------
#if BUILD_CONF__TESTS_FOR_DBNULL

 [Test]
 public static void Test_02()
 {
  using(var db=new MyContext())
  {
   int nRecs=0;

   foreach(var rec in db.table_DUAL.Where(r => "abc"+DBNull.Value==null))
   {
    Assert.AreEqual(0,nRecs);

    ++nRecs;

    var v=rec.ID;

    Console.WriteLine("ID: {0}",v);

    Assert.AreEqual(1,v);
   }//foreach

   db.log.CheckTextOfLastExecutedCommand_F__dQ
    ("SELECT {0}.\"ID\"\n"
    +"FROM \"DUAL\" AS {0}");

   Assert.AreEqual(1,nRecs);
  }//using db
 }//Test_02

#endif //BUILD_CONF__TESTS_FOR_DBNULL

 //-----------------------------------------------------------------------
 private struct tagTestData03
 {
  public string vv;
  public int    nRecs;
 };//struct tagTestData03

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_03__exec_with_different_var_values()
 {
  var testDatas
   =new tagTestData03[]
     {
      new tagTestData03
      {
       vv    =null,
       nRecs =1,
      },

      new tagTestData03
      {
       vv    =" 123 ",
       nRecs =0,
      },
     };//var testDatas

  using(var db=new MyContext())
  {
   for(int nPass=0;nPass!=3;)
   {
    ++nPass;

    Console.WriteLine("----------------- PASS: {0}",nPass);

    foreach(var testData in testDatas)
    {
     int nRecs=0;

     foreach(var rec in db.table_DUAL.Where(r => testData.vv.Trim()==null))
     {
      Assert.AreEqual(0,nRecs);

      ++nRecs;

      var v=rec.ID;

      Console.WriteLine("ID: {0}",v);

      Assert.AreEqual(1,v);
     }//foreach rec

   db.CheckTextOfLastExecutedCommand
    (new TestSqlTemplate()
      .T("SELECT ").N("d","ID").EOL()
      .T("FROM ").N("DUAL").T(" AS ").N("d").EOL()
      .T("WHERE ").P_BOOL("__Exec_V_V_0"));

     Assert.AreEqual
      (testData.nRecs,
       nRecs);
    }//foreach testData
   }//for nPass
  }//using db
 }//Test_03__exec_with_different_var_values
};//class Work_Simple__Test_011__LocalEval

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.Simple

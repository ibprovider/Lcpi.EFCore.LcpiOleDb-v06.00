////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 10.09.2021.
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Funcs.Querable.SET_001.STD.Average.String_Length{
////////////////////////////////////////////////////////////////////////////////
//using

using T_DATA=System.String;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_001__fields

public static class TestSet_001__fields
{
 private const string c_NameOf__TABLE="TEST_MODIFY_ROW";

 private const string c_NameOf__COL_DATA="COL_VARCHAR_32";

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
 public static void Test_001()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const int c_nRecs=3;

     var startTestID
      =System.Convert.ToInt64(TestServices.GenID(tr,"GEN_ID_TEST_MODIFY_ROW",c_nRecs))-c_nRecs+1;

     var curTestID=startTestID;

     using var cmd
      =new xdb.OleDbCommand
        ("insert into "+c_NameOf__TABLE+" (TEST_ID,"+c_NameOf__COL_DATA+") values (?,?)",
         cn,
         tr);

     cmd.Parameters.Refresh();

     for(int i=0;i!=c_nRecs;++i,++curTestID)
     {
      cmd[0].Value=curTestID;

      cmd[1].Value=new string('x',i+1);

      cmd.ExecuteNonQuery();
     }//for i

     var valueWithResult
      =db
       .testTable
       .Where(r => r.TEST_ID>=startTestID && r.TEST_ID<curTestID)
       .Average(x=>x.DATA.Length);

     Assert.AreEqual
      (2.0,
       valueWithResult);

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT AVG(CAST(CHARACTER_LENGTH(").N("t",c_NameOf__COL_DATA).T(") AS DOUBLE PRECISION))").EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (").N("t","TEST_ID").T(" >= ").P_ID("__startTestID_0").T(") AND (").N("t","TEST_ID").T(" < ").P_ID("__curTestID_1").T(")"));
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_001

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002__with_explicit_cast_to_long()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const int c_nRecs=3;

     var startTestID
      =System.Convert.ToInt64(TestServices.GenID(tr,"GEN_ID_TEST_MODIFY_ROW",c_nRecs))-c_nRecs+1;

     var curTestID=startTestID;

     using var cmd
      =new xdb.OleDbCommand
        ("insert into "+c_NameOf__TABLE+" (TEST_ID,"+c_NameOf__COL_DATA+") values (?,?)",
         cn,
         tr);

     cmd.Parameters.Refresh();

     for(int i=0;i!=c_nRecs;++i,++curTestID)
     {
      cmd[0].Value=curTestID;

      cmd[1].Value=new string('x',i+1);

      cmd.ExecuteNonQuery();
     }//for i

     var valueWithResult
      =db
       .testTable
       .Where(r => r.TEST_ID>=startTestID && r.TEST_ID<curTestID)
       .Average(x=>(long)x.DATA.Length);

     Assert.AreEqual
      (2.0,
       valueWithResult);

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT AVG(CAST(CHARACTER_LENGTH(").N("t",c_NameOf__COL_DATA).T(") AS DOUBLE PRECISION))").EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (").N("t","TEST_ID").T(" >= ").P_ID("__startTestID_0").T(") AND (").N("t","TEST_ID").T(" < ").P_ID("__curTestID_1").T(")"));
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_002__with_explicit_cast_to_long
};//class TestSet_001__fields

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Funcs.Querable.SET_001.STD.Average.String_Length

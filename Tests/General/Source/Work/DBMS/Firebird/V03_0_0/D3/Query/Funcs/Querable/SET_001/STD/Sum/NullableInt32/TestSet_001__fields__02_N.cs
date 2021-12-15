////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 09.09.2021.
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.Querable.SET_001.STD.Sum.NullableInt32{
////////////////////////////////////////////////////////////////////////////////
//using

using T_DATA  =System.Nullable<System.Int32>;

using T_DATA_U=System.Int32;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_001__fields__02_N

public static class TestSet_001__fields__02_N
{
 private const string c_NameOf__TABLE="TEST_MODIFY_ROW";

 private const string c_NameOf__COL_DATA="COL_INTEGER";

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
      =(long)TestServices.GenID(tr,"GEN_ID_TEST_MODIFY_ROW",c_nRecs)-c_nRecs+1;

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

      cmd[1].Value=DBNull.Value;

      cmd.ExecuteNonQuery();
     }//for i

     var valueWithResult
      =db
       .testTable
       .Where(r => r.TEST_ID>=startTestID && r.TEST_ID<curTestID)
       .Sum(x=>x.DATA);

     Assert.AreEqual
      (0,
       valueWithResult);

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT CAST(COALESCE(SUM(").N("t",c_NameOf__COL_DATA).T("), 0) AS INTEGER)").EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (").N("t","TEST_ID").T(" >= ").P_ID("__startTestID_0").T(") AND (").N("t","TEST_ID").T(" < ").P_ID("__curTestID_1").T(")"));
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_001

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002()
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
      =(long)TestServices.GenID(tr,"GEN_ID_TEST_MODIFY_ROW",c_nRecs)-c_nRecs+1;

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

      cmd[1].Value=DBNull.Value;

      cmd.ExecuteNonQuery();
     }//for i

     var valueWithResult
      =db
       .testTable
       .Where(r => r.TEST_ID>=startTestID && r.TEST_ID<curTestID)
       .Sum(x=>(long?)x.DATA);

     Assert.AreEqual
      (0,
       valueWithResult);

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT COALESCE(SUM(").N("t",c_NameOf__COL_DATA).T("), 0)").EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (").N("t","TEST_ID").T(" >= ").P_ID("__startTestID_0").T(") AND (").N("t","TEST_ID").T(" < ").P_ID("__curTestID_1").T(")"));
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_002
};//class TestSet_001__fields__02_N

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.Querable.SET_001.STD.Sum.NullableInt32

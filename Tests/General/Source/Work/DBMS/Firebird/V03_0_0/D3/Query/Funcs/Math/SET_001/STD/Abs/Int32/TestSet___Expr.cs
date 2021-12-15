////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 25.04.2019.
//
// Math.Abs(<expr>)
//
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.Math.SET_001.STD.Abs.Int32{
////////////////////////////////////////////////////////////////////////////////
//using

using T_DATA=System.Int32;

////////////////////////////////////////////////////////////////////////////////
//class TestSet___Expr

public static class TestSet___Expr
{
 private const string c_NameOf__TABLE="TEST_MODIFY_ROW";

 private const string c_NameOf__COL_DATA="COL_INTEGER";

 private sealed class MyContext:TestBaseDbContext
 {
  [Table("DUAL")]
  public sealed class DUAL
  {
   [Key]
   [Column("ID")]
   public System.Int32 ID { get; set; }
  };//class DUAL

  //----------------------------------------------------------------------
  public DbSet<DUAL> dualTable { get; set; }

  //----------------------------------------------------------------------
  public MyContext(xdb.OleDbTransaction tr)
   :base(tr)
  {
  }//MyContext
 };//class MyContext

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___02___ByEF()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    TestServices.UnsupportedSQL__ExpressionEvaluationNotSupported
     (tr,
      new TestSqlTemplate()
       .T("SELECT ").N("r","TEST_ID").T(", ").N("r",c_NameOf__COL_DATA).EOL()
       .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("r").EOL()
       .T("WHERE (ABS((").N("r",c_NameOf__COL_DATA).T(" - ").P("__vv_0").T(") + (").N("r",c_NameOf__COL_DATA).T(" / ").P("__vv_0").T(")) = -5) AND (").N("r","TEST_ID").T(" = ").P("__testID_1)")
       .BuildSql(cn));

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___02___ByEF

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___03___ByEF()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     string s=null;

#pragma warning disable CS0472
     var recs=db.dualTable.Where(r => System.Math.Abs(s.Length)==null);
#pragma warning restore CS0472

     int nRecs=0;

     foreach(var r in recs)
     {
      ++nRecs;

      Assert.AreEqual
       (1,
        r.ID);
     }//foreach r

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___03___ByEF
};//class TestSet___Expr

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.Math.SET_001.STD.Abs.Int32

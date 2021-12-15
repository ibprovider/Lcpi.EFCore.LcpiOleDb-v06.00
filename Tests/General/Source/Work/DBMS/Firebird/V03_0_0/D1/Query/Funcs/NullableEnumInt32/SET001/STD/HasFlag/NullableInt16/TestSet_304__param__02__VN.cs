////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 03.06.2021.
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Funcs.NullableEnumInt32.SET001.STD.HasFlag.NullableInt16{
////////////////////////////////////////////////////////////////////////////////

using T_DATA1  =System.Nullable<TestEnum001>;
using T_DATA2  =System.Nullable<System.Int16>;

using T_DATA1_U=TestEnum001;
using T_DATA2_U=System.Int16;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_304__param__02__VN

public static class TestSet_304__param__02__VN
{
 private const string c_NameOf__TABLE            ="DUAL";

 private sealed class MyContext:TestBaseDbContext
 {
  [Table(c_NameOf__TABLE)]
  public sealed class TEST_RECORD
  {
   [Key]
   [Column("ID")]
   public System.Int32? TEST_ID { get; set; }
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
 private static bool HasFlag(this T_DATA1 obj,T_DATA2 value)
 {
  throw new InvalidOperationException("Incorrect usage of DUMMY HasFlag method!");
 }//HasFlag

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_A001___param__param()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_DATA1_U c_value1=TestEnum001.Flag1|TestEnum001.Flag2;

     T_DATA1 vv1=c_value1;
     T_DATA2 vv2=null;

     var recs=db.testTable.Where(r => vv1.HasFlag(vv2));

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("d","ID").EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("d").EOL()
        .T("WHERE NULL"));
    }//using db

    tr.Commit();
   }//using tr
  }//using cn
 }//Test_A001___param__param

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_B001___param__param()
 {
  using(var cn=Helper__CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_DATA1_U c_value1=TestEnum001.Flag1|TestEnum001.Flag2;

     T_DATA1 vv1=c_value1;
     T_DATA2 vv2=null;

     var recs=db.testTable.Where(r => !vv1.HasFlag(vv2));

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("d","ID").EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("d").EOL()
        .T("WHERE NULL"));
    }//using db

    tr.Commit();
   }//using tr
  }//using cn
 }//Test_B001___param__param
};//class TestSet_304__param__02__VN

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Funcs.NullableEnumInt32.SET001.STD.HasFlag.NullableInt16

////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 01.12.2021.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using NUnit.Framework;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Storage.DatabaseProvider.SET_001{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_001

public static class TestSet__ER004__param
{
 private const string c_NameOf__TABLE="DUAL";

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
 [Test]
 public static void Test_001__check_Name()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    using(var db=new MyContext(tr))
    {
     var svc
      =db.GetService<IDatabaseProvider>();

     Assert.NotNull
      (svc);

     var name
      =svc.Name;

     Console.WriteLine
      ("Database Provider Name: [{0}]",
       name);

     StringAssert.StartsWith
      ("Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb",
       name);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_001__check_Name

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_001__check_Version()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    using(var db=new MyContext(tr))
    {
     var svc
      =db.GetService<IDatabaseProvider>();

     Assert.NotNull
      (svc);

     var version
      =svc.Version;

     Console.WriteLine
      ("Database Provider Version: [{0}]",
       version);

     Assert.NotNull
      (version);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_001__check_Version
};//class TestSet__ER004__param

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Storage.DatabaseProvider.SET_001

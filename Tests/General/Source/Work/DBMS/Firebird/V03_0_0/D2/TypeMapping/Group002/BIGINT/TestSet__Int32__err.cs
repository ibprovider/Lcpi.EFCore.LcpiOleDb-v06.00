////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 28.05.2018.
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using com_lib=lcpi.lib.com;

using xdb=lcpi.data.oledb;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D2.TypeMapping.Group002.BIGINT{
////////////////////////////////////////////////////////////////////////////////

using TEST_COL_TYPE=System.Int32;

////////////////////////////////////////////////////////////////////////////////
//class TestSet__Int32__err

public static class TestSet__Int32__err
{
 private sealed class MyContext:TestBaseDbContext
 {
  [Table("TEST_MODIFY_ROW_WD")]
  public sealed class TEST_RECORD
  {
   [Key]
   [Column("TEST_ID")]
   public Int64? TEST_ID { get; set; }

   [Column("COL_BIGINT")]
   public TEST_COL_TYPE? TEST_COL { get; set; }
  };//class TEST_RECORD

  //----------------------------------------------------------------------
  public DbSet<TEST_RECORD> testTable { get; set; }

  //----------------------------------------------------------------------
  public MyContext(xdb.OleDbTransaction tr)
   :base(tr)
  {
  }//MyContext

  //----------------------------------------------------------------------
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
   modelBuilder
    .Entity<TEST_RECORD>()
    .Property(b => b.TEST_COL)
    .HasDefaultValue();
  }//OnModelCreating
 };//class MyContext

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_01()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    var cmd=new xdb.OleDbCommand("",cn,tr);

    using(var db=new MyContext(tr))
    {
     var newRec=new MyContext.TEST_RECORD();

     db.testTable.Add(newRec);

     for(;;)
     {
      try
      {
       var nChanges=db.SaveChanges();
      }
      catch(DbUpdateException e)
      {
       CheckErrors.PrintException_OK(e);

       Assert.NotNull
        (e.InnerException);

       Assert.IsInstanceOf
        (typeof(xEFCore.LcpiOleDb__DataToolException),
         e.InnerException);

       var e2=e.InnerException as xEFCore.LcpiOleDb__DataToolException;

       Assert.IsNull
        (e2.InnerException);

       Assert.AreEqual
        (2,
         TestUtils.GetRecordCount(e2));

       CheckErrors.CheckErrorRecord__common_err__cant_convert_value_between_types_2
        (TestUtils.GetRecord(e2,0),
         CheckErrors.c_src__EFCoreDataProvider__Core_ValueCvt__Int64__Int32,
         com_lib.HResultCode.DB_E_DATAOVERFLOW,
         typeof(Int64),
         typeof(Int32));

       CheckErrors.CheckErrorRecord__common_err__failed_to_set_property_value_3
        (TestUtils.GetRecord(e2,1),
         CheckErrors.c_src__EFCoreDataProvider__Core_ValueInstaller,
         typeof(TestSet__Int32__err).FullName+"+MyContext+TEST_RECORD",
         "TEST_COL",
         "COL_BIGINT");

       break;
      }//catch

      TestServices.ThrowWeWaitError();
     }//for[ever]
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_01
};//class TestSet__Int32__err

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D2.TypeMapping.Group002.BIGINT

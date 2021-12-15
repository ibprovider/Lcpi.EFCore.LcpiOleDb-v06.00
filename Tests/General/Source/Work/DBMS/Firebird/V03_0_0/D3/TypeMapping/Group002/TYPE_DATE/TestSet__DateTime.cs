////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 28.05.2018.
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.TypeMapping.Group002.TYPE_DATE{
////////////////////////////////////////////////////////////////////////////////

using TEST_COL_TYPE=DateTime;

////////////////////////////////////////////////////////////////////////////////
//class TestSet__DateTime

public static class TestSet__DateTime
{
 private sealed class MyContext:TestBaseDbContext
 {
  [Table("TEST_MODIFY_ROW_WD")]
  public sealed class TEST_RECORD
  {
   [Key]
   [Column("TEST_ID")]
   public Int64? TEST_ID { get; set; }

   [Column("COL_TYPE_DATE", TypeName = "DATE")]
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
    try
    {
     using(var db=new MyContext(tr))
     {
      TestServices.ThrowWeWaitError();
     }//using db
    }
    catch(xEFCore.LcpiOleDb__DataToolException e)
    {
     CheckErrors.PrintException_OK(e);

     Assert.AreEqual
      (1,
       TestUtils.GetRecordCount(e));

     CheckErrors.CheckErrorRecord__type_mapping_err__unexpected_ClrType_2
      (TestUtils.GetRecord(e,0),
       CheckErrors.c_src__EFCoreDataProvider__FB_Common__TypeMapping_D3__TYPE_DATE__as_DateOnly,
       typeof(System.DateTime),
       typeof(System.DateOnly));
    }//catch
   }//using tr
  }//using cn
 }//Test_01
};//class TestSet__DateTime

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.TypeMapping.Group002.TYPE_DATE

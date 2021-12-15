////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 18.11.2021.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Model.Annotations.VGS.SET_001.Conflict_v2{
////////////////////////////////////////////////////////////////////////////////

using T_ID  =System.Int64;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_001__IdentityByDefault__and__DefaultValue

public static class TestSet_001__IdentityByDefault__and__DefaultValue
{
 private const string c_NameOf__Table                 = "DUMMY_TEST_TABLE";

 private const string c_NameOf__COL__ID               = "TEST_ID";

 private sealed class MyContext:TestBaseDbContext
 {
  [Table(c_NameOf__Table)]
  public sealed class TEST_RECORD
  {
   [Key]
   [Column(c_NameOf__COL__ID)]
   public T_ID TEST_ID { get; set; }
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
    .Property(b => b.TEST_ID)
    .HasAnnotation
      (xEFCore.MetaData.Internal.LcpiOleDb__AnnotationNames.ValueGenerationStrategy,
       xEFCore.MetaData.LcpiOleDb__ValueGenerationStrategy.IdentityByDefaultColumn)
    .HasDefaultValue(123);
  }//OnModelCreating
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
    try
    {
     using(var db=new MyContext(tr))
     {
      TestServices.ThrowWeWaitError();
     }
    }
    catch(xEFCore.LcpiOleDb__DataToolException e)
    {
     CheckErrors.PrintException_OK(e);

     Assert.AreEqual
      (1,
       TestUtils.GetRecordCount(e));

     CheckErrors.CheckErrorRecord__common_err__entity_property_has_conflict_of_value_generation_strategies__4
      (TestUtils.GetRecord(e,0),
       CheckErrors.c_src__EFCoreDataProvider__Basement_EF_Dbms_Firebird_V03_0_0_Metadata_Conventions___FB_V03_0_0__Convention_StoreGeneration,
       "TEST_RECORD",
       "TEST_ID",
       "IdentityByDefaultColumn",
       "DefaultValue");
    }//catch

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_001
};//class TestSet_001__IdentityByDefault__and__DefaultValue

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Model.Annotations.VGS.SET_001.Conflict_v2

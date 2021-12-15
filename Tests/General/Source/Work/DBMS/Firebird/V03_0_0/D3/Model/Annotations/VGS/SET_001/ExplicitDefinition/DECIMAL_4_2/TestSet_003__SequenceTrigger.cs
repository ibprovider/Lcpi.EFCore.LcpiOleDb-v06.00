////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 16.11.2021.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

using NUnit.Framework;

using xdb=lcpi.data.oledb;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Model.Annotations.VGS.SET_001.ExplicitDefinition.DECIMAL_4_2{
////////////////////////////////////////////////////////////////////////////////

using T_ID  =System.Decimal;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_003__SequenceTrigger

public static class TestSet_003__SequenceTrigger
{
 private const string c_NameOf__Table                 = "DUMMY_TEST_TABLE";

 private const string c_NameOf__COL__ID               = "TEST_ID";

 private const string c_NameOf__Trigger               = "TRIGGER_NAME";

 private const string c_NameOf__Sequence              = "SEQUENCE_NAME";

 private sealed class MyContext:TestBaseDbContext
 {
  [Table(c_NameOf__Table)]
  public sealed class TEST_RECORD
  {
   [Key]
   [Column(c_NameOf__COL__ID, TypeName="DECIMAL(4,2)")]
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
    .UseSequenceTrigger(c_NameOf__Trigger,c_NameOf__Sequence);
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
     }
    }
    catch(xEFCore.LcpiOleDb__DataToolException e)
    {
     CheckErrors.PrintException_OK(e);

     Assert.AreEqual
      (3,
       TestUtils.GetRecordCount(e));

     CheckErrors.CheckErrorRecord__common_err__property_with_datatype_is_not_compatible_with_value_generation_strategy__4
      (TestUtils.GetRecord(e,0),
       CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__Extensions__Property,
       "SequenceTrigger",
       "EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Model.Annotations.VGS.SET_001.ExplicitDefinition.DECIMAL_4_2.TestSet_003__SequenceTrigger+MyContext+TEST_RECORD",
       "TEST_ID",
       "System.Decimal");

     CheckErrors.CheckErrorRecord__validation_err__failed_to_entity_property_validation_2
      (TestUtils.GetRecord(e,1),
       CheckErrors.c_src__EFCoreDataProvider__Basement_EF_Dbms_Firebird_V03_0_0_Infrastructure___FB_V03_0_0__ModelValidator,
       "TEST_RECORD",
       "TEST_ID");

     CheckErrors.CheckErrorRecord__validation_err__failed_to_entity_validation_1
      (TestUtils.GetRecord(e,2),
       CheckErrors.c_src__EFCoreDataProvider__Basement_EF_Dbms_Firebird_V03_0_0_Infrastructure___FB_V03_0_0__ModelValidator,
       "TEST_RECORD");
    }//catch

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_001
};//class TestSet_003__SequenceTrigger

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Model.Annotations.VGS.SET_001.ExplicitDefinition.DECIMAL_4_2

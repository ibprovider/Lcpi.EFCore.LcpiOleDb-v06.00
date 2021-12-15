////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 16.11.2021.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Model.Annotations.VGS.SET_001.GlobalDefinition.NullableInt64{
////////////////////////////////////////////////////////////////////////////////

using T_ID  =System.Nullable<System.Int64>;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_003__SequenceTrigger

public static class TestSet_003__SequenceTrigger
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
    .Model
    .SetValueGenerationStrategy(xEFCore.MetaData.LcpiOleDb__ValueGenerationStrategy.SequenceTrigger("T","S"));

   modelBuilder
    .Entity<TEST_RECORD>()
    .Property(b => b.TEST_ID)
    .ValueGeneratedOnAdd();
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

     CheckErrors.CheckErrorRecord__common_err__value_generation_strategy_cant_be_defined_at_model_level__1
      (TestUtils.GetRecord(e,0),
       CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__Extensions__Model,
       "SequenceTrigger");
    }//catch

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_001
};//class TestSet_003__SequenceTrigger

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Model.Annotations.VGS.SET_001.GlobalDefinition.NullableInt64

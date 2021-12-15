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

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Model.Annotations.VGS.SET_001.ExplicitDefinition.Int64{
////////////////////////////////////////////////////////////////////////////////

using T_ID  =System.Int64;

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
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     //check model

     var entity
      =db.Model.FindEntityType(typeof(MyContext.TEST_RECORD));

     Assert.NotNull
      (entity);

     var property
      =entity.GetProperty(c_NameOf__COL__ID);

     var vgs
      =property.GetValueGenerationStrategy();

     Assert.NotNull
      (vgs);

     Assert.IsInstanceOf<xEFCore.MetaData.LcpiOleDb__AnnotationData__ValueGenerationStrategy_SequenceTrigger>
      (vgs);

     var vgs_t
      =(xEFCore.MetaData.LcpiOleDb__AnnotationData__ValueGenerationStrategy_SequenceTrigger)vgs;

     Assert.AreEqual
      (c_NameOf__Trigger,
       vgs_t.TriggerName);

     Assert.AreEqual
      (c_NameOf__Sequence,
       vgs_t.SequenceName);

     //--------------------------------------------------------------
     var expectedSQL1
      =new TestSqlTemplate()
        .T("CREATE TABLE ").N(c_NameOf__Table).T(" (").CRLF()
        .T("    ").N(c_NameOf__COL__ID).T(" BIGINT NOT NULL,").CRLF()
        .T("    CONSTRAINT ").N("PK_"+c_NameOf__Table).T(" PRIMARY KEY (").N(c_NameOf__COL__ID).T(")").CRLF()
        .T(");").CRLF();

     var expectedSQL2
      =new TestSqlTemplate()
        .T("CREATE TRIGGER ").N(c_NameOf__Trigger).T(" ACTIVE BEFORE INSERT ON ").N(c_NameOf__Table).CRLF()
        .T("AS").CRLF()
        .T("BEGIN").CRLF()
        .T("    IF (NEW.").N(c_NameOf__COL__ID).T(" IS NULL) THEN").CRLF()
        .T("    BEGIN").CRLF()
        .T("        NEW.").N(c_NameOf__COL__ID).T(" = NEXT VALUE FOR ").N(c_NameOf__Sequence).T(";").CRLF()
        .T("    END").CRLF()
        .T("END;").CRLF();

     //----------------------
     TestServices.CheckMigrationSQLs
      (db,
       new [] {expectedSQL1, expectedSQL2});
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_001
};//class TestSet_003__SequenceTrigger

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Model.Annotations.VGS.SET_001.ExplicitDefinition.Int64

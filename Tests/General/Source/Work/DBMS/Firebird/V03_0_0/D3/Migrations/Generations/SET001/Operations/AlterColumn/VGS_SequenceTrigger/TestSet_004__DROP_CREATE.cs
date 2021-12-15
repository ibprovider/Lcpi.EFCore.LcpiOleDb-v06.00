////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 09.11.2021.
using NUnit.Framework;

using EF_MnOP
 =Microsoft.EntityFrameworkCore.Migrations.Operations;

using xEFCore
 =Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.AlterColumn.VGS_SequenceTrigger{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_004__DROP_CREATE

public static class TestSet_004__DROP_CREATE
{
 private const string c_NameOf_Table
  ="TEST_TABLE";

 private const string c_NameOf_Column
  ="COLUMN_NAME";

 private const string c_NameOf__Trigger1
  ="TRIGGER1_NAME";

 private const string c_NameOf__Sequence1
  ="SEQUENCE1_NAME";

 private const string c_NameOf__Trigger2
  ="TRIGGER2_NAME";

 private const string c_NameOf__Sequence2
  ="SEQUENCE2_NAME";

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0001__changed_tr_name()
 {
  var operation
   =new EF_MnOP.AlterColumnOperation
    {
     Table            = c_NameOf_Table,
     Name             = c_NameOf_Column,
     ClrType          = typeof(int),
     IsNullable       = false,

     [xEFCore.MetaData.Internal.LcpiOleDb__AnnotationNames.ValueGenerationStrategy]
      =xEFCore.MetaData.LcpiOleDb__ValueGenerationStrategy.SequenceTrigger(c_NameOf__Trigger2,c_NameOf__Sequence1),

     OldColumn = new EF_MnOP.AddColumnOperation
     {
      Table           = c_NameOf_Table,
      Name            = c_NameOf_Column,
      ClrType         = typeof(int),
      IsNullable      = false,

      [xEFCore.MetaData.Internal.LcpiOleDb__AnnotationNames.ValueGenerationStrategy]
       =xEFCore.MetaData.LcpiOleDb__ValueGenerationStrategy.SequenceTrigger(c_NameOf__Trigger1,c_NameOf__Sequence1),
     }//OldColumn
    };//operation

  //----------------------------------------
  var expectedSQL1
   =new TestSqlTemplate()
     .T("DROP TRIGGER ").N(c_NameOf__Trigger1).T(";").CRLF();

  var expectedSQL2
   =new TestSqlTemplate()
     .T("CREATE TRIGGER ").N(c_NameOf__Trigger2).T(" ACTIVE BEFORE INSERT ON ").N(c_NameOf_Table).CRLF()
     .T("AS").CRLF()
     .T("BEGIN").CRLF()
     .T("    IF (NEW.").N(c_NameOf_Column).T(" IS NULL) THEN").CRLF()
     .T("    BEGIN").CRLF()
     .T("        NEW.").N(c_NameOf_Column).T(" = NEXT VALUE FOR ").N(c_NameOf__Sequence1).T(";").CRLF()
     .T("    END").CRLF()
     .T("END;").CRLF();

  TestHelper.Exec
   (new []{operation},
    new []{expectedSQL1,expectedSQL2});
 }//Test_0001__changed_tr_name

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0002__changed_seq_name()
 {
  var operation
   =new EF_MnOP.AlterColumnOperation
    {
     Table            = c_NameOf_Table,
     Name             = c_NameOf_Column,
     ClrType          = typeof(int),
     IsNullable       = false,

     [xEFCore.MetaData.Internal.LcpiOleDb__AnnotationNames.ValueGenerationStrategy]
      =xEFCore.MetaData.LcpiOleDb__ValueGenerationStrategy.SequenceTrigger(c_NameOf__Trigger1,c_NameOf__Sequence2),

     OldColumn = new EF_MnOP.AddColumnOperation
     {
      Table           = c_NameOf_Table,
      Name            = c_NameOf_Column,
      ClrType         = typeof(int),
      IsNullable      = false,

      [xEFCore.MetaData.Internal.LcpiOleDb__AnnotationNames.ValueGenerationStrategy]
       =xEFCore.MetaData.LcpiOleDb__ValueGenerationStrategy.SequenceTrigger(c_NameOf__Trigger1,c_NameOf__Sequence1),
     }//OldColumn
    };//operation

  //----------------------------------------
  var expectedSQL1
   =new TestSqlTemplate()
     .T("DROP TRIGGER ").N(c_NameOf__Trigger1).T(";").CRLF();

  var expectedSQL2
   =new TestSqlTemplate()
     .T("CREATE TRIGGER ").N(c_NameOf__Trigger1).T(" ACTIVE BEFORE INSERT ON ").N(c_NameOf_Table).CRLF()
     .T("AS").CRLF()
     .T("BEGIN").CRLF()
     .T("    IF (NEW.").N(c_NameOf_Column).T(" IS NULL) THEN").CRLF()
     .T("    BEGIN").CRLF()
     .T("        NEW.").N(c_NameOf_Column).T(" = NEXT VALUE FOR ").N(c_NameOf__Sequence2).T(";").CRLF()
     .T("    END").CRLF()
     .T("END;").CRLF();

  TestHelper.Exec
   (new []{operation},
    new []{expectedSQL1,expectedSQL2});
 }//Test_0002__changed_seq_name
};//class TestSet_004__DROP_CREATE

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.AlterColumn.VGS_SequenceTrigger

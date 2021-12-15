////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 09.11.2021.
using Microsoft.EntityFrameworkCore.Migrations.Operations;

using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.DataTypes.Clr.Int32{
////////////////////////////////////////////////////////////////////////////////

using T_DATA=System.Int32;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_009__VGS__SequenceTrigger

public static class TestSet_009__VGS__SequenceTrigger
{
 private const string c_testTableName
  ="EFCORE_TTABLE_DUMMY";

 private const string c_testColumnName
  ="MY_COLUMN";

 private const string c_NameOf__Trigger
  ="TRIGGER_NAME";

 private const string c_NameOf__Sequence
  ="SEQUENCE_NAME";

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0001__NOT_NULL()
 {
  var operation
   =new CreateTableOperation
    {
     Name
      =c_testTableName,

     Columns
      ={
        new AddColumnOperation
        {
         Name            = c_testColumnName,
         Table           = c_testTableName,
         ClrType         = typeof(T_DATA),
         IsNullable      = false,

         [xEFCore.MetaData.Internal.LcpiOleDb__AnnotationNames.ValueGenerationStrategy]
          =xEFCore.MetaData.LcpiOleDb__ValueGenerationStrategy.SequenceTrigger
            (c_NameOf__Trigger,
             c_NameOf__Sequence),
        },
       },
    };//operation

  //------------------------------------------------------------
  var expectedSQL1
   =new TestSqlTemplate()
     .T("CREATE TABLE ").N(c_testTableName).T(" (").CRLF()
     .T("    ").N(c_testColumnName).T(" INTEGER NOT NULL").CRLF()
     .T(");").CRLF();

  var expectedSQL2
   =new TestSqlTemplate()
     .T("CREATE TRIGGER ").N(c_NameOf__Trigger).T(" ACTIVE BEFORE INSERT ON ").N(c_testTableName).CRLF()
     .T("AS").CRLF()
     .T("BEGIN").CRLF()
     .T("    IF (NEW.").N(c_testColumnName).T(" IS NULL) THEN").CRLF()
     .T("    BEGIN").CRLF()
     .T("        NEW.").N(c_testColumnName).T(" = NEXT VALUE FOR ").N(c_NameOf__Sequence).T(";").CRLF()
     .T("    END").CRLF()
     .T("END;").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL1, expectedSQL2});
 }//Test_0001__NOT_NULL
};//class TestSet_009__VGS__SequenceTrigger

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.DataTypes.Clr.Int32

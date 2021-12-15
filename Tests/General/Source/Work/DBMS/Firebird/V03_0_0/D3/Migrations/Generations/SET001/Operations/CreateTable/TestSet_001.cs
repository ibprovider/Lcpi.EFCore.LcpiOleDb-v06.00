////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 11.11.2021.
using NUnit.Framework;

using EF_Mn
 =Microsoft.EntityFrameworkCore.Migrations;

using EF_MnOP
 =Microsoft.EntityFrameworkCore.Migrations.Operations;

using xEFCore
 =Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.CreateTable{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_001

public static class TestSet_001
{
 private const string c_NameOf_DetailTable
  ="DETAIL_TABLE";

 private const string c_NameOf_DetailTable__COL__ID
  ="DETAIL_TABLE__ID";

 private const string c_NameOf_DetailTable__COL__MasterID
  ="DETAIL_TABLE__MASTER_ID";

 private const string c_NameOf_DetailTable__COL__StableName
  ="DETAIL_TABLE__STABLE_NAME";

 private const string c_NameOf_DetailTable__PK
  ="DETAIL_TABLE_PRIMARY_KEY";

 private const string c_NameOf_DetailTable__FK_to_MasterTable
  ="DETAIL_TABLE_FK_TO_MASTER_TABLE";

 private const string c_NameOf_DetailTable__UNIQUE__StableName
  ="DETAIL_TABLE_UNIQUE__STABLE_NAME";

 private const string c_NameOf__DetailTable__SequenceTrigger
  ="DETAIL_TABLE_TRIGGER__GEN_ID";

 private const string c_NameOf__DetailTable__Sequence
  ="DETAIL_TABLE_SEQUENCE";

 private const string c_NameOf_MasterTable
  ="MASTER_TABLE";

 private const string c_NameOf_MasterTable__COL__ID
  ="MASTER_TABLE__ID";

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0001()
 {
  var operation
   =new EF_MnOP.CreateTableOperation
    {
     Name
      =c_NameOf_DetailTable,

     Columns
      ={
        new EF_MnOP.AddColumnOperation
        {
         Name            = c_NameOf_DetailTable__COL__ID,
         Table           = c_NameOf_DetailTable,
         ClrType         = typeof(int),
         IsNullable      = false,

         [xEFCore.MetaData.Internal.LcpiOleDb__AnnotationNames.ValueGenerationStrategy]
          =xEFCore.MetaData.LcpiOleDb__ValueGenerationStrategy.SequenceTrigger
            (c_NameOf__DetailTable__SequenceTrigger,
             c_NameOf__DetailTable__Sequence),
        },

        new EF_MnOP.AddColumnOperation
        {
         Name            = c_NameOf_DetailTable__COL__MasterID,
         Table           = c_NameOf_DetailTable,
         ClrType         = typeof(short),
         IsNullable      = false,
        },

        new EF_MnOP.AddColumnOperation
        {
         Name            = c_NameOf_DetailTable__COL__StableName,
         Table           = c_NameOf_DetailTable,
         ClrType         = typeof(string),
         IsFixedLength   = true,
         MaxLength       = 8,
         IsNullable      = false,
        },
       },

     PrimaryKey
      =new EF_MnOP.AddPrimaryKeyOperation
       {
        Name
         =c_NameOf_DetailTable__PK,

        Columns
         =new []
          {
           c_NameOf_DetailTable__COL__ID,
          },
       },//PrimaryKey

      ForeignKeys
       ={
         new EF_MnOP.AddForeignKeyOperation
          {
           Name             = c_NameOf_DetailTable__FK_to_MasterTable,
           Columns          = new [] {c_NameOf_DetailTable__COL__MasterID},
           PrincipalTable   = c_NameOf_MasterTable,
           PrincipalColumns = new [] {c_NameOf_MasterTable__COL__ID},

           OnUpdate         = EF_Mn.ReferentialAction.Restrict,
           OnDelete         = EF_Mn.ReferentialAction.Cascade,
          },
        },//ForeignKeys

      UniqueConstraints
       ={
         new EF_MnOP.AddUniqueConstraintOperation
          {
           Name             = c_NameOf_DetailTable__UNIQUE__StableName,

           Columns          = new [] {c_NameOf_DetailTable__COL__ID,c_NameOf_DetailTable__COL__StableName},
          },
        },//UniqueConstraints
    };//operation

  //------------------------------------------------------------
  var expectedSQL1
   =new TestSqlTemplate()
     .T("CREATE TABLE ").N(c_NameOf_DetailTable).T(" (").CRLF()
     .T("    ").N(c_NameOf_DetailTable__COL__ID).T(" INTEGER NOT NULL").T(",").CRLF()
     .T("    ").N(c_NameOf_DetailTable__COL__MasterID).T(" SMALLINT NOT NULL").T(",").CRLF()
     .T("    ").N(c_NameOf_DetailTable__COL__StableName).T(" CHAR(8) CHARACTER SET UTF8 NOT NULL").T(",").CRLF()
     .T("    CONSTRAINT ").N(c_NameOf_DetailTable__PK).T(" PRIMARY KEY (").N(c_NameOf_DetailTable__COL__ID).T("),").CRLF()
     .T("    CONSTRAINT ").N(c_NameOf_DetailTable__UNIQUE__StableName).T(" UNIQUE (").N(c_NameOf_DetailTable__COL__ID).T(", ").N(c_NameOf_DetailTable__COL__StableName).T("),").CRLF()
     .T("    CONSTRAINT ").N(c_NameOf_DetailTable__FK_to_MasterTable).T(" FOREIGN KEY (").N(c_NameOf_DetailTable__COL__MasterID).T(") REFERENCES ").N(c_NameOf_MasterTable).T(" (").N(c_NameOf_MasterTable__COL__ID).T(") ON DELETE CASCADE").CRLF()
     .T(");").CRLF();

  var expectedSQL2
   =new TestSqlTemplate()
     .T("CREATE TRIGGER ").N(c_NameOf__DetailTable__SequenceTrigger).T(" ACTIVE BEFORE INSERT ON ").N(c_NameOf_DetailTable).CRLF()
     .T("AS").CRLF()
     .T("BEGIN").CRLF()
     .T("    IF (NEW.").N(c_NameOf_DetailTable__COL__ID).T(" IS NULL) THEN").CRLF()
     .T("    BEGIN").CRLF()
     .T("        NEW.").N(c_NameOf_DetailTable__COL__ID).T(" = NEXT VALUE FOR ").N(c_NameOf__DetailTable__Sequence).T(";").CRLF()
     .T("    END").CRLF()
     .T("END;").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL1,expectedSQL2});
 }//Test_0001
};//class TestSet_001

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.CreateTable

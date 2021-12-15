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
//class TestSet_002

public static class TestSet_002
{
 private const string c_NameOf_DetailTable
  ="DETAIL_TABLE";

 private const string c_NameOf_DetailTable__COL__ID1
  ="DETAIL_TABLE__ID1";

 private const string c_NameOf_DetailTable__COL__ID2
  ="DETAIL_TABLE__ID2";

 private const string c_NameOf_DetailTable__COL__StableName
  ="DETAIL_TABLE__STABLE_NAME";

 private const string c_NameOf_DetailTable__PK
  ="DETAIL_TABLE_PRIMARY_KEY";

 private const string c_NameOf_DetailTable__FK_to_MasterTable
  ="DETAIL_TABLE_FK_TO_MASTER_TABLE";

 private const string c_NameOf_DetailTable__UNIQUE__StableName
  ="DETAIL_TABLE_UNIQUE__STABLE_NAME";

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
         Name            = c_NameOf_DetailTable__COL__ID1,
         Table           = c_NameOf_DetailTable,
         ClrType         = typeof(int),
         IsNullable      = false,
        },

        new EF_MnOP.AddColumnOperation
        {
         Name            = c_NameOf_DetailTable__COL__ID2,
         Table           = c_NameOf_DetailTable,
         ClrType         = typeof(int),
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
           c_NameOf_DetailTable__COL__ID1,
           c_NameOf_DetailTable__COL__ID2,
          },
       },//PrimaryKey

      UniqueConstraints
       ={
         new EF_MnOP.AddUniqueConstraintOperation
          {
           Name             = c_NameOf_DetailTable__UNIQUE__StableName,

           Columns          = new [] {c_NameOf_DetailTable__COL__StableName},
          },
        },//UniqueConstraints
    };//operation

  //------------------------------------------------------------
  var expectedSQL1
   =new TestSqlTemplate()
     .T("CREATE TABLE ").N(c_NameOf_DetailTable).T(" (").CRLF()
     .T("    ").N(c_NameOf_DetailTable__COL__ID1).T(" INTEGER NOT NULL").T(",").CRLF()
     .T("    ").N(c_NameOf_DetailTable__COL__ID2).T(" INTEGER NOT NULL").T(",").CRLF()
     .T("    ").N(c_NameOf_DetailTable__COL__StableName).T(" CHAR(8) CHARACTER SET UTF8 NOT NULL").T(",").CRLF()
     .T("    CONSTRAINT ").N(c_NameOf_DetailTable__PK).T(" PRIMARY KEY (").N(c_NameOf_DetailTable__COL__ID1).T(", ").N(c_NameOf_DetailTable__COL__ID2).T("),").CRLF()
     .T("    CONSTRAINT ").N(c_NameOf_DetailTable__UNIQUE__StableName).T(" UNIQUE (").N(c_NameOf_DetailTable__COL__StableName).T(")").CRLF()
     .T(");").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL1});
 }//Test_0001
};//class TestSet_002

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.CreateTable

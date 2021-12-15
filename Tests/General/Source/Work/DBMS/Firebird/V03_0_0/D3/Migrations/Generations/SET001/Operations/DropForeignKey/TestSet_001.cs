////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 04.11.2021.
using NUnit.Framework;

using EF_MnOP
 =Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.DropForeignKey{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_001

public static class TestSet_001
{
 private const string c_NameOf_DetailTable
  ="DETAIL_TABLE";

 private const string c_NameOf_FK
  ="FK_DETAIL_MASTER";

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0001()
 {
  var operation
   =new EF_MnOP.DropForeignKeyOperation
    {
     Table            = c_NameOf_DetailTable,
     Name             = c_NameOf_FK,
    };//operation

  //----------------------------------------
  var expectedSQL
   =new TestSqlTemplate()
     .T("ALTER TABLE ").N(c_NameOf_DetailTable).T(" DROP CONSTRAINT ").N(c_NameOf_FK).T(";").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL});
 }//Test_0001
};//class TestSet_001

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.DropForeignKey

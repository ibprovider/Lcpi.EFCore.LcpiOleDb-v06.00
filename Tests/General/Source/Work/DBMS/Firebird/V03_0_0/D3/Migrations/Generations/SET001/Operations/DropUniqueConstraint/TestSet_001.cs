////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 11.11.2021.
using NUnit.Framework;

using EF_MnOP
 =Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.DropUniqueConstraint{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_001

public static class TestSet_001
{
 private const string c_NameOf_Table
  ="MASTER_TABLE";

 private const string c_NameOf_UNIQUE
  ="UNIQUE_MASTER";

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0001()
 {
  var operation
   =new EF_MnOP.DropUniqueConstraintOperation
    {
     Table            = c_NameOf_Table,
     Name             = c_NameOf_UNIQUE,
    };//operation

  //----------------------------------------
  var expectedSQL
   =new TestSqlTemplate()
     .T("ALTER TABLE ").N(c_NameOf_Table).T(" DROP CONSTRAINT ").N(c_NameOf_UNIQUE).T(";").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL});
 }//Test_0001
};//class TestSet_001

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.DropUniqueConstraint

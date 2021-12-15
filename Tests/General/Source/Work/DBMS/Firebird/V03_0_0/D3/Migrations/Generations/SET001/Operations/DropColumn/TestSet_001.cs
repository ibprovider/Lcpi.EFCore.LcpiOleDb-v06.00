////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 04.11.2021.
using NUnit.Framework;

using EF_MnOP
 =Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.DropColumn{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_001

public static class TestSet_001
{
 private const string c_NameOf_Table
  ="TEST_TABLE";

 private const string c_NameOf_Column1
  ="COLUMN1_NAME";

 private const string c_NameOf_Column2
  ="COLUMN2_NAME";

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0001__one_column()
 {
  var operation
   =new EF_MnOP.DropColumnOperation
    {
     Table            = c_NameOf_Table,
     Name             = c_NameOf_Column1
    };//operation

  //----------------------------------------
  var expectedSQL
   =new TestSqlTemplate()
     .T("ALTER TABLE ").N(c_NameOf_Table).T(" DROP COLUMN ").N(c_NameOf_Column1).T(";").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL});
 }//Test_0001__one_column

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0002__two_column()
 {
  var operation1
   =new EF_MnOP.DropColumnOperation
    {
     Table            = c_NameOf_Table,
     Name             = c_NameOf_Column1
    };//operation1

  var operation2
   =new EF_MnOP.DropColumnOperation
    {
     Table            = c_NameOf_Table,
     Name             = c_NameOf_Column2
    };//operation2

  //----------------------------------------
  var expectedSQL1
   =new TestSqlTemplate()
     .T("ALTER TABLE ").N(c_NameOf_Table).T(" DROP COLUMN ").N(c_NameOf_Column1).T(";").CRLF();

  var expectedSQL2
   =new TestSqlTemplate()
     .T("ALTER TABLE ").N(c_NameOf_Table).T(" DROP COLUMN ").N(c_NameOf_Column2).T(";").CRLF();

  TestHelper.Exec
   (new[]{operation1,operation2},
    new[]{expectedSQL1,expectedSQL2});
 }//Test_0002__two_column
};//class TestSet_001

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.DropColumn

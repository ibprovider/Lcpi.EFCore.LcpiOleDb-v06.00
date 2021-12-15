////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 04.11.2021.
using NUnit.Framework;

using EF_MnOP
 =Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.RenameColumn{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_001

public static class TestSet_001
{
 private const string c_NameOf_Table
  ="TEST_TABLE";

 private const string c_NameOf_OLD
  ="OLD_NAME";

 private const string c_NameOf_NEW
  ="NEW_NAME";

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0001()
 {
  var operation
   =new EF_MnOP.RenameColumnOperation
    {
     Table            = c_NameOf_Table,
     Name             = c_NameOf_OLD,
     NewName          = c_NameOf_NEW,
    };//operation

  //----------------------------------------
  var expectedSQL
   =new TestSqlTemplate()
     .T("ALTER TABLE ").N(c_NameOf_Table).T(" ALTER COLUMN ").N(c_NameOf_OLD).T(" TO ").N(c_NameOf_NEW).T(";").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL});
 }//Test_0001

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0002__IGNORE()
 {
  var operation
   =new EF_MnOP.RenameColumnOperation
    {
     Table            = c_NameOf_Table,
     Name             = c_NameOf_OLD,
     NewName          = c_NameOf_OLD,
    };//operation

  //----------------------------------------
  TestHelper.Exec
   (new []{operation},
    new TestSqlTemplate[0]);
 }//Test_0002__IGNORE
};//class TestSet_001

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.RenameColumn

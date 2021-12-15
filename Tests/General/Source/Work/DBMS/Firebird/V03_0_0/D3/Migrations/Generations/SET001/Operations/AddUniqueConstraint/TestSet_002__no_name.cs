////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 11.11.2021.
using NUnit.Framework;

using EF_MnOP
 =Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.AddUniqueConstraint{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_002__no_name

public static class TestSet_002__no_name
{
 private const string c_NameOf_Table
  ="MASTER_TABLE";

 private const string c_NameOf_Table_Col1
  ="ID1";

 private const string c_NameOf_Table_Col2
  ="ID2";

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0001__one_column()
 {
  var operation
   =new EF_MnOP.AddUniqueConstraintOperation
    {
     Table            = c_NameOf_Table,
     Columns          = new[] { c_NameOf_Table_Col1 },
    };//operation

  //----------------------------------------
  var expectedSQL
   =new TestSqlTemplate()
     .T("ALTER TABLE ").N(c_NameOf_Table).T(" ADD ")
     .T("UNIQUE (").N(c_NameOf_Table_Col1).T(");").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL});
 }//Test_0001__one_column

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0002__two_columns()
 {
  var operation
   =new EF_MnOP.AddUniqueConstraintOperation
    {
     Table            = c_NameOf_Table,
     Columns          = new[] { c_NameOf_Table_Col1, c_NameOf_Table_Col2 },
    };//operation

  //----------------------------------------
  var expectedSQL
   =new TestSqlTemplate()
     .T("ALTER TABLE ").N(c_NameOf_Table).T(" ADD ")
     .T("UNIQUE (").N(c_NameOf_Table_Col1).T(", ").N(c_NameOf_Table_Col2).T(");").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL});
 }//Test_0002__two_columns
};//class TestSet_002__no_name

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.AddUniqueConstraint

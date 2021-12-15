////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 04.11.2021.
using System;
using NUnit.Framework;

using EF_MnOP
 =Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.AddPrimaryKey{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_002__no_name

public static class TestSet_002__no_name
{
 private const string c_NameOf_MasterTable
  ="MASTER_TABLE";

 private const string c_NameOf_MasterTable_PkCol1
  ="ID1";

 private const string c_NameOf_MasterTable_PkCol2
  ="ID2";

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0001__one_column()
 {
  var operation
   =new EF_MnOP.AddPrimaryKeyOperation
    {
     Table            = c_NameOf_MasterTable,
     Columns          = new[] { c_NameOf_MasterTable_PkCol1 },
    };//operation

  //----------------------------------------
  var expectedSQL
   =new TestSqlTemplate()
     .T("ALTER TABLE ").N(c_NameOf_MasterTable).T(" ADD ")
     .T("PRIMARY KEY (").N(c_NameOf_MasterTable_PkCol1).T(");").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL});
 }//Test_0001__one_column

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0002__two_columns()
 {
  var operation
   =new EF_MnOP.AddPrimaryKeyOperation
    {
     Table            = c_NameOf_MasterTable,
     Columns          = new[] { c_NameOf_MasterTable_PkCol1, c_NameOf_MasterTable_PkCol2 },
    };//operation

  //----------------------------------------
  var expectedSQL
   =new TestSqlTemplate()
     .T("ALTER TABLE ").N(c_NameOf_MasterTable).T(" ADD ")
     .T("PRIMARY KEY (").N(c_NameOf_MasterTable_PkCol1).T(", ").N(c_NameOf_MasterTable_PkCol2).T(");").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL});
 }//Test_0002__two_columns
};//class TestSet_002__no_name

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.AddPrimaryKey

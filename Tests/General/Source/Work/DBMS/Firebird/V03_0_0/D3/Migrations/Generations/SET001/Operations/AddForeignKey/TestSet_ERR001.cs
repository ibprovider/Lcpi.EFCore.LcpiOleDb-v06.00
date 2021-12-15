////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 03.11.2021.
using System;
using NUnit.Framework;

using EF_MnOP
 =Microsoft.EntityFrameworkCore.Migrations.Operations;

using xEFCore
 =Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.AddForeignKeyOperation{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_ERR001

class TestSet_ERR001
{
 [Test]
 public static void Test_001__DifferentSizeOfColumnLists()
 {
  var operation
   =new EF_MnOP.AddForeignKeyOperation
    {
     Table            = "TT2",
     Name             = "FK",
     Columns          = new[] { "A", "B" },
     PrincipalTable   = "TT1",
     PrincipalColumns = new[] { "A" },
    };//operation

  try
  {
   TestHelper.Exec
    (new[]{operation});
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK
    (e);

   Assert.AreEqual
    (2,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__msql_gen_err__bad_fk_definition__different_size_of_column_lists__2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0__MigrationSqlGenerator,
     2,
     1);

   CheckErrors.CheckErrorRecord__msql_gen_err__failed_to_generate_fk_definition__3
    (TestUtils.GetRecord(e,1),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0__MigrationSqlGenerator,
     "TT2",
     "FK",
     "TT1");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_001__DifferentSizeOfColumnLists

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002__EmptyFkName()
 {
  var operation
   =new EF_MnOP.AddForeignKeyOperation
    {
     Table            = "TT2",
     Name             = "",
     Columns          = new[] { "A" },
     PrincipalTable   = "TT1",
     PrincipalColumns = new[] { "A" },
    };//operation

  try
  {
   TestHelper.Exec
    (new[]{operation});
  }
  catch(ArgumentException e)
  {
   CheckErrors.PrintException_OK
    (e);

   CheckErrors.CheckException__ArgumentIsEmpty
    (e,
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0__MigrationSqlGenerator,
     "ForeignKeyConstraint",
     "operation.Name");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_002__EmptyFkName
};//class TestSet_ERR001

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.AddForeignKeyOperation

////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 05.11.2021.
using System;
using NUnit.Framework;

using EF_MnOP
 =Microsoft.EntityFrameworkCore.Migrations.Operations;

using xEFCore
 =Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Migrations.Generations.SET001.Operations.CreateSequence{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_ERRX01__D1__specific

public static class TestSet_ERRX01__D1__specific
{
 private const string c_NameOf_Sequence
  ="TEST_SEQ";

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0001__overflow()
 {
  var operation
   =new EF_MnOP.CreateSequenceOperation
    {
     Name             = c_NameOf_Sequence,
     IsCyclic         = true,
     ClrType          = typeof(int),
     StartValue       = long.MaxValue,
     IncrementBy      = 1,
    };//operation

  //----------------------------------------
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

   CheckErrors.CheckErrorRecord__msql_gen_err__overflow_in_calculation_of_adjusted_sequence_start_value__3
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__Basement_EF_Dbms_Firebird_V03_0_0_Migrations_D1_Internal_SvcImpls___FB_V03_0_0__MigrationsSvcImpl__GenerateCreateSequence,
     c_NameOf_Sequence,
     long.MaxValue,
     1);

   CheckErrors.CheckErrorRecord__msql_gen_err__failed_to_generate_create_sequence_statement__1
    (TestUtils.GetRecord(e,1),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0__MigrationSqlGenerator,
     c_NameOf_Sequence);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_0001__overflow

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0002__overflow()
 {
  var operation
   =new EF_MnOP.CreateSequenceOperation
    {
     Name             = c_NameOf_Sequence,
     IsCyclic         = true,
     ClrType          = typeof(int),
     StartValue       = long.MinValue,
     IncrementBy      = -1,
    };//operation

  //----------------------------------------
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

   CheckErrors.CheckErrorRecord__msql_gen_err__overflow_in_calculation_of_adjusted_sequence_start_value__3
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__Basement_EF_Dbms_Firebird_V03_0_0_Migrations_D1_Internal_SvcImpls___FB_V03_0_0__MigrationsSvcImpl__GenerateCreateSequence,
     c_NameOf_Sequence,
     long.MinValue,
     -1);

   CheckErrors.CheckErrorRecord__msql_gen_err__failed_to_generate_create_sequence_statement__1
    (TestUtils.GetRecord(e,1),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0__MigrationSqlGenerator,
     c_NameOf_Sequence);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_0002__overflow
};//class TestSet_ERRX01__D1__specific

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Migrations.Generations.SET001.Operations.CreateSequence

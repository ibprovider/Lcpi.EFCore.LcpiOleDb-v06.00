////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 07.11.2021.
using NUnit.Framework;

using EF_MnOP
 =Microsoft.EntityFrameworkCore.Migrations.Operations;

using xEFCore
 =Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Migrations.Generations.SET001.Operations.RestartSequence{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_ERRX01__D1__specific

public static class TestSet_ERRX01__D1__specific
{
 private const string c_NameOf_Sequence
  ="TEST_SEQ";

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0001__less_than_min()
 {
  var operation
   =new EF_MnOP.RestartSequenceOperation
    {
     Name             = c_NameOf_Sequence,
     StartValue       = ((long)int.MinValue)-1
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

   CheckErrors.CheckErrorRecord__msql_gen_err__incorrect_sequence_start_value__4
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__Basement_EF_Dbms_Firebird_V03_0_0_Migrations_D1_Internal_SvcImpls___FB_V03_0_0__MigrationsSvcImpl__GenerateRestartSequence,
     c_NameOf_Sequence,
     operation.StartValue,
     int.MinValue,
     int.MaxValue);

   CheckErrors.CheckErrorRecord__msql_gen_err__failed_to_generate_restart_sequence_statement__1
    (TestUtils.GetRecord(e,1),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0__MigrationSqlGenerator,
     c_NameOf_Sequence);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_0001__less_than_min

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0002__greater_than_max()
 {
  var operation
   =new EF_MnOP.RestartSequenceOperation
    {
     Name             = c_NameOf_Sequence,
     StartValue       = ((long)int.MaxValue)+1
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

   CheckErrors.CheckErrorRecord__msql_gen_err__incorrect_sequence_start_value__4
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__Basement_EF_Dbms_Firebird_V03_0_0_Migrations_D1_Internal_SvcImpls___FB_V03_0_0__MigrationsSvcImpl__GenerateRestartSequence,
     c_NameOf_Sequence,
     operation.StartValue,
     int.MinValue,
     int.MaxValue);

   CheckErrors.CheckErrorRecord__msql_gen_err__failed_to_generate_restart_sequence_statement__1
    (TestUtils.GetRecord(e,1),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0__MigrationSqlGenerator,
     c_NameOf_Sequence);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_0002__greater_than_max
};//class TestSet_ERRX01__D1__specific

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Migrations.Generations.SET001.Operations.RestartSequence

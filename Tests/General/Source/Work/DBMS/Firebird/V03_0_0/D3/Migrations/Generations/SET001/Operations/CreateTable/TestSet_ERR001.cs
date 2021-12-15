////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 10.11.2021.
using System;
using NUnit.Framework;

using EF_MnOP
 =Microsoft.EntityFrameworkCore.Migrations.Operations;

using xEFCore
 =Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.CreateTable{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_ERR001

public static class TestSet_ERR001
{
 [Test]
 public static void Test_0001__newTableNameIsNull()
 {
  var operation
   =new EF_MnOP.CreateTableOperation
    {
     Name
      =null,                                // <--- BAD

     Columns
      ={
        new EF_MnOP.AddColumnOperation
        {
         Name            = "A",
         Table           = "C",
         ClrType         = typeof(int),
         IsNullable      = false,
        },
       },
    };//operation

  //----------------------------------------
  try
  {
   TestHelper.Exec
    (new[]{operation});
  }
  catch(ArgumentNullException e)
  {
   CheckErrors.PrintException_OK
    (e);

   CheckErrors.CheckException__ArgumentNullException
    (e,
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0__MigrationSqlGenerator,
     "Generate(CreateTableOperation...)",
     "operation.Name");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_0001__newTableNameIsNull

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0002__newTableNameIsEmpty()
 {
  var operation
   =new EF_MnOP.CreateTableOperation
    {
     Name
      ="",                                  // <--- BAD

     Columns
      ={
        new EF_MnOP.AddColumnOperation
        {
         Name            = "A",
         Table           = "C",
         ClrType         = typeof(int),
         IsNullable      = false,
        },
       },
    };//operation

  //----------------------------------------
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
     "Generate(CreateTableOperation...)",
     "operation.Name");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_0002__newTableNameIsEmpty

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0003__SchemaIsNotNull()
 {
  var operation
   =new EF_MnOP.CreateTableOperation
    {
     Schema
      ="",                                  // <--- BAD

     Name
      ="A",

     Columns
      ={
        new EF_MnOP.AddColumnOperation
        {
         Name            = "A",
         Table           = "C",
         ClrType         = typeof(int),
         IsNullable      = false,
        },
       },
    };//operation

  //----------------------------------------
  try
  {
   TestHelper.Exec
    (new[]{operation});
  }
  catch(ArgumentException e)
  {
   CheckErrors.PrintException_OK
    (e);

   CheckErrors.CheckException__ArgumentIsNotNull
    (e,
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0__MigrationSqlGenerator,
     "Generate(CreateTableOperation...)",
     "operation.Schema");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_0003__SchemaIsNotNull

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0003__columnIsNull()
 {
  var operation
   =new EF_MnOP.CreateTableOperation
    {
     Name
      ="A",

     Columns
      ={
        new EF_MnOP.AddColumnOperation
        {
         Name            = "C1",
         Table           = "A",
         ClrType         = typeof(int),
         IsNullable      = false,
        },

        null,                               // <----  BAD
       },
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

   CheckErrors.CheckErrorRecord__common_err__argument_is_null__2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0__MigrationSqlGenerator,
     "Generate(CreateTableOperation...)",
     "operation.Columns[1]");

   CheckErrors.CheckErrorRecord__msql_gen_err__failed_to_generate_table_creation_script__1
    (TestUtils.GetRecord(e,1),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0__MigrationSqlGenerator,
     "A");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_0003__SchemaIsNotNull

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0004__incorrectColumnTableName()
 {
  var operation
   =new EF_MnOP.CreateTableOperation
    {
     Name
      ="A",

     Columns
      ={
        new EF_MnOP.AddColumnOperation
        {
         Name            = "C1",
         Table           = "A",
         ClrType         = typeof(int),
         IsNullable      = false,
        },

        new EF_MnOP.AddColumnOperation
        {
         Name            = "C2",
         Table           = "A1",            // <---- BAD
         ClrType         = typeof(int),
         IsNullable      = false,
        },
       },
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

   CheckErrors.CheckErrorRecord__msql_gen_err__column_data_uses_incorrect_table_name__4
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0__MigrationSqlGenerator,
     1,
     "C2",
     "A1",
     "A");

   CheckErrors.CheckErrorRecord__msql_gen_err__failed_to_generate_table_creation_script__1
    (TestUtils.GetRecord(e,1),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0__MigrationSqlGenerator,
     "A");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_0004__incorrectColumnTableName
};//class TestSet_ERR001

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.CreateTable

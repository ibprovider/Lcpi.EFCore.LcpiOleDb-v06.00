////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 10.11.2021.
using System;
using NUnit.Framework;

using EF_MnOP
 =Microsoft.EntityFrameworkCore.Migrations.Operations;

using xEFCore
 =Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.CreateIndex{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_ERR001

public static class TestSet_ERR001
{
 [Test]
 public static void Test_0001__NameIsNull()
 {
  var operation
   =new EF_MnOP.CreateIndexOperation
    {
     Name     =null,                        // <--- BAD
     Table    ="TTT",

     Columns  =new [] {"CC"},
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
     "Generate(CreateIndexOperation...)",
     "operation.Name");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_0001__NameIsNull

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0002__NameIsEmpty()
 {
  var operation
   =new EF_MnOP.CreateIndexOperation
    {
     Name     ="",                          // <--- BAD
     Table    ="TTT",

     Columns  =new [] {"CC"},
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
     "Generate(CreateIndexOperation...)",
     "operation.Name");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_0002__NameIsEmpty

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0003__TableIsNull()
 {
  var operation
   =new EF_MnOP.CreateIndexOperation
    {
     Name     ="CCC",
     Table    =null,                        // <--- BAD

     Columns  =new [] {"CC"},
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
     "Generate(CreateIndexOperation...)",
     "operation.Table");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_0003__TableIsNull

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0004__TableIsEmpty()
 {
  var operation
   =new EF_MnOP.CreateIndexOperation
    {
     Name     ="CCC",
     Table    ="",                          // <--- BAD

     Columns  =new [] {"CC"},
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
     "Generate(CreateIndexOperation...)",
     "operation.Table");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_0004__TableIsEmpty

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0005__SchemaIsNotNull()
 {
  var operation
   =new EF_MnOP.CreateIndexOperation
    {
     Name     ="CCC",
     Table    ="TTT",

     Schema   = "",                         // <--- BAD

     Columns  =new [] {"CC"},
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
     "Generate(CreateIndexOperation...)",
     "operation.Schema");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_0005__SchemaIsNotNull

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0006__ColumnIsEmpty()
 {
  var operation
   =new EF_MnOP.CreateIndexOperation
    {
     Name     ="CCC",
     Table    ="TTT",

     Columns  =new string[0],               // <--- BAD
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
     "Generate(CreateIndexOperation...)",
     "operation.Columns");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_0006__ColumnIsEmpty

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0007__FilterIsEmpty()
 {
  var operation
   =new EF_MnOP.CreateIndexOperation
    {
     Name     ="CCC",
     Table    ="TTT",

     Filter   ="",                          // <--- BAD
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
     "Generate(CreateIndexOperation...)",
     "operation.Filter");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_0007__FilterIsEmpty

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0008__Columns_and_Filter()
 {
  var operation
   =new EF_MnOP.CreateIndexOperation
    {
     Name     ="CCC",
     Table    ="TTT",

     Filter   ="BLA-BLA",
     Columns  =new[]{"C1","C2"},
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

   CheckErrors.CheckErrorRecord__msql_gen_err__bad_index_definition__multiple_data__2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0__MigrationSqlGenerator,
     operation.Name,
     operation.Table);

   CheckErrors.CheckErrorRecord__msql_gen_err__failed_to_generate_create_index_statement__2
    (TestUtils.GetRecord(e,1),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0__MigrationSqlGenerator,
     operation.Name,
     operation.Table);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_0008__Columns_and_Filter

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0009__NO_DATA()
 {
  var operation
   =new EF_MnOP.CreateIndexOperation
    {
     Name     ="CCC",
     Table    ="TTT",

     Filter   =null,
     Columns  =null,
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

   CheckErrors.CheckErrorRecord__msql_gen_err__bad_index_definition__no_data__2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0__MigrationSqlGenerator,
     operation.Name,
     operation.Table);

   CheckErrors.CheckErrorRecord__msql_gen_err__failed_to_generate_create_index_statement__2
    (TestUtils.GetRecord(e,1),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0__MigrationSqlGenerator,
     operation.Name,
     operation.Table);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_0009__NO_DATA
};//class TestSet_ERR001

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.CreateIndex

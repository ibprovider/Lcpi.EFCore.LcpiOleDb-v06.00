////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 11.11.2021.
using System;
using NUnit.Framework;

using EF_MnOP
 =Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.RenameIndex{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_ERR001

class TestSet_ERR001
{
 [Test]
 public static void Test_001__NameIsNull()
 {
  var operation
   =new EF_MnOP.RenameIndexOperation
    {
     Name             = null,
     NewName          = "NEW",
    };//operation

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
     "Generate(RenameIndexOperation...)",
     "operation.Name");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_001__NameIsNull

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002__NameIsEmpty()
 {
  var operation
   =new EF_MnOP.RenameIndexOperation
    {
     Name             = "",
     NewName          = "NEW",
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
     "Generate(RenameIndexOperation...)",
     "operation.Name");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_002__NameIsEmpty

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_003__NewNameIsNull()
 {
  var operation
   =new EF_MnOP.RenameIndexOperation
    {
     Name             = "OLD",
     NewName          = null,
    };//operation

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
     "Generate(RenameIndexOperation...)",
     "operation.NewName");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_003__NewNameIsNull

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_004__NewNameIsEmpty()
 {
  var operation
   =new EF_MnOP.RenameIndexOperation
    {
     Name             = "OLD",
     NewName          = "",
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
     "Generate(RenameIndexOperation...)",
     "operation.NewName");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_004__NewNameIsEmpty

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_005__SchemaIsNotNull()
 {
  var operation
   =new EF_MnOP.RenameIndexOperation
    {
     Name             = "OLD",
     NewName          = "NEW",

     Schema = "",
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

   CheckErrors.CheckException__ArgumentIsNotNull
    (e,
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0__MigrationSqlGenerator,
     "Generate(RenameIndexOperation...)",
     "operation.Schema");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_005__SchemaIsNotNull

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_006__TableIsNotNull()
 {
  var operation
   =new EF_MnOP.RenameIndexOperation
    {
     Name             = "OLD",
     NewName          = "NEW",

     Table = "",
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

   CheckErrors.CheckException__ArgumentIsNotNull
    (e,
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0__MigrationSqlGenerator,
     "Generate(RenameIndexOperation...)",
     "operation.Table");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_006__TableIsNotNull
};//class TestSet_ERR001

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.RenameIndex

////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 03.11.2021.
using System;
using NUnit.Framework;

using EF_MnOP
 =Microsoft.EntityFrameworkCore.Migrations.Operations;

using xEFCore
 =Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.RenameColumn{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_ERR001

class TestSet_ERR001
{
 [Test]
 public static void Test_001__null_Table()
 {
  var operation
   =new EF_MnOP.RenameColumnOperation
    {
     Table            = null,
     Name             = "OLD",
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
     "Generate(RenameColumnOperation...)",
     "operation.Table");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_001__null_Table

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002__null_Name()
 {
  var operation
   =new EF_MnOP.RenameColumnOperation
    {
     Table            = "TTT",
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
     "Generate(RenameColumnOperation...)",
     "operation.Name");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_002__null_Name

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_003__null_NewName()
 {
  var operation
   =new EF_MnOP.RenameColumnOperation
    {
     Table            = "TTT",
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
     "Generate(RenameColumnOperation...)",
     "operation.NewName");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_003__null_NewName

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_101__null_Table()
 {
  var operation
   =new EF_MnOP.RenameColumnOperation
    {
     Table            = "",
     Name             = "OLD",
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
     "Generate(RenameColumnOperation...)",
     "operation.Table");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_101__empty_Table

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_102__empty_Name()
 {
  var operation
   =new EF_MnOP.RenameColumnOperation
    {
     Table            = "TTT",
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
     "Generate(RenameColumnOperation...)",
     "operation.Name");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_102__empty_Name

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_103__empty_NewName()
 {
  var operation
   =new EF_MnOP.RenameColumnOperation
    {
     Table            = "TTT",
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
     "Generate(RenameColumnOperation...)",
     "operation.NewName");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_103__empty_NewName
};//class TestSet_ERR001

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.RenameColumn

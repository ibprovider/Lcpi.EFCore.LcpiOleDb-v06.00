////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 10.11.2021.
using System;
using NUnit.Framework;

using EF_MnOP
 =Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.DropIndex{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_ERR001

public static class TestSet_ERR001
{
 [Test]
 public static void Test_0001__NameIsNull()
 {
  var operation
   =new EF_MnOP.DropIndexOperation
    {
     Name     =null,                        // <--- BAD
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
     "Generate(DropIndexOperation...)",
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
   =new EF_MnOP.DropIndexOperation
    {
     Name     ="",                          // <--- BAD
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
     "Generate(DropIndexOperation...)",
     "operation.Name");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_0002__NameIsEmpty

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0003__TableIsNotNull()
 {
  var operation
   =new EF_MnOP.DropIndexOperation
    {
     Name    ="AAA",
     Table   ="",                           // <--- BAD
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
     "Generate(DropIndexOperation...)",
     "operation.Table");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_0003__TableIsNotNull

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0004__SchemaIsNotNull()
 {
  var operation
   =new EF_MnOP.DropIndexOperation
    {
     Name    ="AAA",
     Schema  ="",                           // <--- BAD
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
     "Generate(DropIndexOperation...)",
     "operation.Schema");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_0004__SchemaIsNotNull
};//class TestSet_ERR001

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.DropIndex

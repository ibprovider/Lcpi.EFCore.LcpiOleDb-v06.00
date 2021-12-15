////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 10.11.2021.
using System;
using NUnit.Framework;

using EF_MnOP
 =Microsoft.EntityFrameworkCore.Migrations.Operations;

using xEFCore
 =Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.AlterColumn{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_ERR001

public static class TestSet_ERR001
{
 [Test]
 public static void Test_0001__inconsistent_table_names()
 {
  var operation
   =new EF_MnOP.AlterColumnOperation
    {
     Table            = "A1",
     Name             = "C1",
     ClrType          = typeof(int),
     IsNullable       = true,
     DefaultValueSql  = "123",

     OldColumn = new EF_MnOP.AddColumnOperation
     {
      Table           = "A2",
      Name            = "C1",
      ClrType         = typeof(int),
      IsNullable      = true,
      DefaultValueSql = "123",
     }//OldColumn
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
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__msql_gen_err__inconsistent_table_names_in_alter_column_operation__2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0__MigrationSqlGenerator,
     "A2",
     "A1");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_0001__inconsistent_table_names

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0002__newTableNameIsNull()
 {
  var operation
   =new EF_MnOP.AlterColumnOperation
    {
     Table            = null,               // <--- BAD
     Name             = "C1",
     ClrType          = typeof(int),
     IsNullable       = true,
     DefaultValueSql  = "123",

     OldColumn = new EF_MnOP.AddColumnOperation
     {
      Table           = "A2",
      Name            = "C1",
      ClrType         = typeof(int),
      IsNullable      = true,
      DefaultValueSql = "123",
     }//OldColumn
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
     "Generate(AlterColumnOperation...)",
     "operation.Table");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_0002__newTableNameIsNull

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0002__newTableNameIsEmpty()
 {
  var operation
   =new EF_MnOP.AlterColumnOperation
    {
     Table            = "",                 // <--- BAD
     Name             = "C1",
     ClrType          = typeof(int),
     IsNullable       = true,
     DefaultValueSql  = "123",

     OldColumn = new EF_MnOP.AddColumnOperation
     {
      Table           = "A2",
      Name            = "C1",
      ClrType         = typeof(int),
      IsNullable      = true,
      DefaultValueSql = "123",
     }//OldColumn
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
     "Generate(AlterColumnOperation...)",
     "operation.Table");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_0002__newTableNameIsEmpty

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0003__oldTableNameIsNull()
 {
  var operation
   =new EF_MnOP.AlterColumnOperation
    {
     Table            = "A1",
     Name             = "C1",
     ClrType          = typeof(int),
     IsNullable       = true,
     DefaultValueSql  = "123",

     OldColumn = new EF_MnOP.AddColumnOperation
     {
      Table           = null,               // <--- BAD
      Name            = "C1",
      ClrType         = typeof(int),
      IsNullable      = true,
      DefaultValueSql = "123",
     }//OldColumn
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
     "Generate(AlterColumnOperation...)",
     "operation.OldColumn.Table");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_0003__oldTableNameIsNull

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0004__oldTableNameIsEmpty()
 {
  var operation
   =new EF_MnOP.AlterColumnOperation
    {
     Table            = "A1",
     Name             = "C1",
     ClrType          = typeof(int),
     IsNullable       = true,
     DefaultValueSql  = "123",

     OldColumn = new EF_MnOP.AddColumnOperation
     {
      Table           = "",                 // <--- BAD
      Name            = "C1",
      ClrType         = typeof(int),
      IsNullable      = true,
      DefaultValueSql = "123",
     }//OldColumn
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
     "Generate(AlterColumnOperation...)",
     "operation.OldColumn.Table");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_0004__oldTableNameIsEmpty

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0005__newColumnNameIsNull()
 {
  var operation
   =new EF_MnOP.AlterColumnOperation
    {
     Table            = "A1",
     Name             = null,               // <--- BAD
     ClrType          = typeof(int),
     IsNullable       = true,
     DefaultValueSql  = "123",

     OldColumn = new EF_MnOP.AddColumnOperation
     {
      Table           = "A2",
      Name            = "C1",
      ClrType         = typeof(int),
      IsNullable      = true,
      DefaultValueSql = "123",
     }//OldColumn
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
     "Generate(AlterColumnOperation...)",
     "operation.Name");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_0005__newColumnNameIsNull

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0006__newColumnNameIsEmpty()
 {
  var operation
   =new EF_MnOP.AlterColumnOperation
    {
     Table            = "A1",
     Name             = "",                  // <--- BAD
     ClrType          = typeof(int),
     IsNullable       = true,
     DefaultValueSql  = "123",

     OldColumn = new EF_MnOP.AddColumnOperation
     {
      Table           = "A2",
      Name            = "C1",
      ClrType         = typeof(int),
      IsNullable      = true,
      DefaultValueSql = "123",
     }//OldColumn
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
     "Generate(AlterColumnOperation...)",
     "operation.Name");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_0006__newColumnNameIsEmpty

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0007__oldColumnNameIsNull()
 {
  var operation
   =new EF_MnOP.AlterColumnOperation
    {
     Table            = "A1",
     Name             = "C1",
     ClrType          = typeof(int),
     IsNullable       = true,
     DefaultValueSql  = "123",

     OldColumn = new EF_MnOP.AddColumnOperation
     {
      Table           = "A2",
      Name            = null,               // <--- BAD
      ClrType         = typeof(int),
      IsNullable      = true,
      DefaultValueSql = "123",
     }//OldColumn
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
     "Generate(AlterColumnOperation...)",
     "operation.OldColumn.Name");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_0007__oldColumnNameIsNull

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0008__oldColumnNameIsEmpty()
 {
  var operation
   =new EF_MnOP.AlterColumnOperation
    {
     Table            = "A1",
     Name             = "C1",
     ClrType          = typeof(int),
     IsNullable       = true,
     DefaultValueSql  = "123",

     OldColumn = new EF_MnOP.AddColumnOperation
     {
      Table           = "A2",
      Name            = "",                 // <--- BAD
      ClrType         = typeof(int),
      IsNullable      = true,
      DefaultValueSql = "123",
     }//OldColumn
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
     "Generate(AlterColumnOperation...)",
     "operation.OldColumn.Name");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_0008__oldColumnNameIsEmpty

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0009__newSchemaNameIsNotNull()
 {
  var operation
   =new EF_MnOP.AlterColumnOperation
    {
     Schema           = "",                 // <--- BAD
     Table            = "A1",
     Name             = "C1",
     ClrType          = typeof(int),
     IsNullable       = true,
     DefaultValueSql  = "123",

     OldColumn = new EF_MnOP.AddColumnOperation
     {
      Table           = "A2",
      Name            = "C1",
      ClrType         = typeof(int),
      IsNullable      = true,
      DefaultValueSql = "123",
     }//OldColumn
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
     "Generate(AlterColumnOperation...)",
     "operation.Schema");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_0009__newSchemaNameIsNotNull

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0010__oldSchemaNameIsNotNull()
 {
  var operation
   =new EF_MnOP.AlterColumnOperation
    {
     Table            = "A1",
     Name             = "C1",
     ClrType          = typeof(int),
     IsNullable       = true,
     DefaultValueSql  = "123",

     OldColumn = new EF_MnOP.AddColumnOperation
     {
      Schema          = "",                 // <--- BAD
      Table           = "A2",
      Name            = "C1",
      ClrType         = typeof(int),
      IsNullable      = true,
      DefaultValueSql = "123",
     }//OldColumn
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
     "Generate(AlterColumnOperation...)",
     "operation.OldColumn.Schema");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_0010__oldSchemaNameIsNotNull

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0011__OldColumnIsNull()
 {
  var operation
   =new EF_MnOP.AlterColumnOperation
    {
     Table            = "A1",
     Name             = "C1",
     ClrType          = typeof(int),
     IsNullable       = true,
     DefaultValueSql  = "123",

     OldColumn = null
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
     "Generate(AlterColumnOperation...)",
     "operation.OldColumn");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_0011__OldColumnIsNull
};//class TestSet_ERR001

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.AlterColumn

////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 24.09.2021.
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Migrations.Generations.SET001.DataTypes.Clr.DateOnly{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_005__def_DefaultValueSql

public static class TestSet_005__def_DefaultValueSql
{
 private const string c_testTableName
  ="EFCORE_TTABLE_DUMMY";

 private const string c_testColumnName
  ="MY_COLUMN";

 //-----------------------------------------------------------------------
 private const string c_testColumnTypeName
  ="DATE";

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0001__NOT_NULL()
 {
  var operation
   =new CreateTableOperation
    {
     Name
      =c_testTableName,
   
     Columns
      ={
        new AddColumnOperation
        {
         Name            = c_testColumnName,
         Table           = c_testTableName,
         ClrType         = null,
         ColumnType      = c_testColumnTypeName,
         IsNullable      = false,
         DefaultValueSql = "12345"
        },
       },
    };//operation

  try
  {
   TestHelper.Exec
    (new[]{operation});
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);
 
   Assert.AreEqual
    (3,
     TestUtils.GetRecordCount(e));
 
   CheckErrors.CheckErrorRecord__type_mapping_err__cn_dialect_does_not_support_usage_of_type_in_DDL_query_2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0_D1__TypeMappingSourceForDDL,
     1,
     "DATE");
 
   CheckErrors.CheckErrorRecord__msql_gen_err__failed_to_generate_column_definition__2
    (TestUtils.GetRecord(e,1),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0__MigrationSqlGenerator,
     c_testTableName,
     c_testColumnName);

   CheckErrors.CheckErrorRecord__msql_gen_err__failed_to_generate_table_creation_script__1
    (TestUtils.GetRecord(e,2),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0__MigrationSqlGenerator,
     c_testTableName);

   return;
  }//catch
 
  TestServices.ThrowWeWaitError();
 }//Test_0001__NOT_NULL

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0002__NULLABLE()
 {
  var operation
   =new CreateTableOperation
    {
     Name
      =c_testTableName,
   
     Columns
      ={
        new AddColumnOperation
        {
         Name            = c_testColumnName,
         Table           = c_testTableName,
         ClrType         = null,
         ColumnType      = c_testColumnTypeName,
         IsNullable      = true,
         DefaultValueSql = "12345"
        },
       },
    };//operation

  try
  {
   TestHelper.Exec
    (new[]{operation});
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);
 
   Assert.AreEqual
    (3,
     TestUtils.GetRecordCount(e));
 
   CheckErrors.CheckErrorRecord__type_mapping_err__cn_dialect_does_not_support_usage_of_type_in_DDL_query_2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0_D1__TypeMappingSourceForDDL,
     1,
     "DATE");
 
   CheckErrors.CheckErrorRecord__msql_gen_err__failed_to_generate_column_definition__2
    (TestUtils.GetRecord(e,1),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0__MigrationSqlGenerator,
     c_testTableName,
     c_testColumnName);

   CheckErrors.CheckErrorRecord__msql_gen_err__failed_to_generate_table_creation_script__1
    (TestUtils.GetRecord(e,2),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0__MigrationSqlGenerator,
     c_testTableName);

   return;
  }//catch
 
  TestServices.ThrowWeWaitError();
 }//Test_0002__NULLABLE
};//class TestSet_005__def_DefaultValueSql

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Migrations.Generations.SET001.DataTypes.Clr.DateOnly

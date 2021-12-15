////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 23.09.2021.
using System.Linq;

using Microsoft.EntityFrameworkCore.Migrations.Operations;

using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Migrations.Generations.SET001.DataTypes.Clr.DateOnly{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_ERR100__bad_AnnotationAttr

public static class TestSet_ERR100__bad_AnnotationAttr
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
 public static void Test_001__unkwnon_annotation()
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
         ColumnType      = c_testColumnTypeName,
         IsNullable      = false,
         
         ["AAAA"]=321,
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

   CheckErrors.CheckErrorRecord__common_err__unknown_annotation__1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0__MigrationSqlGenerator,
     "AAAA");

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
 }//Test_001__unkwnon_annotation

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002__annotation_with_null_value__NO_PROBLEM()
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
         ColumnType      = c_testColumnTypeName,
         IsNullable      = false,
         
         //remove annotation
         [xEFCore.MetaData.Internal.LcpiOleDb__AnnotationNames.ValueGenerationStrategy]
          =null,
        },
       },
    };//operation

  Assert.IsEmpty
   (operation.GetAnnotations());
 }//Test_002__annotation_with_null_value__NO_PROBLEM

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_003__bad_annotation_value_type()
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
         ColumnType      = c_testColumnTypeName,
         IsNullable      = false,
         
         [xEFCore.MetaData.Internal.LcpiOleDb__AnnotationNames.ValueGenerationStrategy]
          =321.0,
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

   CheckErrors.CheckErrorRecord__common_err__annotation_has_value_with_unexpected_type__3
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0__MigrationSqlGenerator,
     xEFCore.MetaData.Internal.LcpiOleDb__AnnotationNames.ValueGenerationStrategy,
     "System.Double",
     "Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.MetaData.LcpiOleDb__AnnotationData__ValueGenerationStrategy");

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
 }//Test_003__bad_annotation_value_type

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_005__multiple_definition_of_annotation__NO_PROBLEM()
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
         ColumnType      = c_testColumnTypeName,
         IsNullable      = false,
         
         [xEFCore.MetaData.Internal.LcpiOleDb__AnnotationNames.ValueGenerationStrategy]
          =xEFCore.MetaData.LcpiOleDb__ValueGenerationStrategy.None,
         
         //replaces previous setup
         [xEFCore.MetaData.Internal.LcpiOleDb__AnnotationNames.ValueGenerationStrategy]
          =xEFCore.MetaData.LcpiOleDb__ValueGenerationStrategy.IdentityByDefaultColumn,
        },
       },
    };//operation

  var expected
    =new[]{xEFCore.MetaData.LcpiOleDb__ValueGenerationStrategy.IdentityByDefaultColumn};

  var actual
   =operation.Columns[0].GetAnnotations().Select(p => p.Value);

  Assert.IsTrue
   (expected.SequenceEqual(actual));
 }//Test_005__multiple_definition_of_annotation__NO_PROBLEM
};//class TestSet_ERR100__bad_AnnotationAttr

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Migrations.Generations.SET001.DataTypes.Clr.DateOnly

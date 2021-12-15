////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 23.09.2021.
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using NUnit.Framework;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Migrations.Generations.SET001{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_001__CREATE_TABLE

public static class TestSet_001__CREATE_TABLE
{
 [Test]
 public static void Test_0001__simple_table()
 {
  const string c_testTableName
   ="EFCORE_TTABLE_DUMMY";

  const string c_testTable_ColumnName_ID
   ="ID";

  var operation
   =new CreateTableOperation
    {
     Name
      =c_testTableName,
   
     Columns
      ={
        new AddColumnOperation
        {
         Name       = c_testTable_ColumnName_ID,
         Table      = c_testTableName,
         ClrType    = typeof(int),
         IsNullable = false,
        },
       },
    };//operation

  var expectedSQL
   =new TestSqlTemplate()
     .T("CREATE TABLE ").N(c_testTableName).T(" (").CRLF()
     .T("    ").N(c_testTable_ColumnName_ID).T(" INTEGER NOT NULL").CRLF()
     .T(");").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL});
 }//Test_0001__simple_table

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0002__simple_table_with_pk()
 {
  const string c_testTableName
   ="EFCORE_TTABLE_DUMMY";

  const string c_testTable_ColumnName_ID
   ="ID";

  var operation
   =new CreateTableOperation
    {
     Name
      =c_testTableName,
   
     Columns
      ={
        new AddColumnOperation
        {
         Name       = c_testTable_ColumnName_ID,
         Table      = c_testTableName,
         ClrType    = typeof(int),
         IsNullable = false,
        },
       },
   
     PrimaryKey
      =new AddPrimaryKeyOperation
       {
        Columns
         =new[]
         {
          c_testTable_ColumnName_ID
         },
       },
    };//operation

  var expectedSQL
   =new TestSqlTemplate()
     .T("CREATE TABLE ").N(c_testTableName).T(" (").CRLF()
     .T("    ").N(c_testTable_ColumnName_ID).T(" INTEGER NOT NULL,").CRLF()
     .T("    PRIMARY KEY (").N(c_testTable_ColumnName_ID).T(")").CRLF()
     .T(");").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL});
 }//Test_0002__simple_table_with_pk
};//class TestSet_001__CREATE_TABLE

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Migrations.Generations.SET001

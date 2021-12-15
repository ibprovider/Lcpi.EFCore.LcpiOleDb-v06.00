////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 09.11.2021.
using NUnit.Framework;

using EF_MnOP
 =Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.AlterColumn.Default{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_003__Default__SET

public static class TestSet_003__Default__SET
{
 private const string c_NameOf_Table
  ="TEST_TABLE";

 private const string c_NameOf_Column
  ="COLUMN_NAME";

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0001__defaultValue__null()
 {
  var operation
   =new EF_MnOP.AlterColumnOperation
    {
     Table            = c_NameOf_Table,
     Name             = c_NameOf_Column,
     ClrType          = typeof(int),
     IsNullable       = true,
     DefaultValue     = 123,

     OldColumn = new EF_MnOP.AddColumnOperation
     {
      Table           = c_NameOf_Table,
      Name            = c_NameOf_Column,
      ClrType         = typeof(int),
      IsNullable      = true,
     }//OldColumn
    };//operation

  //----------------------------------------
  var expectedSQL
   =new TestSqlTemplate()
     .T("ALTER TABLE ").N(c_NameOf_Table).T(" ALTER COLUMN ").N(c_NameOf_Column).T(" SET DEFAULT 123;").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL});
 }//Test_0001__defaultValue__null

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0002__defaultValueSql__null()
 {
  var operation
   =new EF_MnOP.AlterColumnOperation
    {
     Table            = c_NameOf_Table,
     Name             = c_NameOf_Column,
     ClrType          = typeof(int),
     IsNullable       = true,
     DefaultValueSql  = "123",

     OldColumn = new EF_MnOP.AddColumnOperation
     {
      Table           = c_NameOf_Table,
      Name            = c_NameOf_Column,
      ClrType         = typeof(int),
      IsNullable      = true,
     }//OldColumn
    };//operation

  //----------------------------------------
  var expectedSQL
   =new TestSqlTemplate()
     .T("ALTER TABLE ").N(c_NameOf_Table).T(" ALTER COLUMN ").N(c_NameOf_Column).T(" SET DEFAULT 123;").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL});
 }//Test_0002__defaultValueSql__null

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0003__defaultValue__defaultValue2()
 {
  var operation
   =new EF_MnOP.AlterColumnOperation
    {
     Table            = c_NameOf_Table,
     Name             = c_NameOf_Column,
     ClrType          = typeof(int),
     IsNullable       = true,
     DefaultValue     = 333,

     OldColumn = new EF_MnOP.AddColumnOperation
     {
      Table           = c_NameOf_Table,
      Name            = c_NameOf_Column,
      ClrType         = typeof(int),
      IsNullable      = true,
      DefaultValue    = 222
     }//OldColumn
    };//operation

  //----------------------------------------
  var expectedSQL
   =new TestSqlTemplate()
     .T("ALTER TABLE ").N(c_NameOf_Table).T(" ALTER COLUMN ").N(c_NameOf_Column).T(" SET DEFAULT 333;").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL});
 }//Test_0003__defaultValue__defaultValue2

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0004__defaultValueSql__defaultValue2()
 {
  var operation
   =new EF_MnOP.AlterColumnOperation
    {
     Table            = c_NameOf_Table,
     Name             = c_NameOf_Column,
     ClrType          = typeof(int),
     IsNullable       = true,
     DefaultValueSql  = "333",

     OldColumn = new EF_MnOP.AddColumnOperation
     {
      Table           = c_NameOf_Table,
      Name            = c_NameOf_Column,
      ClrType         = typeof(int),
      IsNullable      = true,
      DefaultValue    = 222
     }//OldColumn
    };//operation

  //----------------------------------------
  var expectedSQL
   =new TestSqlTemplate()
     .T("ALTER TABLE ").N(c_NameOf_Table).T(" ALTER COLUMN ").N(c_NameOf_Column).T(" SET DEFAULT 333;").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL});
 }//Test_0004__defaultValueSql__defaultValue2

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0005__defaultValue__defaultValueSql2()
 {
  var operation
   =new EF_MnOP.AlterColumnOperation
    {
     Table            = c_NameOf_Table,
     Name             = c_NameOf_Column,
     ClrType          = typeof(int),
     IsNullable       = true,
     DefaultValue     = 333,

     OldColumn = new EF_MnOP.AddColumnOperation
     {
      Table           = c_NameOf_Table,
      Name            = c_NameOf_Column,
      ClrType         = typeof(int),
      IsNullable      = true,
      DefaultValueSql = "222"
     }//OldColumn
    };//operation

  //----------------------------------------
  var expectedSQL
   =new TestSqlTemplate()
     .T("ALTER TABLE ").N(c_NameOf_Table).T(" ALTER COLUMN ").N(c_NameOf_Column).T(" SET DEFAULT 333;").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL});
 }//Test_0005__defaultValue__defaultValueSql2

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0006__defaultValueSql__defaultValueSql2()
 {
  var operation
   =new EF_MnOP.AlterColumnOperation
    {
     Table            = c_NameOf_Table,
     Name             = c_NameOf_Column,
     ClrType          = typeof(int),
     IsNullable       = true,
     DefaultValueSql  = "333",

     OldColumn = new EF_MnOP.AddColumnOperation
     {
      Table           = c_NameOf_Table,
      Name            = c_NameOf_Column,
      ClrType         = typeof(int),
      IsNullable      = true,
      DefaultValueSql = "222"
     }//OldColumn
    };//operation

  //----------------------------------------
  var expectedSQL
   =new TestSqlTemplate()
     .T("ALTER TABLE ").N(c_NameOf_Table).T(" ALTER COLUMN ").N(c_NameOf_Column).T(" SET DEFAULT 333;").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL});
 }//Test_0006__defaultValueSql__defaultValueSql2
};//class TestSet_003__Default__SET

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.AlterColumn.Default

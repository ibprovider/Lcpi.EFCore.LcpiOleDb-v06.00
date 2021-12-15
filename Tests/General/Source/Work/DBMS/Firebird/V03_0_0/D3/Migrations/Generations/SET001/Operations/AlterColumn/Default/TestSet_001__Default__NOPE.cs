////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 09.11.2021.
using NUnit.Framework;

using EF_MnOP
 =Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.AlterColumn.Default{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_001__Default__NOPE

public static class TestSet_001__Default__NOPE
{
 private const string c_NameOf_Table
  ="TEST_TABLE";

 private const string c_NameOf_Column
  ="COLUMN_NAME";

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0001__old_without_default()
 {
  var operation
   =new EF_MnOP.AlterColumnOperation
    {
     Table            = c_NameOf_Table,
     Name             = c_NameOf_Column,
     ClrType          = typeof(int),
     IsNullable       = true,

     OldColumn = new EF_MnOP.AddColumnOperation
     {
      Table           = c_NameOf_Table,
      Name            = c_NameOf_Column,
      ClrType         = typeof(int),
      IsNullable      = true,

      DefaultValue    = null,
      DefaultValueSql = null,
     }//OldColumn
    };//operation

  //----------------------------------------
  TestHelper.Exec
   (new []{operation},
    new TestSqlTemplate[0]);
 }//Test_0001__old_without_default

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0002__equal__defaultValue__defaultValue()
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
      DefaultValue    = 123,
     }//OldColumn
    };//operation

  //----------------------------------------
  TestHelper.Exec
   (new []{operation},
    new TestSqlTemplate[0]);
 }//Test_0002__equal__defaultValue__defaultValue

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0003__equal__defaultValue__defaultValueSql()
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
      DefaultValueSql = "123",
     }//OldColumn
    };//operation

  //----------------------------------------
  TestHelper.Exec
   (new []{operation},
    new TestSqlTemplate[0]);
 }//Test_0003__equal__defaultValue__defaultValueSql

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0004__equal__defaultValueSql__defaultValue()
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
      DefaultValue    = 123,
     }//OldColumn
    };//operation

  //----------------------------------------
  TestHelper.Exec
   (new []{operation},
    new TestSqlTemplate[0]);
 }//Test_0004__equal__defaultValueSql__defaultValue

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0005__equal__defaultValueSql__defaultValueSql()
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
      DefaultValueSql = "123",
     }//OldColumn
    };//operation

  //----------------------------------------
  TestHelper.Exec
   (new []{operation},
    new TestSqlTemplate[0]);
 }//Test_0005__equal__defaultValueSql__defaultValueSql

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0006__equal__defaultValueSql__defaultValueSql___spaces()
 {
  var operation
   =new EF_MnOP.AlterColumnOperation
    {
     Table            = c_NameOf_Table,
     Name             = c_NameOf_Column,
     ClrType          = typeof(int),
     IsNullable       = true,
     DefaultValueSql  = "  123  ",

     OldColumn = new EF_MnOP.AddColumnOperation
     {
      Table           = c_NameOf_Table,
      Name            = c_NameOf_Column,
      ClrType         = typeof(int),
      IsNullable      = true,
      DefaultValueSql = " 123 ",
     }//OldColumn
    };//operation

  //----------------------------------------
  TestHelper.Exec
   (new []{operation},
    new TestSqlTemplate[0]);
 }//Test_0006__equal__defaultValueSql__defaultValueSql___spaces
};//class TestSet_001__Default__NOPE

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.AlterColumn.Default

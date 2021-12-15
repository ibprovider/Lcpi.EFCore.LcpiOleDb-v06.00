////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 09.11.2021.
using NUnit.Framework;

using EF_MnOP
 =Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.AlterColumn.ColumnType{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_001__NOPE

public static class TestSet_001__NOPE
{
 private const string c_NameOf_Table
  ="TEST_TABLE";

 private const string c_NameOf_Column
  ="COLUMN_NAME";

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0001()
 {
  var operation
   =new EF_MnOP.AlterColumnOperation
    {
     Table            = c_NameOf_Table,
     Name             = c_NameOf_Column,
     ClrType          = typeof(int),
     IsNullable       = false,

     OldColumn = new EF_MnOP.AddColumnOperation
     {
      Table           = c_NameOf_Table,
      Name            = c_NameOf_Column,
      ClrType         = typeof(int),
      IsNullable      = false,
     }//OldColumn
    };//operation

  //----------------------------------------
  TestHelper.Exec
   (new []{operation},
    new TestSqlTemplate[0]);
 }//Test_0001

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0002__varchar8_to_varchar32()
 {
  var operation
   =new EF_MnOP.AlterColumnOperation
    {
     Table            = c_NameOf_Table,
     Name             = c_NameOf_Column,
     ColumnType       = "varchar(32) character set utf8",
     MaxLength        = 32,
     IsFixedLength    = false,
     IsNullable       = false,

     OldColumn = new EF_MnOP.AddColumnOperation
     {
      Table           = c_NameOf_Table,
      Name            = c_NameOf_Column,
      ClrType         = typeof(string),
      MaxLength       = 32,
      IsFixedLength   = false,
      IsNullable      = false,
     }//OldColumn
    };//operation

  //----------------------------------------
  TestHelper.Exec
   (new []{operation},
    new TestSqlTemplate[0]);
 }//Test_0002__varchar8_to_varchar32
};//class TestSet_001__NOPE

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.AlterColumn.ColumnType

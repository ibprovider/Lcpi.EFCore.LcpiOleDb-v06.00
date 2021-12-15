////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 09.11.2021.
using NUnit.Framework;

using EF_MnOP
 =Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.AlterColumn.ColumnType{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_002__DefNewType

public static class TestSet_002__DefNewType
{
 private const string c_NameOf_Table
  ="TEST_TABLE";

 private const string c_NameOf_Column
  ="COLUMN_NAME";

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0001__int_to_long()
 {
  var operation
   =new EF_MnOP.AlterColumnOperation
    {
     Table            = c_NameOf_Table,
     Name             = c_NameOf_Column,
     ClrType          = typeof(long),
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
  var expectedSQL
   =new TestSqlTemplate()
     .T("ALTER TABLE ").N(c_NameOf_Table).T(" ALTER COLUMN ").N(c_NameOf_Column).T(" TYPE BIGINT;").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL});
 }//Test_0001__int_to_long

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0002__varchar8_to_varchar32()
 {
  var operation
   =new EF_MnOP.AlterColumnOperation
    {
     Table            = c_NameOf_Table,
     Name             = c_NameOf_Column,
     ClrType          = typeof(string),
     MaxLength        = 32,
     IsFixedLength    = false,
     IsNullable       = false,

     OldColumn = new EF_MnOP.AddColumnOperation
     {
      Table           = c_NameOf_Table,
      Name            = c_NameOf_Column,
      ClrType         = typeof(string),
      MaxLength       = 8,
      IsFixedLength   = false,
      IsNullable      = false,
     }//OldColumn
    };//operation

  //----------------------------------------
  var expectedSQL
   =new TestSqlTemplate()
     .T("ALTER TABLE ").N(c_NameOf_Table).T(" ALTER COLUMN ").N(c_NameOf_Column).T(" TYPE VARCHAR(32) CHARACTER SET UTF8;").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL});
 }//Test_0002__varchar8_to_varchar32
};//class TestSet_002__DefNewType

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.AlterColumn.ColumnType

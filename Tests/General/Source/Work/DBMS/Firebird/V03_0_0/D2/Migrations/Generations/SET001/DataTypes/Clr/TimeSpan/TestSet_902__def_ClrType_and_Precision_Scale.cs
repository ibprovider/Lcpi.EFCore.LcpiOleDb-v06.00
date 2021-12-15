////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 19.10.2021.
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using NUnit.Framework;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D2.Migrations.Generations.SET001.DataTypes.Clr.TimeSpan{
////////////////////////////////////////////////////////////////////////////////

using T_DATA=System.TimeSpan;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_902__def_ClrType_and_Precision_Scale

public static class TestSet_902__def_ClrType_and_Precision_Scale
{
 private const string c_testTableName
  ="EFCORE_TTABLE_DUMMY";

 private const string c_testColumnName
  ="MY_COLUMN";

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
         ClrType         = typeof(T_DATA),
         IsNullable      = false,

         Precision       = 18,
         Scale           = 4,
        },
       },
    };//operation

  //------------------------------------------------------------
  var expectedSQL
   =new TestSqlTemplate()
     .T("CREATE TABLE ").N(c_testTableName).T(" (").CRLF()
     .T("    ").N(c_testColumnName).T(" NUMERIC(18,4) NOT NULL").CRLF()
     .T(");").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL});
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
         ClrType         = typeof(T_DATA),
         IsNullable      = true,

         Precision       = 18,
         Scale           = 4,
        },
       },
    };//operation

  //------------------------------------------------------------
  var expectedSQL
   =new TestSqlTemplate()
     .T("CREATE TABLE ").N(c_testTableName).T(" (").CRLF()
     .T("    ").N(c_testColumnName).T(" NUMERIC(18,4)").CRLF()
     .T(");").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL});
 }//Test_0002__NULLABLE
};//class TestSet_902__def_ClrType_and_Precision_Scale

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D2.Migrations.Generations.SET001.DataTypes.Clr.TimeSpan

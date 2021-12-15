////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 09.11.2021.
using NUnit.Framework;

using EF_MnOP
 =Microsoft.EntityFrameworkCore.Migrations.Operations;

using xEFCore
 =Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.AlterColumn.VGS_IdentityByDefault{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_ERR001

public static class TestSet_ERR001
{
 private const string c_NameOf_Table
  ="TEST_TABLE";

 private const string c_NameOf_Column
  ="COLUMN_NAME";

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0001__TryDropIdentity()
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

      [xEFCore.MetaData.Internal.LcpiOleDb__AnnotationNames.ValueGenerationStrategy]
       =xEFCore.MetaData.LcpiOleDb__ValueGenerationStrategy.IdentityByDefaultColumn,
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
    (2,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__dbms_err__fb__firebird_does_not_support_drop_identity_attribute_from_column__0
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0__MigrationSqlGenerator);

   CheckErrors.CheckErrorRecord__msql_gen_err__failed_to_generate_alter_column_statement__3
    (TestUtils.GetRecord(e,1),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0__MigrationSqlGenerator,
     c_NameOf_Table,
     c_NameOf_Column,
     c_NameOf_Column);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_0001__TryDropIdentity

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0002__TryAddIdentity()
 {
  var operation
   =new EF_MnOP.AlterColumnOperation
    {
     Table            = c_NameOf_Table,
     Name             = c_NameOf_Column,
     ClrType          = typeof(int),
     IsNullable       = false,

     [xEFCore.MetaData.Internal.LcpiOleDb__AnnotationNames.ValueGenerationStrategy]
      =xEFCore.MetaData.LcpiOleDb__ValueGenerationStrategy.IdentityByDefaultColumn,

     OldColumn = new EF_MnOP.AddColumnOperation
     {
      Table           = c_NameOf_Table,
      Name            = c_NameOf_Column,
      ClrType         = typeof(int),
      IsNullable      = false,
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
    (2,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__dbms_err__fb__firebird_does_not_support_add_identity_attribute_to_column__0
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0__MigrationSqlGenerator);

   CheckErrors.CheckErrorRecord__msql_gen_err__failed_to_generate_alter_column_statement__3
    (TestUtils.GetRecord(e,1),
     CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0__MigrationSqlGenerator,
     c_NameOf_Table,
     c_NameOf_Column,
     c_NameOf_Column);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_0002__TryAddIdentity
};//class TestSet_ERR001

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.AlterColumn.VGS_IdentityByDefault

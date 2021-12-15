////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 25.04.2021.
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Migrations{
////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0__MigrationsSqlGenerator

partial class FB_V03_0_0__MigrationsSqlGenerator
{
 //MigrationsSqlGenerator interface --------------------------------------

 protected override void ForeignKeyAction(ReferentialAction           referentialAction,
                                          MigrationCommandListBuilder builder)
 {
  switch(referentialAction)
  {
   case ReferentialAction.NoAction:
    builder.Append("NO ACTION");
    break;

   case ReferentialAction.Cascade:
    builder.Append("CASCADE");
    break;

   case ReferentialAction.SetNull:
    builder.Append("SET NULL");
    break;

   case ReferentialAction.SetDefault:
    builder.Append("SET DEFAULT");
    break;

   default:
   {
    ThrowError.MSqlGenErr__UnknownFkReferentialAction
     (c_ErrSrcID,
      referentialAction);

    break;
   }//default
  }//switch referentialAction
 }//ForeignKeyAction
};//class FB_V03_0_0__MigrationsSqlGenerator

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Migrations

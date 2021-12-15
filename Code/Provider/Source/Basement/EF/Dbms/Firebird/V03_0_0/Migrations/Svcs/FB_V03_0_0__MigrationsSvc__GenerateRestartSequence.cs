////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 07.11.2021.

using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Migrations.Svcs{
////////////////////////////////////////////////////////////////////////////////
//interface FB_V03_0_0__MigrationsSvc__GenerateRestartSequence

interface FB_V03_0_0__MigrationsSvc__GenerateRestartSequence
 :Core.Core_Svc
{
 void GenerateRestartSequence
        (in MigrationsSqlGeneratorDependencies dependencies,
         RestartSequenceOperation              operation,
         IModel                                model,
         MigrationCommandListBuilder           builder);
};//interface FB_V03_0_0__MigrationsSvc__GenerateRestartSequence

////////////////////////////////////////////////////////////////////////////////
}//Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Migrations.Svcs

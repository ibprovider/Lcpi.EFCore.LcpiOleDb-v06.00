////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 09.11.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Migrations;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Migrations{
////////////////////////////////////////////////////////////////////////////////

using LcpiOleDb__AnnotationData__VGS_SequenceTrigger
 =MetaData.LcpiOleDb__AnnotationData__ValueGenerationStrategy_SequenceTrigger;

////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0__MigrationsSqlGenerator

sealed partial class FB_V03_0_0__MigrationsSqlGenerator
{
 private void Helper__DropSequenceTriggerForColumn
                        (LcpiOleDb__AnnotationData__VGS_SequenceTrigger strategy,
                         MigrationCommandListBuilder                    builder)
 {
  Debug.Assert(!Object.ReferenceEquals(strategy,null));
  Debug.Assert(!Object.ReferenceEquals(builder,null));

  builder.Append("DROP TRIGGER ");
  builder.Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(strategy.TriggerName));

  Helper__TerminateStatement(builder);
 }//Helper__DropSequenceTriggerForColumn
};//class FB_V03_0_0__MigrationsSqlGenerator

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Migrations

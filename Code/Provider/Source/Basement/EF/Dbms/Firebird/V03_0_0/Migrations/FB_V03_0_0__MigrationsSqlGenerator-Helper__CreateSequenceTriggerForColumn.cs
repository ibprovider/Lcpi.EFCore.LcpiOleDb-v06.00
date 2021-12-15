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
 private void Helper__CreateSequenceTriggerForColumn
                        (string                                         tableName,
                         string                                         columnName,
                         LcpiOleDb__AnnotationData__VGS_SequenceTrigger strategy,
                         MigrationCommandListBuilder                    builder)
 {
  Debug.Assert(!Object.ReferenceEquals(tableName,null));
  Debug.Assert(!Object.ReferenceEquals(columnName,null));
  Debug.Assert(!Object.ReferenceEquals(strategy,null));
  Debug.Assert(!Object.ReferenceEquals(builder,null));

  builder.Append("CREATE TRIGGER ");
  builder.Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(strategy.TriggerName));
  builder.Append(" ACTIVE BEFORE INSERT ON ");
  builder.Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(tableName));
  builder.AppendLine();
  builder.AppendLine("AS");
  builder.AppendLine("BEGIN");
  builder.IncrementIndent();
  builder.Append("IF (NEW.");
  builder.Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(columnName));
  builder.Append(" IS NULL) THEN");
  builder.AppendLine();
  builder.AppendLine("BEGIN");
  builder.IncrementIndent();
  builder.Append("NEW.");
  builder.Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(columnName));
  builder.Append(" = NEXT VALUE FOR ");
  builder.Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(strategy.SequenceName));
  builder.Append(Dependencies.SqlGenerationHelper.StatementTerminator);
  builder.AppendLine();
  builder.DecrementIndent();
  builder.AppendLine("END");
  builder.DecrementIndent();
  builder.Append("END");

  Helper__TerminateStatement(builder);
 }//Helper__CreateSequenceTriggerForColumn
};//class FB_V03_0_0__MigrationsSqlGenerator

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Migrations

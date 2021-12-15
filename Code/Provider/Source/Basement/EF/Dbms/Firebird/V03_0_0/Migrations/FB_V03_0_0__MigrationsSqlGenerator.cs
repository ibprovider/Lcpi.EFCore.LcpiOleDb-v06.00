////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 25.04.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Migrations{
////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0__MigrationsSqlGenerator

sealed partial class FB_V03_0_0__MigrationsSqlGenerator
 :MigrationsSqlGenerator
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_V03_0_0__MigrationsSqlGenerator;

 //-----------------------------------------------------------------------
 public FB_V03_0_0__MigrationsSqlGenerator
                        (IRelationalCommandBuilderFactory                    commandBuilderFactory,
                         IUpdateSqlGenerator                                 updateSqlGenerator,
                         ISqlGenerationHelper                                sqlGenerationHelper,
                         Root.Storage.LcpiOleDb__IGetTypeMappingSourceForDDL getTypeMappingSourceForDDL,
                         ICurrentDbContext                                   currentContext,
                         IModificationCommandFactory                         modificationCommandFactory,
                         ILoggingOptions                                     loggingOptions,
                         IRelationalCommandDiagnosticsLogger                 logger,
                         IDiagnosticsLogger<DbLoggerCategory.Migrations>     migrationsLogger,
                         Core.Core_ConnectionOptions                         cnOptions)
  :base(new MigrationsSqlGeneratorDependencies
         (commandBuilderFactory,
          updateSqlGenerator,
          sqlGenerationHelper,
          getTypeMappingSourceForDDL.GetTypeMappingSourceForDDL(),
          currentContext,
          modificationCommandFactory,
          loggingOptions,
          logger,
          migrationsLogger))
 {
#if TRACE
  Core.Core_Trace.Method
   ("FB_V03_0_0__MigrationsSqlGenerator::FB_V03_0_0__MigrationsSqlGenerator(...)");
#endif

  //-------------------------------------------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    "constructor",
    nameof(cnOptions),
    cnOptions);

  //-------------------------------------------------------
  m_MigrationsSvc__GenerateCreateSequence
   =Core.Core_SvcUtils.QuerySvc<Svcs.FB_V03_0_0__MigrationsSvc__GenerateCreateSequence>
     (cnOptions,
      FB_V03_0_0__SvcIDs.FB_V03_0_0__MigrationsSvc__GenerateCreateSequence); //throw

  m_MigrationsSvc__GenerateRestartSequence
   =Core.Core_SvcUtils.QuerySvc<Svcs.FB_V03_0_0__MigrationsSvc__GenerateRestartSequence>
     (cnOptions,
      FB_V03_0_0__SvcIDs.FB_V03_0_0__MigrationsSvc__GenerateRestartSequence); //throw

  m_MigrationsSvc__GenerateAlterSequence
   =Core.Core_SvcUtils.QuerySvc<Svcs.FB_V03_0_0__MigrationsSvc__GenerateAlterSequence>
     (cnOptions,
      FB_V03_0_0__SvcIDs.FB_V03_0_0__MigrationsSvc__GenerateAlterSequence); //throw

  //-------------------------------------------------------
  Debug.Assert(!Object.ReferenceEquals(m_MigrationsSvc__GenerateCreateSequence,null));
  Debug.Assert(!Object.ReferenceEquals(m_MigrationsSvc__GenerateRestartSequence,null));
  Debug.Assert(!Object.ReferenceEquals(m_MigrationsSvc__GenerateAlterSequence,null));
 }//FB_V03_0_0__MigrationsSqlGenerator

 //Helper methods --------------------------------------------------------
 private void Helper__TerminateStatement(MigrationCommandListBuilder builder)
 {
  Debug.Assert(!Object.ReferenceEquals(builder,null));

  builder.AppendLine(this.Dependencies.SqlGenerationHelper.StatementTerminator);

  this.EndStatement(builder);
 }//Helper__TerminateStatement

 //-----------------------------------------------------------------------
 private static bool Helper__HasDefinitionOfDefaultValue(ColumnOperation columnOperation)
 {
  Debug.Assert(!Object.ReferenceEquals(columnOperation,null));

  if(!Object.ReferenceEquals(columnOperation.DefaultValueSql,null))
   return true;

  if(!Object.ReferenceEquals(columnOperation.DefaultValue,null))
   return true;

  return false;
 }//Helper__HasDefinitionOfDefaultValue

 //private data ----------------------------------------------------------
 private readonly Svcs.FB_V03_0_0__MigrationsSvc__GenerateCreateSequence
  m_MigrationsSvc__GenerateCreateSequence;

 private readonly Svcs.FB_V03_0_0__MigrationsSvc__GenerateRestartSequence
  m_MigrationsSvc__GenerateRestartSequence;

 private readonly Svcs.FB_V03_0_0__MigrationsSvc__GenerateAlterSequence
  m_MigrationsSvc__GenerateAlterSequence;
};//class FB_V03_0_0__MigrationsSqlGenerator

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Migrations

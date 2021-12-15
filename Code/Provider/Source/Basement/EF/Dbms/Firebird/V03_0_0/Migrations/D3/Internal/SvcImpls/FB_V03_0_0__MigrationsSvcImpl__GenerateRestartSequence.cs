////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 05.11.2021.
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Globalization;

using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Migrations.D3.Internal.SvcImpls{
////////////////////////////////////////////////////////////////////////////////

using FIREBIRD_SEQUENCE_DATATYPE
 =System.Int64;

////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0__MigrationsSvcImpl__GenerateRestartSequence

sealed class FB_V03_0_0__MigrationsSvcImpl__GenerateRestartSequence
 :Svcs.FB_V03_0_0__MigrationsSvc__GenerateRestartSequence
{
 public static readonly Svcs.FB_V03_0_0__MigrationsSvc__GenerateRestartSequence
  Instance
   =new FB_V03_0_0__MigrationsSvcImpl__GenerateRestartSequence();

 //-----------------------------------------------------------------------
 private FB_V03_0_0__MigrationsSvcImpl__GenerateRestartSequence()
 {
 }

 //interface -------------------------------------------------------------
 public void GenerateRestartSequence
              (in MigrationsSqlGeneratorDependencies dependencies,
               RestartSequenceOperation              operation,
               IModel                                model,
               MigrationCommandListBuilder           builder)
 {
  Debug.Assert(!Object.ReferenceEquals(operation,null));
  Debug.Assert( Object.ReferenceEquals(operation.Schema,null));
  Debug.Assert(!Object.ReferenceEquals(operation.Name,null));
  Debug.Assert(!Object.ReferenceEquals(builder,null));

  Debug.Assert(operation.Name.Length>0);

  //---------------------------------------- Base verification

  Debug.Assert(operation.StartValue.GetType()==typeof(FIREBIRD_SEQUENCE_DATATYPE));

  //---------------------------------------- Generation

  //
  // [2021-11-07]
  //
  // No correction of start value.
  //
  // See service for CreateSequence statement.
  //

  builder.Append("ALTER SEQUENCE ");
  builder.Append(dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Name, operation.Schema));
  builder.Append(" RESTART WITH ");
  builder.Append(operation.StartValue.ToString(CultureInfo.InvariantCulture));
 }//GenerateRestartSequence
};//interface FB_V03_0_0__MigrationsSvcImpl__GenerateRestartSequence

////////////////////////////////////////////////////////////////////////////////
}//Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Migrations.D3.Internal.SvcImpls

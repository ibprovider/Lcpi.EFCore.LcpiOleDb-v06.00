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
//class FB_V03_0_0__MigrationsSvcImpl__GenerateAlterSequence

sealed class FB_V03_0_0__MigrationsSvcImpl__GenerateAlterSequence
 :Svcs.FB_V03_0_0__MigrationsSvc__GenerateAlterSequence
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Basement_EF_Dbms_Firebird_V03_0_0_Migrations_D3_Internal_SvcImpls___FB_V03_0_0__MigrationsSvcImpl__GenerateAlterSequence;

 //-----------------------------------------------------------------------
 public static readonly Svcs.FB_V03_0_0__MigrationsSvc__GenerateAlterSequence
  Instance
   =new FB_V03_0_0__MigrationsSvcImpl__GenerateAlterSequence();

 //-----------------------------------------------------------------------
 private FB_V03_0_0__MigrationsSvcImpl__GenerateAlterSequence()
 {
 }

 //interface -------------------------------------------------------------
 public void GenerateAlterSequence
              (in MigrationsSqlGeneratorDependencies dependencies,
               AlterSequenceOperation               operation,
               IModel                                model,
               MigrationCommandListBuilder           builder)
 {
  Debug.Assert(!Object.ReferenceEquals(operation,null));
  Debug.Assert( Object.ReferenceEquals(operation.Schema,null));
  Debug.Assert(!Object.ReferenceEquals(operation.Name,null));
  Debug.Assert(!Object.ReferenceEquals(builder,null));

  Debug.Assert(operation.Name.Length>0);

  //---------------------------------------- Base verification
  {
   List<Core.Core_ExceptionRecord>
    sourceDataErrs
     =null;

   if(!operation.IsCyclic)
   {
    ErrorUtils.Add
     (ref sourceDataErrs,
      ErrorRecordCreator.DbmsErr__FB__FirebirdDoesNotSupportNonCyclicSequence
       (c_ErrSrcID,
        operation.Name));
   }//if !operation.IsCyclic

   if(operation.MinValue.HasValue)
   {
    if(operation.MinValue.Value!=FIREBIRD_SEQUENCE_DATATYPE.MinValue)
    {
     ErrorUtils.Add
      (ref sourceDataErrs,
       ErrorRecordCreator.DbmsErr__FB__FirebirdDoesNotSupportConfigurationBoundValueOfSequence
        (c_ErrSrcID,
         nameof(operation.MinValue),
         operation.Name,
         FIREBIRD_SEQUENCE_DATATYPE.MinValue));
    }//if
   }//if operation.MinValue.HasValue

   if(operation.MaxValue.HasValue)
   {
    if(operation.MaxValue.Value!=FIREBIRD_SEQUENCE_DATATYPE.MaxValue)
    {
     ErrorUtils.Add
      (ref sourceDataErrs,
       ErrorRecordCreator.DbmsErr__FB__FirebirdDoesNotSupportConfigurationBoundValueOfSequence
        (c_ErrSrcID,
         nameof(operation.MaxValue),
         operation.Name,
         FIREBIRD_SEQUENCE_DATATYPE.MaxValue));
    }//if
   }//if operation.MaxValue.HasValue

   ErrorUtils.ThrowIfNotEmpty
    (sourceDataErrs);
  }//local

  //---------------------------------------- Generation

  //! \todo
  //!  What we should do with operation.OldSequence data?

  //! \todo
  //!  May be we can compare old/new IncrementBy and do not generate SQL if they are identical?

  builder.Append("ALTER SEQUENCE ");
  builder.Append(dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Name, operation.Schema));
  builder.Append(" INCREMENT BY ");
  builder.Append(operation.IncrementBy.ToString(CultureInfo.InvariantCulture));
 }//GenerateAlterSequence
};//interface FB_V03_0_0__MigrationsSvcImpl__GenerateAlterSequence

////////////////////////////////////////////////////////////////////////////////
}//Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Migrations.D3.Internal.SvcImpls

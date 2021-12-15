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
//class FB_V03_0_0__MigrationsSvcImpl__GenerateCreateSequence

sealed class FB_V03_0_0__MigrationsSvcImpl__GenerateCreateSequence
 :Svcs.FB_V03_0_0__MigrationsSvc__GenerateCreateSequence
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Basement_EF_Dbms_Firebird_V03_0_0_Migrations_D3_Internal_SvcImpls___FB_V03_0_0__MigrationsSvcImpl__GenerateCreateSequence;

 //-----------------------------------------------------------------------
 public static readonly Svcs.FB_V03_0_0__MigrationsSvc__GenerateCreateSequence
  Instance
   =new FB_V03_0_0__MigrationsSvcImpl__GenerateCreateSequence();

 //-----------------------------------------------------------------------
 private FB_V03_0_0__MigrationsSvcImpl__GenerateCreateSequence()
 {
 }

 //interface -------------------------------------------------------------
 public void GenerateCreateSequence
              (in MigrationsSqlGeneratorDependencies dependencies,
               CreateSequenceOperation               operation,
               IModel                                model,
               MigrationCommandListBuilder           builder)
 {
  Debug.Assert(!Object.ReferenceEquals(operation,null));
  Debug.Assert( Object.ReferenceEquals(operation.Schema,null));
  Debug.Assert(!Object.ReferenceEquals(operation.Name,null));
  Debug.Assert(!Object.ReferenceEquals(operation.ClrType,null));
  Debug.Assert(!Object.ReferenceEquals(builder,null));

  Debug.Assert(operation.Name.Length>0);

  //---------------------------------------- Base verification
  {
   List<Core.Core_ExceptionRecord>
    sourceDataErrs
     =null;

   if(operation.ClrType!=typeof(FIREBIRD_SEQUENCE_DATATYPE))
   {
    ErrorUtils.Add
     (ref sourceDataErrs,
      ErrorRecordCreator.MSqlGenErr__UnexpectedClrTypeOfSequence
       (c_ErrSrcID,
        operation,
        typeof(FIREBIRD_SEQUENCE_DATATYPE)));
   }//if operation.ClrType!=typeof(FIREBIRD_SEQUENCE_DATATYPE)

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

  //
  // [2021-11-05]
  //
  // Firebird up to V3 incorrect implements support of sequence.
  //
  // Current behaviour:
  //  1. Increment current value of sequence
  //  2. Return new value
  //
  // Expected behaviour:
  //  1. Copy current value
  //  2. Increment value of sequence
  //  3. Return copied value from point 1.
  //
  // Our correction:
  //  - Controlled subtraction of IncrementBy from StartValue.
  //
  // [2021-11-07]
  //
  //  Let's leave this correction.
  //
  //  Note that, this correction can't be applyed to RESTART operation.
  //

  if(operation.StartValue>=0)
  {
   if(operation.IncrementBy>=0)
   {
    //no problem
   }
   else
   {
    Debug.Assert(operation.IncrementBy<0);

    if((FIREBIRD_SEQUENCE_DATATYPE.MaxValue+operation.IncrementBy)<operation.StartValue)
    {
     ThrowError.MSqlGenErr__OverflowInCalculationOfAdjustedSequenceStartValue
      (c_ErrSrcID,
       operation);
    }//if

    //no problem
   }//else
  }
  else
  {
   Debug.Assert(operation.StartValue<0);

   if(operation.IncrementBy<=0)
   {
    //no problem
   }
   else
   {
    Debug.Assert(operation.IncrementBy>0);

    if(operation.StartValue<(FIREBIRD_SEQUENCE_DATATYPE.MinValue+operation.IncrementBy))
    {
     ThrowError.MSqlGenErr__OverflowInCalculationOfAdjustedSequenceStartValue
      (c_ErrSrcID,
       operation);
    }//if

    //no problem
   }//else
  }//else

  var correctedStartValue
   =operation.StartValue-operation.IncrementBy;

  //----------------------------------------
  builder.Append("CREATE SEQUENCE ");
  builder.Append(dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Name, operation.Schema));

  //----------------------------------------
  if(correctedStartValue!=0)
  {
   builder.Append(" START WITH ");
   builder.Append(correctedStartValue.ToString(CultureInfo.InvariantCulture));
  }//if correctedStartValue!=0

  //----------------------------------------
  if(operation.IncrementBy!=1)
  {
   builder.Append(" INCREMENT BY ");
   builder.Append(operation.IncrementBy.ToString(CultureInfo.InvariantCulture));
  }//if
 }//GenerateCreateSequence
};//interface FB_V03_0_0__MigrationsSvcImpl__GenerateCreateSequence

////////////////////////////////////////////////////////////////////////////////
}//Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Migrations.D3.Internal.SvcImpls

////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 25.04.2021.
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Migrations{
////////////////////////////////////////////////////////////////////////////////

using LcpiOleDb__AnnotationNames
 =DataProvider.LcpiOleDb.MetaData.Internal.LcpiOleDb__AnnotationNames;

////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0__MigrationsSqlGenerator

sealed partial class FB_V03_0_0__MigrationsSqlGenerator:MigrationsSqlGenerator
{
 //MigrationsSqlGenerator interface --------------------------------------
 protected override void ColumnDefinition(string                      schema,
                                          string                      table,
                                          string                      name,
                                          ColumnOperation             operation,
                                          IModel                      model,
                                          MigrationCommandListBuilder builder)
 {
  Check.Arg_NotNullAndNotEmpty
   (c_ErrSrcID,
    nameof(ColumnDefinition),
    nameof(table),
    table);

  Check.Arg_NotNullAndNotEmpty
   (c_ErrSrcID,
    nameof(ColumnDefinition),
    nameof(name),
    name);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(ColumnDefinition),
    nameof(operation),
    operation);

  //operation.ColumnType may be null;

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(ColumnDefinition),
    nameof(builder),
    builder);

  try // [catch]
  {
   if(!Object.ReferenceEquals(operation.ComputedColumnSql,null))
   {
    this.Helper__GenerateSQL_ColumnDefinition__COMPUTED
     (schema,
      table,
      name,
      operation,
      model,
      builder); //throw
   }
   else
   {
    Debug.Assert(Object.ReferenceEquals(operation.ComputedColumnSql,null));

    this.Helper__GenerateSQL_ColumnDefinition__STD
     (schema,
      table,
      name,
      operation,
      model,
      builder); //throw
   }//else
  }
  catch(Exception e)
  {
   var exc
    =new LcpiOleDb__DataToolException
      (e);

   exc.add_error
    (lcpi.lib.com.HResultCode.E_FAIL,
     c_ErrSrcID,
     ErrMessageID.msql_gen_err__failed_to_generate_column_definition__2);

   exc
    .push(operation.Table)
    .push(operation.Name)
    .raise();
  }//catch
 }//ColumnDefinition

 //Helper methods --------------------------------------------------------
 private void Helper__GenerateSQL_ColumnDefinition__STD
                                           (string                      schema,
                                            string                      table,
                                            string                      name,
                                            ColumnOperation             operation,
                                            IModel                      model,
                                            MigrationCommandListBuilder builder)
 {
  Debug.Assert(!Object.ReferenceEquals(table,null));
  Debug.Assert(!Object.ReferenceEquals(name,null));
  Debug.Assert(!Object.ReferenceEquals(operation,null));
  Debug.Assert(!Object.ReferenceEquals(builder,null));

  Debug.Assert(Object.ReferenceEquals(operation.ComputedColumnSql,null));

  //-----------------------------------------------------------
  tagColumnAnnotations
   columnAnnotations
    =Helper__GetColumnAnnotations
      (operation);

  //---------------------------------------
  var columnTypeMapping
   =Helper__GetColumnTypeMapping
     (schema,
      table,
      name,
      operation,
      model);

  Debug.Assert(!Object.ReferenceEquals(columnTypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(columnTypeMapping.StoreType,null));

  //---------------------------------------
  builder.Append(this.Dependencies.SqlGenerationHelper.DelimitIdentifier(name));

  builder.Append(" ");

  builder.Append(columnTypeMapping.StoreType);

  if(columnAnnotations.ValueGenerationStrategy.IsNull)
  {
   //Nope
  }
  else
  if(columnAnnotations.ValueGenerationStrategy.Value is MetaData.LcpiOleDb__AnnotationData__ValueGenerationStrategy_None)
  {
   //Nope
  }
  else
  if(columnAnnotations.ValueGenerationStrategy.Value is MetaData.LcpiOleDb__AnnotationData__ValueGenerationStrategy_SequenceTrigger)
  {
   // Generation of identity value in trigger

   Helper__CheckColumnForSequenceTrigger
    (operation,
     columnTypeMapping); //throw

   // Will process this strategy later.
  }
  else
  if(columnAnnotations.ValueGenerationStrategy.Value is MetaData.LcpiOleDb__AnnotationData__ValueGenerationStrategy_IdentityByDefaultColumn)
  {
   // "GENERATED BY DEFAULT AS IDENTITY"

   Helper__CheckColumnForIdentity
    (operation,
     columnTypeMapping); //throw

   builder.Append(" GENERATED BY DEFAULT AS IDENTITY");
  }
  else
  {
   Debug.Assert(!columnAnnotations.ValueGenerationStrategy.IsNull);
   Debug.Assert(!Object.ReferenceEquals(columnAnnotations.ValueGenerationStrategy.Value,null));

   ThrowError.AnnotationHasValueWithUnexpectedType
    (c_ErrSrcID,
     LcpiOleDb__AnnotationNames.ValueGenerationStrategy,
     columnAnnotations.ValueGenerationStrategy.Value.GetType());
  }//else

  this.DefaultValue
   (operation.DefaultValue,
    operation.DefaultValueSql,
    operation.ColumnType,
    builder);

  if(!operation.IsNullable)
  {
   builder.Append(" NOT NULL");
  }//if
 }//Helper__GenerateSQL_ColumnDefinition__STD

 //-----------------------------------------------------------------------
 private void Helper__GenerateSQL_ColumnDefinition__COMPUTED
                                           (string                      schema,
                                            string                      table,
                                            string                      name,
                                            ColumnOperation             operation,
                                            IModel                      model,
                                            MigrationCommandListBuilder builder)
 {
  Debug.Assert(!Object.ReferenceEquals(table,null));
  Debug.Assert(!Object.ReferenceEquals(name,null));
  Debug.Assert(!Object.ReferenceEquals(operation,null));
  Debug.Assert(!Object.ReferenceEquals(builder,null));

  Debug.Assert(!Object.ReferenceEquals(operation.ComputedColumnSql,null));

  //-------------------------------------------------------
  ThrowError.MSqlGenErr__ComputedColumnNotSupported
   (c_ErrSrcID);
 }//Helper__GenerateSQL_ColumnDefinition__COMPUTED

 //-----------------------------------------------------------------------
 private RelationalTypeMapping Helper__GetColumnTypeMapping
                                           (string          schema,
                                            string          tableName,
                                            string          name,
                                            ColumnOperation operation,
                                            IModel          model)
 {
  var typeMapping
   =Helper__FindColumnTypeMapping
     (schema,
      tableName,
      name,
      operation,
      model); //throw

  if(Object.ReferenceEquals(typeMapping,null))
  {
   //ERROR - can't find typeMapping of column

   ThrowError.MSqlGenErr__CantFindTypeMappingForColumn
    (c_ErrSrcID,
     tableName,
     name);
  }//if

  Debug.Assert(!Object.ReferenceEquals(typeMapping,null));

  return typeMapping;
 }//Helper__GetColumnTypeMapping

 //-----------------------------------------------------------------------
 private RelationalTypeMapping Helper__FindColumnTypeMapping
                                           (string          schema,
                                            string          tableName,
                                            string          name,
                                            ColumnOperation operation,
                                            IModel          model)
 {
  Debug.Assert(!Object.ReferenceEquals(tableName,null));
  Debug.Assert(!Object.ReferenceEquals(name,null));
  Debug.Assert(!Object.ReferenceEquals(operation,null));

  Debug.Assert(tableName.Length>0);
  Debug.Assert(name.Length>0);

  //-------------------------------------------------------
  var keyOrIndex
   =false;

  var table
   =model?.GetRelationalModel().FindTable(tableName, schema);

  var column
   =table?.FindColumn(name);

  if(!Object.ReferenceEquals(column,null))
  {
   keyOrIndex
    =Helper__IsKeyOrIndex
      (table,
       column);

   if(Helper__IsEqual(operation,column))
   {
    return Dependencies.TypeMappingSource.FindMapping
            (/*clrType*/null,
             column.StoreType,
             keyOrIndex,
             column.IsUnicode,
             column.MaxLength,
             column.IsRowVersion,
             column.IsFixedLength,
             column.Precision,
             column.Scale);  //throw
   }//if
  }//if

  return Dependencies.TypeMappingSource.FindMapping
          (operation.ClrType,
           operation.ColumnType,
           keyOrIndex,
           operation.IsUnicode,
           operation.MaxLength,
           operation.IsRowVersion,
           operation.IsFixedLength,
           operation.Precision,
           operation.Scale); //throw
 }//Helper__GetColumnTypeMapping

 //-----------------------------------------------------------------------
 private static bool Helper__IsEqual(ColumnOperation operation,
                                     IColumn         column)
 {
  Debug.Assert(!Object.ReferenceEquals(operation,null));
  Debug.Assert(!Object.ReferenceEquals(column,null));

  if(operation.IsUnicode!=column.IsUnicode)
   return false;

  if(operation.MaxLength!=column.MaxLength)
   return false;

  if(operation.Precision!=column.Precision)
   return false;

  if(operation.Scale!=column.Scale)
   return false;

  if(operation.IsFixedLength!=column.IsFixedLength)
   return false;

  if(operation.IsRowVersion!=column.IsRowVersion)
   return false;

  return true;
 }//Helper__IsEqual

 //-----------------------------------------------------------------------
 private static bool Helper__IsKeyOrIndex(ITable  table,
                                          IColumn column)
 {
  Debug.Assert(!Object.ReferenceEquals(table,null));
  Debug.Assert(!Object.ReferenceEquals(column,null));

  if(table.UniqueConstraints.Any(u=>u.Columns.Contains(column)))
   return true;

  if(table.ForeignKeyConstraints.Any(u=>u.Columns.Contains(column)))
   return true;

  if(table.Indexes.Any(u=>u.Columns.Contains(column)))
   return true;

  return false;
 }//Helper__IsKeyOrIndex

 //-----------------------------------------------------------------------
 private static void Helper__CheckColumnForIdentity
                        (ColumnOperation       columnOperation,
                         RelationalTypeMapping columnTypeMapping)
 {
  Debug.Assert(!Object.ReferenceEquals(columnOperation,null));
  Debug.Assert(!Object.ReferenceEquals(columnTypeMapping,null));

  // Voice the whole (error) list, please ...

  List<Core.Core_ExceptionRecord>
   errRecs
    =null;

  //------------------------------------------------------------
  if(!Helper__ColumnDataTypeAllowsDefinitionOfIdentity(columnTypeMapping))
  {
   //ERROR - Can't define IDENTITY for column with this data type.

   ErrorUtils.Add
    (ref errRecs,
     ErrorRecordCreator.MSqlGenErr__IdentityColumnCantBeCreatedWithRequiredDataType
      (c_ErrSrcID,
       columnTypeMapping.ClrType,
       columnTypeMapping.StoreType));
  }//if

  //----------------------------------------
  if(Helper__HasDefinitionOfDefaultValue(columnOperation))
  {
   ErrorUtils.Add
    (ref errRecs,
     ErrorRecordCreator.MSqlGenErr__IdentityColumnCantHasDefaultValue
      (c_ErrSrcID));
  }//if

  //----------------------------------------
  if(columnOperation.IsNullable)
  {
   ErrorUtils.Add
    (ref errRecs,
     ErrorRecordCreator.MSqlGenErr__IdentityColumnCantBeNullable
      (c_ErrSrcID));
  }//if

  //------------------------------------------------------------
  ErrorUtils.ThrowIfNotEmpty
   (errRecs);
 }//Helper__CheckColumnForIdentity

 //-----------------------------------------------------------------------
 private static void Helper__CheckColumnForSequenceTrigger
                        (ColumnOperation       columnOperation,
                         RelationalTypeMapping columnTypeMapping)
 {
  Debug.Assert(!Object.ReferenceEquals(columnOperation,null));
  Debug.Assert(!Object.ReferenceEquals(columnTypeMapping,null));

  Helper__CheckColumnForIdentity
   (columnOperation,
    columnTypeMapping);
 }//Helper__CheckColumnForSequenceTrigger

 //-----------------------------------------------------------------------
 private static bool Helper__ColumnDataTypeAllowsDefinitionOfIdentity
                        (RelationalTypeMapping typeMapping)
 {
  Debug.Assert(!Object.ReferenceEquals(typeMapping,null));

  //------------------------------------------------------------
  if(typeMapping is Common.Storage.FB_Common__ITypeMapping__IsCompatiblyWithIdentity x)
  {
   if(x.IsCompatiblyWithIdentity())
    return true;

   return false;
  }//if

  return false;
 }//Helper__ColumnDataTypeAllowsDefinitionOfIdentity
};//class FB_V03_0_0__MigrationsSqlGenerator

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Migrations

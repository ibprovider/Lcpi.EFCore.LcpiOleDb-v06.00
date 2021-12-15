////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 22.05.2018.
using System;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Update;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Update{
////////////////////////////////////////////////////////////////////////////////
//class FB_Common__UpdateSqlGenerator

//
// NOTE THAT. Here INSERT/UPDATE/DELETE do not check RowsAffected.
//

sealed class FB_Common__UpdateSqlGenerator:IUpdateSqlGenerator
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__UpdateSqlGenerator;

 //-----------------------------------------------------------------------
 public FB_Common__UpdateSqlGenerator(UpdateSqlGeneratorDependencies dependencies)
 {
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__UpdateSqlGenerator::FB_Common__UpdateSqlGenerator(...)");
#endif

  m_Dependencies=dependencies;
 }//FB_Common__UpdateSqlGenerator

 //-----------------------------------------------------------------------
 string IUpdateSqlGenerator.GenerateNextSequenceValueOperation
                                           (string name,
                                            string schema)
 {
#if TRACE
  Core.Core_Trace.Method_Enter
   ("FB_Common__UpdateSqlGenerator::GenerateNextSequenceValueOperation(...)");
#endif

  //----------------------------------------------------------------------
  ThrowSysError.method_not_impl
   (c_ErrSrcID,
    nameof(IUpdateSqlGenerator.GenerateNextSequenceValueOperation));

  return null;
 }//GenerateNextSequenceValueOperation

 //-----------------------------------------------------------------------
 void IUpdateSqlGenerator.AppendNextSequenceValueOperation
                                           (StringBuilder commandStringBuilder,
                                            string        name,
                                            string        schema)
 {
#if TRACE
  Core.Core_Trace.Method_Enter
   ("FB_Common__UpdateSqlGenerator::AppendNextSequenceValueOperation(...)");
#endif

  //----------------------------------------------------------------------
  ThrowSysError.method_not_impl
   (c_ErrSrcID,
    nameof(IUpdateSqlGenerator.AppendNextSequenceValueOperation));
 }//AppendNextSequenceValueOperation

 //-----------------------------------------------------------------------
 void IUpdateSqlGenerator.AppendBatchHeader(StringBuilder commandStringBuilder)
 {
 }//AppendBatchHeader

 //-----------------------------------------------------------------------
 ResultSetMapping IUpdateSqlGenerator.AppendInsertOperation
                                           (StringBuilder                commandStringBuilder,
                                            IReadOnlyModificationCommand command,
                                            int                          commandPosition)
 {
#if TRACE
  Core.Core_Trace.Method_Enter
   ("FB_Common__UpdateSqlGenerator::AppendInsertOperation(...)");
#endif

  //----------------------------------------------------------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(IUpdateSqlGenerator.AppendInsertOperation),
    nameof(commandStringBuilder),
    commandStringBuilder);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(IUpdateSqlGenerator.AppendInsertOperation),
    nameof(command),
    command);

  Check.Arg_NotNullAndNotEmpty
   (c_ErrSrcID,
    nameof(IUpdateSqlGenerator.AppendUpdateOperation),
    "command.ColumnModifications",
    command.ColumnModifications);

  Check.Arg_NotNullAndNotEmpty
   (c_ErrSrcID,
    nameof(IUpdateSqlGenerator.AppendUpdateOperation),
    "command.TableName",
    command.TableName);

  //----------------------------------------------------------------------
  Debug.Assert(!Object.ReferenceEquals(commandStringBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(command,null));
  Debug.Assert(!Object.ReferenceEquals(command.ColumnModifications,null));
  Debug.Assert(!Object.ReferenceEquals(command.TableName,null));
  Debug.Assert(command.TableName.Length>0);

  //----------------------------------------------------------------------
#if TRACE
  Core.Core_Trace.Send
   ("tableName : {0}",command.TableName);

  Core.Core_Trace.Send
   ("schemaName: {0}",command.Schema);
#endif

  //----------------------------------------------------------------------
  var operations       = command.ColumnModifications;

  // NOTE: we do not check that o!=null !

  var writeOperations  = operations.Where(o => o.IsWrite).ToList();
  var readOperations   = operations.Where(o => o.IsRead).ToList();

  this.Helper__AppendInsertCommandHeader
   (commandStringBuilder,
    command.TableName,
    command.Schema,
    writeOperations);

  this.Helper__AppendValuesHeader
   (commandStringBuilder,
    writeOperations);

  this.Helper__AppendValues
   (commandStringBuilder,
    command.TableName,
    command.Schema,
    writeOperations);

  this.Helper__AppendReturningInto
   (commandStringBuilder,
    readOperations);

  commandStringBuilder
   .Append(m_Dependencies.SqlGenerationHelper.StatementTerminator)
   .AppendLine();

  //----------------------------------------------------------------------
#if TRACE
  Core.Core_Trace.Method_Exit
   ("FB_Common__UpdateSqlGenerator::AppendInsertOperation(...)");
#endif

  //! \attention
  //!  RESEARCH: ALWAYS CHECK AFFECTED ROWS COUNT.

  //if(readOperations.Count>0)
   return ResultSetMapping.LastInResultSet;

  //return ResultSetMapping.NoResultSet;
 }//AppendInsertOperation

 //-----------------------------------------------------------------------
 ResultSetMapping IUpdateSqlGenerator.AppendUpdateOperation
                                           (StringBuilder                commandStringBuilder,
                                            IReadOnlyModificationCommand command,
                                            int                          commandPosition)
 {
#if TRACE
  Core.Core_Trace.Method_Enter
   ("FB_Common__UpdateSqlGenerator::AppendUpdateOperation(...)");
#endif

  //----------------------------------------------------------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(IUpdateSqlGenerator.AppendUpdateOperation),
    nameof(commandStringBuilder),
    commandStringBuilder);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(IUpdateSqlGenerator.AppendUpdateOperation),
    nameof(command),
    command);

  Check.Arg_NotNullAndNotEmpty
   (c_ErrSrcID,
    nameof(IUpdateSqlGenerator.AppendUpdateOperation),
    "command.ColumnModifications",
    command.ColumnModifications);

  Check.Arg_NotNullAndNotEmpty
   (c_ErrSrcID,
    nameof(IUpdateSqlGenerator.AppendUpdateOperation),
    "command.TableName",
    command.TableName);

  //----------------------------------------------------------------------
  Debug.Assert(!Object.ReferenceEquals(commandStringBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(command,null));
  Debug.Assert(!Object.ReferenceEquals(command.ColumnModifications,null));
  Debug.Assert(!Object.ReferenceEquals(command.TableName,null));
  Debug.Assert(command.TableName.Length>0);

  //----------------------------------------------------------------------
  var operations          = command.ColumnModifications;

  // NOTE: we do not check that o!=null !

  var writeOperations     = operations.Where(o=>o.IsWrite).ToList();
  var conditionOperations = operations.Where(o=>o.IsCondition).ToList();
  var readOperations      = operations.Where(o=>o.IsRead).ToList();

  this.Helper__AppendUpdateCommandHeader
   (commandStringBuilder,
    command.TableName,
    command.Schema,
    writeOperations);

  this.Helper__AppendWhereClause
   (commandStringBuilder,
    command.TableName,
    command.Schema,
    conditionOperations);

  this.Helper__AppendReturningInto
   (commandStringBuilder,
    readOperations);

  commandStringBuilder
   .Append(m_Dependencies.SqlGenerationHelper.StatementTerminator)
   .AppendLine();

  //----------------------------------------------------------------------
#if TRACE
  Core.Core_Trace.Method_Exit
   ("FB_Common__UpdateSqlGenerator::AppendUpdateOperation(...)");
#endif

  //! \attention
  //!  RESEARCH: ALWAYS CHECK AFFECTED ROWS COUNT.

  //if(readOperations.Count>0)
   return ResultSetMapping.LastInResultSet;

  //return ResultSetMapping.NoResultSet;
 }//AppendUpdateOperation

 //-----------------------------------------------------------------------
 ResultSetMapping IUpdateSqlGenerator.AppendDeleteOperation
                                           (StringBuilder                commandStringBuilder,
                                            IReadOnlyModificationCommand command,
                                            int                          commandPosition)
 {
#if TRACE
  Core.Core_Trace.Method_Enter
   ("FB_Common__UpdateSqlGenerator::AppendDeleteOperation(...)");
#endif

  //----------------------------------------------------------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(IUpdateSqlGenerator.AppendDeleteOperation),
    nameof(commandStringBuilder),
    commandStringBuilder);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(IUpdateSqlGenerator.AppendDeleteOperation),
    nameof(command),
    command);

  Check.Arg_NotNullAndNotEmpty
   (c_ErrSrcID,
    nameof(IUpdateSqlGenerator.AppendDeleteOperation),
    "command.ColumnModifications",
    command.ColumnModifications);

  Check.Arg_NotNullAndNotEmpty
   (c_ErrSrcID,
    nameof(IUpdateSqlGenerator.AppendDeleteOperation),
    "command.TableName",
    command.TableName);

  //----------------------------------------------------------------------
  Debug.Assert(!Object.ReferenceEquals(commandStringBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(command,null));
  Debug.Assert(!Object.ReferenceEquals(command.ColumnModifications,null));
  Debug.Assert(!Object.ReferenceEquals(command.TableName,null));
  Debug.Assert(command.TableName.Length>0);

  //----------------------------------------------------------------------
  var operations          = command.ColumnModifications;

  // NOTE: we do not check that o!=null !

  var conditionOperations = operations.Where(o=>o.IsCondition).ToList();
  var readOperations      = operations.Where(o=>o.IsRead).ToList();

  this.Helper__AppendDeleteCommandHeader
   (commandStringBuilder,
    command.TableName,
    command.Schema);

  this.Helper__AppendWhereClause
   (commandStringBuilder,
    command.TableName,
    command.Schema,
    conditionOperations);

  this.Helper__AppendReturningInto
   (commandStringBuilder,
    readOperations);

  commandStringBuilder
   .Append(m_Dependencies.SqlGenerationHelper.StatementTerminator)
   .AppendLine();

  //----------------------------------------------------------------------
#if TRACE
  Core.Core_Trace.Method_Exit
   ("FB_Common__UpdateSqlGenerator::AppendDeleteOperation(...)");
#endif

  //! \attention
  //!  RESEARCH: ALWAYS CHECK AFFECTED ROWS COUNT.

  //if(readOperations.Count>0)
   return ResultSetMapping.LastInResultSet;

  //return ResultSetMapping.NoResultSet;
 }//AppendDeleteOperation

 //Helper methods --------------------------------------------------------
 private void Helper__AppendInsertCommandHeader
                            (StringBuilder                      commandStringBuilder,
                             string                             name,
                             string                             schema,
                             IReadOnlyList<IColumnModification> operations)
 {
  Debug.Assert(!Object.ReferenceEquals(commandStringBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(name,null));
  Debug.Assert(!Object.ReferenceEquals(operations,null));
  Debug.Assert(name.Length>0);

  //--------------------------------------------------
  commandStringBuilder.Append("INSERT INTO ");

  m_Dependencies.SqlGenerationHelper.DelimitIdentifier
   (commandStringBuilder,
    name,
    schema);

  if(operations.Count==0)
   return;

  commandStringBuilder
   .Append(" (");

  var sep="";

  foreach(var op in operations)
  {
   Debug.Assert(!Object.ReferenceEquals(op,null));

   commandStringBuilder.Append
    (sep);

   m_Dependencies.SqlGenerationHelper.DelimitIdentifier
    (commandStringBuilder,
     op.ColumnName);

   sep=", ";
  }//foreach op

  commandStringBuilder
   .Append(")");
 }//Helper__AppendInsertCommandHeader

 //-----------------------------------------------------------------------
 private void Helper__AppendValuesHeader(StringBuilder                      commandStringBuilder,
                                         IReadOnlyList<IColumnModification> operations)
 {
  Debug.Assert(!Object.ReferenceEquals(commandStringBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(operations,null));

  //--------------------------------------------------
  commandStringBuilder.AppendLine();

  if(operations.Count>0)
  {
   commandStringBuilder.Append("VALUES ");
  }
  else
  {
   commandStringBuilder.Append("DEFAULT VALUES");
  }//else
 }//Helper__AppendValuesHeader

 //-----------------------------------------------------------------------
 private void Helper__AppendValues(StringBuilder                      commandStringBuilder,
                                   string                             name,
                                   string                             schema,
                                   IReadOnlyList<IColumnModification> operations)
 {
  Debug.Assert(!Object.ReferenceEquals(commandStringBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(name,null));
  Debug.Assert(!Object.ReferenceEquals(operations,null));
  Debug.Assert(name.Length>0);

  //--------------------------------------------------
  if(operations.Count==0)
   return;

  commandStringBuilder
   .Append('(');

  var sep="";

  foreach(var op in operations)
  {
   Debug.Assert(!Object.ReferenceEquals(op,null));

   commandStringBuilder.Append
    (sep);

   if(op.IsWrite)
   {
    if(!op.UseCurrentValueParameter)
    {
     Helper__AppendCurrentValueAsSqlLiteral
      (commandStringBuilder,
       op,
       name,
       schema);
    }
    else
    {
     m_Dependencies.SqlGenerationHelper.GenerateParameterNamePlaceholder
      (commandStringBuilder,
       op.ParameterName);
    }
   }
   else
   {
    commandStringBuilder.Append("DEFAULT");
   }//else

   sep=", ";
  }//for op

  commandStringBuilder
   .Append(')');
 }//Helper__AppendValues

 //-----------------------------------------------------------------------
 private void Helper__AppendReturningInto(StringBuilder              commandStringBuilder,
                                         IList<IColumnModification> readOperations)
 {
  Debug.Assert(!Object.ReferenceEquals(commandStringBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(readOperations,null));

  if(readOperations.Count==0)
   return;

  commandStringBuilder.AppendLine();
  commandStringBuilder.Append("RETURNING ");

  string sep=string.Empty;

  Debug.Assert(!Object.ReferenceEquals(sep,null));
  Debug.Assert(sep.Length==0);

  foreach(var op in readOperations)
  {
   commandStringBuilder.Append(sep);

   sep=",";

   m_Dependencies.SqlGenerationHelper.DelimitIdentifier
    (commandStringBuilder,
     op.ColumnName);
  }//foreach op

  commandStringBuilder.AppendLine();
  commandStringBuilder.Append("INTO ");

  sep=string.Empty;

  Debug.Assert(!Object.ReferenceEquals(sep,null));
  Debug.Assert(sep.Length==0);

  foreach(var e in readOperations)
  {
   commandStringBuilder.Append(sep);

   sep=",";

   m_Dependencies.SqlGenerationHelper.GenerateParameterNamePlaceholder
    (commandStringBuilder,
     e.ParameterName);
  }//foreach e
 }//Helper__AppendReturningInto

 //-----------------------------------------------------------------------
 private void Helper__AppendUpdateCommandHeader
                            (StringBuilder                      commandStringBuilder,
                             string                             name,
                             string                             schema,
                             IReadOnlyList<IColumnModification> operations)
  {
  Debug.Assert(!Object.ReferenceEquals(commandStringBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(name,null));
  Debug.Assert(!Object.ReferenceEquals(operations,null));
  Debug.Assert(name.Length>0);

  //--------------------------------------------------
  commandStringBuilder.Append("UPDATE ");

  m_Dependencies.SqlGenerationHelper.DelimitIdentifier
   (commandStringBuilder,
    name,
    schema);

  commandStringBuilder.Append(" SET ");

  var sep="";

  foreach(var op in operations)
  {
   Debug.Assert(!Object.ReferenceEquals(op,null));

   commandStringBuilder.Append
    (sep);

   m_Dependencies.SqlGenerationHelper.DelimitIdentifier
    (commandStringBuilder,
     op.ColumnName);

   commandStringBuilder.Append(" = ");

   if(!op.UseCurrentValueParameter)
   {
    Helper__AppendCurrentValueAsSqlLiteral
     (commandStringBuilder,
      op,
      name,
      schema);
   }
   else
   {
    m_Dependencies.SqlGenerationHelper.GenerateParameterNamePlaceholder
     (commandStringBuilder,
      op.ParameterName);
   }//else

   sep=", ";
  }//for op
 }//Helper__AppendUpdateCommandHeader

 //-----------------------------------------------------------------------
 private void Helper__AppendDeleteCommandHeader
                            (StringBuilder commandStringBuilder,
                             string        name,
                             string        schema)
 {
  Debug.Assert(!Object.ReferenceEquals(commandStringBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(name,null));
  Debug.Assert(name.Length>0);

  //--------------------------------------------------
  commandStringBuilder.Append("DELETE FROM ");

  m_Dependencies.SqlGenerationHelper.DelimitIdentifier
   (commandStringBuilder,
    name,
    schema);
 }//Helper__AppendDeleteCommandHeader

 //-----------------------------------------------------------------------
 private void Helper__AppendWhereClause
                            (StringBuilder                      commandStringBuilder,
                             string                             tableName,
                             string                             schemaName,
                             IReadOnlyList<IColumnModification> operations)
 {
  Debug.Assert(!Object.ReferenceEquals(commandStringBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(operations,null));

  //--------------------------------------------------
  if(operations.Count==0)
   return;

  Debug.Assert(operations.Count>0);

  commandStringBuilder
   .AppendLine()
   .Append("WHERE ");

  if(operations.Count==1)
  {
   Helper__AppendWhereCondition
    (commandStringBuilder,
     tableName,
     schemaName,
     operations[0]);
  }
  else
  {
   //
   // [2021-12-01]
   //
   //  Put each condition into brackets for protection from UFO in FB code.
   //

   Debug.Assert(operations.Count>1);

   string sep=null;

   foreach(var op in operations)
   {
    Debug.Assert(!Object.ReferenceEquals(op,null));

    commandStringBuilder
     .Append(sep);

    commandStringBuilder
     .Append('(');

    Helper__AppendWhereCondition
     (commandStringBuilder,
      tableName,
      schemaName,
      op);

    commandStringBuilder
     .Append(')');

    sep=" AND ";
   }//else
  }//foreach op
 }//Helper__AppendWhereClause

 //-----------------------------------------------------------------------
 private void Helper__AppendWhereCondition(StringBuilder       commandStringBuilder,
                                           string              tableName,
                                           string              schemaName,
                                           IColumnModification columnModification)
 {
  Helper__AppendWhereCondition
   (commandStringBuilder,
    tableName,
    schemaName,
    columnModification,
    columnModification.UseOriginalValueParameter);
 }//Helper__AppendWhereCondition

 //-----------------------------------------------------------------------
 private void Helper__AppendWhereCondition(StringBuilder       commandStringBuilder,
                                           string              tableName,
                                           string              schemaName,
                                           IColumnModification columnModification,
                                           bool                useOriginalValue)
 {
  Debug.Assert(!Object.ReferenceEquals(commandStringBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(columnModification,null));

  //--------------------------------------------------
  //
  // [2021-11-30] The original logic of EF Core.
  //
  // Note that, useOriginalValue equal to columnModification.UseOriginalValueParameter
  //

  Debug.Assert(useOriginalValue==columnModification.UseOriginalValueParameter);

  //--------------------------------------------------
  m_Dependencies.SqlGenerationHelper.DelimitIdentifier
   (commandStringBuilder,
    columnModification.ColumnName);

  var parameterValue
   =useOriginalValue
     ?columnModification.OriginalValue
     :columnModification.Value;

  if(Object.ReferenceEquals(parameterValue,null))
  {
   commandStringBuilder.Append(" IS NULL");
  }
  else
  {
   Debug.Assert(!Object.ReferenceEquals(parameterValue,null));

   //Expected
   Debug.Assert(!DBNull.Value.Equals(parameterValue));

   commandStringBuilder.Append(" = ");

   if(!columnModification.UseParameter)
   {
    //
    // [2021-12-01] We are test the columnModification.Value!
    //
    Debug.Assert(!useOriginalValue);

    Helper__AppendCurrentValueAsSqlLiteral
     (commandStringBuilder,
      columnModification,
      tableName,
      schemaName);
   }
   else
   {
    m_Dependencies.SqlGenerationHelper.GenerateParameterNamePlaceholder
     (commandStringBuilder,
      useOriginalValue
       ?columnModification.OriginalParameterName
       :columnModification.ParameterName!);
   }//else
  }//else
 }//Helper__AppendWhereCondition

 //-----------------------------------------------------------------------
 private void Helper__AppendCurrentValueAsSqlLiteral
                            (StringBuilder       commandStringBuilder,
                             IColumnModification modification,
                             string              tableName,
                             string              schema)
 {
  Debug.Assert(!Object.ReferenceEquals(commandStringBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(modification,null));

  if(Object.ReferenceEquals(modification.TypeMapping,null))
  {
   ThrowError.TypeMappingErr__UnknownStoreTypeName
    (c_ErrSrcID,
     modification.ColumnType,
     modification.ColumnName,
     tableName,
     schema);
  }//if

  Debug.Assert(!Object.ReferenceEquals(modification.TypeMapping,null));

  var valueAsSqlLiteral
   =modification.TypeMapping.GenerateProviderValueSqlLiteral
     (modification.Value);

  Debug.Assert(!Object.ReferenceEquals(valueAsSqlLiteral,null));
  Debug.Assert(valueAsSqlLiteral.Length>0);

  commandStringBuilder.Append
   (valueAsSqlLiteral);
 }//Helper__AppendCurrentValueAsSqlLiteral

 //private data ----------------------------------------------------------
 private readonly UpdateSqlGeneratorDependencies m_Dependencies;
};//class FB_Common__UpdateSqlGenerator

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Update

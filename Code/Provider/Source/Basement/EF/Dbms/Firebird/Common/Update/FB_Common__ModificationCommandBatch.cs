////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 31.05.2018.
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Update{
////////////////////////////////////////////////////////////////////////////////
//class FB_Common__ModificationCommandBatch

sealed class FB_Common__ModificationCommandBatch:SingularModificationCommandBatch
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__ModificationCommandBatch;

 //-----------------------------------------------------------------------
 public FB_Common__ModificationCommandBatch
                        (ModificationCommandBatchFactoryDependencies dependencies)
  :base(dependencies)
 {
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__ModificationCommandBatch::FB_Common__ModificationCommandBatch\n"
   +" (dependencies : {0})",
   dependencies);
#endif
 }//FB_Common__ModificationCommandBatch

 //AffectedCountModificationCommandBatch interface -----------------------

 /// <summary>
 ///  Consumes the data reader created by <see cref="ReaderModificationCommandBatch.Execute" />,
 ///  propagating values back into the <see cref="ModificationCommand" />.
 /// </summary>
 /// <param name="commandIndex"> The ordinal of the command being consumed. </param>
 /// <param name="reader"> The data reader. </param>
 /// <returns> The ordinal of the next command that must be consumed. </returns>
 protected override int ConsumeResultSetWithPropagation
                                           (int                  commandIndex,
                                            RelationalDataReader reader)
 {
  Debug.Assert(!Object.ReferenceEquals(reader,null));
  Debug.Assert(!Object.ReferenceEquals(reader.DbCommand,null));
  Debug.Assert(!Object.ReferenceEquals(reader.DbDataReader,null));
  Debug.Assert(!Object.ReferenceEquals(this.CommandResultSet,null));
  Debug.Assert(!Object.ReferenceEquals(this.ModificationCommands,null));
  Debug.Assert(!Object.ReferenceEquals(this.Dependencies,null));
  Debug.Assert(!Object.ReferenceEquals(this.Dependencies.SqlGenerationHelper,null));

  Debug.Assert(commandIndex<this.CommandResultSet.Count);
  Debug.Assert(commandIndex<this.ModificationCommands.Count);

  //----------------------------------------------------------------------
  const string c_bug_check_src
   ="FB_Common__ModificationCommandBatch::ConsumeResultSetWithPropagation";

  //----------------------------------------------------------------------
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__ModificationCommandBatch::ConsumeResultSetWithPropagation\n"
   +" (commandIndex: {0}\n"
   +"  reader      : {1})",
   commandIndex,
   reader);
#endif

  //----------------------------------------------------------------------
  var command
   =reader.DbCommand;

  Debug.Assert(!Object.ReferenceEquals(command,null));

  var commandParameters
   =command.Parameters;

  Debug.Assert(!Object.ReferenceEquals(commandParameters,null));

  //----------------------------------------------------------------------
  if(this.CommandResultSet[commandIndex]!=ResultSetMapping.LastInResultSet)
  {
   //ERROR - unexpected commandResult

   ThrowBugCheck.ModificationCommandBatch__unexpected_ResultSetMapping
    (c_ErrSrcID,
     c_bug_check_src,
     "#001",
     commandIndex,
     command.CommandText,
     this.CommandResultSet[commandIndex]);
  }//if

  Debug.Assert(this.CommandResultSet[commandIndex]==ResultSetMapping.LastInResultSet);

  //----------------------------------------------------------------------
  if(reader.DbDataReader.FieldCount!=0)
  {
   //ERROR - we expected result in output parameters

   ThrowBugCheck.ModificationCommandBatch__we_not_expected_result_set
    (c_ErrSrcID,
     c_bug_check_src,
     "#002",
     commandIndex,
     command.CommandText,
     reader.DbDataReader.FieldCount);
  }//if reader.DbDataReader.FieldCount!=0

  Debug.Assert(reader.DbDataReader.FieldCount==0);

  //----------------------------------------------------------------------
  var rowsAffected=reader.DbDataReader.RecordsAffected;

  if(rowsAffected!=1)
  {
   //Use own code for generation of exception
   this.ThrowAggregateUpdateConcurrencyException
    (/*commandIndex*/commandIndex+1,
     /*expectedRowsAffected*/1,
     rowsAffected);
  }//if

  Debug.Assert(rowsAffected==1);

  //----------------------------------------------------------------------
  var tableModification=this.ModificationCommands[commandIndex];

  Debug.Assert(tableModification.RequiresResultPropagation);

  var operations=tableModification.ColumnModifications;

#if DEBUG
  bool debug__hasReadOp=false;
#endif

  for(int iOp=0,_cOp=operations.Count;iOp!=_cOp;++iOp)
  {
   var op=operations[iOp];

   Debug.Assert(!Object.ReferenceEquals(op,null));

   if(!op.IsRead)
    continue;

#if DEBUG
   debug__hasReadOp=true;
#endif

   var cmdParam
    =commandParameters[this.Dependencies.SqlGenerationHelper.GenerateParameterName(op.ParameterName)];

   Debug.Assert(!Object.ReferenceEquals(cmdParam,null));

   switch(cmdParam.Direction)
   {
    case System.Data.ParameterDirection.Output:
    case System.Data.ParameterDirection.InputOutput:
    {
     Debug.Assert(!Object.ReferenceEquals(sm_ValueCvtCtx,null));

     Core.Core_ValueInstaller.Exec
      (sm_ValueCvtCtx,
       op,
       cmdParam.Value);

     continue;
    }//case
   }//switch cmdParam.Direction

   //ERROR - incorrect parameter direction

   ThrowBugCheck.ModificationCommandBatch__unexpected_parameter_direction
    (c_ErrSrcID,
     c_bug_check_src,
     "004",
     commandIndex,
     command.CommandText,
     op.ParameterName,
     cmdParam.Direction);

   Debug.Assert(false);
  }//for iOp

#if DEBUG
  Debug.Assert(debug__hasReadOp);
#endif

  return commandIndex+1;
 }//ConsumeResultSetWithPropagation

 //-----------------------------------------------------------------------
 /// <summary>
 ///  Consumes the data reader created by <see cref="ReaderModificationCommandBatch.ExecuteAsync" />,
 ///  propagating values back into the <see cref="ModificationCommand" />.
 /// </summary>
 /// <param name="commandIndex"> The ordinal of the command being consumed. </param>
 /// <param name="reader"> The data reader. </param>
 /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
 /// <returns>
 ///  A task that represents the asynchronous operation.
 ///  The task contains the ordinal of the next command that must be consumed.
 /// </returns>
 protected override Task<int> ConsumeResultSetWithPropagationAsync
                                           (int                  commandIndex,
                                            RelationalDataReader reader,
                                            CancellationToken    cancellationToken)
 {
  Debug.Assert(!Object.ReferenceEquals(reader,null));
  Debug.Assert(!Object.ReferenceEquals(reader.DbCommand,null));
  Debug.Assert(!Object.ReferenceEquals(reader.DbDataReader,null));
  Debug.Assert(!Object.ReferenceEquals(this.CommandResultSet,null));
  Debug.Assert(!Object.ReferenceEquals(this.ModificationCommands,null));
  Debug.Assert(!Object.ReferenceEquals(this.Dependencies,null));
  Debug.Assert(!Object.ReferenceEquals(this.Dependencies.SqlGenerationHelper,null));

  Debug.Assert(commandIndex<this.CommandResultSet.Count);
  Debug.Assert(commandIndex<this.ModificationCommands.Count);

  //----------------------------------------------------------------------
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__ModificationCommandBatch::ConsumeResultSetWithPropagationAsync\n"
   +" (commandIndex      : {0}\n"
   +"  reader            : {1},\n"
   +"  cancellationToken : {2}) - STUB",
   commandIndex,
   reader,
   cancellationToken);
#endif

  //----------------------------------------------------------------------
  return Task.Run
          (() => this.ConsumeResultSetWithPropagation(commandIndex,reader),
           cancellationToken);
 }//ConsumeResultSetWithPropagationAsync

 //-----------------------------------------------------------------------
 /// <summary>
 ///  Consumes the data reader created by <see cref="ReaderModificationCommandBatch.Execute" />
 ///  without propagating values back into the <see cref="ModificationCommand" />.
 /// </summary>
 /// <param name="commandIndex"> The ordinal of the command being consumed. </param>
 /// <param name="reader"> The data reader. </param>
 /// <returns> The ordinal of the next command that must be consumed. </returns>
 protected override int ConsumeResultSetWithoutPropagation
                                           (int                  commandIndex,
                                            RelationalDataReader reader)
 {
  Debug.Assert(!Object.ReferenceEquals(reader,null));
  Debug.Assert(!Object.ReferenceEquals(reader.DbCommand,null));
  Debug.Assert(!Object.ReferenceEquals(reader.DbDataReader,null));
  Debug.Assert(!Object.ReferenceEquals(this.CommandResultSet,null));
  Debug.Assert(!Object.ReferenceEquals(this.ModificationCommands,null));
  Debug.Assert(!Object.ReferenceEquals(this.Dependencies,null));
  Debug.Assert(!Object.ReferenceEquals(this.Dependencies.SqlGenerationHelper,null));

  Debug.Assert(commandIndex<this.CommandResultSet.Count);
  Debug.Assert(commandIndex<this.ModificationCommands.Count);

  //----------------------------------------------------------------------
  const string c_bug_check_src
   ="FB_Common__ModificationCommandBatch::ConsumeResultSetWithoutPropagation";

  //----------------------------------------------------------------------
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__ModificationCommandBatch::ConsumeResultSetWithoutPropagation\n"
   +" (commandIndex: {0}\n"
   +"  reader      : {1})",
   commandIndex,
   reader);
#endif

  //----------------------------------------------------------------------
  if(this.CommandResultSet[commandIndex]!=ResultSetMapping.LastInResultSet)
  {
   //ERROR - unexpected commandResult

   ThrowBugCheck.ModificationCommandBatch__unexpected_ResultSetMapping
    (c_ErrSrcID,
     c_bug_check_src,
     "#001",
     commandIndex,
     reader.DbCommand.CommandText,
     this.CommandResultSet[commandIndex]);
  }//if

  Debug.Assert(this.CommandResultSet[commandIndex]==ResultSetMapping.LastInResultSet);

  //----------------------------------------------------------------------
  if(reader.DbDataReader.FieldCount!=0)
  {
   //ERROR - we not expected result set

   ThrowBugCheck.ModificationCommandBatch__we_not_expected_result_set
    (c_ErrSrcID,
     c_bug_check_src,
     "#002",
     commandIndex,
     reader.DbCommand.CommandText,
     reader.DbDataReader.FieldCount);
  }//if reader.DbDataReader.FieldCount!=0

  Debug.Assert(reader.DbDataReader.FieldCount==0);

  //----------------------------------------------------------------------
  var rowsAffected=reader.DbDataReader.RecordsAffected;

  if(rowsAffected!=1)
  {
   this.ThrowAggregateUpdateConcurrencyException
    (commandIndex+1,
     1,
     rowsAffected);
  }//if

  Debug.Assert(rowsAffected==1);

  //----------------------------------------------------------------------
  var tableModification=this.ModificationCommands[commandIndex];

  Debug.Assert(!tableModification.RequiresResultPropagation);

  var operations=tableModification.ColumnModifications;

  for(int iOp=0,_cOp=operations.Count;iOp!=_cOp;++iOp)
  {
   var op=operations[iOp];

   Debug.Assert(!Object.ReferenceEquals(op,null));

   if(!op.IsRead)
    continue;

   //ERROR - [BUG CHECK] Ooopppsss... Read operation in ResultSetWithoutPropagation!

   ThrowBugCheck.ModificationCommandBatch__found_a_read_op
    (c_ErrSrcID,
     c_bug_check_src,
     "#003",
     commandIndex,
     reader.DbCommand.CommandText,
     op.Property.DeclaringType.Name,
     op.Property.Name);

   Debug.Assert(false);
  }//for iOp

  return commandIndex+1;
 }//ConsumeResultSetWithoutPropagation

 //-----------------------------------------------------------------------
 /// <summary>
 ///  Consumes the data reader created by <see cref="ReaderModificationCommandBatch.ExecuteAsync" />
 ///  without propagating values back into the <see cref="ModificationCommand" />.
 /// </summary>
 /// <param name="commandIndex"> The ordinal of the command being consumed. </param>
 /// <param name="reader"> The data reader. </param>
 /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
 /// <returns>
 ///  A task that represents the asynchronous operation.
 ///  The task contains the ordinal of the next command that must be consumed.
 /// </returns>
 protected override Task<int> ConsumeResultSetWithoutPropagationAsync
                                           (int                  commandIndex,
                                            RelationalDataReader reader,
                                            CancellationToken    cancellationToken)
 {
  Debug.Assert(!Object.ReferenceEquals(reader,null));
  Debug.Assert(!Object.ReferenceEquals(reader.DbCommand,null));
  Debug.Assert(!Object.ReferenceEquals(reader.DbDataReader,null));
  Debug.Assert(!Object.ReferenceEquals(this.CommandResultSet,null));
  Debug.Assert(!Object.ReferenceEquals(this.ModificationCommands,null));
  Debug.Assert(!Object.ReferenceEquals(this.Dependencies,null));
  Debug.Assert(!Object.ReferenceEquals(this.Dependencies.SqlGenerationHelper,null));

  Debug.Assert(commandIndex<this.CommandResultSet.Count);
  Debug.Assert(commandIndex<this.ModificationCommands.Count);

  //----------------------------------------------------------------------
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__ModificationCommandBatch::ConsumeResultSetWithoutPropagationAsync\n"
   +" (commandIndex      : {0}\n"
   +"  reader            : {1},\n"
   +"  cancellationToken : {2}) - STUB",
   commandIndex,
   reader,
   cancellationToken);
#endif

  //----------------------------------------------------------------------
  return Task.Run
          (() => this.ConsumeResultSetWithoutPropagation(commandIndex,reader),
           cancellationToken);
 }//ConsumeResultSetWithoutPropagationAsync

 //private data ----------------------------------------------------------
 private static readonly Core.Values.Converters.Core_ValueCvtCtx_Std
  sm_ValueCvtCtx
   =new Core.Values.Converters.Core_ValueCvtCtx_Std();
};//class FB_Common__ModificationCommandBatch

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Update

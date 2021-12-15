////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 06.09.2021.
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Update{
////////////////////////////////////////////////////////////////////////////////
//class FB_Common__BatchExecutor

//
// Copy of Microsoft.EntityFrameworkCore.Update.BatchExecutor
//  - changed SavepointName for avoid a problem with Dialect 1.
//

sealed class FB_Common__BatchExecutor:IBatchExecutor
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__BatchExecutor;

 //-----------------------------------------------------------------------
 private const string
  SavepointName
   ="EFCore$SavePoint";

 //-----------------------------------------------------------------------
 public FB_Common__BatchExecutor(ICurrentDbContext                           currentContext,
                                 IDiagnosticsLogger<DbLoggerCategory.Update> updateLogger)
 {
  Check.Arg_NotNull
   (c_ErrSrcID,
    "constructor",
    nameof(currentContext),
    currentContext);

  Check.Arg_NotNull
   (c_ErrSrcID,
    "constructor",
    nameof(updateLogger),
    updateLogger);

  //--------------------------------------------------
  m_CurrentContext = currentContext;
  m_UpdateLogger   = updateLogger;

  //--------------------------------------------------
  Debug.Assert(!Object.ReferenceEquals(currentContext,null));
  Debug.Assert(!Object.ReferenceEquals(updateLogger,null));
 }//FB_Common__BatchExecutor

 //-----------------------------------------------------------------------
 public int Execute(IEnumerable<ModificationCommandBatch> commandBatches,
                    IRelationalConnection                 connection)
 {
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Execute),
    nameof(commandBatches),
    commandBatches);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Execute),
    nameof(connection),
    connection);

  //-----------------------------------------------------------------
  var rowsAffected     = 0;
  var transaction      = connection.CurrentTransaction;
  var beganTransaction = false;
  var createdSavepoint = false;

  try
  {
   var transactionEnlistManager = connection as ITransactionEnlistmentManager;

   if(transaction == null
      && transactionEnlistManager?.EnlistedTransaction is null
      && transactionEnlistManager?.CurrentAmbientTransaction is null
      && m_CurrentContext.Context.Database.AutoTransactionsEnabled)
   {
    transaction=connection.BeginTransaction();

    beganTransaction=true;
   }
   else
   {
    connection.Open();

    if(transaction?.SupportsSavepoints==true && m_CurrentContext.Context.Database.AutoSavepointsEnabled)
    {
     transaction.CreateSavepoint(SavepointName);

     createdSavepoint=true;
    }
   }//else

   foreach(var batch in commandBatches)
   {
    Debug.Assert(!Object.ReferenceEquals(batch,null));

    batch.Execute(connection);

    rowsAffected+=batch.ModificationCommands.Count;
   }//foreach

   if(beganTransaction)
   {
    Debug.Assert(!Object.ReferenceEquals(transaction,null));

    transaction.Commit();
   }//if
  }
  catch
  {
   if(createdSavepoint && connection.DbConnection.State == ConnectionState.Open)
   {
    Debug.Assert(!Object.ReferenceEquals(transaction,null));

    try
    {
     transaction.RollbackToSavepoint(SavepointName);
    }
    catch(Exception e)
    {
     m_UpdateLogger.BatchExecutorFailedToRollbackToSavepoint(m_CurrentContext.GetType(), e);
    }
   }//if

   throw;
  }
  finally
  {
   if(beganTransaction)
   {
    Debug.Assert(!Object.ReferenceEquals(transaction,null));

    transaction.Dispose();
   }
   else
   {
    if(createdSavepoint)
    {
     Debug.Assert(!Object.ReferenceEquals(transaction,null));

     if(connection.DbConnection.State==ConnectionState.Open)
     {
      try
      {
       transaction.ReleaseSavepoint(SavepointName);
      }
      catch(Exception e)
      {
       m_UpdateLogger.BatchExecutorFailedToReleaseSavepoint(m_CurrentContext.GetType(), e);
      }
     }//if
    }//if createdSavepoint

    connection.Close();
   }//else
  }//finally

  return rowsAffected;
 }//Execute

 //-----------------------------------------------------------------------
 public async Task<int> ExecuteAsync(IEnumerable<ModificationCommandBatch> commandBatches,
                                     IRelationalConnection                 connection,
                                     CancellationToken                     cancellationToken=default)
 {
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Execute),
    nameof(commandBatches),
    commandBatches);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Execute),
    nameof(connection),
    connection);

  //-----------------------------------------------------------------
  var rowsAffected     = 0;
  var transaction      = connection.CurrentTransaction;
  var beganTransaction = false;
  var createdSavepoint = false;

  try
  {
   var transactionEnlistManager = connection as ITransactionEnlistmentManager;

   if(transaction == null
      && transactionEnlistManager?.EnlistedTransaction is null
      && transactionEnlistManager?.CurrentAmbientTransaction is null
      && m_CurrentContext.Context.Database.AutoTransactionsEnabled)
   {
    transaction=await connection.BeginTransactionAsync(cancellationToken).ConfigureAwait(false);

    beganTransaction=true;
   }
   else
   {
    await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

    if(transaction?.SupportsSavepoints==true && m_CurrentContext.Context.Database.AutoSavepointsEnabled)
    {
     await transaction.CreateSavepointAsync(SavepointName, cancellationToken).ConfigureAwait(false);

     createdSavepoint=true;
    }
   }//else

   foreach(var batch in commandBatches)
   {
    Debug.Assert(!Object.ReferenceEquals(batch,null));

    await batch.ExecuteAsync(connection,cancellationToken).ConfigureAwait(false);

    rowsAffected+=batch.ModificationCommands.Count;
   }//foreach

   if(beganTransaction)
   {
    Debug.Assert(!Object.ReferenceEquals(transaction,null));

    await transaction.CommitAsync(cancellationToken).ConfigureAwait(false);
   }//if
  }
  catch
  {
   if(createdSavepoint && connection.DbConnection.State==ConnectionState.Open)
   {
    try
    {
     await transaction!.RollbackToSavepointAsync(SavepointName,cancellationToken).ConfigureAwait(false);
    }
    catch(Exception e)
    {
     m_UpdateLogger.BatchExecutorFailedToRollbackToSavepoint(m_CurrentContext.GetType(), e);
    }
   }//catch

   throw;
  }
  finally
  {
   if(beganTransaction)
   {
    Debug.Assert(!Object.ReferenceEquals(transaction,null));

    await transaction.DisposeAsync().ConfigureAwait(false);
   }
   else
   {
    if(createdSavepoint)
    {
     Debug.Assert(!Object.ReferenceEquals(transaction,null));

     if(connection.DbConnection.State==ConnectionState.Open)
     {
      try
      {
       await transaction.ReleaseSavepointAsync(SavepointName,cancellationToken).ConfigureAwait(false);
      }
      catch(Exception e)
      {
       m_UpdateLogger.BatchExecutorFailedToReleaseSavepoint(m_CurrentContext.GetType(), e);
      }
     }//if
    }//if createdSavepoint

    await connection.CloseAsync().ConfigureAwait(false);
   }//else
  }//finally

  return rowsAffected;
 }//ExecuteAsync

 //Helper data -----------------------------------------------------------
 private readonly ICurrentDbContext m_CurrentContext;

 private readonly IDiagnosticsLogger<DbLoggerCategory.Update> m_UpdateLogger;
};//class FB_Common__BatchExecutor

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Update

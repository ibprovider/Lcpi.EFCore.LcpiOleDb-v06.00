////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 17.05.2018.
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Data.Common;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;

using xdb=lcpi.data.oledb;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Storage{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_ADP
 =Structure.Structure_ADP;

////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__RelationalCommand

sealed class LcpiOleDb__RelationalCommand:IRelationalCommand
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.LcpiOleDb__RelationalCommand;

 //-----------------------------------------------------------------------
 public LcpiOleDb__RelationalCommand
                        (string                                commandText,
                         IReadOnlyList<IRelationalParameter>   parameters,
                         ISqlGenerationHelper                  sqlGenerationHelper)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlGenerationHelper,null));

#if TRACE
  Core.Core_Trace.Method
   ("LcpiOleDb__RelationalCommand::LcpiOleDb__RelationalCommand\n"
   +"(commandText         :{0},\n"
   +" parameters          :{1},\n"
   +" sqlGenerationHelper :{2})",
    commandText,
    parameters,
    sqlGenerationHelper);
#endif

  //----------------------------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    "constructor",
    nameof(commandText),
    commandText);

  Check.Arg_NotNull
   (c_ErrSrcID,
    "constructor",
    nameof(parameters),
    parameters);

  Check.Arg_NotNull
   (c_ErrSrcID,
    "constructor",
    nameof(sqlGenerationHelper),
    sqlGenerationHelper);

  //----------------------------------------
  m_CommandText=commandText;

  m_Parameters=parameters;

  m_SqlGenerationHelper=sqlGenerationHelper;

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(m_CommandText,null));
  Debug.Assert(!Object.ReferenceEquals(m_Parameters,null));
  Debug.Assert(!Object.ReferenceEquals(m_SqlGenerationHelper,null));
 }//LcpiOleDb__RelationalCommand

 //IRelationalCommand interface ------------------------------------------
 public string CommandText
 {
  get
  {
   return m_CommandText;
  }
 }//CommandText

 //-----------------------------------------------------------------------
 public IReadOnlyList<IRelationalParameter> Parameters
 {
  get
  {
   return m_Parameters;
  }
 }//Parameters

 //-----------------------------------------------------------------------
 public int ExecuteNonQuery(RelationalCommandParameterObject parameterObject)
 {
#if TRACE
  Core.Core_Trace.Method_Enter
   ("LcpiOleDb__RelationalCommand::ExecuteNonQuery(...)");
#endif

  //------------------------------------------------------------
  var connection = parameterObject.Connection;
  var context    = parameterObject.Context;
  var logger     = parameterObject.Logger;

  var startTime=DateTimeOffset.UtcNow;

  bool shouldLogCommandCreate  = logger?.ShouldLogCommandCreate(startTime) == true;
  bool shouldLogCommandExecute = logger?.ShouldLogCommandExecute(startTime) == true;

  // Guid.NewGuid is expensive, do it only if needed
  var commandId
   =(shouldLogCommandCreate||shouldLogCommandExecute)
     ?Guid.NewGuid()
     :default;

  DbCommand command=null;

  connection.Open(); //throw

  int resultValue=0;

  try
  {
   command
    =CreateDbCommand
      (parameterObject,
       commandId,
       DbCommandMethod.ExecuteNonQuery); //throw

   var stopwatch=Stopwatch.StartNew();

   try
   {
    if(!shouldLogCommandExecute)
    {
     resultValue=command.ExecuteNonQuery();
    }
    else
    {
     Debug.Assert(shouldLogCommandExecute);

     Debug.Assert(!Object.ReferenceEquals(logger,null));

     var interceptionResult
      =logger.CommandNonQueryExecuting
        (connection,
         command,
         context,
         commandId,
         connection.ConnectionId,
         startTime,
         parameterObject.CommandSource);

     var nonQueryResult
      =interceptionResult.HasResult
        ? interceptionResult.Result
        : command.ExecuteNonQuery();

     resultValue
      =logger.CommandNonQueryExecuted
        (connection,
         command,
         context,
         commandId,
         connection.ConnectionId,
         nonQueryResult,
         startTime,
         stopwatch.Elapsed,
         parameterObject.CommandSource);
    }//else
   }
   catch(Exception exception)
   {
#if TRACE
    Core.Core_Trace.Method_Exc
     (exception,
      "LcpiOleDb__RelationalCommand::ExecuteNonQuery");
#endif

    logger?.CommandError
     (connection,
      command,
      context,
      DbCommandMethod.ExecuteNonQuery,
      commandId,
      connection.ConnectionId,
      exception,
      startTime,
      stopwatch.Elapsed,
      parameterObject.CommandSource);

    throw;
   }//catch
  }
  finally
  {
   Helper__CleanupCmdAndCn
    (ref command,
     ref connection);

   Debug.Assert(Object.ReferenceEquals(command,null));
   Debug.Assert(Object.ReferenceEquals(connection,null));
  }//finally

#if TRACE
  Core.Core_Trace.Method_Exit
   ("LcpiOleDb__RelationalCommand::ExecuteNonQuery - {0}",
    resultValue);
#endif

  return resultValue;
 }//ExecuteNonQuery

 //-----------------------------------------------------------------------
 public Task<int> ExecuteNonQueryAsync(RelationalCommandParameterObject parameterObject,
                                       CancellationToken                cancellationToken)
 {
  ThrowSysError.method_not_impl
   (c_ErrSrcID,
    "ExecuteNonQueryAsync");

  return null;
 }//ExecuteNonQueryAsync

 //-----------------------------------------------------------------------
 public object ExecuteScalar(RelationalCommandParameterObject parameterObject)
 {
  ThrowSysError.method_not_impl
   (c_ErrSrcID,
    "ExecuteScalar");

  return null;
 }//ExecuteScalar

 //-----------------------------------------------------------------------
 public Task<object> ExecuteScalarAsync(RelationalCommandParameterObject parameterObject,
                                        CancellationToken                cancellationToken)
 {
  ThrowSysError.method_not_impl
   (c_ErrSrcID,
    "ExecuteScalarAsync");

  return null;
 }//ExecuteScalarAsync

 //-----------------------------------------------------------------------
 public Task<RelationalDataReader> ExecuteReaderAsync(RelationalCommandParameterObject parameterObject,
                                                      CancellationToken                cancellationToken)
 {
#if TRACE
  Core.Core_Trace.Method
   ("LcpiOleDb__RelationalCommand::ExecuteReaderAsync(...)");
#endif

  //
  // [2021-04-26]
  //
  // No time and (it's main) wish to write correct code.
  //
  // Feel free to suggest a true implementation of this method.
  //

  return Task.Run(() => this.ExecuteReader(parameterObject),cancellationToken);
 }//ExecuteReaderAsync

 //-----------------------------------------------------------------------
 public RelationalDataReader ExecuteReader(RelationalCommandParameterObject parameterObject)
 {
#if TRACE
  Core.Core_Trace.Method
   ("LcpiOleDb__RelationalCommand::ExecuteReader(...)");
#endif

  //------------------------------------------------------------
  var connection            = parameterObject.Connection;
  var context               = parameterObject.Context;
  var readerColumns         = parameterObject.ReaderColumns;
  var logger                = parameterObject.Logger;
  var detailedErrorsEnabled = parameterObject.DetailedErrorsEnabled;

  var startTime=DateTimeOffset.UtcNow;

  bool shouldLogCommandCreate  = logger?.ShouldLogCommandCreate(startTime) == true;
  bool shouldLogCommandExecute = logger?.ShouldLogCommandExecute(startTime) == true;

  // Guid.NewGuid is expensive, do it only if needed
  var commandId
   =(shouldLogCommandCreate||shouldLogCommandExecute)
     ?Guid.NewGuid()
     :default;

  //------------------------------------------------------------
  RelationalDataReader result=null;

  DbCommand command=null;

  connection.Open(); //throw

  try
  {
   command
    =this.CreateDbCommand
      (parameterObject,
       commandId,
       DbCommandMethod.ExecuteReader);

   var stopwatch=Stopwatch.StartNew();

   DbDataReader reader;

   try
   {
    if(!shouldLogCommandExecute)
    {
     reader=command.ExecuteReader();
    }
    else
    {
     Debug.Assert(shouldLogCommandExecute);

     Debug.Assert(!Object.ReferenceEquals(logger,null));

     var interceptionResult
      =logger.CommandReaderExecuting
        (connection,
         command,
         context,
         commandId,
         connection.ConnectionId,
         startTime,
         parameterObject.CommandSource);

     reader
      =interceptionResult.HasResult
        ? interceptionResult.Result
        : command.ExecuteReader();

     reader
      =logger.CommandReaderExecuted
        (connection,
         command,
         context,
         commandId,
         connection.ConnectionId,
         reader,
         startTime,
         stopwatch.Elapsed,
         parameterObject.CommandSource);
    }//else
   }
   catch(Exception exception)
   {
    logger?.CommandError
     (connection,
      command,
      context,
      DbCommandMethod.ExecuteReader,
      commandId,
      connection.ConnectionId,
      exception,
      startTime,
      stopwatch.Elapsed,
      parameterObject.CommandSource);

    Helper__CleanupCmdAndCn
     (ref command,
      ref connection);

    Debug.Assert(Object.ReferenceEquals(command,null));
    Debug.Assert(Object.ReferenceEquals(connection,null));

    throw;
   }//catch

   if(!Object.ReferenceEquals(readerColumns,null))
   {
    reader
     =new Microsoft.EntityFrameworkCore.Query.Internal.BufferedDataReader
       (reader,
        detailedErrorsEnabled).Initialize(readerColumns);
   }//if

   result
    =new RelationalDataReader(); //throw

   result.Initialize
    (connection,
     command,
     reader,
     commandId,
     logger); //throw?

   //OK.

   //detach from connection and command
   connection =null;
   command    =null;
  }
  finally
  {
   Helper__CleanupCmdAndCn
    (ref command,
     ref connection);

   Debug.Assert(Object.ReferenceEquals(command,null));
   Debug.Assert(Object.ReferenceEquals(connection,null));
  }//finally

  return result;
 }//ExecuteReader

 //-----------------------------------------------------------------------
 public DbCommand CreateDbCommand(RelationalCommandParameterObject parameterObject,
                                  Guid                             commandId,
                                  DbCommandMethod                  commandMethod)
 {
  Debug.Assert(!Object.ReferenceEquals(m_SqlGenerationHelper,null));

#if TRACE
  Core.Core_Trace.Method
   ("LcpiOleDb__RelationalCommand::CreateDbCommand(...)");
#endif

  //----------------------------------------
  var connection
   =Check.Arg_NotNullAndInstanceOf<LcpiOleDb__RelationalConnection,IRelationalConnection>
     (c_ErrSrcID,
      nameof(CreateDbCommand),
      nameof(parameterObject.Connection),
      parameterObject.Connection);

  //----------------------------------------
  //
  // [2020-10-17] xcommand.Parameters.Refresh() requires active connection.
  //

  //! \todo Original CreateDbCommand works with parameterObject.Logger object.

  //----------------------------------------
  var xcommand=new xdb.OleDbCommand();

  DbCommand command=xcommand;

  connection.Open(); //throw

  Debug.Assert(connection.DbConnection.State==System.Data.ConnectionState.Open);

  //----------------------------------------
  try
  {
   command.CommandText=m_CommandText;

   command.Connection=connection.DbConnection;

   if(!Object.ReferenceEquals(connection.CurrentTransaction,null))
   {
    command.Transaction=connection.CurrentTransaction.GetDbTransaction();
   }//if

   if(connection.CommandTimeout.HasValue)
   {
    command.CommandTimeout=connection.CommandTimeout.Value;
   }//if

#if TRACE
   Core.Core_Trace.Send("Getting command parameter descriptions from OLE DB provider");
#endif

   xcommand.Parameters.Refresh();

#if TRACE
   for(int i=0,_c=xcommand.Parameters.Count;i!=_c;++i)
   {
    Core.Core_Trace.Send
     ("CmdParameter[{0}]: name: \"{1}\", type: {2}, size: {3};",
      i,
      xcommand[i].ParameterName,
      xcommand[i].OleDbType,
      xcommand[i].Size);
   }//for i
#endif

   if(!Object.ReferenceEquals(m_Parameters,null) && m_Parameters.Count>0)
   {
    var tmpCmd=new xdb.OleDbCommand();

    var tmpCmd_Params=tmpCmd.Parameters;

    var xparams=xcommand.Parameters;

    foreach(var p in m_Parameters)
    {
#if TRACE
     Core.Core_Trace.Send
      ("Process efcore parameter [{0}]",
       p.InvariantName);
#endif

     var parameterValues=parameterObject.ParameterValues;

     if(Object.ReferenceEquals(parameterValues,null))
     {
      //ERROR - no values

      Debug.Assert(false);

      ThrowError.NoCommandParameterValue
       (c_ErrSrcID,
        p.InvariantName);
     }//if

     tmpCmd_Params.Clear();

     p.AddDbParameter(tmpCmd,parameterValues); //SHIT: Allow EFCore build parameter value.

     for(int i=0,_c=tmpCmd_Params.Count;i!=_c;++i)
     {
      var tmpP=tmpCmd[i];

      Debug.Assert(!Object.ReferenceEquals(tmpP,null));

      var xparam
       =xcommand[tmpP.ParameterName]; //throw

      switch(xparam.Direction)
      {
       case System.Data.ParameterDirection.Input:
       case System.Data.ParameterDirection.InputOutput:
       {
        break;
       }//case Input, InputOutput

       default:
       {
        //ERROR - wrong direction of command parameter

        ThrowError.UnexpectedCommandParameterDirection
         (c_ErrSrcID,
          p.InvariantName,
          xparam.Direction);

        break;
       }//default
      }//switch param.Direction

#if TRACE
     Core.Core_Trace.Send
      (" Setup param [{0}] value: {1}",
       xparam.ParameterName,
       Core.Core_Trace.WrapUnkArg(tmpP.Value));
#endif

      xparam.Value=tmpP.Value;
     }//for i
    }//foreach xparam
   }//if Parameters.Count>0
  }
  finally
  {
   connection.Close();
  }

  return command;
 }//CreateDbCommand

 //-----------------------------------------------------------------------
 public void PopulateFrom(IRelationalCommandTemplate templateCommand)
 {
#if TRACE
  Core.Core_Trace.Method
   ("LcpiOleDb__RelationalCommand::PopulateFrom(...)");
#endif

  //----------------------------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(PopulateFrom),
    nameof(templateCommand),
    templateCommand);

  //----------------------------------------
  var commandText =templateCommand.CommandText;

  var parameters  =templateCommand.Parameters;

  //----------------------------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(PopulateFrom),
    "templateCommand.CommandText",
    templateCommand.CommandText);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(PopulateFrom),
    "templateCommand.Parameters",
    parameters);

  //----------------------------------------
  m_CommandText  = commandText;
  m_Parameters   = parameters;
 }//PopulateFrom

 //Helper methods --------------------------------------------------------
 private static void Helper__CleanupCmdAndCn(ref DbCommand             command,
                                             ref IRelationalConnection connection)
 {
  var tmpCmd =Structure_ADP.Exchange(ref command,null);
  var tmpCn  =Structure_ADP.Exchange(ref connection,null);

  Debug.Assert(Object.ReferenceEquals(command,null));
  Debug.Assert(Object.ReferenceEquals(connection,null));

  if(!Object.ReferenceEquals(tmpCmd,null))
  {
   tmpCmd.Parameters.Clear();

   tmpCmd.Dispose();
  }//if

  if(!Object.ReferenceEquals(tmpCn,null))
  {
   tmpCn.Close();
  }//if
 }//Helper__CleanupCmdAndCn

 //private data ----------------------------------------------------------

 //Not null.
 private readonly ISqlGenerationHelper m_SqlGenerationHelper;

 //-----------------------------------------------------------------------
 private string m_CommandText;

 private IReadOnlyList<IRelationalParameter> m_Parameters;
};//class LcpiOleDb__RelationalCommand

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Storage

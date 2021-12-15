////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 14.09.2018.
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Extensions.Logging;

using Microsoft.EntityFrameworkCore.Diagnostics;

using NUnit.Framework;

namespace EFCore_LcpiOleDb_Tests.General{
////////////////////////////////////////////////////////////////////////////////
//class TestLogger

sealed class TestLogger:ILogger
{
 public TestLogger()
 {
  m_LogNumber=Interlocked.Increment(ref sm_LogNumber);

  m_ExecutedCommand=new List<string>();
 }//TestLogger

 //-----------------------------------------------------------------------
 public void CheckTextOfLastExecutedCommand(string expectedStr)
 {
  var cExecutedCommands=m_ExecutedCommand.Count;

  Console.WriteLine("CheckTextOfLastExecutedCommand: {0}",cExecutedCommands);

  Assert.NotZero(cExecutedCommands);

  var expectedStr1=Helper__NormalizeCmdText(expectedStr);
  var lastCmdText1=Helper__NormalizeCmdText(m_ExecutedCommand.Last());

  Assert.AreEqual
   (expectedStr1,
    lastCmdText1);
 }//CheckTextOfLastExecutedCommand

 //ILogger interface -----------------------------------------------------
 public IDisposable BeginScope<TState>(TState state)
 {
  return null;
 }//BeginScope

 //-----------------------------------------------------------------------
 public bool IsEnabled(LogLevel logLevel)
 {
  return true;
 }//IsEnabled

 //-----------------------------------------------------------------------
 public void Log<TState>(LogLevel                        logLevel,
                         EventId                         eventId,
                         TState                          state,
                         Exception                       exception,
                         Func<TState, Exception, string> formatter)
 {
  this.Helper__Write(formatter(state, exception));

  if(eventId==RelationalEventId.CommandExecuted)
  {
   Debug.Assert(state is IReadOnlyList<KeyValuePair<string, object>>);

   var props=(IReadOnlyList<KeyValuePair<string, object>>)state;

   var CommandText=props.Single(p => p.Key=="commandText").Value;

   m_ExecutedCommand.Add((string)CommandText);
  }//if
 }//Log

 //Helper methods --------------------------------------------------------
 private static string Helper__NormalizeCmdText(string s)
 {
  return s.Replace("\r\n","\n");
 }//Helper__NormalizeCmdText

 //-----------------------------------------------------------------------
 private void Helper__Write(string s)
 {
  Console.WriteLine("LOG [{0}]: {1}",m_LogNumber,s);
 }//Helper__Write

 //private data ----------------------------------------------------------
 private readonly int m_LogNumber;

 private readonly List<string> m_ExecutedCommand;

 //-----------------------------------------------------------------------
 private static int sm_LogNumber=0;
};//class TestLogger

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General

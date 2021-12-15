////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 14.09.2018.
using System;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace EFCore_LcpiOleDb_Tests.General{
////////////////////////////////////////////////////////////////////////////////
//class TestLoggerFactory

class TestLoggerFactory:ILoggerFactory
{
 public TestLoggerFactory(TestLogger log)
 {
  m_log=log;
 }

 //-----------------------------------------------------------------------
 public void AddProvider(ILoggerProvider provider)
 {
 }

 //-----------------------------------------------------------------------
 public ILogger CreateLogger(string categoryName)
 {
  return m_log;
 }//CreateLogger

 //-----------------------------------------------------------------------
 public void Dispose()
 {
  Debug.Assert(false);

  throw new NotImplementedException();
 }//Dispose

 //-----------------------------------------------------------------------
 private readonly TestLogger m_log;
};//class TestLoggerFactory

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General

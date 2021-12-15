////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 14.09.2018.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore;

using xdb=lcpi.data.oledb;
using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General{
////////////////////////////////////////////////////////////////////////////////
//class TestBaseDbContext

class TestBaseDbContext:DbContext
{
 public TestBaseDbContext()
 {
  m_log=new TestLogger();
 }//TestBaseDbContext

 //----------------------------------------------------------------------
 public TestBaseDbContext(xdb.OleDbTransaction tr)
 {
  m_cn=tr.Connection;

  m_log=new TestLogger();

  this.Database.UseTransaction(tr);
 }//TestBaseDbContext

 //----------------------------------------------------------------------
 public TestLogger log
 {
  get
  {
   Debug.Assert(!Object.ReferenceEquals(m_log,null));

   return m_log;
  }//get
 }//log

 //-----------------------------------------------------------------------
 public void ExecConnectionOperation(Action<xdb.OleDbConnection> op)
 {
  var database=this.Database;

  Debug.Assert(!Object.ReferenceEquals(database,null));

  database.OpenConnection(); //throw

  try
  {
   var cn=(xdb.OleDbConnection)database.GetDbConnection();

   Debug.Assert(!Object.ReferenceEquals(cn,null));

   op(cn);
  }
  finally
  {
   Debug.Assert(!Object.ReferenceEquals(database,null));

   database.CloseConnection();
  }//finally
 }//ExecConnectionOperation
 
 //-----------------------------------------------------------------------
 public void CheckTextOfLastExecutedCommand(TestSqlTemplate expectedSqlTemplate)
 {
  Debug.Assert(!Object.ReferenceEquals(expectedSqlTemplate,null));

  ExecConnectionOperation
   (cn => 
    {
     var expectedSql=expectedSqlTemplate.BuildSql(cn);
 
     Debug.Assert(!Object.ReferenceEquals(expectedSql,null));

     this.log.CheckTextOfLastExecutedCommand(expectedSql);
    });
 }//CheckTextOfLastExecutedCommand

 //DbContext interface ---------------------------------------------------
 protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
 {
  Debug.Assert(!Object.ReferenceEquals(m_log,null));

  Action<xEFCore.Infrastructure.LcpiOleDb__DbContextOptionsBuilder>
   optionsActions
    =new ((x) => x.LcpiOleDb__ExecutionOfUnknownMethods(this.Internal__GetCfg__LcpiOleDb__ExecutionOfUnknownMethods()));

  if(Object.ReferenceEquals(m_cn,null))
  {
   optionsBuilder.UseLcpiOleDb
    (TestServices.Conf__GetCnStr(),
     optionsActions);
  }
  else
  {
   optionsBuilder.UseLcpiOleDb
    (m_cn,
     optionsActions);
  }//else

  optionsBuilder.UseLoggerFactory(new TestLoggerFactory(m_log));

  //! \todo Restore configuration of QueryClientEvaluationWarning
  //optionsBuilder.ConfigureWarnings(w => w.Ignore(RelationalEventId.QueryClientEvaluationWarning));
 }//OnConfiguring

 //Own interface ---------------------------------------------------------
 protected virtual bool Internal__GetCfg__LcpiOleDb__ExecutionOfUnknownMethods()
 {
  return false;
 }//Internal__GetCfg__LcpiOleDb__ExecutionOfUnknownMethods

 //-----------------------------------------------------------------------
 private readonly xdb.OleDbConnection m_cn;

 private readonly TestLogger m_log;
};//class TestBaseDbContext

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General

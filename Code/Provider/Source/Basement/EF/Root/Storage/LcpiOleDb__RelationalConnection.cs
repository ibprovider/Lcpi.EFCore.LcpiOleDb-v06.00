////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 17.05.2018.
using System;
using System.Diagnostics;
using System.Data.Common;
using Microsoft.EntityFrameworkCore.Storage;

using xdb=lcpi.data.oledb;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Storage{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__RelationalConnection

sealed class LcpiOleDb__RelationalConnection:RelationalConnection
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.LcpiOleDb__RelationalConnection;

 //-----------------------------------------------------------------------
 public LcpiOleDb__RelationalConnection
                        (RelationalConnectionDependencies dependencies,
                         Core.Core_ConnectionOptions      cnOptions)
  :base(dependencies)
 {
#if TRACE
  Core.Core_Trace.Method
   ("LcpiOleDb__RelationalConnection::LcpiOleDb__RelationalConnection");
#endif

  //----------------------------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    "constructor",
    nameof(cnOptions),
    cnOptions);

  //----------------------------------------
  m_CnOptions=cnOptions;

  Debug.Assert(!Object.ReferenceEquals(m_CnOptions,null));
 }//LcpiOleDb__RelationalConnection

 //RelationalConnection interface ----------------------------------------
 protected override DbConnection CreateDbConnection()
 {
#if TRACE
  Core.Core_Trace.Method
   ("LcpiOleDb__RelationalConnection::CreateDbConnection");
#endif

  return new xdb.OleDbConnection(this.ConnectionString);
 }//CreateDbConnection

 //private data ----------------------------------------------------------
 private readonly Core.Core_ConnectionOptions
  m_CnOptions;
};//class LcpiOleDb__RelationalConnection

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Storage

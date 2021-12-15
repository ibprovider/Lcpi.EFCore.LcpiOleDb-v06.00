////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core. Engines. Dbms. Firebird.
//                                      IBProvider and Contributors. 31.05.2018.
using System;
using System.Diagnostics;

using xdb=lcpi.data.oledb;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird{
////////////////////////////////////////////////////////////////////////////////
//class FB_ConnectionInitializer

/// <summary>
///  Initialization of services for connection to Firebird database
/// </summary>
static class FB_ConnectionInitializer
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Core_Engines_Dbms_FB_ConnectionInitializer;

 //-----------------------------------------------------------------------
 /// <summary>
 ///  Initialization of services for connection to Firebird database
 /// </summary>
 /// <param name="Data">
 ///  Not null.
 /// </param>
 /// <param name="DsInfoRow">
 ///  Not null. Row of "DataSourceInformation" metadata collection.
 /// </param>
 public static void Exec(Core_ConnectionOptionsData Data,
                         System.Data.DataRow        DsInfoRow)
 {
  Debug.Assert(!Object.ReferenceEquals(Data,null));
  Debug.Assert(!Object.ReferenceEquals(DsInfoRow,null));
  Debug.Assert(!Object.ReferenceEquals(DsInfoRow.Table,null));
  Debug.Assert(DsInfoRow.Table.TableName==xdb.OleDbMetaDataCollectionNames.DataSourceInformation);

  //----------------------------------------------------------------------
  if(Data.ServerVersion>=sm_FbVersion__03_0_8)
  {
   V03_0_0.FB_ConnectionInitializer.Exec
    (Data,
     DsInfoRow);
  }
  else
  {
   ThrowError.UnsupportedDbmsVersion
    (c_ErrSrcID,
     Data.ServerName,
     Data.ServerVersion);
  }//else
 }//Exec

 //private data ----------------------------------------------------------

 // History:
 //
 // - v3.0.8.33445
 //   Fixed a translation of TIMESTAMP to string in Dialect 1.
 //   Always use four digit for part with year.
 //
 // - v3.0.8.33506
 //   Fixed DATEDIFF(PRECISION FROM ... TO ...)
 //   return value with FRACTIONAL part
 //    D1: DOUBLE
 //    D3: NUMERIC(18,1)

 private static readonly System.Version
  sm_FbVersion__03_0_8
   =new System.Version(3,0,8,33506);
};//class FB_ConnectionInitializer

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird

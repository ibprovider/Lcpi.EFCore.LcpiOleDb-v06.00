////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core. Engines.
//                                      IBProvider and Contributors. 26.03.2019.
using System;
using System.Diagnostics;

using xdb=lcpi.data.oledb;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.IscBase{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_ADP
 =Structure.Structure_ADP;

////////////////////////////////////////////////////////////////////////////////
//class IscBase_EngineSvc__ConnectionInfo

sealed class IscBase_EngineSvc__ConnectionInfo:Core_Svc
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.IscBase_EngineSvc__ConnectionInfo;

 //-----------------------------------------------------------------------
 private IscBase_EngineSvc__ConnectionInfo()
 {
 }//IscBase_EngineSvc__ConnectionInfo

 //-----------------------------------------------------------------------
 public static IscBase_EngineSvc__ConnectionInfo Create(System.Data.DataRow DsInfoRow)
 {
  Debug.Assert(!Object.ReferenceEquals(DsInfoRow,null));

  //--------------------------------------
  var cninfo=new IscBase_EngineSvc__ConnectionInfo();

  //--------------------------------------
  var iCol__ISC_ConnectionDialect
   =Structure_ADP.IndexOf
    (c_ErrSrcID,
     DsInfoRow.Table,
     xdb.OleDbMetaDataCollectionColumnNames.DataSourceInformation.ISC.ConnectionDialect);

  cninfo.m_ConnectionDialect
   =Structure_ADP.GetInt32_NN
     (c_ErrSrcID,
      DsInfoRow,
      iCol__ISC_ConnectionDialect);

  //--------------------------------------
  return cninfo;
 }//Create

 //-----------------------------------------------------------------------
 public int ConnectionDialect
 {
  get
  {
   return m_ConnectionDialect;
  }//get
 }//ConnectionDialect

 //private data ----------------------------------------------------------
 private int m_ConnectionDialect;
};//class IscBase_EngineSvc__ConnectionInfo

////////////////////////////////////////////////////////////////////////////////
}//Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.IscBase

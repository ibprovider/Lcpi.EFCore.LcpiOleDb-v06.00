////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core.
//                                      IBProvider and Contributors. 21.05.2018.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core{
////////////////////////////////////////////////////////////////////////////////
//class Core_ConnectionOptions

sealed class Core_ConnectionOptions
 :Core_SvcProvider
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Core_ConnectionOptions;

 //-----------------------------------------------------------------------
 public Core_ConnectionOptions(Core_ConnectionOptionsData cnOptData)
 {
  Debug.Assert(!Object.ReferenceEquals(cnOptData,null));

  m_Data=cnOptData;

  Debug.Assert(!Object.ReferenceEquals(m_Data,null));
 }//Core_ConnectionOptions

 //interface -------------------------------------------------------------
 public string ServerName
 {
  get
  {
   Debug.Assert(!Object.ReferenceEquals(m_Data,null));

   return m_Data.ServerName;
  }//get
 }//ServerName

 //-----------------------------------------------------------------------
 public Version ServerVersion
 {
  get
  {
   Debug.Assert(!Object.ReferenceEquals(m_Data,null));

   return m_Data.ServerVersion;
  }//get
 }//ServerVersion

 //-----------------------------------------------------------------------
 public bool IsMultipleActiveResultSetsEnabled
 {
  get
  {
   Debug.Assert(!Object.ReferenceEquals(m_Data,null));

   return m_Data.IsMultipleActiveResultSetsEnabled;
  }//get
 }//IsMultipleActiveResultSetsEnabled

 //EngineSvcProvider interface -------------------------------------------
 public Core_Svc QuerySvc(Guid SvcID)
 {
  Debug.Assert(!Object.ReferenceEquals(m_Data,null));

  return m_Data.QuerySvc(SvcID);
 }//QuerySvc

 //helper data -----------------------------------------------------------
 private readonly Core_ConnectionOptionsData m_Data;
};//class Core_ConnectionOptions

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core

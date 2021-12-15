////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core.
//                                      IBProvider and Contributors. 23.05.2018.
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core{
////////////////////////////////////////////////////////////////////////////////

using LcpiOleDb__DbContextOptionsExtension
 =Infrastructure.LcpiOleDb__DbContextOptionsExtension;

////////////////////////////////////////////////////////////////////////////////
//class Core_ConnectionOptionsData

sealed class Core_ConnectionOptionsData:Core_SvcProvider
{
 public string  ServerName;

 public Version ServerVersion;

 public bool IsMultipleActiveResultSetsEnabled;

 public readonly LcpiOleDb__DbContextOptionsExtension DbContextOptions;

 //-----------------------------------------------------------------------
 public Core_ConnectionOptionsData(LcpiOleDb__DbContextOptionsExtension settings)
 {
  Debug.Assert(!Object.ReferenceEquals(settings,null));

  this.IsMultipleActiveResultSetsEnabled
   =false;

  this.DbContextOptions
   =settings;
 }//Core_ConnectionOptionsData

 //interface -------------------------------------------------------------
 public void RegService(Guid SvcID,Core_Svc Svc)
 {
  Debug.Assert(!Object.ReferenceEquals(Svc,null));

  Debug.Assert(!Object.ReferenceEquals(m_EngineServices,null));

  Debug.Assert(!m_EngineServices.ContainsKey(SvcID));

  m_EngineServices.Add(SvcID,Svc);
 }//RegService

 //-----------------------------------------------------------------------
 public Core_Svc QuerySvc(Guid SvcID)
 {
  Debug.Assert(!Object.ReferenceEquals(m_EngineServices,null));

  Core_Svc Svc;

  if(m_EngineServices.TryGetValue(SvcID,out Svc))
  {
   Debug.Assert(!Object.ReferenceEquals(Svc,null));

   return Svc;
  }//if

  return null;
 }//QuerySvc

 //private data ----------------------------------------------------------
 private readonly Dictionary<Guid,Core_Svc> m_EngineServices
  =new Dictionary<Guid,Core_Svc>();
};//class Core_ConnectionOptionsData

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core

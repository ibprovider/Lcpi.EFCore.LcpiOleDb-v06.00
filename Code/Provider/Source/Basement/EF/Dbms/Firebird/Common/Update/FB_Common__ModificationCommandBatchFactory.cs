////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 22.05.2018.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Update;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Update{
////////////////////////////////////////////////////////////////////////////////
//class FB_Common__ModificationCommandBatchFactory

/*public*/ sealed class FB_Common__ModificationCommandBatchFactory:IModificationCommandBatchFactory
{
 public FB_Common__ModificationCommandBatchFactory(ModificationCommandBatchFactoryDependencies dependencies)
 {
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__ModificationCommandBatchFactory::FB_Common__ModificationCommandBatchFactory\n"
   +" (dependencies : {0})",
   dependencies);
#endif

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(dependencies,null));

  //----------------------------------------
  m_dependencies = dependencies;
 }//FB_Common__ModificationCommandBatchFactory

 //-----------------------------------------------------------------------
 public /*virtual*/ ModificationCommandBatch Create()
 {
#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__ModificationCommandBatchFactory::Create()");
#endif

  return new FB_Common__ModificationCommandBatch(m_dependencies);
 }//Create

 //private data ----------------------------------------------------------
 private readonly ModificationCommandBatchFactoryDependencies m_dependencies;
};//class FB_Common__ModificationCommandBatchFactory

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Update

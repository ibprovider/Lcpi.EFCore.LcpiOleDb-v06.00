////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 18.10.2021.
using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Storage.D1{
////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0_D1__GetTypeMappingSourceForDDL

sealed class FB_V03_0_0_D1__GetTypeMappingSourceForDDL
 :Root.Storage.LcpiOleDb__IGetTypeMappingSourceForDDL
{
 public FB_V03_0_0_D1__GetTypeMappingSourceForDDL(FB_V03_0_0_D1__TypeMappingSourceForDDL typeMappingSource)
 {
  Debug.Assert(!Object.ReferenceEquals(typeMappingSource, null));

  m_TypeMappingSource=typeMappingSource;
 }//FB_V03_0_0_D1__GetTypeMappingSourceForDDL

 //interface -------------------------------------------------------------
 public IRelationalTypeMappingSource GetTypeMappingSourceForDDL()
 {
  Debug.Assert(!Object.ReferenceEquals(m_TypeMappingSource,null));

  return m_TypeMappingSource;
 }//GetTypeMappingSourceForDDL

 //private data ----------------------------------------------------------
 private readonly IRelationalTypeMappingSource
  m_TypeMappingSource;
};//class FB_V03_0_0_D1__GetTypeMappingSourceForDDL

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Storage.D1
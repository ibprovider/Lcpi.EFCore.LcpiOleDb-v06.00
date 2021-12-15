////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 15.11.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__Common__StoreObjectIdentifierHelper

static class LcpiOleDb__Common__StoreObjectIdentifierHelper
{
 public static bool TryBuildEntityStoreIdThatCompatibleWithValueGenerationStrategy
                            (IReadOnlyEntityType       entityType,
                             out StoreObjectIdentifier storeObject)
 {
  Debug.Assert(!Object.ReferenceEquals(entityType,null));

  storeObject=default;

  if(Helper__TryBuildTableStoreID(entityType,ref storeObject))
   return true;

  if(Helper__TryBuildViewStoreID(entityType,ref storeObject))
   return true;

  return false;
 }//TryBuildEntityStoreIdThatCompatibleWithValueGenerationStrategy

 //Helper methods --------------------------------------------------------
 private static bool Helper__TryBuildTableStoreID
                            (IReadOnlyEntityType       entityType,
                             ref StoreObjectIdentifier storeObject)
 {
  Debug.Assert(!Object.ReferenceEquals(entityType,null));

  string name
   =entityType.GetTableName();

  if(Object.ReferenceEquals(name,null))
   return false;

  Debug.Assert(!Object.ReferenceEquals(name,null));

  storeObject
   =StoreObjectIdentifier.Table(name,entityType.GetSchema());

  return true;
 }//Helper__TryBuildTableStoreID

 //-----------------------------------------------------------------------
 private static bool Helper__TryBuildViewStoreID
                            (IReadOnlyEntityType       entityType,
                             ref StoreObjectIdentifier storeObject)
 {
  Debug.Assert(!Object.ReferenceEquals(entityType,null));

  var name
   =entityType.GetViewName();

  if(Object.ReferenceEquals(name,null))
   return false;

  Debug.Assert(!Object.ReferenceEquals(name,null));

  storeObject
   =StoreObjectIdentifier.View(name,entityType.GetViewSchema());

  return true;
 }//Helper__TryBuildViewStoreID
};//class LcpiOleDb__Common__StoreObjectIdentifierHelper

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb

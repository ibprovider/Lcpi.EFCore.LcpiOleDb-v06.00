////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 22.10.2021.

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.Mapping{
////////////////////////////////////////////////////////////////////////////////
//class FB_Common__TypeMapping

abstract class FB_Common__TypeMapping
 :Root.Storage.Mapping.LcpiOleDb__TypeMapping
{
 protected FB_Common__TypeMapping(in RelationalTypeMappingParameters parameters)
  :base(parameters)
 {
 }

 //RelationalTypeMapping interface ---------------------------------------
 public override sealed string StoreTypeNameBase
 {
  get
  {
   return this.Internal__GetStoreTypeNameBase();
  }
 }//StoreTypeNameBase

 //Internal interface ----------------------------------------------------
 protected abstract string Internal__GetStoreTypeNameBase();
};//class FB_Common__TypeMapping

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.Mapping

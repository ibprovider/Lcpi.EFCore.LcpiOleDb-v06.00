////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 18.05.2018.
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D3{
////////////////////////////////////////////////////////////////////////////////
//using

using LcpiOleDb__Sql_ETranslator_MethodCall
 =Root.Query.Sql.Expressions.Translators.LcpiOleDb__Sql_ETranslator_MethodCall;

using LcpiOleDb__SqlSvc__DataFor_MethodCallTranslatorProvider
 =Root.Query.Sql.Svcs.LcpiOleDb__SqlSvc__DataFor_MethodCallTranslatorProvider;

using Structure_MethodId
 =Structure.Structure_MethodId;

////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0__DataFor_MethodCallTranslatorProvider

sealed partial class FB_V03_0_0__DataFor_MethodCallTranslatorProvider
 :LcpiOleDb__SqlSvc__DataFor_MethodCallTranslatorProvider
{
 public static readonly FB_V03_0_0__DataFor_MethodCallTranslatorProvider
  Instance
   =new FB_V03_0_0__DataFor_MethodCallTranslatorProvider();

 //-----------------------------------------------------------------------
 private FB_V03_0_0__DataFor_MethodCallTranslatorProvider()
 {
 }//FB_V03_0_0__DataFor_MethodCallTranslatorProvider

 //Structure_IGetDataByKey2 interface ------------------------------------
 public bool TryGetData(Structure_MethodId                        methodId,
                        out LcpiOleDb__Sql_ETranslator_MethodCall translator)
 {
  Debug.Assert(!Object.ReferenceEquals(methodId,null));

  Debug.Assert(!Object.ReferenceEquals(tagDataByKey.sm_Items,null));

  if(!tagDataByKey.sm_Items.TryGetValue(methodId,out translator))
   return false;

  Debug.Assert(!Object.ReferenceEquals(translator,null));

  return true;
 }//TryGetData

 //-----------------------------------------------------------------------
 public IEnumerable<Structure_MethodId> SelectKeysByName(string name)
 {
  Debug.Assert(!Object.ReferenceEquals(name,null));

  if(!tagKeysByName.sm_Items.TryGetValue(name,out var keys))
   return sm_EMPTY_LIST_WITH_KEYS;

  Debug.Assert(!Object.ReferenceEquals(keys,null));
  Debug.Assert(keys.Count>0);

  return keys;
 }//SelectKeysByName

 //private data ----------------------------------------------------------
 private static readonly Structure_MethodId[]
  sm_EMPTY_LIST_WITH_KEYS
   =new Structure_MethodId[0];
};//class FB_V03_0_0__DataFor_MethodCallTranslatorProvider

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D3

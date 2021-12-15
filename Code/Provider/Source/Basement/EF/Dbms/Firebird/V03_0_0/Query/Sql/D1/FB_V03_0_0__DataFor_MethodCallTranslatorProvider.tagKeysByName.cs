////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 27.05.2021.
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D1{
////////////////////////////////////////////////////////////////////////////////
//using

using FB_Common_SqlTranslators
 =Common.Query.Sql.Expressions.Translators;

using Structure_MethodId
 =Structure.Structure_MethodId;

////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0__DataFor_MethodCallTranslatorProvider

sealed partial class FB_V03_0_0__DataFor_MethodCallTranslatorProvider
{
 //private types ---------------------------------------------------------
 private sealed class tagContainer_for_KeysByName
  :Dictionary<string,List<Structure_MethodId>>
 {
  public tagContainer_for_KeysByName Add(Structure_MethodId methodId)
  {
   Debug.Assert(!Object.ReferenceEquals(methodId,null));
   Debug.Assert(!Object.ReferenceEquals(methodId.MethodName,null));

   if(!base.TryGetValue(methodId.MethodName,out var keys))
   {
    keys=new List<Structure_MethodId>();

    base.Add(methodId.MethodName,keys);
   }//if

   Debug.Assert(!keys.Contains(methodId));

   keys.Add(methodId);

   return this;
  }//Add
 };//class tagContainer_for_KeysByName

 //private data ----------------------------------------------------------
 private static class tagKeysByName
 {
  public static readonly tagContainer_for_KeysByName
   sm_Items
    =Helper__CreateItems();

  //-------------------------------------------------------
  private static tagContainer_for_KeysByName Helper__CreateItems()
  {
   var result
    =new tagContainer_for_KeysByName();

   foreach(var key in tagDataByKey.sm_Items.Keys)
   {
    Debug.Assert(!Object.ReferenceEquals(key,null));

    result.Add(key);
   }//foreach key

   return result;
  }//Helper__CreateItems
 };//class tagDataByKey
};//class FB_V03_0_0__DataFor_MethodCallTranslatorProvider

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D1

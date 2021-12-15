////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 19.11.2018.
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Local.Expressions.Methods.Code.DbCast.Converters{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

////////////////////////////////////////////////////////////////////////////////
//interface DbCast_CvtCtx_Std

sealed class DbCast_CvtCtx_Std:Core.Core_ValueCvtCtx
{
 //interface -------------------------------------------------------------
 public Core.Core_ValueCvt GetValueCvt(System.Type sourceType,
                                       System.Type targetType)
 {
  Debug.Assert(!Object.ReferenceEquals(sourceType,null));
  Debug.Assert(!Object.ReferenceEquals(targetType,null));

  return Helper__GetValueCvt(sourceType,targetType);
 }//GetValueCvt

 //private types ---------------------------------------------------------
 private sealed class tagLevel1:Dictionary<System.Type,Core.Core_ValueCvt<object,object>>
 {
  public tagLevel1 Add_Cvt(System.Type                       toType,
                           Core.Core_ValueCvt<object,object> valueCvt)
  {
   Debug.Assert(!Object.ReferenceEquals(toType,null));
   Debug.Assert(!Object.ReferenceEquals(valueCvt,null));

   Debug.Assert(!base.ContainsKey(toType));

   base.Add(toType,valueCvt);

   return this;
  }//Add_Cvt
 };//class tagLevel1

 //-----------------------------------------------------------------------
 private sealed class tagLevel0:Dictionary<System.Type,tagLevel1>
 {
  public tagLevel1 Create_Level1(System.Type fromType)
  {
   Debug.Assert(!Object.ReferenceEquals(fromType,null));

   var level1=new tagLevel1();

   base.Add(fromType,level1);

   return level1;
  }//Create_Level1
 };//class tagLevel1

 //Helper methods --------------------------------------------------------
 private static Core.Core_ValueCvt Helper__GetValueCvt(System.Type sourceType,
                                                       System.Type targetType)
 {
  Debug.Assert(!Object.ReferenceEquals(sourceType,null));
  Debug.Assert(!Object.ReferenceEquals(targetType,null));

  Debug.Assert(!Object.ReferenceEquals(sm_CvtMap,null));

  tagLevel1 m2;

  if(!sm_CvtMap.TryGetValue(sourceType,out m2))
   return null;

  Debug.Assert(!Object.ReferenceEquals(m2,null));

  Core.Core_ValueCvt<object,object> cvt;

  if(!m2.TryGetValue(targetType,out cvt))
   return null;

  Debug.Assert(!Object.ReferenceEquals(cvt,null));

  return cvt;
 }//Helper__GetValueCvt

 //-----------------------------------------------------------------------
 private static tagLevel0 Helper__CreateCvtMap()
 {
  var Map=new tagLevel0();

  //---------------------------------------- Simple
  Map
   .Create_Level1(Structure_TypeCache.TypeOf__System_Int32)

   .Add_Cvt(Structure_TypeCache.TypeOf__System_Int32,   DbCast_Cvt__Int32__Int32.Instance)
   .Add_Cvt(Structure_TypeCache.TypeOf__System_Double,  DbCast_Cvt__Int32__Double.Instance)
   ;

  Map
   .Create_Level1(Structure_TypeCache.TypeOf__System_Int64)

   .Add_Cvt(Structure_TypeCache.TypeOf__System_Int32,   DbCast_Cvt__Int64__Int32.Instance)
   .Add_Cvt(Structure_TypeCache.TypeOf__System_Int64,   DbCast_Cvt__Int64__Int64.Instance)
   ;

  Map
   .Create_Level1(Structure_TypeCache.TypeOf__System_Decimal)

   .Add_Cvt(Structure_TypeCache.TypeOf__System_Decimal, DbCast_Cvt__Decimal__Decimal.Instance)
   .Add_Cvt(Structure_TypeCache.TypeOf__System_Int32,   DbCast_Cvt__Decimal__Int32.Instance)
   ;

  Map
   .Create_Level1(Structure_TypeCache.TypeOf__System_Double)

   .Add_Cvt(Structure_TypeCache.TypeOf__System_Double,  DbCast_Cvt__Double__Double.Instance)
   .Add_Cvt(Structure_TypeCache.TypeOf__System_Int32,   DbCast_Cvt__Double__Int32.Instance)
   ;

  //----------------------------------------
  return Map;
 }//Helper__CreateCvtMap

 //private data ----------------------------------------------------------
 private static readonly tagLevel0
  sm_CvtMap
   =Helper__CreateCvtMap();
};//class DbCast_CvtCtx_Std

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Local.Expressions.Methods.Code.DbCast.Converters

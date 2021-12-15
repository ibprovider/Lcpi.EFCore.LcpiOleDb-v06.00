////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core.
//                                      IBProvider and Contributors. 02.06.2018.
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Values.Converters{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

////////////////////////////////////////////////////////////////////////////////
//interface Core_ValueCvtCtx_Std

sealed class Core_ValueCvtCtx_Std:Core_ValueCvtCtx
{
 //interface -------------------------------------------------------------
 public Core_ValueCvt GetValueCvt(System.Type sourceType,
                                  System.Type targetType)
 {
  Debug.Assert(!Object.ReferenceEquals(sourceType,null));
  Debug.Assert(!Object.ReferenceEquals(targetType,null));

  return Helper__GetValueCvt(sourceType,targetType);
 }//GetValueCvt

 //private types ---------------------------------------------------------
 private sealed class tagLevel1:Dictionary<System.Type,Core_ValueCvt<object,object>>
 {
  public tagLevel1 Add_Cvt(System.Type                  toType,
                           Core_ValueCvt<object,object> valueCvt)
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
 private static Core_ValueCvt Helper__GetValueCvt(System.Type sourceType,
                                                  System.Type targetType)
 {
  Debug.Assert(!Object.ReferenceEquals(sourceType,null));
  Debug.Assert(!Object.ReferenceEquals(targetType,null));

  tagLevel1 m2;

  if(!sm_CvtMap.TryGetValue(sourceType,out m2))
   return null;

  Debug.Assert(!Object.ReferenceEquals(m2,null));

  Core_ValueCvt<object,object> cvt;

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
   .Create_Level1(Structure_TypeCache.TypeOf__System_Int16)

   .Add_Cvt(Structure_TypeCache.TypeOf__System_Int16    ,Core_ValueCvt__Int16__Int16.Instance)
   .Add_Cvt(Structure_TypeCache.TypeOf__System_Int32    ,Core_ValueCvt__Int16__Int32.Instance)
   .Add_Cvt(Structure_TypeCache.TypeOf__System_Int64    ,Core_ValueCvt__Int16__Int64.Instance)
   .Add_Cvt(Structure_TypeCache.TypeOf__System_Decimal  ,Core_ValueCvt__Int16__Decimal.Instance)
   ;

  //--------------------------
  Map
   .Create_Level1(Structure_TypeCache.TypeOf__System_Int32)

   .Add_Cvt(Structure_TypeCache.TypeOf__System_Int16    ,Core_ValueCvt__Int32__Int16.Instance)
   .Add_Cvt(Structure_TypeCache.TypeOf__System_Int32    ,Core_ValueCvt__Int32__Int32.Instance)
   .Add_Cvt(Structure_TypeCache.TypeOf__System_Int64    ,Core_ValueCvt__Int32__Int64.Instance)
   .Add_Cvt(Structure_TypeCache.TypeOf__System_Decimal  ,Core_ValueCvt__Int32__Decimal.Instance)
   ;

  //--------------------------
  Map
   .Create_Level1(Structure_TypeCache.TypeOf__System_Int64)

   .Add_Cvt(Structure_TypeCache.TypeOf__System_Int16    ,Core_ValueCvt__Int64__Int16.Instance)
   .Add_Cvt(Structure_TypeCache.TypeOf__System_Int32    ,Core_ValueCvt__Int64__Int32.Instance)
   .Add_Cvt(Structure_TypeCache.TypeOf__System_Int64    ,Core_ValueCvt__Int64__Int64.Instance)
   .Add_Cvt(Structure_TypeCache.TypeOf__System_Decimal  ,Core_ValueCvt__Int64__Decimal.Instance)
   ;

  //--------------------------
  Map
   .Create_Level1(Structure_TypeCache.TypeOf__System_Single)

   .Add_Cvt(Structure_TypeCache.TypeOf__System_Single   ,Core_ValueCvt__Single__Single.Instance)
   .Add_Cvt(Structure_TypeCache.TypeOf__System_Double   ,Core_ValueCvt__Single__Double.Instance)
   ;

  //--------------------------
  Map
   .Create_Level1(Structure_TypeCache.TypeOf__System_Double)

   .Add_Cvt(Structure_TypeCache.TypeOf__System_Double,Core_ValueCvt__Double__Double.Instance)
   ;

  //--------------------------
  Map
   .Create_Level1(Structure_TypeCache.TypeOf__System_Decimal)

   .Add_Cvt(Structure_TypeCache.TypeOf__System_Decimal,Core_ValueCvt__Decimal__Decimal.Instance)
   ;

  //--------------------------
  Map
   .Create_Level1(Structure_TypeCache.TypeOf__System_Boolean)

   .Add_Cvt(Structure_TypeCache.TypeOf__System_Boolean,Core_ValueCvt__Boolean__Boolean.Instance)
   ;

  //--------------------------
  Map
   .Create_Level1(Structure_TypeCache.TypeOf__System_DateTime)

   .Add_Cvt(Structure_TypeCache.TypeOf__System_DateTime,Core_ValueCvt__DateTime__DateTime.Instance)
   .Add_Cvt(Structure_TypeCache.TypeOf__System_DateOnly,Core_ValueCvt__DateTime__DateOnly.Instance)
   ;

  //--------------------------
  Map
   .Create_Level1(Structure_TypeCache.TypeOf__System_TimeSpan)

   .Add_Cvt(Structure_TypeCache.TypeOf__System_TimeSpan,Core_ValueCvt__TimeSpan__TimeSpan.Instance)
   .Add_Cvt(Structure_TypeCache.TypeOf__System_TimeOnly,Core_ValueCvt__TimeSpan__TimeOnly.Instance)
   ;

  //--------------------------
  Map
   .Create_Level1(Structure_TypeCache.TypeOf__System_String)

   .Add_Cvt(Structure_TypeCache.TypeOf__System_String      ,Core_ValueCvt__String__String.Instance)
   .Add_Cvt(Structure_TypeCache.TypeOf__System_Array_Char  ,Core_ValueCvt__String__Array_Char.Instance)
   ;

  //--------------------------
  Map
   .Create_Level1(Structure_TypeCache.TypeOf__System_Guid)

   .Add_Cvt(Structure_TypeCache.TypeOf__System_Guid        ,Core_ValueCvt__Guid__Guid.Instance)
   .Add_Cvt(Structure_TypeCache.TypeOf__System_Array_Byte  ,Core_ValueCvt__Guid__Array1_Byte.Instance)
   ;

  //---------------------------------------- Array
  Map
   .Create_Level1(Structure_TypeCache.TypeOf__System_Array_Byte)

   .Add_Cvt(Structure_TypeCache.TypeOf__System_Array_Byte,Core_ValueCvt__Array_Byte__Array_Byte.Instance)
   ;

  //----------------------------------------
  return Map;
 }//Helper__CreateCvtMap

 //private data ----------------------------------------------------------
 private static readonly tagLevel0
  sm_CvtMap
   =Helper__CreateCvtMap();
};//class Core_ValueCvtCtx_Std

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Values.Converters

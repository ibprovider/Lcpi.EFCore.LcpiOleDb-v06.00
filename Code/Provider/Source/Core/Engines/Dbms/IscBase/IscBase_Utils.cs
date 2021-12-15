////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core. Engines.
//                                      IBProvider and Contributors. 29.05.2018.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.IscBase{
////////////////////////////////////////////////////////////////////////////////
//class IscBase_Utils

static class IscBase_Utils
{
 public const long c_AdjustTicks=500;

 //-----------------------------------------------------------------------
 public static int GetConnectionDialect(Core_ConnectionOptions cnOptions)
 {
  Debug.Assert(!Object.ReferenceEquals(cnOptions,null));
 
  var cnInfoCns
   =Core_SvcUtils.QuerySvc<Core.Engines.Dbms.IscBase.IscBase_EngineSvc__ConnectionInfo>
     (cnOptions,
      EngineSvcID.IscBase_EngineSvc__ConnectionInfo);

  Debug.Assert(!Object.ReferenceEquals(cnInfoCns,null));

  return cnInfoCns.ConnectionDialect;
 }//GetConnectionDialect

 //-----------------------------------------------------------------------
 public static System.Int64 NormalizeTicks(in System.Int64 value)
 {
  var r
   =value-(value%Core_Consts.TimeSpan___TicksInMicroSec);

  return r;
 }//NormalizeTicks

 //-----------------------------------------------------------------------
 public static System.DateTime NormalizeDateTime(in System.DateTime value)
 {
  var ticks
   =NormalizeTicks(value.Ticks);

  var r
   =new System.DateTime(ticks);

  return r;
 }//NormalizeDateTime

 //-----------------------------------------------------------------------
 public static System.TimeSpan NormalizeTimeSpan(in System.TimeSpan value)
 {
  var ticks
   =NormalizeTicks(value.Ticks);

  var r
   =new System.TimeSpan(ticks);

  return r;
 }//NormalizeTimeSpan

 //-----------------------------------------------------------------------
 public static System.TimeOnly NormalizeTimeOnly(in System.TimeOnly value)
 {
#if DEBUG
  Debug.Assert(Structure.Structure_ADP.DEBUG__TimeOnlyContainsValidSqlTime(value));
#endif

  var ticks
   =NormalizeTicks(value.Ticks);

  var r
   =new System.TimeOnly(ticks);

  return r;
 }//NormalizeTimeOnly
};//class IscBase_Utils

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.IscBase

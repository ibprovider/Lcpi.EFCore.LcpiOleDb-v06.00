////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core. Engines.
//                                      IBProvider and Contributors. 29.05.2018.

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.IscBase{
////////////////////////////////////////////////////////////////////////////////
//class IscBase_Const

static class IscBase_Const
{
 public const int c_max_char_size              =32767;

 public const int c_max_varchar_size           =32765;

 public const int c_max_numeric_precision      =18;

 public const int c_max_decimal_precision      =18;

 //-------------------------------------------------------------
 public const int  c_SqlPrecision__NUMERIC__Int16
  =4;

 public const int  c_SqlPrecision__NUMERIC__Int32
  =9;

 public const int  c_SqlPrecision__NUMERIC__Int64
  =18;

 //-------------------------------------------------------------
 public const int c_TICKS_IN_TIME_FRACTION
  =1000;

 public const byte c_TIME_FRACTION_SCALE
  =4;

 public const int c_TIME_FRACTION_PRECISION
  =10000;

 //-------------------------------------------------------------
 public static readonly System.DateTime MinDate
  =new System.DateTime(1,1,1);

 public static readonly System.DateTime MaxDate
  =new System.DateTime(9999,12,31,23,59,59)+new System.TimeSpan(9999*Core_Consts.TimeSpan___TicksInMicroSec);
};//class IscBase_Const

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.IscBase

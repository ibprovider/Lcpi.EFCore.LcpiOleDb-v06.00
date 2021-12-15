////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core.
//                                      IBProvider and Contributors. 02.03.2021.

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core{
////////////////////////////////////////////////////////////////////////////////
//class Core_Consts

static class Core_Consts
{
 public const int MaxPrecision__Decimal     =29;

 public const int MaxScale__Decimal         =28;

 //-------------------------------------------------------------
 public const long TimeSpan___TicksInMicroSec          =1000;

 public const long TimeSpan___TicksInSec               =TimeSpan___TicksInMicroSec*10000;

 public const long TimeSpan___TicksInMin               =TimeSpan___TicksInSec*60;

 public const long TimeSpan___TicksInHour              =TimeSpan___TicksInMin*60;

 public const long TimeSpan___TicksInDay               =TimeSpan___TicksInHour*24;
};//class Core_Consts

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core
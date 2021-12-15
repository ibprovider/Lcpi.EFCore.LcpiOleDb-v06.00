////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core. Engines. Dbms. Firebird.
//                                      IBProvider and Contributors. 02.07.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

using Structure_StrHelpers
 =Structure.Structure_StrHelpers;

////////////////////////////////////////////////////////////////////////////////

using T_TARGET_VALUE
 =System.TimeOnly;

////////////////////////////////////////////////////////////////////////////////
//class Convert_Code__STRING__TYPE_TIME_as_TimeOnly

static class Convert_Code__STRING__TYPE_TIME_as_TimeOnly
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Core_Engines_Dbms_FB_Common_Mirror__Convert_Code__STRING__TYPE_TIME_as_TimeOnly;

 //Interface -------------------------------------------------------------
 public static T_TARGET_VALUE Exec(System.String strValue)
 {
  int part_Hours=0;
  int part_Minutes=0;
  int part_Seconds=0;
  int part_MicroSeconds=0;

  var r
   =Helpers.Convert_Helper__ParserPart__STRING_TIME.Exec
    (strValue,
     /*offset*/0,
     out part_Hours,
     out part_Minutes,
     out part_Seconds,
     out part_MicroSeconds);

  if(r.Code!=Helpers.Convert_Helper__ParserPart__STRING_TIME.ExecResultCode.Ok)
  {
   Helper__ThrowError__CantConvert();

   Debug.Assert(false);
  }//if

  int offset
   =Structure_StrHelpers.Skip__SPACES_TABS
     (strValue,
      r.Offset);

  if(offset!=strValue.Length)
  {
   Helper__ThrowError__CantConvert();

   Debug.Assert(false);
  }//if

  Debug.Assert(offset==strValue.Length);

  //----------------------------------------
  const long c_TicksInMicroSec=1000;
  const long c_TicksInSec     =c_TicksInMicroSec*10*1000;
  const long c_TicksInMin     =c_TicksInSec*60;
  const long c_TicksInHour    =c_TicksInMin*60;

  long resultTicks
   =c_TicksInHour     * part_Hours
   +c_TicksInMin      * part_Minutes
   +c_TicksInSec      * part_Seconds
   +c_TicksInMicroSec * part_MicroSeconds;

  //----------------------------------------
  return new T_TARGET_VALUE(resultTicks);
 }//Exec

 //Helper methods --------------------------------------------------------
 private static void Helper__ThrowError__CantConvert()
 {
  ThrowError.FailedToConvertValueBetweenTypes
   (c_ErrSrcID,
    Structure_TypeCache.TypeOf__System_String,
    typeof(T_TARGET_VALUE)); //throw!
 }//Helper__ThrowError__CantConvert
};//class Convert_Code__STRING__TYPE_TIME_as_TimeOnly

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Code
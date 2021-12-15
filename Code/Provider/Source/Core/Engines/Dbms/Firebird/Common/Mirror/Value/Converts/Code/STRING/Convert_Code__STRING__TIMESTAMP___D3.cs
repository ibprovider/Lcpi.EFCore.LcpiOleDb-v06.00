////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core. Engines. Dbms. Firebird.
//                                      IBProvider and Contributors. 20.02.2021.
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
//class Convert_Code__STRING__TIMESTAMP___D3

static class Convert_Code__STRING__TIMESTAMP___D3
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Core_Engines_Dbms_FB_Common_Mirror__Convert_Code__STRING__TIMESTAMP___D3;

 //Interface -------------------------------------------------------------
 public static System.DateTime Exec(System.String strValue)
 {
  int part_Year         =0;
  int part_Month        =0;
  int part_Day          =0;
  int part_Hours        =0;
  int part_Minutes      =0;
  int part_Seconds      =0;
  int part_MicroSeconds =0;

  //-------------------------------------------------------
  int offset
   =0;

  var r1
   =Helpers.Convert_Helper__ParserPart__STRING_DATE___D3.Exec
    (strValue,
     offset,
     out part_Year,
     out part_Month,
     out part_Day);

  if(r1.Code!=Helpers.Convert_Helper__ParserPart__STRING_DATE___D3.ExecResultCode.Ok)
  {
   Helper__ThrowError__CantConvert();

   Debug.Assert(false);
  }//if

  Debug.Assert(r1.Code==Helpers.Convert_Helper__ParserPart__STRING_DATE___D3.ExecResultCode.Ok);

  //-------------------------------------------------------
  if(r1.Offset==strValue.Length)
  {
   // OK. END OF TEXT. TIMESTAMP with DATE part only.

   offset=r1.Offset;
  }
  else
  {
   offset
    =Structure_StrHelpers.Skip__SPACES_TABS
      (strValue,
       r1.Offset);

   if(r1.Offset==offset)
   {
    //No empty space after DATE part!

    Helper__ThrowError__CantConvert();

    Debug.Assert(false);
   }//if

   Debug.Assert(r1.Offset<offset);

   if(offset!=strValue.Length)
   {
    //parsing a TIME part
    var r2
     =Helpers.Convert_Helper__ParserPart__STRING_TIME.Exec
       (strValue,
        offset,
        out part_Hours,
        out part_Minutes,
        out part_Seconds,
        out part_MicroSeconds);

    if(r2.Code!=Helpers.Convert_Helper__ParserPart__STRING_TIME.ExecResultCode.Ok)
    {
     Helper__ThrowError__CantConvert();

     Debug.Assert(false);
    }//if

    offset=r2.Offset;
   }//if
  }//else

  //-------------------------------------------------------
  offset
   =Structure_StrHelpers.Skip__SPACES_TABS
     (strValue,
      offset);

  if(offset!=strValue.Length)
  {
   //Unexpected data after processed text

   Helper__ThrowError__CantConvert();

   Debug.Assert(false);
  }//if

  //-------------------------------------------------------
  Debug.Assert(offset==strValue.Length);

  //OK. Build result.

  var result
   =new System.DateTime
     (part_Year,
      part_Month,
      part_Day,
      part_Hours,
      part_Minutes,
      part_Seconds)
    .AddTicks(1000*part_MicroSeconds);

  return result;
 }//Exec

 //Helper methods --------------------------------------------------------
 private static void Helper__ThrowError__CantConvert()
 {
  ThrowError.FailedToConvertValueBetweenTypes
   (c_ErrSrcID,
    Structure_TypeCache.TypeOf__System_String,
    Structure_TypeCache.TypeOf__System_DateTime); //throw!
 }//Helper__ThrowError__CantConvert
};//Convert_Code__STRING__TIMESTAMP___D3

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Code

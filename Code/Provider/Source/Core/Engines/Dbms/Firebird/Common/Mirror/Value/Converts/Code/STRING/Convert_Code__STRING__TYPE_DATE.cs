////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core. Engines. Dbms. Firebird.
//                                      IBProvider and Contributors. 03.07.2021.
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
//class Convert_Code__STRING__TYPE_DATE

static class Convert_Code__STRING__TYPE_DATE
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Core_Engines_Dbms_FB_Common_Mirror__Convert_Code__STRING__TYPE_DATE;

 //Interface -------------------------------------------------------------
 public static System.DateOnly Exec(System.String strValue)
 {
  int part_Year  =0;
  int part_Month =0;
  int part_Day   =0;

  //-------------------------------------------------------
  var r
   =Helpers.Convert_Helper__ParserPart__STRING_DATE___D3.Exec
    (strValue,
     /*offset*/0,
     out part_Year,
     out part_Month,
     out part_Day);

  if(r.Code!=Helpers.Convert_Helper__ParserPart__STRING_DATE___D3.ExecResultCode.Ok)
  {
   Helper__ThrowError__CantConvert();

   Debug.Assert(false);
  }//if

  Debug.Assert(r.Code==Helpers.Convert_Helper__ParserPart__STRING_DATE___D3.ExecResultCode.Ok);

  //-------------------------------------------------------
  int offset
   =Structure_StrHelpers.Skip__SPACES_TABS
     (strValue,
      r.Offset);

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
   =new System.DateOnly
     (part_Year,
      part_Month,
      part_Day);

  return result;
 }//Exec

 //Helper methods --------------------------------------------------------
 private static void Helper__ThrowError__CantConvert()
 {
  ThrowError.FailedToConvertValueBetweenTypes
   (c_ErrSrcID,
    Structure_TypeCache.TypeOf__System_String,
    Structure_TypeCache.TypeOf__System_DateOnly); //throw!
 }//Helper__ThrowError__CantConvert
};//Convert_Code__STRING__TYPE_DATE

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Code

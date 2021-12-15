////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core. Engines. Dbms. Firebird.
//                                      IBProvider and Contributors. 16.02.2021.
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
//class Convert_Code__STRING__BOOLEAN

/// <summary>
///  Utility for conversion of string value to boolean value.
/// </summary>
//!
//! \note
//!  This utility obtains and uses a Core_TextServices service.
//!
static class Convert_Code__STRING__BOOLEAN
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Core_Engines_Dbms_FB_Common_Mirror__Convert_Code__STRING__BOOLEAN;

 //Interface -------------------------------------------------------------

 /// <summary>
 ///  Convert string value to boolean value.
 /// </summary>
 //! \param[in] cvtCtx
 //!  Not null. Must provide interface Core_CvsProvider.
 //! \param[in] strValue
 //!  Not null.
 //! \return
 //!  Converted value.
 public static System.Boolean Exec(Core_ValueCvtCtx cvtCtx,
                                   System.String    strValue)
 {
  Debug.Assert(!Object.ReferenceEquals(cvtCtx,null));
  Debug.Assert(!Object.ReferenceEquals(strValue,null));

  //-------------------------------------------------------
  var textSvcs
   =Core_SvcUtils.QuerySvc<Core_TextServices>
     (cvtCtx,
      Core_SvcID.Core_TextServices); //throw

  Debug.Assert(!Object.ReferenceEquals(textSvcs,null));

  //-------------------------------------------------------
  int offset
   =Core_TextServicesHelpers.Skip__EmptySymbols
     (textSvcs,
      strValue,
      /*offset*/0);

  //-------------------------------------------------------
  bool result=false;

  if(Structure_StrHelpers.TestStrPrefix__ASCII_UPPER(strValue,offset,"TRUE"))
  {
   result=true;

   Debug.Assert("TRUE".Length==4);

   offset+=4; // T R U E
  }
  else
  if(Structure_StrHelpers.TestStrPrefix__ASCII_UPPER(strValue,offset,"FALSE"))
  {
   result=false;

   Debug.Assert("FALSE".Length==5);

   offset+=5; // F A L S E
  }
  else
  {
   Helper__ThrowError__FailedToConvertValueBetweenTypes();

   Debug.Assert(false);
  }//else

  //-------------------------------------------------------
  offset
   =Core_TextServicesHelpers.Skip__EmptySymbols
     (textSvcs,
      strValue,
      offset);

  Debug.Assert(offset>=0);
  Debug.Assert(offset<=strValue.Length);

  if(offset==strValue.Length)
   return result;

  Debug.Assert(offset<strValue.Length);

  Helper__ThrowError__FailedToConvertValueBetweenTypes();

  Debug.Assert(false);

  return false;
 }//Exec

 //Helper methods --------------------------------------------------------
 private static void Helper__ThrowError__FailedToConvertValueBetweenTypes()
 {
  ThrowError.FailedToConvertValueBetweenTypes
   (c_ErrSrcID,
    Structure_TypeCache.TypeOf__System_String,
    Structure_TypeCache.TypeOf__System_Boolean); //throw!
 }//Helper__ThrowError__FailedToConvertValueBetweenTypes
};//class Convert_Code__STRING__BOOLEAN

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Code

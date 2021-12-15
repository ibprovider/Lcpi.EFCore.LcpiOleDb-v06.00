////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core. Engines. Common
//                                      IBProvider and Contributors. 24.05.2018.
using System;
using System.Diagnostics;
using System.Text;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Common{
////////////////////////////////////////////////////////////////////////////////
//class Common_EngineSvc__CommandParamereterNameBuilder__Error_NoPrefix

sealed class Common_EngineSvc__CommandParamereterNameBuilder__Error_NoPrefix
 :EngineSvc__CommandParameterNameBuilder
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Common_EngineSvc__CommandParamereterNameBuilder__Error_NoPrefix;

 //-----------------------------------------------------------------------
 private Common_EngineSvc__CommandParamereterNameBuilder__Error_NoPrefix()
 {
 }//Common_EngineSvc__CommandParamereterNameBuilder__Error_NoPrefix

 //-----------------------------------------------------------------------
 public static EngineSvc__CommandParameterNameBuilder Create()
 {
  //[2020-10-15] Tested.

  Debug.Assert(!Object.ReferenceEquals(sm_Instance,null));

  return sm_Instance;
 }//Create

 //interface -------------------------------------------------------------
 public string GenParameterName(string invariantName)
 {
  //[2020-10-15] Tested.

  Debug.Assert(!string.IsNullOrEmpty(invariantName));

  //ERROR - Не определен префикс именованных параметров
  ThrowError.NotDefinedNamedParameterPrefix(c_ErrSrcID);

  return null;
 }//GenParameterName

 //-----------------------------------------------------------------------
 public void GenParameterName(StringBuilder builder,
                              string        invariantName)
 {
  //[2020-10-15] Tested.

  Debug.Assert(!Object.ReferenceEquals(builder,null));
  Debug.Assert(!string.IsNullOrEmpty(invariantName));

  //ERROR - Не определен префикс именованных параметров
  ThrowError.NotDefinedNamedParameterPrefix(c_ErrSrcID);

  Debug.Assert(false);
 }//GenParameterName

 //-----------------------------------------------------------------------
 public string GenParameterMarker(string invariantName)
 {
  //[2020-10-15] Tested.

  Debug.Assert(!string.IsNullOrEmpty(invariantName));

  //ERROR - Не определен префикс именованных параметров
  ThrowError.NotDefinedNamedParameterPrefix(c_ErrSrcID);

  return null;
 }//GenParameterMarker

 //-----------------------------------------------------------------------
 public void GenParameterMarker(StringBuilder builder,
                                string        invariantName)
 {
  //[2020-10-15] Tested.

  Debug.Assert(!Object.ReferenceEquals(builder,null));
  Debug.Assert(!string.IsNullOrEmpty(invariantName));

  //ERROR - Не определен префикс именованных параметров
  ThrowError.NotDefinedNamedParameterPrefix(c_ErrSrcID);

  Debug.Assert(false);
 }//GenParameterMarker

 //-----------------------------------------------------------------------
 public string ExtractInvariantParameterName(string parameterName)
 {
  //[2021-09-02] Tested.

  Debug.Assert(!string.IsNullOrEmpty(parameterName));

  //ERROR - Не определен префикс именованных параметров
  ThrowError.NotDefinedNamedParameterPrefix(c_ErrSrcID);

  Debug.Assert(false);

  return null;
 }//ExtractInvariantParameterName

 //-----------------------------------------------------------------------
 private static EngineSvc__CommandParameterNameBuilder
  sm_Instance
   =new Common_EngineSvc__CommandParamereterNameBuilder__Error_NoPrefix();
};//class Common_EngineSvc__CommandParamereterNameBuilder__Error_NoPrefix

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Common

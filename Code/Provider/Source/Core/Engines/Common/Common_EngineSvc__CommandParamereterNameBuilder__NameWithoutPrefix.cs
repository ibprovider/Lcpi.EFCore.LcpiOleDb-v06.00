////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core. Engines. Common
//                                      IBProvider and Contributors. 24.05.2018.
using System;
using System.Diagnostics;
using System.Text;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Common{
////////////////////////////////////////////////////////////////////////////////
//class Common_EngineSvc__CommandParamereterNameBuilder__NameWithoutPrefix

sealed class Common_EngineSvc__CommandParamereterNameBuilder__NameWithoutPrefix
 :EngineSvc__CommandParameterNameBuilder
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Common_EngineSvc__CommandParamereterNameBuilder__NameWithoutPrefix;

 //-----------------------------------------------------------------------
 private Common_EngineSvc__CommandParamereterNameBuilder__NameWithoutPrefix(string ParameterPrefix)
 {
  Debug.Assert(!Object.ReferenceEquals(ParameterPrefix,null));
  Debug.Assert(ParameterPrefix.Length>0);

  m_ParameterPrefix=ParameterPrefix;
 }//Common_EngineSvc__CommandParamereterNameBuilder__NameWithoutPrefix

 //-----------------------------------------------------------------------
 public static EngineSvc__CommandParameterNameBuilder Create(string ParameterPrefix)
 {
  //[2020-10-15] Tested.

  Debug.Assert(!Object.ReferenceEquals(ParameterPrefix,null));
  Debug.Assert(ParameterPrefix.Length>0);

  return new Common_EngineSvc__CommandParamereterNameBuilder__NameWithoutPrefix(ParameterPrefix);
 }//Create

 //interface -------------------------------------------------------------
 public string GenParameterName(string invariantName)
 {
  //[2020-10-15] Tested.

  Debug.Assert(!string.IsNullOrEmpty(invariantName));

  Debug.Assert(!Object.ReferenceEquals(m_ParameterPrefix,null));
  Debug.Assert(m_ParameterPrefix.Length>0);

  return invariantName;
 }//GenParameterName

 //-----------------------------------------------------------------------
 public void GenParameterName(StringBuilder builder,
                              string        invariantName)
 {
  //[2020-10-15] Tested.

  Debug.Assert(!Object.ReferenceEquals(builder,null));
  Debug.Assert(!string.IsNullOrEmpty(invariantName));

  Debug.Assert(!Object.ReferenceEquals(m_ParameterPrefix,null));
  Debug.Assert(m_ParameterPrefix.Length>0);

  builder.Append(invariantName);
 }//GenParameterName

 //-----------------------------------------------------------------------
 public string GenParameterMarker(string invariantName)
 {
  //[2020-10-15] Tested.

  Debug.Assert(!string.IsNullOrEmpty(invariantName));

  Debug.Assert(!Object.ReferenceEquals(m_ParameterPrefix,null));
  Debug.Assert(m_ParameterPrefix.Length>0);

  return m_ParameterPrefix+invariantName;
 }//GenParameterMarker

 //-----------------------------------------------------------------------
 public void GenParameterMarker(StringBuilder builder,
                                string        invariantName)
 {
  //[2020-10-15] Tested.

  Debug.Assert(!Object.ReferenceEquals(builder,null));
  Debug.Assert(!string.IsNullOrEmpty(invariantName));

  Debug.Assert(!Object.ReferenceEquals(m_ParameterPrefix,null));
  Debug.Assert(m_ParameterPrefix.Length>0);

  builder.Append(m_ParameterPrefix);

  builder.Append(invariantName);
 }//GenParameterMarker

 //-----------------------------------------------------------------------
 public string ExtractInvariantParameterName(string parameterName)
 {
  //[2021-09-02] Tested.

  Debug.Assert(!string.IsNullOrEmpty(parameterName));

  Debug.Assert(!Object.ReferenceEquals(m_ParameterPrefix,null));
  Debug.Assert(m_ParameterPrefix.Length>0);

  //-------------------------------------------------------
  Check.Arg_NotNullAndNotEmpty
   (c_ErrSrcID,
    nameof(ExtractInvariantParameterName),
    nameof(parameterName),
    parameterName);

  //-------------------------------------------------------
  return parameterName;
 }//ExtractInvariantParameterName

 //private data ----------------------------------------------------------
 private readonly string m_ParameterPrefix;
};//class Common_EngineSvc__CommandParamereterNameBuilder__NameWithoutPrefix

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Common

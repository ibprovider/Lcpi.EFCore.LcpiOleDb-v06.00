////////////////////////////////////////////////////////////////////////////////
//EF.Core Provider for LCPI OLE DB and Firebird.
//                                      IBProvider and Contributors. 23.10.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.Mapping{
////////////////////////////////////////////////////////////////////////////////
//class FB_Common__TypeMappingHelpers

static class FB_Common__TypeMappingHelpers
{
 public static string BuildStoreTypeName__CHAR_or_VARCHAR
                        (string storeTypeNameBase,
                         int    length,
                         string charsetName)
 {
  Debug.Assert(!string.IsNullOrEmpty(storeTypeNameBase));

  var n_reserved
   =storeTypeNameBase.Length+1+5+1;
  
  if(!Object.ReferenceEquals(charsetName,null))
   n_reserved+=c_block__CHARACTER_SET.Length+charsetName.Length;

  //----------------------------------------
  var sb
   =new System.Text.StringBuilder
     (n_reserved);

  sb.Append(storeTypeNameBase);
  sb.Append('(');
  sb.Append(length.ToString(FB_Common__TypeMappingConfig.CvtCulture));
  sb.Append(')');

  if(!Object.ReferenceEquals(charsetName,null))
  {
   sb.Append(c_block__CHARACTER_SET);
   sb.Append(charsetName);
  }//if

  return sb.ToString();
 }//BuildStoreTypeName__CHAR_or_VARCHAR

 //-----------------------------------------------------------------------
 public static string AppendCharSetName(string storeTypeName,string charsetName)
 {
  Debug.Assert(!string.IsNullOrEmpty(storeTypeName));

  if(Object.ReferenceEquals(charsetName,null))
   return storeTypeName;

  return storeTypeName+c_block__CHARACTER_SET+charsetName;
 }//AppendCharSetName

 //private data ----------------------------------------------------------
 private const string c_block__CHARACTER_SET
  =" CHARACTER SET ";
};//class FB_Common__TypeMappingUtils

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.Mapping

////////////////////////////////////////////////////////////////////////////////
//EF.Core Provider for LCPI OLE DB and Firebird.
//                                      IBProvider and Contributors. 15.09.2021.
using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage{
////////////////////////////////////////////////////////////////////////////////
//class FB_Common__TypeMappingUtils

static class FB_Common__TypeMappingUtils
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__TypeMappingUtils;

 //-----------------------------------------------------------------------
 public static bool IsBLOB(RelationalTypeMapping typeMapping)
 {
  const string c_bugcheck_src
   ="FB_Common__TypeMappingUtils::Helper__GetResultTypeMapping";

  //-------------------------------------------------------
  Check.BugCheck_Value_NotNull
   (c_ErrSrcID,
    c_bugcheck_src,
    "#001",
    nameof(typeMapping),
    typeMapping);

  Debug.Assert(!Object.ReferenceEquals(typeMapping,null));

  //-------------------------------------------------------
  if(typeMapping is FB_Common__ITypeMapping__BLOB)
   return true;

  return false;
 }//IsBLOB
};//class FB_Common__TypeMappingUtils

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage

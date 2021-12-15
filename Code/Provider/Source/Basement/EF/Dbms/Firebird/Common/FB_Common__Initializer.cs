////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 22.05.2018.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common{
////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Initializer

static class FB_Common__Initializer
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__Initializer;

 //-----------------------------------------------------------------------
 public static void ApplyServices(EntityFrameworkRelationalServicesBuilder builder,
                                  Core.Core_ConnectionOptionsData          cnOptionsData)
 {
  Debug.Assert(!Object.ReferenceEquals(builder,null));
  Debug.Assert(!Object.ReferenceEquals(cnOptionsData,null));

  if(cnOptionsData.ServerVersion>=sm_V03_0)
  {
   V03_0_0.FB_V03_0_0__Initializer.ApplyServices
    (builder,
     cnOptionsData);

   return;
  }//if Firebird v3.0

  ThrowError.UnsupportedDbmsVersion
   (c_ErrSrcID,
    cnOptionsData.ServerName,
    cnOptionsData.ServerVersion);
 }//ApplyServices

 //-----------------------------------------------------------------------
 private static readonly Version sm_V03_0
  =new Version(3,0);
};//class FB_Common__Initializer

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common

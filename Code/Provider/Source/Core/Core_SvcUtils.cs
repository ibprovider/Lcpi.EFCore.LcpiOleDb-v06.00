////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core.
//                                      IBProvider and Contributors. 24.05.2018.
using System;
using System.Diagnostics;

using com_lib=lcpi.lib.com;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core{
////////////////////////////////////////////////////////////////////////////////
//class Core_SvcUtils

static class Core_SvcUtils
{
 public static T QuerySvc<T>(Core_SvcProvider provider,Guid SvcID) where T: class, Core_Svc
 {
  // [2020-10-18] Review.

  Debug.Assert(!Object.ReferenceEquals(provider,null));

  var Svc=provider.QuerySvc(SvcID);

  if(Object.ReferenceEquals(Svc,null))
  {
   //ERROR - Engine Service not supported
   Debug.Assert(false);

   ThrowBugCheck.engine_svc_not_supported
    (ErrSourceID.common,
     SvcID);
  }//if Object.ReferenceEquals(Svc,null)

  Debug.Assert(!Object.ReferenceEquals(Svc,null));

  T typedSvc=(Svc as T);

  if(Object.ReferenceEquals(typedSvc,null))
  {
   //ERROR - [BUG CHECK] Service not support required interface
   Debug.Assert(false);

   ThrowBugCheck.engine_svc_not_supported_req_interface<T>
    (ErrSourceID.common,
     SvcID);
  }//if

  Debug.Assert(!Object.ReferenceEquals(typedSvc,null));

  return typedSvc;
 }//QuerySvc

 //-----------------------------------------------------------------------
 public static T QuerySvc<T>(Core_Svc provider,Guid SvcID) where T: class, Core_Svc
 {
  Debug.Assert(!Object.ReferenceEquals(provider,null));

  const string c_bugcheck_src
   ="Core_SvcUtils::QuerySvc(Core_Svc,Guid)";

  Core_SvcProvider
   provider_t
    =Check.BugCheck_Value_NotNullAndInstanceOf<Core_SvcProvider,object>
      (ErrSourceID.common,
       c_bugcheck_src,
       "#001",
       nameof(provider),
       provider);

  return QuerySvc<T>(provider_t,SvcID);
 }//QuerySvc
};//class Core_SvcUtils

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core

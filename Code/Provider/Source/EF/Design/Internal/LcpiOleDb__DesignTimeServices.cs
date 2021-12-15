////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 28.11.2021.
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Design.Internal{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__DesignTimeServices

public sealed class LcpiOleDb__DesignTimeServices
 :IDesignTimeServices
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.LcpiOleDb__DesignTimeServices;

 //------------------------------------------------------------------
 public LcpiOleDb__DesignTimeServices()
 {
#if TRACE
  Core.Core_Trace.Method
   ("LcpiOleDb__DesignTimeServices::LcpiOleDb__DesignTimeServices()");
#endif
 }//LcpiOleDb__DesignTimeServices

 //------------------------------------------------------------------
 void IDesignTimeServices.ConfigureDesignTimeServices(IServiceCollection serviceCollection)
 {
#if TRACE
  Core.Core_Trace.Method
   ("LcpiOleDb__DesignTimeServices::ConfigureDesignTimeServices(serviceCollection)");
#endif

  //--------------------------------------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(IDesignTimeServices.ConfigureDesignTimeServices),
    nameof(serviceCollection),
    serviceCollection);

  //--------------------------------------------------

  //System.Diagnostics.Debugger.Launch();

  //
  // [2021-11-29]
  //
  //  No way for right implementation.
  //
  //  Yet not supported.
  //

  ThrowError.FeatureNotSupported__DesignTimeServices
   (c_ErrSrcID);
 }//IDesignTimeServices.ConfigureDesignTimeServices
};//class LcpiOleDb__DesignTimeServices

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Design.Internal

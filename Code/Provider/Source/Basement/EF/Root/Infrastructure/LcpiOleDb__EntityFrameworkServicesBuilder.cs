////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 21.11.2020.
using System;
using System.Diagnostics;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.Infrastructure;

using Microsoft.Extensions.DependencyInjection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Infrastructure{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__EntityFrameworkServicesBuilder

sealed class LcpiOleDb__EntityFrameworkServicesBuilder:EntityFrameworkRelationalServicesBuilder
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.LcpiOleDb__EntityFrameworkServicesBuilder;

 //-----------------------------------------------------------------------
 public LcpiOleDb__EntityFrameworkServicesBuilder(IServiceCollection serviceCollection)
  :base(serviceCollection)
 {
 }//LcpiOleDb__EntityFrameworkServicesBuilder

 //EntityFrameworkRelationalServicesBuilder interface --------------------
 protected override ServiceCharacteristics GetServiceCharacteristics(Type serviceType)
 {
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(GetServiceCharacteristics),
    nameof(serviceType),
    serviceType);

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(serviceType,null));

  ServiceCharacteristics r;

  if(sm_LcpiOleDbServices.TryGetValue(serviceType,out r))
  {
   Debug.Assert(r.GetType().IsValueType);

   return r;
  }//if

  return base.GetServiceCharacteristics(serviceType);
 }//GetServiceCharacteristics

 //private data ----------------------------------------------------------
 private static readonly IDictionary<Type, ServiceCharacteristics>
  sm_LcpiOleDbServices
   =new Dictionary<Type, ServiceCharacteristics>
     {
      { typeof(Query.LcpiOleDb__ISqlTreeNodeBuilder),
        new ServiceCharacteristics(ServiceLifetime.Scoped) },
      
      { typeof(Query.LcpiOleDb__IUnaryOperatorTranslatorProvider),
        new ServiceCharacteristics(ServiceLifetime.Singleton) },

      { typeof(Query.LcpiOleDb__IBinaryOperatorTranslatorProvider),
        new ServiceCharacteristics(ServiceLifetime.Singleton) },

      { typeof(Storage.LcpiOleDb__IGetTypeMappingSourceForDDL),
        new ServiceCharacteristics(ServiceLifetime.Singleton) },
     };//sm_LcpiOleDbServices
};//class LcpiOleDb__EntityFrameworkServicesBuilder

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Infrastructure

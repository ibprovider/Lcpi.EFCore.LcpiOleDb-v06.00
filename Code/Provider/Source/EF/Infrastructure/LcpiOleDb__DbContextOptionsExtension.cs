////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 17.05.2018.
using System;
using System.Diagnostics;
using System.Data.Common;
using System.Threading;

using IServiceCollection
 =Microsoft.Extensions.DependencyInjection.IServiceCollection;

using RelationalOptionsExtension
 =Microsoft.EntityFrameworkCore.Infrastructure.RelationalOptionsExtension;

using IDbContextOptions
 =Microsoft.EntityFrameworkCore.Infrastructure.IDbContextOptions;

using DbContextOptionsExtensionInfo
 =Microsoft.EntityFrameworkCore.Infrastructure.DbContextOptionsExtensionInfo;

using xdb
 =lcpi.data.oledb;

using com_lib
 =lcpi.lib.com;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Infrastructure{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_ADP
 =Structure.Structure_ADP;

////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__DbContextOptionsExtension

public sealed partial class LcpiOleDb__DbContextOptionsExtension:RelationalOptionsExtension
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.LcpiOleDb__DbContextOptionsExtension;

 //-----------------------------------------------------------------------
 public LcpiOleDb__DbContextOptionsExtension()
 {
#if TRACE
  Core.Core_Trace.Method
   ("LcpiOleDb__DbContextOptionsExtension::LcpiOleDb__DbContextOptionsExtension()");
#endif

  m_ExtensionInfo=null;

  m_ExecutionOfUnknownMethods=true;
 }//LcpiOleDb__DbContextOptionsExtension

 //-----------------------------------------------------------------------
 private LcpiOleDb__DbContextOptionsExtension(LcpiOleDb__DbContextOptionsExtension copyFrom)
  :base(copyFrom)
 {
#if TRACE
  Core.Core_Trace.Method
   ("LcpiOleDb__DbContextOptionsExtension::LcpiOleDb__DbContextOptionsExtension(copyFrom)");
#endif

  m_ExtensionInfo=null;

  m_ExecutionOfUnknownMethods=copyFrom.m_ExecutionOfUnknownMethods;
 }//LcpiOleDb__DbContextOptionsExtension(copyFrom)

 //-----------------------------------------------------------------------
 public static new LcpiOleDb__DbContextOptionsExtension Extract(IDbContextOptions options)
 {
#if TRACE
  Core.Core_Trace.Method
   ("LcpiOleDb__DbContextOptionsExtension::Extract({0})",
    options);
#endif

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Extract),
    nameof(options),
    options);

  LcpiOleDb__DbContextOptionsExtension result=null;

  foreach(var x in options.Extensions)
  {
   Debug.Assert(!Object.ReferenceEquals(x,null));

   var r=x as LcpiOleDb__DbContextOptionsExtension;

   if(Object.ReferenceEquals(r,null))
    continue;

   Debug.Assert(!Object.ReferenceEquals(r,null));

   if(!Object.ReferenceEquals(result,null))
   {
    //ERROR - multiple connection configuration

    ThrowError.MultipleProviderConfigured
     (c_ErrSrcID);
   }//if

   Debug.Assert(Object.ReferenceEquals(result,null));

   result=r;
  }//foreach x

  if(Object.ReferenceEquals(result,null))
  {
   //ERROR - no connection configuration

   ThrowError.NoProviderConfigured
    (c_ErrSrcID);
  }//if

  Debug.Assert(!Object.ReferenceEquals(result,null));

  return result;
 }//Extract

 //own interface ---------------------------------------------------------
 public bool ExecutionOfUnknownMethods
 {
  get
  {
   return m_ExecutionOfUnknownMethods;
  }//get
 }//ExecutionOfUnknownMethods

 //-----------------------------------------------------------------------
 public new LcpiOleDb__DbContextOptionsExtension WithConnectionString(string connectionString)
 {
#if TRACE
  Core.Core_Trace.Method
   ("LcpiOleDb__DbContextOptionsExtension::WithConnectionString({0})",
    connectionString);
#endif

  const string c_bugcheck_src
   ="LcpiOleDb__DbContextOptionsExtension::WithConnectionString";

  var result
   =base.WithConnectionString(connectionString);

  var result_t
   =Check.BugCheck_Value_NotNullAndInstanceOf<LcpiOleDb__DbContextOptionsExtension,RelationalOptionsExtension>
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      nameof(result),
      result);

  return result_t;
 }//WithConnectionString

 //-----------------------------------------------------------------------
 public LcpiOleDb__DbContextOptionsExtension WithConnection(xdb.OleDbConnection connection)
 {
#if TRACE
  Core.Core_Trace.Method
   ("LcpiOleDb__DbContextOptionsExtension::WithConnection({0})",
    connection);
#endif

  const string c_bugcheck_src
   ="LcpiOleDb__DbContextOptionsExtension::WithConnection";

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(WithConnection),
    nameof(connection),
    connection);

  var result
   =base.WithConnection(connection);

  var result_t
   =Check.BugCheck_Value_NotNullAndInstanceOf<LcpiOleDb__DbContextOptionsExtension,RelationalOptionsExtension>
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      nameof(result),
      result);

  return result_t;
 }//WithConnection - OleDbConnection

 //-----------------------------------------------------------------------
 public LcpiOleDb__DbContextOptionsExtension WithExecutionOfUnknownMethods(bool value)
 {
#if TRACE
  Core.Core_Trace.Method
   ("LcpiOleDb__DbContextOptionsExtension::WithExecutionOfUnknownMethods({0})",
    value);
#endif

  if(m_ExecutionOfUnknownMethods==value)
   return this;

  var x=this.Helper__Clone();

  Debug.Assert(!Object.ReferenceEquals(x,null));

  x.m_ExecutionOfUnknownMethods=value;

  return x;
 }//WithExecutionOfUnknownMethods

 //RelationalOptionsExtension interface ----------------------------------
 public override DbContextOptionsExtensionInfo Info
 {
  get
  {
#if TRACE
   Core.Core_Trace.Method
    ("LcpiOleDb__DbContextOptionsExtension::get_Info");
#endif

   if(Object.ReferenceEquals(m_ExtensionInfo,null))
   {
    Interlocked.CompareExchange
     (ref m_ExtensionInfo,
      new tagExtensionInfo(this),
      null);
   }//if

   Debug.Assert(!Object.ReferenceEquals(m_ExtensionInfo,null));

   return m_ExtensionInfo;
  }//get
 }//Info

 //-----------------------------------------------------------------------
 public override RelationalOptionsExtension WithConnection(DbConnection connection)
 {
#if TRACE
  Core.Core_Trace.Method
   ("LcpiOleDb__DbContextOptionsExtension::WithConnection(DbConnection: {0})",
    connection);
#endif

  var connection_t
   =Check.Arg_NotNullAndInstanceOf<xdb.OleDbConnection,DbConnection>
     (c_ErrSrcID,
      nameof(WithConnection),
      nameof(connection),
      connection);

  Debug.Assert(!Object.ReferenceEquals(connection_t,null));

  return base.WithConnection(connection_t);
 }//WithConnection - DbConnection

 //-----------------------------------------------------------------------
 protected override RelationalOptionsExtension Clone()
 {
#if TRACE
  Core.Core_Trace.Method
   ("LcpiOleDb__DbContextOptionsExtension::Clone()");
#endif

  return this.Helper__Clone();
 }//Clone

 //-----------------------------------------------------------------------
 public override void ApplyServices(IServiceCollection services)
 {
  Debug.Assert(!Object.ReferenceEquals(services,null));

#if TRACE
  Core.Core_Trace.Method
   ("LcpiOleDb__DbContextOptionsExtension::ApplyServices({0})",
    services);
#endif

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(ApplyServices),
    nameof(services),
    services);

  this.Helper__ApplyServices(services);

  return;
 }//ApplyServices

 //Helper methods --------------------------------------------------------
 private LcpiOleDb__DbContextOptionsExtension Helper__Clone()
 {
  Debug.Assert(this.GetType()==typeof(LcpiOleDb__DbContextOptionsExtension));

  return new LcpiOleDb__DbContextOptionsExtension(this);
 }//Helper__Clone

 //-----------------------------------------------------------------------
 private void Helper__ApplyServices(IServiceCollection serviceCollection)
 {
  Debug.Assert(!Object.ReferenceEquals(serviceCollection,null));

  //-----------
#if TRACE
  Core.Core_Trace.Method
   ("LcpiOleDb__DbContextOptionsExtension::Helper__ApplyServices({0})",
    serviceCollection);
#endif

  //-----------
  var cnOptionsData
   =Helper__LoadOptionsData();

  //-----------
  var builder
   =new Basement.EF.Root.Infrastructure.LcpiOleDb__EntityFrameworkServicesBuilder(serviceCollection);

  //---------------------------------------
  {
   var cnOptions
    =new Core.Core_ConnectionOptions(cnOptionsData); //throw

   builder
    .TryAddProviderSpecificServices
      (b=>b.TryAddSingleton(cnOptions));
  }//local

  //----------------------------------------
  if(Structure_ADP.EqualDbmsName(cnOptionsData.ServerName,Core.Engines.Dbms.DBMS__ID.Firebird))
  {
   Basement.EF.Dbms.Firebird.Common.FB_Common__Initializer.ApplyServices
    (builder,
     cnOptionsData);
  }
  else
  {
   //ERROR - Unknown DBMS Name

   ThrowError.UnknownDbmsName
    (c_ErrSrcID,
     cnOptionsData.ServerName);
  }//else
 }//Helper__ApplyServices

 //Helper methods --------------------------------------------------------
 private Core.Core_ConnectionOptionsData Helper__LoadOptionsData()
 {
  var cnData
   =new Core.Core_ConnectionOptionsData
     (this);

  try
  {
   if(!Object.ReferenceEquals(this.Connection,null))
   {
    Helper__LoadOptionsData
     (cnData,
      this.Connection);
   }//if
   else
   if(!string.IsNullOrEmpty(this.ConnectionString))
   {
    Helper__LoadOptionsData
     (cnData,
      this.ConnectionString);
   }//if
   else
   {
    ThrowError.NoSourceForLoadCnInfo
     (c_ErrSrcID);
   }
  }
  catch(Exception e)
  {
   var exc=new LcpiOleDb__DataToolException(e);

   exc.add_error
    (com_lib.HResultCode.E_FAIL,
     c_ErrSrcID,
     ErrMessageID.common_err__failed_to_read_connection_properties_0);

   exc.raise();
  }//catch

  return cnData;
 }//Helper__LoadOptionsData

 //-----------------------------------------------------------------------
 private static void Helper__LoadOptionsData(Core.Core_ConnectionOptionsData cnData,
                                             DbConnection                    cn)
 {
  Debug.Assert(!Object.ReferenceEquals(cnData,null));
  Debug.Assert(!Object.ReferenceEquals(cn,null));

  bool cnWasOpen=false;

  try
  {
   Structure_ADP.OpenConnectionIfClosed
    (c_ErrSrcID,
     cn,
     ref cnWasOpen); //throw

   Core.Core_ConnectionOptionsInitializer.Exec
    (cnData,
     cn);
  }
  finally
  {
   if(cnWasOpen)
    cn.Close(); //throw
  }//finally
 }//Helper__LoadOptionsData - cn

 //-----------------------------------------------------------------------
 private static void Helper__LoadOptionsData(Core.Core_ConnectionOptionsData cnData,
                                             string                          cnStr)
 {
  Debug.Assert(!Object.ReferenceEquals(cnData,null));
  Debug.Assert(!string.IsNullOrEmpty(cnStr));

  using(var cn=new xdb.OleDbConnection(cnStr))
  {
   cn.Open(); //throw

   Core.Core_ConnectionOptionsInitializer.Exec
    (cnData,
     cn);
  }//using cn
 }//Helper__LoadOptionsData - cnStr

 //private data ----------------------------------------------------------
 private tagExtensionInfo m_ExtensionInfo;

 private bool m_ExecutionOfUnknownMethods;
};//class LcpiOleDb__DbContextOptionsExtension

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Infrastructure

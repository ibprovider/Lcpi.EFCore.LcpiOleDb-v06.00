////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 22.05.2018.
using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;

using LcpiOleDb__DbContextOptionsBuilder
 =Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Infrastructure.LcpiOleDb__DbContextOptionsBuilder;

using LcpiOleDb__DbContextOptionsExtension
 =Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Infrastructure.LcpiOleDb__DbContextOptionsExtension;

#if TRACE
using Core_Trace
 =Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Core_Trace;
#endif

using ErrSourceID
 =Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.ErrSourceID;

using Check
 =Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Check;

using xdb=lcpi.data.oledb;

namespace Microsoft.EntityFrameworkCore{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__Extensions__DbContextOptions

public static class LcpiOleDb__Extensions__DbContextOptions
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.LcpiOleDb__Extensions__DbContextOptions;

 //-----------------------------------------------------------------------
 public static DbContextOptionsBuilder
                         UseLcpiOleDb
                           (this DbContextOptionsBuilder               optionsBuilder,
                            string                                     connectionString,
                            Action<LcpiOleDb__DbContextOptionsBuilder> optionsAction=null)
 {
  // [2020-10-15] Tested.

  //----------------------------------------------------------------------
#if TRACE
  Core_Trace.Method
   ("LcpiOleDb__Extensions__DbContextOptions::UseLcpiOleDb({0},{1})",
    optionsBuilder,
    connectionString);
#endif

  //----------------------------------------------------------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(UseLcpiOleDb),
    nameof(optionsBuilder),
    optionsBuilder);

  Check.Arg_NotNullAndNotEmpty
   (c_ErrSrcID,
    nameof(UseLcpiOleDb),
    nameof(connectionString),
    connectionString);

  //----------------------------------------------------------------------
  var extension
   =Helper__GetOrCreateExtension(optionsBuilder).WithConnectionString(connectionString);

  Debug.Assert(!Object.ReferenceEquals(extension,null));

  return Helper__FinishInitialize
          (optionsBuilder,
           extension,
           optionsAction);
 }//UseLcpiOleDb - connectionString

 //-----------------------------------------------------------------------
 public static DbContextOptionsBuilder
                         UseLcpiOleDb
                           (this DbContextOptionsBuilder               optionsBuilder,
                            xdb.OleDbConnection                        connection,
                            Action<LcpiOleDb__DbContextOptionsBuilder> optionsAction=null)
 {
  // [2020-10-15] Tested.

  //----------------------------------------------------------------------
#if TRACE
  Core_Trace.Method
   ("LcpiOleDb__Extensions__DbContextOptions::UseLcpiOleDb({0},{1})",
    optionsBuilder,
    connection);
#endif

  //----------------------------------------------------------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(UseLcpiOleDb),
    nameof(optionsBuilder),
    optionsBuilder);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(UseLcpiOleDb),
    nameof(connection),
    connection);

  //----------------------------------------------------------------------
  var extension
   =Helper__GetOrCreateExtension(optionsBuilder).WithConnection(connection);

  Debug.Assert(!Object.ReferenceEquals(extension,null));

  return Helper__FinishInitialize
          (optionsBuilder,
           extension,
           optionsAction);
 }//UseLcpiOleDb - connection

 //-----------------------------------------------------------------------
 public static DbContextOptionsBuilder<TContext>
                         UseLcpiOleDb<TContext>
                           (this DbContextOptionsBuilder<TContext>     optionsBuilder,
                            string                                     connectionString,
                            Action<LcpiOleDb__DbContextOptionsBuilder> optionsAction=null)
                            where TContext : DbContext
 {
  // [2020-10-15] Tested.

  //----------------------------------------------------------------------
#if TRACE
  Core_Trace.Method
   ("LcpiOleDb__Extensions__DbContextOptions::UseLcpiOleDb<TContext>({0},{1})",
    optionsBuilder,
    connectionString);
#endif

  //----------------------------------------------------------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    "UseLcpiOleDb<TContext>",
    nameof(optionsBuilder),
    optionsBuilder);

  Check.Arg_NotNullAndNotEmpty
   (c_ErrSrcID,
    "UseLcpiOleDb<TContext>",
    nameof(connectionString),
    connectionString);

  //----------------------------------------------------------------------
  var extension
   =Helper__GetOrCreateExtension(optionsBuilder).WithConnectionString(connectionString);

  Debug.Assert(!Object.ReferenceEquals(extension,null));

  return Helper__FinishInitialize
          (optionsBuilder,
           extension,
           optionsAction);
 }//UseLcpiOleDb - connectionString

 //-----------------------------------------------------------------------
 public static DbContextOptionsBuilder<TContext>
                         UseLcpiOleDb<TContext>
                           (this DbContextOptionsBuilder<TContext>     optionsBuilder,
                            xdb.OleDbConnection                        connection,
                            Action<LcpiOleDb__DbContextOptionsBuilder> optionsAction=null)
                            where TContext : DbContext
 {
  // [2020-10-15] Tested.

  //----------------------------------------------------------------------
#if TRACE
  Core_Trace.Method
   ("LcpiOleDb__Extensions__DbContextOptions::UseLcpiOleDb<TContext>({0},{1})",
    optionsBuilder,
    connection);
#endif

  //----------------------------------------------------------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    "UseLcpiOleDb<TContext>",
    nameof(optionsBuilder),
    optionsBuilder);

  Check.Arg_NotNull
   (c_ErrSrcID,
    "UseLcpiOleDb<TContext>",
    nameof(connection),
    connection);

  //----------------------------------------------------------------------
  var extension
   =Helper__GetOrCreateExtension(optionsBuilder).WithConnection(connection);

  Debug.Assert(!Object.ReferenceEquals(extension,null));

  return Helper__FinishInitialize
          (optionsBuilder,
           extension,
           optionsAction);
 }//UseLcpiOleDb - connection

 //Helper methods --------------------------------------------------------
 private static LcpiOleDb__DbContextOptionsExtension Helper__GetOrCreateExtension(DbContextOptionsBuilder optionsBuilder)
 {
  Debug.Assert(!Object.ReferenceEquals(optionsBuilder,null));

  var x=optionsBuilder.Options.FindExtension<LcpiOleDb__DbContextOptionsExtension>();

  if(!Object.ReferenceEquals(x,null))
   return x;

  return new LcpiOleDb__DbContextOptionsExtension();
 }//Helper__GetOrCreateExtension

 //-----------------------------------------------------------------------
 private static T Helper__FinishInitialize<T>(T                                          optionsBuilder,
                                              LcpiOleDb__DbContextOptionsExtension       extension,
                                              Action<LcpiOleDb__DbContextOptionsBuilder> optionsAction)
  where T: DbContextOptionsBuilder
 {
  Debug.Assert(!Object.ReferenceEquals(optionsBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(extension,null));

  Helper__FI_AddOrUpdateExtension(optionsBuilder,extension);

  Helper__FI_ConfigureWarnings(optionsBuilder);

  if(!Object.ReferenceEquals(optionsAction,null))
  {
   optionsAction(new LcpiOleDb__DbContextOptionsBuilder(optionsBuilder));
  }//if

  Debug.Assert(!Object.ReferenceEquals(optionsBuilder,null));

  return optionsBuilder;
 }//Helper__FinishInitialize<T>

 //-----------------------------------------------------------------------
 private static void Helper__FI_ConfigureWarnings(DbContextOptionsBuilder optionsBuilder)
 {
  Debug.Assert(!Object.ReferenceEquals(optionsBuilder,null));

  var coreOptionsExtension
   =optionsBuilder.Options.FindExtension<CoreOptionsExtension>();

  if(Object.ReferenceEquals(coreOptionsExtension,null))
   coreOptionsExtension=new CoreOptionsExtension();

  Debug.Assert(!Object.ReferenceEquals(coreOptionsExtension,null));

  var warningConfiguration
   =coreOptionsExtension.WarningsConfiguration.TryWithExplicit
     (RelationalEventId.AmbientTransactionWarning,
      WarningBehavior.Throw);

  //[2020-10-24] Must be
  Debug.Assert(!Object.ReferenceEquals(warningConfiguration,null));

  coreOptionsExtension
   =coreOptionsExtension.WithWarningsConfiguration(warningConfiguration);

  //[2020-10-24] Must be
  Debug.Assert(!Object.ReferenceEquals(coreOptionsExtension,null));

  Helper__FI_AddOrUpdateExtension
   (optionsBuilder,
    coreOptionsExtension);
 }//Helper__FI_ConfigureWarnings

 //-----------------------------------------------------------------------
 private static void Helper__FI_AddOrUpdateExtension<TExtension>
                                           (IDbContextOptionsBuilderInfrastructure optionsBuilder,
                                            TExtension                             extension)
   where TExtension: class, IDbContextOptionsExtension
 {
  Debug.Assert(!Object.ReferenceEquals(optionsBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(extension,null));

  optionsBuilder.AddOrUpdateExtension(extension);
 }//Helper__FI_AddOrUpdateExtension<TExtension>
};//class LcpiOleDb__Extensions__DbContextOptions

////////////////////////////////////////////////////////////////////////////////
}//namespace Microsoft.EntityFrameworkCore

////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 22.05.2018.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Diagnostics;                                //LoggingDefinitions
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;                                    //IDatabaseProvider
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.EntityFrameworkCore.Migrations;

using Microsoft.Extensions.DependencyInjection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0{
////////////////////////////////////////////////////////////////////////////////

using LcpiOleDb__ISqlTreeNodeBuilder
 =Root.Query.LcpiOleDb__ISqlTreeNodeBuilder;

using LcpiOleDb__IUnaryOperatorTranslatorProvider
 =Root.Query.LcpiOleDb__IUnaryOperatorTranslatorProvider;

using LcpiOleDb__IBinaryOperatorTranslatorProvider
 =Root.Query.LcpiOleDb__IBinaryOperatorTranslatorProvider;

////////////////////////////////////////////////////////////////////////////////
//
// [2020-10-17] Minimal working set of services:
//  - LoggingDefinitions
//  - IDatabaseProvider
//  - ISqlGenerationHelper
//  - IRelationalConnection
//  - IProviderConventionSetBuilder  <---- !!!
//  - IModificationCommandBatchFactory
//  - IUpdateSqlGenerator
//  - IRelationalTypeMappingSource
//  - IRelationalDatabaseCreator [enough stub]
//
////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0__Initializer

static class FB_V03_0_0__Initializer
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_V03_0_0__Initializer;

 //-----------------------------------------------------------------------
 public static void ApplyServices(EntityFrameworkRelationalServicesBuilder builder,
                                  Core.Core_ConnectionOptionsData          cnOptionsData)
 {
  Debug.Assert(!Object.ReferenceEquals(builder,null));
  Debug.Assert(!Object.ReferenceEquals(cnOptionsData,null));

  //----------------------------------------
  var cnInfoCns
   =Core.Core_SvcUtils.QuerySvc<Core.Engines.Dbms.IscBase.IscBase_EngineSvc__ConnectionInfo>
     (cnOptionsData,
      Core.Engines.EngineSvcID.IscBase_EngineSvc__ConnectionInfo);

  Debug.Assert(!Object.ReferenceEquals(cnInfoCns,null));

  //----------------------------------------
   builder
    .TryAdd<IQueryableMethodTranslatingExpressionVisitorFactory, EXT.Microsoft.EntityFrameworkCore.Query.Internal.RelationalQueryableMethodTranslatingExpressionVisitorFactory>()

   /*END*/
   ;

  //---------------------------------------- TOP LAYER [PUBLIC] SERVICES
   builder
    .TryAdd<IRelationalAnnotationProvider                      , DataProvider.LcpiOleDb.MetaData.Internal.LcpiOleDb__AnnotationProvider>()
    .TryAdd<IDatabaseProvider                                  , DatabaseProvider<DataProvider.LcpiOleDb.Infrastructure.LcpiOleDb__DbContextOptionsExtension>>()
    .TryAdd<LoggingDefinitions                                 , DataProvider.LcpiOleDb.Diagnostics.Internal.LcpiOleDb__LoggingDefinitions>()

   /*END*/
   ;

  //---------------------------------------- COMMON SERVICES OF BASEMENT
   builder
    .TryAdd<IRelationalDatabaseCreator                         , Root.Storage.LcpiOleDb__RelationalDatabaseCreator>()
    .TryAdd<IRelationalCommandBuilderFactory                   , Root.Storage.LcpiOleDb__RelationalCommandBuilderFactory>()
    .TryAdd<IRelationalConnection                              , Root.Storage.LcpiOleDb__RelationalConnection>()
    .TryAdd<IMethodCallTranslatorProvider                      , Root.Query.Sql.LcpiOleDb__MethodCallTranslatorProvider>()
    .TryAdd<IMemberTranslatorProvider                          , Root.Query.Sql.LcpiOleDb__MemberTranslatorProvider>()
    .TryAdd<IRelationalSqlTranslatingExpressionVisitorFactory  , Root.Query.ExpressionVisitors.LcpiOleDb__SqlTranslatingExpressionVisitorFactory>()
    .TryAdd<ISqlExpressionFactory                              > (p => p.GetRequiredService<Root.Query.LcpiOleDb__SqlExpressionFactory>())
    .TryAdd<IQueryTranslationPreprocessorFactory               , Root.Query.LcpiOleDb__QueryTranslationPreprocessorFactory>()
    .TryAdd<IRelationalParameterBasedSqlProcessorFactory       , Root.Query.LcpiOleDb__ParameterBasedSqlProcessorFactory>()
    .TryAdd<IQueryCompiler                                     , Root.Query.LcpiOleDb__QueryCompiler>()
    .TryAdd<IModificationCommandFactory                        , Root.Update.LcpiOleDb__ModificationCommandFactory>()

    /*Specific*/
    .TryAdd<LcpiOleDb__ISqlTreeNodeBuilder                     > (p => p.GetRequiredService<Root.Query.LcpiOleDb__SqlExpressionFactory>())

   /*END*/
   ;

  //----------------------------------------
  builder
   .TryAddProviderSpecificServices
     (b=>b.TryAddScoped<Root.Query.LcpiOleDb__SqlExpressionFactory,Root.Query.LcpiOleDb__SqlExpressionFactory>());

  //----------------------------------------
  builder
   .TryAdd<IBatchExecutor                                     , Dbms.Firebird.Common.Update.FB_Common__BatchExecutor>()
   .TryAdd<IQuerySqlGeneratorFactory                          , Dbms.Firebird.Common.Query.Sql.FB_Common__QuerySqlGeneratorFactory>()
   //.TryAdd<IValueGeneratorSelector                            , Dbms.Firebird.ValueGeneration.FB_ValueGeneratorSelector>()
   .TryAdd<IModificationCommandBatchFactory                   , Dbms.Firebird.Common.Update.FB_Common__ModificationCommandBatchFactory>()
   .TryAdd<IUpdateSqlGenerator                                , Dbms.Firebird.Common.Update.FB_Common__UpdateSqlGenerator>()
   .TryAdd<ISqlGenerationHelper                               , Dbms.Firebird.V03_0_0.Storage.FB_V03_0_0__SqlGenerationHelper>()
   .TryAdd<IProviderConventionSetBuilder                      , Dbms.Firebird.V03_0_0.Metadata.Conventions.FB_V03_0_0__ConventionSetBuilder>()
   .TryAdd<IQueryTranslationPostprocessorFactory              , Dbms.Firebird.V03_0_0.Query.FB_V03_0_0__QueryTranslationPostprocessorFactory>()
   .TryAdd<IMigrationsSqlGenerator                            , Dbms.Firebird.V03_0_0.Migrations.FB_V03_0_0__MigrationsSqlGenerator>()
   .TryAdd<IHistoryRepository                                 , Dbms.Firebird.V03_0_0.Migrations.FB_V03_0_0__HistoryRepository>()
   .TryAdd<IModelValidator                                    , Dbms.Firebird.V03_0_0.Infrastructure.FB_V03_0_0__ModelValidator>()

   //.TryAdd<IMigrationsAnnotationProvider    , FbMigrationsAnnotationProvider>()

   /*END*/
   ;

  //----------------------------------------
  //builder
  // .TryAddProviderSpecificServices
  //     (b => b.TryAddScoped    <IFbMigrationSqlGeneratorBehavior           , FbMigrationSqlGeneratorBehavior>()

  //----------------------------------------------------------------------
  switch(cnInfoCns.ConnectionDialect)
  {
   case 1:
   {
    //SVC: Preparation of expression tree for local evaluation
    cnOptionsData.RegService
     (Root.LcpiOleDb__SvcIDs.LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,
      tagDataForD1.Build_LocalSvc__PrepareForLocalEvaluation(cnOptionsData));

    builder
     .TryAddProviderSpecificServices
       (b=>b.TryAddSingleton
            <Dbms.Firebird.V03_0_0.Storage.D1.FB_V03_0_0_D1__TypeMappingSourceForDML,
             Dbms.Firebird.V03_0_0.Storage.D1.FB_V03_0_0_D1__TypeMappingSourceForDML>());

    builder
     .TryAddProviderSpecificServices
       (b=>b.TryAddSingleton
            <Dbms.Firebird.V03_0_0.Storage.D1.FB_V03_0_0_D1__TypeMappingSourceForDDL,
             Dbms.Firebird.V03_0_0.Storage.D1.FB_V03_0_0_D1__TypeMappingSourceForDDL>());

    builder
     .TryAdd
       <Root.Storage.LcpiOleDb__IGetTypeMappingSourceForDDL,
        Dbms.Firebird.V03_0_0.Storage.D1.FB_V03_0_0_D1__GetTypeMappingSourceForDDL>();

    builder
     .TryAdd
       <IRelationalTypeMappingSource>
        (p => p.GetRequiredService<Dbms.Firebird.V03_0_0.Storage.D1.FB_V03_0_0_D1__TypeMappingSourceForDML>());

    builder
     .TryAdd
       <LcpiOleDb__IUnaryOperatorTranslatorProvider,
        Dbms.Firebird.Common.Query.Sql.FB_Common__UnaryOperatorTranslatorProvider
         <Dbms.Firebird.V03_0_0.Query.Sql.D1.FB_V03_0_0__DataFor_UnaryOperatorTranslatorProvider> >();

    builder
    .TryAdd
       <LcpiOleDb__IBinaryOperatorTranslatorProvider,
        Dbms.Firebird.Common.Query.Sql.FB_Common__BinaryOperatorTranslatorProvider
         <Dbms.Firebird.V03_0_0.Query.Sql.D1.FB_V03_0_0__DataFor_BinaryOperatorTranslatorProvider> >();

    cnOptionsData.RegService
     (Root.LcpiOleDb__SvcIDs.LcpiOleDb__SqlSvc__DataFor_MemberTranslatorProvider,
      Dbms.Firebird.V03_0_0.Query.Sql.D1.FB_V03_0_0__DataFor_MemberTranslatorProvider.Instance);

    builder
     .TryAddProviderSpecificServices
       (b=>b.TryAddSingleton(Dbms.Firebird.V03_0_0.Query.Sql.D1.FB_V03_0_0__QuerySqlPartGenerator__Parameter.Instance));

    cnOptionsData.RegService
     (Root.LcpiOleDb__SvcIDs.LcpiOleDb__SqlSvc__DataFor_MethodCallTranslatorProvider,
      Dbms.Firebird.V03_0_0.Query.Sql.D1.FB_V03_0_0__DataFor_MethodCallTranslatorProvider.Instance);

    cnOptionsData.RegService
     (FB_V03_0_0__SvcIDs.FB_V03_0_0__MigrationsSvc__GenerateCreateSequence,
      Dbms.Firebird.V03_0_0.Migrations.D1.Internal.SvcImpls.FB_V03_0_0__MigrationsSvcImpl__GenerateCreateSequence.Instance);

    cnOptionsData.RegService
     (FB_V03_0_0__SvcIDs.FB_V03_0_0__MigrationsSvc__GenerateRestartSequence,
      Dbms.Firebird.V03_0_0.Migrations.D1.Internal.SvcImpls.FB_V03_0_0__MigrationsSvcImpl__GenerateRestartSequence.Instance);

    cnOptionsData.RegService
     (FB_V03_0_0__SvcIDs.FB_V03_0_0__MigrationsSvc__GenerateAlterSequence,
      Dbms.Firebird.V03_0_0.Migrations.D1.Internal.SvcImpls.FB_V03_0_0__MigrationsSvcImpl__GenerateAlterSequence.Instance);

    break;
   }//case 1

   case 2:
   {
    //SVC: Preparation of expression tree for local evaluation
    cnOptionsData.RegService
     (Root.LcpiOleDb__SvcIDs.LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,
      tagDataForD2.Build_LocalSvc__PrepareForLocalEvaluation(cnOptionsData));

    builder
     .TryAddProviderSpecificServices
       (b=>b.TryAddSingleton
            <Dbms.Firebird.V03_0_0.Storage.D2.FB_V03_0_0_D2__TypeMappingSourceForDML,
             Dbms.Firebird.V03_0_0.Storage.D2.FB_V03_0_0_D2__TypeMappingSourceForDML>());

    builder
     .TryAddProviderSpecificServices
       (b=>b.TryAddSingleton
            <Dbms.Firebird.V03_0_0.Storage.D2.FB_V03_0_0_D2__TypeMappingSourceForDDL,
             Dbms.Firebird.V03_0_0.Storage.D2.FB_V03_0_0_D2__TypeMappingSourceForDDL>());

    builder
     .TryAdd
       <Root.Storage.LcpiOleDb__IGetTypeMappingSourceForDDL,
        Dbms.Firebird.V03_0_0.Storage.D2.FB_V03_0_0_D2__GetTypeMappingSourceForDDL>();

    builder
     .TryAdd
       <IRelationalTypeMappingSource>
        (p => p.GetRequiredService<Dbms.Firebird.V03_0_0.Storage.D2.FB_V03_0_0_D2__TypeMappingSourceForDML>());

    builder
     .TryAdd
       <LcpiOleDb__IUnaryOperatorTranslatorProvider,
        Dbms.Firebird.Common.Query.Sql.FB_Common__UnaryOperatorTranslatorProvider
         <Dbms.Firebird.V03_0_0.Query.Sql.D2.FB_V03_0_0__DataFor_UnaryOperatorTranslatorProvider> >();

    builder
     .TryAdd
       <LcpiOleDb__IBinaryOperatorTranslatorProvider,
        Dbms.Firebird.Common.Query.Sql.FB_Common__BinaryOperatorTranslatorProvider
         <Dbms.Firebird.V03_0_0.Query.Sql.D3.FB_V03_0_0__DataFor_BinaryOperatorTranslatorProvider> >();

    cnOptionsData.RegService
     (Root.LcpiOleDb__SvcIDs.LcpiOleDb__SqlSvc__DataFor_MemberTranslatorProvider,
      Dbms.Firebird.V03_0_0.Query.Sql.D1.FB_V03_0_0__DataFor_MemberTranslatorProvider.Instance);

    builder
     .TryAddProviderSpecificServices
       (b=>b.TryAddSingleton(Dbms.Firebird.V03_0_0.Query.Sql.D2.FB_V03_0_0__QuerySqlPartGenerator__Parameter.Instance));

    cnOptionsData.RegService
     (Root.LcpiOleDb__SvcIDs.LcpiOleDb__SqlSvc__DataFor_MethodCallTranslatorProvider,
      Dbms.Firebird.V03_0_0.Query.Sql.D3.FB_V03_0_0__DataFor_MethodCallTranslatorProvider.Instance);

    cnOptionsData.RegService
     (FB_V03_0_0__SvcIDs.FB_V03_0_0__MigrationsSvc__GenerateCreateSequence,
      Dbms.Firebird.V03_0_0.Migrations.D3.Internal.SvcImpls.FB_V03_0_0__MigrationsSvcImpl__GenerateCreateSequence.Instance);

    cnOptionsData.RegService
     (FB_V03_0_0__SvcIDs.FB_V03_0_0__MigrationsSvc__GenerateRestartSequence,
      Dbms.Firebird.V03_0_0.Migrations.D3.Internal.SvcImpls.FB_V03_0_0__MigrationsSvcImpl__GenerateRestartSequence.Instance);

    cnOptionsData.RegService
     (FB_V03_0_0__SvcIDs.FB_V03_0_0__MigrationsSvc__GenerateAlterSequence,
      Dbms.Firebird.V03_0_0.Migrations.D3.Internal.SvcImpls.FB_V03_0_0__MigrationsSvcImpl__GenerateAlterSequence.Instance);

    break;
   }//case 2

   case 3:
   {
    //SVC: Preparation of expression tree for local evaluation
    cnOptionsData.RegService
     (Root.LcpiOleDb__SvcIDs.LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,
      tagDataForD3.Build_LocalSvc__PrepareForLocalEvaluation(cnOptionsData));

    builder
     .TryAddProviderSpecificServices
       (b=>b.TryAddSingleton
            <Dbms.Firebird.V03_0_0.Storage.D3.FB_V03_0_0_D3__TypeMappingSource,
             Dbms.Firebird.V03_0_0.Storage.D3.FB_V03_0_0_D3__TypeMappingSource>());

    builder
     .TryAdd
       <Root.Storage.LcpiOleDb__IGetTypeMappingSourceForDDL,
        Dbms.Firebird.V03_0_0.Storage.D3.FB_V03_0_0_D3__GetTypeMappingSourceForDDL>();

    builder
     .TryAdd
       <IRelationalTypeMappingSource>
        (p => p.GetRequiredService<Dbms.Firebird.V03_0_0.Storage.D3.FB_V03_0_0_D3__TypeMappingSource>());

    builder
     .TryAdd
       <LcpiOleDb__IUnaryOperatorTranslatorProvider,
        Dbms.Firebird.Common.Query.Sql.FB_Common__UnaryOperatorTranslatorProvider
         <Dbms.Firebird.V03_0_0.Query.Sql.D3.FB_V03_0_0__DataFor_UnaryOperatorTranslatorProvider> >();

    builder
     .TryAdd
       <LcpiOleDb__IBinaryOperatorTranslatorProvider,
        Dbms.Firebird.Common.Query.Sql.FB_Common__BinaryOperatorTranslatorProvider
         <Dbms.Firebird.V03_0_0.Query.Sql.D3.FB_V03_0_0__DataFor_BinaryOperatorTranslatorProvider> >();

    cnOptionsData.RegService
     (Root.LcpiOleDb__SvcIDs.LcpiOleDb__SqlSvc__DataFor_MemberTranslatorProvider,
      Dbms.Firebird.V03_0_0.Query.Sql.D3.FB_V03_0_0__DataFor_MemberTranslatorProvider.Instance);

    builder
     .TryAddProviderSpecificServices
       (b=>b.TryAddSingleton(Dbms.Firebird.V03_0_0.Query.Sql.D3.FB_V03_0_0__QuerySqlPartGenerator__Parameter.Instance));

    cnOptionsData.RegService
     (Root.LcpiOleDb__SvcIDs.LcpiOleDb__SqlSvc__DataFor_MethodCallTranslatorProvider,
      Dbms.Firebird.V03_0_0.Query.Sql.D3.FB_V03_0_0__DataFor_MethodCallTranslatorProvider.Instance);

    cnOptionsData.RegService
     (FB_V03_0_0__SvcIDs.FB_V03_0_0__MigrationsSvc__GenerateCreateSequence,
      Dbms.Firebird.V03_0_0.Migrations.D3.Internal.SvcImpls.FB_V03_0_0__MigrationsSvcImpl__GenerateCreateSequence.Instance);

    cnOptionsData.RegService
     (FB_V03_0_0__SvcIDs.FB_V03_0_0__MigrationsSvc__GenerateRestartSequence,
      Dbms.Firebird.V03_0_0.Migrations.D3.Internal.SvcImpls.FB_V03_0_0__MigrationsSvcImpl__GenerateRestartSequence.Instance);

    cnOptionsData.RegService
     (FB_V03_0_0__SvcIDs.FB_V03_0_0__MigrationsSvc__GenerateAlterSequence,
      Dbms.Firebird.V03_0_0.Migrations.D3.Internal.SvcImpls.FB_V03_0_0__MigrationsSvcImpl__GenerateAlterSequence.Instance);

    break;
   }//case 3

   default:
   {
    ThrowError.UnsupportedConnectionDialect
     (c_ErrSrcID,
      cnInfoCns.ConnectionDialect);

    break;
   }//default
  }//switch cnInfoCns.ConnectionDialect

  //----------------------------------------------------------------------
  builder
   .TryAddCoreServices();
 }//ApplyServices

 //private data [D1] -----------------------------------------------------
 private static class tagDataForD1
 {
  private static readonly Root.Query.Local.LcpiOleDb__LocalEval_Services
   sm_ExpressionServices
    =Root.Query.Local.LcpiOleDb__LocalEval_Services.Create
      (Core.Engines.Dbms.Firebird.Common.FB_Common__TextServices.Instance,
       Query.Local.D1.Expressions.FB_Data__Expressions_Local__Converts.Data,                 // <---- D1
       Query.Local.D0.Expressions.FB_Data__Expressions_Local__Translators_Unary.Data,
       Query.Local.D1.Expressions.FB_Data__Expressions_Local__Op2__V_V.Data,                 // <---- D1
       Query.Local.D0.Expressions.FB_Data__Expressions_Local__Translators_MethodCalls.Data);

  //------------------------------------------------------------
  public static Root.Query.Local.Svcs.LcpiOleDb__LocalSvc__PrepareForLocalEvaluation
   Build_LocalSvc__PrepareForLocalEvaluation(Core.Core_ConnectionOptionsData cnData)
   {
    Debug.Assert(!Object.ReferenceEquals(cnData,null));

    return new Root.Query.Local.Svcs.LcpiOleDb__LocalSvc__PrepareForLocalEvaluation
      (sm_ExpressionServices,
       Query.Local.D0.Expressions.FB_Data__Expressions_Local__Translators_Members.Data,
       cnData.DbContextOptions.ExecutionOfUnknownMethods);
   }//Build_LocalSvc__PrepareForLocalEvaluation
 };//class tagDataForD1

 //private data [D2] -----------------------------------------------------
 private static class tagDataForD2
 {
  private static readonly Root.Query.Local.LcpiOleDb__LocalEval_Services
   sm_ExpressionServices
    =Root.Query.Local.LcpiOleDb__LocalEval_Services.Create
      (Core.Engines.Dbms.Firebird.Common.FB_Common__TextServices.Instance,
       Query.Local.D3.Expressions.FB_Data__Expressions_Local__Converts.Data,                 // <---- D3
       Query.Local.D0.Expressions.FB_Data__Expressions_Local__Translators_Unary.Data,
       Query.Local.D3.Expressions.FB_Data__Expressions_Local__Op2__V_V.Data,                 // <---- D3
       Query.Local.D0.Expressions.FB_Data__Expressions_Local__Translators_MethodCalls.Data);

  //------------------------------------------------------------
  public static Root.Query.Local.Svcs.LcpiOleDb__LocalSvc__PrepareForLocalEvaluation
   Build_LocalSvc__PrepareForLocalEvaluation(Core.Core_ConnectionOptionsData cnData)
   {
    Debug.Assert(!Object.ReferenceEquals(cnData,null));

    return new Root.Query.Local.Svcs.LcpiOleDb__LocalSvc__PrepareForLocalEvaluation
      (sm_ExpressionServices,
       Query.Local.D0.Expressions.FB_Data__Expressions_Local__Translators_Members.Data,
       cnData.DbContextOptions.ExecutionOfUnknownMethods);
   }//Build_LocalSvc__PrepareForLocalEvaluation
 };//class tagDataForD2

 //private data [D3] -----------------------------------------------------
 private static class tagDataForD3
 {
  private static readonly Root.Query.Local.LcpiOleDb__LocalEval_Services
   sm_ExpressionServices
    =Root.Query.Local.LcpiOleDb__LocalEval_Services.Create
      (Core.Engines.Dbms.Firebird.Common.FB_Common__TextServices.Instance,
       Query.Local.D3.Expressions.FB_Data__Expressions_Local__Converts.Data,                 // <---- D3
       Query.Local.D0.Expressions.FB_Data__Expressions_Local__Translators_Unary.Data,
       Query.Local.D3.Expressions.FB_Data__Expressions_Local__Op2__V_V.Data,                 // <---- D3
       Query.Local.D0.Expressions.FB_Data__Expressions_Local__Translators_MethodCalls.Data);

  //------------------------------------------------------------
  public static Root.Query.Local.Svcs.LcpiOleDb__LocalSvc__PrepareForLocalEvaluation
   Build_LocalSvc__PrepareForLocalEvaluation(Core.Core_ConnectionOptionsData cnData)
   {
    Debug.Assert(!Object.ReferenceEquals(cnData,null));

    return new Root.Query.Local.Svcs.LcpiOleDb__LocalSvc__PrepareForLocalEvaluation
      (sm_ExpressionServices,
       Query.Local.D0.Expressions.FB_Data__Expressions_Local__Translators_Members.Data,
       cnData.DbContextOptions.ExecutionOfUnknownMethods);
   }//Build_LocalSvc__PrepareForLocalEvaluation
 };//class tagDataForD3
};//class FB_V03_0_0__Initializer

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0

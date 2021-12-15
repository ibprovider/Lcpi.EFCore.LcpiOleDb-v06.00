////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 24.11.2021.
using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Infrastructure{
////////////////////////////////////////////////////////////////////////////////
//using

using T_VALIDATOR_LOGGER
 =IDiagnosticsLogger<DbLoggerCategory.Model.Validation>;

////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0__ModelValidator

sealed class FB_V03_0_0__ModelValidator:RelationalModelValidator
{
 const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Basement_EF_Dbms_Firebird_V03_0_0_Infrastructure___FB_V03_0_0__ModelValidator;

 //-----------------------------------------------------------------------
 public FB_V03_0_0__ModelValidator(ModelValidatorDependencies           dependencies,
                                   RelationalModelValidatorDependencies relationalDependencies)
  :base(dependencies,relationalDependencies)
 {
 }

 //RelationalModelValidator interface ------------------------------------
 public override void Validate(IModel             model,
                               T_VALIDATOR_LOGGER logger)
 {
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Validate),
    nameof(model),
    model);

  //--------------------------------------------------
  base.Validate(model,logger);

  Helper__ValidateEntities
   (model,
    logger);
 }//Validate

 //Helper methods --------------------------------------------------------
 private static void Helper__ValidateEntities
                            (IReadOnlyModel     model,
                             T_VALIDATOR_LOGGER logger)
 {
  Debug.Assert(!Object.ReferenceEquals(model,null));

  foreach(var entity in model.GetEntityTypes())
  {
   Debug.Assert(!Object.ReferenceEquals(entity,null));

   Helper__CheckEntity
    (entity,
     logger);
  }//foreach entity
 }//Helper__ValidateEntities

 //-----------------------------------------------------------------------
 private static void Helper__CheckEntity
                            (IReadOnlyEntityType entity,
                             T_VALIDATOR_LOGGER  logger)
 {
  Debug.Assert(!Object.ReferenceEquals(entity,null));

  try
  {
   Helper__CheckEntitySchema
    (entity,
     logger);

   foreach(var property in entity.GetProperties())
   {
    Debug.Assert(!Object.ReferenceEquals(property,null));

    //-----------------------
    Helper__CheckEntityProperty
     (entity,
      property,
      logger);
   }//foreach property
  }
  catch(Exception e)
  {
   var exc
    =new LcpiOleDb__DataToolException
      (e);

   exc.add_error
    (lcpi.lib.com.HResultCode.E_FAIL,
     c_ErrSrcID,
     ErrMessageID.validation_err__failed_to_entity_validation_1);

   exc
    .push(entity.DisplayName())
    .raise();
  }//catch
 }//Helper__CheckEntity

 //-----------------------------------------------------------------------
 private static void Helper__CheckEntitySchema
                            (IReadOnlyEntityType entity,
                             T_VALIDATOR_LOGGER  logger)
 {
  Debug.Assert(!Object.ReferenceEquals(entity,null));

  var schemaName
   =entity.GetSchema();

  if(!Object.ReferenceEquals(schemaName,null))
  {
   ThrowError.DbmsErr__FB__FirebirdDoesNotSupportSchemas
    (c_ErrSrcID);
  }//if
 }//Helper__CheckEntitySchema

 //-----------------------------------------------------------------------
 private static void Helper__CheckEntityProperty
                            (IReadOnlyEntityType entity,
                             IReadOnlyProperty   property,
                             T_VALIDATOR_LOGGER  logger)
 {
  Debug.Assert(!Object.ReferenceEquals(entity,null));
  Debug.Assert(!Object.ReferenceEquals(property,null));

  try
  {
   Helper__CheckValueGenerationStrategy
    (property,
     logger);
  }
  catch(Exception e)
  {
   var exc
    =new LcpiOleDb__DataToolException
      (e);

   exc.add_error
    (lcpi.lib.com.HResultCode.E_FAIL,
     c_ErrSrcID,
     ErrMessageID.validation_err__failed_to_entity_property_validation_2);

   exc
    .push(entity.DisplayName())
    .push(property.Name)
    .raise();
  }//catch
 }//Helper__CheckEntityProperty

 //-----------------------------------------------------------------------
 private static void Helper__CheckValueGenerationStrategy
                            (IReadOnlyProperty  property,
                             T_VALIDATOR_LOGGER logger)
 {
  Debug.Assert(!Object.ReferenceEquals(property,null));

  property.Internal__CheckValueGenerationStrategy();
 }//Helper__CheckValueGenerationStrategy
};//class FB_V03_0_0__ModelValidator

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Infrastructure

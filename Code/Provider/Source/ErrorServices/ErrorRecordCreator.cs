////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 06.10.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Metadata;

using com_lib=lcpi.lib.com;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb{
////////////////////////////////////////////////////////////////////////////////
//class ErrorRecordCreator

static class ErrorRecordCreator
{
 public static Core.Core_ExceptionRecord
  MSqlGenErr__IdentityColumnCantBeCreatedWithRequiredDataType
                                           (ErrSourceID errSrcID,
                                            System.Type clrType,
                                            string      sqlType)
 {
  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.msql_gen_err__identity_column_cant_be_created_with_required_data_type__2);

  errRec
   .push_iif(clrType,ErrMessageID.text__not_avail__tag_style)
   .push_iif(sqlType,ErrMessageID.text__not_avail__tag_style);
  
  return errRec;
 }//MSqlGenErr__IdentityColumnCantBeCreatedWithRequiredDataType

 //-----------------------------------------------------------------------
 public static Core.Core_ExceptionRecord
  MSqlGenErr__IdentityColumnCantHasDefaultValue
                                           (ErrSourceID errSrcID)
 {
  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.msql_gen_err__identity_column_cant_be_has_default_value__0);

  return errRec;
 }//MSqlGenErr__IdentityColumnCantHasDefaultValue

 //-----------------------------------------------------------------------
 public static Core.Core_ExceptionRecord
  MSqlGenErr__IdentityColumnCantBeNullable(ErrSourceID errSrcID)
 {
  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.msql_gen_err__identity_column_cant_be_nullable__0);

  return errRec;
 }//MSqlGenErr__IdentityColumnCantBeNullable

 //-----------------------------------------------------------------------
 public static Core.Core_ExceptionRecord
  MSqlGenErr__UnexpectedClrTypeOfSequence(ErrSourceID             errSrcID,
                                          CreateSequenceOperation operation,
                                          System.Type             expectedClrType)
 {
  Debug.Assert(!Object.ReferenceEquals(operation,null));
  Debug.Assert(!string.IsNullOrEmpty(operation.Name));
  Debug.Assert(!Object.ReferenceEquals(expectedClrType,null));

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.msql_gen_err__unexpected_sequence_ClrType__3);

  errRec
   .push(operation.Name)
   .push(operation.ClrType)
   .push(expectedClrType);

  return errRec;
 }//MSqlGenErr__UnexpectedClrTypeOfSequence

 //-----------------------------------------------------------------------
 public static Core.Core_ExceptionRecord
  MSqlGenErr__IncorrectStartValueOfSequence(ErrSourceID             errSrcID,
                                            string                  sequenceName,
                                            long                    actualStartValue,
                                            long                    minStartValue,
                                            long                    maxStartValue)
 {
  Debug.Assert(!string.IsNullOrEmpty(sequenceName));

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.msql_gen_err__incorrect_sequence_start_value__4);

  errRec
   .push(sequenceName)
   .push(actualStartValue)
   .push(minStartValue)
   .push(maxStartValue);

  return errRec;
 }//MSqlGenErr__IncorrectStartValueOfSequence

 //-----------------------------------------------------------------------
 public static Core.Core_ExceptionRecord
  TypeMappingErr__MultipleDefinitionOfTypeProperty
                                           (ErrSourceID errSrcID,
                                            string      propertyName,
                                            object      propertyValue1,
                                            object      propertyValue2)
 {
  Debug.Assert(!Object.ReferenceEquals(propertyName,null));
  Debug.Assert(propertyName.Length>0);
  Debug.Assert(propertyName.Trim()==propertyName);

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.type_mapping_err__multiple_definition_of_type_property_3);

  errRec
   .push(propertyName)
   .push_object(propertyValue1)
   .push_object(propertyValue2);

  return errRec;
 }//TypeMappingErr__MultipleDefinitionOfTypeProperty

 //-----------------------------------------------------------------------
 public static Core.Core_ExceptionRecord
  TypeMappingErr__BadDataTypeDefinition(ErrSourceID errSrcID,
                                        string      dataTypeSign)
 {
  Debug.Assert(!string.IsNullOrEmpty(dataTypeSign));

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.type_mapping_err__bad_datatype_definition_1);

  errRec
   .push(dataTypeSign);

  return errRec;
 }//TypeMappingErr__BadDataTypeDefinition

 //-----------------------------------------------------------------------
 public static Core.Core_ExceptionRecord
  CommonErr__EntityPropertyHasConflictOfValueGenerationStrategies
                                           (ErrSourceID       errSrcID,
                                            IReadOnlyProperty property,
                                            string            firstVGS,
                                            string            secondVGS)
 {
  Debug.Assert(!Object.ReferenceEquals(property,null));
  Debug.Assert(!string.IsNullOrEmpty(firstVGS));
  Debug.Assert(!string.IsNullOrEmpty(secondVGS));

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.common_err__entity_property_has_conflict_of_value_generation_strategies__4);

  errRec
   .push(property.DeclaringEntityType.DisplayName())
   .push(property.Name)
   .push(firstVGS)
   .push(secondVGS);

  return errRec;
 }//CommonErr__EntityPropertyHasConflictOfValueGenerationStrategies

 //-----------------------------------------------------------------------
 public static Core.Core_ExceptionRecord
  DbmsErr__FB__FirebirdDoesNotSupportNonCyclicSequence
                                           (ErrSourceID errSrcID,
                                            string      sequenceName)
 {
  Debug.Assert(!string.IsNullOrEmpty(sequenceName));

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.DB_E_NOTSUPPORTED,
      errSrcID,
      ErrMessageID.dbms_err__fb__firebird_does_not_support_non_cyclic_sequence__1);

  errRec
   .push(sequenceName);
  
  return errRec;
 }//DbmsErr__FB__FirebirdDoesNotSupportNonCyclicSequence

 //-----------------------------------------------------------------------
 public static Core.Core_ExceptionRecord
  DbmsErr__FB__FirebirdDoesNotSupportConfigurationBoundValueOfSequence
                                           (ErrSourceID errSrcID,
                                            string      boundName,
                                            string      sequenceName,
                                            long        allowedValue)
 {
  Debug.Assert(!string.IsNullOrEmpty(boundName));
  Debug.Assert(!string.IsNullOrEmpty(sequenceName));

  var errRec
   =new Core.Core_ExceptionRecord
     (com_lib.HResultCode.DB_E_NOTSUPPORTED,
      errSrcID,
      ErrMessageID.dbms_err__fb__firebird_does_not_support_configuration_of_sequence_bound_value__3);

  errRec
   .push(boundName)
   .push(sequenceName)
   .push(allowedValue);
  
  return errRec;
 }//DbmsErr__FB__FirebirdDoesNotSupportConfigurationBoundValueOfSequence
};//class ErrorRecordCreator

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb

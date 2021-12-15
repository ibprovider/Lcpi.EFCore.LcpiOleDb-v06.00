////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 09.11.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Migrations{
////////////////////////////////////////////////////////////////////////////////

using LcpiOleDb__AnnotationNames
 =DataProvider.LcpiOleDb.MetaData.Internal.LcpiOleDb__AnnotationNames;

using LcpiOleDb__AnnotationData__VGS
 =DataProvider.LcpiOleDb.MetaData.LcpiOleDb__AnnotationData__ValueGenerationStrategy;

using LcpiOleDb__AnnotationData__VGS_s
 =Structure.Structure_ValueWithNull
   <DataProvider.LcpiOleDb.MetaData.LcpiOleDb__AnnotationData__ValueGenerationStrategy>;

using LcpiOleDb__AnnotationData__VGS_IdentityByDefaultColumn
 =DataProvider.LcpiOleDb.MetaData.LcpiOleDb__AnnotationData__ValueGenerationStrategy_IdentityByDefaultColumn;

using LcpiOleDb__AnnotationData__VGS_SequenceTrigger
 =DataProvider.LcpiOleDb.MetaData.LcpiOleDb__AnnotationData__ValueGenerationStrategy_SequenceTrigger;

////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0__MigrationsSqlGenerator

partial class FB_V03_0_0__MigrationsSqlGenerator
{
 //MigrationsSqlGenerator interface --------------------------------------

 protected override void Generate
                            (AlterColumnOperation        operation,
                             IModel                      model,
                             MigrationCommandListBuilder builder)
 {
  const string c_methodSign
   =nameof(Generate)+"("+nameof(AlterColumnOperation)+"...)";

  //----------------------------------------------------------------------
  Check.Arg_NotNull
  (c_ErrSrcID,
   c_methodSign,
   nameof(operation),
   operation);

  //-------------------------
  Check.Arg_IsNull
  (c_ErrSrcID,
   c_methodSign,
   "operation.Schema",
   operation.Schema);

  Check.Arg_NotNullAndNotEmpty
   (c_ErrSrcID,
    c_methodSign,
    "operation.Table",
    operation.Table);

  Check.Arg_NotNullAndNotEmpty
   (c_ErrSrcID,
    c_methodSign,
    "operation.Name",
    operation.Name);

  //-------------------------
  Check.Arg_NotNull
  (c_ErrSrcID,
   c_methodSign,
   "operation.OldColumn",
   operation.OldColumn);

  Check.Arg_IsNull
  (c_ErrSrcID,
   c_methodSign,
   "operation.OldColumn.Schema",
   operation.OldColumn.Schema);

  Check.Arg_NotNullAndNotEmpty
  (c_ErrSrcID,
   c_methodSign,
   "operation.OldColumn.Table",
   operation.OldColumn.Table);

  Check.Arg_NotNullAndNotEmpty
  (c_ErrSrcID,
   c_methodSign,
   "operation.OldColumn.Name",
   operation.OldColumn.Name);

  //-------------------------
  if(!System.StringComparer.Ordinal.Equals(operation.Table,operation.OldColumn.Table))
  {
   //ERROR - inconsistent operation data

   ThrowError.MSqlGenErr__InconsistentTableNamesInAlterColumnOperation
    (c_ErrSrcID,
     operation.OldColumn.Table,
     operation.Table);
  }//if

  //-------------------------
  Check.Arg_NotNull
  (c_ErrSrcID,
   c_methodSign,
   nameof(builder),
   builder);

  //-------------------------
  try // [catch]
  {
   var operationPlan
    =Helper__BuildAlterColumnPlan
      (operation,
       model);

   //-------------------------------------------------- DROP VGS_SequenceTrigger
   if(!Object.ReferenceEquals(operationPlan.operationsForVGS.RemoveOp__VGS_SequenceTrigger,null))
   {
    Helper__DropSequenceTriggerForColumn
     (operationPlan.operationsForVGS.RemoveOp__VGS_SequenceTrigger,
      builder);
   }//if

   //-------------------------------------------------- RENAME COLUMN
   if(operationPlan.RenameOp__ColumnName)
   {
    builder.Append("ALTER TABLE ");
    builder.Append(this.Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Table));
    builder.Append(" ALTER COLUMN ");
    builder.Append(this.Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.OldColumn.Name));
    builder.Append(" TO ");
    builder.Append(this.Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Name));

    Helper__TerminateStatement(builder);
   }//if RenameOp__ColumnName

   //-------------------------------------------------- DROP NOT NULL
   if(operationPlan.RemoveOp__NOT_NULL)
   {
    builder.Append("ALTER TABLE ");
    builder.Append(this.Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Table));
    builder.Append(" ALTER COLUMN ");
    builder.Append(this.Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Name));
    builder.Append(" DROP NOT NULL");

    Helper__TerminateStatement(builder);
   }//if RemoveOp__DefaultValue

   //-------------------------------------------------- DROP DEFAULT
   if(operationPlan.RemoveOp__DefaultValue)
   {
    builder.Append("ALTER TABLE ");
    builder.Append(this.Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Table));
    builder.Append(" ALTER COLUMN ");
    builder.Append(this.Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Name));
    builder.Append(" DROP DEFAULT");

    Helper__TerminateStatement(builder);
   }//if RemoveOp__DefaultValue

   //-------------------------------------------------- NEW TYPE
   if(!Object.ReferenceEquals(operationPlan.newColumnTypeMapping,null))
   {
    builder.Append("ALTER TABLE ");
    builder.Append(this.Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Table));
    builder.Append(" ALTER COLUMN ");
    builder.Append(this.Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Name));
    builder.Append(" TYPE ");
    builder.Append(operationPlan.newColumnTypeMapping.StoreType);

    Helper__TerminateStatement(builder);
   }//if

   //-------------------------------------------------- SET DEFAULT
   if(operationPlan.AddOp__DefaultValue)
   {
    builder.Append("ALTER TABLE ");
    builder.Append(this.Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Table));
    builder.Append(" ALTER COLUMN ");
    builder.Append(this.Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Name));
    builder.Append(" SET");

    Helper__GenerateSQL_DefaultValue
     (builder,
      operationPlan.newDefaultValueLiteral);

    Helper__TerminateStatement(builder);
   }//if AddOp__DefaultValue

   //-------------------------------------------------- SET NOT NULL
   if(operationPlan.AddOp__NOT_NULL)
   {
    builder.Append("ALTER TABLE ");
    builder.Append(this.Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Table));
    builder.Append(" ALTER COLUMN ");
    builder.Append(this.Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Name));
    builder.Append(" SET NOT NULL");

    Helper__TerminateStatement(builder);
   }//if AddOp__NOT_NULL

   //-------------------------------------------------- CREATE VGS_SequenceTrigger
   if(!Object.ReferenceEquals(operationPlan.operationsForVGS.AddOp__VGS_SequenceTrigger,null))
   {
    Helper__CreateSequenceTriggerForColumn
     (operation.Table,
      operation.Name,
      operationPlan.operationsForVGS.AddOp__VGS_SequenceTrigger,
      builder);
   }//if
  }
  catch(Exception e)
  {
   var exc
    =new LcpiOleDb__DataToolException(e);

   exc.add_error
    (lcpi.lib.com.HResultCode.E_FAIL,
     c_ErrSrcID,
     ErrMessageID.msql_gen_err__failed_to_generate_alter_column_statement__3);

   exc
    .push(operation.Table)
    .push(operation.Name)
    .push(operation.OldColumn.Name)
    .raise();
  }//catch
 }//Generate - AlterColumnOperation

 //Helper methods --------------------------------------------------------
 private tagAlterColumnPlan Helper__BuildAlterColumnPlan
                            (AlterColumnOperation operation,
                             IModel               model)
 {
  Debug.Assert(!Object.ReferenceEquals(operation,null));
  Debug.Assert(!Object.ReferenceEquals(operation.OldColumn,null));

  tagAlterColumnPlan operationPlan;

  //---------------------------------------------------------------------- COLUMN NAME
  Helper__BuildAlterColumnPlan__TestColumnName
   (operation,
    out operationPlan.RenameOp__ColumnName);

  //---------------------------------------------------------------------- TYPE
  var oldColumnTypeMapping
   =Helper__GetColumnTypeMapping
     (operation.OldColumn.Schema,
      operation.OldColumn.Table,
      operation.OldColumn.Name,
      operation.OldColumn,
      model);

  Debug.Assert(!Object.ReferenceEquals(oldColumnTypeMapping,null));

  var newColumnTypeMapping
   =Helper__GetColumnTypeMapping
     (operation.Schema,
      operation.Table,
      operation.Name,
      operation,
      model);

  Debug.Assert(!Object.ReferenceEquals(newColumnTypeMapping,null));

  Helper__BuildAlterColumnPlan__TestColumnType
   (oldColumnTypeMapping,
    newColumnTypeMapping,
    out operationPlan.newColumnTypeMapping);

  //---------------------------------------------------------------------- DEFAULT
  Helper__BuildAlterColumnPlan__TestDefaultValue
   (operation,
    out operationPlan.RemoveOp__DefaultValue,
    out operationPlan.AddOp__DefaultValue,
    out operationPlan.newDefaultValueLiteral);

  //---------------------------------------------------------------------- NOT NULL
  Helper__BuildAlterColumnPlan__TestIsNullable
   (operation,
    out operationPlan.RemoveOp__NOT_NULL,
    out operationPlan.AddOp__NOT_NULL);

  //-------------------------------------------------- Test Annotations
  tagColumnAnnotations
   oldAnnotations
    =Helper__GetColumnAnnotations
      (operation.OldColumn);

  tagColumnAnnotations
   newAnnotations
    =Helper__GetColumnAnnotations
      (operation);

  Helper__BuildAlterColumnPlan__TestVGS
   (operation,
    oldAnnotations.ValueGenerationStrategy,
    newAnnotations.ValueGenerationStrategy,
    newColumnTypeMapping,
    out operationPlan.operationsForVGS);

  //---------------------------------------------------------------------- DONE
  return operationPlan;
 }//Helper__BuildAlterColumnPlan

 //-----------------------------------------------------------------------
 private void Helper__BuildAlterColumnPlan__TestColumnName
                            (AlterColumnOperation operation,
                             out bool             resultPlan_renameColumn)
 {
  Debug.Assert(!Object.ReferenceEquals(operation,null));
  Debug.Assert(!Object.ReferenceEquals(operation.Name,null));
  Debug.Assert(!Object.ReferenceEquals(operation.OldColumn,null));
  Debug.Assert(!Object.ReferenceEquals(operation.OldColumn.Name,null));

  if(System.StringComparer.Ordinal.Equals(operation.Name,operation.OldColumn.Name))
  {
   resultPlan_renameColumn=false;
  }
  else
  {
   resultPlan_renameColumn=true;
  }//else
 }//Helper__BuildAlterColumnPlan__TestColumnName

 //-----------------------------------------------------------------------
 private void Helper__BuildAlterColumnPlan__TestColumnType
                            (RelationalTypeMapping      oldColumnTypeMapping,
                             RelationalTypeMapping      newColumnTypeMapping,
                             out RelationalTypeMapping  resultPlan_newColumnTypeMapping)
 {
  Debug.Assert(!Object.ReferenceEquals(oldColumnTypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(newColumnTypeMapping,null));

  if(oldColumnTypeMapping.StoreType!=newColumnTypeMapping.StoreType)
  {
   resultPlan_newColumnTypeMapping=newColumnTypeMapping;
  }
  else
  {
   resultPlan_newColumnTypeMapping=null;
  }//else
 }//Helper__BuildAlterColumnPlan__TestColumnType

 //-----------------------------------------------------------------------
 private void Helper__BuildAlterColumnPlan__TestDefaultValue
                            (AlterColumnOperation operation,
                             out bool             resultPlan_removeOld,
                             out bool             resultPlan_addNew,
                             out string           resultPlan_newDefaultValueLiteral)
 {
  Debug.Assert(!Object.ReferenceEquals(operation,null));
  Debug.Assert(!Object.ReferenceEquals(operation.OldColumn,null));

  string newDefaultValue
   =Helper__PrepareDefaultValue
     (operation.DefaultValue,
      operation.DefaultValueSql);

  string oldDefaultValue
   =Helper__PrepareDefaultValue
     (operation.OldColumn.DefaultValue,
      operation.OldColumn.DefaultValueSql);

  if(Object.ReferenceEquals(oldDefaultValue,null))
  {
   resultPlan_removeOld=false;

   if(Object.ReferenceEquals(newDefaultValue,null))
   {
    resultPlan_addNew=false;

    resultPlan_newDefaultValueLiteral=null;
   }
   else
   {
    resultPlan_addNew=true;

    resultPlan_newDefaultValueLiteral=newDefaultValue;
   }//else

   return;
  }//if oldDefaultValue==null

  Debug.Assert(!Object.ReferenceEquals(oldDefaultValue,null));

  if(Object.ReferenceEquals(newDefaultValue,null))
  {
   resultPlan_removeOld=true;
   resultPlan_addNew   =false;

   resultPlan_newDefaultValueLiteral=null;

   return;
  }//if newDefaultValue=null

  Debug.Assert(!Object.ReferenceEquals(newDefaultValue,null));

  if(System.StringComparer.Ordinal.Equals(oldDefaultValue,newDefaultValue))
  {
   resultPlan_removeOld=false;
   resultPlan_addNew   =false;

   resultPlan_newDefaultValueLiteral=null;

   return;
  }//if

  //NOT EQUAL

  resultPlan_removeOld=false; //will overwrited by new value
  resultPlan_addNew   =true;

  resultPlan_newDefaultValueLiteral=newDefaultValue;
 }//Helper__BuildAlterColumnPlan__TestDefaultValue

 //-----------------------------------------------------------------------
 private void Helper__BuildAlterColumnPlan__TestIsNullable
                            (AlterColumnOperation operation,
                             out bool             resultPlan_remove_NOT_NULL,
                             out bool             resultPlan_add_NOT_NULL)
 {
  Debug.Assert(!Object.ReferenceEquals(operation,null));
  Debug.Assert(!Object.ReferenceEquals(operation.OldColumn,null));

  if(operation.IsNullable==operation.OldColumn.IsNullable)
  {
   resultPlan_remove_NOT_NULL  =false;
   resultPlan_add_NOT_NULL     =false;

   return;
  }//if

  Debug.Assert(operation.IsNullable!=operation.OldColumn.IsNullable);

  if(operation.OldColumn.IsNullable)
  {
   resultPlan_remove_NOT_NULL  =true;
   resultPlan_add_NOT_NULL     =false;

   return;
  }//if

  Debug.Assert(!operation.OldColumn.IsNullable);
  Debug.Assert( operation.IsNullable);

  resultPlan_remove_NOT_NULL   =false;
  resultPlan_add_NOT_NULL      =true;
 }//Helper__BuildAlterColumnPlan__TestIsNullable

 //-----------------------------------------------------------------------
 private void Helper__BuildAlterColumnPlan__TestVGS
                            (AlterColumnOperation             columnOperation,
                             LcpiOleDb__AnnotationData__VGS_s oldVGS_s,
                             LcpiOleDb__AnnotationData__VGS_s newVGS_s,
                             RelationalTypeMapping            newColumnTypeMapping,
                             out tagAlterColumnPlan__VGS      operationsForVGS)
 {
  Debug.Assert(!Object.ReferenceEquals(columnOperation,null));
  Debug.Assert(!Object.ReferenceEquals(newColumnTypeMapping,null));

  operationsForVGS
   =default;

  //--------------------------------------------------
  var oldVGS
   =oldVGS_s.GetValueOrDefault(null);

  var newVGS
   =newVGS_s.GetValueOrDefault(null);

  //-------------------------------------------------- TEST OLD VGS
  for(;;)
  {
   if(Helper__TestValueGenerationStratefy_IsIdentity(oldVGS))
   {
    if(!Helper__TestValueGenerationStratefy_IsIdentity(newVGS))
    {
     //Switch from Identity to NonIdentity

     ThrowError.DbmsErr__FB__FirebirdDoesNotSupportDropIdentityAttributeFromColumn
      (c_ErrSrcID);
    }//if

    Helper__BuildAlterColumnPlan__TestVGS_Identity
     (oldVGS,
      newVGS,
      ref operationsForVGS);

    return;
   }//if

   Debug.Assert(!Helper__TestValueGenerationStratefy_IsIdentity(oldVGS));

   if(Helper__TestValueGenerationStratefy_IsIdentity(newVGS))
   {
    //ERROR - switch from NonIdentity to Identity

    ThrowError.DbmsErr__FB__FirebirdDoesNotSupportAddIdentityAttributeToColumn
     (c_ErrSrcID);
   }//if

   //--------------------------------------------------
   if(oldVGS is LcpiOleDb__AnnotationData__VGS_SequenceTrigger oldVGS_seq_tr)
   {
    if(newVGS is LcpiOleDb__AnnotationData__VGS_SequenceTrigger newVGS_seq_tr)
    {
     Helper__BuildAlterColumnPlan__TestVGS_SequenceTrigger
      (columnOperation,
       oldVGS_seq_tr,
       newVGS_seq_tr,
       newColumnTypeMapping,
       ref operationsForVGS);

     return;
    }//if

    operationsForVGS.RemoveOp__VGS_SequenceTrigger
     =oldVGS_seq_tr;

    break;
   }//if

   //--------------------------------------------------
   if(!Object.ReferenceEquals(oldVGS,null))
   {
    //ERROR - unexpected type of VGS!

    ThrowError.AnnotationHasValueWithUnexpectedType
     (c_ErrSrcID,
      LcpiOleDb__AnnotationNames.ValueGenerationStrategy,
      oldVGS.GetType());
   }//if

   break;
  }//for[ever]

  //-------------------------------------------------- TEST NEW VGS

  Debug.Assert(!Helper__TestValueGenerationStratefy_IsIdentity(newVGS));

  {
   if(newVGS is LcpiOleDb__AnnotationData__VGS_SequenceTrigger newVGS_seq_tr)
   {
    Helper__CheckColumnForSequenceTrigger
     (columnOperation,
      newColumnTypeMapping); //throw

    operationsForVGS.AddOp__VGS_SequenceTrigger
     =newVGS_seq_tr;

    return;
   }//if
  }//local

  if(!Object.ReferenceEquals(newVGS,null))
  {
   //ERROR - unexpected type of VGS!

   ThrowError.AnnotationHasValueWithUnexpectedType
    (c_ErrSrcID,
     LcpiOleDb__AnnotationNames.ValueGenerationStrategy,
     newVGS.GetType());
  }//if
 }//Helper__BuildAlterColumnPlan__TestVGS

 //-----------------------------------------------------------------------
 private void Helper__BuildAlterColumnPlan__TestVGS_Identity
                            (LcpiOleDb__AnnotationData__VGS oldVGS,
                             LcpiOleDb__AnnotationData__VGS newVGS,
                             ref tagAlterColumnPlan__VGS    operationsForVGS)
 {
  Debug.Assert(Helper__TestValueGenerationStratefy_IsIdentity(oldVGS));
  Debug.Assert(Helper__TestValueGenerationStratefy_IsIdentity(newVGS));

  //NOPE
 }//Helper__BuildAlterColumnPlan__TestVGS_Identity

 //-----------------------------------------------------------------------
 private void Helper__BuildAlterColumnPlan__TestVGS_SequenceTrigger
                            (AlterColumnOperation                           columnOperation,
                             LcpiOleDb__AnnotationData__VGS_SequenceTrigger oldVGS_seq_tr,
                             LcpiOleDb__AnnotationData__VGS_SequenceTrigger newVGS_seq_tr,
                             RelationalTypeMapping                          newColumnTypeMapping,
                             ref tagAlterColumnPlan__VGS                    operationsForVGS)
 {
  Debug.Assert(!Object.ReferenceEquals(columnOperation,null));
  Debug.Assert(!Object.ReferenceEquals(newColumnTypeMapping,null));

  Debug.Assert(!Object.ReferenceEquals(oldVGS_seq_tr,null));
  Debug.Assert(!Object.ReferenceEquals(newVGS_seq_tr,null));

  if(oldVGS_seq_tr.EqualTo(newVGS_seq_tr))
  {
   //NOPE
   return;
  }//if

  Helper__CheckColumnForSequenceTrigger
   (columnOperation,
    newColumnTypeMapping);

  //1. Drop old trigger
  operationsForVGS.RemoveOp__VGS_SequenceTrigger
   =oldVGS_seq_tr;

  //2. Create new trigger
  operationsForVGS.AddOp__VGS_SequenceTrigger
   =newVGS_seq_tr;
 }//Helper__BuildAlterColumnPlan__TestVGS_SequenceTrigger

 //Helper types ----------------------------------------------------------
 private static bool Helper__TestValueGenerationStratefy_IsIdentity
                            (LcpiOleDb__AnnotationData__VGS valueGenerationStrategy)
 {
  if(valueGenerationStrategy is LcpiOleDb__AnnotationData__VGS_IdentityByDefaultColumn)
   return true;

  return false;
 }//Helper__TestValueGenerationStratefy_IsIdentity

 //Helper types ----------------------------------------------------------

 //Operations for "Value Generation Strategy"
 private struct tagAlterColumnPlan__VGS
 {
  public LcpiOleDb__AnnotationData__VGS_SequenceTrigger
   RemoveOp__VGS_SequenceTrigger;

  public LcpiOleDb__AnnotationData__VGS_SequenceTrigger
   AddOp__VGS_SequenceTrigger;
 };//struct tagAlterColumnPlan__VGS

 //-----------------------------------------------------------------------
 private struct tagAlterColumnPlan
 {
  public bool RenameOp__ColumnName;

  public bool RemoveOp__DefaultValue;
  public bool RemoveOp__NOT_NULL;

  public bool AddOp__DefaultValue;
  public bool AddOp__NOT_NULL;

  public string newDefaultValueLiteral;

  public RelationalTypeMapping newColumnTypeMapping;

  public tagAlterColumnPlan__VGS operationsForVGS;
 };//struct tagAlterColumnPlan
};//class FB_V03_0_0__MigrationsSqlGenerator

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Migrations

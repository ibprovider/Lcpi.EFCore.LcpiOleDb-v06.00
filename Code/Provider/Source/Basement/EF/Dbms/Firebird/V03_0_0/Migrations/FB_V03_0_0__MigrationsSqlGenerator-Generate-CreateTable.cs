////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 08.11.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Migrations{
////////////////////////////////////////////////////////////////////////////////

using LcpiOleDb__AnnotationNames
 =DataProvider.LcpiOleDb.MetaData.Internal.LcpiOleDb__AnnotationNames;

using LcpiOleDb__AnnotationData__ValueGenerationStrategy
 =MetaData.LcpiOleDb__AnnotationData__ValueGenerationStrategy;

using LcpiOleDb__AnnotationData__ValueGenerationStrategy_SequenceTrigger
 =MetaData.LcpiOleDb__AnnotationData__ValueGenerationStrategy_SequenceTrigger;

////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0__MigrationsSqlGenerator

partial class FB_V03_0_0__MigrationsSqlGenerator
{
 //MigrationsSqlGenerator interface --------------------------------------

 protected override void Generate(CreateTableOperation        operation,
                                  IModel                      model,
                                  MigrationCommandListBuilder builder,
                                  bool                        terminate)
 {
  const string c_methodSign
   =nameof(Generate)+"("+nameof(CreateTableOperation)+"...)";

  Check.Arg_NotNull
   (c_ErrSrcID,
    c_methodSign,
    nameof(operation),
    operation);

  Check.Arg_IsNull
   (c_ErrSrcID,
    c_methodSign,
    "operation.Schema",
    operation.Schema);

  Check.Arg_NotNullAndNotEmpty
   (c_ErrSrcID,
    c_methodSign,
    "operation.Name",
    operation.Name);

  // Read-only not null property
  Debug.Assert(!Object.ReferenceEquals(operation.Columns,null));

  Check.Arg_NotNull
   (c_ErrSrcID,
    c_methodSign,
    nameof(builder),
    builder);

  try // [catch]
  {
   //------------------------------------------------- Check Columns
   for(int i=0,_c=operation.Columns.Count;i!=_c;++i)
   {
    var column
     =operation.Columns[i];

    var columnAddrSign
     ="operation.Columns["+i+"]";

    var columnAddrSign_Table
     =columnAddrSign+".Table";

    Check.Arg_NotNull
     (c_ErrSrcID,
      c_methodSign,
      columnAddrSign,
      column);

    Check.Arg_NotNullAndNotEmpty
     (c_ErrSrcID,
      c_methodSign,
      columnAddrSign_Table,
      column.Table);

    //-----------------------
    if(!System.StringComparer.Ordinal.Equals(operation.Name,column.Table))
    {
     ThrowError.MSqlGenErr__ColumnDataUsesIncorrectTableName
      (c_ErrSrcID,
       i,
       column.Name,
       column.Table,
       operation.Name);
    }//if
   }//for i

   //---------------------------------------------------------------------
   base.Generate
    (operation,
     model,
     builder,
     /*terminate*/true);

   //---------------------------------------------------------------------
   foreach(var column in operation.Columns)
   {
    Debug.Assert(!Object.ReferenceEquals(column,null));

    //[2021-11-08] Expected!
    Debug.Assert(operation.Name==column.Table);

    var valueGenerationStrategy_obj
     =column[LcpiOleDb__AnnotationNames.ValueGenerationStrategy];

    if(Object.ReferenceEquals(valueGenerationStrategy_obj,null))
     return; //no strategy

    Debug.Assert(valueGenerationStrategy_obj is LcpiOleDb__AnnotationData__ValueGenerationStrategy);

    if(valueGenerationStrategy_obj is LcpiOleDb__AnnotationData__ValueGenerationStrategy_SequenceTrigger valueGenerationStrategy_SequenceTrigger)
    {
     //creation of generation trigger

     Debug.Assert(!string.IsNullOrEmpty(valueGenerationStrategy_SequenceTrigger.TriggerName));
     Debug.Assert(!string.IsNullOrEmpty(valueGenerationStrategy_SequenceTrigger.SequenceName));

     this.Helper__CreateSequenceTriggerForColumn
      (column.Table,
       column.Name,
       valueGenerationStrategy_SequenceTrigger,
       builder);
    }//if - SequenceTrigger
   }//foreach column
  }
  catch(Exception e)
  {
   var exc
    =new LcpiOleDb__DataToolException(e);

   exc.add_error
    (lcpi.lib.com.HResultCode.E_FAIL,
     c_ErrSrcID,
     ErrMessageID.msql_gen_err__failed_to_generate_table_creation_script__1);

   exc
    .push(operation.Name)
    .raise();
  }//catch
 }//Generate - RenameColumnOperation
};//class FB_V03_0_0__MigrationsSqlGenerator

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Migrations

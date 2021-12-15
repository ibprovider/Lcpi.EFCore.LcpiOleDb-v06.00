////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 25.04.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Migrations{
////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0__MigrationsSqlGenerator

partial class FB_V03_0_0__MigrationsSqlGenerator
{
 //MigrationsSqlGenerator interface --------------------------------------

 protected override void ForeignKeyConstraint(AddForeignKeyOperation      operation,
                                              IModel                      model,
                                              MigrationCommandListBuilder builder)
 {
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(ForeignKeyConstraint),
    nameof(operation),
    operation);

  Check.Arg_IsNullOrNotEmpty
   (c_ErrSrcID,
    nameof(ForeignKeyConstraint),
    "operation.Name",
    operation.Name);

  Check.Arg_NotNullAndNotEmpty
   (c_ErrSrcID,
    nameof(ForeignKeyConstraint),
    "operation.Columns",
    operation.Columns);

  Check.Arg_NotNullAndNotEmpty
   (c_ErrSrcID,
    nameof(ForeignKeyConstraint),
    "operation.PrincipalColumns",
    operation.PrincipalColumns);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(ForeignKeyConstraint),
    nameof(builder),
    builder);

  try // [catch]
  {
   Debug.Assert(!Object.ReferenceEquals(operation.Columns,null));
   Debug.Assert(!Object.ReferenceEquals(operation.PrincipalColumns,null));

   Debug.Assert(operation.Columns.Length>0);
   Debug.Assert(operation.PrincipalColumns.Length>0);

   if(operation.Columns.Length!=operation.PrincipalColumns.Length)
   {
    ThrowError.MSqlGenErr__DifferentSizeOfFkColumnLists
     (c_ErrSrcID,
      operation.Columns.Length,
      operation.PrincipalColumns.Length);
   }//if

   Debug.Assert(operation.Columns.Length==operation.PrincipalColumns.Length);

   //--------------------------------------------------
   if(!Object.ReferenceEquals(operation.Name,null))
   {
    Debug.Assert(operation.Name.Length>0);

    builder.Append("CONSTRAINT ");
    builder.Append(this.Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Name));
    builder.Append(" ");
   }//if

   builder.Append("FOREIGN KEY (");
   builder.Append(this.ColumnList(operation.Columns));
   builder.Append(") REFERENCES ");
   builder.Append(this.Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.PrincipalTable,operation.PrincipalSchema));

   if(!Object.ReferenceEquals(operation.PrincipalColumns,null))
   {
    builder.Append(" (");
    builder.Append(this.ColumnList(operation.PrincipalColumns));
    builder.Append(")");
   }//if

   if(operation.OnUpdate!=ReferentialAction.Restrict)
   {
    builder.Append(" ON UPDATE ");

    this.ForeignKeyAction
     (operation.OnUpdate,
      builder);
   }//if

   if(operation.OnDelete!=ReferentialAction.Restrict)
   {
    builder.Append(" ON DELETE ");

    this.ForeignKeyAction
     (operation.OnDelete,
      builder);
   }//if
  }
  catch(Exception e)
  {
   var exc
    =new LcpiOleDb__DataToolException
      (e);

   exc.add_error
    (lcpi.lib.com.HResultCode.E_FAIL,
     c_ErrSrcID,
     ErrMessageID.msql_gen_err__failed_to_generate_fk_definition__3);

   exc
    .push(operation.Table)
    .push(operation.Name) //may be null
    .push(operation.PrincipalTable)
    .raise();
  }//catch
 }//ForeignKeyConstraint
};//class FB_V03_0_0__MigrationsSqlGenerator

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Migrations

////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 11.11.2021.
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

 protected override void Generate(RenameIndexOperation       operation,
                                  IModel                      model,
                                  MigrationCommandListBuilder builder)
 {
  const string c_methodSign
   =nameof(Generate)+"("+nameof(RenameIndexOperation)+"...)";

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

  Check.Arg_IsNull
   (c_ErrSrcID,
    c_methodSign,
    "operation.Table",
    operation.Table);

  Check.Arg_NotNullAndNotEmpty
   (c_ErrSrcID,
    c_methodSign,
    "operation.Name",
    operation.Name);

  Check.Arg_NotNullAndNotEmpty
   (c_ErrSrcID,
    c_methodSign,
    "operation.NewName",
    operation.NewName);

  Check.Arg_NotNull
   (c_ErrSrcID,
    c_methodSign,
    nameof(builder),
    builder);

  //----------------------------------------------------------------------
  ThrowError.DbmsErr__FB__FirebirdDoesNotSupportRenamingOfIndexes
   (c_ErrSrcID);
 }//Generate - RenameIndexOperation
};//class FB_V03_0_0__MigrationsSqlGenerator

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Migrations

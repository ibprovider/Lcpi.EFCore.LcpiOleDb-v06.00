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

 protected override void Generate(CreateIndexOperation        operation,
                                  IModel                      model,
                                  MigrationCommandListBuilder builder,
                                  bool                        terminate)
 {
  const string c_methodSign
   =nameof(Generate)+"("+nameof(CreateIndexOperation)+"...)";

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
    "operation.Table",
    operation.Table);

  Check.Arg_NotNullAndNotEmpty
   (c_ErrSrcID,
    c_methodSign,
    "operation.Name",
    operation.Name);

  Check.Arg_IsNullOrNotEmpty
   (c_ErrSrcID,
    c_methodSign,
    "operation.Filter",
    operation.Filter);

  Check.Arg_IsNullOrNotEmpty
   (c_ErrSrcID,
    c_methodSign,
    "operation.Columns",
    operation.Columns);

  Check.Arg_NotNull
   (c_ErrSrcID,
    c_methodSign,
    nameof(builder),
    builder);

  //----------------------------------------------------------------------

  try // [catch]
  {
   builder.Append("CREATE ");

   if(operation.IsUnique)
   {
    builder.Append("UNIQUE ");
   }//if

   //IndexTraits(operation,model,builder);

   builder.Append("INDEX ");
   builder.Append(this.Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Name));
   builder.Append(" ON ");
   builder.Append(this.Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Table));

   if(!Object.ReferenceEquals(operation.Filter,null))
   {
    Debug.Assert(operation.Filter.Length>0);

    if(!Object.ReferenceEquals(operation.Columns,null))
    {
     Debug.Assert(operation.Columns.Length>0);

     //ERROR - incorrect index definition.

     ThrowError.MSqlGenErr__BadIndexDefinition_MultipleData
      (c_ErrSrcID,
       operation.Name,
       operation.Table);
    }//if

    builder.Append(" COMPUTED BY (");
    builder.Append(operation.Filter);
    builder.Append(")");
   }
   else
   if(!Object.ReferenceEquals(operation.Columns,null))
   {
    builder.Append(" (");
    builder.Append(this.ColumnList(operation.Columns));
    builder.Append(")");
   }
   else
   {
    //ERROR - incorrect index definition. NO DATA.

    //This mean that:
    Debug.Assert(Object.ReferenceEquals(operation.Columns,null));
    Debug.Assert(Object.ReferenceEquals(operation.Filter,null));

    ThrowError.MSqlGenErr__BadIndexDefinition_NoData
     (c_ErrSrcID,
      operation.Name,
      operation.Table);
   }//else

   if(terminate)
   {
    Helper__TerminateStatement(builder);
   }//if
  }
  catch(Exception e)
  {
   var exc
    =new LcpiOleDb__DataToolException(e);

   exc.add_error
    (lcpi.lib.com.HResultCode.E_FAIL,
     c_ErrSrcID,
     ErrMessageID.msql_gen_err__failed_to_generate_create_index_statement__2);

   exc
    .push(operation.Name)
    .push(operation.Table)
    .raise();
  }//catch
 }//Generate - CreateIndexOperation
};//class FB_V03_0_0__MigrationsSqlGenerator

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Migrations

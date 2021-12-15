////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 07.11.2021.
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

 protected override void Generate(RestartSequenceOperation    operation,
                                  IModel                      model,
                                  MigrationCommandListBuilder builder)
 {
  const string c_methodSign
   =nameof(Generate)+"("+nameof(RestartSequenceOperation)+"...)";

  Check.Arg_NotNull
   (c_ErrSrcID,
    c_methodSign,
    nameof(operation),
    operation);

  Check.Arg_NotNull
   (c_ErrSrcID,
    c_methodSign,
    "operation.Name",
    operation.Name);

  Check.Arg_IsNull
   (c_ErrSrcID,
    c_methodSign,
    "operation.Schema",
    operation.Schema);

  Check.Arg_NotNull
   (c_ErrSrcID,
    c_methodSign,
    nameof(builder),
    builder);

  //----------------------------------------

  try // [catch]
  {
   Debug.Assert(!Object.ReferenceEquals(m_MigrationsSvc__GenerateRestartSequence,null));

   m_MigrationsSvc__GenerateRestartSequence.GenerateRestartSequence
    (this.Dependencies,
     operation,
     model,
     builder);

   Helper__TerminateStatement
    (builder);
  }
  catch(Exception e)
  {
   var exc
    =new LcpiOleDb__DataToolException
      (e);

   exc.add_error
    (lcpi.lib.com.HResultCode.E_FAIL,
     c_ErrSrcID,
     ErrMessageID.msql_gen_err__failed_to_generate_restart_sequence_statement__1);

   exc
    .push(operation.Name)
    .raise();
  }//catch
 }//Generate - CreateSequenceOperation
};//class FB_V03_0_0__MigrationsSqlGenerator

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Migrations

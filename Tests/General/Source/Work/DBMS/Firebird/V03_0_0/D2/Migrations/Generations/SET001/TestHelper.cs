////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 23.09.2021.
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D2.Migrations.Generations.SET001{
////////////////////////////////////////////////////////////////////////////////
//class TestHelper

static class TestHelper
{
 private sealed class MyContext:TestBaseDbContext
 {
  public MyContext(xdb.OleDbTransaction tr)
   :base(tr)
  {
  }//MyContext
 };//class MyContext

 //-----------------------------------------------------------------------
 public static IReadOnlyList<MigrationCommand> Exec(IReadOnlyList<MigrationOperation> operations)
 {
  IReadOnlyList<MigrationCommand>
   migrationCommands
    =null;

  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    using(var db=new MyContext(tr))
    {
     var generator
      =db.GetService<IMigrationsSqlGenerator>();
     
     var options
      =MigrationsSqlGenerationOptions.Default;

     migrationCommands
      =generator.Generate
        (operations,
         db.Model,
         options);

     Assert.NotNull
      (migrationCommands);
    }//using db

    tr.Commit();
   }//using tr
  }//using cn

  return migrationCommands;
 }//Exec

 //-----------------------------------------------------------------------
 public static void Exec(IReadOnlyList<MigrationOperation> operations,
                         IReadOnlyList<TestSqlTemplate>    expectedSQLs)
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    using(var db=new MyContext(tr))
    {
     TestServices.CheckMigrationSQLs
      (db,
       operations,
       expectedSQLs);
    }//using db

    tr.Commit();
   }//using tr
  }//using cn
 }//Exec
};//class TestHelper

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D2.Migrations.Generations.SET001

////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 15.10.2020.
using NUnit.Framework;

using Microsoft.EntityFrameworkCore;
using System;

using xDB=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Extensions.LcpiOleDb__Extensions__DbContextOptions{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_02__UseLcpiOleDb__opt_cn

public static class TestSet_02__UseLcpiOleDb__opt_cn
{
 [Test]
 public static void Test_01__err__null_optionsBuilder()
 {
  DbContextOptionsBuilder Opt=null;

  var cn=new xDB.OleDbConnection();

  try
  {
   Opt.UseLcpiOleDb(cn);
  }
  catch(ArgumentNullException exc)
  {
   CheckErrors.PrintException_OK(exc);

   CheckErrors.CheckException__ArgumentNullException
    (exc,
     CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__Extensions__DbContextOptions,
     "UseLcpiOleDb",
     "optionsBuilder");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_01__err__null_optionsBuilder

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02__err__null_connectionString()
 {
  DbContextOptionsBuilder Opt=new DbContextOptionsBuilder();

  xDB.OleDbConnection cn=null;

  try
  {
   Opt.UseLcpiOleDb(cn);
  }
  catch(ArgumentNullException exc)
  {
   CheckErrors.PrintException_OK(exc);

   CheckErrors.CheckException__ArgumentNullException
    (exc,
     CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__Extensions__DbContextOptions,
     "UseLcpiOleDb",
     "connection");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_02__err__null_connectionString
};//class TestSet_02__UseLcpiOleDb__opt_cn

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Extensions.LcpiOleDb__Extensions__DbContextOptions

////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 15.10.2020.
using NUnit.Framework;

using Microsoft.EntityFrameworkCore;
using System;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Extensions.LcpiOleDb__Extensions__DbContextOptions{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_03__UseLcpiOleDb__optT_cnStr

public static class TestSet_03__UseLcpiOleDb__optT_cnStr
{
 [Test]
 public static void Test_01__err__null_optionsBuilder()
 {
  DbContextOptionsBuilder<TestBaseDbContext> Opt=null;

  try
  {
   Opt.UseLcpiOleDb(TestServices.Conf__GetCnStr());
  }
  catch(ArgumentNullException exc)
  {
   CheckErrors.PrintException_OK(exc);

   CheckErrors.CheckException__ArgumentNullException
    (exc,
     CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__Extensions__DbContextOptions,
     "UseLcpiOleDb<TContext>",
     "optionsBuilder");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_01__err__null_optionsBuilder

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02__err__null_connectionString()
 {
  var Opt=new DbContextOptionsBuilder<TestBaseDbContext>();

  string connectionString=null;

  try
  {
   Opt.UseLcpiOleDb(connectionString);
  }
  catch(ArgumentNullException exc)
  {
   CheckErrors.PrintException_OK(exc);

   CheckErrors.CheckException__ArgumentNullException
    (exc,
     CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__Extensions__DbContextOptions,
     "UseLcpiOleDb<TContext>",
     "connectionString");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_02__err__null_connectionString

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_03__err__empty_connectionString()
 {
  var Opt=new DbContextOptionsBuilder<TestBaseDbContext>();

  string connectionString="";

  try
  {
   Opt.UseLcpiOleDb(connectionString);
  }
  catch(ArgumentException exc)
  {
   CheckErrors.PrintException_OK(exc);

   CheckErrors.CheckException__ArgumentIsEmpty
    (exc,
     CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__Extensions__DbContextOptions,
     "UseLcpiOleDb<TContext>",
     "connectionString");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_03__err__empty_connectionString
};//class TestSet_03__UseLcpiOleDb__optT_cnStr

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Extensions.LcpiOleDb__Extensions__DbContextOptions

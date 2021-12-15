////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 15.10.2020.
using NUnit.Framework;
using System;
using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Core.Engines.Dbms.IscBase.IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d1{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__QuoteIdentifier__builder_id

public static class TestsFor__QuoteIdentifier__builder_id
{
 [Test]
 public static void Test_001()
 {
  var p=xEFCore.Core.Engines.Dbms.IscBase.IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d1.Create();

  Assert.IsNotNull(p);

  var builder=new System.Text.StringBuilder();

  p.QuoteIdentifier(builder,"name123");

  Assert.AreEqual
   ("name123",
    builder.ToString());
 }//Test_001

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002()
 {
  var p=xEFCore.Core.Engines.Dbms.IscBase.IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d1.Create();

  Assert.IsNotNull(p);

  var builder=new System.Text.StringBuilder();

  p.QuoteIdentifier(builder,"name123$");

  Assert.AreEqual
   ("name123$",
    builder.ToString());
 }//Test_002

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_003()
 {
  var p=xEFCore.Core.Engines.Dbms.IscBase.IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d1.Create();

  Assert.IsNotNull(p);

  var builder=new System.Text.StringBuilder();

  p.QuoteIdentifier(builder,"name123_");

  Assert.AreEqual
   ("name123_",
    builder.ToString());
 }//Test_003

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_100_err__bad1()
 {
  var p=xEFCore.Core.Engines.Dbms.IscBase.IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d1.Create();

  Assert.IsNotNull(p);

  var builder=new System.Text.StringBuilder();

  try
  {
   p.QuoteIdentifier(builder,"1name123");
  }
  catch(InvalidOperationException exc)
  {
   CheckErrors.PrintException_OK(exc);

   CheckErrors.CheckException__common_err__bad_symbol_in_unquoted_object_name_2
    (exc,
     CheckErrors.c_src__EFCoreDataProvider__IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d1,
     0,
     '1');

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_100_err__bad1

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_101_err__bad2()
 {
  var p=xEFCore.Core.Engines.Dbms.IscBase.IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d1.Create();

  Assert.IsNotNull(p);

  var builder=new System.Text.StringBuilder();

  try
  {
   p.QuoteIdentifier(builder,"name123 ");
  }
  catch(InvalidOperationException exc)
  {
   CheckErrors.PrintException_OK(exc);

   CheckErrors.CheckException__common_err__bad_symbol_in_unquoted_object_name_2
    (exc,
     CheckErrors.c_src__EFCoreDataProvider__IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d1,
     7,
     ' ');

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_101_err__bad2

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_102_err__empty()
 {
  var p=xEFCore.Core.Engines.Dbms.IscBase.IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d1.Create();

  Assert.IsNotNull(p);

  var builder=new System.Text.StringBuilder();

  try
  {
   p.QuoteIdentifier(builder,"");
  }
  catch(InvalidOperationException exc)
  {
   CheckErrors.PrintException_OK(exc);

   CheckErrors.CheckException__common_err__empty_object_name_0
    (exc,
     CheckErrors.c_src__EFCoreDataProvider__IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d1);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_102_err__empty
};//class TestsFor__QuoteIdentifier__builder_id

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Core.Engines.Dbms.IscBase.IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d1

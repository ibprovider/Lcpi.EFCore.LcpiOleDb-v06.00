////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 15.10.2020.
using NUnit.Framework;
using System;
using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Core.Engines.Dbms.IscBase.IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d3{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__QuoteIdentifier__id

public static class TestsFor__QuoteIdentifier__id
{
 [Test]
 public static void Test_001()
 {
  var p=xEFCore.Core.Engines.Dbms.IscBase.IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d3.Create();

  Assert.IsNotNull(p);

  var x=p.QuoteIdentifier("name123");

  Assert.AreEqual
   ("\"name123\"",
    x);
 }//Test_001

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002()
 {
  var p=xEFCore.Core.Engines.Dbms.IscBase.IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d3.Create();

  Assert.IsNotNull(p);

  var x=p.QuoteIdentifier("$name123");

  Assert.AreEqual
   ("\"$name123\"",
    x);
 }//Test_002

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_003()
 {
  var p=xEFCore.Core.Engines.Dbms.IscBase.IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d3.Create();

  Assert.IsNotNull(p);

  var x=p.QuoteIdentifier("_name123");

  Assert.AreEqual
   ("\"_name123\"",
    x);
 }//Test_003

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_004()
 {
  var p=xEFCore.Core.Engines.Dbms.IscBase.IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d3.Create();

  Assert.IsNotNull(p);

  var x=p.QuoteIdentifier("\n\"");

  Assert.AreEqual
   ("\"\n\"\"\"",
    x);
 }//Test_004

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_100_err__bad1()
 {
  var p=xEFCore.Core.Engines.Dbms.IscBase.IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d3.Create();

  Assert.IsNotNull(p);

  try
  {
   var x=p.QuoteIdentifier("\0name123");
  }
  catch(InvalidOperationException exc)
  {
   CheckErrors.PrintException_OK(exc);

   CheckErrors.CheckException__common_err__bad_symbol_in_quoted_object_name_2
    (exc,
     CheckErrors.c_src__EFCoreDataProvider__IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d3,
     0,
     '\0');

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_100_err__bad1

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_101_err__bad2()
 {
  var p=xEFCore.Core.Engines.Dbms.IscBase.IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d3.Create();

  Assert.IsNotNull(p);

  try
  {
   var x=p.QuoteIdentifier("name123\0");
  }
  catch(InvalidOperationException exc)
  {
   CheckErrors.PrintException_OK(exc);

   CheckErrors.CheckException__common_err__bad_symbol_in_quoted_object_name_2
    (exc,
     CheckErrors.c_src__EFCoreDataProvider__IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d3,
     7,
     '\0');

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_101_err__bad2

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_102_err__empty()
 {
  var p=xEFCore.Core.Engines.Dbms.IscBase.IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d3.Create();

  Assert.IsNotNull(p);

  try
  {
   var x=p.QuoteIdentifier("");
  }
  catch(InvalidOperationException exc)
  {
   CheckErrors.PrintException_OK(exc);

   CheckErrors.CheckException__common_err__empty_object_name_0
    (exc,
     CheckErrors.c_src__EFCoreDataProvider__IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d3);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_102_err__empty
};//class TestsFor__QuoteIdentifier__id

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Core.Engines.Dbms.IscBase.IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d3

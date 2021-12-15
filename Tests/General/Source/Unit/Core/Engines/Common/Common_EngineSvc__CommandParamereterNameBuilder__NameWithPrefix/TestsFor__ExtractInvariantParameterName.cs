////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 02.09.2021.
using System;
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Core.Engines.Common.Common_EngineSvc__CommandParamereterNameBuilder__NameWithPrefix{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__ExtractInvariantParameterName

public static class TestsFor__ExtractInvariantParameterName
{
 [Test]
 public static void Test_01()
 {
  var p
   =xEFCore.Core.Engines.Common.Common_EngineSvc__CommandParamereterNameBuilder__NameWithPrefix.Create
     (":");

  Assert.IsNotNull(p);

  var x
   =p.ExtractInvariantParameterName(":param1");

  Assert.AreEqual
   ("param1",
    x);
 }//Test_01

 //-----------------------------------------------------------------------
#if !DEBUG
 [Test]
 public static void Test_ERR01__bad_format()
 {
  var p
   =xEFCore.Core.Engines.Common.Common_EngineSvc__CommandParamereterNameBuilder__NameWithPrefix.Create
     (":");

  Assert.IsNotNull(p);

  try
  {
   var x
    =p.ExtractInvariantParameterName(":");
  }
  catch(InvalidOperationException e)
  {
   CheckErrors.PrintException_OK(e);

   CheckErrors.CheckException__common_err__bad_cmd_parameter_name_format_1
    (e,
     CheckErrors.c_src__EFCoreDataProvider__Common_EngineSvc__CommandParamereterNameBuilder__NameWithPrefix,
     ":");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_ERR01__bad_format
#endif // !DEBUG

 //-----------------------------------------------------------------------
#if !DEBUG
 [Test]
 public static void Test_ERR02__bad_format()
 {
  var p
   =xEFCore.Core.Engines.Common.Common_EngineSvc__CommandParamereterNameBuilder__NameWithPrefix.Create
     (":::");

  Assert.IsNotNull(p);

  try
  {
   var x
    =p.ExtractInvariantParameterName("::");
  }
  catch(InvalidOperationException e)
  {
   CheckErrors.PrintException_OK(e);

   CheckErrors.CheckException__common_err__bad_cmd_parameter_name_format_1
    (e,
     CheckErrors.c_src__EFCoreDataProvider__Common_EngineSvc__CommandParamereterNameBuilder__NameWithPrefix,
     "::");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_ERR02__bad_format
#endif // !DEBUG

 //-----------------------------------------------------------------------
#if !DEBUG
 [Test]
 public static void Test_ERR03__bad_format__incorrect_prefix()
 {
  var p
   =xEFCore.Core.Engines.Common.Common_EngineSvc__CommandParamereterNameBuilder__NameWithPrefix.Create
     (":::");

  Assert.IsNotNull(p);

  try
  {
   var x
    =p.ExtractInvariantParameterName("asdfg");
  }
  catch(InvalidOperationException e)
  {
   CheckErrors.PrintException_OK(e);

   CheckErrors.CheckException__common_err__bad_cmd_parameter_name_format__incorrect_prefix_1
    (e,
     CheckErrors.c_src__EFCoreDataProvider__Common_EngineSvc__CommandParamereterNameBuilder__NameWithPrefix,
     "asdfg");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_ERR03__bad_format__incorrect_prefix
#endif // !DEBUG

 //-----------------------------------------------------------------------
#if !DEBUG
 [Test]
 public static void Test_ERR04__null()
 {
  var p
   =xEFCore.Core.Engines.Common.Common_EngineSvc__CommandParamereterNameBuilder__NameWithPrefix.Create
     (":::");

  Assert.IsNotNull(p);

  try
  {
   var x
    =p.ExtractInvariantParameterName(null);
  }
  catch(ArgumentNullException e)
  {
   CheckErrors.PrintException_OK(e);

   CheckErrors.CheckException__ArgumentNullException
    (e,
     CheckErrors.c_src__EFCoreDataProvider__Common_EngineSvc__CommandParamereterNameBuilder__NameWithPrefix,
     "ExtractInvariantParameterName",
     "parameterName");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_ERR04__null
#endif // !DEBUG

 //-----------------------------------------------------------------------
#if !DEBUG
 [Test]
 public static void Test_ERR05__empty()
 {
  var p
   =xEFCore.Core.Engines.Common.Common_EngineSvc__CommandParamereterNameBuilder__NameWithPrefix.Create
     (":::");

  Assert.IsNotNull(p);

  try
  {
   var x
    =p.ExtractInvariantParameterName("");
  }
  catch(ArgumentException e)
  {
   CheckErrors.PrintException_OK(e);

   CheckErrors.CheckException__ArgumentIsEmpty
    (e,
     CheckErrors.c_src__EFCoreDataProvider__Common_EngineSvc__CommandParamereterNameBuilder__NameWithPrefix,
     "ExtractInvariantParameterName",
     "parameterName");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_ERR05__empty
#endif // !DEBUG
};//class TestsFor__ExtractInvariantParameterName

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Core.Engines.Common.Common_EngineSvc__CommandParamereterNameBuilder__NameWithPrefix

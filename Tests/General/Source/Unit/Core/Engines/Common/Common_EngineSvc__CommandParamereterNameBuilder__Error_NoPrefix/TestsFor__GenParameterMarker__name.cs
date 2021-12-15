////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 15.10.2020.
using System;
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Core.Engines.Common.Common_EngineSvc__CommandParamereterNameBuilder__Error_NoPrefix{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__GenParameterMarker__name

public static class TestsFor__GenParameterMarker__name
{
 [Test]
 public static void Test_01()
 {
  var p=xEFCore.Core.Engines.Common.Common_EngineSvc__CommandParamereterNameBuilder__Error_NoPrefix.Create();

  Assert.IsNotNull(p);

  try
  {
   p.GenParameterMarker("param1");
  }
  catch(InvalidOperationException e)
  {
   CheckErrors.PrintException_OK(e);

   CheckErrors.CheckException__common_err__not_defined_cmd_parameter_prefix_0
    (e,
     CheckErrors.c_src__EFCoreDataProvider__Common_EngineSvc__CommandParamereterNameBuilder__Error_NoPrefix);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_01
};//class TestsFor__GenParameterMarker__name

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Core.Engines.Common.Common_EngineSvc__CommandParamereterNameBuilder__Error_NoPrefix

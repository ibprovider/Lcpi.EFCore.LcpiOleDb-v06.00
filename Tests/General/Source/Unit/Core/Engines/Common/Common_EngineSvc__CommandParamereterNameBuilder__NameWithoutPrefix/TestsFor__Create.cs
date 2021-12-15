////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 15.10.2020.
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Core.Engines.Common.Common_EngineSvc__CommandParamereterNameBuilder__NameWithoutPrefix{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__Create

public static class TestsFor__Create
{
 [Test]
 public static void Test_01()
 {
  var p=xEFCore.Core.Engines.Common.Common_EngineSvc__CommandParamereterNameBuilder__NameWithoutPrefix.Create(":");

  Assert.IsNotNull(p);
 }//Test_01
};//class TestsFor__Create

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Core.Engines.Common.Common_EngineSvc__CommandParamereterNameBuilder__NameWithoutPrefix

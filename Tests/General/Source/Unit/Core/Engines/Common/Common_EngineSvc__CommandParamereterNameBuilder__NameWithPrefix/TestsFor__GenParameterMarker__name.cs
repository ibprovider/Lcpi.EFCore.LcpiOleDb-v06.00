////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 15.10.2020.
using System;
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Core.Engines.Common.Common_EngineSvc__CommandParamereterNameBuilder__NameWithPrefix{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__GenParameterMarker__name

public static class TestsFor__GenParameterMarker__name
{
 [Test]
 public static void Test_01()
 {
  var p=xEFCore.Core.Engines.Common.Common_EngineSvc__CommandParamereterNameBuilder__NameWithPrefix.Create(":");

  Assert.IsNotNull(p);

  var x=p.GenParameterMarker("param1");

  Assert.AreEqual
   (":param1",
    x);
 }//Test_01
};//class TestsFor__GenParameterMarker__name

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Core.Engines.Common.Common_EngineSvc__CommandParamereterNameBuilder__NameWithPrefix

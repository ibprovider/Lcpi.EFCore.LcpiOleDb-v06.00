////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 15.10.2020.
using System;
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Core.Engines.Common.Common_EngineSvc__CommandParamereterNameBuilder__NameWithPrefix{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__GenParameterName__builder_name

public static class TestsFor__GenParameterName__builder_name
{
 [Test]
 public static void Test_01()
 {
  var p=xEFCore.Core.Engines.Common.Common_EngineSvc__CommandParamereterNameBuilder__NameWithPrefix.Create(":");

  Assert.IsNotNull(p);

  var builder=new System.Text.StringBuilder();

  p.GenParameterName(builder,"param1");

  Assert.AreEqual
   (":param1",
    builder.ToString());
 }//Test_01
};//class TestsFor__GenParameterName__builder_name

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Core.Engines.Common.Common_EngineSvc__CommandParamereterNameBuilder__NameWithPrefix

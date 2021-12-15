////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 15.10.2020.
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Core.Engines.Dbms.IscBase.IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d1{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__Create

public static class TestsFor__Create
{
 [Test]
 public static void Test_01()
 {
  var p=xEFCore.Core.Engines.Dbms.IscBase.IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d1.Create();

  Assert.IsNotNull(p);
 }//Test_01
};//class TestsFor__Create

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Core.Engines.Dbms.IscBase.IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d1

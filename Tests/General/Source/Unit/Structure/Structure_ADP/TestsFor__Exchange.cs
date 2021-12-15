////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 10.12.2020.
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_ADP{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__Exchange

public static class TestsFor__Exchange
{
 [Test]
 public static void Test_01()
 {
  var v="abc";

  var p=xEFCore.Structure.Structure_ADP.Exchange(ref v,null);

  Assert.AreEqual
   ("abc",
    p);

  Assert.IsNull
   (v);
 }//Test_01
};//class TestsFor__Exchange

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_ADP

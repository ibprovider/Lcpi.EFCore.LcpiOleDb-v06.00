////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 14.10.2020.
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_ADP{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__EqualDbmsName

public static class TestsFor__EqualDbmsName
{
 [Test]
 public static void Test_01()
 {
  Assert.IsTrue
   (xEFCore.Structure.Structure_ADP.EqualDbmsName
     ("AaAaAa",
      "aAaAaA"));
 }//Test_01
};//class TestsFor__EqualDbmsName

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_ADP

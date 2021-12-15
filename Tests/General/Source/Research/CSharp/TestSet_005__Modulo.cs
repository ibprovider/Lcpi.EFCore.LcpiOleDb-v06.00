////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 01.10.2021.
using NUnit.Framework;

namespace EFCore_LcpiOleDb_Tests.General.Research.CSharp{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_005__Modulo

public static class TestSet_005__Modulo
{
 [Test]
 public static void Test_001__Int16__Decimal()
 {
  System.Int16   left=5;

  System.Decimal right=2.7m;

  object result=left%right;

  Assert.AreEqual
   (2.3m,                // <------- ATTENTION !!! Firebird, for example, returns 2!
    result);
 }//Test_001
};//class TestSet_005__Modulo

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Research.CSharp

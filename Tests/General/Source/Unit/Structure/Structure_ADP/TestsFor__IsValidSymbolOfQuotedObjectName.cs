////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 14.10.2020.
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_ADP{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__IsValidSymbolOfQuotedObjectName

public static class TestsFor__IsValidSymbolOfQuotedObjectName
{
 [Test]
 public static void Test_01__yes()
 {
  for(uint i=1;i!=512;++i)
  {
   Assert.IsTrue
    (xEFCore.Structure.Structure_ADP.IsValidSymbolOfQuotedObjectName((char)(i)));
  }//foreach ch
 }//Test_01__yes

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02__no()
 {
  const string c_chs
   ="\0";

  foreach(char ch in c_chs)
  {
   Assert.IsFalse
    (xEFCore.Structure.Structure_ADP.IsValidSymbolOfQuotedObjectName(ch));
  }//foreach ch
 }//Test_02__no
};//class TestsFor__IsValidSymbolOfQuotedObjectName

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_ADP

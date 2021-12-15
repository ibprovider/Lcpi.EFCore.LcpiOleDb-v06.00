////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 14.10.2020.
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_ADP{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__IsValidSymbolOfUnquotedObjectName_1

public static class TestsFor__IsValidSymbolOfUnquotedObjectName_1
{
 [Test]
 public static void Test_01__yes()
 {
  const string c_chs
   //01234567890123456789012345
   ="abcdefghijklmnopqrstuvwxyz"
   +"ABCDEFGHIJKLMNOPQRSTUVWXYZ";

  foreach(char ch in c_chs)
  {
   Assert.IsTrue
    (xEFCore.Structure.Structure_ADP.IsValidSymbolOfUnquotedObjectName_1(ch));
  }//foreach ch
 }//Test_01__yes

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02__no()
 {
  const string c_chs
   //01234567890123456789012345
   ="0123456789"
   +" \t\n\r\0_$";

  foreach(char ch in c_chs)
  {
   Assert.IsFalse
    (xEFCore.Structure.Structure_ADP.IsValidSymbolOfUnquotedObjectName_1(ch));
  }//foreach ch
 }//Test_02__no
};//class TestsFor__IsValidSymbolOfUnquotedObjectName_1

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_ADP

////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 18.10.2020.
using NUnit.Framework;

using xEFCore_c
 =Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Objects.DataProvider.Dbms.Firebird.Common.FB_Common__Utilities{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__TextToSqlLiteral__char

public static class TestsFor__TextToSqlLiteral__char
{
 [Test]
 public static void Test_01__from_0_to_32()
 {
  for(byte ch=0;ch!=' ';++ch)
  {
   string r="_utf8 x'"+ch.ToString("X2")+"'";

   Assert.AreEqual
    (r,
     xEFCore_c.FB_Common__Utilities.TextToSqlLiteral((char)ch));
  }//for ch
 }//Test_01__from_0_to_32

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02__single_quote()
 {
  Assert.AreEqual
   ("_utf8 ''''",
    xEFCore_c.FB_Common__Utilities.TextToSqlLiteral('\''));
 }//Test_02__single_quote

 //-----------------------------------------------------------------------
 private static readonly string sm_Data03
  //01234567890123456789012345
  ="abcdefghijklmnopqrstuvwxyz"
  +"ABCDEFGHIJKLMNOPQRSTUVWXYZ";

 [Test]
 public static void Test_03()
 {
  foreach(char ch in sm_Data03)
  {
   Assert.AreEqual
    ("_utf8 '"+ch+"'",
     xEFCore_c.FB_Common__Utilities.TextToSqlLiteral(ch));
  }//foreach ch
 }//Test_03
};//class TestsFor__TextToSqlLiteral__char

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Objects.DataProvider.Dbms.Firebird.Common.FB_Common__Utilities

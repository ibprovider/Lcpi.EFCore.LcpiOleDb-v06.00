////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 18.10.2020.
using NUnit.Framework;

using xEFCore_c
 =Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Objects.DataProvider.Dbms.Firebird.Common.FB_Common__Utilities{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__BytesToSqlLiteral

public static class TestsFor__BytesToSqlLiteral
{
 [Test]
 public static void Test_00__empty()
 {
  Assert.AreEqual
   ("x''",
    xEFCore_c.FB_Common__Utilities.BytesToSqlLiteral(new byte[]{}));
 }//Test_00__empty

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_01()
 {
  Assert.AreEqual
   ("x'01'",
    xEFCore_c.FB_Common__Utilities.BytesToSqlLiteral(new byte[]{1}));
 }//Test_01

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02()
 {
  Assert.AreEqual
   ("x'0102'",
    xEFCore_c.FB_Common__Utilities.BytesToSqlLiteral(new byte[]{1,2}));
 }//Test_02

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_03()
 {
  Assert.AreEqual
   ("x'0102FF'",
    xEFCore_c.FB_Common__Utilities.BytesToSqlLiteral(new byte[]{1,2,255}));
 }//Test_03

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_04__all()
 {
  for(byte b=0;;++b)
  {
   string r="x'"+b.ToString("X2")+"'";

   Assert.AreEqual
    (r,
     xEFCore_c.FB_Common__Utilities.BytesToSqlLiteral(new byte[]{b}));

   if(b==255)
    break;
  }//for b
 }//Test_04__all
};//class TestsFor__BytesToSqlLiteral

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Objects.DataProvider.Dbms.Firebird.Common.FB_Common__Utilities

///////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 15.05.2018.
using System;
using System.Diagnostics;
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_MemberId{
////////////////////////////////////////////////////////////////////////////////

using Structure_MemberId
 =xEFCore.Structure.Structure_MemberId;

////////////////////////////////////////////////////////////////////////////////
//class TestsFor__ToString

public static class TestsFor__ToString
{
 [Test]
 public static void Test_01()
 {
  Structure_MemberId x
   =Structure_MemberId.Create_ClassMember(typeof(string),"Length");

  Assert.AreEqual
   ("System.String.Length",
    x.ToString());
 }//Test_01

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02()
 {
  Structure_MemberId x
   =Structure_MemberId.Create_ClassMember(typeof(Nullable<int>),"Value");

  Assert.AreEqual
   ("Nullable<System.Int32>.Value",
    x.ToString());
 }//Test_02
};//class TestsFor__ToString

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_MemberId

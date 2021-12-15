////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 15.05.2018.
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_MemberId{
////////////////////////////////////////////////////////////////////////////////

using Structure_MemberId
 =xEFCore.Structure.Structure_MemberId;

////////////////////////////////////////////////////////////////////////////////
//class TestsFor__Create_ObjectMember

public static class TestsFor__Create_ObjectMember
{
 [Test]
 public static void Test_01()
 {
  var x=Structure_MemberId.Create_ObjectMember(typeof(string),"Length");

  Assert.IsNotNull
   (x);

  Assert.AreEqual
   ("Length",
    x.MemberName);

  Assert.AreEqual
   (false,
    x.MemberIsStatic);

  Assert.AreEqual
   (typeof(string),
    x.ObjectType);
 }//Test_01
};//class TestsFor__Create_ObjectMember

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_MemberId

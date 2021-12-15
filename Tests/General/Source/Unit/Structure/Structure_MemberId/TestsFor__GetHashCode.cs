////////////////////////////////////////////////////////////////////////////////
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
//class TestsFor__GetHashCode

public static class TestsFor__GetHashCode
{
 [Test]
 public static void Test_01()
 {
  Structure_MemberId x=Structure_MemberId.Create_ClassMember(typeof(string),"Length");

  Assert.AreEqual
   (Helper__Hash(x),
    x.GetHashCode());
 }//Test_01

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02__type()
 {
  //Different ObjectType

  Structure_MemberId x1=Structure_MemberId.Create_ClassMember(typeof(string),"Length");
  Structure_MemberId x2=Structure_MemberId.Create_ClassMember(typeof(int),"Length");

  Assert.AreNotEqual
   (x1.GetHashCode(),
    x2.GetHashCode());
 }//Test_02__type

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_03__name()
 {
  //Different MemberName

  Structure_MemberId x1=Structure_MemberId.Create_ClassMember(typeof(string),"Length");
  Structure_MemberId x2=Structure_MemberId.Create_ClassMember(typeof(string),"Length2");

  Assert.AreNotEqual
   (x1.GetHashCode(),
    x2.GetHashCode());
 }//Test_03__name

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_04__is_static()
 {
  //Different MemberIsStatic

  Structure_MemberId x1=Structure_MemberId.Create_ClassMember (typeof(string),"Length");
  Structure_MemberId x2=Structure_MemberId.Create_ObjectMember(typeof(string),"Length");

  Assert.AreNotEqual
   (x1.GetHashCode(),
    x2.GetHashCode());
 }//Test_04__is_static

 //Helper methods --------------------------------------------------------
 private static int Helper__Hash(Structure_MemberId x)
 {
  Debug.Assert(!Object.ReferenceEquals(x,null));
  Debug.Assert(!Object.ReferenceEquals(x.MemberName,null));
  Debug.Assert(!Object.ReferenceEquals(x.ObjectType,null));

  unchecked
  {
   //-----
   var hashCode=x.ObjectType.GetHashCode();

   hashCode=(hashCode*397)^x.MemberName.GetHashCode();

   hashCode=(hashCode*397)^x.MemberIsStatic.GetHashCode();

   return hashCode;
  }//unchecked
 }//Helper__Hash
};//class TestsFor__GetHashCode

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_MemberId

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
//class TestsFor__op_Equal

public static class TestsFor__op_Equal
{
 [Test]
 public static void Test_00__nulls()
 {
  //it is test data
  Structure_MemberId x1=null;
  Structure_MemberId x2=null;

  Assert.IsTrue(x1==x2);
 }//Test_00__nulls

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_01()
 {
  //it is test data
  Structure_MemberId x1=Structure_MemberId.Create_ClassMember(typeof(string),"Length");
  Structure_MemberId x2=null;

  Assert.IsFalse(x1==x2);
 }//Test_01

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_01r()
 {
  //it is test data
  Structure_MemberId x1=Structure_MemberId.Create_ClassMember(typeof(string),"Length");
  Structure_MemberId x2=null;

  Assert.IsFalse(x2==x1);
 }//Test_01r

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02()
 {
  //it is test data
  var x1=Structure_MemberId.Create_ClassMember(typeof(string),"Length");
  var x2=x1;

  Assert.IsTrue(x1==x2);
 }//Test_02

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_03()
 {
  //it is test data
  var x1=Structure_MemberId.Create_ClassMember(typeof(string),"Length");
  var x2=Structure_MemberId.Create_ClassMember(typeof(string),"Length");

  Assert.IsTrue(x1==x2);
 }//Test_03

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_04__no__type()
 {
  //it is test data
  var x1=Structure_MemberId.Create_ClassMember(typeof(int),"Length");
  var x2=Structure_MemberId.Create_ClassMember(typeof(string),"Length");

  Assert.IsFalse(x1==x2);
 }//Test_04__no__type

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_05__no__name()
 {
  //it is test data
  var x1=Structure_MemberId.Create_ClassMember(typeof(string),"Length");
  var x2=Structure_MemberId.Create_ClassMember(typeof(string),"Length2");

  Assert.IsFalse(x1==x2);
 }//Test_05__no__name

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_06__no__is_static()
 {
  //it is test data
  var x1=Structure_MemberId.Create_ObjectMember(typeof(string),"Length");
  var x2=Structure_MemberId.Create_ClassMember(typeof(string),"Length");

  Assert.IsFalse(x1==x2);
 }//Test_06__no__is_static
};//class TestsFor__op_Equal

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_MemberId

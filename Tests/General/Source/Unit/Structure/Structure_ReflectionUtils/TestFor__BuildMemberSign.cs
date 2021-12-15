////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 15.05.2018.
using System;
using System.Reflection;
using System.Linq;

using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

using Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_ReflectionUtils{
////////////////////////////////////////////////////////////////////////////////

using Structure_ReflectionUtils
 =xEFCore.Structure.Structure_ReflectionUtils;

////////////////////////////////////////////////////////////////////////////////
//class TestFor__BuildMemberSign

public static class TestFor__BuildMemberSign
{
 [Test]
 public static void Test_01()
 {
  var m
   =typeof(Nullable<int>).GetMember("Value")[0];

  var s
   =Structure_ReflectionUtils.BuildMemberSign(m);

  Assert.AreEqual
   ("Nullable<System.Int32>.Value",
    s);
 }//Test_01
};//class TestFor__BuildMemberSign

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_ReflectionUtils

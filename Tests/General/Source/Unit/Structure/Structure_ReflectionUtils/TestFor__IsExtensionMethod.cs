////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 15.05.2018.
using System;
using NUnit.Framework;
using System.Reflection;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

using Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_ReflectionUtils{
////////////////////////////////////////////////////////////////////////////////
//class TestFor__IsExtensionMethod

public static class TestFor__IsExtensionMethod
{
 [Test]
 public static void Test_01()
 {
  MethodInfo m
   =typeof(string)
    .Extension__GetRuntimeMethod
      (nameof(string.Contains),
        new System.Type[]
        {
         typeof(string)
        });

  Assert.IsNotNull(m);

  Assert.IsFalse
   (xEFCore.Structure.Structure_ReflectionUtils.IsExtensionMethod(m));
 }//Test_01

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02()
 {
  MethodInfo m
   =typeof(LcpiOleDb__Extensions__Type)
    .Extension__GetRuntimeMethod
      (nameof(LcpiOleDb__Extensions__Type.Extension__GetRuntimeMethod),
        new System.Type[]
        {
         typeof(Type),
         typeof(string),
         typeof(Type[])
        });

  Assert.IsNotNull(m);

  Assert.IsTrue
   (xEFCore.Structure.Structure_ReflectionUtils.IsExtensionMethod(m));
 }//Test_02
};//class TestFor__IsExtensionMethod

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_ReflectionUtils

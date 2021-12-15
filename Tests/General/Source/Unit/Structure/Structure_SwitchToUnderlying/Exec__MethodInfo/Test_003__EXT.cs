////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 18.06.2021.
using System;
using NUnit.Framework;
using System.Reflection;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_SwitchToUnderlying.Exec__MethodInfo{
////////////////////////////////////////////////////////////////////////////////

using Test_003__EXT__Internals;

////////////////////////////////////////////////////////////////////////////////

namespace Test_003__EXT__Internals{
////////////////////////////////////////////////////////////////////////////////
//class T_OBJECT_003

static class T_OBJECT_003
{
 public static TestTypes.Enums.EnumInt16 Exec(this TestTypes.Enums.EnumInt16 x)
 {
  return x;
 }//Exec

 //-----------------------------------------------------------------------
 public static System.Int16 Exec(this System.Int16 x)
 {
  return x;
 }//Exec

 //-----------------------------------------------------------------------
 public static System.Nullable<TestTypes.Enums.EnumInt32> Add2(this System.Collections.Generic.IList<System.Nullable<TestTypes.Enums.EnumInt32>> list,System.Nullable<TestTypes.Enums.EnumInt32> value)
 {
  list.Add(value);

  return value;
 }//Add2

 //-----------------------------------------------------------------------
 public static System.Nullable<System.Int32> Add2(this System.Collections.Generic.IList<System.Nullable<System.Int32>> list,System.Nullable<System.Int32> value)
 {
  list.Add(value);

  return value;
 }//Add2
};//class T_OBJECT_003

////////////////////////////////////////////////////////////////////////////////
}//namespace Test_003__EXT__Internals

////////////////////////////////////////////////////////////////////////////////
//class Test_003__EXT

static class Test_003__EXT
{
 [Test]
 public static void Test_001__Exec_16()
 {
  var sourceType
   =typeof(T_OBJECT_003);

  var sourceMethod
   =sourceType.GetRuntimeMethod
     ("Exec",
      new[]
       {typeof(TestTypes.Enums.EnumInt16)});

  Assert.IsNotNull
   (sourceMethod);

  var expectedType
   =typeof(T_OBJECT_003);

  var expectedMethod
   =expectedType.GetRuntimeMethod
     ("Exec",
      new[]{typeof(System.Int16)});

  Assert.IsNotNull
   (expectedMethod);

  var resultMethod
   =xEFCore.Structure.Structure_SwitchToUnderlying.Exec
     (sourceMethod);

  Assert.AreEqual
   (expectedMethod,
    resultMethod);
 }//Test_001__Exec_16

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002__Add2_Nullable32()
 {
  var sourceType
   =typeof(T_OBJECT_003);

  var sourceMethod
   =sourceType.GetRuntimeMethod
     ("Add2",
      new[]
       {
        typeof(System.Collections.Generic.IList<System.Nullable<TestTypes.Enums.EnumInt32>>),
        typeof(System.Nullable<TestTypes.Enums.EnumInt32>)
       });

  Assert.IsNotNull
   (sourceMethod);

  var expectedType
   =typeof(T_OBJECT_003);

  var expectedMethod
   =expectedType.GetRuntimeMethod
     ("Add2",
      new[]
       {
        typeof(System.Collections.Generic.IList<System.Nullable<System.Int32>>),
        typeof(System.Nullable<System.Int32>)
       });

  Assert.IsNotNull
   (expectedMethod);

  var resultMethod
   =xEFCore.Structure.Structure_SwitchToUnderlying.Exec
     (sourceMethod);

  Assert.AreEqual
   (expectedMethod,
    resultMethod);
 }//Test_002__Add2_Nullable32
};//class Test_003__EXT

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_SwitchToUnderlying.Exec__MethodInfo

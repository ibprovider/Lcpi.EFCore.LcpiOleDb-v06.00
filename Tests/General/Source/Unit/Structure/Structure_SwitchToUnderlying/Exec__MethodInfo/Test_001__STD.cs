////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 18.06.2021.
using System;
using NUnit.Framework;
using System.Reflection;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

using structure_lib=lcpi.lib.structure;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_SwitchToUnderlying.Exec__MethodInfo{
////////////////////////////////////////////////////////////////////////////////
//class Test_001__STD

static class Test_001__STD
{
 private class T_OBJECT
 {
  public TestTypes.Enums.EnumInt16 M16(TestTypes.Enums.EnumInt16 x)
  {
   return x;
  }//M16 - EnumInt16

  public System.Int16 M16(System.Int16 x)
  {
   return x;
  }//M16 - In1t16

  public TestTypes.Enums.EnumInt32 M32(TestTypes.Enums.EnumInt32 x)
  {
   return x;
  }//M32 - EnumInt32
 };//class T_OBJECT

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_001__M16()
 {
  var sourceType
   =typeof(T_OBJECT);

  var sourceMethod
   =sourceType.GetRuntimeMethod
     (nameof(T_OBJECT.M16),
      new[]{typeof(TestTypes.Enums.EnumInt16)});

  Assert.IsNotNull
   (sourceMethod);

  var expectedType
   =typeof(T_OBJECT);

  var expectedMethod
   =expectedType.GetRuntimeMethod
     (nameof(T_OBJECT.M16),
      new[]{typeof(System.Int16)});

  Assert.IsNotNull
   (expectedMethod);

  var resultMethod
   =xEFCore.Structure.Structure_SwitchToUnderlying.Exec
     (sourceMethod);

  Assert.AreEqual
   (expectedMethod,
    resultMethod);
 }//Test_001__M16

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002__GenericListNullable16()
 {
  var sourceType
   =typeof(System.Collections.Generic.List<System.Nullable<TestTypes.Enums.EnumInt16>>);

  var sourceMethod
   =sourceType.GetRuntimeMethod
     ("Add",
      new[]{typeof(System.Nullable<TestTypes.Enums.EnumInt16>)});

  Assert.IsNotNull
   (sourceMethod);

  var expectedType
   =typeof(System.Collections.Generic.List<System.Nullable<System.Int16>>);

  var expectedMethod
   =expectedType.GetRuntimeMethod
     ("Add",
      new[]{typeof(System.Nullable<System.Int16>)});

  Assert.IsNotNull
   (expectedMethod);

  var resultMethod
   =xEFCore.Structure.Structure_SwitchToUnderlying.Exec
     (sourceMethod);

  Assert.AreEqual
   (expectedMethod,
    resultMethod);
 }//Test_002__GenericListNullable16

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_ERR001__M32()
 {
  //
  // TRY MAP
  //
  //  M32(TestTypes.Enums.EnumInt32)
  //
  // TO
  //
  //  M32(System.Int32)
  //

  var sourceType
   =typeof(T_OBJECT);

  var sourceMethod
   =sourceType.GetRuntimeMethod
     (nameof(T_OBJECT.M32),
      new[]{typeof(TestTypes.Enums.EnumInt32)});

  Assert.IsNotNull
   (sourceMethod);

  try
  {
   var resultMethod
    =xEFCore.Structure.Structure_SwitchToUnderlying.Exec
      (sourceMethod);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__common_err__cant_remap_normal_method_3
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__Structure_SwitchToUnderlying,
     "EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_SwitchToUnderlying.Exec__MethodInfo.Test_001__STD+T_OBJECT.M32(EFCore_LcpiOleDb_Tests.General.TestTypes.Enums.EnumInt32)",
     "EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_SwitchToUnderlying.Exec__MethodInfo.Test_001__STD+T_OBJECT",
     "System.Int32");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_001__M16
};//class Test_001__STD

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_SwitchToUnderlying.Exec__MethodInfo

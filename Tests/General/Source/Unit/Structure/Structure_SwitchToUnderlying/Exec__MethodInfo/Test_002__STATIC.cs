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
//class Test_002__STATIC

static class Test_002__STATIC
{
 private class T_OBJECT<T>
 {
  public static T Exec(T x)
  {
   return x;
  }//Exec

  public static T Add(System.Collections.Generic.IList<T> list,T value)
  {
   list.Add(value);

   return value;
  }//Add

  //-------------------------------------------------------
  static public T Exec3(T x,TestTypes.Enums.EnumInt64 e)
  {
   return x;
  }//Exec3

  //-------------------------------------------------------
  static public T Exec4(T x,TestTypes.Enums.EnumInt64 e)
  {
   return x;
  }//Exec4

  public T Exec4(T x,System.Int64 e)
  {
   return x;
  }//Exec4
 };//class T_OBJECT<T>

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_001__Exec_16()
 {
  var sourceType
   =typeof(T_OBJECT<TestTypes.Enums.EnumInt16>);

  var sourceMethod
   =sourceType.GetRuntimeMethod
     ("Exec",
      new[]
       {typeof(TestTypes.Enums.EnumInt16)});

  Assert.IsNotNull
   (sourceMethod);

  var expectedType
   =typeof(T_OBJECT<System.Int16>);

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
 public static void Test_002__Add_Nullable32()
 {
  var sourceType
   =typeof(T_OBJECT<System.Nullable<TestTypes.Enums.EnumInt32>>);

  var sourceMethod
   =sourceType.GetRuntimeMethod
     ("Add",
      new[]
       {
        typeof(System.Collections.Generic.IList<System.Nullable<TestTypes.Enums.EnumInt32>>),
        typeof(System.Nullable<TestTypes.Enums.EnumInt32>)
       });

  Assert.IsNotNull
   (sourceMethod);

  var expectedType
   =typeof(T_OBJECT<System.Nullable<System.Int32>>);

  var expectedMethod
   =expectedType.GetRuntimeMethod
     ("Add",
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
 }//Test_002__Add_Nullable32

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_ERR001__Exec3()
 {
  //
  // TRY MAP
  //
  //  Exec3<TestTypes.Enums.EnumInt16>(TestTypes.Enums.EnumInt16, TestTypes.Enums.EnumInt64)
  //
  // TO
  //
  //  Exec3<System.Int16>(System.Int16, System.Int64)
  //

  //----------------------------------------
  var sourceType
   =typeof(T_OBJECT<TestTypes.Enums.EnumInt16>);

  var sourceMethod
   =sourceType.GetRuntimeMethod
     ("Exec3",
      new[]
       {typeof(TestTypes.Enums.EnumInt16),typeof(TestTypes.Enums.EnumInt64)});

  Assert.IsNotNull
   (sourceMethod);

  //----------------------------------------
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
     "EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_SwitchToUnderlying.Exec__MethodInfo.Test_002__STATIC+T_OBJECT<EFCore_LcpiOleDb_Tests.General.TestTypes.Enums.EnumInt16>.Exec3(EFCore_LcpiOleDb_Tests.General.TestTypes.Enums.EnumInt16, EFCore_LcpiOleDb_Tests.General.TestTypes.Enums.EnumInt64)",
     "EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_SwitchToUnderlying.Exec__MethodInfo.Test_002__STATIC+T_OBJECT<System.Int16>",
     "System.Int16, System.Int64");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_ERR001__Exec3

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_ERR002__Exec4()
 {
  //
  // TRY MAP
  //
  //  Exec4<TestTypes.Enums.EnumInt16>(TestTypes.Enums.EnumInt16, TestTypes.Enums.EnumInt64)
  //
  // TO
  //
  //  Exec4<System.Int16>(System.Int16, System.Int64)
  //
  //  MUST IGNORE INSTANCE VARIANT
  //

  //----------------------------------------
  var sourceType
   =typeof(T_OBJECT<TestTypes.Enums.EnumInt16>);

  var sourceMethod
   =sourceType.GetRuntimeMethod
     ("Exec4",
      new[]
       {typeof(TestTypes.Enums.EnumInt16),typeof(TestTypes.Enums.EnumInt64)});

  Assert.IsNotNull
   (sourceMethod);

  //----------------------------------------
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
     "EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_SwitchToUnderlying.Exec__MethodInfo.Test_002__STATIC+T_OBJECT<EFCore_LcpiOleDb_Tests.General.TestTypes.Enums.EnumInt16>.Exec4(EFCore_LcpiOleDb_Tests.General.TestTypes.Enums.EnumInt16, EFCore_LcpiOleDb_Tests.General.TestTypes.Enums.EnumInt64)",
     "EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_SwitchToUnderlying.Exec__MethodInfo.Test_002__STATIC+T_OBJECT<System.Int16>",
     "System.Int16, System.Int64");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_ERR002__Exec4
};//class Test_002__STATIC

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_SwitchToUnderlying.Exec__MethodInfo

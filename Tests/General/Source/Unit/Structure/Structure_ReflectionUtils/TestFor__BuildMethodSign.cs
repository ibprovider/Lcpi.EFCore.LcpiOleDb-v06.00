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

using Structure_MethodInfoCache
 =xEFCore.Structure.Structure_MethodInfoCache;

////////////////////////////////////////////////////////////////////////////////
//class TestFor__BuildMethodSign

public static class TestFor__BuildMethodSign
{
 [Test]
 public static void Test_01()
 {
  var s
   =Structure_ReflectionUtils.BuildMethodSign(Structure_MethodInfoCache.MethodInfoOf__Object__std__Equals__object);

  Assert.AreEqual
   ("System.Object.Equals(System.Object)",
    s);
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

  var s
   =Structure_ReflectionUtils.BuildMethodSign(m);

  Assert.AreEqual
   ("Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.LcpiOleDb__Extensions__Type.Extension__GetRuntimeMethod(this System.Type, System.String, System.Type[])",
    s);
 }//Test_02

 //-----------------------------------------------------------------------
 public static void FUNC3(int x)
 {
  x=0;
 }//FUNC3

 //-----------------------------------------------------------------------
 public static void FUNC3(ref int x)
 {
  x=0;
 }//FUNC3

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_03__ByVal()
 {
  MethodInfo m
   =typeof(TestFor__BuildMethodSign)
    .Extension__GetRuntimeMethod
      (nameof(TestFor__BuildMethodSign.FUNC3),
        new System.Type[]
        {
         typeof(int)
        });

  Assert.IsNotNull(m);

  var s
   =Structure_ReflectionUtils.BuildMethodSign(m);

  Assert.AreEqual
   ("EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_ReflectionUtils.TestFor__BuildMethodSign.FUNC3(System.Int32)",
    s);
 }//Test_03__ByVal

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_03__ByRef()
 {
  MethodInfo m
   =typeof(TestFor__BuildMethodSign)
    .Extension__GetRuntimeMethod
      (nameof(TestFor__BuildMethodSign.FUNC3),
        new System.Type[]
        {
         typeof(int).MakeByRefType()
        });

  Assert.IsNotNull(m);

  var s
   =Structure_ReflectionUtils.BuildMethodSign(m);

  Assert.AreEqual
   ("EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_ReflectionUtils.TestFor__BuildMethodSign.FUNC3(System.Int32 ByRef)",
    s);
 }//Test_03__ByRef

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_04__Dictionary_string_nullableInt32__Add()
 {
  MethodInfo m
   =typeof(System.Collections.Generic.Dictionary<string,int?>)
    .Extension__GetRuntimeMethod
      ("Add",
        new System.Type[]
        {
         typeof(string),
         typeof(int?)
        });

  Assert.IsNotNull(m);

  var s
   =Structure_ReflectionUtils.BuildMethodSign(m);

  Assert.AreEqual
   ("System.Collections.Generic.Dictionary<System.String, Nullable<System.Int32>>.Add(System.String, Nullable<System.Int32>)",
    s);
 }//Test_04__Dictionary_string_nullableInt32__Add

 //-----------------------------------------------------------------------
 private static T EXEC_05<T>(System.Collections.Generic.IList<T> list,T v)
 {
  list.Add(v);

  return v;
 }//EXEC_05

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_05__GenericMethod1()
 {
  var m_g
   =GetMethod
    ("EXEC_05",
     1,
     types => new[]{ typeof(System.Collections.Generic.IList<>).MakeGenericType(types[0]), types[0] });

  Assert.IsNotNull(m_g);

  var m
   =m_g.MakeGenericMethod
     (new System.Type[]
      {
       typeof(System.Int32)
      });

  Assert.IsNotNull(m);

  var s
   =Structure_ReflectionUtils.BuildMethodSign
     (m);

  Assert.AreEqual
   ("EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_ReflectionUtils.TestFor__BuildMethodSign.EXEC_05<System.Int32>(System.Collections.Generic.IList<System.Int32>, System.Int32)",
    s);
 }//Test_05__GenericMethod1

 //-----------------------------------------------------------------------
 private static T1 EXEC_06<T1,T2>(Nullable<T1> v1,Nullable<T2> v2)
  where T1: struct
  where T2: struct
 {
  return v1.Value;
 }//EXEC_06

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_06__GenericMethod2()
 {
  var m_g
   =GetMethod
    ("EXEC_06",
     2,
     types => new[]{ typeof(System.Nullable<>).MakeGenericType(types[0]), typeof(System.Nullable<>).MakeGenericType(types[1]) });

  Assert.IsNotNull(m_g);

  var m
   =m_g.MakeGenericMethod
     (new System.Type[]
      {
       typeof(System.Int32),
       typeof(System.Int64)
      });

  Assert.IsNotNull(m);

  var s
   =Structure_ReflectionUtils.BuildMethodSign
     (m);

  Assert.AreEqual
   ("EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_ReflectionUtils.TestFor__BuildMethodSign.EXEC_06<System.Int32, System.Int64>(Nullable<System.Int32>, Nullable<System.Int64>)",
    s);
 }//Test_06__GenericMethod2

 //-----------------------------------------------------------------------
 private static MethodInfo GetMethod(string               name,
                                     int                  genericParameterCount,
                                     Func<Type[], Type[]> parameterGenerator)
 {
  var queryableMethodGroups
   =typeof(TestFor__BuildMethodSign)
     .GetMethods(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.DeclaredOnly)
     .GroupBy(mi => mi.Name)
     .ToDictionary(e => e.Key, l => l.ToList());

  var r
   =queryableMethodGroups[name].Single
     (
      mi => ((genericParameterCount == 0 && !mi.IsGenericMethod) || (mi.IsGenericMethod && mi.GetGenericArguments().Length == genericParameterCount))
            && mi.GetParameters().Select(e => e.ParameterType).SequenceEqual(parameterGenerator(mi.IsGenericMethod ? mi.GetGenericArguments() : Array.Empty<Type>()))
     );

  return r;
 }//GetMethod
};//class TestFor__BuildMethodSign

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_ReflectionUtils

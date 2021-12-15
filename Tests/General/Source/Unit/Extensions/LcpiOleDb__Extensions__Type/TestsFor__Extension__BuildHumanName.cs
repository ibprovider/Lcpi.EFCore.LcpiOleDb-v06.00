////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 13.10.2020.
using NUnit.Framework;

using Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Extensions.LcpiOleDb__Extensions__Type{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__Extension__BuildHumanName

public static class TestsFor__Extension__BuildHumanName
{
 [Test]
 public static void Test_01__Int32()
 {
  Assert.AreEqual
   ("System.Int32",
    typeof(System.Int32).Extension__BuildHumanName());
 }//Test_01__Int32

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02__Nullable_Int32()
 {
  Assert.AreEqual
   ("Nullable<System.Int32>",
    typeof(System.Nullable<System.Int32>).Extension__BuildHumanName());
 }//Test_02__Nullable_Int32

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_03__Array_Of_Nullable_Int32()
 {
  Assert.AreEqual
   ("Nullable<System.Int32>[]",
    typeof(System.Nullable<System.Int32>[]).Extension__BuildHumanName());
 }//Test_03__Array_Of_Nullable_Int32

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_04__Dictionary_string_int()
 {
  Assert.AreEqual
   ("System.Collections.Generic.Dictionary<System.String, System.Int32>",
    typeof(System.Collections.Generic.Dictionary<string,int>).Extension__BuildHumanName());
 }//Test_04__Dictionary_string_int

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_05__Dictionary_generic()
 {
  Assert.AreEqual
   ("System.Collections.Generic.Dictionary<,>",
    typeof(System.Collections.Generic.Dictionary<,>).Extension__BuildHumanName());
 }//Test_05__Dictionary_generic

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_06__Nullable_generic()
 {
  Assert.AreEqual
   ("Nullable<>",
    typeof(System.Nullable<>).Extension__BuildHumanName());
 }//Test_06__Nullable_generic

 //-----------------------------------------------------------------------
 static class tagCLASS07_00
 {
  static public class tagCLASS07_01<T>
  {
   static public class tagCLASS07_02
   {
    public static T EXEC(T v)
    {
     return v;
    }//EXEC
   }//class tagCLASS07_02
  }//class tagCLASS07_01<T>
 }//class tagCLASS07_00

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_07__nested_01_spec()
 {
  Assert.AreEqual
   ("EFCore_LcpiOleDb_Tests.General.Unit.Extensions.LcpiOleDb__Extensions__Type.TestsFor__Extension__BuildHumanName+tagCLASS07_00+tagCLASS07_01<System.Int32>+tagCLASS07_02",
    typeof(tagCLASS07_00.tagCLASS07_01<int>.tagCLASS07_02).Extension__BuildHumanName());
 }//Test_07__nested_01_spec

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_07__nested_02_gen()
 {
  Assert.AreEqual
   ("EFCore_LcpiOleDb_Tests.General.Unit.Extensions.LcpiOleDb__Extensions__Type.TestsFor__Extension__BuildHumanName+tagCLASS07_00+tagCLASS07_01<>+tagCLASS07_02",
    typeof(tagCLASS07_00.tagCLASS07_01<>.tagCLASS07_02).Extension__BuildHumanName());
 }//Test_07__nested_02_gen

 //-----------------------------------------------------------------------
 static class tagCLASS08_00
 {
  static public class tagCLASS08_01<T1>
  {
   static public class tagCLASS08_02<T2,T3>
   {
    public static T1 EXEC(T1 v)
    {
     return v;
    }//EXEC
   }//class tagCLASS08_02<T2,T3>
  }//class tagCLASS08_01<T>
 }//class tagCLASS08_00

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_08__nested_01_spec()
 {
  Assert.AreEqual
   ("EFCore_LcpiOleDb_Tests.General.Unit.Extensions.LcpiOleDb__Extensions__Type.TestsFor__Extension__BuildHumanName+tagCLASS08_00+tagCLASS08_01<System.Int32>+tagCLASS08_02<System.Int16, System.String>",
    typeof(tagCLASS08_00.tagCLASS08_01<int>.tagCLASS08_02<short,string>).Extension__BuildHumanName());
 }//Test_08__nested_01_spec

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_08__nested_02_gen()
 {
  Assert.AreEqual
   ("EFCore_LcpiOleDb_Tests.General.Unit.Extensions.LcpiOleDb__Extensions__Type.TestsFor__Extension__BuildHumanName+tagCLASS08_00+tagCLASS08_01<>+tagCLASS08_02<,>",
    typeof(tagCLASS08_00.tagCLASS08_01<>.tagCLASS08_02<,>).Extension__BuildHumanName());
 }//Test_08__nested_02_gen

 //-----------------------------------------------------------------------
 static class tagCLASS09_00
 {
  static public class tagCLASS09_01<T1>
  {
   static public class tagCLASS09_02
   {
    static public class tagCLASS09_03<T2,T3>
    {
     public static T1 EXEC(T1 v)
     {
      return v;
     }//EXEC
    }//class tagCLASS09_03<T2,T3>
   }//class tagCLASS09_02
  }//class tagCLASS09_01<T>
 }//class tagCLASS09_00

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_09__nested_01_spec()
 {
  Assert.AreEqual
   ("EFCore_LcpiOleDb_Tests.General.Unit.Extensions.LcpiOleDb__Extensions__Type.TestsFor__Extension__BuildHumanName+tagCLASS09_00+tagCLASS09_01<System.Int32>+tagCLASS09_02+tagCLASS09_03<System.Int16, System.String>",
    typeof(tagCLASS09_00.tagCLASS09_01<int>.tagCLASS09_02.tagCLASS09_03<short,string>).Extension__BuildHumanName());
 }//Test_09__nested_01_spec

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_09__nested_02_gen()
 {
  Assert.AreEqual
   ("EFCore_LcpiOleDb_Tests.General.Unit.Extensions.LcpiOleDb__Extensions__Type.TestsFor__Extension__BuildHumanName+tagCLASS09_00+tagCLASS09_01<>+tagCLASS09_02+tagCLASS09_03<,>",
    typeof(tagCLASS09_00.tagCLASS09_01<>.tagCLASS09_02.tagCLASS09_03<,>).Extension__BuildHumanName());
 }//Test_09__nested_02_gen

 //-----------------------------------------------------------------------
 interface tagINTERFACE10_01<T1,T2>{ };
 interface tagINTERFACE10_03<T1>{ };

 class tagCLASS10_00
 {
  public class tagCLASS10_01<T1>:tagINTERFACE10_01<T1,T1>
  {
   public class tagCLASS10_02
   {
    public class tagCLASS10_03<T2,T3>:tagINTERFACE10_03<T3>
    {
     public static T1 EXEC(T1 v)
     {
      return v;
     }//EXEC
    }//class tagCLASS10_03<T2,T3>
   }//class tagCLASS10_02
  }//class tagCLASS10_01<T>
 }//class tagCLASS10_00

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_10__nested_01_spec()
 {
  Assert.AreEqual
   ("EFCore_LcpiOleDb_Tests.General.Unit.Extensions.LcpiOleDb__Extensions__Type.TestsFor__Extension__BuildHumanName+tagCLASS10_00+tagCLASS10_01<System.Int32>+tagCLASS10_02+tagCLASS10_03<System.Int16, System.String>",
    typeof(tagCLASS10_00.tagCLASS10_01<int>.tagCLASS10_02.tagCLASS10_03<short,string>).Extension__BuildHumanName());
 }//Test_10__nested_01_spec

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_10__nested_02_gen()
 {
  Assert.AreEqual
   ("EFCore_LcpiOleDb_Tests.General.Unit.Extensions.LcpiOleDb__Extensions__Type.TestsFor__Extension__BuildHumanName+tagCLASS10_00+tagCLASS10_01<>+tagCLASS10_02+tagCLASS10_03<,>",
    typeof(tagCLASS10_00.tagCLASS10_01<>.tagCLASS10_02.tagCLASS10_03<,>).Extension__BuildHumanName());
 }//Test_10__nested_02_gen
};//class TestsFor__Extension__BuildHumanName

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Extensions.LcpiOleDb__Extensions__Type

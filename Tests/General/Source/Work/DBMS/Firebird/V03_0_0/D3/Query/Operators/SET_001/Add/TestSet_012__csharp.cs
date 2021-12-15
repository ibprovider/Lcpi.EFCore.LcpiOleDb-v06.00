////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 02.01.2021.
using NUnit.Framework;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Operators.SET_001.Add{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_012__csharp

public static class TestSet_012__csharp
{
 [Test]
 public static void Test__Int16()
 {
  Assert.AreEqual(null        , sm_Int16__p1  +  sm_NullableInt16__null);
  Assert.AreEqual(null        , sm_Int16__p1  +  sm_NullableInt32__null);
  Assert.AreEqual(null        , sm_Int16__p1  +  sm_NullableInt64__null);

  Assert.AreEqual("1"         , sm_Int16__p1  +  sm_String__null);
  Assert.AreEqual("1"         , sm_Int16__p1  +  sm_String__empty);
  Assert.AreEqual("1AAA"      , sm_Int16__p1  +  sm_String__AAA);
 }//Test__Int16

 //-----------------------------------------------------------------------
 [Test]
 public static void Test__Int32()
 {
  Assert.AreEqual(null        , sm_Int32__p1  +  sm_NullableInt16__null);
  Assert.AreEqual(null        , sm_Int32__p1  +  sm_NullableInt32__null);
  Assert.AreEqual(null        , sm_Int32__p1  +  sm_NullableInt64__null);

  Assert.AreEqual("1"         , sm_Int32__p1  +  sm_String__null);
  Assert.AreEqual("1"         , sm_Int32__p1  +  sm_String__empty);
  Assert.AreEqual("1AAA"      , sm_Int32__p1  +  sm_String__AAA);
 }//Test__Int32

 //-----------------------------------------------------------------------
 [Test]
 public static void Test__Int64()
 {
  Assert.AreEqual(null        , sm_Int64__p1  +  sm_NullableInt16__null);
  Assert.AreEqual(null        , sm_Int64__p1  +  sm_NullableInt32__null);
  Assert.AreEqual(null        , sm_Int64__p1  +  sm_NullableInt64__null);

  Assert.AreEqual("1"         , sm_Int64__p1  +  sm_String__null);
  Assert.AreEqual("1"         , sm_Int64__p1  +  sm_String__empty);
  Assert.AreEqual("1AAA"      , sm_Int64__p1  +  sm_String__AAA);
 }//Test__Int64

 //-----------------------------------------------------------------------
 [Test]
 public static void Test__NullableInt16()
 {
  Assert.AreEqual(null        , sm_NullableInt16__p1  +  sm_NullableInt16__null);
  Assert.AreEqual(null        , sm_NullableInt16__p1  +  sm_NullableInt32__null);
  Assert.AreEqual(null        , sm_NullableInt16__p1  +  sm_NullableInt64__null);

  Assert.AreEqual(null        , sm_NullableInt16__null  +  sm_NullableInt16__p1);
  Assert.AreEqual(null        , sm_NullableInt16__null  +  sm_NullableInt32__p1);
  Assert.AreEqual(null        , sm_NullableInt16__null  +  sm_NullableInt64__p1);

  Assert.AreEqual("1"         , sm_NullableInt16__p1  +  sm_String__null);
  Assert.AreEqual("1"         , sm_NullableInt16__p1  +  sm_String__empty);
  Assert.AreEqual("1AAA"      , sm_NullableInt16__p1  +  sm_String__AAA);

  Assert.AreEqual(""          , sm_NullableInt16__null  +  sm_String__null);
  Assert.AreEqual(""          , sm_NullableInt16__null  +  sm_String__empty);
  Assert.AreEqual("AAA"       , sm_NullableInt16__null  +  sm_String__AAA);
 }//Test__NullableInt16

 //-----------------------------------------------------------------------
 [Test]
 public static void Test__NullableInt32()
 {
  Assert.AreEqual(null        , sm_NullableInt32__p1  +  sm_NullableInt16__null);
  Assert.AreEqual(null        , sm_NullableInt32__p1  +  sm_NullableInt32__null);
  Assert.AreEqual(null        , sm_NullableInt32__p1  +  sm_NullableInt64__null);

  Assert.AreEqual(null        , sm_NullableInt32__null  +  sm_NullableInt16__p1);
  Assert.AreEqual(null        , sm_NullableInt32__null  +  sm_NullableInt32__p1);
  Assert.AreEqual(null        , sm_NullableInt32__null  +  sm_NullableInt64__p1);

  Assert.AreEqual("1"         , sm_NullableInt32__p1  +  sm_String__null);
  Assert.AreEqual("1"         , sm_NullableInt32__p1  +  sm_String__empty);
  Assert.AreEqual("1AAA"      , sm_NullableInt32__p1  +  sm_String__AAA);

  Assert.AreEqual(""          , sm_NullableInt32__null  +  sm_String__null);
  Assert.AreEqual(""          , sm_NullableInt32__null  +  sm_String__empty);
  Assert.AreEqual("AAA"       , sm_NullableInt32__null  +  sm_String__AAA);
 }//Test__NullableInt16

 //-----------------------------------------------------------------------
 [Test]
 public static void Test__NullableInt64()
 {
  Assert.AreEqual(null        , sm_NullableInt64__p1  +  sm_NullableInt16__null);
  Assert.AreEqual(null        , sm_NullableInt64__p1  +  sm_NullableInt32__null);
  Assert.AreEqual(null        , sm_NullableInt64__p1  +  sm_NullableInt64__null);

  Assert.AreEqual(null        , sm_NullableInt64__null  +  sm_NullableInt16__p1);
  Assert.AreEqual(null        , sm_NullableInt64__null  +  sm_NullableInt32__p1);
  Assert.AreEqual(null        , sm_NullableInt64__null  +  sm_NullableInt64__p1);

  Assert.AreEqual("1"         , sm_NullableInt64__p1  +  sm_String__null);
  Assert.AreEqual("1"         , sm_NullableInt64__p1  +  sm_String__empty);
  Assert.AreEqual("1AAA"      , sm_NullableInt64__p1  +  sm_String__AAA);

  Assert.AreEqual(""          , sm_NullableInt64__null  +  sm_String__null);
  Assert.AreEqual(""          , sm_NullableInt64__null  +  sm_String__empty);
  Assert.AreEqual("AAA"       , sm_NullableInt64__null  +  sm_String__AAA);
 }//Test__NullableInt64

 //-----------------------------------------------------------------------
 [Test]
 public static void Test__String()
 {
  Assert.AreEqual(""          , sm_String__null  +  sm_Object__null);

  Assert.AreEqual(""          , sm_String__null  +  sm_NullableInt16__null);
  Assert.AreEqual(""          , sm_String__null  +  sm_NullableInt32__null);
  Assert.AreEqual(""          , sm_String__null  +  sm_NullableInt64__null);

  Assert.AreEqual("1"         , sm_String__null  +  sm_NullableInt16__p1);
  Assert.AreEqual("1"         , sm_String__null  +  sm_NullableInt32__p1);
  Assert.AreEqual("1"         , sm_String__null  +  sm_NullableInt64__p1);

  Assert.AreEqual(""          , sm_String__null  +  sm_String__null);
  Assert.AreEqual(""          , sm_String__null  +  sm_String__empty);
  Assert.AreEqual("AAA"       , sm_String__null  +  sm_String__AAA);

  //----------------------------------------
  Assert.AreEqual(""          , sm_String__empty +  sm_Object__null);

  Assert.AreEqual(""          , sm_String__empty +  sm_NullableInt16__null);
  Assert.AreEqual(""          , sm_String__empty +  sm_NullableInt32__null);
  Assert.AreEqual(""          , sm_String__empty +  sm_NullableInt64__null);

  Assert.AreEqual("1"         , sm_String__empty +  sm_NullableInt16__p1);
  Assert.AreEqual("1"         , sm_String__empty +  sm_NullableInt32__p1);
  Assert.AreEqual("1"         , sm_String__empty +  sm_NullableInt64__p1);

  Assert.AreEqual(""          , sm_String__empty +  sm_String__null);
  Assert.AreEqual(""          , sm_String__empty +  sm_String__empty);
  Assert.AreEqual("AAA"       , sm_String__empty +  sm_String__AAA);

  //----------------------------------------
  Assert.AreEqual("AAA"       , sm_String__AAA   +  sm_Object__null);

  Assert.AreEqual("AAA"       , sm_String__AAA   +  sm_NullableInt16__null);
  Assert.AreEqual("AAA"       , sm_String__AAA   +  sm_NullableInt32__null);
  Assert.AreEqual("AAA"       , sm_String__AAA   +  sm_NullableInt64__null);

  Assert.AreEqual("AAA1"      , sm_String__AAA   +  sm_NullableInt16__p1);
  Assert.AreEqual("AAA1"      , sm_String__AAA   +  sm_NullableInt32__p1);
  Assert.AreEqual("AAA1"      , sm_String__AAA   +  sm_NullableInt64__p1);

  Assert.AreEqual("AAA"       , sm_String__AAA   +  sm_String__null);
  Assert.AreEqual("AAA"       , sm_String__AAA   +  sm_String__empty);
  Assert.AreEqual("AAAAAA"    , sm_String__AAA   +  sm_String__AAA);
 }//Test__String

 //private data ----------------------------------------------------------
 private static readonly System.Object sm_Object__null=null;

 private static readonly System.Int16? sm_Int16__p1=1;
 private static readonly System.Int32? sm_Int32__p1=1;
 private static readonly System.Int64? sm_Int64__p1=1;

 private static readonly System.Int16? sm_NullableInt16__p1=1;
 private static readonly System.Int32? sm_NullableInt32__p1=1;
 private static readonly System.Int64? sm_NullableInt64__p1=1;

 private static readonly System.Int16? sm_NullableInt16__null=null;
 private static readonly System.Int32? sm_NullableInt32__null=null;
 private static readonly System.Int64? sm_NullableInt64__null=null;

 private static readonly System.String sm_String__null   =null;
 private static readonly System.String sm_String__empty  ="";
 private static readonly System.String sm_String__AAA    ="AAA";
};//class TestSet_012__csharp

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Operators.SET_001.Add

////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 15.05.2018.
using NUnit.Framework;

namespace EFCore_LcpiOleDb_Tests.General.Research.CSharp{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_01

class TestSet_001__CallOfPrivateMethod
{
 private class tagObj
 {
  private bool Method(int x,out int y)
  {
   y=-x;

   return true;
  }//Method
 };//class tagObj

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_01()
 {
  var obj=new tagObj();

  System.Reflection.MethodInfo
   dynMethod1
    =obj.GetType().GetMethod
       ("Method",
        System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

  Assert.IsNotNull
   (dynMethod1);

  var dynMethod2
   =obj.GetType().GetMethod
       ("Method",
        System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance,
        null,
        new[]{typeof(int),typeof(int).MakeByRefType()},
        null);

  Assert.IsNotNull
   (dynMethod2);

  Assert.AreEqual
   (dynMethod1,
    dynMethod2);

  var dynMethod3
   =obj.GetType().GetMethod
       ("Method",
        System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance,
        null,
        new[]{typeof(int),typeof(int)}, //special tests
        null);

  Assert.IsNull
   (dynMethod3);

  var callArgs
   =new object[]
    {
     /* 0 */ 42,
     /* 1 */ /*out*/ null,
    };//callArgs

  object rr=dynMethod1.Invoke(obj, callArgs);

  Assert.AreEqual
   (true,
    rr);

  Assert.AreEqual
   (-42,
    callArgs[1]);
 }//Test_01

 //-----------------------------------------------------------------------
 private class tagObj2:tagObj
 {
  private bool Method(int x,out int y)
  {
   y=-x;

   return true;
  }//Method
 };//class tagObj

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02()
 {
  var obj=new tagObj2();

  System.Reflection.MethodInfo
   dynMethod1
    =typeof(tagObj).GetMethod
       ("Method",
        System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

  Assert.IsNotNull
   (dynMethod1);

  var dynMethod2
   =typeof(tagObj).GetMethod
       ("Method",
        System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance,
        null,
        new[]{typeof(int),typeof(int).MakeByRefType()},
        null);

  Assert.IsNotNull
   (dynMethod2);

  Assert.AreEqual
   (dynMethod1,
    dynMethod2);

  var dynMethod3
   =typeof(tagObj).GetMethod
       ("Method",
        System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance,
        null,
        new[]{typeof(int),typeof(int)}, //special tests
        null);

  Assert.IsNull
   (dynMethod3);

  var callArgs
   =new object[]
    {
     /* 0 */ 42,
     /* 1 */ /*out*/ null,
    };//callArgs

  object rr=dynMethod1.Invoke(obj, callArgs);

  Assert.AreEqual
   (true,
    rr);

  Assert.AreEqual
   (-42,
    callArgs[1]);
 }//Test_02
};//class TestSet_001__CallOfPrivateMethod

////////////////////////////////////////////////////////////////////////////////
}//namespace TestSet_001__CallOfPrivateMethod

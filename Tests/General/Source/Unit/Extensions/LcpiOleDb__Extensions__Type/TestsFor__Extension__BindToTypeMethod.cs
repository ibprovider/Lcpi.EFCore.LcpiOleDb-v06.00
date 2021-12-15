////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 13.10.2020.
using System.Reflection;
using NUnit.Framework;

using Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

using structure_lib=lcpi.lib.structure;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Extensions.LcpiOleDb__Extensions__Type{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__Extension__BindToTypeMethod

public static class TestsFor__Extension__BindToTypeMethod
{
 class tagObj
 {
  private void method(int a,out long b)
  {
   b=-a;
  }

  private int method(short r)
  {
   return -r;
  }
 };//class tagObj

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_01()
 {
  var x=new tagObj();

  var m
   =x.GetType().Extension__BindToTypeMethod
     ("method",
      typeof(void),
      new System.Type[]
      {
       typeof(int),
       typeof(long).MakeByRefType(),
      },
      BindingFlags.NonPublic|BindingFlags.Instance);

  Assert.NotNull(m);

  Assert.AreEqual
   (typeof(tagObj),
    m.DeclaringType);

  Assert.AreEqual
   ("method",
    m.Name);

  Assert.AreEqual
   (typeof(void),
    m.ReturnType);

  var mParams
   =m.GetParameters();

  Assert.NotNull
   (mParams);

  Assert.AreEqual
   (2,
    mParams.Length);

  Assert.NotNull (mParams[0]);
  Assert.NotNull (mParams[1]);

  Assert.NotNull (mParams[0].ParameterType);
  Assert.NotNull (mParams[1].ParameterType);

  Assert.AreEqual (typeof(int)                  , mParams[0].ParameterType);
  Assert.AreEqual (typeof(long).MakeByRefType() , mParams[1].ParameterType);

  //----
  var args=new object[]{1,null};

  m.Invoke(x,args);

  Assert.AreEqual
   (1,
    args[0]);

  Assert.AreEqual
   (-1L,
    args[1]);
 }//Test_01

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02()
 {
  var x=new tagObj();

  var m
   =x.GetType().Extension__BindToTypeMethod
     ("method",
      typeof(int),
      new System.Type[]
      {
       typeof(short),
      },
      BindingFlags.NonPublic|BindingFlags.Instance);

  Assert.NotNull(m);

  Assert.AreEqual
   (typeof(tagObj),
    m.DeclaringType);

  Assert.AreEqual
   ("method",
    m.Name);

  Assert.AreEqual
   (typeof(int),
    m.ReturnType);

  var mParams
   =m.GetParameters();

  Assert.NotNull
   (mParams);

  Assert.AreEqual
   (1,
    mParams.Length);

  Assert.NotNull (mParams[0]);

  Assert.NotNull (mParams[0].ParameterType);

  Assert.AreEqual (typeof(short), mParams[0].ParameterType);

  //----
  var args=new object[]{(short)1};

  var res=m.Invoke(x,args);

  Assert.AreEqual
   (1,
    args[0]);

  Assert.AreEqual
   (-1,
    res);
 }//Test_02

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_E1___not_found()
 {
  var x=new tagObj();

  try
  {
   var m
    =x.GetType().Extension__BindToTypeMethod
      ("method",
       typeof(int),
       new System.Type[]
       {
        typeof(string), typeof(int),
       },
       BindingFlags.NonPublic|BindingFlags.Instance);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception exc)
  {
   CheckErrors.PrintException_OK(exc);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(exc));

   Assert.IsNotNull
    (TestUtils.GetRecord(exc,0));

   CheckErrors.CheckErrorRecord__bug_check__bind_to_type_method__not_found_4
    (TestUtils.GetRecord(exc,0),
     CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__Extensions__Type,
     typeof(tagObj),
     "method",
     "System.String, System.Int32",
     BindingFlags.NonPublic|BindingFlags.Instance);
  }//catch
 }//Test_E1___not_found

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_E2___bad_return_type()
 {
  var x=new tagObj();

  try
  {
   var m
    =x.GetType().Extension__BindToTypeMethod
      ("method",
       typeof(long),
       new System.Type[]
       {
        typeof(short),
       },
       BindingFlags.NonPublic|BindingFlags.Instance);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception exc)
  {
   CheckErrors.PrintException_OK(exc);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(exc));

   Assert.IsNotNull
    (TestUtils.GetRecord(exc,0));

   CheckErrors.CheckErrorRecord__bug_check__bind_to_type_method__bad_return_type_6
    (TestUtils.GetRecord(exc,0),
     CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__Extensions__Type,
     typeof(tagObj),
     "method",
     "System.Int16",
     BindingFlags.NonPublic|BindingFlags.Instance,
     /*expected*/"System.Int64",
     /*actual*/"System.Int32");
  }//catch
 }//Test_E2___bad_return_type
};//class TestsFor__Extension__BindToTypeMethod

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Extensions.LcpiOleDb__Extensions__Type

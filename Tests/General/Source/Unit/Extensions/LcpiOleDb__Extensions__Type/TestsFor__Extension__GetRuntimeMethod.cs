////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 13.10.2020.
using NUnit.Framework;

using Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

using structure_lib=lcpi.lib.structure;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Extensions.LcpiOleDb__Extensions__Type{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__Extension__GetRuntimeMethod

public static class TestsFor__Extension__GetRuntimeMethod
{
 [Test]
 public static void Test_01__String_Contains_Char()
 {
  var m
   =typeof(string).Extension__GetRuntimeMethod
     (nameof(string.Contains),
      new System.Type[]
      {
       typeof(System.Char)
      });

  Assert.NotNull(m);

  Assert.AreEqual
   (typeof(string),
    m.DeclaringType);

  Assert.AreEqual
   ("Contains",
    m.Name);

  var mParams
   =m.GetParameters();

  Assert.NotNull
   (mParams);

  Assert.AreEqual
   (1,
    mParams.Length);

  Assert.NotNull
   (mParams[0]);

  Assert.AreEqual
   (typeof(System.Char),
    mParams[0].ParameterType);
 }//Test_01__String_Contains_Char

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_ERR01__NotFound()
 {
  try
  {
   var m
    =typeof(string).Extension__GetRuntimeMethod
      ("ADD2",
       new System.Type[]
       {
        typeof(System.Char),
        typeof(System.Int16)
       });
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK
    (e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__common_err__type_not_support_method_3
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__Extensions__Type,
     "System.String",
     "ADD2",
     "System.Char, System.Int16");
  }//catch
 }//Test_01__String_Contains_Char
};//class TestsFor__Extension__GetRuntimeMethod

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Extensions.LcpiOleDb__Extensions__Type

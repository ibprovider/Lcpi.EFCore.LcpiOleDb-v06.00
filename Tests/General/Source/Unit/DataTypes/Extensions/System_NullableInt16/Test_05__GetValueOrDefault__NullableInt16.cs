////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 30.08.2021.
using NUnit.Framework;

using structure_lib=lcpi.lib.structure;

using Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DataTypes.Extensions;

namespace EFCore_LcpiOleDb_Tests.General.Unit.DataTypes.Extensions.System_NullableInt16{
////////////////////////////////////////////////////////////////////////////////
//class Test_02__GetValueOrDefault__NullableInt16

public static class Test_02__GetValueOrDefault__NullableInt16
{
#if(!DEBUG)
 [Test]
 public static void Test_01__TryCall()
 {
  System.Int16? d=0;

  System.Int16? defaultValue=0;

  try
  {
   d.GetValueOrDefault(defaultValue);
  }
  catch(structure_lib.exceptions.t_invalid_operation_exception e)
  {
   CheckErrors.PrintException_OK
    (e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));
  
   CheckErrors.CheckErrorRecord__common_err__direct_call_of_linq_method_not_allowed_1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__DataTypes_Extensions__System_NullableInt16,
     "GetValueOrDefault(this Nullable<System.Int16>,Nullable<System.Int16>)");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_01__TryCall
#endif // !DEBUG
}//class Test_02__GetValueOrDefault__NullableInt16

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.DataTypes.Extensions.System_NullableInt16

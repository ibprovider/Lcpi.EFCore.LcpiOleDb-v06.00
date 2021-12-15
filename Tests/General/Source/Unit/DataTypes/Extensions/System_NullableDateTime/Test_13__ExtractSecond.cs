////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 08.11.2020.
using NUnit.Framework;

using structure_lib=lcpi.lib.structure;

using Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DataTypes.Extensions;

namespace EFCore_LcpiOleDb_Tests.General.Unit.DataTypes.Extensions.System_NullableDateTime{
////////////////////////////////////////////////////////////////////////////////
//class Test_13__ExtractSecond

public static class Test_13__ExtractSecond
{
#if(!DEBUG)
 [Test]
 public static void Test_01__TryCall()
 {
  System.DateTime? d=new System.DateTime(2018,11,7);

  try
  {
   var y=d.ExtractSecond();
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
     CheckErrors.c_src__EFCoreDataProvider__DataTypes_Extensions__System_NullableDateTime,
     "ExtractSecond(this System.Nullable<System.DateTime>)");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_01__TryCall
#endif // !DEBUG
}//class Test_13__ExtractSecond

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.DataTypes.Extensions.System_NullableDateTime

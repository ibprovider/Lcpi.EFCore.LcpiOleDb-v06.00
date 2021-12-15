////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 01.05.2019.
using NUnit.Framework;

using structure_lib=lcpi.lib.structure;

using EF_DBF=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DbFunctions;

namespace EFCore_LcpiOleDb_Tests.General.Unit.DbFunctions.DbMath.Sign{
////////////////////////////////////////////////////////////////////////////////
//class Test_03__Sign__Int32

public static class Test_03__Sign__Int32
{
#if(!DEBUG)
 [Test]
 public static void Test_01__TryCall()
 {
  int v=0;

  try
  {
   var r=EF_DBF.DbMath.Sign(v);
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
     CheckErrors.c_src__EFCoreDataProvider__DbFunctions__DbMath,
     "Sign(Int32)");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_01__TryCall
#endif // !DEBUG
}//class Test_03__Sign__Int32

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.DbFunctions.DbMath.Sign

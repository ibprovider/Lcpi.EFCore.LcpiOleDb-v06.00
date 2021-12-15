////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 02.04.2019.
using NUnit.Framework;

using structure_lib=lcpi.lib.structure;

using EF_DBF=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DbFunctions;

namespace EFCore_LcpiOleDb_Tests.General.Unit.DbFunctions.DbMath.Truncate{
////////////////////////////////////////////////////////////////////////////////
//class Test_N1__Truncate__NullableDouble

public static class Test_N1__Truncate__NullableDouble
{
#if(!DEBUG)
 [Test]
 public static void Test_01__TryCall()
 {
  double? v=0;

  try
  {
   var r=EF_DBF.DbMath.Truncate(v);
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
     "Truncate(Nullable<Double>)");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_01__TryCall
#endif // !DEBUG
}//class Test_N1__Truncate__NullableDouble

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.DbFunctions.DbMath.Truncate

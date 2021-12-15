////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 23.07.2021.
using NUnit.Framework;

using structure_lib=lcpi.lib.structure;

using Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DataTypes.Extensions;

namespace EFCore_LcpiOleDb_Tests.General.Unit.DataTypes.Extensions.System_TimeOnly{
////////////////////////////////////////////////////////////////////////////////
//using

using T_DATA  =System.TimeOnly;
using T_DATA_U=System.TimeOnly;

////////////////////////////////////////////////////////////////////////////////
//class Test_01__Add___NullableTimeSpan

public static class Test_01__Add___NullableTimeSpan
{
#if(!DEBUG)
 [Test]
 public static void Test_01__TryCall()
 {
  System.TimeSpan? v=null;

  T_DATA t=new T_DATA_U(1,2,3);

  try
  {
   t.Add(v);
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
     CheckErrors.c_src__EFCoreDataProvider__DataTypes_Extensions__System_TimeOnly,
     "Add(this System.TimeOnly,Nullable<System.TimeSpan>)");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_01__TryCall
#endif // !DEBUG
}//class Test_01__Add___NullableTimeSpan

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.DataTypes.Extensions.System_TimeOnly

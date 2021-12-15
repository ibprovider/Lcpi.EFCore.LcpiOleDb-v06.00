////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 07.11.2018.
using NUnit.Framework;

using structure_lib=lcpi.lib.structure;

using Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DataTypes.Extensions;

namespace EFCore_LcpiOleDb_Tests.General.Unit.DataTypes.Extensions.System_DateTime{
////////////////////////////////////////////////////////////////////////////////
//class Test_01__AddYears

public static class Test_01__AddYears
{
#if(!DEBUG)
 [Test]
 public static void Test_01__TryCall()
 {
  int? v=null;

  var d=new System.DateTime(2018,11,7);

  try
  {
   d.AddYears(v);
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
     CheckErrors.c_src__EFCoreDataProvider__DataTypes_Extensions__System_DateTime,
     "AddYears(this System.DateTime,Nullable<System.Int32>)");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_01__TryCall
#endif // !DEBUG
}//class Test_01__AddYears

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.DataTypes.Extensions.System_DateTime

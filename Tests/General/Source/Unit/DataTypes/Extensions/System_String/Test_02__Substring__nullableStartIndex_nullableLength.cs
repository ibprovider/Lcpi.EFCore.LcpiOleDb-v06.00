////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 07.11.2018.
using NUnit.Framework;

using structure_lib=lcpi.lib.structure;

using Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DataTypes.Extensions;

namespace EFCore_LcpiOleDb_Tests.General.Unit.DataTypes.Extensions.System_String{
////////////////////////////////////////////////////////////////////////////////
//class Test_02__Substring__nullableStartIndex_nullableLength

public static class Test_02__Substring__nullableStartIndex_nullableLength
{
#if(!DEBUG)
 [Test]
 public static void Test_01__TryCall()
 {
  int? v=null;

  var s="1234";

  try
  {
   s.Substring(v,v);
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
     CheckErrors.c_src__EFCoreDataProvider__DataTypes_Extensions__System_String,
     "Substring(this System.String,Nullable<System.Int64>,Nullable<System.Int64>)");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_01__TryCall
#endif // !DEBUG
}//class Test_02__Substring__nullableStartIndex_nullableLength

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.DataTypes.Extensions.System_String

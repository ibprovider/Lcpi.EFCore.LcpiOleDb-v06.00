////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 15.05.2018.
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

using Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Core.Core_ExceptionRecord{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_01

public static class TestSet_01
{
 [Test]
 public static void Test_01()
 {
  var Err
   =new xEFCore.Core.Core_ExceptionRecord
     (lcpi.lib.com.HResultCode.E_FAIL,
      ErrSourceID.Core_ExceptionRecord,
      ErrMessageID.common_err__unknown_dbms_name_1);

  Err.push("MYDBMS");

  CheckErrors.CheckErrorRecord__CommonErr__UnknownDbmsName
   (Err,
    CheckErrors.c_src__EFCoreDataProvider__Core_ExceptionRecord,
    "MYDBMS");
 }//Test_01
}//class TestSet_01

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Core.Core_ExceptionRecord

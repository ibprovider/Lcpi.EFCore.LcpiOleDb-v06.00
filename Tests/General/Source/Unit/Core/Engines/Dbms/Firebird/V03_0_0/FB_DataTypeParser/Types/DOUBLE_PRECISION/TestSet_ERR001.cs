////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 20.10.2020.
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Core.Engines.Dbms.Firebird.V03_0_0.FB_DataTypeParser.Types.DOUBLE_PRECISION{
////////////////////////////////////////////////////////////////////////////////

using T_FB_DATATYPE_ID
 =xEFCore.Core.Engines.Dbms.Firebird.Common.FB_Common__DataTypeID;

using T_FB_DATATYPE_PARSER
 =xEFCore.Core.Engines.Dbms.Firebird.V03_0_0.FB_DataTypeParser;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_ERR001

static class TestSet_ERR001
{
 [Test]
 public static void Test_001___EXEC_P000()
 {  
  const string c_sourceStr
   ="DOUBLE PRECISION BLABLABLA";

  try
  {
   T_FB_DATATYPE_PARSER.Exec
    (c_sourceStr,
     out var resultData);
  }
  catch(xEFCore.LcpiOleDb__DataToolException exc)
  {
   CheckErrors.PrintException_OK
    (exc);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(exc));

   CheckErrors.CheckErrorRecord__type_mapping_err__unexpected_data_at_end_of_datatype_definition_1
    (TestUtils.GetRecord(exc,0),
     CheckErrors.c_src__Core_Engines_Dbms_FB_V03_0_0__FB_DataTypeParser,
     "DOUBLE");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_001___EXEC_P000

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002()
 {  
  const string c_sourceStr
   ="DOUBLE";

  try
  {
   T_FB_DATATYPE_PARSER.Exec
    (c_sourceStr,
     out var resultData);
  }
  catch(xEFCore.LcpiOleDb__DataToolException exc)
  {
   CheckErrors.PrintException_OK
    (exc);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(exc));

   CheckErrors.CheckErrorRecord__type_mapping_err__incompleted_datatype_definition_1
    (TestUtils.GetRecord(exc,0),
     CheckErrors.c_src__Core_Engines_Dbms_FB_V03_0_0__FB_DataTypeParser,
     "DOUBLE");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_002

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_003()
 {  
  const string c_sourceStr
   ="DOUBLE DOUBLE";

  var resultCode
   =T_FB_DATATYPE_PARSER.Exec
     (c_sourceStr,
      out var resultData);

  Assert.AreEqual
   (T_FB_DATATYPE_PARSER.ResultCode.UnknownTypeName,
    resultCode);
 }//Test_003

};//class TestSet_ERR001

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Core.Engines.Dbms.Firebird.V03_0_0.FB_DataTypeParser.Types.DOUBLE_PRECISION

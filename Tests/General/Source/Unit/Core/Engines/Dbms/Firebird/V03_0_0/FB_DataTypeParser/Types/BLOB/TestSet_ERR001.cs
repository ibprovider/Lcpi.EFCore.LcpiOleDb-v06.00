////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 20.10.2020.
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Core.Engines.Dbms.Firebird.V03_0_0.FB_DataTypeParser.Types.BLOB{
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
   ="BLOB BLABLABLA";

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
     "BLOB");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_001___EXEC_P000

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002()
 {  
  const string c_sourceStr
   ="BLOB SUB_TYPE";

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

   CheckErrors.CheckErrorRecord__type_mapping_err__not_defined_subtype_name_1
    (TestUtils.GetRecord(exc,0),
     CheckErrors.c_src__Core_Engines_Dbms_FB_V03_0_0__FB_DataTypeParser,
     "BLOB");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_002

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_003()
 {  
  const string c_sourceStr
   ="BLOB SUB_TYPE s";

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

   CheckErrors.CheckErrorRecord__type_mapping_err__unknown_blob_subtype_1
    (TestUtils.GetRecord(exc,0),
     CheckErrors.c_src__Core_Engines_Dbms_FB_V03_0_0__FB_DataTypeParser,
     "s");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_003

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_004()
 {  
  const string c_sourceStr
   ="BLOB SUB_TYPE TEXT C";

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
     "BLOB");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_004

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_005()
 {  
  const string c_sourceStr
   ="BLOB SUB_TYPE TEXT CHARACTER";

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
     "BLOB");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_005

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_006()
 {  
  const string c_sourceStr
   ="BLOB SUB_TYPE TEXT CHARACTER ss";

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

   CheckErrors.CheckErrorRecord__type_mapping_err__bad_datatype_definition_1
    (TestUtils.GetRecord(exc,0),
     CheckErrors.c_src__Core_Engines_Dbms_FB_V03_0_0__FB_DataTypeParser,
     "BLOB");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_006

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_007()
 {  
  const string c_sourceStr
   ="BLOB SUB_TYPE TEXT CHARACTER SET";

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

   CheckErrors.CheckErrorRecord__type_mapping_err__not_defined_charset_name_1
    (TestUtils.GetRecord(exc,0),
     CheckErrors.c_src__Core_Engines_Dbms_FB_V03_0_0__FB_DataTypeParser,
     "BLOB");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_007

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_008()
 {  
  const string c_sourceStr
   ="BLOB SUB_TYPE BINARY CHARACTER SET OCTETS";

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

   CheckErrors.CheckErrorRecord__type_mapping_err__definition_of_blob_charset_allowed_only_for_subtype_text_0
    (TestUtils.GetRecord(exc,0),
     CheckErrors.c_src__Core_Engines_Dbms_FB_V03_0_0__FB_DataTypeParser);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_008

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_009()
 {  
  const string c_sourceStr
   ="BLOB CHARACTER SET OCTETS";

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

   CheckErrors.CheckErrorRecord__type_mapping_err__definition_of_blob_charset_allowed_only_for_subtype_text_0
    (TestUtils.GetRecord(exc,0),
     CheckErrors.c_src__Core_Engines_Dbms_FB_V03_0_0__FB_DataTypeParser);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_009

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_010()
 {  
  const string c_sourceStr
   ="BLOB SUB_TYPE TEXT CHARACTER SET BIG_5 aaa";

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
     "BLOB");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_010
};//class TestSet_ERR001

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Core.Engines.Dbms.Firebird.V03_0_0.FB_DataTypeParser.Types.BLOB

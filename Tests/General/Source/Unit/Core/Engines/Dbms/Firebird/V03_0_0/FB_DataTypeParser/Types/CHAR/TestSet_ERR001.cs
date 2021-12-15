////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 20.10.2020.
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Core.Engines.Dbms.Firebird.V03_0_0.FB_DataTypeParser.Types.CHAR{
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
   ="CHAR BLABLABLA";

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
     "CHAR");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_001___EXEC_P000

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002___VCH_P000()
 {  
  const string c_sourceStr
   ="CHAR (";

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
     "CHAR");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_002___VCH_P000

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_003___VCH_P001()
 {  
  const string c_sourceStr
   ="CHAR (  a123)";

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

   CheckErrors.CheckErrorRecord__type_mapping_err__failed_to_parse_datatype_length_1
    (TestUtils.GetRecord(exc,0),
     CheckErrors.c_src__Core_Engines_Dbms_FB_V03_0_0__FB_DataTypeParser,
     "CHAR");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_003___VCH_P001

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_004___VCH_P002()
 {  
  const string c_sourceStr
   ="CHAR (  123";

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
     "CHAR");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_004___VCH_P002

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_005___VCH_P003()
 {  
  const string c_sourceStr
   ="CHAR ( 2147483648 ";

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

   CheckErrors.CheckErrorRecord__type_mapping_err__too_large_length_of_datatype_1
    (TestUtils.GetRecord(exc,0),
     CheckErrors.c_src__Core_Engines_Dbms_FB_V03_0_0__FB_DataTypeParser,
     "CHAR");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_005___VCH_P003

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_006___VCH_P004()
 {  
  const string c_sourceStr
   ="CHAR ( 2147483647 ";

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
     "CHAR");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_006___VCH_P004

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_007___VCH_P005()
 {  
  const string c_sourceStr
   ="CHAR ( 2147483647 a";

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
     "CHAR");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_007___VCH_P005

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_008___CSN_P000()
 {  
  const string c_sourceStr
   ="CHAR ( 2147483647 ) CHARACTER ";

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
     "CHAR");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_008___CSN_P000

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_009___CSN_P001()
 {  
  const string c_sourceStr
   ="CHAR ( 2147483647 ) CHARACTER SEEEEET";

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
     "CHAR");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_009___CSN_P001

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_010___CSN_P002()
 {  
  const string c_sourceStr
   ="CHAR ( 2147483647 ) CHARACTER SET";

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
     "CHAR");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_010___CSN_P002
};//class TestSet_ERR001

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Core.Engines.Dbms.Firebird.V03_0_0.FB_DataTypeParser.Types.CHAR

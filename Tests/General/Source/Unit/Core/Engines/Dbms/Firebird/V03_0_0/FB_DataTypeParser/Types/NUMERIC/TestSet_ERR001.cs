////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 20.10.2020.
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Core.Engines.Dbms.Firebird.V03_0_0.FB_DataTypeParser.Types.NUMERIC{
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
   ="NUMERIC BLABLABLA";

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
     "NUMERIC");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_001___EXEC_P000

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002()
 {  
  const string c_sourceStr
   ="NUMERIC(";

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
     "NUMERIC");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_002

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_003()
 {  
  const string c_sourceStr
   ="NUMERIC(a";

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

   CheckErrors.CheckErrorRecord__type_mapping_err__failed_to_parse_datatype_precision_1
    (TestUtils.GetRecord(exc,0),
     CheckErrors.c_src__Core_Engines_Dbms_FB_V03_0_0__FB_DataTypeParser,
     "NUMERIC");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_003

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_004()
 {
  const string c_sourceStr
   ="NUMERIC(2147483648";

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

   CheckErrors.CheckErrorRecord__type_mapping_err__too_large_precision_of_datatype_1
    (TestUtils.GetRecord(exc,0),
     CheckErrors.c_src__Core_Engines_Dbms_FB_V03_0_0__FB_DataTypeParser,
     "NUMERIC");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_004

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_005()
 {
  const string c_sourceStr
   ="NUMERIC(2147483647";

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
     "NUMERIC");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_005

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_006()
 {
  const string c_sourceStr
   ="NUMERIC(2147483647a";

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
     "NUMERIC");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_006

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_007()
 {
  const string c_sourceStr
   ="NUMERIC(2147483647,";

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
     "NUMERIC");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_007

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_008()
 {
  const string c_sourceStr
   ="NUMERIC(2147483647,a";

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

   CheckErrors.CheckErrorRecord__type_mapping_err__failed_to_parse_datatype_scale_1
    (TestUtils.GetRecord(exc,0),
     CheckErrors.c_src__Core_Engines_Dbms_FB_V03_0_0__FB_DataTypeParser,
     "NUMERIC");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_008

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_009()
 {
  const string c_sourceStr
   ="NUMERIC(2147483647,2147483648";

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

   CheckErrors.CheckErrorRecord__type_mapping_err__too_large_scale_of_datatype_1
    (TestUtils.GetRecord(exc,0),
     CheckErrors.c_src__Core_Engines_Dbms_FB_V03_0_0__FB_DataTypeParser,
     "NUMERIC");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_009

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_010()
 {
  const string c_sourceStr
   ="NUMERIC(2147483647,2147483647a";

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
     "NUMERIC");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_010

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_011()
 {
  const string c_sourceStr
   ="NUMERIC(2147483647,2147483647";

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
     "NUMERIC");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_011

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_012()
 {
  const string c_sourceStr
   ="NUMERIC(2147483647,2147483647 ";

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
     "NUMERIC");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_012

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_013()
 {
  const string c_sourceStr
   ="NUMERIC(2147483647,2147483647)a";

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
     "NUMERIC");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_013
};//class TestSet_ERR001

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Core.Engines.Dbms.Firebird.V03_0_0.FB_DataTypeParser.Types.NUMERIC

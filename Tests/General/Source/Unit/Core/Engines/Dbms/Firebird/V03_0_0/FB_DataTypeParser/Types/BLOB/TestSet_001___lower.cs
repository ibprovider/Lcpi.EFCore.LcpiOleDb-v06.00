////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 20.10.2020.
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Core.Engines.Dbms.Firebird.V03_0_0.FB_DataTypeParser.Types.BLOB{
////////////////////////////////////////////////////////////////////////////////

using T_FB_DATATYPE_ID
 =xEFCore.Core.Engines.Dbms.Firebird.Common.FB_Common__DataTypeID;

using T_FB_BLOB_SUBTYPE_ID
 =xEFCore.Core.Engines.Dbms.Firebird.Common.FB_Common__BlobSubTypeID;

using T_FB_DATATYPE_PARSER
 =xEFCore.Core.Engines.Dbms.Firebird.V03_0_0.FB_DataTypeParser;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_001___lower

static class TestSet_001___lower
{
 [Test]
 public static void Test_001__one_typename()
 {
  const string c_sourceStr
   ="blob";

  var resultCode
   =T_FB_DATATYPE_PARSER.Exec
     (c_sourceStr,
      out var resultData);

  Assert.AreEqual
   (T_FB_DATATYPE_PARSER.ResultCode.Ok,
    resultCode);

  TestHelpers.CheckResultData
   (resultData,
    c_sourceStr,
    T_FB_DATATYPE_ID.BLOB,
    "BLOB",
    /*length*/   null,
    /*precision*/null,
    /*scale*/    null,
    /*subType*/  null,
    /*csName*/   null,
    /*bounds*/   null);
 }//Test_001__one_typename

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_001__one_typename__with_spaces()
 {
  const string c_sourceStr
   ="  blob   ";

  var resultCode
   =T_FB_DATATYPE_PARSER.Exec
     (c_sourceStr,
      out var resultData);

  Assert.AreEqual
   (T_FB_DATATYPE_PARSER.ResultCode.Ok,
    resultCode);

  TestHelpers.CheckResultData
   (resultData,
    c_sourceStr,
    T_FB_DATATYPE_ID.BLOB,
    "BLOB",
    /*length*/   null,
    /*precision*/null,
    /*scale*/    null,
    /*subType*/  null,
    /*csName*/   null,
    /*bounds*/   null);
 }//Test_001__one_typename__with_spaces

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002__subtype_BINARY()
 {
  const string c_sourceStr
   ="blob sub_type binary";

  var resultCode
   =T_FB_DATATYPE_PARSER.Exec
     (c_sourceStr,
      out var resultData);

  Assert.AreEqual
   (T_FB_DATATYPE_PARSER.ResultCode.Ok,
    resultCode);

  TestHelpers.CheckResultData
   (resultData,
    c_sourceStr,
    T_FB_DATATYPE_ID.BLOB,
    "BLOB",
    /*length*/   null,
    /*precision*/null,
    /*scale*/    null,
    /*subType*/  T_FB_BLOB_SUBTYPE_ID.BINARY,
    /*csName*/   null,
    /*bounds*/   null);
 }//Test_002__subtype_BINARY

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002__subtype_BINARY__with_spaces()
 {
  const string c_sourceStr
   ="  blob   sub_type    binary  ";

  var resultCode
   =T_FB_DATATYPE_PARSER.Exec
     (c_sourceStr,
      out var resultData);

  Assert.AreEqual
   (T_FB_DATATYPE_PARSER.ResultCode.Ok,
    resultCode);

  TestHelpers.CheckResultData
   (resultData,
    c_sourceStr,
    T_FB_DATATYPE_ID.BLOB,
    "BLOB",
    /*length*/   null,
    /*precision*/null,
    /*scale*/    null,
    /*subType*/  T_FB_BLOB_SUBTYPE_ID.BINARY,
    /*csName*/   null,
    /*bounds*/   null);
 }//Test_002__subtype_BINARY__with_spaces

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_003__subtype_TEXT()
 {
  const string c_sourceStr
   ="blob sub_type text";

  var resultCode
   =T_FB_DATATYPE_PARSER.Exec
     (c_sourceStr,
      out var resultData);

  Assert.AreEqual
   (T_FB_DATATYPE_PARSER.ResultCode.Ok,
    resultCode);

  TestHelpers.CheckResultData
   (resultData,
    c_sourceStr,
    T_FB_DATATYPE_ID.BLOB,
    "BLOB",
    /*length*/   null,
    /*precision*/null,
    /*scale*/    null,
    /*subType*/  T_FB_BLOB_SUBTYPE_ID.TEXT,
    /*csName*/   null,
    /*bounds*/   null);
 }//Test_003__subtype_TEXT

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_003__subtype_TEXT__with_spaces()
 {
  const string c_sourceStr
   ="  blob   sub_type    text  ";

  var resultCode
   =T_FB_DATATYPE_PARSER.Exec
     (c_sourceStr,
      out var resultData);

  Assert.AreEqual
   (T_FB_DATATYPE_PARSER.ResultCode.Ok,
    resultCode);

  TestHelpers.CheckResultData
   (resultData,
    c_sourceStr,
    T_FB_DATATYPE_ID.BLOB,
    "BLOB",
    /*length*/   null,
    /*precision*/null,
    /*scale*/    null,
    /*subType*/  T_FB_BLOB_SUBTYPE_ID.TEXT,
    /*csName*/   null,
    /*bounds*/   null);
 }//Test_003__subtype_TEXT__with_spaces

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_004__subtype_TEXT_and_cs_OCTETS()
 {
  const string c_sourceStr
   ="blob sub_type text character set octets";

  var resultCode
   =T_FB_DATATYPE_PARSER.Exec
     (c_sourceStr,
      out var resultData);

  Assert.AreEqual
   (T_FB_DATATYPE_PARSER.ResultCode.Ok,
    resultCode);

  TestHelpers.CheckResultData
   (resultData,
    c_sourceStr,
    T_FB_DATATYPE_ID.BLOB,
    "BLOB",
    /*length*/   null,
    /*precision*/null,
    /*scale*/    null,
    /*subType*/  T_FB_BLOB_SUBTYPE_ID.TEXT,
    /*csName*/   "OCTETS",
    /*bounds*/   null);
 }//Test_004__subtype_TEXT_and_cs_OCTETS

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_004__subtype_TEXT_and_cs_OCTETS__with_spaces()
 {
  const string c_sourceStr
   =" blob  sub_type  text  character  set    octets   ";

  var resultCode
   =T_FB_DATATYPE_PARSER.Exec
     (c_sourceStr,
      out var resultData);

  Assert.AreEqual
   (T_FB_DATATYPE_PARSER.ResultCode.Ok,
    resultCode);

  TestHelpers.CheckResultData
   (resultData,
    c_sourceStr,
    T_FB_DATATYPE_ID.BLOB,
    "BLOB",
    /*length*/   null,
    /*precision*/null,
    /*scale*/    null,
    /*subType*/  T_FB_BLOB_SUBTYPE_ID.TEXT,
    /*csName*/   "OCTETS",
    /*bounds*/   null);
 }//Test_004__subtype_TEXT_and_cs_OCTETS__with_spaces

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_005__subtype_TEXT_and_cs_UTF8()
 {
  const string c_sourceStr
   ="blob sub_type text character set utf8";

  var resultCode
   =T_FB_DATATYPE_PARSER.Exec
     (c_sourceStr,
      out var resultData);

  Assert.AreEqual
   (T_FB_DATATYPE_PARSER.ResultCode.Ok,
    resultCode);

  TestHelpers.CheckResultData
   (resultData,
    c_sourceStr,
    T_FB_DATATYPE_ID.BLOB,
    "BLOB",
    /*length*/   null,
    /*precision*/null,
    /*scale*/    null,
    /*subType*/  T_FB_BLOB_SUBTYPE_ID.TEXT,
    /*csName*/   "UTF8",
    /*bounds*/   null);
 }//Test_005__subtype_TEXT_and_cs_UTF8

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_005__subtype_TEXT_and_cs_UTF8__with_spaces()
 {
  const string c_sourceStr
   =" blob  sub_type  text  character  set    utf8   ";

  var resultCode
   =T_FB_DATATYPE_PARSER.Exec
     (c_sourceStr,
      out var resultData);

  Assert.AreEqual
   (T_FB_DATATYPE_PARSER.ResultCode.Ok,
    resultCode);

  TestHelpers.CheckResultData
   (resultData,
    c_sourceStr,
    T_FB_DATATYPE_ID.BLOB,
    "BLOB",
    /*length*/   null,
    /*precision*/null,
    /*scale*/    null,
    /*subType*/  T_FB_BLOB_SUBTYPE_ID.TEXT,
    /*csName*/   "UTF8",
    /*bounds*/   null);
 }//Test_005__subtype_TEXT_and_cs_UTF8__with_spaces
};//class TestSet_001___lower

////////////////////////////////////////////////////////////////////////////////
}//EFCore_LcpiOleDb_Tests.General.Unit.Core.Engines.Dbms.Firebird.V03_0_0.FB_DataTypeParser.Types.BLOB

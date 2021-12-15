////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 20.10.2020.
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Core.Engines.Dbms.Firebird.V03_0_0.FB_DataTypeParser.Types.DECIMAL{
////////////////////////////////////////////////////////////////////////////////

using T_FB_DATATYPE_ID
 =xEFCore.Core.Engines.Dbms.Firebird.Common.FB_Common__DataTypeID;

using T_FB_DATATYPE_PARSER
 =xEFCore.Core.Engines.Dbms.Firebird.V03_0_0.FB_DataTypeParser;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_001

static class TestSet_001
{
 [Test]
 public static void Test_001__one_typename()
 {
  const string c_sourceStr
   ="DECIMAL";

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
    T_FB_DATATYPE_ID.DECIMAL,
    "DECIMAL",
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
   =" DECIMAL ";

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
    T_FB_DATATYPE_ID.DECIMAL,
    "DECIMAL",
    /*length*/   null,
    /*precision*/null,
    /*scale*/    null,
    /*subType*/  null,
    /*csName*/   null,
    /*bounds*/   null);
 }//Test_001__one_typename__with_spaces

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002__typename_with_precision()
 {
  const string c_sourceStr
   ="DECIMAL(6)";

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
    T_FB_DATATYPE_ID.DECIMAL,
    "DECIMAL",
    /*length*/   null,
    /*precision*/6,
    /*scale*/    null,
    /*subType*/  null,
    /*csName*/   null,
    /*bounds*/   null);
 }//Test_002__typename_with_precision

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002__typename_with_precision__with_spaces()
 {
  const string c_sourceStr
   =" DECIMAL ( 6 ) ";

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
    T_FB_DATATYPE_ID.DECIMAL,
    "DECIMAL",
    /*length*/   null,
    /*precision*/6,
    /*scale*/    null,
    /*subType*/  null,
    /*csName*/   null,
    /*bounds*/   null);
 }//Test_002__typename_with_precision__with_spaces

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_003__typename_with_precision_and_scale()
 {
  const string c_sourceStr
   ="DECIMAL(6,3)";

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
    T_FB_DATATYPE_ID.DECIMAL,
    "DECIMAL",
    /*length*/   null,
    /*precision*/6,
    /*scale*/    3,
    /*subType*/  null,
    /*csName*/   null,
    /*bounds*/   null);
 }//Test_003__typename_with_precision_and_scale

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_003__typename_with_precision_and_scale__with_spaces()
 {
  const string c_sourceStr
   =" DECIMAL ( 6 , 3 ) ";

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
    T_FB_DATATYPE_ID.DECIMAL,
    "DECIMAL",
    /*length*/   null,
    /*precision*/6,
    /*scale*/    3,
    /*subType*/  null,
    /*csName*/   null,
    /*bounds*/   null);
 }//Test_003__typename_with_precision_and_scale__with_spaces
};//class TestSet_001

////////////////////////////////////////////////////////////////////////////////
}//EFCore_LcpiOleDb_Tests.General.Unit.Core.Engines.Dbms.Firebird.V03_0_0.FB_DataTypeParser.Types.DECIMAL

////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 21.10.2020.
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Core.Engines.Dbms.Firebird.V03_0_0.FB_DataTypeParser.Types.BOOLEAN{
////////////////////////////////////////////////////////////////////////////////

using T_FB_DATATYPE_ID
 =xEFCore.Core.Engines.Dbms.Firebird.Common.FB_Common__DataTypeID;

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
   ="boolean";

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
    T_FB_DATATYPE_ID.BOOLEAN,
    "BOOLEAN",
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
   ="   boolean   ";

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
    T_FB_DATATYPE_ID.BOOLEAN,
    "BOOLEAN",
    /*length*/   null,
    /*precision*/null,
    /*scale*/    null,
    /*subType*/  null,
    /*csName*/   null,
    /*bounds*/   null);
 }//Test_001__one_typename__with_spaces
};//class TestSet_001___lower

////////////////////////////////////////////////////////////////////////////////
}//EFCore_LcpiOleDb_Tests.General.Unit.Core.Engines.Dbms.Firebird.V03_0_0.FB_DataTypeParser.Types.BOOLEAN

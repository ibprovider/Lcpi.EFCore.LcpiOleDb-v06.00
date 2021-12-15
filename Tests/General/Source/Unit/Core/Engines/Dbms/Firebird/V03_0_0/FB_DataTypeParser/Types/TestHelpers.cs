////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 20.10.2020.
using System;
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Core.Engines.Dbms.Firebird.V03_0_0.FB_DataTypeParser.Types{
////////////////////////////////////////////////////////////////////////////////

using T_FB_DATATYPE_ID
 =xEFCore.Core.Engines.Dbms.Firebird.Common.FB_Common__DataTypeID;

using T_FB_BLOB_SUBTYPE_ID
 =xEFCore.Core.Engines.Dbms.Firebird.Common.FB_Common__BlobSubTypeID;

using T_FB_DATATYPE_PARSER
 =xEFCore.Core.Engines.Dbms.Firebird.V03_0_0.FB_DataTypeParser;

using T_FB_ARRAY_BOUND
 =xEFCore.Core.Engines.Dbms.Firebird.Common.FB_Common__ArrayBound;

////////////////////////////////////////////////////////////////////////////////
//class TestHelpers

static class TestHelpers
{
 public static void CheckResultData
                        (in T_FB_DATATYPE_PARSER.tagResultData resultData,
                         string                                expected_SourceStr,
                         T_FB_DATATYPE_ID                      expected_DataTypeID,
                         string                                expected_DataTypeNameBase,
                         Nullable<int>                         expected_Length,
                         Nullable<int>                         expected_Precision,
                         Nullable<int>                         expected_Scale,
                         Nullable<T_FB_BLOB_SUBTYPE_ID>        expected_BlobSubTypeID,
                         string                                expected_CharSetName,
                         T_FB_ARRAY_BOUND[]                    expected_ArrayBounds)
 {
  Assert.AreEqual
   (expected_SourceStr,
    resultData.SourceStr);

  Assert.AreEqual
   (expected_DataTypeID,
    resultData.DataTypeDescr.DataTypeID);

  Assert.AreEqual
   (expected_DataTypeNameBase,
    resultData.DataTypeDescr.DataTypeNameBase);

  Assert.AreEqual
   (expected_Length,
    resultData.DataTypeDescr.Length);

  Assert.AreEqual
   (expected_Precision,
    resultData.DataTypeDescr.Precision);

  Assert.AreEqual
   (expected_Scale,
    resultData.DataTypeDescr.Scale);

  Assert.AreEqual
   (expected_BlobSubTypeID,
    resultData.DataTypeDescr.BlobSubTypeID);

  Assert.AreEqual
   (expected_CharSetName,
    resultData.DataTypeDescr.CharSetName);

  if(Object.ReferenceEquals(expected_ArrayBounds,null))
  {
   Assert.IsNull
    (resultData.DataTypeDescr.ArrayBounds);
  }
  else
  {
   Assert.NotNull
    (resultData.DataTypeDescr.ArrayBounds);

   Assert.AreEqual
    (expected_ArrayBounds.Length,
     resultData.DataTypeDescr.ArrayBounds.Length);

   for(int i=0;i!=expected_ArrayBounds.Length;++i)
   {
    Assert.AreEqual
     (expected_ArrayBounds[i].Lower,
      resultData.DataTypeDescr.ArrayBounds[i].Lower,
      "dimension {0}, wrong lower bound",
      i);

    Assert.AreEqual
     (expected_ArrayBounds[i].Upper,
      resultData.DataTypeDescr.ArrayBounds[i].Upper,
      "dimension {0}, wrong upper bound",
      i);
   }//for i
  }//else
 }//CheckResultData
};//class TestHelpers

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Core.Engines.Dbms.Firebird.V03_0_0.FB_DataTypeParser.Types

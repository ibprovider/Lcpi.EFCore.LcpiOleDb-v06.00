////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 29.05.2018.
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.Check{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__RelationalTypeMappingInfo__SizeIsNull

class TestsFor__RelationalTypeMappingInfo__SizeIsNull
{
 [Test]
 public static void Test_02()
 {
  // public RelationalTypeMappingInfo(
  //     [NotNull] string storeTypeName,
  //     [NotNull] string storeTypeNameBase,
  //     bool? unicode,
  //     int? size,
  //     int? precision,
  //     int? scale)

  var mappingInfo
   =new Microsoft.EntityFrameworkCore.Storage.RelationalTypeMappingInfo
        ("CHAR",
         "CHAR",
         null,
         null,
         null,
         null);

  Assert.IsFalse
   (mappingInfo.Size.HasValue);

  xEFCore.Check.RelationalTypeMappingInfo__SizeIsNull
   (xEFCore.ErrSourceID.FB_Common__TypeMapping__NUMERIC,
    mappingInfo);
 }//Test_02

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_03__err()
 {
  // public RelationalTypeMappingInfo(
  //     [NotNull] string storeTypeName,
  //     [NotNull] string storeTypeNameBase,
  //     bool? unicode,
  //     int? size,
  //     int? precision,
  //     int? scale)

  var mappingInfo
   =new Microsoft.EntityFrameworkCore.Storage.RelationalTypeMappingInfo
         ("CHAR(10)",
          "CHAR",
          null,
          10,
          null,
          null);

  Assert.IsTrue
   (mappingInfo.Size.HasValue);

  Assert.AreEqual
   (10,
    mappingInfo.Size.Value);

  try
  {
   xEFCore.Check.RelationalTypeMappingInfo__SizeIsNull
    (xEFCore.ErrSourceID.FB_Common__TypeMapping__NUMERIC,
     mappingInfo);
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__unexpected_Size_1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_Common__TypeMapping__NUMERIC,
     10);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_03__err
};//class TestsFor__RelationalTypeMappingInfo__SizeIsNull

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.Check

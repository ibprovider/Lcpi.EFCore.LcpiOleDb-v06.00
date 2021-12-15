////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 29.05.2018.
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.Check{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__RelationalTypeMappingInfo__Scale

class TestsFor__RelationalTypeMappingInfo__Scale
{
 [Test]
 public static void Test_01()
 {
  // public RelationalTypeMappingInfo(
  //     [NotNull] string storeTypeName,
  //     [NotNull] string storeTypeNameBase,
  //     bool? unicode,
  //     int? size,
  //     int? precision,
  //     int? scale)

  for(int scale=0;scale!=11;++scale)
  {
   var mappingInfo
    =new Microsoft.EntityFrameworkCore.Storage.RelationalTypeMappingInfo
         (string.Format("NUMERIC(10,{0})",scale),
          "NUMERIC",
          null,
          null,
          10,
          scale);

   Assert.IsTrue
    (mappingInfo.Scale.HasValue);

   Assert.AreEqual
    (scale,
     mappingInfo.Scale.Value);

   xEFCore.Check.RelationalTypeMappingInfo__Scale
    (xEFCore.ErrSourceID.FB_Common__TypeMapping__NUMERIC,
     mappingInfo);
  }//for maxSize
 }//Test_01

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02__null()
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
        ("NUMERIC(10)",
         "NUMERIC",
         null,
         null,
         10,
         null);

  Assert.IsFalse
   (mappingInfo.Scale.HasValue);

  try
  {
   xEFCore.Check.RelationalTypeMappingInfo__Scale
    (xEFCore.ErrSourceID.FB_Common__TypeMapping__NUMERIC,
     mappingInfo);
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK
    (e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__not_defined_Scale_0
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_Common__TypeMapping__NUMERIC);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_02__null

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_04__neg_one()
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
        ("NUMERIC(10,-1)",
         "NUMERIC",
         null,
         null,
         10,
         -1);

  Assert.IsTrue
   (mappingInfo.Scale.HasValue);

  Assert.AreEqual
   (-1,
    mappingInfo.Scale.Value);

  try
  {
   xEFCore.Check.RelationalTypeMappingInfo__Scale
    (xEFCore.ErrSourceID.FB_Common__TypeMapping__NUMERIC,
     mappingInfo);
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK
    (e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__unexpected_Scale_1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_Common__TypeMapping__NUMERIC,
     -1);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_04__neg_one

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_05__too_large()
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
        ("NUMERIC(10,11)",
         "NUMERIC",
         null,
         null,
         10,
         11);

  Assert.IsTrue
   (mappingInfo.Scale.HasValue);

  Assert.AreEqual
   (11,
    mappingInfo.Scale.Value);

  try
  {
   xEFCore.Check.RelationalTypeMappingInfo__Scale
    (xEFCore.ErrSourceID.FB_Common__TypeMapping__DECIMAL,
     mappingInfo);
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK
    (e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__too_large_Scale_2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_Common__TypeMapping__DECIMAL,
     11,
     10);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_05__too_large
};//class TestsFor__RelationalTypeMappingInfo__Scale

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.Check

////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 29.05.2018.
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.Check{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__RelationalTypeMappingInfo__Precision

class TestsFor__RelationalTypeMappingInfo__Precision
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

  var mappingInfo
   =new Microsoft.EntityFrameworkCore.Storage.RelationalTypeMappingInfo
        ("NUMERIC(10,5)",
         "NUMERIC",
         null,
         null,
         10,
         5);

  Assert.IsTrue
   (mappingInfo.Precision.HasValue);

  Assert.AreEqual
   (10,
    mappingInfo.Precision.Value);

  for(int maxP=10;maxP!=20;++maxP)
  {
   xEFCore.Check.RelationalTypeMappingInfo__Precision
    (xEFCore.ErrSourceID.FB_Common__TypeMapping__NUMERIC,
     mappingInfo,
     maxP);
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
        ("NUMERIC",
         "NUMERIC",
         null,
         null,
         null,
         null);

  Assert.IsFalse
   (mappingInfo.Precision.HasValue);

  try
  {
   xEFCore.Check.RelationalTypeMappingInfo__Precision
    (xEFCore.ErrSourceID.FB_Common__TypeMapping__NUMERIC,
     mappingInfo,
     10);
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK
    (e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__not_defined_Precision_0
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_Common__TypeMapping__NUMERIC);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_02__null

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_03__zero()
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
        ("DECIMAL(0)",
         "DECIMAL",
         null,
         null,
         0,
         null);

  Assert.IsTrue
   (mappingInfo.Precision.HasValue);

  Assert.Zero
   (mappingInfo.Precision.Value);

  try
  {
   xEFCore.Check.RelationalTypeMappingInfo__Precision
    (xEFCore.ErrSourceID.FB_Common__TypeMapping__DECIMAL,
     mappingInfo,
     10);
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK
    (e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__unexpected_Precision_1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_Common__TypeMapping__DECIMAL,
     0);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_03__zero

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
        ("NUMERIC(-1)",
         "NUMERIC",
         null,
         null,
         -1,
         0);

  Assert.IsTrue
   (mappingInfo.Precision.HasValue);

  Assert.AreEqual
   (-1,
    mappingInfo.Precision.Value);

  try
  {
   xEFCore.Check.RelationalTypeMappingInfo__Precision
    (xEFCore.ErrSourceID.FB_Common__TypeMapping__NUMERIC,
     mappingInfo,
     10);
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK
    (e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__unexpected_Precision_1
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
        ("NUMERIC(11)",
         "NUMERIC",
         null,
         null,
         11,
         null);

  Assert.IsTrue
   (mappingInfo.Precision.HasValue);

  Assert.AreEqual
   (11,
    mappingInfo.Precision.Value);

  try
  {
   xEFCore.Check.RelationalTypeMappingInfo__Precision
    (xEFCore.ErrSourceID.FB_Common__TypeMapping__DECIMAL,
     mappingInfo,
     10);
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK
    (e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__too_large_Precision_2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_Common__TypeMapping__DECIMAL,
     11,
     10);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_05__too_large
};//class TestsFor__RelationalTypeMappingInfo__Precision

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.Check

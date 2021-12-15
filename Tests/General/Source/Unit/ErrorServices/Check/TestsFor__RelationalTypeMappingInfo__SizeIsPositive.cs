////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 29.05.2018.
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.Check{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__RelationalTypeMappingInfo__SizeIsPositive

class TestsFor__RelationalTypeMappingInfo__SizeIsPositive
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

  for(int maxSize=10;maxSize!=20;++maxSize)
  {
   xEFCore.Check.RelationalTypeMappingInfo__SizeIsPositive
    (xEFCore.ErrSourceID.FB_Common__TypeMapping__CHAR,
     mappingInfo,
     maxSize);
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
        ("CHAR",
         "CHAR",
         null,
         null,
         null,
         null);

  Assert.IsFalse
   (mappingInfo.Size.HasValue);

  try
  {
   xEFCore.Check.RelationalTypeMappingInfo__SizeIsPositive
    (xEFCore.ErrSourceID.FB_Common__TypeMapping__CHAR,
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

   CheckErrors.CheckErrorRecord__type_mapping_err__not_defined_Size_0
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_Common__TypeMapping__CHAR);

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
        ("CHAR(0)",
         "CHAR",
         null,
         0,
         null,
         null);

  Assert.IsTrue
   (mappingInfo.Size.HasValue);

  Assert.Zero
   (mappingInfo.Size.Value);

  try
  {
   xEFCore.Check.RelationalTypeMappingInfo__SizeIsPositive
    (xEFCore.ErrSourceID.FB_Common__TypeMapping__CHAR,
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

   CheckErrors.CheckErrorRecord__type_mapping_err__unexpected_Size_1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_Common__TypeMapping__CHAR,
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
        ("CHAR(-1)",
         "CHAR",
         null,
         -1,
         null,
         null);

  Assert.IsTrue
   (mappingInfo.Size.HasValue);

  Assert.AreEqual
   (-1,
    mappingInfo.Size.Value);

  try
  {
   xEFCore.Check.RelationalTypeMappingInfo__SizeIsPositive
    (xEFCore.ErrSourceID.FB_Common__TypeMapping__CHAR,
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

   CheckErrors.CheckErrorRecord__type_mapping_err__unexpected_Size_1
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_Common__TypeMapping__CHAR,
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
        ("CHAR(11)",
         "CHAR",
         null,
         11,
         null,
         null);

  Assert.IsTrue
   (mappingInfo.Size.HasValue);

  Assert.AreEqual
   (11,
    mappingInfo.Size.Value);

  try
  {
   xEFCore.Check.RelationalTypeMappingInfo__SizeIsPositive
    (xEFCore.ErrSourceID.FB_Common__TypeMapping__CHAR,
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

   CheckErrors.CheckErrorRecord__type_mapping_err__too_large_Size_2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_Common__TypeMapping__CHAR,
     11,
     10);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_05__too_large
};//class TestsFor__RelationalTypeMappingInfo__SizeIsPositive

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.Check

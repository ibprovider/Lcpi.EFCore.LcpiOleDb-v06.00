////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 19.10.2021.
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.Check{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__RelationalTypeMappingInfo__IsFixedLength__optional

class TestsFor__RelationalTypeMappingInfo__IsFixedLength__optional
{
 [Test]
 public static void Test_01()
 {
  // public RelationalTypeMappingInfo(
  //     [NotNull] Type type,
  //     [CanBeNull] string storeTypeName,
  //     [CanBeNull] string storeTypeNameBase = null,
  //     bool keyOrIndex,
  //     bool? unicode,
  //     int? size,
  //     bool? rowVersion,
  //     bool? fixedLength,
  //     int? precision,
  //     int? scale)

  var mappingInfo
   =new Microsoft.EntityFrameworkCore.Storage.RelationalTypeMappingInfo
        (typeof(string),
         "CHAR",
         "CHAR",
         false,
         /*unicode*/null,
         null,
         null,
         /*fixedLength*/true,
         null,
         null);

  Assert.IsTrue
   (mappingInfo.IsFixedLength.HasValue);

  xEFCore.Check.RelationalTypeMappingInfo__IsFixedLength__optional
   (xEFCore.ErrSourceID.FB_Common__TypeMapping__CHAR,
    mappingInfo,
    true);
 }//Test_01

 //-----------------------------------------------------------------------
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
   (mappingInfo.IsFixedLength.HasValue);
 
  xEFCore.Check.RelationalTypeMappingInfo__IsFixedLength__optional
   (xEFCore.ErrSourceID.FB_Common__TypeMapping__NUMERIC,
    mappingInfo,
    true);
 }//Test_02

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_03__err()
 {
  // public RelationalTypeMappingInfo(
  //     [NotNull] Type type,
  //     [CanBeNull] string storeTypeName,
  //     [CanBeNull] string storeTypeNameBase = null,
  //     bool keyOrIndex,
  //     bool? unicode,
  //     int? size,
  //     bool? rowVersion,
  //     bool? fixedLength,
  //     int? precision,
  //     int? scale)

  var mappingInfo
   =new Microsoft.EntityFrameworkCore.Storage.RelationalTypeMappingInfo
        (typeof(string),
         "CHAR",
         "CHAR",
         false,
         /*unicode*/null,
         null,
         null,
         /*fixedLength*/false,
         null,
         null);

  Assert.IsTrue
   (mappingInfo.IsFixedLength.HasValue);

  try
  {
   xEFCore.Check.RelationalTypeMappingInfo__IsFixedLength__optional
    (xEFCore.ErrSourceID.FB_Common__TypeMapping__CHAR,
     mappingInfo,
     true);
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK
    (e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__unexpected_IsFixedLength_2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_Common__TypeMapping__CHAR,
     false,
     true);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_03__err
};//class TestsFor__RelationalTypeMappingInfo__IsFixedLength__optional

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.Check

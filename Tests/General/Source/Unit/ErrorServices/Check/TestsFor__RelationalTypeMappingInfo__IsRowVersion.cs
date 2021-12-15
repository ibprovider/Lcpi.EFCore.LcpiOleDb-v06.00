////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 29.05.2018.
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.Check{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__RelationalTypeMappingInfo__IsRowVersion

class TestsFor__RelationalTypeMappingInfo__IsRowVersion
{
 [Test]
 public static void Test_01()
 {
  // public RelationalTypeMappingInfo(
  //     [NotNull] Type type,
  //     [CanBeNull] string storeTypeNameBase = null,
  //     [CanBeNull] string storeTypeName,
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
         /*unicode*/true,
         null,
         /*rowVersion*/true,
         /*fixedLength*/null,
         null,
         null);

  Assert.IsTrue
   (mappingInfo.IsRowVersion.HasValue);

  xEFCore.Check.RelationalTypeMappingInfo__IsRowVersion
   (xEFCore.ErrSourceID.FB_Common__TypeMapping__CHAR,
    mappingInfo,
    true);
 }//Test_01

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_01n()
 {
  // public RelationalTypeMappingInfo(
  //     [NotNull] Type type,
  //     [CanBeNull] string storeTypeNameBase = null,
  //     [CanBeNull] string storeTypeName,
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
         /*unicode*/true,
         null,
         /*rowVersion*/null,
         /*fixedLength*/null,
         null,
         null);

  Assert.IsFalse
   (mappingInfo.IsRowVersion.HasValue);

  xEFCore.Check.RelationalTypeMappingInfo__IsRowVersion
   (xEFCore.ErrSourceID.FB_Common__TypeMapping__CHAR,
    mappingInfo,
    true);
 }//Test_01n

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
         /*unicode*/true,
         null,
         /*rowVersion*/true,
         /*fixedLength*/null,
         null,
         null);

  Assert.IsTrue
   (mappingInfo.IsRowVersion.HasValue);

  try
  {
   xEFCore.Check.RelationalTypeMappingInfo__IsRowVersion
    (xEFCore.ErrSourceID.FB_Common__TypeMapping__CHAR,
     mappingInfo,
     false);
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK
    (e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__unexpected_IsRowVersion_2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_Common__TypeMapping__CHAR,
     true,
     false);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_03__err
};//class TestsFor__RelationalTypeMappingInfo__IsRowVersion

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.Check

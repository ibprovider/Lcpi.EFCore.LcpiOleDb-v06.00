////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 29.05.2018.
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.Check{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__RelationalTypeMappingInfo__ClrType

class TestsFor__RelationalTypeMappingInfo__ClrType
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
         /*unicode*/true,
         null,
         null,
         /*fixedLength*/null,
         null,
         null);

  Assert.AreSame
   (mappingInfo.ClrType,
    typeof(string));

  xEFCore.Check.RelationalTypeMappingInfo__ClrType
   (xEFCore.ErrSourceID.FB_Common__TypeMapping__CHAR,
    mappingInfo,
    typeof(string));
 }//Test_01

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_01n()
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
        (null,
         "CHAR",
         "CHAR",
         false,
         /*unicode*/true,
         null,
         null,
         /*fixedLength*/null,
         null,
         null);

  Assert.AreSame
   (mappingInfo.ClrType,
    null);

  xEFCore.Check.RelationalTypeMappingInfo__ClrType
   (xEFCore.ErrSourceID.FB_Common__TypeMapping__CHAR,
    mappingInfo,
    typeof(string));
 }//Test_01n

 //-----------------------------------------------------------------------
// [Test]
// public static void Test_02()
// {
//  // public RelationalTypeMappingInfo(
//  //     [NotNull] Type type,
//  //     [CanBeNull] string storeTypeName,
//  //     bool keyOrIndex,
//  //     bool? unicode,
//  //     int? size,
//  //     bool? rowVersion,
//  //     bool? fixedLength,
//  //     int? precision,
//  //     int? scale)
//
//
//  var mappingInfo
//   =new Microsoft.EntityFrameworkCore.Storage.RelationalTypeMappingInfo
//        (null,
//         "CHAR",
//         false,
//         /*unicode*/true,
//         null,
//         null,
//         /*fixedLength*/null,
//         null,
//         null);
//
//  Assert.IsNull
//   (mappingInfo.ClrType);
//
//  xEFCore.Check.RelationalTypeMappingInfo__ClrType
//   (xEFCore.ErrSourceID.FB_Common__TypeMapping__CHAR,
//    mappingInfo,
//    typeof(string));
// }//Test_02

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
         null,
         /*fixedLength*/null,
         null,
         null);

  Assert.AreSame
   (mappingInfo.ClrType,
    typeof(string));

  try
  {
   xEFCore.Check.RelationalTypeMappingInfo__ClrType
    (xEFCore.ErrSourceID.FB_Common__TypeMapping__CHAR,
     mappingInfo,
     typeof(int));
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK
    (e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__unexpected_ClrType_2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_Common__TypeMapping__CHAR,
     typeof(string),
     typeof(int));

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_03__err
};//class TestsFor__RelationalTypeMappingInfo__ClrType

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.Check

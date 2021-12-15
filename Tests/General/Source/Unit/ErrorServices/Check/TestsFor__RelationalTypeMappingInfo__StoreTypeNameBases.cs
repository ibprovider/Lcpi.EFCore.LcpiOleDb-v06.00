////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 29.05.2018.
using System;
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.Check{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__RelationalTypeMappingInfo__StoreTypeNameBases

class TestsFor__RelationalTypeMappingInfo__StoreTypeNameBases
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
        ("NUMERIC(2,1)",
         "NUMERIC",
         null,
         null,
         2,
         1);

  Assert.AreEqual
   ("NUMERIC",
    mappingInfo.StoreTypeNameBase);

  xEFCore.Check.RelationalTypeMappingInfo__StoreTypeNameBases
   (xEFCore.ErrSourceID.FB_Common__TypeMapping__NUMERIC,
    mappingInfo,
    "DECIMAL","NUMERIC");

  xEFCore.Check.RelationalTypeMappingInfo__StoreTypeNameBases
   (xEFCore.ErrSourceID.FB_Common__TypeMapping__NUMERIC,
    mappingInfo,
    "numeric","decimal");
 }//Test_01

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02()
 {
  var mappingInfo
   =new Microsoft.EntityFrameworkCore.Storage.RelationalTypeMappingInfo
        (typeof(Int32));

  Assert.IsNull
   (mappingInfo.StoreTypeNameBase);

  xEFCore.Check.RelationalTypeMappingInfo__StoreTypeNameBases
   (xEFCore.ErrSourceID.FB_Common__TypeMapping__NUMERIC,
    mappingInfo,
    "DECIMAL","NUMERIC");

  xEFCore.Check.RelationalTypeMappingInfo__StoreTypeNameBases
   (xEFCore.ErrSourceID.FB_Common__TypeMapping__NUMERIC,
    mappingInfo,
    "numeric","decimal");
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
        ("DECIMAL(2,1)",
         "DECIMAL",
         null,
         null,
         2,
         1);

  Assert.AreEqual
   ("DECIMAL",
    mappingInfo.StoreTypeNameBase);

  try
  {
   xEFCore.Check.RelationalTypeMappingInfo__StoreTypeNameBases
    (xEFCore.ErrSourceID.FB_Common__TypeMapping__NUMERIC,
     mappingInfo,
     "NUMERIC","CHAR");
  }
  catch(xEFCore.LcpiOleDb__DataToolException e)
  {
   CheckErrors.PrintException_OK(e);

   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(e));

   CheckErrors.CheckErrorRecord__type_mapping_err__unexpected_StoreTypeNameBase_2
    (TestUtils.GetRecord(e,0),
     CheckErrors.c_src__EFCoreDataProvider__FB_Common__TypeMapping__NUMERIC,
     "DECIMAL",
     "NUMERIC");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_03__err
};//class TestsFor__RelationalTypeMappingInfo__StoreTypeNameBases

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.Check

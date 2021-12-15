//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 17.12.2020.

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0{
////////////////////////////////////////////////////////////////////////////////
//class MasterTestData

static class MasterTestData
{
 public static class DateTime
 {
  public static class Equals_object
  {
   public static readonly System.DateTime
    TestValue__2018_10_09
     =new System.DateTime(2018,10,9);
  };//class Equals_object

  //----------------------------------------------------------------------
  public static class ExtractMinute
  {
   public static readonly System.DateTime
    TestValue__2018_10_09__13_14_15__543
     =new System.DateTime(2018,10,9,13,14,15,543);
  };//class ExtractMinute

  //----------------------------------------------------------------------
  public static class ExtractSecond
  {
   public static readonly System.DateTime
    TestValue__2018_10_09__13_14_15__543
     =new System.DateTime(2018,10,9,13,14,15,543);
  };//class ExtractSecond
 };//class DateTime

 //-----------------------------------------------------------------------
 public static class DateOnly
 {
  public static class Equals_object
  {
   public static readonly System.DateOnly
    TestValue__2018_10_09
     =new System.DateOnly(2018,10,9);
  };//class Equals_object
 };//class DateOnly

 //-----------------------------------------------------------------------

 public static class TimeSpan
 {
  public static class Common
  {
   public static readonly System.TimeSpan
    TestValue__09_15_36_1239
     =new System.TimeSpan(0,9,15,36)+new System.TimeSpan(1239*1000);

   public static readonly System.TimeSpan
    TestValue__123days__09_15_36_1239
     =new System.TimeSpan(123,9,15,36)+new System.TimeSpan(1239*1000);
  };//class Common

  public static class Equals_object
  {
   public static readonly System.TimeSpan
    TestValue__21_19_57_1234
     =new System.TimeSpan(0,21,19,57)+new System.TimeSpan(1234*1000);
  };//class Equals_object
 };//class TimeSpan
};//static class MasterTestData

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0
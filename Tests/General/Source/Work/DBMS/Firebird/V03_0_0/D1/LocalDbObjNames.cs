////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 28.09.2021.
using System;
using System.Diagnostics;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1{
////////////////////////////////////////////////////////////////////////////////
//class LocalCnHelper

static class LocalDbObjNames
{
 public static class TEST_MODIFY_ROW_WD
 {
  public const string Name
   ="TEST_MODIFY_ROW_WD";

  public static class Columns
  {
   public const string COL_for_TimeSpan
    ="COL_TIMESPAN_D1";
  };//class Columns
 };//class TEST_MODIFY_ROW_WD

 public static class TEST_MODIFY_ROW2
 {
  public const string Name
   ="TEST_MODIFY_ROW2";

  public static class Columns
  {
   public const string COL_for_TimeSpan
    ="COL_TIMESPAN_D1";

   public const string COL2_for_TimeSpan
    ="COL2_TIMESPAN_D1";
  };//class Columns
 };//class TEST_MODIFY_ROW2
};//class LocalDbObjNames

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1

////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 07.07.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DataTypes.Extensions{
////////////////////////////////////////////////////////////////////////////////
//class System_DateOnly

public static class System_DateOnly
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.DataTypes_Extensions__System_DateOnly;

 //-----------------------------------------------------------------------
 public static Nullable<System.DateOnly> AddYears(this System.DateOnly obj,
                                                  Nullable<Int32>      value)
 {
  Debug.Assert(false);

  ThrowError.InvalidOp__DirectCallOfLinqMethodNotAllowed
   (c_ErrSrcID,
    "AddYears(this System.DateOnly,Nullable<System.Int32>)");

  Debug.Assert(false);

  return null;
 }//AddYears

 //-----------------------------------------------------------------------
 public static Nullable<System.DateOnly> AddMonths(this System.DateOnly obj,
                                                   Nullable<Int32>      value)
 {
  Debug.Assert(false);

  ThrowError.InvalidOp__DirectCallOfLinqMethodNotAllowed
   (c_ErrSrcID,
    "AddMonths(this System.DateOnly,Nullable<System.Int32>)");

  Debug.Assert(false);

  return null;
 }//AddMonths

 //-----------------------------------------------------------------------
 public static Nullable<System.DateOnly> AddDays(this System.DateOnly obj,
                                                 Nullable<Int32>      value)
 {
  Debug.Assert(false);

  ThrowError.InvalidOp__DirectCallOfLinqMethodNotAllowed
   (c_ErrSrcID,
    "AddDays(this System.DateOnly,Nullable<System.Int32>)");

  Debug.Assert(false);

  return null;
 }//AddDays

 //-----------------------------------------------------------------------
 public static int ExtractYear(this System.DateOnly obj)
 {
  // [2020-11-08] Tested.

  Debug.Assert(false);

  ThrowError.InvalidOp__DirectCallOfLinqMethodNotAllowed
   (c_ErrSrcID,
    "ExtractYear(this System.DateOnly)");

  Debug.Assert(false);

  return 0;
 }//ExtractYear

 //-----------------------------------------------------------------------
 public static int ExtractMonth(this System.DateOnly obj)
 {
  // [2020-11-08] Tested.

  Debug.Assert(false);

  ThrowError.InvalidOp__DirectCallOfLinqMethodNotAllowed
   (c_ErrSrcID,
    "ExtractMonth(this System.DateOnly)");

  Debug.Assert(false);

  return 0;
 }//ExtractMonth

 //-----------------------------------------------------------------------
 public static int ExtractDay(this System.DateOnly obj)
 {
  // [2020-11-08] Tested.

  Debug.Assert(false);

  ThrowError.InvalidOp__DirectCallOfLinqMethodNotAllowed
   (c_ErrSrcID,
    "ExtractDay(this System.DateOnly)");

  Debug.Assert(false);

  return 0;
 }//ExtractDay

 //-----------------------------------------------------------------------
 public static System.DayOfWeek ExtractDayOfWeek(this System.DateOnly obj)
 {
  // [2020-11-08] Tested.

  Debug.Assert(false);

  ThrowError.InvalidOp__DirectCallOfLinqMethodNotAllowed
   (c_ErrSrcID,
    "ExtractDayOfWeek(this System.DateOnly)");

  Debug.Assert(false);

  return 0;
 }//ExtractDayOfWeek

 //-----------------------------------------------------------------------
 public static int ExtractDayOfYear(this System.DateOnly obj)
 {
  // [2020-11-08] Tested.

  Debug.Assert(false);

  ThrowError.InvalidOp__DirectCallOfLinqMethodNotAllowed
   (c_ErrSrcID,
    "ExtractDayOfYear(this System.DateOnly)");

  Debug.Assert(false);

  return 0;
 }//ExtractDayOfYear
};//class System_DateOnly

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DataTypes.Extensions

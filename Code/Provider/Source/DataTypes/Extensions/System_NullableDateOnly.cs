////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 07.07.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DataTypes.Extensions{
////////////////////////////////////////////////////////////////////////////////

using T_SOURCE
 =System.Nullable<System.DateOnly>;

////////////////////////////////////////////////////////////////////////////////
//class System_NullableDateOnly

public static class System_NullableDateOnly
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.DataTypes_Extensions__System_NullableDateOnly;

 //-----------------------------------------------------------------------
 public static T_SOURCE AddYears(this T_SOURCE                 obj,
                                 System.Nullable<System.Int32> value)
 {
  Debug.Assert(false);

  ThrowError.InvalidOp__DirectCallOfLinqMethodNotAllowed
   (c_ErrSrcID,
    "AddYears(this Nullable<System.DateOnly>,Nullable<System.Int32>)");

  Debug.Assert(false);

   return null;
 }//AddYears

 //-----------------------------------------------------------------------
 public static T_SOURCE AddMonths(this T_SOURCE                 obj,
                                  System.Nullable<System.Int32> value)
 {
  Debug.Assert(false);

  ThrowError.InvalidOp__DirectCallOfLinqMethodNotAllowed
   (c_ErrSrcID,
    "AddMonths(this Nullable<System.DateOnly>,Nullable<System.Int32>)");

  Debug.Assert(false);

   return null;
 }//AddMonths

 //-----------------------------------------------------------------------
 public static T_SOURCE AddDays(this T_SOURCE                 obj,
                                System.Nullable<System.Int32> value)
 {
  Debug.Assert(false);

  ThrowError.InvalidOp__DirectCallOfLinqMethodNotAllowed
   (c_ErrSrcID,
    "AddDays(this Nullable<System.DateOnly>,Nullable<System.Int32>)");

  Debug.Assert(false);

   return null;
 }//AddDays

 //-----------------------------------------------------------------------
 public static System.Nullable<System.Int32> ExtractYear(this T_SOURCE obj)
 {
  Debug.Assert(false);

  ThrowError.InvalidOp__DirectCallOfLinqMethodNotAllowed
   (c_ErrSrcID,
    "ExtractYear(this Nullable<System.DateOnly>)");

  Debug.Assert(false);

  return null;
 }//ExtractYear

 //-----------------------------------------------------------------------
 public static System.Nullable<System.Int32> ExtractMonth(this T_SOURCE obj)
 {
  Debug.Assert(false);

  ThrowError.InvalidOp__DirectCallOfLinqMethodNotAllowed
   (c_ErrSrcID,
    "ExtractMonth(this Nullable<System.DateOnly>)");

  Debug.Assert(false);

  return null;
 }//ExtractMonth

 //-----------------------------------------------------------------------
 public static System.Nullable<System.Int32> ExtractDay(this T_SOURCE obj)
 {
  Debug.Assert(false);

  ThrowError.InvalidOp__DirectCallOfLinqMethodNotAllowed
   (c_ErrSrcID,
    "ExtractDay(this Nullable<System.DateOnly>)");

  Debug.Assert(false);

  return null;
 }//ExtractDay

 //-----------------------------------------------------------------------
 public static System.Nullable<System.DayOfWeek> ExtractDayOfWeek(this T_SOURCE obj)
 {
  Debug.Assert(false);

  ThrowError.InvalidOp__DirectCallOfLinqMethodNotAllowed
   (c_ErrSrcID,
    "ExtractDayOfWeek(this Nullable<System.DateOnly>)");

  Debug.Assert(false);

  return null;
 }//ExtractDayOfWeek

 //-----------------------------------------------------------------------
 public static System.Nullable<System.Int32> ExtractDayOfYear(this T_SOURCE obj)
 {
  Debug.Assert(false);

  ThrowError.InvalidOp__DirectCallOfLinqMethodNotAllowed
   (c_ErrSrcID,
    "ExtractDayOfYear(this Nullable<System.DateOnly>)");

  Debug.Assert(false);

  return null;
 }//ExtractDayOfYear
};//class System_NullableDateOnly

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DataTypes.Extensions

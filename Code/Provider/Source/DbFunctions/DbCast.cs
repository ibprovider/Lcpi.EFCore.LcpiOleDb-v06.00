////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 13.11.2018.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DbFunctions{
////////////////////////////////////////////////////////////////////////////////
//class DbCast

public static class DbCast
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.DbFunctions__DbCast;

 //-----------------------------------------------------------------------
 public static Nullable<Int32> AsInteger(object v)
 {
  // [2020-11-08] Tested.

  Debug.Assert(false);

  ThrowError.InvalidOp__DirectCallOfLinqMethodNotAllowed
   (c_ErrSrcID,
    "AsInteger");

  Debug.Assert(false);

  return null;
 }//AsInteger

 //-----------------------------------------------------------------------
 public static Nullable<Int64> AsBigInt(object v)
 {
  // [2021-09-22] Tested.

  Debug.Assert(false);

  ThrowError.InvalidOp__DirectCallOfLinqMethodNotAllowed
   (c_ErrSrcID,
    "AsBigInt");

  Debug.Assert(false);

  return null;
 }//AsBigInt

 //-----------------------------------------------------------------------
 public static Nullable<Double> AsDouble(object v)
 {
  // [2020-11-08] Tested.

  Debug.Assert(false);

  ThrowError.InvalidOp__DirectCallOfLinqMethodNotAllowed
   (c_ErrSrcID,
    "AsDouble");

  Debug.Assert(false);

  return null;
 }//AsDouble
};//class DbCast

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DbFunctions

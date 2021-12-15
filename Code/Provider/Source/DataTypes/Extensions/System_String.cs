////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 12.10.2018.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DataTypes.Extensions{
////////////////////////////////////////////////////////////////////////////////
//class System_String

public static class System_String
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.DataTypes_Extensions__System_String;

 //-----------------------------------------------------------------------
 public static System.String Substring(this System.String obj,
                                       Nullable<Int64>    startIndex)
 {
  // [2020-11-08] Tested.

  Debug.Assert(false);

  ThrowError.InvalidOp__DirectCallOfLinqMethodNotAllowed
   (c_ErrSrcID,
    "Substring(this System.String,Nullable<System.Int64>)");

  return null;
 }//Substring - startIndex

 //-----------------------------------------------------------------------
 public static System.String Substring(this System.String obj,
                                       Nullable<Int64>    startIndex,
                                       Nullable<Int64>    length)
 {
  // [2020-11-08] Tested.

  Debug.Assert(false);

  ThrowError.InvalidOp__DirectCallOfLinqMethodNotAllowed
   (c_ErrSrcID,
    "Substring(this System.String,Nullable<System.Int64>,Nullable<System.Int64>)");

  return null;
 }//Substring - startIndex, length
};//class System_String

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DataTypes.Extensions

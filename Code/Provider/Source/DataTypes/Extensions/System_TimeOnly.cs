////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 19.07.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DataTypes.Extensions{
////////////////////////////////////////////////////////////////////////////////
//class System_TimeOnly

public static class System_TimeOnly
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.DataTypes_Extensions__System_TimeOnly;

 //-----------------------------------------------------------------------
 public static Nullable<System.TimeOnly> Add(this System.TimeOnly             obj,
                                             System.Nullable<System.TimeSpan> value)
 {
  Debug.Assert(false);

  ThrowError.InvalidOp__DirectCallOfLinqMethodNotAllowed
   (c_ErrSrcID,
    "Add(this System.TimeOnly,Nullable<System.TimeSpan>)");

  Debug.Assert(false);

  return null;
 }//Add

 //-----------------------------------------------------------------------
 public static Nullable<System.TimeOnly> AddHours(this System.TimeOnly           obj,
                                                  System.Nullable<System.Double> value)
 {
  Debug.Assert(false);

  ThrowError.InvalidOp__DirectCallOfLinqMethodNotAllowed
   (c_ErrSrcID,
    "AddHours(this System.TimeOnly,Nullable<System.Double>)");

  Debug.Assert(false);

  return null;
 }//AddHours

 //-----------------------------------------------------------------------
 public static Nullable<System.TimeOnly> AddMinutes(this System.TimeOnly           obj,
                                                    System.Nullable<System.Double> value)
 {
  Debug.Assert(false);

  ThrowError.InvalidOp__DirectCallOfLinqMethodNotAllowed
   (c_ErrSrcID,
    "AddMinutes(this System.TimeOnly,Nullable<System.Double>)");

  Debug.Assert(false);

  return null;
 }//AddMinutes

 //-----------------------------------------------------------------------
 public static Nullable<System.Boolean> IsBetween(this System.TimeOnly             obj,
                                                  System.Nullable<System.TimeOnly> start,
                                                  System.Nullable<System.TimeOnly> end)
 {
  Debug.Assert(false);

  ThrowError.InvalidOp__DirectCallOfLinqMethodNotAllowed
   (c_ErrSrcID,
    "IsBetween(this System.TimeOnly,Nullable<System.TimeOnly>,Nullable<System.TimeOnly>)");

  Debug.Assert(false);

  return null;
 }//IsBetween
};//class System_TimeOnly

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DataTypes.Extensions

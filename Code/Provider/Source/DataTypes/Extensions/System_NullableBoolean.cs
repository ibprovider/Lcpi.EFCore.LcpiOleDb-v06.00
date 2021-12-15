////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 30.08.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DataTypes.Extensions{
////////////////////////////////////////////////////////////////////////////////

using T_SOURCE
 =System.Nullable<System.Boolean>;

////////////////////////////////////////////////////////////////////////////////
//class System_NullableBoolean

public static class System_NullableBoolean
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.DataTypes_Extensions__System_NullableBoolean;

 //-----------------------------------------------------------------------
 public static System.Nullable<System.Boolean>
                 GetValueOrDefault(this T_SOURCE                   obj,
                                   System.Nullable<System.Boolean> defaultValue)
 {
  Debug.Assert(false);

  ThrowError.InvalidOp__DirectCallOfLinqMethodNotAllowed
   (c_ErrSrcID,
    "GetValueOrDefault(this Nullable<System.Boolean>,Nullable<System.Boolean>)");

  Debug.Assert(false);

  return false;
 }//GetValueOrDefault
};//class System_NullableBoolean

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DataTypes.Extensions

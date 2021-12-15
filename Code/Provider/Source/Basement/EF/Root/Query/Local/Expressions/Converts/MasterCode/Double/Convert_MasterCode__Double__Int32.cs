////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 05.06.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.MasterCode{
////////////////////////////////////////////////////////////////////////////////

using T_SOURCE
 =System.Double;

using T_TARGET
 =System.Int32;

////////////////////////////////////////////////////////////////////////////////
//class Convert_MasterCode__Double__Int32

static class Convert_MasterCode__Double__Int32
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Root_Query_Local_Expressions__Cvt_MasterCode__Double__Int32;

 //-----------------------------------------------------------------------
 public static T_TARGET Exec(T_SOURCE v)
 {
  Debug.Assert(((T_TARGET)( 0.9D))==((T_TARGET)0));
  Debug.Assert(((T_TARGET)(-0.9D))==((T_TARGET)0));

  var v2=System.Math.Truncate(v);

  if(v2<T_TARGET.MinValue || T_TARGET.MaxValue<v2)
  {
   ThrowError.FailedToConvertValueBetweenTypes__overflow
    (c_ErrSrcID,
     /*source*/typeof(T_SOURCE),
     /*target*/typeof(T_TARGET),
     /*innerException*/null);
  }//if

  return (T_TARGET)v2;
 }//Exec
};//class Convert_MasterCode__Double__Int32

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.MasterCode
